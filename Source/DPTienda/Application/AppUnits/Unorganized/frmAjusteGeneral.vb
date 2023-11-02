Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes


Public Class frmAjusteGeneral
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkObs As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebTotalCodigos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents grpGroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents ebFolioAjuste As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents gbSalida As System.Windows.Forms.GroupBox
    Friend WithEvents ebCostoS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCantidadS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTallaS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodigoS As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCostoS As System.Windows.Forms.Label
    Friend WithEvents lblCantidadS As System.Windows.Forms.Label
    Friend WithEvents lblTallaS As System.Windows.Forms.Label
    Friend WithEvents lblCodigoS As System.Windows.Forms.Label
    Friend WithEvents gbEntrada As System.Windows.Forms.GroupBox
    Friend WithEvents ebCostoE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCantidadE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTallaE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodigoE As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCostoE As System.Windows.Forms.Label
    Friend WithEvents lblCantidadE As System.Windows.Forms.Label
    Friend WithEvents lblTallaE As System.Windows.Forms.Label
    Friend WithEvents lblCodigoE As System.Windows.Forms.Label
    Friend WithEvents grdAjuste As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAjusteGeneral))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ebObservaciones = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chkObs = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ebTotalCodigos = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblLabel3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblLabel5 = New System.Windows.Forms.Label
        Me.lblLabel2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLabel4 = New System.Windows.Forms.Label
        Me.grpGroupBox3 = New System.Windows.Forms.GroupBox
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblFecha = New System.Windows.Forms.Label
        Me.ebFolioAjuste = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblLabel1 = New System.Windows.Forms.Label
        Me.gbSalida = New System.Windows.Forms.GroupBox
        Me.ebCostoS = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCantidadS = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebTallaS = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCodigoS = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblCostoS = New System.Windows.Forms.Label
        Me.lblCantidadS = New System.Windows.Forms.Label
        Me.lblTallaS = New System.Windows.Forms.Label
        Me.lblCodigoS = New System.Windows.Forms.Label
        Me.gbEntrada = New System.Windows.Forms.GroupBox
        Me.ebCostoE = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCantidadE = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebTallaE = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCodigoE = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblCostoE = New System.Windows.Forms.Label
        Me.lblCantidadE = New System.Windows.Forms.Label
        Me.lblTallaE = New System.Windows.Forms.Label
        Me.lblCodigoE = New System.Windows.Forms.Label
        Me.grdAjuste = New Janus.Windows.GridEX.GridEX
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.grpGroupBox3.SuspendLayout()
        Me.gbSalida.SuspendLayout()
        Me.gbEntrada.SuspendLayout()
        CType(Me.grdAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.Label6)
        Me.explorerBar1.Controls.Add(Me.Label7)
        Me.explorerBar1.Controls.Add(Me.ebObservaciones)
        Me.explorerBar1.Controls.Add(Me.chkObs)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Controls.Add(Me.ebTotalCodigos)
        Me.explorerBar1.Controls.Add(Me.lblLabel3)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.Label5)
        Me.explorerBar1.Controls.Add(Me.lblLabel5)
        Me.explorerBar1.Controls.Add(Me.lblLabel2)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.lblLabel4)
        Me.explorerBar1.Controls.Add(Me.grpGroupBox3)
        Me.explorerBar1.Controls.Add(Me.gbSalida)
        Me.explorerBar1.Controls.Add(Me.gbEntrada)
        Me.explorerBar1.Controls.Add(Me.grdAjuste)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(792, 512)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(176, 488)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Iniciar"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(152, 488)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 24)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "F6"
        '
        'ebObservaciones
        '
        Me.ebObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebObservaciones.Enabled = False
        Me.ebObservaciones.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebObservaciones.Location = New System.Drawing.Point(16, 413)
        Me.ebObservaciones.Multiline = True
        Me.ebObservaciones.Name = "ebObservaciones"
        Me.ebObservaciones.Size = New System.Drawing.Size(718, 60)
        Me.ebObservaciones.TabIndex = 122
        Me.ebObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkObs
        '
        Me.chkObs.BackColor = System.Drawing.Color.Transparent
        Me.chkObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkObs.Location = New System.Drawing.Point(24, 389)
        Me.chkObs.Name = "chkObs"
        Me.chkObs.Size = New System.Drawing.Size(152, 24)
        Me.chkObs.TabIndex = 121
        Me.chkObs.Text = "OBSERVACIONES"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Nuevo Ajuste"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(16, 488)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 24)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "F5"
        '
        'ebTotalCodigos
        '
        Me.ebTotalCodigos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalCodigos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalCodigos.BackColor = System.Drawing.SystemColors.Info
        Me.ebTotalCodigos.Enabled = False
        Me.ebTotalCodigos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalCodigos.Location = New System.Drawing.Point(660, 381)
        Me.ebTotalCodigos.Name = "ebTotalCodigos"
        Me.ebTotalCodigos.ReadOnly = True
        Me.ebTotalCodigos.Size = New System.Drawing.Size(75, 22)
        Me.ebTotalCodigos.TabIndex = 130
        Me.ebTotalCodigos.TabStop = False
        Me.ebTotalCodigos.Text = "0"
        Me.ebTotalCodigos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTotalCodigos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebTotalCodigos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel3.Location = New System.Drawing.Point(472, 389)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(180, 23)
        Me.lblLabel3.TabIndex = 129
        Me.lblLabel3.Text = "Total de Códigos Auditados   :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(680, 488)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Salir"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(648, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 24)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Esc"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(376, 488)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(128, 16)
        Me.lblLabel5.TabIndex = 126
        Me.lblLabel5.Text = "Guardar e Imprimir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(272, 488)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(64, 16)
        Me.lblLabel2.TabIndex = 125
        Me.lblLabel2.Text = "Guardar"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(352, 488)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 24)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "F9"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(248, 488)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 123
        Me.lblLabel4.Text = "F2"
        '
        'grpGroupBox3
        '
        Me.grpGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox3.Controls.Add(Me.ebFecha)
        Me.grpGroupBox3.Controls.Add(Me.lblFecha)
        Me.grpGroupBox3.Controls.Add(Me.ebFolioAjuste)
        Me.grpGroupBox3.Controls.Add(Me.lblLabel1)
        Me.grpGroupBox3.Location = New System.Drawing.Point(16, 29)
        Me.grpGroupBox3.Name = "grpGroupBox3"
        Me.grpGroupBox3.Size = New System.Drawing.Size(720, 48)
        Me.grpGroupBox3.TabIndex = 117
        Me.grpGroupBox3.TabStop = False
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(536, 16)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(168, 22)
        Me.ebFecha.TabIndex = 1
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(480, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(64, 24)
        Me.lblFecha.TabIndex = 11
        Me.lblFecha.Text = "Fecha   :"
        '
        'ebFolioAjuste
        '
        Me.ebFolioAjuste.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioAjuste.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioAjuste.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioAjuste.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioAjuste.Location = New System.Drawing.Point(112, 16)
        Me.ebFolioAjuste.Name = "ebFolioAjuste"
        Me.ebFolioAjuste.Size = New System.Drawing.Size(104, 22)
        Me.ebFolioAjuste.TabIndex = 0
        Me.ebFolioAjuste.Text = "0"
        Me.ebFolioAjuste.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioAjuste.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioAjuste.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(16, 18)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(104, 23)
        Me.lblLabel1.TabIndex = 9
        Me.lblLabel1.Text = "Folio de Ajuste :"
        '
        'gbSalida
        '
        Me.gbSalida.BackColor = System.Drawing.Color.Transparent
        Me.gbSalida.Controls.Add(Me.ebCostoS)
        Me.gbSalida.Controls.Add(Me.ebCantidadS)
        Me.gbSalida.Controls.Add(Me.ebTallaS)
        Me.gbSalida.Controls.Add(Me.ebCodigoS)
        Me.gbSalida.Controls.Add(Me.lblCostoS)
        Me.gbSalida.Controls.Add(Me.lblCantidadS)
        Me.gbSalida.Controls.Add(Me.lblTallaS)
        Me.gbSalida.Controls.Add(Me.lblCodigoS)
        Me.gbSalida.Enabled = False
        Me.gbSalida.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSalida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbSalida.Location = New System.Drawing.Point(368, 85)
        Me.gbSalida.Name = "gbSalida"
        Me.gbSalida.Size = New System.Drawing.Size(367, 138)
        Me.gbSalida.TabIndex = 119
        Me.gbSalida.TabStop = False
        Me.gbSalida.Text = " Ajuste de Salida"
        '
        'ebCostoS
        '
        Me.ebCostoS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCostoS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCostoS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCostoS.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebCostoS.Location = New System.Drawing.Point(89, 103)
        Me.ebCostoS.MaxLength = 10
        Me.ebCostoS.Name = "ebCostoS"
        Me.ebCostoS.ReadOnly = True
        Me.ebCostoS.Size = New System.Drawing.Size(79, 22)
        Me.ebCostoS.TabIndex = 3
        Me.ebCostoS.Text = "$0.00"
        Me.ebCostoS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCostoS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCantidadS
        '
        Me.ebCantidadS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidadS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidadS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCantidadS.Location = New System.Drawing.Point(89, 77)
        Me.ebCantidadS.MaxLength = 5
        Me.ebCantidadS.Name = "ebCantidadS"
        Me.ebCantidadS.ReadOnly = True
        Me.ebCantidadS.Size = New System.Drawing.Size(79, 22)
        Me.ebCantidadS.TabIndex = 2
        Me.ebCantidadS.Text = "0"
        Me.ebCantidadS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCantidadS.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebCantidadS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTallaS
        '
        Me.ebTallaS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaS.DecimalDigits = 1
        Me.ebTallaS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTallaS.Location = New System.Drawing.Point(89, 51)
        Me.ebTallaS.MaxLength = 5
        Me.ebTallaS.Name = "ebTallaS"
        Me.ebTallaS.Size = New System.Drawing.Size(79, 22)
        Me.ebTallaS.TabIndex = 1
        Me.ebTallaS.Text = "0.0"
        Me.ebTallaS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTallaS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoS
        '
        Me.ebCodigoS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoS.AutoSize = False
        Me.ebCodigoS.ButtonImage = CType(resources.GetObject("ebCodigoS.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoS.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodigoS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoS.Location = New System.Drawing.Point(89, 25)
        Me.ebCodigoS.MaxLength = 20
        Me.ebCodigoS.Name = "ebCodigoS"
        Me.ebCodigoS.Size = New System.Drawing.Size(240, 22)
        Me.ebCodigoS.TabIndex = 0
        Me.ebCodigoS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCostoS
        '
        Me.lblCostoS.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoS.Location = New System.Drawing.Point(17, 106)
        Me.lblCostoS.Name = "lblCostoS"
        Me.lblCostoS.Size = New System.Drawing.Size(64, 23)
        Me.lblCostoS.TabIndex = 3
        Me.lblCostoS.Text = "Costo"
        '
        'lblCantidadS
        '
        Me.lblCantidadS.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadS.Location = New System.Drawing.Point(17, 82)
        Me.lblCantidadS.Name = "lblCantidadS"
        Me.lblCantidadS.Size = New System.Drawing.Size(64, 23)
        Me.lblCantidadS.TabIndex = 2
        Me.lblCantidadS.Text = "Cantidad"
        '
        'lblTallaS
        '
        Me.lblTallaS.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTallaS.Location = New System.Drawing.Point(17, 55)
        Me.lblTallaS.Name = "lblTallaS"
        Me.lblTallaS.Size = New System.Drawing.Size(64, 23)
        Me.lblTallaS.TabIndex = 1
        Me.lblTallaS.Text = "Talla"
        '
        'lblCodigoS
        '
        Me.lblCodigoS.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoS.Location = New System.Drawing.Point(17, 28)
        Me.lblCodigoS.Name = "lblCodigoS"
        Me.lblCodigoS.Size = New System.Drawing.Size(64, 23)
        Me.lblCodigoS.TabIndex = 0
        Me.lblCodigoS.Text = "Código"
        '
        'gbEntrada
        '
        Me.gbEntrada.BackColor = System.Drawing.Color.Transparent
        Me.gbEntrada.Controls.Add(Me.ebCostoE)
        Me.gbEntrada.Controls.Add(Me.ebCantidadE)
        Me.gbEntrada.Controls.Add(Me.ebTallaE)
        Me.gbEntrada.Controls.Add(Me.ebCodigoE)
        Me.gbEntrada.Controls.Add(Me.lblCostoE)
        Me.gbEntrada.Controls.Add(Me.lblCantidadE)
        Me.gbEntrada.Controls.Add(Me.lblTallaE)
        Me.gbEntrada.Controls.Add(Me.lblCodigoE)
        Me.gbEntrada.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEntrada.Location = New System.Drawing.Point(16, 85)
        Me.gbEntrada.Name = "gbEntrada"
        Me.gbEntrada.Size = New System.Drawing.Size(350, 138)
        Me.gbEntrada.TabIndex = 118
        Me.gbEntrada.TabStop = False
        Me.gbEntrada.Text = " Ajuste de Entrada "
        '
        'ebCostoE
        '
        Me.ebCostoE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCostoE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCostoE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCostoE.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebCostoE.Location = New System.Drawing.Point(80, 103)
        Me.ebCostoE.MaxLength = 10
        Me.ebCostoE.Name = "ebCostoE"
        Me.ebCostoE.ReadOnly = True
        Me.ebCostoE.Size = New System.Drawing.Size(80, 22)
        Me.ebCostoE.TabIndex = 3
        Me.ebCostoE.Text = "$0.00"
        Me.ebCostoE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCostoE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCantidadE
        '
        Me.ebCantidadE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidadE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidadE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCantidadE.Location = New System.Drawing.Point(80, 77)
        Me.ebCantidadE.MaxLength = 5
        Me.ebCantidadE.Name = "ebCantidadE"
        Me.ebCantidadE.Size = New System.Drawing.Size(80, 22)
        Me.ebCantidadE.TabIndex = 2
        Me.ebCantidadE.Text = "0"
        Me.ebCantidadE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCantidadE.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebCantidadE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTallaE
        '
        Me.ebTallaE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaE.DecimalDigits = 1
        Me.ebTallaE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTallaE.Location = New System.Drawing.Point(80, 51)
        Me.ebTallaE.MaxLength = 5
        Me.ebTallaE.Name = "ebTallaE"
        Me.ebTallaE.Size = New System.Drawing.Size(80, 22)
        Me.ebTallaE.TabIndex = 1
        Me.ebTallaE.Text = "0.0"
        Me.ebTallaE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTallaE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoE
        '
        Me.ebCodigoE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoE.AutoSize = False
        Me.ebCodigoE.ButtonImage = CType(resources.GetObject("ebCodigoE.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoE.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodigoE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoE.Location = New System.Drawing.Point(80, 25)
        Me.ebCodigoE.MaxLength = 20
        Me.ebCodigoE.Name = "ebCodigoE"
        Me.ebCodigoE.Size = New System.Drawing.Size(240, 22)
        Me.ebCodigoE.TabIndex = 0
        Me.ebCodigoE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCostoE
        '
        Me.lblCostoE.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoE.Location = New System.Drawing.Point(8, 107)
        Me.lblCostoE.Name = "lblCostoE"
        Me.lblCostoE.Size = New System.Drawing.Size(64, 23)
        Me.lblCostoE.TabIndex = 3
        Me.lblCostoE.Text = "Costo"
        '
        'lblCantidadE
        '
        Me.lblCantidadE.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadE.Location = New System.Drawing.Point(8, 83)
        Me.lblCantidadE.Name = "lblCantidadE"
        Me.lblCantidadE.Size = New System.Drawing.Size(64, 23)
        Me.lblCantidadE.TabIndex = 2
        Me.lblCantidadE.Text = "Cantidad"
        '
        'lblTallaE
        '
        Me.lblTallaE.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTallaE.Location = New System.Drawing.Point(8, 57)
        Me.lblTallaE.Name = "lblTallaE"
        Me.lblTallaE.Size = New System.Drawing.Size(64, 23)
        Me.lblTallaE.TabIndex = 1
        Me.lblTallaE.Text = "Talla"
        '
        'lblCodigoE
        '
        Me.lblCodigoE.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoE.Location = New System.Drawing.Point(8, 28)
        Me.lblCodigoE.Name = "lblCodigoE"
        Me.lblCodigoE.Size = New System.Drawing.Size(64, 23)
        Me.lblCodigoE.TabIndex = 0
        Me.lblCodigoE.Text = "Código"
        '
        'grdAjuste
        '
        Me.grdAjuste.AllowColumnDrag = False
        Me.grdAjuste.AllowDrop = True
        GridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><AllowGroup>False</AllowGroup><Columns Collection=""t" & _
        "rue""><Column0 ID=""AE_Codigo""><Caption>Código</Caption><DataMember>AE_Codigo</Dat" & _
        "aMember><EditType>NoEdit</EditType><HeaderAlignment>Center</HeaderAlignment><Key" & _
        ">AE_Codigo</Key><Position>0</Position><Width>170</Width></Column0><Column1 ID=""A" & _
        "E_Talla""><Caption>Talla</Caption><DataMember>AE_Talla</DataMember><EditType>NoEd" & _
        "it</EditType><FormatString>n</FormatString><HeaderAlignment>Center</HeaderAlignm" & _
        "ent><Key>AE_Talla</Key><Position>1</Position><TextAlignment>Far</TextAlignment><" & _
        "Width>50</Width></Column1><Column2 ID=""AE_Cantidad""><Caption>Cantidad</Caption><" & _
        "DataMember>AE_Cantidad</DataMember><EditType>NoEdit</EditType><HeaderAlignment>C" & _
        "enter</HeaderAlignment><Key>AE_Cantidad</Key><Position>2</Position><TextAlignmen" & _
        "t>Far</TextAlignment><Width>60</Width></Column2><Column3 ID=""AE_Costo""><Caption>" & _
        "Costo</Caption><DataMember>AE_Costo</DataMember><EditType>NoEdit</EditType><Form" & _
        "atString>c</FormatString><HeaderAlignment>Center</HeaderAlignment><Key>AE_Costo<" & _
        "/Key><Position>3</Position><TextAlignment>Far</TextAlignment><Width>70</Width></" & _
        "Column3><Column4 ID=""AS_Codigo""><Caption>Código</Caption><DataMember>AS_Codigo</" & _
        "DataMember><EditType>NoEdit</EditType><HeaderAlignment>Center</HeaderAlignment><" & _
        "Key>AS_Codigo</Key><Position>4</Position><Width>170</Width></Column4><Column5 ID" & _
        "=""AS_Talla""><Caption>Talla</Caption><DataMember>AS_Talla</DataMember><EditType>N" & _
        "oEdit</EditType><FormatString>n</FormatString><HeaderAlignment>Center</HeaderAli" & _
        "gnment><Key>AS_Talla</Key><Position>5</Position><TextAlignment>Far</TextAlignmen" & _
        "t><Width>50</Width></Column5><Column6 ID=""AS_Cantidad""><Caption>Cantidad</Captio" & _
        "n><DataMember>AS_Cantidad</DataMember><DefaultGroupFormatString /><EditType>NoEd" & _
        "it</EditType><HeaderAlignment>Center</HeaderAlignment><Key>AS_Cantidad</Key><Pos" & _
        "ition>6</Position><TextAlignment>Far</TextAlignment><Width>60</Width></Column6><" & _
        "Column7 ID=""AS_Costo""><Caption>Costo</Caption><DataMember>AS_Costo</DataMember><" & _
        "EditType>NoEdit</EditType><FormatString>c</FormatString><HeaderAlignment>Center<" & _
        "/HeaderAlignment><Key>AS_Costo</Key><Position>7</Position><TextAlignment>Far</Te" & _
        "xtAlignment><Width>70</Width></Column7></Columns><GroupCondition ID="""" /></RootT" & _
        "able></GridEXLayoutData>"
        Me.grdAjuste.DesignTimeLayout = GridEXLayout1
        Me.grdAjuste.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdAjuste.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.grdAjuste.GroupByBoxVisible = False
        Me.grdAjuste.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.grdAjuste.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False
        Me.grdAjuste.Location = New System.Drawing.Point(16, 229)
        Me.grdAjuste.Name = "grdAjuste"
        Me.grdAjuste.Size = New System.Drawing.Size(720, 144)
        Me.grdAjuste.TabIndex = 120
        Me.grdAjuste.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmAjusteGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 511)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAjusteGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ajuste General"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.grpGroupBox3.ResumeLayout(False)
        Me.gbSalida.ResumeLayout(False)
        Me.gbEntrada.ResumeLayout(False)
        CType(Me.grdAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembro"

    Dim dtTallasE As New DataTable
    Dim dtTallasS As New DataTable

    Public AdministrativoID As String


#End Region

#Region "Variables Objeto"

    'Objeto Ajuste
    Dim oAjusteMGR As AjusteGeneralManager
    Dim oAjusteInfo As AjusteGeneralInfo

    'Objeto Articulo
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Objeto Cambio Talla
    Dim oCTallaMgr As CambioTallaManager

#End Region

#Region "Inicializar"

    Private Sub InitialObjects()

        oAjusteMGR = New AjusteGeneralManager(oAppContext)
        oAjusteInfo = oAjusteMGR.Create

        'Objeto Articulo
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

        'Objeto Cambio Talla
        oCTallaMgr = New CambioTallaManager(oAppContext)

    End Sub

#End Region

    Private Sub frmAjusteGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            InitialObjects()

            Nuevo()

    End Sub

    Private Sub frmAjusteGeneral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter
                SendKeys.Send("{TAB}")

            Case Keys.F2
                'Guardar
                GuardarAjuste(0)

            Case Keys.F9
                'Guardar Imprimir
                GuardarAjuste(1)

            Case Keys.F5
                Nuevo()

            Case Keys.F6

                If gbEntrada.Enabled Then
                    ebCodigoS.Text = String.Empty
                    ebTallaS.Value = 0
                    ebCantidadS.Value = 0
                    ebCostoS.Value = 0
                    ebCodigoE.Text = String.Empty
                    ebTallaE.Value = 0
                    ebCantidadE.Value = 0
                    ebCostoE.Value = 0
                    gbSalida.Enabled = False
                    ebCodigoE.Focus()
                End If

            Case Keys.Escape
                Me.Close()

        End Select

    End Sub

    Private Sub CreateStructureDetail()

        Dim oCol As DataColumn

        oAjusteInfo.Detalle.Dispose()
        oAjusteInfo.Detalle = Nothing

        oAjusteInfo.Detalle = New DataTable("Detalle")

        oCol = New DataColumn
        oCol.ColumnName = "AE_Codigo"
        oCol.DataType = System.Type.GetType("System.String")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AE_Talla"
        oCol.DataType = System.Type.GetType("System.Decimal")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AE_Cantidad"
        oCol.DataType = System.Type.GetType("System.Int32")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AE_Costo"
        oCol.DataType = System.Type.GetType("System.Decimal")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AS_Codigo"
        oCol.DataType = System.Type.GetType("System.String")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AS_Talla"
        oCol.DataType = System.Type.GetType("System.Decimal")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AS_Cantidad"
        oCol.DataType = System.Type.GetType("System.Int32")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        oCol = Nothing
        oCol = New DataColumn
        oCol.ColumnName = "AS_Costo"
        oCol.DataType = System.Type.GetType("System.Decimal")
        oAjusteInfo.Detalle.Columns.Add(oCol)

        grdAjuste.DataSource = oAjusteInfo.Detalle
        grdAjuste.Refresh()

    End Sub

    Private Sub ebCodigoE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigoE.Validating

        If ebCodigoE.Text <> String.Empty Then

            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(ebCodigoE.Text, oArticulo)

            If oArticulo.Exist Then

                ebCostoE.Value = oArticulo.CostoProm

                dtTallasE.Dispose()
                dtTallasE = Nothing
                dtTallasE = New DataTable("TallasE")

                dtTallasE = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

                If dtTallasE Is Nothing Then
                    MsgBox("Corrida del Artículo Incorrecta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                    ebCodigoE.Text = String.Empty
                    ebTallaE.Value = 0
                    ebCantidadE.Value = 0
                    ebCostoE.Value = 0
                    e.Cancel = True
                End If

            Else

                MsgBox("El Código de Artículo No Existe", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                ebCodigoE.Text = String.Empty
                ebTallaE.Value = 0
                ebCantidadE.Value = 0
                ebCostoE.Value = 0
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub ebTallaE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTallaE.Validating

        If ebCodigoE.Text <> String.Empty Then

            If ebTallaE.Value > 0 Then

                If Not TallaEsdeArticulo(ebTallaE.Value, 0) Then

                    MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                    ebTallaE.Value = 0
                    e.Cancel = True

                End If

            Else

                If ebTallaE.Value < 0 Then

                    ebTallaE.Value = 0
                    e.Cancel = True

                Else

                    If dtTallasE.Rows(0).Item("C01") <> 0 Then

                        MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                        ebTallaE.Value = 0
                        e.Cancel = True

                    End If

                End If

            End If

        End If

    End Sub

    Private Function TallaEsdeArticulo(ByVal decTalla As Decimal, ByVal Tipo As Integer) As Boolean

        Dim dRow As DataRow

        If Tipo = 0 Then
            dRow = dtTallasE.Rows(0)
        Else
            dRow = dtTallasS.Rows(0)
        End If

        If dRow!C01 = decTalla Or _
            dRow!C02 = decTalla Or _
            dRow!C03 = decTalla Or _
            dRow!C04 = decTalla Or _
            dRow!C05 = decTalla Or _
            dRow!C06 = decTalla Or _
            dRow!C07 = decTalla Or _
            dRow!C08 = decTalla Or _
            dRow!C09 = decTalla Or _
            dRow!C10 = decTalla Or _
            dRow!C11 = decTalla Or _
            dRow!C12 = decTalla Or _
            dRow!C13 = decTalla Or _
            dRow!C14 = decTalla Or _
            dRow!C15 = decTalla Or _
            dRow!C16 = decTalla Or _
            dRow!C17 = decTalla Or _
            dRow!C18 = decTalla Or _
            dRow!C19 = decTalla Or _
            dRow!C20 = decTalla Then

            Return True

        Else

            Return False

        End If

    End Function

    Private Sub ebCantidadE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCantidadE.ValueChanged

        If ebCantidadE.Value > 0 And ebCodigoE.Text <> String.Empty Then

            gbSalida.Enabled = True
            ebCantidadS.Value = ebCantidadE.Value

        Else

            gbSalida.Enabled = False

            If ebCantidadE.Value <= 0 Then
                ebCantidadE.Value = 0
                ebCantidadS.Value = 0
            End If

        End If

    End Sub

    Private Sub ebCodigoS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigoS.Validating

        If ebCodigoS.Text <> String.Empty Then

            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(ebCodigoS.Text, oArticulo)

            If oArticulo.Exist Then

                ebCostoS.Value = oArticulo.CostoProm

                dtTallasS.Dispose()
                dtTallasS = Nothing
                dtTallasS = New DataTable("TallasS")

                dtTallasS = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

                If dtTallasS Is Nothing Then
                    MsgBox("Corrida del Artículo Incorrecta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                    ebCodigoS.Text = String.Empty
                    ebTallaS.Value = 0
                    ebCantidadS.Value = 0
                    ebCostoS.Value = 0
                    e.Cancel = True
                End If

            Else

                MsgBox("El Código de Artículo No Existe", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                ebCodigoS.Text = String.Empty
                ebTallaS.Value = 0
                ebCantidadS.Value = 0
                ebCostoS.Value = 0
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub ebTallaS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTallaS.Validating

        If ebCodigoS.Text <> String.Empty Then

            If ebTallaS.Value > 0 Then

                If Not TallaEsdeArticulo(ebTallaS.Value, 1) Then

                    MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                    ebTallaS.Value = 0
                    e.Cancel = True

                Else

                    If oCTallaMgr.GetStock(oAppContext.ApplicationConfiguration.Almacen, ebCodigoS.Text, ebTallaS.Value) < ebCantidadS.Value Then

                        MsgBox("No hay existencias suficientes para dar salida a esta talla.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                        ebTallaS.Value = 0
                        e.Cancel = True

                    Else

                        AgregarAjuste()
                        chkObs.Focus()

                    End If

                End If

            Else

                If ebTallaS.Value < 0 Then

                    ebTallaS.Value = 0
                    e.Cancel = True

                Else

                    If dtTallasS.Rows(0).Item("C01") <> 0 Then

                        MsgBox("La talla no es válida para el código capturado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                        ebTallaS.Value = 0
                        e.Cancel = True

                    Else

                        If oCTallaMgr.GetStock(oAppContext.ApplicationConfiguration.Almacen, ebCodigoS.Text, ebTallaS.Value) < ebCantidadS.Value Then

                            MsgBox("No hay existencias suficientes para dar salida a esta talla.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                            ebTallaS.Value = 0
                            e.Cancel = True

                        Else

                            AgregarAjuste()

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub AgregarAjuste()

        If oAjusteInfo.Detalle.Rows.Count < oAppContext.ApplicationConfiguration.CodigosXAuditoria Then

            Dim dRow As DataRow
            dRow = oAjusteInfo.Detalle.NewRow
            dRow!AE_Codigo = ebCodigoE.Text
            dRow!AE_Talla = ebTallaE.Value
            dRow!AE_Cantidad = ebCantidadE.Value
            dRow!AE_Costo = ebCostoE.Value
            dRow!AS_Codigo = ebCodigoS.Text
            dRow!AS_Talla = ebTallaS.Value
            dRow!AS_Cantidad = ebCantidadE.Value
            dRow!AS_Costo = ebCostoS.Value
            oAjusteInfo.Detalle.Rows.Add(dRow)

            oAjusteInfo.Detalle.AcceptChanges()

            dRow = Nothing

            CalculaCostoCantidadAjuste()

            oArticulo.ClearFields()
            ebCodigoE.Text = String.Empty
            ebTallaE.Value = 0
            ebCantidadE.Value = 0
            ebCostoE.Value = 0
            ebCodigoS.Text = String.Empty
            ebTallaS.Value = 0
            ebCantidadS.Value = 0
            ebCostoS.Value = 0
            ebFecha.Text = Format(Date.Now, "short date") & " - " & Format(Date.Now, "hh:mm:ss")

        Else

            MsgBox("No puede agregar más códigos al ajuste.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

        End If

    End Sub

    Private Sub ebCodigoE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoE.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                SearchArticulo(0)

        End Select

    End Sub

    Private Sub ebCodigoE_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCodigoE.ButtonClick

        SearchArticulo(0)

    End Sub

    Private Sub ebCodigos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoS.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                SearchArticulo(1)

        End Select

    End Sub

    Private Sub ebCodigos_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCodigoS.ButtonClick

        SearchArticulo(1)

    End Sub

    Private Sub SearchArticulo(ByVal Tipo As Integer)

        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(oOpenRecordDlg.Record.Item("Código"), oArticulo)

            If oArticulo.Exist Then

                If Tipo = 0 Then    'Entrada

                    ebCodigoE.Text = oArticulo.CodArticulo
                    ebCostoE.Value = oArticulo.CostoProm

                    dtTallasE.Dispose()
                    dtTallasE = Nothing
                    dtTallasE = New DataTable("TallasE")

                    dtTallasE = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

                    If dtTallasE Is Nothing Then
                        MsgBox("Corrida del Artículo Incorrecta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                        ebCodigoE.Text = String.Empty
                        ebTallaE.Value = 0
                        ebCantidadE.Value = 0
                        ebCostoE.Value = 0
                        ebCodigoE.Focus()
                    Else
                        ebTallaE.Focus()
                    End If

                Else                'Salida

                    ebCodigoS.Text = oArticulo.CodArticulo
                    ebCostoS.Value = oArticulo.CostoProm

                    dtTallasS.Dispose()
                    dtTallasS = Nothing
                    dtTallasS = New DataTable("TallasS")

                    dtTallasS = oCTallaMgr.GetTallas(oArticulo.CodCorrida).Tables(0)

                    If dtTallasS Is Nothing Then
                        MsgBox("Corrida del Artículo Incorrecta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                        ebCodigoS.Text = String.Empty
                        ebTallaS.Value = 0
                        ebCantidadS.Value = 0
                        ebCostoS.Value = 0
                        ebCodigoS.Focus()
                    Else
                        ebTallaS.Focus()
                    End If

                End If

            Else

                MsgBox("El Código de Artículo No Existe", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

                If Tipo = 0 Then
                    ebCodigoE.Text = String.Empty
                    ebTallaE.Value = 0
                    ebCantidadE.Value = 0
                    ebCostoE.Value = 0
                    ebCodigoE.Focus()
                Else
                    ebCodigoS.Text = String.Empty
                    ebTallaS.Value = 0
                    ebCantidadS.Value = 0
                    ebCostoS.Value = 0
                    ebCodigoS.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub GuardarAjuste(ByVal Tipo As Integer)

        If oAjusteInfo.Detalle.Rows.Count > 0 Then

            If ebObservaciones.Text = String.Empty Then

                MsgBox("Ingrese las observaciones necesarias para el Ajuste.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

            Else

                If oAjusteInfo.IsNew Then

                    'GUARDAMOS AJUSTE
                    oAjusteInfo.FolioAjuste = 0
                    oAjusteInfo.FechaAjuste = Date.Now
                    oAjusteInfo.Observaciones = ebObservaciones.Text
                    oAjusteInfo.Usuario = Me.AdministrativoID
                    oAjusteMGR.Save(oAjusteInfo)

                    'GUARDAMOS MOVIMIENTO
                    oAjusteMGR.PutMovimiento(oAjusteInfo)

                    MsgBox("Ajuste General No." & Format(oAjusteInfo.FolioAjuste, "000000") & " se guardó satisfactoriamente", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

                    If Tipo = 1 Then
                        'Imprimir
                        ImprimeAjusteGeneral()
                    End If

                    Nuevo()

                Else

                    If Tipo = 1 Then
                        'Imprimir
                        ImprimeAjusteGeneral()
                    End If

                End If


            End If

        Else

            MsgBox("Debe ingresar Articulos para Guardar Ajuste.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

        End If

    End Sub

    Private Sub Nuevo()

        'Activar
        ebFolioAjuste.Enabled = True
        gbEntrada.Enabled = True
        gbSalida.Enabled = False
        chkObs.Enabled = True
        grdAjuste.Enabled = True
        ebObservaciones.Enabled = False

        ebCodigoE.Text = String.Empty
        ebTallaE.Value = 0
        ebCantidadE.Value = 0
        ebCostoE.Value = 0
        ebCodigoS.Text = String.Empty
        ebTallaS.Value = 0
        ebCantidadS.Value = 0
        ebCostoS.Value = 0
        ebTotalCodigos.Value = 0
        ebFecha.Text = Format(Date.Now, "Short date") & " - " & Format(Date.Now, "hh:mm:ss")
        ebObservaciones.Text = String.Empty
        chkObs.Checked = False

        oAjusteInfo.ClearFields()

        CreateStructureDetail()

        ebFolioAjuste.Value = oAjusteMGR.GetFolio

        oAjusteInfo.FolioAjuste = ebFolioAjuste.Value

        ebFolioAjuste.Focus()

    End Sub

    Private Sub CalculaCostoCantidadAjuste()

        Dim dRow As DataRow

        oAjusteInfo.AE_CostoTotal = 0
        oAjusteInfo.AS_CostoTotal = 0
        oAjusteInfo.TotalCodigos = 0

        For Each dRow In oAjusteInfo.Detalle.Rows

            With oAjusteInfo

                .AE_CostoTotal = .AE_CostoTotal + dRow!AE_Costo
                .AS_CostoTotal = .AS_CostoTotal + dRow!AS_Costo
                .TotalCodigos = .TotalCodigos + dRow!AE_Cantidad

            End With

        Next

        ebTotalCodigos.Value = oAjusteInfo.TotalCodigos

    End Sub

    Private Sub grdAjuste_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdAjuste.KeyDown

        Select Case e.KeyCode

            Case Keys.Delete

                If oAjusteInfo.Detalle.Rows.Count > 0 Then

                    oAjusteInfo.Detalle.Rows(grdAjuste.Row).Delete()

                    oAjusteInfo.Detalle.AcceptChanges()

                    CalculaCostoCantidadAjuste()

                End If

        End Select

    End Sub

    Private Sub ebFolioAjuste_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioAjuste.Validating

        If ebFolioAjuste.Value > 0 Then

            If ebFolioAjuste.Value > oAjusteInfo.FolioAjuste Then
                MsgBox("Folio de Ajuste No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")
                e.Cancel = True
            Else
                If ebFolioAjuste.Value < oAjusteInfo.FolioAjuste Then
                    'Buscamos Ajuste
                    SearchAjuste(ebFolioAjuste.Value)
                End If
            End If

        Else

            ebFolioAjuste.Value = oAjusteMGR.GetFolio
            oAjusteInfo.FolioAjuste = ebFolioAjuste.Value
            e.Cancel = True

        End If

    End Sub

    Private Function SearchAjuste(ByVal intFolioAjuste As Integer) As Boolean

        oAjusteInfo.ClearFields()
        oAjusteMGR.LoadInto(intFolioAjuste, oAjusteInfo)

        If oAjusteInfo.FolioAjuste <> 0 Then

            With oAjusteInfo
                ebObservaciones.Text = .Observaciones
                ebFecha.Text = Format(.FechaAjuste, "Short Date") & " - " & Format(.FechaAjuste, "hh:mm:ss")
                grdAjuste.DataSource = oAjusteInfo.Detalle
                grdAjuste.Refresh()
                'Desactivar
                CalculaCostoCantidadAjuste()
                ebFolioAjuste.Enabled = False
                gbEntrada.Enabled = False
                gbSalida.Enabled = False
                chkObs.Enabled = False
                grdAjuste.Enabled = False
                ebObservaciones.Enabled = False
            End With

        End If

    End Function

    Private Sub chkObs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkObs.CheckedChanged

        If chkObs.Checked Then
            ebObservaciones.Enabled = True
        Else
            ebObservaciones.Text = String.Empty
            ebObservaciones.Enabled = False
        End If

    End Sub

    Private Sub chkObs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkObs.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            If Not chkObs.Checked Then

                ebFolioAjuste.Focus()

            End If

        End If

    End Sub

    Private Sub ImprimeAjusteGeneral()

        Dim oARReporte As New rptAjusteGeneral(oAjusteInfo)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Ajuste General"

        oARReporte.Document.Print(False, False)
        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        MsgBox("Ajuste General Impreso satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Ajuste General")

        'oReportViewer.Dispose()
        'oReportViewer = Nothing
        'oARReporte = Nothing

    End Sub

    Private Sub ebCantidadE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCantidadE.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter
                SendKeys.Send("{TAB}")

        End Select

    End Sub

End Class

