Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports System.Text
Imports System.Web
Imports Newtonsoft.Json
Imports EO.WebBrowser
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class frmPagoEcommApi


    Public Sub New(ByVal oResponse As Dictionary(Of String, Object), ByVal configEcomm As ConfigEcomm, ByVal Vendedor As String, ByVal nombrePlayer As String, ByVal numPedido As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        responseEcomm = oResponse
        configEcommerce = configEcomm
        urlServicio = oConfigCierreFI.ServicioEcomm
        method = "dpvale"
        player = Vendedor
        NombrePlayers = nombrePlayer
        NumPedidos = numPedido
        respondeApi = Nothing
        Dim url As String = ConcatenarParametros(responseEcomm, configEcommerce)
        Console.WriteLine("URL: " & url)
        webApiEcomm.WebView.Url = urlServicio & "/" & method & "?" & url

    End Sub
#Region "Propiedades"
    Dim responseEcomm As Dictionary(Of String, Object)
    Dim configEcommerce As ConfigEcomm
    Dim urlServicio As String = ""
    Dim method As String = ""
    Dim player As String = ""
    Dim NombrePlayers As String = ""
    Dim NumPedidos As String = ""
    'Dim pedido As String = ""
    Dim respondeApi As Dictionary(Of String, Object)


    Public Property Response As Dictionary(Of String, Object)
        Get
            Return respondeApi
        End Get
        Set(value As Dictionary(Of String, Object))
            respondeApi = value
        End Set
    End Property
#End Region

#Region "Formateo de datos para url"
    Private Function ConcatenarParametros(ByVal oResponse As Dictionary(Of String, Object), ByVal configEcomm As ConfigEcomm) As String

        Dim strReturn As String = String.Empty
        Dim ParamConcatenados As StringBuilder = Nothing

        If Not oResponse Is Nothing Then

            'Contruimos el objeto para concatenar los parametros (Nombre y Valor)
            ParamConcatenados = New StringBuilder()
            ParamConcatenados.Append("plataforma=aptos&")
            ParamConcatenados.Append("monto=" & HttpUtility.UrlEncode(oResponse("total")))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("tienda=" & HttpUtility.UrlEncode(configEcomm.Tienda))
            ParamConcatenados.Append("&")
            'R-M-G Nov2019 se agrega el número de player pedido y se agrega parámetro de nombre player
            ParamConcatenados.Append("vendedor=" & HttpUtility.UrlEncode(player))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("pedido=" & HttpUtility.UrlEncode(NumPedidos))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("nombre_vendedor=" & HttpUtility.UrlEncode(NombrePlayers))
            ParamConcatenados.Append("&")
            'ParamConcatenados.Append("pedido=" & HttpUtility.UrlEncode(pedido))
            'ParamConcatenados.Append("&")
            ParamConcatenados.Append("nombre=" & HttpUtility.UrlEncode(configEcomm.Nombre))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("calle_numero=" & HttpUtility.UrlEncode(configEcomm.CalleNum))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("colonia=" & HttpUtility.UrlEncode(configEcomm.Colonia))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("cp=" & HttpUtility.UrlEncode(configEcomm.CP))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("telefono=" & HttpUtility.UrlEncode(configEcomm.Telefono))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("ciudad=" & HttpUtility.UrlEncode(configEcomm.Ciudad))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("estado=" & HttpUtility.UrlEncode(configEcomm.Estado))
            ParamConcatenados.Append("&")
            ParamConcatenados.Append("productos=")
            'ParamConcatenados.Append("&")
            'Items de la venta, separado por pipes "|": Sku, Cantidad, Precio unitario, Monto, Descuento, VtaEmpleado.
            Dim primerProducto As Boolean = True
            For Each product As Object In oResponse("DatosOrden")
                If primerProducto = False Then
                    ParamConcatenados.Append("|")
                End If
                primerProducto = False
                ParamConcatenados.Append(HttpUtility.UrlEncode(CStr(product("partNumber"))) & ",")
                ParamConcatenados.Append(HttpUtility.UrlEncode(CStr(product("quantity"))) & ",")
                ParamConcatenados.Append(HttpUtility.UrlEncode(CStr(product("orderItemPrice"))) & ",")
                Dim monto As Integer = CInt(product("orderItemPrice")) + CInt(product("shippingCharge"))
                ParamConcatenados.Append(HttpUtility.UrlEncode(CStr(monto)) & ",")
                ParamConcatenados.Append(HttpUtility.UrlEncode("0") & ",")
                ParamConcatenados.Append(HttpUtility.UrlEncode(CStr(monto)))
            Next

        End If

        'Obtenemos los parametros concatenados
        If Not oResponse Is Nothing Then strReturn = ParamConcatenados.ToString

        Return strReturn

    End Function
#End Region

    Private Sub frmPagoEcommApi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        webApiEcomm.WebView.RegisterJSExtensionFunction("RespuestaApi", New JSExtInvokeHandler(AddressOf WebView_JSEcommApi))
        webApiEcomm.WebView.RegisterJSExtensionFunction("ImprimeJson", New JSExtInvokeHandler(AddressOf ImprimirJson))
    End Sub

    'Extension handler function RespuestaApi
    Private Sub WebView_JSEcommApi(sender As Object, e As JSExtInvokeArgs)
        Try
            Dim rspApi As String = TryCast(e.Arguments(0), String)
            'Console.WriteLine(rspApi)
            'Dim respApi As String = "{CA: '100615',  Fecha_venc: '2021-08-29 12:27:00',  FormaDePago: 'DPVale',  HTML_T: '',  Informativo: '',  Msg: 'Venta almacenada',  No_tarjeta: 'XXXXXXXXX5734',  Status: 1}"
            respondeApi = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rspApi)
            ImprimirPagare(respondeApi)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pago Ecommerce", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.Message, "Error caja de pagos")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        
    End Sub

    Private Sub ImprimirJson(sender As Object, e As JSExtInvokeArgs)
        Try
            Dim rspApi As String = TryCast(e.Arguments(0), String)
            'Console.WriteLine(rspApi)
            'Dim respApi As String = "{CA: '100615',  Fecha_venc: '2021-08-29 12:27:00',  FormaDePago: 'DPVale',  HTML_T: '',  Informativo: '',  Msg: 'Venta almacenada',  No_tarjeta: 'XXXXXXXXX5734',  Status: 1}"
            respondeApi = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rspApi)
            ImprimirPagare(respondeApi)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pago Ecommerce", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.Message, "Error caja de pagos")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try

    End Sub

    Private Sub frmPagoEcommApi_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub UiButton1_Click(sender As System.Object, e As System.EventArgs) Handles UiButton1.Click

        If MessageBox.Show("No se ha efectuado el pago." & vbCrLf & "¿Está seguro de que desea cancelar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            respondeApi = Nothing
            ''respondeApi = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(File.ReadAllText("compra.txt"))
            ''ImprimirPagare(respondeApi)
            Me.Close()
        End If

    End Sub

    Private Sub UiButton2_Click(sender As System.Object, e As System.EventArgs)
        If respondeApi IsNot Nothing Then
            'Dim html As String = "&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n&lt;tbody&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;COMERCIAL D'PORTENIS, S.A. DE C.V.&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Matriz:&amp;nbsp;Melchor Ocampo #1005 Centro&amp;nbsp;&amp;nbsp;Mazatl&amp;aacute;n, Sin.&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;SUCURSAL:&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;09/05/2019 11:25:48&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;DPVALE&lt;/strong&gt; (0022207518)&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp; 4&amp;nbsp;&lt;strong&gt;QUINCENAS&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;ACREDITADO&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;ANA CRISTINA SARABIA MARTINEZ&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;(0070085614)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;CANJEANTE&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN (90265351)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Monto Total: $577.60&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;FIRMA ________________________&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;PAGOS QUINCENALES DE $&lt;/strong&gt;&amp;nbsp;156&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;EMPIEZA A PAGAR EL:&lt;/strong&gt;&amp;nbsp;2019-05-31&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 20px;&quot;&gt;\r\n&lt;td style=&quot;height: 20px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&lt;!-- pagebreak --&gt;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;/tbody&gt;\r\n&lt;/table&gt;\r\n\r\n&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n  &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n     &lt;td style=&quot;width: 56.9364%; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Plaza: &lt;/strong&gt;MZT&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Expedido en:&amp;nbsp;&lt;/strong&gt;Aquiles Serdan&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;TICKET DE VENTA&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Caja: &lt;/strong&gt;1&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Fecha:&amp;nbsp;&lt;/strong&gt;09/05/2019&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; text-align: right; height: 15px;&quot;&gt;&lt;strong&gt;Hora:&amp;nbsp;&lt;/strong&gt;11:25:48&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 15px;&quot; colspan=&quot;2&quot;&gt;**&amp;iexcl;AHORA ESTAS PROTEGIDO!**&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Estas disfrutando del beneficio exclusivo que Ramirez Miramontes y Asociados S.A. de C.V. /SegurosAfirmeS.A.deC.V.,Afirme grupo Financiero brinda a sus clientes y hace de su conocimiento que sus datos personales recabados se trataran para todos los fines vinculados con la relaci&amp;oacute;n jur&amp;iacute;dica celebrada.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;No. Certificado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;0300457808&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Asegurado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN &lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;RFC:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;XAXX010101XXX&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Sexo:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;Femenino&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Por solo $12.00 quincenales con un total de $48, tu suma asegurada por fallecimiento es de $50000 M.N. con vigencia del 2019-05-09 hasta 2019-07-15. Con edades de aceptaci&amp;oacute;n de 18 hasta 70 a&amp;ntilde;os de edad.No cubre fallecimiento por homicidio intencional ni por suicidio.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Consentimiento-Certificado de Seguro de Vida&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;No. P&amp;oacute;liza:&amp;nbsp;&lt;/strong&gt;005-000035282-00&lt;strong&gt;&lt;br /&gt;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 69px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 69px;&quot; colspan=&quot;2&quot;&gt;Beneficiario Preferente: Comercial D&amp;acute;Portenis,S.A.deC.V. hasta el saldo adeudado al momento del fallecimiento y el remanente a favor del beneficiario.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Beneficiario: &lt;/strong&gt;prueba prueba prueba, Padre - 10%&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 158px;&quot; colspan=&quot;2&quot;&gt;Consulta tus condiciones y aviso integro en: &lt;a href=&quot;http://www.excelenciaseguros.com&quot;&gt;www.excelenciaseguros.com&lt;/a&gt;, para mayor informaci&amp;oacute;n sobre la renovaci&amp;oacute;n o cancelaci&amp;oacute;n de la p&amp;oacute;liza favor de comunicarse a los tel&amp;eacute;fonos 018000018989 y 01333826 1833, donde tambi&amp;eacute;n podr&amp;aacute; conocer la documentaci&amp;oacute;n necesaria para cobrar el seguro de vida y que hacer en caso de siniestro.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;height: 158px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;Constar mi consentimiento para formar parte del grupo asegurado en la p&amp;oacute;liza de referencia, as&amp;iacute; como para que las condiciones generales de la p&amp;oacute;liza, y que entre otras cosas contiene los derechos y obligaciones a mi cargo, me sean entregadas atrav&amp;eacute;s de mi correo electr&amp;oacute;nico:________________ mismas que estar&amp;aacute;n disponibles en todo momento para su consulta en www.excelenciaseguros.com&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n&lt;/table&gt;\r\n"
            'Dim htmlContent As String = HttpUtility.HtmlDecode(html.Replace("\r\n", ""))
            If CStr(respondeApi("HTML_R")) <> String.Empty Then
                '----------------------------------------------------------------------------------------------------------
                'Carga de pagare para impresión
                '----------------------------------------------------------------------------------------------------------
                Dim htmlContent As String = HttpUtility.HtmlDecode(CStr(respondeApi("HTML_R")).Replace("\r\n", ""))
                webticket.WebView.LoadHtmlAndWait(htmlContent)
                Dim sp As Printing.PrinterSettings = New Printing.PrinterSettings()
                Dim ps As Printing.PageSettings = New Printing.PageSettings()
                'sp.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                With ps

                    .Margins.Left = 0
                    .Margins.Right = 0
                    .Margins.Top = 0
                    .Margins.Bottom = 0
                    .PaperSource = sp.PaperSources.Item(0)
                End With

                webticket.WebView.Print(sp, ps)
            End If
            If CStr(respondeApi("HTML_T")) <> String.Empty Then

                '----------------------------------------------------------------------------------------------------------
                'Carga de tikcet para impresión
                '----------------------------------------------------------------------------------------------------------
                Dim htmlContent As String = HttpUtility.HtmlDecode(CStr(respondeApi("HTML_T")).Replace("\r\n", ""))
                WebControl1.WebView.LoadHtmlAndWait(htmlContent)
                Dim spT As Printing.PrinterSettings = New Printing.PrinterSettings()
                Dim psT As Printing.PageSettings = New Printing.PageSettings()
                spT.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                With psT

                    .Margins.Left = 0
                    .Margins.Right = 0
                    .Margins.Top = 0
                    .Margins.Bottom = 0
                    .PaperSource = spT.PaperSources.Item(0)
                End With

                WebControl1.WebView.Print(spT, psT)

            End If

            Me.Close()
        Else
            MessageBox.Show("No se tiene una respuesta para poder continuar.", "Otros Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#Region "Metodos y funciones"

    Private Sub ImprimirPagare(ByVal Json As Dictionary(Of String, Object))
        If Json IsNot Nothing Then
            'Dim html As String = "&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n&lt;tbody&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;COMERCIAL D'PORTENIS, S.A. DE C.V.&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Matriz:&amp;nbsp;Melchor Ocampo #1005 Centro&amp;nbsp;&amp;nbsp;Mazatl&amp;aacute;n, Sin.&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;SUCURSAL:&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;09/05/2019 11:25:48&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;DPVALE&lt;/strong&gt; (0022207518)&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp; 4&amp;nbsp;&lt;strong&gt;QUINCENAS&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 56.9364%; height: 15px;&quot; width=&quot;165&quot;&gt;&lt;strong&gt;ACREDITADO&lt;/strong&gt;&lt;/td&gt;\r\n&lt;td style=&quot;width: 42.7746%; height: 15px;&quot; width=&quot;122&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;ANA CRISTINA SARABIA MARTINEZ&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;(0070085614)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;CANJEANTE&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN (90265351)&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;Monto Total: $577.60&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;FIRMA ________________________&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;PAGOS QUINCENALES DE $&lt;/strong&gt;&amp;nbsp;156&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot; width=&quot;287&quot;&gt;&lt;strong&gt;EMPIEZA A PAGAR EL:&lt;/strong&gt;&amp;nbsp;2019-05-31&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 20px;&quot;&gt;\r\n&lt;td style=&quot;height: 20px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&lt;!-- pagebreak --&gt;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;tr style=&quot;height: 15px;&quot;&gt;\r\n&lt;td style=&quot;height: 15px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n&lt;/tr&gt;\r\n&lt;/tbody&gt;\r\n&lt;/table&gt;\r\n\r\n&lt;table style=&quot;width: 50%; border-collapse: collapse; margin-right: auto;&quot; border=&quot;0&quot;&gt;\r\n  &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n     &lt;td style=&quot;width: 56.9364%; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Plaza: &lt;/strong&gt;MZT&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Expedido en:&amp;nbsp;&lt;/strong&gt;Aquiles Serdan&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: left;&quot; colspan=&quot;2&quot;&gt;Aquiles Serdan s/n, Col. Centro&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px; text-align: center;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;TICKET DE VENTA&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Caja: &lt;/strong&gt;1&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Fecha:&amp;nbsp;&lt;/strong&gt;09/05/2019&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; text-align: right; height: 15px;&quot;&gt;&lt;strong&gt;Hora:&amp;nbsp;&lt;/strong&gt;11:25:48&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 15px;&quot; colspan=&quot;2&quot;&gt;**&amp;iexcl;AHORA ESTAS PROTEGIDO!**&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Estas disfrutando del beneficio exclusivo que Ramirez Miramontes y Asociados S.A. de C.V. /SegurosAfirmeS.A.deC.V.,Afirme grupo Financiero brinda a sus clientes y hace de su conocimiento que sus datos personales recabados se trataran para todos los fines vinculados con la relaci&amp;oacute;n jur&amp;iacute;dica celebrada.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;No. Certificado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;0300457808&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Asegurado:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;FRANCISCO JAVIER ROJO GOLDEN &lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;RFC:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;XAXX010101XXX&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;Sexo:&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;Femenino&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 122px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 122px;&quot; colspan=&quot;2&quot;&gt;Por solo $12.00 quincenales con un total de $48, tu suma asegurada por fallecimiento es de $50000 M.N. con vigencia del 2019-05-09 hasta 2019-07-15. Con edades de aceptaci&amp;oacute;n de 18 hasta 70 a&amp;ntilde;os de edad.No cubre fallecimiento por homicidio intencional ni por suicidio.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; text-align: center; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Consentimiento-Certificado de Seguro de Vida&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;No. P&amp;oacute;liza:&amp;nbsp;&lt;/strong&gt;005-000035282-00&lt;strong&gt;&lt;br /&gt;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 69px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 69px;&quot; colspan=&quot;2&quot;&gt;Beneficiario Preferente: Comercial D&amp;acute;Portenis,S.A.deC.V. hasta el saldo adeudado al momento del fallecimiento y el remanente a favor del beneficiario.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 33px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 33px;&quot; colspan=&quot;2&quot;&gt;&lt;strong&gt;Beneficiario: &lt;/strong&gt;prueba prueba prueba, Padre - 10%&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 158px;&quot; colspan=&quot;2&quot;&gt;Consulta tus condiciones y aviso integro en: &lt;a href=&quot;http://www.excelenciaseguros.com&quot;&gt;www.excelenciaseguros.com&lt;/a&gt;, para mayor informaci&amp;oacute;n sobre la renovaci&amp;oacute;n o cancelaci&amp;oacute;n de la p&amp;oacute;liza favor de comunicarse a los tel&amp;eacute;fonos 018000018989 y 01333826 1833, donde tambi&amp;eacute;n podr&amp;aacute; conocer la documentaci&amp;oacute;n necesaria para cobrar el seguro de vida y que hacer en caso de siniestro.&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 56.9364%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;td style=&quot;width: 42.7746%; height: 15px;&quot;&gt;&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 158px;&quot;&gt;\r\n   &lt;td style=&quot;height: 158px; width: 99.711%;&quot; colspan=&quot;2&quot;&gt;Constar mi consentimiento para formar parte del grupo asegurado en la p&amp;oacute;liza de referencia, as&amp;iacute; como para que las condiciones generales de la p&amp;oacute;liza, y que entre otras cosas contiene los derechos y obligaciones a mi cargo, me sean entregadas atrav&amp;eacute;s de mi correo electr&amp;oacute;nico:________________ mismas que estar&amp;aacute;n disponibles en todo momento para su consulta en www.excelenciaseguros.com&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n   &lt;tr style=&quot;height: 15px;&quot;&gt;\r\n   &lt;td style=&quot;width: 99.711%; height: 15px;&quot; colspan=&quot;2&quot;&gt;&amp;nbsp;&lt;/td&gt;\r\n   &lt;/tr&gt;\r\n&lt;/table&gt;\r\n"
            'Dim htmlContent As String = HttpUtility.HtmlDecode(html.Replace("\r\n", ""))
            If CStr(Json("HTML_R")) <> String.Empty Then
                '----------------------------------------------------------------------------------------------------------
                'Carga de pagare para impresión
                '----------------------------------------------------------------------------------------------------------
                Dim htmlContent As String = HttpUtility.HtmlDecode(CStr(Json("HTML_R")).Replace("\r\n", ""))
                webticket.WebView.LoadHtmlAndWait(htmlContent)

                Dim sp As Printing.PrinterSettings = New Printing.PrinterSettings()
                Dim ps As Printing.PageSettings = New Printing.PageSettings()
                'sp.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                If oConfigCierreFI.ImpresoraEcommerce.Trim() <> "" Then
                    sp.PrinterName = oConfigCierreFI.ImpresoraEcommerce
                End If
                With ps

                    .Margins.Left = 0
                    .Margins.Right = 0
                    .Margins.Top = 0
                    .Margins.Bottom = 0
                    .PaperSource = sp.PaperSources.Item(0)
                End With

                webticket.WebView.Print(sp, ps)
                webticket.WebView.LoadHtmlAndWait(htmlContent)
            End If
            If Json.ContainsKey("HTML_T") Then
                '----------------------------------------------------------------------------------------------------------
                'Carga de tikcet para impresión
                '----------------------------------------------------------------------------------------------------------
                Dim lstTickets As New List(Of String)
                Dim contenido As String = ""
                lstTickets = JsonConvert.DeserializeObject(Of List(Of String))(CType(Json("HTML_T"), JArray).ToString())
                For Each ticket As String In lstTickets
                    contenido = HttpUtility.HtmlDecode(ticket).Replace("\r\n", "")

                    webticket.WebView.LoadHtmlAndWait(contenido)
                    'webticket.WebView.Print()
                    Dim spT As Printing.PrinterSettings = New Printing.PrinterSettings()
                    Dim psT As Printing.PageSettings = New Printing.PageSettings()

                    spT.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    With psT

                        .Margins.Left = 0
                        .Margins.Right = 0
                        .Margins.Top = 0
                        .Margins.Bottom = 0
                        .PaperSource = spT.PaperSources.Item(0)
                    End With

                    webticket.WebView.Print(spT, psT)
                    webticket.WebView.LoadHtmlAndWait(contenido)
                Next
                'Dim htmlContent As String = HttpUtility.HtmlDecode(CStr(Json("HTML_T")).Replace("\r\n", ""))

                'webticket.WebView.LoadHtmlAndWait(htmlContent)
                ''webticket.WebView.Print()
                'Dim spT As Printing.PrinterSettings = New Printing.PrinterSettings()
                'Dim psT As Printing.PageSettings = New Printing.PageSettings()

                'spT.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                'With psT

                '    .Margins.Left = 0
                '    .Margins.Right = 0
                '    .Margins.Top = 0
                '    .Margins.Bottom = 0
                '    .PaperSource = spT.PaperSources.Item(0)
                'End With

                'webticket.WebView.Print(spT, psT)
                'webticket.WebView.LoadHtmlAndWait(htmlContent)
            End If
            'If CStr(Json("HTML_T")) <> String.Empty Then

            'End If

            Me.Close()
        Else
            MessageBox.Show("No se tiene una respuesta para poder continuar.", "Otros Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

End Class