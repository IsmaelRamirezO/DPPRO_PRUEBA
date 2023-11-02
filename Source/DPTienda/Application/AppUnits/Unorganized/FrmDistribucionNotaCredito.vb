Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsEstadoCuentaAsociado
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU.wsAsociados
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.PeriodoDetalleUI
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.IO
Imports System.Collections.Generic

'Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago

Public Class FrmDistribucionNotaCredito
    Inherits System.Windows.Forms.Form

    Dim oDPVale As cDPVale

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebMontoCDT As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents LblCDT As System.Windows.Forms.Label
    Friend WithEvents LblDPVale As System.Windows.Forms.Label
    Friend WithEvents gridNotaCredito As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebMontoNotaCredito As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMontoDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMontoAnticipoCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMontoTarjetaCredito As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uIBtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMontoFonacot As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMontoFacilito As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCanje As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCanje As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDistribucionNotaCredito))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.txtCanje = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCanje = New System.Windows.Forms.Label()
        Me.ebMontoFonacot = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoFacilito = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.uIBtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ebMontoDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoAnticipoCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoTarjetaCredito = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMontoNotaCredito = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.gridNotaCredito = New Janus.Windows.GridEX.GridEX()
        Me.ebMontoCDT = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.LblCDT = New System.Windows.Forms.Label()
        Me.LblDPVale = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(10, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 23)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Monto Nota Crédito:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.txtCanje)
        Me.ExplorerBar1.Controls.Add(Me.lblCanje)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoFonacot)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoFacilito)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.uIBtnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoDPVale)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoAnticipoCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoTarjetaCredito)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoNotaCredito)
        Me.ExplorerBar1.Controls.Add(Me.gridNotaCredito)
        Me.ExplorerBar1.Controls.Add(Me.ebMontoCDT)
        Me.ExplorerBar1.Controls.Add(Me.LblCDT)
        Me.ExplorerBar1.Controls.Add(Me.LblDPVale)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Anticipo Clientes"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(896, 376)
        Me.ExplorerBar1.TabIndex = 29
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'txtCanje
        '
        Me.txtCanje.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCanje.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCanje.BackColor = System.Drawing.SystemColors.Info
        Me.txtCanje.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanje.Location = New System.Drawing.Point(104, 350)
        Me.txtCanje.Name = "txtCanje"
        Me.txtCanje.ReadOnly = True
        Me.txtCanje.Size = New System.Drawing.Size(104, 22)
        Me.txtCanje.TabIndex = 45
        Me.txtCanje.TabStop = False
        Me.txtCanje.Text = "0"
        Me.txtCanje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCanje.Visible = False
        Me.txtCanje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCanje
        '
        Me.lblCanje.BackColor = System.Drawing.Color.Transparent
        Me.lblCanje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCanje.Location = New System.Drawing.Point(16, 351)
        Me.lblCanje.Name = "lblCanje"
        Me.lblCanje.Size = New System.Drawing.Size(96, 23)
        Me.lblCanje.TabIndex = 44
        Me.lblCanje.Text = "Canje:"
        Me.lblCanje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCanje.Visible = False
        '
        'ebMontoFonacot
        '
        Me.ebMontoFonacot.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoFonacot.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoFonacot.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoFonacot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoFonacot.Location = New System.Drawing.Point(496, 288)
        Me.ebMontoFonacot.Name = "ebMontoFonacot"
        Me.ebMontoFonacot.ReadOnly = True
        Me.ebMontoFonacot.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoFonacot.TabIndex = 42
        Me.ebMontoFonacot.TabStop = False
        Me.ebMontoFonacot.Text = "0"
        Me.ebMontoFonacot.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoFonacot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoFacilito
        '
        Me.ebMontoFacilito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoFacilito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoFacilito.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoFacilito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoFacilito.Location = New System.Drawing.Point(496, 320)
        Me.ebMontoFacilito.Name = "ebMontoFacilito"
        Me.ebMontoFacilito.ReadOnly = True
        Me.ebMontoFacilito.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoFacilito.TabIndex = 41
        Me.ebMontoFacilito.TabStop = False
        Me.ebMontoFacilito.Text = "0"
        Me.ebMontoFacilito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoFacilito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(416, 320)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Facilito :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(416, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 23)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fonacot:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'uIBtnAceptar
        '
        Me.uIBtnAceptar.Icon = CType(resources.GetObject("uIBtnAceptar.Icon"), System.Drawing.Icon)
        Me.uIBtnAceptar.Location = New System.Drawing.Point(608, 309)
        Me.uIBtnAceptar.Name = "uIBtnAceptar"
        Me.uIBtnAceptar.Size = New System.Drawing.Size(104, 34)
        Me.uIBtnAceptar.TabIndex = 38
        Me.uIBtnAceptar.Text = "Guardar"
        Me.uIBtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMontoDPVale
        '
        Me.ebMontoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoDPVale.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoDPVale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoDPVale.Location = New System.Drawing.Point(296, 288)
        Me.ebMontoDPVale.Name = "ebMontoDPVale"
        Me.ebMontoDPVale.ReadOnly = True
        Me.ebMontoDPVale.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoDPVale.TabIndex = 37
        Me.ebMontoDPVale.TabStop = False
        Me.ebMontoDPVale.Text = "0"
        Me.ebMontoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoAnticipoCliente
        '
        Me.ebMontoAnticipoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoAnticipoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoAnticipoCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoAnticipoCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoAnticipoCliente.Location = New System.Drawing.Point(104, 320)
        Me.ebMontoAnticipoCliente.Name = "ebMontoAnticipoCliente"
        Me.ebMontoAnticipoCliente.ReadOnly = True
        Me.ebMontoAnticipoCliente.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoAnticipoCliente.TabIndex = 36
        Me.ebMontoAnticipoCliente.TabStop = False
        Me.ebMontoAnticipoCliente.Text = "0"
        Me.ebMontoAnticipoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoAnticipoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoTarjetaCredito
        '
        Me.ebMontoTarjetaCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoTarjetaCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoTarjetaCredito.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoTarjetaCredito.Location = New System.Drawing.Point(104, 288)
        Me.ebMontoTarjetaCredito.Name = "ebMontoTarjetaCredito"
        Me.ebMontoTarjetaCredito.ReadOnly = True
        Me.ebMontoTarjetaCredito.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoTarjetaCredito.TabIndex = 35
        Me.ebMontoTarjetaCredito.TabStop = False
        Me.ebMontoTarjetaCredito.Text = "0"
        Me.ebMontoTarjetaCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoTarjetaCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoNotaCredito
        '
        Me.ebMontoNotaCredito.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoNotaCredito.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoNotaCredito.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoNotaCredito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoNotaCredito.Location = New System.Drawing.Point(162, 47)
        Me.ebMontoNotaCredito.Name = "ebMontoNotaCredito"
        Me.ebMontoNotaCredito.ReadOnly = True
        Me.ebMontoNotaCredito.Size = New System.Drawing.Size(128, 22)
        Me.ebMontoNotaCredito.TabIndex = 34
        Me.ebMontoNotaCredito.TabStop = False
        Me.ebMontoNotaCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoNotaCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gridNotaCredito
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridNotaCredito.DesignTimeLayout = GridEXLayout1
        Me.gridNotaCredito.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridNotaCredito.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridNotaCredito.GroupByBoxVisible = False
        Me.gridNotaCredito.Location = New System.Drawing.Point(8, 80)
        Me.gridNotaCredito.Name = "gridNotaCredito"
        Me.gridNotaCredito.Size = New System.Drawing.Size(704, 192)
        Me.gridNotaCredito.TabIndex = 33
        Me.gridNotaCredito.TabStop = False
        Me.gridNotaCredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMontoCDT
        '
        Me.ebMontoCDT.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoCDT.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoCDT.BackColor = System.Drawing.SystemColors.Info
        Me.ebMontoCDT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoCDT.Location = New System.Drawing.Point(296, 320)
        Me.ebMontoCDT.Name = "ebMontoCDT"
        Me.ebMontoCDT.ReadOnly = True
        Me.ebMontoCDT.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoCDT.TabIndex = 32
        Me.ebMontoCDT.TabStop = False
        Me.ebMontoCDT.Text = "0"
        Me.ebMontoCDT.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoCDT.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblCDT
        '
        Me.LblCDT.BackColor = System.Drawing.Color.Transparent
        Me.LblCDT.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblCDT.Location = New System.Drawing.Point(216, 320)
        Me.LblCDT.Name = "LblCDT"
        Me.LblCDT.Size = New System.Drawing.Size(72, 23)
        Me.LblCDT.TabIndex = 31
        Me.LblCDT.Text = "C.D.T :"
        Me.LblCDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblDPVale
        '
        Me.LblDPVale.BackColor = System.Drawing.Color.Transparent
        Me.LblDPVale.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblDPVale.Location = New System.Drawing.Point(216, 288)
        Me.LblDPVale.Name = "LblDPVale"
        Me.LblDPVale.Size = New System.Drawing.Size(72, 23)
        Me.LblDPVale.TabIndex = 25
        Me.LblDPVale.Text = "DP Vale :"
        Me.LblDPVale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 320)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 23)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Vale Caja :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "T. Crédito :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmDistribucionNotaCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 347)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDistribucionNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribución Nota de Crédito"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gridNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oSAPMgr As ProcesoSAPManager

    Private oDistribucionNCMgr As DistribucionNCManager

    Private oDistribucionNC As DistribucionNC

    Private oNotaCredito As NotaCredito

    Private intAnticipoID As Integer

    Private strTipoVentaID As String

    Private bFacturar As Boolean

    Private boFacturasPorLiquidar As Boolean

    Private bolSalir As Boolean

    Private Referencia As Integer 'Factura a la que se le realizó la NC.

    Public bShow As Boolean = True

    Private MotivoPedido As String

    Private m_Factura As Factura

    Private m_NotaCredito As NotaCredito

    Private CustomerName As String = String.Empty
    Private SaldoPuntos As String = String.Empty
