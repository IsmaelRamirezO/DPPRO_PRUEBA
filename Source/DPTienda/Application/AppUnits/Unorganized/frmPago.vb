Imports System
Imports System.Data
Imports System.io
Imports Janus.Windows.GridEX

Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas 
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoDescuento
Imports DportenisPro.DPTienda.ApplicationUnits.PeriodoDetalleUI
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPromocionesAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports System.Drawing.Printing
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports MQTT
Imports System.Collections.Generic
Imports Pinpad

Imports Newtonsoft.Json
Imports uPaydll
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU

Public Class frmPago

    Inherits System.Windows.Forms.Form
    Public tipoV As Boolean = False
    Dim booleHub As Boolean = False
    Dim bolCargoEHub As Boolean = False
    Dim intPromo As Integer = 0
    Dim m_oCupon As CuponDescuento = Nothing
    Dim strFolioFIValeCaja As String = ""
    Dim strClienteSAPValeCaja As String = ""
    Dim strFolioFIVta As String = ""
    Dim FechaSAP As DateTime
    Public bReintentoDPVL As Boolean = False
    Public strDatosPromoClientes As String = ""
    Private resultado As Hashtable
    Private deslizada As Boolean = False
    Private ValeInfo As Dictionary(Of String, Object)
    Private motivo As String = String.Empty
    Dim userAuth As String = String.Empty

    '----------------------------------------------------------
    ' JNAVA (09.06.2015): Datos de financiamiento Seg. DPVale
    '----------------------------------------------------------
    Dim DivPlaza As String = ""

    '--------------------------------------------------------
    ' JNAVA (02.07.2015): Rechazo Seguro DPVL
    '--------------------------------------------------------
    Private RechazoSeguro As String = ""
    Dim bPrimeraCompraKarum As Boolean = False
    Private MontoSeguro As New Dictionary(Of String, Object)

    '--------------------------------------------------------------------
    'FLIZARRAGA 24/08/2016: Proveedor de Puntos
    '--------------------------------------------------------------------
    Private Provider As Integer

    '--------------------------------------------------------------------
    'FLIZARRAGA 14/11/2017: Fecha de primer pago
    '--------------------------------------------------------------------
    Public FechaPrimerPago As DateTime
    Private oDPVale As cDPVale

    '--------------------------------------------------------------------
    'FLIZARRAGA 08/03/2018: Valida que haya autorizacion con bonificación
    '--------------------------------------------------------------------
    Private Activacion As Boolean = False
    Private DatosPuntoFactura As Hashtable

    '--------------------------------------------------------------------------
    'FLIZARRAGA 17/08/2018: Obtiene el nombre del cliente que canjeo artículos
    '--------------------------------------------------------------------------
    Private NombreClienteCanje As String
    Private IsRedeem As Boolean = False

    '-----------------------------------------------------------------------------------------------------------
    'MLVARGAS 28/02/2020: Lista para almacenar los id's de los registros insertados a transacciones sin tarjeta
    '-----------------------------------------------------------------------------------------------------------
    Dim lstItems As New List(Of Integer)


#Region "Banamex"

    Private Sub ReeimpresionBanamex(ByVal dtFormasPago As DataTable)
        If oConfigCierreFI.PagosBanamex Then
            Dim pay As New uPaydll.upaydll
            Dim DPValeId As String = ""
            For Each row As DataRow In dtFormasPago.Rows
                If CStr(row("CodFormasPago")).Trim() = "TACR" Or CStr(row("CodFormasPago")).Trim() = "TADB" Then
                    DPValeId = CStr(row("DPValeID"))
                    pay.reimpresion(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, DPValeId)
                End If
            Next
        End If
    End Sub

#End Region

#Region "DPCard Puntos"
    Private pagoDPPT As Hashtable
    Private dpCardCliente As Hashtable
    Private dpDatosRenew As Hashtable
    Private pedidoId As Integer
    Private factura As Factura
#End Region

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (11.04.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit
    Dim VentaIdS2c As String = String.Empty
    'Dim oDPValeS2C As Dictionary(Of String, Object) 'InfoValeS2Credit
    'Dim oPromocionesS2C As Dictionary(Of String, Object) 'PromocionesS2Credit
    'Dim oSegurosS2C As Dictionary(Of String, Object) 'SegurosS2Credit
    'Dim oClienteResS2C As List(Of Dictionary(Of String, Object)) 'ResultadoClienteS2Credit
    'Dim oResVentaS2C As Dictionary(Of String, Object) 'ResultadoVentaS2Credit

#End Region

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        InitializeObjects()

        InitializeObjectsSAP()
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
    Friend WithEvents explorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebAutorizacion As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebTotalComision As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblLabel10 As System.Windows.Forms.Label
    Friend WithEvents ebTotalPagoCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebTipoTarjeta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebCambioCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioValeCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebAhorro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gridFormaPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EBPagoCom As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EBBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EBTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPromocion As System.Windows.Forms.Label
    Friend WithEvents cmbPromocion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblCronometro As System.Windows.Forms.Label
    Friend WithEvents timer1 As System.Timers.Timer
    Friend WithEvents lblCapturaDatos As System.Windows.Forms.Label
    Friend WithEvents lblF12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPago))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblCapturaDatos = New System.Windows.Forms.Label()
        Me.lblF12 = New System.Windows.Forms.Label()
        Me.lblCronometro = New System.Windows.Forms.Label()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.cmbPromocion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblPromocion = New System.Windows.Forms.Label()
        Me.ebAutorizacion = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebTotalComision = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLabel10 = New System.Windows.Forms.Label()
        Me.ebTotalPagoCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebTipoTarjeta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebCambioCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolioValeCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebAhorro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gridFormaPago = New Janus.Windows.GridEX.GridEX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EBPagoCom = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EBBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EBTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.timer1 = New System.Timers.Timer()
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar3.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar3
        '
        Me.explorerBar3.Controls.Add(Me.lblCapturaDatos)
        Me.explorerBar3.Controls.Add(Me.lblF12)
        Me.explorerBar3.Controls.Add(Me.lblCronometro)
        Me.explorerBar3.Controls.Add(Me.btnLeerTarjeta)
        Me.explorerBar3.Controls.Add(Me.cmbPromocion)
        Me.explorerBar3.Controls.Add(Me.lblPromocion)
        Me.explorerBar3.Controls.Add(Me.ebAutorizacion)
        Me.explorerBar3.Controls.Add(Me.ebNumTarj)
        Me.explorerBar3.Controls.Add(Me.ebTotalComision)
        Me.explorerBar3.Controls.Add(Me.Label10)
        Me.explorerBar3.Controls.Add(Me.lblLabel10)
        Me.explorerBar3.Controls.Add(Me.ebTotalPagoCliente)
        Me.explorerBar3.Controls.Add(Me.ebCodBanco)
        Me.explorerBar3.Controls.Add(Me.ebTipoTarjeta)
        Me.explorerBar3.Controls.Add(Me.Label4)
        Me.explorerBar3.Controls.Add(Me.Label5)
        Me.explorerBar3.Controls.Add(Me.lblLabel5)
        Me.explorerBar3.Controls.Add(Me.lblLabel2)
        Me.explorerBar3.Controls.Add(Me.lblLabel1)
        Me.explorerBar3.Controls.Add(Me.lblLabel4)
        Me.explorerBar3.Controls.Add(Me.ExplorerBar1)
        Me.explorerBar3.Controls.Add(Me.ebFolioValeCaja)
        Me.explorerBar3.Controls.Add(Me.Label3)
        Me.explorerBar3.Controls.Add(Me.ExplorerBar2)
        Me.explorerBar3.Controls.Add(Me.cmbFormaPago)
        Me.explorerBar3.Controls.Add(Me.gridFormaPago)
        Me.explorerBar3.Controls.Add(Me.Label13)
        Me.explorerBar3.Controls.Add(Me.EBPagoCom)
        Me.explorerBar3.Controls.Add(Me.EBPago)
        Me.explorerBar3.Controls.Add(Me.Label12)
        Me.explorerBar3.Controls.Add(Me.EBBanco)
        Me.explorerBar3.Controls.Add(Me.Label11)
        Me.explorerBar3.Controls.Add(Me.Label1)
        Me.explorerBar3.Controls.Add(Me.EBTarjeta)
        Me.explorerBar3.Controls.Add(Me.Label6)
        Me.explorerBar3.Controls.Add(Me.Label2)
        Me.explorerBar3.Controls.Add(Me.uitnAgregar)
        Me.explorerBar3.Controls.Add(Me.Label9)
        Me.explorerBar3.Controls.Add(Me.txtCVV2)
        Me.explorerBar3.Controls.Add(Me.Label16)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Expanded = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Formas de Pago"
        Me.explorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.explorerBar3.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar3.Name = "explorerBar3"
        Me.explorerBar3.Size = New System.Drawing.Size(752, 512)
        Me.explorerBar3.TabIndex = 0
        Me.explorerBar3.Text = "ExplorerBar3"
        Me.explorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblCapturaDatos
        '
        Me.lblCapturaDatos.BackColor = System.Drawing.Color.Transparent
        Me.lblCapturaDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapturaDatos.ForeColor = System.Drawing.Color.Black
        Me.lblCapturaDatos.Location = New System.Drawing.Point(320, 480)
        Me.lblCapturaDatos.Name = "lblCapturaDatos"
        Me.lblCapturaDatos.Size = New System.Drawing.Size(164, 16)
        Me.lblCapturaDatos.TabIndex = 95
        Me.lblCapturaDatos.Text = "Capturar Datos Cliente"
        Me.lblCapturaDatos.Visible = False
        '
        'lblF12
        '
        Me.lblF12.BackColor = System.Drawing.Color.Transparent
        Me.lblF12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblF12.ForeColor = System.Drawing.Color.Red
        Me.lblF12.Location = New System.Drawing.Point(288, 480)
        Me.lblF12.Name = "lblF12"
        Me.lblF12.Size = New System.Drawing.Size(32, 24)
        Me.lblF12.TabIndex = 94
        Me.lblF12.Text = "F12"
        Me.lblF12.Visible = False
        '
        'lblCronometro
        '
        Me.lblCronometro.BackColor = System.Drawing.Color.Transparent
        Me.lblCronometro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCronometro.Location = New System.Drawing.Point(8, 328)
        Me.lblCronometro.Name = "lblCronometro"
        Me.lblCronometro.Size = New System.Drawing.Size(88, 24)
        Me.lblCronometro.TabIndex = 93
        Me.lblCronometro.Text = "00 : 00 : 00"
        Me.lblCronometro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCronometro.Visible = False
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(360, 192)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 10
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbPromocion
        '
        Me.cmbPromocion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPromocion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbPromocion.DesignTimeLayout = GridEXLayout1
        Me.cmbPromocion.Enabled = False
        Me.cmbPromocion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmbPromocion.Location = New System.Drawing.Point(328, 224)
        Me.cmbPromocion.Name = "cmbPromocion"
        Me.cmbPromocion.Size = New System.Drawing.Size(72, 22)
        Me.cmbPromocion.TabIndex = 12
        Me.cmbPromocion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPromocion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPromocion
        '
        Me.lblPromocion.AccessibleDescription = "0"
        Me.lblPromocion.AutoSize = True
        Me.lblPromocion.BackColor = System.Drawing.Color.Transparent
        Me.lblPromocion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromocion.Location = New System.Drawing.Point(248, 224)
        Me.lblPromocion.Name = "lblPromocion"
        Me.lblPromocion.Size = New System.Drawing.Size(84, 16)
        Me.lblPromocion.TabIndex = 34
        Me.lblPromocion.Text = "Promoción :"
        '
        'ebAutorizacion
        '
        Me.ebAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAutorizacion.Enabled = False
        Me.ebAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAutorizacion.Location = New System.Drawing.Point(152, 224)
        Me.ebAutorizacion.MaxLength = 10
        Me.ebAutorizacion.Name = "ebAutorizacion"
        Me.ebAutorizacion.Numeric = True
        Me.ebAutorizacion.Size = New System.Drawing.Size(88, 22)
        Me.ebAutorizacion.TabIndex = 11
        Me.ebAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Enabled = False
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(152, 192)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(208, 22)
        Me.ebNumTarj.TabIndex = 9
        Me.ebNumTarj.TabStop = False
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTotalComision
        '
        Me.ebTotalComision.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalComision.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalComision.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalComision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalComision.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalComision.Location = New System.Drawing.Point(152, 288)
        Me.ebTotalComision.MaxLength = 8
        Me.ebTotalComision.Name = "ebTotalComision"
        Me.ebTotalComision.ReadOnly = True
        Me.ebTotalComision.Size = New System.Drawing.Size(112, 22)
        Me.ebTotalComision.TabIndex = 13
        Me.ebTotalComision.TabStop = False
        Me.ebTotalComision.Text = "$0.00"
        Me.ebTotalComision.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalComision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = "0"
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Total Com. Tarjeta  :"
        '
        'lblLabel10
        '
        Me.lblLabel10.AccessibleDescription = "0"
        Me.lblLabel10.AutoSize = True
        Me.lblLabel10.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel10.Location = New System.Drawing.Point(472, 176)
        Me.lblLabel10.Name = "lblLabel10"
        Me.lblLabel10.Size = New System.Drawing.Size(129, 16)
        Me.lblLabel10.TabIndex = 24
        Me.lblLabel10.Text = "Total Pago Cliente:"
        '
        'ebTotalPagoCliente
        '
        Me.ebTotalPagoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalPagoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalPagoCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalPagoCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalPagoCliente.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalPagoCliente.Location = New System.Drawing.Point(608, 176)
        Me.ebTotalPagoCliente.MaxLength = 8
        Me.ebTotalPagoCliente.Name = "ebTotalPagoCliente"
        Me.ebTotalPagoCliente.ReadOnly = True
        Me.ebTotalPagoCliente.Size = New System.Drawing.Size(118, 22)
        Me.ebTotalPagoCliente.TabIndex = 25
        Me.ebTotalPagoCliente.TabStop = False
        Me.ebTotalPagoCliente.Text = "$0.00"
        Me.ebTotalPagoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalPagoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodBanco
        '
        Me.ebCodBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.ebCodBanco.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.ebCodBanco.DesignTimeLayout = GridEXLayout2
        Me.ebCodBanco.Enabled = False
        Me.ebCodBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Location = New System.Drawing.Point(152, 161)
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.Size = New System.Drawing.Size(72, 22)
        Me.ebCodBanco.TabIndex = 6
        Me.ebCodBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoTarjeta
        '
        Me.ebTipoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoTarjeta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.ebTipoTarjeta.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.ebTipoTarjeta.DesignTimeLayout = GridEXLayout3
        Me.ebTipoTarjeta.Enabled = False
        Me.ebTipoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoTarjeta.Location = New System.Drawing.Point(152, 129)
        Me.ebTipoTarjeta.Name = "ebTipoTarjeta"
        Me.ebTipoTarjeta.Size = New System.Drawing.Size(48, 22)
        Me.ebTipoTarjeta.TabIndex = 4
        Me.ebTipoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(656, 480)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Cancelar"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(624, 480)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Esc"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(152, 480)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(164, 16)
        Me.lblLabel5.TabIndex = 31
        Me.lblLabel5.Text = "Guardar e Imprimir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(48, 480)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 29
        Me.lblLabel2.Text = "Guardar"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(128, 480)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 30
        Me.lblLabel1.Text = "F9"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(24, 480)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 28
        Me.lblLabel4.Text = "F2"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebCambioCliente)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.ForeColor = System.Drawing.Color.Black
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Su cambio es :"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(16, 352)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(384, 120)
        Me.ExplorerBar1.TabIndex = 27
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebCambioCliente
        '
        Me.ebCambioCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCambioCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCambioCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebCambioCliente.Font = New System.Drawing.Font("Tahoma", 33.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCambioCliente.ForeColor = System.Drawing.Color.Black
        Me.ebCambioCliente.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebCambioCliente.Location = New System.Drawing.Point(54, 40)
        Me.ebCambioCliente.Name = "ebCambioCliente"
        Me.ebCambioCliente.ReadOnly = True
        Me.ebCambioCliente.Size = New System.Drawing.Size(288, 61)
        Me.ebCambioCliente.TabIndex = 16
        Me.ebCambioCliente.TabStop = False
        Me.ebCambioCliente.Text = "$0.00"
        Me.ebCambioCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCambioCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioValeCaja
        '
        Me.ebFolioValeCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioValeCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioValeCaja.ControlStyle.ControlColor = System.Drawing.SystemColors.Window
        Me.ebFolioValeCaja.Enabled = False
        Me.ebFolioValeCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioValeCaja.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioValeCaja.Location = New System.Drawing.Point(152, 69)
        Me.ebFolioValeCaja.MaxLength = 10
        Me.ebFolioValeCaja.Name = "ebFolioValeCaja"
        Me.ebFolioValeCaja.Size = New System.Drawing.Size(112, 22)
        Me.ebFolioValeCaja.TabIndex = 2
        Me.ebFolioValeCaja.Text = "0"
        Me.ebFolioValeCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioValeCaja.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolioValeCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = "0"
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Folio Vale de Caja   :"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.Controls.Add(Me.ebImporteTotal)
        Me.ExplorerBar2.Controls.Add(Me.ebAhorro)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Importe"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(408, 208)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(322, 264)
        Me.ExplorerBar2.TabIndex = 26
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebImporteTotal
        '
        Me.ebImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.BackColor = System.Drawing.SystemColors.Info
        Me.ebImporteTotal.Font = New System.Drawing.Font("Tahoma", 33.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporteTotal.ForeColor = System.Drawing.Color.Black
        Me.ebImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporteTotal.Location = New System.Drawing.Point(16, 184)
        Me.ebImporteTotal.Name = "ebImporteTotal"
        Me.ebImporteTotal.ReadOnly = True
        Me.ebImporteTotal.Size = New System.Drawing.Size(288, 61)
        Me.ebImporteTotal.TabIndex = 17
        Me.ebImporteTotal.TabStop = False
        Me.ebImporteTotal.Text = "$0.00"
        Me.ebImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAhorro
        '
        Me.ebAhorro.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAhorro.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAhorro.BackColor = System.Drawing.SystemColors.Info
        Me.ebAhorro.Font = New System.Drawing.Font("Tahoma", 33.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAhorro.ForeColor = System.Drawing.Color.Red
        Me.ebAhorro.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebAhorro.Location = New System.Drawing.Point(16, 80)
        Me.ebAhorro.Name = "ebAhorro"
        Me.ebAhorro.ReadOnly = True
        Me.ebAhorro.Size = New System.Drawing.Size(288, 61)
        Me.ebAhorro.TabIndex = 15
        Me.ebAhorro.TabStop = False
        Me.ebAhorro.Text = "$0.00"
        Me.ebAhorro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebAhorro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 23)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Importe Total        :"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Usted Ahorró        :"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbFormaPago.DesignTimeLayout = GridEXLayout4
        Me.cmbFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(152, 40)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(248, 22)
        Me.cmbFormaPago.TabIndex = 1
        Me.cmbFormaPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gridFormaPago
        '
        Me.gridFormaPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.gridFormaPago.DesignTimeLayout = GridEXLayout5
        Me.gridFormaPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridFormaPago.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gridFormaPago.GroupByBoxVisible = False
        Me.gridFormaPago.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.Location = New System.Drawing.Point(408, 40)
        Me.gridFormaPago.Name = "gridFormaPago"
        Me.gridFormaPago.Size = New System.Drawing.Size(322, 130)
        Me.gridFormaPago.TabIndex = 23
        Me.gridFormaPago.TabStop = False
        Me.gridFormaPago.TotalRowFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = "0"
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "No. de Tarjeta         :"
        '
        'EBPagoCom
        '
        Me.EBPagoCom.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.BackColor = System.Drawing.SystemColors.Info
        Me.EBPagoCom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPagoCom.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPagoCom.Location = New System.Drawing.Point(152, 256)
        Me.EBPagoCom.MaxLength = 8
        Me.EBPagoCom.Name = "EBPagoCom"
        Me.EBPagoCom.ReadOnly = True
        Me.EBPagoCom.Size = New System.Drawing.Size(112, 22)
        Me.EBPagoCom.TabIndex = 12
        Me.EBPagoCom.TabStop = False
        Me.EBPagoCom.Text = "$0.00"
        Me.EBPagoCom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EBPagoCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBPago
        '
        Me.EBPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPago.Location = New System.Drawing.Point(152, 99)
        Me.EBPago.MaxLength = 8
        Me.EBPago.Name = "EBPago"
        Me.EBPago.Size = New System.Drawing.Size(112, 22)
        Me.EBPago.TabIndex = 3
        Me.EBPago.Text = "$0.00"
        Me.EBPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EBPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = "0"
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 16)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Comisión Tarjeta     :"
        '
        'EBBanco
        '
        Me.EBBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBBanco.BackColor = System.Drawing.SystemColors.Info
        Me.EBBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.ForeColor = System.Drawing.Color.Black
        Me.EBBanco.Location = New System.Drawing.Point(232, 161)
        Me.EBBanco.Name = "EBBanco"
        Me.EBBanco.ReadOnly = True
        Me.EBBanco.Size = New System.Drawing.Size(168, 22)
        Me.EBBanco.TabIndex = 7
        Me.EBBanco.TabStop = False
        Me.EBBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(139, 16)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Terminal                  :"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "No. Autorización     :"
        '
        'EBTarjeta
        '
        Me.EBTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.EBTarjeta.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EBTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTarjeta.ForeColor = System.Drawing.Color.Black
        Me.EBTarjeta.Location = New System.Drawing.Point(208, 129)
        Me.EBTarjeta.Name = "EBTarjeta"
        Me.EBTarjeta.ReadOnly = True
        Me.EBTarjeta.Size = New System.Drawing.Size(192, 22)
        Me.EBTarjeta.TabIndex = 5
        Me.EBTarjeta.TabStop = False
        Me.EBTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = "0"
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tipo de Tarjeta       :"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Monto a Pagar       :"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Location = New System.Drawing.Point(272, 280)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(128, 32)
        Me.uitnAgregar.TabIndex = 14
        Me.uitnAgregar.Text = "&Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Forma de Pago       :"
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Enabled = False
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(152, 192)
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCVV2.Size = New System.Drawing.Size(75, 22)
        Me.txtCVV2.TabIndex = 8
        Me.txtCVV2.Text = "123"
        Me.txtCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCVV2.Visible = False
        Me.txtCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = "0"
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 192)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(139, 16)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "CVV2                       :"
        Me.Label16.Visible = False
        '
        'timer1
        '
        Me.timer1.Interval = 1000.0R
        Me.timer1.SynchronizingObject = Me
        '
        'frmPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "      Facturación    -   Forma de Pago"
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar3.ResumeLayout(False)
        Me.explorerBar3.PerformLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.gridFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"

    Public Property ModoVenta() As Integer
        Get
            Return modo_venta
        End Get
        Set(ByVal Value As Integer)
            modo_venta = Value
        End Set
    End Property

    Public Property DataSetSiHay() As DataSet
        Get
            Return dsSiHay
        End Get
        Set(ByVal Value As DataSet)
            dsSiHay = Value
        End Set
    End Property

    Public Property dtFormasPago() As DataTable
        Get
            Return m_dtFormasPago
        End Get
        Set(ByVal Value As DataTable)
            m_dtFormasPago = Value
        End Set
    End Property

    Public Property oCuponDesc() As CuponDescuento
        Get
            Return m_oCupon
        End Get
        Set(ByVal Value As CuponDescuento)
            m_oCupon = Value
        End Set
    End Property

    Public Property dtElectronicos() As DataTable
        Get
            Return dtTablaElectronicos
        End Get
        Set(ByVal Value As DataTable)
            dtTablaElectronicos = Value
        End Set
    End Property

#End Region

#Region "Environment Var"

#Region "Global Var"

    Dim pdtGeneralPrintPreview As DataTable

    Dim oFonacotRPT As New cInfoFONACOT

    'Tabla Temporal de Formas de Pago
    Public dsFormasPago As New DataSet

    'Tabla Temporal FormaPago DPVale
    Dim dtDPVale As DataTable
    Public intFolioDPVale As Integer = 0
    Public StrFolioDPVale As String = ""
    Public bReimprir As Boolean = False

    'Tabla Temporal Vales de Caja
    Dim dtValeCaja As DataTable

    Dim vCodTipoDescuento As String

    'Nombre del Asociado y del cliente del Asociado
    Public vNombreAsociado As String
    Public vNombreClienteAsociado As String

    'Si es una factura originada por una NC
    Dim EsInstanciaNC As Boolean = False
    Dim EsInstanciaApartado As Boolean = False
    Dim oDevolucionDPValeInfo As DevolucionDPValeInfo
    Dim decMontoCobranza As Decimal = 0

    'Deuda Facilito
    Dim decDeudaFacilito As Decimal = 0

    'Revale
    Public vSobrante As Decimal
    Dim bPares As Boolean
    Dim vParesConsumidos As Integer
    Dim bImpRevale As Boolean = True

    '--Variable de Condicion de Venta segun el Tipo de Venta
    Dim strCondicionVenta As String = String.Empty
    Dim strListaPrecios As String = String.Empty


    '--Variable para mandar SALDO a Facturas DIPS-Credito
    Dim boolEsCredito As Boolean = False

    Public boolLaImprimo As Boolean
    Dim m_dtFormasPago As DataTable

    Dim strNoAfiliacion As String
    Dim strNombreM As String
    Dim strVencM As String
    Dim mPosEntryM As Integer = 0
    Dim strCriptogramaM As String = ""
    Dim strTarjetaBloq As String
    Public strRazonNoRegistroDatos As String = ""
    Public bCronometro As Boolean = False
    Public strCrono As String = ""
    Public dtDescFormasPago As DataTable
    Dim modo_venta As Integer = 0 'Se usa apra saber si se llama desde el módulo de facturacion o facturacion sin existencia
    Public DPValeVentaID As String = ""

    '-----------------------------------------------------------
    'JNAVA (05.12.2014): Tabla de Electronicos
    '-----------------------------------------------------------    
    Dim dtTablaElectronicos As DataTable

    '-----------------------------------------------------------
    'JNAVA (09.02.2015): Beneficiarios Seguro de Vida
    '----------------------------------------------------------- 
    Public Beneficiarios As String = String.Empty

    '-----------------------------------------------------------
    'JNAVA (11.02.2015): Datos de Seguro de Vida
    '----------------------------------------------------------- 
    Public DatosTicketSeguro As New Hashtable
    Public ImporteSeguro As Decimal = 0
    Private ImporteSeguroQuin As Decimal = 0

#End Region

#Region "Objects Var"

    Dim oFingerPrintMgr As FingerPrintManager

    'Objeto Nota Credito
    'Fonacot Facilito change
    Public oNotaCreditoMgr As DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.NotasCreditoManager
    Public oNotaCredito As DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.NotaCredito

    'Objeto Vale Caja
    'Fonacot Facilito change
    Public oVCMgr As ValeCajaManager
    Public oVC As ValeCaja


    'Objeto Factura
    Dim oFacturaMgr As FacturaManager
    Public oFactura As Factura

    'ValesDescuentoInfo Local
    Dim oValeDescuentoLocalInfo As New ValesDescuentoInfo

    'Objeto Factura Corrida
    Dim oFacturaCorridaMgr As FacturaCorridaManager
    Dim oFacturaCorrida As FacturaCorrida

    'Objeto Factura Forma de Pago
    Dim oFacturaFormaPago As FacturaFormaPago

    'Objeto Articulo
    Dim oCatalogoArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Catalogo Tipo Tarjeta
    Dim oCatalogoTipoTarjetaMgr As CatalogoTipoTarjetasManager
    Dim dsTipoTarjeta As New DataSet

    'Catalogo Bancos
    Dim oCatalogoBancoMgr As CatalogoBancosManager
    Dim dsBanco As New DataSet

    'Catalogo Promociones
    Dim oCatalogoPromoMgr As CatalogoPromocionesManager
    Dim dtPromociones As New DataTable

    Dim owsValidaDPVale As ControlDPValesWS.ControlDPVales
    Public owsDPValeInfo As ControlDPValesWS.DPValeInfo
    Dim oDpvaleSAP As cDPValeSAP

    Dim owsDPvaleFacturaInfo As ControlDPValesWS.DPValeFacturaInfo

    'Objeto Creditos en Tienda
    'Dim oCreditoEnTienda As DportenisPro.DPTienda.ApplicationUnits.Facturas.wsCreditosEnTienda.CreditoCreditosEnTienda
    'Dim OCreditoEnTiendaInfo As DportenisPro.DPTienda.ApplicationUnits.Facturas.wsCreditosEnTienda.CreditoEnTiendaInfo

    'Objeto Pago Credito Directo
    'Dim oPagoCreditoDirecto As wsPagosCreditoDirecto.PagosCreditoDirecto
    'Dim oPagoCreditoDirectoInfo As wsPagosCreditoDirecto.PagosCreditoDirectoInfo

    'Objeto Clientes
    Dim oClienteMgr As ClientesManager
    Dim oCliente As ClienteAlterno

    'Objeto EstadoCuentaAsociadoWS
    'Dim owsEstadoCuentaAsociado As wsEstadoCuentaAsociado.EstadodeCuentaAsociado
    'Dim owsMovimientoInfo2 As wsEstadoCuentaAsociado.MovimientosInfo

    Dim owsMovimientoInfo As ControlDPValesWS.MovimientosInfo

    'Objeto Vale de Caja
    Dim oValeCajaMgr As ValeCajaManager
    Dim oValeCaja As ValeCaja

    'Objeto wsValesDescuentoEmpleado
    Dim oWsValesDescuentoE As _
            DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoDescuento.ws.ValesDescuentoEmpleado.ValesDescuentoEmpleado
    Dim oWsValesDescuentoEInfo As _
            DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoDescuento.ws.ValesDescuentoEmpleado.ValesDescuentoEmpleadoInfo

    '--Implementación del CatalogoFormasPago
    Dim oCatFormaPago As CatalogoFormasPagoManager

#End Region

#Region "SAP Objects"

    Public oSAPMgr As ProcesoSAPManager

#End Region

#Region "Variables SiHay"
    Private dsSiHay As DataSet
#End Region

#Region "Variables DPCard"
    '------------------------------------------------
    'JNAVA (26.02.2015): Datos DP Card
    '------------------------------------------------
    Dim htDatosDPC As Hashtable
    Dim ClienteDPC As String = String.Empty
#End Region

#End Region

#Region "Initialize"

    Public Sub InitializeObjects()

        'Nota de Credito
        'Fonacot Facilito change
        oNotaCreditoMgr = New DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        If oNotaCredito Is Nothing Then
            oNotaCredito = oNotaCreditoMgr.Create
        End If

        oFingerPrintMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)

        'Vale Caja
        'Fonacot Facilito change
        oVCMgr = New ValeCajaManager(oAppContext)
        If oVC Is Nothing Then
            oVC = oVCMgr.Create
        End If



        'Factura Corrida
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaCorrida = oFacturaCorridaMgr.Create

        'Factura Forma Pago
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)

        'Catalogo Tipo Tarjetas
        oCatalogoTipoTarjetaMgr = New CatalogoTipoTarjetasManager(oAppContext)

        'Catalogo Bancos
        oCatalogoBancoMgr = New CatalogoBancosManager(oAppContext)

        'Catalogo Promociones
        oCatalogoPromoMgr = New CatalogoPromocionesManager(oAppContext, oConfigCierreFI)

        'Creamos Nuestro Objeto Articulo
        oCatalogoArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oCatalogoArticuloMgr.Create

        'DPVale WS
        'owsValidaDPVale = New ControlDPValesWS.ControlDPVales
        oDpvaleSAP = New cDPValeSAP

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    owsValidaDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '                owsValidaDPVale.strURL.TrimStart("/")
        'End If

        'Objeto Credito En Tienda WS
        'oCreditoEnTienda = New DportenisPro.DPTienda.ApplicationUnits.Facturas.wsCreditosEnTienda.CreditoCreditosEnTienda
        'OCreditoEnTiendaInfo = New DportenisPro.DPTienda.ApplicationUnits.Facturas.wsCreditosEnTienda.CreditoEnTiendaInfo

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    oCreditoEnTienda.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '                oCreditoEnTienda.strURL.TrimStart("/")
        'End If

        ''Objeto Pago Credito Directo WS
        'oPagoCreditoDirecto = New wsPagosCreditoDirecto.PagosCreditoDirecto
        'oPagoCreditoDirectoInfo = New wsPagosCreditoDirecto.PagosCreditoDirectoInfo

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    oPagoCreditoDirecto.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '                oPagoCreditoDirecto.strUrl.TrimStart("/")
        'End If

        'Creamos Objeto Clientes
        oClienteMgr = New ClientesManager(oAppContext)
        oCliente = oClienteMgr.CreateAlterno

        'Objeto EstadoCuentaAsociadoWS
        'owsEstadoCuentaAsociado = New wsEstadoCuentaAsociado.EstadodeCuentaAsociado
        'owsMovimientoInfo2 = New wsEstadoCuentaAsociado.MovimientosInfo

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'owsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            '            owsEstadoCuentaAsociado.strURL.TrimStart("/")
        End If

        '--Objeto Vale de Caja
        oValeCajaMgr = New ValeCajaManager(oAppContext)
        oValeCaja = oValeCajaMgr.Create

        '--Implementación CatalogoFormasPago
        oCatFormaPago = New CatalogoFormasPagoManager(oAppContext)

    End Sub

    Public Sub InitializeObjectsSAP()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        FechaSAP = oSAPMgr.MSS_GET_SY_DATE_TIME
        'FechaSAP = DateTime.Now
    End Sub

#End Region

#Region "User Methods"

    Private Sub LimpiaCamposFormaPago(ByVal bResFonacot As Boolean)
        EBPago.Value = ebImporteTotal.Value - ebTotalPagoCliente.Value

        If Not EBPago.Value = 0 Then
            Select Case oFactura.CodTipoVenta
                Case "P"    'Publico General
                    'cmbFormaPago.Value = "VCJA"
                Case "V"    'DPVale
                Case "A"    'Asociado
                Case "C"    'Asociado Credito
                Case "S"    'DPSocio
                Case "F", "K"   'Fonacot
                    If bResFonacot Then cmbFormaPago.Value = "EFEC"
                Case "O"    'Facilito
                    If oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
                        cmbFormaPago.Value = "EFEC"
                    Else
                        cmbFormaPago.Value = "FACI"
                    End If

                Case "M"    'Mayoreo
            End Select
        Else
            Me.cmbFormaPago.Enabled = False
            Me.EBPago.Enabled = False
        End If

        If EBPago.Value < 0 Then
            EBPago.Value = 0
        End If

        ebFolioValeCaja.Value = 0
        ebTipoTarjeta.Text = ""
        EBTarjeta.Text = ""
        ebNumTarj.Text = ""
        ebCodBanco.Text = ""
        ebAutorizacion.Text = ""
        EBTarjeta.Text = ""
        EBBanco.Text = ""
        EBPagoCom.Value = 0
        Me.btnLeerTarjeta.Enabled = False
        Me.cmbPromocion.Enabled = False
        Me.cmbPromocion.Text = ""
        strClienteSAPValeCaja = ""
        strFolioFIValeCaja = ""

        '-------------------------------------------------------------------
        'JNAVA (12.03.2015): Dejamos deshabilitado para que notecleen
        '------------------------------------------------------------------
        Me.ebNumTarj.ReadOnly = True
        'Me.btnLeerTarjeta.Enabled = True

        '-----------------------------------------------------------------------------------------------------------
        'MLVARGAS (30.05.2018): Al final se vuelve a poner forma de pago en efectivo para evitar que repitan DPCard
        '-----------------------------------------------------------------------------------------------------------
        cmbFormaPago.Value = "EFEC"

    End Sub

    Private Sub ActualizaValeCaja()

        Dim oRow As DataRow
        Dim intValeNuevoID As Integer

        For Each oRow In dtValeCaja.Rows

            intValeNuevoID = 0

            oValeCaja = Nothing
            oValeCaja = oValeCajaMgr.Create

            oValeCaja = oValeCajaMgr.Load(oRow("ValeCajaID"))

            If oRow("MontoValeCaja") > oRow("MontoUtilizado") Then

                Dim oValeNuevo As ValeCaja
                oValeNuevo = oValeCajaMgr.Create

                'Generamos vale nuevo
                oValeNuevo.CodCliente = oValeCaja.CodCliente
                oValeNuevo.DocumentoID = oFactura.FacturaID
                oValeNuevo.DocumentoImporte = oFactura.Total
                oValeNuevo.Fecha = Now
                'oValeNuevo.FolioDocumento = oFactura.FolioFactura
                oValeNuevo.FolioDocumento = oFactura.FolioSAP
                oValeNuevo.Importe = oRow("MontoValeCaja") - oRow("MontoUtilizado")
                oValeNuevo.MontoUtilizado = 0
                oValeNuevo.Nombre = oValeCaja.Nombre
                oValeNuevo.StastusRegistro = True

                oValeNuevo.TipoDocumento = "FA"
                'oValeNuevo.TipoDocumento = oValeCaja.DocumentoID

                oValeNuevo.Usuario = oAppContext.Security.CurrentUser.Name
                Dim frmValeC As New FrmValeCaja
                frmValeC.ValeCajaNuevo(oValeNuevo, oRow("ValeCajaID"), oRow("MontoUtilizado"))
                intValeNuevoID = frmValeC.intValeCajaID 'Se saca el id del vale de caja generado


                'GUARDAMOS VALE CAJA DPVALE
                If intValeNuevoID > 0 Then
                    'Insertamos en la tabla de vale de caja DPVL
                    Dim strFIDEV As String = oFacturaMgr.GetFIDEVByValeCajaID(oValeCaja.ValeCajaID)
                    If strFIDEV <> "" Then
                        oNotaCreditoMgr.InsertaValeCajaDPVL(intValeNuevoID, strFIDEV)
                    End If

                End If


                frmValeC.Dispose()
                frmValeC = Nothing
                oValeNuevo = Nothing

            End If

            'oValeCaja.Fecha = Now
            'oValeCaja.TipoDocumento = "FA"  'Factura
            'oValeCaja.FolioDocumento = oFactura.FolioFactura
            'oValeCaja.DocumentoID = oFactura.FacturaID
            oValeCaja.MontoUtilizado = oRow("MontoUtilizado")
            'oValeCaja.DocumentoImporte = oFactura.Total
            'oValeCaja.Usuario = oAppContext.Security.CurrentUser.Name
            oValeCaja.ValeGenerado = intValeNuevoID
            'oValeCaja.FolioFITrasladoSaldo = oRow("FolioFITraslado")

            oValeCaja.ResetFlagNew()

            oValeCajaMgr.Save(oValeCaja)

        Next

        oValeCaja = Nothing

        oValeCajaMgr.Dispose()

        oValeCajaMgr = Nothing

    End Sub

#End Region

#Region "Form Methods"

    Friend Overloads Sub [ShowDialog](ByVal RemoteFactura As Factura, _
                                        ByVal CodTipoDescuento As String, _
                                        ByVal InstanciaNC As Boolean, _
                                        ByVal DevolucionDPVale As DevolucionDPValeInfo, _
                                        ByVal InstanciaApartado As Boolean, _
                                        ByVal oDVDInfo As ValesDescuentoInfo, _
                                        ByVal CondicionVenta As String, _
                                        ByVal ListaPrecios As String)

        'Pasamos a nuestra Factura Local los datos de la Factura
        'oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFactura = oFacturaMgr.Create
        oFactura = RemoteFactura
        ebAhorro.Value = oFactura.DescTotal
        ebImporteTotal.Value = oFactura.Total
        vCodTipoDescuento = CodTipoDescuento
        oValeDescuentoLocalInfo = oDVDInfo
        '--Condicion de Venta
        strCondicionVenta = CondicionVenta
        '--Lista de Precios
        strListaPrecios = ListaPrecios

        'Verificamos si es una instancia de NC
        If InstanciaNC = True Then
            EsInstanciaNC = True
            oDevolucionDPValeInfo = DevolucionDPVale
            oFactura.NotaCreditoID = oDevolucionDPValeInfo.NotaCreditoID
        End If

        'Verificamos si es una instancia de Apartado
        If InstanciaApartado Then
            EsInstanciaApartado = True
        End If

        Me.ShowDialog()

    End Sub

    Private Sub uitnAgregar_Click(ByVal sender As System.Object, _
                                  ByVal e As System.EventArgs) _
            Handles uitnAgregar.Click

        'Dim bolProcDPvale As Boolean = False

        If ebTotalPagoCliente.Value >= ebImporteTotal.Value Then
            MsgBox("No se pueden agregar más pagos. El Importe Total ha sido cubierto. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Forma de Pago")
            Exit Sub
        End If

        If EBPago.Value <= 0 And CStr(cmbFormaPago.Value) <> "DPPT" Then
            MsgBox("Ingrese Monto a Pagar.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            EBPago.Focus()
            Exit Sub
        End If

        Dim bResFonacot As Boolean

        Select Case cmbFormaPago.Value

            Case "VCJA"            'Vale de Caja / Anticipo Cliente / Nota de Credito

                AgregaPagoAnticipoCliente()

            Case "EFEC"            'Efectivo

                AgregaPagoEfectivo()

            Case "TACR", "TADB"     'Tarjeta Crédito o Débito
                If oConfigCierreFI.PagosBanamex = True Then
                    AddFormaPagoBanamex()
                Else
                    If bolCargoEHub = False Then
                        Me.ebTipoTarjeta.Value = "TM"
                        Me.ebTipoTarjeta.Focus()
                        Me.uitnAgregar.Focus()
                    End If

                    If ValidaPagoEnTarjeta() Then
                        Dim Pago As Decimal = 0
                        If bolCargoEHub = False Then
                            Dim dvBanco As New DataView(dsBanco.Tables(0), "CodBanco = '" & Me.ebCodBanco.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
                            Dim NumT As String = ""
                            Pago = Me.EBPago.Value
                            NumT = Me.ebNumTarj.Text
                            Me.strNoAfiliacion = oFacturaMgr.GetAfiliacion(Me.cmbPromocion.Value, dvBanco(0)!IDEmisor)
                            If Me.cmbPromocion.Value <> 1 Then
                                Me.cmbFormaPago.Value = "TACR"
                                Me.ebTipoTarjeta.Value = "TM"
                                Me.EBPago.Value = Pago
                                Me.ebNumTarj.Text = NumT
                            End If
                            Me.intPromo = Me.cmbPromocion.Value
                        Else
                            Pago = Me.EBPago.Value
                            If intPromo > 1 Then
                                Me.cmbFormaPago.Value = "TACR"
                                Me.EBPago.Value = Pago
                            End If
                        End If

                        AgregaPagoTarjeta()
                        ebTotalComision.Value = ebTotalComision.Value + EBPagoCom.Value

                        If Me.ebTipoTarjeta.Value = "TM" AndAlso oConfigCierreFI.UsarTPV = False Then
                            ImprimirVoucherManual(mPosEntryM)
                        End If

                        mPosEntryM = 0
                        strNoAfiliacion = ""
                        intPromo = 0
                    Else
                        Exit Sub
                    End If
                End If
                

            Case "FACI"            'Facilito

                AgregaPagoFacilito()

            Case "FONA", "TFON" 'Fonacot

                If EBPago.Value > ebImporteTotal.Value Then
                    MsgBox("Monto Fonacot no puede ser mayor al Total de la Factura. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
                    EBPago.Focus()
                    Exit Sub

                Else

                    'Facilito Fonacot
                    If Not oVC.ValeCajaID > 0 Then

                        Dim ofrmFonacot As New frmAutorizacionFonacot
                        If cmbFormaPago.Value = "FONA" Then
                            ofrmFonacot.TipoVenta = "F"
                        Else
                            ofrmFonacot.TipoVenta = "K"
                        End If

                        ofrmFonacot.CodVendedor = oFactura.CodVendedor
                        ofrmFonacot.MontoFonacot = EBPago.Value
                        ofrmFonacot.CodCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                        ofrmFonacot.ShowDialog()

                        If ofrmFonacot.DialogResult = DialogResult.OK Then

                            If ofrmFonacot.chkTE.Checked Then
                                Me.ebTipoTarjeta.Value = "TE"
                                Me.ebNumTarj.Text = ofrmFonacot.ebNoTarjeta.Text
                            End If

                            AgregaPagoFonacot(ofrmFonacot.EdBxNumAuto.Text)
                            'Cuando ya esten las Impresoras HP
                            If oConfigCierreFI.PrinterHP Then
                                oFonacotRPT.Capital = ofrmFonacot.nbCapital.Text
                                oFonacotRPT.Comision = ofrmFonacot.nbCalculoComision.Text
                                oFonacotRPT.Credito = ofrmFonacot.nbCredito.Text
                                oFonacotRPT.Expedidapor = UCase(ofrmFonacot.EdBxExpPor.Text)
                                oFonacotRPT.AnioExpedicion = ofrmFonacot.CalendarCmbAñoExp.Value.Year.ToString
                                oFonacotRPT.Identificacion = UCase(ofrmFonacot.UCmbBxIdentificacion.Text)
                                oFonacotRPT.Interes = ofrmFonacot.nbIntereses.Text
                                oFonacotRPT.NumIdentificacion = UCase(ofrmFonacot.ebNumIdentificacion.Text)
                                oFonacotRPT.PagoMensual = ofrmFonacot.nbPagoMensual.Text
                            End If

                            bResFonacot = True
                        Else
                            bResFonacot = False
                        End If
                        ofrmFonacot.Dispose()
                        ofrmFonacot = Nothing
                    Else
                        'Facilito Fonacot
                        AgregaPagoFonacot("")
                    End If

                End If
            Case "DPVL"            'DPVale
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (27.01.2015): Validamos que si es Venta con Electronicos
                '-------------------------------------------------------------------------------------------------------------------------------
                If HayElectronicos() Then
                    '-------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (27.01.2015): Si es, se revisa el limite con Vales correspondiente a los electronicos
                    '-------------------------------------------------------------------------------------------------------------------------------
                    If CDbl(EBPago.Text) > oConfigCierreFI.ImporteMaximoElectronicosDPVale Then
                        MsgBox("La compra maxima de Electrónicos con VALE es de " & Format(oConfigCierreFI.ImporteMaximoElectronicosDPVale, "$ #,###.00") & " pesos." _
                        & Microsoft.VisualBasic.vbCrLf & _
                        "El resto favor de pagarlo con otra forma de pago.", MsgBoxStyle.Information, "Forma de Pago")
                        EBPago.Focus()
                        Exit Sub
                    End If
                Else
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (27.01.2015): Si No es Venta con electronicos, se hace lo normal
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'Validamos Que no lleve mas de $5,000 con Vales
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 01.07.2014: Se dejo configurable el importe maximo con el que se puede pagar con DPVale
                    '--------------------------------------------------------------------------------------------------------------------------------
                    'If CDbl(EBPago.Text) > 5000 Then
                    If CDbl(EBPago.Text) > oConfigCierreFI.ImporteMaximoDPVale Then
                        MsgBox("La compra maxima con VALE es de " & Format(oConfigCierreFI.ImporteMaximoDPVale, "$ #,###.00") & " pesos." _
                        & Microsoft.VisualBasic.vbCrLf & _
                        "El resto favor de pagarlo con otra forma de pago.", MsgBoxStyle.Information, "Forma de Pago")
                        EBPago.Focus()
                        Exit Sub
                    End If
                    Dim RowPagos() As DataRow = dsFormasPago.Tables(0).Select("CodFormasPago='DPVL'")
                    If RowPagos.Length > 0 Then
                        MessageBox.Show("No se puede agregar dos formas de pago DPVale", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                'If dsFormasPago.Tables(0).Rows.Count > 0 Then
                '    Dim i As Double = IIf(IsDBNull(dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago = DPVL")), 0, dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago = DPVL"))
                '    Dim suma As Double = i + CDbl(EBPago.Text)
                '    If suma > 5000 Then
                '        MsgBox("El monto maximo a pagar con VALE es de $5,000 pesos. ", MsgBoxStyle.Information, "  Forma de Pago")
                '        EBPago.Focus()
                '        Exit Sub
                '    End If
                'End If

                If Not oAppSAPConfig.DPValeSAP Then
                    DPValeImplement()
                Else
                    DPValeImplementSAP()
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 30.04.2015: Comentamos la captura del beneficiario en esta parte porque ahora se tiene que esperar a saber si se genero 
                'realmente el seguro en SAP
                '---------------------------------------------------------------------------------------------------------------------------------
                'CapturarBeneficiario:
                '                '-----------------------------------------------------------------------------
                '                ' JNAVA (09.02.2015): Revisamos si se pide Beneficiario para Generar Seguro
                '                '-----------------------------------------------------------------------------
                '                If Me.oDpvaleSAP.IDDPVale <> String.Empty Then
                '                    If oConfigCierreFI.GenerarSeguro Then
                '                        '-----------------------------------------------------------------------------
                '                        '  JNAVA (13.02.2015): Si es Revale o Rerevale no pide beneficario
                '                        '-----------------------------------------------------------------------------
                '                        If Not Me.oDpvaleSAP.IsRevale AndAlso Not Me.oDpvaleSAP.IsReRevale Then
                '                            '-----------------------------------------------------------------------------
                '                            '  JNAVA (09.02.2015): Capturamos el nombre del Beneficiario
                '                            '-----------------------------------------------------------------------------
                '                            Beneficiarios = InputBox("Beneficiario: ", "Beneficiarios", "", 400, 300)

                '                            '-----------------------------------------------------------------------------
                '                            '  JNAVA (09.02.2015): Si no se capturo el Beneficiario, no dejamos continuar con la venta
                '                            '-----------------------------------------------------------------------------
                '                            If Beneficiarios = "" Then
                '                                MsgBox("Debe capturar el Nombre del Beneficiario para continuar con la Venta.", MsgBoxStyle.Information, "  Forma de Pago")
                '                                GoTo CapturarBeneficiario
                '                            End If
                '                        End If
                '                    End If
                '                End If

            Case "CRED"            'Crédito

                If EBPago.Value <> oFactura.Total Then
                    MsgBox("El Monto a Pagar con Crédito debe ser igual al Monto de la Factura.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Facturación")
                    Exit Select
                End If

                '--Cargamos Datos de Credito del Asociado
                oCliente.Clear()
                Me.oClienteMgr.Load(oFactura.ClienteId, oCliente, oFactura.CodTipoVenta)
                vNombreAsociado = Trim(oCliente.NombreCompleto)
                vNombreClienteAsociado = String.Empty

                Dim vCreditoDisponible As Decimal
                Dim oLimiteCreditoSAP As New CreditoAsociadoSAP
                oLimiteCreditoSAP = oSAPMgr.GetCreditoAsociadoSAP(CStr(oFactura.ClienteId).PadLeft(10, "0"))

                vCreditoDisponible = oLimiteCreditoSAP.LimiteCredito - oLimiteCreditoSAP.Credito

                If oLimiteCreditoSAP.LimiteCredito = 0 Then
                    MsgBox("Cliente No cuenta con Crédito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Clientes DIPs")
                    Exit Select
                ElseIf oLimiteCreditoSAP.Bloqueado = "S" Then
                    MsgBox("Cliente tiene el Crédito Bloqueado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Clientes DIPs")
                    Exit Select
                ElseIf (EBPago.Value > vCreditoDisponible) Then
                    MsgBox("Crédito insuficiente. Disponible : " & Format(vCreditoDisponible, "Currency"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Clientes DIPs")
                    Exit Select
                End If

                AgregaPagoCredito()


            Case "DPCA" ' DPCARD

                '-----------------------------------------------------------------------------
                'JNAVA (27.02.2015): Verificamos que se haya cargado los datos de DPCard
                '-----------------------------------------------------------------------------
                If Me.ebNumTarj.Text.Trim = "" Then
                    MessageBox.Show("No se ha deslizado el DP Card. Favor de Verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                '-----------------------------------------------------------------------------
                'FLIZARRAGA 04/04/2015: Se Valida que no supere el monto
                '-----------------------------------------------------------------------------

                If EBPago.Value > (CDec(ebImporteTotal.Value) - CDec(ebTotalPagoCliente.Value)) Then
                    MsgBox("Monto DPCard no puede ser mayor al Total de la Factura. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Forma de Pago")
                    EBPago.Focus()
                    Exit Sub
                End If

                '-----------------------------------------------------------------------------
                'JNAVA (02.03.2015): Verificamos que se haya seleccionado la promocion
                '-----------------------------------------------------------------------------
                If Me.cmbPromocion.Text = "" Then
                    MessageBox.Show("No se ha seleccionado la Promoción. Favor de Verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                '-----------------------------------------------------------------------------
                'JNAVA (30.01.2015): Autorizar pagos con tarjeta DPCard
                '-----------------------------------------------------------------------------
                If AutorizaCargoDPCard() Then

                    Dim Pago As Decimal = 0
                    Dim NumT As String = ""

                    Pago = Me.EBPago.Value
                    NumT = Me.ebNumTarj.Text

                    'Me.strNoAfiliacion = oFacturaMgr.GetAfiliacion(Me.cmbPromocion.Value, dvBanco(0)!IDEmisor)

                    '-----------------------------------------------------------------------------
                    'Agregamos el pago de DPCard a la Factura
                    '-----------------------------------------------------------------------------
                    If AgregarPagoDPCard() Then

                        '-----------------------------------------------------------------------------
                        ' JNAVA (25.02.2015): Imprimimos Vouchers de cancelacion de ventas
                        '-----------------------------------------------------------------------------
                        Dim oOtrosPagos As New OtrosPagos
                        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA") 'COPIA P/TIENDA
                        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", True) 'COPIA P/CLIENTE

                    Else
                        Exit Sub
                    End If

                Else                    
                    Exit Sub
                End If
            Case "DPPT"
                AgregarFormaPagoDPCardPunto()

        End Select

        '--Actualizamos cambio
        ActualizaCambioCliente()
        '--

        If ebTotalPagoCliente.Value >= ebImporteTotal.Value Then
            MsgBox("El Importe Total ha sido cubierto. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Forma de Pago")
            If cmbFormaPago.Value = "TACR" Or cmbFormaPago.Value = "TADB" Then
                If MessageBox.Show("Se guardará la venta" & vbCrLf & "¿Deseas Imprimir el ticket de Venta?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Select Case Me.ModoVenta
                        Case 0
                            'CerrarVenta(True)
                            CerrarVentaDirecto(True)
                        Case 1
                            'CerrarVentaSH(True)
                            '--------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 28.04.2015: Se corrigio que cuando pagaban con dpvale y una diferencia con tarjeta de debito o credito no
                            '                     guardaba el pedido porque solo mandaba llamar la funcion donde no se contemplaba la forma de
                            '                     pago DPVale
                            '--------------------------------------------------------------------------------------------------------------------
                            'If oConfigCierreFI.DPValeSiHay = True Then
                            CerrarVentaSHDPVale(True)
                            'Else
                            '    CerrarVentaSH(True)
                            'End If
                    End Select
                End If
            End If
        End If

        LimpiaCamposFormaPago(bResFonacot)
        cmbFormaPago.Focus()

    End Sub

    Private Sub CapturaBeneficiarioSeguroDPVL(ByVal oDpvaleSAPLocal As cDPValeSAP)
CapturarBeneficiario:
        '-----------------------------------------------------------------------------
        ' JNAVA (09.02.2015): Revisamos si se pide Beneficiario para Generar Seguro
        '-----------------------------------------------------------------------------
        If oDpvaleSAPLocal.IDDPVale <> String.Empty Then
            If oConfigCierreFI.GenerarSeguro Then
                '-----------------------------------------------------------------------------
                '  JNAVA (13.02.2015): Si es Revale o Rerevale no pide beneficario
                '-----------------------------------------------------------------------------
                If Not oDpvaleSAPLocal.IsRevale AndAlso Not oDpvaleSAPLocal.IsReRevale Then
                    '-----------------------------------------------------------------------------
                    '  JNAVA (09.02.2015): Capturamos el nombre del Beneficiario
                    '-----------------------------------------------------------------------------
                    Beneficiarios = InputBox("Beneficiario: ", "Beneficiarios", "", 400, 300)

                    '-----------------------------------------------------------------------------
                    '  JNAVA (09.02.2015): Si no se capturo el Beneficiario, no dejamos continuar con la venta
                    '-----------------------------------------------------------------------------
                    If Beneficiarios.Trim = "" Then
                        MessageBox.Show("Debe capturar el Nombre del Beneficiario para continuar con la Venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        GoTo CapturarBeneficiario
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub DPValeImplementSAP()
        If EsInstanciaNC = False Then
            '-----------------------------DPVALE SAP-----------------------------
            Dim DPV As New FrmValidacionDpvale(oFactura)

            DPV.DPValeSAP.TipoVenta = oFactura.CodTipoVenta
            DPV.DPValeSAP.ParesPzas = CInt(oFactura.Detalle.Tables(0).Compute("sum(Cantidad)", "cantidad>0"))
            DPV.DPValeSAP.TotalFactura = oFactura.Total
            DPV.DPValeSAP.EBPago = EBPago.Value
            DPV.ShowDialog()

            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            ' JNAVA (13.07.2016): Comentamos por que ya no se utilizara
            '---------------------------------------------------------------------------------------
            ''---------------------------------------------------------------------------------------
            '' JNAVA (13.04.2016): Obtenemos datos del cliente consultados en S2Credit para venta
            ''---------------------------------------------------------------------------------------
            'If oConfigCierreFI.AplicarS2Credit Then
            '    Me.oClienteResS2C = DPV.oClienteResS2C
            '    Me.oDPValeS2C = DPV.oDPValeS2C
            'End If
            ''---------------------------------------------------------------------------------------

            If DPV.DialogResult = DialogResult.OK Then

                Me.oDpvaleSAP = DPV.DPValeSAP

                vNombreAsociado = oDpvaleSAP.NombreAsociado & " (" & oDpvaleSAP.IDAsociado & ")"
                vNombreClienteAsociado = oDpvaleSAP.NombreCliente & " (" & oDpvaleSAP.IDCliente & ")"

                'Revisamos si el monto utilizado es mayor que el total de la factura dejamos como monto utilizado el total de la factura
                If oFactura.Total < oDpvaleSAP.MontoUtilizado Then oDpvaleSAP.MontoUtilizado = oFactura.Total

                ''Aqui modifico lo que se pago con DPVALE por si fue menos''''''
                Me.EBPago.Value = oDpvaleSAP.MontoUtilizado

                If EBPago.Value <= 0 Then
                    MessageBox.Show("El DPVale no pudo ser utilizado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbFormaPago.Focus()
                    Exit Sub
                End If

                If oDpvaleSAP.RPARES_PZAS > 0 Then
                    Me.bPares = True
                    Me.vSobrante = oDpvaleSAP.RPARES_PZAS
                Else
                    Me.bPares = False
                    Me.vSobrante = oDpvaleSAP.RMONTODPVALE
                End If

                bImpRevale = oDpvaleSAP.REVALE
                'owsDPValeInfo = New ControlDPValesWS.DPValeInfo
                'owsDPValeInfo.FechaExpedicion = oDpvaleSAP.FechaExpedicion
                'owsDPValeInfo.FechaEntregado = oDpvaleSAP.FechaExpedicion
                'owsDPValeInfo.DPValeOrigen = oDpvaleSAP.IDDPVale
                'owsDPValeInfo.MontoDPValeI = oDpvaleSAP.MontoUtilizado
                'owsDPValeInfo.MontoDPValeP = oDpvaleSAP.ParesPzas
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                AgregaPagoDPVale(oDpvaleSAP.IDDPVale, _
                                oDpvaleSAP.NombreCliente, _
                                CDate(oDpvaleSAP.FechaExpedicion), _
                                CInt(oDpvaleSAP.IDAsociado), _
                                CInt(oDpvaleSAP.IDCliente))
            Else
                cmbFormaPago.Enabled = True
            End If
            ''-----------------------------DPVALE SAP-----------------------------
        Else
            Dim oCSAP As ClientesSAP
            If EBPago.Value < oDevolucionDPValeInfo.MontoDPVale Then
                MsgBox("El monto debe ser igual o mayor al importe del DPVale devuelto.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                EBPago.Focus()
                Exit Sub
            Else
                If EBPago.Value > ebImporteTotal.Value Then
                    MsgBox("El Monto DPVale debe ser menor al Importe Total. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                    EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                    EBPago.Focus()
                    Exit Sub
                Else
                    If (EBPago.Value > oDevolucionDPValeInfo.MontoDPVale) Then
                        If (EBPago.Value > oDevolucionDPValeInfo.MontoDPVale + oAppContext.ApplicationConfiguration.MargenMaximoDPVale) Then
                            MsgBox("El DPVale devuelto solo puede cubrir hasta " & Format(oDevolucionDPValeInfo.MontoDPVale + oAppContext.ApplicationConfiguration.MargenMaximoDPVale, "currency") & " del Importe Total", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                            EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                            EBPago.Focus()
                            Exit Sub
                        ElseIf oDevolucionDPValeInfo.Status.Trim() <> "" Then
                            MessageBox.Show(oDevolucionDPValeInfo.Status, "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            'Agregamos Pago de Instancia NC dpvale sap
                            If oS2Credit.SearchCustomersWithAmount(oDevolucionDPValeInfo.Codct, CDec(EBPago.Value)) = True Then
                                oCSAP = GetClienteDPVale(oDevolucionDPValeInfo.Codct)
                                If Not oCSAP Is Nothing Then
                                    If oCSAP.Status = 1 Then
                                        'Agregamos Pago de Instancia NC dpvale sap
                                        FillDataOfNCInstanceDPVALESAP()
                                    Else
                                        MessageBox.Show("Cliente Bloqueado", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    ElseIf oDevolucionDPValeInfo.Status.Trim() <> "" Then
                        MessageBox.Show(oDevolucionDPValeInfo.Status, "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        If oS2Credit.SearchCustomersWithAmount(oDevolucionDPValeInfo.Codct, CDec(EBPago.Value)) = True Then
                            oCSAP = GetClienteDPVale(oDevolucionDPValeInfo.Codct)
                            If Not oCSAP Is Nothing Then
                                If oCSAP.Status = 1 Then
                                    'Agregamos Pago de Instancia NC dpvale sap
                                    FillDataOfNCInstanceDPVALESAP()
                                Else
                                    MessageBox.Show("Cliente Bloqueado", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DPValeImplement()

        Dim bolProcDPvale As Boolean = False

        If EsInstanciaNC = False Then       'Verificamos si es una instancia de una Nota de Credito
            ofrmValidaDPVale = New frmValidaDPVale(oAppContext)

            '-- Esta alta de cliente ya no aplica. Este formulario esta en un componente.
            ofrmValidaDPVale.Controls(0).Controls(4).Visible = False

            'TODO Erick--Implementar Boton
            Dim btnClientes As New Janus.Windows.EditControls.UIButton
            With btnClientes
                .Size = ofrmValidaDPVale.Controls(0).Controls(4).Size
                .Location = ofrmValidaDPVale.Controls(0).Controls(4).Location
                .Text = "Alta Clientes"
                .Name = "btnAgregarClientesSAP"
                .Visible = True
                .VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
            End With
            AddHandler btnClientes.Click, AddressOf btnClientes_Click
            ofrmValidaDPVale.Controls(0).Controls.Add(btnClientes)
            'TODO Erick--Implementar Boton

            ofrmValidaDPVale.ShowMe(EBPago.Value, oFactura.Fecha, oFactura.Total, oFactura.Detalle.Tables(0).Compute("sum(Cantidad)", "cantidad>0"))
ReprocesoDPVale:
            If bolProcDPvale Then
                ofrmValidaDPVale.ReShowMe(bolProcDPvale)
            End If
            Select Case ofrmValidaDPVale.DialogResult
                Case DialogResult.Retry
                    Dim ofrmClientes As New CatalogoClientesForm
                    ofrmClientes.ShowMeforFactura()
                    ofrmValidaDPVale.ebClienteAsociadoID.Value = ofrmClientes.pubClienteID
                    ofrmValidaDPVale.ebClienteAsociado.Text = ofrmClientes.PubNombreCliente
                    ofrmClientes.Dispose()
                    ofrmClientes = Nothing
                    bolProcDPvale = True
                    GoTo ReprocesoDPVale
                Case DialogResult.OK
                    Dim FechaExpedicionAsociado As DateTime
                    vNombreAsociado = ofrmValidaDPVale.ebNombreAsociado.Text & " (" & ofrmValidaDPVale.ebAsociadoID.Text & ")"
                    vNombreClienteAsociado = ofrmValidaDPVale.ebClienteAsociado.Text & " (" & ofrmValidaDPVale.ebClienteAsociadoID.Text & ")"
                    FechaExpedicionAsociado = (CDate(ofrmValidaDPVale.msFechaExpedicion.Text) & " 01:00:00")
                    ''Aqui modifico lo que se pago con vale de caja''''''
                    Me.EBPago.Value = ofrmValidaDPVale.vMontoDPVale '''''
                    If EBPago.Value <= 0 Then
                        MessageBox.Show("El vale no pudo ser utilizado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cmbFormaPago.Focus()
                        Exit Sub
                    End If
                    'Implementar ParesPzas.
                    Me.vSobrante = ofrmValidaDPVale.vSobrante
                    Me.owsDPValeInfo = ofrmValidaDPVale.dsDPVale
                    owsDPValeInfo.FechaExpedicion = ofrmValidaDPVale.msFechaExpedicion.Text
                    owsDPValeInfo.FechaEntregado = ofrmValidaDPVale.msFechaExpedicion.Text
                    'owsDPValeInfo.DPValeOrigen = ofrmValidaDPVale.ebDPValeID.Value
                    owsDPValeInfo.MontoDPValeI = ofrmValidaDPVale.ebMontoVale.Value 'Importe "Efectivo" del DPVale
                    owsDPValeInfo.MontoDPValeP = ofrmValidaDPVale.nbParesPzas.Value 'Importe Pares/Pzas del DPVale
                    bImpRevale = ofrmValidaDPVale.bImpRevale
                    Me.bPares = ofrmValidaDPVale.bParesPiezas
                    Me.Logo = ofrmValidaDPVale.Logo
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AgregaPagoDPVale(ofrmValidaDPVale.ebDPValeID.Value, _
                                        ofrmValidaDPVale.ebClienteAsociado.Text, _
                                        FechaExpedicionAsociado, _
                                        ofrmValidaDPVale.ebAsociadoID.Value, _
                                        ofrmValidaDPVale.ebClienteAsociadoID.Value)

            End Select
            ofrmValidaDPVale.Dispose()
            ofrmValidaDPVale = Nothing

        Else
            If EBPago.Value < oDevolucionDPValeInfo.MontoDPVale Then
                MsgBox("El monto debe ser igual o mayor al importe del DPVale devuelto.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                EBPago.Focus()
                Exit Sub
            Else
                If EBPago.Value > ebImporteTotal.Value Then
                    MsgBox("El Monto DPVale debe ser menor al Importe Total. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                    EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                    EBPago.Focus()
                    Exit Sub
                Else
                    If (EBPago.Value > oDevolucionDPValeInfo.MontoDPVale) Then
                        If (EBPago.Value > oDevolucionDPValeInfo.MontoDPVale + oAppContext.ApplicationConfiguration.MargenMaximoDPVale) Then
                            MsgBox("El DPVale devuelto solo puede cubrir hasta " & Format(oDevolucionDPValeInfo.MontoDPVale + oAppContext.ApplicationConfiguration.MargenMaximoDPVale, "currency") & " del Importe Total", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                            EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                            EBPago.Focus()
                            Exit Sub
                        Else
                            'Agregamos Pago de Instancia NC
                            FillDataOfNCInstance()
                        End If
                    Else
                        'Agregamos Pago de Instancia NC
                        FillDataOfNCInstance()
                    End If
                End If
            End If
        End If

    End Sub

    'TODO Erick Metodo Click
    Private ClienteID As Integer
    Dim ofrmValidaDPVale As frmValidaDPVale


    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmClientes As New frmClientesSAP
        frmClientes.TipoVenta = oFactura.CodTipoVenta

        frmClientes.ShowMeforFactura()

        If frmClientes.DialogResult = DialogResult.OK Then

            ClienteID = frmClientes.CodigoClienteDPVALE

            ofrmValidaDPVale.Controls(0).Controls(8).Text = ClienteID
            ofrmValidaDPVale.Controls(0).Controls(14).Text = frmClientes.NombreApellidos

            frmClientes.Dispose()
            frmClientes = Nothing

        Else

            frmClientes.Dispose()
            frmClientes = Nothing
        End If
    End Sub
    'TODO Erick Metodo Click
    Private Sub FillDataOfNCInstance()

        Dim MontoIncrementoDPValeNC As Decimal = 0
        Dim vNombreTemp As String = String.Empty

        owsDPValeInfo = Nothing
        owsDPValeInfo = New ControlDPValesWS.DPValeInfo
        owsDPValeInfo = owsValidaDPVale.GetDPVale(oDevolucionDPValeInfo.DPValeID)

        intFolioDPVale = owsDPValeInfo.DPValeID

        oCliente.Clear()
        oClienteMgr.LoadInto(owsDPValeInfo.ClienteID, oCliente)

        vNombreTemp = Trim(oCliente.Nombre) & " " & Trim(oCliente.ApellidoPaterno) & " " & Trim(oCliente.ApellidoMaterno)

        vNombreAsociado = vNombreTemp & " (" & owsDPValeInfo.AsociadoID & ")"
        vNombreClienteAsociado = owsDPValeInfo.ClienteAsociado & " (" & owsDPValeInfo.ClienteAsociadoID & ")"

        'Asignamos Nuevo Valor del Vale
        MontoIncrementoDPValeNC = (EBPago.Value - oDevolucionDPValeInfo.MontoDPVale)
        oDevolucionDPValeInfo.MontoDPValeUtilizado = EBPago.Value
        owsDPValeInfo.MontoUtilizado = owsDPValeInfo.MontoUtilizado + MontoIncrementoDPValeNC

        'Agregamos Pago
        AgregaPagoDPValeNC()

        Dim drValidaDPValeRow As DataRow
        drValidaDPValeRow = dtDPVale.NewRow

        With drValidaDPValeRow

            .Item("DPValeID") = owsDPValeInfo.DPValeID
            .Item("MontoDPVale") = EBPago.Value
            .Item("ClienteAsociado") = owsDPValeInfo.ClienteAsociado
            .Item("FechaExpedicionAsociado") = owsDPValeInfo.FechaExpedicion
            .Item("AsociadoID") = owsDPValeInfo.AsociadoID
            .Item("ClienteAsociadoID") = owsDPValeInfo.ClienteAsociadoID
            .Item("CodigoSAP") = GetCodigoSAPASociado(owsDPValeInfo.AsociadoID)

            dtDPVale.Rows.Add(drValidaDPValeRow)

        End With

    End Sub

    Private Sub FillDataOfNCInstanceDPVALESAP()

        'Dim MontoIncrementoDPValeNC As Decimal = 0

        owsDPValeInfo = Nothing
        owsDPValeInfo = New ControlDPValesWS.DPValeInfo
        Dim dtDetalleVale As DataTable

        Dim oDPVale As New cDPVale
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 27/09/2017: Se valida si es vale electronico
        '------------------------------------------------------------------------------------------------------
        If IsNumeric(oDevolucionDPValeInfo.DPValeID) Then
            oDevolucionDPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID.PadLeft(10, "0")
        End If
        oDPVale.INUMVA = oDevolucionDPValeInfo.DPValeID.Trim()
        oDPVale.I_RUTA = "X"

        '----------------------------------------------------------------------------------------
        ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
        '----------------------------------------------------------------------------------------
        'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

        '----------------------------------------------------------------------------------------
        ' JNAVA (11.04.2016): Valida DPVale en S2Credit
        '----------------------------------------------------------------------------------------
        'BuscarValeS2Credit(CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0"))

        '----------------------------------------------------------------------------------------
        ' JNAVA (14.07.2016): Valida DPVale
        '----------------------------------------------------------------------------------------
        Dim NombreDistrS2C As String
        If oConfigCierreFI.AplicarS2Credit Then
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, NombreDistrS2C)
        Else
            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
        End If
        '----------------------------------------------------------------------------------

        If oDPVale.EPLAZA = String.Empty Then
            MessageBox.Show("No hay Plaza para el dpvale " & oDPVale.INUMVA.ToString, "sin Plaza", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If oDPVale.EEXIST = "S" Then

            If oDPVale.ESTATU = "A" Then

                Dim oRow As DataRow
                oRow = oDPVale.InfoDPVALE.Rows(0)
                '---------------------------------------------
                oDpvaleSAP.IDDPVale = CInt(oDPVale.INUMVA)
                oDpvaleSAP.TipoVenta = oFactura.CodTipoVenta
                oDpvaleSAP.ParesPzas = CInt(oFactura.Detalle.Tables(0).Compute("sum(Cantidad)", "cantidad>0"))
                oDpvaleSAP.TotalFactura = oFactura.Total
                oDpvaleSAP.EBPago = EBPago.Value
                oDpvaleSAP.InfoDPVALE = oDPVale.InfoDPVALE
                oDpvaleSAP.Plaza = oDPVale.EPLAZA
                oDpvaleSAP.LimiteCredito = oDPVale.LimiteCredito
                oDpvaleSAP.IDAsociado = CStr(oRow("KUNNR"))

                If Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 1, 4) = "0000" Then
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    'oDpvaleSAP.FechaExpedicion = Now.Date
                    'oDpvaleSAP.FechaCreacion = Now.Date
                    oDpvaleSAP.FechaExpedicion = FechaSAP
                    oDpvaleSAP.FechaCreacion = FechaSAP
                Else
                    oDpvaleSAP.FechaExpedicion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
                    oDpvaleSAP.FechaCreacion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
                End If

                If Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 1, 4) = "0000" Then
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    'oDpvaleSAP.FechaInicial = Now.Date
                    oDpvaleSAP.FechaInicial = FechaSAP
                Else
                    oDpvaleSAP.FechaInicial = Mid(oRow("FECIN"), 7, 2) & "/" & Mid(oRow("FECIN"), 5, 2) & "/" & Mid(oRow("FECIN"), 1, 4)
                End If

                oDpvaleSAP.IDCliente = CInt(oRow("CODCT"))
                If oConfigCierreFI.AplicarS2Credit Then
                    oDpvaleSAP.NombreAsociado = NombreDistrS2C
                Else
                    oDpvaleSAP.NombreAsociado = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDpvaleSAP.IDAsociado))
                End If

                '----------------------------------------------------------------
                ' JNAVA (02.03.2016): Modificacion por cambios de retail
                '----------------------------------------------------------------
                Dim oClienteSAP As New ClientesSAP
                oClienteSAP = GetClienteDPVale(oDpvaleSAP.IDCliente)
                oDpvaleSAP.NombreCliente = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos 'FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDpvaleSAP.IDCliente))
                '----------------------------------------------------------------
                oDpvaleSAP.MONTODPVALE = EBPago.Value
                oDpvaleSAP.MontoUtilizado = EBPago.Value
                ''Obtener las quincenas en las que se pagara dpvale
                'oDpvaleSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDpvaleSAP.Plaza, FechaSAP, oDpvaleSAP.MONTODPVALE, oDpvaleSAP.IDDPVale, oDpvaleSAP.FechaCobro, dtDetalleVale)

                '--------------------------------------------------------------------------------------------
                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                '--------------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    '----------------------------------------------------------------------------------------
                    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                    '----------------------------------------------------------------------------------------
                    oDpvaleSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDpvaleSAP.Plaza, FechaSAP, oDpvaleSAP.MONTODPVALE, oDpvaleSAP.IDDPVale, oDpvaleSAP.FechaCobro, dtDetalleVale)
                Else
                    oDpvaleSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDpvaleSAP.Plaza, FechaSAP, oDpvaleSAP.MONTODPVALE, oDpvaleSAP.IDDPVale, oDpvaleSAP.FechaCobro, dtDetalleVale)
                End If
                '--------------------------------------------------------------------------------------------

                oDpvaleSAP.REVALE = False
                oDpvaleSAP.RMONTODPVALE = 0
                Dim vale As DataRow = GetRowFechaCobro(dtDetalleVale, DateTime.Now)
                If Not vale Is Nothing Then
                    If oConfigCierreFI.CompreAhoraPDOpcional Then
                        If Not dtDetalleVale Is Nothing AndAlso dtDetalleVale.Columns.Contains("PromocionID") Then
                            oDpvaleSAP.PromocionID = CStr(vale!PromocionID)
                        End If
                    End If
                End If

                '------------------------------------------------------------------------------------------
                'JNAVA (13.02.2015): Determinamos que es Revale al venir de la Instanciade Notas de Credito
                '------------------------------------------------------------------------------------------
                oDpvaleSAP.IsRevale = True
                '------------------------------------------------------------------------------------------

                '--------------Ver si se puede quitar-------------------
                owsDPValeInfo.DPValeID = oDpvaleSAP.IDDPVale
                owsDPValeInfo.ClienteID = oDpvaleSAP.IDAsociado
                owsDPValeInfo.AsociadoID = oDpvaleSAP.IDAsociado
                owsDPValeInfo.ClienteAsociadoID = oDpvaleSAP.IDCliente
                owsDPValeInfo.FechaExpedicion = oDpvaleSAP.FechaExpedicion
                '---------------------------------------------------------------

                intFolioDPVale = oDpvaleSAP.IDDPVale
                vNombreAsociado = oDpvaleSAP.NombreAsociado & " (" & oDpvaleSAP.IDAsociado & ")"
                owsDPValeInfo.ClienteAsociado = oDpvaleSAP.NombreCliente
                vNombreClienteAsociado = oDpvaleSAP.NombreCliente & " (" & oDpvaleSAP.IDCliente & ")"

                oDevolucionDPValeInfo.MontoDPValeUtilizado = oDpvaleSAP.MontoUtilizado
                '--------------Ver si se puede quitar-------------------
                owsDPValeInfo.MontoUtilizado = oDpvaleSAP.MontoUtilizado
                '-------------------------------------------------------

                'Agregamos Pago
                AgregaPagoDPValeNC()

                Dim drValidaDPValeRow As DataRow
                drValidaDPValeRow = dtDPVale.NewRow

                With drValidaDPValeRow

                    .Item("DPValeID") = oDpvaleSAP.IDDPVale
                    .Item("MontoDPVale") = oDpvaleSAP.MontoUtilizado
                    .Item("ClienteAsociado") = oDpvaleSAP.NombreCliente
                    .Item("FechaExpedicionAsociado") = oDpvaleSAP.FechaExpedicion
                    .Item("AsociadoID") = oDpvaleSAP.IDAsociado
                    .Item("ClienteAsociadoID") = oDpvaleSAP.IDCliente
                    .Item("CodigoSAP") = oDpvaleSAP.IDAsociado

                    dtDPVale.Rows.Add(drValidaDPValeRow)

                End With

            Else
                If oDPVale.ESTATU = "U" Or oDPVale.ESTATU = "C" Then
                    MessageBox.Show("El Dpvale ya esta Usado", "esta usado", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta usado
                End If
            End If
        Else
            MessageBox.Show("El Dpvale no Existe ", "No existe", MessageBoxButtons.OK, MessageBoxIcon.Information) 'NO existe
        End If

    End Sub


    Private Function FormatName(ByVal strname As String) As String
        Try
            Dim strApepApemNom() As String
            Dim strNombre As String = String.Empty
            Dim strApelidos As String = String.Empty

            strApepApemNom = Split(Trim(strname), "_")
            Select Case strApepApemNom.Length
                Case 6
                    strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2) & " " & strApepApemNom(3)
                Case 5
                    strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2)
                Case 4
                    strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 3
                    strNombre = Trim(strApepApemNom(2))
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 2
                    strNombre = strApepApemNom(1)
                    strApelidos = Trim(strApepApemNom(0))
                Case 1
                    strNombre = String.Empty
                    strApelidos = Trim(strApepApemNom(0))
                Case Else
                    strNombre = String.Empty
                    strApelidos = String.Empty
            End Select

            strNombre = strNombre & " " & strApelidos

            Return Trim(strNombre)

        Catch ex As Exception
            Throw New ApplicationException("[FormatName]", ex)
        End Try

    End Function


    Private Function GetFolioSAPByDPVale(ByVal intDPValeID As Integer) As String

        Dim owsDPValeInfo As DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        Dim owsValidaDPVale As New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.ControlDPVales
        'Dim oWsSAP As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.wsSAP.CreditoSAP

        owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        owsDPValeInfo = owsValidaDPVale.GetDPVale(intDPValeID)

        Dim oResult As String = String.Empty

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'oWsSAP.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'oWsSAP.strUrl.TrimStart("/")
        End If

        'oResult = oWsSAP.GetDistribuidorSAP(owsDPValeInfo.AsociadoID)

        'oWsSAP.Dispose()

        'oWsSAP = Nothing

        Return oResult

    End Function

    'Private Sub CreaEstructuraNegados(ByRef dtNegados As DataTable)

    '    dtNegados = New DataTable("Negados")

    '    With dtNegados
    '        .Columns.Add(New DataColumn("Codigo", GetType(String)))
    '        .Columns.Add(New DataColumn("Talla", GetType(String)))
    '        .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
    '        .Columns.Add(New DataColumn("Negados", GetType(Integer)))
    '        .Columns.Add(New DataColumn("Motivo", GetType(String)))
    '        .Columns.Add(New DataColumn("MotivoDesc", GetType(String)))
    '        .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
    '        .AcceptChanges()
    '    End With

    'End Sub

    '    Private Function NegarMaterialesPedidosEC(ByVal dtMateriales As DataTable, ByVal dtDefectuososEC As DataTable, ByVal dtDefECSAP As DataTable) As DataTable

    '        Dim oRow As DataRow
    '        Dim dtPed As DataTable
    '        Dim dtPedDet As DataTable
    '        'Dim dtTrasModif As DataTable
    '        Dim oFacturaTemp As Factura
    '        Dim dtNegados As DataTable
    '        Dim oNewRow As DataRow
    '        Dim Talla As String = ""
    '        Dim CantDef As Integer = 0
    '        Dim MotivoID As String = "", Motivo As String = ""

    '        dtPed = oSAPMgr.ZPOL_TRASLPEN(oSAPMgr.Read_Centros, dtPedDet) ', dtTrasModif)

    '        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
    '            Dim dvPedidoDet As DataView

    '            CreaEstructuraNegados(dtNegados)
    '            '----------------------------------------------------------------------------------------------------------------------------------
    '            'Obtenemos el ID y la descripción de SAP del motivo de negación de los codigos
    '            '----------------------------------------------------------------------------------------------------------------------------------
    '            MotivoID = GetMotivoID("V", Motivo)

    '            For Each oRow In dtMateriales.Rows
    '                For Each oRowP As DataRow In dtPed.Rows
    '                    If CStr(oRowP!Status).Trim.ToUpper = "P" Then
    '                        dvPedidoDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowP!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
    '                        For Each oRowPD As DataRowView In dvPedidoDet
    '                            If CInt(oRowPD!Cant_Pendiente) <= 0 Then GoTo SiguienteMaterial
    '                            If IsNumeric(oRow!Talla) Then
    '                                Talla = Format(CDec(oRow!Talla), "#.0")
    '                            Else
    '                                Talla = CStr(oRow!Talla).Trim
    '                            End If
    '                            If CStr(oRowPD!Material).Trim.ToUpper = CStr(oRow!Codigo).Trim.ToUpper AndAlso CStr(oRowPD!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                'Obtenemos la cantidad marcada en SAP como de baja calidad para Ecommerce
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                CantDef = GetCantidadDefectuososEC(dtDefectuososEC, dtDefECSAP, oRow!Codigo, Talla)

    '                                If IsNumeric(oRow!Talla) AndAlso InStr(CStr(oRow!Talla).Trim, ".0") > 0 Then
    '                                    Talla = CInt(oRow!Talla)
    '                                Else
    '                                    Talla = CStr(oRow!Talla).Trim
    '                                End If
    '                                oFacturaTemp = oFacturaMgr.Create()
    '                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                'Le restamos la cantidad de codigos que tiene marcada como defectuosos en SAP para obtener la cantidad realmente 
    '                                'libre que queda para surtir los pedidos de Ecommerce
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                oFacturaTemp.FacturaArticuloExistencia -= CantDef
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                'Revisamos si la cantidad libre menos la cantidad de la factura es menor a la cantidad que le estan solicitando
    '                                'en el pedido de Ecommerce
    '                                '----------------------------------------------------------------------------------------------------------------
    '                                If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
    '                                    oNewRow = dtNegados.NewRow
    '                                    With oNewRow
    '                                        !Codigo = CStr(oRowPD!Material).Trim
    '                                        !Talla = CStr(oRowPD!Talla).Trim
    '                                        !Cantidad = 0
    '                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
    '                                        !Motivo = MotivoID '"00010"
    '                                        !MotivoDesc = Motivo '"Vendido"
    '                                        !PedidoEC = CStr(oRowP!Folio_Pedido).Trim
    '                                    End With
    '                                    dtNegados.Rows.Add(oNewRow)
    '                                End If
    '                                oFacturaTemp = Nothing
    '                                GoTo Siguiente
    '                            End If
    'SiguienteMaterial:
    '                        Next
    '                    End If
    '                Next
    'Siguiente:
    '            Next
    '        End If

    '        Return dtNegados

    '    End Function

    'Private Function GetCantidadDefectuososEC(ByVal dtDef As DataTable, ByVal dtDefSAP As DataTable, ByVal Codigo As String, ByVal Talla As String) As Integer

    '    Dim cant As Integer = 0
    '    Dim dvCod As New DataView(dtDefSAP, "Material = '" & Codigo.Trim.ToUpper & "' And Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)
    '    Dim Total As Integer = 0

    '    If dvCod.Count > 0 Then
    '        Dim oRow As DataRowView
    '        'Sacamos la cantidad total por codigo y talla sin importar el motivo de marcado
    '        Total = dvCod(0)!TotalXTalla
    '        'Sumamos la cantidad de codigos de baja calidad que van en el detalle de la factura
    '        dvCod = New DataView(dtDef, "Material = '" & Codigo.Trim.ToUpper & "' And Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)
    '        For Each oRow In dvCod
    '            cant += oRow!Cantidad
    '        Next
    '        'Restamos la cantidad de codigos que van en el detalle de la factura a la cantidad total marcada en SAP
    '        Total -= cant
    '    End If

    '    Return Total

    'End Function

    'Private Function ValidarMaterialesDefectuososEC(ByVal dtMateriales As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String) As Boolean

    '    Dim oRowM As DataRow
    '    Dim dtDefEC As DataTable
    '    Dim dtTemp As DataTable
    '    Dim oFacturaTemp As Factura
    '    Dim oNewRow As DataRow
    '    Dim Talla As String = ""
    '    Dim Max As Integer = 0, Min As Integer = 0
    '    Dim bRes As Boolean = True
    '    Dim dvMatDef As DataView
    '    Dim oRowDEC As DataRowView
    '    Dim MotivoDesmarcado As String = ""
    '    Dim dtMotivosDes As DataTable
    '    Dim DesID As String = ""
    '    Dim CantXTalla As Integer = 0

    '    dtDefEC = oSAPMgr.ZPOL_GET_DEFT_CENTRO()

    '    If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then

    '        'Obetenemos el id de motivo de desmarcado de SAP
    '        dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS("V")
    '        If dtMotivosDes.Rows.Count > 0 Then
    '            MotivoDesmarcado = dtMotivosDes.Rows(0)!Motivo
    '            DesID = dtMotivosDes.Rows(0)!ID
    '        End If

    '        dtTemp = dtDefEC.Clone
    '        dtTemp.Columns.Add("Minimo", GetType(Integer))
    '        dtTemp.Columns.Add("Maximo", GetType(Integer))
    '        dtTemp.Columns.Add("MaximoTotal", GetType(Integer))
    '        dtTemp.Columns.Add("Motivo", GetType(String))  'Motivo por el que se está desmarcando
    '        dtTemp.Columns.Add("MotivoMarc", GetType(String)) 'Motivo por el que estaba marcado
    '        dtTemp.Columns.Add("DesmarcadoID", GetType(String))
    '        dtTemp.Columns.Add("MarcadoID", GetType(String))
    '        dtTemp.AcceptChanges()

    '        For Each oRowM In dtMateriales.Rows

    '            If IsNumeric(oRowM!Talla) Then
    '                Talla = Format(CDec(oRowM!Talla), "#.0")
    '            Else
    '                Talla = CStr(oRowM!Talla).Trim
    '            End If
    '            'Filtramos por Codigo y Talla para separarlos por los diferentes motivos de marcado
    '            dvMatDef = New DataView(dtDefEC, "Material = '" & CStr(oRowM!Codigo) & "' and Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)

    '            If dvMatDef.Count > 0 Then

    '                CantXTalla = dtDefEC.Compute("SUM(Cantidad)", "Material = '" & CStr(oRowM!Codigo) & "' and Talla = '" & Talla.Trim.ToUpper & "'")

    '                If IsNumeric(oRowM!Talla) AndAlso InStr(CStr(oRowM!Talla).Trim, ".0") > 0 Then
    '                    Talla = CInt(oRowM!Talla)
    '                Else
    '                    Talla = CStr(oRowM!Talla).Trim
    '                End If
    '                oFacturaTemp = oFacturaMgr.Create()
    '                oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)

    '                Max = 0 : Min = 0

    '                If (oFacturaTemp.FacturaArticuloExistencia - CantXTalla) >= oRowM!Cantidad Then
    '                    Min = 0
    '                Else
    '                    Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - CantXTalla)
    '                End If
    '                oFacturaTemp = Nothing
    '                For Each oRowDEC In dvMatDef
    '                    Max = IIf(oRowDEC!Cantidad < oRowM!Cantidad, oRowDEC!Cantidad, oRowM!Cantidad)
    '                    oNewRow = dtTemp.NewRow
    '                    With oNewRow
    '                        !Material = CStr(oRowDEC!Material).Trim
    '                        !Talla = CStr(oRowDEC!Talla).Trim
    '                        !Cantidad = 0
    '                        !Minimo = Min
    '                        !Maximo = Max
    '                        !MaximoTotal = oRowM!Cantidad
    '                        !Motivo = MotivoDesmarcado.Trim
    '                        !DesmarcadoID = DesID.Trim
    '                        !MarcadoID = CStr(oRowDEC!ID).Trim
    '                        !MotivoMarc = CStr(oRowDEC!Motivo).Trim
    '                    End With
    '                    dtTemp.Rows.Add(oNewRow)
    '                Next
    '            End If

    '            'For Each oRowDE As DataRow In dtDefEC.Rows
    '            '    If IsNumeric(oRowM!Talla) Then
    '            '        Talla = Format(CDec(oRowM!Talla), "#.0")
    '            '    Else
    '            '        Talla = CStr(oRowM!Talla).Trim
    '            '    End If
    '            '    If CStr(oRowDE!Material).Trim.ToUpper = CStr(oRowM!Codigo).Trim.ToUpper AndAlso CStr(oRowDE!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '            '        If IsNumeric(oRowM!Talla) AndAlso InStr(CStr(oRowM!Talla).Trim, ".0") > 0 Then
    '            '            Talla = CInt(oRowM!Talla)
    '            '        Else
    '            '            Talla = CStr(oRowM!Talla).Trim
    '            '        End If
    '            '        oFacturaTemp = oFacturaMgr.Create()
    '            '        oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '            '        Max = 0 : Min = 0
    '            '        If (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad) >= oRowM!Cantidad Then
    '            '            Min = 0
    '            '        Else
    '            '            Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad)
    '            '        End If
    '            '        Max = IIf(oRowDE!Cantidad < oRowM!Cantidad, oRowDE!Cantidad, oRowM!Cantidad)
    '            '        oNewRow = dtTemp.NewRow
    '            '        With oNewRow
    '            '            !Material = CStr(oRowDE!Material).Trim
    '            '            !Talla = CStr(oRowDE!Talla).Trim
    '            '            !Cantidad = Min
    '            '            !Minimo = Min
    '            '            !Maximo = Max
    '            '            !MotivoDes = "Vendido en la factura "
    '            '        End With
    '            '        dtTemp.Rows.Add(oNewRow)
    '            '        oFacturaTemp = Nothing
    '            '        Exit For
    '            '    End If
    '            'Next
    '        Next

    '        If dtTemp.Rows.Count > 0 Then
    '            If UserName.Trim = "" Then
    '                If MessageBox.Show("Existen codigos marcados como de baja calidad que podrian ir en el detalle de esta operación.." & vbCrLf & "Es necesario especificarlos." & _
    '                vbCrLf & vbCrLf & "¿Desea continuar con este proceso?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
    '                    bRes = False
    '                End If
    '            End If
    '            If bRes = True Then
    '                Dim oFrmDE As New frmDesmarcarDefectuososEC
    '                oFrmDE.dtSource = dtTemp
    '                oFrmDE.UserDesmarca = UserName.Trim
    '                If oFrmDE.ShowDialog() = DialogResult.OK Then
    '                    dtDefecEC = oFrmDE.dtDefectuososEC.Copy
    '                    UserName = oFrmDE.UserDesmarca.Trim
    '                Else
    '                    MessageBox.Show("Es necesario especificar las piezas marcadas como baja calidad que van en la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    bRes = False
    '                End If
    '            Else
    '                bRes = False
    '            End If
    '        End If
    '    End If

    '    Return bRes

    'End Function

    Private Sub frmPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape    'Cancelar Captura

                Me.DialogResult = DialogResult.Cancel

            Case Keys.F2  'Guardar sin imprimir
                '-------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/04/2013: Se elige si se paga con la forma tradicional o con la Aplicacion del SiHay
                '-------------------------------------------------------------------------------------------------------------------
                Select Case Me.ModoVenta
                    Case 0
                        'CerrarVenta(False)
                        CerrarVentaDirecto(False)
                    Case 1
                        'If oConfigCierreFI.DPValeSiHay = True Then
                        CerrarVentaSHDPVale(False)
                        'Else
                        'CerrarVentaSH(False)
                        'End If
                End Select

            Case Keys.F9 'Guardar e imprimir
                '-------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/04/2013: Se elige si se paga con la forma tradicional o con la Aplicacion del SiHay
                '-------------------------------------------------------------------------------------------------------------------
                Select Case Me.ModoVenta
                    Case 0
                        'CerrarVenta(True)
                        CerrarVentaDirecto(True)
                    Case 1
                        'If oConfigCierreFI.DPValeSiHay = True Then
                        CerrarVentaSHDPVale(True)
                        'Else
                        '    CerrarVentaSH(True)
                        'End If
                End Select

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.F12

                If oConfigCierreFI.PedirDatosPromoComienzo Then CapturaCelParaSMS(True, True)

        End Select

    End Sub

    Private Sub CerrarVenta(ByVal imprimir As Boolean)
        Dim codvendedor As String = oFactura.CodVendedor
        codvendedor = codvendedor.Substring(codvendedor.Length - 6, 6)
        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then

            MsgBox("El Importe Total no ha sido cubierto. No puede guardar la Factura.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Forma de Pago")

        Else

            If FacturaIsSaved() Then
                MsgBox("La Factura ya ha sido guardada. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Forma de Pago")
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Fonacot. Validamos que por lo menos tenga forma de pago FONACOT
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "F" Then
                If ValidarFormaPago("TFON") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If ValidarFormaPago("FONA") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Facilito. Validamos que por lo menos tenga forma de pago FACILITO
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "O" Then
                If ValidarFormaPago("FACI") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FACILITO", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

        '-----------------------------------------------------------------------------------
        'JNAVA (17.12.2015): Guardamos en SAP RETAIL y nos Salimos (para prueba)
        '-----------------------------------------------------------------------------------
        'SaveFacturaRetail()
        'Me.DialogResult = DialogResult.OK
        'Exit Sub
        '-----------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 17/04/2015: En caso de que DPCard Puntos este activado y sea una venta de una tarjeta DPCard Puntos
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim resultado As Hashtable
        Dim payment() As DataRow
        ReDim payment(-1)
        If oConfigCierreFI.DPCardPuntos = True Then
            Dim bResultCanje As Boolean = True
            If IsDPCardPunto() = True AndAlso IsDPCardPuntosRenewMembership() = False Then
                If CapturaCliente() = False Then
                    MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            ElseIf IsDPCardPuntosRenewMembership() = True Then
                ValidaRenewMembership()
            Else
                payment = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
                '---------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 16/04/2015: Se valida si es forma de Pago o solo se bonificaran puntos
                '---------------------------------------------------------------------------------------------------------------
                If payment.Length > 0 Then
                    '-----------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 25/04/2015: Valida si se canjearan puntos en factura normal o si hay
                    '-----------------------------------------------------------------------------------------------------------
                    Select Case Me.ModoVenta
                        Case 0
                            resultado = CanjearPuntos(bResultCanje)
                        Case 1
                            resultado = CanjearPuntosSiHay(bResultCanje)
                    End Select

                    If bResultCanje = False Then Exit Sub

                End If
            End If
        End If
        Dim dtNegados As DataTable
        Dim UserNameNiega As String = ""
        Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
        Dim UserNameDesmarca As String = ""
        Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
        oFactura.Fecha = FechaSAP
        '-----------------------------------------------------------------------------------------------------------------------------
        'Validamos si los codigos de la factura estan marcados como defectuosos para Ecommerce
        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 08/05/2013: Se le resta la cantidad que haya habido en algun producto pendiente por surtir O Facturar
        '-----------------------------------------------------------------------------------------------------------------------------
        'Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oFactura.Detalle.Tables(0))
        'If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "V", dtDefecECSAP) = False Then
        '    Exit Sub
        'End If

        ''-----------------------------------------------------------------------------------------------------------------------------
        ''Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle de la factura
        ''-----------------------------------------------------------------------------------------------------------------------------
        'If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
        '    Exit Sub
        'End If

        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        If ValidarMaterialesNegadosSH(oFactura.Detalle.Tables(0), dtNegadosSH, "PF,P,RP") = False Then
            ShowFormNegadosSH(dtNegadosSH)
            Exit Sub
        End If
        'If oConfigCierreFI.SurtirEcommerce Then
        '    dtNegados = NegarMaterialesPedidosEC(oFactura.Detalle.Tables(0), dtDefectuososEC, dtDefecECSAP)
        '    UserNameNiega = UserNameDesmarca
        '    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
        '        Dim strMsg As String = ""

        '        If UserNameNiega.Trim <> "" Then
        '            strMsg = "Hay codigos en el detalle de la factura que se negaran a algun pedido solicitado por Ecommerce" & vbCrLf & _
        '                     "Sera necesario identificarse para continuar" & vbCrLf & vbCrLf & "¿Desea continuar con la factura?"
        '        Else
        '            strMsg = "Hay codigos en el detalle de la factura que se negaran a algun pedido solicitado por Ecommerce" & _
        '                     vbCrLf & vbCrLf & "¿Desea continuar con la factura?"
        '        End If
        '        If MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '            If UserNameNiega.Trim = "" Then
        '                oAppContext.Security.CloseImpersonatedSession()
        '                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") = False Then
        '                    MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                    Exit Sub
        '                Else
        '                    UserNameNiega = oAppContext.Security.CurrentUser.Name
        '                    oAppContext.Security.CloseImpersonatedSession()
        '                End If
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        'End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------
        'Obtenemos el tiempo de duración operativa y detenemos el cronómetro
        '--------------------------------------------------------------------------------------------------------------------------------------------------
        Dim TiempoOperacion As String = Me.lblCronometro.Text
        EjecutaCronometro(False)
        '--------------------------------------------------------------------------------------------------------------------------------------------------
        'Realizamos el traspaso de saldo al cliente si en las formas de pago va algun vale de caja en caso de ser necesario
        '--------------------------------------------------------------------------------------------------------------------------------------------------
        'If RealizarTraspasoSaldos() = False Then
        '    MessageBox.Show("No fue posible realizar el traspaso de saldo al cliente " & oFactura.ClienteId & "." & vbCrLf & "No se guardó la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        If imprimir = False Then
            oFactura.Impresa = 0
        Else
            oFactura.Impresa = 1
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------------------
        'Grabamos primero en PRO si es cualquier tipo de ventas, excepto "DPVALE"
        '--------------------------------------------------------------------------------------------------------------------------------------------------
        If oFactura.CodTipoVenta = "V" Then
            oFactura.Referencia = "DPVL-" & CStr(oDpvaleSAP.IDDPVale).PadLeft(10, "0")
        ElseIf EsInstanciaApartado = False Then
            oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
        End If
        If Not oFactura.CodTipoVenta = "V" Then
            boolLaImprimo = False
            SaveFactura()
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/01/2016: Relaciona la factura con el serial
            '----------------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.FacturaID > 0 Then
                oFacturaMgr.SaveSerial(oFactura.SerialId, "W", oFactura.CodVendedor, oFactura.FacturaID)
            Else
                oFacturaMgr.SaveSerial(oFactura.SerialId, "E", oFactura.CodVendedor, 0)
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2015: Valida si hay formas de pago de canje para actualizar el número de tarjeta y estatus de canje
            '----------------------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                    Dim dato As New Hashtable
                    dato("NoTarjeta") = CStr(resultado("CardId"))
                    dato("CodDPCardPunto") = "CAN"
                    IsRedeem = True
                    oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                End If
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Grabamos temporalmente los codigos de baja calidad que van en el detalle de la factura
                '--------------------------------------------------------------------------------------------------------------------------------------------------
                'MessageBox.Show(FacturaID)
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                For Each oRow As DataRow In dtDefectuososEC.Rows
                    oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oFactura.FolioFactura, oFactura.CodCaja, "FA")
                Next
            End If
        Else
            '--------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 02.06.2015: Se encapsulo la extraccion de datos del seguro de vida de DPVL en un procedimiento
            '--------------------------------------------------------------------------------------------------------------------------------
            ExtraerDatosSeguroDeVidaDPVL()
        End If
        '----------------------------------------------------------------------------------------------------------------------------
        'Revisamos el tiempo que dura guardando la factura en SAP
        '----------------------------------------------------------------------------------------------------------------------------
        Dim HoraSapIni As DateTime = Now
        '----------------------------------------------------------------------------------------------------------------------------
        'Guardamos la factura en SAP
        '----------------------------------------------------------------------------------------------------------------------------
        'SaveFacturaSAP()
        Dim response As New Dictionary(Of String, Object)
        response = SaveFacturaRetail()
        If oFactura.CodTipoVenta = "V" Then
            'If CStr(response("ZRECH")).Trim() <> "" Then
            '    Dim dtPagosVale As DataTable = CType(response("FormasPagoDPVale"), DataTable)
            '    Dim dtViewVale As New DataView(dtPagosVale, "FORMA_PAGO='DPVL'", "", DataViewRowState.CurrentRows)
            '    If dtViewVale.Count > 0 Then
            '        If CStr(dtViewVale(0)!zseg) = "0" Then
            '            oFactura.SeguroVidaSAPDPVL = False
            '            ImporteSeguro = 0
            '        Else
            '            oFactura.SeguroVidaSAPDPVL = True
            '        End If
            '    End If
            'End If
        End If
        If response.ContainsKey("FolioSAP") Then
            oFactura.FolioSAP = CStr(response("FolioSAP"))
            oFactura.FolioFISAP = CStr(response("DocFi"))
            oFactura.REVALE = CStr(response("FolioRevale"))
        End If

        '----------------------------------------------------------------------------------------------------------------------------
        'Calculamos el tiempo que duró guardando la factura en SAP y guardamos el tiempo obtenido y el tiempo de operación
        '----------------------------------------------------------------------------------------------------------------------------
        'If TiempoOperacion.Trim <> "" AndAlso CLng(TiempoOperacion.Trim.Replace(":", "").Replace(" ", "")) > 0 AndAlso oFactura.SerialId.Trim <> "" Then oSAPMgr.ZRFC_INSERTA_TIEMPOS(oFactura.SerialId, "FA", TiempoOperacion.Trim.Replace(" ", ""), Format(CDate(Now.Subtract(HoraSapIni).ToString), "HH:mm:ss"))
        'If TiempoOperacion.Trim <> "" AndAlso CLng(TiempoOperacion.Trim.Replace(":", "").Replace(" ", "")) > 0 AndAlso oFactura.FolioSAP.Trim <> "" Then oSAPMgr.ZRFC_INSERTA_TIEMPOS(oFactura.FolioSAP, "FA", TiempoOperacion.Trim.Replace(" ", ""), Format(CDate(Now.Subtract(HoraSapIni).ToString), "HH:mm:ss"))
        If oFactura.SerialId = String.Empty OrElse oFactura.SerialId = String.Empty Then 'OrElse oFactura.FolioFISAP = "0" OrElse oFactura.FolioSAP = "0" Then
            'If oFactura.FolioFISAP = String.Empty OrElse oFactura.FolioSAP = String.Empty OrElse oFactura.FolioFISAP = "0" OrElse oFactura.FolioSAP = "0" Then

                If oFactura.CodTipoVenta = "V" Then

                    '----------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (16.11.2016): No mostramos mensaje si está activo s2credit
                    '----------------------------------------------------------------------------------------------------------------------------
                    If Not oConfigCierreFI.AplicarS2Credit Then
                        MessageBox.Show("Por el momento no se puede facturar DPortenisVale", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------

                    'Posiblemente se haga un Revale para NC.
                    'Ver que ondas con  este codigo

                    If EsInstanciaNC Then
                        If Not oAppSAPConfig.DPValeSAP Then
                            Dim DPValeInfo As New DevolucionDPValeInfo()
                            DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            DPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                            DPValeInfo.FechaExpedicion = FechaSAP
                            DPValeInfo.FechaEntregado = FechaSAP
                            DPValeInfo.FacturaId = 0
                            DPValeInfo.MontoDPValeUtilizado = 0
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)

                            owsDPValeInfo = New ControlDPValesWS.DPValeInfo
                            owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            'owsDPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                            'owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                            owsDPValeInfo.FechaExpedicion = FechaSAP.ToShortDateString
                            owsDPValeInfo.FechaEntregado = FechaSAP.ToShortDateString
                            owsDPValeInfo.FacturaID = 0
                            owsDPValeInfo.MontoUtilizado = 0
                            owsDPValeInfo.MontoDPValeP = 0
                            Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                            owsDPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)
                            PrintRevale(DPValeInfo, String.Empty, Nothing)
                        Else
                            owsDPValeInfo = New ControlDPValesWS.DPValeInfo
                            owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale

                            Dim oDPVale As New cDPVale
                            oDPVale.INUMVA = CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0")

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                            '----------------------------------------------------------------------------------------
                            'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (11.04.2016): Valida DPVale en S2Credit
                            '----------------------------------------------------------------------------------------
                            'BuscarValeS2Credit(CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0"))

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (14.07.2016): Valida DPVale
                            '----------------------------------------------------------------------------------------
                            Dim FirmaDistribuidor As Image = Nothing
                            Dim NombreDistribuidor As String = String.Empty
                            If oConfigCierreFI.AplicarS2Credit Then
                                oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                            Else
                                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                            End If
                            '----------------------------------------------------------------------------------------

                            Dim oRow As DataRow
                            oRow = oDPVale.InfoDPVALE.Rows(0)
                            Dim DPValeInfo As New DevolucionDPValeInfo()
                            DPValeInfo.DPValeOrigen = oRow("Orige")
                            DPValeInfo.FechaExpedicion = FechaSAP
                            DPValeInfo.FechaEntregado = FechaSAP
                            DPValeInfo.FacturaId = 0
                            DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            DPValeInfo.MontoDPValeUtilizado = 0
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                            'owsDPValeInfo.DPValeOrigen = oRow("Orige")
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                            'owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                            owsDPValeInfo.FechaExpedicion = FechaSAP.ToShortDateString
                            owsDPValeInfo.FechaEntregado = FechaSAP.ToShortDateString
                            owsDPValeInfo.FacturaID = 0
                            owsDPValeInfo.MontoUtilizado = 0
                            owsDPValeInfo.MontoDPValeP = 0
                            Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                            owsDPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                            PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
                        End If
                    End If

                    Exit Sub
                ElseIf oFactura.CodTipoVenta = "D" Then
                    MessageBox.Show("Por el momento no se puede facturar DIPS", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
        End If
        '----------------------------------------------------------------------------------------------------
        'Quemamos el cupon de descuento en caso de existir en SAP
        '----------------------------------------------------------------------------------------------------
        If Not oCuponDesc Is Nothing Then
            Dim strFolioNew As String = ""
            Dim pagos As DataTable = GetEnviosFormasPago()
            Dim result As New Dictionary(Of String, Object)
            RestService.Metodo = "/pos/cupones"
            result = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.Referencia, pagos)
            strFolioNew = CStr(result("SapZcupUtilCupon")("E_FOLIO"))
            'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, strFolioNew, pagos)
            oFacturaMgr.ActualizarCuponDetalle(oFactura.FacturaID, strFolioNew)
        End If
        'OJO
        'Grabamos únicamente si el tipo de venta es "DPVALE"
        If oFactura.CodTipoVenta = "V" Then
            boolLaImprimo = True
            '------------------------------------------------------------------
            'JNAVA (02.03.2016): Obtenemos quincenas de DPVale
            '------------------------------------------------------------------
            oFactura.Nquincenas = oDpvaleSAP.NUMDE
            '------------------------------------------------------------------
            SaveFactura()
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/01/2016: Relaciona la factura con el serial
            '----------------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.FacturaID > 0 Then
                oFacturaMgr.SaveSerial(oFactura.SerialId, "S", oFactura.CodVendedor, oFactura.FacturaID)
            Else
                oFacturaMgr.SaveSerial(oFactura.SerialId, "E", oFactura.CodVendedor, 0)
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2015: Valida si hay formas de pago de canje para actualizar el número de tarjeta y estatus de canje
            '----------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                Dim dato As New Hashtable
                dato("NoTarjeta") = CStr(resultado("CardId"))
                dato("CodDPCardPunto") = "CAN"
                oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
            End If
        Else
            '------------------------------------------------------------------------------------------------------------------------
            'Quemamos el vale de empleado en caso de existir en SAP
            '------------------------------------------------------------------------------------------------------------------------
            'If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
            '    oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, oFactura.FolioSAP)
            'End If
            '------------------------------------------------------------------------------------------------------------------------
            'Si no es DPVALE entonces actualizamos los folio SAP y FI validamos si me regreso folios SAP para la factura
            '------------------------------------------------------------------------------------------------------------------------
            If oFactura.FolioSAP.Trim <> String.Empty And oFactura.FolioFISAP.Trim <> String.Empty Then
                '--------------------------------------------------------------------------------------------------------------------
                'Actualizamos los folios SAP
                '--------------------------------------------------------------------------------------------------------------------
                oFacturaMgr.UpdateFolioSAP(oFactura)
            End If
            '------------------------------------------------------------------------------------------------------------------------
            'Guardamos la relacion cliente-venta y la razon por la que rechazaron registrar los datos del cliente en caso de ser asi
            '------------------------------------------------------------------------------------------------------------------------
            'If oConfigCierreFI.UsarHuellas Then
            '    oFactura.CodPlaza = oSAPMgr.Read_Plaza
            '    If oFactura.FolioSAP.Trim <> "" AndAlso oFactura.CodTipoVenta = "P" AndAlso oFingerPrintMgr.SaveClienteVenta(oFactura) Then
            '        oFacturaMgr.ActualizaStatusEnvioServerPG(oFactura.FolioSAP, 1)
            '    End If
            'End If

            '------------------------------------------------------------------------------------------------------------------------
            'Imprimimos la Factura
            '------------------------------------------------------------------------------------------------------------------------
            Select Case Me.ModoVenta
                Case 0
                    If oFactura.Impresa = True Then
                        '------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 15.11.2013: Se revisa si está activa la impresion termica de la miniprinter y es tipo de venta empleado o dpvale
                        'para imprimirlo 1 vez mas para anexar la copia al corte
                        '------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.MiniprinterTermica AndAlso InStr("V,E", oFactura.CodTipoVenta) > 0 Then ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                        ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                    Else
                        ActionPreview2(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                    End If
                Case 1
                    If oFactura.Impresa = True Then

                    End If
            End Select
            'If oFactura.Impresa = True Then
            '    ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
            'Else
            '    ActionPreview2(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
            'End If

            Me.Cursor = Cursors.Default
            'MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'Si se guardó correctamente la factura en SAP continuamos con el proceso de los pedidos del EC
        '---------------------------------------------------------------------------------------------------------------------------
        If oFactura.FolioSAP.Trim <> "" And oFactura.FolioFISAP.Trim <> "" Then
            '-----------------------------------------------------------------------------------------------------------------------
            'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario si esta activado el proceso de surtido para
            'EC en la config
            '-----------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.SurtirEcommerce Then
                If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                    oSAPMgr.ZPOL_TRASL_NEGAR(oFactura.FolioSAP, "V", UserNameNiega, dtNegados)
                    ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------
            'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en la factura
            '-----------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                If oSAPMgr.ZPOL_DEFECTUOSOS_INS(oFactura.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
                    oFacturaMgr.BorrarCodigosBajaCalidad(oFactura.FolioFactura, oFactura.CodCaja, "FA")
                End If
            End If
            MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
        End If

        '---------------------------------------------------------------------------------------------------------------------------
        'JNAVA - 08/11/2013: Generamos cupon si existe promocion de descuento proxima compra
        '---------------------------------------------------------------------------------------------------------------------------
        'RGEMAIN 08.07.2015: Generamos el cupon de promocion proxima compra solo si es la primera vez que compran con la tarjeta de
        '                    DPCard Credit
        '---------------------------------------------------------------------------------------------------------------------------
        If bPrimeraCompraKarum AndAlso oFactura.CodTipoVenta.Trim <> "D" Then CuponDescuentoProximaCompra(oFactura)

        bPrimeraCompraKarum = False
        '---------------------------------------------------------------------------------------------------------------------------
        'JNAVA - 08/11/2013: Generamos ReReVale si el Tipo de Venta es de DPVale
        '---------------------------------------------------------------------------------------------------------------------------
        GenerarReReValeVentaDPVALE(oFactura)

        '---------------------------------------------------------------------------------------------------------------------------
        'JNAVA (05.12.2014): Guardamos (de ser necesario) los Electronicos de la Factura en SAP
        '---------------------------------------------------------------------------------------------------------------------------
        GuardarElectronicosSAP()

        '---------------------------------------------------------------------------------------------------------------------------
        'JNAVA (06.02.2015): Guardamos (de ser necesario) el registro del Seguro de DPVale en la BD
        '---------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.04.2015: Validamos si realmente se genero el seguro de vida en SAP y solo asi guardamos e imprimimos el ticket
        '                     del seguro de vida
        '---------------------------------------------------------------------------------------------------------------------------
        If oFactura.SeguroVidaSAPDPVL Then

                '---------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08.04.2016): Revisamos si esta activo S2Credit como Validador
                '---------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (08.04.2016): Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
                    '---------------------------------------------------------------------------------------------------------------------------
                    If Not DatosTicketSeguro Is Nothing Then
                        GuardarSeguroS2Credit(oDpvaleSAP)
                    End If
                Else
                    CapturaBeneficiarioSeguroDPVL(Me.oDpvaleSAP)
                    GuardarSeguroDPVale(oFactura.CodTipoVenta)
                End If

        Else
            '---------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (02.07.2015): Si no se genera seguro de vida, mostramos el mensaje de Motivo de Rechazo
            '---------------------------------------------------------------------------------------------------------------------------
            If RechazoSeguro.Trim <> "" Then ' PONER TRIM PARA FIX
                MessageBox.Show(RechazoSeguro, "Seguro de Vida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/04/2015: Activamos o aplicamos puntos a DPCard Puntos 
        '---------------------------------------------------------------------------------------------------------------------------
        DPCardPuntos()

        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/05/2015: Se imprime el recibo de Canje
        '---------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
            PrintTicketDPCardPuntos(resultado)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 29.08.2014: Capturamos Cel del cliente solo si no esta activada la config
        '---------------------------------------------------------------------------------------------------------------------------
        CapturaCelParaSMS(oConfigCierreFI.PedirDatosPromoComienzo, False)

        Me.DialogResult = DialogResult.OK

            End If
            '------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2014: Actualiza el ScoreBoard siempre y cuando este configurado
            '------------------------------------------------------------------------------------------------
            If oConfigCierreFI.ScoreBoard Then
                DashBoard.ShowAndUpdateScoreBoard()
            End If

    End Sub

    Private Function ConcatenarMateriales(ByVal oList As List(Of String)) As String
        Dim materiales As String = String.Empty

        If oList.Count > 1 Then
            For i As Integer = 0 To oList.Count - 1
                materiales += oList.Item(i) + ","
            Next i
            materiales = "(" & materiales.Substring(0, materiales.Length - 1) & ")"
        Else
            materiales = oList.Item(0)
        End If

        Return materiales
    End Function


    Private Function ConsultaExistenciasSAPCAR(ByVal tipo As String, ByVal articulos As List(Of String), ByVal centro As String) As DataTable
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable

        htParams.Add("ClienteSAP", oSapMgr.SAPApplicationConfig.ClienteCAR)
        htParams.Add("Material", ConcatenarMateriales(articulos))
        If centro.Length > 0 Then
            htParams.Add("Centro", centro)
        End If
        If tipo = "SI_HAY" Then
            htParams.Add("IDCanal", oSapMgr.SAPApplicationConfig.IdCanalCAR)
            htParams.Add("Version", oSapMgr.SAPApplicationConfig.VersionCAR)
        End If

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As ProcesosRetail

        If tipo = "General" Then
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/POSStkSet", "GET")
        Else
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/VersionStkSet", "GET")
        End If

        dtDatos = oRetail.SapCarInventario(htParams)

        Return dtDatos

    End Function


    Public Function ValidarMaterialesSAPCAR(ByVal tipo As String, ByVal dtSource As DataTable, ByRef dtMaterialesNegados As DataTable) As Boolean
        Dim listProducts As New List(Of String)
        Dim centro As String
        Dim dtQryView As DataView
        Dim nCantSol As Integer
        Dim nCantBajaCalidad As Integer
        Dim nCantLibre As Integer
        Dim valido As Boolean = True

        For Each oRow As DataRow In dtSource.Rows
            listProducts.Add(CStr(oRow!Codigo))
        Next

        centro = oSAPMgr.Read_Centros()
        Dim dtArticulos As DataTable
        dtArticulos = ConsultaExistenciasSAPCAR(tipo, listProducts, centro)

        ' Procesar la respuesta del servicio
        If Not dtArticulos Is Nothing AndAlso dtArticulos.Rows.Count > 0 Then
            dtQryView = New DataView(dtArticulos, "", "", DataViewRowState.CurrentRows)
            For Each oRow As DataRow In dtSource.Rows
                dtQryView.RowFilter = "Material='" & oRow!Codigo & "'"
                If dtQryView.Count > 0 Then
                    nCantSol = oRow!Cantidad
                    nCantBajaCalidad = dtQryView.Item(0)!STK_CALIDAD
                    If EsInstanciaApartado Then
                        nCantLibre = dtQryView.Item(0)!APARTADOS
                    Else
                        nCantLibre = dtQryView.Item(0)!STK_DISPONIBLE
                    End If

                    If nCantLibre < nCantSol Then
                        If nCantBajaCalidad < nCantSol Then
                            Dim row As DataRow = dtMaterialesNegados.NewRow()
                            row("CodArticulo") = oRow!CodProveedor
                            row("talla") = dtQryView.Item(0)!TALLA '   oRow!Talla
                            row("Pedido") = nCantSol
                            row("Existencia") = nCantLibre
                            dtMaterialesNegados.Rows.Add(row)
                            valido = False
                        End If
                    End If
                Else
                    ' Registrar los articulos no encontrados                    
                    Dim row As DataRow = dtMaterialesNegados.NewRow()
                    row("CodArticulo") = oRow!CodProveedor
                    row("talla") = oRow!Talla
                    row("Pedido") = oRow!Cantidad
                    row("Existencia") = "0"
                    dtMaterialesNegados.Rows.Add(row)
                    valido = False
                End If
            Next
        Else
            'Si no encontró ningún artículo, se presento un error al ejecutar el servicio
            valido = False
        End If

        Return valido
    End Function

    Private Sub ValidaFormaPago()
        If oFactura.CodTipoVenta = "V" Then
            If oDpvaleSAP.IDDPVale = "" Then
                MessageBox.Show("Debe proporcionar un DPVale como forma de pago, o cambiar el tipo de venta.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub


    Private Sub CerrarVentaDirecto(ByVal imprimir As Boolean)
        Dim codvendedor As String = oFactura.CodVendedor
        If codvendedor.Length > 6 Then
            codvendedor = codvendedor.Substring(codvendedor.Length - 6, 6)
        End If

        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then

            MsgBox("El Importe Total no ha sido cubierto. No puede guardar la Factura.  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")

        Else

            ValidaFormaPago()

            If FacturaIsSaved() Then
                MsgBox("La Factura ya ha sido guardada. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Forma de Pago")
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Fonacot. Validamos que por lo menos tenga forma de pago FONACOT
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "F" Then
                If ValidarFormaPago("TFON") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If ValidarFormaPago("FONA") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Facilito. Validamos que por lo menos tenga forma de pago FACILITO
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "O" Then
                If ValidarFormaPago("FACI") = False AndAlso oNotaCredito.SALESDOCUMENT.Trim() = "" Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FACILITO", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            '-----------------------------------------------------------------------------------
            'JNAVA (17.12.2015): Guardamos en SAP RETAIL y nos Salimos (para prueba)
            '-----------------------------------------------------------------------------------
            'SaveFacturaRetail()
            'Me.DialogResult = DialogResult.OK
            'Exit Sub
            '-----------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Grabamos primero en PRO si es cualquier tipo de ventas, excepto "DPVALE"
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/05/2017: Se cambio de lugar donde se arma la referencia
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "V" Then
                If oDpvaleSAP.IDDPVale <> "" Then
                    oFactura.Referencia = "DPVL-" & CStr(oDpvaleSAP.IDDPVale).PadLeft(10, "0")
                Else
                    MessageBox.Show("El número de vale esta vacio. Favor de revisar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            ElseIf EsInstanciaApartado = False Then
                oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
            End If
            If oFacturaMgr.ValidaReferencia(oFactura.Referencia) Then
                MessageBox.Show("La referencia: " & CStr(oFactura.Referencia) & " ya existe", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/04/2015: En caso de que DPCard Puntos este activado y sea una venta de una tarjeta DPCard Puntos
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim resultado As Hashtable
            Dim payment() As DataRow
            ReDim payment(-1)
            If oConfigCierreFI.DPCardPuntos = True Then
                Dim bResultCanje As Boolean = True
                If IsDPCardPunto() = True AndAlso IsDPCardPuntosRenewMembership() = False Then
                    If CapturaCliente() = False Then
                        'MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                ElseIf IsDPCardPuntosRenewMembership() = True Then
                    ValidaRenewMembership()
                Else
                    payment = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
                    '---------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 16/04/2015: Se valida si es forma de Pago o solo se bonificaran puntos
                    '---------------------------------------------------------------------------------------------------------------
                    If payment.Length > 0 Then
                        '-----------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 25/04/2015: Valida si se canjearan puntos en factura normal o si hay
                        '-----------------------------------------------------------------------------------------------------------
                        Select Case Me.ModoVenta
                            Case 0
                                resultado = CanjearPuntos(bResultCanje)
                            Case 1
                                resultado = CanjearPuntosSiHay(bResultCanje)
                        End Select

                        If bResultCanje = False Then Exit Sub

                    End If
                End If
            End If
            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
            oFactura.Fecha = FechaSAP


            If oSAPMgr.SAPApplicationConfig.Inventario Then
                '-----------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 13/08/2021: Implementar el nuevo servicio de SAP CAR para validar Defectuosos, Apartados, Negados
                '-----------------------------------------------------------------------------------------------------------------------------
                Dim dtNegadosSAP As DataTable = GetStructureMaterialesNegados()
                If ValidarMaterialesSAPCAR("General", oFactura.Detalle.Tables(0), dtNegadosSAP) = False Then
                    If Not dtNegadosSAP Is Nothing AndAlso dtNegadosSAP.Rows.Count > 0 Then
                        ShowFormNegadosExistencias(dtNegadosSAP)
                    End If
                    Exit Sub
                End If
            End If


            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()

            '-----------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS 30/05/2022: Se comenta validación porque se cambio al formulario de Facturaciòn
            '-----------------------------------------------------------------------------------------------------------------------------

            'If ValidarMaterialesNegadosSH(oFactura.Detalle.Tables(0), dtNegadosSH, "PF,P,RP") = False Then
            '    ShowFormNegadosSH(dtNegadosSH)
            '    Exit Sub
            'End If

            '-----------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (07.02.2017): Se le resta la cantidad que haya habido en algun producto pendiente por surtir O Facturar
            '-----------------------------------------------------------------------------------------------------------------------------
            If ValidarMaterialesDefectuososEC(oFactura.Detalle.Tables(0), dtDefectuososEC, UserNameDesmarca, "V", dtDefecECSAP) = False Then
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (07.02.2017): Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle de la factura
            '-----------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS 30/05/2022: Se comenta validación porque se cambio al formulario de Facturaciòn
            '-----------------------------------------------------------------------------------------------------------------------------
            'If ValidarMaterialesParaNegarEC(dtNegados, oFactura.Detalle.Tables(0), dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
            '    Exit Sub
            'End If
           
            '------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (10.02.2017): Validamos para desmarcar los codigos de baja calidad EC seleccionados en SAP
            '------------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                Dim strRes As String = String.Empty
                strRes = oSAPMgr.ZPOL_DEFECTUOSOS_INS(String.Empty, "DD", UserNameDesmarca, dtDefectuososEC)
                If strRes.Trim.ToUpper <> "Y" Then
                    Exit Sub
                End If
            End If

            '------------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (20.07.2022): Se desmarcan los códigos de baja calidad en la base datos local
            '------------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oFacturaMgr.DesmarcaBajaCalidad(dtDefectuososEC)
            End If



            '------------------------------------------------------------------------------------------------------------------------------

            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el tiempo de duración operativa y detenemos el cronómetro
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            Dim TiempoOperacion As String = Me.lblCronometro.Text
            EjecutaCronometro(False)

            If imprimir = False Then
                oFactura.Impresa = 0
            Else
                oFactura.Impresa = 1
            End If
            ''--------------------------------------------------------------------------------------------------------------------------------------------------
            ''Grabamos primero en PRO si es cualquier tipo de ventas, excepto "DPVALE"
            ''--------------------------------------------------------------------------------------------------------------------------------------------------
            'If oFactura.CodTipoVenta = "V" Then
            '    oFactura.Referencia = "DPVL-" & CStr(oDpvaleSAP.IDDPVale).PadLeft(10, "0")
            'ElseIf EsInstanciaApartado = False Then
            '    oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
            'End If
            'If oFacturaMgr.ValidaReferencia(oFactura.Referencia) Then
            '    MessageBox.Show("La referencia: " & CStr(oFactura.Referencia) & " ya existe", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            If oFactura.CodTipoVenta = "V" Then
                '--------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 02.06.2015: Se encapsulo la extraccion de datos del seguro de vida de DPVL en un procedimiento
                '--------------------------------------------------------------------------------------------------------------------------------
                ExtraerDatosSeguroDeVidaDPVL()
            End If
            boolLaImprimo = False
            If Me.dsFormasPago.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No hay formas de pagos en el pedido", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/11/2018: Se valida que la suma del detalle cuadre con la cabecera
            '------------------------------------------------------------------------------------------------------
            If ValidaTotalDetalleCabecera() = False Then
                MessageBox.Show("El total no coincide con la suma del detalle", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Try
                SaveFactura()
                If oFactura.CodTipoVenta = "V" Then
                    '------------------------------------------------------------------
                    'JNAVA (02.03.2016): Obtenemos quincenas de DPVale
                    '------------------------------------------------------------------
                    oFactura.Nquincenas = oDpvaleSAP.NUMDE
                    If SaveDPValeInfo(oFactura.FacturaID) = False Then
                        MessageBox.Show("Ocurrio un error al guardar el detalle del DPVale", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al guardar la factura")
                Try
                    oFacturaMgr.ValidarFacturaExitosa(oFactura.Referencia)
                    MessageBox.Show(ex.Message, "Error factura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                Catch e As Exception
                    EscribeLog(e.Message, "Error al eliminar el pedido de venta en el dppro")
                    MessageBox.Show(e.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                Exit Sub
            End Try
            Try
                If oFacturaMgr.ValidarFacturaExitosa(oFactura.Referencia) = False Then
                    MessageBox.Show("Hubo un error al guardar el pedido de venta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    EscribeLog("Se elimino toda la venta debido a que hubo un error en el guardado del pedido", "Guardado de venta")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al eliminar el pedido de venta en el dppro")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            '----------------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/01/2016: Relaciona la factura con el serial
            '----------------------------------------------------------------------------------------------------------------------------------------------
            Try
                If oFactura.FacturaID > 0 Then
                    oFacturaMgr.SaveSerial(oFactura.SerialId, "W", oFactura.CodVendedor, oFactura.FacturaID)
                Else
                    oFacturaMgr.SaveSerial(oFactura.SerialId, "E", oFactura.CodVendedor, 0)
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/05/2015: Valida si hay formas de pago de canje para actualizar el número de tarjeta y estatus de canje
                '----------------------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                    Dim dato As New Hashtable
                    dato("NoTarjeta") = CStr(resultado("CardId"))
                    dato("CodDPCardPunto") = "CAN"
                    IsRedeem = True
                    oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                End If
                '--------------------------------------------------------------------------------------------------------------------------------------------------
                'Grabamos temporalmente los codigos de baja calidad que van en el detalle de la factura
                '--------------------------------------------------------------------------------------------------------------------------------------------------
                If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                    For Each oRow As DataRow In dtDefectuososEC.Rows
                        oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oFactura.FolioFactura, oFactura.CodCaja, "FA")
                    Next
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al actualizar tarjeta de puntos o códigos de baja calidad")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try


            '----------------------------------------------------------------------------------------------------------------------------
            'Revisamos el tiempo que dura guardando la factura en SAP
            '----------------------------------------------------------------------------------------------------------------------------
            Dim HoraSapIni As DateTime = Now

            '----------------------------------------------------------------------------------------------------------------------------
            'Guardamos la factura en SAP
            '----------------------------------------------------------------------------------------------------------------------------
            Dim response As New Dictionary(Of String, Object)
            response = SaveFacturaRetail()
            If response.ContainsKey("FolioSAP") Then
                oFactura.FolioSAP = CStr(response("FolioSAP"))
                oFactura.FolioFISAP = CStr(response("DocFi"))
                oFactura.REVALE = CStr(response("FolioRevale"))
            End If
            '----------------------------------------------------------------------------------------------------------------------------
            'Calculamos el tiempo que duró guardando la factura en SAP y guardamos el tiempo obtenido y el tiempo de operación
            '----------------------------------------------------------------------------------------------------------------------------
            If oFactura.SerialId = String.Empty OrElse oFactura.SerialId = String.Empty Then 'OrElse oFactura.FolioFISAP = "0" OrElse oFactura.FolioSAP = "0" Then
                'If oFactura.FolioFISAP = String.Empty OrElse oFactura.FolioSAP = String.Empty OrElse oFactura.FolioFISAP = "0" OrElse oFactura.FolioSAP = "0" Then

                If oFactura.CodTipoVenta = "V" Then

                    '----------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (16.11.2016): No mostramos mensaje si está activo s2credit
                    '----------------------------------------------------------------------------------------------------------------------------
                    If Not oConfigCierreFI.AplicarS2Credit Then
                        MessageBox.Show("Por el momento no se puede facturar DPortenisVale", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------

                    'Posiblemente se haga un Revale para NC.
                    'Ver que ondas con  este codigo

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (15.07.2016): Valida DPVale
                    '----------------------------------------------------------------------------------------
                    Dim FirmaDistribuidor As Image = Nothing
                    Dim NombreDistribuidor As String = String.Empty
                    '----------------------------------------------------------------------------------------

                    If EsInstanciaNC Then
                        If Not oAppSAPConfig.DPValeSAP Then
                            Dim DPValeInfo As New DevolucionDPValeInfo()
                            DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            DPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.MontoDPVale
                            DPValeInfo.FechaExpedicion = FechaSAP
                            DPValeInfo.FechaEntregado = FechaSAP
                            DPValeInfo.FacturaId = 0
                            DPValeInfo.MontoDPValeUtilizado = 0
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)

                            owsDPValeInfo = New ControlDPValesWS.DPValeInfo
                            owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            'owsDPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                            'owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                            owsDPValeInfo.FechaExpedicion = FechaSAP.ToShortDateString
                            owsDPValeInfo.FechaEntregado = FechaSAP.ToShortDateString
                            owsDPValeInfo.FacturaID = 0
                            owsDPValeInfo.MontoUtilizado = 0
                            owsDPValeInfo.MontoDPValeP = 0
                            Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                            owsDPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)
                            PrintRevale(DPValeInfo, String.Empty, Nothing)
                        Else
                            owsDPValeInfo = New ControlDPValesWS.DPValeInfo
                            owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale

                            Dim oDPVale As New cDPVale
                            oDPVale.INUMVA = CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0")

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (14.07.2016): Valida DPVale
                            '----------------------------------------------------------------------------------------
                            If oConfigCierreFI.AplicarS2Credit Then
                                oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                            Else
                                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                            End If
                            '----------------------------------------------------------------------------------

                            Dim oRow As DataRow
                            oRow = oDPVale.InfoDPVALE.Rows(0)
                            Dim DPValeInfo As New DevolucionDPValeInfo()
                            DPValeInfo.DPValeOrigen = oRow("Orige")
                            DPValeInfo.FechaExpedicion = FechaSAP
                            DPValeInfo.FechaEntregado = FechaSAP
                            DPValeInfo.FacturaId = 0
                            DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                            DPValeInfo.MontoDPValeUtilizado = 0
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID


                            'owsDPValeInfo.DPValeOrigen = oRow("Orige")
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                            'owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                            owsDPValeInfo.FechaExpedicion = FechaSAP.ToShortDateString
                            owsDPValeInfo.FechaEntregado = FechaSAP.ToShortDateString
                            owsDPValeInfo.FacturaID = 0
                            owsDPValeInfo.MontoUtilizado = 0
                            owsDPValeInfo.MontoDPValeP = 0
                            Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                            owsDPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                            PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
                        End If
                    End If

                    Exit Sub
                ElseIf oFactura.CodTipoVenta = "D" Then
                    MessageBox.Show("Por el momento no se puede facturar DIPS", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            '----------------------------------------------------------------------------------------------------
            'Quemamos el cupon de descuento en caso de existir en SAP
            '----------------------------------------------------------------------------------------------------
            Try
                If Not oCuponDesc Is Nothing Then
                    Dim strFolioNew As String = ""
                    Dim pagos As DataTable = GetEnviosFormasPago()
                    Dim result As New Dictionary(Of String, Object)
                    RestService.Metodo = "/pos/cupones"
                    result = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.Referencia, pagos)
                    strFolioNew = CStr(result("SapZcupUtilCupon")("E_FOLIO"))
                    'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, strFolioNew, pagos)
                    oFacturaMgr.ActualizarCuponDetalle(oFactura.FacturaID, strFolioNew)
                End If
                '------------------------------------------------------------------------------------------------------------------------
                'Quemamos el vale de empleado en caso de existir en SAP
                '------------------------------------------------------------------------------------------------------------------------
                '------------------------------------------------------------------------------------------------------------------------
                'Si no es DPVALE entonces actualizamos los folio SAP y FI validamos si me regreso folios SAP para la factura
                '------------------------------------------------------------------------------------------------------------------------
                If oFactura.FolioSAP.Trim <> String.Empty And oFactura.FolioFISAP.Trim <> String.Empty Then
                    '--------------------------------------------------------------------------------------------------------------------
                    'Actualizamos los folios SAP
                    '--------------------------------------------------------------------------------------------------------------------
                    oFacturaMgr.UpdateFolioSAP(oFactura)
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al actualizar factura o cupon")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try


            '------------------------------------------------------------------------------------------------------------------------
            'Guardamos la relacion cliente-venta y la razon por la que rechazaron registrar los datos del cliente en caso de ser asi
            '------------------------------------------------------------------------------------------------------------------------

            '------------------------------------------------------------------------------------------------------------------------
            'Imprimimos la Factura
            '------------------------------------------------------------------------------------------------------------------------
            Try
                Select Case Me.ModoVenta
                    Case 0
                        If oFactura.Impresa = True Then
                            If oFactura.CodTipoVenta = "V" Then
                                ActionPreview3(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                                If MessageBox.Show("¿Desea volver a imprimir esta factura?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                    ActionPreview3(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                                End If
                            Else
                                '------------------------------------------------------------------------------------------------------------------------
                                'RGERMAIN 15.11.2013: Se revisa si está activa la impresion termica de la miniprinter y es tipo de venta empleado o dpvale
                                'para imprimirlo 1 vez mas para anexar la copia al corte
                                '------------------------------------------------------------------------------------------------------------------------


                                If oConfigCierreFI.MiniprinterTermica AndAlso InStr("E", oFactura.CodTipoVenta) > 0 Then ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                                ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                            End If

                        Else
                            ActionPreview2(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                        End If
                    Case 1
                        If oFactura.Impresa = True Then

                        End If
                End Select
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al Imprimir Factura")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try


            Me.Cursor = Cursors.Default

            '---------------------------------------------------------------------------------------------------------------------------
            'Si se guardó correctamente la factura en SAP continuamos con el proceso de los pedidos del EC
            '---------------------------------------------------------------------------------------------------------------------------
            If oFactura.FolioSAP.Trim <> "" And oFactura.FolioFISAP.Trim <> "" Then
                '-----------------------------------------------------------------------------------------------------------------------
                'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario si esta activado el proceso de surtido para
                'EC en la config
                '-----------------------------------------------------------------------------------------------------------------------
                Try
                    If oConfigCierreFI.SurtirEcommerce Then
                        If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                            oSAPMgr.ZPOL_TRASL_NEGAR(oFactura.FolioSAP, "V", UserNameNiega, dtNegados)
                            ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                        End If
                    End If
                    '-----------------------------------------------------------------------------------------------------------------------
                    'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en la factura
                    '-----------------------------------------------------------------------------------------------------------------------
                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        If oSAPMgr.ZPOL_DEFECTUOSOS_INS(oFactura.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
                            oFacturaMgr.BorrarCodigosBajaCalidad(oFactura.FolioFactura, oFactura.CodCaja, "FA")
                        End If
                    End If
                Catch ex As Exception
                    EscribeLog(ex.Message, "Error al guardar defectusos y codigos de baja calidad")
                    MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
            End If

            '---------------------------------------------------------------------------------------------------------------------------
            'JNAVA - 08/11/2013: Generamos cupon si existe promocion de descuento proxima compra
            '---------------------------------------------------------------------------------------------------------------------------
            'RGEMAIN 08.07.2015: Generamos el cupon de promocion proxima compra solo si es la primera vez que compran con la tarjeta de
            '                    DPCard Credit
            '---------------------------------------------------------------------------------------------------------------------------
            'If bPrimeraCompraKarum AndAlso oFactura.CodTipoVenta.Trim <> "D" Then CuponDescuentoProximaCompra(oFactura)

            bPrimeraCompraKarum = False
            Try
                '---------------------------------------------------------------------------------------------------------------------------
                'JNAVA - 08/11/2013: Generamos ReReVale si el Tipo de Venta es de DPVale
                '---------------------------------------------------------------------------------------------------------------------------
                GenerarReReValeVentaDPVALE(oFactura)

                '---------------------------------------------------------------------------------------------------------------------------
                'JNAVA (05.12.2014): Guardamos (de ser necesario) los Electronicos de la Factura en SAP
                '---------------------------------------------------------------------------------------------------------------------------
                GuardarElectronicosSAP()

                '---------------------------------------------------------------------------------------------------------------------------
                'JNAVA (06.02.2015): Guardamos (de ser necesario) el registro del Seguro de DPVale en la BD
                '---------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 28.04.2015: Validamos si realmente se genero el seguro de vida en SAP y solo asi guardamos e imprimimos el ticket
                '                     del seguro de vida
                '---------------------------------------------------------------------------------------------------------------------------
                If oFactura.SeguroVidaSAPDPVL Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (08.04.2016): Revisamos si esta activo S2Credit como Validador
                    '---------------------------------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then

                        '---------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (08.04.2016): Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
                        '---------------------------------------------------------------------------------------------------------------------------
                        If Not DatosTicketSeguro Is Nothing Then
                            GuardarSeguroS2Credit(oDpvaleSAP)
                        End If
                    Else
                        CapturaBeneficiarioSeguroDPVL(Me.oDpvaleSAP)
                        GuardarSeguroDPVale(oFactura.CodTipoVenta)
                    End If

                Else
                    '---------------------------------------------------------------------------------------------------------------------------
                    ' JNAVA (02.07.2015): Si no se genera seguro de vida, mostramos el mensaje de Motivo de Rechazo
                    '---------------------------------------------------------------------------------------------------------------------------
                    If RechazoSeguro.Trim <> "" Then ' PONER TRIM PARA FIX
                        MessageBox.Show(RechazoSeguro, "Seguro de Vida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                '-----------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 31/07/2017: Imprime pagare de vale electronico
                '-----------------------------------------------------------------------------------------------------------
                If oDpvaleSAP.ValeElectronico Then
                    ImprimeValeElectronico(oDpvaleSAP)
                End If
                '--------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 01/04/2015: Activamos o aplicamos puntos a DPCard Puntos 
                '---------------------------------------------------------------------------------------------------------------------------
                DPCardPuntos()

                '------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS (28/02/2020) Actualizamos el estatus de las Transacciones con tarjeta CLUB DP, introducidas manualmente de existir
                '------------------------------------------------------------------------------------------------------------------------

                If lstItems.Count > 0 Then
                    For Each item As String In lstItems
                        oFacturaMgr.UpdEstatusTransaccionSinTarjeta(item, "Transacción concluida")
                    Next
                End If

                '---------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/05/2015: Se imprime el recibo de Canje
                '---------------------------------------------------------------------------------------------------------------------------                

                If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                    PrintTicketDPCardPuntos(resultado)
                End If
                '---------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 29.08.2014: Capturamos Cel del cliente solo si no esta activada la config
                '---------------------------------------------------------------------------------------------------------------------------
                CapturaCelParaSMS(oConfigCierreFI.PedirDatosPromoComienzo, False)
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al finalizar el pedido")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Me.DialogResult = DialogResult.OK

        End If
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/05/2014: Actualiza el ScoreBoard siempre y cuando este configurado
        '------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ScoreBoard Then
            DashBoard.ShowAndUpdateScoreBoard()
        End If

    End Sub

    Private Sub CapturaCelParaSMS(ByVal bUpdate As Boolean, ByVal bShow As Boolean)
        Dim frmCapCel As frmCapturaCelSMS
        Try
            Dim ZonaVenta() As String
            Dim strCliente As String = ""
            '---------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Si no es actualizacion de datos hacemos el proceso completo, si no solo actualizamos los datos
            '---------------------------------------------------------------------------------------------------------------------------
            If bUpdate = False Then
                '---------------------------------------------------------------------------------------------------------------
                'Preguntamos si desea dejar su cel para envio de promociones si la config esta activada
                '---------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.PromoSMS AndAlso MessageBox.Show("¿Desea recibir nuestras promociones a través de un SMS?", _
                 "Promociones SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    frmCapCel = New frmCapturaCelSMS
                    'PedirCel:
                    If frmCapCel.ShowDialog = DialogResult.OK Then
                        '    If MessageBox.Show("¿Estas seguro que deseas cancelar la captura del teléfono celular del cliente?", _
                        '     "Promoción SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        '        GoTo PedirCel
                        '    End If
                        'Else
                        ZonaVenta = GetZonaVentaSAP(oFactura.CodTipoVenta)
                        strCliente = GetClienteFactura(True)
                        '7:                  'oSAPMgr.ZRFC_INSERTA_DATOS_SMS(strCel.Trim, ZonaVenta(0), strCliente.Trim)

                        '--------------------------------------------------------------------------------------
                        ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
                        '--------------------------------------------------------------------------------------
                        'oSAPMgr.ZRFC_INSERTA_DATOS_PROMO(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, ZonaVenta(0), strCliente.Trim, frmCapCel.ebEmail.Text.Trim, oFactura.FolioSAP, Me.DPValeVentaID)
                        Dim oRetail As New ProcesosRetail("/pos/tiendas", "POST")
                        oRetail.SapZrfcInsetaDatosPromo(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, ZonaVenta(0), strCliente.Trim, frmCapCel.ebEmail.Text.Trim, oFactura.FolioSAP, Me.DPValeVentaID)

                    End If
                End If
            Else
                Dim strDatos() As String
                If strDatosPromoClientes.Trim <> "" Then strDatos = strDatosPromoClientes.Trim.Split("|")
                frmCapCel = New frmCapturaCelSMS
                If bShow Then
                    If strDatosPromoClientes.Trim <> "" Then
                        frmCapCel.nebLada.Value = strDatos(0)
                        frmCapCel.nebNumCel.Value = strDatos(1)
                        frmCapCel.ebEmail.Text = strDatos(2)
                    End If
                    frmCapCel.ShowDialog()
                End If
                If (bShow = False AndAlso strDatosPromoClientes.Trim <> "") OrElse frmCapCel.DialogResult = DialogResult.OK Then
                    strCliente = GetClienteFactura(True)
                    If frmCapCel Is Nothing Then
                        ZonaVenta = GetZonaVentaSAP(oFactura.CodTipoVenta)
                        '--------------------------------------------------------------------------------------
                        ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
                        '--------------------------------------------------------------------------------------
                        'oSAPMgr.ZRFC_INSERTA_DATOS_PROMO(strDatos(0).Trim, strDatos(1).Trim, ZonaVenta(0), strCliente.Trim, strDatos(2).Trim, oFactura.FolioSAP, Me.DPValeVentaID)
                        Dim oRetail As New ProcesosRetail("/pos/tiendas", "POST")
                        oRetail.SapZrfcInsetaDatosPromo(strDatos(0).Trim, strDatos(1).Trim, ZonaVenta(0), strCliente.Trim, strDatos(2).Trim, oFactura.FolioSAP, Me.DPValeVentaID)
                    Else

                        '--------------------------------------------------------------------------------------
                        ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
                        '--------------------------------------------------------------------------------------
                        'oSAPMgr.ZRFC_INSERTA_DATOS_PROMO(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, "", strCliente.Trim, frmCapCel.ebEmail.Text.Trim, oFactura.FolioSAP, Me.DPValeVentaID)
                        Dim oRetail As New ProcesosRetail("/pos/tiendas", "POST")
                        oRetail.SapZrfcInsetaDatosPromo(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, "", strCliente.Trim, frmCapCel.ebEmail.Text.Trim, oFactura.FolioSAP, Me.DPValeVentaID)
                        strDatosPromoClientes = frmCapCel.nebLada.Value & "|" & frmCapCel.nebNumCel.Value & "|" & frmCapCel.ebEmail.Text.Trim
                    End If
                End If
            End If

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al capturar celular para sms: Linea " & Err.Erl)
        Finally
            If Not frmCapCel Is Nothing Then
                frmCapCel.Dispose()
                frmCapCel = Nothing
            End If
        End Try

    End Sub

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
                If dvPedDet.Count <= 0 Then
                    oSAPMgr.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, oRowN!ID_SOLICITUD)
                End If
            End If
        Next

    End Sub

    'Private Function ValidarClienteFacturaValeCaja(ByVal strCodClienteVC As String) As Boolean

    '    Dim bRes As Boolean = True
    '    Dim strClienteFactura As String = GetClienteFactura.ToUpper.Trim
    '    Dim strCodTipoCliente As String = ""

    '    strCodTipoCliente = oFacturaMgr.ValidaTipoVentaCliente(strCodClienteVC.Trim.PadLeft(10, "0"))

    '    If strCodClienteVC.Trim.ToUpper <> strClienteFactura.ToUpper.Trim Then
    '        If InStr("I,A,D,S,V", strCodTipoCliente.Trim.ToUpper) > 0 Then
    '            If strCodTipoCliente.Trim.ToUpper = "V" AndAlso strClienteFactura.Trim = "" Then
    '                MessageBox.Show("Es necesario primero agregar la forma de pago DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Else
    '                MessageBox.Show("Verifique el número de cliente..." & vbCrLf & "Para Vale de caja y esta Factura, el valor indicado no corresponde, en el tipo de venta Seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If
    '            bRes = False
    '        End If
    '    End If
    '    'If strCodClienteVC.Trim.ToUpper <> strClienteFactura.ToUpper.Trim Then
    '    '    Select Case strCodTipoVenta.Trim.ToUpper
    '    '        Case "D", "I", "S"
    '    '            MessageBox.Show("Verifique el número de cliente..." & vbCrLf & "Para Vale de caja y esta Factura, el valor indicado no corresponde, en el tipo de venta Seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    '            bRes = False
    '    '        Case "V"
    '    '            If strClienteFactura.Trim = "" Then
    '    '                MessageBox.Show("Es necesario primero agregar la forma de pago DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    '            End If
    '    '            bRes = False
    '    '    End Select
    '    'End If

    '    Return bRes

    'End Function

    Private Function GetTipoClienteVC(ByVal strCodClienteVC As String) As String

        Dim strCodTipoCliente As String = ""
        strCodTipoCliente = oFactura.CodTipoVenta
        'Select Case strCodClienteVC.Trim.ToUpper
        '    Case "0260002268", "0260000000", "0260000001"
        '        strCodTipoCliente = oFactura.CodTipoVenta
        '    Case Else
        '        strCodTipoCliente = oFacturaMgr.ValidaTipoVentaCliente(strCodClienteVC.Trim.PadLeft(10, "0"))
        'End Select

        Return strCodTipoCliente

    End Function

    Private Function ValidarClienteFacturaValeCaja(ByVal strCodClienteVC As String) As Boolean

        Dim bRes As Boolean = True
        Dim strClienteFactura As String = GetClienteFactura.ToUpper.Trim
        Dim strCodTipoCliente As String = ""

        If strCodClienteVC.Trim.ToUpper <> strClienteFactura.ToUpper.Trim Then
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Revisamos el tipo de cliente al que pertenece el vale de caja
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Select Case strCodClienteVC.Trim.ToUpper
            '    Case "0260002268", "0260000000", "0260000001"
            '        strCodTipoCliente = oFactura.CodTipoVenta
            '    Case Else
            '        strCodTipoCliente = oFacturaMgr.ValidaTipoVentaCliente(strCodClienteVC.Trim.PadLeft(10, "0"))
            'End Select
            strCodTipoCliente = GetTipoClienteVC(strCodClienteVC)
            '----------------------------------------------------------------------------------------------------------------------------------
            'Si el tipo de cliente es facturacon fiscal, apartado, dips o socios no permite agregar el vale de caja
            '----------------------------------------------------------------------------------------------------------------------------------
            If InStr("I,A,D,S,V", strCodTipoCliente.Trim.ToUpper) > 0 Then
                If strCodTipoCliente.Trim.ToUpper = "V" Then
                    If strClienteFactura.Trim = "" Then
                        MessageBox.Show("Es necesario primero agregar la forma de pago DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Verifique el número de cliente..." & vbCrLf & "Para Vale de caja y esta Factura, el valor indicado no corresponde, en el tipo de venta Seleccionado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bRes = False
                End If
            End If
        End If

        Return bRes

    End Function

    '--------------------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (24.02.2016): Se comento por que ya no se usara
    '--------------------------------------------------------------------------------------------------------------------------------------------------
    'Private Function RealizarTraspasoSaldos() As Boolean
    '    Dim bRes As Boolean = True
    '    Dim strClienteFactura As String = ""
    '    Dim strClienteVC As String = ""
    '    Dim strCodTipoClienteVC As String = ""

    '    Try
    '        Dim oRow As DataRow
    '        Dim strFolioTraspaso As String = ""
    '        Dim oValeCajaTemp As ValeCaja

    '        strClienteFactura = GetClienteFactura()

    '        If Not dtValeCaja Is Nothing AndAlso dtValeCaja.Rows.Count > 0 Then
    '            For Each oRow In dtValeCaja.Rows
    '                strClienteVC = ""
    '                strClienteVC = CStr(oRow!ClienteSAPID)
    '                strCodTipoClienteVC = GetTipoClienteVC(strClienteVC)
    '                If strClienteVC.Trim.ToUpper <> strClienteFactura.Trim.ToUpper AndAlso strCodTipoClienteVC.Trim.ToUpper <> "V" Then
    '                    oValeCajaTemp = oValeCajaMgr.Load(oRow!ValeCajaID)
    '                    If Not oValeCajaTemp Is Nothing Then
    '                        If oValeCajaTemp.FolioFITrasladoSaldo.Trim = "" Then
    '                            strFolioTraspaso = oSAPMgr.ZBAPI_TRASLADO_SALDOS(strClienteVC, strClienteFactura, CStr(oRow!FolioFISAPDev)) ', CStr(oRow!FolioFISAPVta))
    '                            If strFolioTraspaso = "" Then
    '                                bRes = False
    '                                Exit For
    '        
    'Else
    '                                oValeCajaMgr.UpdateFolioFITS(oValeCajaTemp.ValeCajaID, strFolioTraspaso)
    '                                'oRow!FolioFITraslado = strFolioTraspaso.Trim
    '                            End If
    '                        End If
    '                    Else
    '                        EscribeLog("No existe el vale de caja con ID: " & oRow!ValeCajaID, "No existe Vale de Caja")
    '                        bRes = False
    '                        Exit For
    '                    End If
    '                End If
    '            Next
    '            dtValeCaja.AcceptChanges()
    '        End If
    '        '1:          If strClienteSAPValeCaja.Trim <> CStr(oFactura.ClienteId).Trim Then
    '        '                Dim dRow As DataRow
    '        '2:              Dim dtFormasPago As DataTable = dsFormasPago.Tables(0).Copy
    '        '3:              If dtFormasPago.Rows.Count > 0 Then
    '        '4:                  For Each dRow In dtFormasPago.Rows
    '        '5:                      If dRow!CodFormasPago = "VCJA" Then
    '        '6:                          If oSAPMgr.ZBAPI_TRASLADO_SALDOS(strClienteSAPValeCaja, oFactura.ClienteId, strFolioFIValeCaja) = "" Then
    '        '                                bRes = False
    '        '                                Exit For
    '        '                            End If
    '        '                        End If
    '        '                    Next
    '        '                End If
    '        '            End If
    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "Error al traspasar el saldo del cliente " & strClienteSAPValeCaja & " al cliente " & strClienteFactura & " Linea: " & Err.Erl)
    '        bRes = False
    '    End Try

    '    Return bRes

    'End Function

    Public Function GetClienteFactura(Optional ByVal ParaSMS As Boolean = False) As String

        Dim strClienteID As String = ""
        Dim arDatosDPVale() As String

        Select Case oFactura.CodTipoVenta
            Case "P"
                If ParaSMS = False Then
                    strClienteID = oAppContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                Else
                    strClienteID = IIf(oFactura.ClientPGID > 0, oFactura.ClientPGID, "1")
                End If
            Case "E"
                If ParaSMS = False Then
                    strClienteID = "99999".PadLeft(10, "0")
                Else
                    strClienteID = ""
                End If
            Case "I", "A", "S", "D"
                strClienteID = CStr(oFactura.ClienteId).PadLeft(10, "0")
            Case "F"
                If ParaSMS = False Then
                    strClienteID = "0260000000"
                Else
                    strClienteID = CStr(oFactura.ClienteId).PadLeft(10, "0")
                End If
            Case "K"
                If ParaSMS = False Then
                    strClienteID = "0260002268"
                Else
                    strClienteID = CStr(oFactura.ClienteId).PadLeft(10, "0")
                End If
            Case "O"
                If ParaSMS = False Then
                    strClienteID = "0260000001"
                Else
                    strClienteID = CStr(oFactura.ClienteId).PadLeft(10, "0")
                End If
            Case "V"
                If Not dtDPVale Is Nothing AndAlso dtDPVale.Rows.Count > 0 Then
                    arDatosDPVale = GetDPValeSAP()
                    'strClienteID = arDatosDPVale(0).PadLeft(10, "0")
                    If ParaSMS Then
                        'Se toma el codcliente para relacionar el celular con el cliente del distribuidor
                        strClienteID = arDatosDPVale(0).PadLeft(10, "0")
                    Else
                        'Se toma el codigo del distribuidor porque es a quien se le pone el saldo a favor cuando se hace una devolucion de dpvale
                        strClienteID = arDatosDPVale(2).PadLeft(10, "0")
                    End If
                Else
                    strClienteID = ""
                End If
        End Select

        Return strClienteID

    End Function

    Private Sub frmPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        boolLaImprimo = False

        '--Inicializamos Objjetos
        'InitializeObjects()

        InitializeObjectsSAP()

        '--Creamos dataset de formas de pago
        CreateDataFormaPago()

        vNombreAsociado = String.Empty
        vNombreClienteAsociado = String.Empty
        Me.strNoAfiliacion = String.Empty
        Me.strTarjetaBloq = String.Empty

        '--Si la venta es DPVale
        'If oFactura.CodTipoVenta = "V" And EsInstanciaNC = False Then
        If oFactura.CodTipoVenta = "V" Then
            CreateDataDPVale()
        End If

        '--Llenamos el Combo Formas de Pago
        FillFormaPago()

        '--Llenamos el Combo Caja
        FillBancos()

        '--Llenamos el Combo TipoTarjeta
        FillTipoTarjeta()

        'Creamos Estructura Combo Promociones
        Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False

        '--Si la facturacion es por nota de credito
        If EsInstanciaNC Then
            cmbFormaPago.Enabled = False
            EBPago.Enabled = False
            With oDevolucionDPValeInfo
                If .MontoDPVale > ebImporteTotal.Value Then
                    If .MontoDPVale - ebImporteTotal.Value >= 0.01 AndAlso .MontoDPVale - ebImporteTotal.Value <= 0.99 Then
                        .MontoDPVale = ebImporteTotal.Value
                    End If
                End If
                'EBPago.Value = oDevolucionDPValeInfo.MontoDPVale
                EBPago.Value = .MontoDPVale
            End With
        Else
            '--Si es facturación de apartado
            If EsInstanciaApartado Then
                '--Agregamos Pago Liquidacion
                AgregaPagoLiquidacion()
            Else
                EBPago.Value = ebImporteTotal.Value
            End If
        End If

        If UCase(oFactura.CodTipoVenta) = "F" Then  'Venta Fonacot
            If Not oVC.ValeCajaID > 0 Then
                cmbFormaPago.Value = "FONA"
                cmbFormaPago.Enabled = False
            Else
                If oFactura.Total = oVC.Importe Then
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total
                    'AgregaPagoFacilito()
                    uitnAgregar.PerformClick()
                Else
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total - oVC.Importe
                    'AgregaPagoFacilito()
                    uitnAgregar.PerformClick()
                End If
            End If

        End If

        If UCase(oFactura.CodTipoVenta) = "K" Then  'Venta Tarjeta Fonacot
            If Not oVC.ValeCajaID > 0 Then
                cmbFormaPago.Value = "TFON"
                'cmbFormaPago.Enabled = False
            Else
                Me.ebFolioValeCaja.Text = oVC.FolioDocumento.Trim.PadLeft(10, "0")
                Me.ebFolioValeCaja_Validating(Nothing, Nothing)
                If oFactura.Total = oVC.Importe Then
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total
                    'AgregaPagoFacilito()
                    uitnAgregar.PerformClick()
                Else
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total - oVC.Importe
                    'AgregaPagoFacilito()
                    uitnAgregar.PerformClick()
                End If
            End If

        End If

        If UCase(oFactura.CodTipoVenta) = "O" Then  'Venta Facilito
            'Fonacot Facilito change -->This IF
            If Not oVC.ValeCajaID > 0 Then
                Dim omsgR As MsgBoxResult
                omsgR = MsgBox("Se encuentra realizando una Venta Facilito. ¿Desea aplicarle un enganche al Documento? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, " Facturación")
                If omsgR = MsgBoxResult.No Then
                    cmbFormaPago.Value = "FACI"
                    EBPago.Value = oFactura.Total
                    AgregaPagoFacilito()
                Else
                    cmbFormaPago.Value = "EFEC"
                End If
            Else
                If oFactura.Total = oVC.Importe Then
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total
                    AgregaPagoFacilito()
                Else
                    cmbFormaPago.Value = "VCJA"
                    EBPago.Value = oFactura.Total - oVC.Importe
                    AgregaPagoFacilito()
                End If

            End If

        End If

        ' Si se ha hecho algun cargo con forma de pago TACR o TADB mediante eHub y no se ha guardado la factura
        If dsFormasPago.Tables(0).Rows.Count > 0 Then

            '--Actualizamos cambio
            ActualizaCambioCliente()

            For Each oRow As DataRow In dsFormasPago.Tables(0).Rows

                If oRow!CodFormasPago = "TACR" OrElse oRow!CodFormasPago = "TADB" OrElse oRow!CodFormasPago = "TFON" Then
                    Me.ebTotalPagoCliente.Value += oRow!MontoPago
                End If

            Next

            LimpiaCamposFormaPago(False)

        End If

        If bCronometro Then EjecutaCronometro(True)

        If oConfigCierreFI.PedirDatosPromoComienzo Then
            Me.lblCapturaDatos.Visible = True
            Me.lblF12.Visible = True
        End If

        If Me.tipoV Then
            Me.cmbFormaPago.Enabled = False
            Me.cmbFormaPago.Value = "DPVL"
            Me.cmbFormaPago.Text = "DPVALE"
            'Console.WriteLine("dpvale activado")
        End If

    End Sub

#End Region

#Region "Fill Combos And Data"

    Private Function GetFormasPagoCupon(ByVal formasPago As DataTable) As String
        Dim strPago As String = ""
        For Each row As DataRow In formasPago.Rows
            strPago &= "'" & CStr(row!FORMA_PAGO) & "',"
        Next
        If oNotaCredito.SALESDOCUMENT.Trim() = "" Then
            Select Case oFactura.CodTipoVenta
                Case "K"
                    strPago &= "'TFON','FONA',"
                Case "O"
                    strPago &= "'FACI',"
            End Select
        End If
        If strPago.Length > 0 Then
            strPago = strPago.Remove(strPago.Length - 1, 1)
        Else
            strPago = "''"
        End If
        Return strPago
    End Function

    Private Function GetEnviosFormasPago() As DataTable
        Dim formasPago As New DataTable("T_FORMASPAGO")
        formasPago.Columns.Add("FORMA_PAGO", GetType(String))
        For Each row As DataRow In dsFormasPago.Tables(0).Rows
            Dim fila As DataRow = formasPago.NewRow()
            fila("FORMA_PAGO") = CStr(row!CodFormasPago)
            formasPago.Rows.Add(fila)
        Next
        Return formasPago
    End Function

    Private Function FiltrarFormasPago(ByVal strFormasPago As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If InStr(strFormasPago.Trim.ToUpper, CStr(oRow!CodFormasPago).Trim.ToUpper) <= 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp

    End Function

    Private Function FiltrarTerminal(ByVal Terminal As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If InStr(Terminal.Trim().ToUpper(), CStr(oRow!CodBanco).Trim().ToUpper()) <= 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp
    End Function

    Private Sub FillFormaPago()
        Dim dtFormasPago As DataTable = oCatFormaPago.GetAll(oFactura.CodTipoVenta).Tables(0)
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 26.07.2013: Quitamos la formas de pago no permitidas para las Ventas SH
        '-------------------------------------------------------------------------------------------------------------------------------------------------


        If ModoVenta = 1 Then
            dtFormasPago = FiltrarFormasPago("VCJA", dtFormasPago)
            dtFormasPago = FiltrarFormasPago("DPPT", dtFormasPago)
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (29.01.2015): Validamos si esta activa la Config de DP Card para aceptar la forma de pago
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        If Not oConfigCierreFI.AplicaDPCard Then
            dtFormasPago = FiltrarFormasPago("DPCA", dtFormasPago)
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 16/05/2015: Validar si esta activa la Configuración de DPCard Puntos si no esta activa la quitamos de la formas de pago
        '-------------------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.DPCardPuntos = False Then
            dtFormasPago = FiltrarFormasPago("DPPT", dtFormasPago)
        End If

        If oFactura.CodTipoVenta = "O" AndAlso oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
            dtFormasPago = FiltrarFormasPago("FACI", dtFormasPago)
        End If

        If oFactura.CodTipoVenta = "K" AndAlso oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
            dtFormasPago = FiltrarFormasPago("TFON", dtFormasPago)
            dtFormasPago = FiltrarFormasPago("FONA", dtFormasPago)
        End If


        If IsDPCardPunto() Then
            dtFormasPago = FiltrarFormasPago("DPPT", dtFormasPago)
        End If

        Dim dvFormasPago As DataView
        Dim strFormaPago As String = ""
        If Not oCuponDesc Is Nothing OrElse (Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0) Then
            'strFormaPago = oCuponDesc.Descripcion.Trim.Split(" ")(0)
            If oCuponDesc Is Nothing Then
                dtDescFormasPago.Columns("CodFormaPago").ColumnName = "FORMA_PAGO"
                dtDescFormasPago.AcceptChanges()
                strFormaPago = GetFormasPagoCupon(dtDescFormasPago)
            Else
                strFormaPago = GetFormasPagoCupon(oCuponDesc.FormasPago)
            End If
            dvFormasPago = New DataView(dtFormasPago, "CodFormasPago IN (" & strFormaPago.Trim.ToUpper & ")", "", DataViewRowState.CurrentRows)
            'If dvFormasPago.Count > 0 Then
            '    cmbFormaPago.DataSource = dvFormasPago
            'Else
            '    cmbFormaPago.DataSource = dtFormasPago
            'End If
            'Else
            '    cmbFormaPago.DataSource = dtFormasPago
        End If

        If Not dvFormasPago Is Nothing AndAlso dvFormasPago.Count > 0 Then
            cmbFormaPago.DataSource = dvFormasPago
        Else
            cmbFormaPago.DataSource = dtFormasPago
        End If

        'cmbFormaPago.DataSource = oCatFormaPago.GetAll(oFactura.CodTipoVenta).Tables(0)


        cmbFormaPago.DropDownList.Columns.Add("Cod.")
        cmbFormaPago.DropDownList.Columns.Add("Descripción")
        cmbFormaPago.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
        cmbFormaPago.DropDownList.Columns("Cod.").Width = 50
        cmbFormaPago.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbFormaPago.DropDownList.Columns("Descripción").Width = 150
        cmbFormaPago.DisplayMember = "Descripcion"
        cmbFormaPago.ValueMember = "CodFormasPago"

        cmbFormaPago.Refresh()

        If Not dvFormasPago Is Nothing AndAlso dvFormasPago.Count > 0 Then
            If strFormaPago.Trim = "EFEC" Then
                cmbFormaPago.Value = strFormaPago.Trim.ToUpper
            End If
            If oFactura.CodTipoVenta.Trim.ToUpper = "V" Then
                Me.cmbFormaPago.Value = "DPVL"
            End If
        Else
            Select Case oFactura.CodTipoVenta
                Case "P"    'Publico General
                    cmbFormaPago.Value = "EFEC"
                Case "V"    'DPVale
                    cmbFormaPago.Value = "DPVL"
                    cmbFormaPago.Enabled = False
                    'Case "D"    'DPVale
                    '    cmbFormaPago.Value = "CRED"
                Case "D"    'DIPS
                    cmbFormaPago.Value = "EFEC"
                Case "I"    'Fact. Fiscal
                    cmbFormaPago.Value = "EFEC"
                Case "A"    'Apartados
                    cmbFormaPago.Value = "LIQU"
            End Select
        End If
    End Sub

    'Private Sub FillFormaPago()

    '    Dim dtFormasPago As DataTable = oCatFormaPago.GetAll(oFactura.CodTipoVenta).Tables(0)
    '    Dim dvFormasPago As DataView
    '    Dim strFormaPago As String = ""

    '    If Not oCuponDesc Is Nothing Then
    '        strFormaPago = oCuponDesc.Descripcion.Trim.Split(" ")(0)
    '        dvFormasPago = New DataView(dtFormasPago, "CodFormasPago = '" & strFormaPago.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)
    '        If dvFormasPago.Count > 0 Then
    '            cmbFormaPago.DataSource = dvFormasPago
    '        Else
    '            cmbFormaPago.DataSource = dtFormasPago
    '        End If
    '    Else
    '        cmbFormaPago.DataSource = dtFormasPago
    '    End If

    '    cmbFormaPago.DropDownList.Columns.Add("Cod.")
    '    cmbFormaPago.DropDownList.Columns.Add("Descripción")
    '    cmbFormaPago.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
    '    cmbFormaPago.DropDownList.Columns("Cod.").Width = 50
    '    cmbFormaPago.DropDownList.Columns("Descripción").DataMember = "Descripcion"
    '    cmbFormaPago.DropDownList.Columns("Descripción").Width = 150
    '    cmbFormaPago.DisplayMember = "Descripcion"
    '    cmbFormaPago.ValueMember = "CodFormasPago"

    '    cmbFormaPago.Refresh()

    '    If Not dvFormasPago Is Nothing AndAlso dvFormasPago.Count > 0 Then
    '        If strFormaPago.Trim = "EFEC" Then
    '            cmbFormaPago.Value = strFormaPago.Trim.ToUpper
    '        End If
    '    Else
    '        Select Case oFactura.CodTipoVenta
    '            Case "P"    'Publico General
    '                cmbFormaPago.Value = "EFEC"
    '            Case "V"    'DPVale
    '                cmbFormaPago.Value = "DPVL"
    '                cmbFormaPago.Enabled = False
    '                'Case "D"    'DPVale
    '                '    cmbFormaPago.Value = "CRED"
    '            Case "D"    'DIPS
    '                cmbFormaPago.Value = "EFEC"
    '            Case "I"    'Fact. Fiscal
    '                cmbFormaPago.Value = "EFEC"
    '            Case "A"    'Apartados
    '                cmbFormaPago.Value = "LIQU"
    '        End Select
    '    End If

    'End Sub

    Private Sub FillFormaPagoDEVFACFON(ByVal strTipo As String)
        Dim dtFormaPago As DataTable = oCatFormaPago.GetAll(strTipo).Tables(0)
        If oFactura.CodTipoVenta = "O" AndAlso oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
            dtFormaPago = FiltrarFormasPago("FACI", dtFormaPago)
        End If

        'If oFactura.CodTipoVenta = "K" AndAlso oNotaCredito.SALESDOCUMENT.Trim() <> "" Then
        '    dtFormaPago = FiltrarFormasPago("TFON", dtFormaPago)
        '    dtFormaPago = FiltrarFormasPago("FONA", dtFormaPago)
        'End If
        cmbFormaPago.DataSource = dtFormaPago
        cmbFormaPago.Refresh()
        cmbFormaPago.Value = "EFEC"


    End Sub

    Private Sub FillTipoTarjeta()

        dsTipoTarjeta = oCatalogoTipoTarjetaMgr.GetAll(False)
        ebTipoTarjeta.DataSource = dsTipoTarjeta.Tables(0)
        ebTipoTarjeta.DropDownList.Columns.Add("Tipo")
        ebTipoTarjeta.DropDownList.Columns.Add("Descripcion")
        ebTipoTarjeta.DropDownList.Columns("Tipo").DataMember = "CodTipoTarjeta"
        ebTipoTarjeta.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        ebTipoTarjeta.DropDownList.Columns("Tipo").Width = 50
        ebTipoTarjeta.DropDownList.Columns("Descripcion").Width = 150
        ebTipoTarjeta.DisplayMember = "CodTipoTarjeta"
        ebTipoTarjeta.ValueMember = "CodTipoTarjeta"
        ebTipoTarjeta.Refresh()

    End Sub

    Private Sub FillBancos()
        Dim dtBanco As DataTable = Nothing
        dsBanco = oCatalogoBancoMgr.GetAll(False)
        dtBanco = dsBanco.Tables(0)
        dtBanco = FiltrarTerminal("T1", dtBanco)
        dtBanco = FiltrarTerminal("T2", dtBanco)
        ebCodBanco.DataSource = dtBanco
        ebCodBanco.DropDownList.Columns.Add("Cod. Banco")
        ebCodBanco.DropDownList.Columns.Add("Descripcion")
        ebCodBanco.DropDownList.Columns("Cod. Banco").DataMember = "CodBanco"
        ebCodBanco.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        ebCodBanco.DropDownList.Columns("Cod. Banco").Width = 50
        ebCodBanco.DropDownList.Columns("Descripcion").Width = 150
        ebCodBanco.DisplayMember = "CodBanco"
        ebCodBanco.ValueMember = "CodBanco"
        ebCodBanco.Refresh()

    End Sub

    Private Sub FillBancoPromociones(ByVal Bin As Integer, ByVal Importe As Decimal)

        dtPromociones = oCatalogoPromoMgr.GetAllByBin(Bin, Importe)
        Me.cmbPromocion.DataSource = dtPromociones
        'Me.cmbPromocion.DropDownList.Columns.Add("CodPromo")
        'Me.cmbPromocion.DropDownList.Columns.Add("Descripcion")
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        'Me.cmbPromocion.DropDownList.Columns("CodPromo").Width = 50
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150
        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()

    End Sub

    Private Sub FillDataMovimiento(ByVal intApartado As Integer)

        With oFacturaCorrida.Movimiento
            .ClearFieldsMovimiento()
            .Mov_CodTipoMov = 201
            .Mov_TipoMovimiento = "S"
            .Mov_Status = "A"
            .Mov_Apartados = intApartado
            .Mov_CodAlmacen = oFactura.CodAlmacen
            .Mov_Destino = oFactura.ClienteId
            .Mov_Folio = oFactura.FolioFactura
            .Mov_CodArticulo = oArticulo.CodArticulo
            .Mov_Descripcion = oArticulo.Descripcion
            .Mov_CodLinea = oArticulo.Codlinea
            .Mov_CodMarca = oArticulo.CodMarca
            .Mov_CodFamilia = oArticulo.CodFamilia
            .Mov_CodUnidad = oArticulo.CodUnidadVta
            .Mov_CodUso = oArticulo.CodUso
            .Mov_CodCategoria = oArticulo.CodCategoria
            .Mov_CostoUnit = oArticulo.CostoProm
            .Mov_PrecioUnit = oFacturaCorrida.PrecioUnitario
            .Mov_FolioControl = ""
            .Mov_CodCaja = oFactura.CodCaja

        End With

    End Sub

#End Region

#Region "Agregar Pagos"

    Private Sub AgregaPagoEfectivo()

        Dim i As Integer
        Dim nReg As Integer = dsFormasPago.Tables(0).Rows.Count - 1
        If nReg >= 0 Then

            For i = 0 To nReg

                If dsFormasPago.Tables(0).Rows(i).Item("CodFormasPago") = "EFEC" Then

                    dsFormasPago.Tables(0).Rows(i).Item("MontoPago") = dsFormasPago.Tables(0).Rows(i).Item("MontoPago") + EBPago.Value

                    ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

                    If ebTotalPagoCliente.Value > ebImporteTotal.Value Then

                        ebCambioCliente.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value

                    End If

                    Exit Sub

                End If

            Next

        End If

        Dim drEfectivoRow As DataRow
        drEfectivoRow = dsFormasPago.Tables(0).NewRow

        With drEfectivoRow

            .Item("DPValeID") = 0
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drEfectivoRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

            If ebTotalPagoCliente.Value > ebImporteTotal.Value Then

                ebCambioCliente.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value

            End If

        End With

        drEfectivoRow = Nothing

    End Sub

    Private Sub AgregaPagoTarjeta()

        Dim drTarjetaRow As DataRow
        drTarjetaRow = dsFormasPago.Tables(0).NewRow

        With drTarjetaRow

            'Se agrega el Ticket "mHTicket"
            If bolCargoEHub = True Then
                .Item("DPValeID") = oAppSAPConfig.Ticket - 1
                bolCargoEHub = False
            Else
                .Item("DPValeID") = 0
            End If
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = ebCodBanco.Value
            .Item("CodTipoTarjeta") = ebTipoTarjeta.Value
            .Item("NumeroTarjeta") = ebNumTarj.Text
            .Item("NumeroAutorizacion") = ebAutorizacion.Text
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = EBPagoCom.Value
            .Item("IngresoComision") = Decimal.Round(EBPagoCom.Value / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            .Item("IvaComision") = .Item("ComisionBancaria") - .Item("IngresoComision")
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value
            .Item("NoAfiliacion") = strNoAfiliacion
            .Item("Id_Num_Promo") = Me.intPromo

            dsFormasPago.Tables(0).Rows.Add(drTarjetaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drTarjetaRow = Nothing

    End Sub


    Private Sub AgregaPagoAnticipoCliente()

        Dim drAnticipoRow As DataRow
        drAnticipoRow = dsFormasPago.Tables(0).NewRow

        With drAnticipoRow
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            If Not oVC.ValeCajaID > 0 Then
                .Item("DPValeID") = oValeCaja.ValeCajaID
                .Item("MontoPago") = EBPago.Value
                .Item("CodFormasPago") = cmbFormaPago.Value
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value
            Else
                .Item("DPValeID") = oVC.ValeCajaID
                .Item("MontoPago") = oVC.Importe
                .Item("CodFormasPago") = "VCJA"
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + oVC.Importe
            End If


            dsFormasPago.Tables(0).Rows.Add(drAnticipoRow)

            gridFormaPago.Refresh()
            '----------------------------------------------------------------------------------------------------------------------------------------------------
            'Actualizamos el temporal de vales de caja
            '----------------------------------------------------------------------------------------------------------------------------------------------------
            If dtValeCaja Is Nothing Then
                CreateDataValeCaja()
            End If
            Dim rRow As DataRow
            rRow = dtValeCaja.NewRow
            If Not oVC.ValeCajaID > 0 Then
                rRow("ValeCajaID") = oValeCaja.ValeCajaID
                rRow("MontoValeCaja") = oValeCaja.Importe
                rRow("MontoUtilizado") = EBPago.Value
                rRow("ClienteSAPID") = strClienteSAPValeCaja
                rRow("FolioFISAPDev") = strFolioFIValeCaja
                rRow("FolioFISAPVta") = strFolioFIVta
                dtValeCaja.Rows.Add(rRow)
                rRow = Nothing
            Else
                rRow("ValeCajaID") = oVC.ValeCajaID
                rRow("MontoValeCaja") = oVC.Importe
                rRow("MontoUtilizado") = oVC.Importe
                rRow("ClienteSAPID") = strClienteSAPValeCaja
                rRow("FolioFISAPDev") = strFolioFIValeCaja
                rRow("FolioFISAPVta") = strFolioFIVta
                dtValeCaja.Rows.Add(rRow)
                rRow = Nothing
            End If
            strFolioFIValeCaja = ""
            strClienteSAPValeCaja = ""
            strFolioFIVta = ""
            '/****************

        End With

        drAnticipoRow = Nothing

        If Not oVC.ValeCajaID > 0 Then
            'cmbFormaPago.Enabled = False
            'EBPago.Enabled = False
        Else
            If Not oFactura.Total = oVC.Importe Then
                cmbFormaPago.Enabled = True
                EBPago.Enabled = True
                EBPago.Value = oFactura.Total - oVC.Importe
                FillFormaPagoDEVFACFON("P")
            Else
                cmbFormaPago.Enabled = False
                EBPago.Enabled = False
            End If

        End If

    End Sub

    Private Sub AgregaPagoDPVale(ByVal vDPValeID As String, ByVal vClientedelAsociado As String, _
                                    ByVal vFechaDelAsociado As Date, ByVal vAsociadoID As Integer, _
                                    ByVal vClienteAsociadoID As Integer)
        StrFolioDPVale = vDPValeID
        'intFolioDPVale = vDPValeID

        'Agregamos Forma de Pago DPVale
        Dim drDPValeRow As DataRow
        drDPValeRow = dsFormasPago.Tables(0).NewRow

        With drDPValeRow

            .Item("DPValeID") = vDPValeID
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drDPValeRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drDPValeRow = Nothing

        'Agregamos Datos del DPvale al Temporal
        Dim drValidaDPValeRow As DataRow
        drValidaDPValeRow = dtDPVale.NewRow

        With drValidaDPValeRow

            .Item("DPValeID") = vDPValeID
            .Item("MontoDPVale") = EBPago.Value
            .Item("ClienteAsociado") = vClientedelAsociado
            .Item("FechaExpedicionAsociado") = vFechaDelAsociado
            .Item("AsociadoID") = vAsociadoID
            .Item("ClienteAsociadoID") = vClienteAsociadoID

            If oAppSAPConfig.DPValeSAP Then
                .Item("CodigoSAP") = vAsociadoID
            Else
                .Item("CodigoSAP") = GetCodigoSAPASociado(vAsociadoID)
            End If

            dtDPVale.Rows.Add(drValidaDPValeRow)

        End With

        drValidaDPValeRow = Nothing

        cmbFormaPago.Value = "EFEC"
        cmbFormaPago.Enabled = True

    End Sub

    Private Sub AgregaPagoDPValeNC()

        'Agregamos Forma de Pago DPVale
        Dim drDPValeRow As DataRow
        drDPValeRow = dsFormasPago.Tables(0).NewRow

        With drDPValeRow

            '.Item("DPValeID") = owsDPValeInfo.DPValeID
            .Item("DPValeID") = oDpvaleSAP.IDDPVale
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = oDevolucionDPValeInfo.NotaCreditoID
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drDPValeRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

            decMontoCobranza = EBPago.Value

        End With

        drDPValeRow = Nothing

        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then
            cmbFormaPago.Enabled = True
            EBPago.Enabled = True
        End If

    End Sub

    Private Sub AgregaPagoCredito()

        Dim drCreditoRow As DataRow
        drCreditoRow = dsFormasPago.Tables(0).NewRow

        With drCreditoRow

            .Item("DPValeID") = 0
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value

            dsFormasPago.Tables(0).Rows.Add(drCreditoRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drCreditoRow = Nothing

        cmbFormaPago.Enabled = False
        boolEsCredito = True
    End Sub

    Private Sub AgregaPagoFonacot(ByVal strNumAuto As String)

        Dim drFonacotRow As DataRow
        drFonacotRow = dsFormasPago.Tables(0).NewRow

        With drFonacotRow

            If Not oVC.ValeCajaID > 0 Then
                If Me.ebTipoTarjeta.Value = "TE" Then
                    .Item("DPValeID") = oAppSAPConfig.Ticket - 1
                Else
                    .Item("DPValeID") = 0
                End If
                .Item("MontoPago") = EBPago.Value
                .Item("CodFormasPago") = cmbFormaPago.Value
            Else
                .Item("DPValeID") = oVC.ValeCajaID
                .Item("MontoPago") = oVC.Importe
                .Item("CodFormasPago") = "VCJA"
            End If

            If Me.ebTipoTarjeta.Value = "TE" Then
                .Item("CodBanco") = "T1"
                .Item("CodTipoTarjeta") = "TE"
                .Item("NumeroTarjeta") = ebNumTarj.Text
                .Item("NumeroAutorizacion") = strNumAuto
                .Item("NotaCreditoID") = 0
                .Item("ComisionBancaria") = EBPagoCom.Value
                .Item("IngresoComision") = Decimal.Round(EBPagoCom.Value / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                .Item("IvaComision") = .Item("ComisionBancaria") - .Item("IngresoComision")
                .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
                .Item("NoAfiliacion") = strNoAfiliacion
            Else
                .Item("CodBanco") = String.Empty
                .Item("CodTipoTarjeta") = String.Empty
                .Item("NumeroTarjeta") = String.Empty
                .Item("NumeroAutorizacion") = strNumAuto
                .Item("NotaCreditoID") = 0
                .Item("ComisionBancaria") = 0
                .Item("IngresoComision") = 0
                .Item("IvaComision") = 0
                .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            End If

            If Not oVC.ValeCajaID > 0 Then
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value
            Else
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + oVC.Importe
            End If

            dsFormasPago.Tables(0).Rows.Add(drFonacotRow)

            gridFormaPago.Refresh()

        End With

        Me.ebTipoTarjeta.Value = ""
        Me.ebNumTarj.Text = ""
        Me.ebNumTarj.Text = ""

        drFonacotRow = Nothing

        If Not oVC.ValeCajaID > 0 Then
            If ebTotalPagoCliente.Value >= ebImporteTotal.Value Then

                cmbFormaPago.Enabled = False
                EBPago.Enabled = False

            Else

                cmbFormaPago.Value = "EFEC"
                cmbFormaPago.Enabled = True
                EBPago.Enabled = True

            End If
        Else
            If Not oFactura.Total = oVC.Importe Then
                cmbFormaPago.Enabled = True
                EBPago.Enabled = True
                FillFormaPagoDEVFACFON("P")
            Else
                cmbFormaPago.Enabled = False
                EBPago.Enabled = False
            End If

        End If




    End Sub

    Private Sub AgregaPagoLiquidacion()

        Dim drLiquidaRow As DataRow
        drLiquidaRow = dsFormasPago.Tables(0).NewRow

        With drLiquidaRow

            .Item("DPValeID") = 0
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = ebImporteTotal.Value

            dsFormasPago.Tables(0).Rows.Add(drLiquidaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebImporteTotal.Value

        End With

        drLiquidaRow = Nothing

        cmbFormaPago.Enabled = False
        EBPago.Enabled = False

    End Sub

    Private Sub AgregaPagoFacilito()

        Dim drFacilRow As DataRow
        drFacilRow = dsFormasPago.Tables(0).NewRow

        With drFacilRow
            If Not oVC.ValeCajaID > 0 Then
                .Item("DPValeID") = 0
                .Item("MontoPago") = EBPago.Value
                .Item("CodFormasPago") = cmbFormaPago.Value
            Else
                .Item("DPValeID") = oVC.ValeCajaID
                .Item("MontoPago") = oVC.Importe
                .Item("CodFormasPago") = "VCJA"
            End If


            .Item("CodBanco") = String.Empty
            .Item("CodTipoTarjeta") = String.Empty
            .Item("NumeroTarjeta") = String.Empty
            .Item("NumeroAutorizacion") = String.Empty
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = 0
            .Item("IngresoComision") = 0
            .Item("IvaComision") = 0
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper


            'Variable de Deuda Facilito
            If Not oVC.ValeCajaID > 0 Then
                decDeudaFacilito = decDeudaFacilito + EBPago.Value
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value
            Else
                decDeudaFacilito = decDeudaFacilito + oVC.Importe
                ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + oVC.Importe
            End If


            dsFormasPago.Tables(0).Rows.Add(drFacilRow)

            gridFormaPago.Refresh()



        End With

        drFacilRow = Nothing
        If Not oVC.ValeCajaID > 0 Then
            cmbFormaPago.Enabled = False
            EBPago.Enabled = False
        Else
            If Not oFactura.Total = oVC.Importe Then
                cmbFormaPago.Enabled = True
                EBPago.Enabled = True
                FillFormaPagoDEVFACFON("P")
            Else
                cmbFormaPago.Enabled = False
                EBPago.Enabled = False
            End If

        End If
    End Sub

    Private Function GetCodigoSAPASociado(ByVal AsociadoID As Integer) As String

        'im oWsSAP As New wsSAP.CreditoSAP
        Dim oResult As String = String.Empty

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'oWsSAP.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'oWsSAP.strUrl.TrimStart("/")
        End If

        'oResult = oWsSAP.GetDistribuidorSAP(AsociadoID)

        'oWsSAP.Dispose()

        'oWsSAP = Nothing

        Return oResult

    End Function


#End Region

#Region "Guardar Factura"

    Public Sub SaveFactura()

        Me.Cursor = Cursors.WaitCursor
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 10/06/2013: Se obtiene la fecha del servidor SAP, para no guardar con la fecha local de la pc
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Dim FechaSAP As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME


        If GuardarFactura(FechaSAP) Then
            'guardamos los motivos de captura manual

            If GuardarFacturaCorrida(FechaSAP) Then

                If GuardarFormadePago(FechaSAP) Then

                    'Actualizamos DPVale
                    If oFactura.CodTipoVenta = "V" Then

                        If Not oAppSAPConfig.DPValeSAP Then
                            ActualizaDPVale()
                            'If Not EsInstanciaNC Then   'Es una factura nueva por lo tanto tenemos que meterle su FI
                            GuardaFIDocumentWS() 'Guardamos FIDocument de la venta DPVale
                            'End If

                        Else

                            ActualizaDPValeSAP()

                        End If
                        '-----------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 09.06.2015: Se comento porque ahora se obtienen los datos del seguro antes de guardar la factura en SAP
                        '-----------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (12.02.2015): Si es Revale, no hacemos nada del seguro
                        '-----------------------------------------------------------------------------------
                        'DatosTicketSeguro.Clear()
                        'If Not Me.oDpvaleSAP.IsRevale AndAlso Not Me.oDpvaleSAP.IsReRevale Then
                        '    '-----------------------------------------------------------------------------------
                        '    ' JNAVA (12.02.2015): Preparamos los datos para el ticket de Seguro
                        '    '---------------------------------------------------------------------------------------------------------------
                        '    'RGERMAIN 14.05.2015: Validamos que realmente se haya generado el seguro de vida en SAP para obtener los datos
                        '    '---------------------------------------------------------------------------------------------------------------
                        '    If oConfigCierreFI.GenerarSeguro AndAlso oFactura.SeguroVidaSAPDPVL Then
                        '        '-----------------------------------------------------------------------------------
                        '        ' Obtenemos los datos del seguro
                        '        '-----------------------------------------------------------------------------------
                        '        DatosTicketSeguro = PrepararDatosTicket(Me.oDpvaleSAP.IDCliente, Me.oDpvaleSAP.NUMDE, Me.oDpvaleSAP.FechaCobro, oFactura.CodTipoVenta)
                        '        If DatosTicketSeguro Is Nothing OrElse DatosTicketSeguro.Count <= 0 Then
                        '            MessageBox.Show("Ocurrio un error al obtener los datos del Financiamiento del Seguro." & vbCrLf & "No existe la configuracion de seguros de vida para esta plaza.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '            EscribeLog("No existe la configuracion de seguros de vida para la plaza " & oAppSAPConfig.Plaza.Trim, "Ocurrio un error al obtener los datos del Financiamiento del seguro de vida")
                        '        End If
                        '    End If
                        'End If
                    End If

                    'Insertamos Vale de Descuento Utilizado
                    'If vCodTipoDescuento = "DVD" Then           'HACK: @ngulo - Verificar el manejo de Vales de Descuento en SAP
                    '    'Quemar Vales de Descuento Empleado
                    '    Dim strStatusVale, strPorcentaje As String
                    '    QuemaValeEmpleadoSAP(oValeDescuentoLocalInfo.FolioVale, strStatusVale, strPorcentaje)
                    'End If

                    'Actualizamos Vales de Caja
                    If Not (dtValeCaja Is Nothing) Then
                        ActualizaValeCaja()
                        'If Not oVC.ValeCajaID > 0 Then
                        '    MsgBox("Se Imprimirá Factura ponga el papel correspondiente por Favor. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")
                        'End If

                    End If

                    If boolLaImprimo = True Then

                        If oFactura.Impresa = True Then
                            ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                        Else
                        End If

                        Me.Cursor = Cursors.Default
                        'MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

                    End If


                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("ERROR. Forma de Pago no se guardó. ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

                End If

            Else

                Me.Cursor = Cursors.Default
                MsgBox("ERROR. Corrida y Forma de Pago no se guardaron. ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

            End If

        Else

            Me.Cursor = Cursors.Default
            MsgBox("ERROR. La Factura no ha sido guardada.   ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

        End If
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 08/03/2018: Se actualiza la factura cuando la acumulación procede de una activación.
        '------------------------------------------------------------------------------------------------
        If Activacion Then
            oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, DatosPuntoFactura)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    'Private Sub QuemaValeEmpleadoSAP(ByVal strVale As String, ByRef strStatusVale As String, ByRef strPorcentaje As String)
    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        'Parametros Exports
    '        Dim NUMVA As SAPFunctionsOCX.Parameter          '   Fichero local para upload/download
    '        'Fin Parametros Exports

    '        'Parametros Imports
    '        Dim STATU As SAPFunctionsOCX.Parameter           '   Indicador de una posición
    '        Dim PORCENTAJE As SAPFunctionsOCX.Parameter           '   Indicador de una posición
    '        'Fin parametros Imports

    '        With objR3.Connection
    '            .ApplicationServer = oAppSAPConfig.ApplicationServer
    '            .GroupName = oAppSAPConfig.GroupName
    '            .System = oAppSAPConfig.System
    '            .Client = oAppSAPConfig.Client
    '            .User = oAppSAPConfig.User
    '            .Password = oAppSAPConfig.Password
    '            .language = oAppSAPConfig.Language
    '            .SystemNumber = oAppSAPConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        End If

    '        objFunc = objR3.Add("ZBAPI_QUEMARVALEDESCTO")

    '        'Exports
    '        NUMVA = objFunc.Exports("NUMVA")
    '        'Fin Exports


    '        'Imports
    '        STATU = objFunc.Imports("STATU")
    '        PORCENTAJE = objFunc.Imports("PORCENTAJE")
    '        'Fin Imports

    '        'Captura de Info
    '        NUMVA.Value = strVale.PadLeft(10, "0")
    '        Dim bolStatus As Boolean
    '        bolStatus = objFunc.Call()

    '        If STATU.Value = String.Empty Then
    '            MsgBox("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema." & bolStatus)
    '            'Throw New ApplicationException("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema.")
    '        Else

    '            strStatusVale = STATU.Value
    '            strPorcentaje = PORCENTAJE.Value

    '        End If

    '        objR3.Connection.LogOff()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try


    'End Sub

    Private Sub GuardaFIDocumentWS()

        'Dim oWsSAP As New wsSAP.CreditoSAP

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
        '    oWsSAP.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    oWsSAP.strUrl.TrimStart("/")
        'End If

        'oWsSAP.SaveFIDocument(oFactura.CodAlmacen, oFactura.CodCaja, oFactura.FolioFactura, oFactura.FolioFISAP)

        'oWsSAP.Dispose()

        'oWsSAP = Nothing

    End Sub

    Private Function GuardarFactura(ByVal FechaSAP As DateTime) As Boolean

        GuardarFactura = False

        'If dsFormasPago.Tables(0).Rows(0).Item("CodFormasPago") = "C" Then
        '    oFactura.CodTipoVenta = "C"
        'End If

        If Me.boolEsCredito Then
            oFactura.Saldo = Me.oFactura.Total
        Else
            oFactura.Saldo = 0
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 10/06/2013: Se guarda con la fecha del servidor SAP
        '--------------------------------------------------------------------------------------------------------------------------------------
        oFactura.Fecha = FechaSAP
        oFacturaMgr.Save(oFactura)
        If oFactura.FacturaID > 0 Then
            If EsInstanciaApartado Then
                'Marcamos el Apartado como Entregado
                oFacturaMgr.UPdateApartadoEntregado(oFactura.ApartadoID)
            End If

            If Not oFactura.dtMotivos Is Nothing Then
                For Each orow As DataRow In oFactura.dtMotivos.Rows
                    oFacturaMgr.SaveMotivo(oFactura.FacturaID, orow("Tienda"), orow("Articulo"), orow("Talla"), orow("IdMotivo"), "VTA")
                Next
            End If
            '-----------------------------------------------------------------------------------------------------------------------
            'Guardamos el vale de empleado utilizado en la factura en caso que existiera
            '-----------------------------------------------------------------------------------------------------------------------
            If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                oFacturaMgr.SaveValeEmpleado(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, oFactura.FacturaID)
            End If
            '-----------------------------------------------------------------------------------------------------------------------
            'Guardamos el cupon de descuento utilizado en la factura en caso de llevar
            '-----------------------------------------------------------------------------------------------------------------------
            If Not oCuponDesc Is Nothing Then
                oFacturaMgr.SaveCuponDescuento(oCuponDesc.Folio, oFactura.FacturaID)
            End If

            Return True
        End If

    End Function

    Private Function AgruparCodigos(ByVal dtDetTemp As DataTable) As DataTable

        Dim dtDetAgrup As DataTable = dtDetTemp.Copy
        Dim oNewRow As DataRow
        Dim Codigos As String = ""
        Dim Cant As Integer = 0
        Dim Total As Decimal = 0
        Dim TotalDesc As Decimal = 0
        Dim odtView As DataView

        dtDetAgrup.Clear()

        For Each oRow As DataRow In dtDetTemp.Rows

            If InStr(Codigos, CStr(oRow!Codigo & oRow!Talla).ToUpper) <= 0 Then

                Codigos &= CStr(oRow!Codigo & oRow!Talla).ToUpper & ","
                odtView = New DataView(dtDetTemp, "Codigo='" & oRow!Codigo & " and Talla='" & oRow!Talla & "'", "Codigo", DataViewRowState.CurrentRows)

                TotalDesc = 0
                For Each oRowV As DataRowView In odtView
                    TotalDesc += oRowV!Total + oRowV!Descuento * (oRowV!Adicional / 100)
                Next

                Cant = dtDetTemp.Compute("Sum(Cantidad)", "Codigo = '" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'")
                Total = dtDetTemp.Compute("Sum(Total)", "Codigo = '" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'")

                oNewRow = dtDetAgrup.NewRow
                With oNewRow
                    !Codigo = oRow!Codigo
                    !Talla = oRow!Talla
                    !Cantidad = Cant
                    !Importe = oRow!Importe
                    !Total = oRow!Total
                    !Descuento = oRow!Descuento
                    !Adicional = (TotalDesc * 100) / Total
                    !Checado = oRow!Checado
                    !UsadoPromo = oRow!UsadoPromo
                End With
                dtDetAgrup.Rows.Add(oNewRow)

            End If

        Next
        dtDetAgrup.AcceptChanges()

        Return dtDetAgrup

    End Function

    Private Function GuardarFacturaCorrida(ByVal FechaSAP As DateTime) As Boolean

        GuardarFacturaCorrida = False

        If oFactura.FacturaID > 0 Then

            'Grabamos Factura Corrida

            Dim nReg As Integer, nFil As Integer

            nReg = oFactura.Detalle.Tables(0).Rows.Count - 1

            For nFil = 0 To nReg

                With oFactura.Detalle.Tables(0).Rows(nFil)

                    If .Item("Codigo") <> "" And .Item("Cantidad") > 0 And .Item("Importe") > 0 Then

                        oArticulo.ClearFields()

                        oCatalogoArticuloMgr.LoadInto(.Item("Codigo"), oArticulo)

                        oFacturaCorrida.Clearfields()

                        'Asignamos Campos Corrida
                        oFacturaCorrida.FacturaID = oFactura.FacturaID
                        oFacturaCorrida.CodArticulo = .Item("Codigo")
                        oFacturaCorrida.Cantidad = .Item("Cantidad")
                        oFacturaCorrida.Numero = .Item("Talla")
                        oFacturaCorrida.CostoUnitario = oArticulo.CostoProm
                        oFacturaCorrida.PrecioUnitario = .Item("Importe")
                        oFacturaCorrida.PrecioOferta = oArticulo.PrecioOferta
                        oFacturaCorrida.Total = .Item("Total")

                        '--CodTipoDescuento (DMA, DPO, DPE, etc) y Descuento sera el Adicional
                        If .Item("Adicional") > 0 Then

                            'oFacturaCorrida.CodTipoDescuento = vCodTipoDescuento
                            oFacturaCorrida.CodTipoDescuento = .Item("Condicion")
                        Else
                            oFacturaCorrida.CodTipoDescuento = ""
                        End If
                        oFacturaCorrida.Descuento = .Item("Adicional")

                        '--DescuentoSistema y CantDescuentoSistema se cargan con la Condicion De Venta SAP / o con DPesos
                        '--oFacturaCorrida.DescuentoSistema = oArticulo.Descuento
                        '--oFacturaCorrida.CantDescuentoSistema = Decimal.Round((oArticulo.Descuento / 100) * oArticulo.PrecioVenta, 2)
                        oFacturaCorrida.DescuentoSistema = CondicionVenta_Porcentaje()
                        oFacturaCorrida.CantDescuentoSistema = .Item("Descuento")

                        '--------------------------------------------------------------------------------------------------------------------------------------------------
                        'JNAVA (05.12.2014): Obtenemos el Numero de Serie e IMEI de los Electronicos (si se facturaron electronicos)
                        '--------------------------------------------------------------------------------------------------------------------------------------------------
                        ObtenerCorridaElectronicos(.Item("Codigo"), oFacturaCorrida.NumeroSerie, oFacturaCorrida.IMEI)

                        'oFacturaCorridaMgr.Save(oFacturaCorrida)
                        '-----------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 06/06/2013: Guardamos con la fecha obtenida del servidor SAP
                        '-----------------------------------------------------------------------------------------------------------------------
                        oFacturaCorrida.Fecha = FechaSAP

                        Dim valido As Boolean = oFacturaCorridaMgr.Save(oFacturaCorrida)
                        If valido = False Then
                            Return False
                        End If

                        'Guardamos Movimiento del Articulo
                        If EsInstanciaApartado Then
                            FillDataMovimiento((.Item("Cantidad") * -1))    'HACK: @ngulo Verificar si esta linea no produce negativos
                        Else
                            FillDataMovimiento(0)
                        End If

                        Dim oRow As DataRow
                        Dim tMontoNC As Decimal = 0, tCostNC As Decimal = 0
                        Dim dsMultU As DataSet, drMultU As DataRow
                        tMontoNC = 0
                        tCostNC = 0
                        For Each oRow In dsFormasPago.Tables(0).Rows
                            'Si la Forma de Pago es Vale de Caja
                            If oRow!CodFormasPago = "VCJA" Then
                                tMontoNC = tMontoNC + oRow!MontoPago
                                dsMultU = oFacturaCorridaMgr.CostNC(oRow!DPValeID)
                                For Each drMultU In dsMultU.Tables(0).Rows
                                    If Not IsDBNull(drMultU!CostNC) Then
                                        tCostNC = tCostNC + drMultU!CostNC
                                    End If
                                Next
                                dsMultU = Nothing
                            End If
                        Next

                        tMontoNC = tMontoNC / (1 + oAppContext.ApplicationConfiguration.IVA)
                        oFacturaCorridaMgr.SaveMovimiento(oFactura.Total, oFacturaCorrida, tMontoNC, tCostNC)

                    End If

                End With

            Next

            Return True

        End If

    End Function

    Private Function CondicionVenta_Porcentaje() As Decimal

        Dim oResult As Decimal
        Dim oCventa As New CondicionesVtaSAP

        With oCventa
            If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                GoTo Cambio_053
                ' .OficinaVtas = "C053"
            Else
Cambio_053:
                .OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
            End If
            '.OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
            .Jerarquia = oArticulo.Jerarquia
            .CondMat = oArticulo.CodMarca
            .CondPrec = strCondicionVenta
            .Material = oArticulo.CodArticulo
            .ListPrec = strListaPrecios
        End With

        oFacturaMgr.GetCondicionVenta(oCventa)

        oResult = oCventa.DescPorcentaje

        oCventa = Nothing

        Return oResult

    End Function

    Private Sub ActualizaCambioCliente()

        For Each Orow As DataRow In dsFormasPago.Tables(0).Rows
            If Orow!CodFormasPago = "EFEC" Then
                If (ebTotalPagoCliente.Value > ebImporteTotal.Value) And _
                    (ebTotalPagoCliente.Value - ebImporteTotal.Value) < Orow!MontoPago Then
                    ebCambioCliente.Value = ebTotalPagoCliente.Value - ebImporteTotal.Value
                End If
            End If
        Next

    End Sub

    Private Function GuardarFormadePago(ByVal FechaSAP As DateTime) As Boolean

        GuardarFormadePago = False

        If oFactura.FacturaID > 0 Then

            'Grabamos Factura Forma de Pago

            Dim nReg As Integer, nFil As Integer
            Dim tMontoCredito As Decimal
            tMontoCredito = 0

            nReg = dsFormasPago.Tables(0).Rows.Count - 1

            For nFil = 0 To nReg

                With dsFormasPago.Tables(0).Rows(nFil)

                    oFacturaFormaPago.ClearFields()

                    If .Item("CodFormasPago") = "EFEC" And ebCambioCliente.Value > 0 Then
                        .Item("MontoPago") = .Item("MontoPago") - ebCambioCliente.Value
                        ebTotalPagoCliente.Value = ebTotalPagoCliente.Value - ebCambioCliente.Value
                    End If

                    'Asignamos Campos Forma de Pago
                    oFacturaFormaPago.FacturaID = oFactura.FacturaID
                    oFacturaFormaPago.DPValeID = .Item("DPValeID")
                    oFacturaFormaPago.FormaPagoID = .Item("CodFormasPago")
                    oFacturaFormaPago.BancoID = .Item("CodBanco")
                    oFacturaFormaPago.TipoTarjetaID = .Item("CodTipoTarjeta")
                    oFacturaFormaPago.NumeroTarjeta = .Item("NumeroTarjeta")
                    oFacturaFormaPago.NumeroAutorización = .Item("NumeroAutorizacion")
                    oFacturaFormaPago.NotaCreditoID = .Item("NotaCreditoID")
                    oFacturaFormaPago.ComisionBancaria = .Item("ComisionBancaria")
                    oFacturaFormaPago.IngresoComision = .Item("IngresoComision")
                    oFacturaFormaPago.IVAComision = .Item("IVAComision")
                    oFacturaFormaPago.Monto = .Item("MontoPago")
                    oFacturaFormaPago.NoAfiliacion = .Item("NoAfiliacion")
                    oFacturaFormaPago.Promocion = .Item("Id_Num_Promo")

                    '-----------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 06/06/2013: Guardamos con la fecha obtenida del servidor SAP
                    '-----------------------------------------------------------------------------------------------------------------------
                    oFacturaFormaPago.RecordCreatedOn = FechaSAP


                    oFacturaFormaPago.Save()

                    'Si la Forma de Pago es Credito (C)
                    'If .Item("CodFormasPago") = "CRED" Then
                    '    tMontoCredito = tMontoCredito + .Item("MontoPago")
                    'End If

                End With

            Next

            'If tMontoCredito > 0 Then

            '    oPagoCreditoDirectoInfo = Nothing
            '    oPagoCreditoDirectoInfo = New wsPagosCreditoDirecto.PagosCreditoDirectoInfo
            '    oPagoCreditoDirectoInfo.CreditoEnTiendaID = OCreditoEnTiendaInfo.CreditoEnTiendaID
            '    oPagoCreditoDirectoInfo.AsociadoID = OCreditoEnTiendaInfo.AsociadoID
            '    oPagoCreditoDirectoInfo.ClienteID = OCreditoEnTiendaInfo.ClienteID
            '    oPagoCreditoDirectoInfo.CodAlmacen = oFactura.CodAlmacen
            '    oPagoCreditoDirectoInfo.CodCaja = oFactura.CodCaja
            '    oPagoCreditoDirectoInfo.FolioFactura = oFactura.FolioFactura
            '    oPagoCreditoDirectoInfo.FechaFactura = oFactura.Fecha
            '    oPagoCreditoDirectoInfo.RelacionAbonos = String.Empty
            '    oPagoCreditoDirectoInfo.FechaLimitePago = DateAdd(DateInterval.Day, OCreditoEnTiendaInfo.Plazo, oFactura.Fecha)
            '    oPagoCreditoDirectoInfo.PagoEstablecido = tMontoCredito
            '    oPagoCreditoDirectoInfo.Saldo = tMontoCredito
            '    oPagoCreditoDirectoInfo.SaldoAnterior = 0
            '    oPagoCreditoDirectoInfo.SaldoVencido = 0
            '    oPagoCreditoDirectoInfo.DescuentoProntoPago = 0
            '    oPagoCreditoDirectoInfo.RecargoMoroso = "0"
            '    oPagoCreditoDirectoInfo.Usuario = oAppContext.Security.CurrentUser.Name
            '    oPagoCreditoDirectoInfo.Fecha = Date.Now
            '    oPagoCreditoDirectoInfo.Player = oFactura.CodVendedor

            '    oPagoCreditoDirecto.CreatePagoCreditoDirecto(oPagoCreditoDirectoInfo)

            '    'Guardamos El movimiento del Asociado
            '    'Objeto EstadoCuentaAsociadoWS
            '    owsEstadoCuentaAsociado = New wsEstadoCuentaAsociado.EstadodeCuentaAsociado

            '    If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            '        owsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            '                    owsEstadoCuentaAsociado.strURL.TrimStart("/")
            '    End If

            '    owsMovimientoInfo2 = New wsEstadoCuentaAsociado.MovimientosInfo

            '    owsMovimientoInfo2.FechaMovimiento = oFactura.Fecha
            '    owsMovimientoInfo2.CodigoAlmacen = oFactura.CodAlmacen
            '    owsMovimientoInfo2.CodigoCaja = oFactura.CodCaja
            '    owsMovimientoInfo2.FolioMovimiento = oFactura.FolioFactura
            '    owsMovimientoInfo2.TipoDocumento = "FACTURA"
            '    owsMovimientoInfo2.Usuario = oAppContext.Security.CurrentUser.Name
            '    owsMovimientoInfo2.StatusRegistro = 1
            '    owsMovimientoInfo2.Cargo = tMontoCredito
            '    owsMovimientoInfo2.Abono = 0
            '    owsMovimientoInfo2.AsociadoID = OCreditoEnTiendaInfo.AsociadoID
            '    owsMovimientoInfo2.Año = CInt(Format(oFactura.Fecha, "yyyy"))
            '    owsMovimientoInfo2.Mes = CInt(Format(oFactura.Fecha, "MM"))

            '    owsEstadoCuentaAsociado.InsertMovimiento("C", owsMovimientoInfo2)

            'End If

            Return True

        End If

    End Function

    Private Sub ActualizaDPVale()

        Dim iFil As Integer
        Dim tMontoDPvale As Decimal
        Dim vAsociadoID As Integer = 0
        Dim DPValeInfo As New DevolucionDPValeInfo()

        tMontoDPvale = 0

        If (Not dtDPVale Is Nothing) AndAlso EsInstanciaNC = False Then

            If dtDPVale.Rows.Count > 0 Then

                For iFil = 0 To (dtDPVale.Rows.Count - 1)

                    owsDPvaleFacturaInfo = New ControlDPValesWS.DPValeFacturaInfo

                    With owsDPvaleFacturaInfo

                        .DPValeID = dtDPVale.Rows(iFil).Item("DPValeID")
                        .FechaEntregado = dtDPVale.Rows(iFil).Item("FechaExpedicionAsociado")
                        .ClienteAsociado = dtDPVale.Rows(iFil).Item("ClienteAsociado")
                        .Monto = dtDPVale.Rows(iFil).Item("MontoDPVale")
                        .AsociadoID = dtDPVale.Rows(iFil).Item("AsociadoID")
                        .ClienteAsociadoID = dtDPVale.Rows(iFil).Item("ClienteAsociadoID")
                        .MontoCobranza = dtDPVale.Rows(iFil).Item("MontoDPVale")
                        .Almacen = oAppContext.ApplicationConfiguration.Almacen
                        .FacturaID = oFactura.FacturaID
                        '----------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                        '----------------------------------------------------------------------------------------------------------------------------------
                        '.FechaFactura = Now
                        .FechaFactura = FechaSAP
                        .CodigoCaja = oFactura.CodCaja
                        .FolioFactura = oFactura.FolioFactura

                        If Me.vSobrante > 0 Then

                            If Not Me.bPares Then
                                .ParesPzas = 0
                            Else
                                .ParesPzas = oFactura.Detalle.Tables(0).Compute("sum(Cantidad)", "cantidad>0")
                            End If
                        Else
                            .ParesPzas = 0
                        End If

                        .MontoDPValeI = owsDPValeInfo.MontoDPValeI
                        .MontoDPValeP = owsDPValeInfo.MontoDPValeP

                    End With

                    'Se Inserta o Actualiza la Factura en OPERACIONES-------
                    'owsValidaDPVale.UpdateDataFactura(owsDPvaleFacturaInfo)
                    '-------------------------------------------------------

                    vAsociadoID = dtDPVale.Rows(iFil).Item("AsociadoID")

                    tMontoDPvale = tMontoDPvale + dtDPVale.Rows(iFil).Item("MontoDPVale")

                    '''''''''''Nuevo
                    If tMontoDPvale > 0 Then

                        'owsMovimientoInfo = New wsEstadoCuentaAsociado.MovimientosInfo
                        owsMovimientoInfo = New ControlDPValesWS.MovimientosInfo
                        owsMovimientoInfo.FechaMovimiento = oFactura.Fecha
                        owsMovimientoInfo.CodigoAlmacen = oFactura.CodAlmacen
                        owsMovimientoInfo.CodigoCaja = oFactura.CodCaja
                        owsMovimientoInfo.FolioMovimiento = oFactura.FolioFactura
                        owsMovimientoInfo.TipoDocumento = "FACTURA"
                        owsMovimientoInfo.Usuario = oAppContext.Security.CurrentUser.Name
                        owsMovimientoInfo.StatusRegistro = 1
                        owsMovimientoInfo.Cargo = tMontoDPvale
                        owsMovimientoInfo.Abono = 0
                        owsMovimientoInfo.AsociadoID = vAsociadoID
                        owsMovimientoInfo.Año = CInt(Format(oFactura.Fecha, "yyyy"))
                        owsMovimientoInfo.Mes = CInt(Format(oFactura.Fecha, "MM"))

                        ''Se agrega la Plaza y el periodo en el que se realizó la factura.
                        owsMovimientoInfo.Referencia = 0
                        owsMovimientoInfo.Plaza = GetPlaza()


                    End If
                    '''''''''''Fin Nuevo

                    '''Verificamos si sobra dinero para revale y si este se puede imprimir
                    If Me.vSobrante > 0 And bImpRevale Then
                        DPValeInfo.DPValeID = 0
                        DPValeInfo.ClienteAsociado = owsDPvaleFacturaInfo.ClienteAsociado
                        DPValeInfo.StatusRegistro = 1
                        DPValeInfo.AsociadoID = owsDPvaleFacturaInfo.AsociadoID
                        DPValeInfo.ClienteAsociadoID = owsDPvaleFacturaInfo.ClienteAsociadoID
                        DPValeInfo.Fecha = FechaSAP
                        With owsDPValeInfo

                            .DPValeID = 0
                            .ClienteAsociado = owsDPvaleFacturaInfo.ClienteAsociado
                            .StatusRegistro = 1
                            .AsociadoID = owsDPvaleFacturaInfo.AsociadoID
                            .ClienteAsociadoID = owsDPvaleFacturaInfo.ClienteAsociadoID
                            '--------------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '--------------------------------------------------------------------------------------------------------------------------------
                            '.Fecha = Now
                            .Fecha = FechaSAP

                        End With

                        If Not Me.bPares Then
                            MessageBox.Show("Se generará un revale porla cantidad de " & Format(Me.vSobrante, "c"), "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            DPValeInfo.MontoDPValeI = vSobrante
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = owsValidaDPVale.VentaDPValeCR(owsDPvaleFacturaInfo, owsDPValeInfo, owsMovimientoInfo)
                            owsDPValeInfo.MontoDPValeI = vSobrante
                            owsDPValeInfo.MontoDPValeP = 0
                            owsDPValeInfo.DPValeID = owsValidaDPVale.VentaDPValeCR(owsDPvaleFacturaInfo, owsDPValeInfo, owsMovimientoInfo)
                            PrintRevale(DPValeInfo, String.Empty, Nothing)

                        Else

                            MessageBox.Show("Se generará un revale porla cantidad de " & Me.vSobrante & " Pares Pzas.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            DPValeInfo.MontoDPValeP = vSobrante
                            DPValeInfo.MontoDPValeI = 0
                            DPValeInfo.DPValeID = owsValidaDPVale.VentaDPValeCR(owsDPvaleFacturaInfo, owsDPValeInfo, owsMovimientoInfo)
                            owsDPValeInfo.MontoDPValeP = vSobrante
                            owsDPValeInfo.MontoDPValeI = 0

                            owsDPValeInfo.DPValeID = owsValidaDPVale.VentaDPValeCR(owsDPvaleFacturaInfo, owsDPValeInfo, owsMovimientoInfo)

                            Me.PrintRevalePares()


                        End If

                    Else

                        owsValidaDPVale.VentaDPValeSR(owsDPvaleFacturaInfo, owsMovimientoInfo)
                    End If


                Next

            End If

        End If

        If EsInstanciaNC = True Then
            'Actualizamos Nuevos Datos del DPVale
            owsDPvaleFacturaInfo = New ControlDPValesWS.DPValeFacturaInfo

            With owsDPvaleFacturaInfo
                .DPValeID = owsDPValeInfo.DPValeID
                .Almacen = oAppContext.ApplicationConfiguration.Almacen
                .FacturaID = oFactura.FacturaID
                .FechaEntregado = owsDPValeInfo.FechaExpedicion
                '--------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                '--------------------------------------------------------------------------------------------------------------------------------------
                '.FechaFactura = Now
                .FechaFactura = FechaSAP
                .ClienteAsociado = owsDPValeInfo.ClienteAsociado
                .Monto = owsDPValeInfo.MontoUtilizado
                .AsociadoID = owsDPValeInfo.AsociadoID
                .ClienteAsociadoID = owsDPValeInfo.ClienteAsociadoID
                .CodigoCaja = oFactura.CodCaja
                .FolioFactura = oFactura.FolioFactura
                .MontoCobranza = decMontoCobranza
            End With

            'owsValidaDPVale.UpdateDataFactura(owsDPvaleFacturaInfo)

            'owsDPvaleFacturaInfo = Nothing

            vAsociadoID = owsDPValeInfo.AsociadoID

            tMontoDPvale = oDevolucionDPValeInfo.MontoDPValeUtilizado

            If tMontoDPvale > 0 Then

                'Objeto EstadoCuentaAsociadoWS
                'owsEstadoCuentaAsociado = New wsEstadoCuentaAsociado.EstadodeCuentaAsociado
                Dim oPeriodoDetalleMgr As New PeriodoDetalleManager(oAppContext)

                If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

                    'owsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
                    '            owsEstadoCuentaAsociado.strURL.TrimStart("/")
                End If

                'owsMovimientoInfo = New wsEstadoCuentaAsociado.MovimientosInfo
                owsMovimientoInfo = New ControlDPValesWS.MovimientosInfo

                owsMovimientoInfo.FechaMovimiento = oFactura.Fecha
                owsMovimientoInfo.CodigoAlmacen = oFactura.CodAlmacen
                owsMovimientoInfo.CodigoCaja = oFactura.CodCaja
                owsMovimientoInfo.FolioMovimiento = oFactura.FolioFactura
                owsMovimientoInfo.TipoDocumento = "FACTURA"
                owsMovimientoInfo.Usuario = oAppContext.Security.CurrentUser.Name
                owsMovimientoInfo.StatusRegistro = 1
                owsMovimientoInfo.Cargo = tMontoDPvale
                owsMovimientoInfo.Abono = 0
                owsMovimientoInfo.AsociadoID = vAsociadoID
                owsMovimientoInfo.Año = CInt(Format(oFactura.Fecha, "yyyy"))
                owsMovimientoInfo.Mes = CInt(Format(oFactura.Fecha, "MM"))

                ''Se agrega la Plaza y el periodo en el que se realizó la factura.
                owsMovimientoInfo.Referencia = 0        'oPeriodoDetalleMgr.SelectPeriodoActual(oFactura.Fecha)
                owsMovimientoInfo.Plaza = GetPlaza()

                owsValidaDPVale.VentaDPValeSR(owsDPvaleFacturaInfo, owsMovimientoInfo)

            End If

        End If

    End Sub

    Private Sub ActualizaDPValeSAP()

        Dim iFil As Integer
        Dim tMontoDPvale As Decimal
        Dim vAsociadoID As Integer = 0
        Dim DPValeInfo As New DevolucionDPValeInfo()

        tMontoDPvale = 0

        If (Not dtDPVale Is Nothing) AndAlso EsInstanciaNC = False Then

            If dtDPVale.Rows.Count > 0 Then

                For iFil = 0 To (dtDPVale.Rows.Count - 1)

                    owsDPvaleFacturaInfo = New ControlDPValesWS.DPValeFacturaInfo

                    '--------------------------------------------------------------------
                    ' JNAVA (15.07.2016): Datos de Distribuidor de S2Credit
                    '--------------------------------------------------------------------
                    Dim FirmaDistribuidor As Image = Nothing
                    Dim NombreDistribuidor As String = String.Empty
                    '--------------------------------------------------------------------

                    With owsDPvaleFacturaInfo

                        Dim oDPVale As New cDPVale
                        oDPVale.INUMVA = oFactura.REVALE

                        If oFactura.REVALE = String.Empty OrElse CDec(oFactura.REVALE) = 0 Then
                            Exit For
                        End If

                        ''Cambiar por una ruta de configuración
                        'Dim oConURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
                        'oConURed.Conecta()

                        'If Not Directory.Exists(oConfigCierreFI.Ruta & "\Firmas") Then
                        '    Directory.CreateDirectory(oConfigCierreFI.Ruta & "\Firmas")
                        'End If

                        'oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & oFactura.REVALE.PadLeft(10, "0") & ".bmp"

                        'If File.Exists(oDPVale.I_RUTA) Then
                        '    oDPVale.I_RUTA = "X"
                        'End If
                        oDPVale.I_RUTA = "X"

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                        '----------------------------------------------------------------------------------------
                        'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                        ''-----------------------------------------------------
                        '' JNAVA (11.04.2016): Valida DPVale en S2Credit
                        ''-----------------------------------------------------
                        'BuscarValeS2Credit(oFactura.REVALE)

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (14.07.2016): Valida DPVale
                        '----------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                        Else
                            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                        End If
                        '----------------------------------------------------------------------------------

                        oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & oFactura.REVALE.PadLeft(10, "0") & ".bmp"

                        'oConURed.Desconecta()
                        'oConURed.Desconecta()

                        'No me acuerdo por que puse esta validacion
                        If Trim(oDPVale.INUMVA) = String.Empty Then
                            oDPVale.INUMVA = 0
                        Else
                            .DPValeID = CInt(oDPVale.INUMVA)
                        End If

                        If Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 1, 4) = "0000" Then
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-------------------------------------------------------------------------------------------------------------------------------
                            '.FechaEntregado = Now.Date
                            .FechaEntregado = FechaSAP
                        Else
                            .FechaEntregado = Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 7, 2) & "/" & Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 5, 2) & "/" & Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 1, 4)
                        End If

                        .Monto = CDec(oDPVale.InfoDPVALE.Rows(0)("MONTO"))
                        .AsociadoID = CStr(oDPVale.InfoDPVALE.Rows(0)("KUNNR"))
                        .ClienteAsociadoID = CStr(oDPVale.InfoDPVALE.Rows(0)("CODCT")).PadLeft(10, "0")

                        '-------------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (15.07.2016): Si esta activo S2Credit, obtenemos info del cliente de S2credit
                        '-------------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            Dim oClienteSAP As ClientesSAP
                            oClienteSAP = oS2Credit.ObtenerClientePorID(.ClienteAsociadoID)
                            .ClienteAsociado = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos
                            oClienteSAP = Nothing
                        Else
                            .ClienteAsociado = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(.ClienteAsociadoID))
                        End If

                        .MontoCobranza = CDec(oDPVale.InfoDPVALE.Rows(0)("MONTO"))
                        .Almacen = oAppContext.ApplicationConfiguration.Almacen
                        .FacturaID = oFactura.FacturaID
                        '--------------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                        '--------------------------------------------------------------------------------------------------------------------------------------
                        '.FechaFactura = Now
                        .FechaFactura = FechaSAP
                        .CodigoCaja = oFactura.CodCaja
                        .FolioFactura = oFactura.FolioFactura

                        If Me.vSobrante > 0 Then
                            If Not Me.bPares Then
                                .ParesPzas = 0
                            Else
                                .ParesPzas = oFactura.Detalle.Tables(0).Compute("sum(Cantidad)", "cantidad>0")
                            End If
                        Else
                            .ParesPzas = 0
                        End If
                        .MontoDPValeI = owsDPValeInfo.MontoDPValeI
                        .MontoDPValeP = owsDPValeInfo.MontoDPValeP

                    End With


                    vAsociadoID = owsDPvaleFacturaInfo.AsociadoID

                    tMontoDPvale = tMontoDPvale + owsDPvaleFacturaInfo.Monto

                    '''Verificamos si sobra dinero para revale y si este se puede imprimir
                    If Me.vSobrante > 0 And bImpRevale Then

                        With owsDPValeInfo
                            DPValeInfo.DPValeID = 0
                            DPValeInfo.ClienteAsociado = owsDPvaleFacturaInfo.ClienteAsociado
                            DPValeInfo.StatusRegistro = 1
                            DPValeInfo.ClienteAsociado = owsDPvaleFacturaInfo.ClienteAsociado
                            DPValeInfo.Fecha = FechaSAP

                            .DPValeID = 0
                            .ClienteAsociado = owsDPvaleFacturaInfo.ClienteAsociado

                            .StatusRegistro = 1
                            .AsociadoID = owsDPvaleFacturaInfo.AsociadoID
                            .ClienteAsociadoID = owsDPvaleFacturaInfo.ClienteAsociadoID
                            '-------------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                            '-------------------------------------------------------------------------------------------------------------------------------
                            '.Fecha = Now
                            .Fecha = FechaSAP

                        End With

                        If Not Me.bPares Then
                            MessageBox.Show("Se generará un revale por la cantidad de " & Format(Me.vSobrante, "c"), "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            DPValeInfo.MontoDPValeI = vSobrante
                            DPValeInfo.MontoDPValeP = 0
                            DPValeInfo.DPValeID = owsDPvaleFacturaInfo.DPValeID

                            owsDPValeInfo.MontoDPValeI = vSobrante
                            owsDPValeInfo.MontoDPValeP = 0
                            owsDPValeInfo.DPValeID = owsDPvaleFacturaInfo.DPValeID
                            PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)

                        Else

                            MessageBox.Show("Se generará un revale por la cantidad de " & Me.vSobrante & " Pares Pzas.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            DPValeInfo.MontoDPValeP = vSobrante
                            DPValeInfo.MontoDPValeI = 0
                            DPValeInfo.DPValeID = owsDPvaleFacturaInfo.DPValeID

                            owsDPValeInfo.MontoDPValeP = vSobrante
                            owsDPValeInfo.MontoDPValeI = 0
                            owsDPValeInfo.DPValeID = owsDPvaleFacturaInfo.DPValeID

                            Me.PrintRevalePares()

                        End If

                    Else
                        'NO hace nada
                    End If


                Next

            End If

        End If

        If EsInstanciaNC = True Then

            'Actualizamos Nuevos Datos del DPVale ver si se necesita

            owsDPvaleFacturaInfo = New ControlDPValesWS.DPValeFacturaInfo

            With owsDPvaleFacturaInfo
                .DPValeID = owsDPValeInfo.DPValeID
                .Almacen = oAppContext.ApplicationConfiguration.Almacen
                .FacturaID = oFactura.FacturaID
                .FechaEntregado = owsDPValeInfo.FechaExpedicion
                '--------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 17.05.2014: Cambiamos por fecha actual del servidor de SAP en lugar de la fecha local
                '--------------------------------------------------------------------------------------------------------------------------------------
                .FechaFactura = FechaSAP
                '.FechaFactura = Now
                .ClienteAsociado = owsDPValeInfo.ClienteAsociado
                .Monto = owsDPValeInfo.MontoUtilizado
                .AsociadoID = owsDPValeInfo.AsociadoID
                .ClienteAsociadoID = owsDPValeInfo.ClienteAsociadoID
                .CodigoCaja = oFactura.CodCaja
                .FolioFactura = oFactura.FolioFactura
                .MontoCobranza = decMontoCobranza
            End With
            vAsociadoID = owsDPValeInfo.AsociadoID
            tMontoDPvale = oDevolucionDPValeInfo.MontoDPValeUtilizado

        End If
    End Sub

    Private Function GetPlaza() As String
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Return oAlmacen.PlazaID
            End If
        End If

    End Function


#End Region

#Region "Validaciones"

    Private Sub cmbFormaPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaPago.ValueChanged
        Dim bDPPT As Boolean = False

        '----------------------------------------------------------------------------------------
        'MLVARGAS 11/05/2018: Validar que solo se ingrese una vez la forma de pago DPCard Puntos
        '----------------------------------------------------------------------------------------
        If cmbFormaPago.Value <> "" Then
            If cmbFormaPago.Value = "DPPT" Then
                For Each row As DataRow In dsFormasPago.Tables(0).Rows
                    Dim pago As String = row("CodFormasPago")
                    If pago = "DPPT" Then
                        bDPPT = True
                        Exit For
                    End If
                Next

                If bDPPT Then
                    MsgBox("No se puede agregar dos formas de DPPuntos", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Dportenis PRO")
                    cmbFormaPago.Value = "EFEC"
                End If
            End If
        End If

        If ebImporteTotal.Value > ebTotalPagoCliente.Value Then
            EBPago.Value = ebImporteTotal.Value - ebTotalPagoCliente.Value
        Else
            EBPago.Value = 0
        End If

        '-------------------------------------------------------------------
        'JNAVA (12.03.2015): Dejamos deshabilitado para que no tecleen tarjetas
        '------------------------------------------------------------------
        Me.ebNumTarj.ReadOnly = True

        Select Case cmbFormaPago.Value

            Case "EFEC"    'Efectivo
                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

                Me.ebNumTarj.ReadOnly = True

            Case "TACR", "TADB" 'Tarjeta Crédito ó Débito
                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Value = "TE"
                ebTipoTarjeta.ReadOnly = False
                ebTipoTarjeta.Enabled = True
                ebCodBanco.Value = dsBanco.Tables(0).Rows(2).Item(0)
                'FillBancoPromociones(dsBanco.Tables(0).Rows(0)!IDEmisor)
                ebCodBanco.Enabled = True
                ebNumTarj.Enabled = True
                ebAutorizacion.Enabled = True
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = True

            Case "VCJA"    'Anticipo Cliente
                If Not oVC.ValeCajaID > 0 Then
                    Label2.Text = "Monto a Pagar       :"
                    ebFolioValeCaja.Enabled = True
                Else
                    Label2.Text = "Monto a Pagar       :"
                    ebFolioValeCaja.Enabled = False
                    Me.ebFolioValeCaja.Text = oVC.ValeCajaID
                    Me.EBPago.Text = oVC.Importe
                End If
                Me.cmbFormaPago.Enabled = True
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Enabled = False
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case "CRED"    'Credito

                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Enabled = False
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case "DPVL"    'DPVale

                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case "FACI"    'Facilito

                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Value = oFactura.Total - ebTotalPagoCliente.Value
                EBPago.Enabled = False
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case "FONA", "TFON"    'Fonacot

                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                ebTipoTarjeta.Enabled = False
                ebCodBanco.Enabled = False
                ebNumTarj.Enabled = False
                ebAutorizacion.Enabled = False
                EBPago.Value = oFactura.Total - ebTotalPagoCliente.Value
                EBPago.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

                '---------------------------------------------------------------
                'JNAVA (26.01.2015): Forma de pago de DP Card
                '---------------------------------------------------------------
            Case "DPCA"    'DP Card

                'Deshabilitamos controles
                Me.Label2.Text = "Monto a Pagar       :"
                Me.ebFolioValeCaja.Enabled = False
                Me.ebFolioValeCaja.Value = ""

                '---------------------------------------------------------------
                'JNAVA (26.02.2015): Ponemos Por default el tipo de tarjeta TE
                '---------------------------------------------------------------
                Me.ebTipoTarjeta.Value = "TE"
                Me.ebTipoTarjeta.ReadOnly = True
                Me.ebTipoTarjeta.Enabled = False
                Dim drView As DataRowView
                drView = Me.ebTipoTarjeta.SelectedItem
                Me.EBTarjeta.Text = drView.Item(1)

                'ebCodBanco.Value = dsBanco.Tables(0).Rows(0).Item(0)
                'FillBancoPromociones(dsBanco.Tables(0).Rows(0)!IDEmisor)
                Me.ebCodBanco.Value = ""
                Me.ebCodBanco.Enabled = False

                'Habilitamos nlo necesario
                Me.ebNumTarj.Enabled = True

                '-------------------------------------------------------------------
                'JNAVA (12.03.2015): Dejamos habilitado para que tecleen el DP Card
                '------------------------------------------------------------------
                Me.ebNumTarj.ReadOnly = False

                Me.ebAutorizacion.Enabled = False
                Me.EBPago.Enabled = True
                Me.cmbPromocion.Enabled = True
                Me.btnLeerTarjeta.Enabled = True
            Case "DPPT"

                'Deshabilitamos controles
                Me.Label2.Text = "Monto a Pagar       :"
                Me.ebFolioValeCaja.Enabled = False
                Me.ebFolioValeCaja.Value = ""

                '---------------------------------------------------------------
                'FLIZARRAGA 16/04/2015: Ponemos Por default el tipo de tarjeta TE
                '---------------------------------------------------------------
                Me.ebTipoTarjeta.Value = "TE"
                Me.ebTipoTarjeta.ReadOnly = True
                Me.ebTipoTarjeta.Enabled = False
                Dim drView As DataRowView
                drView = Me.ebTipoTarjeta.SelectedItem
                Me.EBTarjeta.Text = drView.Item(1)

                'ebCodBanco.Value = dsBanco.Tables(0).Rows(0).Item(0)
                'FillBancoPromociones(dsBanco.Tables(0).Rows(0)!IDEmisor)
                Me.ebCodBanco.Value = ""
                Me.ebCodBanco.Enabled = False

                'Habilitamos nlo necesario
                Me.ebNumTarj.Enabled = True

                '-------------------------------------------------------------------
                'FLIZARRAGA 16/04/2015: Dejamos deshabilitado las tarjetas
                '-------------------------------------------------------------------
                Me.ebNumTarj.ReadOnly = True

                Me.ebAutorizacion.Enabled = False
                Me.EBPago.Enabled = False
                Me.cmbPromocion.Enabled = False
                Me.btnLeerTarjeta.Enabled = False

            Case Else

                Label2.Text = "Monto a Pagar       :"
                ebFolioValeCaja.Enabled = False
                EBPago.Enabled = True
                Me.btnLeerTarjeta.Enabled = False
                '-------------------------------------------------------------------
                'JNAVA (12.03.2015): Dejamos deshabilitado para que notecleen
                '------------------------------------------------------------------
                Me.ebNumTarj.ReadOnly = True

        End Select

    End Sub

    Private Sub ebTipoTarjeta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTipoTarjeta.Validating

        booleHub = False

        If ebTipoTarjeta.Value <> "" Then

            Dim drView As DataRowView
            drView = ebTipoTarjeta.SelectedItem

            EBTarjeta.Text = drView.Item(1)

            If drView.Item(0) = "TE" Then
                If oAppSAPConfig.eHub = True Then
                    booleHub = True
                End If
                Me.txtCVV2.Enabled = True
                Me.cmbPromocion.Enabled = False
                Me.ebAutorizacion.ReadOnly = True
                Me.ebAutorizacion.BackColor = Color.Ivory
            Else
                Me.txtCVV2.Enabled = False
                Me.cmbPromocion.Enabled = True
                Me.ebAutorizacion.ReadOnly = False
                Me.ebAutorizacion.BackColor = Color.White
            End If

            drView = Nothing

        Else

            EBTarjeta.Text = ""

        End If

    End Sub

    Private Sub ebCodBanco_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodBanco.Validating

        If ebCodBanco.Value <> "" Then

            Dim drView As DataRowView
            drView = ebCodBanco.SelectedItem

            EBBanco.Text = drView.Item(1)

            If Not oAppSAPConfig.eHub = True Then
                'Dim oForm As New frmFotosTerminal
                'oForm.ShowDialog()

                'If oForm.intResultForm = 1 Then
                '    ebCodBanco.Text = "T1"
                '    ebCodBanco.Value = "T1"
                '    EBBanco.Text = "BANCOMER"
                'ElseIf oForm.intResultForm = 2 Then
                '    ebCodBanco.Text = "T2"
                '    ebCodBanco.Value = "T2"
                '    EBBanco.Text = "SANTANDER"
                'ElseIf oForm.intResultForm = 3 Then
                '    ebCodBanco.Text = "T3"
                '    ebCodBanco.Value = "T3"
                '    EBBanco.Text = "BANAMEX"
                'End If

                'If MessageBox.Show("La Forma de Pago que se aplicara es para el banco: " & UCase(drView.Item(1)), "DPtienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

                'ebCodBanco.Focus()

                'End If

            End If
            If oConfigCierreFI.PagosBanamex = True Then
                GetPromocionesBanamex()
                cmbPromocion.Enabled = True
                ebNumTarj.Enabled = False
                btnLeerTarjeta.Enabled = False
                cmbPromocion.Focus()
            End If
            'If Me.ebTipoTarjeta.Value = "TM" Then
            '    FillBancoPromociones(CInt(drView!IDEmisor))
            '    Me.cmbPromocion.Text = ""
            'End If

            drView = Nothing

        Else

            EBBanco.Text = ""

        End If

    End Sub

    Private Sub cmbFormaPago_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbFormaPago.Validating

        If cmbFormaPago.Value <> "" Then
            If cmbFormaPago.Value = "DPVL" Then
                If EsInstanciaNC = True And Not (owsDPValeInfo Is Nothing) Then
                    If owsDPValeInfo.DPValeID <> 0 Then
                        MsgBox("La Forma de Pago DPVale ya ha sido agregada. Seleccione una distinta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
                        cmbFormaPago.Value = "EFEC"
                        e.Cancel = True
                    End If
                End If
                If intFolioDPVale > 0 Then
                    MsgBox("La Forma de Pago DPVale ya ha sido agregada. Seleccione una distinta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
                    cmbFormaPago.Value = "EFEC"
                    e.Cancel = True
                End If
            End If
            If cmbFormaPago.Value = "FONA" And dsFormasPago.Tables(0).Rows.Count > 0 Then
                MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
                cmbFormaPago.Value = "EFEC"
                e.Cancel = True
            End If
            'Prueba------------------------
            'If cmbFormaPago.Value = "TFON" And dsFormasPago.Tables(0).Rows.Count > 0 Then
            '    MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
            '    cmbFormaPago.Value = "EFEC"
            '    e.Cancel = True
            'End If
            '-------------------------------------------------------------------------------------------------------------------------------
            'Si la venta es de tarjeta fonacot no permitimos que elijan inicialmente ninguna forma de pago que no sea TFON o VCJA
            '-------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta.Trim = "K" AndAlso InStr("EFEC,TADB,TACR,DPCA,DPPT", cmbFormaPago.Value) > 0 AndAlso _
            dsFormasPago.Tables(0).Rows.Count = 0 Then
                MsgBox("No está permitido agregar esta forma de pago inicialmente en este tipo de venta.", MsgBoxStyle.Exclamation + _
                       MsgBoxStyle.OkOnly, "  Facturacion")
                cmbFormaPago.Value = "TFON"
                e.Cancel = True
            End If
            'Prueba------------------------
            If cmbFormaPago.Value = "CRED" And dsFormasPago.Tables(0).Rows.Count > 0 Then
                MsgBox("La Forma de Pago no es válida. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturacion")
                e.Cancel = True
            End If
            If cmbFormaPago.Value = "VCJA" Then
                If EBPago.Enabled Then
                    EBPago.Value = 0
                End If
            End If
        End If

    End Sub

    Private Function ValidaPagoEnTarjeta() As Boolean

        If EBPago.Value <= 0 Then

            MsgBox("Ingrese Monto a Pagar.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            EBPago.Focus()
            Return False

        End If

        If ebTipoTarjeta.Text = "" Then

            MsgBox("Ingrese Tipo de Tarjeta.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            ebTipoTarjeta.Focus()
            Return False

        End If

        If ebCodBanco.Text = "" Then

            MsgBox("Ingrese Código de Banco.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            ebCodBanco.Focus()
            Return False

        End If

        If ebNumTarj.Text = String.Empty Then

            MsgBox("Ingrese Número de Tarjeta.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            ebNumTarj.Focus()
            Return False

        End If

        If ebAutorizacion.Text = String.Empty Then

            MsgBox("Ingrese Número de Autorización.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            ebAutorizacion.Focus()
            Return False

        End If

        If Me.cmbPromocion.Text = String.Empty And Me.ebTipoTarjeta.Value = "TM" Then

            MsgBox("Seleccione la promoción utilizada.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Forma de Pago")
            Me.cmbPromocion.Focus()
            Return False

        End If

        Return True

    End Function

    Private Sub EBPago_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBPago.Validating

        Select Case cmbFormaPago.Value

            Case "TACR"

                EBPagoCom.Value = EBPago.Value * (oAppContext.ApplicationConfiguration.ComisionTarjetaCredito / 100)
                If (Me.EBPago.Value + Me.ebTotalPagoCliente.Value) > Me.ebImporteTotal.Value Then
                    MsgBox("Monto a pagar no puede ser mayor al Importe Total.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Facturación")
                    e.Cancel = True
                End If

            Case "TADB"

                EBPagoCom.Value = EBPago.Value * (oAppContext.ApplicationConfiguration.ComisionTarjetaDebito / 100)
                If (Me.EBPago.Value + Me.ebTotalPagoCliente.Value) > Me.ebImporteTotal.Value Then
                    MsgBox("Monto a pagar no puede ser mayor al Importe Total.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Facturación")
                    e.Cancel = True
                End If

            Case "DPVL", "CRED"

                If EBPago.Value > ebImporteTotal.Value Then

                    MsgBox("Monto a pagar no puede ser mayor al Importe Total.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Facturación")
                    e.Cancel = True

                End If

            Case Else

                EBPagoCom.Value = 0

        End Select

    End Sub




    Private Sub ebFolioValeCaja_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioValeCaja.Validating

        Dim dRow As DataRow

        If ebFolioValeCaja.Value >= 0 Then
            '----------------------------------------------------------------------------------------------------------------------------------------
            'Revisamos el vale de caja en la BD Local SQL
            '----------------------------------------------------------------------------------------------------------------------------------------
            oValeCaja = oValeCajaMgr.GetByFolioDocumento(Me.ebFolioValeCaja.Value)
            'EBPago.Value = oValeCaja.Importe

            '----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 16.07.2013: Revisamos si el vale de caja no se encontro con el folio SAP del documento, entonces lo buscamos con el folio id DPPRO 
            'o si se encontro pero es de tipo CP o PI lo igualamos a nothing porque el folio SAP de esos vales de caja se repite y es necesario buscarlos
            'con el id del dppro
            '----------------------------------------------------------------------------------------------------------------------------------------
            If oValeCaja Is Nothing Then
                oValeCaja = oValeCajaMgr.Load(Me.ebFolioValeCaja.Value)
                'ElseIf InStr("PI,CP", oValeCaja.TipoDocumento.Trim.ToUpper) > 0 Then
                '    oValeCaja = Nothing
            End If

            If Not (oValeCaja Is Nothing) Then
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Verificamos si el Vale ya se agregó
                '----------------------------------------------------------------------------------------------------------------------------------------
                If dsFormasPago.Tables(0).Rows.Count > 0 Then
                    For Each dRow In dsFormasPago.Tables(0).Rows
                        'If dRow!CodFormasPago = "VCJA" And dRow!DPValeID = ebFolioValeCaja.Value Then
                        If dRow!CodFormasPago = "VCJA" AndAlso dRow!DPValeID = oValeCaja.ValeCajaID Then
                            MsgBox("El Vale de Caja " & Format(ebFolioValeCaja.Value, "000000") & " ya fue agregado. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Facturación")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos el vale da caja en SAP
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Dim result As New Dictionary(Of String, Object)
                'If oValeCaja.TipoDocumento = "CP" OrElse oValeCaja.TipoDocumento = "PI" OrElse oValeCaja.TipoDocumento = "CF" Then
                '    strFolioFIValeCaja = oValeCaja.FolioFISAP
                '    RestService.Metodo = "/pos/ventas"
                '    result = RestService.SapZdpproClienteDev("", oValeCaja.FolioDocumento)
                '    If result.ContainsKey("E_KUNNR") = False Then
                '        strClienteSAPValeCaja = CStr(result("E_KUNNR"))
                '    Else
                '        MessageBox.Show("Cliente no existente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    End If
                '    strClienteSAPValeCaja = oSAPMgr.ZBAPI_VALIDACLIENTEVALECAJA("", oValeCaja.FolioDocumento)
                'Else
                '    strFolioFIValeCaja = oValeCajaMgr.GetFolioFI(oValeCaja.TipoDocumento, oValeCaja.FolioDocumento, strFolioFIVta)
                '    RestService.Metodo = "/pos/ventas"
                '    result = RestService.SapZdpproClienteDev("", oValeCaja.FolioDocumento)
                '    If result.ContainsKey("E_KUNNR") = True Then
                '        strClienteSAPValeCaja = CStr(result("E_KUNNR"))
                '    Else
                '        MessageBox.Show("Cliente no existente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    End If

                '    strClienteSAPValeCaja = oSAPMgr.ZBAPI_VALIDACLIENTEVALECAJA("", oValeCaja.FolioDocumento)
                'End If

                'If strClienteSAPValeCaja.Trim = "" Then GoTo NoExiste
                'oValeCaja = oValeCajaMgr.Load(ebFolioValeCaja.Value)
                'Else
                '    oValeCaja = oValeCajaMgr.GetByFolioDocumento(strFolioVale)
                'End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                'Validamos Vale de Caja
                '----------------------------------------------------------------------------------------------------------------------------------------
                If oValeCaja.MontoUtilizado > 0 Then

                    'MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " ya fue utilizado. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Facturación")
                    MsgBox("El Vale de Caja " & oValeCaja.FolioDocumento.Trim.PadLeft(10, "0") & " ya fue utilizado. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Facturación")
                    Me.ebFolioValeCaja.Value = 0
                    e.Cancel = True

                Else

                    If oValeCaja.StastusRegistro = False Then

                        'MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " está deshabilitado. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Facturación")
                        MsgBox("El Vale de Caja " & oValeCaja.FolioDocumento.Trim.PadLeft(10, "0") & " está deshabilitado. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Facturación")
                        Me.ebFolioValeCaja.Value = 0
                        e.Cancel = True

                    ElseIf Date.Today.Subtract(oValeCaja.Fecha).Days > 45 Then

                        'MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " ya expiró", MsgBoxStyle.Exclamation, "Facturación")
                        MsgBox("El Vale de Caja " & oValeCaja.FolioDocumento.Trim.PadLeft(10, "0") & " ya expiró", MsgBoxStyle.Exclamation, "Facturación")
                        Me.ebFolioValeCaja.Value = 0
                        e.Cancel = True

                        'ElseIf ValidarClienteFacturaValeCaja(strClienteSAPValeCaja) = False Then
                        '    Me.ebFolioValeCaja.Value = 0
                        '    e.Cancel = True

                    Else
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        'Validamos si sobrepasamos el Total de la Deuda
                        '---------------------------------------------------------------------------------------------------------------------------------------------------
                        If (ebTotalPagoCliente.Value + oValeCaja.Importe) > oFactura.Total Then

                            'EBPago.Value = oFactura.Total - ebTotalPagoCliente.Value
                            MessageBox.Show("El importe a pagar debe ser mayor o igual al importe del vale de caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebFolioValeCaja.Value = 0
                            e.Cancel = True

                        Else

                            EBPago.Value = oValeCaja.Importe

                        End If

                    End If

                End If

            Else
NoExiste:
                MsgBox("Folio del Vale de Caja no existe. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Facturación")
                Me.ebFolioValeCaja.Value = 0
                e.Cancel = True

            End If

        End If

        'Me.ebFolioValeCaja.ReadOnly = True

    End Sub

    Private Function FacturaIsSaved() As Boolean

        Dim oFacturaTempo As Factura
        oFacturaTempo = oFacturaMgr.Create
        oFacturaTempo.ClearFields()

        oFacturaMgr.Load(oFactura.FolioFactura, oFactura.CodCaja, oFacturaTempo)

        If oFacturaTempo Is Nothing Then

            oFacturaTempo = Nothing

            Return False

        Else

            If oFacturaTempo.FacturaID > 0 Then

                Return True

            Else

                Return False

            End If

        End If

    End Function

#End Region

#Region "Print Methods"

    Public Sub ActionPreview(ByVal FacturaID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean, _
                             Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, _
                             Optional ByVal bReimpresion As Boolean = False, Optional ByVal bCopia As Boolean = True, _
                             Optional ByVal bRecibidoPor As Boolean = False)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        If oFacturaMgr Is Nothing Then
            oFacturaMgr = New FacturaManager(oAppContext)
            If oFactura Is Nothing Then
                oFactura = oFacturaMgr.Create
                oFacturaMgr.LoadInto(FacturaID, oFactura)
                'oFacturaMgr.Load(FacturaID, oAppContext.ApplicationConfiguration.NoCaja, oFactura)
            End If
        Else
            If oFactura Is Nothing Then
                oFactura = oFacturaMgr.Create
                oFacturaMgr.LoadInto(FacturaID, oFactura)
            End If
        End If
        With orptDataInfo
            .FacturaID = FacturaID
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = StrFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)

        Try
            'Validar que aparezca solo cuando el tipo de venta sea FONACOT
            'y que aparezca cuando sea la impresora HP
            If oConfigCierreFI.PrinterHP Then
                If TipoLeyenda = "" Then
                    If oFactura.CodTipoVenta = "F" Then
                        If Not oVC.ValeCajaID > 0 Then
                            If MessageBox.Show("¿Deseas imprimir HOJA FONACOT?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                Dim print_document As PrintDocument = PreparePrintDocument()
                                print_document.DocumentName = "HOJA FONACOT"
                                print_document.Print()
                            End If
                        End If

                    End If
                End If
            End If
            Dim result As Dictionary(Of String, Object) = GetMensajeDPTicket()
            Dim oARReporte As DataDynamics.ActiveReports.ActiveReport
            If oConfigCierreFI.MiniPrinter Then
                '-----------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 04/06/2013: Si se envia el parametro bRecibidoPor usamos el constructor del Si Hay, si no el normal
                '-----------------------------------------------------------------------------------------------------------------------------
                If bRecibidoPor Then

                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, bRecibidoPor, ImporteSeguro, result, FechaPrimerPago)
                Else
                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, ImporteSeguro, result, FechaPrimerPago)
                End If
                'Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                '                                         bReimpresion, bRecibidoPor)
                oARReporte.Document.Name = "Reporte Facturacion"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                Dim oARViewer As New ReportViewerForm

                'oARReporte.Run()

                oARReporte.Document.Print(False, False)


                'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)                

                'oARViewer.Report = oARReporte
                'oARViewer.Show()

            Else
                pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
            End If


            Dim msgReimpresion As String = String.Empty

            If bReimprir Or oFactura.CodTipoVenta = "V" Then
                msgReimpresion = "¿Desea imprimir todos los documentos de la factura?"
            Else
                msgReimpresion = "¿Desea volver a imprimir esta factura?"
            End If

            If bCopia AndAlso MessageBox.Show(msgReimpresion, " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                If oConfigCierreFI.MiniPrinter Then

                    'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)
                    'Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, "COPIA DE FACTURA", oConfigCierreFI.ImprimirCedula, "", _
                    '                                         strQuin, bReimpresion)
                    If bRecibidoPor Then
                        oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                            bReimpresion, bRecibidoPor, ImporteSeguro, result, FechaPrimerPago)
                    Else
                        oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                            bReimpresion, ImporteSeguro, result, FechaPrimerPago)
                    End If

                    oARReporte.Document.Name = "Reporte Facturacion"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    'oARReporte.Run()

                    oARReporte.Document.Print(False, False)


                    Dim oARViewer As New ReportViewerForm


                    'oarviewer.Report = oarreporte
                    'oarviewer.Show()

                    ReeimpresionBanamex(ObtenerFormasPagoByFacturaID(oFactura.FacturaID))


                Else
                    pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
                End If
            End If
            If TipoLeyenda = "" Then
                If oFactura.CodTipoVenta = "P" AndAlso oConfigCierreFI.UsarSccanerIFE = True Then
                    If MessageBox.Show("¿Desea capturar los datos del cliente?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Dim oForm As New frmClientes(pdtDetalles, pdtPagos, pdtGeneral, oAppContext.ApplicationConfiguration.Almacen)
                        oForm.ShowDialog()
                    End If
                End If
            End If


            orptDataInfo = Nothing

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa. Linea: " & Err.Erl, ex)

        End Try

    End Sub

    Public Sub ActionPreview2(ByVal FacturaID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean, Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        With orptDataInfo
            .FacturaID = FacturaID
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = intFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)

        Try
            If oFactura.CodTipoVenta = "P" AndAlso oConfigCierreFI.UsarSccanerIFE = True Then
                If MessageBox.Show("¿Desea capturar los datos del cliente?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    Dim oForm As New frmClientes(pdtDetalles, pdtPagos, pdtGeneral, oAppContext.ApplicationConfiguration.Almacen)
                    oForm.ShowDialog()
                End If
            End If

            orptDataInfo = Nothing

        Catch ex As Exception
            Throw New ApplicationException("Se produjó un error al mostrar formulario del cliente.", ex)
        End Try

    End Sub



    Public Sub ActionPreview3(ByVal FacturaID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean, _
                             Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, _
                             Optional ByVal bReimpresion As Boolean = False, Optional ByVal bCopia As Boolean = True, _
                             Optional ByVal bRecibidoPor As Boolean = False)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        If oFacturaMgr Is Nothing Then
            oFacturaMgr = New FacturaManager(oAppContext)
            If oFactura Is Nothing Then
                oFactura = oFacturaMgr.Create
                oFacturaMgr.Load(FacturaID, oAppContext.ApplicationConfiguration.NoCaja, oFactura)
            End If
        End If
        With orptDataInfo
            .FacturaID = FacturaID
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = StrFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)

        Try
            'Validar que aparezca solo cuando el tipo de venta sea FONACOT
            'y que aparezca cuando sea la impresora HP
            If oConfigCierreFI.PrinterHP Then
                If TipoLeyenda = "" Then
                    If oFactura.CodTipoVenta = "F" Then
                        If Not oVC.ValeCajaID > 0 Then
                            If MessageBox.Show("¿Deseas imprimir HOJA FONACOT?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                Dim print_document As PrintDocument = PreparePrintDocument()
                                print_document.DocumentName = "HOJA FONACOT"
                                print_document.Print()
                            End If
                        End If

                    End If
                End If
            End If
            Dim result As Dictionary(Of String, Object) = GetMensajeDPTicket()
            Dim oARReporte As DataDynamics.ActiveReports.ActiveReport
            If oConfigCierreFI.MiniPrinter Then
                '-----------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 04/06/2013: Si se envia el parametro bRecibidoPor usamos el constructor del Si Hay, si no el normal
                '-----------------------------------------------------------------------------------------------------------------------------
                If bRecibidoPor Then

                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, bRecibidoPor, ImporteSeguro, result, FechaPrimerPago)
                Else
                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, ImporteSeguro, result, FechaPrimerPago)
                End If
                'Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                '                                         bReimpresion, bRecibidoPor)
                oARReporte.Document.Name = "Reporte Facturacion"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                Dim oARViewer As New ReportViewerForm

                'oARReporte.Run()

                oARReporte.Document.Print(False, False)


                'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)                

                'oARViewer.Report = oARReporte
                'oARViewer.Show()

            Else
                pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
            End If

            ' If bCopia AndAlso MessageBox.Show("¿Desea volver a imprimir esta factura?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            If oConfigCierreFI.MiniPrinter Then

                'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)
                'Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, "COPIA DE FACTURA", oConfigCierreFI.ImprimirCedula, "", _
                '                                         strQuin, bReimpresion)
                If bRecibidoPor Then
                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, bRecibidoPor, ImporteSeguro, result, FechaPrimerPago)
                Else
                    oARReporte = New ReporteFacturacion(orptDataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                        bReimpresion, ImporteSeguro, result, FechaPrimerPago)
                End If

                oARReporte.Document.Name = "Reporte Facturacion"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                'oARReporte.Run()

                oARReporte.Document.Print(False, False)


                Dim oARViewer As New ReportViewerForm


                'oarviewer.Report = oarreporte
                'oarviewer.Show()

            Else
                pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
            End If
            ' End If
            If TipoLeyenda = "" Then
                If oFactura.CodTipoVenta = "P" AndAlso oConfigCierreFI.UsarSccanerIFE = True Then
                    If MessageBox.Show("¿Desea capturar los datos del cliente?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Dim oForm As New frmClientes(pdtDetalles, pdtPagos, pdtGeneral, oAppContext.ApplicationConfiguration.Almacen)
                        oForm.ShowDialog()
                    End If
                End If
            End If


            orptDataInfo = Nothing

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa. Linea: " & Err.Erl, ex)

        End Try

    End Sub



    ' Make and return a PrintDocument object that's ready
    ' to print the paragraphs.
    Private Function PreparePrintDocument() As PrintDocument
        ' Make the PrintDocument object.
        Dim print_document As New PrintDocument

        ' Install the PrintPage event handler.
        AddHandler print_document.PrintPage, AddressOf Print_PrintPage

        ' Return the object.
        Return print_document
    End Function

    ' Imprimir Forma de Fonacot.
    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim dsFormaPagoPrintPreview As New DataSet

        '--------------------------------------------
        Dim drawFont As New Font("TAHOMA", 9)
        Dim drawBrush As New SolidBrush(Color.Black)

        Dim drawStrFormaR As New StringFormat
        drawStrFormaR.Alignment = StringAlignment.Far

        Dim drawStrFormaL As New StringFormat
        drawStrFormaL.Alignment = StringAlignment.Near

        Dim drawStrFormaC As New StringFormat
        drawStrFormaC.Alignment = StringAlignment.Center

        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        '(X   ,Y  )
        '(LEFT,TOP)
        '-----------------------------------------------------------------------------
        'Capital
        e.Graphics.DrawString(Format(oFonacotRPT.Capital, "#,##0.00"), drawFont, drawBrush, 180, 73, drawStrFormaR)
        'Intereses
        e.Graphics.DrawString(Format(oFonacotRPT.Interes, "#,##0.00"), drawFont, drawBrush, 180, 77, drawStrFormaR)
        'Comision por Apertura
        e.Graphics.DrawString(Format(oFonacotRPT.Comision, "#,##0.00"), drawFont, drawBrush, 180, 86, drawStrFormaR)
        'Credito
        e.Graphics.DrawString(Format(oFonacotRPT.Credito, "#,##0.00"), drawFont, drawBrush, 180, 91, drawStrFormaR)
        'Pago Mensual
        e.Graphics.DrawString(Format(oFonacotRPT.PagoMensual, "#,##0.00"), drawFont, drawBrush, 180, 98, drawStrFormaR)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        'Identificacion Del Titular y Numero
        e.Graphics.DrawString(oFonacotRPT.Identificacion & "(" & oFonacotRPT.NumIdentificacion & ")", drawFont, drawBrush, 63, 109, drawStrFormaL)
        'Expedida Por
        e.Graphics.DrawString(oFonacotRPT.Expedidapor, drawFont, drawBrush, 116, 109, drawStrFormaL)
        'Fecha expedicion
        e.Graphics.DrawString(oFonacotRPT.AnioExpedicion, drawFont, drawBrush, 149, 109, drawStrFormaL)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        'Nombre o razon social del establecimiento
        e.Graphics.DrawString("COMERCIAL D'PORTENIS S.A. DE C.V.", drawFont, drawBrush, 78, 120, drawStrFormaC)
        'Numero FONACOT
        e.Graphics.DrawString("D00252921", drawFont, drawBrush, 175, 120, drawStrFormaC)
        '-----------------------------------------------------------------------------

        '------------------------SUCURSAL
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        '-------------------------SUCURSAL   

        '-----------------------------------------------------------------------------
        'DOMICILIO DE ENTREGA
        'e.Graphics.DrawString("DOMICILIO DE ENTREGA DE MERCANCIA", drawFont, drawBrush, 108, 129, drawStrFormaC)
        e.Graphics.DrawString(oAlmacen.DireccionCalle & " C.P." & oAlmacen.DireccionCP, drawFont, drawBrush, 108, 130, drawStrFormaC)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        'Nombre de quien recibe Mercancia
        e.Graphics.DrawString(pdtGeneralPrintPreview.Rows(0).Item("NombreCliente"), drawFont, drawBrush, 6, 140, drawStrFormaL)
        'Parentesco
        e.Graphics.DrawString("TITULAR", drawFont, drawBrush, 105, 140, drawStrFormaL)
        'fecha  
        e.Graphics.DrawString(UCase(Format(Date.Now, "dd-MMM-yyyy")), drawFont, drawBrush, 137, 140, drawStrFormaL)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        'Descripcion
        e.Graphics.DrawString("CALZADO", drawFont, drawBrush, 105, 154, drawStrFormaC)
        'Precio
        e.Graphics.DrawString(Format(CDec(pdtGeneralPrintPreview.Rows(0).Item("Total")), "$#,##0.00"), drawFont, drawBrush, 200, 154, drawStrFormaR)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        dsFormaPagoPrintPreview = oFacturaFormaPago.Load(oFactura.FacturaID)
        'Total
        e.Graphics.DrawString(Format(CDec(pdtGeneralPrintPreview.Rows(0).Item("Total")), "$#,##0.00"), drawFont, drawBrush, 200, 169, drawStrFormaR)
        'Contado
        '-->>>-------------------------PAGO EFEC TACR TACB
        'validar que no sea nulo
        Dim strEFE As String
        If IsDBNull(dsFormaPagoPrintPreview.Tables(0).Compute("sum(montopago)", "codFormasPago<>'FONA'")) Then
            strEFE = String.Empty
        Else
            strEFE = Format(CDec(dsFormaPagoPrintPreview.Tables(0).Compute("sum(montopago)", "codFormasPago<>'FONA'")), "$#,##0.00")
        End If
        e.Graphics.DrawString(strEFE, drawFont, drawBrush, 200, 174, drawStrFormaR)
        '-->>>-------------------------PAGO EFEC TACR TACB
        'Cred FONACOT
        e.Graphics.DrawString(Format(oFonacotRPT.Capital, "$#,##0.00"), drawFont, drawBrush, 200, 178, drawStrFormaR)
        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        'BUENO POR
        e.Graphics.DrawString(Format(oFonacotRPT.Credito, "$#,##0.00"), drawFont, drawBrush, 157, 205, drawStrFormaL)
        'BUENO POR LETRA
        e.Graphics.DrawString(Format(oFonacotRPT.Credito, "$#,##0.00"), drawFont, drawBrush, 40, 209, drawStrFormaL)
        'LETRA
        e.Graphics.DrawString(UCase(Letras(oFonacotRPT.Credito)), drawFont, drawBrush, 40, 216, drawStrFormaL)
        'LUGAR Y FECHA
        e.Graphics.DrawString(oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yyyy")), drawFont, drawBrush, 30, 259, drawStrFormaL)
        '-----------------------------------------------------------------------------

        oAlmacen = Nothing
        ' There are no more pages.
        e.HasMorePages = False
    End Sub

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & " pesos con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

#End Region

#Region "DataTemp"

    Private Sub CreateDataDPVale()

        dtDPVale = New DataTable("DPVale")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "DPValeID"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoDPVale"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "ClienteAsociado"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.DateTime")
        dCol.ColumnName = "FechaExpedicionAsociado"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "AsociadoID"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "ClienteAsociadoID"
        dtDPVale.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodigoSAP"
        dtDPVale.Columns.Add(dCol)


    End Sub

    Private Sub CreateDataFormaPago()

        dsFormasPago = New DataSet

        Dim dtFormaPago As New DataTable("FormasPago")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodFormasPago"
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodBanco"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodTipoTarjeta"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NumeroTarjeta"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NumeroAutorizacion"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "NotaCreditoID"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "ComisionBancaria"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "IngresoComision"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "IvaComision"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "DescripcionFormaPago"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoPago"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "DPValeID"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NoAfiliacion"
        dCol.DefaultValue = String.Empty
        dtFormaPago.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "Id_Num_Promo"
        dCol.DefaultValue = 0
        dtFormaPago.Columns.Add(dCol)

        If Not Me.dtFormasPago Is Nothing Then
            dtFormaPago = Me.dtFormasPago.Copy
        End If
        dsFormasPago.Tables.Add(dtFormaPago)

        gridFormaPago.DataSource = dsFormasPago.Tables(0)
        gridFormaPago.RetrieveStructure()
        gridFormaPago.RootTable.Columns(0).Visible = False
        gridFormaPago.RootTable.Columns(1).Visible = False
        gridFormaPago.RootTable.Columns(2).Visible = False
        gridFormaPago.RootTable.Columns(3).Visible = False
        gridFormaPago.RootTable.Columns(4).Visible = False
        gridFormaPago.RootTable.Columns(5).Visible = False
        gridFormaPago.RootTable.Columns(6).Visible = False
        gridFormaPago.RootTable.Columns(7).Visible = False
        gridFormaPago.RootTable.Columns(8).Visible = False
        gridFormaPago.RootTable.Columns(9).Width = 195
        gridFormaPago.RootTable.Columns(9).HeaderAlignment = TextAlignment.Center
        gridFormaPago.RootTable.Columns(9).Caption = "Forma de Pago"
        gridFormaPago.RootTable.Columns(10).Width = 100
        gridFormaPago.RootTable.Columns(10).HeaderAlignment = TextAlignment.Center
        gridFormaPago.RootTable.Columns(10).Caption = "Monto Total"
        gridFormaPago.RootTable.Columns(11).Visible = False
        gridFormaPago.RootTable.Columns(12).Visible = False
        gridFormaPago.RootTable.Columns(13).Visible = False

        Dim dtPagos As DataTable = dsFormasPago.Tables(0)
        Dim total As Decimal = 0

        If dtPagos.Rows.Count > 0 Then
            For Each oRow As DataRow In dtPagos.Rows
                total += oRow!MontoPago
            Next
        End If
        ebTotalPagoCliente.Value = total


    End Sub

    Private Sub CreateDataValeCaja()

        dtValeCaja = New DataTable("ValeCaja")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int32")
        dCol.ColumnName = "ValeCajaID"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoValeCaja"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "MontoUtilizado"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "ClienteSAPID"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFISAPDev"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFISAPVta"
        dtValeCaja.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FolioFITraslado"
        dCol.DefaultValue = ""
        dtValeCaja.Columns.Add(dCol)

    End Sub

#End Region

#Region "DPVale Methods"

    Private m_bitLogo As Bitmap

    Public Property Logo() As Bitmap
        Get
            Return m_bitLogo
        End Get
        Set(ByVal Value As Bitmap)
            m_bitLogo = Value
        End Set
    End Property

#Region "Print ReVale"

    Public Sub PrintRevale(ByVal owsDPValeInfo As DevolucionDPValeInfo, ByVal NombreDistribuidor As String, ByVal FirmaDistribuidor As Image, Optional ByVal MontoOriginal As Decimal = 0, Optional ByVal MontoVenta As Decimal = 0)

        If oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
            Me.PrintRevaleMoneyStandar()
            Exit Sub
        ElseIf Not ValidatingPrinter(oAppContext.ApplicationConfiguration.MiniPrintName) Then
            Me.PrintRevaleMoneyStandar()
            Exit Sub
        End If

        Try

            Dim oARReporte As New rptRevaleMiniPrinter(owsDPValeInfo, Me.vSobrante, NombreDistribuidor, FirmaDistribuidor, MontoOriginal, MontoVenta)

            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Impresión Revale"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
                '    oARReporte.Document.Printer.PrinterSettings.PrinterName = "SAMSUNG SRP-350"
                '    oARReporte.Document.Printer.PrinterName = "SAMSUNG SRP-350"
                'Else
                oARReporte.PageSettings.PaperHeight = 7
                oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.Print(False, False)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Catch ex As ApplicationException

            Me.PrintRevaleMoneyStandar()

        End Try
    End Sub

    Public Sub PrintRevalePares()

        If oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
            PrintRevaleParesStandar()
            Exit Sub
        ElseIf Not ValidatingPrinter(oAppContext.ApplicationConfiguration.MiniPrintName) Then
            PrintRevaleParesStandar()
            Exit Sub
        End If

        Try

            Dim oARReporte As New rptRevaleParesPzas(owsDPValeInfo, Me.vSobrante)
            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Impresión Revale"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
                '    oARReporte.Document.Printer.PrinterSettings.PrinterName = "SAMSUNG SRP-350"
                '    oARReporte.Document.Printer.PrinterName = "SAMSUNG SRP-350"
                'Else
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            End If

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.Print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Catch ex As ApplicationException

            PrintRevaleParesStandar()

        End Try

    End Sub

    Public Sub PrintRevaleParesStandar()


        Dim oARReporte As New rptRevaleParesStandar(owsDPValeInfo, Me.vSobrante, Me.Logo)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Impresión Revale"

        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            ' oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub PrintRevaleMoneyStandar()


        Dim oARReporte As New rptRevaleMoneyStandar(owsDPValeInfo, Me.vSobrante, Me.Logo)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Impresión Revale"

        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try
            ' oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Function ValidatingPrinter(ByVal printer As String) As Boolean

        Try

            Dim pd As New PrintDocument

            pd.PrinterSettings.PrinterName = printer

            If pd.PrinterSettings.IsValid Then
                Return True
                'MessageBox.Show("Printer is valid.")
            Else
                Return False
                'MessageBox.Show("Printer is invalid.")
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#End Region

#Region "Sap Retail"
    Private RestService As New ProcesosRetail("", "POST")
#End Region

#Region "SAP Methods"

    Private Sub SaveFacturaSAP()

        Me.Cursor = Cursors.WaitCursor

        Dim arDatosZV() As String
        Dim arDatosDPVale() As String

        Dim oVentaFacturaSAP As New VentasFacturaSAP

        With oVentaFacturaSAP

            'Se manda la Fecha Apartado.
            'Para determinar el precio. 18.10.2007
            .FechaApartado = oFactura.FechaApartado

            .FacturaDP = oFactura.CodAlmacen & oFactura.CodCaja & CStr(oFactura.FolioFactura)
            '   .FacturaDP = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & CStr(oFactura.FolioFactura)
            '---------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 17.05.2014: Enviamos la fecha del servidor SAP
            '---------------------------------------------------------------------------------------------------------------------------------------------
            .FechaMovimiento = FechaSAP
            '.FechaMovimiento = Date.Now.Date

            .ClasePedido = "Z" & Mid(oAppContext.ApplicationConfiguration.Almacen, 2, 2) & "1"

            If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                GoTo Cambio_053
                '.OficinaVentas = "C053"
            Else
Cambio_053:
                .OficinaVentas = "T" & oAppContext.ApplicationConfiguration.Almacen
            End If

            .Vendedor = oFactura.CodVendedor

            If oAppSAPConfig.DPValeSAP And oFactura.CodTipoVenta = "V" Then

                .Centro = oSAPMgr.Read_Centros()

            Else
                If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                    'Cambio_053
                    '.Centro = "C053"
                    .Centro = "T053"
                Else
                    .Centro = "T" & oAppContext.ApplicationConfiguration.Almacen
                End If
            End If

            Select Case oFactura.CodTipoVenta
                Case "P"
                    .Credito = "N"
                    .CodigoCliente = oAppContext.ApplicationConfiguration.Almacen.PadLeft(10, "0")
                Case "E"
                    .Credito = "N"
                    .CodigoCliente = "99999".PadLeft(10, "0")
                Case "F", "O", "I", "A", "S", "K"
                    .Credito = "N"
                    .CodigoCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                Case "V"
                    .Credito = "S"
                    arDatosDPVale = GetDPValeSAP()
                    .CodigoCliente = arDatosDPVale(0).PadLeft(10, "0")
                    .MontoDPVale = arDatosDPVale(1)
                    .ClienteDistribuidor = arDatosDPVale(2).PadLeft(10, "0")
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 17.05.2014: Se agrego un id a las ventas DPVale para en caso de fallo en SAP realizar un reintento del guardado e identificar 
                    'que es la misma venta
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    .DPValeVentaID = Me.DPValeVentaID

                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (17.05.2014): Se agrego el dato del seguro para saber si se genera o no
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    .SeguroDPVL = oConfigCierreFI.GenerarSeguro
                    If oConfigCierreFI.GenerarSeguro = True Then
                        If oConfigCierreFI.ValidaSeguroDPVL = True Then
                            If MessageBox.Show("¿Desea realizar el cargo del seguro?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                .ZSEG = "1"
                            Else
                                .ZSEG = "0"
                            End If
                        Else
                            .ZSEG = "1"
                        End If
                    Else
                        .ZSEG = "0"
                    End If

                    '---------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 29.05.2015: Se envian el monto del seguro y el folio del acreedor a la RFC de SAP
                    '---------------------------------------------------------------------------------------------------------------------------
                    .ImpSegDPVL = ImporteSeguro
                    If Not DatosTicketSeguro Is Nothing AndAlso DatosTicketSeguro.Count > 0 Then .FolSegDPVL = DatosTicketSeguro("folseg")

                    '---------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 09.06.2015: Se envia la Division de la Plaza a la RFC de SAP
                    '---------------------------------------------------------------------------------------------------------------------------
                    .DivPDPVL = DivPlaza

                Case "D"
                    .Credito = "S"
                    .CodigoCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
            End Select

            .NUMDE = oDpvaleSAP.NUMDE                       '--Numero de Quincenas
            .PARES_PZAS = oDpvaleSAP.ParesPzas              '--Numero de Pares Piezas
            .MONTOUTILIZADO = oDpvaleSAP.MontoUtilizado     '--Monto Utilizado
            .REVALE = oDpvaleSAP.REVALE                     '--TRUE si se ocupa Revale FALSE si no se necesita
            .RPARES_PZAS = oDpvaleSAP.RPARES_PZAS           '--Pares Piezas de Revale
            .RMONTODPVALE = oDpvaleSAP.RMONTODPVALE         '--Monto de Revale
            .FOLIOREVALE = String.Empty                     '--Numero de REVALE GENERADO
            .FechaCobroDPVL = oDpvaleSAP.FechaCobro         '--Fecha en la que se empezara a cobrar el primer abono

            arDatosZV = GetZonaVentaSAP(oFactura.CodTipoVenta)
            .ZonaVenta = arDatosZV(0)
            .NumeroVale = arDatosZV(1)      'DPVale o Vale de Caja 

            .TipoVenta = oFactura.CodTipoVenta
            .NombreBAPI = GetNombreBAPI(.ZonaVenta)
            '.Detalle = PutCondicion(oFactura.Detalle.Tables(0))
            .Detalle = oFactura.Detalle.Tables(0)

        End With

        '--Guardar Factura en SAP
        'oSAPMgr.Write_FacturaSAP(oVentaFacturaSAP, bReintentoDPVL)
        '-----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/05/2015: Valida si se guardara por medio de MQTT o directamente en SAP
        '-----------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.MQTTPOS = True Then
            WriteFacturaMQTT(oVentaFacturaSAP, bReintentoDPVL)
        Else
            oSAPMgr.Write_FacturaSAP(oVentaFacturaSAP, bReintentoDPVL)
        End If

        '--Publicamos Folios
        oFactura.FolioSAP = oVentaFacturaSAP.FolioSAP
        oFactura.FolioFISAP = oVentaFacturaSAP.FolioFISAP
        oFactura.REVALE = oVentaFacturaSAP.FOLIOREVALE
        oFactura.Nquincenas = oVentaFacturaSAP.NUMDE
        '--------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.04.2015: Obtenemos el valor que representa si se genero o no el seguro de vida en SAP
        '--------------------------------------------------------------------------------------------------------------------------------------------
        oFactura.SeguroVidaSAPDPVL = oVentaFacturaSAP.SeguroDPVL

        '--------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (02.07.2015): Obtenemos el valor que dice el motivo de rechazo del seguro de vida en SAP
        '--------------------------------------------------------------------------------------------------------------------------------------------
        RechazoSeguro = ""
        RechazoSeguro = oVentaFacturaSAP.RechazoSeguro

        '--------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.04.2015: Si no se genero el seguro de vida en SAP seteamos el importe a cero para que no sume este importe al ticket de venta
        '--------------------------------------------------------------------------------------------------------------------------------------------
        If oVentaFacturaSAP.SeguroDPVL = False Then ImporteSeguro = 0

        oVentaFacturaSAP.Dispose()
        oVentaFacturaSAP = Nothing

        'Actualizo la tabla KNA1 en el campo TELFX, indica que el cliente ya compro el catalogo
        If oFactura.CodTipoVenta = "D" Or oFactura.CodTipoVenta = "S" Then
            Dim result As Dictionary(Of String, Object)
            For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                    RestService.Metodo = "pos/dips"
                    result = RestService.SapZBapiActualizaDips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    'oSAPMgr.Write_Actualiza_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    Exit For
                End If
            Next

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Function GetZonaVentaSAP(ByVal tipoVenta As String) As String()

        Dim dvZonaVenta As New DataView
        Dim oResult(2) As String
        With dvZonaVenta
            .Table = dsFormasPago.Tables(0)
            .AllowDelete = False
            .AllowEdit = False
            .AllowNew = False
            .Sort = "MontoPago DESC"

            If tipoVenta = "F" Then
                .RowFilter = "CodFormasPago = 'FONA'"
            ElseIf tipoVenta = "K" Then
                .RowFilter = "CodFormasPago = 'TFON'"
            ElseIf tipoVenta = "O" Then
                .RowFilter = "CodFormasPago = 'FACI'"
            ElseIf tipoVenta = "V" Then
                .RowFilter = "CodFormasPago = 'DPVL'"
            End If

        End With
        If Not oVC.ValeCajaID > 0 Then
            If tipoVenta = "K" Then
                oResult(0) = "TFON"
                dvZonaVenta.RowFilter = "CodFormasPago = 'VCJA'"
                If dvZonaVenta.Count <= 0 Then
                    dvZonaVenta.RowFilter = "CodFormasPago = 'TFON'"
                End If
                oResult(1) = CStr(dvZonaVenta.Item(0).Item("DPValeID")).PadLeft(10, "0")
            Else
                '---------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 04.06.2015: Si es Forma de Pago de DPCard Puntos la zona de venta en SAP será Tarjeta de Credito
                '---------------------------------------------------------------------------------------------------------------------------
                If CStr(dvZonaVenta.Item(0).Item("CodFormasPago")).Trim.ToUpper = "DPPT" Or CStr(dvZonaVenta.Item(0).Item("CodFormasPago")).Trim.ToUpper = "DPCA" Then
                    oResult(0) = "TACR"
                    oResult(1) = CStr(dvZonaVenta.Item(0).Item("DPValeID")).PadLeft(10, "0")
                Else
                    oResult(0) = dvZonaVenta.Item(0).Item("CodFormasPago")
                    oResult(1) = CStr(dvZonaVenta.Item(0).Item("DPValeID")).PadLeft(10, "0")
                End If

            End If
            'oResult(0) = dvZonaVenta.Item(0).Item("CodFormasPago")
            'oResult(1) = CStr(dvZonaVenta.Item(0).Item("DPValeID")).PadLeft(10, "0")
        Else
            If tipoVenta = "O" Then
                oResult(0) = "FACI"
                oResult(1) = oVC.ValeCajaID
            ElseIf tipoVenta = "F" Then
                oResult(0) = "FONA"
                oResult(1) = oVC.ValeCajaID
            ElseIf tipoVenta = "K" Then
                oResult(0) = "TFON"
                oResult(1) = oVC.ValeCajaID
            End If

        End If


        dvZonaVenta.Dispose()
        dvZonaVenta = Nothing

        Return oResult

    End Function

    Private Function GetDPValeSAP() As String()

        Dim oRow As DataRow
        Dim oResult(3) As String
        oRow = dtDPVale.Rows(0)

        If oAppSAPConfig.DPValeSAP Then
            oResult(0) = oRow!ClienteAsociadoID
            oResult(1) = oRow!MontoDPVale
            oResult(2) = oRow!CodigoSAP
        Else
            oResult(0) = oRow!CodigoSAP
            oResult(1) = oRow!MontoDPVale
            oResult(2) = oRow!CodigoSAP
        End If

        oRow = Nothing

        Return oResult

    End Function

    Private Function GetNombreBAPI(ByVal strZonaVenta As String) As String

        If oFactura.CodTipoVenta = "D" Then
            Return "ZBAPISD12_VENTADIPS"                        '--DIP's
        ElseIf oFactura.CodTipoVenta = "A" Then
            Return "ZBAPISD11_VENTAAPARTADO"
        ElseIf oFactura.CodTipoVenta = "I" Then
            Select Case UCase(strZonaVenta)
                Case "EFEC"
                    Return "ZBAPISD06_VTAEFECTIVOFACFIS"        '--Fact. Fiscal
                Case "VCJA"
                    Return "ZBAPISD09_VTAVALECAJA"              '--Fact. Fiscal
                Case "TACR"
                    Return "ZBAPISD08_VTATARJETAFACFIS"         '--Fact. Fiscal
                Case "TADB"
                    Return "ZBAPISD08_VTATARJETAFACFIS"         '--Fact. Fiscal
            End Select
        Else
            Select Case UCase(strZonaVenta)
                Case "EFEC"
                    Return "ZBAPISD05_VENTASEFECPG"             '--Pub. General
                Case "VCJA"
                    Return "ZBAPISD09_VTAVALECAJA"              '--Pub. General
                Case "TACR"
                    Return "ZBAPISD07_VENTASTARCPG"             '--Pub. General
                Case "TADB"
                    Return "ZBAPISD07_VENTASTARCPG"             '--Pub. General

                    '------------------------------------------------------------------------------------------
                    'JNAVA (02.03.2015): Se agrego lo correspondiente a la forma de pago de DPCARD
                    '------------------------------------------------------------------------------------------
                Case "DPCA"
                    Return "ZBAPISD07_VENTASTARCPG"             '--Pub. General
                    '------------------------------------------------------------------------------------------
                Case "FONA", "TFON"
                    Return "ZBAPISD14_VENTASFONACOT"            '--FONACOT
                Case "FACI"
                    Return "ZBAPISD15_VENTASFACILITO"           '--FACILITO
                Case "DPVL"
                    If oAppSAPConfig.DPValeSAP Then
                        Return "ZBAPISD10_VENTA_DPVALE"         '--DPVALE SAP
                    Else
                        Return "ZBAPISD10_VENTADPVALE"          '--DPVALE
                    End If
            End Select
        End If

    End Function

    Private Function PutCondicion(ByVal dtDatos As DataTable) As DataTable

        Dim oData As New DataTable
        Dim oCol As DataColumn
        Dim oRow As DataRow
        Dim oCondicionVenta As Decimal
        oData = dtDatos

        '--Añadimos Columna Condicion
        oCol = New DataColumn
        With oCol
            .ColumnName = "Condicion"
            .DataType = Type.GetType("System.String")
            .MaxLength = 4
            .DefaultValue = ""
        End With
        oData.Columns.Add(oCol)
        oCol.Dispose()
        oCol = Nothing
        '--Fin Columna Condicion

        For Each oRow In oData.Rows
            If oRow!Adicional > 0 Then
                If vCodTipoDescuento = "DMA" Then                   '--Descuento de Manager
                    oRow!Condicion = "ZDP4"
                ElseIf vCodTipoDescuento = "DVD" Then               '--Vales de Descuento
                    oRow!Condicion = "ZDP4"
                    'oRow!Condicion = "Z3AN"
                ElseIf vCodTipoDescuento = "DCD" Then               '--Descuento DIPs
                    oRow!Condicion = "ZDP4"
                ElseIf vCodTipoDescuento = "DPO" OrElse vCodTipoDescuento = "DPE" Then
                    oRow!Condicion = "ZDP4"
                Else
                    oRow!Condicion = ""
                End If
            Else
                oArticulo.ClearFields()
                oCatalogoArticuloMgr.LoadInto(oRow!Codigo, oArticulo)
                oCondicionVenta = CondicionVenta_Porcentaje()
                If oRow!Descuento > 0 And oCondicionVenta = 0 Then  '--Es un Dpesos
                    oRow!Condicion = "Z501"
                Else
                    oRow!Condicion = ""
                End If
            End If
        Next

        oRow = Nothing

        Return oData

    End Function

#End Region

#Region "Eventos"

    '    Private Sub ebNumTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarj.KeyDown

    '        If e.KeyCode = Keys.Enter Then

    '            If ebNumTarj.Text.Length <= 16 Then
    '                Exit Sub
    '                'ElseIf Trim(Me.txtCVV2.Text) = "" AndAlso Me.ebTipoTarjeta.Value = "TE" Then
    '                '   MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                '  Me.txtCVV2.Focus()
    '                ' Exit Sub
    '            End If

    '            If Me.ebTipoTarjeta.Value = "TE" Then
    '                If oAppSAPConfig.eHub = True Then
    '                    If booleHub Then
    '                        Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                        Dim i As Long
    '                        Dim mSalida As String
    '                        Dim mAmount As Double           '4    
    '                        Dim mPOSEntry As String         '22        
    '                        Dim mTrack2 As String           '35        
    '                        Dim mRespose As String          '61

    '                        Dim mE2 As String
    '                        Dim mHRecordType As String
    '                        Dim mHTerm As String
    '                        Dim mHCajero As String
    '                        Dim mHTienda As String
    '                        Dim mHTicket As String
    '                        Dim mHTrack2 As String
    '                        Dim mHImporte As String
    '                        Dim mHMeses As String
    '                        Dim mHSkip As String
    '                        Dim mHCVV2 As String
    '                        Dim mHCargo As String
    '                        Dim mHCredito As String
    '                        Dim mHFijo As String
    '                        Dim mCard As String
    '                        Dim mAutorizacion As String
    '                        Dim Mensaje As String
    '                        Dim Mensaje46 As String
    '                        Dim mRespcode As String
    '                        Dim mFile As Integer

    '                        Dim mDummy As String
    '                        Dim mCarPun As String
    '                        Dim mCrePun As String
    '                        Dim mCarDin As String
    '                        Dim mCreDin As String
    '                        Dim mNumCia As String
    '                        Dim mNumPlan As String
    '                        Dim mOperacion As String
    '                        Dim mAfiliacion As String
    '                        Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
    '                        Dim mRespuesta As String
    '                        Dim mComentario As String



    '                        'Ocultamos informacion de la tarjeta , para dejar unicamente el numero
    '                        Dim strTrack() As String = ebNumTarj.Text.Split(";")
    '                        Dim strNombre As String

    '                        strNombre = GetName(strTrack(0))

    '                        'If InStr(strTrack(0), "¨") > 0 Then
    '                        '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("¨", 19) - 18)
    '                        '    strNombre = strNombre.Replace("¨", "").Trim
    '                        'Else
    '                        '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("^", 19) - 18)
    '                        '    strNombre = strNombre.Replace("^", "").Trim
    '                        'End If
    '                        ebNumTarj.Text = strTrack(1)

    '                        Dim intPosition As Integer = 0
    '                        Dim strVencimiento As String = String.Empty
    '                        Dim strPromocion As String = String.Empty
    '                        Dim strNum As String = (ebNumTarj.Text).Replace(";", "")
    '                        intPosition = InStr(strNum, "=")
    '                        strVencimiento = Mid(strNum, intPosition + 3, 2) & "/" & Mid(strNum, intPosition + 1, 2)
    '                        strNum = Mid(strNum, 1, intPosition - 1)

    '                        'If strTarjetaBloq <> "" Then
    '                        If oFacturaMgr.EsTarjetaBloqueada(strNum) Then
    '                            'Dim strTarjetasBloq As String() = strTarjetaBloq.Split("°")
    '                            'For Each Str As String In strTarjetasBloq
    '                            'If Str.ToUpper.Trim = strNum.ToUpper.Trim Then
    '                            MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Me.ebNumTarj.Text = strNum
    '                            Exit Sub
    '                            'End If
    '                            '  Next
    '                            'ElseIf Me.EBPago.Value > 5000 Then
    '                        ElseIf Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                                MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Me.ebNumTarj.Text = strNum
    '                                Exit Sub
    '                            Else
    '                                oAppContext.Security.CloseImpersonatedSession()
    '                            End If
    '                        ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) OrElse BuscaTarjeta(strNum) = True Then
    '                            oAppContext.Security.CloseImpersonatedSession()
    '                            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                                MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Me.ebNumTarj.Text = strNum
    '                                Exit Sub
    '                            Else
    '                                oAppContext.Security.CloseImpersonatedSession()
    '                            End If
    '                        End If

    '                        'INICIO Consulta de promociones
    '                        Dim strProSkip, strProMeses As String
    '                        mTrack2 = (ebNumTarj.Text).Replace(";", "")
    '                        mTrack2 = (mTrack2).Replace("?", "")

    '                        mSalida = x.PagoTarjeta(oAppContext.ApplicationConfiguration.Almacen, _
    '                        oAppContext.ApplicationConfiguration.NoCaja, oFactura.CodVendedor, _
    '                        "000001", 902, mTrack2, CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, _
    '                        mHMeses, mHSkip, mCVV2)

    '                        strProMeses = ""
    '                        strProSkip = ""

    '                        mDummy = mSalida
    '                        Do While Len(mDummy) > 0
    '                            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                            If InStr(mRespose, "39==") > 0 Then
    '                                mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If
    '                            If InStr(mRespose, "43==") > 0 Then
    '                                Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                            End If
    '                            If InStr(mRespose, "46==") > 0 Then
    '                                Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If

    '                        Loop
    '                        If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
    '                            'Mando llamar la pantalla para seleccionar la promocion del pago
    '                            Dim ofrm As New frmPromociones(Mensaje46)
    '                            If ofrm.ShowDialog() = DialogResult.OK Then
    '                                strProMeses = ofrm.Plazo
    '                                strProSkip = ofrm.Skip
    '                                strPromocion = ofrm.ebPromocion.Text
    '                                intPromo = CInt(strProMeses)
    '                            Else
    '                                Me.ebNumTarj.Text = ""
    '                                Me.txtCVV2.Text = ""
    '                                Me.txtCVV2.Focus()

    '                                Exit Sub
    '                            End If

    '                        End If
    '                        'FIN Consulta de promociones

    '                        'Limpiamos las variebles que pudieron ser afectadas en la consulta de promociones
    '                        x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
    '                        mRespcode = ""
    '                        Mensaje = ""
    '                        Mensaje46 = ""

    '                        On Error Resume Next
    '                        mHTienda = oAppContext.ApplicationConfiguration.Almacen
    '                        mHTerm = oAppContext.ApplicationConfiguration.NoCaja
    '                        mHCajero = oFactura.CodVendedor
    '                        mHRecordType = 2
    '                        mPOSEntry = "902"
    '                        mTrack2 = (ebNumTarj.Text).Replace(";", "")
    '                        mTrack2 = (mTrack2).Replace("?", "")
    '                        ebNumTarj.Text = strNum
    '                        mAmount = CDbl(EBPago.Text)
    '                        'El ticket debe de variar, ver de donde se va a sacar el consecutivo
    '                        mHTicket = oAppSAPConfig.Ticket

    '                        If InStr(mTrack2, "=") > 0 Then
    '                            mCard = mTrack2.Substring(0, InStr(mTrack2, "=") - 1)
    '                        End If

    '                        mSalida = ""
    '                        mDummy = ""

    '                        Select Case CInt(mHRecordType)
    '                            Case 1 : mHCVV2 = "    " 'Consulta Planes
    '                                mCVV2 = "    "
    '                                mOperacion = "000001"
    '                            Case 2 : mOperacion = "000000" 'CreditAuth
    '                                mHMeses = strProMeses
    '                                mHSkip = strProSkip
    '                                mHCVV2 = txtCVV2.Text
    '                                mCVV2 = Trim(txtCVV2.Text)
    '                                'Case 3 : mOperacion = "000003" 'ConsCteFrec
    '                                'Case 4 : mOperacion = "000004" 'ActCteFrec
    '                                '    mCarPun = txtCargoPun.Text
    '                                '    mCrePun = txtAbonoPun.Text
    '                                '    mCarDin = txtCargoDin.Text
    '                                '    mCreDin = txtAbonoDin.Text
    '                                '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
    '                                'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
    '                                'Case 6 : mOperacion = "000006" 'PlanCelular
    '                                'Case 7 : mOperacion = "000007" 'VentaTACelular
    '                                '    mHMeses = txtSkip.Text
    '                                '    mHSkip = txtMeses.Text
    '                                'Case 8 : mOperacion = "000008" 'PeticionVenta
    '                                'Case 9 : mOperacion = "000009" 'ConsultaSaldo
    '                                'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
    '                                '    mHCargo = txtCargoDin.Text
    '                                '    mHCredito = txtAbonoDin.Text
    '                                '    If mHCredito > 0 Then
    '                                '        mAmount = mHCredito
    '                                '        mOperacion = "000110"
    '                                '    Else
    '                                '        mAmount = mHCargo
    '                                '    End If
    '                                'Case 11 : mOperacion = "000011" 'ConsultaBono
    '                        End Select
    '                        'txtOutput.Text = ""
    '                        mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, mOperacion, mPOSEntry, mTrack2, _
    '                                                mAmount, mHTicket, mComentario, mRespuesta, mHMeses, mHSkip, _
    '                                                mCVV2)

    '                        mDummy = mSalida
    '                        Do While Len(mDummy) > 0
    '                            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                            If InStr(mRespose, "38==") > 0 Then
    '                                mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
    '                            End If
    '                            If InStr(mRespose, "39==") > 0 Then
    '                                mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                            End If
    '                            If InStr(mRespose, "43==") > 0 Then
    '                                Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                            End If
    '                            If InStr(mRespose, "46==") > 0 Then
    '                                Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                                Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
    '                            End If
    '                            If InStr(mRespose, "48==") > 0 Then
    '                                mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
    '                            End If
    '                        Loop
    '                        If mOperacion = "000001" Then
    '                            If mAutorizacion > 1 Then
    '                                Mid$(mHFijo, 4, 1) = "1"
    '                            End If
    '                            While InStr(Mensaje46, vbCrLf) > 0
    '                                mDummy = Mensaje46.Substring(0, InStr(Mensaje46, vbCrLf) - 1)
    '                                Mensaje46 = Mensaje46.Substring(InStr(Mensaje46, vbCrLf) + 1, Len(Mensaje46) - InStr(Mensaje46, vbCrLf) - 1)
    '                            End While
    '                        Else
    '                            mDummy = mHFijo
    '                            If mOperacion = "000002" Then
    '                                mDummy = mDummy & mRespcode & mAutorizacion
    '                                mDummy = mDummy & Mensaje.Substring(0, 40)
    '                                If Len(Mensaje) < 40 Then
    '                                    mDummy = mDummy & Space(40 - Len(Mensaje))
    '                                End If
    '                            End If
    '                            If mOperacion = "000002" Then
    '                                mDummy = mDummy & Mensaje46.Substring(0, 20)
    '                                If Len(Mensaje46) < 20 Then
    '                                    mDummy = mDummy & Space(20 - Len(Mensaje46))
    '                                End If
    '                                mDummy = mDummy & mAfiliacion
    '                            Else
    '                                mDummy = mDummy & Mensaje46
    '                            End If

    '                        End If


    '                        If mRespcode = "00" AndAlso Trim(mAutorizacion) <> "" AndAlso Trim(mAfiliacion) <> "" Then

    '                            'If Mensaje46 Is Nothing Then
    '                            '    Mensaje46 = "00"
    '                            'End If

    '                            'Mensaje = UCase(Mensaje)
    '                            Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper

    '                            If InStr(Mensaje, "BANAMEX") > 0 Then
    '                                ebCodBanco.Text = "T3"
    '                                ebCodBanco.Value = "T3"
    '                                EBBanco.Text = "BANAMEX"
    '                            ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
    '                                ebCodBanco.Text = "T1"
    '                                ebCodBanco.Value = "T1"
    '                                EBBanco.Text = "BANCOMER"
    '                            ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
    '                                ebCodBanco.Text = "T2"
    '                                ebCodBanco.Value = "T2"
    '                                EBBanco.Text = "SANTANDER"
    '                            End If

    '                            Me.ebTipoTarjeta.Value = "TE"
    '                            'Select Case Mensaje46.Substring(2, Mensaje46.Length - 2)
    '                            '    Case "BANAMEX"
    '                            '        ebCodBanco.Text = "T3"
    '                            '        ebCodBanco.Value = "T3"
    '                            '        EBBanco.Text = "BANAMEX"
    '                            '    Case "BANCOMER"
    '                            '        ebCodBanco.Text = "T1"
    '                            '        ebCodBanco.Value = "T1"
    '                            '        EBBanco.Text = "BANCOMER"
    '                            '    Case "SANTANDER"
    '                            '        ebCodBanco.Text = "T2"
    '                            '        ebCodBanco.Value = "T2"
    '                            '        EBBanco.Text = "SANTANDER"
    '                            'End Select


    '                            strNoAfiliacion = mAfiliacion
    '                            'Transaccion Exitosa
    '                            Me.ebAutorizacion.Text = mAutorizacion
    '                            bolCargoEHub = True
    '                            MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "DPTienda")

    '                            ''''I. Actualizamos Ticket.
    '                            Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    '                            Dim oSApReader As New SapConfigReader(strConfigurationFile)
    '                            oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
    '                            oSApReader.SaveSettings(oAppSAPConfig)
    '                            ''''F. Actualizamos Ticket.


    '                            ''Original Banco
    '                            Dim bolReimpresion As Boolean = False
    '                            Dim oView As ReportViewerForm

    'Reimprimir:
    '                            Select Case ebCodBanco.Text

    '                                Case "T3"
    'Imprime_Banamex:
    '                                    Dim oARReporte As New rptTicketBANAMEX(CDbl(EBPago.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, oFactura.CodVendedor, _
    '                                                                           mAfiliacion, EBBanco.Text, "ORIGINAL BANCO")
    '                                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporte.Run()
    '                                    oARReporte.Document.Print(False, False)

    '                                    ''Copia Cliente
    '                                    Dim oARReporteC As New rptTicketBANAMEX(CDbl(EBPago.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, oFactura.CodVendedor, _
    '                                                                           mAfiliacion, EBBanco.Text, "COPIA CLIENTE")
    '                                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporteC.Run()
    '                                    oARReporteC.Document.Print(False, False)

    '                                Case "T1"

    '                                    Dim oARReporte As New rptTicketBancomer(CDbl(EBPago.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, oFactura.CodVendedor, _
    '                                                                           mAfiliacion, EBBanco.Text, "ORIGINAL BANCO", "", True, True, "")
    '                                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporte.Run()
    '                                    'oARReporte.Document.Print(False, False)
    '                                    oView.Report = oarreporte
    '                                    oView.Show()

    '                                    oView = New ReportViewerForm

    '                                    'Copia Cliente
    '                                    Dim oARReporteC As New rptTicketBancomer(CDbl(EBPago.Text), strNum, strVencimiento, mAutorizacion, strPromocion, "VENTA", strNombre, oFactura.CodVendedor, _
    '                                                                           mAfiliacion, EBBanco.Text, "COPIA CLIENTE", "", True, True, "")
    '                                    oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
    '                                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                                    oARReporteC.Run()
    '                                    'oARReporteC.Document.Print(False, False)
    '                                    oView.Report = oarreportec
    '                                    oView.Show()

    '                                Case Else

    '                                    GoTo Imprime_Banamex

    '                            End Select

    '                            If bolReimpresion = False Then
    '                                If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '                                    bolReimpresion = True
    '                                    GoTo Reimprimir
    '                                End If
    '                            End If

    '                            Me.uitnAgregar.Focus()
    '                            Me.uitnAgregar.PerformClick()

    '                        Else
    '                            'Transaccion Rechazada

    '                            If Trim(mRespcode) <> "00" Then

    '                                Dim Motivo As String = ""

    '                                Select Case mRespcode.Trim
    '                                    Case "04", "14", "41", "43", "142"
    '                                        oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarj.Text.Trim)
    '                                        'Me.strTarjetaBloq &= Me.ebNumTarj.Text & "°"
    '                                        Motivo = "La tarjeta ha sido rechazada.".ToUpper
    '                                    Case "49"
    '                                        Motivo = "CVV2 Incorrecto.".ToUpper
    '                                    Case "91"
    '                                        Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
    '                                End Select

    '                                MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
    '                                       mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '                            ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
    '                                       " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                       MsgBoxStyle.Exclamation, "DPTienda")

    '                            ElseIf Trim(mAutorizacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
    '                                       Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                       MsgBoxStyle.Exclamation, "DPTienda")

    '                            ElseIf Trim(mAfiliacion) = "" Then

    '                                MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
    '                                       Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                                       MsgBoxStyle.Exclamation, "DPTienda")

    '                            End If

    '                            Me.ebNumTarj.Text = ""
    '                            Me.txtCVV2.Text = ""
    '                            Me.txtCVV2.Focus()

    '                        End If


    '                        'mConsecutivo = mConsecutivo + 1
    '                        'txtOutput.Text = "Mensaje al Voucher" & vbCrLf & mDummy & vbCrLf
    '                        'txtOutput.Text = "Mensaje Recibido" & vbCrLf & mSalida & vbCrLf
    '                    End If
    '                Else
    '                    GoTo Manual
    '                End If
    '            Else
    'Manual:
    '                'Ocultamos informacion de la tarjeta , para dejar unicamente el numero
    '                Dim strTrack() As String = ebNumTarj.Text.Split(";")

    '                strNombreM = GetName(strTrack(0))
    '                'If InStr(strTrack(0), "¨") > 0 Then
    '                '    strNombreM = strTrack(0).Substring(18, strTrack(0).IndexOf("¨", 19) - 18)
    '                '    strNombreM = strNombreM.Replace("¨", "").Trim
    '                'Else
    '                '    strNombreM = strTrack(0).Substring(18, strTrack(0).IndexOf("^", 19) - 18)
    '                '    strNombreM = strNombreM.Replace("^", "").Trim
    '                'End If

    '                ebNumTarj.Text = strTrack(1)
    '                Array.Clear(strTrack, 0, 2)
    '                strTrack = ebNumTarj.Text.Split("=")
    '                ebNumTarj.Text = strTrack(0)
    '                strVencM = strtrack(1).Substring(2, 2) & "/" & strtrack(1).Substring(0, 2)

    '                'If strTarjetaBloq <> "" Then
    '                If oFacturaMgr.EsTarjetaBloqueada(ebNumTarj.Text.Trim) Then
    '                    'Dim strTarjetasBloq As String() = strTarjetaBloq.Split("°")
    '                    'For Each Str As String In strTarjetasBloq
    '                    'If Str.ToUpper.Trim = ebNumTarj.Text.ToUpper.Trim Then
    '                    MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    Me.cmbPromocion.DataSource = Nothing
    '                    Me.cmbPromocion.Text = ""
    '                    Exit Sub
    '                    'End If
    '                    'Next
    '                    'ElseIf Me.EBPago.Value > 5000 Then
    '                ElseIf Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
    '                    oAppContext.Security.CloseImpersonatedSession()
    '                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Me.cmbPromocion.DataSource = Nothing
    '                        Me.cmbPromocion.Text = ""
    '                        Exit Sub
    '                    Else
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                    End If
    '                ElseIf oCatFormaPago.TarjetaUsadaHoy(Me.ebNumTarj.Text) OrElse BuscaTarjeta(Me.ebNumTarj.Text) = True Then
    '                    oAppContext.Security.CloseImpersonatedSession()
    '                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
    '                        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Me.cmbPromocion.DataSource = Nothing
    '                        Me.cmbPromocion.Text = ""
    '                        Exit Sub
    '                    Else
    '                        oAppContext.Security.CloseImpersonatedSession()
    '                    End If
    '                End If

    '                FillBancoPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), Me.EBPago.Value)
    '                Me.cmbPromocion.Text = ""

    '            End If

    '        End If

    '    End Sub

    Private Function AutorizarCargoTarjeta() As Boolean

        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        Dim pagoTarj As Decimal = 0

        '-----------------------------------------------------------
        'JNAVA (29.01.2015): Determinamos si se leera DP CARD
        '-----------------------------------------------------------
        If Me.cmbFormaPago.Value = "DPCA" Then
            Band = LeerDPCard()
            GoTo Final
        End If

        If Me.ebTipoTarjeta.Value = "TE" Then

            If oAppSAPConfig.eHub = True Then

                If booleHub Then

                    Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    Dim mSalida As String = ""
                    Dim mPOSEntry As String = ""       '22        
                    Dim mTrack2 As String = ""        '35        
                    Dim mRespose As String = ""        '61
                    'Dim mHRecordType As String = ""
                    Dim mHTerm As String = ""
                    Dim mHCajero As String = ""
                    Dim mHTienda As String = ""
                    Dim mHTicket As String = ""
                    Dim mHMeses As String = ""
                    Dim mHSkip As String = ""
                    Dim mHFijo As String = ""
                    Dim mAutorizacion As String = ""
                    Dim Mensaje As String = ""
                    Dim Mensaje46 As String = ""
                    Dim mRespcode As String = ""
                    Dim mDummy As String = ""
                    Dim mOperacion As String = ""
                    Dim mAfiliacion As String = ""
                    Dim mCVV2 As String = ""
                    Dim mRespuesta As String = ""
                    Dim mComentario As String = ""
                    Dim strNombre As String = ""
                    Dim strCriptograma As String = ""
                    Dim strCardSN As String = ""
                    Dim strEmisor As String = ""

                    pagoTarj = CDec(EBPago.Value)

                    'ebNumTarj.Text = Datos(0)
                    'strNombre = Datos(1)
                    'strCardSN = Datos(4)
                    'strCriptograma = Datos(5)

                    'Dim intPosition As Integer = 0
                    Dim strVencimiento As String = ""
                    Dim strPromocion As String = ""
                    Dim strNum As String = "" '(ebNumTarj.Text).Replace(";", "")
                    'intPosition = InStr(strNum, "=")
                    'strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
                    'strNum = Mid(strNum, 1, intPosition - 1)
                    'mPOSEntry = Datos(3) & "1"


                    'If oFacturaMgr.EsTarjetaBloqueada(strNum) Then

                    '    MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Me.ebNumTarj.Text = strNum
                    '    Band = False
                    '    If mPOSEntry.Trim = "051" Then
                    '        Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    '    End If
                    '    GoTo Final

                    If Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
                        oAppContext.Security.CloseImpersonatedSession()
                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                            MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.ebNumTarj.Text = ""
                            Band = False
                            GoTo Final
                        Else
                            oAppContext.Security.CloseImpersonatedSession()
                        End If
                        'ElseIf oCatFormaPago.TarjetaUsadaHoy(strNum) OrElse BuscaTarjeta(strNum) = True Then
                        '    oAppContext.Security.CloseImpersonatedSession()
                        '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                        '        If mPOSEntry.Trim = "051" Then
                        '            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                        '        End If
                        '        MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '        Me.ebNumTarj.Text = strNum
                        '        Band = False
                        '        GoTo Final
                        '    Else
                        '        oAppContext.Security.CloseImpersonatedSession()
                        '    End If
                    End If

                    'INICIO Consulta de promociones
                    'Dim strProSkip, strProMeses As String
                    'mTrack2 = (ebNumTarj.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")
                    mHTienda = oAppContext.ApplicationConfiguration.Almacen
                    mHTerm = oAppContext.ApplicationConfiguration.NoCaja
                    mHCajero = oFactura.CodVendedor

                    'mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000001", mPOSEntry, mTrack2, _
                    'CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, _
                    'strCardSN, "", mHMeses, mHSkip, mCVV2)

                    'strProMeses = ""
                    'strProSkip = ""

                    'mDummy = mSalida
                    'Do While Len(mDummy) > 0
                    '    mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
                    '    mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
                    '    If InStr(mRespose, "39==") > 0 Then
                    '        mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '    End If
                    '    If InStr(mRespose, "43==") > 0 Then
                    '        Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '        If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                    '    End If
                    '    If InStr(mRespose, "46==") > 0 Then
                    '        Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                    '    End If

                    'Loop
                    'Mensaje46 = "0100Normal              |06006 Meses Sin Intereses|120012 Meses Sin Intereses|"
                    'mRespcode = "00"
                    'If mRespcode = "00" And InStr(Mensaje46, "|") > 0 Then
                    '    'Mando llamar la pantalla para seleccionar la promocion del pago
                    '    Dim ofrm As New frmPromociones(Mensaje46)
                    '    If ofrm.ShowDialog() = DialogResult.OK Then
                    '        strProMeses = ofrm.Plazo
                    '        strProSkip = ofrm.Skip
                    '        strPromocion = ofrm.ebPromocion.Text
                    '        intPromo = CInt(strProMeses)
                    '    Else
                    '        Me.ebNumTarj.Text = ""
                    '        Me.txtCVV2.Text = ""
                    '        Me.txtCVV2.Focus()

                    '        Band = False
                    '        GoTo Final
                    '        'Exit Function
                    '    End If
                    'End If
                    'FIN Consulta de promociones

                    'Limpiamos las variables que pudieron ser afectadas en la consulta de promociones
                    Dim mFirma As String = ""
                    Dim mLote As String = ""
                    Dim mSubtechTermID As String = ""
                    Dim mTrace As String = ""


                    x = New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub
                    mRespcode = ""
                    Mensaje = ""
                    Mensaje46 = ""

                    On Error Resume Next

                    'mHRecordType = 2
                    'mPOSEntry = Datos(3) & "1"
                    'mTrack2 = (ebNumTarj.Text).Replace(";", "")
                    'mTrack2 = (mTrack2).Replace("?", "")
                    'ebNumTarj.Text = strNum

                    'El ticket debe de variar, ver de donde se va a sacar el consecutivo
                    mHTicket = oAppSAPConfig.Ticket

                    mSalida = ""
                    mDummy = ""
                    mOperacion = "000000"
                    mHMeses = ""
                    mHSkip = ""
                    mCVV2 = ""

                    'Select Case CInt(mHRecordType)
                    '    Case 1 'mHCVV2 = "    " 'Consulta Planes
                    '        mCVV2 = "    "
                    '        mOperacion = "000001"
                    '    Case 2 : mOperacion = "000000" 'CreditAuth
                    '        mHMeses = strProMeses
                    '        mHSkip = strProSkip
                    '        'mHCVV2 = txtCVV2.Text
                    '        mCVV2 = Trim(txtCVV2.Text)
                    '        'Case 3 : mOperacion = "000003" 'ConsCteFrec
                    '        'Case 4 : mOperacion = "000004" 'ActCteFrec
                    '        '    mCarPun = txtCargoPun.Text
                    '        '    mCrePun = txtAbonoPun.Text
                    '        '    mCarDin = txtCargoDin.Text
                    '        '    mCreDin = txtAbonoDin.Text
                    '        '    mAmount = mCarPun & "|" & mCrePun & "|" & mCarDin & "|" & mCreDin
                    '        'Case 5 : mOperacion = "000005" 'CatalogoCiaCelular
                    '        'Case 6 : mOperacion = "000006" 'PlanCelular
                    '        'Case 7 : mOperacion = "000007" 'VentaTACelular
                    '        '    mHMeses = txtSkip.Text
                    '        '    mHSkip = txtMeses.Text
                    '        'Case 8 : mOperacion = "000008" 'PeticionVenta
                    '        'Case 9 : mOperacion = "000009" 'ConsultaSaldo
                    '        'Case 10 : mOperacion = "000010" 'ActTarjetaRegalo
                    '        '    mHCargo = txtCargoDin.Text
                    '        '    mHCredito = txtAbonoDin.Text
                    '        '    If mHCredito > 0 Then
                    '        '        mAmount = mHCredito
                    '        '        mOperacion = "000110"
                    '        '    Else
                    '        '        mAmount = mHCargo
                    '        '    End If
                    '        'Case 11 : mOperacion = "000011" 'ConsultaBono
                    'End Select

                    'mPOSEntry = ""
                    mTrack2 = ""
                    strCardSN = ""
                    oProcesos = Process.GetProcessesByName("eHubEMV")
                    If oProcesos.Length < 1 Then
                        Process.Start(Application.StartupPath & "\eHubEMV.exe")
                    End If
                    mSalida = x.PagoTarjeta(mHTienda, mHTerm, mHCajero, "000000", mPOSEntry, mTrack2, _
                                            CDbl(EBPago.Text), mHTicket, mComentario, mRespuesta, strCardSN, _
                                            "", mHMeses, mHSkip, mCVV2)
                    mHTicket = ""
                    mDummy = mSalida
                    Debug.Write(mSalida & vbCrLf & "".PadLeft(50, "_"))
                    Do While Len(mDummy) > 0
                        mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
                        mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
                        If InStr(mRespose, "22==") > 0 Then
                            mPOSEntry = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "35==") > 0 Then
                            mTrack2 = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "38==") > 0 Then
                            mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
                        End If
                        If InStr(mRespose, "39==") > 0 Then
                            mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                        End If
                        If InStr(mRespose, "43==") > 0 Then
                            Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                        End If
                        If InStr(mRespose, "46==") > 0 Then
                            Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
                        End If
                        If InStr(mRespose, "48==") > 0 Then
                            mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "61==") > 0 Then
                            mFirma = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "62==") > 0 Then
                            mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "63==") > 0 Then
                            mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "64==") > 0 Then
                            mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "65==") > 0 Then
                            mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                    Loop

                    ''''I. Actualizamos Ticket.
                    Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
                    Dim oSApReader As New SapConfigReader(strConfigurationFile)
                    oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
                    oSApReader.SaveSettings(oAppSAPConfig)
                    ''''F. Actualizamos Ticket.

                    If mRespcode.Trim = "00" AndAlso mAutorizacion.Trim <> "" AndAlso mAfiliacion.Trim <> "" Then

                        Dim strTrack2() As String = mTrack2.Split("=")

                        Me.ebNumTarj.Text = strTrack2(0).Replace(";", "")
                        strNum = Me.ebNumTarj.Text.Trim
                        strVencimiento = strTrack2(1).Substring(2, 2) & "/" & strTrack2(1).Substring(0, 2)
                        If mPOSEntry.Trim = "051" Then
                            Dim strMsgs() As String = Mensaje46.Split(",")
                            strCriptograma = strMsgs(strMsgs.Length - 1).Trim
                            If InStr(strCriptograma, "ARQC") <= 0 Then strCriptograma = ""
                        End If

                        If InStr(Mensaje46, "3 MESES") > 0 Then
                            strPromocion = "3 Meses Sin Intereses"
                            intPromo = 3
                        ElseIf InStr(Mensaje46, "6 MESES") > 0 Then
                            strPromocion = "6 Meses Sin Intereses"
                            intPromo = 6
                        ElseIf InStr(Mensaje46, "9 MESES") > 0 Then
                            strPromocion = "9 Meses Sin Intereses"
                            intPromo = 9
                        ElseIf InStr(Mensaje46, "12 MESES") > 0 Then
                            strPromocion = "12 Meses Sin Intereses"
                            intPromo = 12
                        ElseIf InStr(Mensaje46, "15 MESES") > 0 Then
                            strPromocion = "15 Meses Sin Intereses"
                            intPromo = 15
                        ElseIf InStr(Mensaje46, "18 MESES") > 0 Then
                            strPromocion = "18 Meses Sin Intereses"
                            intPromo = 18
                        Else
                            strPromocion = "Normal"
                            intPromo = 1
                        End If

                        Mensaje = ""
                        Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper

                        strEmisor = EBBanco.Text

                        If InStr(Mensaje, "BANAMEX") > 0 Then
                            ebCodBanco.Text = "T3"
                            ebCodBanco.Value = "T3"
                            EBBanco.Text = "BANAMEX"
                        ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                            ebCodBanco.Text = "T1"
                            ebCodBanco.Value = "T1"
                            EBBanco.Text = "BANCOMER"
                        ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                            ebCodBanco.Text = "T2"
                            ebCodBanco.Value = "T2"
                            EBBanco.Text = "SANTANDER"
                        End If

                        Me.ebTipoTarjeta.Value = "TE"

                        'Transaccion Exitosa
                        Me.ebAutorizacion.Text = mAutorizacion
                        Me.strNoAfiliacion = mAfiliacion

                        bolCargoEHub = True
                        MsgBox("Transacción Exitosa" & Microsoft.VisualBasic.vbCrLf & "Preparar Miniprinter", MsgBoxStyle.Information, "Dportenis PRO")

                        Dim bolReimpresion As Boolean = False
                        Dim oReportV As ReportViewerForm
Reimprimir:
                        Select Case ebCodBanco.Text

                            Case "T3"
Imprime_Banamex:
                                ''Original Banco
                                Dim oARReporte As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                                       mAutorizacion, strPromocion, "VENTA", _
                                                                       strNombre, oFactura.CodVendedor, _
                                                                       mAfiliacion, strEmisor, "ORIGINAL BANCO", _
                                                                       mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                ''Copia Cliente
                                Dim oARReporteC As New rptTicketBANAMEX(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, oFactura.CodVendedor, _
                                                                        mAfiliacion, strEmisor, "COPIA CLIENTE", _
                                                                        mFirma, strCriptograma, True, mHTicket, mLote, _
                                                                       mTrace, mSubtechTermID)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporte
                                oReportV.Show()

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporteC
                                oReportV.Show()

                            Case "T1"

                                Dim oARReporte As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, oFactura.CodVendedor, _
                                                                        mAfiliacion, EBBanco.Text, "ORIGINAL BANCO", _
                                                                        mPOSEntry, True, True, strCriptograma, _
                                                                        mFirma)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBancomer(pagoTarj, strNum, strVencimiento, _
                                                                        mAutorizacion, strPromocion, "VENTA", _
                                                                        strNombre, oFactura.CodVendedor, _
                                                                        mAfiliacion, EBBanco.Text, "COPIA CLIENTE", _
                                                                        mPOSEntry, True, True, strCriptograma, _
                                                                        mFirma)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporte
                                oReportV.Show()

                                oReportV = New ReportViewerForm
                                oReportV.Report = oARReporteC
                                oReportV.Show()

                            Case Else

                                GoTo Imprime_Banamex

                        End Select

                        If bolReimpresion = False Then
                            If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                bolReimpresion = True
                                GoTo Reimprimir
                            End If
                        End If

                        Me.uitnAgregar.Focus()
                        Me.uitnAgregar.PerformClick()

                    ElseIf mRespcode = "06" Then

                        MessageBox.Show("El tiempo de espera para deslizar / insertar la tarjeta ha terminado." & vbCrLf & _
                                        "Por favor, Intente de nuevo.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Band = False
                        GoTo Final

                    ElseIf mRespcode.Trim = "95" Then

                        'Transaccion Cancelada
                        Band = False
                        Me.btnLeerTarjeta.Focus()
                        GoTo Final

                    Else
                        'Transaccion Rechazada

                        Band = False

                        If Trim(mRespcode) <> "00" Then
                            Dim Motivo As String = ""

                            Motivo = Mensaje46

                            Select Case mRespcode.Trim
                                'Case "01"
                                '    Motivo = "Promocion Invalida o Monto inferior al minimo permitido.".ToUpper
                                '    Mensaje46 = "Promocion invalida o monto inferior al minimo permitido.".ToUpper
                                'Case "05"
                                '    Motivo = "CVV2 Requerido".ToUpper
                                Case "04", "14", "41", "43", "142"
                                    oFacturaMgr.SaveTarjetaRechazada(Me.ebNumTarj.Text.Trim)
                                    Motivo = "La tarjeta ha sido rechazada.".ToUpper
                                Case "45"
                                    Motivo = "Promocion Invalida.".ToUpper
                                Case "46"
                                    Motivo = "Monto Inferior al mínimo permitido para las promociones."
                                Case "48"
                                    Motivo = "CVV2 Requerido".ToUpper
                                Case "49"
                                    Motivo = "CVV2 Incorrecto.".ToUpper
                                Case "91", "70"
                                    Motivo = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                                    Mensaje46 = "Se ha superado el tiempo de espera. Intente de Nuevo.".ToUpper
                            End Select

                            'MessageBox.Show("Transacción Rechazada." & vbCrLf & Motivo & vbCrLf & _
                            '       mSalida, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            If Motivo.Trim <> "" Then Motivo = vbCrLf & vbCrLf & Motivo
                            If Mensaje46.Trim <> "" Then Mensaje46 = vbCrLf & vbCrLf & Mensaje46
                            'MessageBox.Show("Transacción Rechazada.".ToUpper & Mensaje46.ToUpper _
                            ', "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            MessageBox.Show("Transacción Rechazada.".ToUpper & Motivo.ToUpper _
                            , "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
                                   " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAutorizacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        End If

                        Me.ebNumTarj.Text = ""
                        Me.txtCVV2.Text = ""
                        'Me.txtCVV2.Focus()
                        Me.btnLeerTarjeta.Focus()

                    End If

                End If
            Else
                GoTo Manual
            End If
        Else
Manual:
            Dim Ruta As String = "C:\LecturaTarjeta.txt"
            Dim strPosEntry As String = ""
            Dim Datos() As String

            pagoTarj = CDec(Me.EBPago.Value)

            oProcesos = Process.GetProcessesByName("eHubEMV")
            For Each oApp In oProcesos
                oApp.CloseMainWindow()
                oApp.WaitForExit()
            Next

            Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

            If File.Exists(Ruta) Then
                Datos = LeerArchivoTarjeta(Ruta)
                File.Delete(Ruta)
            Else
                Band = False
                'Me.ebNumTarj.Text = ""
                'Me.cmbPromocion.DataSource = Nothing
                'Me.cmbPromocion.Text = ""
                GoTo FinalManual
            End If

            Dim strTrack() As String

            ebNumTarj.Text = Datos(0)
            Me.mPosEntryM = CInt(Datos(3) & "1")
            Me.strCriptogramaM = Datos(5)
            Me.strNombreM = Datos(6)

            strPosEntry = CStr(mPosEntryM).Trim.PadLeft(3, "0")

            strTrack = ebNumTarj.Text.Split("=")
            ebNumTarj.Text = strTrack(0)
            strVencM = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)

            If oFacturaMgr.EsTarjetaBloqueada(ebNumTarj.Text.Trim) Then
                MessageBox.Show("La tarjeta ha sido bloqueada." & vbCr & "Es necesario pasar otra tarjeta", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Me.cmbPromocion.DataSource = Nothing
                'Me.cmbPromocion.Text = ""
                'Me.ebAutorizacion.Text = ""
                Band = False
                'If strPosEntry.Trim = "051" Then
                '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                'End If
                GoTo FinalManual
            ElseIf Me.EBPago.Value > oConfigCierreFI.MontoMaxTarjetas Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Me.cmbPromocion.DataSource = Nothing
                    'Me.cmbPromocion.Text = ""
                    Band = False
                    'If strPosEntry.Trim = "051" Then
                    '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    'End If
                    GoTo FinalManual
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            ElseIf oCatFormaPago.TarjetaUsadaHoy(Me.ebNumTarj.Text) OrElse BuscaTarjeta(Me.ebNumTarj.Text) = True Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                    MessageBox.Show("Es necesario la autorización del manager para continuar.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Me.cmbPromocion.DataSource = Nothing
                    'Me.cmbPromocion.Text = ""
                    Band = False
                    'If strPosEntry.Trim = "051" Then
                    '    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                    'End If
                    GoTo FinalManual
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            End If

            FillBancoPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), pagoTarj) 'Me.EBPago.Value)
            Me.cmbPromocion.Text = ""
FinalManual:
            If Band = False Then
                Me.cmbPromocion.DataSource = Nothing
                Me.cmbPromocion.Text = ""
                Me.ebAutorizacion.Text = ""
                Me.ebNumTarj.Text = ""
            End If
            If strPosEntry.Trim = "051" Then
                Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
            End If
        End If
Final:
        Return Band

    End Function

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.ASCII)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        Return strContenido

    End Function

    Private Function LeerCampo55(ByVal Ruta As String) As String

        Dim oStreamR As StreamReader
        Dim strContenido As String = ""

        oStreamR = New StreamReader(Ruta)

        strContenido = oStreamR.ReadToEnd

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub GenerarArchivoDatos(ByVal Ruta As String, ByVal monto As String, ByVal Tienda As String, _
                                    ByVal Caja As String, ByVal Cajero As String, ByVal cvv2 As String, _
                                    ByVal ticket As String)

        Dim oStreamW As StreamWriter
        Dim Datos As String = ""

        oStreamW = New StreamWriter(Ruta)

        Datos = monto & "|"
        Datos &= Tienda & "|"
        Datos &= Caja & "|"
        Datos &= Cajero & "|"
        Datos &= cvv2 & "|"
        Datos &= ticket

        oStreamW.Write(Datos)

        oStreamW.Close()

    End Sub

    Private Sub frmPago_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.dtFormasPago = dsFormasPago.Tables(0).Copy
        If bReintentoDPVL AndAlso Me.DialogResult <> DialogResult.OK Then
            If MessageBox.Show("Se detectó que ocurrió un error al realizar la venta DPVale. En este momento puedes reintentar guardar la venta." & vbCrLf & vbCrLf & "Si te sales ya no será posible realizar el reintento. ¿Deseas salir de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
        If Me.DialogResult <> DialogResult.OK Then
            '----------------------------------------------------------------------------------
            ' JNAVA 06/04/2014 - Validamos si se necesita caputar o no, los motivos de rechazo
            '----------------------------------------------------------------------------------
            CapturarMotivoRechazo()
        End If
    End Sub

    Private Sub ImprimirVoucherManual(ByVal mPosEntry As Integer)

        Dim bolReimpresion As Boolean = False
        Dim oReportView As New ReportViewerForm

Reimprimir:
        Select Case Me.ebCodBanco.Text.ToUpper

            Case "T3"
Imprime_Banamex:
                Dim oARReporte As New rptTicketBANAMEX(CDbl(EBPago.Text), Me.ebNumTarj.Text.Trim, strVencM, Me.ebAutorizacion.Text.Trim, _
                                                       Me.cmbPromocion.Text, "VENTA", strNombreM, oFactura.CodVendedor, _
                                                       strNoAfiliacion, EBBanco.Text, "ORIGINAL BANCO", strNombreM, strCriptogramaM, _
                                                       False, "", "", "", "")
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                'oARReporte.Document.Print(False, False)

                ''Copia Cliente
                Dim oARReporteC As New rptTicketBANAMEX(CDbl(EBPago.Text), ebNumTarj.Text.Trim, strVencM, ebAutorizacion.Text, _
                                                        Me.cmbPromocion.Text, "VENTA", strNombreM, oFactura.CodVendedor, _
                                                        strNoAfiliacion, EBBanco.Text, "COPIA CLIENTE", strNombreM, strCriptogramaM, _
                                                        False, "", "", "", "")
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                'oARReporteC.Document.Print(False, False)

                oReportView.Report = oARReporte
                oReportView.Show()

                oReportView = New ReportViewerForm
                oReportView.Report = oARReporteC
                oReportView.Show()

            Case "T1"

                Dim oARReporte As New rptTicketBancomer(CDbl(EBPago.Text), Me.ebNumTarj.Text, strVencM, _
                                                        Me.ebAutorizacion.Text, Me.cmbPromocion.Text, "VENTA", _
                                                        strNombreM, oFactura.CodVendedor, strNoAfiliacion, _
                                                        EBBanco.Text, "ORIGINAL BANCO", mPosEntry, True, False, _
                                                        strCriptogramaM, strNombreM)
                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporte.Run()
                oARReporte.Document.Print(False, False)

                'Copia Cliente
                Dim oARReporteC As New rptTicketBancomer(CDbl(EBPago.Text), ebNumTarj.Text, strVencM, _
                                                         Me.ebAutorizacion.Text, Me.cmbPromocion.Text, "VENTA", _
                                                         strNombreM, oFactura.CodVendedor, strNoAfiliacion, _
                                                         EBBanco.Text, "COPIA CLIENTE", mPosEntry, True, False, _
                                                         strCriptogramaM, strNombreM)
                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                oARReporteC.Run()
                oARReporteC.Document.Print(False, False)

                'oReportView.Report = oARReporte
                'oReportView.Show()

                'oReportView = New ReportViewerForm
                'oReportView.Report = oARReporteC
                'oReportView.Show()

            Case Else

                GoTo Imprime_Banamex

        End Select

        If bolReimpresion = False Then
            If MessageBox.Show("¿Desea reimpirmir los vouchers?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                bolReimpresion = True
                GoTo Reimprimir
            End If
        End If

    End Sub

    Private Function BuscaTarjeta(ByVal strNumTarj As String) As Boolean

        For Each oRow As DataRow In dsFormasPago.Tables(0).Rows

            If CStr(oRow!NumeroTarjeta).ToUpper = strNumTarj.ToUpper Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub EBPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBPago.ValueChanged

        If (Me.cmbFormaPago.Value = "TACR" OrElse Me.cmbFormaPago.Value = "TADB") AndAlso Me.ebTipoTarjeta.Text = "TM" Then
            Me.ebNumTarj.Text = ""
            Me.cmbPromocion.DataSource = Nothing
            Me.cmbPromocion.Text = ""
        End If

    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click

        Me.btnLeerTarjeta.Enabled = False
        '-----------------------------------------------------------------------------------------------
        'FLIZARRAGA 16/01/2017: Se valida si es por medio de Pagos Banamex por el cual saldra el cobro
        '-----------------------------------------------------------------------------------------------
        AutorizarCargoTarjeta()

        Me.btnLeerTarjeta.Enabled = True

    End Sub

    'Private Sub ebFolioValeCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolioValeCaja.KeyDown
    '    If e.Alt AndAlso e.KeyCode = Keys.T Then
    '        oAppContext.Security.CloseImpersonatedSession()
    '        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") Then
    '            Me.ebFolioValeCaja.ReadOnly = False
    '            Me.ebFolioValeCaja.Focus()
    '        End If
    '        oAppContext.Security.CloseImpersonatedSession()
    '    End If
    'End Sub

    Private Sub timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer1.Elapsed
        Me.lblCronometro.Text = Format(CDate(Me.lblCronometro.Text).AddSeconds(1), "HH : mm : ss")
    End Sub

    Private Sub EjecutaCronometro(ByVal bStart As Boolean)
        If bStart Then
            Me.lblCronometro.Text = strCrono
            Me.lblCronometro.Visible = True
            Me.timer1.Start()
        Else
            Me.lblCronometro.Text = "00 : 00 : 00"
            Me.lblCronometro.Visible = False
            Me.timer1.Stop()
        End If
    End Sub

    Private Sub ebNumTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarj.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case Me.cmbFormaPago.Value
                Case "DPCA"
                    If ValidacionLuhn(ebNumTarj.Text.Trim()) Then
                        FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.EBPago.Value))
                        Me.cmbPromocion.Text = ""
                        Me.cmbPromocion.Focus()
                        deslizada = False
                    End If
            End Select
        End If
    End Sub

    Private Sub ebNumTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumTarj.Validating
        If ebNumTarj.Text <> "" Then
            If Me.cmbFormaPago.Value = "DPCA" Then
                If ValidacionLuhn(ebNumTarj.Text.Trim()) Then
                    FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.EBPago.Value))
                    Me.cmbPromocion.Text = ""
                    Me.cmbPromocion.Focus()
                    deslizada = False

                    'MLVARGAS (11/11/2019): Si la tarjeta fué tecleada solicitar el motivo
                    If deslizada = False AndAlso Me.ebNumTarj.Text.Trim.Length = 16 Then
                        Dim frmMotivo As New frmMotivoCaptura()
                        frmMotivo.ShowDialog()
                        motivo = frmMotivo.strMotivo
                    End If

                End If
            End If
        End If
    End Sub



#End Region

#Region "Facturacion SiHay"

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2013: Función para imprimir los tickets de la Facturación SiHay uno para las etiquetas
    '----------------------------------------------------------------------------------------------------------------------------------

    Public Sub ActionPreviewSH(ByVal FacturaID As Integer, ByVal PedidoID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean, _
                             Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, _
                             Optional ByVal bReimpresion As Boolean = False)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        Dim dtDetalleExistencias As DataTable = IIf(DataSetSiHay.Tables.Contains("ArticulosConExistencia") = True, DataSetSiHay.Tables("ArticulosConExistencia"), Nothing)
        Dim dtDetalleSinExistencias As DataTable = IIf(DataSetSiHay.Tables.Contains("ArticulosSinExistencias") = True, DataSetSiHay.Tables("ArticulosSinExistencias"), Nothing)

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        If oFacturaMgr Is Nothing Then
            oFacturaMgr = New FacturaManager(oAppContext)
            If oFactura Is Nothing Then
                oFactura = oFacturaMgr.Create
                oFacturaMgr.Load(FacturaID, oAppContext.ApplicationConfiguration.NoCaja, oFactura)
            End If
        End If
        With orptDataInfo
            .PedidoID = PedidoID
            .FacturaID = FacturaID
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = intFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)

        Try
            'Validar que aparezca solo cuando el tipo de venta sea FONACOT
            'y que aparezca cuando sea la impresora HP
            If oConfigCierreFI.PrinterHP Then
                If TipoLeyenda = "" Then
                    If oFactura.CodTipoVenta = "F" Then
                        If Not oVC.ValeCajaID > 0 Then
                            If MessageBox.Show("¿Deseas imprimir HOJA FONACOT?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                Dim print_document As PrintDocument = PreparePrintDocument()
                                print_document.DocumentName = "HOJA FONACOT"
                                print_document.Print()
                            End If
                        End If

                    End If
                End If
            End If

            If oConfigCierreFI.MiniPrinter Then
                If dtDetalleExistencias.Rows.Count > 0 Then
                    Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                                             bReimpresion)
                    oARReporte.Document.Name = "Reporte Facturacion"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                    Dim oARViewer As New ReportViewerForm

                    'oARReporte.Run()

                    'oARReporte.Document.Print(False, False)
                    oARViewer.Report = oARReporte
                    oARViewer.Show()
                End If


                If dtDetalleSinExistencias.Rows.Count > 0 Then
                    Dim reporteSinExistencia As New ReporteFacturacion
                    reporteSinExistencia.ImprimirPedidoSH(orptDataInfo, dtDetalleSinExistencias, pdtGeneral, False, "PENDIENTE", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, bReimpresion)
                    reporteSinExistencia.Document.Name = "Reporte Facturacion"
                    reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                    Dim viewerSinExistencia As New ReportViewerForm

                    'oARReporte.Run()

                    'reporteSinExistencia.Document.Print(False, False)
                    Dim viewerEx As New ReportViewerForm
                    viewerEx.Report = reporteSinExistencia
                    viewerEx.Show()
                End If
                'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)                

                'viewerSinExistencia.Report = oARReporte
                'viewerSinExistencia.Show()

            Else
                pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
            End If

            If MessageBox.Show("¿Desea volver a imprimir esta factura?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                If oConfigCierreFI.MiniPrinter Then
                    If dtDetalleExistencias.Rows.Count > 0 Then
                        'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)
                        Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, True, "COPIA DE FACTURA", oConfigCierreFI.ImprimirCedula, "", _
                                                                 strQuin, bReimpresion)

                        oARReporte.Document.Name = "Reporte Facturacion"
                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        'oARReporte.Run()

                        oARReporte.Document.Print(False, False)

                        Dim oARViewer As New ReportViewerForm
                        oARViewer.Report = oARReporte
                        oARViewer.Show()
                    End If
                    If dtDetalleSinExistencias.Rows.Count > 0 Then
                        'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)
                        Dim oARReporteSinExistencia As New ReporteFacturacion(orptDataInfo, pdtGeneral, False, "COPIA PENDIENTE", oConfigCierreFI.ImprimirCedula, "", _
                                                                 strQuin, bReimpresion)

                        oARReporteSinExistencia.Document.Name = "Reporte Facturacion"
                        oARReporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        'oARReporte.Run()

                        oARReporteSinExistencia.Document.Print(False, False)

                        Dim viewerEx As New ReportViewerForm
                        viewerEx.Report = oARReporteSinExistencia
                        viewerEx.Show()
                    End If

                    'oarviewer.Report = oarreporte
                    'oarviewer.Show()

                Else
                    pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
                End If
            End If
            If TipoLeyenda = "" Then
                If oFactura.CodTipoVenta = "P" AndAlso oConfigCierreFI.UsarSccanerIFE = True Then
                    If MessageBox.Show("¿Desea capturar los datos del cliente?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Dim oForm As New frmClientes(pdtDetalles, pdtPagos, pdtGeneral, oAppContext.ApplicationConfiguration.Almacen)
                        oForm.ShowDialog()
                    End If
                End If
            End If


            orptDataInfo = Nothing

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa.", ex)

        End Try

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Función para imprimir los articulos Pendientes Por Entregar del Pedido
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub ActionPreviewPedidoSH(ByVal PedidoID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean, _
                             Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, _
                             Optional ByVal bReimpresion As Boolean = False)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        Dim dtDetalleSinExistencias As DataTable = IIf(DataSetSiHay.Tables.Contains("ArticulosSinExistencias") = True, DataSetSiHay.Tables("ArticulosSinExistencias"), Nothing)

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        With orptDataInfo
            .PedidoID = PedidoID
            .TipoVoucher = 1
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = intFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatosPedidoSH(orptDataInfo, pdtGeneral, pdtPagos, pdtNotas)

        Try
            'Validar que aparezca solo cuando el tipo de venta sea FONACOT
            'y que aparezca cuando sea la impresora HP
            If dtDetalleSinExistencias.Rows.Count > 0 AndAlso TipoLeyenda = "CANCELACION" Then
                Dim reporteSinExistencia As New ReporteFacturacion
                reporteSinExistencia.ImprimirPedidoSH(orptDataInfo, dtDetalleSinExistencias, pdtGeneral, False, "CANCELACION", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, bReimpresion)
                reporteSinExistencia.Document.Name = "Reporte Facturacion"
                reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                reporteSinExistencia.Document.Print(False, False)
            Else
                If oConfigCierreFI.PrinterHP Then
                    If TipoLeyenda = "" Then
                        If oFactura.CodTipoVenta = "F" Then
                            If Not oVC.ValeCajaID > 0 Then
                                If MessageBox.Show("¿Deseas imprimir HOJA FONACOT?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                    Dim print_document As PrintDocument = PreparePrintDocument()
                                    print_document.DocumentName = "HOJA FONACOT"
                                    print_document.Print()
                                End If
                            End If

                        End If
                    End If
                End If

                If oConfigCierreFI.MiniPrinter Then
                    If dtDetalleSinExistencias.Rows.Count > 0 Then
                        Dim reporteSinExistencia As New ReporteFacturacion
                        reporteSinExistencia.ImprimirPedidoSH(orptDataInfo, dtDetalleSinExistencias, pdtGeneral, False, "PENDIENTE", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, bReimpresion)
                        reporteSinExistencia.Document.Name = "Reporte Facturacion"
                        reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                        Dim viewerSinExistencia As New ReportViewerForm

                        'oARReporte.Run()

                        'reporteSinExistencia.Document.Print(False, False)
                        viewerSinExistencia.Report = reporteSinExistencia
                        viewerSinExistencia.Show()
                    End If

                    'pImprimir.ImprimirFacturaMiniPrinter("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta)                

                    'viewerSinExistencia.Report = oARReporte
                    'viewerSinExistencia.Show()

                Else
                    pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
                End If

                If MessageBox.Show("¿Desea volver a imprimir esta factura?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If oConfigCierreFI.MiniPrinter Then
                        If dtDetalleSinExistencias.Rows.Count > 0 Then
                            Dim reporteSinExistencia As New ReporteFacturacion
                            reporteSinExistencia.ImprimirPedidoSH(orptDataInfo, dtDetalleSinExistencias, pdtGeneral, False, "COPIA PENDIENTE", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, bReimpresion)
                            reporteSinExistencia.Document.Name = "Reporte Facturacion"
                            reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                            Dim viewerSinExistencia As New ReportViewerForm

                            'oARReporte.Run()

                            reporteSinExistencia.Document.Print(False, False)
                        End If

                        'oarviewer.Report = oarreporte
                        'oarviewer.Show()

                    Else
                        pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", True, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, False)
                    End If
                End If
                If TipoLeyenda = "" Then
                    If oFactura.CodTipoVenta = "P" AndAlso oConfigCierreFI.UsarSccanerIFE = True Then
                        If MessageBox.Show("¿Desea capturar los datos del cliente?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                            Dim oForm As New frmClientes(pdtDetalles, pdtPagos, pdtGeneral, oAppContext.ApplicationConfiguration.Almacen)
                            oForm.ShowDialog()
                        End If
                    End If
                End If
            End If
            orptDataInfo = Nothing

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa.", ex)

        End Try

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2013: Función que realiza el guardado de la factura en SQL Server y SAP para aplicar la promoción del SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Sub CerrarVentaSH(ByVal imprimir As Boolean)

        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then

            MsgBox("El Importe Total no ha sido cubierto. No puede guardar la Factura.  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")

        Else

            If FacturaIsSaved() Then
                MsgBox("La Factura ya ha sido guardada. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Forma de Pago")
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/04/2015: En caso de que DPCard Puntos este activado y sea una venta de una tarjeta DPCard Puntos
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim resultado As Hashtable
            Dim payment() As DataRow
            ReDim payment(-1)
            If oConfigCierreFI.DPCardPuntos = True Then
                Dim bResultCanje As Boolean = True
                If IsDPCardPunto() = True AndAlso IsDPCardPuntosRenewMembership() = False Then
                    If CapturaCliente() = False Then
                        MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                ElseIf IsDPCardPuntosRenewMembership() = True Then
                    ValidaRenewMembership()
                Else
                    payment = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
                    '---------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 16/04/2015: Se valida si es forma de Pago o solo se bonificaran puntos
                    '---------------------------------------------------------------------------------------------------------------
                    If payment.Length > 0 Then
                        '-----------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 25/04/2015: Valida si se canjearan puntos en factura normal o si hay
                        '-----------------------------------------------------------------------------------------------------------
                        Select Case Me.ModoVenta
                            Case 0
                                resultado = CanjearPuntos(bResultCanje)
                            Case 1
                                resultado = CanjearPuntosSiHay(bResultCanje)
                        End Select

                        If bResultCanje = False Then Exit Sub
                    End If
                End If
            End If

            Dim pedido As Pedidos = Nothing
            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
            'Dim factura As factura = Nothing
            Dim opciones As Hashtable
            '-----------------------------------------------------------------------------------------------------------------------------
            'Validamos si los codigos de la factura estan marcados como defectuosos para Ecommerce
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/05/2013: Se le resta la cantidad que haya habido en algun producto pendiente por surtir O Facturar
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oFactura.Detalle.Tables(0))
            If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "V", dtDefecECSAP) = False Then
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle de la factura
            '-----------------------------------------------------------------------------------------------------------------------------
            If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            'Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
            'If ValidarMaterialesNegadosSH(RestarCantidadesSiHay(oFactura.Detalle.Tables(0)), dtNegadosSH, "PF,P,RP") = False Then
            '    ShowFormNegadosSH(dtNegadosSH)
            '    Exit Sub
            'End If
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el tiempo de duración operativa y detenemos el cronómetro
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            Dim TiempoOperacion As String = Me.lblCronometro.Text
            EjecutaCronometro(False)
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (24.02.2016): Se comento por 1ue ya no se usara
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Realizamos el traspaso de saldo al cliente si en las formas de pago va algun vale de caja en caso de ser necesario
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'If RealizarTraspasoSaldos() = False Then
            '    MessageBox.Show("No fue posible realizar el traspaso de saldo al cliente " & oFactura.ClienteId & "." & vbCrLf & "No se guardó la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            If oFactura.CodTipoVenta = "V" Then
                oFactura.Referencia = "DPVL-" & CStr(oDpvaleSAP.IDDPVale)
            ElseIf EsInstanciaApartado = False Then
                oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyyyMMddHHmmss")
            End If
            If imprimir = False Then
                oFactura.Impresa = 0
            Else
                oFactura.Impresa = 1
            End If

            If Not oFactura.CodTipoVenta = "V" Then
                boolLaImprimo = False
                opciones = SavePedidoSH(oFactura)
                If opciones("Saved") = False Then
                    MessageBox.Show("No se pudo guardar el pedido surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                pedido = CType(opciones("Pedido"), Pedidos)
                pedido.Impresa = oFactura.Impresa
                pedidoId = pedido.PedidoID
                '-------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/05/2015: Actualiza el estado en la tabla de pedidos y el status en caso de ser un canjeo
                '-------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                    Dim dato As New Hashtable
                    dato("NoTarjeta") = CStr(resultado("CardId"))
                    dato("CodDPCardPunto") = "CAN"
                    IsRedeem = True
                    pedido.UpdateDPCardPuntos(pedido.PedidoID, dato)
                End If
                If DataSetSiHay.Tables.Contains("ArticulosMinimos") = True Then
                    pedido.ExistenciasMinimas = DataSetSiHay.Tables("ArticulosMinimos")
                End If
                If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                    factura = CreateFacturaDisponiblesSH()
                    SaveFacturaSH(factura, pedido)
                    '-------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 19/05/2015: Actualiza el estado en la tabla de pedidos y el status en caso de ser un canjeo
                    '-------------------------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                        Dim dato As New Hashtable
                        dato("NoTarjeta") = CStr(resultado("CardId"))
                        dato("CodDPCardPunto") = "CAN"
                        oFacturaMgr.ActualizaNoDPCardPuntos(factura.FacturaID, dato)
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    'Grabamos temporalmente los codigos de baja calidad que van en el detalle de la factura
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        For Each oRow As DataRow In dtDefectuososEC.Rows
                            oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oFactura.FolioFactura, oFactura.CodCaja, "FA")
                        Next
                    End If
                    'End If
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Revisamos el tiempo que dura guardando la factura en SAP
                    '----------------------------------------------------------------------------------------------------------------------------
                    Dim HoraSapIni As DateTime = Now
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Guardamos la factura en SAP
                    '----------------------------------------------------------------------------------------------------------------------------
                    'SaveFacturaSAP()
                    Dim MsgResult As DataTable, result As Boolean = False
                    If pedido.CodTipoVenta = "V" Then
                        '----------------------------------------------------------------------------------------------------------------------------
                        'JNAVA (27.10.2014): Obtenemos Datos que necesitamos del DPVALE para la venta
                        '----------------------------------------------------------------------------------------------------------------------------
                        Dim oVentaFacturaSAP As VentasFacturaSAP
                        oVentaFacturaSAP = SetVentaPedidoDPValeSAP(pedido.CodTipoVenta, oDpvaleSAP)
                        '----------------------------------------------------------------------------------------------------------------------------
                        result = pedido.SaveSAP(factura, MsgResult, oVentaFacturaSAP)
                    Else
                        result = pedido.SaveSAP(factura, MsgResult)
                    End If
                    If result = False Then
                        If Not MsgResult Is Nothing AndAlso MsgResult.Rows.Count > 0 Then
                            MessageBox.Show(GetMensajeErrorPedido(MsgResult), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.DialogResult = DialogResult.OK
                            Exit Sub
                        End If
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Calculamos el tiempo que duró guardando la factura en SAP y guardamos el tiempo obtenido y el tiempo de operación
                    '----------------------------------------------------------------------------------------------------------------------------
                    If TiempoOperacion.Trim <> "" AndAlso CLng(TiempoOperacion.Trim.Replace(":", "").Replace(" ", "")) > 0 AndAlso oFactura.FolioSAP.Trim <> "" Then oSAPMgr.ZRFC_INSERTA_TIEMPOS(oFactura.FolioSAP, "FA", TiempoOperacion.Trim.Replace(" ", ""), Format(CDate(Now.Subtract(HoraSapIni).ToString), "HH:mm:ss"))

                    If factura.FolioFISAP = String.Empty OrElse factura.FolioSAP = String.Empty OrElse factura.FolioFISAP = "0" OrElse factura.FolioSAP = "0" Then
                        'oFactura.FolioFISAP = factura.FolioFISAP
                        If factura.CodTipoVenta = "V" Then
                            MessageBox.Show("Por el momento no se puede facturar DPortenisVale", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'Posiblemente se haga un Revale para NC.
                            'Ver que ondas con  este codigo

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (15.07.2016): Valida DPVale
                            '----------------------------------------------------------------------------------------
                            Dim FirmaDistribuidor As Image = Nothing
                            Dim NombreDistribuidor As String = String.Empty
                            '----------------------------------------------------------------------------------------
                            Dim DPValeInfo As New DevolucionDPValeInfo()
                            If EsInstanciaNC Then
                                If Not oAppSAPConfig.DPValeSAP Then
                                    DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                    DPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                                    DPValeInfo.FechaExpedicion = Now
                                    DPValeInfo.FechaEntregado = Now
                                    DPValeInfo.FacturaId = 0
                                    DPValeInfo.MontoDPValeUtilizado = 0
                                    DPValeInfo.MontoDPValeP = 0
                                    DPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)

                                    owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                    'owsDPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                                    owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                                    owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                                    owsDPValeInfo.FacturaID = 0
                                    owsDPValeInfo.MontoUtilizado = 0
                                    owsDPValeInfo.MontoDPValeP = 0
                                    Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                                    owsDPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)
                                    PrintRevale(DPValeInfo, String.Empty, Nothing)
                                Else
                                    DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                    owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale

                                    Dim oDPVale As New cDPVale
                                    oDPVale.INUMVA = CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0")

                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                                    '----------------------------------------------------------------------------------------
                                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                                    ''-----------------------------------------------------
                                    '' JNAVA (11.04.2016): Valida DPVale en S2Credit
                                    ''-----------------------------------------------------
                                    'BuscarValeS2Credit(CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0"))

                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (14.07.2016): Valida DPVale
                                    '----------------------------------------------------------------------------------------
                                    If oConfigCierreFI.AplicarS2Credit Then
                                        oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                                    Else
                                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                    End If
                                    '----------------------------------------------------------------------------------

                                    Dim oRow As DataRow
                                    oRow = oDPVale.InfoDPVALE.Rows(0)
                                    DPValeInfo.DPValeOrigen = oRow("Orige")
                                    DPValeInfo.FechaExpedicion = Now
                                    DPValeInfo.FechaEntregado = Now
                                    DPValeInfo.FacturaId = 0
                                    DPValeInfo.MontoDPValeUtilizado = 0
                                    DPValeInfo.MontoDPValeP = 0
                                    DPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                                    'owsDPValeInfo.DPValeOrigen = oRow("Orige")
                                    owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                                    owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                                    owsDPValeInfo.FacturaID = 0
                                    owsDPValeInfo.MontoUtilizado = 0
                                    owsDPValeInfo.MontoDPValeP = 0
                                    Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                                    owsDPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                                    PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
                                End If
                            End If

                            Exit Sub
                        ElseIf factura.CodTipoVenta = "D" Then
                            MessageBox.Show("Por el momento no se puede facturar DIPS", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    '----------------------------------------------------------------------------------------------------
                    'Quemamos el cupon de descuento en caso de existir en SAP
                    '----------------------------------------------------------------------------------------------------
                    If Not oCuponDesc Is Nothing Then
                        Dim strFolioNew As String = ""
                        Dim pagos As DataTable = GetEnviosFormasPago()
                        Dim res As New Dictionary(Of String, Object)
                        RestService.Metodo = "pos/cupon"
                        res = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, pagos)
                        strFolioNew = CStr(res("SapZcupUtilCupon")("E_FOLIO"))
                        'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, factura.CodTipoVenta, factura.FolioSAP, strFolioNew, pagos)
                        oFacturaMgr.ActualizarCuponDetalle(factura.FacturaID, strFolioNew)
                        oFacturaMgr.ActualizarFolioCuponPedido(pedido.PedidoID, strFolioNew)
                    End If
                    'OJO
                    'Grabamos únicamente si el tipo de venta es "DPVALE"
                    If oFactura.CodTipoVenta = "V" Then
                        boolLaImprimo = True
                        opciones = SavePedidoSH(oFactura)
                        If opciones("Saved") = False Then
                            MessageBox.Show("No se pudo guardar el pedido surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        pedido = CType(opciones("Pedido"), Pedidos)
                        If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                            factura = CreateFacturaDisponiblesSH()
                            SaveFacturaSH(factura, pedido)
                        End If
                        'SaveFactura()
                    Else
                        '------------------------------------------------------------------------------------------------------------------------
                        'Quemamos el vale de empleado en caso de existir en SAP
                        '------------------------------------------------------------------------------------------------------------------------
                        If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                            oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, factura.FolioSAP)
                        End If
                        '------------------------------------------------------------------------------------------------------------------------
                        'Si no es DPVALE entonces actualizamos los folio SAP y FI validamos si me regreso folios SAP para la factura
                        '------------------------------------------------------------------------------------------------------------------------
                        If factura.FolioSAP.Trim <> String.Empty And factura.FolioFISAP.Trim <> String.Empty Then
                            '--------------------------------------------------------------------------------------------------------------------
                            'Actualizamos los folios SAP
                            '--------------------------------------------------------------------------------------------------------------------
                            oFacturaMgr.UpdateFolioSAP(factura)
                        End If
                        '------------------------------------------------------------------------------------------------------------------------
                        'Guardamos la relacion cliente-venta y la razon por la que rechazaron registrar los datos del cliente en caso de ser asi
                        '------------------------------------------------------------------------------------------------------------------------
                        'If oConfigCierreFI.UsarHuellas Then
                        '    oFactura.CodPlaza = oSAPMgr.Read_Plaza
                        '    If factura.FolioSAP.Trim <> "" AndAlso factura.CodTipoVenta = "P" AndAlso oFingerPrintMgr.SaveClienteVenta(factura) Then
                        '        oFacturaMgr.ActualizaStatusEnvioServerPG(factura.FolioSAP, 1)
                        '    End If
                        'End If
                        '------------------------------------------------------------------------------------------------------------------------
                        'Imprimimos la Factura
                        '------------------------------------------------------------------------------------------------------------------------
                        If factura.Impresa = True Then
                            '--------------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 15.11.2013: Se revisa si está activa la impresion termica de la miniprinter ara imprimirlo 1 vez mas para anexar 
                            'la copia al corte. Aqui no se valida el tipo de venta siempre imprime 1 copia mas si esta activa la config
                            '--------------------------------------------------------------------------------------------------------------------------
                            If oConfigCierreFI.MiniprinterTermica Then ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                            ActionPreviewFacturacionSH(factura.PedidoID, True, "Facturacion", True, "FACTURA", factura.Nquincenas)
                            'ActionPreviewSH(factura.FacturaID, factura.PedidoID, "Facturacion", True, "", factura.Nquincenas)
                        Else
                            ActionPreview2(factura.FacturaID, "Facturacion", True, "", factura.Nquincenas)
                        End If


                        Me.Cursor = Cursors.Default
                        'MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

                    End If
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Si se guardó correctamente la factura en SAP continuamos con el proceso de los pedidos del EC
                    '---------------------------------------------------------------------------------------------------------------------------
                    If factura.FolioSAP.Trim <> "" And factura.FolioFISAP.Trim <> "" Then
                        '-----------------------------------------------------------------------------------------------------------------------
                        'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario si esta activado el proceso de surtido para
                        'EC en la config
                        '-----------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.SurtirEcommerce Then
                            If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                                oSAPMgr.ZPOL_TRASL_NEGAR(factura.FolioSAP, "V", UserNameNiega, dtNegados)
                                ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                            End If
                        End If
                        '-----------------------------------------------------------------------------------------------------------------------
                        'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en la factura
                        '-----------------------------------------------------------------------------------------------------------------------
                        If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                            If oSAPMgr.ZPOL_DEFECTUOSOS_INS(factura.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
                                oFacturaMgr.BorrarCodigosBajaCalidad(factura.FolioFactura, factura.CodCaja, "FA")
                            End If
                        End If
                        MsgBox("El pedido y la Factura se guardaron satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
                    End If
                Else
                    If GuardarFormadePagoSH(pedido.PedidoID, Me.dsFormasPago) = True Then
                        Dim MsgResult As DataTable, result As Boolean = False
                        If pedido.CodTipoVenta = "V" Then
                            '----------------------------------------------------------------------------------------------------------------------------
                            'JNAVA (27.10.2014): Obtenemos Datos que necesitamos del DPVALE para la venta
                            '----------------------------------------------------------------------------------------------------------------------------
                            Dim oVentaFacturaSAP As VentasFacturaSAP
                            oVentaFacturaSAP = SetVentaPedidoDPValeSAP(pedido.CodTipoVenta, oDpvaleSAP)
                            '----------------------------------------------------------------------------------------------------------------------------
                            result = pedido.SaveSAP(factura, MsgResult, oVentaFacturaSAP)
                        Else
                            result = pedido.SaveSAP(factura, MsgResult)
                        End If
                        If result = False Then
                            If Not MsgResult Is Nothing AndAlso MsgResult.Rows.Count > 0 Then
                                MessageBox.Show(CStr(MsgResult.Rows(0)!MESSAGE) & " en la linea ", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                        If imprimir = True Then
                            ActionPreviewFacturacionSH(pedido.PedidoID, True, "Facturacion", True, "")
                            'ActionPreviewPedidoSH(pedido.PedidoID, "Facturacion", True, "")
                        End If

                        '----------------------------------------------------------------------------------------------------
                        'Quemamos el cupon de descuento en caso de existir en SAP
                        '----------------------------------------------------------------------------------------------------
                        If Not oCuponDesc Is Nothing Then
                            Dim strFolioNew As String = ""
                            Dim pagos As DataTable = GetEnviosFormasPago()
                            Dim res As New Dictionary(Of String, Object)
                            RestService.Metodo = "pos/cupon"
                            res = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, pagos)
                            strFolioNew = CStr(res("SapZcupUtilCupon")("E_FOLIO"))
                            'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, pedido.CodTipoVenta, pedido.FolioSAP, strFolioNew, pagos)
                            oFacturaMgr.ActualizarFolioCuponPedido(pedido.PedidoID, strFolioNew)
                        End If

                        '------------------------------------------------------------------------------------------------------------------------
                        'Quemamos el vale de empleado en caso de existir en SAP
                        '------------------------------------------------------------------------------------------------------------------------
                        If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                            oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, pedido.FolioSAP)
                        End If
                        MsgBox("El Pedido se guardó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
                    Else
                        MessageBox.Show("Hubo un error al guardar las formas de pago", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If

            '---------------------------------------------------------------------------------------------------------------------------
            'JNAVA - 09/11/2013: Generamos cupon si existe promocion de descuento proxima compra
            '---------------------------------------------------------------------------------------------------------------------------
            'RGEMAIN 08.07.2015: Generamos el cupon de promocion proxima compra solo si es la primera vez que compran con la tarjeta de
            '                    DPCard Credit
            '---------------------------------------------------------------------------------------------------------------------------
            If bPrimeraCompraKarum AndAlso oFactura.CodTipoVenta.Trim <> "D" Then CuponDescuentoProximaCompra(oFactura)

            bPrimeraCompraKarum = False
            '---------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 01/04/2015: Activamos o aplicamos puntos a DPCard Puntos 
            '---------------------------------------------------------------------------------------------------------------------------
            DPCardPuntos()

            '---------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2015: Se imprime el recibo de Canje
            '---------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                PrintTicketDPCardPuntos(resultado)
            End If

            '---------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Capturamos Cel del cliente solo si no esta activada la config
            '---------------------------------------------------------------------------------------------------------------------------
            CapturaCelParaSMS(oConfigCierreFI.PedirDatosPromoComienzo, False)

            Me.DialogResult = DialogResult.OK

        End If
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/05/2014: Actualiza el ScoreBoard siempre y cuando este configurado
        '------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ScoreBoard Then
            DashBoard.ShowAndUpdateScoreBoard()
        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/10/2014: Funcion de Cierre de ventas para ventas del Si Hay con DPVale
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Sub CerrarVentaSHDPVale(ByVal imprimir As Boolean)

        If ebTotalPagoCliente.Value < ebImporteTotal.Value Then

            MsgBox("El Importe Total no ha sido cubierto. No puede guardar la Factura.  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Forma de Pago")

        Else

            ValidaFormaPago()

            If FacturaIsSaved() Then
                MsgBox("La Factura ya ha sido guardada. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Forma de Pago")
                Exit Sub
            End If

            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Fonacot. Validamos que por lo menos tenga forma de pago FONACOT
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "F" Then
                If ValidarFormaPago("TFON") = False Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If ValidarFormaPago("FONA") = False Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FONACOT", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/09/2016: Validamos si la venta es Facilito. Validamos que por lo menos tenga forma de pago FACILITO
            '------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "O" Then
                If ValidarFormaPago("FACI") = False Then
                    MessageBox.Show("Debe de tener por lo menos una forma de pago FACILITO", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/04/2015: En caso de que DPCard Puntos este activado y sea una venta de una tarjeta DPCard Puntos
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim resultado As Hashtable
            Dim payment() As DataRow
            ReDim payment(-1)
            'If oConfigCierreFI.DPCardPuntos = True Then
            '    Dim bResultCanje As Boolean = True
            '    If IsDPCardPunto() = True AndAlso IsDPCardPuntosRenewMembership() = False Then
            '        If CapturaCliente() = False Then
            '            MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '            Return
            '        End If
            '    ElseIf IsDPCardPuntosRenewMembership() = True Then
            '        ValidaRenewMembership()
            '    Else
            '        payment = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
            '        '---------------------------------------------------------------------------------------------------------------
            '        'FLIZARRAGA 16/04/2015: Se valida si es forma de Pago o solo se bonificaran puntos
            '        '---------------------------------------------------------------------------------------------------------------
            '        If payment.Length > 0 Then
            '            '-----------------------------------------------------------------------------------------------------------
            '            'FLIZARRAGA 25/04/2015: Valida si se canjearan puntos en factura normal o si hay
            '            '-----------------------------------------------------------------------------------------------------------
            '            Select Case Me.ModoVenta
            '                Case 0
            '                    resultado = CanjearPuntos(bResultCanje)
            '                Case 1
            '                    resultado = CanjearPuntosSiHay(bResultCanje)
            '            End Select

            '            If bResultCanje = False Then Exit Sub

            '        End If
            '    End If
            'End If

            Dim pedido As Pedidos = Nothing
            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
            'Dim factura As factura = Nothing
            Dim opciones As Hashtable
            oFactura.Fecha = FechaSAP


            '-----------------------------------------------------------------------------------------------------------------------------
            'Validamos si los codigos de la factura estan marcados como defectuosos para Ecommerce
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/05/2013: Se le resta la cantidad que haya habido en algun producto pendiente por surtir O Facturar
            '-----------------------------------------------------------------------------------------------------------------------------

            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oFactura.Detalle.Tables(0))
            If ValidarMaterialesDefectuososEC(dtArticuloLibre, dtDefectuososEC, UserNameDesmarca, "V", dtDefecECSAP) = False Then
                Exit Sub
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle de la factura
            '-----------------------------------------------------------------------------------------------------------------------------
            If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
                Exit Sub
            End If

            '------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (10.02.2017): Validamos para desmarcar los codigos de baja calidad EC seleccionados en SAP
            '------------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                Dim strRes As String = String.Empty
                strRes = oSAPMgr.ZPOL_DEFECTUOSOS_INS(String.Empty, "DD", UserNameDesmarca, dtDefectuososEC)
                If strRes.Trim.ToUpper <> "Y" Then
                    Exit Sub
                Else
                    ' descargar articulos para poder validar
                End If
            End If


            '------------------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (20.07.2022): Se desmarcan los códigos de baja calidad en la base datos local
            '------------------------------------------------------------------------------------------------------------------------------
            If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                oFacturaMgr.DesmarcaBajaCalidad(dtDefectuososEC)
            End If

            '------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            'Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
            'If ValidarMaterialesNegadosSH(RestarCantidadesSiHay(oFactura.Detalle.Tables(0)), dtNegadosSH, "PF,P,RP") = False Then
            '    ShowFormNegadosSH(dtNegadosSH)
            '    Exit Sub
            'End If
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el tiempo de duración operativa y detenemos el cronómetro
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            Dim TiempoOperacion As String = Me.lblCronometro.Text
            EjecutaCronometro(False)
            ''--------------------------------------------------------------------------------------------------------------------------------------------------
            ''Realizamos el traspaso de saldo al cliente si en las formas de pago va algun vale de caja en caso de ser necesario
            ''--------------------------------------------------------------------------------------------------------------------------------------------------
            'If RealizarTraspasoSaldos() = False Then
            '    MessageBox.Show("No fue posible realizar el traspaso de saldo al cliente " & oFactura.ClienteId & "." & vbCrLf & "No se guardó la factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            If oFactura.CodTipoVenta = "V" Then
                If oDpvaleSAP.IDDPVale <> "" Then
                    oFactura.Referencia = "DPVL-" & CStr(oDpvaleSAP.IDDPVale).PadLeft(10, "0")
                Else
                    MessageBox.Show("El número de vale esta vacio. Favor de revisar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            ElseIf EsInstanciaApartado = False Then
                oFactura.Referencia = oAppContext.ApplicationConfiguration.Almacen.PadLeft(3, "0") & oAppContext.ApplicationConfiguration.NoCaja.Remove(0, 1) & Format(DateTime.Now, "yyMMddHHmmss")
            End If
            If imprimir = False Then
                oFactura.Impresa = 0
            Else
                oFactura.Impresa = 1
            End If
            '---------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 12/09/2018: Validamos que tenga formas de pagos
            '---------------------------------------------------------------------------------------------------------------
            If Me.dsFormasPago.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No hay formas de pagos en el pedido", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 23/11/2018: Se valida que la suma del detalle cuadre con la cabecera
            '------------------------------------------------------------------------------------------------------
            If ValidaTotalDetalleCabecera() = False Then
                MessageBox.Show("El total no coincide con la suma del detalle", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            'Grabamos primero en PRO si es cualquier tipo de ventas, excepto "DPVALE"
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            opciones = SavePedidoSH(oFactura, IIf(oFactura.CodTipoVenta = "V", True, False))
            pedido = CType(opciones("Pedido"), Pedidos)
            pedido.Impresa = oFactura.Impresa
            pedidoId = pedido.PedidoID
            '-------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2015: Actualiza el estado en la tabla de pedidos y el status en caso de ser un canjeo
            '-------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                Dim dato As New Hashtable
                dato("NoTarjeta") = CStr(resultado("CardId"))
                dato("CodDPCardPunto") = "CAN"
                IsRedeem = True
                pedido.UpdateDPCardPuntos(pedido.PedidoID, dato)
            End If
            If DataSetSiHay.Tables.Contains("ArticulosMinimos") = True Then
                pedido.ExistenciasMinimas = DataSetSiHay.Tables("ArticulosMinimos")
            End If
            If Not oFactura.CodTipoVenta = "V" Then
                boolLaImprimo = False
                If opciones("Saved") = False Then
                    MessageBox.Show("No se pudo guardar el pedido surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                    factura = CreateFacturaDisponiblesSH()
                    SaveFacturaSH(factura, pedido)
                    '-------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 19/05/2015: Actualiza el estado en la tabla de pedidos y el status en caso de ser un canjeo
                    '-------------------------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.DPCardPuntos = True AndAlso payment.Length > 0 Then
                        Dim dato As New Hashtable
                        dato("NoTarjeta") = CStr(resultado("CardId"))
                        dato("CodDPCardPunto") = "CAN"
                        oFacturaMgr.ActualizaNoDPCardPuntos(factura.FacturaID, dato)
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    'Grabamos temporalmente los codigos de baja calidad que van en el detalle de la factura
                    '--------------------------------------------------------------------------------------------------------------------------------------------------
                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        For Each oRow As DataRow In dtDefectuososEC.Rows
                            oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oFactura.FolioFactura, oFactura.CodCaja, "FA")
                        Next
                    End If
                Else
                    If Not (dtValeCaja Is Nothing) Then
                        ActualizaValeCaja()
                    End If
                End If
            End If
            If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                '----------------------------------------------------------------------------------------------------------------------------
                'Revisamos el tiempo que dura guardando la factura en SAP
                '----------------------------------------------------------------------------------------------------------------------------
                Dim HoraSapIni As DateTime = Now
                '----------------------------------------------------------------------------------------------------------------------------
                'Guardamos la factura en SAP
                '----------------------------------------------------------------------------------------------------------------------------
                'SaveFacturaSAP()
                Dim MsgResult As New DataTable
                Dim result As Boolean = False


                With MsgResult
                    .Columns.Add("MESSAGE", GetType(String))
                    .AcceptChanges()
                End With


                If pedido.CodTipoVenta = "V" Then
                    '----------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (27.10.2014): Obtenemos Datos que necesitamos del DPVALE para la venta
                    '----------------------------------------------------------------------------------------------------------------------------
                    Dim oVentaFacturaSAP As VentasFacturaSAP
                    oVentaFacturaSAP = SetVentaPedidoDPValeSAP(pedido.CodTipoVenta, oDpvaleSAP)
                    '----------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 03.11.2014: Creamos el objeto de factura para que realice correctamente solo la solicitud de las piezas que no 
                    'tuvieron inventario en la tienda
                    '----------------------------------------------------------------------------------------------------------------------------
                    factura = CreateFacturaDisponiblesSH()

                    result = pedido.SaveSAPRest(oFactura, MsgResult, oVentaFacturaSAP, DataSetSiHay.Tables("ArticulosConExistencia"), MontoSeguro)
                    'result = pedido.SaveSAP(oFactura, MsgResult, oVentaFacturaSAP, DataSetSiHay.Tables("ArticulosConExistencia"))
                    factura.FolioSAP = oFactura.FolioSAP
                    factura.FolioFISAP = oFactura.FolioFISAP
                Else
                    result = pedido.SaveSAPRest(oFactura, MsgResult, , , MontoSeguro)
                    oFactura.FacturaID = factura.FacturaID
                    factura.FolioSAP = oFactura.FolioSAP
                    factura.FolioFISAP = oFactura.FolioFISAP
                    'result = pedido.SaveSAP(oFactura, MsgResult)
                End If
                If result = False Then
                    If Not MsgResult Is Nothing AndAlso MsgResult.Rows.Count > 0 Then
                        MessageBox.Show(GetMensajeErrorPedido(MsgResult), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.DialogResult = DialogResult.OK
                        Exit Sub
                    End If
                Else
                    If oFactura.CodTipoVenta = "V" Then

                        '------------------------------------------------------------------------------------------------------------------------------
                        'MLVARGAS 20/09/2022: Se mueve la impresión del ticket del seguro después de la impresión de la venta
                        '------------------------------------------------------------------------------------------------------------------------------
                        'If oFactura.SeguroVidaSAPDPVL Then
                        '    Dim SeguroID As String = "1"
                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    ' Obtenemos el ID de la Venta en S2Credit
                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    VentaIdS2c = String.Empty
                        '    VentaIdS2c = oFactura.VentaS2CreditID

                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    ' Obtenemos los datos del Seguro de Vida
                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    ExtraerDatosSeguroS2Credit(VentaIdS2c, SeguroID)

                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    ' Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
                        '    '---------------------------------------------------------------------------------------------------------------------------
                        '    If Not DatosTicketSeguro Is Nothing Then
                        '        GuardarSeguroS2Credit(oDpvaleSAP)
                        '    End If
                        'End If
                        '--------------------------------------------------------------------------------------
                        'FLIZARRAGA 14/11/2017: Obtenemos la fecha del Amortización de compra
                        '--------------------------------------------------------------------------------------
                        Me.oDPVale = New cDPVale()
                        If IsNumeric(oDpvaleSAP.IDDPVale) Then
                            Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.PadLeft(10, "0")
                        Else
                            Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.Trim()
                        End If
                        Me.oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, Nothing)
                        Me.FechaPrimerPago = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
                        Me.FechaPrimerPago = GetFechaFechaPrimerPago(FechaPrimerPago)
                    End If
                End If
                '----------------------------------------------------------------------------------------------------------------------------
                'Calculamos el tiempo que duró guardando la factura en SAP y guardamos el tiempo obtenido y el tiempo de operación
                '----------------------------------------------------------------------------------------------------------------------------
                If TiempoOperacion.Trim <> "" AndAlso CLng(TiempoOperacion.Trim.Replace(":", "").Replace(" ", "")) > 0 AndAlso oFactura.FolioSAP.Trim <> "" Then oSAPMgr.ZRFC_INSERTA_TIEMPOS(oFactura.FolioSAP, "FA", TiempoOperacion.Trim.Replace(" ", ""), Format(CDate(Now.Subtract(HoraSapIni).ToString), "HH:mm:ss"))

                If factura.FolioSAP = String.Empty OrElse factura.FolioSAP = "0" Then

                    If factura.CodTipoVenta = "V" Then

                        '----------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (16.11.2016): No mostramos mensaje si está activo s2credit
                        '----------------------------------------------------------------------------------------------------------------------------
                        If Not oConfigCierreFI.AplicarS2Credit Then
                            MessageBox.Show("Por el momento no se puede facturar DPortenisVale", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        '----------------------------------------------------------------------------------------------------------------------------

                        'Posiblemente se haga un Revale para NC.
                        'Ver que ondas con  este codigo

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (15.07.2016): Valida DPVale S2Credit
                        '----------------------------------------------------------------------------------------
                        Dim FirmaDistribuidor As Image = Nothing
                        Dim NombreDistribuidor As String = String.Empty
                        '----------------------------------------------------------------------------------------
                        Dim DPValeInfo As New DevolucionDPValeInfo()
                        If EsInstanciaNC Then
                            If Not oAppSAPConfig.DPValeSAP Then
                                DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                DPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                                DPValeInfo.FechaExpedicion = Now
                                DPValeInfo.FechaEntregado = Now
                                DPValeInfo.FacturaId = 0
                                DPValeInfo.MontoDPValeUtilizado = 0
                                DPValeInfo.MontoDPValeP = 0
                                DPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)

                                owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                owsDPValeInfo.DPValeOrigen = oDevolucionDPValeInfo.DPValeID
                                owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                                owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                                owsDPValeInfo.FacturaID = 0
                                owsDPValeInfo.MontoUtilizado = 0
                                owsDPValeInfo.MontoDPValeP = 0
                                Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                                owsDPValeInfo.DPValeID = owsValidaDPVale.CreateReVale(owsDPValeInfo)
                                PrintRevale(DPValeInfo, String.Empty, Nothing)
                            Else
                                DPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale
                                owsDPValeInfo.MontoDPValeI = oDevolucionDPValeInfo.MontoDPVale

                                Dim oDPVale As New cDPVale
                                oDPVale.INUMVA = CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0")

                                '----------------------------------------------------------------------------------------
                                ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                                '----------------------------------------------------------------------------------------
                                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                                ''-----------------------------------------------------
                                '' JNAVA 11.04.2016): Valida DPVale en S2Credit
                                ''-----------------------------------------------------
                                'BuscarValeS2Credit(CStr(oDevolucionDPValeInfo.DPValeID).PadLeft(10, "0"))

                                '----------------------------------------------------------------------------------------
                                ' JNAVA (14.07.2016): Valida DPVale
                                '----------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
                                Else
                                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                                End If
                                '----------------------------------------------------------------------------------

                                Dim oRow As DataRow
                                oRow = oDPVale.InfoDPVALE.Rows(0)
                                DPValeInfo.DPValeOrigen = oRow("Orige")
                                DPValeInfo.FechaExpedicion = Now
                                DPValeInfo.FechaEntregado = Now
                                DPValeInfo.FacturaId = 0
                                DPValeInfo.MontoDPValeUtilizado = 0
                                DPValeInfo.MontoDPValeP = 0
                                DPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                                'owsDPValeInfo.DPValeOrigen = oRow("Orige")
                                owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                                owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                                owsDPValeInfo.FacturaID = 0
                                owsDPValeInfo.MontoUtilizado = 0
                                owsDPValeInfo.MontoDPValeP = 0
                                Me.vSobrante = oDevolucionDPValeInfo.MontoDPVale
                                owsDPValeInfo.DPValeID = oDevolucionDPValeInfo.DPValeID

                                PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
                            End If
                        End If
                    ElseIf factura.CodTipoVenta = "D" Then
                        MessageBox.Show("Por el momento no se puede facturar DIPS", "Error al GUARDAR en SAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                '----------------------------------------------------------------------------------------------------
                'Quemamos el cupon de descuento en caso de existir en SAP
                '----------------------------------------------------------------------------------------------------
                If Not oCuponDesc Is Nothing Then
                    Dim strFolioNew As String = ""
                    Dim pagos As DataTable = GetEnviosFormasPago()
                    Dim res As Dictionary(Of String, Object)
                    RestService.Metodo = "/pos/cupones"
                    res = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, pagos)
                    strFolioNew = CStr(res("SapZcupUtilCupon")("E_FOLIO"))
                    'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, factura.CodTipoVenta, factura.FolioSAP, strFolioNew, pagos)
                    oFacturaMgr.ActualizarCuponDetalle(factura.FacturaID, strFolioNew)
                    oFacturaMgr.ActualizarFolioCuponPedido(pedido.PedidoID, strFolioNew)
                End If
                'OJO
                'Grabamos únicamente si el tipo de venta es "DPVALE"
                If oFactura.CodTipoVenta = "V" Then
                    boolLaImprimo = True
                    pedido.Impresa = False
                    opciones("Saved") = pedido.Save()
                    If opciones("Saved") = False Then
                        MessageBox.Show("No se pudo guardar el pedido surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    factura.Nquincenas = Me.oDpvaleSAP.NUMDE
                    SaveFacturaSH(factura, pedido)
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Grabamos temporalmente los codigos de baja calidad que van en el detalle de la factura
                    '----------------------------------------------------------------------------------------------------------------------------
                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        For Each oRow As DataRow In dtDefectuososEC.Rows
                            oFacturaMgr.SaveCodigoBajaCalidad(CStr(oRow!Material), CStr(oRow!Talla), CInt(oRow!Cantidad), CStr(oRow!Motivo), oFactura.FolioFactura, oFactura.CodCaja, "FA")
                        Next
                    End If
                Else
                    '------------------------------------------------------------------------------------------------------------------------
                    'Quemamos el vale de empleado en caso de existir en SAP
                    '------------------------------------------------------------------------------------------------------------------------
                    If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                        oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, pedido.FolioSAP)
                    End If
                    '------------------------------------------------------------------------------------------------------------------------
                    'Si no es DPVALE entonces actualizamos los folio SAP y FI validamos si me regreso folios SAP para la factura
                    '------------------------------------------------------------------------------------------------------------------------
                    If factura.FolioSAP.Trim <> String.Empty And factura.FolioFISAP.Trim <> String.Empty Then
                        '--------------------------------------------------------------------------------------------------------------------
                        'Actualizamos los folios SAP
                        '--------------------------------------------------------------------------------------------------------------------
                        oFacturaMgr.UpdateFolioSAP(factura)
                    End If
                    '------------------------------------------------------------------------------------------------------------------------
                    'Guardamos la relacion cliente-venta y la razon por la que rechazaron registrar los datos del cliente en caso de ser asi
                    '------------------------------------------------------------------------------------------------------------------------
                    'If oConfigCierreFI.UsarHuellas Then
                    '    oFactura.CodPlaza = oSAPMgr.Read_Plaza
                    '    If factura.FolioSAP.Trim <> "" AndAlso factura.CodTipoVenta = "P" AndAlso oFingerPrintMgr.SaveClienteVenta(factura) Then
                    '        oFacturaMgr.ActualizaStatusEnvioServerPG(factura.FolioSAP, 1)
                    '    End If
                    'End If


                    '------------------------------------------------------------------------------------------------------------------------
                    'Imprimimos la Factura  SI HAY
                    '------------------------------------------------------------------------------------------------------------------------
                    If factura.Impresa = True Then
                        '--------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 15.11.2013: Se revisa si está activa la impresion termica de la miniprinter para imprimirlo 1 vez mas para anexar 
                        'la copia al corte. Aqui no se valida el tipo de venta siempre imprime 1 copia mas si esta activa la config
                        '--------------------------------------------------------------------------------------------------------------------------
                        Dim bReimprimir As Boolean = False  'Bandera para indicar si el usuario quiso reimprimir el pedido

                        If oConfigCierreFI.MiniprinterTermica Then ActionPreview(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)

                        bReimprimir = ActionPreviewFacturacionSH(factura.PedidoID, True, "Facturacion", True, "FACTURA", factura.Nquincenas, False, False)
                        'ActionPreviewSH(factura.FacturaID, factura.PedidoID, "Facturacion", True, "", factura.Nquincenas)

                        If bReimprimir Then
                            If oDpvaleSAP.ValeElectronico Then
                                ImprimeValeElectronico(oDpvaleSAP)
                            End If

                            ReeimpresionBanamex(ObtenerFormasPagoByFacturaID(factura.FacturaID))
                        End If
                    Else
                        ActionPreview2(factura.FacturaID, "Facturacion", True, "", factura.Nquincenas)
                    End If



                    Me.Cursor = Cursors.Default
                    'MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

                    End If
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Si se guardó correctamente la factura en SAP continuamos con el proceso de los pedidos del EC
                    '---------------------------------------------------------------------------------------------------------------------------
                    If factura.FolioSAP.Trim <> "" And factura.FolioFISAP.Trim <> "" Then
                        '-----------------------------------------------------------------------------------------------------------------------
                        'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario si esta activado el proceso de surtido para
                        'EC en la config
                        '-----------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.SurtirEcommerce Then
                            If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                                oSAPMgr.ZPOL_TRASL_NEGAR(factura.FolioSAP, "V", UserNameNiega, dtNegados)
                                ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                            End If
                        End If

                        '-----------------------------------------------------------------------------------------------------------------------
                        'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en la factura
                        '-----------------------------------------------------------------------------------------------------------------------
                        'If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        '    If oSAPMgr.ZPOL_DEFECTUOSOS_INS(factura.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC).Trim = "Y" Then
                        '        oFacturaMgr.BorrarCodigosBajaCalidad(factura.FolioFactura, factura.CodCaja, "FA")
                        '    End If
                        'End If
                        Me.Focus()
                        MsgBox("El pedido y la Factura se guardaron satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
                    End If
            Else
                    Dim MsgResult As New DataTable, result As Boolean = False
                    MsgResult.Columns.Add("MESSAGE", GetType(String))
                    MsgResult.AcceptChanges()

                    If pedido.CodTipoVenta = "V" Then
                        Try
                            '----------------------------------------------------------------------------------------------------------------------------
                            'JNAVA (27.10.2014): Obtenemos Datos que necesitamos del DPVALE para la venta
                            '----------------------------------------------------------------------------------------------------------------------------
                            Dim oVentaFacturaSAP As VentasFacturaSAP
                            oVentaFacturaSAP = SetVentaPedidoDPValeSAP(pedido.CodTipoVenta, oDpvaleSAP)
                            '----------------------------------------------------------------------------------------------------------------------------

1:                          result = pedido.SaveSAPRest(oFactura, MsgResult, oVentaFacturaSAP, , MontoSeguro)
                            '1:                      result = pedido.SaveSAP(oFactura, MsgResult, oVentaFacturaSAP)
2:                          If result Then
                                If oFactura.SeguroVidaSAPDPVL AndAlso oFactura.CodTipoVenta = "V" Then
                                    Dim SeguroID As String = "1"
                                    '---------------------------------------------------------------------------------------------------------------------------
                                    ' Obtenemos el ID de la Venta en S2Credit
                                    '---------------------------------------------------------------------------------------------------------------------------
                                    VentaIdS2c = String.Empty
                                    VentaIdS2c = oFactura.VentaS2CreditID

                                    '---------------------------------------------------------------------------------------------------------------------------
                                    ' Obtenemos los datos del Seguro de Vida
                                    '---------------------------------------------------------------------------------------------------------------------------
                                    ExtraerDatosSeguroS2Credit(VentaIdS2c, SeguroID)

                                    '---------------------------------------------------------------------------------------------------------------------------
                                    ' Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
                                    '---------------------------------------------------------------------------------------------------------------------------
                                    If Not DatosTicketSeguro Is Nothing Then
                                        GuardarSeguroS2Credit(oDpvaleSAP)
                                    End If
                                End If
                                '--------------------------------------------------------------------------------------
                                'FLIZARRAGA 14/11/2017: Obtenemos la fecha del Amortización de compra
                                '--------------------------------------------------------------------------------------
                                Me.oDPVale = New cDPVale()
                                If IsNumeric(oDpvaleSAP.IDDPVale) Then
                                    Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.PadLeft(10, "0")
                                Else
                                    Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.Trim()
                                End If
                                Me.oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, Nothing)
                                Me.FechaPrimerPago = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
                                Me.FechaPrimerPago = GetFechaFechaPrimerPago(FechaPrimerPago)
3:                              pedido.Impresa = False
4:                              opciones("Saved") = pedido.Save()
5:                              If opciones("Saved") = False Then
                                    MessageBox.Show("No se pudo guardar el pedido en la base de datos local surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If
6:                              If GuardarFormadePagoSH(pedido.PedidoID, Me.dsFormasPago) = False Then
                                    MessageBox.Show("Hubo un error al guardar las formas de pago", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If

                                If Not (dtValeCaja Is Nothing) Then
                                    ActualizaValeCaja()
                                End If

                            End If
                        Catch ex As Exception
                            EscribeLog(ex.ToString, "Error en el proceso de guardado DPVale. Linea " & Err.Erl)
                            Throw ex
                        End Try
                    ElseIf GuardarFormadePagoSH(pedido.PedidoID, Me.dsFormasPago) = True Then
                        result = pedido.SaveSAPRest(oFactura, MsgResult, , , MontoSeguro)
                        'result = pedido.SaveSAP(oFactura, MsgResult)
                    Else
                        MessageBox.Show("Hubo un error al guardar las formas de pago", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If result = False Then
                        If Not MsgResult Is Nothing AndAlso MsgResult.Rows.Count > 0 Then
                            MessageBox.Show(CStr(MsgResult.Rows(0)!MESSAGE), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.DialogResult = DialogResult.Cancel
                            Exit Sub
                        End If
                    End If
                    If imprimir = True Then
                        ' ES SOLO VENTA DE SI HAY (NO SE FACTURO NADA)
                        Dim bReimprimir As Boolean = False
                        bReimprimir = ActionPreviewFacturacionSH(pedido.PedidoID, True, "Facturacion", True, "", Me.oDpvaleSAP.NUMDE)

                        If bReimprimir Then
                            ReeimpresionBanamex(Me.dsFormasPago.Tables(0))
                        End If


                        'ActionPreviewPedidoSH(pedido.PedidoID, "Facturacion", True, "")
                    End If
                    '----------------------------------------------------------------------------------------------------
                    'Quemamos el cupon de descuento en caso de existir en SAP
                    '----------------------------------------------------------------------------------------------------
                    If Not oCuponDesc Is Nothing Then
                        Dim strFolioNew As String = ""
                        Dim pagos As DataTable = GetEnviosFormasPago()
                        Dim res As New Dictionary(Of String, Object)
                        RestService.Metodo = "/pos/cupones"
                        res = RestService.SapZcupUtilCupon(oCuponDesc.Folio, oFactura.CodTipoVenta, oFactura.FolioSAP, pagos)
                        strFolioNew = CStr(res("SapZcupUtilCupon")("E_FOLIO"))
                        'oSAPMgr.ZBAPI_QUEMA_CUPON_DESCUENTO(oCuponDesc.Folio, pedido.CodTipoVenta, pedido.FolioSAP, strFolioNew, pagos)
                        oFacturaMgr.ActualizarFolioCuponPedido(pedido.PedidoID, strFolioNew)
                    End If

                    '------------------------------------------------------------------------------------------------------------------------
                    'Quemamos el vale de empleado en caso de existir en SAP
                    '------------------------------------------------------------------------------------------------------------------------
                    If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                        oSAPMgr.ZBAPI_QUEMA_VALE_EMPLEADO(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, pedido.FolioSAP)
                    End If
                    Me.Focus()
                    MsgBox("El Pedido se guardó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
            End If
            '---------------------------------------------------------------------------------------------------------------------------
            'JNAVA - 09/11/2013: Generamos cupon si existe promocion de descuento proxima compra
            '---------------------------------------------------------------------------------------------------------------------------
            'RGEMAIN 08.07.2015: Generamos el cupon de promocion proxima compra solo si es la primera vez que compran con la tarjeta de
            '                    DPCard Credit
            '---------------------------------------------------------------------------------------------------------------------------
            If bPrimeraCompraKarum AndAlso oFactura.CodTipoVenta.Trim <> "D" Then CuponDescuentoProximaCompra(oFactura)
            bPrimeraCompraKarum = False

            '---------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (15.09.2016):: Revisamos si esta activo S2Credit como Validador
            '---------------------------------------------------------------------------------------------------------------------------
            'If oConfigCierreFI.AplicarS2Credit Then
            '    '---------------------------------------------------------------------------------------------------------------------------
            '    ' Validamos si realmente se genero el seguro de vida en S2Credit y solo asi guardamos e imprimimos el ticket del seguro de vida
            '    '---------------------------------------------------------------------------------------------------------------------------
            '    If oFactura.SeguroVidaSAPDPVL AndAlso oFactura.CodTipoVenta = "V" Then
            '        Dim SeguroID As String = "1"
            '        '---------------------------------------------------------------------------------------------------------------------------
            '        ' Obtenemos el ID de la Venta en S2Credit
            '        '---------------------------------------------------------------------------------------------------------------------------
            '        VentaIdS2c = String.Empty
            '        VentaIdS2c = oFactura.VentaS2CreditID

            '        '---------------------------------------------------------------------------------------------------------------------------
            '        ' Obtenemos los datos del Seguro de Vida
            '        '---------------------------------------------------------------------------------------------------------------------------
            '        ExtraerDatosSeguroS2Credit(VentaIdS2c, SeguroID)

            '        '---------------------------------------------------------------------------------------------------------------------------
            '        ' Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
            '        '---------------------------------------------------------------------------------------------------------------------------
            '        If Not DatosTicketSeguro Is Nothing Then
            '            GuardarSeguroS2Credit(oDpvaleSAP)
            '        End If
            '    End If
            'End If
            '-----------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 31/07/2017: Imprime pagare de vale electronico
            '-----------------------------------------------------------------------------------------------------------
            If oDpvaleSAP.ValeElectronico Then
                ImprimeValeElectronico(oDpvaleSAP)
            End If
            '---------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (16.02.2017): No hay activacion o bonificacion de DPCard Puntos en SH
            '---------------------------------------------------------------------------------------------------------------------------
            ''---------------------------------------------------------------------------------------------------------------------------
            ''FLIZARRAGA 01/04/2015: Activamos o aplicamos puntos a DPCard Puntos 
            ''---------------------------------------------------------------------------------------------------------------------------
            'DPCardPuntos()
            '---------------------------------------------------------------------------------------------------------------------------

            '---------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Capturamos Cel del cliente solo si no esta activada la config
            '---------------------------------------------------------------------------------------------------------------------------
            CapturaCelParaSMS(oConfigCierreFI.PedirDatosPromoComienzo, False)

            Me.DialogResult = DialogResult.OK

        End If
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/05/2014: Actualiza el ScoreBoard siempre y cuando este configurado
        '------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ScoreBoard Then
            DashBoard.ShowAndUpdateScoreBoard()
        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Función para Mostrar en un Message Box los articulos que fueron negados del SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Function MostrarMensajeNegadosSH(ByVal dtMaterialesNegados As DataTable)
        Dim msg As String = "Estos Articulos no alcanzan la existencia debido a que hay pendientes por Surtir o Facturar:" & vbCrLf
        For Each row As DataRow In dtMaterialesNegados.Rows
            Dim codigo As String = CStr(row!CodArticulo)
            Dim talla As String = CStr(row!Talla)
            Dim Pedido As Integer = CInt(row!Pedido)
            Dim existencia As Integer = CInt(row!Existencia)
            msg &= "Codigo: " & CStr(codigo) & " Existencias: " & CStr(existencia) & " Pedido: " & CStr(Pedido) & vbCrLf
        Next
        MessageBox.Show(msg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Muestra los articulos que fueron negados en el SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Sub ShowFormNegadosSH(ByVal dtMaterialesNegados As DataTable)
        Dim frmNegados As New frmMostrarMensajeArticulos
        frmNegados.Source = dtMaterialesNegados
        frmNegados.lblMensaje.Text = "Articulos Negados porque estan pendientes por surtir o Facturar"
        frmNegados.SetAttributesColumnsGrid(GetAtributosMensajesSH())
        frmNegados.Show()
    End Sub


    Public Sub ShowFormNegadosExistencias(ByVal dtMaterialesNegados As DataTable)
        Dim frmNegados As New frmMostrarMensajeArticulos
        frmNegados.Text = "Artículos"
        frmNegados.Source = dtMaterialesNegados
        frmNegados.lblMensaje.Text = "Articulos Negados por falta de Existencias"
        frmNegados.SetAttributesColumnsGrid(GetAtributosMensajesSH())
        frmNegados.Show()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Obtiene los atributos del grid donde se muestran los Articulos Negados
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Function GetAtributosMensajesSH() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Talla"
        row("Ancho") = 67
        row("Texto") = "Talla"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Pedido"
        row("Ancho") = 67
        row("Texto") = "Pedido"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Existencia"
        row("Ancho") = 81
        row("Texto") = "Existencia"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/04/2013: Funcion que obtendra los articulos que se vayan a facturar
    '----------------------------------------------------------------------------------------------------------------------------------
    Private Function CrearDataTablePedidoFacturaSH(ByVal detalle As DataTable) As DataTable
        Dim dtPedidoAFacturar As DataTable = detalle.Clone()
        For Each row As DataRow In detalle.Rows
            If CInt(row!SinExistencia) = 0 Then
                dtPedidoAFacturar.ImportRow(row)
            End If
        Next
        Return dtPedidoAFacturar
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2013: Funcion para guardar la factura por medio de la venta "SiHay"
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Sub SaveFacturaSH(ByRef oFactura As Factura, ByVal Pedido As Pedidos)

        Me.Cursor = Cursors.WaitCursor
        oFactura.PedidoID = Pedido.PedidoID
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 10/06/2013: Se obtiene la fecha del servidor SAP, para no guardar con la fecha local de la pc
        '--------------------------------------------------------------------------------------------------------------------------------------
        oFactura.Fecha = oSAPMgr.MSS_GET_SY_DATE_TIME

        If GuardarFacturaSH(oFactura) Then
            'guardamos los motivos de captura manual

            If GuardarFacturaCorridaSH(oFactura) Then

                If GuardarFormadePagoSH(Pedido.PedidoID, dsFormasPago) Then

                    'Actualizamos DPVale
                    If oFactura.CodTipoVenta = "V" Then

                        If Not oAppSAPConfig.DPValeSAP Then
                            ActualizaDPVale()
                            'If Not EsInstanciaNC Then   'Es una factura nueva por lo tanto tenemos que meterle su FI
                            GuardaFIDocumentWS() 'Guardamos FIDocument de la venta DPVale
                            'End If

                        Else

                            ActualizaDPValeSAP()

                        End If
                        '-----------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 09.06.2015: Se comento porque ahora se obtienen los datos del seguro antes de guardar la factura en SAP
                        '-----------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (12.02.2015): Si es Revale, no hacemos nada del seguro
                        '-----------------------------------------------------------------------------------
                        'DatosTicketSeguro.Clear()
                        'If Not Me.oDpvaleSAP.IsRevale AndAlso Not Me.oDpvaleSAP.IsReRevale Then
                        '    '-----------------------------------------------------------------------------------
                        '    ' JNAVA (12.02.2015): Preparamos los datos para el ticket de Seguro
                        '    '---------------------------------------------------------------------------------------------------------------
                        '    'RGERMAIN 14.05.2015: Validamos que realmente se haya generado el seguro de vida en SAP para obtener los datos
                        '    '---------------------------------------------------------------------------------------------------------------
                        '    If oConfigCierreFI.GenerarSeguro AndAlso oFactura.SeguroVidaSAPDPVL Then
                        '        '-----------------------------------------------------------------------------------
                        '        ' Obtenemos los datos del seguro
                        '        '-----------------------------------------------------------------------------------
                        '        DatosTicketSeguro = PrepararDatosTicket(Me.oDpvaleSAP.IDCliente, Me.oDpvaleSAP.NUMDE, Me.oDpvaleSAP.FechaCobro, oFactura.CodTipoVenta)
                        '        If DatosTicketSeguro Is Nothing OrElse DatosTicketSeguro.Count <= 0 Then
                        '            MessageBox.Show("Ocurrio un error al obtener los datos del Financiamiento del Seguro." & vbCrLf & "No existe la configuracion de seguros de vida para esta plaza.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '            EscribeLog("No existe la configuracion de seguros de vida para la plaza " & oAppSAPConfig.Plaza.Trim, "Ocurrio un error al obtener los datos del Financiamiento del seguro de vida")
                        '        End If
                        '    End If
                        'End If

                    End If

                    'Insertamos Vale de Descuento Utilizado
                    'If vCodTipoDescuento = "DVD" Then           'HACK: @ngulo - Verificar el manejo de Vales de Descuento en SAP
                    '    'Quemar Vales de Descuento Empleado
                    '    Dim strStatusVale, strPorcentaje As String
                    '    QuemaValeEmpleadoSAP(oValeDescuentoLocalInfo.FolioVale, strStatusVale, strPorcentaje)
                    'End If

                    'Actualizamos Vales de Caja
                    If Not (dtValeCaja Is Nothing) Then
                        ActualizaValeCaja()
                        'If Not oVC.ValeCajaID > 0 Then
                        '    MsgBox("Se Imprimirá Factura ponga el papel correspondiente por Favor. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturación")
                        'End If

                    End If

                    If boolLaImprimo = True Then

                        If oFactura.Impresa = True Then
                            'ActionPreviewSH(oFactura.FacturaID, "Facturacion", True, "", oFactura.Nquincenas)
                            ActionPreviewFacturacionSH(oFactura.PedidoID, True, "Facturacion", True, "Factura".ToUpper, oFactura.Nquincenas)
                        Else
                        End If

                        Me.Cursor = Cursors.Default
                        'MsgBox("La Factura se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

                    End If

                    'AQUI


                    If oFactura.SeguroVidaSAPDPVL Then
                        Dim SeguroID As String = "1"
                        '---------------------------------------------------------------------------------------------------------------------------
                        ' Obtenemos el ID de la Venta en S2Credit
                        '---------------------------------------------------------------------------------------------------------------------------
                        VentaIdS2c = String.Empty
                        VentaIdS2c = oFactura.VentaS2CreditID

                        '---------------------------------------------------------------------------------------------------------------------------
                        ' Obtenemos los datos del Seguro de Vida
                        '---------------------------------------------------------------------------------------------------------------------------
                        ExtraerDatosSeguroS2Credit(VentaIdS2c, SeguroID)

                        '---------------------------------------------------------------------------------------------------------------------------
                        ' Validamos que se vaya a generar seguro (Si no se cargaron los datos del Ticket, no se Genero seguro
                        '---------------------------------------------------------------------------------------------------------------------------
                        If Not DatosTicketSeguro Is Nothing Then
                            GuardarSeguroS2Credit(oDpvaleSAP)
                        End If
                    End If


                End If

            Else

                Me.Cursor = Cursors.Default
                MsgBox("ERROR. Corrida y Forma de Pago no se guardaron. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "  Facturación")

            End If

        Else

            Me.Cursor = Cursors.Default
            MsgBox("ERROR. La Factura no ha sido guardada.   ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "  Facturación")

        End If
        '------------------------------------------------------------------------------------------------
        'FLIZARRAGA 08/03/2018: Se actualiza la factura cuando la acumulación procede de una activación.
        '------------------------------------------------------------------------------------------------
        If Activacion Then
            oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, DatosPuntoFactura)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ExtraerDatosSeguroDeVidaDPVL()

        '--------------------------------------------------------------------------------------------------------------------------------
        'JANVA  (08.08.2016): Si esta activo el S2Credit, no hace nada aqui y se sale
        '--------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            Exit Sub
        End If

        '-----------------------------------------------------------------------------------
        ' JNAVA (12.02.2015): Si es Revale, no hacemos nada del seguro
        '-----------------------------------------------------------------------------------
        DatosTicketSeguro.Clear()
        If Me.oDpvaleSAP.IsRevale = False Then
            '---------------------------------------------------------------------------------------------------------------
            ' JNAVA (12.02.2015): Preparamos los datos para el ticket de Seguro
            '---------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarSeguro Then
                '-----------------------------------------------------------------------------------
                ' Obtenemos los datos del seguro
                '-----------------------------------------------------------------------------------
                DatosTicketSeguro = PrepararDatosTicket(Me.oDpvaleSAP.IDCliente, Me.oDpvaleSAP.NUMDE, Me.oDpvaleSAP.FechaCobro, oFactura.CodTipoVenta)
                If DatosTicketSeguro Is Nothing OrElse DatosTicketSeguro.Count <= 0 Then
                    MessageBox.Show("Ocurrio un error al obtener los datos del Financiamiento del Seguro." & vbCrLf & "No existe la configuracion de seguros de vida para esta plaza.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog("No existe la configuracion de seguros de vida para la plaza " & oAppSAPConfig.Plaza.Trim, "Ocurrio un error al obtener los datos del Financiamiento del seguro de vida")
                End If
            End If
        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2013: Guarda la factura del modo de venta "SiHay"
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Function GuardarFacturaSH(ByRef oFactura As Factura) As Boolean

        GuardarFacturaSH = False

        'If dsFormasPago.Tables(0).Rows(0).Item("CodFormasPago") = "C" Then
        '    oFactura.CodTipoVenta = "C"
        'End If

        If Me.boolEsCredito Then
            oFactura.Saldo = Me.oFactura.Total
        Else
            oFactura.Saldo = 0
        End If
        oFacturaMgr.SaveFacturaPedidoSH(oFactura)
        'oFacturaMgr.Save(oFactura)
        If oFactura.FacturaID > 0 Then
            If EsInstanciaApartado Then
                'Marcamos el Apartado como Entregado
                oFacturaMgr.UPdateApartadoEntregado(oFactura.ApartadoID)
            End If

            If Not oFactura.dtMotivos Is Nothing Then
                For Each orow As DataRow In oFactura.dtMotivos.Rows
                    oFacturaMgr.SaveMotivo(oFactura.FacturaID, orow("Tienda"), orow("Articulo"), orow("Talla"), orow("IdMotivo"), "VTA")
                Next
            End If
            '-----------------------------------------------------------------------------------------------------------------------
            'Guardamos el vale de empleado utilizado en la factura en caso que existiera
            '-----------------------------------------------------------------------------------------------------------------------
            'If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
            '    oFacturaMgr.SaveValeEmpleado(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, oFactura.FacturaID)
            'End If
            '-----------------------------------------------------------------------------------------------------------------------
            'Guardamos el cupon de descuento utilizado en la factura en caso de llevar
            '-----------------------------------------------------------------------------------------------------------------------
            If Not oCuponDesc Is Nothing Then
                oFacturaMgr.SaveCuponDescuento(oCuponDesc.Folio, oFactura.FacturaID)
            End If

            Return True
        End If

    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2013: Guarda Facturas Corrida en modo de Venta "SiHay"
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Function GuardarFacturaCorridaSH(ByRef oFactura As Factura) As Boolean

        GuardarFacturaCorridaSH = False

        If oFactura.FacturaID > 0 Then
            'Grabamos Factura Corrida
            For Each row As DataRow In Me.DataSetSiHay.Tables("ArticulosConExistencia").Rows
                If CStr(row!CodArticulo) <> "" AndAlso CInt(row!Cantidad) > 0 AndAlso CDec(row!PrecioUnitario) > 0 Then

                    oArticulo.ClearFields()

                    oCatalogoArticuloMgr.LoadInto(CStr(row!CodArticulo), oArticulo)
                    oFacturaCorrida.Clearfields()

                    'Asignamos Campos Corrida

                    oFacturaCorrida.FacturaID = oFactura.FacturaID
                    oFacturaCorrida.CodArticulo = CStr(row!CodArticulo)
                    oFacturaCorrida.Cantidad = CDec(row!Cantidad)
                    oFacturaCorrida.Numero = CStr(row!Numero)
                    oFacturaCorrida.CostoUnitario = oArticulo.CostoProm
                    oFacturaCorrida.PrecioUnitario = CDec(row!PrecioUnitario)
                    oFacturaCorrida.PrecioOferta = oArticulo.PrecioOferta
                    oFacturaCorrida.Total = CDec(row!Total)

                    '--CodTipoDescuento (DMA, DPO, DPE, etc) y Descuento sera el Adicional
                    If CDec(row!Adicional) > 0 Then

                        'oFacturaCorrida.CodTipoDescuento = vCodTipoDescuento
                        oFacturaCorrida.CodTipoDescuento = CStr(row!Condicion)
                    Else
                        oFacturaCorrida.CodTipoDescuento = ""
                    End If
                    oFacturaCorrida.Descuento = CDec(row!Adicional)

                    '--DescuentoSistema y CantDescuentoSistema se cargan con la Condicion De Venta SAP / o con DPesos
                    '--oFacturaCorrida.DescuentoSistema = oArticulo.Descuento
                    '--oFacturaCorrida.CantDescuentoSistema = Decimal.Round((oArticulo.Descuento / 100) * oArticulo.PrecioVenta, 2)
                    oFacturaCorrida.DescuentoSistema = CondicionVenta_Porcentaje()
                    oFacturaCorrida.CantDescuentoSistema = CDec(row!CantDescuentoSistema)

                    'oFacturaCorridaMgr.Save(oFacturaCorrida)
                    Dim valido As Boolean = oFacturaCorridaMgr.Save(oFacturaCorrida)
                    If valido = False Then
                        Return False
                    End If

                    'Guardamos Movimiento del Articulo
                    If EsInstanciaApartado Then
                        FillDataMovimiento((CDec(row!Cantidad) * -1))    'HACK: @ngulo Verificar si esta linea no produce negativos
                    Else
                        FillDataMovimiento(0)
                    End If

                    Dim oRow As DataRow
                    Dim tMontoNC As Decimal = 0, tCostNC As Decimal = 0
                    Dim dsMultU As DataSet, drMultU As DataRow
                    tMontoNC = 0
                    tCostNC = 0
                    For Each oRow In dsFormasPago.Tables(0).Rows
                        'Si la Forma de Pago es Vale de Caja
                        If oRow!CodFormasPago = "VCJA" Then
                            tMontoNC = tMontoNC + oRow!MontoPago
                            dsMultU = oFacturaCorridaMgr.CostNC(oRow!DPValeID)
                            For Each drMultU In dsMultU.Tables(0).Rows
                                If Not IsDBNull(drMultU!CostNC) Then
                                    tCostNC = tCostNC + drMultU!CostNC
                                End If
                            Next
                            dsMultU = Nothing
                        End If
                    Next

                    tMontoNC = tMontoNC / (1 + oAppContext.ApplicationConfiguration.IVA)
                    oFacturaCorridaMgr.SaveMovimiento(oFactura.Total, oFacturaCorrida, tMontoNC, tCostNC)

                End If
            Next
            Return True
        End If
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2013: Guarda las formas pagos del modo Venta "SiHay" en la base de datos local
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Function GuardarFormadePagoSH(ByVal PedidoID As Integer, ByRef dsFormasPago As DataSet) As Boolean

        GuardarFormadePagoSH = False

        If PedidoID > 0 Then

            'Grabamos Factura Forma de Pago

            Dim nReg As Integer, nFil As Integer
            Dim tMontoCredito As Decimal
            tMontoCredito = 0

            nReg = dsFormasPago.Tables(0).Rows.Count - 1

            For nFil = 0 To nReg

                With dsFormasPago.Tables(0).Rows(nFil)

                    oFacturaFormaPago.ClearFields()

                    If .Item("CodFormasPago") = "EFEC" And ebCambioCliente.Value > 0 Then
                        .Item("MontoPago") = .Item("MontoPago") - ebCambioCliente.Value
                        ebTotalPagoCliente.Value = ebTotalPagoCliente.Value - ebCambioCliente.Value
                    End If

                    'Asignamos Campos Forma de Pago
                    oFacturaFormaPago.PedidoID = PedidoID
                    oFacturaFormaPago.FacturaID = 0
                    oFacturaFormaPago.DPValeID = .Item("DPValeID")
                    oFacturaFormaPago.FormaPagoID = .Item("CodFormasPago")
                    oFacturaFormaPago.BancoID = .Item("CodBanco")
                    oFacturaFormaPago.TipoTarjetaID = .Item("CodTipoTarjeta")
                    oFacturaFormaPago.NumeroTarjeta = .Item("NumeroTarjeta")
                    oFacturaFormaPago.NumeroAutorización = .Item("NumeroAutorizacion")
                    oFacturaFormaPago.NotaCreditoID = .Item("NotaCreditoID")
                    oFacturaFormaPago.ComisionBancaria = .Item("ComisionBancaria")
                    oFacturaFormaPago.IngresoComision = .Item("IngresoComision")
                    oFacturaFormaPago.IVAComision = .Item("IVAComision")
                    oFacturaFormaPago.Monto = .Item("MontoPago")
                    oFacturaFormaPago.NoAfiliacion = .Item("NoAfiliacion")
                    oFacturaFormaPago.Promocion = .Item("Id_Num_Promo")

                    oFacturaFormaPago.SavePedidoSH()

                    'Si la Forma de Pago es Credito (C)
                    'If .Item("CodFormasPago") = "CRED" Then
                    '    tMontoCredito = tMontoCredito + .Item("MontoPago")
                    'End If

                End With

            Next
            Return True

        End If

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Guardar el Pedido y sus detalles de la venta "SiHay"
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function SavePedidoSH(ByVal factura As Factura, Optional ByVal IsDPVale As Boolean = False) As Hashtable
        Dim opciones As New Hashtable
        Dim oPedido As New Pedidos
        Dim ArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim articulo As Articulo = ArticuloMgr.Create()
        oPedido.ClienteID = IIf(factura.CodTipoVenta.Trim() = "P", "10000000".PadLeft(10, "0"), factura.ClienteId.ToString().PadLeft(10, "0"))
        oPedido.ClientePGID = factura.ClientPGID
        oPedido.CodAlmacen = factura.CodAlmacen
        oPedido.CodCaja = factura.CodCaja
        oPedido.CodTipoVenta = factura.CodTipoVenta
        oPedido.CodVendedor = factura.CodVendedor
        oPedido.DescTotal = factura.DescTotal
        oPedido.DPesos = factura.DPesos
        oPedido.Fecha = oSAPMgr.MSS_GET_SY_DATE_TIME()
        oPedido.Impresa = False
        oPedido.IVA = factura.IVA
        oPedido.NumeroFacilito = oFactura.NumeroFacilito
        oPedido.Status = "GRA"
        oPedido.StatusRegistro = oFactura.StatusRegistro
        oPedido.SubTotal = oFactura.SubTotal
        oPedido.Total = oFactura.Total
        oPedido.SerialId = oFactura.SerialId
        oPedido.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
        If oFactura.CodTipoVenta = "V" Then
            oPedido.Referencia = oFactura.Referencia
        ElseIf EsInstanciaApartado = False Then
            oPedido.Referencia = oFactura.Referencia
        End If
        If oFactura.CodTipoVenta = "E" AndAlso vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
            oPedido.ValeEmpleado = oValeDescuentoLocalInfo.Serie & "|" & oValeDescuentoLocalInfo.FolioVale
        Else
            oPedido.ValeEmpleado = ""
        End If
        oPedido.ValeEmpleado = ""
        oPedido.NewFolio()
        If oFactura.Detalle.Tables(0).Rows.Count > 0 Then
            ReDim oPedido.PedidosDetalles(oFactura.Detalle.Tables(0).Rows.Count - 1)
        End If
        Dim index As Integer = 0
        For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
            Dim detalle As New PedidoDetalles
            articulo.ClearFields()
            ArticuloMgr.LoadInto(CStr(row!Codigo), articulo)
            detalle.CodArticulo = CStr(row!Codigo)
            detalle.Cantidad = CDec(row!Cantidad)
            detalle.Numero = CStr(row!Talla)
            detalle.CostoUnit = articulo.CostoProm
            detalle.PrecioUnit = CDec(row!Importe)
            detalle.PrecioOferta = oArticulo.PrecioOferta
            detalle.Total = CDec(row!Total)
            detalle.Fecha = Date.Today
            detalle.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
            detalle.StatusRegistro = True
            detalle.Condicion = GetCondicionArticulo(detalle.CodArticulo, detalle.Numero)
            '--CodTipoDescuento (DMA, DPO, DPE, etc) y Descuento sera el Adicional
            If CInt(row!Adicional) > 0 Then
                detalle.CodTipoDescuento = CStr(row!Condicion)
            Else
                detalle.CodTipoDescuento = ""
            End If
            detalle.Descuento = CDec(row!Adicional)
            detalle.DescuentoSistema = CondicionVenta_Porcentaje()
            detalle.CantDescuentoSistema = CDec(row!Descuento)
            oPedido.PedidosDetalles(index) = detalle
            index += 1
        Next
        If IsDPVale = False Then
            opciones("Saved") = oPedido.Save()
            If oPedido.PedidoID > 0 Then
                '-----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/07/2017: Guardamos el vale de empleado utilizado en el pedido en caso que existiera
                '-----------------------------------------------------------------------------------------------------------------------
                If vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                    oFacturaMgr.SaveValeEmpleadoPedido(oValeDescuentoLocalInfo.FolioVale, oValeDescuentoLocalInfo.Serie, oPedido.PedidoID)
                End If
                oFacturaMgr.SaveSerial(oPedido.SerialId, "W", oFactura.CodVendedor, 0, 0, oPedido.PedidoID)
            Else
                oFacturaMgr.SaveSerial(oPedido.SerialId, "E", oFactura.CodVendedor, 0, 0, 0)
            End If
        Else
            oPedido.CargarFormasPagoDPVale(Me.dsFormasPago, ebCambioCliente.Value)
            opciones("Saved") = False
        End If
        'opciones("Saved") = oPedido.Save()
        opciones("Pedido") = oPedido
        Return opciones
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Resta las cantidades del pedido "SiHay"
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function RestarCantidadesSiHay(ByVal dtMateriales As DataTable) As DataTable
        Dim dtArticulos As DataTable = dtMateriales.Copy()
        For Each row As DataRow In dtArticulos.Rows
            If CInt(row!SinExistencia) > 0 Then
                row("Cantidad") = CInt(row!Cantidad) - CInt(row!SinExistencia)
            End If
        Next
        dtArticulos.AcceptChanges()
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA: 29/04/2013: Crea un objeto de Factura y obtiene solo lo que se va a facturar
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function CreateFacturaDisponiblesSH() As Factura
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim factura As Factura = FacturaMgr.Create()
        Dim ConExistencia As DataTable = Me.DataSetSiHay.Tables("ArticulosConExistencia")
        factura.CodVendedor = oFactura.CodVendedor
        factura.CodPlaza = oFactura.CodPlaza
        factura.CodCaja = oFactura.CodCaja
        factura.CodAlmacen = oFactura.CodAlmacen
        factura.ApartadoID = oFactura.ApartadoID
        factura.FolioFactura = oFactura.FolioFactura
        factura.FolioSAP = oFactura.FolioSAP
        'factura.FolioFISAP = oFactura.FolioFISAP
        factura.ClienteId = oFactura.ClienteId
        factura.ClientPGID = oFactura.ClientPGID
        factura.PedidoID = oFactura.PedidoID
        factura.CodTipoVenta = oFactura.CodTipoVenta
        factura.NumeroFacilito = oFactura.NumeroFacilito
        factura.RazonRechazo = oFactura.RazonRechazo
        factura.RazonRechazoID = oFactura.RazonRechazoID
        factura.dtMotivos = oFactura.dtMotivos
        factura.Fecha = oFactura.Fecha
        factura.DPesos = oFactura.DPesos
        factura.Usuario = oFactura.Usuario
        factura.Nquincenas = oFactura.Nquincenas
        factura.StatusRegistro = oFactura.StatusRegistro
        factura.StatusFactura = oFactura.StatusFactura
        factura.Saldo = oFactura.Saldo
        factura.Referencia = oFactura.Referencia
        Dim desctotal As Decimal = GetDescuentoTotalFacturaExistenciaSH(ConExistencia)
        factura.DescTotal = Math.Round(desctotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
        factura.SubTotal = Math.Round(CDec(ConExistencia.Compute("SUM(Total)", "")) - desctotal, 2)
        factura.Total = Math.Round(CDec(factura.SubTotal * (oAppContext.ApplicationConfiguration.IVA + 1)), 2)
        factura.Impresa = oFactura.Impresa
        factura.IVA = Math.Round(CDec(factura.SubTotal * oAppContext.ApplicationConfiguration.IVA), 2)
        Return factura
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/05/2013: Funcion para obtener el descuento total de la factura "SiHay"
    '--------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDescuentoTotalFacturaExistenciaSH(ByVal dtDetalle As DataTable) As Decimal
        Dim DescTotal As Decimal = 0
        For Each row As DataRow In dtDetalle.Rows
            DescTotal += CDec(row!CantDescuentoSistema) + ((CDec(row!Total) - CDec(row!CantDescuentoSistema)) * (CDec(row!Descuento) / 100))
        Next
        Return DescTotal
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Funcion para mandar imprimir desde Facturación
    '--------------------------------------------------------------------------------------------------------------------------------
    Public Function ActionPreviewFacturacionSH(ByVal PedidoID As Integer, ByVal copia As Boolean, ByVal ModuloID As String, ByVal Disponible As Boolean, _
                             Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, _
                             Optional ByVal bReimpresion As Boolean = False, Optional ByVal bSoloPendPorEntregar As Boolean = False) As Boolean

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        Dim pedido As New Pedidos(PedidoID.ToString())
        Dim oS2Credit As New ProcesosS2Credit
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oClienteSAP As ClientesSAP
        Dim oDPVale As New cDPVale
        Dim bFormaPago As Boolean = True
        Dim dataInfo As rptFacturaInfo
        Dim bRespuesta As Boolean = False
        '----------------------------------------------------------------------------------------------------------
        ' FLIZARRAGA (20.01.2017): Se realizaron cambios en el ticket de la facturación del si hay
        '----------------------------------------------------------------------------------------------------------
        If pedido.CodTipoVenta = "V" Then ' JNAVA (14.02.2017): se valida por tipo de venta en ves de DPVale ID
            'If pedido.DPValeID > 0 Then
            oDPVale.INUMVA = CStr(pedido.DPValeID)
            oDPVale.I_RUTA = "X"
            Dim FirmaDistrS2C As Image
            Dim NombreDistrS2C As String = String.Empty
            If oConfigCierreFI.AplicarS2Credit Then
                oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistrS2C, NombreDistrS2C)
            Else
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
            End If
            If oConfigCierreFI.AplicarS2Credit Then
                vNombreAsociado = NombreDistrS2C.TrimEnd
            Else
                vNombreAsociado = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPVale.InfoDPVALE.Rows(0)!KUNNR))
            End If
            oClienteSAP = GetClienteDPVale(oDPVale.InfoDPVALE.Rows(0)!CODCT)
            vNombreClienteAsociado = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos
        End If
        '----------------------------------------------------------------------------------------------------------

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        With orptDataInfo
            .PedidoID = PedidoID
            .FacturaID = 0
            .ModuloID = ModuloID
            .Disponible = Disponible
            .NombreAsociado = vNombreAsociado
            .vNombreClienteAsociado = vNombreClienteAsociado
            .DeudaFacilito = decDeudaFacilito
            .FolioDPVale = StrFolioDPVale
        End With
        pdtGeneralPrintPreview = pdtGeneral
        pImprimir.ObtenerDatosPedidoSH(orptDataInfo, pdtGeneral, pdtPagos, pdtNotas)
        Try
            Dim TitleTicketFactura As String = "", TitleTicketPedido As String = ""
            If bSoloPendPorEntregar = False AndAlso Not pedido.Facturas Is Nothing Then
                Dim first As Boolean = True
                bFormaPago = False
                For Each invoice As Factura In pedido.Facturas
                    dataInfo = New rptFacturaInfo
                    pImprimir = New cImprimirFactura
                    With dataInfo
                        .PedidoID = PedidoID
                        .FacturaID = invoice.FacturaID
                        .ModuloID = ModuloID
                        .Disponible = Disponible
                        .NombreAsociado = vNombreAsociado
                        .vNombreClienteAsociado = vNombreClienteAsociado
                        .DeudaFacilito = decDeudaFacilito
                        .FolioDPVale = StrFolioDPVale
                    End With
                    pdtGeneralPrintPreview = pdtGeneral
                    If invoice.Impresa = True Then
                        TitleTicketPedido = "COPIA PENDIENTE"
                        TitleTicketFactura = "COPIA DE FACTURA"
                    Else
                        TitleTicketPedido = "PENDIENTE"
                        TitleTicketFactura = "FACTURA"
                    End If
                    'Validar que aparezca solo cuando el tipo de venta sea FONACOT
                    'y que aparezca cuando sea la impresora HP
                    If oConfigCierreFI.PrinterHP Then
                        If TipoLeyenda = "" Then
                            If invoice.CodTipoVenta = "F" Then
                                If Not oVC.ValeCajaID > 0 Then
                                    If MessageBox.Show("¿Deseas imprimir HOJA FONACOT?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                        Dim print_document As PrintDocument = PreparePrintDocument()
                                        print_document.DocumentName = "HOJA FONACOT"
                                        print_document.Print()
                                    End If
                                End If

                            End If
                        End If
                    End If
                    If oConfigCierreFI.MiniPrinter Then
                        Dim oARReporte As Object
                        If first Then
                            oARReporte = New ReporteFacturacionSH(dataInfo, pdtGeneral, True, TitleTicketFactura, oConfigCierreFI.ImprimirCedula, False, TipoLeyenda, strQuin, bReimpresion, ImporteSeguro, FechaPrimerPago)
                            first = False
                        Else
                            'oARReporte = New ReporteFacturacion(dataInfo, pdtGeneral, True, TitleTicketFactura, oConfigCierreFI.ImprimirCedula, False, "", strQuin, bReimpresion)
                            'Dim oARReporte As New ReporteFacturacion(dataInfo, pdtGeneral, True, TitleTicketFactura, oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion)
                            oARReporte = New ReporteFacturacion(dataInfo, pdtGeneral, True, TitleTicketFactura, oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, bReimpresion, , ImporteSeguro, , FechaPrimerPago)
                        End If
                        'Dim oARReporte As New ReporteFacturacion(dataInfo, pdtGeneral, True, TitleTicketFactura, oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion)
                        'Dim oARReporte As New ReporteFacturacion(dataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                        'bReimpresion)
                        oARReporte.Document.Name = "Reporte Facturacion"
                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                        'Dim oARViewer As New ReportViewerForm

                        'oARReporte.Run()

                        oARReporte.Document.Print(False, False)
                        'oARViewer.Report = oARReporte
                        'oARViewer.Show()
                    End If
                Next
            End If
            'Se valida si es una cancelacion del Si hay
            If TipoLeyenda.Trim = "cancelacion".ToUpper Then
                dataInfo = New rptFacturaInfo
                pImprimir = New cImprimirFactura
                With dataInfo
                    .PedidoID = PedidoID
                    .FacturaID = 0
                    .ModuloID = ModuloID
                    .Disponible = Disponible
                    .NombreAsociado = vNombreAsociado
                    .vNombreClienteAsociado = vNombreClienteAsociado
                    .DeudaFacilito = decDeudaFacilito
                    .FolioDPVale = StrFolioDPVale
                End With
                'If TitleTicketPedido.Trim = "" Then
                '    TitleTicketPedido = IIf(pedido.Impresa, "COPIA CANCELACION", "CANCELACION")
                'End If
                'If TipoLeyenda.Trim = "cancelacion".ToUpper Then TitleTicketPedido = "CANCELACION"
                Dim reporteSinExistencia As New ReporteFacturacion
                Dim Manager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim FechaServidor As DateTime = Manager.MSS_GET_SY_DATE_TIME()
                If pedido.Fecha.Date = FechaServidor.Date Then
                    reporteSinExistencia.ImprimirCancelacionSH(True, dataInfo, pedido.ArticulosNoFacturados, pdtGeneral, bFormaPago, "CANCELACION", oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro)
                Else
                    reporteSinExistencia.ImprimirCancelacionSH(False, dataInfo, pedido.ArticulosNoFacturados, pdtGeneral, bFormaPago, "CANCELACION", oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro)
                End If
                reporteSinExistencia.Document.Name = "Reporte Facturacion"
                reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                'Dim viewerSinExistencia As New ReportViewerForm

                'oARReporte.Run()

                reporteSinExistencia.Document.Print(False, False)
                'viewerSinExistencia.Report = reporteSinExistencia
                'viewerSinExistencia.Show()
                pedido.Impresa = True
                pedido.Save()
                If copia = True Then

                    'If TitleTicketPedido.Trim = "" Then
                    '    TitleTicketPedido = IIf(pedido.Impresa, "COPIA CANCELACION", "CANCELACION")
                    'End If
                    'If TipoLeyenda.Trim = "cancelacion".ToUpper Then TitleTicketPedido = "CANCELACION"
                    Dim reporteSinExistenciaCopy As New ReporteFacturacion
                    If pedido.Fecha.Date = FechaServidor.Date Then
                        reporteSinExistencia.ImprimirCancelacionSH(True, dataInfo, pedido.ArticulosFacturados, pdtGeneral, bFormaPago, "COPIA CANCELACION", oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro)
                    Else
                        reporteSinExistencia.ImprimirCancelacionSH(False, dataInfo, pedido.ArticulosNoFacturados, pdtGeneral, bFormaPago, "COPIA CANCELACION", oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro)
                    End If
                    reporteSinExistenciaCopy.Document.Name = "Reporte Facturacion"
                    reporteSinExistenciaCopy.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    reporteSinExistenciaCopy.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                    'Dim viewerSinExistencia As New ReportViewerForm

                    'oARReporte.Run()

                    reporteSinExistencia.Document.Print(False, False)
                    'viewerSinExistencia.Report = reporteSinExistencia
                    'viewerSinExistencia.Show()
                End If
            Else
                ' Obtener total de artículos sin facturar para imprimir el ticket de artículos pendientes
                If pedido.ArticulosNoFacturados.Rows.Count > 0 Then
                    dataInfo = New rptFacturaInfo
                    pImprimir = New cImprimirFactura
                    With dataInfo
                        .PedidoID = PedidoID
                        .FacturaID = 0
                        .ModuloID = ModuloID
                        .Disponible = Disponible
                        .NombreAsociado = vNombreAsociado
                        .vNombreClienteAsociado = vNombreClienteAsociado
                        .DeudaFacilito = decDeudaFacilito
                        .FolioDPVale = StrFolioDPVale
                    End With
                    If TitleTicketPedido.Trim = "" Then
                        TitleTicketPedido = IIf(pedido.Impresa, "COPIA PENDIENTE", "PENDIENTE")
                    End If
                    If TipoLeyenda.Trim = "Factura".ToUpper Then TitleTicketPedido = "PENDIENTE"
                    Dim reporteSinExistencia As New ReporteFacturacion
                    reporteSinExistencia.ImprimirPedidoSH(dataInfo, pedido.ArticulosNoFacturados, pdtGeneral, bFormaPago, TitleTicketPedido, oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro, FechaPrimerPago)
                    reporteSinExistencia.Document.Name = "Reporte Facturacion"
                    reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                    'Dim viewerSinExistencia As New ReportViewerForm

                    'oARReporte.Run()

                    reporteSinExistencia.Document.Print(False, False)
                    'viewerSinExistencia.Report = reporteSinExistencia
                    'viewerSinExistencia.Show()
                End If
                pedido.Impresa = True
                pedido.Save()
                If copia = True Then
                    If MessageBox.Show("¿Desea volver a imprimir el pedido?", " Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        bRespuesta = True
                        If oConfigCierreFI.MiniPrinter Then
                            If bSoloPendPorEntregar = False AndAlso Not pedido.Facturas Is Nothing Then
                                For Each invoice As Factura In pedido.Facturas
                                    dataInfo = New rptFacturaInfo
                                    pImprimir = New cImprimirFactura
                                    With dataInfo
                                        .PedidoID = PedidoID
                                        .FacturaID = invoice.FacturaID
                                        .ModuloID = ModuloID
                                        .Disponible = Disponible
                                        .NombreAsociado = vNombreAsociado
                                        .vNombreClienteAsociado = vNombreClienteAsociado
                                        .DeudaFacilito = decDeudaFacilito
                                        .FolioDPVale = StrFolioDPVale
                                    End With
                                    pdtGeneralPrintPreview = pdtGeneral
                                    If oConfigCierreFI.MiniPrinter Then
                                        '  Dim oARReporte As New ReporteFacturacion(dataInfo, pdtGeneral, True, "COPIA DE FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, _
                                        ' strQuin, bReimpresion, , ImporteSeguro, , FechaPrimerPago)

                                        Dim oARReporte As New ReporteFacturacionSH(dataInfo, pdtGeneral, True, "COPIA DE FACTURA", oConfigCierreFI.ImprimirCedula, False, TipoLeyenda, strQuin, bReimpresion, ImporteSeguro, FechaPrimerPago)

                                        'Dim oARReporte As New ReporteFacturacion(dataInfo, pdtGeneral, "FACTURA", oConfigCierreFI.ImprimirCedula, TipoLeyenda, strQuin, _
                                        'bReimpresion)
                                        oARReporte.Document.Name = "Reporte Facturacion"
                                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                                        'Dim oARViewer As New ReportViewerForm

                                        'oARReporte.Run()

                                        oARReporte.Document.Print(False, False)
                                        'oARViewer.Report = oARReporte
                                        'oARViewer.Show()
                                    End If
                                Next
                            End If
                            If pedido.ArticulosNoFacturados.Rows.Count > 0 Then
                                dataInfo = New rptFacturaInfo
                                pImprimir = New cImprimirFactura
                                With dataInfo
                                    .PedidoID = PedidoID
                                    .FacturaID = 0
                                    .ModuloID = ModuloID
                                    .Disponible = Disponible
                                    .NombreAsociado = vNombreAsociado
                                    .vNombreClienteAsociado = vNombreClienteAsociado
                                    .DeudaFacilito = decDeudaFacilito
                                    .FolioDPVale = StrFolioDPVale
                                End With
                                Dim reporteSinExistencia As New ReporteFacturacion
                                reporteSinExistencia.ImprimirPedidoSH(dataInfo, pedido.ArticulosNoFacturados, pdtGeneral, bFormaPago, "COPIA PENDIENTE", oConfigCierreFI.ImprimirCedula, "", strQuin, bReimpresion, ImporteSeguro, FechaPrimerPago)
                                reporteSinExistencia.Document.Name = "Reporte Facturacion"
                                reporteSinExistencia.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                reporteSinExistencia.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                                'Dim viewerSinExistencia As New ReportViewerForm

                                'oARReporte.Run()

                                reporteSinExistencia.Document.Print(False, False)
                                'viewerSinExistencia.Report = reporteSinExistencia
                                'viewerSinExistencia.Show()
                            End If

                        End If

                    End If
                End If
            End If

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa.", ex)

        End Try

        Return bRespuesta

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        Dim dtLibres As DataTable = Nothing
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Me.DataSetSiHay.Tables.Contains("MaterialesLibres") Then
            dtLibres = Me.DataSetSiHay.Tables("MaterialesLibres")
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!Codigo)
                Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/05/2013: Obtiene la condicion del producto del detalle
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Function GetCondicionArticulo(ByVal CodArticulo As String, ByVal Talla As String) As String
        Dim condicion As String = ""
        Dim rows() As DataRow = oFactura.Detalle.Tables(0).Select("Codigo='" & CodArticulo & "' AND Talla='" & Talla & "'")
        If rows.Length > 0 Then
            condicion = CStr(rows(0)!Condicion)
        End If
        Return condicion
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/05/2013: Obtiene los mensajes de errores
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function GetMensajeErrorPedido(ByVal result As DataTable) As String
        Dim mensaje As String = ""
        For Each row As DataRow In result.Rows
            mensaje &= CStr(row!MESSAGE) & vbCrLf
        Next
        Return mensaje
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'JNAVA (27.10.2014): Obtenemos y Datos que necesitamos del DPVALE para la venta SH
    '----------------------------------------------------------------------------------------------------------------------------
    Private Function SetVentaPedidoDPValeSAP(ByVal CodTipoVenta As String, ByVal oDpvaleSAP As cDPValeSAP) As VentasFacturaSAP

        Dim oVentaFacturaSAP As New VentasFacturaSAP
        With oVentaFacturaSAP
            Dim arDatosDPVale() As String = GetDPValeSAP()
            .CodigoCliente = arDatosDPVale(0).PadLeft(10, "0")
            .MontoDPVale = oDpvaleSAP.MONTODPVALE
            .ClienteDistribuidor = arDatosDPVale(2).PadLeft(10, "0")

            Dim arDatosZV() As String = GetZonaVentaSAP(CodTipoVenta)
            .ZonaVenta = arDatosZV(0)
            .NumeroVale = arDatosZV(1)      'DPVale o Vale de Caja

            .DPValeVentaID = Me.DPValeVentaID
            .NUMDE = oDpvaleSAP.NUMDE                       '--Numero de Quincenas
            .PARES_PZAS = oDpvaleSAP.ParesPzas              '--Numero de Pares Piezas
            .MONTOUTILIZADO = oDpvaleSAP.MontoUtilizado     '--Monto Utilizado
            .REVALE = oDpvaleSAP.REVALE                     '--TRUE si se ocupa Revale FALSE si no se necesita
            .FechaCobroDPVL = oDpvaleSAP.FechaCobro         '--Fecha en la que se empezara a cobrar el primer abono

            '---------------------------------------------------------------------------------------------------------
            ' JNAVA (04.04.2017): Agregamos el ID de la Promocion
            '---------------------------------------------------------------------------------------------------------
            .PromocionID = oDpvaleSAP.PromocionID
            '---------------------------------------------------------------------------------------------------------

        End With

        Return oVentaFacturaSAP

    End Function

#End Region

#Region "Descuento Proxima Compra"

    '-------------------------------------------------------------------------------
    'JNAVA 08/11/2013: Creacion del Cupon de descuento Proxima Compra
    '-------------------------------------------------------------------------------
    Private Sub CuponDescuentoProximaCompra(ByVal oFactura As Factura)

        Dim Cupon As Hashtable
        Dim Mensaje As String
        Dim strNombre As String = ""
        Dim FechaVig As String = ""
        Dim CodCliente As String = ""
        Dim ClienteNombre As String = ""

        Try

            Cupon = oSAPMgr.ZCDES_PROXIMACOMPRA_CREADESCTO(oFactura.Fecha, oFactura.Total, Mensaje)

            'Si el Cupon viene vacio, nos salimos para evitar excepciones
            If Cupon Is Nothing OrElse CStr(Cupon.Item("FOLIO")).Trim = "" Then
                If Mensaje.Trim <> "" Then MessageBox.Show(Mensaje, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'Creamos y llenamos el objeto oCupon
            Dim oCupon As New CuponDescuento
            Try
                With oCupon
                    .Descripcion = Cupon.Item("DESCRIPCION")
                    .Descuento = Cupon.Item("DESCUENTO")
                    'Formateamos la Fecha
                    FechaVig = Cupon.Item("FIN")
                    .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
                    'Formateamos la Fecha
                    .Folio = Cupon.Item("FOLIO")
                    .LimiteDescuento = Cupon.Item("LIMITE_DESCTO")
                    .Maximo = Cupon.Item("MAXIMO")
                    .Minimo = Cupon.Item("MINIMO")
                    .TipoDescuento = Cupon.Item("TIPO_DESCTO")
                End With
            Catch ex As Exception
                MessageBox.Show("Error al cargar cupón creado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "-Error al cargar cupón creado de descuento de proximá compra desde SAP-")
                Exit Sub
            End Try

            'Imprimimos de ser necesario
            If oCupon.Folio.Trim <> "" Then
                '-------------------------------------------------------------------------------------
                'JNAVA - 08/11/2013: Obtenemos los datos necesariso del Cliente 
                '-------------------------------------------------------------------------------------
                Try
                    If oFactura.ClienteId = 1 AndAlso oFactura.ClientPGID = 0 Then
                        CodCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                        ClienteNombre = "PÚBLICO GENERAL"
                        GoTo Imprimir
                    ElseIf oFactura.ClienteId = 99999 Then
                        CodCliente = CStr(oFactura.ClienteId).PadLeft(10, "0")
                        ClienteNombre = "VENTAS A EMPLEADOS"
                        GoTo Imprimir
                    End If

                    Dim oClienteA As ClienteAlterno
                    oClienteA = oClienteMgr.CreateAlterno
                    CodCliente = ""
                    ClienteNombre = ""
                    If oFactura.CodTipoVenta = "P" Then
                        oClienteMgr.LoadPG(CStr(oFactura.ClientPGID).PadLeft(10, "0"), oClienteA)
                        CodCliente = oClienteA.CodigoCliente
                        ClienteNombre = oClienteA.NombreCompleto
                    Else
                        oClienteMgr.Load(CStr(oFactura.ClienteId).PadLeft(10, "0"), oClienteA, oFactura.CodTipoVenta)
                        CodCliente = oClienteA.CodigoCliente
                        ClienteNombre = oClienteA.NombreCompleto
                    End If
                    oClienteA = Nothing

                Catch ex As Exception
                    MessageBox.Show("Error al cargar datos del cliente para el cupón creado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(ex.ToString, "-Error al cargar datos del cliente para el cupón creado de descuento de proximá compra desde SAP-")
                    Exit Sub
                End Try
                '-----------------------------------------------------------------------------------------------------------------------------------------

Imprimir:
                'Imprimimos cupon
                Try
                    If oConfigCierreFI.MiniPrinter Then
                        'If CLng(CodCliente) <> 1 AndAlso CLng(CodCliente) <> 99999 Then strNombre = ClienteNombre.Trim
                        Dim oRpt As New rptReCupon(oCupon.Folio, oCupon.Maximo, oCupon.Descuento, oCupon.FechaVigencia, ClienteNombre, oCupon.TipoDescuento, "CD", oCupon.LimiteDescuento, True)
                        oRpt.Document.Name = "Cupón de Descuento"
                        oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oRpt.Run()
                        oRpt.Document.Print(False, False)
                        'Dim RepView As New ReportViewerForm
                        'RepView.Report = oRpt
                        'RepView.Show()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al imprimir cupón creado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(ex.ToString, "-Error al imprimir cupón creado de descuento de proximá compra desde SAP-")
                    Exit Sub
                End Try

                MessageBox.Show(Mensaje, "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            oCupon = Nothing

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al generar cupón de descuento de próxima compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al generar cupón de descuento de proximá compra en SAP-")
        End Try

    End Sub

#End Region

#Region "Motivos de Rechazo DPVale"
    '----------------------------------------------------------------------------------------------------------------------
    ' JNAVA 06/05/2014 - Funcion para validar si se debe mostrar o no la captura de motivos de rechazo
    '----------------------------------------------------------------------------------------------------------------------
    Private Sub CapturarMotivoRechazo()
        If oConfigCierreFI.MotivosRechazoDPVL Then 'Validamos que este la configuracion activa
            If oDpvaleSAP Is Nothing OrElse oDpvaleSAP.IDDPVale = String.Empty Then 'Validamos que se haya cargado o no algun vale
                Exit Sub
            Else 'Mostramos pantalla de captura de motivo de rechazos
                Dim ofrmMotivos As New frmCapturarMotivos(oDpvaleSAP.IDDPVale, "3")
                ofrmMotivos.ShowDialog()
                ofrmMotivos.Dispose()
            End If
        End If
    End Sub
#End Region

#Region "ReReVale DPVale"

    Private Sub GenerarReReValeVentaDPVALE(ByVal oFactura As Factura)

        'Validamos que este la configuracion activa
        If oConfigCierreFI.GenerarReRevale Then

            'Validamos que el tipo de Venta sea con DPVale
            If oFactura.CodTipoVenta = "V" Then

                '---------------------------------------------------------------------------------------------
                'JNAVA (27.01.2015): NO generaramos re-vale cuando se trate de venta con electronicos
                '---------------------------------------------------------------------------------------------
                If HayElectronicos() Then
                    Exit Sub
                End If

                'Validamos que se realmente se haya cargado o no algun DPVale
                If Not oDpvaleSAP Is Nothing OrElse oDpvaleSAP.IDDPVale <> String.Empty Then

                    'Si es un REVALE o un REREVALE, no se genera otro REREVALE
                    If oDpvaleSAP.IsRevale Or oDpvaleSAP.IsReRevale Then
                        Exit Sub
                    End If

                    Dim strResult As String = String.Empty
                    Dim FolioReReVale As String = String.Empty
                    Dim MontoReRevale As Decimal = Decimal.Zero, MontoOriginal As Decimal = 0
                    Dim ParesPzsReRevale As Integer = 0
                    Dim ParesPzsFactura As Integer = 0
                    Dim strMensaje As String = String.Empty

                    Try

                        'Obtenemos los Parez Piezas de la Factura
                        ParesPzsFactura = oFactura.Detalle.Tables(0).Compute("SUM(Cantidad)", "")

                        'Validamos que el Monto del DPVale sea mayor que el Importe Total de la Factura
                        'O los Pares Piezas del DPVale sea mayor que los Pares Piezas de la Factura
                        If oDpvaleSAP.MONTODPVALE > oFactura.Total OrElse (oDpvaleSAP.RPARES_PZAS + oDpvaleSAP.ParesPzas) > ParesPzsFactura Then

                            If oDpvaleSAP.RMONTODPVALE > 0 Then 'Si es por monto (Monto pendiente)
                                'Calculamos el saldo del cliente
                                MontoReRevale = oDpvaleSAP.RMONTODPVALE
                                MontoOriginal = oDpvaleSAP.MONTODPVALE
                                ParesPzsReRevale = 0
                                strMensaje = "El Cliente cuenta con saldo de $" & MontoReRevale & " para Generar un Revale." & vbCrLf & "¿Desea generarlo?"
                            ElseIf (oDpvaleSAP.RPARES_PZAS + oDpvaleSAP.ParesPzas) > ParesPzsFactura Then 'Si es por piezas (piezas pendientes)
                                'Calculamos el monto y los pares restantes del cliente en base a la configuracion
                                ParesPzsReRevale = oDpvaleSAP.RPARES_PZAS
                                MontoReRevale = oConfigCierreFI.ImporteMaximoDPVale - oFactura.Total
                                MontoOriginal = oConfigCierreFI.ImporteMaximoDPVale
                                strMensaje = "El Cliente cuenta con Saldo de $" & MontoReRevale & " para " & oDpvaleSAP.RPARES_PZAS & " Piezas para Generar un Revale." & vbCrLf & " ¿Desea generarlo?"
                            End If

                            'Si el monto para el ReRevale es mayor que cero, continua el proceso
                            If MontoReRevale > 0 Then

                                'Preguntamos si desea Generar el Rerevale
                                If MessageBox.Show(strMensaje, "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                    '--------------------------------------------------------------------------------------------
                                    ' JNAVA (20.07.2016): Genera ReVale en S2Credit o en SAP si esta activa la Configuracion 
                                    '--------------------------------------------------------------------------------------------
                                    ''Generamos el ReReVale en SAP
                                    'FolioReReVale = oSAPMgr.ZBAPI_GENERAR_REREVALE(oDpvaleSAP.IDDPVale, MontoReRevale, ParesPzsReRevale, strResult)

                                    '--------------------------------------------------------------------------------------------
                                    ' JNAVA (20.07.2016): Generamos Revale 
                                    '--------------------------------------------------------------------------------------------
                                    Dim oS2Credit As New ProcesosS2Credit
                                    If oConfigCierreFI.AplicarS2Credit Then
                                        FolioReReVale = oS2Credit.GeneraReVale(oDpvaleSAP.IDDPVale, oDpvaleSAP.IDCliente, MontoReRevale, strResult, True)
                                    Else
                                        ' JNAVA (18.08.2016): Obtenemos el cliente del vale para el ReReVale
                                        '------------------------------------------------------------------------
                                        Dim arDatosDPVale() As String = GetDPValeSAP()
                                        FolioReReVale = oSAPMgr.ZBAPI_GENERAR_REREVALE(oDpvaleSAP.IDDPVale, MontoReRevale, ParesPzsReRevale, strResult, arDatosDPVale(0).PadLeft(10, "0"))
                                    End If
                                    '--------------------------------------------------------------------------------------------

                                    'Validamos Resultados
                                    Select Case strResult

                                        Case "S"
                                            'Imprimimos ReReVale
                                            ImprimeReRevale(FolioReReVale, MontoReRevale, MontoOriginal, oFactura.Total, ParesPzsReRevale)
                                        Case "N"
                                            MessageBox.Show("El REVALE no se genero en SAP, por que no existe Vale Origen", "No existe Vale Origen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Case "E"
                                            MessageBox.Show("El REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Case Else
                                            MessageBox.Show("El REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                    End Select

                                End If

                            Else

                                Exit Sub

                            End If

                        Else

                            Exit Sub

                        End If

                    Catch ex As Exception
                        MessageBox.Show("Ocurrio un error al generar el Revale cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        EscribeLog(ex.ToString, "-Error al generar el Revale de Venta con DPVale-")
                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ImprimeReRevale(ByVal FolioReReVale As String, ByVal MontoReReVale As Decimal, ByVal MontoOriginal As Decimal, ByVal MontoVenta As Decimal, ByVal ParesPzas As String)

        Try

            owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
            owsDPValeInfo.MontoDPValeI = MontoReReVale

            Dim oDPVale As New cDPVale
            oDPVale.INUMVA = FolioReReVale.PadLeft(10, "0")
            oDPVale.I_RUTA = "X"
            '----------------------------------------------------------------------------------------
            ' JNAVA (14.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
            '----------------------------------------------------------------------------------------
            'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            ''-----------------------------------------------------
            '' JNAVA (11.04.2016): Valida DPVale en S2Credit
            ''-----------------------------------------------------
            'BuscarValeS2Credit(CStr(Convert.ToInt32(FolioReReVale)).PadLeft(10, "0"))

            '----------------------------------------------------------------------------------------
            ' JNAVA (14.07.2016): Valida DPVale
            '----------------------------------------------------------------------------------------
            Dim FirmaDistrS2C As Image = Nothing
            Dim NombreDistrS2C As String = String.Empty
            If oConfigCierreFI.AplicarS2Credit Then
                oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistrS2C, NombreDistrS2C)
            Else
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
            End If
            '----------------------------------------------------------------------------------

            oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(Convert.ToInt32(FolioReReVale)).PadLeft(10, "0") & ".bmp"

            Dim oRow As DataRow
            oRow = oDPVale.InfoDPVALE.Rows(0)
            '----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 15/10/2018: Se cambio la estructura debido a que el vale electronico admite valores alfanumericos
            '----------------------------------------------------------------------------------------------------------------------------
            Dim dpvaleInfo As New DevolucionDPValeInfo()
            dpvaleInfo.DPValeOrigen = oRow("Orige")
            dpvaleInfo.FechaExpedicion = Now
            dpvaleInfo.FechaEntregado = Now
            dpvaleInfo.FacturaId = 0
            dpvaleInfo.MontoDPValeUtilizado = 0
            dpvaleInfo.MontoDPValeP = 0
            dpvaleInfo.DPValeID = Convert.ToInt32(FolioReReVale)
            dpvaleInfo.AsociadoID = oRow("KUNNR")
            dpvaleInfo.ClienteAsociadoID = oRow("CODCT")
            dpvaleInfo.ParesPzas = ParesPzas
            'owsDPValeInfo.DPValeOrigen = oRow("Orige")
            owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
            owsDPValeInfo.FechaEntregado = Now.ToShortDateString
            owsDPValeInfo.FacturaID = 0
            owsDPValeInfo.MontoUtilizado = 0
            owsDPValeInfo.MontoDPValeP = 0
            vSobrante = MontoReReVale
            owsDPValeInfo.DPValeID = Convert.ToInt32(FolioReReVale)
            owsDPValeInfo.AsociadoID = oRow("KUNNR")
            owsDPValeInfo.ClienteAsociadoID = oRow("CODCT")

            '----------------------------------------------
            'JNAVA (15.12.2014): Piezas de Rerevale
            '----------------------------------------------
            owsDPValeInfo.ParesPzas = ParesPzas
            '----------------------------------------------

            PrintRevale(dpvaleInfo, NombreDistrS2C, FirmaDistrS2C, MontoOriginal, MontoVenta)

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Revale de Venta con DPVale.", "Revale Venta DPVale", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EscribeLog(ex.ToString, "-Error al Imprimir el Revale de Venta con DPVale-")
        End Try

    End Sub

#End Region

#Region "Venta de Electronicos"

    Private Function HayElectronicos() As Boolean
        Dim bReturn As Boolean = False
        If Not dtElectronicos Is Nothing AndAlso dtElectronicos.Rows.Count > 0 Then
            bReturn = True
        End If
        Return bReturn
    End Function

    Private Sub ObtenerCorridaElectronicos(ByVal Codigo As String, ByRef NumeroSerie As String, ByRef IMEI As String)
        If HayElectronicos() Then
            Dim dvElectronicos As DataView
            dvElectronicos = New DataView(dtElectronicos, "Material = '" & Codigo & "'", "", DataViewRowState.CurrentRows)
            If dvElectronicos.Count > 0 Then
                For Each dvRow As DataRowView In dvElectronicos
                    NumeroSerie += dvRow!NumSerie & ";"
                    'Solo si es Celular agregamos los IMEI
                    If dvRow!NumDenominacion = "11" Or dvRow!NumDenominacion = "12" Then
                        IMEI += dvRow!IMEI & ";"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GuardarElectronicosSAP()

        Try

            'Revisamos que tengamos electronicos en la factura
            If HayElectronicos() Then

                Dim dtFormasPago As DataTable
                Dim strFormasPagos As String = String.Empty
                Dim strDPValeID As String = String.Empty
                Dim ErrorSAP As String = String.Empty
                Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")

                'Obtenemos las formas de pago de la factura
                Dim oFormaPagoElectronicos As New FacturaFormaPago(oAppContext)
                oFormaPagoElectronicos.ClearFields()
                dtFormasPago = oFormaPagoElectronicos.Load(oFactura.FacturaID).Tables(0)
                For Each oRowFP As DataRow In dtFormasPago.Rows
                    'Sacamos el codigo de la Formas de pago
                    strFormasPagos += oRowFP!CodFormasPago & ";"
                    'Sacamos folio del DPVale
                    If oRowFP!DPValeID <> "" Then
                        strDPValeID = oRowFP!DPValeID
                    End If
                Next

                '-------------------------------------------------------------------------
                ' JNAVA (22.02.2016): Se adecuo para enviar referencia en ves de factura
                '-------------------------------------------------------------------------
                'Ponemos las formas de pago obtenidas en la tabla de Electronicos
                For Each oRowE As DataRow In dtElectronicos.Rows
                    oRowE!Factura = oFactura.Referencia 'oFactura.FacturaSAP
                    oRowE!DPVale = strDPValeID
                    oRowE!FormaPago = strFormasPagos
                Next

                'Grabamos en SAP
                ErrorSAP = oSAPMgr.ZDPT_GUARDAR_VENTAS_ELEC(dtElectronicos)

                If ErrorSAP.Trim <> "" Then
                    MessageBox.Show("Ocurrió un problema al guardar los Electrónicos en SAP. Favor de revisar el Log de Errores.", "Electrónicos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    EscribeLog(ErrorSAP, "Error al guardar los Electrónicos en SAP.")
                End If

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

#End Region

#Region "DP Card" 'JNAVA (26.01.2015): Metodos y Funciones para menejo de DP Card

    '-----------------------------------------------------------------------------
    'JNAVA (29.01.2015): Leer datos de tarjeta DPCard
    '-----------------------------------------------------------------------------
    Private Function LeerDPCard() As Boolean
        Dim valido As Boolean = False
        Dim pinpad As Pinpad.Pinpad = Nothing
        Try
            'Leemos el numero de la tarjeta DP Card
            '--------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/02/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
            '--------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PagosBanamex = True Then
                pinpad = New Pinpad.Pinpad()
                Dim bin As String = ""
                'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
                Dim code As String = pinpad.LeerTarjeta(CDec(EBPago.Value).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
                If code.Trim() <> "10" AndAlso code.Trim() <> "40" Then
                    Dim Name As String = pinpad.getAppLabel()
                    bin = pinpad.getCardNumber(code)
                    deslizada = True
                    Me.ClienteDPC = Name
                    Me.ebNumTarj.Text = bin
                    FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.EBPago.Value))
                    Me.cmbPromocion.Text = ""
                    valido = True
                Else
                    EscribeLog(code, "Error al lecturar la tarjeta dpcard")
                    MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 20/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            Else
                Dim oOtrosPagos As New OtrosPagos
                If oOtrosPagos.LeerDatosDPCard(Me.ebNumTarj.Text, Me.ClienteDPC) Then
                    'Cargamos las promociones de DP Card
                    deslizada = True
                    FillDPCardPromociones(CInt(ebNumTarj.Text.Substring(0, 6)), CDec(Me.EBPago.Value))
                    Me.cmbPromocion.Text = ""
                    valido = True
                End If
            End If
        Catch ex As Exception
            If oConfigCierreFI.PagosBanamex AndAlso Not pinpad Is Nothing Then
                pinpad.Respuesta("2", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            End If
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try
        Return valido
    End Function

    '-----------------------------------------------------------------------------
    'JNAVA (29.01.2015): Cargar promociones para tarjeta DPCard
    '-----------------------------------------------------------------------------
    Private Sub FillDPCardPromociones(ByVal Bin As Integer, ByVal Importe As Decimal)

        dtPromociones = oFacturaMgr.GetPromocionesDPCardByBIN(Bin, Importe, oFactura.CodTipoVenta)

        Me.cmbPromocion.DataSource = dtPromociones
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Descripcion"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150

        Me.cmbPromocion.DisplayMember = "Descripcion"
        Me.cmbPromocion.ValueMember = "Promocion"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()

    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' MLVARGAS (06.03.2020): Aunque exista una falla al autorizar la tarjeta se graba a transacciones sin tarjeta
    '--------------------------------------------------------------------------------------------------------------

    Private Sub RegistraTransaccionInconclusa()
        If deslizada = False AndAlso Me.cmbFormaPago.Value = "DPCA" Then
            oFacturaMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, CStr(resultado("AccountNumber")), _
                                                 String.Empty, EBPago.Value, "DPCredito", "Transacción inconclusa", String.Empty, motivo, oFactura.CodVendedor, userAuth)
        End If
    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (30.01.2015): Autorizar pagos con tarjeta DPCard
    '-----------------------------------------------------------------------------
    Private Function AutorizaCargoDPCard() As Boolean

        Dim bResp As Boolean = True
        Dim MontoPago As Decimal = 0.0

        '----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 25/02/2015: Se invoca el Metodo Purchase del Webservice de Karum para realizar la venta
        '----------------------------------------------------------------------------------------------------------------------
        Dim ws As New WSBroker("WS_KARUM", True)
        Dim param As New Hashtable
        Dim codeTran As String
        Dim pagos As Integer = dsFormasPago.Tables(0).Rows.Count
        Dim rows() As DataRow = dsFormasPago.Tables(0).Select("CodFormasPago='DPCA'")
        Dim count As Integer = rows.Length
        If EBPago.Value < (CDec(ebImporteTotal.Value) - CDec(ebTotalPagoCliente.Value)) Then
            codeTran = "7026"
        Else
            codeTran = "4120"
        End If
        param("NoTarjeta") = ebNumTarj.Text.Trim()
        MontoPago = EBPago.Value
        param("Monto") = EBPago.Value
        param("Promocion") = Me.cmbPromocion.Value
        'param("Promocion") = "00"
        param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
        param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
        param("IDTransaccion") = "4120"
        param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
        'param("IDTienda")="D3" &oAppContext.ApplicationConfiguration.Almacen.PadLeft(5,"0")
        param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")

        '--------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/11/2015: Se carga el player que realizo la factura.
        '--------------------------------------------------------------------------------------------------------
        Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
        Dim vendedor As Vendedor = VendedorMgr.Create()
        VendedorMgr.LoadInto(oFactura.CodVendedor, vendedor)

        If deslizada = True Then
            param("Tipo") = "00"
        Else
            param("Tipo") = "01"
        End If

        param("Detalles") = oFactura.Detalle.Tables(0)
        resultado = ws.Purchase(param)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("Success") Then
                If CBool(resultado("Success")) = True Then
                    ebAutorizacion.Text = CStr(resultado("Autorizacion"))

                    '-------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 26/11/2015: Cual la tarjeta es tecleada manualmente toma el nombre del WebService
                    '-------------------------------------------------------------------------------------------------------
                    If deslizada = False Then
                        Me.ClienteDPC = CStr(resultado("TarjetaHabiente"))
                    End If
                    bResp = True

                    '-----------------------------------------------------------------------------
                    ' JNAVA (26.02.2015): Obtenemos datos de KARUM (para ticket y registros)
                    '-----------------------------------------------------------------------------
                    htDatosDPC = resultado
                    '''PRUEBAS
                    htDatosDPC("Transaccion") = CStr(resultado("Transaccion"))
                    htDatosDPC("Autorizacion") = CStr(resultado("Autorizacion"))
                    '''PRUEBAS

                    '-----------------------------------------------------------------------------
                    ' JNAVA (08.04.2015): El número de la tienda debe ser el de KARUM
                    '-----------------------------------------------------------------------------
                    htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                    htDatosDPC("Tarjeta") = Me.ebNumTarj.Text.Trim()
                    htDatosDPC("TarjetaHabiente") = Me.ClienteDPC
                    'htDatosDPC("Monto") = MontoPago
                    htDatosDPC("Vendedor") = vendedor.ID & " " & vendedor.Nombre
                    If deslizada = True Then
                        htDatosDPC("Linea") = "DESLIZADA"
                    Else
                        htDatosDPC("Linea") = "DIGITADA"
                    End If

                    '-----------------------------------------------------------
                    'FLIZARRAGA 25/11/2017: Se obtiene Consecutivo POS del bus
                    '-----------------------------------------------------------
                    htDatosDPC("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")

                    '-----------------------------------------------------------
                    'JNAVA (24.03.2015): Consecutivo POS
                    '-----------------------------------------------------------
                    If Me.cmbPromocion.Value <> "00" Then
                        htDatosDPC("Promocion") = Me.cmbPromocion.Text
                        '------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 20/11/2015: Valida si es que tiene meses sin intereses
                        '------------------------------------------------------------------------------------------------------
                        Dim meses As Integer, strMeses As String = cmbPromocion.Text.Substring(0, 1)
                        If IsNumeric(strMeses) = True Then
                            meses = CInt(strMeses)
                        Else
                            meses = 0
                        End If
                        htDatosDPC("Meses") = CStr(meses)
                    Else
                        htDatosDPC("Promocion") = ""
                        htDatosDPC("Meses") = "0"
                    End If

                    '-------------------------------------------------------------------------------------------
                    ' MLVARGAS (08.11.2019): Si la tarjeta fue tecleada se almacena en TransaccionesSinTarjeta
                    '-------------------------------------------------------------------------------------------
                    Dim idTransaccion As Integer = 0
                    If deslizada = False AndAlso Me.cmbFormaPago.Value = "DPCA" Then
                        idTransaccion = oFacturaMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, CStr(resultado("AccountNumber")), _
                                                             String.Empty, EBPago.Value, "DPCredito", "Transacción inconclusa", String.Empty, motivo, oFactura.CodVendedor, userAuth)                        
                        lstItems.Add(idTransaccion)
                    End If

                    '-------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 08.07.2015: Determinamos si es la primera compra con esta tarjeta de karum
                    '-------------------------------------------------------------------------------------------------------------------
                    'If CInt(htDatosDPC("Transaccion")) = 1 Then bPrimeraCompraKarum = True
                    '----------------------------------------------------------------------------
                    'Saldo Disponible
                    '----------------------------------------------------------------------------
                    MessageBox.Show("El nuevo saldo disponible para el Tarjetahabiente " & Me.ClienteDPC & " es de " & CDec(resultado("SaldoDisponible")).ToString("C"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------
                    'MLVARGAS 09.02.2021: Cuando marca error el servicio de Karum no retorna el numero de cuenta, por lo que no se va a grabar a TransaccionesSinTarjeta 
                    '-------------------------------------------------------------------------------------------------------------------------------------------------------
                    'RegistraTransaccionInconclusa()
                    EscribeLog(CStr(resultado("Mensaje")), "Error al tratar de efectuar la compra con Karum")
                    MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bResp = False
                End If
            Else
                '-------------------------------------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 09.02.2021: Cuando marca error el servicio de Karum no retorna el numero de cuenta, por lo que no se va a grabar a TransaccionesSinTarjeta 
                '-------------------------------------------------------------------------------------------------------------------------------------------------------
                'RegistraTransaccionInconclusa()
            End If
        Else
            '-------------------------------------------------------------------------------------------------------------------------------------------------------
            'MLVARGAS 09.02.2021: Cuando marca error el servicio de Karum no retorna el numero de cuenta, por lo que no se va a grabar a TransaccionesSinTarjeta 
            '-------------------------------------------------------------------------------------------------------------------------------------------------------
            'RegistraTransaccionInconclusa()
            EscribeLog("No hubo respuesta por parte del Webservice", "Error al tratar de efectuar la compra con Karum")
            MessageBox.Show("No hubo respuesta de Credit Card", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResp = False
        End If


        Return bResp

    End Function

    '-----------------------------------------------------------------------------
    'JNAVA (30.01.2015): Agregar pagos con tarjeta DPCard
    '-----------------------------------------------------------------------------
    Private Function AgregarPagoDPCard() As Boolean
        Dim bResp As Boolean = True
        Dim cadena As String = String.Empty
        Dim tarjeta As String

        Dim drTarjetaRow As DataRow
        drTarjetaRow = dsFormasPago.Tables(0).NewRow

        If ebNumTarj.Text.Trim.Length >= 16 Then
            tarjeta = ebNumTarj.Text.Trim
            cadena = tarjeta.Substring(0, 6)
            cadena += "******"
            cadena += tarjeta.Substring(12, 4)
        End If

        With drTarjetaRow

            .Item("DPValeID") = oConfigCierreFI.ConsecutivoPOS - 1 'Se agrega el ConsecutivoPOS 
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = ebCodBanco.Value
            .Item("CodTipoTarjeta") = ebTipoTarjeta.Value
            .Item("NumeroTarjeta") = cadena 'ebNumTarj.Text
            .Item("NumeroAutorizacion") = ebAutorizacion.Text
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = EBPagoCom.Value
            .Item("IngresoComision") = 0 'Decimal.Round(EBPagoCom.Value / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            .Item("IvaComision") = 0 '.Item("ComisionBancaria") - .Item("IngresoComision")
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value
            .Item("NoAfiliacion") = strNoAfiliacion
            .Item("Id_Num_Promo") = Me.cmbPromocion.Value

            dsFormasPago.Tables(0).Rows.Add(drTarjetaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drTarjetaRow = Nothing

        Return bResp
    End Function

    Public Function ObtenerFormasPagoByFacturaID(ByVal FacturaID As Integer) As DataTable

        Dim dtResult As DataTable

        Try

            dtResult = oFacturaFormaPago.Load(FacturaID).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try

        Return dtResult

    End Function

#End Region

#Region "Seguros DPVale" 'JNAVA (26.01.2015): Metodos y Funciones para menejo de los Seguros de DPVale

    '-----------------------------------------------------------------------------
    'JNAVA (06.02.2015): Guardar registro de Seguro de DPVale
    '-----------------------------------------------------------------------------
    Private Sub GuardarSeguroDPVale(ByVal CodTipoVenta As String)

        '-----------------------------------------------------------------------------
        'Revisamos que sea una venta con DPVale
        '-----------------------------------------------------------------------------
        If CodTipoVenta <> "V" Then
            Exit Sub
        End If

        '-----------------------------------------------------------------------------
        ' Confirmamos que la configuracion para generar el seguro este activa
        '-----------------------------------------------------------------------------
        If oConfigCierreFI.GenerarSeguro Then

            '-----------------------------------------------------------------------------
            'Validamos que se realmente se haya cargado o no algun DPVale
            '-----------------------------------------------------------------------------
            If Not Me.oDpvaleSAP Is Nothing OrElse Me.oDpvaleSAP.IDDPVale <> String.Empty Then

                Try

                    '-----------------------------------------------------------------------------
                    ' Guardamos datos en Tabla SegCalzado (BD DPValeTODO)
                    '-----------------------------------------------------------------------------
                    If oFacturaMgr.GrabarSeguroDPVale(Me.oDpvaleSAP.IDDPVale, Beneficiarios, oAppContext.Security.CurrentUser.SessionLoginName) Then

                        '-----------------------------------------------------------------------------
                        ' JNAVA (12.01.2015): Validamos que se hayan cargado los datos del seguro
                        '-----------------------------------------------------------------------------
                        If DatosTicketSeguro.Count > 0 Then
                            '-----------------------------------------------------------------------------
                            ' Imprimimos el Ticket de Venta del Seguro de Vida
                            '-----------------------------------------------------------------------------
                            DatosTicketSeguro("Beneficiarios") = Beneficiarios.Trim
                            ImprimirTicketSeguro()
                        End If

                    End If

                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error al guardar los datos del Seguro de Vida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(ex.ToString, "Ocurrio un error al guardar los datos del Seguro de Vida.")
                End Try

            End If

        End If

    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (09.02.2015): Impresion del ticket de Seguro de Vida de DPVale
    '-----------------------------------------------------------------------------
    Public Sub ImprimirTicketSeguro()

        Try

            Dim EsReImpresion As Boolean = False

ReImprimir:
            '-----------------------------------------------------------------------------------
            ' Ticket del seguro
            '-----------------------------------------------------------------------------------
            'Dim oARReporte As New rptTicketSeguro(DatosTicketSeguro)
            Dim oARReporte As New rptTicketSeguroConfigurable(DatosTicketSeguro)
            oARReporte.Document.Name = "Ticket Seguro"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                oARReporte.PageSettings.PaperHeight = 7
                oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'Dim oReportViewer As New ReportViewerForm
            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            '-----------------------------------------------------------------------------------
            ' Imprimimos ticket del seguro
            '-----------------------------------------------------------------------------------
            Try
                oARReporte.Document.Print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '-----------------------------------------------------------------------------------
            ' ReImprimimos ticket del seguro
            '-----------------------------------------------------------------------------------
            If Not EsReImpresion Then
                EsReImpresion = True
                GoTo ReImprimir
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el ticket de seguro de vida DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el ticket de seguro de vida DPVale-")
        End Try


    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (10.02.2015): Funcion para prerar datos para el ticket de seguros
    '-----------------------------------------------------------------------------
    Public Function PrepararDatosTicket(ByVal CodClienteDPVL As String, ByVal NumQuincenasDPVL As String, ByVal FechaCobroDPVL As Date, ByVal CodTipoVenta As String) As Hashtable

        Dim htDatosTicket As New Hashtable
        Dim dtFinanciamiento As DataTable
        Dim Plaza As String

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos de la plaza
        '-----------------------------------------------------------------------------
        'Plaza = GetPlaza()
        Plaza = oAppSAPConfig.Plaza.Trim
        htDatosTicket("Plaza") = Plaza
        htDatosTicket("Ciudad") = ObtenerDescripcionPlaza()
        htDatosTicket("Direccion") = ObtenerDireccionPlaza()
        htDatosTicket("Caja") = oAppContext.ApplicationConfiguration.NoCaja
        'htDatosTicket("Fecha") = ""
        'htDatosTicket("Hora") = ""

        '-----------------------------------------------------------------------------
        ' Preparamos datos del Financiamiento
        '-----------------------------------------------------------------------------
        Dim Aseguradora As String
        Dim Aseguradora2 As String
        Dim ImpSeg As Decimal
        Dim ImppSeg As Decimal
        Dim NoPoliza As String
        Dim maiseg As String
        Dim seg As String, folseg As String = ""

        '-----------------------------------------------------------------------------
        ' JNAVA (09.06.2015): Division de Plaza
        '-----------------------------------------------------------------------------
        Dim DIVP As String = ""

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos del Financiamiento
        '-----------------------------------------------------------------------------
        dtFinanciamiento = oFacturaMgr.GetDatosFinanciamiento(Plaza)
        If dtFinanciamiento Is Nothing OrElse dtFinanciamiento.Rows.Count <= 0 Then
            htDatosTicket = Nothing
            ImporteSeguro = 0
            GoTo Salir
        End If

        '-----------------------------------------------------------------------------
        ' Sacamos los datos del Financiamiento
        '-----------------------------------------------------------------------------
        For Each oRow As DataRow In dtFinanciamiento.Rows
            Aseguradora = oRow!Aseguradora
            Aseguradora2 = oRow!Aseguradora2
            ImpSeg = oRow!ImpSeg
            ImppSeg = oRow!ImppSeg
            NoPoliza = oRow!NoPoliza
            maiseg = CStr(oRow!maiseg).Trim
            seg = CStr(oRow!seg).Trim
            folseg = CStr(oRow!folseg).Trim
            DIVP = CStr(oRow!DIVP).Trim
        Next

        '-----------------------------------------------------------------------------
        ' Comenzamos a setear datos de Financiamiento
        '-----------------------------------------------------------------------------
        htDatosTicket("Aseguradora") = Aseguradora

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos del Canjeante
        '-----------------------------------------------------------------------------
        oCliente.Clear()
        Me.oClienteMgr.Load(CodClienteDPVL, oCliente, CodTipoVenta)

        '-----------------------------------------------------------------------------
        ' Seteamos datos del cliente
        '-----------------------------------------------------------------------------
        htDatosTicket("NoCanjeante") = CStr(oCliente.CodigoAlterno).PadLeft(10, "0")
        htDatosTicket("Canjeante") = oCliente.NombreCompleto
        htDatosTicket("RFC") = oCliente.RFC
        htDatosTicket("Sexo") = IIf(oCliente.Sexo = "F", "Femenino", "Masculino")

        '-----------------------------------------------------------------------------
        ' Seteamos datos de Financiamiento
        '-----------------------------------------------------------------------------
        'oDpvaleSAP.FechaCobro
        Me.ImporteSeguro = ImpSeg
        htDatosTicket("ImporteFin") = Format((NumQuincenasDPVL * ImpSeg), "c")
        htDatosTicket("MontoSeguro") = Format(ImppSeg, "c")
        htDatosTicket("folseg") = folseg
        htDatosTicket("FechaInicio") = FechaCobroDPVL
        htDatosTicket("Vigencia") = FechaCobroDPVL.AddMonths(NumQuincenasDPVL / 2)
        htDatosTicket("NoPoliza") = NoPoliza
        htDatosTicket("Beneficiarios") = Beneficiarios

        htDatosTicket("DireccionFinanciador") = maiseg
        htDatosTicket("TelefonoFinanciador") = seg
        htDatosTicket("TelefonoInformacion") = seg

        htDatosTicket("Aseguradora2") = Aseguradora2

        '-----------------------------------------------------------------------------
        ' JNAVA (09.06.2015): Seteamos variable general de la division de la plaza
        '-----------------------------------------------------------------------------
        Me.DivPlaza = DIVP

Salir:
        Return htDatosTicket

    End Function

    Private Function ObtenerDescripcionPlaza() As String
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Return oAlmacen.Descripcion
            End If
        End If
    End Function

    Private Function ObtenerDireccionPlaza() As String
        Dim Direccion As String = ""
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Direccion = oAlmacen.DireccionCalle & " " & oAlmacen.DireccionNumExt & " " & oAlmacen.DireccionCP
                Return Direccion
            End If
        End If
    End Function

#End Region

#Region "DPCard Puntos"

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Valida si en el detalle algun artículo es una tarjeta DPCard Puntos
    '----------------------------------------------------------------------------------------------------------------------------

    Private Function IsDPCardPunto() As Boolean
        Dim valido As Boolean = False
        Dim ArtMgr As New CatalogoArticuloManager(oAppContext)
        Dim Art As Articulo = ArtMgr.Create()
        For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
            Art.ClearFields()
            ArtMgr.LoadInto(CStr(row("Codigo")), Art)
            If Art.CodArtProv.Contains("CARD") Then
                Return True
            End If
            'If CStr(row("Codigo")).Contains("DPCARD") Then
            '    Return True
            'End If
        Next
        Return valido
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/04/2015: Valida si en el detalle algun articulo es una tarjeta DPCard Renovar Membresia
    '-----------------------------------------------------------------------------------------------------------------------------

    Private Function IsDPCardPuntosRenewMembership() As Boolean
        Dim valido As Boolean = False
        Dim ArtMr As New CatalogoArticuloManager(oAppContext)
        Dim Art As Articulo = ArtMr.Create()
        For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
            Art.ClearFields()
            ArtMr.LoadInto(CStr(row("Codigo")), Art)
            If Art.CodArtProv.Contains("DPCARD03") = True Or Art.CodArtProv.Contains("DPCARD04") = True Then
                Return True
            End If
            'If CStr(row("Codigo")).IndexOf("DPCARDRENOVACION") <> -1 Then
            '    Return True
            'End If
        Next
        Return valido
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Activa la tarjeta o bonifica puntos
    '-----------------------------------------------------------------------------------------------------------------------------

    Private Sub DPCardPuntos()
        '-----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 16/04/2015: Valida si esta activado los puntos de Lealtad.
        '-----------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.DPCardPuntos Then
            Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
            Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)
            '-------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/04/2015: Valida si el detalle trae una tarjeta DPCard Puntos
            '-------------------------------------------------------------------------------------------------------------------
            If IsDPCardPunto() Then
                If IsDPCardPuntosRenewMembership() = False Then
                    'ActivateDPCardPuntos(oVendedor)
                Else
                    RenewMembership()
                End If
            Else
                Dim payment() As DataRow = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")

                
                'Dim objAmount As Object = Me.dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPCA','DPPT')")
                'ASANCHEZ validamos el monto para que acumule vale de caja si esta activo la validación de karum de caso contrario no lo bonificara
                'Dim objAmount As Object
                'If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                '    objAmount = Me.dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPCA','DPPT')")
                'Else
                '    'ASANCHEZ que no acumule cuanto con vale de caja y acumulara cuando se pague con dpcard 'DPCA',
                '    objAmount = Me.dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPPT','VCJA')")
                'End If

                'Dim MontoAmount As Decimal = 0
                'If IsDBNull(objAmount) = False Then
                '    MontoAmount = CDec(objAmount)                    
                'End If
                'wgomez formas pago blue
                Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                Dim dtFormasPagoNoAcumula As DataTable = FacturaMgr.GetFormasPagoNoAcumula().Tables(0)
                Dim MontoAmount As Decimal = 0

                For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                    Dim bEncontrado As Boolean = False
                    For Each row1 As DataRow In dtFormasPagoNoAcumula.Rows
                        If CStr(row("CodFormasPago")) = CStr(row1("CodFormasPago")) Then
                            bEncontrado = True
                            Exit For
                        End If
                    Next
                    If bEncontrado = False Then
                        MontoAmount = MontoAmount + Math.Round(CDec(row("MontoPago")), 2)
                    End If

                Next

                If MontoAmount > 0 Then
                    If MessageBox.Show("¿Deseas bonificar puntos?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        '----------------------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 25/04/2015: Valida si se bonificara puntos en factura normal o si hay y valida que no haya forma de pago DPCard Credit
                        '----------------------------------------------------------------------------------------------------------------------------------
                        Select Case Me.ModoVenta
                            Case 0
                                BonificaPuntos(oVendedor, MontoAmount)
                            Case 1
                                BonificaPuntosSiHay(oVendedor, MontoAmount)
                        End Select
                    End If
                End If
                'If payment.Length = 0 Then
                '    payment = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPCA'")
                '    If payment.Length = 0 Then
                '        If MessageBox.Show("¿Deseas bonificar puntos?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '            '----------------------------------------------------------------------------------------------------------------------------------
                '            'FLIZARRAGA 25/04/2015: Valida si se bonificara puntos en factura normal o si hay y valida que no haya forma de pago DPCard Credit
                '            '----------------------------------------------------------------------------------------------------------------------------------
                '            Select Case Me.ModoVenta
                '                Case 0
                '                    BonificaPuntos(oVendedor)
                '                Case 1
                '                    BonificaPuntosSiHay(oVendedor)
                '            End Select

                '        Else
                '            'Select Case Me.ModoVenta
                '            '    Case 0
                '            '        BonificaPuntosSinTarjeta(oVendedor, oFactura.FolioSAP, oFactura.SubTotal, oFactura.Total)
                '            '    Case 1
                '            '        If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                '            '            BonificaPuntosSinTarjeta(oVendedor, factura.FolioSAP, factura.SubTotal, factura.Total, True)
                '            '        End If
                '            'End Select
                '        End If
                '    End If
            End If

            'Dim payment() As DataRow = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
            ''---------------------------------------------------------------------------------------------------------------
            ''FLIZARRAGA 16/04/2015: Se valida si es forma de Pago o solo se bonificaran puntos
            ''---------------------------------------------------------------------------------------------------------------
            'If payment.Length > 0 Then
            '    '-----------------------------------------------------------------------------------------------------------
            '    'FLIZARRAGA 25/04/2015: Valida si se canjearan puntos en factura normal o si hay
            '    '-----------------------------------------------------------------------------------------------------------
            '    Select Case Me.ModoVenta
            '        Case 0
            '            CanjearPuntos()
            '        Case 1
            '            CanjearPuntosSiHay()
            '    End Select
            'Else
            '    If MessageBox.Show("¿Deseas bonificar puntos?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        '-----------------------------------------------------------------------------------------------------------
            '        'FLIZARRAGA 25/04/2015: Valida si se bonificara puntos en factura normal o si hay
            '        '-----------------------------------------------------------------------------------------------------------
            '        Select Case Me.ModoVenta
            '            Case 0
            '                BonificaPuntos(oVendedor)
            '            Case 1
            '                BonificaPuntosSiHay(oVendedor)
            '        End Select
            '    Else
            '        Select Case Me.ModoVenta
            '            Case 0
            '                BonificaPuntosSinTarjeta(oVendedor, oFactura.FolioSAP, oFactura.SubTotal, oFactura.Total)
            '            Case 1
            '                If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
            '                    BonificaPuntosSinTarjeta(oVendedor, factura.FolioSAP, factura.SubTotal, factura.Total, True)
            '                End If
            '        End Select
            '    End If
            'End If

            'End If
        End If

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Impresión de la activación de tarjeta DPCard Puntos de Blue Engine.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintTicketDPCardPuntos(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As Object
        Dim provider As Integer = CInt(datos("Provider"))
        If provider = Proveedor.BLUE Then
            rptActivaciondpCard = New rptDPCardPuntos(datos)
            With rptActivaciondpCard
                .Document.Name = "Activacion DPCard Puntos"
                .PageSettings.PaperHeight = 7
                .PageSettings.PaperWidth = 14
                .PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                .Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                .Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                .Run()
            End With
            Try
                rptActivaciondpCard.Document.Print(False, False)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            rptActivaciondpCard = New rptDPCardPuntosKarum(datos)
            With rptActivaciondpCard
                .Document.Name = "Activacion DPCard Puntos"
                .PageSettings.PaperHeight = 7
                .PageSettings.PaperWidth = 14
                .PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                .Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                .Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                .Run()
            End With
            Try
                rptActivaciondpCard.Document.Print(False, False)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 28/02/2020: Agregar Id's de transacciones con tarjeta CLUB DP que fueron tecleadas
    '----------------------------------------------------------------------------------------------------------------------------
    Private Sub AgregaIdsTransaccionManual(ByVal lista As List(Of Integer))
        If lista.Count > 0 Then
            For Each item As Integer In lista
                lstItems.Add(item)
            Next
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/04/2015: Agrega la forma de pago DPCard Puntos
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub AgregarFormaPagoDPCardPunto()
        Dim frmCanjear As New frmDPCardPuntosAgregar(DPCardOperation.CANJEAR)
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)
        Dim params As New Hashtable
        params("referenceId3") = ""
        params("referenceId4") = ""
        params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
        params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
        params("SupervisorCode") = oFactura.CodVendedor
        params("SupervisorName") = oVendedor.Nombre
        params("SellerCode") = oFactura.CodVendedor
        params("SellerName") = oVendedor.Nombre
        frmCanjear.Params = params
        frmCanjear.player = oVendedor.Nombre
        frmCanjear.codVendedor = oFactura.CodVendedor
        frmCanjear.monto = EBPago.Value
        frmCanjear.ShowDialog()

        If frmCanjear.DialogResult = DialogResult.OK Then
            AgregaIdsTransaccionManual(frmCanjear.lstIds)            
            If CDec(frmCanjear.DatosPuntos("Monto")) <= (CDec(ebImporteTotal.Value) - CDec(ebTotalPagoCliente.Value)) Then
                Me.EBPago.Value = CDec(frmCanjear.DatosPuntos("Monto"))
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Me.NombreClienteCanje = CStr(frmCanjear.DatosPuntos("NombreCliente"))
                Else
                    Me.NombreClienteCanje = CStr(frmCanjear.DatosPuntos("CustomerName"))
                End If

                AgregarPagoDPCardPuntos(frmCanjear.DatosPuntos)
                If frmCanjear.DPCardManual Then
                    oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmCanjear.userAuth, frmCanjear.DatosPuntos("CardId"), CDec(frmCanjear.DatosPuntos("Monto")), , 1, frmCanjear.Autorizado)
                ElseIf frmCanjear.Autorizado Then
                    oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmCanjear.userAuth, frmCanjear.DatosPuntos("CardId"), CDec(frmCanjear.DatosPuntos("Monto")), , 1, frmCanjear.Autorizado)
                End If
            Else
                MessageBox.Show("El importe es mayor que la cantidad a pagar", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    '-----------------------------------------------------------------------------
    'FLIZARRAGA 30/01/2015: Agregar pagos con tarjeta DPCard Puntos Lealtad
    '-----------------------------------------------------------------------------
    Private Function AgregarPagoDPCardPuntos(ByVal datos As Hashtable) As Boolean
        Dim bResp As Boolean = True

        Dim drTarjetaRow As DataRow
        drTarjetaRow = dsFormasPago.Tables(0).NewRow

        With drTarjetaRow

            .Item("DPValeID") = 0 'Se agrega el ConsecutivoPOS 
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = ebCodBanco.Value
            .Item("CodTipoTarjeta") = ebTipoTarjeta.Value
            .Item("NumeroTarjeta") = CStr(datos("CardId"))
            .Item("NumeroAutorizacion") = ebAutorizacion.Text
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = EBPagoCom.Value
            .Item("IngresoComision") = 0 'Decimal.Round(EBPagoCom.Value / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            .Item("IvaComision") = 0 '.Item("ComisionBancaria") - .Item("IngresoComision")
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = CDec(datos("Monto"))
            .Item("NoAfiliacion") = strNoAfiliacion
            .Item("Id_Num_Promo") = 0

            dsFormasPago.Tables(0).Rows.Add(drTarjetaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        Me.pagoDPPT = datos
        drTarjetaRow = Nothing

        Return bResp
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Canjea puntos por artículos DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function CanjearPuntos(ByRef bResult As Boolean) As Hashtable
        Dim resultado As Hashtable
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Try
            Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)
            Dim params As New Hashtable
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            Dim CardId As String = ""
            Dim tipo_ As String = String.Empty
            If CStr(Me.pagoDPPT("CardId")).Length = 16 Or CStr(Me.pagoDPPT("CardId")).Length = 13 Then
                Dim bin As Integer = CInt(CStr(Me.pagoDPPT("CardId")).Substring(0, 6))
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Me.Provider = Proveedor.KARUM
                    Else
                        Me.Provider = Proveedor.BLUE
                    End If
                Else
                    Me.Provider = Proveedor.BLUE
                    'tipo_ = consulta_bin_tipo_blue(CStr(Me.pagoDPPT("CardId")))
                    If CStr(Me.pagoDPPT("CardId")).Trim().Length = 13 Then
                        tipo_ = "CFB"
                    Else
                        tipo_ = consulta_bin_tipo_blue(CStr(Me.pagoDPPT("CardId")).Trim())
                    End If
                End If

                CardId = CStr(Me.pagoDPPT("CardId"))
            Else
                Me.Provider = Proveedor.KARUM
                CardId = CStr(Me.pagoDPPT("CardId")).PadLeft(16, "0")
            End If
            'Dim bin As Integer = CInt(CStr(Me.pagoDPPT("CardId")).Substring(0, 6))
            'If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
            '    Me.Provider = Proveedor.KARUM
            'Else
            '    Me.Provider = Proveedor.BLUE
            'End If
            params("CardId") = CardId
            'params("CardId") = CStr(Me.pagoDPPT("CardId"))
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")

            'ASANCHEZ 06/04/2021 Validación para canjear puntos de blue 
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                '---------------------------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (14.09.2015): Enviamos en los parametros de Amount y TotalAmount del Canje de Puntos (BLUE) el monto con IVA
                '---------------------------------------------------------------------------------------------------------------------------------------------------
                'params("amount") = CStr(Math.Round(CDec(Me.pagoDPPT("Monto")) / (oAppContext.ApplicationConfiguration.IVA + 1), 2))
                If Me.Provider = Proveedor.BLUE Then
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("totalAmount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("ReferenceId4") = ""
                Else
                    params("totalAmount") = 0
                    params("tipo") = CStr(Me.pagoDPPT("tipo"))
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    Dim canje As Decimal = 0
                    Dim count As Integer = GetCuentaFormaPagoPuntos(dsFormasPago.Tables(0), canje)
                    If dsFormasPago.Tables(0).Rows.Count > 1 AndAlso count > 0 Then
                        canje = oFactura.Total - canje
                        params("ReferenceId4") = canje.ToString("##,##0.00").Replace(",", "")
                        'params("ReferenceId4") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    ElseIf count > 0 Then
                        params("ReferenceId4") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    End If
                End If

                '-----------------------------------------------------------------------------------------------------------
                ' JNAVA (22.09.2015): se corrigio que en la cancelacion de canje de puntos se envie la fecha de la factura
                '                     asi como el almacen correcto
                '-----------------------------------------------------------------------------------------------------------
                'params("ticketid") = fecha.ToString("yyyyMMddHHmmss") 'oFactura.FolioSAP
                params("ticketid") = FechaSAP.ToString("yyyyMMddHHmmss")
                If Me.Provider = Proveedor.BLUE Then
                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                Else
                    params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------------

                Dim pagos As String = "", codFormaPago As String = ""
                For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                    codFormaPago = CStr(row("CodFormasPago"))
                    If codFormaPago = "DPVL" Then
                        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                    Else
                        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                    End If
                Next
                pagos = pagos.Remove(pagos.Length - 1, 1)
                params("ReferenceId3") = pagos

                params("SupervisorCode") = oFactura.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = oFactura.CodVendedor
                params("SellerName") = oVendedor.Nombre
                params("localHour") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                Dim producto As String = ""
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                    total = 0
                    descSistema = 0
                    descuento = 0
                    unitPrice = 0
                    cantidad = 0
                    articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                    cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                    total = row("Total")
                    descSistema = row("Descuento")
                    total = total - descSistema
                    descuento = row("Adicional")
                    descuento = total * (descuento / 100)
                    unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                    unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = unitPrice * cantidad
                    If Me.Provider = Proveedor.BLUE Then
                        producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Else
                        producto &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                    End If

                Next
                producto = producto.Remove(producto.Length - 1, 1)
                If Me.Provider = Proveedor.KARUM Then
                    params("ConsecutivoKarum") = oConfigCierreFI.ConsecutivoPuntosPOS
                End If
                params("products") = producto
                resultado = ws.Redeem(params)
                'If Me.Provider = Proveedor.KARUM Then
                '    ActualizarConsecutivoPuntosPOS()
                'End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            PrintHashtable(resultado)
                            resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                            resultado("Provider") = Me.Provider
                            If Me.Provider = Proveedor.KARUM Then
                                resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                                resultado("TipoReporte") = "CAN"
                                resultado("tipo") = CStr(Me.pagoDPPT("tipo"))
                                resultado("Monto") = CDec(Me.pagoDPPT("Monto"))
                                resultado("NombreCliente") = Me.NombreClienteCanje
                            End If
                        Else
                            If CInt(resultado("ResultID")) = -27 Then
                                oAppContext.Security.CloseImpersonatedSession()
                                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Canje") = True Then
                                    params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                    resultado = ws.Redeem(params)
                                    If resultado.Count > 0 Then
                                        If resultado.ContainsKey("ResultID") = True Then
                                            If CInt(resultado("ResultID")) >= 0 Then
                                                PrintHashtable(resultado)
                                                resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                                resultado("TipoReporte") = "CAN"
                                                resultado("Provider") = Me.Provider
                                            End If
                                        Else
                                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            'Throw New ApplicationException(CStr(resultado("Description")))
                                            bResult = False
                                        End If
                                    End If
                                Else
                                    oAppContext.Security.CloseImpersonatedSession()
                                    'Throw New ApplicationException("Agrega otra forma de pago")
                                    MessageBox.Show("Es necesario agregar otra forma de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    bResult = False
                                End If
                                oAppContext.Security.CloseImpersonatedSession()
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                bResult = False
                                'Throw New ApplicationException(CStr(resultado("Description")))
                            End If
                        End If
                    End If
                End If
            Else
                'ASANCHEZ 06/04/2021 Nueva forma del collect en blue
                If tipo_.Trim() = "DB" Then
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("totalAmount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("ReferenceId4") = ""
                    '-----------------------------------------------------------------------------------------------------------
                    ' JNAVA (22.09.2015): se corrigio que en la cancelacion de canje de puntos se envie la fecha de la factura
                    '                     asi como el almacen correcto
                    '-----------------------------------------------------------------------------------------------------------
                    'params("ticketid") = fecha.ToString("yyyyMMddHHmmss") 'oFactura.FolioSAP
                    params("ticketid") = FechaSAP.ToString("yyyyMMddHHmmss")

                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja

                    '---------------------------------------------------------------------------------------------------------------------------------------------------

                    Dim pagos As String = "", codFormaPago As String = ""
                    For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                        codFormaPago = CStr(row("CodFormasPago"))
                        If codFormaPago = "DPVL" Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If
                    Next
                    pagos = pagos.Remove(pagos.Length - 1, 1)
                    params("ReferenceId3") = pagos

                    params("SupervisorCode") = oFactura.CodVendedor
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = oFactura.CodVendedor
                    params("SellerName") = oVendedor.Nombre
                    params("localHour") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    Dim producto As String = ""
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                        cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                        total = row("Total")
                        descSistema = row("Descuento")
                        total = total - descSistema
                        descuento = row("Adicional")
                        descuento = total * (descuento / 100)
                        unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                        unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                        total = unitPrice * cantidad
                        producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Next
                    producto = producto.Remove(producto.Length - 1, 1)
                    params("products") = producto
                    resultado = ws.Redeem(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) >= 0 Then
                                PrintHashtable(resultado)
                                resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                resultado("Provider") = Me.Provider
                            Else
                                If CInt(resultado("ResultID")) = -27 Then
                                    oAppContext.Security.CloseImpersonatedSession()
                                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Canje") = True Then
                                        params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                        resultado = ws.Redeem(params)
                                        If resultado.Count > 0 Then
                                            If resultado.ContainsKey("ResultID") = True Then
                                                If CInt(resultado("ResultID")) >= 0 Then
                                                    PrintHashtable(resultado)
                                                    resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                                    resultado("TipoReporte") = "CAN"
                                                    resultado("Provider") = Me.Provider
                                                End If
                                            Else
                                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                'Throw New ApplicationException(CStr(resultado("Description")))
                                                bResult = False
                                            End If
                                        End If
                                    Else
                                        oAppContext.Security.CloseImpersonatedSession()
                                        'Throw New ApplicationException("Agrega otra forma de pago")
                                        MessageBox.Show("Es necesario agregar otra forma de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    End If
                                    oAppContext.Security.CloseImpersonatedSession()
                                Else
                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    bResult = False
                                    'Throw New ApplicationException(CStr(resultado("Description")))
                                End If
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetCollect As Dictionary(Of String, Object)
                    oBluegetCollect = New Dictionary(Of String, Object)
                    oBluegetCollect.Add("cardId", CardId.Trim())
                    oBluegetCollect.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                    oBluegetCollect.Add("amount", CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", ""))
                    oBluegetCollect.Add("totalAmount", oFactura.Total.ToString("##,##0.00").Replace(",", ""))
                    oBluegetCollect.Add("ticketId", oFactura.Referencia)
                    oBluegetCollect.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    Dim pagos As String = "", codFormaPago As String = ""
                    For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                        codFormaPago = CStr(row("CodFormasPago"))
                        If codFormaPago = "DPVL" Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If
                    Next
                    oBluegetCollect.Add("referenceId3", pagos)
                    oBluegetCollect.Add("referenceId4", "")
                    oBluegetCollect.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("supervisorCod", oFactura.CodVendedor)
                    oBluegetCollect.Add("supervisorName", oVendedor.Nombre)
                    oBluegetCollect.Add("sellerCode", oFactura.CodVendedor)
                    oBluegetCollect.Add("sellerName", oVendedor.Nombre)
                    oBluegetCollect.Add("version", "X")
                    Dim producto As String = ""
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                        cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                        total = row("Total")
                        descSistema = row("Descuento")
                        total = total - descSistema
                        descuento = row("Adicional")
                        descuento = total * (descuento / 100)
                        unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                        unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                        total = unitPrice * cantidad

                        'producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"

                        'producto &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                        'wgomez cambiar precio total por precio unitario 
                        producto &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                        'producto &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    Next
                    producto = producto.Remove(producto.Length - 1, 1)
                    oBluegetCollect.Add("localHour", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))
                    oBluegetCollect.Add("products", producto)
                    Dim ws_1 As New WSBroker("blue_api_s1", "Redeem")
                    Dim rs_ As Dictionary(Of String, Object)
                    resultado = ws_1.nuevos_servicios_blue(oBluegetCollect)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) > 0 Then
                                resultado("ConsecutivoPOS") = CStr(resultado("ResultID"))
                                resultado("TipoReporte") = "CAN"


                                resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                                resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                resultado("tipo") = CStr(Me.pagoDPPT("tipo"))
                                resultado("Monto") = CDec(Me.pagoDPPT("Monto"))
                                resultado("NombreCliente") = Me.NombreClienteCanje
                                resultado("CustomerName") = Me.NombreClienteCanje
                                resultado("CardId") = CardId.Trim()
                                PrintHashtable(resultado)

                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(CStr(resultado("Description")) + " - en el servicio de Redeem blue", "Caneje WS Redeem Blue")
                            End If

                        End If
                        oAppContext.Security.CloseImpersonatedSession()

                    Else
                        EscribeLog("No se encontro Resultado del servicio de Redeem blue", "Caneje WS Redeem Blue")
                        oAppContext.Security.CloseImpersonatedSession()
                    End If
                End If

            End If

           
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al canjear puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return resultado
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/11/2016: Retorna la cuenta de la forma de pago de puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetCuentaFormaPagoPuntos(ByVal dtFormasPago As DataTable, ByRef canje As Decimal)
        Dim cuenta As Integer = 0
        For Each row As DataRow In dtFormasPago.Rows
            If CStr(row("CodFormasPago")).Trim() <> "DPPT" Then
                canje += CDec(row("MontoPago"))
            End If
        Next
        For Each row As DataRow In dtFormasPago.Rows
            If CStr(row("CodFormasPago")).Trim() = "DPPT" Then
                cuenta += 1
            End If
        Next
        Return cuenta
    End Function

    Private Sub AddValuesToHashable(ByRef ObjetoOrigen As Hashtable, ByVal Valores As Hashtable)
        For Each atributo As String In Valores.Keys
            ObjetoOrigen(atributo) = Valores(atributo)
        Next
    End Sub


    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Bonifica puntos a la tarjeta DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub BonificaPuntos(ByVal oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor, Optional ByVal Monto As Decimal = 0)
        Try
            'wgomez formas pago blue
            Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim dtFormasPagoNoAcumula As DataTable = FacturaMgr.GetFormasPagoNoAcumula().Tables(0)
            Dim MontoBlue As Decimal = 0

            For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                Dim bEncontrado As Boolean = False
                For Each row1 As DataRow In dtFormasPagoNoAcumula.Rows
                    If CStr(row("CodFormasPago")) = CStr(row1("CodFormasPago")) Then
                        bEncontrado = True
                        Exit For
                    End If
                Next
                If bEncontrado = False Then
                    MontoBlue = MontoBlue + Math.Round(CDec(row("MontoPago")), 2)
                End If

            Next


            Dim frmAplicaPuntos As New frmDPCardPuntosAgregar(DPCardOperation.AGREGAR)
            frmAplicaPuntos.CodTipoVenta = oFactura.CodTipoVenta
            Dim payments() As DataRow = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPCA'")
            If payments.Length > 0 Then
                frmAplicaPuntos.PagoDPCard = True
            End If
            Dim params As New Hashtable
            params("TicketId") = oFactura.Referencia
            'params("Amount") = oFactura.SubTotal
            'params("TotalAmount") = oFactura.Total
            'params("Amount") = Monto / (1 + oAppContext.ApplicationConfiguration.IVA)
            'params("Amount") = MontoBlue / (1 + oAppContext.ApplicationConfiguration.IVA)
            params("Amount") = MontoBlue
            params("TotalAmount") = oFactura.Total
            Dim pagos As String = "", codFormaPago As String = ""


            For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                codFormaPago = CStr(row("CodFormasPago"))
                If codFormaPago = "DPVL" Then
                    pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                Else
                    pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                End If
            Next
            params("FormasPago") = pagos.Remove(pagos.Length - 1, 1)
            params("ReferenceId4") = ""
            params("SupervisorCode") = oFactura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = oFactura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            params("NoAssigned1") = ""
            params("NoAssigned2") = ""
            Dim product As String = "", productKarum As String = ""
            Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
            Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
            Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
            Dim cantidad As Decimal = 0
            For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                total = 0
                descSistema = 0
                descuento = 0
                unitPrice = 0
                cantidad = 0
                articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                total = row("Total")
                descSistema = row("Descuento")
                total = total - descSistema
                descuento = row("Adicional")
                descuento = total * (descuento / 100)

                unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                total = unitPrice * cantidad
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    If Me.Provider = Proveedor.BLUE Then
                        product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Else
                        product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                    End If
                Else
                    'product &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'wgomez cambio de precio total al precio unitario
                    'product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                End If

            Next
            params("Products") = product.Remove(product.Length - 1, 1)
            If oConfigCierreFI.ServiciosBlueBonificacion = "True" Then
                params("CustomerName") = ""
            End If

            frmAplicaPuntos.Params = params
            frmAplicaPuntos.player = oVendedor.Nombre
            frmAplicaPuntos.codVendedor = oFactura.CodVendedor
            frmAplicaPuntos.monto = MontoBlue
            frmAplicaPuntos.ShowDialog()
            If frmAplicaPuntos.DialogResult = DialogResult.OK Then
                AgregaIdsTransaccionManual(frmAplicaPuntos.lstIds)
                If Not frmAplicaPuntos.DatosPuntos Is Nothing Then
                    frmAplicaPuntos.DatosPuntos("CodVendedor") = oVendedor.ID
                    frmAplicaPuntos.DatosPuntos("TipoReporte") = "BON"
                    Dim dato As New Hashtable
                    If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                        frmAplicaPuntos.DatosPuntos("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    Else
                        frmAplicaPuntos.DatosPuntos("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                        'frmAplicaPuntos.DatosPuntos("CustomerName") = ""
                    End If
                    dato("NoTarjeta") = frmAplicaPuntos.DatosPuntos("CardId")
                    dato("CodDPCardPunto") = "BON"
                    dato("Provider") = frmAplicaPuntos.Provider

                    frmAplicaPuntos.DatosPuntos("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                    If IsRedeem = False Then
                        oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                    Else
                        dato("CodDPCardPunto") = "C/B"
                        oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                    End If
                    If frmAplicaPuntos.DPCardManual Then
                        oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmAplicaPuntos.userAuth, frmAplicaPuntos.DatosPuntos("CardId"), CDec(Me.ebImporteTotal.Value), 1, , frmAplicaPuntos.Autorizado)
                    ElseIf frmAplicaPuntos.Autorizado Then
                        oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmAplicaPuntos.userAuth, frmAplicaPuntos.DatosPuntos("CardId"), CDec(Me.ebImporteTotal.Value), 1, , frmAplicaPuntos.Autorizado)
                    End If
                    MessageBox.Show("La tarjeta se leyo correctamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    PrintTicketDPCardPuntos(frmAplicaPuntos.DatosPuntos)
                Else
                    MessageBox.Show(frmAplicaPuntos.ErrorDPCard, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show(frmAplicaPuntos.ErrorDPCard, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al bonificar puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2015: Bonifica puntos en el Si Hay siempre y cuando se facture DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub BonificaPuntosSiHay(ByVal oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor, Optional ByVal Monto As Decimal = 0)
        Try
            If Me.ModoVenta = 1 Then
                If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                    Dim frmAplicaPuntos As New frmDPCardPuntosAgregar(DPCardOperation.AGREGAR)
                    frmAplicaPuntos.CodTipoVenta = oFactura.CodTipoVenta
                    Dim payments() As DataRow = Me.dsFormasPago.Tables(0).Select("CodFormasPago='DPCA'")
                    If payments.Length > 0 Then
                        frmAplicaPuntos.PagoDPCard = True
                    End If
                    Dim params As New Hashtable
                    Dim pedido As New Pedidos(pedidoId)
                    params("TicketId") = factura.FolioSAP
                    'params("Amount") = factura.SubTotal
                    'params("TotalAmount") = factura.Total
                    params("Amount") = Monto / (1 + oAppContext.ApplicationConfiguration.IVA)
                    params("TotalAmount") = Monto
                    Dim pagos As String = "", codFormaPago As String = ""
                    For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                        codFormaPago = CStr(row("CodFormasPago"))
                        If codFormaPago = "DPVL" Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If
                    Next
                    params("FormasPago") = pagos.Remove(pagos.Length - 1, 1)
                    params("ReferenceId4") = ""
                    params("SupervisorCode") = factura.CodVendedor
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = factura.CodVendedor
                    params("SellerName") = oVendedor.Nombre
                    params("NoAssigned1") = ""
                    params("NoAssigned2") = ""
                    Dim product As String = "", productKarum As String = ""
                    Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                    Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In DataSetSiHay.Tables("ArticulosConExistencia").Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                        cantidad = Math.Round(CDec(row("Cantidad")), 2)
                        total = Math.Round(CDec(row("Total")), 2)
                        descSistema = Math.Round(CDec(row("Descuento")), 2)
                        total = total - descSistema
                        descuento = Math.Round(CDec(row("Adicional")), 2)
                        descuento = total * (descuento / 100)
                        total -= descuento
                        unitPrice = total / cantidad
                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                            If Me.Provider = Proveedor.BLUE Then
                                product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                            Else
                                productKarum &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                            End If
                            'bonificación sihay
                        Else
                            product &= articulo.CodArticulo & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                        End If
                    Next
                    params("Products") = product.Remove(product.Length - 1, 1)
                    params("ProductsKarum") = productKarum.Remove(product.Length - 1, 1)
                    frmAplicaPuntos.Params = params
                    frmAplicaPuntos.player = oVendedor.Nombre
                    frmAplicaPuntos.ShowDialog()
                    If frmAplicaPuntos.DialogResult = DialogResult.OK Then
                        AgregaIdsTransaccionManual(frmAplicaPuntos.lstIds)
                        If Not frmAplicaPuntos.DatosPuntos Is Nothing Then
                            frmAplicaPuntos.DatosPuntos("CodVendedor") = oVendedor.ID
                            frmAplicaPuntos.DatosPuntos("TipoReporte") = "BON"
                            Dim dato As New Hashtable
                            dato("NoTarjeta") = frmAplicaPuntos.DatosPuntos("CardId")
                            dato("CodDPCardPunto") = "BON"
                            dato("Provider") = frmAplicaPuntos.Provider
                            frmAplicaPuntos.DatosPuntos("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                            frmAplicaPuntos.DatosPuntos("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            pedido.UpdateDPCardPuntos(pedido.PedidoID, dato)
                            oFacturaMgr.ActualizaNoDPCardPuntos(factura.FacturaID, dato)
                            If frmAplicaPuntos.DPCardManual Then
                                oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmAplicaPuntos.userAuth, frmAplicaPuntos.DatosPuntos("CardId"), CDec(Me.ebImporteTotal.Value), 1, , frmAplicaPuntos.Autorizado)
                            ElseIf frmAplicaPuntos.Autorizado Then
                                oFacturaMgr.insertAutLealtad(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, frmAplicaPuntos.userAuth, frmAplicaPuntos.DatosPuntos("CardId"), CDec(Me.ebImporteTotal.Value), 1, , frmAplicaPuntos.Autorizado)
                            End If
                            PrintTicketDPCardPuntos(frmAplicaPuntos.DatosPuntos)
                        Else
                            MessageBox.Show(frmAplicaPuntos.ErrorDPCard, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show(frmAplicaPuntos.ErrorDPCard, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Bonificar Puntos Si Hay")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 06/04/2015: Muestra los puntos perdidos por no usar o tener DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function BonificaPuntosSinTarjeta(ByVal oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor, ByVal TicketId As String, ByVal subtotalAmount As Decimal, ByVal totalAmount As Decimal, Optional ByVal SiHay As Boolean = False) As Decimal
        Dim puntos As Decimal = 0
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        params("CardId") = ""
        params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
        params("Amount") = subtotalAmount
        params("TotalAmount") = totalAmount
        params("TicketId") = TicketId
        params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
        Dim pagos As String = "", codFormaPago As String = ""
        For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
            codFormaPago = CStr(row("CodFormasPago"))
            If codFormaPago = "DPVL" Then
                pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
            Else
                pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
            End If
        Next
        params("ReferenceId3") = pagos.Remove(pagos.Length - 1, 1)
        params("ReferenceId4") = ""
        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
        params("SupervisorCode") = oVendedor.ID
        params("SupervisorName") = oVendedor.Nombre
        params("SellerCode") = oVendedor.ID
        params("SellerName") = oVendedor.Nombre
        Dim product As String = ""
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0
        If SiHay = True Then
            For Each row As DataRow In DataSetSiHay.Tables("ArticulosConExistencia").Rows
                total = 0
                descSistema = 0
                descuento = 0
                unitPrice = 0
                cantidad = 0
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                total = Math.Round(CDec(row("Total")), 2)
                descSistema = Math.Round(CDec(row("Descuento")), 2)
                total = total - descSistema
                descuento = Math.Round(CDec(row("Adicional")), 2)
                descuento = total * (descuento / 100)
                total -= descuento
                unitPrice = total / cantidad
                product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
            Next
            params("Products") = product.Remove(product.Length - 1, 1)
        Else
            For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                total = 0
                descSistema = 0
                descuento = 0
                unitPrice = 0
                cantidad = 0
                articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                total = Math.Round(CDec(row("Total")), 2)
                descSistema = Math.Round(CDec(row("Descuento")), 2)
                total = total - descSistema
                descuento = Math.Round(CDec(row("Adicional")), 2)
                descuento = total * (descuento / 100)
                total -= descuento
                unitPrice = total / cantidad
                product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
            Next
            params("Products") = product.Remove(product.Length - 1, 1)
        End If
        params("NoAssigned1") = ""
        params("NoAssigned2") = ""
        resultado = ws.Collect(params)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("ResultID") = True Then
                If CInt(resultado("ResultID")) >= 0 Then
                    puntos = CDec(resultado("TransactionPoints"))
                End If
            End If
        End If
        Return puntos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2015: Canjea articulos en el si hay siempre y cuando se Facture DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------
    'JNAVA (30.09.2015): Se realizaron correcciones para que se tome el detalle en base al detalle de la venta y no al pedido
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function CanjearPuntosSiHay(ByRef bResult As Boolean) As Hashtable

        Dim resultado As Hashtable
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim tipo_ As String = String.Empty
        Try
            Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
            'Dim pedido As New Pedidos(pedidoId)
            oVendedor.ClearFields()
            'oVendedoresMgr.LoadInto(pedido.CodVendedor.CodVendedor, oVendedor)
            oVendedoresMgr.LoadInto(oFactura.CodVendedor, oVendedor)
            Dim params As New Hashtable
            Dim CardId As String = ""
            If CStr(Me.pagoDPPT("CardId")).Length = 16 Then
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(CStr(Me.pagoDPPT("CardId")).Substring(0, 6))
                    If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Me.Provider = Proveedor.KARUM
                    Else
                        Me.Provider = Proveedor.BLUE
                    End If
                Else
                    Me.Provider = Proveedor.BLUE
                    tipo_ = consulta_bin_tipo_blue(CStr(Me.pagoDPPT("CardId")))
                End If

                CardId = CStr(Me.pagoDPPT("CardId"))
            Else
                Me.Provider = Proveedor.KARUM
                CardId = CStr(Me.pagoDPPT("CardId")).PadLeft(16, "0")
                'Me.pagoDPPT("CardId") = CStr(Me.pagoDPPT("CardId")).PadLeft(16, "0")
            End If
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            params("CardId") = CardId
            'params("CardId") = CStr(Me.pagoDPPT("CardId"))
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            'Valida que este activo los servicios de Karum o de blue respectivamente
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                '---------------------------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (30.09.2015): Enviamos en los parametros de Amount y TotalAmount del Canje de Puntos (BLUE) el monto con IVA
                '---------------------------------------------------------------------------------------------------------------------------------------------------
                'params("amount") = CStr(Math.Round(CDec(Me.pagoDPPT("Monto")) / (oAppContext.ApplicationConfiguration.IVA + 1), 2))
                If Me.Provider = Proveedor.BLUE Then
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("totalAmount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("ReferenceId4") = ""
                Else
                    params("totalAmount") = 0
                    params("tipo") = CStr(Me.pagoDPPT("tipo"))
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    Dim canje As Decimal = 0
                    Dim count As Integer = GetCuentaFormaPagoPuntos(dsFormasPago.Tables(0), canje)
                    If dsFormasPago.Tables(0).Rows.Count > 1 AndAlso count > 0 Then
                        canje = oFactura.Total - canje
                        params("ReferenceId4") = canje.ToString("##,##0.00").Replace(",", "")
                        'params("ReferenceId4") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    ElseIf count > 0 Then
                        params("ReferenceId4") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    End If
                End If
                '-----------------------------------------------------------------------------------------------------------
                ' JNAVA (30.09.2015): se corrigio que en la cancelacion de canje de puntos se envie la fecha de la factura
                '                     asi como el almacen correcto
                '-----------------------------------------------------------------------------------------------------------
                'params("ticketid") = fecha.ToString("yyyyMMddHHmmss") 'oFactura.FolioSAP
                params("ticketid") = FechaSAP.ToString("yyyyMMddHHmmss")
                If Me.Provider = Proveedor.BLUE Then
                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                Else
                    params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                End If
                '---------------------------------------------------------------------------------------------------------------------------------------------------

                Dim pagos As String = "", codFormaPago As String = ""
                For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                    codFormaPago = CStr(row("CodFormasPago"))
                    If codFormaPago = "DPVL" Then
                        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                    Else
                        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                    End If
                Next
                pagos = pagos.Remove(pagos.Length - 1, 1)
                params("ReferenceId3") = pagos
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                params("SupervisorCode") = oFactura.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = oFactura.CodVendedor
                params("SellerName") = oVendedor.Nombre
                params("localHour") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")

                Dim producto As String = ""
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                'For Each row As PedidoDetalles In pedido.PedidosDetalles
                For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                    total = 0
                    descSistema = 0
                    descuento = 0
                    unitPrice = 0
                    cantidad = 0
                    articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                    cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                    total = row("Total")
                    descSistema = row("Descuento")
                    total = total - descSistema
                    descuento = row("Adicional")
                    descuento = total * (descuento / 100)
                    unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                    unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = unitPrice * cantidad
                    If Me.Provider = Proveedor.BLUE Then
                        producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Else
                        producto &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                    End If
                Next
                producto = producto.Remove(producto.Length - 1, 1)
                params("products") = producto
                If Me.Provider = Proveedor.KARUM Then
                    params("ConsecutivoKarum") = oConfigCierreFI.ConsecutivoPuntosPOS
                End If
                resultado = ws.Redeem(params)
                'If Me.Provider = Proveedor.KARUM Then
                '    ActualizarConsecutivoPuntosPOS()
                'End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            PrintHashtable(resultado)
                            resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                            resultado("Provider") = Me.Provider
                            If Me.Provider = Proveedor.KARUM Then
                                resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                                resultado("TipoReporte") = "CAN"
                                resultado("tipo") = CStr(Me.pagoDPPT("tipo"))
                                resultado("Monto") = CDec(Me.pagoDPPT("Monto"))
                                resultado("NombreCliente") = Me.NombreClienteCanje
                            End If
                            '----------------------------------------------------------------------
                            'JNAVA (30.09.2015): Comentado por que ya se hace despues 
                            '----------------------------------------------------------------------
                            'pedido.UpdateDPCardPuntos(pedido.PedidoID, dato)
                            'If DataSetSiHay.Tables("ArticulosConExistencia").Rows.Count > 0 Then
                            '    oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                            'End If
                            'PrintTicketDPCardPuntos(resultado)
                            '----------------------------------------------------------------------
                        Else
                            If CInt(resultado("ResultID")) = -27 Then
                                oAppContext.Security.CloseImpersonatedSession()
                                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Canje") = True Then
                                    params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                    resultado = ws.Redeem(params)
                                    If resultado.Count > 0 Then
                                        If resultado.ContainsKey("ResultID") = True Then
                                            If CInt(resultado("ResultID")) >= 0 Then
                                                PrintHashtable(resultado)
                                                resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                                resultado("TipoReporte") = "CAN"
                                                resultado("Provider") = Me.Provider
                                                '----------------------------------------------------------------------
                                                'JNAVA (30.09.2015): Comentado por que ya se hace despues 
                                                '----------------------------------------------------------------------
                                                'Dim dato As New Hashtable
                                                'dato("NoTarjeta") = CStr(resultado("CardId"))
                                                'dato("CodDPCardPunto") = "CAN"
                                                'oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                                                'PrintTicketDPCardPuntos(resultado)
                                                '----------------------------------------------------------------------
                                            End If
                                        Else
                                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            bResult = False
                                            'Throw New ApplicationException(CStr(resultado("Description")))
                                        End If
                                    End If
                                Else
                                    oAppContext.Security.CloseImpersonatedSession()
                                    'Throw New ApplicationException("Agrega otra forma de pago")
                                    MessageBox.Show("Es necesario agregar otra forma de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    bResult = False
                                End If
                                oAppContext.Security.CloseImpersonatedSession()
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'Throw New ApplicationException(CStr(resultado("Description")))
                                bResult = False
                            End If
                        End If
                    End If
                End If
            Else
                'ASANCHEZ 06/04/2021 Nueva forma del collect en blue
                If tipo_.Trim() = "DB" Then
                    params("amount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("totalAmount") = CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", "")
                    params("ReferenceId4") = ""
                    '-----------------------------------------------------------------------------------------------------------
                    ' JNAVA (22.09.2015): se corrigio que en la cancelacion de canje de puntos se envie la fecha de la factura
                    '                     asi como el almacen correcto
                    '-----------------------------------------------------------------------------------------------------------
                    'params("ticketid") = fecha.ToString("yyyyMMddHHmmss") 'oFactura.FolioSAP
                    params("ticketid") = FechaSAP.ToString("yyyyMMddHHmmss")

                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja

                    '---------------------------------------------------------------------------------------------------------------------------------------------------

                    Dim pagos As String = "", codFormaPago As String = ""
                    For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                        codFormaPago = CStr(row("CodFormasPago"))
                        If codFormaPago = "DPVL" Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If
                    Next
                    pagos = pagos.Remove(pagos.Length - 1, 1)
                    params("ReferenceId3") = pagos

                    params("SupervisorCode") = oFactura.CodVendedor
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = oFactura.CodVendedor
                    params("SellerName") = oVendedor.Nombre
                    params("localHour") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    Dim producto As String = ""
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                        cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                        total = row("Total")
                        descSistema = row("Descuento")
                        total = total - descSistema
                        descuento = row("Adicional")
                        descuento = total * (descuento / 100)
                        unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                        unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                        total = unitPrice * cantidad
                        producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Next
                    producto = producto.Remove(producto.Length - 1, 1)
                    params("products") = producto
                    resultado = ws.Redeem(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) >= 0 Then
                                PrintHashtable(resultado)
                                resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                resultado("Provider") = Me.Provider
                            Else
                                If CInt(resultado("ResultID")) = -27 Then
                                    oAppContext.Security.CloseImpersonatedSession()
                                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Canje") = True Then
                                        params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                        resultado = ws.Redeem(params)
                                        If resultado.Count > 0 Then
                                            If resultado.ContainsKey("ResultID") = True Then
                                                If CInt(resultado("ResultID")) >= 0 Then
                                                    PrintHashtable(resultado)
                                                    resultado("CardId") = CStr(Me.pagoDPPT("CardId"))
                                                    resultado("TipoReporte") = "CAN"
                                                    resultado("Provider") = Me.Provider
                                                End If
                                            Else
                                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                'Throw New ApplicationException(CStr(resultado("Description")))
                                                bResult = False
                                            End If
                                        End If
                                    Else
                                        oAppContext.Security.CloseImpersonatedSession()
                                        'Throw New ApplicationException("Agrega otra forma de pago")
                                        MessageBox.Show("Es necesario agregar otra forma de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        bResult = False
                                    End If
                                    oAppContext.Security.CloseImpersonatedSession()
                                Else
                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    bResult = False
                                    'Throw New ApplicationException(CStr(resultado("Description")))
                                End If
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetCollect As Dictionary(Of String, Object)
                    oBluegetCollect = New Dictionary(Of String, Object)
                    oBluegetCollect.Add("cardId", CardId.Trim())
                    oBluegetCollect.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                    oBluegetCollect.Add("amount", CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", ""))
                    oBluegetCollect.Add("totalAmount", CDec(Me.pagoDPPT("Monto")).ToString("##,##0.00").Replace(",", ""))
                    oBluegetCollect.Add("ticketId", FechaSAP.ToString("yyyyMMddHHmmss"))
                    oBluegetCollect.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    'Dim pagos As String = "", codFormaPago As String = ""
                    'For Each row As DataRow In Me.dsFormasPago.Tables(0).Rows
                    '    codFormaPago = CStr(row("CodFormasPago"))
                    '    If codFormaPago = "DPVL" Then
                    '        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                    '    Else
                    '        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                    '    End If
                    'Next
                    oBluegetCollect.Add("referenceId3", "")
                    oBluegetCollect.Add("referenceId4", "")
                    oBluegetCollect.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("supervisorCod", oFactura.CodVendedor)
                    oBluegetCollect.Add("supervisorName", oVendedor.Nombre)
                    oBluegetCollect.Add("sellerCode", oFactura.CodVendedor)
                    oBluegetCollect.Add("sellerName", oVendedor.Nombre)
                    Dim producto As String = ""
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                        total = 0
                        descSistema = 0
                        descuento = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                        cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                        total = row("Total")
                        descSistema = row("Descuento")
                        total = total - descSistema
                        descuento = row("Adicional")
                        descuento = total * (descuento / 100)
                        unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                        unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                        total = unitPrice * cantidad

                        'producto &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                        'producto &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                        'wgomez Cambiar total por precio unitario
                        'producto &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                        producto &= Convert.ToInt64(articulo.CodArticulo) & ",1," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    Next
                    oBluegetCollect.Add("products", producto)
                    Dim ws_1 As New WSBroker("blue_api_s1", "Redeem")
                    Dim rs_ As Dictionary(Of String, Object)
                    resultado = ws_1.nuevos_servicios_blue(oBluegetCollect)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) > 0 Then
                                resultado("ConsecutivoPOS") = CStr(resultado("ResultID"))
                                resultado("TipoReporte") = "CAN"


                                resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                                resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                resultado("tipo") = CStr(Me.pagoDPPT("tipo"))
                                resultado("Monto") = CDec(Me.pagoDPPT("Monto"))
                                resultado("NombreCliente") = Me.NombreClienteCanje
                                resultado("CustomerName") = Me.NombreClienteCanje
                                resultado("CardId") = CardId.Trim()
                                PrintHashtable(resultado)
                                'resultado("CardId") = CardId.Trim()
                                oAppContext.Security.CloseImpersonatedSession()
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(CStr(resultado("Description")) + " - en el servicio de Redeem blue", "Caneje de puntos Redeem blue")
                                oAppContext.Security.CloseImpersonatedSession()
                            End If
                        End If
                    Else

                    End If
                End If
            End If
            
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Canjear puntos en el Si Hay")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return resultado
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/04/2015: Activa Tarjeta DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function ActivateDPCardPuntos(ByVal oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor) As Boolean
        Dim valido As Boolean = False
        Try
            Dim params As New Hashtable
            Dim ParamsAdd As New Hashtable
            Dim frmActivaPuntos As New frmDPCardPuntosAgregar(DPCardOperation.ACTIVAR)
            frmActivaPuntos.CodTipoVenta = oFactura.CodTipoVenta
            params("TicketId") = oFactura.Referencia
            Select Case oFactura.CodTipoVenta
                Case "V"
                    params("ReferenceId3") = "CFDPV"
                Case "D"
                    params("ReferenceId3") = "DPC|" & CStr(oFactura.ClienteId)
                Case Else
                    params("ReferenceId3") = "CF"
            End Select
            params("ReferenceId4") = CStr(Me.dpCardCliente("Nombre")) & "|" & CStr(Me.dpCardCliente("ApePaterno")) & "|" & CStr(Me.dpCardCliente("Telefono"))
            params("SupervisorCode") = oFactura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = oFactura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            params("NoAssigned1") = ""
            params("NoAssigned2") = ""

            '---------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/03/2018: Se agregara la bonificación de puntos en caso de que aplique
            '---------------------------------------------------------------------------------------------------------------
            Dim LogActivacion As String = ""
            'Dim ObjMonto As Object = dsFormasPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('VCJA','DPCA','DPPT')")
            Dim MontoActivacion As Decimal = GetSumaFormasPago(LogActivacion)
            Dim RestarTarjeta As Decimal = GetMontoDPCardPunto()
            MontoActivacion -= RestarTarjeta
            LogActivacion &= "La resta de la tarjeta es " & CStr(RestarTarjeta) & vbCrLf
            'If Not ObjMonto Is Nothing Then
            '    MontoActivacion = CDec(ObjMonto)
            '    MontoActivacion -= GetMontoDPCardPunto()
            'End If

            If MontoActivacion > 0 Then
                ParamsAdd("TicketId") = oFactura.Referencia
                ParamsAdd("Amount") = MontoActivacion / (1 + oAppContext.ApplicationConfiguration.IVA)
                ParamsAdd("TotalAmount") = MontoActivacion
                LogActivacion &= "El total de la bonificación sera: " & CStr(MontoActivacion)
                Dim pagos As String = "", codFormaPago As String = ""
                Dim PagosRow() As DataRow = dsFormasPago.Tables(0).Select("CodFormasPago NOT IN ('VCJA','DPCA','DPPT')")
                For Each row As DataRow In PagosRow
                    codFormaPago = CStr(row("CodFormasPago"))
                    If codFormaPago = "DPVL" Then
                        pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "-" & CStr(row("DPValeID")) & "|"
                    Else
                        If row("CodFormasPago") = "EFEC" And ebCambioCliente.Value > 0 Then
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")) - ebCambioCliente.Value, 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        Else
                            pagos &= CStr(Math.Round(CDec(row("MontoPago")), 2)) & "|" & CStr(row("CodFormasPago")) & "|"
                        End If

                    End If
                Next
                ParamsAdd("FormasPago") = pagos.Remove(pagos.Length - 1, 1)
                ParamsAdd("ReferenceId4") = ""
                ParamsAdd("SupervisorCode") = oFactura.CodVendedor
                ParamsAdd("SupervisorName") = oVendedor.Nombre
                ParamsAdd("SellerCode") = oFactura.CodVendedor
                ParamsAdd("SellerName") = oVendedor.Nombre
                ParamsAdd("NoAssigned1") = ""
                ParamsAdd("NoAssigned2") = ""
                Dim product As String = "", productKarum As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In oFactura.Detalle.Tables(0).Rows
                    total = 0
                    descSistema = 0
                    descuento = 0
                    unitPrice = 0
                    cantidad = 0
                    articulo = ArticuloMgr.Load(CStr(row("Codigo")))
                    cantidad = Decimal.Round(CDec(row("Cantidad")), 2)
                    total = row("Total")
                    descSistema = row("Descuento")
                    total = total - descSistema
                    descuento = row("Adicional")
                    descuento = total * (descuento / 100)

                    unitPrice = row("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                    unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = unitPrice * cantidad
                    If Me.Provider = Proveedor.BLUE Then
                        product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Else
                        product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                    End If
                Next
                ParamsAdd("Products") = product.Remove(product.Length - 1, 1)
                frmActivaPuntos.ParamsAdd = ParamsAdd
            End If
            EscribeLog(LogActivacion, "Log de activacion")
            frmActivaPuntos.Params = params
            frmActivaPuntos.ShowDialog()
            If frmActivaPuntos.DialogResult = DialogResult.OK Then
                AgregaIdsTransaccionManual(frmActivaPuntos.lstIds)
                If Not frmActivaPuntos.DatosPuntos Is Nothing Then
                    Activacion = True
                    DatosPuntoFactura = New Hashtable()
                    frmActivaPuntos.DatosPuntos("CodVendedor") = oVendedor.ID
                    frmActivaPuntos.DatosPuntos("TipoReporte") = "ACT"
                    DatosPuntoFactura("NoTarjeta") = CStr(frmActivaPuntos.DatosPuntos("CardId"))
                    DatosPuntoFactura("Provider") = frmActivaPuntos.Provider
                    DatosPuntoFactura("CodDPCardPunto") = "ACT"
                    PrintTicketDPCardPuntos(frmActivaPuntos.DatosPuntos)
                    If Not frmActivaPuntos.DatosPuntosActivacion Is Nothing Then
                        DatosPuntoFactura("CodDPCardPunto") = "BON"
                        frmActivaPuntos.DatosPuntosActivacion("Provider") = frmActivaPuntos.Provider
                        frmActivaPuntos.DatosPuntosActivacion("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        frmActivaPuntos.DatosPuntosActivacion("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                        frmActivaPuntos.DatosPuntosActivacion("CodVendedor") = oVendedor.ID
                        frmActivaPuntos.DatosPuntosActivacion("TipoReporte") = "BON"
                        MessageBox.Show("La tarjeta se leyo correctamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        PrintTicketDPCardPuntos(frmActivaPuntos.DatosPuntosActivacion)
                    End If
                    valido = True
                End If
            Else
                MessageBox.Show("Hubo un error al activar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al activar los puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/04/2015: Renovar Membresia de DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub RenewMembership()
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim oVendedorMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedorMgr.Create()
        oVendedorMgr.LoadInto(oFactura.CodVendedor, oVendedor)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Try
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            params("CardId") = CStr(dpDatosRenew("CardId"))
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            params("ticketid") = oFactura.FolioSAP
            params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
            params("ReferenceId3") = ""
            params("ReferenceId4") = ""
            params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
            params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            params("SupervisorCode") = oFactura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = oFactura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            params("Amount") = oFactura.SubTotal
            resultado = ws.RenewMembership(params)
            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultID") = True Then
                    If CInt(resultado("ResultID")) >= 0 Then
                        PrintHashtable(resultado)
                        resultado("CardId") = CStr(dpDatosRenew("CardId"))
                        resultado("CodVendedor") = oVendedor.ID
                        Dim dato As New Hashtable
                        dato("NoTarjeta") = CStr(dpDatosRenew("CardId"))
                        dato("CodDPCardPunto") = "REN"
                        oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
                        PrintRenewMembership(resultado)
                    Else
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al renovar la membresia")
            Throw New ApplicationException(ex.Message, ex)
        End Try

        'Dim params As New Hashtable
        'Dim frmActivaPuntos As New frmDPCardPuntosAgregar(DPCardOperation.RENOVAR)
        'params("ticketid") = oFactura.FolioSAP
        'params("ReferenceId3") = ""
        'params("ReferenceId4") = ""
        'params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
        'params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
        'params("SupervisorCode") = oFactura.CodVendedor
        'params("SupervisorName") = oVendedor.Nombre
        'params("SellerCode") = oFactura.CodVendedor
        'params("SellerName") = oVendedor.Nombre
        'params("Amount") = oFactura.SubTotal
        'frmActivaPuntos.Params = params
        'frmActivaPuntos.ShowDialog()
        'If frmActivaPuntos.DialogResult = DialogResult.OK Then
        '    dpDatosRenew = New Hashtable
        '    dpDatosRenew("CardId") = frmActivaPuntos.DatosPuntos("CodVendedor")
        '    frmActivaPuntos.DatosPuntos("CodVendedor") = oVendedor.ID
        '    Dim dato As New Hashtable
        '    dato("NoTarjeta") = CStr(frmActivaPuntos.DatosPuntos("CardId"))
        '    dato("CodDPCardPunto") = "REN"
        '    oFacturaMgr.ActualizaNoDPCardPuntos(oFactura.FacturaID, dato)
        '    PrintRenewMembership(frmActivaPuntos.DatosPuntos)
        'End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/04/2015: Valida la renovación de la DPCard Puntos
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub ValidaRenewMembership()
        Dim oVendedorMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedorMgr.Create()
        Try
            oVendedorMgr.LoadInto(oFactura.CodVendedor, oVendedor)
            Dim params As New Hashtable
            Dim frmActivaPuntos As New frmDPCardPuntosAgregar(DPCardOperation.RENOVAR)
            params("ticketid") = oFactura.FolioSAP
            params("ReferenceId3") = ""
            params("ReferenceId4") = ""
            params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
            params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            params("SupervisorCode") = oFactura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = oFactura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            params("Amount") = oFactura.SubTotal
            frmActivaPuntos.Params = params
            frmActivaPuntos.ShowDialog()
            If frmActivaPuntos.DialogResult = DialogResult.OK Then
                AgregaIdsTransaccionManual(frmActivaPuntos.lstIds)
                dpDatosRenew = New Hashtable
                dpDatosRenew("CardId") = CStr(frmActivaPuntos.DatosPuntos("CardId"))
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al validar la renovación de Membresia")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Impresión de Renovación de membresia de DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintRenewMembership(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptRenewMembership(datos)
        With rptActivaciondpCard
            .Document.Name = "Activacion DPCard Puntos"
            .PageSettings.PaperHeight = 7
            .PageSettings.PaperWidth = 14
            .PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            .Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Run()
        End With
        Try
            rptActivaciondpCard.Document.Print(False, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Captura el nombre y apellido del Cliente DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function CapturaCliente() As Boolean
        Dim valido As Boolean = True
        Try
            If oConfigCierreFI.DPCardPuntos = True Then
                If IsDPCardPunto() = True Then
                    Dim frmCaptura As New frmDPCardPuntoCliente
                    frmCaptura.ShowDialog()
                    If frmCaptura.DialogResult = DialogResult.OK Then
                        dpCardCliente = New Hashtable
                        dpCardCliente("Nombre") = frmCaptura.Nombre
                        dpCardCliente("ApePaterno") = frmCaptura.ApePaterno
                        dpCardCliente("Telefono") = frmCaptura.Telefono
                        Dim oVendedorMgr As New CatalogoVendedoresManager(oAppContext)
                        Dim oVendedor As Vendedor = oVendedorMgr.Create()
                        oVendedorMgr.LoadInto(oFactura.CodVendedor, oVendedor)
                        valido = ActivateDPCardPuntos(oVendedor)
                    Else
                        MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        valido = False
                    End If
                Else
                    MessageBox.Show("Se debe capturar la información del Cliente para poder Activar una tarjeta DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    valido = False
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al solicitar los datos de tarjeta")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

    Private Sub ebNumTarj_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebNumTarj.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

#Region "MQTT POS"

    Private Function WriteFacturaMQTT(ByRef oVentasFacturaSAP As VentasFacturaSAP, Optional ByRef bReintento As Boolean = False)
        Dim mqtt As MQTTXMLRFC = Nothing

        Try
            Select Case oVentasFacturaSAP.TipoVenta
                Case "P", "S", "E"    '--Publico Gral.
                    Select Case oVentasFacturaSAP.ZonaVenta
                        Case "EFEC"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturaSAPEfectivo(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If

                        Case "TACR", "TADB", "DPCA", "DPPT"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturasSAPTACR(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If
                        Case "VCJA"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturasSAPValeCaja(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If

                    End Select
                Case "I"       '--Fact. Fiscal
                    Select Case oVentasFacturaSAP.ZonaVenta
                        Case "EFEC"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturasSAPEfectivotFactFiscal(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If
                        Case "TACR", "TADB", "DPCA"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturasSAPTarjetaFactFiscal(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If
                        Case "VCJA"
                            mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                            mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                            mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                            mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                            mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                            Dim result As Hashtable = GetVentasFacturasSAPValeCajaFactFiscal(oVentasFacturaSAP)
                            mqtt.Parameters = CType(result("Parameters"), Hashtable)
                            mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                            mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                            If mqtt.Execute() = True Then
                                oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                                oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                                If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                                    Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                                    Dim strError As String = ""
                                    For Each row As DataRow In dtReturn.Rows
                                        strError = strError & vbCrLf & CStr(row!Message).Trim
                                    Next
                                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                                    oVentasFacturaSAP.FolioSAP = ""
                                    oVentasFacturaSAP.FolioFISAP = ""
                                Else
                                    oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                                End If
                            Else
                                MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                            End If

                    End Select
                Case "V"     '--DPVALE
                    mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                    mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                    mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                    mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                    mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                    Dim result As Hashtable = GetVentasFacturaSAPDPVale(oVentasFacturaSAP)
                    mqtt.Parameters = CType(result("Parameters"), Hashtable)
                    mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                    mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                    If mqtt.Execute() = True Then
                        oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                        oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                        oVentasFacturaSAP.FOLIOREVALE = mqtt.GetExportValue("E_REVALE")
                        oVentasFacturaSAP.RechazoSeguro = mqtt.GetExportValue("E_ZRECH")
                        If mqtt.GetExportValue("E_SEGGEN") = "X" Then
                            oVentasFacturaSAP.SeguroDPVL = True
                        Else
                            oVentasFacturaSAP.SeguroDPVL = False
                        End If
                        If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                            Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                            Dim strError As String = ""
                            For Each row As DataRow In dtReturn.Rows
                                strError = strError & vbCrLf & CStr(row!Message).Trim
                            Next
                            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                            oVentasFacturaSAP.FolioSAP = ""
                            oVentasFacturaSAP.FolioFISAP = ""
                            oVentasFacturaSAP.FOLIOREVALE = ""
                        Else
                            oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                        End If
                    Else
                        MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                    End If
                Case "D"     '--DIP'S
                    mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                    mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                    mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                    mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                    mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                    Dim result As Hashtable = GetVentasFacturaSAPDIP(oVentasFacturaSAP)
                    mqtt.Parameters = CType(result("Parameters"), Hashtable)
                    mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                    mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                    If mqtt.Execute() = True Then
                        oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                        oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                        oVentasFacturaSAP.FOLIOREVALE = mqtt.GetExportValue("E_REVALE")
                        If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                            Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                            Dim strError As String = ""
                            For Each row As DataRow In dtReturn.Rows
                                strError = strError & vbCrLf & CStr(row!Message).Trim
                            Next
                            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                            oVentasFacturaSAP.FolioSAP = ""
                            oVentasFacturaSAP.FolioFISAP = ""
                            oVentasFacturaSAP.FOLIOREVALE = ""
                        Else
                            oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                        End If
                    Else
                        MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                    End If
                Case "A"     '--Apartados
                    mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                    mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                    mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                    mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                    mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                    Dim result As Hashtable = GetVentasFacturaSAPApartado(oVentasFacturaSAP)
                    mqtt.Parameters = CType(result("Parameters"), Hashtable)
                    mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                    mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                    If mqtt.Execute() = True Then
                        oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                        oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                        If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                            Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                            Dim strError As String = ""
                            For Each row As DataRow In dtReturn.Rows
                                strError = strError & vbCrLf & CStr(row!Message).Trim
                            Next
                            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                            oVentasFacturaSAP.FolioSAP = ""
                            oVentasFacturaSAP.FolioFISAP = ""
                        Else
                            oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                        End If
                    Else
                        MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                    End If
                Case "F", "K"   '--FONACOT
                    mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                    mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                    mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                    mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                    mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                    Dim result As Hashtable = GetVentasFacturaSAPFonacot(oVentasFacturaSAP)
                    mqtt.Parameters = CType(result("Parameters"), Hashtable)
                    mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                    mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                    If mqtt.Execute() = True Then
                        oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                        oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                        If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                            Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                            Dim strError As String = ""
                            For Each row As DataRow In dtReturn.Rows
                                strError = strError & vbCrLf & CStr(row!Message).Trim
                            Next
                            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                            oVentasFacturaSAP.FolioSAP = ""
                            oVentasFacturaSAP.FolioFISAP = ""
                        Else
                            oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                        End If
                    Else
                        MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                    End If
                Case "O"     '--FACILITO
                    mqtt = New MQTTXMLRFC(oVentasFacturaSAP.NombreBAPI)
                    mqtt.Almacen = oAppContext.ApplicationConfiguration.Almacen
                    mqtt.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
                    mqtt.Folio = oFacturaMgr.NextFolioFactura(oAppContext.ApplicationConfiguration.NoCaja)
                    mqtt.RutaProperties = oConfigCierreFI.RutaArchivoProperties
                    Dim result As Hashtable = GetVentasFacturaSAPFacilito(oVentasFacturaSAP)
                    mqtt.Parameters = CType(result("Parameters"), Hashtable)
                    mqtt.Tables.Add(CType(result("DatosDet"), DataTable))
                    mqtt.Tables.Add(CType(result("Condiciones"), DataTable))
                    If mqtt.Execute() = True Then
                        oVentasFacturaSAP.FolioSAP = mqtt.GetExportValue("SALESDOCUMENT")
                        oVentasFacturaSAP.FolioFISAP = mqtt.GetExportValue("FIDOCUMENT")
                        If oVentasFacturaSAP.FolioSAP.Trim = "" OrElse oVentasFacturaSAP.FolioFISAP = "" Then
                            Dim dtReturn As DataTable = CType(mqtt.Exports("SAPRETURN"), DataTable)
                            Dim strError As String = ""
                            For Each row As DataRow In dtReturn.Rows
                                strError = strError & vbCrLf & CStr(row!Message).Trim
                            Next
                            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                            oVentasFacturaSAP.FolioSAP = ""
                            oVentasFacturaSAP.FolioFISAP = ""
                        Else
                            oFacturaMgr.UpdateFolioMQTT(oAppContext.ApplicationConfiguration.NoCaja, CLng(mqtt.Folio))
                        End If
                    Else
                        MessageBox.Show(mqtt.GetExportValue("Error"), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        EscribeLog(mqtt.GetExportValue("Error"), "Error en MQTT al realizar el llamado")
                    End If
            End Select
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al grabar la venta en SAP con MQTT: Linea " & Err.Erl)
            MessageBox.Show("Ocurrió un error al guardar la venta" & vbCrLf & "Favor de revisar el Log de Errores", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas de Publico en General
    '-----------------------------------------------------------------------------------------------------------------------------

    Public Function GetVentasFacturaSAPEfectivo(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With

        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas de Tarjetas de Credito
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturasSAPTACR(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Vale de Caja
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturasSAPValeCaja(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("I_NUMVA") = .NumeroVale
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Efectivo de Facturación Fiscal
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturasSAPEfectivotFactFiscal(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Tarjetas de Credito para la facturación fiscal
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturasSAPTarjetaFactFiscal(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Vale de Caja para la facturación fiscal
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturasSAPValeCajaFactFiscal(ByRef oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("I_NUMVA") = .NumeroVale
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con DPVale para la facturación fiscal
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturaSAPDPVale(ByVal oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("I_FACDPPRO") = .FacturaDP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .ClienteDistribuidor
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_NUMVA") = .NumeroVale
            parameters("I_CTEDIST") = .CodigoCliente
            parameters("I_NUMDE") = CStr(.NUMDE)
            parameters("I_PARES_PZAS") = CStr(.PARES_PZAS)
            parameters("I_MONTODPVALE") = .MontoDPVale
            parameters("I_MONTOUTILIZADO") = CStr(.MONTOUTILIZADO)
            If .REVALE Then
                parameters("I_REVALE") = "X"
            Else
                parameters("I_REVALE") = ""
            End If
            parameters("I_RPARES_PZAS") = CStr(.RPARES_PZAS)
            parameters("I_RMONTODPVALE") = .RMONTODPVALE
            parameters("I_FECHA") = Format(.FechaMovimiento, "dd/MM/yyyy")
            parameters("I_FECCO") = Format(.FechaCobroDPVL, "dd/MM/yyyy")
            parameters("I_ID") = .DPValeVentaID

            '-----------------------------------------------------------------------
            'FLIZARRAGA 08/09/2015: Adaptando lo DPVales Seguros
            '-----------------------------------------------------------------------

            'If .SeguroDPVL Then
            '    parameters("I_ZSEG") = 1
            'Else
            '    parameters("I_ZSEG") = "0"
            'End If
            '------------------------------------------------------------------------------
            'FLIZARRAGA 10/11/2015: Validacion para saber si acepta el seguro de vida o no
            '------------------------------------------------------------------------------
            parameters("I_ZSEG") = .ZSEG

            parameters("I_IMPSEG") = .ImpSegDPVL
            parameters("I_FOLSEG") = .FolSegDPVL
            parameters("I_DIVP") = .DivPDPVL
        End With

        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Ventas DIPS 
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturaSAPDIP(ByVal oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV", "ZDIP"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Obtiene los datos de la factura para las ventas con Ventas de Apartados 
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturaSAPApartado(ByVal oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_CONTRATO") = .FechaApartado
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With

        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/05/2015: Obtiene los datos de la factura para las ventas con Ventas de Fonacot 
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturaSAPFonacot(ByVal oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/05/2015: Obtiene los datos de la factura para las ventas con Ventas de Facilito
    '---------------------------------------------------------------------------------------------------------------------------

    Private Function GetVentasFacturaSAPFacilito(ByVal oVentasFacturaSAP As VentasFacturaSAP) As Hashtable
        Dim result As New Hashtable
        Dim parameters As New Hashtable
        Dim datosdet As New DataTable("DATOSDET")
        datosdet.Columns.Add("Folio", GetType(String))
        datosdet.Columns.Add("MATNR", GetType(String))
        datosdet.Columns.Add("CANTIDAD", GetType(String))
        datosdet.Columns.Add("TALLA", GetType(String))
        datosdet.AcceptChanges()


        Dim condiciones As New DataTable("CONDICIONES")
        condiciones.Columns.Add("FOLIO", GetType(String))
        condiciones.Columns.Add("MATNR", GetType(String))
        condiciones.Columns.Add("CONDICION", GetType(String))
        condiciones.Columns.Add("IMPORTE", GetType(String))
        condiciones.AcceptChanges()

        With oVentasFacturaSAP
            parameters("CLASEPEDIDO") = .ClasePedido
            parameters("OFICINAVTA") = .OficinaVentas
            parameters("I_AGENTE") = .Vendedor
            parameters("I_WERKS") = .Centro
            parameters("I_CREDITO") = .Credito
            parameters("I_KUNNR") = .CodigoCliente
            parameters("I_ZONAVTA") = .ZonaVenta
            parameters("I_MODE") = "N"
            parameters("I_FACDPPRO") = .FacturaDP
        End With


        Dim i As Integer = 0
        Dim fila As DataRow = Nothing
        Dim renglon As DataRow = Nothing
        For Each row As DataRow In oVentasFacturaSAP.Detalle.Rows
            i += 10
            fila = datosdet.NewRow()
            fila("FOLIO") = CStr(i).Trim().PadLeft(4, "0")
            fila("MATNR") = row!Codigo
            fila("CANTIDAD") = CStr(row!Cantidad)
            fila("TALLA") = FormatTalla(row!Talla)
            datosdet.Rows.Add(fila)
            If row!Condicion <> "" Then
                renglon = condiciones.NewRow()
                renglon("FOLIO") = CStr(i).PadLeft(4, "0")
                renglon("MATNR") = row!Codigo
                renglon("CONDICION") = row!Condicion
                Select Case row!Condicion
                    Case "ZDP4", "ZRDV"
                        renglon("IMPORTE") = CStr(Math.Round(CDec(row!Adicional), 2))
                    Case "Z501"
                        renglon("IMPORTE") = CStr(row!Descuento)
                End Select
                condiciones.Rows.Add(renglon)
            End If
        Next
        result("Parameters") = parameters
        result("DatosDet") = datosdet
        result("Condiciones") = condiciones
        Return result
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/05/2015: Da formato a las tallas de Artículos
    '---------------------------------------------------------------------------------------------------------------------------

    Friend Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber & ".0"
            End If
        End If
        Return strNumber
    End Function

#End Region

#Region "RETAIL Methods"

    Public Function SaveFacturaRetail() As Dictionary(Of String, Object)
        Me.Cursor = Cursors.WaitCursor
        Dim response As New Dictionary(Of String, Object)
        Dim arDatosZV() As String
        Dim arDatosDPVale() As String


        Dim oProcesarVenta As New Dictionary(Of String, Object)

        With oProcesarVenta
            If EsInstanciaApartado Then
                Dim fechaApartado As String = oFactura.FechaApartado.Substring(6, 4) & "-" & oFactura.FechaApartado.Substring(3, 2) & "-" & oFactura.FechaApartado.Substring(0, 2)
                .Add("I_FECHA_CREACION", fechaApartado)
            Else
                .Add("I_FECHA_CREACION", Format(oFactura.Fecha, "yyyy-MM-dd"))
            End If
            If oFactura.CodTipoVenta = "S" OrElse oFactura.CodTipoVenta = "D" Then
                .Add("I_SOLICITANTE", oFactura.ClienteId)
            Else
                .Add("I_SOLICITANTE", "")
            End If
            Dim CatalogoTipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oAppContext)

            Dim MotivoPedido As String = ""
            .Add("I_REQUIERE_FACTURA", "")
            .Add("I_COSTO_ENVIO", 0)
            .Add("I_REFERENCIA", oFactura.Referencia)
            .Add("I_OFICINAVENTAS", "T" & oAppContext.ApplicationConfiguration.Almacen)
            If EsInstanciaApartado Then
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
            If oFactura.CodTipoVenta = "E" AndAlso vCodTipoDescuento = "DVD" AndAlso oValeDescuentoLocalInfo.FolioVale > 0 Then
                .Add("I_FOLIO", oValeDescuentoLocalInfo.Serie & "|" & oValeDescuentoLocalInfo.FolioVale)
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
            For Each oRow As DataRow In dsFormasPago.Tables(0).Rows
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
                        arDatosDPVale = GetDPValeSAP()
                        .Add("NUMVA", oDpvaleSAP.IDDPVale.PadLeft(10, "0"))
                        .Add("NUMDE", oDpvaleSAP.NUMDE)
                        .Add("DISTRIB", arDatosDPVale(2).PadLeft(10, "0"))
                        .Add("CTEDIST", arDatosDPVale(0).PadLeft(10, "0"))
                        .Add("PARES_PZAS", oDpvaleSAP.ParesPzas)
                        .Add("MONTO_UTILIZADO", oDpvaleSAP.MontoUtilizado.ToString("##,##0.00").Replace(",", ""))
                        .Add("MONTODPVALE", CDec(arDatosDPVale(1)).ToString("##,##0.00").Replace(",", ""))
                        .Add("FECCO", oDpvaleSAP.FechaCobro.ToString("yyyyMMdd"))
                        If oDpvaleSAP.REVALE Then
                            .Add("REVALE", "X")
                        Else
                            .Add("REVALE", "")
                        End If
                        '----------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 05/05/2016: Se comento los RPAREZ_PZA porque no se ocupaba.
                        '----------------------------------------------------------------------------------------------------------
                        '.Add("RPARES_PZAS", oDpvaleSAP.RPARES_PZAS)
                        .Add("RMONTODPVALE", oDpvaleSAP.RMONTODPVALE.ToString("##,##0.00").Replace(",", ""))
                        If oConfigCierreFI.GenerarSeguro Then
                            Dim SecureArray() As String
                            Dim DataSecure As New Hashtable()
                            SecureArray = GetDPValeSAP()
                            DataSecure("I_NUMVA") = oDpvaleSAP.IDDPVale
                            DataSecure("I_KUNNR") = SecureArray(0).PadLeft(10, "0")
                            If oConfigCierreFI.GenerarSeguro Then
                                DataSecure("I_ZSEG") = "1"
                            Else
                                DataSecure("I_ZSEG") = "0"
                            End If
                            DataSecure("I_FECCO") = oDpvaleSAP.FechaCobro.ToString("yyyyMMdd")
                            DataSecure("I_NUMDE") = oDpvaleSAP.NUMDE
                            '-----------------------------------------------------------------------------------------
                            ' JNAVA (03.08.2016): Qui comento pro que en Retail y S2credit ya no se utilizara
                            ''-----------------------------------------------------------------------------------------
                            'If oSAPMgr.ZDPVL_VALSEGUROSAFS(DataSecure) = True Then
                            '    oFactura.SeguroVidaSAPDPVL = True
                            '    .Add("ZSEG", "1")
                            'Else
                            '    oFactura.SeguroVidaSAPDPVL = False
                            '    ImporteSeguro = 0
                            '    .Add("ZSEG", "0")
                            'End If
                            '-----------------------------------------------------------------------------------------
                        Else
                            .Add("ZSEG", "0")
                        End If
                        .Add("IMPSEG", ImporteSeguro.ToString("##,##0.00").Replace(",", ""))
                        If Not DatosTicketSeguro Is Nothing AndAlso DatosTicketSeguro.Count > 0 Then .Add("FOLSEG", DatosTicketSeguro("folseg")) Else .Add("FOLSEG", 0)
                        .Add("DIV", DivPlaza)
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

            ' ------------------------------------------------------------------
            ' Llenamos datos de las Productos 
            '-------------------------------------------------------------------
            Dim rows() As DataRow = Nothing
            Dim TraspasoEntradaMgr As New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
            Dim zequi As New Zequi(TraspasoEntradaMgr)
            Dim oProductos As New List(Of Dictionary(Of String, Object))
            For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                '------------------------------------------------------------------
                ' Seteamos datos del detalle
                '------------------------------------------------------------------
                If oRow("Codigo") <> "" And oRow("Cantidad") > 0 And oRow("Importe") > 0 Then
                    Dim oCodigo As New Dictionary(Of String, Object)
                    With oCodigo
                        .Add("POSNR", "")
                        .Add("ORDERITEM_ID", "")
                        .Add("MATNR", CStr(oRow!Codigo).PadLeft(10, "0"))
                        .Add("CANTIDAD", CInt(oRow!Cantidad))
                        If CDec(oRow!Adicional) > 0 Then
                            .Add("DESCUENTO", CDec(oRow!Adicional).ToString("##,##0.00").Replace(",", ""))
                            .Add("CLASE_CONDICION", "ZDP4")
                        Else
                            .Add("DESCUENTO", 0)
                            .Add("CLASE_CONDICION", "")
                        End If
                        '--------------------------------------------------------------------------------
                        'FLIZARRAGA 16/02/2018: Validamos si es artículo con serie
                        '--------------------------------------------------------------------------------
                        'If Not Me.dtTablaElectronicos Is Nothing Then
                        '    rows = Me.dtTablaElectronicos.Select("MATERIAL='" & CStr(oRow("Codigo")) & "'")
                        '    If rows.Length > 0 Then
                        '        zequi = TraspasoEntradaMgr.GetZequi(CStr(rows(0)!MATERIAL), CStr(rows(0)!NUMSERIE))
                        '        .Add("SERNR", zequi.Serie)
                        '        .Add("SOBKZ", zequi.SOBKZ)
                        '    Else
                        '        .Add("SERNR", "")
                        '        .Add("SOBKZ", "")
                        '    End If
                        'End If
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
                End If
            Next
            '------------------------------------------------------------------
            ' Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("T_PRODUCTOS", oProductos)

        End With

        If oFactura.CodTipoVenta.Trim() = "O" OrElse oFactura.CodTipoVenta.Trim() = "V" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
            Dim lstInterlocutor As New List(Of Dictionary(Of String, Object))
            Dim inter As New Dictionary(Of String, Object)
            If oFactura.CodTipoVenta = "V" Then
                inter("CLIENTE") = arDatosDPVale(0).PadLeft(10, "0")
            Else
                inter("CLIENTE") = oFactura.ClienteId
            End If
            inter("TIPO_CLIENTE") = oFactura.TipoCliente
            lstInterlocutor.Add(inter)
            oProcesarVenta("T_INTERLOCUTORES") = lstInterlocutor
        End If

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")
        oRetail.Parametros.Add("SerialID", oFactura.SerialId)
        response = oRetail.SapZsdProcesoventa(oProcesarVenta)

        '----------------------------------------------------------------------------------
        ' JNAVA (13.07.2016): Realizamos venta de dpvale en S2Credit
        '----------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            If oFactura.CodTipoVenta = "V" Then
                '----------------------------------------------------------------------------------
                ' JNAVA (04.08.2016): Por Default el Seguro es 1, cuando se quiera cambiar es desde aqui
                '----------------------------------------------------------------------------------
                Dim SeguroID As String = "1"
                '----------------------------------------------------------------------------------
                '  Realizamos venta de dpvale en S2Credit
                '----------------------------------------------------------------------------------
                VentaIdS2c = String.Empty
                Dim mensaje As String = String.Empty

                VentaIdS2c = oS2Credit.RealizarVenta(arDatosDPVale, oDpvaleSAP, SeguroID, mensaje, MontoSeguro)
                If mensaje <> String.Empty Then
                    MessageBox.Show("Ocurrio un guardar en s2credit." & vbCrLf & mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
                '----------------------------------------------------------------------------------
                ' JNAVA (04.08.2016): Si regresa ID de la venta es que se genero seguro
                '----------------------------------------------------------------------------------
                If VentaIdS2c <> String.Empty Then
                    '----------------------------------------------------------------------------------
                    ' JNAVA (04.08.2016): Extrameos datos del seguro
                    '----------------------------------------------------------------------------------
                    ExtraerDatosSeguroS2Credit(VentaIdS2c, SeguroID)
                    oFactura.SeguroVidaSAPDPVL = True
                End If
                '--------------------------------------------------------------------------------------
                'FLIZARRAGA 14/11/2017: Obtenemos la fecha del Amortización de compra
                '--------------------------------------------------------------------------------------
                Me.oDPVale = New cDPVale()
                If IsNumeric(oDpvaleSAP.IDDPVale) Then
                    Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.PadLeft(10, "0")
                Else
                    Me.oDPVale.INUMVA = oDpvaleSAP.IDDPVale.Trim()
                End If
                Me.oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, Nothing)
                Me.FechaPrimerPago = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
                Me.FechaPrimerPago = GetFechaFechaPrimerPago(FechaPrimerPago)
            End If
        End If
        '----------------------------------------------------------------------------------

        oFacturaMgr.SaveSerial(oFactura.SerialId, "S", oFactura.CodVendedor, oFactura.FacturaID)
        If oFactura.CodTipoVenta = "D" Or oFactura.CodTipoVenta = "S" Then
            Dim result As Dictionary(Of String, Object)
            For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                oCatalogoArticuloMgr.LoadInto(CStr(oRow("Codigo")), oArticulo)
                If oArticulo.CodMarca.ToUpper() = "DT" Then
                    'RestService.Metodo = "/pos/dips"
                    'result = RestService.SapZBapiActualizaDips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    oSAPMgr.Write_Actualiza_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    Exit For
                End If
            Next

        End If

        Me.Cursor = Cursors.Default
        Return response
    End Function

#End Region

#Region "S2Credit"

    '-----------------------------------------------------------------------------------
    ' JNAVA (08.04.2016): Obtenemos los datos del Seguro de Vida desde S2Credit
    '-----------------------------------------------------------------------------------
    Public Sub ExtraerDatosSeguroS2Credit(ByVal VentaID As String, ByVal SeguroID As String)

        '-----------------------------------------------------------------------------------
        ' Si es Revale, no hacemos nada del seguro
        '-----------------------------------------------------------------------------------
        If Not Me.oDpvaleSAP.IsRevale Then

            '---------------------------------------------------------------------------------------------------------------
            '  Preparamos los datos para el ticket de Seguro
            '---------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarSeguro Then

                '-----------------------------------------------------------------------------------
                ' Obtenemos los datos de la aseguradora
                '-----------------------------------------------------------------------------------
                Dim oDatosAseguradora As New Hashtable
                Dim oRowAseguradora As DataRow
                oS2Credit.ObtenerSeguroPorID(SeguroID, 0, oRowAseguradora)

                If Not oRowAseguradora Is Nothing Then
                    oDatosAseguradora.Add("purchaseId", oRowAseguradora("name"))
                    oDatosAseguradora.Add("name", oRowAseguradora("name"))
                    oDatosAseguradora.Add("rate", oRowAseguradora("rate"))
                    oDatosAseguradora.Add("business_name", oRowAseguradora("business_name"))
                    oDatosAseguradora.Add("prime_amount", oRowAseguradora("prime_amount"))
                    oDatosAseguradora.Add("insurance_policy", oRowAseguradora("insurance_policy"))
                    oDatosAseguradora.Add("url", oRowAseguradora("url"))
                    oDatosAseguradora.Add("phone", oRowAseguradora("phone"))
                    oDatosAseguradora.Add("email", oRowAseguradora("email"))
                End If
                '-----------------------------------------------------------------------------------
                'FLIZARRAGA 19/05/2017: Se cargan los montos del seguro y fechas
                '-----------------------------------------------------------------------------------
                oDatosAseguradora("insurance") = CDec(MontoSeguro("insurance"))
                oDatosAseguradora("amount") = CDec(MontoSeguro("amount"))
                oDatosAseguradora("FechaPrimeraAmortizacion") = CDate(MontoSeguro("datestart"))
                oDatosAseguradora("CuentaAmortizaciones") = CInt(MontoSeguro("CuentaAmortizaciones"))
                oDatosAseguradora("MontoAmortizaciones") = CDec(MontoSeguro("MontoAmortizaciones"))
                oDatosAseguradora("datestart") = oFactura.Fecha
                oDatosAseguradora("dateend") = CDate(MontoSeguro("dateend"))
                oDatosAseguradora("numde") = CInt(oDpvaleSAP.NUMDE)
                oDatosAseguradora("loan_term") = MontoSeguro("loan_term")
                If oDpvaleSAP.PromocionID.Trim() <> "" Then
                    If oDpvaleSAP.FechaCobro.Date > DateTime.Now.Date Then
                        oDatosAseguradora.Add("idOffer", oDpvaleSAP.PromocionID.Trim)
                    Else
                        oDatosAseguradora.Add("idOffer", "")
                    End If
                Else
                    oDatosAseguradora.Add("idOffer", "")
                End If
                '-----------------------------------------------------------------------------------
                ' Obtenemos los datos del seguro
                '-----------------------------------------------------------------------------------
                DatosTicketSeguro.Clear()
                DatosTicketSeguro = PrepararDatosTicketS2Credit(Me.oDpvaleSAP.IDCliente, Me.oDpvaleSAP.NUMDE, Me.oDpvaleSAP.FechaCobro, oFactura.CodTipoVenta, oDatosAseguradora)
                If DatosTicketSeguro Is Nothing OrElse DatosTicketSeguro.Count <= 0 Then
                    MessageBox.Show("Ocurrio un error al obtener los datos del Financiamiento del Seguro." & vbCrLf & "No existe la configuración de seguros de vida en S2Credit.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog("No existe la configuracion de seguros de vida en S2Credit", "Ocurrio un error al obtener los datos del Financiamiento del seguro de vida en S2Credit")
                End If

            End If
        End If

    End Sub

    '-----------------------------------------------------------------------------
    'JNAVA (08.04.2016): Funcion para prerar datos para el ticket de seguros de S2Credit
    '-----------------------------------------------------------------------------
    Public Function PrepararDatosTicketS2Credit(ByVal CodClienteDPVL As String, ByVal NumQuincenasDPVL As String, ByVal FechaCobroDPVL As Date, ByVal CodTipoVenta As String, ByVal DatosAseguradora As Hashtable) As Hashtable

        Dim htDatosTicket As New Hashtable
        Dim dtFinanciamiento As DataTable
        Dim Plaza As String

        '-----------------------------------------------------------------------------
        ' Validamos que los datos del Financiamiento esten correctos
        '-----------------------------------------------------------------------------
        If DatosAseguradora Is Nothing OrElse DatosAseguradora.Count <= 0 Then
            htDatosTicket = Nothing
            ImporteSeguro = 0
            GoTo Salir
        End If

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos de la plaza
        '-----------------------------------------------------------------------------
        htDatosTicket("Plaza") = oAppSAPConfig.Plaza.Trim
        htDatosTicket("Ciudad") = ObtenerDescripcionPlaza()
        htDatosTicket("Direccion") = ObtenerDireccionPlaza()
        htDatosTicket("Caja") = oAppContext.ApplicationConfiguration.NoCaja

        '-----------------------------------------------------------------------------
        ' Comenzamos a setear datos de Financiamiento
        '-----------------------------------------------------------------------------
        htDatosTicket("VentaID") = DatosAseguradora("purchaseId") 'ID de la Venta en S2Credit
        htDatosTicket("Aseguradora") = DatosAseguradora("business_name")

        '-----------------------------------------------------------------------------
        ' Obtenemos los datos del Canjeante
        '-----------------------------------------------------------------------------
        oCliente.Clear()
        Me.oClienteMgr.Load(CodClienteDPVL, oCliente, CodTipoVenta)

        '-----------------------------------------------------------------------------
        ' Seteamos datos del cliente
        '-----------------------------------------------------------------------------
        htDatosTicket("NoCanjeante") = CStr(oCliente.CodigoAlterno).PadLeft(10, "0")
        htDatosTicket("Canjeante") = oCliente.NombreCompleto
        htDatosTicket("RFC") = oCliente.RFC
        htDatosTicket("Sexo") = IIf(oCliente.Sexo = "F", "Femenino", "Masculino")

        '-----------------------------------------------------------------------------
        ' Seteamos datos de Financiamiento
        '-----------------------------------------------------------------------------
        Me.ImporteSeguroQuin = CDec(DatosAseguradora("amount"))

        htDatosTicket("ImporteSeguroQuin") = Me.ImporteSeguroQuin
        Dim datestart As DateTime, dateend As DateTime
        Dim idOffer As String = CStr(DatosAseguradora("idOffer"))
        Dim FechaCompra As DateTime, FechaUltimaAmortizacion As DateTime
        Dim DiasDiferencia As Long = 0, CalculoQuincena As Decimal = 0
        FechaCompra = CDate(DatosAseguradora("datestart"))
        FechaUltimaAmortizacion = CDate(DatosAseguradora("dateend"))
        DiasDiferencia = DateDiff(DateInterval.Day, FechaCompra, FechaUltimaAmortizacion)
        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 13/07/2017: Se realiza el calculo de la fecha de vigencia del seguro
        '---------------------------------------------------------------------------------------------------------------------------
        Dim dias As Integer = 0
        Dim loanTerm As Integer = CInt(DatosAseguradora("loan_term"))
        Dim AmortizationCount As Integer = CInt(DatosAseguradora("CuentaAmortizaciones"))
        Dim numde As Integer = CInt(DatosAseguradora("numde"))
        dias = loanTerm * CInt(oConfigCierreFI.DiasQuincena)
        If idOffer.Trim() = "" Then
            If AmortizationCount < numde Then
                datestart = CDate(DatosAseguradora("FechaPrimeraAmortizacion"))
                htDatosTicket("FechaInicio") = datestart
                Me.ImporteSeguro = Me.ImporteSeguroQuin * AmortizationCount
                dateend = datestart.AddDays(dias)
            Else
                datestart = CDate(DatosAseguradora("datestart"))
                htDatosTicket("FechaInicio") = datestart
                Me.ImporteSeguro = Me.ImporteSeguroQuin * AmortizationCount
                dateend = datestart.AddDays(dias)
            End If
        Else
            Dim FechaInicio As DateTime = CDate(DatosAseguradora("datestart"))
            Dim FechaFinal As DateTime = CDate(DatosAseguradora("dateend")).AddDays(15)
            Dim QuincenaInsurance As Decimal = CDec(DatosAseguradora("MontoAmortizaciones")) / 12
            Dim QuincenaFecha As Decimal = DateDiff(DateInterval.Day, FechaInicio, FechaFinal) / 15
            Dim DiferenciaTotal As Decimal = Math.Abs(QuincenaFecha - QuincenaInsurance)
            Dim DiasASumar As Integer = CInt(QuincenaInsurance) * CInt(oConfigCierreFI.DiasQuincena)
            If DiferenciaTotal <= 1 Then
                datestart = CDate(DatosAseguradora("datestart"))
                htDatosTicket("FechaInicio") = datestart
                dateend = datestart.AddDays(DiasASumar)
                Me.ImporteSeguro = Me.ImporteSeguroQuin * AmortizationCount
            Else
                datestart = CDate(DatosAseguradora("FechaPrimeraAmortizacion"))
                htDatosTicket("FechaInicio") = datestart
                dateend = datestart.AddDays(DiasASumar)
                Me.ImporteSeguro = Me.ImporteSeguroQuin * AmortizationCount
            End If
        End If
        htDatosTicket("ImporteSeguro") = Me.ImporteSeguro
        htDatosTicket("FechaFin") = dateend
        htDatosTicket("ImporteFin") = Format((NumQuincenasDPVL * CDec(DatosAseguradora("rate"))), "c")
        htDatosTicket("MontoSeguro") = Format(CDec(DatosAseguradora("prime_amount")), "c")
        htDatosTicket("folseg") = ""
        htDatosTicket("Vigencia") = FechaCobroDPVL.AddMonths(NumQuincenasDPVL / 2)
        htDatosTicket("NoPoliza") = DatosAseguradora("insurance_policy")
        htDatosTicket("Beneficiarios") = Beneficiarios

        htDatosTicket("DireccionFinanciador") = DatosAseguradora("email")
        htDatosTicket("TelefonoFinanciador") = DatosAseguradora("phone")
        htDatosTicket("TelefonoInformacion") = DatosAseguradora("phone")

        htDatosTicket("Aseguradora2") = DatosAseguradora("name")

        '-----------------------------------------------------------------------------
        ' Seteamos variable general de la division de la plaza
        '-----------------------------------------------------------------------------
        Me.DivPlaza = ""

Salir:
        Return htDatosTicket

    End Function

    '-----------------------------------------------------------------------------
    ' JNAVA (08.04.2016): Revisamos si se pide Beneficiario para Generar Seguro
    '-----------------------------------------------------------------------------
    Private Sub GuardarSeguroS2Credit(ByVal oDpvaleSAPLocal As cDPValeSAP)

        Dim oDatosBeneficiario As Dictionary(Of String, Object)

        If oFactura.CodTipoVenta <> "V" Then
            Exit Sub
        End If



        If oDpvaleSAPLocal.IDDPVale <> String.Empty Then

            If oConfigCierreFI.GenerarSeguro Then

                '-----------------------------------------------------------------------------
                ' Si es Revale o Rerevale no pide beneficario
                '-----------------------------------------------------------------------------
                If Not oDpvaleSAPLocal.IsRevale AndAlso Not oDpvaleSAPLocal.IsReRevale Then

CapturarBeneficiario:

                    '-----------------------------------------------------------------------------
                    ' JNAVA (05.08.2016): Capturamos los datos del Beneficiario
                    '-----------------------------------------------------------------------------
                    Dim oCapturaBeneficiario As New frmBeneficiarioS2Credit
                    oCapturaBeneficiario.ShowDialog()
                    oDatosBeneficiario = oCapturaBeneficiario.DatosBeneficiario
                    oCapturaBeneficiario.Dispose()

                    '-----------------------------------------------------------------------------
                    '  Si no se capturo el Beneficiario, no dejamos continuar con la venta
                    '-----------------------------------------------------------------------------
                    If oDatosBeneficiario Is Nothing Then
                        MessageBox.Show("Debe capturar los datos del Beneficiario para continuar con la Venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        GoTo CapturarBeneficiario
                    End If

                    '-----------------------------------------------------------------------------
                    ' Guardamos el Beneficiario en S2Credit
                    '-----------------------------------------------------------------------------
                    Dim strError As String = String.Empty
                    If oS2Credit.GuardarBeneficiario(VentaIdS2c, oDatosBeneficiario, strError) Then

                        '-----------------------------------------------------------------------------
                        ' Validamos que se hayan cargado los datos del seguro
                        '-----------------------------------------------------------------------------
                        If Not DatosTicketSeguro Is Nothing And DatosTicketSeguro.Count > 0 Then

                            Dim Beneficiarios As String
                            Beneficiarios = oDatosBeneficiario("Nombres") & " " & oDatosBeneficiario("ApellidoPaterno") & " " & oDatosBeneficiario("ApellidoMaterno") & _
                                            ", " & oDatosBeneficiario("Parentesco") & " - 100%"

                            '-----------------------------------------------------------------------------
                            ' Imprimimos el Ticket de Venta del Seguro de Vida
                            '-----------------------------------------------------------------------------
                            DatosTicketSeguro("Beneficiarios") = Beneficiarios
                            ImprimirTicketSeguro()

                        End If

                    Else

                        MessageBox.Show("No se guardo el beneficiario: " & strError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub

                    End If

                End If

            End If

        End If

    End Sub

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016): Valida/Busca Vale en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscarValeS2Credit(ByVal NumVale As String)
    '    If oConfigCierreFI.AplicarS2Credit Then
    '        Dim oS2Credit As New ProcesosS2Credit
    '        Dim oDPValeS2C As Dictionary(Of String, Object) 'InfoValeS2Credit
    '        Try
    '            oDPValeS2C = Nothing
    '            oDPValeS2C = oS2Credit.CouponSearch(NumVale)
    '            If Not oDPValeS2C Is Nothing Then
    '                oDPValeS2C.Add("idCoupon", NumVale)
    '            End If
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    'End Sub

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016): Realiza Venta en S2Credit
    ''-----------------------------------------------------
    'Private Sub RealizarVentaS2Credit(ByVal Amount As Decimal, ByVal purchase_amount As Decimal, ByVal fortnight As String)

    '    Try
    '        '-----------------------------------------------------
    '        ' Preparamos datos para la venta
    '        '-----------------------------------------------------
    '        Dim oVentaS2C As New Dictionary(Of String, Object) 'New VentaS2Credit
    '        With oVentaS2C
    '            If Not oClienteResS2C Is Nothing AndAlso oClienteResS2C.Count >= 1 Then
    '                oVentaS2C("id_customer") = oClienteResS2C.Item(0)("id") 'oClienteResS2C.results(0).id
    '            Else
    '                oVentaS2C("id_customer") = "0"
    '            End If
    '            oVentaS2C("id_distributor") = oDPValeS2C("idDistributor")
    '            oVentaS2C("id_coupon") = CInt(oDPValeS2C("idCoupon"))
    '            oVentaS2C("id_identification") = 1 'Por lo pronto, se manda siempre el comodin
    '            oVentaS2C("identification_value") = "X"
    '            oVentaS2C("purchase_date") = Format(Date.Today, "yyyy-MM-dd") '2016 - 1 - 24
    '            If Amount <= 0 Then
    '                oVentaS2C("amount") = purchase_amount.ToString("##,##0.00").Replace(",", "")
    '            Else
    '                oVentaS2C("amount") = Amount.ToString("##,##0.00").Replace(",", "")
    '            End If
    '            oVentaS2C("purchase_amount") = purchase_amount.ToString("##,##0.00").Replace(",", "")
    '            oVentaS2C("id_fortnight") = ObtenerIDQuincenasS2Credit(fortnight)
    '            oVentaS2C("id_insurance") = 1
    '        End With

    '        '-----------------------------------------------------
    '        ' Realizamos la venta en S2Credit
    '        '-----------------------------------------------------
    '        Me.oResVentaS2C = Nothing
    '        Me.oResVentaS2C = oS2Credit.SavePurchase(oVentaS2C)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Private Function ObtenerIDQuincenasS2Credit(ByVal Quincenas As String) As String

    '    '-----------------------------------------------------
    '    ' JNAVA (11.04.2016): Obtiene las quincenas en S2Credit
    '    '-----------------------------------------------------
    '    Dim ID As String = ""
    '    If oConfigCierreFI.AplicarS2Credit Then

    '        Dim oS2Credit As New ProcesosS2Credit
    '        Try
    '            Dim oQuincenasSC2 As List(Of Dictionary(Of String, Object)) 'NumeroQuincenasS2Credit
    '            oQuincenasSC2 = oS2Credit.fortnights()
    '            If Not oQuincenasSC2 Is Nothing AndAlso oQuincenasSC2.Count > 0 Then
    '                For Each oQuincena As Dictionary(Of String, Object) In oQuincenasSC2
    '                    If oQuincena("name").Trim = Quincenas.Trim Then
    '                        ID = oQuincena("id")
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    '    Return ID
    'End Function

    ''-----------------------------------------------------
    '' JNAVA (13.07.2016): Realiza Venta en S2Credit
    ''-----------------------------------------------------
    'Private Sub RealizarVentaS2Credit(ByVal arDatosDPVale() As String, ByVal oDPValeSAP As cDPValeSAP)

    '    Try

    '        '-----------------------------------------------------
    '        ' Preparamos datos para la venta
    '        '-----------------------------------------------------
    '        Dim oS2Credit As New ProcesosS2Credit
    '        Dim oVentaS2C As New Dictionary(Of String, Object)


    '        With oVentaS2C
    '            oVentaS2C("id_customer") = CInt(arDatosDPVale(0))
    '            oVentaS2C("id_distributor") = CInt(arDatosDPVale(2))
    '            oVentaS2C("id_coupon") = CInt(oDPValeSAP.IDDPVale)
    '            oVentaS2C("id_identification") = 1 'Se manda siempre el comodin
    '            oVentaS2C("identification_value") = "X"
    '            oVentaS2C("purchase_date") = Format(Date.Today, "yyyy-MM-dd")
    '            If oDPValeSAP.MONTODPVALE <= 0 Then
    '                oVentaS2C("amount") = oDPValeSAP.MontoUtilizado.ToString("##,##0.00").Replace(",", "")
    '            Else
    '                oVentaS2C("amount") = oDPValeSAP.MONTODPVALE.ToString("##,##0.00").Replace(",", "")
    '            End If
    '            oVentaS2C("purchase_amount") = oDPValeSAP.MontoUtilizado.ToString("##,##0.00").Replace(",", "")
    '            oVentaS2C("id_fortnight") = ObtenerIDQuincenasS2Credit(oDPValeSAP.NUMDE)
    '            oVentaS2C("id_insurance") = 1
    '        End With

    '        '-----------------------------------------------------
    '        ' Realizamos la venta en S2Credit
    '        '-----------------------------------------------------
    '        Dim oResVentaS2C As Dictionary(Of String, Object)
    '        oResVentaS2C = oS2Credit.SavePurchase(oVentaS2C)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

#End Region

#Region "Conciliacion de pedidos PRO y SAP"
    Private Function ValidarFormaPago(ByVal CodFormaPago As String) As Boolean
        Dim valido As Boolean = False
        For Each row As DataRow In dsFormasPago.Tables(0).Rows
            If CStr(row("CodFormasPago")).Trim() = CodFormaPago Then
                valido = True
            End If
        Next
        Return valido
    End Function

    Private Function SaveDPValeInfo(ByVal FacturaId As Integer) As Boolean

        Dim valido As Boolean = False
        Dim datos As New Dictionary(Of String, Object)
        Try
            Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim FormaPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
            Dim formasPago As DataTable = FormaPago.Load(FacturaId).Tables(0)
            Dim FormaPagoId As String = ""
            Dim arDatosZV() As String
            Dim arDatosDPVale() As String

            For Each row As DataRow In formasPago.Rows
                If CStr(row("CodFormasPago")) = "DPVL" Then
                    FormaPagoId = CStr(row("FormaPagoID"))
                End If
            Next
            arDatosDPVale = GetDPValeSAP()
            datos("FORMAPAGOID") = FormaPagoId
            datos("NUMVA") = oDpvaleSAP.IDDPVale
            datos("NUMDE") = oDpvaleSAP.NUMDE
            datos("DISTRIB") = arDatosDPVale(2).PadLeft(10, "0")
            datos("CTEDIST") = arDatosDPVale(0).PadLeft(10, "0")
            datos("PARES_PZAS") = oDpvaleSAP.ParesPzas
            datos("MONTO_UTILIZADO") = oDpvaleSAP.MontoUtilizado
            datos("MONTODPVALE") = CDec(arDatosDPVale(1))
            datos("FECCO") = oDpvaleSAP.FechaCobro
            If oDpvaleSAP.REVALE Then
                datos("REVALE") = True
            Else
                datos("REVALE") = False
            End If
            datos("RPARES_PZAS") = oDpvaleSAP.RPARES_PZAS
            datos("RMONTODPVALE") = oDpvaleSAP.RMONTODPVALE
            If oConfigCierreFI.GenerarSeguro Then
                Dim SecureArray() As String
                Dim DataSecure As New Hashtable()
                SecureArray = GetDPValeSAP()
                DataSecure("I_NUMVA") = oDpvaleSAP.IDDPVale
                DataSecure("I_KUNNR") = SecureArray(0).PadLeft(10, "0")
                If oConfigCierreFI.GenerarSeguro Then
                    DataSecure("I_ZSEG") = "1"
                Else
                    DataSecure("I_ZSEG") = "0"
                End If
                DataSecure("I_FECCO") = oDpvaleSAP.FechaCobro.ToString("yyyyMMdd")
                DataSecure("I_NUMDE") = oDpvaleSAP.NUMDE

                '------------------------------------------------------------------
                ' JNAVA (07.04.2017): Validamos que si está activo S2credit
                '------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    oFactura.SeguroVidaSAPDPVL = False
                    ImporteSeguro = 0
                    datos("ZSEG") = 0
                Else
                    If oSAPMgr.ZDPVL_VALSEGUROSAFS(DataSecure) = True Then
                        oFactura.SeguroVidaSAPDPVL = True
                        datos("ZSEG") = 1
                    Else
                        oFactura.SeguroVidaSAPDPVL = False
                        ImporteSeguro = 0
                        datos("ZSEG") = 0
                    End If
                End If
                '------------------------------------------------------------------
            Else
                '---------------------------------------------------------------------------------
                ' JNAVA (02.12.2016): Corrección por si no esta activo el seguro mandar el ZSEG
                '---------------------------------------------------------------------------------
                oFactura.SeguroVidaSAPDPVL = False
                ImporteSeguro = 0
                datos("ZSEG") = 0
            End If
            datos("IMPSEG") = ImporteSeguro
            If Not DatosTicketSeguro Is Nothing AndAlso DatosTicketSeguro.Count > 0 Then
                datos("FOLSEG") = DatosTicketSeguro("folseg")
            Else
                datos("FOLSEG") = 0
            End If
            datos("DIV") = DivPlaza
            If FacturaMgr.SaveDetalleDPVale(datos) = False Then
                MessageBox.Show("Hubo un error al guardar los datos de DPVale", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            valido = True
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al guardar el detalle del DPVale")
            valido = False
        End Try
        Return valido
    End Function
#End Region

#Region "Pagos Banamex"

    Private Function ValidarPagoBanamex(ByRef mensaje As String) As Boolean
        Dim valido As Boolean = True
        If cmbPromocion.Value Is Nothing Then
            valido = False
            mensaje = "No has elegido la promoción"
        ElseIf CStr(cmbPromocion.Value).Trim() = "" Then
            valido = False
            mensaje = "No has elegido la promoción"
        ElseIf EBPago.Value Is Nothing AndAlso CDec(EBPago.Value) > 0 Then
            valido = False
            mensaje = "No has capturado el monto a pagar"
        End If
        Return valido
    End Function

    Private Sub AddFormaPagoBanamex()
        Dim mensaje As String = ""
        If ValidarPagoBanamex(mensaje) = True Then
            Dim pay As New uPaydll.upaydll()
            Dim response As String = pay.ventas(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, Convert.ToDecimal(EBPago.Value), CInt(cmbPromocion.Value), Convert.ToDecimal(0.0), Convert.ToDecimal(0.0))
            If response.Trim() <> "" Then
                Dim lstResponse As Dictionary(Of String, Object) = GetResponse(response)
                '--------------------------------------------------------------------------------
                'FLIZARRAGA 18/01/2017: Se valida si paso la tarjeta
                '--------------------------------------------------------------------------------
                If CInt(lstResponse("trn_internal_respcode")) = -1 Then
                    ebAutorizacion.Text = CStr(lstResponse("trn_auth_code"))
                    Dim dvBanco As New DataView(dsBanco.Tables(0), "CodBanco = '" & Me.ebCodBanco.Value & "'", "CodBanco", DataViewRowState.CurrentRows)
                    Me.strNoAfiliacion = oFacturaMgr.GetAfiliacion(Me.cmbPromocion.Value, dvBanco(0)!IDEmisor)
                    If InsertFormaPagoBanamex(lstResponse) Then
                        '------------------------------------------------------------------------
                        'FLIZARRAGA 18/01/2017: Se imprimen los vouchers
                        '------------------------------------------------------------------------
                        'PrintVoucherBanamex(lstResponse, False)
                        'PrintVoucherBanamex(lstResponse, True)
                        MessageBox.Show("Su pago fue realizado exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show(CStr(lstResponse("trn_msg_host")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            pay = Nothing
        Else
            MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function GetResponse(ByVal response As String) As Dictionary(Of String, Object)
        Dim resultado As New Dictionary(Of String, Object)
        If response.Trim() <> "" Then
            Dim responses() As String = response.Split("|")
            Dim values() As String
            For Each answer As String In responses
                values = answer.Split("=")
                If values(0).Trim() <> "" Then
                    resultado(CStr(values(0)).Trim()) = values(1)
                End If
            Next
        End If
        Return resultado
    End Function

    Private Function InsertFormaPagoBanamex(ByVal datos As Dictionary(Of String, Object)) As Boolean
        Dim bResp As Boolean = True

        Dim drTarjetaRow As DataRow
        drTarjetaRow = dsFormasPago.Tables(0).NewRow

        With drTarjetaRow

            .Item("DPValeID") = CStr(datos("trn_id")) 'Se agrega el ConsecutivoPOS 
            .Item("CodFormasPago") = cmbFormaPago.Value
            .Item("CodBanco") = ebCodBanco.Value
            .Item("CodTipoTarjeta") = ebTipoTarjeta.Value
            .Item("NumeroTarjeta") = CStr(datos("trn_card_number"))
            .Item("NumeroAutorizacion") = ebAutorizacion.Text
            .Item("NotaCreditoID") = 0
            .Item("ComisionBancaria") = EBPagoCom.Value
            .Item("IngresoComision") = 0 'Decimal.Round(EBPagoCom.Value / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            .Item("IvaComision") = 0 '.Item("ComisionBancaria") - .Item("IngresoComision")
            .Item("DescripcionFormaPago") = cmbFormaPago.Text.ToUpper
            .Item("MontoPago") = EBPago.Value
            .Item("NoAfiliacion") = Me.strNoAfiliacion
            .Item("Id_Num_Promo") = Me.cmbPromocion.Value

            dsFormasPago.Tables(0).Rows.Add(drTarjetaRow)

            gridFormaPago.Refresh()

            ebTotalPagoCliente.Value = ebTotalPagoCliente.Value + EBPago.Value

        End With

        drTarjetaRow = Nothing

        Return bResp
    End Function

    Private Sub PrintVoucherBanamex(ByVal Datos As Dictionary(Of String, Object), ByVal EsCopia As Boolean)
        Dim oARReporte As New rptVoucherBanamex(Datos, EsCopia)
        oARReporte.Document.Name = "Voucher Banamex"

        If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

            oARReporte.PageSettings.PaperHeight = 7
            oARReporte.PageSettings.PaperWidth = 14
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
            oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        End If

        oARReporte.Run()

        'Dim oReportViewer As New ReportViewerForm
        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        '-----------------------------------------------------------------------------------
        ' Imprimimos voucher 
        '-----------------------------------------------------------------------------------
        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    '-----------------------------------------------------------------------------
    'FLIZARRAGA 17/01/2017: Obtiene las promociones de Banamex
    '-----------------------------------------------------------------------------

    Private Sub GetPromocionesBanamex()
        dtPromociones = oFacturaMgr.GetPromocionesBanamex()

        Me.cmbPromocion.DataSource = dtPromociones
        Me.cmbPromocion.DropDownList.Columns("CodPromo").DataMember = "Id_Num_Promo"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").DataMember = "Desc_Promo"
        Me.cmbPromocion.DropDownList.Columns("Descripcion").Width = 150

        Me.cmbPromocion.DisplayMember = "Desc_Promo"
        Me.cmbPromocion.ValueMember = "Id_Num_Promo"
        Me.cmbPromocion.DropDownList.Columns("CodPromo").Visible = False
        Me.cmbPromocion.Refresh()
    End Sub

#End Region

#Region "Compre hoy y pague despues"

    Private Function GetRowFechaCobro(ByVal dtDetalle As DataTable, ByVal Hoy As DateTime) As DataRow
        Dim fila As DataRow = Nothing
        If Not dtDetalle Is Nothing AndAlso dtDetalle.Rows.Count > 0 Then
            Dim view As New DataView(dtDetalle.Copy())
            view.Sort = "NUMDE DESC"
            For Each row As DataRow In view.Table.Rows
                Dim strFecha As String = CStr(row!FECCO)
                Dim FechaCobro As DateTime
                If strFecha.Trim() <> "" AndAlso CLng(strFecha.Trim) > 0 Then
                    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                    FechaCobro = CDate(strFecha)
                    If FechaCobro > Hoy Then
                        row("FECCO") = FechaCobro
                        fila = row
                        Return fila
                    End If
                End If
            Next
        End If
        Return fila
    End Function

#End Region

#Region "DPTickets"

    Private Function GetMensajeDPTicket() As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        If oConfigCierreFI.HabilitarDPTicket Then
            Dim xml As String
            Dim fecha As DateTime
            Dim strFecha As String
            Dim vale As cDPVale
            Try
                Dim insurance As Boolean = False
                If Not DatosTicketSeguro Is Nothing Then
                    insurance = True
                Else
                    insurance = False
                End If
                If IsDBNull(oDpvaleSAP.InfoDPVALE.Rows(0)("FECCR")) = False Then
                    strFecha = CStr(oDpvaleSAP.InfoDPVALE.Rows(0)!FECCR)
                    fecha = New DateTime(CInt(strFecha.Substring(0, 4)), CInt(strFecha.Substring(4, 2)), CInt(strFecha.Substring(6, 2)))
                Else
                    fecha = DateTime.Now
                End If
                xml = CrearXMLDPTicket("VF", "CANJEANTE", CInt(oDpvaleSAP.NUMDE), CDec(oDpvaleSAP.MONTODPVALE), fecha, insurance)
                Dim proceso As New ProcesosDPTicket()
                result = proceso.GetDPTicket(xml)
            Catch ex As Exception
                EscribeLog(ex.Message, "Error al obtener DPTicket")
            End Try
        End If
        Return result
    End Function

    Public Function CrearXMLDPTicket(ByVal TipoVenta As String, ByVal Canjeante As String, ByVal NumQ As Integer, ByVal MontoPrestamo As Decimal, ByVal FechaInicio As DateTime, ByVal seguro As Boolean) As String
        Dim xml As String = "<Mensaje>" & vbCrLf
        xml &= "<Origen Ident='dpvale' />"
        xml &= "<contenido sucursal='" & oAppContext.ApplicationConfiguration.Plaza & "-" & oAppContext.ApplicationConfiguration.Tienda & "' "
        xml &= "tipo_venta='" & TipoVenta & "' "
        xml &= "fechainicio='" & FechaInicio.ToString("dd/MM/yyyy") & "' "
        xml &= "cliente='" & Canjeante.Trim() & "' "
        If seguro Then
            xml &= "seguro='SI' "
        Else
            xml &= "seguro='NO' "
        End If
        xml &= "tipo_plazo='" & CStr(NumQ) & "QNA' "
        xml &= "monto='" & MontoPrestamo.ToString("##,##0.00").Replace(",", "") & "' /> " & vbCrLf
        xml &= "<detalles></detalles>" & vbCrLf
        xml &= "</Mensaje>"
        Return xml
    End Function

#End Region

#Region "Vale Electronico"

    Public Sub ImprimeValeElectronico(ByVal oDpvaleSAP As cDPValeSAP)
        Dim datoReporte As New Dictionary(Of String, Object)
        Dim oS2Credit As New ProcesosS2Credit
        Dim oCSAP As ClientesSAP
        Dim CatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim oAlmacen As Almacen = CatalogoAlmacenMgr.Create()
        Dim MontoLetra As New Letras()
        Dim centro As String = ""
        centro = oSAPMgr.Read_Centros(oAppContext.ApplicationConfiguration.Almacen)
        CatalogoAlmacenMgr.LoadInto(centro, oAlmacen)
        oCSAP = GetClienteDPVale(oDpvaleSAP.IDCliente)
        datoReporte("NUMVA") = oDpvaleSAP.IDDPVale
        datoReporte("CODCT") = oDpvaleSAP.IDCliente
        datoReporte("KUNNR") = oDpvaleSAP.IDAsociado
        datoReporte("DomicilioCODCT") = oCSAP.Domicilio & " " & oCSAP.NumeroExterior & " " & oCSAP.NumeroInterior & " " & oCSAP.Colonia & " " & oCSAP.Ciudad & " " & oCSAP.Estado
        datoReporte("TelefonoCODCT") = oCSAP.Telefono
        datoReporte("NombreCODCT") = oCSAP.Nombre & " " & oCSAP.Apellidos
        datoReporte("NoArticulos") = oDpvaleSAP.ParesPzas
        datoReporte("Monto") = oDpvaleSAP.MontoUtilizado
        datoReporte("PagareDomicilio") = oAlmacen.DireccionCalle & " " & oAlmacen.DireccionNumExt & " " & oAlmacen.DireccionNumInt & " " & oAlmacen.DireccionColonia & " " & oAlmacen.DireccionCP
        datoReporte("PagareCiudad") = oAlmacen.DireccionCiudad
        datoReporte("MontoLetra") = MontoLetra.Letras(oDpvaleSAP.MontoUtilizado)
        If oDpvaleSAP.PromocionID.Trim() <> "" Then
            If oDpvaleSAP.FechaCobro.Date > DateTime.Now.Date Then
                datoReporte("EsCompreHoyPagueDespues") = True
            Else
                datoReporte("EsCompreHoyPagueDespues") = False
            End If
        Else
            datoReporte("EsCompreHoyPagueDespues") = False
        End If
        datoReporte("EsRevale") = oDpvaleSAP.REVALE
        datoReporte("FolioRevale") = oDpvaleSAP.IDDPVale
        datoReporte("FechaEmision") = oDpvaleSAP.FechaCreacion
        datoReporte("FechaFacturacion") = oDpvaleSAP.FechaCobro
        Dim rptValeElect As New rptValeElectronico(datoReporte)
        Try
            rptValeElect.Run()
            rptValeElect.Document.Print(False, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.Message, "Error al imprimir el vale electronico")
        End Try
    End Sub

#End Region

#Region "Fecha de primer Pago Vale"

    Private Function GetFechaFechaPrimerPago(ByVal Fecha As DateTime) As DateTime
        Dim FechaCobro As DateTime
        If Fecha.Day >= 1 And Fecha.Day <= 6 Then
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, 15)
        ElseIf Fecha.Day >= 7 AndAlso Fecha.Day <= 20 Then
            Dim dia As Integer = 0
            Select Case Fecha.Month
                Case 1
                    dia = 31
                Case 2
                    dia = 28
                Case 3
                    dia = 31
                Case 4
                    dia = 30
                Case 5
                    dia = 31
                Case 6
                    dia = 30
                Case 7
                    dia = 31
                Case 8
                    dia = 31
                Case 9
                    dia = 30
                Case 10
                    dia = 31
                Case 11
                    dia = 30
                Case 12
                    dia = 31
            End Select
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, dia)
        ElseIf Fecha.Day >= 21 AndAlso Fecha.Day <= 31 Then
            FechaCobro = New DateTime(Fecha.AddMonths(1).Year, Fecha.AddMonths(1).Month, 15)
        End If
        Return FechaCobro
    End Function

#End Region

#Region "Activación de tarjeta y acumulación de puntos"

    Private Function GetSumaFormasPago(ByRef Log As String) As Decimal
        Dim AmountActivacion As Decimal = 0
        Log &= "El total de la factura es: " & CStr(ebImporteTotal.Value) & vbCrLf
        For Each row As DataRow In dsFormasPago.Tables(0).Rows
            If CStr(row("CodFormasPago")).Trim() <> "VCJA" AndAlso CStr(row("CodFormasPago")).Trim() <> "DPCA" AndAlso CStr(row("CodFormasPago")).Trim() <> "DPPT" Then
                If row("CodFormasPago") = "EFEC" And ebCambioCliente.Value > 0 Then
                    AmountActivacion += CDec(row("MontoPago")) - ebCambioCliente.Value
                Else
                    AmountActivacion += CDec(row("MontoPago"))
                End If
                Log &= "La forma de Pago " & CStr(row("CodFormasPago")) & " tiene un monto de " & CStr(row("MontoPago")) & vbCrLf
            End If
        Next
        Log &= "El total de la suma sin formas de pago VCJA,DPCA,DPPT: " & CStr(AmountActivacion) & vbCrLf
        Return AmountActivacion
    End Function

    Private Function GetMontoDPCardPunto() As Decimal
        Dim Monto As Decimal = 0
        Dim ArtMgr As New CatalogoArticuloManager(oAppContext)
        Dim Art As Articulo = ArtMgr.Create()
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0
        For Each RowFila As DataRow In oFactura.Detalle.Tables(0).Rows
            Art.ClearFields()
            ArtMgr.LoadInto(CStr(RowFila("Codigo")), Art)
            If Art.CodArtProv.Contains("CARD") Then
                total = 0
                descSistema = 0
                descuento = 0
                unitPrice = 0
                cantidad = 0
                cantidad = Decimal.Round(CDec(RowFila("Cantidad")), 2)
                total = RowFila("Total")
                descSistema = RowFila("Descuento")
                total = total - descSistema
                descuento = RowFila("Adicional")
                descuento = total * (descuento / 100)

                unitPrice = RowFila("Importe") - (descSistema / cantidad) - (descuento / cantidad)
                unitPrice = Decimal.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                total = unitPrice * cantidad
                Monto += total
            End If
        Next
        Return Monto
    End Function

#End Region

#Region "Mejoras en tiendas"

    Private Function ValidaTotalDetalleCabecera() As Boolean
        Dim valido As Boolean = True
        Dim oRow As DataRow
        Dim vTotalGeneral As Decimal = 0
        Dim vSubTotal As Decimal = 0
        Dim vDscto As Decimal = 0
        Dim vDsctoAdicional As Decimal = 0
        Dim vSaldarDescuentoAdicional As Decimal = 0
        Dim vIVA As Decimal = 0
        Dim vDsctoUnit As Decimal = 0, vDsctoAdiUnit As Decimal = 0, vImporte As Decimal = 0
        'Dim idx As Integer = 0 
        Dim LogMensaje As String = "El total factura: " & CStr(oFactura.Total) & vbCrLf
        '--Flag Descuento Adicional

        '--End Flag
        If oFactura.Detalle.Tables(0).Rows.Count > 0 AndAlso oFactura.Detalle.Tables(0).Rows(0).RowState <> DataRowState.Deleted AndAlso CStr(oFactura.Detalle.Tables(0).Rows(0)!Codigo).Trim <> "" Then
            For Each oRow In oFactura.Detalle.Tables(0).Rows
                'Obtenemos el descuento total del producto
                If CInt(oRow!Cantidad) > 0 Then

                    '-----------------------------------------------------------------------------------
                    ' Descuento por Sistema
                    '-----------------------------------------------------------------------------------
                    vDscto += oRow("Descuento")
                    'Calculamos el descuento por sistema que le toca a cada pieza del producto
                    vDsctoUnit = oRow("Descuento") / oRow("Cantidad")


                    '-----------------------------------------------------------------------------------
                    ' Descuento Adicional
                    '-----------------------------------------------------------------------------------
                    vSaldarDescuentoAdicional += oRow("Adicional")
                    'Calculamos el descuento adicional que le corresponde a cada pieza del producto
                    vDsctoAdiUnit = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdiUnit = vDsctoAdiUnit / oRow("Cantidad") ' Truncar(vDsctoAdiUnit, 2) / oRow("Cantidad")
                    Dim vDsctoAdicionalTotal As Decimal = Decimal.Zero
                    vDsctoAdicionalTotal = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdicional += vDsctoAdicionalTotal


                    '-----------------------------------------------------------------------------------
                    ' Importe
                    '-----------------------------------------------------------------------------------
                    'Calculamos el importe unitario de cada pieza del producto restando los descuentos
                    vImporte = oRow("Importe") - vDsctoUnit - vDsctoAdiUnit
                    'Le aumentamos el iva al precio unitario
                    vImporte = Decimal.Round(vImporte * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    LogMensaje &= "CodArtículo: " & CStr(oRow("Codigo")) & " Cant: " & CStr(oRow("Cantidad")) & " Importe: " & CStr(vImporte) & vbCrLf
                    '-----------------------------------------------------------------------------------
                    ' Total
                    '-----------------------------------------------------------------------------------
                    'Sumamos al importe total de la factura el total de este producto ya con los descuentos restados y el iva aumentado
                    vTotalGeneral = vTotalGeneral + (vImporte * oRow("Cantidad"))

                End If
            Next
        End If
        If Math.Abs(oFactura.Total - vTotalGeneral) > 1 Then
            EscribeLog("Error de Monto " & vbCrLf & LogMensaje, "Log de errores de Monto")
            valido = False
        Else
            EscribeLog("Correcto Monto " & vbCrLf & LogMensaje, "Log de errores de Monto")
        End If
        Return valido
    End Function

#End Region

End Class