Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports System.Collections.Generic
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Public Class frmConsignacion

#Region "Variables"

    Private oVendedoresMgr As CatalogoVendedoresManager
    Private oVendedor As Vendedor
    Private AlmacenMgr As CatalogoAlmacenesManager
    Private Almacen As Almacen
    Private ArticuloMgr As CatalogoArticuloManager
    Private Articulo As Articulo
    Private oSAPMgr As ProcesoSAPManager
    Private oCatalogoUPCMgr As CatalogoUPCManager
    Private oFacturaMgr As FacturaManager
    Private TraspasoEntradaMgr As TraspasosEntradaManager
    Private TipoConsignacion As TrasladoConsignacion
    Private dtTrasladoDetalle As DataTable
    Private dtPedido As DataTable
    Private strline As String = ""
    Private lstZDpro As List(Of ZdproPedidos)
    Private EsConSerie As Boolean = False
    Private Usuario As String
    Private TraspasoEntradaId As Integer = 0
    Private TraspasoSalidaId As Integer = 0
    Private frmMainForm As MainForm

#End Region

#Region "Constructores"

    Public Sub New(ByVal TipoConsignacion As Integer, ByVal Usuario As String, ByVal frmMainForm As MainForm)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.frmMainForm = frmMainForm
        Me.TipoConsignacion = TipoConsignacion
        Me.Usuario = Usuario
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Inicializar()
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub Inicializar()
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        AlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        ArticuloMgr = New CatalogoArticuloManager(oAppContext)
        TraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oVendedor = oVendedoresMgr.Create()
        Articulo = ArticuloMgr.Create()
        Almacen = AlmacenMgr.Create()
        AlmacenMgr.LoadInto(oSAPMgr.Read_Centros(), Almacen)
        txtCodAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen
        txtAlmacenDescr.Text = Almacen.Descripcion
        txtFecha.Value = oSAPMgr.MSS_GET_SY_DATE_TIME()
    End Sub

    Private Sub Nuevo()
        Me.dtPedido = Nothing
        Me.dtTrasladoDetalle = Nothing
        txtCodProveedor.Text = ""
        txtProveedorDesc.Text = ""
        txtPlayer.Text = ""
        txtPlayerDescripcion.Text = ""
        txtNoPedido.Text = ""
        txtReferencia.Text = ""
        txtFecha.Value = DateTime.Now
        txtTotalPedido.Value = 0
        txtTotalRecibido.Value = 0
        gridDetalle.DataSource = Nothing
        Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuAplicarTraslado").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuImpresion").Enabled = Janus.Windows.UI.InheritableBoolean.False
        EnableControl(True)
        Me.gridDetalle.Focus()
    End Sub

    Private Sub LoadSearchFormPlayer()
        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            If oOpenRecordDialogView.Record Is Nothing Then
                Exit Sub
            End If
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)

            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                txtPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre

            Else
                txtPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
            'End Select


        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub BuscarTraslado()
        Dim frmBuscar As New frmBuscarTrasladoConsignacion(Me.TipoConsignacion)
        If frmBuscar.ShowDialog() = DialogResult.OK Then
            dtTrasladoDetalle = frmBuscar.TrasladoDetalle
            If dtTrasladoDetalle.Rows.Count > 0 Then
                Dim CabeceraRow As DataRow = dtTrasladoDetalle.Rows(0)
                Me.txtCodProveedor.Text = CStr(CabeceraRow("LIFNR"))
                Me.txtProveedorDesc.Text = CStr(CabeceraRow("TXLFN"))
                Me.txtCodAlmacen.Text = CStr(CabeceraRow("WERKS"))
                Me.txtAlmacenDescr.Text = CStr(CabeceraRow("TXWRK"))
                Me.txtNoPedido.Text = CStr(CabeceraRow("EBELN"))
                'Me.txtReferencia.Text = CStr(CabeceraRow("LFSNR"))

                AgregarCamposTraslado(Me.dtTrasladoDetalle)

                Me.dtTrasladoDetalle.AcceptChanges()

                CargarDetallesFaltantes(Me.dtTrasladoDetalle)

                Me.gridDetalle.DataSource = Me.dtTrasladoDetalle
                Dim objRecibidas As Object = Nothing, TotalPedido As Integer = 0
                objRecibidas = dtTrasladoDetalle.Compute("SUM(MENGE)", "")
                If Not objRecibidas Is Nothing Then
                    TotalPedido = objRecibidas
                End If
                txtTotalPedido.Text = CStr(TotalPedido)
                CalcularPiezas()
                'CalcularPiezas()
                Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuAplicarTraslado").Enabled = Janus.Windows.UI.InheritableBoolean.True
                Me.gridDetalle.Focus()
            End If
        End If
    End Sub

    Private Sub AgregarCamposTraslado(ByRef dtTrasladoDetalle As DataTable)
        dtTrasladoDetalle.Columns.Add("CodArtProv", GetType(String))
        dtTrasladoDetalle.Columns.Add("Numero", GetType(String))
        dtTrasladoDetalle.Columns.Add("ERFMG", GetType(Integer))
        dtTrasladoDetalle.Columns.Add("ZTOTPED", GetType(Integer))
        dtTrasladoDetalle.Columns.Add("ZTOTREC", GetType(Integer))
        dtTrasladoDetalle.Columns.Add("MBLNR", GetType(String))
        dtTrasladoDetalle.Columns.Add("BKTXT", GetType(String))
        dtTrasladoDetalle.Columns.Add("SERNR", GetType(String))
        dtTrasladoDetalle.Columns.Add("LFSNR", GetType(String))
        dtTrasladoDetalle.Columns.Add("Faltante", GetType(Integer))
        dtTrasladoDetalle.Columns.Add("Sobrante", GetType(Integer))

        dtTrasladoDetalle.AcceptChanges()
    End Sub

    Private Sub CargarDetallesFaltantes(ByRef dtTraslado As DataTable)
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()
        Dim ArtExistencia As New Hashtable()
        For Each row As DataRow In dtTraslado.Rows
            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(CStr(row("MATNR")), oArticulo)
            'ArtExistencia = oArticuloMgr.GetExistenciaByCodigo(oArticulo.CodArticulo)
            row("CodArtProv") = oArticulo.CodArtProv
            row("Numero") = CStr(row("TALLA"))
            row("ERFMG") = 0
            row("SERNR") = ""
            row.AcceptChanges()
        Next
        dtTraslado.AcceptChanges()
    End Sub

    Private Sub CalcularPiezas()
        Dim TotalRecibidas As Integer = 0, TotalLecturadas As Integer = 0
        Dim objRecibidas As Object = Nothing
        Dim objLecturadas As Object = Nothing

        '---------------------------------------------------------------------------------------------------
        ' JNAVA (22.05.2018): Valida si ya existe el codigo para volver a sumar los recibidos
        '---------------------------------------------------------------------------------------------------
        If Not dtTrasladoDetalle Is Nothing Then
            Dim UltimoCodigo As String = String.Empty
            For Each oRowS As DataRow In dtTrasladoDetalle.Rows
                If oRowS.Item("MATNR").ToString <> UltimoCodigo Then
                    UltimoCodigo = oRowS.Item("MATNR").ToString
                    objRecibidas += CInt(oRowS!MENGE)
                End If
            Next
            TotalRecibidas = objRecibidas
        End If
        '---------------------------------------------------------------------------------------------------

        'objRecibidas = dtTrasladoDetalle.Compute("SUM(MENGE)", "")
        objLecturadas = dtTrasladoDetalle.Compute("SUM(ERFMG)", "")


        If IsDBNull(objRecibidas) = False Then
            TotalRecibidas = CInt(objRecibidas)
        End If
        If IsDBNull(objLecturadas) = False Then
            TotalLecturadas = CInt(objLecturadas)
        End If
        For Each row As DataRow In Me.dtTrasladoDetalle.Rows
            row("ZTOTPED") = TotalRecibidas
            row("ZTOTREC") = TotalRecibidas
            row.AcceptChanges()
        Next
        Me.txtTotalRecibido.Value = TotalLecturadas
        Me.dtTrasladoDetalle.AcceptChanges()
    End Sub

    Private Sub Lecturar(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter AndAlso strline.Trim() <> "" Then
            'If oCatalogoUPCMgr.IsSkuOrMaterial(strline) = "S" Then
            'Es un CodigoUPC
            'Dim dsUPC As New DataTable
            'dsUPC = oFacturaMgr.GetUPCData(strline)
            'If dsUPC.Rows.Count > 0 Then
            strline = strline.PadLeft(18, "0")
            Dim rows() As DataRow = Me.dtTrasladoDetalle.Select("EAN11='" & strline & "'")
            If rows.Length > 0 Then
                If CStr(rows(0)("NSERIE")).Trim() = "X" Then
                    AgregarNumeroSerie(rows(0))
                Else
                    rows(0)!ERFMG = CInt(rows(0)!ERFMG) + 1
                End If
                CalcularPiezas()
            End If
            strline = ""
            'Else
            '    MessageBox.Show("Material no corresponde" & vbCrLf & "UPC: " & strline & vbCrLf & "Devolver a Transportista", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
            'End If
        Else
            If e.KeyCode = 189 Then
                strline = strline & "-"
            Else
                strline = strline & Chr(e.KeyCode)
            End If
        End If
    End Sub

    Private Sub AgregarNumeroSerie(ByVal row As DataRow)
        Dim NumeroSerie As String = "", Count As Integer = 0
        NumeroSerie = InputBox("Captura Número de Serie", "Dportenis PRO")
        If NumeroSerie.Trim() <> "" Then
            Dim series() As DataRow = dtTrasladoDetalle.Select("EAN11='" & CStr(row("EAN11")) & "' AND SERNR='" & NumeroSerie & "'")
            If series.Length = 0 Then
                Dim rows() As DataRow = dtTrasladoDetalle.Select("EAN11='" & CStr(row("EAN11")) & "'", "MENGE ASC")
                If rows.Length = 1 AndAlso CStr(rows(0)!SERNR).Trim() = "" Then
                    rows(0)!SERNR = NumeroSerie
                    rows(0)!ERFMG = CInt(rows(0)!ERFMG) + 1
                    rows(0).AcceptChanges()
                ElseIf rows.Length >= 1 Then
                    If CInt(rows(0)("MENGE")) > 1 Then
                        Dim fila As DataRow = dtTrasladoDetalle.NewRow()
                        fila("MBLNR") = rows(0)("MBLNR")
                        fila("EBELN") = rows(0)("EBELN")
                        fila("LIFNR") = rows(0)("LIFNR")
                        fila("TXLFN") = rows(0)("TXLFN")
                        fila("WERKS") = rows(0)("WERKS")
                        fila("TXWRK") = rows(0)("TXWRK")
                        fila("MATNR") = rows(0)("MATNR")
                        fila("TXZ01") = rows(0)("TXZ01")
                        fila("MTART") = rows(0)("MTART")
                        fila("MENGE") = CInt(rows(0)("MENGE")) - 1
                        fila("EAN11") = rows(0)("EAN11")
                        fila("BKTXT") = rows(0)("BKTXT")
                        fila("NSERIE") = rows(0)("NSERIE")
                        fila("SERNR") = NumeroSerie
                        fila("ZTOTPED") = rows(0)("ZTOTPED")
                        fila("ZTOTREC") = rows(0)("ZTOTREC")
                        fila("ERFMG") = 1
                        fila("CodArtProv") = rows(0)("CodArtProv")
                        fila("Numero") = rows(0)("Numero")
                        Me.dtTrasladoDetalle.Rows.Add(fila)
                    Else
                        MessageBox.Show("La cantidad lecturada no puede ser mayor que el pedido", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                MessageBox.Show("No se puede agregar material con el mismo número de serie", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            dtTrasladoDetalle.AcceptChanges()
        Else
            MessageBox.Show("No se pudo agregar el artículo debido a que se cancelo la captura de número de serie", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AplicarTraslado()
        Select Case Me.TipoConsignacion
            Case TrasladoConsignacion.ORDENCOMPRA
                AplicarOrdenCompra()
            Case TrasladoConsignacion.DEVOLUCION
                AplicarDevolucionProveedor()
        End Select
    End Sub

    Private Sub AplicarOrdenCompra()
        dtPedido = AgregarDetallesValidos(Me.dtTrasladoDetalle)
        If ValidarOrdenCompra() Then
            Try
                lstZDpro = New List(Of ZdproPedidos)
                lstZDpro = GuardarZDPropedido(Me.dtPedido)
                EsConSerie = hasItemsWithSerie(Me.dtPedido)
                'If GuardarTraspasoEntrada() Then
                Dim Traspaso As New Dictionary(Of String, Object)
                Traspaso("DetallePedido") = Me.dtPedido
                Traspaso("lstZDpro") = lstZDpro
                Traspaso("TrasladoConsignacion") = Me.TipoConsignacion
                Traspaso("TraspasoEntradaId") = Me.TraspasoEntradaId
                Traspaso("TraspasoSalidaId") = Me.TraspasoSalidaId
                Traspaso("EsConSerie") = EsConSerie
                'frmMainForm.AplicarConsignacion(Traspaso)
                If SaveConsignacion(Traspaso) Then
                    PrintTraslado(Me.dtPedido)
                    'Dim async As New ProcessAs=ync()
                    'async.Execute(AddressOf SaveSAP)
                    MessageBox.Show("Se aplico correctamente el pedido de compra", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Else
                'EscribeLog("Hubo un error al generar la devolución de proveedor en DPPRO", "Traspaso Entrada Consignación")
                'MessageBox.Show("Hubo un error al generar la entrada de mercancía en DPPRO", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
                Nuevo()
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al aplicar el traslado")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub AplicarDevolucionProveedor()
        dtPedido = AgregarDetallesValidos(Me.dtTrasladoDetalle)
        If ValidarDevolucion() Then
            Try
                lstZDpro = New List(Of ZdproPedidos)
                lstZDpro = GuardarZDPropedido(Me.dtPedido)
                EsConSerie = hasItemsWithSerie(Me.dtPedido)
                'If GuardarTraspasoSalida() Then
                Dim Traspaso As New Dictionary(Of String, Object)
                Traspaso("DetallePedido") = Me.dtPedido
                Traspaso("lstZDpro") = lstZDpro
                Traspaso("TrasladoConsignacion") = Me.TipoConsignacion
                Traspaso("TraspasoEntradaId") = Me.TraspasoEntradaId
                Traspaso("TraspasoSalidaId") = Me.TraspasoSalidaId
                Traspaso("EsConSerie") = EsConSerie
                'frmMainForm.AplicarConsignacion(Traspaso)
                If SaveConsignacion(Traspaso) Then
                    PrintTraslado(Me.dtPedido)
                    'Dim async As New ProcessAsync()
                    'async.Execute(AddressOf SaveSAP)
                    MessageBox.Show("Se aplico correctamente el pedido de Devolución", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Else
                'EscribeLog("Hubo un error al generar la devolución de proveedor en DPPRO", "Traspaso Salida Consignación")
                'MessageBox.Show("Hubo un error al generar la devolución de proveedor en DPPRO", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
                Nuevo()
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al aplicar el traslado")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function ValidarOrdenCompra() As Boolean
        Dim valido As Boolean = True
        Dim msg As String = ""
        If Me.txtPlayer.Text.Trim() = "" Then
            MessageBox.Show("El código de vendedor esta vacio", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Dim dtPedidoFaltante As DataTable = Me.dtPedido.Clone()
        For Each row As DataRow In Me.dtPedido.Rows
            If CInt(row("ERFMG")) > 0 Then
                If CInt(row("ERFMG")) <> CInt(row("MENGE")) Then
                    If CInt(row("ERFMG")) > CInt(row("MENGE")) Then
                        msg &= CStr(row("MATNR")) & " Cantidad Pedido: " & CStr(row("MENGE")) & " no puede ser mayor a la cantidad Recibida: " & CStr(row("ERFMG")) & vbCrLf
                        row("Sobrante") = CInt(row("ERFMG")) - CInt(row("MENGE"))
                        row("Faltante") = 0
                        dtPedidoFaltante.ImportRow(row)
                    Else
                        msg &= CStr(row("MATNR")) & " Cantidad Pedido: " & CStr(row("MENGE")) & " es menor a la cantidad Recibida: " & CStr(row("ERFMG")) & vbCrLf
                        row("Faltante") = CInt(row("MENGE")) - CInt(row("ERFMG"))
                        row("Sobrante") = 0
                        dtPedidoFaltante.ImportRow(row)
                    End If
                End If
                row.AcceptChanges()
                'If CInt(row("ERFMG")) > CInt(row("MENGE")) Then
                '    msg &= CStr(row("MATNR")) & " Cantidad Pedido: " & CStr(row("MENGE")) & " no puede ser mayor a la cantidad Recibida: " & CStr(row("ERFMG")) & vbCrLf
                'End If
            Else
                msg &= CStr(row("MATNR")) & " esta en cero cantidad la recepción de aplicar" & vbCrLf
                MessageBox.Show(msg, "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

        Next
        Me.dtPedido.AcceptChanges()
        If ValidaCodigosEnCatalogo(Me.dtPedido) = False Then
            Return False
        End If
        If msg.Trim() <> "" Then
            If ShowFormFaltantesSobrantes(dtPedidoFaltante) = False Then
                valido = False
            Else
                AjustarPedido(Me.dtPedido)
                valido = True
            End If
            'If MessageBox.Show("Los siguientes códigos no coinciden en las cantidades" & vbCrLf & msg & "¿Deseas continuar?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            '    valido = False
            'Else
            '    AjustarPedido(Me.dtPedido)
            '    valido = True
            'End If
            'valido = False
            'MessageBox.Show("Los siguientes códigos no coinciden en las cantidades" & vbCrLf & msg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Sub AjustarPedido(ByRef dtPedido As DataTable)
        For Each row As DataRow In dtPedido.Rows
            If CInt(row("ERFMG")) > 0 Then
                If CInt(row("ERFMG")) > CInt(row("MENGE")) Then
                    row("ERFMG") = row("MENGE")
                    row.AcceptChanges()
                End If
            End If
        Next
        dtPedido.AcceptChanges()
    End Sub

    Private Function ValidarDevolucion() As Boolean
        Dim valido As Boolean = True
        Dim msg As String = ""
        If Me.txtPlayer.Text.Trim() = "" Then
            MessageBox.Show("El código de vendedor esta vacio", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        For Each row As DataRow In Me.dtPedido.Rows
            If CInt(row("ERFMG")) > 0 Then
                If CInt(row("ERFMG")) > CInt(row("MENGE")) Then
                    msg &= CStr(row("MATNR")) & " Cantidad Pedido: " & CStr(row("MENGE")) & " no puede ser mayor a la cantidad Recibida: " & CStr(row("ERFMG")) & vbCrLf
                End If
            Else
                msg &= CStr(row("EAN11")) & " esta en cero cantidad la recepción de aplicar" & vbCrLf
            End If

        Next
        If ValidaCodigosEnCatalogo(Me.dtPedido) = False Then
            Return False
        End If
        If msg.Trim() <> "" Then
            valido = False
            MessageBox.Show("Los siguientes códigos no coinciden en las cantidades" & vbCrLf & msg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Function GuardarZDPropedido(ByVal dtTrasladoDetalle As DataTable) As List(Of ZdproPedidos)
        Dim lstZdproPedido As New List(Of ZdproPedidos)
        Dim zdpro As ZdproPedidos = Nothing
        Dim Identificador As String = Guid.NewGuid().ToString()
        For Each row As DataRow In dtTrasladoDetalle.Rows
            zdpro = New ZdproPedidos(TraspasoEntradaMgr)
            zdpro.Identificador = Identificador
            zdpro.PedidoSAP = CStr(row("EBELN"))
            zdpro.Proveedor = CStr(row("LIFNR"))
            zdpro.ProveedorDesc = CStr(row("TXLFN"))
            zdpro.CodAlmacen = CStr(row("WERKS"))
            zdpro.AlmacenDesc = CStr(row("TXWRK"))
            zdpro.CodArticulo = CStr(row("MATNR"))
            zdpro.ArticuloDesc = CStr(row("TXZ01"))
            zdpro.TipoArticulo = CStr(row("MTART"))
            zdpro.CantidadRecibida = CInt(row("MENGE"))
            zdpro.CantidadLecturada = CInt(row("ERFMG"))
            If IsDBNull(row("Sobrante")) = False Then
                zdpro.Sobrante = CInt(row("Sobrante"))
            Else
                zdpro.Sobrante = 0
            End If
            zdpro.CodUpc = CStr(row("EAN11"))
            row("BKTXT") = txtPlayerDescripcion.Text.Trim()
            zdpro.CodVendedor = Me.txtPlayer.Text.Trim()
            zdpro.Responsable = Me.txtPlayerDescripcion.Text.Trim()
            zdpro.Referencia = Me.txtReferencia.Text.Trim()
            zdpro.Serie = CStr(row("SERNR"))
            zdpro.TotalPedido = CInt(Me.txtTotalPedido.Value)
            zdpro.TotalRecibido = CInt(Me.txtTotalRecibido.Value)
            zdpro.Fecha = oSAPMgr.MSS_GET_SY_DATE_TIME()
            If Me.TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
                zdpro.Tipo = "COM"
            Else
                zdpro.Tipo = "DEV"
            End If
            row("ZTOTPED") = CInt(Me.txtTotalPedido.Value)
            row("ZTOTREC") = CInt(Me.txtTotalRecibido.Value)
            row.AcceptChanges()
            lstZdproPedido.Add(zdpro)
        Next
        Me.dtTrasladoDetalle.AcceptChanges()
        Me.TraspasoEntradaMgr.SaveZdproPedido(lstZdproPedido)
        Return lstZdproPedido
    End Function

    Private Function GuardarZequi(ByVal dtZequi As DataTable, ByVal lstZequi As List(Of Zequi)) As Boolean
        Dim valido As Boolean = False
        Dim zequi As Zequi = Nothing
        Try
            For Each row As DataRow In dtZequi.Rows
                zequi = New Zequi(TraspasoEntradaMgr)
                zequi.CodArticulo = CStr(row("MATNR"))
                zequi.Serie = CStr(row("SERNR"))
                zequi.NoPedido = CStr(row("EBELN"))
                zequi.CentroOrigen = CStr(row("WERKS"))
                zequi.CentroDestino = CStr(row("WERKSD"))
                zequi.Proveedor = CStr(row("LIFNR"))
                zequi.DocMaterial = CStr(row("MBLNR"))
                zequi.ClaseMovimiento = CStr(row("BWART"))
                zequi.SOBKZ = CStr(row("SOBKZ"))
                zequi.SHKZG = CStr(row("SHKZG"))
                zequi.BEWTP = CStr(row("BEWTP"))
                lstZequi.Add(zequi)
            Next
            TraspasoEntradaMgr.SaveZequi(lstZequi)
            valido = True
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al guardar los artículos de Consignación")
        End Try
        Return valido
    End Function

    Private Function SaveSAP() As Boolean
        Dim valido As Boolean = False
        Try
            Dim result As New Dictionary(Of String, Object)
            result = oSAPMgr.ZMMOC02(Me.dtPedido)
            If CBool(result("Success")) Then
                Dim response As New Dictionary(Of String, Object)
                Dim mblnr As String = CStr(result("MBLNR"))
                For Each zdpro As ZdproPedidos In lstZDpro
                    zdpro.DocMaterial = mblnr
                Next
                If TraspasoEntradaMgr.SaveZdproPedido(lstZDpro) Then
                    If Me.TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
                        TraspasoEntradaMgr.ActualizarDocumentoEntradaMercancia(TraspasoEntradaId, mblnr)
                    ElseIf Me.TipoConsignacion = TrasladoConsignacion.DEVOLUCION Then
                        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
                        oTraspasoSalidaMgr.ActualizaDocumentoDevProveedor(TraspasoSalidaId, mblnr)
                    End If
                    If EsConSerie Then
                        response = oSAPMgr.ZMMOC03(mblnr)
                        If CBool(response("Success")) Then
                            Dim dtZequi As DataTable = CType(response("ZEQUI"), DataTable)
                            Dim lstZequi As New List(Of DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi)
                            If GuardarZequi(dtZequi, lstZequi) Then
                                valido = True
                            Else
                                MessageBox.Show("Error al guardar los productos de consignación", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog("Error al guardar tabla Zequi", "Error Zequi")
                            End If
                        End If
                    Else
                        valido = True
                    End If
                Else
                    MessageBox.Show("No se pudierón guardar los datos del pedido", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    EscribeLog("No se pudierón guardar los datos del pedido", "Error al grabar Zdppro")
                End If
            Else
                MessageBox.Show("Error al aplicar el traslado" & vbCrLf & CStr(result("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            valido = False
        End Try
        Return valido
    End Function

    Private Sub CargarDesdeLectora()
        Cursor.Current = Cursors.WaitCursor
        Dim ruta As String = ""
        If BuscaLectora(ruta, oConfigCierreFI.NombreLectoraTE, oConfigCierreFI.NombreArchivoLectoraTE) Then
            If ruta.Trim() <> "" Then
                Dim bTraslaso As Boolean = False
                Dim rows() As DataRow = Nothing
                Dim oSR As New StreamReader(ruta)
                strline = oSR.ReadLine()
                Do While Not strline Is Nothing
                    If bTraslaso = False Then
                        If CargarTraslado(strline) Then
                            rows = Me.dtTrasladoDetalle.Select("NSERIE='X'")
                            If rows.Length = 0 Then
                                bTraslaso = True
                            Else
                                MessageBox.Show("Pedido de artículos con número de serie no se pueden cargar con la lectora", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Formato del archivo de carga incorrecto. Favor de verificar.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        rows = Me.dtTrasladoDetalle.Select("EAN11='" & strline & "'")
                        If rows.Length > 0 Then
                            rows(0)!ERFMG += 1
                        End If
                    End If
                    strline = oSR.ReadLine()
                Loop
                Me.gridDetalle.DataSource = Me.dtTrasladoDetalle
                Dim objRecibidas As Object = Nothing, TotalPedido As Integer = 0
                objRecibidas = dtTrasladoDetalle.Compute("SUM(MENGE)", "")
                If Not objRecibidas Is Nothing Then
                    TotalPedido = objRecibidas
                End If
                txtTotalPedido.Text = CStr(TotalPedido)
                CalcularPiezas()
                Me.gridDetalle.Enabled = False
                Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuAplicarTraslado").Enabled = Janus.Windows.UI.InheritableBoolean.True
                Me.txtPlayer.Focus()
            End If
        End If
    End Sub

    Private Function BuscaLectora(ByRef RutaLayout As String, ByVal NombreLectora As String, ByVal NombreArchivo As String) As Boolean
        Dim bResult As Boolean = False
        Dim fso As New Scripting.FileSystemObject

        Dim NombreUnidad As String = ""
        Dim LetraUnidad As String = ""

        Try
            For Each unidad As Scripting.Drive In fso.Drives
                If unidad.DriveType = 3 Then
                    NombreUnidad = unidad.ShareName()
                ElseIf unidad.IsReady Then
                    NombreUnidad = unidad.VolumeName
                End If
                If NombreUnidad = NombreLectora Then
                    LetraUnidad = unidad.DriveLetter
                    bResult = True
                    Exit For
                End If
            Next

            If bResult Then
                Dim Ruta As String
                Dim Temp As New DirectoryInfo(LetraUnidad & ":")
                Ruta = BuscaArchivoLayout(Temp, NombreArchivo)
                RutaLayout = Ruta
            End If

            fso = Nothing
            Return bResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function BuscaArchivoLayout(ByVal SearchDir As DirectoryInfo, ByVal searchFileName As String) As String
        Static Dim FoundPath As String = ""
        Try
            If FoundPath = "" Then
                Dim temp As String = ""
                If SearchDir.GetFiles(searchFileName).Length > 0 Then
                    FoundPath = SearchDir.FullName & "\" & searchFileName
                    Return SearchDir.FullName & "\" & searchFileName
                End If
                Dim Directories() As DirectoryInfo = SearchDir.GetDirectories("*")
                For Each newDir As DirectoryInfo In Directories
                    temp = BuscaArchivoLayout(newDir, searchFileName)
                Next
                Return temp
            Else
                Return FoundPath
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function CargarTraslado(ByVal Pedido As String) As Boolean
        Dim valido As Boolean = True
        Dim result As New Dictionary(Of String, Object)
        Try
            Select Case Me.TipoConsignacion
                Case TrasladoConsignacion.ORDENCOMPRA
                    result = oSAPMgr.ZMMOC01(Pedido, oSAPMgr.Read_Centros(), oSAPMgr.MSS_GET_SY_DATE_TIME())
                Case TrasladoConsignacion.DEVOLUCION
                    result = oSAPMgr.ZMMOD01(Pedido, oSAPMgr.Read_Centros, oSAPMgr.MSS_GET_SY_DATE_TIME())
            End Select
            If result.ContainsKey("Success") Then
                If CBool(result("Success")) = True Then
                    Me.dtTrasladoDetalle = CType(result("Pedido"), DataTable)
                    Dim CabeceraRow As DataRow = dtTrasladoDetalle.Rows(0)
                    Me.txtCodProveedor.Text = CStr(CabeceraRow("LIFNR"))
                    Me.txtProveedorDesc.Text = CStr(CabeceraRow("TXLFN"))
                    Me.txtCodAlmacen.Text = CStr(CabeceraRow("WERKS"))
                    Me.txtAlmacenDescr.Text = CStr(CabeceraRow("TXWRK"))
                    Me.txtNoPedido.Text = CStr(CabeceraRow("EBELN"))
                    AgregarCamposTraslado(Me.dtTrasladoDetalle)
                    CargarDetallesFaltantes(Me.dtTrasladoDetalle)
                    valido = True
                Else
                    valido = False
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al cargar el pedido")
            Throw ex
        End Try
        Return valido
    End Function

    Private Function hasItemsWithSerie(ByVal dtDetalle As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim rows() As DataRow = dtDetalle.Select("NSERIE='X'")
        If rows.Length > 0 Then
            valido = True
        End If
        Return valido
    End Function

    Public Function GuardarTraspasoEntrada() As Boolean
        TraspasoEntradaId = 0
        Dim valido As Boolean = False
        Dim oTraspasoEntrada As New TraspasoEntrada(TraspasoEntradaMgr)
        Dim AlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Try
            Dim RowCabecera As DataRow = Me.dtPedido.Rows(0)
            Dim Almacen As Almacen = AlmacenMgr.Create()
            Dim dtTraspasoEntrada As DataTable = CrearDetalleTraspasoEntrada(Me.dtPedido)
            AlmacenMgr.LoadInto(CStr(RowCabecera("WERKS")), Almacen)
            oTraspasoEntrada.AlmacenOrigenID = ""
            oTraspasoEntrada.AlmacenDestinoID = oAppContext.ApplicationConfiguration.Almacen
            oTraspasoEntrada.AutorizadoPorID = Usuario
            oTraspasoEntrada.Referencia = Me.txtReferencia.Text.Trim()
            oTraspasoEntrada.Observaciones = "Orden de Compra"
            oTraspasoEntrada.FolioSAP = ""
            oTraspasoEntrada.TraspasoRecibidoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
            oTraspasoEntrada.TraspasoCreadoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
            oTraspasoEntrada.Status = "GRA"
            oTraspasoEntrada.Detalle = New DataSet()
            oTraspasoEntrada.Detalle.Tables.Add(dtTraspasoEntrada)
            If (TraspasoEntradaMgr.AplicarEntrada(oTraspasoEntrada, oAppContext.Security.CurrentUser.ID, oAppContext.Security.CurrentUser.SessionLoginName) = True) Then
                valido = True
                TraspasoEntradaId = oTraspasoEntrada.Folio
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al darle entrada a la orden de compra")
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return valido
    End Function

    Private Function GuardarTraspasoSalida() As Boolean
        TraspasoSalidaId = 0
        Dim valido As Boolean = False
        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        Dim AlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oTraspasoSalida As TraspasoSalida
        Dim dsTraspasoCorrida As New DataSet()
        Dim dtDetalleSAP As DataTable
        Dim Almacen As Almacen = AlmacenMgr.Create()
        Try
            Dim RowCabecera As DataRow = Me.dtTrasladoDetalle.Rows(0)
            AlmacenMgr.LoadInto(CStr(RowCabecera("WERKS")), Almacen)
            oTraspasoSalida = oTraspasoSalidaMgr.Create()
            oTraspasoSalida.Observaciones = "Devolución de proveedor"
            oTraspasoSalida.TraspasoRecibidoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
            oTraspasoSalida.TraspasoCreadoEl = oSAPMgr.MSS_GET_SY_DATE_TIME().ToShortDateString()
            oTraspasoSalida.Guia = ""
            oTraspasoSalida.TotalBultos = 0
            oTraspasoSalida.AutorizadoPorID = oAppContext.Security.CurrentUser.ID
            oTraspasoSalida.Cargos = 0
            oTraspasoSalida.SubTotal = 0
            oTraspasoSalida.MonedaID = ""
            oTraspasoSalida.TransportistaID = "006"
            oTraspasoSalida.Status = "GRA"
            oTraspasoSalida.AlmacenDestinoID = oAppContext.ApplicationConfiguration.Almacen
            oTraspasoSalida.AlmacenOrigenID = ""
            oTraspasoSalida.Referencia = Me.txtReferencia.Text.Trim()
            oTraspasoSalida.TraspasoID = 0
            oTraspasoSalida.Folio = ""
            oTraspasoSalida.Entrega = ""
            oTraspasoSalida.FolioSAP = ""
            oTraspasoSalida.PedidoEC = CStr(RowCabecera("EBELN"))
            oTraspasoSalida.Modulo = "OC"
            oTraspasoSalida.Detalle = CrearDetalleTraspasoSalida(Me.dtPedido)
            oTraspasoSalida.Save()
            valido = True
            TraspasoSalidaId = oTraspasoSalida.TraspasoID
        Catch ex As Exception
            valido = False
            EscribeLog(ex.Message, "Error al generar el traspaso de salida")
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return valido
    End Function

    Private Function CrearDetalleTraspasoEntrada(ByVal dtTraspaso As DataTable) As DataTable
        Dim dtDetalle As New DataTable
        dtDetalle.Columns.Add("Codigo", GetType(String))
        dtDetalle.Columns.Add("Cantidad", GetType(Integer))
        dtDetalle.Columns.Add("TALLA", GetType(String))
        dtDetalle.Columns.Add("Descripcion", GetType(String))
        dtDetalle.Columns.Add("Bulto", GetType(Integer))
        Dim fila As DataRow = Nothing
        Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim articulo As Articulo = ArticuloMgr.Create()
        For Each row As DataRow In dtTraspaso.Rows
            articulo.ClearFields()
            ArticuloMgr.LoadInto(CStr(row("MATNR")), articulo)
            fila = dtDetalle.NewRow()
            fila("Codigo") = CStr(row("MATNR"))
            fila("TALLA") = CStr(row("Numero"))
            fila("Cantidad") = CInt(row("ERFMG"))
            fila("Bulto") = 1
            fila("Descripcion") = articulo.Descripcion
            dtDetalle.Rows.Add(fila)
        Next
        dtDetalle.AcceptChanges()
        Return dtDetalle
    End Function

    Public Function CrearDetalleTraspasoSalida(ByVal dtConfirmados As DataTable) As DataSet

        Dim oRow As DataRow
        Dim oArticuloTemp As Articulo
        Dim cant As Integer = 0
        Dim dsTraspasoSalidaDetalle As DataSet
        Dim Talla As String = ""
        Dim oTraspasoSMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        Dim oArticulosMgr As New CatalogoArticuloManager(oAppContext)
        oTraspasoSMgr.CrearTablaTmp()

        For Each oRow In dtConfirmados.Rows
            oArticuloTemp = Nothing
            cant = 0
            oArticuloTemp = oArticulosMgr.Load(CStr(oRow!MATNR))
            If Not oArticuloTemp Is Nothing Then
                cant = CInt(oRow!MENGE)
                If IsNumeric(oRow!Numero) Then
                    If InStr(CStr(oRow!Numero), ".5") <= 0 Then
                        Talla = CInt(oRow!Numero)
                    Else
                        Talla = CStr(oRow!Numero).Trim
                    End If
                Else
                    Talla = CStr(oRow!Numero).Trim
                End If
                oTraspasoSMgr.AgregarArticulo(oArticuloTemp, Talla, cant, oArticuloTemp.CostoProm * cant, 0)
            End If
        Next

        dsTraspasoSalidaDetalle = Nothing
        dsTraspasoSalidaDetalle = oTraspasoSMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")

        oArticuloTemp = Nothing

        Return dsTraspasoSalidaDetalle

    End Function

    Private Sub AbrirTraspaso()
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim ordenes As New OrdenesCompraOpenRecordDialogView()
        If Me.TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
            ordenes.TipoConsignacion = "COM"
        Else
            ordenes.TipoConsignacion = "DEV"
        End If

        oOpenRecordDlg.CurrentView = ordenes


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Dim dtOrdenesCompra As DataTable = TraspasoEntradaMgr.GetZdpproPedidoByPedidoSAP(CStr(oOpenRecordDlg.Record.Item("PedidoSAP")), CStr(oOpenRecordDlg.Record.Item("Identificador")))
            Dim RowCabecera As DataRow = dtOrdenesCompra.Rows(0)
            Me.txtCodProveedor.Text = CStr(RowCabecera("Proveedor"))
            Me.txtProveedorDesc.Text = CStr(RowCabecera("ProveedorDesc"))
            Me.txtNoPedido.Text = CStr(RowCabecera("PedidoSAP"))
            Me.txtCodAlmacen.Text = CStr(RowCabecera("CodAlmacen"))
            Me.txtAlmacenDescr.Text = CStr(RowCabecera("AlmacenDesc"))
            Me.txtReferencia.Text = CStr(RowCabecera("Referencia"))
            Me.txtPlayer.Text = CStr(RowCabecera("CodVendedor"))
            Me.txtPlayerDescripcion.Text = CStr(RowCabecera("Responsable"))
            Me.txtFecha.Value = CDate(RowCabecera("Fecha"))
            Me.dtTrasladoDetalle = CreardtTrasladoDetalle(dtOrdenesCompra)
            Me.gridDetalle.DataSource = Me.dtTrasladoDetalle
            CalcularFaltanteSobrante(Me.dtTrasladoDetalle)
            EnableControl(False)
            Dim objRecibidas As Object = Nothing, TotalPedido As Integer = 0
            objRecibidas = dtTrasladoDetalle.Compute("SUM(MENGE)", "")
            If Not objRecibidas Is Nothing Then
                TotalPedido = objRecibidas
            End If
            txtTotalPedido.Text = CStr(TotalPedido)
            CalcularPiezas()

            Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuImpresion").Enabled = Janus.Windows.UI.InheritableBoolean.True
            Me.ToolbarConsignacion.CommandBars("Toolbar").Commands("MnuCargarLectora").Enabled = Janus.Windows.UI.InheritableBoolean.True
        End If
    End Sub

    Private Sub PrintTraslado(ByVal dtTrasladoDetalle As DataTable)
        Dim oARReporte As New rptConsignacion(dtTrasladoDetalle)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Consignación"
        oARReporte.Run()

        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()
    End Sub

    Private Sub ImprimirTraslado()
        If Not Me.dtTrasladoDetalle Is Nothing Then
            PrintTraslado(Me.dtTrasladoDetalle)
        End If
    End Sub

    Private Function CreardtTrasladoDetalle(ByVal dtZdproPedido As DataTable) As DataTable
        Dim dtHomologo As New DataTable()
        Dim fila As DataRow = Nothing
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()
        Dim ArtExistencia As New Hashtable()
        dtHomologo.Columns.Add("MBLNR", GetType(String))
        dtHomologo.Columns.Add("EBELN", GetType(String))
        dtHomologo.Columns.Add("LIFNR", GetType(String))
        dtHomologo.Columns.Add("TXLFN", GetType(String))
        dtHomologo.Columns.Add("WERKS", GetType(String))
        dtHomologo.Columns.Add("TXWRK", GetType(String))
        dtHomologo.Columns.Add("MATNR", GetType(String))
        dtHomologo.Columns.Add("TXZ01", GetType(String))
        dtHomologo.Columns.Add("MTART", GetType(String))
        dtHomologo.Columns.Add("MENGE", GetType(Integer))
        dtHomologo.Columns.Add("ERFMG", GetType(Integer))
        dtHomologo.Columns.Add("EAN11", GetType(String))
        dtHomologo.Columns.Add("BKTXT", GetType(String))
        dtHomologo.Columns.Add("LFSNR", GetType(String))
        dtHomologo.Columns.Add("SERNR", GetType(String))
        dtHomologo.Columns.Add("ZTOTPED", GetType(Integer))
        dtHomologo.Columns.Add("ZTOTREC", GetType(Integer))
        dtHomologo.Columns.Add("CodArtProv", GetType(String))
        dtHomologo.Columns.Add("Numero", GetType(String))
        dtHomologo.Columns.Add("IDNLF", GetType(String))
        dtHomologo.Columns.Add("Faltante", GetType(String))
        dtHomologo.Columns.Add("Sobrante", GetType(String))
        dtHomologo.AcceptChanges()

        For Each row As DataRow In dtZdproPedido.Rows
            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(CStr(row("CodArticulo")), oArticulo)
            fila = dtHomologo.NewRow()
            fila("MBLNR") = CStr(row("DocMaterial"))
            fila("EBELN") = CStr(row("PedidoSAP"))
            fila("LIFNR") = CStr(row("Proveedor"))
            fila("TXLFN") = CStr(row("ProveedorDesc"))
            fila("WERKS") = CStr(row("CodAlmacen"))
            fila("TXWRK") = CStr(row("AlmacenDesc"))
            fila("MATNR") = CStr(row("CodArticulo"))
            fila("TXZ01") = CStr(row("ArticuloDesc"))
            fila("MTART") = CStr(row("TipoArticulo"))
            fila("MENGE") = CInt(row("CantidadRecibida"))
            fila("ERFMG") = CInt(row("CantidadLecturada"))
            fila("EAN11") = CStr(row("CodUpc"))
            fila("BKTXT") = CStr(row("Responsable"))
            fila("LFSNR") = CStr(row("Referencia"))
            fila("SERNR") = CStr(row("Serie"))
            fila("ZTOTPED") = CInt(row("TotalPedido"))
            fila("ZTOTREC") = CInt(row("TotalRecibido"))
            fila("Sobrante") = CInt(row("Sobrante"))
            fila("IDNLF") = oArticulo.CodArtProv
            fila("Numero") = ""
            dtHomologo.Rows.Add(fila)
        Next
        dtHomologo.AcceptChanges()
        Return dtHomologo
    End Function

    Private Sub EnableControl(ByVal Value As Boolean)
        Me.txtCodProveedor.Enabled = Value
        Me.txtProveedorDesc.Enabled = Value
        Me.txtNoPedido.Enabled = Value
        Me.txtCodAlmacen.Enabled = Value
        Me.txtAlmacenDescr.Enabled = Value
        Me.txtReferencia.Enabled = Value
        Me.txtCodProveedor.Enabled = Value
        Me.txtProveedorDesc.Enabled = Value
        Me.txtFecha.Enabled = Value
        Me.gridDetalle.Enabled = Value
    End Sub

    Private Function AgregarDetallesValidos(ByRef dtTraspasoDetalle As DataTable) As DataTable
        Dim dtPedido As DataTable = dtTraspasoDetalle.Clone()
        For Each row As DataRow In dtTraspasoDetalle.Rows
            If CInt(row("ERFMG")) > 0 Then
                row("LFSNR") = Me.txtReferencia.Text.Trim()
                dtPedido.ImportRow(row)
            End If
        Next
        dtPedido.AcceptChanges()
        Return dtPedido
    End Function

    Private Function ValidaCodigosEnCatalogo(ByVal dtTemp As DataTable) As Boolean
        Dim strMateriales As String = ""
        Dim odrArticulo As DataRow
        Dim oArticulo As Articulo
        Dim bRes As Boolean = True
        Dim dtCod As DataTable
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim oArticulosMgr As New CatalogoArticuloManager(oAppContext)

        frmDescargas.Timer1.Enabled = False

        CreaEstructuraTablaDescarga(dtCod)

        For Each odrArticulo In dtTemp.Rows
            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("MATNR")))
            If oArticulo Is Nothing Then

                frmDescargas.bPorCodigo = True
                frmDescargas.bMostrarMensaje = False

                dtCod.Clear()
                AgregarCodigo(CStr(odrArticulo("MATNR")).Trim, dtCod)
                frmDescargas.dtMateriales = dtCod

                frmDescargas.ShowDev("Articulos")

                oArticulo = Nothing
                oArticulo = oArticulosMgr.Load(CStr(odrArticulo("MATNR")))
                If Not oArticulo Is Nothing Then
                    frmDescargas.ShowDev("Descuentos")
                    frmDescargas.ShowDev("Inventarios")
                    frmDescargas.ShowDev("CodigosUPC")
                Else
                    strMateriales = CStr(odrArticulo("MATNR")) & vbCrLf
                End If

            End If
        Next

        If strMateriales.Trim <> "" Then
            strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & _
                             vbCrLf & strMateriales
            MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Sub CreaEstructuraTablaDescarga(ByRef dtTemp As DataTable)

        dtTemp = New DataTable("Materiales")
        dtTemp.Columns.Add("Material", Type.GetType("System.String"))
        dtTemp.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtTemp.AcceptChanges()

    End Sub

    Private Sub AgregarCodigo(ByVal strCodigo As String, ByRef dtTemp As DataTable)

        Dim oRow As DataRow = dtTemp.NewRow
        oRow!Material = strCodigo.Trim.ToUpper
        oRow!Descripcion = ""
        dtTemp.Rows.Add(oRow)
        dtTemp.AcceptChanges()

    End Sub

    Private Function SaveConsignacion(ByVal Traspaso As Dictionary(Of String, Object)) As Boolean
        Dim valido As Boolean = False
        Dim result As New Dictionary(Of String, Object)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim TraspasoEntradaMgr As New DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Dim dtPedido As DataTable = CType(Traspaso("DetallePedido"), DataTable)
        Dim lstZDpro As List(Of ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos) = CType(Traspaso("lstZDpro"), List(Of ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos))
        Dim TipoConsignacion As TrasladoConsignacion = CType(Traspaso("TrasladoConsignacion"), TrasladoConsignacion)
        Dim TraspasoId As Integer = 0, EsConSerie As Boolean, TraspasoSuccess As Boolean
        If TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
            TraspasoId = CInt(Traspaso("TraspasoEntradaId"))
        ElseIf TipoConsignacion = TrasladoConsignacion.DEVOLUCION Then
            TraspasoId = CInt(Traspaso("TraspasoSalidaId"))
        End If
        EsConSerie = CBool(Traspaso("EsConSerie"))
        Try
            result = oSAPMgr.ZMMOC02(dtPedido)
            If CBool(result("Success")) Then
                Dim response As New Dictionary(Of String, Object)
                Dim mblnr As String = CStr(result("MBLNR"))
                For Each zdpro As ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos In lstZDpro
                    zdpro.DocMaterial = mblnr
                Next
                If TraspasoEntradaMgr.SaveZdproPedido(lstZDpro) Then
                    If TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
                        If GuardarTraspasoEntrada() Then
                            TraspasoEntradaMgr.ActualizarDocumentoEntradaMercancia(TraspasoEntradaId, mblnr)
                        Else
                            MessageBox.Show("Error al guardar el traspaso de entrada", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            EscribeLog("Error al guardar el traspaso de entrada", "Error traspaso entrada")
                            Return False
                        End If
                    ElseIf TipoConsignacion = TrasladoConsignacion.DEVOLUCION Then
                        If GuardarTraspasoSalida() Then
                            Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
                            oTraspasoSalidaMgr.ActualizaDocumentoDevProveedor(TraspasoSalidaId, mblnr)
                        Else
                            MessageBox.Show("Error al guardar el traspaso de salida", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            EscribeLog("Error al guardar el traspaso de salida", "Error traspaso Salida")
                            Return False
                        End If
                    End If
                    If EsConSerie Then
                        response = oSAPMgr.ZMMOC03(mblnr)
                        If CBool(response("Success")) Then
                            Dim dtZequi As DataTable = CType(response("ZEQUI"), DataTable)
                            Dim lstZequi As New List(Of DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi)
                            If GuardarZequi(dtZequi, lstZequi) Then
                                valido = True
                            Else
                                MessageBox.Show("Error al guardar los productos de consignación", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog("Error al guardar tabla Zequi", "Error Zequi")
                            End If
                        End If
                    Else
                        valido = True
                    End If
                Else
                    MessageBox.Show("No se pudierón guardar los datos del pedido", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    EscribeLog("No se pudierón guardar los datos del pedido", "Error al guardar datos del pedido")
                End If
            Else
                Dim NoError As String = CStr(result("ErrorNumber"))
                Select Case NoError
                    Case "006"
                        MessageBox.Show("Error al aplicar el traslado en SAP" & vbCrLf & CStr(result("Mensaje")) & vbCrLf & "Intente de nuevo mas tarde", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Case Else
                        MessageBox.Show("Error al aplicar el traslado en SAP" & vbCrLf & CStr(result("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
                EscribeLog("Error al aplicar el traslado en SAP" & vbCrLf & CStr(result("Mensaje")), "Error al aplicar consignacion SAP")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al aplicar el traslado en SAP " & ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog("Error al aplicar el traslado" & vbCrLf & ex.Message, "Error al aplicar el traspaso")
        End Try
        Return valido
    End Function

    Private Sub CalcularFaltanteSobrante(ByVal dtPedido As DataTable)
        For Each row As DataRow In dtPedido.Rows
            row("Faltante") = 0
            row("Sobrante") = CInt(row("Sobrante"))
            If CInt(row("ERFMG")) <> CInt(row("MENGE")) Then
                If CInt(row("ERFMG")) > CInt(row("MENGE")) Then

                Else
                    row("Faltante") = CInt(row("MENGE")) - CInt(row("ERFMG"))
                End If
            End If
            row.AcceptChanges()
        Next
        dtPedido.AcceptChanges()
    End Sub

#End Region

#Region "Eventos"

    Private Sub ToolbarConsignacion_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarConsignacion.CommandClick
        Select Case e.Command.Key
            Case "MnuNuevo"
                Nuevo()
            Case "MnuAbrir"
                AbrirTraspaso()
            Case "MnuBuscar"
                BuscarTraslado()
            Case "MnuCargarLectora"
                CargarDesdeLectora()
            Case "MnuImpresion"
                ImprimirTraslado()
            Case "MnuAplicarTraslado"
                AplicarTraslado()
            Case "MnuSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub txtPlayer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlayer.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtPlayer_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub txtPlayer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPlayer.Validating
        If txtPlayer.Text.Trim() <> "" Then

            oVendedor.ClearFields()

            Try
                oVendedoresMgr.LoadInto(txtPlayer.Text.Trim(), oVendedor)

                If oVendedor.ID <> String.Empty Then

                    txtPlayerDescripcion.Text = oVendedor.Nombre
                Else
                    MsgBox("Código de Vendedor NO EXISTE.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Consignación ")

                    oVendedor.ClearFields()
                    Me.txtPlayerDescripcion.Text = ""
                    e.Cancel = True
                End If

            Catch ex As Exception

                MsgBox("Código de Vendedor NO EXISTE.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Consignación ")
                EscribeLog(ex.ToString, "Consignación: Código de Vendedor NO EXISTE.")
                oVendedor.ClearFields()
                Me.txtPlayerDescripcion.Text = ""
                e.Cancel = True

            End Try


        End If
    End Sub

    Private Sub gridDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
        Lecturar(e)
    End Sub

    Private Sub frmConsignacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "Mejora Entrega en tiendas"

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 04/10/2018: Muestra los articulos donde hay sobrantes y faltantes
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Function ShowFormFaltantesSobrantes(ByVal dtMateriales As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim frmAjuste As New frmMensajeOrdenCompra
        frmAjuste.Source = dtMateriales
        frmAjuste.Text = "Artículos que contienen Faltantes y Sobrantes"
        frmAjuste.lblMensaje.Text = "Los siguientes códigos no coinciden en las cantidades" & vbCrLf & "¿Deseas continuar?"
        frmAjuste.SetAttributesColumnsGrid(GetAtributos())
        If frmAjuste.ShowDialog() = Windows.Forms.DialogResult.OK Then
            valido = True
        End If
        Return valido
    End Function

    Public Function GetAtributos() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "MATNR"
        row("Ancho") = 130
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "CodArtProv"
        row("Ancho") = 90
        row("Texto") = "Cod. Prov"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Faltante"
        row("Ancho") = 40
        row("Texto") = "Faltante"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Sobrante"
        row("Ancho") = 40
        row("Texto") = "Sobrante"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function

#End Region



End Class