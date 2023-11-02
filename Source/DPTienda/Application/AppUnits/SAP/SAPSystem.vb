Imports System.IO
Imports SAPFunctionsOCX
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports System.Reflection
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class SAPSystem

    Inherits System.Windows.Forms.Form

    Dim oFacturasMgr As FacturaManager

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturasMgr = New FacturaManager(oAppContext, oConfigCierreFI)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSave As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebLanguage As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUser As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClient As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSystem As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebGroupName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebApplicationServer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nebTicket As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebPlaza As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ChkBxDPValeSAP As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTdaNueva As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrestamos As System.Windows.Forms.CheckBox
    Friend WithEvents chkeHub As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiTabPage3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnProbarDPV As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ebLanguageDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPasswordDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUserDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClientDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSystemDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebGroupNameDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebServerDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebTimeout As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiTabPage4 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents EbSAPCAR As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents LblPuerto As System.Windows.Forms.Label
    Friend WithEvents LblServidorCAR As System.Windows.Forms.Label
    Friend WithEvents nebPuertoCAR As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebServidorCAR As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents chkSiHay As System.Windows.Forms.CheckBox
    Friend WithEvents chkDevoluciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkInventario As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ebClienteCAR As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ebPwdCAR As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuarioCAR As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebIdCanal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents ebVersionCAR As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebReemplazar As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblReemplazar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents ebBuscar As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAPSystem))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTimeout = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnProbar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ebLanguage = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebUser = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebClient = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSystem = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebGroupName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebApplicationServer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New Janus.Windows.EditControls.UIButton()
        Me.btnSave = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabPage3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnProbarDPV = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ebLanguageDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPasswordDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebUserDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebClientDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSystemDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebGroupNameDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebServerDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ChckBxTdaNueva = New System.Windows.Forms.CheckBox()
        Me.chkeHub = New System.Windows.Forms.CheckBox()
        Me.nebTicket = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.chkPrestamos = New System.Windows.Forms.CheckBox()
        Me.ChkBxDPValeSAP = New System.Windows.Forms.CheckBox()
        Me.ebPlaza = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.UiTabPage4 = New Janus.Windows.UI.Tab.UITabPage()
        Me.EbSAPCAR = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.chkSiHay = New System.Windows.Forms.CheckBox()
        Me.chkDevoluciones = New System.Windows.Forms.CheckBox()
        Me.chkInventario = New System.Windows.Forms.CheckBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ebVersionCAR = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebIdCanal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ebPwdCAR = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebUsuarioCAR = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebClienteCAR = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nebPuertoCAR = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebServidorCAR = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.LblPuerto = New System.Windows.Forms.Label()
        Me.LblServidorCAR = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebBuscar = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblReemplazar = New System.Windows.Forms.Label()
        Me.ebReemplazar = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        Me.UiTabPage3.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.UiTabPage4.SuspendLayout()
        CType(Me.EbSAPCAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EbSAPCAR.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebTimeout)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.btnProbar)
        Me.ExplorerBar1.Controls.Add(Me.PictureBox1)
        Me.ExplorerBar1.Controls.Add(Me.ebLanguage)
        Me.ExplorerBar1.Controls.Add(Me.ebPassword)
        Me.ExplorerBar1.Controls.Add(Me.ebUser)
        Me.ExplorerBar1.Controls.Add(Me.ebClient)
        Me.ExplorerBar1.Controls.Add(Me.ebSystem)
        Me.ExplorerBar1.Controls.Add(Me.ebGroupName)
        Me.ExplorerBar1.Controls.Add(Me.ebApplicationServer)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(398, 346)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTimeout
        '
        Me.ebTimeout.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTimeout.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTimeout.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebTimeout.Location = New System.Drawing.Point(224, 258)
        Me.ebTimeout.Name = "ebTimeout"
        Me.ebTimeout.Size = New System.Drawing.Size(56, 20)
        Me.ebTimeout.TabIndex = 22
        Me.ebTimeout.Text = "900000"
        Me.ebTimeout.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTimeout.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebTimeout.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(120, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Time Out"
        '
        'btnProbar
        '
        Me.btnProbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbar.Location = New System.Drawing.Point(23, 95)
        Me.btnProbar.Name = "btnProbar"
        Me.btnProbar.Size = New System.Drawing.Size(80, 32)
        Me.btnProbar.TabIndex = 18
        Me.btnProbar.Text = "&Probar"
        Me.btnProbar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(39, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'ebLanguage
        '
        Me.ebLanguage.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLanguage.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLanguage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLanguage.Location = New System.Drawing.Point(224, 224)
        Me.ebLanguage.MaxLength = 2
        Me.ebLanguage.Name = "ebLanguage"
        Me.ebLanguage.Size = New System.Drawing.Size(32, 20)
        Me.ebLanguage.TabIndex = 9
        Me.ebLanguage.Text = "ES"
        Me.ebLanguage.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'ebPassword
        '
        Me.ebPassword.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassword.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassword.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(224, 192)
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassword.Size = New System.Drawing.Size(144, 20)
        Me.ebPassword.TabIndex = 8
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebUser
        '
        Me.ebUser.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUser.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUser.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUser.Location = New System.Drawing.Point(224, 160)
        Me.ebUser.Name = "ebUser"
        Me.ebUser.Size = New System.Drawing.Size(144, 20)
        Me.ebUser.TabIndex = 7
        Me.ebUser.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebClient
        '
        Me.ebClient.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClient.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClient.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClient.Location = New System.Drawing.Point(224, 128)
        Me.ebClient.Name = "ebClient"
        Me.ebClient.Size = New System.Drawing.Size(56, 20)
        Me.ebClient.TabIndex = 6
        Me.ebClient.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebSystem
        '
        Me.ebSystem.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSystem.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSystem.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSystem.Location = New System.Drawing.Point(224, 96)
        Me.ebSystem.Name = "ebSystem"
        Me.ebSystem.Size = New System.Drawing.Size(56, 20)
        Me.ebSystem.TabIndex = 5
        Me.ebSystem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebGroupName
        '
        Me.ebGroupName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebGroupName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebGroupName.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebGroupName.Location = New System.Drawing.Point(224, 64)
        Me.ebGroupName.MaxLength = 20
        Me.ebGroupName.Name = "ebGroupName"
        Me.ebGroupName.Size = New System.Drawing.Size(144, 20)
        Me.ebGroupName.TabIndex = 4
        Me.ebGroupName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebApplicationServer
        '
        Me.ebApplicationServer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApplicationServer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApplicationServer.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApplicationServer.Location = New System.Drawing.Point(224, 32)
        Me.ebApplicationServer.MaxLength = 20
        Me.ebApplicationServer.Name = "ebApplicationServer"
        Me.ebApplicationServer.Size = New System.Drawing.Size(144, 20)
        Me.ebApplicationServer.TabIndex = 3
        Me.ebApplicationServer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(120, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Language"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(120, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Password"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(120, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "User"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(120, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Client"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(120, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 23)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "System"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(120, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Group Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(120, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Application Server"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(250, 374)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Salir"
        Me.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(25, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 32)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiTab1
        '
        Me.UiTab1.FirstTabOffset = 3
        Me.UiTab1.Location = New System.Drawing.Point(0, 0)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(400, 368)
        Me.UiTab1.TabIndex = 1
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage3, Me.UiTabPage2, Me.UiTabPage4})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar1)
        Me.UiTabPage1.Key = "tbConfiguracionSAP"
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(398, 346)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Configuración SAP"
        '
        'UiTabPage3
        '
        Me.UiTabPage3.Controls.Add(Me.ExplorerBar4)
        Me.UiTabPage3.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage3.Name = "UiTabPage3"
        Me.UiTabPage3.Size = New System.Drawing.Size(398, 346)
        Me.UiTabPage3.TabStop = True
        Me.UiTabPage3.Text = "DPVale AFS"
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.Controls.Add(Me.btnProbarDPV)
        Me.ExplorerBar4.Controls.Add(Me.PictureBox2)
        Me.ExplorerBar4.Controls.Add(Me.ebLanguageDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebPasswordDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebUserDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebClientDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebSystemDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebGroupNameDPVale)
        Me.ExplorerBar4.Controls.Add(Me.ebServerDPVale)
        Me.ExplorerBar4.Controls.Add(Me.Label10)
        Me.ExplorerBar4.Controls.Add(Me.Label11)
        Me.ExplorerBar4.Controls.Add(Me.Label12)
        Me.ExplorerBar4.Controls.Add(Me.Label13)
        Me.ExplorerBar4.Controls.Add(Me.Label14)
        Me.ExplorerBar4.Controls.Add(Me.Label15)
        Me.ExplorerBar4.Controls.Add(Me.Label16)
        Me.ExplorerBar4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(398, 346)
        Me.ExplorerBar4.TabIndex = 1
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnProbarDPV
        '
        Me.btnProbarDPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarDPV.Location = New System.Drawing.Point(23, 95)
        Me.btnProbarDPV.Name = "btnProbarDPV"
        Me.btnProbarDPV.Size = New System.Drawing.Size(80, 32)
        Me.btnProbarDPV.TabIndex = 18
        Me.btnProbarDPV.Text = "&Probar"
        Me.btnProbarDPV.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(39, 39)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'ebLanguageDPVale
        '
        Me.ebLanguageDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLanguageDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLanguageDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLanguageDPVale.Location = New System.Drawing.Point(224, 224)
        Me.ebLanguageDPVale.MaxLength = 2
        Me.ebLanguageDPVale.Name = "ebLanguageDPVale"
        Me.ebLanguageDPVale.Size = New System.Drawing.Size(32, 20)
        Me.ebLanguageDPVale.TabIndex = 9
        Me.ebLanguageDPVale.Text = "ES"
        Me.ebLanguageDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'ebPasswordDPVale
        '
        Me.ebPasswordDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordDPVale.Location = New System.Drawing.Point(224, 192)
        Me.ebPasswordDPVale.Name = "ebPasswordDPVale"
        Me.ebPasswordDPVale.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPasswordDPVale.Size = New System.Drawing.Size(144, 20)
        Me.ebPasswordDPVale.TabIndex = 8
        Me.ebPasswordDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebUserDPVale
        '
        Me.ebUserDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserDPVale.Location = New System.Drawing.Point(224, 160)
        Me.ebUserDPVale.Name = "ebUserDPVale"
        Me.ebUserDPVale.Size = New System.Drawing.Size(144, 20)
        Me.ebUserDPVale.TabIndex = 7
        Me.ebUserDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebClientDPVale
        '
        Me.ebClientDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClientDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClientDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClientDPVale.Location = New System.Drawing.Point(224, 128)
        Me.ebClientDPVale.Name = "ebClientDPVale"
        Me.ebClientDPVale.Size = New System.Drawing.Size(56, 20)
        Me.ebClientDPVale.TabIndex = 6
        Me.ebClientDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebSystemDPVale
        '
        Me.ebSystemDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSystemDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSystemDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSystemDPVale.Location = New System.Drawing.Point(224, 96)
        Me.ebSystemDPVale.Name = "ebSystemDPVale"
        Me.ebSystemDPVale.Size = New System.Drawing.Size(56, 20)
        Me.ebSystemDPVale.TabIndex = 5
        Me.ebSystemDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebGroupNameDPVale
        '
        Me.ebGroupNameDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebGroupNameDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebGroupNameDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebGroupNameDPVale.Location = New System.Drawing.Point(224, 64)
        Me.ebGroupNameDPVale.MaxLength = 20
        Me.ebGroupNameDPVale.Name = "ebGroupNameDPVale"
        Me.ebGroupNameDPVale.Size = New System.Drawing.Size(144, 20)
        Me.ebGroupNameDPVale.TabIndex = 4
        Me.ebGroupNameDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebServerDPVale
        '
        Me.ebServerDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServerDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServerDPVale.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServerDPVale.Location = New System.Drawing.Point(224, 32)
        Me.ebServerDPVale.MaxLength = 20
        Me.ebServerDPVale.Name = "ebServerDPVale"
        Me.ebServerDPVale.Size = New System.Drawing.Size(144, 20)
        Me.ebServerDPVale.TabIndex = 3
        Me.ebServerDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(120, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 23)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Language"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(120, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 23)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Password"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(120, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 23)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "User"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(120, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 23)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Client"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(120, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 23)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "System"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(120, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 23)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Group Name"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(120, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 23)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Application Server"
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.ExplorerBar3)
        Me.UiTabPage2.Key = "tbOtrasConfiguraciones"
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(398, 346)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "Otras Configuraciones"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.Controls.Add(Me.UiGroupBox2)
        Me.ExplorerBar3.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(398, 346)
        Me.ExplorerBar3.TabIndex = 0
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.ChckBxTdaNueva)
        Me.UiGroupBox2.Controls.Add(Me.chkeHub)
        Me.UiGroupBox2.Controls.Add(Me.nebTicket)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Location = New System.Drawing.Point(16, 24)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(368, 120)
        Me.UiGroupBox2.TabIndex = 38
        Me.UiGroupBox2.Text = "Dportenis Pro"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'ChckBxTdaNueva
        '
        Me.ChckBxTdaNueva.BackColor = System.Drawing.Color.Transparent
        Me.ChckBxTdaNueva.Location = New System.Drawing.Point(16, 80)
        Me.ChckBxTdaNueva.Name = "ChckBxTdaNueva"
        Me.ChckBxTdaNueva.Size = New System.Drawing.Size(104, 24)
        Me.ChckBxTdaNueva.TabIndex = 31
        Me.ChckBxTdaNueva.Text = "Tienda Nueva"
        Me.ChckBxTdaNueva.UseVisualStyleBackColor = False
        '
        'chkeHub
        '
        Me.chkeHub.BackColor = System.Drawing.Color.Transparent
        Me.chkeHub.Location = New System.Drawing.Point(16, 56)
        Me.chkeHub.Name = "chkeHub"
        Me.chkeHub.Size = New System.Drawing.Size(56, 24)
        Me.chkeHub.TabIndex = 36
        Me.chkeHub.Text = "eHub"
        Me.chkeHub.UseVisualStyleBackColor = False
        '
        'nebTicket
        '
        Me.nebTicket.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTicket.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTicket.Location = New System.Drawing.Point(144, 32)
        Me.nebTicket.Name = "nebTicket"
        Me.nebTicket.Size = New System.Drawing.Size(72, 20)
        Me.nebTicket.TabIndex = 3
        Me.nebTicket.Text = "10"
        Me.nebTicket.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebTicket.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebTicket.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(16, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 23)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Ticket Tarjeta Crédito"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.chkPrestamos)
        Me.UiGroupBox1.Controls.Add(Me.ChkBxDPValeSAP)
        Me.UiGroupBox1.Controls.Add(Me.ebPlaza)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 168)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(368, 136)
        Me.UiGroupBox1.TabIndex = 37
        Me.UiGroupBox1.Text = "DPortenis Vale"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'chkPrestamos
        '
        Me.chkPrestamos.BackColor = System.Drawing.Color.Transparent
        Me.chkPrestamos.Location = New System.Drawing.Point(56, 96)
        Me.chkPrestamos.Name = "chkPrestamos"
        Me.chkPrestamos.Size = New System.Drawing.Size(112, 24)
        Me.chkPrestamos.TabIndex = 35
        Me.chkPrestamos.Text = "Prestamos DPVL"
        Me.chkPrestamos.UseVisualStyleBackColor = False
        '
        'ChkBxDPValeSAP
        '
        Me.ChkBxDPValeSAP.BackColor = System.Drawing.Color.Transparent
        Me.ChkBxDPValeSAP.Location = New System.Drawing.Point(56, 64)
        Me.ChkBxDPValeSAP.Name = "ChkBxDPValeSAP"
        Me.ChkBxDPValeSAP.Size = New System.Drawing.Size(112, 24)
        Me.ChkBxDPValeSAP.TabIndex = 32
        Me.ChkBxDPValeSAP.Text = "DPVale SAP"
        Me.ChkBxDPValeSAP.UseVisualStyleBackColor = False
        '
        'ebPlaza
        '
        Me.ebPlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlaza.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlaza.Location = New System.Drawing.Point(56, 32)
        Me.ebPlaza.MaxLength = 3
        Me.ebPlaza.Name = "ebPlaza"
        Me.ebPlaza.Size = New System.Drawing.Size(72, 20)
        Me.ebPlaza.TabIndex = 33
        Me.ebPlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(16, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 23)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Plaza"
        '
        'UiTabPage4
        '
        Me.UiTabPage4.Controls.Add(Me.EbSAPCAR)
        Me.UiTabPage4.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage4.Name = "UiTabPage4"
        Me.UiTabPage4.Size = New System.Drawing.Size(398, 346)
        Me.UiTabPage4.TabStop = True
        Me.UiTabPage4.Text = "SAP CAR"
        '
        'EbSAPCAR
        '
        Me.EbSAPCAR.Controls.Add(Me.UiGroupBox5)
        Me.EbSAPCAR.Controls.Add(Me.UiGroupBox4)
        Me.EbSAPCAR.Controls.Add(Me.UiGroupBox3)
        Me.EbSAPCAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EbSAPCAR.Location = New System.Drawing.Point(0, 0)
        Me.EbSAPCAR.Name = "EbSAPCAR"
        Me.EbSAPCAR.Size = New System.Drawing.Size(398, 346)
        Me.EbSAPCAR.TabIndex = 1
        Me.EbSAPCAR.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox4.Controls.Add(Me.chkSiHay)
        Me.UiGroupBox4.Controls.Add(Me.chkDevoluciones)
        Me.UiGroupBox4.Controls.Add(Me.chkInventario)
        Me.UiGroupBox4.Location = New System.Drawing.Point(11, 212)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(133, 120)
        Me.UiGroupBox4.TabIndex = 68
        Me.UiGroupBox4.Text = "Aplicar en"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'chkSiHay
        '
        Me.chkSiHay.AutoSize = True
        Me.chkSiHay.BackColor = System.Drawing.Color.Transparent
        Me.chkSiHay.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSiHay.Location = New System.Drawing.Point(13, 82)
        Me.chkSiHay.Name = "chkSiHay"
        Me.chkSiHay.Size = New System.Drawing.Size(59, 20)
        Me.chkSiHay.TabIndex = 71
        Me.chkSiHay.Text = "Si Hay"
        Me.chkSiHay.UseVisualStyleBackColor = False
        '
        'chkDevoluciones
        '
        Me.chkDevoluciones.AutoSize = True
        Me.chkDevoluciones.BackColor = System.Drawing.Color.Transparent
        Me.chkDevoluciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDevoluciones.Location = New System.Drawing.Point(13, 54)
        Me.chkDevoluciones.Name = "chkDevoluciones"
        Me.chkDevoluciones.Size = New System.Drawing.Size(91, 20)
        Me.chkDevoluciones.TabIndex = 69
        Me.chkDevoluciones.Text = "Devoluciones"
        Me.chkDevoluciones.UseVisualStyleBackColor = False
        '
        'chkInventario
        '
        Me.chkInventario.AutoSize = True
        Me.chkInventario.BackColor = System.Drawing.Color.Transparent
        Me.chkInventario.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInventario.Location = New System.Drawing.Point(13, 28)
        Me.chkInventario.Name = "chkInventario"
        Me.chkInventario.Size = New System.Drawing.Size(74, 20)
        Me.chkInventario.TabIndex = 68
        Me.chkInventario.Text = "Inventario"
        Me.chkInventario.UseVisualStyleBackColor = False
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.lblVersion)
        Me.UiGroupBox3.Controls.Add(Me.ebVersionCAR)
        Me.UiGroupBox3.Controls.Add(Me.ebIdCanal)
        Me.UiGroupBox3.Controls.Add(Me.Label21)
        Me.UiGroupBox3.Controls.Add(Me.Label20)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.ebPwdCAR)
        Me.UiGroupBox3.Controls.Add(Me.ebUsuarioCAR)
        Me.UiGroupBox3.Controls.Add(Me.Label18)
        Me.UiGroupBox3.Controls.Add(Me.ebClienteCAR)
        Me.UiGroupBox3.Controls.Add(Me.nebPuertoCAR)
        Me.UiGroupBox3.Controls.Add(Me.ebServidorCAR)
        Me.UiGroupBox3.Controls.Add(Me.LblPuerto)
        Me.UiGroupBox3.Controls.Add(Me.LblServidorCAR)
        Me.UiGroupBox3.Location = New System.Drawing.Point(13, 20)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(368, 177)
        Me.UiGroupBox3.TabIndex = 63
        Me.UiGroupBox3.Text = "Configuración CAR"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Location = New System.Drawing.Point(225, 145)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(51, 23)
        Me.lblVersion.TabIndex = 137
        Me.lblVersion.Text = "Versión"
        '
        'ebVersionCAR
        '
        Me.ebVersionCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebVersionCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebVersionCAR.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebVersionCAR.Location = New System.Drawing.Point(282, 145)
        Me.ebVersionCAR.Name = "ebVersionCAR"
        Me.ebVersionCAR.Size = New System.Drawing.Size(74, 20)
        Me.ebVersionCAR.TabIndex = 136
        Me.ebVersionCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebIdCanal
        '
        Me.ebIdCanal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebIdCanal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebIdCanal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebIdCanal.Location = New System.Drawing.Point(106, 143)
        Me.ebIdCanal.Name = "ebIdCanal"
        Me.ebIdCanal.Size = New System.Drawing.Size(74, 20)
        Me.ebIdCanal.TabIndex = 135
        Me.ebIdCanal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(16, 145)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 21)
        Me.Label21.TabIndex = 134
        Me.Label21.Text = "Id Canal"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(16, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 23)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "Contraseña"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(16, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 23)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "Usuario"
        '
        'ebPwdCAR
        '
        Me.ebPwdCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPwdCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPwdCAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPwdCAR.Location = New System.Drawing.Point(106, 85)
        Me.ebPwdCAR.MaxLength = 0
        Me.ebPwdCAR.Name = "ebPwdCAR"
        Me.ebPwdCAR.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPwdCAR.Size = New System.Drawing.Size(134, 21)
        Me.ebPwdCAR.TabIndex = 131
        Me.ebPwdCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPwdCAR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUsuarioCAR
        '
        Me.ebUsuarioCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuarioCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuarioCAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuarioCAR.Location = New System.Drawing.Point(106, 58)
        Me.ebUsuarioCAR.MaxLength = 0
        Me.ebUsuarioCAR.Name = "ebUsuarioCAR"
        Me.ebUsuarioCAR.Size = New System.Drawing.Size(134, 21)
        Me.ebUsuarioCAR.TabIndex = 130
        Me.ebUsuarioCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuarioCAR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(225, 117)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 23)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = "Cliente"
        '
        'ebClienteCAR
        '
        Me.ebClienteCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteCAR.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteCAR.Location = New System.Drawing.Point(282, 114)
        Me.ebClienteCAR.Name = "ebClienteCAR"
        Me.ebClienteCAR.Size = New System.Drawing.Size(74, 20)
        Me.ebClienteCAR.TabIndex = 128
        Me.ebClienteCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'nebPuertoCAR
        '
        Me.nebPuertoCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPuertoCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPuertoCAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebPuertoCAR.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebPuertoCAR.Location = New System.Drawing.Point(106, 114)
        Me.nebPuertoCAR.Name = "nebPuertoCAR"
        Me.nebPuertoCAR.Size = New System.Drawing.Size(74, 21)
        Me.nebPuertoCAR.TabIndex = 127
        Me.nebPuertoCAR.Text = "0"
        Me.nebPuertoCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebPuertoCAR.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPuertoCAR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebServidorCAR
        '
        Me.ebServidorCAR.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServidorCAR.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServidorCAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServidorCAR.Location = New System.Drawing.Point(106, 30)
        Me.ebServidorCAR.MaxLength = 0
        Me.ebServidorCAR.Name = "ebServidorCAR"
        Me.ebServidorCAR.Size = New System.Drawing.Size(250, 21)
        Me.ebServidorCAR.TabIndex = 126
        Me.ebServidorCAR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorCAR.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'LblPuerto
        '
        Me.LblPuerto.BackColor = System.Drawing.Color.Transparent
        Me.LblPuerto.Location = New System.Drawing.Point(16, 117)
        Me.LblPuerto.Name = "LblPuerto"
        Me.LblPuerto.Size = New System.Drawing.Size(69, 21)
        Me.LblPuerto.TabIndex = 4
        Me.LblPuerto.Text = "Puerto"
        '
        'LblServidorCAR
        '
        Me.LblServidorCAR.BackColor = System.Drawing.Color.Transparent
        Me.LblServidorCAR.Location = New System.Drawing.Point(16, 32)
        Me.LblServidorCAR.Name = "LblServidorCAR"
        Me.LblServidorCAR.Size = New System.Drawing.Size(86, 23)
        Me.LblServidorCAR.TabIndex = 1
        Me.LblServidorCAR.Text = "Servidor CAR"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.Controls.Add(Me.UiTab1)
        Me.ExplorerBar2.Controls.Add(Me.btnSave)
        Me.ExplorerBar2.Controls.Add(Me.btnCancel)
        Me.ExplorerBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(394, 416)
        Me.ExplorerBar2.TabIndex = 2
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox5.Controls.Add(Me.ebReemplazar)
        Me.UiGroupBox5.Controls.Add(Me.lblReemplazar)
        Me.UiGroupBox5.Controls.Add(Me.lblBuscar)
        Me.UiGroupBox5.Controls.Add(Me.ebBuscar)
        Me.UiGroupBox5.Location = New System.Drawing.Point(150, 212)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(231, 120)
        Me.UiGroupBox5.TabIndex = 70
        Me.UiGroupBox5.Text = "Reemplazar Cadena Url Imagen"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'ebBuscar
        '
        Me.ebBuscar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBuscar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBuscar.Location = New System.Drawing.Point(99, 28)
        Me.ebBuscar.MaxLength = 0
        Me.ebBuscar.Name = "ebBuscar"
        Me.ebBuscar.Size = New System.Drawing.Size(120, 21)
        Me.ebBuscar.TabIndex = 131
        Me.ebBuscar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBuscar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblBuscar
        '
        Me.lblBuscar.BackColor = System.Drawing.Color.Transparent
        Me.lblBuscar.Location = New System.Drawing.Point(6, 33)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(51, 23)
        Me.lblBuscar.TabIndex = 133
        Me.lblBuscar.Text = "Buscar"
        '
        'lblReemplazar
        '
        Me.lblReemplazar.BackColor = System.Drawing.Color.Transparent
        Me.lblReemplazar.Location = New System.Drawing.Point(6, 64)
        Me.lblReemplazar.Name = "lblReemplazar"
        Me.lblReemplazar.Size = New System.Drawing.Size(97, 23)
        Me.lblReemplazar.TabIndex = 134
        Me.lblReemplazar.Text = "Reemplazar con"
        '
        'ebReemplazar
        '
        Me.ebReemplazar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebReemplazar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebReemplazar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebReemplazar.Location = New System.Drawing.Point(99, 59)
        Me.ebReemplazar.MaxLength = 0
        Me.ebReemplazar.Name = "ebReemplazar"
        Me.ebReemplazar.Size = New System.Drawing.Size(120, 21)
        Me.ebReemplazar.TabIndex = 135
        Me.ebReemplazar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReemplazar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'SAPSystem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 416)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SAPSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración SAP"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.UiTabPage3.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        Me.ExplorerBar4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiTabPage4.ResumeLayout(False)
        CType(Me.EbSAPCAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EbSAPCAR.ResumeLayout(False)
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Methods"

    Private strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"

    Private Sub SAPSystem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If File.Exists(strConfigurationFile) Then
            ShowConfigSAP()
        End If

    End Sub

    Private Sub ShowConfigSAP()

        With oAppSAPConfig
            Me.ebApplicationServer.Text = .ApplicationServer
            Me.ebGroupName.Text = .GroupName
            Me.ebSystem.Text = .System
            Me.ebClient.Text = .Client
            Me.ebUser.Text = .User
            Me.ebPassword.Text = .Password
            Me.ebLanguage.Text = .Language
            Me.ChckBxTdaNueva.Checked = .TdaNueva
            Me.ChkBxDPValeSAP.Checked = .DPValeSAP
            Me.ebPlaza.Text = .Plaza
            Me.nebTicket.Value = .Ticket
            Me.chkPrestamos.Checked = .Prestamos
            Me.chkeHub.Checked = .eHub

            '------------------------------------------------------
            ' JNAVA (14.04.2016): Configuración para DPVale AFS
            '------------------------------------------------------
            Me.ebServerDPVale.Text = .ApplicationServerDPVale
            Me.ebGroupNameDPVale.Text = .GroupNameDPVale
            Me.ebSystemDPVale.Text = .SystemDPVale
            Me.ebClientDPVale.Text = .ClientDPVale
            Me.ebUserDPVale.Text = .UserDPVale
            Me.ebPasswordDPVale.Text = .PasswordDPVale
            Me.ebLanguageDPVale.Text = .LanguageDPVale

            '------------------------------------------------------------
            ' JNAVA (12.05.2016): Configuración para Timeout SAP
            '------------------------------------------------------------
            Me.ebTimeout.Value = .Timeout
            '------------------------------------------------------------

            '------------------------------------------------------------
            ' MLVARGAS (10.08.2021): Configuración para SAP CAR
            '------------------------------------------------------------   
            Me.ebServidorCAR.Text = .ServerCAR
            Me.nebPuertoCAR.Value = .PuertoCAR
            Me.ebClienteCAR.Text = .ClienteCAR
            Me.ebVersionCAR.Text = .VersionCAR
            Me.ebUsuarioCAR.Text = .UserCAR
            Me.ebPwdCAR.Text = .PwdCAR
            Me.ebIdCanal.Text = .IdCanalCAR
            Me.chkSiHay.Checked = .SiHay
            Me.chkInventario.Checked = .Inventario
            Me.chkDevoluciones.Checked = .Devoluciones

            '--------------------------------------------------------------
            ' MLVARGAS (22.09.2021): Configuración de la URL de la Imagen
            '--------------------------------------------------------------- 
            Me.ebBuscar.Text = .BuscarCAR
            Me.ebReemplazar.Text = .ReemplazarCAR


        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim oSApReader As New SapConfigReader(strConfigurationFile)
        Dim oSettingsSAP As New SAPApplicationConfig
        With oSettingsSAP
            .ApplicationServer = Me.ebApplicationServer.Text
            .GroupName = Me.ebGroupName.Text
            .System = Me.ebSystem.Text
            .Client = Me.ebClient.Text
            .User = Me.ebUser.Text
            .Password = Me.ebPassword.Text
            .Language = Me.ebLanguage.Text
            If Me.ChckBxTdaNueva.Checked = True Then
                .TdaNueva = True
            Else
                .TdaNueva = False
            End If
            If Me.ChkBxDPValeSAP.Checked Then
                .DPValeSAP = True
            Else
                .DPValeSAP = False
            End If

            .Plaza = Me.ebPlaza.Text

            .Ticket = Me.nebTicket.Value
            .Prestamos = Me.chkPrestamos.Checked
            .eHub = Me.chkeHub.Checked

            '------------------------------------------------------
            ' JNAVA (14.04.2016): Configuración para DPVale AFS
            '------------------------------------------------------
            .ApplicationServerDPVale = Me.ebServerDPVale.Text
            .GroupNameDPVale = Me.ebGroupNameDPVale.Text
            .SystemDPVale = Me.ebSystemDPVale.Text
            .ClientDPVale = Me.ebClientDPVale.Text
            .UserDPVale = Me.ebUserDPVale.Text
            .PasswordDPVale = Me.ebPasswordDPVale.Text
            .LanguageDPVale = Me.ebLanguageDPVale.Text

            '------------------------------------------------------
            ' JNAVA (12.05.2016): Configuración para Timeout SAP
            '------------------------------------------------------
            .Timeout = Me.ebTimeout.Value
            '------------------------------------------------------

            '------------------------------------------------------
            ' MLVARGAS (10.08.2021): Configuración para SAP CAR
            '------------------------------------------------------
            .ServerCAR = Me.ebServidorCAR.Text
            .PuertoCAR = Me.nebPuertoCAR.Value
            .ClienteCAR = Me.ebClienteCAR.Text
            .VersionCAR = Me.ebVersionCAR.Text
            .UserCAR = Me.ebUsuarioCAR.Text
            .PwdCAR = Me.ebPwdCAR.Text
            .IdCanalCAR = Me.ebIdCanal.Text
            .SiHay = Me.chkSiHay.Checked
            .Inventario = Me.chkInventario.Checked
            .Devoluciones = Me.chkDevoluciones.Checked

            '------------------------------------------------------
            ' MLVARGAS (22.09.2021): Configuración URL de la imagen
            '------------------------------------------------------
            .BuscarCAR = Me.ebBuscar.Text
            .ReemplazarCAR = Me.ebReemplazar.Text

        End With
        oSApReader.SaveSettings(oSettingsSAP)
        oSettingsSAP = Nothing
        oSApReader = Nothing

        '-----------------------------------------------------------------------------------------------------------------
        'Cargamos nuevamente en el objeto global los datos
        '-----------------------------------------------------------------------------------------------------------------
        LoadConfigSAP()
        '-----------------------------------------------------------------------------------------------------------------
        'Guardamos configuracion en el servidor
        '-----------------------------------------------------------------------------------------------------------------
        SaveConfigSAPInServer(True)
        '-----------------------------------------------------------------------------------------------------------------
        'Encriptamos la info del cml
        '-----------------------------------------------------------------------------------------------------------------
        EncriptarCML(strConfigurationFile)

        MsgBox("Se guardó configuración SAP.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAP")

    End Sub

    'Private Sub SaveConfigInServer()

    '    Try

    '        Dim Properties As PropertyInfo() = oAppSAPConfig.GetType.GetProperties
    '        Dim strError As String
    '        Dim Valor As String = ""
    '        Dim bolPass As Boolean

    '        For Each oProp As PropertyInfo In Properties
    '            strError = ""
    '            bolPass = False
    '            Valor = oProp.GetValue(oAppSAPConfig, Nothing)
    '            If oProp.Name.ToUpper.Trim = "PASSWORD" Then
    '                Valor = oSecurity.EncriptarCML(Valor)
    '                bolPass = True
    '            End If
    '            strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 2, bolPass)
    '            If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oAppSapConfig." & oProp.Name)
    '        Next

    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "Error al guardar config general in server: oAppSAPConfig")
    '    End Try

    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnProbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbar.Click

        '    Dim objR3 As New SAPFunctionsOCX.SAPFunctions

        '    With objR3.Connection
        '        .ApplicationServer = Me.ebApplicationServer.Text
        '        .GroupName = Me.ebGroupName.Text
        '        .System = Me.ebSystem.Text
        '        .Client = Me.ebClient.Text
        '        .User = Me.ebUser.Text
        '        .Password = Me.ebPassword.Text
        '        .Language = Me.ebLanguage.Text
        '        .SystemNumber = Me.ebSystem.Text
        '    End With

        '    If objR3.Connection.logon(0, True) <> True Then
        '        objR3 = Nothing
        '        MsgBox("La configuración es INCORRECTA.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "SAP")
        '        Exit Sub
        '    Else
        '        MsgBox("La configuración es CORRECTA.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "SAP")
        '    End If

        '    objR3.Connection.LogOff()

        '    objR3 = Nothing

        ProbarConexionSAP(Me.ebApplicationServer.Text, Me.ebSystem.Text, Me.ebClient.Text, Me.ebUser.Text, Me.ebPassword.Text, Me.ebLanguage.Text)

    End Sub

    Private Sub btnProbarDPV_Click(sender As System.Object, e As System.EventArgs) Handles btnProbarDPV.Click
        ProbarConexionSAP(Me.ebServerDPVale.Text, Me.ebSystemDPVale.Text, Me.ebClientDPVale.Text, Me.ebUserDPVale.Text, Me.ebPasswordDPVale.Text, Me.ebLanguageDPVale.Text)
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (30.12.2015): Se cambio a ERPConnectLIC por que el Interop.SAPFunctionsOCX no funciona (es de 32 bits)
    '--------------------------------------------------------------------------------------------------------------------------
    Private Sub ProbarConexionSAP(ByVal ApplicationServer As String, ByVal System As String, ByVal Client As String, ByVal User As String, ByVal Password As String, ByVal Language As String)

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                ApplicationServer, _
                System, _
                User, _
                Password, _
                Language, _
                Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("La configuración es INCORRECTA.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAP")
            Else
                MsgBox("La configuración es CORRECTA.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAP")
            End If

            R3.Close()

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Sub

#End Region


    Private Sub chkDevoluciones_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDevoluciones.CheckedChanged

    End Sub
End Class