#Region "Carga notas de crédito Masivo"
    ''' <summary>
    ''' Variable para determinar si la pantalla se debe mostrar completamente en modo desatendido (cargas masivas de notas de crédito)
    ''' </summary>
    ''' <remarks></remarks>
    Private Desatendido As Boolean = False
    ''' <summary>
    ''' Variable para determinar si se debe de generar el revale de manera automática
    ''' </summary>
    ''' <remarks>Depende de la propiedad <paramref name="Desatendido"></paramref> tenga valor true</remarks>
    Private GenerarRevale As Boolean = False
#End Region

#Region "Variables ValeCaja"
    'Para Saldar ValeCaja en impresion
    Dim decTarjetaCredito As Decimal
    Dim decFonacot As Decimal
#End Region


#End Region

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (11.04.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit
    Public oDPValeS2C As Dictionary(Of String, Object) 'InfoValeS2Credit
    Public oClienteResS2C As List(Of Dictionary(Of String, Object)) 'ResultadoClienteS2Credit
    Public oReValeS2C As Dictionary(Of String, Object) '

#End Region

#Region "Propiedades"

    Public WriteOnly Property NotaCredito() As NotaCredito

        Set(ByVal Value As NotaCredito)

            oNotaCredito = Value

        End Set

    End Property


    Public WriteOnly Property AnticipoID() As Integer

        Set(ByVal Value As Integer)

            intAnticipoID = Value

        End Set

    End Property


    Public WriteOnly Property TipoVenaID() As String

        Set(ByVal Value As String)

            strTipoVentaID = Value

        End Set

    End Property

    Public Property Facturar() As Boolean
        Get
            Return bFacturar
        End Get
        Set(ByVal Value As Boolean)
            bFacturar = Value
        End Set
    End Property

    Public WriteOnly Property FacturasPorLiquidar() As Boolean

        Set(ByVal Value As Boolean)

            boFacturasPorLiquidar = Value

        End Set

    End Property

    Public Sub ShowDev()

        Sm_Inicializar()

        uIBtnAceptar.PerformClick()

    End Sub

    Public Property Factura As Factura
        Get
            Return m_Factura
        End Get
        Set(value As Factura)
            m_Factura = value
        End Set
    End Property

#End Region

#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oDistribucionNCMgr = New DistribucionNCManager(oAppContext)

        'NOTA :
        '       Utilizar como parametro el ID del AniticipoClientes

        'oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(oNotaCredito)


        'Dim intAnticipoID As Integer

        'intAnticipoID = oContratosMgr.DistibucionCancelarContrato(oContrato)

        oDistribucionNC = Nothing

        oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID, "NC")

        'ebMontoNotaCredito.Text = Format(oDistribucionNC.TotalAnticipoCliente, "Currency")

        ebMontoNotaCredito.Text = Format(oDistribucionNC.TotalAnticipoCliente + oDistribucionNC.TotalFonacotFacilito, "Currency")

        ebMontoTarjetaCredito.Text = Format(oDistribucionNC.TotalTarjetaCredito, "Standard")
        'Aqui debe aparecer el saldo
        ebMontoAnticipoCliente.Text = Format(oDistribucionNC.SaldoAnticipoCliente + oDistribucionNC.TotalCanje, "Standard")

        ebMontoDPVale.Text = Format(oDistribucionNC.TotalDPVale, "Standard")

        ebMontoCDT.Text = Format(oDistribucionNC.TotalCDT, "Standard")

        '----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 18/09/2018: Obtenemos el importe del canje a devolver
        '----------------------------------------------------------------------------------------------------------------------------
        Me.txtCanje.Text = Format(oDistribucionNC.TotalCanje, "Standard")

        gridNotaCredito.DataSource = oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle")

        If oNotaCredito.TipoVentaID = "F" Or oNotaCredito.TipoVentaID = "K" Then

            ebMontoFonacot.Text = Format(oDistribucionNC.TotalFonacotFacilito, "Standard")
            gridNotaCredito.Tables(0).Columns("MontoCanceladoFonacotFacilito").Caption = "FONACOT"

        End If

        If oNotaCredito.TipoVentaID = "O" Then

            ebMontoFacilito.Text = Format(oDistribucionNC.TotalFonacotFacilito, "Standard")
            gridNotaCredito.Tables(0).Columns("MontoCanceladoFonacotFacilito").Caption = "FACILITO"

        End If


        'UpdateMovimientosEstadoCuentaAsociado()

        Sm_FormConfiguracion()

    End Sub

    Private Sub Sm_Finalizar()

        oDistribucionNCMgr = Nothing

        oDistribucionNC = Nothing

    End Sub

    Private Sub Sm_FormConfiguracion()
        Dim tipoVentaMgr As New CatalogoTipoVentaManager(oAppContext)

        With gridNotaCredito.Tables(0)

            Select Case (strTipoVentaID)

                Case "P", "A", "I"

                    .Columns("DPValeID").Visible = False

                    .Columns("MontoCanceladoDPVale").Visible = False

                    ebMontoDPVale.Visible = False

                    LblDPVale.Visible = False

                    .Columns("MontoCanceladoCDT").Visible = False

                    ebMontoCDT.Visible = False

                    LblCDT.Visible = False

                Case "V"

                    .Columns("MontoCanceladoCDT").Visible = False

                    ebMontoCDT.Visible = False

                    LblCDT.Visible = False


                Case "D"

                    .Columns("DPValeID").Visible = False

                    .Columns("MontoCanceladoDPVale").Visible = False

                    ebMontoDPVale.Visible = False

                    LblDPVale.Visible = False

            End Select

        End With
        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 13/02/2016 Se carga el motivo de pedido de la nota de credito
        '-----------------------------------------------------------------------------------------------------------------------------
        MotivoPedido = tipoVentaMgr.GetMotivoPedidoByTipoVenta(strTipoVentaID)
    End Sub

    Private Function Fm_bolValidarNoAutorizacionCancelacion() As Boolean

        Dim drFactura As DataRow


        For Each drFactura In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows

            If (drFactura("NumeroTarjeta") <> String.Empty) And (IsDBNull(drFactura("NumeroAutorizacionCancelacion"))) Then

                MsgBox("La Factura : " & drFactura("Referencia") & " no tiene el No. de Cancelación.", MsgBoxStyle.Exclamation, "DPTienda")
                If MessageBox.Show("Desea continuar", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Function
                Else
                    decTarjetaCredito += CDec(Me.ebMontoTarjetaCredito.Text & "0")

                End If


            ElseIf (drFactura("NumeroTarjeta") <> String.Empty) And (Trim(CType(drFactura("NumeroAutorizacionCancelacion"), String)) = String.Empty) Then

                MsgBox("La Factura : " & drFactura("Referencia") & " no tiene el No. de Cancelación.", MsgBoxStyle.Exclamation, "DPTienda")
                If MessageBox.Show("Desea continuar", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Function
                Else
                    decTarjetaCredito += CDec(Me.ebMontoTarjetaCredito.Text & "0")
                End If


            End If

        Next

        Return True

    End Function

    Private Sub UpdateMovimientosEstadoCuentaAsociado()

        'Dim owsEstadoCuentaAsociado As New wsEstadoCuentaAsociado.EstadodeCuentaAsociado
        'Dim oMovimientoInfo As New wsEstadoCuentaAsociado.MovimientosInfo
        'Dim oSaldoInfo As New wsEstadoCuentaAsociado.SaldosInfo
        'Dim wsAsociado As New wsAsociados.CreditoAsociados
        'Dim oAsociado As New AsociadoInfo

        Dim intAsociadoID As Integer


        'Establecer Referencia.

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'owsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'owsEstadoCuentaAsociado.strURL

        End If


        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'wsAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'wsAsociado.strURL

        End If


        'oAsociado = wsAsociado.GetAsociadoByClienteID(oNotaCredito.ClienteID)

        'intAsociadoID = oAsociado.AsociadoID

        'wsAsociado = Nothing
        'oAsociado = Nothing


        'Actualizar Saldos y Movimientos
        With oNotaCredito

            'oMovimientoInfo.FechaMovimiento = .Fecha
            'oMovimientoInfo.CodigoAlmacen = .AlmacenID
            'oMovimientoInfo.CodigoCaja = .CajaID
            'oMovimientoInfo.FolioMovimiento = .NotaCreditoFolio
            'oMovimientoInfo.TipoDocumento = "NC"
            'oMovimientoInfo.Usuario = .Usuario
            'oMovimientoInfo.StatusRegistro = 1


            'oMovimientoInfo.Cargo = 0
            'oMovimientoInfo.AsociadoID = intAsociadoID
            'oMovimientoInfo.Mes = CInt(Format(.Fecha, "MM"))
            'oMovimientoInfo.Año = CInt(Format(.Fecha, "yyyy"))

            'If (oNotaCredito.TipoVentaID = "V") Then

            '    oMovimientoInfo.Abono = oDistribucionNC.TotalDPVale

            '    owsEstadoCuentaAsociado.InsertMovimiento("V", oMovimientoInfo)

            'ElseIf (oNotaCredito.TipoVentaID = "C") Then

            '    oMovimientoInfo.Abono = oDistribucionNC.TotalCDT

            '    owsEstadoCuentaAsociado.InsertMovimiento("C", oMovimientoInfo)

            'End If

        End With

    End Sub

    Private Sub FacturarDevolucionDPVale()

        'si es la tienda 053 y si es un dpvale mando imprimir una hoja con informacion

        Dim oResult As MsgBoxResult, i As Integer = 0
        Dim oRow As DataRow
        Dim idDpvale As String = ""
        Dim eRen As DataRow
        Dim oDPVale As New cDPVale


        ' Si facturar es false solo va a generar el revale
        If Facturar Then
            oResult = MsgBox("¿Desea Facturar Devolución DPVale?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Facturar DPVale")
        Else
            oResult = MsgBoxResult.Yes
        End If


        For Each oRow In oDistribucionNC.Detalle.Tables(0).Rows
            oRow = oDistribucionNC.Detalle.Tables(0).Rows(i)
            If CStr(oRow.Item("DPvaleID")) <> "" Then

                idDpvale = CStr(oRow.Item("DPvaleID"))
                Exit For

            End If
            i = i + 1
        Next

        If idDpvale <> "" Then

            'Objeto DPVale WS
            'Dim owsDPVale As New wsControlDPVales.ControlDPVales
            'Dim owsDPValeInfo As New wsControlDPVales.DPValeInfo
            'Dim owsDPValeFactura As New wsControlDPVales.DPValeFacturaInfo

            'Establecer Referencias.


            If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

                'owsDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
                'owsDPVale.strURL

            End If

            If oAppSAPConfig.DPValeSAP Then
                oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

                oDPVale.INUMVA = idDpvale
                oDPVale.I_RUTA = "X"

                '----------------------------------------------------------------------------------------
                ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                '----------------------------------------------------------------------------------------
                ' oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                '----------------------------------------------------------------------------------------
                ' JNAVA (15.07.2016): Valida DPVale
                '----------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
                Else
                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                End If
                '----------------------------------------------------------------------------------------

                If oDPVale.EEXIST = "S" Then
                    '--------------------------------
                    eRen = oDPVale.InfoDPVALE.Rows(0)
                    '--------------------------------
                Else
                    MessageBox.Show("El DPortenis Vale no existe", "Valida DPVale Origen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                'owsDPValeInfo.DPValeID = oDPVale.INUMVA
                'If Not eRen("DOCDP") = "" Then
                '    owsDPValeInfo.FacturaID = CInt(eRen("DOCDP"))
                'End If

            Else
                'owsDPValeInfo = owsDPVale.GetDPVale(idDpvale)
            End If



            If idDpvale <> "" Then

                'Objeto Factura
                Dim oFacturaMgr As New FacturaManager(oAppContext)
                Dim oFactura As Factura = oFacturaMgr.Create
                oFactura.ClearFields()
                Dim factid As Integer = oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)

                If oAppSAPConfig.DPValeSAP Then
                    'Que me encuentre la factura en base a el folio de dportenis pro
                    'oFacturaMgr.Load(owsDPValeInfo.FacturaID, oAppContext.ApplicationConfiguration.NoCaja, oFactura)
                Else
                    oFacturaMgr.LoadInto(factid, oFactura)
                End If

                'With owsDPValeFactura
                '    If oAppSAPConfig.DPValeSAP Then
                '        .FolioFactura = owsDPValeInfo.FacturaID
                '        .Almacen = oAppContext.ApplicationConfiguration.Almacen
                '        .CodigoCaja = oAppContext.ApplicationConfiguration.NoCaja
                '    Else
                '        .FolioFactura = oFactura.FolioFactura
                '        .Almacen = oFactura.CodAlmacen
                '        .CodigoCaja = oFactura.CodCaja
                '    End If
                '    .DPValeID = idDpvale
                '    .Devolucion = oDistribucionNC.TotalDPVale
                'End With

                'MARCAMOS LA DEVOLUCION

                If Not oAppSAPConfig.DPValeSAP Then
                    'owsDPVale.DPValeDevolucionUPD(owsDPValeFactura)
                End If


                If oResult = MsgBoxResult.Yes Then

                    'Facturamos
                    '---------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si está activa la nueva facturacion
                    '---------------------------------------------------------------------
                    Dim ofrmFactura As Object 'New frmFacturacion
                    If oConfigCierreFI.FacturacionNueva Then
                        ofrmFactura = New frmFacturacionNueva
                    Else
                        ofrmFactura = New frmFacturacion
                    End If
                    '---------------------------------------------------------------------

                    If oAppSAPConfig.DPValeSAP Then

                        '------------------Ir a sacar el dpvale a SAP-------------------------
                        Dim strResult As String = String.Empty
                        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (15.07.2016): Genera ReVale en S2Credit o en SAP si esta activa la Configuracion 
                        '----------------------------------------------------------------------------------------
                        'oNotaCredito.REVALE = oSAPMgr.ZBAPI_GENERAR_REVALE(idDpvale, oDistribucionNC.TotalDPVale, strResult)

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (15.07.2016): Generamos Revale 
                        '----------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            oNotaCredito.REVALE = oS2Credit.GeneraReVale(idDpvale, CStr(oDPVale.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0"), oDistribucionNC.TotalDPVale, strResult)
                        Else
                            oNotaCredito.REVALE = oSAPMgr.ZBAPI_GENERAR_REVALE(idDpvale, oDistribucionNC.TotalDPVale, strResult)
                        End If

                        '------------------Ir a sacar el dpvale a SAP-------------------------
                        'S 'Correcto', N = 'No existe Vale Origen', E='No se pudo generar el revale'
                        If strResult = "S" Then

                            MessageBox.Show("Vale Generado.-" & oNotaCredito.REVALE, "ReVale", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ImprimeRevale()

                            If Facturar Then
                                ofrmFactura.ShowNC(oNotaCredito.ID, _
                                               oDistribucionNC.TotalDPVale, _
                                               Convert.ToInt32(oNotaCredito.REVALE), _
                                               oNotaCredito.ClienteID, _
                                               oNotaCredito.PlayerID)
                            End If



                            bolSalir = True

                            Me.DialogResult = DialogResult.OK

                        Else
                            If strResult = "N" Then
                                MessageBox.Show("No se podra Facturar, el REVALE no se genero, por que no existe Vale Origen", "No existe Vale Origen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                If strResult = "E" Then
                                    MessageBox.Show("No se podra Facturar, el REVALE no se genero ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Else
                                    MessageBox.Show("No se podra Facturar, el REVALE no se genero ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If
                    Else

                        If Facturar Then
                            ofrmFactura.ShowNC(oNotaCredito.ID, _
                                            oDistribucionNC.TotalDPVale, _
                                            idDpvale, _
                                            oNotaCredito.ClienteID, _
                                            oNotaCredito.PlayerID)
                        End If


                    End If

                    ofrmFactura.Dispose()


                    oFactura = Nothing

                Else

                    If Not oAppSAPConfig.DPValeSAP Then
                        'Restamos al Monto DPVale utilizado
                        'Actualizamos DPVale
                        owsDPValeInfo.MontoUtilizado = owsDPValeInfo.MontoUtilizado - oDistribucionNC.TotalDPVale
                        If owsDPValeInfo.MontoUtilizado <= 0 Then
                            owsDPValeInfo.StatusRegistro = False
                        End If
                        'owsDPVale.UpdateDPVale(owsDPValeInfo)
                    Else

                        ''
                        Dim strResult As String = String.Empty
                        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

                        If MessageBox.Show("¿Desea generar el ReVale?", "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (20.07.2016): Genera ReVale en S2Credit o en SAP si esta activa la Configuracion 
                            '----------------------------------------------------------------------------------------
                            'oNotaCredito.REVALE = oSAPMgr.ZBAPI_GENERAR_REVALE(idDpvale, oDistribucionNC.TotalDPVale, strResult)

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (15.07.2016): Generamos Revale 
                            '----------------------------------------------------------------------------------------
                            If oConfigCierreFI.AplicarS2Credit Then
                                oNotaCredito.REVALE = oS2Credit.GeneraReVale(idDpvale, CStr(oDPVale.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0"), oDistribucionNC.TotalDPVale, strResult)
                            Else
                                oNotaCredito.REVALE = oSAPMgr.ZBAPI_GENERAR_REVALE(idDpvale, oDistribucionNC.TotalDPVale, strResult)
                            End If
                            '----------------------------------------------------------------------------------------

                            If strResult = "S" Then
                                ImprimeRevale()
                            Else
                                If strResult = "N" Then
                                    MessageBox.Show("No se podra Facturar, el REVALE no se genero en SAP, por que no existe Vale Origen", "No existe Vale Origen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    If strResult = "E" Then
                                        MessageBox.Show("No se podra Facturar, el REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Else
                                        MessageBox.Show("No se podra Facturar, el REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                            End If

                        End If

                    End If

                End If

            Else

                MsgBox("El Folio del DPVale No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Facturar DPVale")

            End If

            'owsDPVale.Dispose()
            'owsDPVale = Nothing
            'owsDPValeInfo = Nothing
            'owsDPValeFactura = Nothing

            

        End If

    End Sub
    Private Sub ImprimeRevale()
        'oNotaCredito.ID(, _
        'oDistribucionNC.TotalDPVale, ImprimeRevale
        'Convert.ToInt32(oNotaCredito.REVALE), _
        'oNotaCredito.ClienteID, _
        'oNotaCredito.PlayerID)

        'oDevolucionDPvale.NotaCreditoID = NCID
        'oDevolucionDPvale.MontoDPVale = MontoDPVale
        'oDevolucionDPvale.DPValeID = DPValeID
        'oDevolucionDPvale.ClienteID = ClienteID
        'oDevolucionDPvale.PlayerNC = Player

        'If MessageBox.Show("Desea mandar imprimir el ReVale", "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        Dim ofrmPago As New frmPago

        ofrmPago.InitializeObjects()
        ofrmPago.InitializeObjectsSAP()
        ofrmPago.owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        ofrmPago.owsDPValeInfo.MontoDPValeI = oDistribucionNC.TotalDPVale


        Dim oDPVale As New cDPVale
        oDPVale.INUMVA = CStr(Convert.ToInt32(oNotaCredito.REVALE)).PadLeft(10, "0")

        'Dim oConURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
        'oConURed.Conecta()

        'If Not Directory.Exists(oConfigCierreFI.Ruta & "\Firmas") Then
        '    Directory.CreateDirectory(oConfigCierreFI.Ruta & "\Firmas")
        'Else
        '    'Obtener la lista de todos los archivos
        '    Dim strFiles() As String = Directory.GetFileSystemEntries(oConfigCierreFI.Ruta & "\Firmas\", "*.BMP")

        '    For Each strFile As String In strFiles
        '        If Now.AddDays(-1).ToShortDateString = File.GetCreationTime(strFile).ToShortDateString Then
        '            If File.Exists(strFile) Then File.Delete(strFile)
        '        End If
        '    Next

        'End If


        'oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(Convert.ToInt32(oNotaCredito.REVALE)).PadLeft(10, "0") & ".bmp"

        'If File.Exists(oDPVale.I_RUTA) Then
        oDPVale.I_RUTA = "X"
        'End If

        '----------------------------------------------------------------------------------------
        ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
        '----------------------------------------------------------------------------------------
        'oDPVale = ofrmPago.oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

        '----------------------------------------------------------------------------------------
        ' JNAVA (15.07.2016): Valida DPVale
        '----------------------------------------------------------------------------------------
        Dim FirmaDistribuidor As Image
        Dim NombreDistribuidor As String = String.Empty
        If oConfigCierreFI.AplicarS2Credit Then
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
        Else
            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
        End If
        '----------------------------------------------------------------------------------------

        'oConURed.Desconecta()
        'oConURed.Desconecta()

        oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(Convert.ToInt32(oNotaCredito.REVALE)).PadLeft(10, "0") & ".bmp"

        Dim oRow As DataRow
        oRow = oDPVale.InfoDPVALE.Rows(0)
        Dim DpvaleInfo As DevolucionDPValeInfo
        DpvaleInfo.DPValeOrigen = oRow("Orige")
        DpvaleInfo.FechaExpedicion = Now
        DpvaleInfo.FechaEntregado = Now
        DpvaleInfo.FacturaId = 0
        DpvaleInfo.MontoDPValeUtilizado = 0
        DpvaleInfo.MontoDPValeP = 0
        DpvaleInfo.DPValeID = Convert.ToInt32(oNotaCredito.REVALE)
        DpvaleInfo.AsociadoID = oRow("KUNNR")
        DpvaleInfo.ClienteAsociadoID = oRow("CODCT")

        'ofrmPago.owsDPValeInfo.DPValeOrigen = oRow("Orige")
        ofrmPago.owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
        ofrmPago.owsDPValeInfo.FechaEntregado = Now.ToShortDateString
        ofrmPago.owsDPValeInfo.FacturaID = 0
        ofrmPago.owsDPValeInfo.MontoUtilizado = 0
        ofrmPago.owsDPValeInfo.MontoDPValeP = 0
        ofrmPago.vSobrante = oDistribucionNC.TotalDPVale
        ofrmPago.owsDPValeInfo.DPValeID = Convert.ToInt32(oNotaCredito.REVALE)
        ofrmPago.owsDPValeInfo.AsociadoID = oRow("KUNNR")
        ofrmPago.owsDPValeInfo.ClienteAsociadoID = oRow("CODCT")

        ofrmPago.PrintRevale(DpvaleInfo, NombreDistribuidor, FirmaDistribuidor)
        ofrmPago.Dispose()
        ofrmPago = Nothing

        'End If
    End Sub
    Private Function GetPeriodo() As Integer
        Try

            Dim oPeriodoDetalle As New PeriodoDetalleManager(oAppContext)
            Return oPeriodoDetalle.SelectPeriodoActual(oNotaCredito.Fecha)

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Private Function GetPlaza() As String
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Return oAlmacen.PlazaID
            End If
        End If

    End Function

    Private Sub UpdateMovimientosEstadoCuentaAsociado(ByVal oNotaCredito As NotaCredito)

        'Dim owsEstadoCuentaAsociado As New wsEstadoCuentaAsociado.EstadodeCuentaAsociado
        'Dim oMovimientoInfo As New wsEstadoCuentaAsociado.MovimientosInfo
        Dim oAsociadoMgr As New AsociadosManager(oAppContext)
        Dim oAsociado As Asociado
        'Dim owsDPVale As New wsControlDPVales.ControlDPVales
        'Dim owsDPValeInfo As wsControlDPVales.DPValeInfo
        'Referencia = GetPeriodo()

        'Establecer Referencias.

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'owsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'owsEstadoCuentaAsociado.strURL

        End If


        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'owsDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") + "/" + _
            'owsDPVale.strURL

        End If



        'Actualizar Saldos y Movimientos

        ' With oNotaCredito

        '    oMovimientoInfo.FechaMovimiento = .Fecha
        '    oMovimientoInfo.CodigoAlmacen = .AlmacenID
        '    oMovimientoInfo.CodigoCaja = .CajaID
        '    oMovimientoInfo.FolioMovimiento = .NotaCreditoFolio
        '    oMovimientoInfo.TipoDocumento = "NC"
        '    oMovimientoInfo.Usuario = .Usuario
        '    oMovimientoInfo.StatusRegistro = True

        '    'oMovimientoInfo.Abono = .Importe

        '    oMovimientoInfo.Cargo = 0
        '    oMovimientoInfo.Año = CType(Format(.Fecha, "yyyy"), Integer)
        '    oMovimientoInfo.Mes = CType(Format(.Fecha, "MM"), Integer)


        '    ''Se agrega la Plaza y el periodo en el que se realizó la factura.
        '    oMovimientoInfo.Referencia = .Detalle.Tables("NotasCreditoDetalle").Rows(0)("FolioReferencia")
        '    'oMovimientoInfo.Referencia = 0 'Referencia
        '    oMovimientoInfo.Plaza = GetPlaza()
        '    If (oNotaCredito.TipoVentaID = "C") Then

        '        oMovimientoInfo.Abono = ebMontoCDT.Text


        '        oAsociado = oAsociadoMgr.Create
        '        oAsociadoMgr.LoadIntoByClienteID(.ClienteID, oAsociado)

        '        oMovimientoInfo.AsociadoID = oAsociado.AsociadoID

        '        owsEstadoCuentaAsociado.InsertMovimiento("C", oMovimientoInfo)

        '    ElseIf (oNotaCredito.TipoVentaID = "V") Then

        '        oMovimientoInfo.Abono = ebMontoDPVale.Text


        '        Dim dr() As DataRow = oDistribucionNC.Detalle.Tables(0).Select("DPValeID > 0")

        '        owsDPValeInfo = owsDPVale.GetDPVale(dr(0)!DPValeID)

        '        oMovimientoInfo.AsociadoID = owsDPValeInfo.AsociadoID

        '        owsEstadoCuentaAsociado.InsertMovimiento("V", oMovimientoInfo)

        '    End If

        'End With

        'oAsociado = Nothing
        'oAsociadoMgr = Nothing
        'owsDPVale = Nothing
        'owsDPValeInfo = Nothing
        'owsEstadoCuentaAsociado = Nothing
        'oMovimientoInfo = Nothing

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub FrmDistribucionNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()
        If bShow = False Then GuardarDNC()

    End Sub

    Private Sub FrmDistribucionNotaCredito_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_Finalizar()

    End Sub

    Private Sub FrmDistribucionNotaCredito_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If (bolSalir = False) Then

            MsgBox("No ha sido Guardado el Anticipo a Cliente.", MsgBoxStyle.Exclamation, "DPTienda")

            e.Cancel = True

        End If

    End Sub

    Private Sub GuardarDNC()

        Dim idValeCajaGenerate As Integer = 0
        Dim oRetail As New ProcesosRetail("/pos/ventas", "POST")

        'If (Fm_bolValidarNoAutorizacionCancelacion() = False) Then

        '    Exit Sub

        'End If

        Dim decTotalValeCaja As Decimal
        Dim decTotalCanje As Decimal
        Dim decDPvale As Decimal

        oDistribucionNCMgr.CapturarNoCancelacion(oDistribucionNC.Detalle)

        'Variables Saldar
        decTarjetaCredito += CDec(Me.ebMontoTarjetaCredito.Text & "0")
        Me.decFonacot = CDec(ebMontoFonacot.Text.Trim & "0") + CDec(ebMontoFacilito.Text.Trim & "0")
        'Fin Variables Saldar

        'Mostrar Vale de Caja :
        decTotalValeCaja = CDec(ebMontoAnticipoCliente.Text) + _
                            CDec(ebMontoFonacot.Text & "0") + _
                            CDec(ebMontoFacilito.Text & "0") + _
                            CDec(ebMontoCDT.Text & "0")

        decDPvale = CDec(ebMontoDPVale.Text)

        decTotalValeCaja += decTarjetaCredito

        '---------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 18/09/2018: Hacemos el retorno del canje e impresión
        '---------------------------------------------------------------------------------------------------------------------------
        'decTotalCanje = CDec(Me.txtCanje.Text.Trim())

        'If decTotalCanje > 0 Then
        '    DevolverCanje(decTotalCanje)
        'End If
        If Not Factura Is Nothing Then
            If Factura.NoDPCardPuntos.Trim() <> "" Then
                If Factura.CodDPCardPunto.Trim() = "C/B" Or Factura.CodDPCardPunto.Trim() = "BON" Then
                    DevolverBonificacion(decTotalValeCaja + decDPvale)
                ElseIf Factura.CodDPCardPunto.Trim() = "CAN" Then
                    Dim PagoCanje As Decimal = CDec(Me.txtCanje.Text.Trim())
                    If PagoCanje > 0 Then
                        DevolverBonificacion(PagoCanje)
                    End If
                End If
            End If
        End If
        
        If decTotalValeCaja > 0 Then   'If CDec(ebMontoAnticipoCliente.Text) > 0 Then

            oDPVale = New cDPVale
            Dim StrFolio As String = ""
            Dim division As String = ""
            Dim strCliente As String = ""
            
            If oNotaCredito.TipoVentaID = "V" Then

                If Not oAppSAPConfig.DPValeSAP Then
                    strCliente = ""
                Else
                    Dim strFolioFactura As String = oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)
                    Dim strDpValeIDDP As String = CStr(oDistribucionNCMgr.GetDpValeIDDP(CInt(strFolioFactura)))

                    '------------------------------------------------------------------------------------------------------------------------------
                    ' MLVARGAS (11.12.2020): El valor anterior strDpValeIDDP  es el id de la forma de pago no el vale, se obtiene la referencia y de ahí el vale
                    '------------------------------------------------------------------------------------------------------------------------------
                    strDpValeIDDP = CStr(oDistribucionNCMgr.GetDpVale(CInt(strFolioFactura)))
                    If strDpValeIDDP.Trim.Length > 0 Then
                        If strDpValeIDDP.IndexOf("-") > 0 Then
                            Dim vale As String = strDpValeIDDP.Substring(strDpValeIDDP.IndexOf("-") + 1)
                            strDpValeIDDP = vale
                        End If
                    End If


                    Me.oDPVale.INUMVA = strDpValeIDDP
                    Me.oDPVale.I_RUTA = "X"
                    'oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                    '-------------------------------------------------------------------------------------------------
                    ' JNAVA (14.07.2016): Valida DPVale en S2Credit si esta activo como validador 
                    '-------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then
                        oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
                    Else
                        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If

                    strCliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")
                End If



                division = oDistribucionNCMgr.DivisionSel
                strCliente = strCliente.PadLeft(10, "0")
                oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                'StrFolio = oSAPMgr.GenerarValeCajaDPVL(strCliente, CStr(decTotalValeCaja), division, oAppContext.ApplicationConfiguration.Almacen, oNotaCredito.SALESDOCUMENT, MotivoPedido)
                'StrFolio = oRetail.ZGenerarValeCaja(strCliente, CStr(decTotalValeCaja), division, oAppContext.ApplicationConfiguration.Almacen, oNotaCredito.SALESDOCUMENT, MotivoPedido)
            End If


            Dim frmValeCaja As New FrmValeCaja
            Dim oValeCaja As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
            Dim oCliente As ClienteAlterno
            Dim oCatalogoClientesMgr As New ClientesManager(oAppContext)

            oCliente = oCatalogoClientesMgr.CreateAlterno
            If (oNotaCredito.TipoVentaID <> "P" And oNotaCredito.TipoVentaID <> "E") Then
                oCatalogoClientesMgr.Load(oNotaCredito.ClienteID, oCliente, oNotaCredito.TipoVentaID)
            End If


            oValeCaja = oValeCajaMgr.Create

            With oValeCaja

                '.ValeCajaID = 0

                .Fecha = oNotaCredito.Fecha
                'VALE CAJA
                .Importe = decTotalValeCaja '- Me.decFonacot    '.Importe = ebMontoAnticipoCliente.Text

                .TipoDocumento = "NC"

                '--------------------------------------------------------------------------------------------
                ' JNAVA (14.03.2017): Validamos si tiene entrega de SH para guardarla en el Vale de Caja
                '--------------------------------------------------------------------------------------------
                If oNotaCredito.FolioSAP.Trim() = String.Empty Then
                    .FolioDocumento = oNotaCredito.SALESDOCUMENT
                Else
                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (29.03.2017): seteamos el DOCFI de la factura Original
                    '--------------------------------------------------------------------------------------------
                    Dim oFacturaMgr As New FacturaManager(oAppContext)
                    Dim oFactura As Factura = oFacturaMgr.Create
                    oFactura.ClearFields()
                    oFacturaMgr.LoadInto(CInt(oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)), oFactura)

                    .FolioDocumento = oNotaCredito.SALESDOCUMENT
                    '--------------------------------------------------------------------------------------------
                End If
                '--------------------------------------------------------------------------------------------

                '.FolioDocumento = oNotaCredito.NotaCreditoFolio

                .DocumentoID = oNotaCredito.ID

                .DocumentoImporte = oNotaCredito.Importe

                .CodCliente = oNotaCredito.ClienteID


                If oNotaCredito.TipoVentaID = "P" OrElse oNotaCredito.TipoVentaID = "E" Then
                    .Nombre = "PÚBLICO GENERAL"

                Else
                    '--------------------------------------------------------------------------------------------------------
                    ' JNAVA (16.02.2017): Si es empresa, mostramos correctamente el nombre correctamente de la empresa
                    '--------------------------------------------------------------------------------------------------------
                    If oCliente.EsEmpresa Then
                        .Nombre = CStr(oCliente.Nombre & " " & oCliente.ApellidoPaterno).TrimEnd
                    Else
                        .Nombre = oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno & " " & oCliente.Nombre
                    End If
                    '--------------------------------------------------------------------------------------------------------
                End If

                .DevEfectivo = False

                .Motivo = String.Empty

                .StastusRegistro = True

                .DistribucionDetalle = oDistribucionNC.Detalle

            End With

            'Variables Saldar
            frmValeCaja.MontoTarjetaCredito = Me.decTarjetaCredito
            frmValeCaja.MontoFonacot = Me.decFonacot
            'Fin Variables Saldar

            frmValeCaja.ValeCaja = oValeCaja
            frmValeCaja.NotaCredito = oNotaCredito
            frmValeCaja.FacturasPorLiquidar = boFacturasPorLiquidar
            frmValeCaja.bShow = bShow

            ' AF (14-11-2016): Notas de credito masivas
            'frmValeCaja.Desatendido = True
            ' AF (14-11-2016): Notas de credito masivas

            If boFacturasPorLiquidar = True Then
                frmValeCaja.ShowDev()
            Else
                frmValeCaja.ShowDialog()
            End If

            idValeCajaGenerate = frmValeCaja.intValeCajaID

            If StrFolio.Trim <> "" Then
                'Insertamos en la tabla de vale de caja DPVL
                oDistribucionNCMgr.InsertaValeCajaDPVL(idValeCajaGenerate, StrFolio)
            End If

            frmValeCaja = Nothing
            oValeCaja = Nothing
            oValeCajaMgr = Nothing
            oCliente = Nothing
            oCatalogoClientesMgr = Nothing

        End If

        'Actualizar Movimientos y Saldos de Asociados. 
        If (oNotaCredito.TipoVentaID = "V") Then

            'Solamente se usara con la version vieja de DPVale
            If Not oAppSAPConfig.DPValeSAP Then

                UpdateMovimientosEstadoCuentaAsociado(oNotaCredito)

            End If

        End If

        ''-----------------------------------------------------
        '' JNAVA (13.04.2016): Valida/Busca cliente en S2Credit
        ''-----------------------------------------------------
        'GeneraRevaleS2Credit()
        ''-----------------------------------------------------

        'Facturar DPVale Charles DPValeID :
        If CDec(ebMontoDPVale.Text) > 0 Then
            If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                If oNotaCredito.TipoVentaID = "V" AndAlso Not Desatendido Then  ' AF (14-11-2016): Notas de credito masivas
                    MessageBox.Show("Poner Hoja para imprimir comprobante de devolucion de Dpvale", "Imprimir combrobante NC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim oARReporte As New ActRptDevolucionNC53(oNotaCredito)
                    oARReporte.Document.Name = "Nota de Credito"
                    oARReporte.DataSource = oNotaCredito.Detalle.Tables(0)
                    oARReporte.Run()
                    oARReporte.Document.Print(False, False)
                End If
            End If

            ' AF (14-11-2016): Notas de credito masivas
            If Not Desatendido Then
                FacturarDevolucionDPVale()
            End If
            ' AF (14-11-2016): Notas de credito masivas

        End If
        '********

        ''''''Abono Credito Directo por Devolucion
        'Ahora se manda llamar desde NC
        'If boFacturasPorLiquidar = True Then

        '    ''Segun Paolini no tiene que hacer esto con mandar a la SD17 queda ya
        '    Dim ofrmAbonoCeditoDirecto As New frmAbonoCreditoDirectoTienda
        '    Dim dsDevoluciones As New DataSet
        '    dsDevoluciones = oDistribucionNC.Detalle.Clone()
        '    Dim oNotasCreditoMgr As New NotasCreditoManager(oAppContext)

        '    For Each row As DataRow In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows
        '        If row("MontoCanceladoCDT") > 0 Then
        '            dsDevoluciones.Tables("AnticiposClientesDetalle").ImportRow(row)
        '        End If
        '    Next

        '    If MsgBox("¿Aplicar abono automaticamente?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
        '        'ofrmAbonoCeditoDirecto.ShowDev(oNotasCreditoMgr.GetIDAsociado(oDistribucionNC.ClienteID), _
        '        '                dsDevoluciones, idValeCajaGenerate, True)

        '        ofrmAbonoCeditoDirecto.ShowDev(oDistribucionNC.ClienteID, _
        '                        dsDevoluciones, idValeCajaGenerate, True)

        '    Else
        '        'ofrmAbonoCeditoDirecto.ShowDev(oNotasCreditoMgr.GetIDAsociado(oDistribucionNC.ClienteID), _
        '        '                                dsDevoluciones, idValeCajaGenerate)

        '        ofrmAbonoCeditoDirecto.ShowDev(oDistribucionNC.ClienteID, dsDevoluciones, idValeCajaGenerate)
        '    End If

        'End If
        ''''
        bolSalir = True

        Me.Close()

    End Sub

    Private Sub uibtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uIBtnAceptar.Click

        Try
            GuardarDNC()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar la distribución de nota de crédito")
            MessageBox.Show("Ocurrió un error al guardar la Distribución de Nota de Crédito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub FrmDistribucionNotaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

#End Region

#Region "S2Credit"

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016): Valida/Busca Vale en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscarValeS2Credit(ByVal NumVale As String)
    '    If oConfigCierreFI.AplicaS2Credit Then
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
    '' JNAVA (11.04..2016): Valida/Busca cliente en S2Credit
    ''-----------------------------------------------------
    'Private Sub GeneraRevaleS2Credit()

    '    If Me.oNotaCredito.TipoVentaID = "V" Then

    '        If oConfigCierreFI.AplicaS2Credit Then
    '            Try

    '                Dim strCliente As String
    '                Dim strNombreCliente As String

    '                '-----------------------------------------------------
    '                ' Revisamos si hay pago con DPVale
    '                '-----------------------------------------------------
    '                If CDec(ebMontoDPVale.Text) <= 0 Then
    '                    Exit Sub
    '                End If

    '                '----------------------------------------------------------------------------------------------------
    '                ' JNAVA (03.02.2016): Cargamos el ID del DPVale
    '                '----------------------------------------------------------------------------------------------------
    '                Dim strFolioFactura As String = String.Empty
    '                Dim strDpValeIDDP As String = String.Empty

    '                strFolioFactura = oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)
    '                strDpValeIDDP = CStr(oDistribucionNCMgr.GetDpValeIDDP(CInt(strFolioFactura)))

    '                '----------------------------------------------------------------------------------------------------
    '                ' JNAVA (03.02.2016): Cargamos info del vale para sacar el cliente
    '                '----------------------------------------------------------------------------------------------------
    '                Me.oDPVale = New cDPVale
    '                Me.oDPVale.INUMVA = strDpValeIDDP
    '                Me.oDPVale.I_RUTA = "X"
    '                oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    '                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
    '                strCliente = CStr(oDPVale.InfoDPVALE.Rows(0).Item("CODCT")).PadRight(10, " ")

    '                '----------------------------------------------------------------------------------------------------
    '                ' JNAVA (03.02.2016): Sacamos nombre de cliente en SAP
    '                '----------------------------------------------------------------------------------------------------
    '                Dim oClienteSAP As New ClientesSAP
    '                oClienteSAP = GetClienteDPVale(strCliente)
    '                strNombreCliente = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos
    '                oClienteSAP = Nothing
    '                '----------------------------------------------------------------------------------------------------

    '                'Dim oResults As List(Of Dictionary(Of String, Object)) = oClienteResS2C("results")
    '                If Not strDpValeIDDP Is String.Empty And Not strNombreCliente Is String.Empty Then

    '                    '-----------------------------------------------------
    '                    ' Validamos al cliente
    '                    '-----------------------------------------------------
    '                    BuscaClienteS2Credit(strNombreCliente)
    '                    If Not oClienteResS2C Is Nothing AndAlso oClienteResS2C.Count > 0 Then
    '                        strCliente = oClienteResS2C.Item(0)("id") 'oClienteResS2C.results(0).id
    '                    Else
    '                        strCliente = "0"
    '                    End If

    '                    '-----------------------------------------------------
    '                    ' Generamos Revale a partir del Vale Original
    '                    '-----------------------------------------------------
    '                    Me.oReValeS2C = Nothing
    '                    Me.oReValeS2C = oS2Credit.NewCoupon(strDpValeIDDP, strCliente, CDec(ebMontoDPVale.Text))

    '                End If

    '            Catch ex As Exception
    '                'Throw ex
    '                EscribeLog(ex.ToString, "ERROR GENERAR REVALE S2CREDIT")
    '            End Try
    '        End If

    '    End If

    'End Sub

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016):  Valida/Busca cliente en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscaClienteS2Credit(ByVal NombreCliente As String)
    '    If oConfigCierreFI.AplicaS2Credit Then
    '        Try
    '            Me.oClienteResS2C = Nothing
    '            Me.oClienteResS2C = oS2Credit.SearchCustomers(NombreCliente)
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    'End Sub

#End Region

#Region "DesAtendido"
    ''' <summary>
    ''' AF (14-11-2016): Función para ejecutar la forma en modo desatendido (sin interacción alguna por parte del usuario)
    ''' Función ejecutada desde la pantalla de carga de notas de credito masivo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ProcesaDistribucion(ByVal GenerarRevale As Boolean) As String
        Dim resultado As String = String.Empty

        Try
            Desatendido = True
            Me.GenerarRevale = GenerarRevale
            Sm_Inicializar()
            GuardarDNC()
            If GenerarRevale Then
                FacturarDevolucionDPValeAutomatico()
            End If

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar la distribución de nota de crédito")
            resultado = "Error al guardar la distribución de nota de crédito " & ex.ToString()
        End Try
        Return resultado
    End Function

    Private Sub FacturarDevolucionDPValeAutomatico()

        Dim i As Integer = 0
        Dim oRow As DataRow
        Dim idDpvale As Integer = 0

        idDpvale = oDistribucionNC.Detalle.Tables(0).Rows(0)("DPvaleID")

        If idDpvale > 0 Then

            If oAppSAPConfig.DPValeSAP Then
                oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim oDPVale As New cDPVale
                oDPVale.INUMVA = idDpvale
                oDPVale.I_RUTA = "X"
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                Dim eRen As DataRow
                If oDPVale.EEXIST = "S" Then
                    '--------------------------------
                    eRen = oDPVale.InfoDPVALE.Rows(0)
                    '--------------------------------
                Else
                    Throw New Exception("El DPortenis Vale no existe")
                End If
            End If

            If idDpvale <> 0 Then

                'Objeto Factura
                Dim oFacturaMgr As New FacturaManager(oAppContext)
                Dim oFactura As Factura = oFacturaMgr.Create
                oFactura.ClearFields()
                Dim factid As Integer = oDistribucionNCMgr.GetFacturaByNCID(oNotaCredito.ID)

                If Not oAppSAPConfig.DPValeSAP Then
                    oFacturaMgr.LoadInto(factid, oFactura)
                End If
                'MARCAMOS LA DEVOLUCION


                If Not oAppSAPConfig.DPValeSAP Then
                    'Restamos al Monto DPVale utilizado
                    'Actualizamos DPVale
                    owsDPValeInfo.MontoUtilizado = owsDPValeInfo.MontoUtilizado - oDistribucionNC.TotalDPVale
                    If owsDPValeInfo.MontoUtilizado <= 0 Then
                        owsDPValeInfo.StatusRegistro = False
                    End If
                Else
                    ''
                    Dim strResult As String = String.Empty
                    oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

                    oNotaCredito.REVALE = oSAPMgr.ZBAPI_GENERAR_REVALE(idDpvale, oDistribucionNC.TotalDPVale, strResult)
                    If strResult = "S" Then
                        Exit Sub
                    Else
                        If strResult = "N" Then
                            Throw New Exception("No se podra Facturar, el REVALE no se genero en SAP, por que no existe Vale Origen")
                        Else
                            If strResult = "E" Then
                                Throw New Exception("No se podra Facturar, el REVALE no se genero en SAP ")
                            Else
                                Throw New Exception("No se podra Facturar, el REVALE no se genero en SAP ")
                            End If
                        End If
                    End If

                End If

            Else
                Throw New Exception("El Folio del DPVale No Existe. ")
            End If

        End If

    End Sub

#End Region

#Region "Mejoras Lealtad"


    '---------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 25/11/2019: Obtener el cliente y el saldo en puntos
    '---------------------------------------------------------------------------------------------------------------------------
    Public Sub GetBalanceDPCard(ByVal factura As Factura)
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        Dim Provider As Integer


        Try
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
            '----------------------------------------------------------------------------------------------------------------------
            If factura.NoDPCardPuntos.Trim().Length = 16 Then
                Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                    Provider = Proveedor.KARUM
                Else
                    Provider = Proveedor.BLUE
                End If
                CardId = factura.NoDPCardPuntos.Trim()
            Else
                Provider = Proveedor.KARUM
                CardId = factura.NoDPCardPuntos.Trim()
                'Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            params("cardId") = CardId
            'params("cardId") = Me.txtCardID.Text.Trim()
            params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            params("ticketid") = ""
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
            '----------------------------------------------------------------------------------------------------------------------
            If Provider = Proveedor.BLUE Then
                params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                params("referenceId3") = ""
                params("referenceId4") = ""
                params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
            Else
                params("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                params("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("tipo") = "01"
            End If

            params("supervisorCode") = String.Empty 'CStr(Me.Params("SupervisorCode"))
            params("supervisorName") = String.Empty 'CStr(Me.Params("SupervisorName"))
            params("sellerCode") = String.Empty 'CStr(Me.Params("SellerCode"))
            params("sellerName") = String.Empty 'CStr(Me.Params("SellerName"))
            resultado = ws.GetBalance(params)

            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultId") = True Then
                    If CInt(resultado("ResultId")) > 0 Then

                        '-----------------------------------------------------------------------------
                        'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                        '-----------------------------------------------------------------------------
                        CustomerName = CStr(resultado("CustomerName"))

                        '-----------------------------------------------------------------------------
                        'JNAVA (17.11.2016): Validamos el proveedor para obtener los puntos
                        '-----------------------------------------------------------------------------
                        If Provider = Proveedor.KARUM Then
                            '-----------------------------------------------------------------------------
                            '  Validamos si los puntos y el saldo son numerico o no
                            '-----------------------------------------------------------------------------
                            If IsNumeric(resultado("SaldoPuntos").ToString.Trim) Then
                                SaldoPuntos = CDec(resultado("SaldoPuntos")).ToString()
                            Else
                                SaldoPuntos = 0
                            End If

                        Else
                            SaldoPuntos = CDec(resultado("BalancePoints")).ToString()
                            'Me.txtSaldo.Text = Format(CDec(resultado("BalanceAmount")), "c")
                        End If
                        '-----------------------------------------------------------------------------
                    Else
                        MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al obtener el saldo de puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub




    Private Sub DevolverCanje(ByVal MontoCanje As Decimal, Optional ByRef impDev As Decimal = 0)
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim resultado As New Hashtable
        Dim params As New Hashtable
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
        oVendedoresMgr.LoadInto(oNotaCredito.PlayerID, oVendedor)
        Dim Provider As Integer
        Dim CardId As String = ""
        Dim formasPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
        Dim dsFormasPago As DataSet
        If Factura.PedidoID = 0 Then
            dsFormasPago = formasPago.Load(Factura.FacturaID)
        Else
            dsFormasPago = formasPago.LoadByPedidoID(Factura.PedidoID)
        End If
        If Factura.NoDPCardPuntos.Trim().Length = 16 Then
            Dim bin As Integer = CInt(Factura.NoDPCardPuntos.Trim().Substring(0, 6))
            If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                Provider = Proveedor.KARUM
            Else
                Provider = Proveedor.BLUE
            End If
            CardId = Factura.NoDPCardPuntos
        Else
            Provider = Proveedor.KARUM
            CardId = Factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
            'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
        End If
        params("CardId") = CardId
        'params("CardId") = factura.NoDPCardPuntos
        params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
        params("Amount") = MontoCanje
        params("TotalAmount") = MontoCanje
        params("ticketid") = Factura.Referencia
        If Provider = Proveedor.BLUE Then
            params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
        Else
            params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            params("tipo") = "01"
        End If

        Select Case Factura.CodTipoVenta.Trim()
            Case "V"
                params("ReferenceId3") = "CFDPV"
            Case "D"
                params("ReferenceId3") = "DPC"
            Case Else
                params("ReferenceId3") = "CF"
        End Select
        If Provider = Proveedor.KARUM Then
            params("ReferenceId3") = "CAN"
            params("ReferenceId4") = CStr(MontoCanje) & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
            'params("ReferenceId4") = ebSubTotal.Text.Trim() & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
            params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
        Else
            params("ReferenceId4") = ""
            params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
            params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
        End If
        params("SupervisorCode") = oNotaCredito.PlayerID
        params("SupervisorName") = oVendedor.Nombre
        params("SellerCode") = oVendedor.ID
        params("SellerName") = oVendedor.Nombre
        Dim product As String = ""
        Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0
        For Each row As DataRow In oNotaCredito.Detalle.Tables(0).Rows
            total = 0
            unitPrice = 0
            cantidad = 0
            articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
            cantidad = Math.Round(CDec(row("Cantidad")), 2)
            total = row("Importe")
            unitPrice = total / cantidad
            If Provider = Proveedor.BLUE Then
                product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
            Else
                product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
            End If
        Next
        params("Products") = product.Remove(product.Length - 1, 1)
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (17.09.2015): Se ejecuta la Transaccion ReturnByMoneyRegister que quita los puntos asignados a la tarjeta por la compra original
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'resultado = ws.ReturnRegister(params)
        resultado = ws.ReturnByMoneyRegister(params)
        'If Provider = Proveedor.KARUM Then
        '    ActualizarConsecutivoPuntosPOS()
        'End If
        If resultado.Count > 0 Then
            If resultado.ContainsKey("ResultID") = True Then
                If CInt(resultado("ResultID")) >= 0 Then
                    PrintHashtable(resultado)

                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'MLVARGAS (26.11.2019): Buscar el nombre del cliente en el servicio GetBalance
                    '-----------------------------------------------------------------------------------------------------------------------------------------

                    'Obtener el Saldo y el Cliente
                    GetBalanceDPCard(Factura)
                    resultado("CustomerName") = CustomerName
                    resultado("TotalPoints") = SaldoPuntos
                    resultado("MontoBonificacion") = MontoCanje

                    If Provider = Proveedor.BLUE Then
                        Dim imp As Decimal = CDec(resultado("TotalPointsInCash"))
                        If imp < 0 Then
                            impDev = imp
                        End If
                    Else
                        resultado("TipoReporte") = "DEV"
                        resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                        resultado("CardId") = CardId
                        resultado("CodVendedor") = oNotaCredito.PlayerID
                        resultado("Monto") = CDec(params("Amount")) * -1
                        resultado("tipo") = "01"

                        '-----------------------------------------------------------
                        'FLIZARRAGA 30/10/2017: Consecutivo POS
                        '-----------------------------------------------------------
                        resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                        PrintTicketDevolucionPuntos(resultado)
                    End If
                Else
                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub DevolverBonificacion(ByVal MontoBonificacion As Decimal, Optional ByRef impDev As Decimal = 0)
        If oConfigCierreFI.DPCardPuntos = True Then
            If Factura.NoDPCardPuntos <> "" Then
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
                Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create
                Dim Provider As Integer
                Dim CardId As String = ""
                Dim tipo_ As String = String.Empty
                If Factura.NoDPCardPuntos.Trim().Length = 16 Then
                    If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                        Dim bin As Integer = CInt(Factura.NoDPCardPuntos.Trim().Substring(0, 6))
                        If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                            Provider = Proveedor.KARUM
                        Else
                            Provider = Proveedor.BLUE
                        End If
                    Else
                        tipo_ = consulta_bin_tipo_blue(Factura.NoDPCardPuntos.Trim())
                    End If
                    
                    CardId = Factura.NoDPCardPuntos
                Else
                    Provider = Proveedor.KARUM
                    CardId = Factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
                    'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
                End If
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(oNotaCredito.PlayerID.Trim(), oVendedor)
                Dim formasPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
                Dim dsFormasPago As DataSet
                If Factura.PedidoID = 0 Then
                    dsFormasPago = formasPago.Load(Factura.FacturaID)
                Else
                    dsFormasPago = formasPago.LoadByPedidoID(Factura.PedidoID)
                End If
                Dim rows() As DataRow = dsFormasPago.Tables(0).Select("CodFormasPago='DPPT'")
                'If Provider = Proveedor.BLUE AndAlso factura.CodDPCardPunto = "CAN" Then
                'ASANCHEZ solamente entrara cuando este activo el servicio de karum si no no entrara
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    If Provider = Proveedor.BLUE Then
                        Exit Sub
                    End If
                    Dim ws As New WSBroker("WS_BLUE", True)
                    Dim resultado As New Hashtable
                    Dim params As New Hashtable
                    params("CardId") = CardId
                    'params("CardId") = factura.NoDPCardPuntos
                    params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("Amount") = MontoBonificacion
                    params("TotalAmount") = MontoBonificacion
                    params("ticketid") = Factura.FolioSAP
                    '-----------------------------------------------------------------------------
                    'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                    '-----------------------------------------------------------------------------
                    If Provider = Proveedor.BLUE Then
                        params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    Else
                        params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        params("tipo") = "01"
                    End If
                    'params("StoreId") = "004"
                    '-----------------------------------------------------------------------------
                    Select Case oNotaCredito.TipoVentaID
                        Case "V"
                            params("ReferenceId3") = "CFDPV"
                        Case "D"
                            params("ReferenceId3") = "DPC"
                        Case Else
                            params("ReferenceId3") = "CF"
                    End Select
                    If Provider = Proveedor.KARUM Then
                        params("ReferenceId3") = "BON"
                        params("ReferenceId4") = MontoBonificacion & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                        'params("ReferenceId4") = ebSubTotal.Text.Trim() & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    Else
                        params("ReferenceId4") = ""
                        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    End If

                    params("SupervisorCode") = oNotaCredito.PlayerID.Trim()
                    params("SupervisorName") = oVendedor.Nombre
                    params("SellerCode") = oNotaCredito.PlayerID.Trim()
                    params("SellerName") = oVendedor.Nombre
                    Dim product As String = ""
                    Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                    Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                    Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                    Dim cantidad As Decimal = 0
                    For Each row As DataRow In oNotaCredito.Detalle.Tables(0).Rows
                        total = 0
                        unitPrice = 0
                        cantidad = 0
                        articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                        cantidad = Math.Round(CDec(row("Cantidad")), 2)
                        total = row("Importe")
                        unitPrice = row("PrecioUnit")
                        'unitPrice = total / cantidad
                        If Provider = Proveedor.BLUE Then
                            product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                        Else
                            product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                        End If

                    Next
                    params("Products") = product.Remove(product.Length - 1, 1)
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (17.09.2015): Se ejecuta la Transaccion ReturnByMoneyRegister que quita los puntos asignados a la tarjeta por la compra original
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    'resultado = ws.ReturnRegister(params)
                    resultado = ws.ReturnByMoneyRegister(params)
                    'If Provider = Proveedor.KARUM Then
                    '    ActualizarConsecutivoPuntosPOS()
                    'End If
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) >= 0 Then
                                PrintHashtable(resultado)

                                'Obtener el Saldo y el Cliente
                                GetBalanceDPCard(Factura)
                                resultado("CustomerName") = CustomerName
                                resultado("TotalPoints") = SaldoPuntos
                                resultado("MontoBonificacion") = MontoBonificacion

                                If Provider = Proveedor.BLUE Then
                                    Dim imp As Decimal = CDec(resultado("TotalPointsInCash"))
                                    If imp < 0 Then
                                        impDev = imp
                                    End If
                                Else
                                    Dim values() As String = CStr(params("ReferenceId4")).Split("-")
                                    resultado("CardId") = Factura.NoDPCardPuntos.Trim()
                                    resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                                    resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                                    '-----------------------------------------------------------
                                    'FLIZARRAGA 30/10/2017: Consecutivo POS
                                    '-----------------------------------------------------------
                                    resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                                    resultado("TipoReporte") = "DEVBON"
                                    resultado("Monto") = CDec(params("Amount")) * -1
                                    resultado("tipo") = "01"
                                    PrintReportPuntos(resultado)
                                End If
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If

                
            End If
        End If
    End Sub

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/12/2016: Impresión de la devolución del Canje
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintTicketDevolucionPuntos(ByVal Datos As Hashtable)
        Dim rptActivaciondpCard As New rptDPCardPuntosKarum(Datos)
        With rptActivaciondpCard
            .Document.Name = "Devolucion ClubDP Lealtad"
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

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/09/2018: Impresión de la devolución del Canje
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintReportPuntos(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptDPCardPuntosKarum(datos)
        With rptActivaciondpCard
            .Document.Name = "Devolucion DPCard Puntos"
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

#End Region

End Class
