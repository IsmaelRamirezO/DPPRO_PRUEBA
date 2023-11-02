Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports EmpGerInt
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas



Public Class frmInicioDia
    Inherits System.Windows.Forms.Form

    Private oInicioDiaMgr As InicioDiaManager
    Private oInicioDia As InicioDia
    Private FechaInicioDiaReal As Date
    Private oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager
    Private oProSAPMgr As ProcesoSAPManager
    Private oServerUPC As ServerUPCManager
    Private RestService As New ProcesosRetail("", "POST")


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInicioDia As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFechaInicioDia As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioDia))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnInicioDia = New Janus.Windows.EditControls.UIButton()
        Me.ebFechaInicioDia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnInicioDia)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaInicioDia)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(290, 159)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnInicioDia
        '
        Me.btnInicioDia.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnInicioDia.Icon = CType(resources.GetObject("btnInicioDia.Icon"), System.Drawing.Icon)
        Me.btnInicioDia.Location = New System.Drawing.Point(64, 104)
        Me.btnInicioDia.Name = "btnInicioDia"
        Me.btnInicioDia.Size = New System.Drawing.Size(160, 32)
        Me.btnInicioDia.TabIndex = 8
        Me.btnInicioDia.Text = "Iniciar Dia"
        Me.btnInicioDia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFechaInicioDia
        '
        '
        '
        '
        Me.ebFechaInicioDia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaInicioDia.Location = New System.Drawing.Point(144, 48)
        Me.ebFechaInicioDia.Name = "ebFechaInicioDia"
        Me.ebFechaInicioDia.Size = New System.Drawing.Size(128, 23)
        Me.ebFechaInicioDia.TabIndex = 4
        Me.ebFechaInicioDia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'frmInicioDia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(290, 159)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInicioDia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Dia"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitializeObjects()

        oInicioDiaMgr = New InicioDiaManager(oAppContext)

        oInicioDia = oInicioDiaMgr.Create

        FechaInicioDiaReal = oInicioDia.FechaInicioDia

        oAbonoCreditoDirectoMgr = New AbonoCreditoDirectoManager(oAppContext)

        oProSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oServerUPC = New ServerUPCManager(oAppContext, oConfigCierreFI)
    End Sub

    Private Sub InitializeBinding()

        ebFechaInicioDia.DataBindings.Add(New Binding("Value", oInicioDia, "FechaInicioDia"))

    End Sub

    Private Sub EliminaRegistrosExistentes(ByVal Tabla As String)
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTraspasoEntradaMgr.EliminaRegistrosExistentes(Tabla)
    End Sub

    Private Sub CargaInicialArticulosAclaracion(ByVal dtResult As DataTable)
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTraspasoEntradaMgr.SaveCargaInicialArticulosAclaracion(dtResult)
    End Sub

    Private Sub CargaInicialBajaCalidad(ByVal dtResult As DataTable)
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTraspasoEntradaMgr.SaveCargaInicialBajaCalidad(dtResult)
    End Sub

    Private Sub CargaInicialDefectuosos(ByVal dtResult As DataTable)
        Dim oTraspasoEntradaMgr As TraspasosEntradaManager
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTraspasoEntradaMgr.SaveCargaInicialDefectuosos(dtResult)
    End Sub


    Private Sub ActualizaTablaInicial(ByVal Tabla As String, ByVal NombreTabla As String)
        Dim strCentro As String = String.Empty
        Dim oParametros As New Dictionary(Of String, Object)
        Dim dtResult As DataTable
        Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        strCentro = ProcesoMgr.Read_Centros


        'Obtener la información para ejecutar la RFC
        With oParametros
            .Add("PI_CENTRO_IN", strCentro)
            .Add("PI_TABLA_IN", Tabla)
        End With

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
        dtResult = oRetail.SapZFmCommx008DescargaUnica(oParametros)


        If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
            EliminaRegistrosExistentes(NombreTabla)

            If Tabla = "01" Then CargaInicialBajaCalidad(dtResult)
            If Tabla = "02" Then CargaInicialDefectuosos(dtResult)
            If Tabla = "03" Then CargaInicialArticulosAclaracion(dtResult)
        End If


    End Sub


    Private Sub btnInicioDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicioDia.Click

        Dim oInicioDia2 As InicioDia

        oInicioDia2 = oInicioDiaMgr.ValidaCierreDia(oInicioDia.CodAlmacen)

        If oInicioDiaMgr.Load(ebFechaInicioDia.Value, oInicioDia.CodAlmacen) > 0 Then

            MsgBox("Día " & Format(ebFechaInicioDia.Value, "dd/MM/yyyy") & " ya fue iniciado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Iniciar Día")

            ebFechaInicioDia.Focus()

        ElseIf Not oInicioDia2 Is Nothing Then

            MessageBox.Show("Antes de iniciar día, cierre día " & Format(oInicioDia2.FechaInicioDia, "dd/MM/yyyy"), _
            "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub

        ElseIf (ebFechaInicioDia.Value <> FechaInicioDiaReal) Then

            MessageBox.Show("El día correcto a iniciar es el " & Format(FechaInicioDiaReal, "dd/MM/yyyy"), _
            "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub

        Else

            '------------------------------------------------------------------
            ' FLIZARRAGA (16.11.2016):validamos si hay pedidos pendietes para deter el inicio de dia
            '------------------------------------------------------------------
            Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            If oConfigCierreFI.EvitarInicioDia = True Then
                Dim strMensaje As String = ""
                strMensaje = Me.ValidarPedidosNoGuardadosEnSAP()
                If strMensaje.Trim() <> "" Then
                    MessageBox.Show(strMensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(strMensaje, "Facturas no guardadas en SAP")
                    Exit Sub
                End If
                'If ProcesoMgr.ZSD_VALIDA_INICIODIA(oAppContext.ApplicationConfiguration.Almacen).Trim() = "1" Then
                '    MessageBox.Show("No se puede iniciar día porque hay pedidos pendientes de guardar en SAP", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Exit Sub
                'End If
            End If

            '----------------------------------------------------------------------------------------------------------------------------------------
            'Se guarda el Inicio de Dia
            '----------------------------------------------------------------------------------------------------------------------------------------
            oInicioDiaMgr.Save(oInicioDia)


            '----------------------------------------------------------------------------------------------------------------------------------------
            'Verificar que haya realizado la descarga de las tablas inciales (01 BajaCalidad, 02 Defectuosos, 03 Aclaraciones)
            '----------------------------------------------------------------------------------------------------------------------------------------

            Dim dtAclaraciones As DataTable
            Dim dtDefectuosos As DataTable
            Dim dtBajaCalidad As DataTable

            dtAclaraciones = oInicioDiaMgr.GetTablasIniciales("ArticulosAclaracion")
            dtDefectuosos = oInicioDiaMgr.GetTablasIniciales("Defectuosos")
            dtBajaCalidad = oInicioDiaMgr.GetTablasIniciales("BajaCalidad")

            If dtBajaCalidad.Rows.Count = 0 Then
                ActualizaTablaInicial("01", "BajaCalidad")
                oInicioDiaMgr.InsertTabla("BajaCalidad")
            End If

            If dtDefectuosos.Rows.Count = 0 Then
                ActualizaTablaInicial("02", "Defectuosos")
                oInicioDiaMgr.InsertTabla("Defectuosos")
            End If

            If dtAclaraciones.Rows.Count = 0 Then
                ActualizaTablaInicial("03", "ArticulosAclaracion")
                oInicioDiaMgr.InsertTabla("ArticulosAclaracion")
            End If


            MsgBox("Inicio de dia " & Format(ebFechaInicioDia.Value, "dd/MM/yyyy") & "  se realizó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Iniciar Día")
            '----------------------------------------------------------------------------------------------------------------------------------------
            'Realizamos las descargas al iniciar dia
            '----------------------------------------------------------------------------------------------------------------------------------------
            RealizarDescargasDiarias()
            '----------------------------------------------------------------------------------------------------------------------------------------
            'If RealizarDescargasDiarias() = False Then
            '    MessageBox.Show("Es necesario realizar las descargas correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            'Seteamos las cargas iniciales en Servidor
            'oInicioDiaMgr.SetCargasIniciales()

            '''''

            '----------------------------INICIAR DIA SISTEMA GERENCIAL
            Dim negGer As NegGerencial
            negGer = New EmpGerInt.NegGerencial(oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server, _
                                                     oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database, _
                                                    oAppContext.ApplicationConfiguration.DataStorageConfiguration.User, _
                                                      oAppContext.ApplicationConfiguration.DataStorageConfiguration.Password)
            negGer.IniciarDia(Date.Now.Date)
            '----------------------------INICIAR DIA SISTEMA GERENCIAL


            '----------------------------------------------------------------------------------------------------------------------------------------
            'Sacar Inventario Inicial
            '----------------------------------------------------------------------------------------------------------------------------------------
            oInicioDiaMgr.InventarioInicial(oInicioDia)


            'La Bitacora se Sacara por Rango de Fecha en un mismo archivo.
            'GenerarBitacoraXLS()

            oInicioDia.ClearFields()
            'Iniciar el campo Abono CDT se me hace que ya no se usa
            'oAbonoCreditoDirectoMgr.UpdateCatalogoCajasAbonoCDT(0, "I")

            '**********************Reporte de Descuentos Impresion Etiquetas **********************
            Dim frmx As New FrmDescNuevosPrintEtiquetas
            frmx.Show()
            frmx.CargaEtiquetas()
            '**********************Reporte de Descuentos **********************
            Me.DialogResult = DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Function RealizarDescargasDiarias() As Boolean
        Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim strCentro As String = ProcesoMgr.Read_Centros
        Dim bResult As Boolean = True

        Try
            '----------------------------------------------------------------------------------------------------------------------------------------
            'Cargas Iniciales Validacion para poder desactivar las cargas Iniciales
            '----------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.CargaInicial Then

                'Carga de datos con el proceso anterior
                Dim ofrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                ofrmProcesoSAP.bPorCodigo = False
                ofrmProcesoSAP.ShowDialog()
                ofrmProcesoSAP.Dispose()
                ofrmProcesoSAP = Nothing

            Else
                'MessageBox.Show("La Cargas Iniciales Se Encuentran Desactivadas." & _
                'Microsoft.VisualBasic.vbCrLf & "Solo se descargaran Descuentos,Cobranza,Códigos UPC,Marcas y Promociones", _
                '"DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '----------------------------------------------------------------------------------------------------------------------------------------
                'Actualizamos el status de las cargas iniciales diarias
                '----------------------------------------------------------------------------------------------------------------------------------------
                oServerUPC.SetCargasInicialesDiaria(oAppContext.ApplicationConfiguration.Almacen)
                '----------------------------------------------------------------------------------------------------------------------------------------
                Dim ofrmProcesoSAP As InitialForm  'New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga de Descuentos y Precios
                '----------------------------------------------------------------------------------------------------------------------------------------

                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                ofrmProcesoSAP.FechaDA = Me.ebFechaInicioDia.Value
                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("Descuentos")
                ofrmProcesoSAP.Dispose()

                ofrmProcesoSAP = Nothing


                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga de las cobranzas de SAP
                '----------------------------------------------------------------------------------------------------------------------------------------
                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("Cobranza")
                ofrmProcesoSAP.Dispose()
                ofrmProcesoSAP = Nothing

                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga de los UPC
                '----------------------------------------------------------------------------------------------------------------------------------------

                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("CodigosUPC")
                ofrmProcesoSAP.Dispose()
                ofrmProcesoSAP = Nothing

                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga de las Promociones
                '----------------------------------------------------------------------------------------------------------------------------------------
                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("Promociones")
                ofrmProcesoSAP.Dispose()

                ofrmProcesoSAP = Nothing
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga de Descuentos Adicionales
                '----------------------------------------------------------------------------------------------------------------------------------------
                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                ofrmProcesoSAP.FechaDA = Me.ebFechaInicioDia.Value
                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("DescuentosAdicionales")
                ofrmProcesoSAP.Dispose()

                ofrmProcesoSAP = Nothing
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga del Catalogo de Marcas
                '----------------------------------------------------------------------------------------------------------------------------------------
                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("Marcas")
                ofrmProcesoSAP.Dispose()

                ofrmProcesoSAP = Nothing
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Realizamos la descarga del Catalogo de Razones de Rechazo de registros de clientes PG
                '----------------------------------------------------------------------------------------------------------------------------------------
                ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                ofrmProcesoSAP.bMostrarMensaje = False
                ofrmProcesoSAP.ShowDev("RazonesRechazo")
                ofrmProcesoSAP.Dispose()

                ofrmProcesoSAP = Nothing
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos si hay centros nuevos en cuyo caso se realiza la descarga de Almacenes
                '----------------------------------------------------------------------------------------------------------------------------------------
                Dim result As New Generic.Dictionary(Of String, Object)
                RestService.Metodo = "/pos/inventarios"
                result = RestService.SapZdpproCentronuevo()
                If CBool(result("SapZdpproCentronuevo")("RESULT")) Then
                    ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                    ofrmProcesoSAP.bMostrarMensaje = False
                    ofrmProcesoSAP.ShowDev("Almacenes")
                    ofrmProcesoSAP.Dispose()

                    ofrmProcesoSAP = Nothing
                End If
                'If oProSAPMgr.ZDPPRO_CENTRONUEVO() Then
                '    ofrmProcesoSAP = New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                '    ofrmprocesosap.bMostrarMensaje = False
                '    ofrmProcesoSAP.ShowDev("Almacenes")
                '    ofrmProcesoSAP.Dispose()

                '    ofrmProcesoSAP = Nothing
                'End If

                'MessageBox.Show("Las descargas del inicio de dia se han realizado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            bResult = False
            EscribeLog(ex.ToString, "Ocurrio un error al realizar las descargas Inicio Dia")
        End Try

        Return bResult

    End Function

    Private Sub frmInicioDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        InitializeBinding()

    End Sub

    Private Sub frmInicioDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2016: Validar facturas no creadas en SAP, pero que si estan en el dppro
    '------------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarPedidosNoGuardadosEnSAP() As String
        Dim strMensaje As String = ""
        Dim lstPedidos As New List(Of Dictionary(Of String, Object))
        Dim oCierreDiasMgr As New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim FechaInicio As DateTime, FechaFin As DateTime
        FechaInicio = CDate(Me.ebFechaInicioDia.Value).AddDays(-1).AddMonths(-1)
        FechaFin = CDate(Me.ebFechaInicioDia.Value).AddDays(-1)
        Dim dtFacturas As DataTable = oCierreDiasMgr.GetFacturas(FechaInicio, FechaFin)
        Dim dtFacturasSAP As DataTable = oSapMgr.ZSD_VALIDA_PEDIDOS(FechaInicio, FechaFin)
        Dim rows() As DataRow = Nothing
        Dim refPRO As String = ""
        Dim refSAP As String = ""
        For Each rowPRO As DataRow In dtFacturas.Rows
            refPRO = CStr(rowPRO("Referencia")).Trim()
            rows = dtFacturasSAP.Select("BSTNK='" & refPRO & "'", "")
            If rows.Length = 0 Then
                strMensaje &= "Factura No Guardada: " & CStr(rowPRO("Referencia")) & vbCrLf
            End If
        Next
        Return strMensaje
    End Function

End Class
