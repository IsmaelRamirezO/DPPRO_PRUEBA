Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class frmGuardarFacturasPendientes
    Inherits System.Windows.Forms.Form

    Private m_bboolTipo As Boolean = False

    Private m_cieoParent As CierreDiaManager

    Dim oAjuste As AjusteGeneralTallaInfo

    Dim oAjusteMgr As AjusteGeneralTallaManager

    Dim oNotaCredito As NotaCredito

    Dim oNotaCreditoMgr As NotasCreditoManager
    Private dtPedidos As DataTable

    Dim oSAPMgr As ProcesoSAPManager
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridFormaPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbSelectAll As System.Windows.Forms.CheckBox

    Private RestService As ProcesosRetail


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        CreaEstructuraPedido()
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
    Friend WithEvents gbProgreso As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents pbProceso As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim gridFormaPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuardarFacturasPendientes))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cbSelectAll = New System.Windows.Forms.CheckBox()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.pbProceso = New Janus.Windows.EditControls.UIProgressBar()
        Me.gridFormaPago = New Janus.Windows.GridEX.GridEX()
        Me.btnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.gbProgreso = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.cbSelectAll)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.btnFacturar)
        Me.ExplorerBar1.Controls.Add(Me.pbProceso)
        Me.ExplorerBar1.Controls.Add(Me.gridFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.btnBuscar)
        Me.ExplorerBar1.Controls.Add(Me.dtFechaFin)
        Me.ExplorerBar1.Controls.Add(Me.dtFechaInicio)
        Me.ExplorerBar1.Controls.Add(Me.lblFechaFin)
        Me.ExplorerBar1.Controls.Add(Me.lblFechaInicio)
        Me.ExplorerBar1.Controls.Add(Me.gbProgreso)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(459, 331)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cbSelectAll
        '
        Me.cbSelectAll.AutoSize = True
        Me.cbSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.cbSelectAll.Location = New System.Drawing.Point(24, 43)
        Me.cbSelectAll.Name = "cbSelectAll"
        Me.cbSelectAll.Size = New System.Drawing.Size(56, 17)
        Me.cbSelectAll.TabIndex = 29
        Me.cbSelectAll.Text = "Todos"
        Me.cbSelectAll.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(371, 294)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 24)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnFacturar
        '
        Me.btnFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturar.Location = New System.Drawing.Point(280, 294)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(78, 24)
        Me.btnFacturar.TabIndex = 16
        Me.btnFacturar.Text = "&Facturar"
        Me.btnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'pbProceso
        '
        Me.pbProceso.AccessibleDescription = ""
        Me.pbProceso.AccessibleName = ""
        Me.pbProceso.BackgroundFormatStyle.BackColor = System.Drawing.Color.White
        Me.pbProceso.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Lavender
        Me.pbProceso.BackgroundFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbProceso.Location = New System.Drawing.Point(10, 265)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.ProgressFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackColorAlphaMode = Janus.Windows.UI.AlphaMode.Opaque
        Me.pbProceso.ProgressFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ProgressFormatStyle.BackgroundImageDrawMode = Janus.Windows.UI.BackgroundImageDrawMode.Center
        Me.pbProceso.ProgressFormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        Me.pbProceso.ShowPercentage = True
        Me.pbProceso.Size = New System.Drawing.Size(440, 23)
        Me.pbProceso.TabIndex = 0
        Me.pbProceso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'gridFormaPago
        '
        gridFormaPago_DesignTimeLayout.LayoutString = resources.GetString("gridFormaPago_DesignTimeLayout.LayoutString")
        Me.gridFormaPago.DesignTimeLayout = gridFormaPago_DesignTimeLayout
        Me.gridFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gridFormaPago.GroupByBoxVisible = False
        Me.gridFormaPago.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.Location = New System.Drawing.Point(10, 61)
        Me.gridFormaPago.Name = "gridFormaPago"
        Me.gridFormaPago.Size = New System.Drawing.Size(440, 194)
        Me.gridFormaPago.TabIndex = 24
        Me.gridFormaPago.TabStop = False
        Me.gridFormaPago.TotalRowFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(372, 18)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 21)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(254, 18)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(85, 20)
        Me.dtFechaFin.TabIndex = 10
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(95, 19)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(85, 20)
        Me.dtFechaInicio.TabIndex = 9
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFin.Location = New System.Drawing.Point(184, 21)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaFin.TabIndex = 7
        Me.lblFechaFin.Text = "Fecha Fin:"
        Me.lblFechaFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.Location = New System.Drawing.Point(11, 21)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(81, 13)
        Me.lblFechaInicio.TabIndex = 4
        Me.lblFechaInicio.Text = "Fecha Inicio:"
        Me.lblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbProgreso
        '
        Me.gbProgreso.BackColor = System.Drawing.Color.Transparent
        Me.gbProgreso.Location = New System.Drawing.Point(360, 169)
        Me.gbProgreso.Name = "gbProgreso"
        Me.gbProgreso.Size = New System.Drawing.Size(309, 76)
        Me.gbProgreso.TabIndex = 2
        Me.gbProgreso.Text = " Progreso "
        '
        'frmGuardarFacturasPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(459, 331)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.MinimumSize = New System.Drawing.Size(376, 184)
        Me.Name = "frmGuardarFacturasPendientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardando Facturas Pendientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property oParent() As CierreDiaManager
        Get
            Return m_cieoParent
        End Get
        Set(ByVal Value As CierreDiaManager)
            m_cieoParent = Value
        End Set
    End Property

    Public Property boolTipo() As Boolean
        Get
            Return m_bboolTipo
        End Get
        Set(ByVal Value As Boolean)
            m_bboolTipo = Value
        End Set
    End Property

    Private Sub CreaEstructuraNegados(ByRef dtNegados As DataTable)

        dtNegados = New DataTable("Negados")

        With dtNegados
            .Columns.Add(New DataColumn("Codigo", GetType(String)))
            .Columns.Add(New DataColumn("Talla", GetType(String)))
            .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            .Columns.Add(New DataColumn("Negados", GetType(Integer)))
            .Columns.Add(New DataColumn("Motivo", GetType(String)))
            .Columns.Add(New DataColumn("MotivoDesc", GetType(String)))
            .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
            .AcceptChanges()
        End With

    End Sub

    Private Sub CreaEstructuraPedido()
        dtPedidos = New DataTable()
        dtPedidos.Columns.Add("Seleccion", GetType(Boolean))
        dtPedidos.Columns.Add("FacturaId", GetType(Integer))
        dtPedidos.Columns.Add("Referencia", GetType(String))
        dtPedidos.Columns.Add("Folio", GetType(String))
        dtPedidos.Columns.Add("Fecha", GetType(DateTime))
        dtPedidos.AcceptChanges()
    End Sub

    Private Function NegarMaterialesPedidosEC(ByVal dtMateriales As DataTable) As DataTable

        Dim oRow As DataRow
        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oFacturaTemp As Factura
        Dim dtNegados As DataTable
        Dim oNewRow As DataRow
        Dim Talla As String = ""
        Dim oFacturaMgr As New FacturaManager(oParent.ApplicationContext, oParent.ConfigSaveArchivos)

        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
            Dim dvPedidoDet As DataView

            CreaEstructuraNegados(dtNegados)

            For Each oRow In dtMateriales.Rows
                For Each oRowP As DataRow In dtPed.Rows
                    If CStr(oRowP!Status).Trim.ToUpper = "P" Then
                        dvPedidoDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowP!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
                        For Each oRowPD As DataRowView In dvPedidoDet
                            If CInt(oRowPD!Cant_Pendiente) <= 0 Then GoTo SiguienteMaterial
                            If IsNumeric(oRow!Numero) Then
                                Talla = Format(CDec(oRow!Numero), "#.0")
                            Else
                                Talla = CStr(oRow!Numero).Trim
                            End If
                            If CStr(oRowPD!Material).Trim.ToUpper = CStr(oRow!CodArticulo).Trim.ToUpper AndAlso CStr(oRowPD!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                                If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
                                    Talla = CInt(oRow!Numero)
                                Else
                                    Talla = CStr(oRow!Numero).Trim
                                End If
                                oFacturaTemp = oFacturaMgr.Create()
                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!CodArticulo).Trim, oParent.ApplicationContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
                                If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
                                    oNewRow = dtNegados.NewRow
                                    With oNewRow
                                        !Codigo = CStr(oRowPD!Material).Trim
                                        !Talla = CStr(oRowPD!Talla).Trim
                                        !Cantidad = 0
                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
                                        !Motivo = "00011"
                                        !MotivoDesc = "Apartado"
                                        !PedidoEC = CStr(oRowP!Folio_Pedido).Trim
                                    End With
                                    dtNegados.Rows.Add(oNewRow)
                                End If
                                oFacturaTemp = Nothing
                                GoTo Siguiente
                            End If
SiguienteMaterial:
                        Next
                    End If
                Next
Siguiente:
            Next
        End If

        Return dtNegados

    End Function

    Private Sub ValidarCambioStatusPedido(ByVal dtNegados As DataTable, ByVal Responsable As String)

        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oRowN As DataRow, oRowP As DataRow
        Dim Pedidos As String = ""
        Dim dvPedDet As DataView

        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        For Each oRowN In dtNegados.Rows
            If InStr(Pedidos.Trim.ToUpper, CStr(oRowN!PedidoEC).Trim.ToUpper) <= 0 Then
                Pedidos &= CStr(oRowN!PedidoEC).Trim.ToUpper & ","
                dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And (Cant_Pendiente > 0 Or Cant_Entregado > 0)", "", DataViewRowState.CurrentRows)
                'dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
                If dvPedDet.Count <= 0 Then
                    oSAPMgr.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, "")
                End If
            End If
        Next

    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2016: Validar facturas no creadas en SAP, pero que si estan en el dppro
    '------------------------------------------------------------------------------------------------------------------------------------

    Public Sub ValidarPedidosNoGuardadosEnSAP()
        Dim oCierreDiaMgr As New CierreDiaManager(oParent.ApplicationContext, oParent.SAPApplicationConfig, oParent.ConfigSaveArchivos)
        Dim lstPedidos As New List(Of Dictionary(Of String, Object))
        'Dim dtFacturas As DataTable = oCierreDiaMgr.GetFacturasSinDPVale(dtFechaInicio.Value) ', dtFechaFin.Value)
        Dim dtFacturas As DataTable = oCierreDiaMgr.GetFacturas(dtFechaInicio.Value, dtFechaFin.Value)
        'Dim dtFacturasSAP As DataTable = oSAPMgr.ZSD_VALIDA_PEDIDOS(dtFechaInicio.Value) ', dtFechaFin.Value)
        Dim dtFacturasSAP As DataTable = oSAPMgr.ZSD_VALIDA_PEDIDOS(dtFechaInicio.Value, dtFechaFin.Value)
        Dim FormaPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oParent.ApplicationContext)
        Dim dtFormasPago As DataTable
        Dim rows() As DataRow = Nothing
        Dim refPRO As String = ""
        Dim refSAP As String = ""
        Me.pbProceso.Minimum = 0
        Me.pbProceso.Maximum = dtFacturas.Rows.Count + 1
        Me.pbProceso.Value = 0
        Dim monto As Decimal = 0
        Dim row As DataRow = Nothing
        dtPedidos.Clear()
        For Each rowPRO As DataRow In dtFacturas.Rows
            refPRO = CStr(rowPRO("Referencia")).Trim()
            monto = CDec(rowPRO("Total"))
            rows = dtFacturasSAP.Select("BSTNK='" & refPRO & "'", "")
            If rows.Length = 0 Then
                row = dtPedidos.NewRow()
                row("Seleccion") = False
                row("FacturaId") = CInt(rowPRO("FacturaId"))
                row("Referencia") = CStr(rowPRO("Referencia"))
                row("Folio") = CStr(rowPRO("FolioFactura"))
                row("Fecha") = CDate(rowPRO("Fecha"))
                dtPedidos.Rows.Add(row)
            End If
        Next
        Me.gridFormaPago.DataSource = dtPedidos
        Me.pbProceso.Value = 0
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2016: Se genera el pedido que por alguna razon marco error en SAP al momento de generarlo
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Private Function CreateOrder(ByVal row As DataRow, ByVal FormasPago As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim oProcesarVenta As New Dictionary(Of String, Object)
        Dim FactMgr As New FacturaManager(oParent.ApplicationContext, oParent.ConfigSaveArchivos)
        Dim response As New Dictionary(Of String, Object)
        Dim oDPVale As New cDPVale
        Try
            Dim oFactura As Factura = FactMgr.Create()
            FactMgr.LoadInto(CInt(row("FacturaId")), oFactura)
            Dim serial As String = FactMgr.GetSerialByFacturaId(oFactura.FacturaID)
            oFactura.SerialId = serial
            With oProcesarVenta
                .Add("I_FECHA_CREACION", Format(oFactura.Fecha, "yyyy-MM-dd"))
                If oFactura.CodTipoVenta = "S" OrElse oFactura.CodTipoVenta = "D" Then
                    .Add("I_SOLICITANTE", oFactura.ClienteId)
                Else
                    .Add("I_SOLICITANTE", "")
                End If
                Dim CatalogoTipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oParent.ApplicationContext)

                Dim MotivoPedido As String = ""
                .Add("I_REQUIERE_FACTURA", "")
                .Add("I_COSTO_ENVIO", 0)
                .Add("I_REFERENCIA", oFactura.Referencia)
                .Add("I_OFICINAVENTAS", "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen)
                If oFactura.CodTipoVenta = "A" Then
                    .Add("I_MOT_PEDIDO", "ZAF")
                Else
                    MotivoPedido = CatalogoTipoVenta.GetMotivoPedidoByTipoVenta(oFactura.CodTipoVenta)
                    .Add("I_MOT_PEDIDO", MotivoPedido)
                End If
                .Add("I_CLASEDOC", "")
                .Add("I_CANAL", "10")
                .Add("I_CEBE", "")
                .Add("I_CENTRO", "")
                .Add("I_GPOVENDEDOR", "")
                .Add("I_ORGVENTAS", "")
                .Add("I_SECTOR", "")
                .Add("I_VERSION_ID", "")
                .Add("I_REP_VENTAS", oFactura.CodVendedor)
                If oFactura.CodTipoVenta = "E" Then
                    Dim valeEmpleado As ValeEmpleado = FactMgr.GetValeEmpleado(oFactura.FacturaID)
                    .Add("I_FOLIO", valeEmpleado.Serie & "|" & valeEmpleado.Folio)
                Else
                    .Add("I_FOLIO", "")
                End If
                .Add("I_HORA", "")
                .Add("I_USUARIO", "")
                .Add("I_PLAZA", "")
                .Add("I_MONTO_TOTAL", 0)
                .Add("I_SERIALID", oFactura.SerialId)
                ' ------------------------------------------------------------------
                ' Llenamos datos de las Formas de Pago 
                '------------------------------------------------------------------
                Dim oFormasPago As New List(Of Dictionary(Of String, Object))
                Dim ImporteSeguro As Decimal = 0
                For Each oRow As DataRow In FormasPago.Rows
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oPago As New Dictionary(Of String, Object)
                    With oPago
                        .Add("FORMA_PAGO", oRow!CodFormasPago)
                        .Add("IMPORTE", CDec(oRow!MontoPago).ToString("##,##0.00").Replace(",", ""))
                        .Add("REFERENCIA", "")
                        .Add("FOLIO", "")
                        .Add("PER_FINANC", "")
                        .Add("NUM_APROBACION", "")
                        If oFactura.CodTipoVenta = "V" Then
                            Dim infoVale As Dictionary(Of String, Object) = FactMgr.GetInfoDetalleDPValeByFormaPago(CInt(oRow!FormaPagoID))
                            .Add("NUMVA", CStr(infoVale("DPValeID")).PadLeft(10, "0"))
                            .Add("NUMDE", CInt(infoVale("Numde")))
                            .Add("DISTRIB", CStr(infoVale("Distribuidor")).PadLeft(10, "0"))
                            .Add("CTEDIST", CStr(infoVale("Ctefinal")).PadLeft(10, "0"))
                            .Add("PARES_PZAS", CInt(infoVale("ParesPza")))
                            .Add("MONTO_UTILIZADO", CDec(infoVale("MontoUtilizado")).ToString("##,##0.00").Replace(",", ""))
                            .Add("MONTODPVALE", CDec(infoVale("MontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                            .Add("FECCO", CDate(infoVale("Fecco")).ToString("yyyyMMdd"))
                            If CBool(infoVale("Revale")) Then
                                .Add("REVALE", "X")
                            Else
                                .Add("REVALE", "")
                            End If
                            '----------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 05/05/2016: Se comento los RPAREZ_PZA porque no se ocupaba.
                            '----------------------------------------------------------------------------------------------------------
                            '.Add("RPARES_PZAS", oDpvaleSAP.RPARES_PZAS)
                            .Add("RMONTODPVALE", CDec(infoVale("RMontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                            If oParent.ConfigSaveArchivos.GenerarSeguro Then
                                Dim DataSecure As New Hashtable()
                                DataSecure("I_NUMVA") = CStr(infoVale("DPValeID")).PadLeft(10, "0")
                                DataSecure("I_KUNNR") = CStr(infoVale("Distribuidor")).PadLeft(10, "0")
                                If oParent.ConfigSaveArchivos.GenerarSeguro Then
                                    DataSecure("I_ZSEG") = "1"
                                Else
                                    DataSecure("I_ZSEG") = "0"
                                End If
                                DataSecure("I_FECCO") = CDate(infoVale("Fecco")).ToString("yyyyMMdd")
                                DataSecure("I_NUMDE") = CInt(infoVale("Numde"))
                                'If oSAPMgr.ZDPVL_VALSEGUROSAFS(DataSecure) = True Then
                                '    oFactura.SeguroVidaSAPDPVL = True
                                '    ImporteSeguro = CDec(infoVale("Impseg"))
                                '    .Add("ZSEG", "1")
                                'Else
                                '    oFactura.SeguroVidaSAPDPVL = False
                                '    ImporteSeguro = 0
                                '    .Add("ZSEG", "0")
                                'End If
                            Else
                                .Add("ZSEG", "0")
                            End If
                            .Add("IMPSEG", ImporteSeguro.ToString("##,##0.00").Replace(",", ""))
                            If infoVale.ContainsKey("Folseg") Then .Add("FOLSEG", CStr(infoVale("Folseg"))) Else .Add("FOLSEG", 0)
                            .Add("DIV", CStr(infoVale("Div")))
                        End If
                        .Add("NTARJETA", "")
                        .Add("SIHAY", "")
                        .Add("PEDIDOSH", "")
                        .Add("STATUS", "")
                    End With
                    oFormasPago.Add(oPago)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_FORMAS_PAGO", oFormasPago)
                oFactura.Detalle = FactMgr.GetFacturasById(oFactura.FacturaID)
                Dim oProductos As New List(Of Dictionary(Of String, Object))
                For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oCodigo As New Dictionary(Of String, Object)
                    With oCodigo
                        .Add("POSNR", "")
                        .Add("ORDERITEM_ID", "")
                        .Add("MATNR", CStr(oRow!CodArticulo).PadLeft(10, "0"))
                        .Add("CANTIDAD", CInt(oRow!Cantidad))
                        If CDec(oRow!Descuento) > 0 Then
                            .Add("DESCUENTO", CDec(oRow!Descuento).ToString("##,##0.00").Replace(",", ""))
                            .Add("CLASE_CONDICION", "ZDP4")
                        Else
                            .Add("DESCUENTO", 0)
                            .Add("CLASE_CONDICION", "")
                        End If

                        'If oFactura.CodTipoVenta = "V" Then
                        '    .Add("CLASE_CONDICION", "ZDP4")
                        'Else
                        '    .Add("CLASE_CONDICION", "") '"ZDP1")
                        'End If

                        .Add("ID_PROMOCION", "")
                        .Add("ALMACEN", "")
                        .Add("MOT_RECHAZO", "")
                    End With
                    oProductos.Add(oCodigo)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_PRODUCTOS", oProductos)
            End With
            If oFactura.CodTipoVenta.Trim() = "O" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
                Dim lstInterlocutor As New List(Of Dictionary(Of String, Object))
                Dim inter As New Dictionary(Of String, Object)
                inter("CLIENTE") = oFactura.ClienteId
                inter("TIPO_CLIENTE") = oFactura.TipoCliente
                lstInterlocutor.Add(inter)
                oProcesarVenta("T_INTERLOCUTORES") = lstInterlocutor
            End If
            '------------------------------------------------------------------
            'Ejecutamos la Transaccion
            '------------------------------------------------------------------
            Dim oRetail As New ProcesosRetail("/pos/ventas_directas", "POST", oParent.ConfigSaveArchivos, oParent.ApplicationContext, oParent.SAPApplicationConfig)
            oRetail.Parametros.Add("SerialID", oFactura.SerialId)
            response = oRetail.SapZsdProcesoventa(oProcesarVenta, False)
            FactMgr.SaveSerial(oFactura.SerialId, "S", oParent.ApplicationContext.Security.CurrentUser.ID, oFactura.FacturaID)
            valido = True
        Catch ex As Exception
            valido = False
        End Try
        Return valido
    End Function

#Region "Realizar los Ajustes Automaticos Pendientes"

    Private Sub RealizarAjustesAutomaticosPendientes()

        Dim dtAjustesTallaPNC As DataTable
        Dim FacturaSAP As String

        dtAjustesTallaPNC = oAjusteMgr.LoadAjustesPendientesAllNC()

        For Each oRow As DataRow In dtAjustesTallaPNC.Rows

            oNotaCredito = oNotaCreditoMgr.Load(oRow!NotaCreditoID)

            If Not oNotaCredito Is Nothing Then

                If oNotaCredito.FIDOCUMENT <> "" AndAlso oNotaCredito.SALESDOCUMENT <> "" Then

                    oAjuste = oAjusteMgr.Create
                    oAjuste.FolioAjuste = oAjusteMgr.GetFolio
                    oAjuste.Almacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    oAjuste.Observaciones = "Ajuste Automático por Devolución"

                    Dim dtAjustesTallaByNC As DataTable

                    dtAjustesTallaByNC = oAjusteMgr.LoadAjustesPendientesByNotaCreditoID_All(oRow!NotaCreditoID)

                    For Each drRow As DataRow In dtAjustesTallaByNC.Rows

                        Dim oNewRow As DataRow = oAjuste.Detalle.NewRow()

                        oNewRow("Codigo") = drRow("CodArticulo")
                        oNewRow("Descripcion") = drRow("Descripcion")
                        oNewRow("TallaS") = drRow("TallaFactura")
                        oNewRow("TallaE") = drRow("TallaReal")
                        oNewRow("Cantidad") = drRow("Cantidad")
                        oNewRow("Reversa") = 1
                        oNewRow("Tipo") = "AA"
                        oNewRow("CantDevuelta") = drRow("Cantidad")
                        FacturaSAP = drRow("FacturaSAP")

                        oAjuste.Detalle.Rows.Add(oNewRow)

                    Next

                    'Para que llene en todos los registros el folio SAP
                    For Each oADRow As DataRow In oAjuste.Detalle.Rows
                        oAjuste.Codigo = oADRow!codigo
                        oAjuste.Cantidad = oADRow!cantidad
                        oAjuste.Talla_S = oADRow!TallaS
                        oAjuste.Talla_E = oADRow!TallaE
                        '------------------------------------
                        oSAPMgr.Write_AJUSTETalla(oAjuste)
                        '------------------------------------
                        oADRow!foliosap = oAjuste.FolioSAP
                    Next

                    'Para ver que se haya grabado por lo menos un ajuste en SAP
                    oAjuste.TotalCodigos = 0
                    For Each oADRow As DataRow In oAjuste.Detalle.Rows
                        If oADRow!foliosap <> String.Empty Then
                            oAjuste.TotalCodigos += 1
                        End If
                    Next
                    '------------------------------------------------------
                    If oAjuste.TotalCodigos <> 0 Then
                        'Dim oGrdRow As Janus.Windows.GridEX.GridEXRow
                        oAjuste.Usuario = oParent.ApplicationContext.ApplicationConfiguration.Usuario
                        oAjuste.FolioFacturaSAP = FacturaSAP.PadLeft(10, "0")
                        oAjusteMgr.Save(oAjuste, 0, True)
                        oAjusteMgr.PutMovimiento(oAjuste, "E")
                        oAjusteMgr.PutMovimiento(oAjuste, "S")
                    Else
                        'MsgBox("Ningun Ajuste se Guardo en SAP",MsgBoxStyle.Exclamation,"Ajustes Talla", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

            End If

        Next

    End Sub

#End Region

    'Private Sub FacturaCANSelDontSaved()

    '    Dim oCierreDiaDG As New CierreDiaDataGateWay(Me.oParent)
    '    Dim dsFacturaSelDontSaved As New DataSet
    '    Dim oFacturaMgr As New FacturaManager(Me.oParent.ApplicationContext)
    '    Dim oCancelarFacturaMgr As New CancelaFacturaManager(Me.oParent.ApplicationContext, Me.oParent.SAPApplicationConfig, oParent.ConfigSaveArchivos)
    '    Dim oFingerMgr As FingerPrintManager

    '    dsFacturaSelDontSaved = oCierreDiaDG.FacturaCANSelDontSaved

    '    Me.pbProceso.Maximum = dsFacturaSelDontSaved.Tables(0).Rows.Count
    '    Me.pbProceso.Value = 0
    '    Me.Text = "Cancelando Facturas Pendientes"

    '    Dim oFactura As Factura

    '    For Each oRow As DataRow In dsFacturaSelDontSaved.Tables(0).Rows

    '        oFactura = oFacturaMgr.Create

    '        Me.ebFactura.Text = oRow("FolioFactura")
    '        Me.nbMonto.Value = oRow("Total")

    '        Me.ebFactura.Refresh()
    '        Me.nbMonto.Refresh()

    '        Dim strFIDOC As String, strSALESDOC As String
    '        Dim RestService As New ProcesosRetail("pos/factura", "POST", oParent.ConfigSaveArchivos, oParent.ApplicationContext, oParent.SAPApplicationConfig)
    '        Dim result As New Generic.Dictionary(Of String, Object)
    '        oCancelarFacturaMgr.UpdateStatusFacturaCierreDiaRetail(oRow("FacturaID"), oRow("FolioSAP"), oRow("CodVendedor"), oRow("CodAlmacen"), strFIDOC, strSALESDOC)
    '        result = RestService.SapZbapisd29Cancelacion(oRow("FacturaID"), oRow("FolioSAP"), oRow("CodVendedor"), oRow("CodAlmacen"), strFIDOC, strSALESDOC)

    '        If strFIDOC <> "" AndAlso strSALESDOC <> "" Then
    '            oFacturaMgr.LoadInto(oRow("FacturaID"), oFactura)
    '            '--------------------------------------------------------------------------------------------------------------------------------------------
    '            'Cancelamos la venta en el servidor de PG
    '            '--------------------------------------------------------------------------------------------------------------------------------------------
    '            If oParent.ConfigSaveArchivos.UsarHuellas Then
    '                If oFactura.CodTipoVenta = "P" AndAlso oFactura.FolioSAP.Trim <> "" Then
    '                    oFingerMgr = New FingerPrintManager(oParent.ApplicationContext, oParent.ConfigSaveArchivos)
    '                    If oFingerMgr.CancelaClienteVenta(oFactura.FolioSAP, strSALESDOC, strFIDOC) Then
    '                        oFacturaMgr.ActualizaStatusEnvioServerPG(oFactura.FolioSAP, 2)
    '                    End If
    '                End If
    '            End If
    '            '-------------------------------------------------------------------------------------------------------------
    '            'Revivimos Vale de Empleado en caso de que existiera
    '            '-------------------------------------------------------------------------------------------------------------
    '            If oFactura.CodTipoVenta = "E" Then
    '                RestService = New ProcesosRetail("pos/factura", "POST", oParent.ConfigSaveArchivos, oParent.ApplicationContext, oParent.SAPApplicationConfig)
    '                RestService.SapZRevivirvaledescto(oRow("FolioSAP"))
    '                'oSAPMgr.ZBAPI_REVIVE_VALE_EMPLEADO(oRow("FolioSAP"))
    '            End If
    '            '-------------------------------------------------------------------------------------------------------------
    '            'Revivimos el cupon de descuento en caso de existir en la factura
    '            '-------------------------------------------------------------------------------------------------------------
    '            Dim strFolioCupon As String = ""
    '            strFolioCupon = oFacturaMgr.GetCuponDescuento(oFactura.FacturaID)
    '            If strFolioCupon.Trim <> "" Then
    '                oFacturaMgr.MarcarCuponDescuentoUsado(False, strFolioCupon, oFactura.FacturaID)
    '                RestService.Metodo = "pos/cupon"
    '                RestService.SapZCupCancelacion(strFolioCupon)
    '                'oSAPMgr.ZBAPI_REVIVE_CUPON(strFolioCupon)
    '            End If

    '        End If

    '        Me.pbProceso.Value += 1
    '        Me.pbProceso.Refresh()

    '    Next
    'End Sub


    Private Sub frmGuardarFacturasPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oAjusteMgr = New AjusteGeneralTallaManager(oParent.ApplicationContext)

        oNotaCreditoMgr = New NotasCreditoManager(oParent.ApplicationContext, oParent.SAPApplicationConfig, oParent.ConfigSaveArchivos)

        oSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        ValidarPedidosNoGuardadosEnSAP()
    End Sub

    Private Sub btnFacturar_Click(sender As System.Object, e As System.EventArgs) Handles btnFacturar.Click
        SavePedidos()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/10/2016: Guarda los pedidos en SAP que hayan fallado al guardarse
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub SavePedidos()
        Dim rows() As DataRow = Nothing
        Dim FormaPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oParent.ApplicationContext)
        Dim dtFormasPago As DataTable
        Dim strMensaje As String = "", facGuardado As String = ""
        rows = dtPedidos.Select("Seleccion=true")
        Me.pbProceso.Minimum = 0
        Me.pbProceso.Maximum = rows.Length
        Me.pbProceso.Value = 0
        If rows.Length > 0 Then
            For Each row As DataRow In rows
                FormaPago.ClearFields()
                dtFormasPago = FormaPago.Load(CInt(row("FacturaId"))).Tables(0)
                If CreateOrder(row, dtFormasPago) = False Then
                    strMensaje &= "Factura No Guardada: " & CStr(row("Referencia")) & vbCrLf
                Else
                    facGuardado &= "Factura Guardada: " & CStr(row("referencia")) & vbCrLf
                End If
                Me.pbProceso.Value += 1
                Application.DoEvents()
            Next
        End If
        Me.pbProceso.Minimum = 0
        Me.pbProceso.Maximum = 0
        Me.pbProceso.Value = 0
        If strMensaje.Trim() <> "" Then
            MessageBox.Show(strMensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If facGuardado.Trim() <> "" Then
            MessageBox.Show(facGuardado, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        ValidarPedidosNoGuardadosEnSAP()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub


    Private Sub SelectCheckBox(ByVal value As Boolean)
        If Not dtPedidos Is Nothing Then
            If dtPedidos.Rows.Count > 0 Then
                For Each row As DataRow In dtPedidos.Rows
                    row("Seleccion") = value
                    row.AcceptChanges()
                Next
                dtPedidos.AcceptChanges()
            End If
        End If
    End Sub

    Private Sub cbSelectAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbSelectAll.CheckedChanged
        SelectCheckBox(cbSelectAll.Checked)
    End Sub
End Class
