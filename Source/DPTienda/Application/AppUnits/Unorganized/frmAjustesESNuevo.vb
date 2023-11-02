Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada

Public Class frmAjustesESNuevo
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oAjusteMgr = New AjusteGeneralManager(oAppContext)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents ebAjustes As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebNombreResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents grdProductosAJE As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdProductosAJS As Janus.Windows.GridEX.GridEX
    Friend WithEvents nbTotalArticulosAJE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents nbTotalArticulosAJS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents nbTotalAJE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbTotalAJS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents nbFolioAUT As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chkTraspasoEntrada As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbMovimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents nebFolioTEOrigen As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesESNuevo))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ebAjustes = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebFolioTEOrigen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.chkTraspasoEntrada = New Janus.Windows.EditControls.UICheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFolioAUT = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.nbTotalAJS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbTotalAJE = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.nbTotalArticulosAJS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.grdProductosAJS = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbMovimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.nbFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombreResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdProductosAJE = New Janus.Windows.GridEX.GridEX()
        Me.nbTotalArticulosAJE = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.ebAjustes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ebAjustes.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.grdProductosAJS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.grdProductosAJE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ebAjustes
        '
        Me.ebAjustes.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ebAjustes.Controls.Add(Me.nebFolioTEOrigen)
        Me.ebAjustes.Controls.Add(Me.chkTraspasoEntrada)
        Me.ebAjustes.Controls.Add(Me.Label27)
        Me.ebAjustes.Controls.Add(Me.UiGroupBox2)
        Me.ebAjustes.Controls.Add(Me.nbTotalAJS)
        Me.ebAjustes.Controls.Add(Me.nbTotalAJE)
        Me.ebAjustes.Controls.Add(Me.Label24)
        Me.ebAjustes.Controls.Add(Me.Label23)
        Me.ebAjustes.Controls.Add(Me.Label20)
        Me.ebAjustes.Controls.Add(Me.nbTotalArticulosAJS)
        Me.ebAjustes.Controls.Add(Me.grdProductosAJS)
        Me.ebAjustes.Controls.Add(Me.UiGroupBox1)
        Me.ebAjustes.Controls.Add(Me.Label18)
        Me.ebAjustes.Controls.Add(Me.Label17)
        Me.ebAjustes.Controls.Add(Me.Label16)
        Me.ebAjustes.Controls.Add(Me.Label15)
        Me.ebAjustes.Controls.Add(Me.Label14)
        Me.ebAjustes.Controls.Add(Me.Label13)
        Me.ebAjustes.Controls.Add(Me.Label12)
        Me.ebAjustes.Controls.Add(Me.Label11)
        Me.ebAjustes.Controls.Add(Me.Label10)
        Me.ebAjustes.Controls.Add(Me.Label9)
        Me.ebAjustes.Controls.Add(Me.Label8)
        Me.ebAjustes.Controls.Add(Me.Label7)
        Me.ebAjustes.Controls.Add(Me.txtObservaciones)
        Me.ebAjustes.Controls.Add(Me.Label6)
        Me.ebAjustes.Controls.Add(Me.Label5)
        Me.ebAjustes.Controls.Add(Me.grdProductosAJE)
        Me.ebAjustes.Controls.Add(Me.nbTotalArticulosAJE)
        Me.ebAjustes.Controls.Add(Me.Label21)
        Me.ebAjustes.Controls.Add(Me.Label22)
        Me.ebAjustes.Controls.Add(Me.Label2)
        Me.ebAjustes.Controls.Add(Me.Label19)
        Me.ebAjustes.Location = New System.Drawing.Point(0, 0)
        Me.ebAjustes.Name = "ebAjustes"
        Me.ebAjustes.Size = New System.Drawing.Size(704, 528)
        Me.ebAjustes.TabIndex = 0
        Me.ebAjustes.Text = "ExplorerBar1"
        Me.ebAjustes.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebFolioTEOrigen
        '
        Me.nebFolioTEOrigen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolioTEOrigen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolioTEOrigen.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebFolioTEOrigen.FormatString = "0000000000"
        Me.nebFolioTEOrigen.Location = New System.Drawing.Point(104, 456)
        Me.nebFolioTEOrigen.Name = "nebFolioTEOrigen"
        Me.nebFolioTEOrigen.Size = New System.Drawing.Size(96, 20)
        Me.nebFolioTEOrigen.TabIndex = 33
        Me.nebFolioTEOrigen.Text = "0000000000"
        Me.nebFolioTEOrigen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebFolioTEOrigen.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebFolioTEOrigen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkTraspasoEntrada
        '
        Me.chkTraspasoEntrada.BackColor = System.Drawing.Color.Transparent
        Me.chkTraspasoEntrada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTraspasoEntrada.Location = New System.Drawing.Point(8, 424)
        Me.chkTraspasoEntrada.Name = "chkTraspasoEntrada"
        Me.chkTraspasoEntrada.Size = New System.Drawing.Size(264, 16)
        Me.chkTraspasoEntrada.TabIndex = 34
        Me.chkTraspasoEntrada.Text = "Ajuste por Traspaso de Entrada"
        Me.chkTraspasoEntrada.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 456)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 13)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Folio TE Origen"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.nbFolioAUT)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Location = New System.Drawing.Point(512, 16)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(176, 80)
        Me.UiGroupBox2.TabIndex = 29
        Me.UiGroupBox2.Text = "Autorizar Ajuste"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nbFolioAUT
        '
        Me.nbFolioAUT.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolioAUT.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolioAUT.ButtonImage = CType(resources.GetObject("nbFolioAUT.ButtonImage"), System.Drawing.Image)
        Me.nbFolioAUT.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolioAUT.Location = New System.Drawing.Point(56, 32)
        Me.nbFolioAUT.Name = "nbFolioAUT"
        Me.nbFolioAUT.Size = New System.Drawing.Size(104, 22)
        Me.nbFolioAUT.TabIndex = 1
        Me.nbFolioAUT.Text = "0"
        Me.nbFolioAUT.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolioAUT.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolioAUT.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(16, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Folio.-"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nbTotalAJS
        '
        Me.nbTotalAJS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalAJS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalAJS.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalAJS.Enabled = False
        Me.nbTotalAJS.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalAJS.FormatString = "c"
        Me.nbTotalAJS.Location = New System.Drawing.Point(302, 424)
        Me.nbTotalAJS.Name = "nbTotalAJS"
        Me.nbTotalAJS.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalAJS.TabIndex = 28
        Me.nbTotalAJS.Text = "$0.00"
        Me.nbTotalAJS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalAJS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalAJE
        '
        Me.nbTotalAJE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalAJE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalAJE.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalAJE.Enabled = False
        Me.nbTotalAJE.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalAJE.FormatString = "c"
        Me.nbTotalAJE.Location = New System.Drawing.Point(293, 265)
        Me.nbTotalAJE.Name = "nbTotalAJE"
        Me.nbTotalAJE.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalAJE.TabIndex = 27
        Me.nbTotalAJE.Text = "$0.00"
        Me.nbTotalAJE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalAJE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(8, 112)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Ajuste Entrada"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(8, 272)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 13)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Ajuste Salida"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(408, 424)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(183, 13)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Total de Artículos Ajuste Salida"
        '
        'nbTotalArticulosAJS
        '
        Me.nbTotalArticulosAJS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulosAJS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulosAJS.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalArticulosAJS.Enabled = False
        Me.nbTotalArticulosAJS.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalArticulosAJS.Location = New System.Drawing.Point(600, 424)
        Me.nbTotalArticulosAJS.Name = "nbTotalArticulosAJS"
        Me.nbTotalArticulosAJS.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalArticulosAJS.TabIndex = 24
        Me.nbTotalArticulosAJS.Text = "0"
        Me.nbTotalArticulosAJS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalArticulosAJS.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalArticulosAJS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grdProductosAJS
        '
        Me.grdProductosAJS.AllowColumnDrag = False
        Me.grdProductosAJS.AlternatingColors = True
        Me.grdProductosAJS.AutomaticSort = False
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdProductosAJS.DesignTimeLayout = GridEXLayout1
        Me.grdProductosAJS.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdProductosAJS.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.grdProductosAJS.ExpandableCards = False
        Me.grdProductosAJS.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProductosAJS.GroupByBoxVisible = False
        Me.grdProductosAJS.HeaderFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdProductosAJS.HeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.ControlLight
        Me.grdProductosAJS.HeaderFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical
        Me.grdProductosAJS.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grdProductosAJS.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdProductosAJS.Location = New System.Drawing.Point(8, 288)
        Me.grdProductosAJS.Name = "grdProductosAJS"
        Me.grdProductosAJS.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdProductosAJS.Size = New System.Drawing.Size(688, 136)
        Me.grdProductosAJS.TabIndex = 22
        Me.grdProductosAJS.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdProductosAJS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.Label28)
        Me.UiGroupBox1.Controls.Add(Me.cmbMotivo)
        Me.UiGroupBox1.Controls.Add(Me.Label25)
        Me.UiGroupBox1.Controls.Add(Me.cmbMovimiento)
        Me.UiGroupBox1.Controls.Add(Me.nbFolio)
        Me.UiGroupBox1.Controls.Add(Me.CalendarCombo1)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.ebResponsable)
        Me.UiGroupBox1.Controls.Add(Me.ebNombreResponsable)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(488, 93)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Consulta Ajuste Grabados"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(248, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "Motivo"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMotivo
        '
        Me.cmbMotivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMotivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbMotivo.DesignTimeLayout = GridEXLayout2
        Me.cmbMotivo.Location = New System.Drawing.Point(294, 47)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(184, 20)
        Me.cmbMotivo.TabIndex = 8
        Me.cmbMotivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 47)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Movimiento"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMovimiento
        '
        Me.cmbMovimiento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMovimiento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMovimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.cmbMovimiento.DesignTimeLayout = GridEXLayout3
        Me.cmbMovimiento.Location = New System.Drawing.Point(80, 47)
        Me.cmbMovimiento.Name = "cmbMovimiento"
        Me.cmbMovimiento.Size = New System.Drawing.Size(146, 20)
        Me.cmbMovimiento.TabIndex = 6
        Me.cmbMovimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMovimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFolio
        '
        Me.nbFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolio.ButtonImage = CType(resources.GetObject("nbFolio.ButtonImage"), System.Drawing.Image)
        Me.nbFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolio.Location = New System.Drawing.Point(48, 19)
        Me.nbFolio.Name = "nbFolio"
        Me.nbFolio.Size = New System.Drawing.Size(104, 22)
        Me.nbFolio.TabIndex = 1
        Me.nbFolio.Text = "0"
        Me.nbFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'CalendarCombo1
        '
        Me.CalendarCombo1.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.CalendarCombo1.Enabled = False
        Me.CalendarCombo1.Location = New System.Drawing.Point(375, 19)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.ShowDropDown = False
        Me.CalendarCombo1.Size = New System.Drawing.Size(104, 20)
        Me.CalendarCombo1.TabIndex = 5
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(288, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha Ajuste.-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio.-"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Responsable"
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsable.Enabled = False
        Me.ebResponsable.Location = New System.Drawing.Point(80, 71)
        Me.ebResponsable.MaxLength = 10
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.Size = New System.Drawing.Size(72, 20)
        Me.ebResponsable.TabIndex = 1
        Me.ebResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombreResponsable
        '
        Me.ebNombreResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebNombreResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombreResponsable.Enabled = False
        Me.ebNombreResponsable.Location = New System.Drawing.Point(159, 71)
        Me.ebNombreResponsable.MaxLength = 10
        Me.ebNombreResponsable.Name = "ebNombreResponsable"
        Me.ebNombreResponsable.Size = New System.Drawing.Size(320, 20)
        Me.ebNombreResponsable.TabIndex = 2
        Me.ebNombreResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(506, 504)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 16)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Nuevo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(490, 504)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 16)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "F4"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(578, 504)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 16)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Salir"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(554, 504)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "ESC"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(146, 504)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 16)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Borrar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(114, 504)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "SUPR"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(386, 504)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 16)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Guardar / Imprimir"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(370, 504)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 16)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "F9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(314, 504)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Grabar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(298, 504)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "F2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(230, 504)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Seleccionar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(194, 504)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Alt + S"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(302, 456)
        Me.txtObservaciones.MaxLength = 255
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(394, 40)
        Me.txtObservaciones.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(208, 456)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(401, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total de Artículos Ajuste Entrada"
        '
        'grdProductosAJE
        '
        Me.grdProductosAJE.AllowColumnDrag = False
        Me.grdProductosAJE.AlternatingColors = True
        Me.grdProductosAJE.AutomaticSort = False
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.grdProductosAJE.DesignTimeLayout = GridEXLayout4
        Me.grdProductosAJE.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdProductosAJE.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.grdProductosAJE.ExpandableCards = False
        Me.grdProductosAJE.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProductosAJE.GroupByBoxVisible = False
        Me.grdProductosAJE.HeaderFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdProductosAJE.HeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.ControlLight
        Me.grdProductosAJE.HeaderFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical
        Me.grdProductosAJE.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grdProductosAJE.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdProductosAJE.Location = New System.Drawing.Point(8, 128)
        Me.grdProductosAJE.Name = "grdProductosAJE"
        Me.grdProductosAJE.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdProductosAJE.Size = New System.Drawing.Size(688, 136)
        Me.grdProductosAJE.TabIndex = 3
        Me.grdProductosAJE.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdProductosAJE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalArticulosAJE
        '
        Me.nbTotalArticulosAJE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulosAJE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulosAJE.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalArticulosAJE.Enabled = False
        Me.nbTotalArticulosAJE.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalArticulosAJE.Location = New System.Drawing.Point(600, 265)
        Me.nbTotalArticulosAJE.Name = "nbTotalArticulosAJE"
        Me.nbTotalArticulosAJE.Size = New System.Drawing.Size(96, 20)
        Me.nbTotalArticulosAJE.TabIndex = 5
        Me.nbTotalArticulosAJE.Text = "0"
        Me.nbTotalArticulosAJE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalArticulosAJE.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalArticulosAJE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(26, 504)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 16)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "INSERT"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(66, 504)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 16)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "Agregar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(634, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Imprimir"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(618, 504)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(19, 16)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "F5"
        '
        'frmAjustesESNuevo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(696, 522)
        Me.Controls.Add(Me.ebAjustes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(712, 560)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(712, 560)
        Me.Name = "frmAjustesESNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes de Entrada - Salida"
        CType(Me.ebAjustes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ebAjustes.ResumeLayout(False)
        Me.ebAjustes.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.grdProductosAJS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.grdProductosAJE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Globales"

    Dim oAjusteMgr As AjusteGeneralManager
    Dim oAjusteAJE As AjusteGeneralInfo
    Dim oAjusteAJS As AjusteGeneralInfo
    Dim oTraspasoEntradaMgr As TraspasosEntradaManager
    Dim oTraspasoEntrada As TraspasoEntrada


    Dim dsCatalogoArticulos As DataSet
    Dim oCatalogoArticulosMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    Dim dsTallas As DataSet
    Dim oFacturaMgr As FacturaManager


    Dim bolLoadForm As Boolean
    Dim intRecordActual As Integer

    ''MgrSAP
    Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    'Datables para nuevos parametros de SAP Retail
    Dim dsMovMot As New DataSet("MovimientosMotivos")

#End Region

#Region "Propiedades"

    Private m_intAJS As Integer = 0
    Private m_intAJE As Integer = 0
    Private m_strEstado As String = String.Empty

    Private m_blReajuste As Boolean = False

    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Value As String)
            m_strEstado = Value
        End Set
    End Property

    Public Property AJS() As Integer
        Get
            Return m_intAJS
        End Get
        Set(ByVal Value As Integer)
            m_intAJS = Value
        End Set
    End Property

    Public Property AJE() As Integer
        Get
            Return m_intAJE
        End Get
        Set(ByVal Value As Integer)
            m_intAJE = Value
        End Set
    End Property

    Public Property Reajuste() As String
        Get
            Return m_blReajuste
        End Get
        Set(ByVal Value As String)
            m_blReajuste = Value
        End Set
    End Property

#End Region

#Region "Eventos Controles"

    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductosAJE.KeyDown
        Select Case e.KeyCode
            Case Keys.Insert
                Me.AgregarCodigoAJE()
            Case Keys.Delete
                Me.bolLoadForm = False
                Dim intRecord As Integer = grdProductosAJE.Row
                Me.oAjusteAJE.Detalle.Rows.RemoveAt(intRecord)
                Me.oAjusteAJE.Detalle.AcceptChanges()
                Me.bolLoadForm = True
            Case e.Alt And Keys.S

                If grdProductosAJE.Col = 0 AndAlso (IsDBNull(grdProductosAJE.GetValue(0)) OrElse CStr(grdProductosAJE.GetValue(0)) = String.Empty) Then
                    Dim strCodArticulo As String = LoadSearchArticulo()
                    If Not strCodArticulo = String.Empty Then
                        grdProductosAJE.SetValue(0, strCodArticulo)
                    End If


                End If

        End Select
    End Sub

    Private Sub grdProductosAJS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductosAJS.KeyDown
        Select Case e.KeyCode
            Case Keys.Insert
                Me.AgregarCodigoAJS()
            Case Keys.Delete
                Me.bolLoadForm = False
                Dim intRecord As Integer = grdProductosAJS.Row
                Me.oAjusteAJS.Detalle.Rows.RemoveAt(intRecord)
                Me.oAjusteAJS.Detalle.AcceptChanges()
                Me.bolLoadForm = True
            Case e.Alt And Keys.S
                If grdProductosAJS.Col = 0 AndAlso (IsDBNull(grdProductosAJS.GetValue(0)) OrElse CStr(grdProductosAJS.GetValue(0)) = String.Empty) Then
                    Dim strCodArticulo As String = LoadSearchArticulo()
                    If Not strCodArticulo = String.Empty Then
                        grdProductosAJS.SetValue(0, strCodArticulo)
                    End If
                End If
        End Select
    End Sub

    Private Sub grdProductos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductosAJE.CurrentCellChanged
        If Me.bolLoadForm = True Then
            If Not Me.intRecordActual = grdProductosAJE.Row AndAlso (Not (IsDBNull(grdProductosAJE.GetValue("Codigo")) OrElse grdProductosAJE.GetValue("Codigo") = String.Empty)) Then
                Me.intRecordActual = Me.grdProductosAJE.Row
                oArticulo = oCatalogoArticulosMgr.Create()
                oArticulo.ClearFields()
                oCatalogoArticulosMgr.LoadInto(Me.grdProductosAJE.GetValue("Codigo"), oArticulo)
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                'FillTallasArticulo(oArticulo.CodCorrida)
                Me.nbTotalArticulosAJE.Value = oAjusteAJE.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
                Me.nbTotalAJE.Value = oAjusteAJE.Detalle.Compute("sum(Total)", "Cantidad>0")
            Else
                Me.nbTotalArticulosAJE.Value = oAjusteAJE.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
                Me.nbTotalAJE.Value = oAjusteAJE.Detalle.Compute("sum(Total)", "Cantidad>0")
                Me.intRecordActual = Me.grdProductosAJE.Row
            End If
        End If
    End Sub

    Private Sub grdProductosAJS_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductosAJS.CurrentCellChanged
        If Me.bolLoadForm = True Then
            If Not Me.intRecordActual = grdProductosAJS.Row AndAlso (Not (IsDBNull(grdProductosAJS.GetValue("Codigo")) OrElse grdProductosAJS.GetValue("Codigo") = String.Empty)) Then
                Me.intRecordActual = Me.grdProductosAJS.Row
                oArticulo = oCatalogoArticulosMgr.Create()
                oArticulo.ClearFields()
                oCatalogoArticulosMgr.LoadInto(Me.grdProductosAJS.GetValue("Codigo"), oArticulo)
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                'FillTallasArticulo(oArticulo.CodCorrida)
                Me.nbTotalArticulosAJS.Value = oAjusteAJS.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
                Me.nbTotalAJS.Value = oAjusteAJS.Detalle.Compute("sum(Total)", "Cantidad>0")
            Else
                Me.nbTotalArticulosAJS.Value = oAjusteAJS.Detalle.Compute("sum(Cantidad)", "Cantidad>0")
                Me.nbTotalAJS.Value = oAjusteAJS.Detalle.Compute("sum(Total)", "Cantidad>0")
                Me.intRecordActual = Me.grdProductosAJS.Row
            End If
        End If
    End Sub

    Private Sub nbFolio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolio.KeyDown
        Dim intfolio As Integer = Me.nbFolio.Value
        If e.KeyCode = Keys.Enter Then
            If Me.nbFolio.Value > 0 Then
                InicializarObjetos()
                Dim dtAjuste As New DataTable
                dtAjuste = oAjusteMgr.AjusteESNuevoSel(intfolio, "GRA")
                If dtAjuste.Rows.Count > 0 Then
                    Me.nbFolio.Value = dtAjuste.Rows(0).Item("FolioAjuste")
                    Me.AJE = dtAjuste.Rows(0).Item("FolioAJE")
                    Me.AJS = dtAjuste.Rows(0).Item("FolioAJS")
                    Me.ebResponsable.Text = dtAjuste.Rows(0).Item("usuario")
                    Me.txtObservaciones.Text = dtAjuste.Rows(0).Item("Observaciones")
                    Me.CalendarCombo1.Value = dtAjuste.Rows(0).Item("Fecha")
                    Me.Estado = dtAjuste.Rows(0).Item("Estado")
                    AbrirAjuste()
                Else
                    Me.InicializarObjetos()
                End If

            Else
                Me.InicializarObjetos()
            End If
        End If
    End Sub

    Private Sub nbFolioAUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolioAUT.KeyDown
        Dim intfolio As Integer = Me.nbFolioAUT.Value
        If e.KeyCode = Keys.Enter Then
            If Me.nbFolioAUT.Value > 0 Then
                InicializarObjetos()
                Dim dtAjuste As New DataTable
                dtAjuste = oAjusteMgr.AjusteESNuevoSel(intfolio, "AUT")
                If dtAjuste.Rows.Count > 0 Then
                    Me.nbFolioAUT.Value = dtAjuste.Rows(0).Item("FolioAjuste")
                    Me.AJE = dtAjuste.Rows(0).Item("FolioAJE")
                    Me.AJS = dtAjuste.Rows(0).Item("FolioAJS")
                    Me.ebResponsable.Text = dtAjuste.Rows(0).Item("usuario")
                    Me.txtObservaciones.Text = dtAjuste.Rows(0).Item("Observaciones")
                    Me.CalendarCombo1.Value = dtAjuste.Rows(0).Item("Fecha")
                    Me.Estado = dtAjuste.Rows(0).Item("Estado")
                    AbrirAjuste()
                Else
                    Me.InicializarObjetos()
                End If
            Else
                Me.InicializarObjetos()
            End If
        End If
    End Sub

    Private Sub nbFolio_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbFolio.ButtonClick
        InicializarObjetos()

        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim oAjustesOpenRecordDialogView As New AjustesOpenRecordNuevoDialogView
        oAjustesOpenRecordDialogView.TipoConsulta = "GRA"
        oOpenRecordDlg.CurrentView = oAjustesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                Dim strFolio As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then
                    strFolio = oOpenRecordDlg.Record.Item("FolioAjuste")
                    Me.AJE = oOpenRecordDlg.Record.Item("FolioAJE")
                    Me.AJS = oOpenRecordDlg.Record.Item("FolioAJS")
                    Me.ebResponsable.Text = oOpenRecordDlg.Record.Item("usuario")
                    Me.txtObservaciones.Text = oOpenRecordDlg.Record.Item("Observaciones")
                    Me.CalendarCombo1.Value = oOpenRecordDlg.Record.Item("Fecha")
                    Me.Estado = oOpenRecordDlg.Record.Item("Estado")

                Else
                    strFolio = oOpenRecordDlg.pbCodigo
                End If
                Me.nbFolio.Value = strFolio
                Me.nbFolioAUT.Value = 0
                Me.AbrirAjuste()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub nbFolioAUT_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbFolioAUT.ButtonClick
        InicializarObjetos()

        Dim oOpenRecordDlg As New OpenRecordDialog

        Dim oAjustesOpenRecordDialogView As New AjustesOpenRecordNuevoDialogView
        oAjustesOpenRecordDialogView.TipoConsulta = "AUT"
        oOpenRecordDlg.CurrentView = oAjustesOpenRecordDialogView


        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                Dim strFolio As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then
                    strFolio = oOpenRecordDlg.Record.Item("FolioAjuste")
                    Me.AJE = oOpenRecordDlg.Record.Item("FolioAJE")
                    Me.AJS = oOpenRecordDlg.Record.Item("FolioAJS")
                    Me.ebResponsable.Text = oOpenRecordDlg.Record.Item("usuario")
                    Me.txtObservaciones.Text = oOpenRecordDlg.Record.Item("Observaciones")
                    Me.CalendarCombo1.Value = oOpenRecordDlg.Record.Item("Fecha")
                    Me.Estado = oOpenRecordDlg.Record.Item("Estado")

                Else
                    strFolio = oOpenRecordDlg.pbCodigo
                End If
                Me.nbFolioAUT.Value = strFolio
                Me.nbFolio.Value = 0
                Me.AbrirAjuste()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub grdProductos_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdProductosAJE.Validating
        e.Cancel = ValidaAllRecordAJE()
    End Sub

    Private Sub grdProductosAJS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdProductosAJS.Validating
        e.Cancel = ValidaAllRecordAJS()
    End Sub

    Private Sub grdProductos_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductosAJE.GotFocus
        If Me.oAjusteAJE.Detalle.Rows.Count = 0 Then
            Me.AgregarCodigoAJE()
        End If
    End Sub

    Private Sub grdProductosAJS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductosAJS.GotFocus
        If Me.oAjusteAJS.Detalle.Rows.Count = 0 Then
            Me.AgregarCodigoAJS()
        End If
    End Sub

    Private Sub frmAjustesES_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreaMovMotivosSource()
        InicializarObjetos()

    End Sub

    Private Sub frmAjustesES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                'If (grdProductosAJE.Enabled And grdProductosAJS.Enabled) OrElse Estado = "AUT" Then
                If ValidaMovES() = True OrElse Estado = "AUT" Then
                    Guardar(False)
                Else
                    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Keys.F4
                'Nuevo
                InicializarObjetos()
                Me.nbFolio.Focus()

            Case Keys.F9
                'If (grdProductosAJE.Enabled And grdProductosAJS.Enabled) Or Estado = "AUT" Then
                If ValidaMovES() = True OrElse Estado = "AUT" Then
                    Guardar(True)
                Else
                    MessageBox.Show("No se permite modificar ajustes", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Keys.Escape
                bolLoadForm = True
                Me.Close()
            Case Keys.F5
                If Not grdProductosAJE.Enabled And Not grdProductosAJS.Enabled And Estado <> "AUT" Then
                    If Me.Estado = "GRA" Then
                        If Me.oAjusteAJS.Detalle.Rows.Count > 0 Then
                            ActionPrintAjusteAJS(Me.nbFolio.Text)
                        End If
                        If Me.oAjusteAJE.Detalle.Rows.Count > 0 Then
                            ActionPrintAjusteAJE(Me.nbFolio.Text)
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub frmAjustesES_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bolLoadForm = False
    End Sub

#End Region

#Region "Procedimientos Programador"

    Private Sub CreaMovMotivosSource()

        Dim dtMov As New DataTable("Movimientos")
        Dim dtMot As New DataTable("Motivos")

        With dtMov
            .Columns.Add("CodMov", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .AcceptChanges()
        End With

        With dtMot
            .Columns.Add("CodMov", GetType(String))
            .Columns.Add("CodMot", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .AcceptChanges()
        End With

        Dim oNewRow As DataRow
        Dim i As Integer = 0, CodMov As String, Desc As String = "", CodMot As String

        For i = 0 To 10
            Select Case i
                Case 0
                    CodMov = "951"
                    Desc = "Baja por robo"
                Case 1
                    CodMov = "953"
                    Desc = "Faltante de Inventario"
                Case 2
                    CodMov = "954"
                    Desc = "Sobrantes"
                Case 3
                    CodMov = "955"
                    Desc = "Vale de empleado"
                Case 4
                    CodMov = "957"
                    Desc = "Siniestros"
                Case 5
                    CodMov = "959"
                    Desc = "Embargo SAT"
                Case 6
                    CodMov = "963"
                    Desc = "Patrocinios"
                Case 7
                    CodMov = "965"
                    Desc = "Catálogos"
                Case 8
                    CodMov = "967"
                    Desc = "Mermas"
                Case 9
                    CodMov = "969"
                    Desc = "Donaciones"
                Case 10
                    CodMov = "953954"
                    Desc = "Cambio de Modelo/Talla"
            End Select
            oNewRow = dtMov.NewRow
            With oNewRow
                !CodMov = CodMov
                !Descripcion = Desc.Trim
                dtMov.Rows.Add(oNewRow)
            End With
        Next

        For i = 0 To 14
            Select Case i
                Case 0
                    CodMov = "951"
                    CodMot = "0001"
                    Desc = "Baja por robo"
                Case 1
                    CodMov = "953"
                    CodMot = "0001"
                    Desc = "Falta Control"
                Case 2
                    CodMov = "953"
                    CodMot = "0002"
                    Desc = "Robo Hormiga"
                Case 3
                    CodMov = "953"
                    CodMot = "0003"
                    Desc = "Impares"
                Case 4
                    CodMov = "953"
                    CodMot = "0004"
                    Desc = "Robo piso de venta"
                Case 5
                    CodMov = "953"
                    CodMot = "0009"
                    Desc = "Cambio de modelo"
                Case 6
                    CodMov = "954"
                    CodMot = "0005"
                    Desc = "Falta Control"
                Case 7
                    CodMov = "955"
                    CodMot = "0001"
                    Desc = "Vale de empleado"
                Case 8
                    CodMov = "957"
                    CodMot = "0001"
                    Desc = "Siniestros"
                Case 9
                    CodMov = "959"
                    CodMot = "0001"
                    Desc = "Embargo SAT"
                Case 10
                    CodMov = "963"
                    CodMot = "0001"
                    Desc = "Patrocinios"
                Case 11
                    CodMov = "965"
                    CodMot = "0001"
                    Desc = "Catálogos"
                Case 12
                    CodMov = "967"
                    CodMot = "0001"
                    Desc = "Mermas"
                Case 13
                    CodMov = "969"
                    CodMot = "0001"
                    Desc = "Donaciones"
                Case 14
                    CodMov = "953954"
                    CodMot = "0009"
                    Desc = "Cambio de Modelo/Talla"
            End Select
            oNewRow = dtMot.NewRow
            With oNewRow
                !CodMov = CodMov
                !CodMot = CodMot
                !Descripcion = Desc.Trim
                dtMot.Rows.Add(oNewRow)
            End With
        Next

        dsMovMot.Tables.Add(dtMov)
        dsMovMot.Tables.Add(dtMot)
        dsMovMot.AcceptChanges()

    End Sub

    Private Sub FillMovimientos()

        With Me.cmbMovimiento
            .Clear()
            .Text = ""
            .Value = Nothing
            .DataSource = dsMovMot.Tables(0)
            .DisplayMember = "Descripcion"
            .ValueMember = "CodMov"
            .Refresh()
        End With

    End Sub

    Private Sub FillMotivos(ByVal CodMov As Long)

        Dim dv As New DataView(dsMovMot.Tables(1), "", "", DataViewRowState.CurrentRows)

        dv.RowFilter = "CodMov = '" & CodMov & "'"

        With Me.cmbMotivo
            .Clear()
            .Text = ""
            .Value = Nothing
            .DataSource = dv
            .DisplayMember = "Descripcion"
            .ValueMember = "CodMot"
            '.Value = ""
            .Refresh()
        End With

    End Sub

    Private Sub BloqueaGridES()

        Select Case cmbMovimiento.Value
            Case "951", "953", "955", "957", "959", "961", "963", "965", "967", "969"
                grdProductosAJE.Enabled = False
                oAjusteAJE.Detalle.Clear()
                grdProductosAJE.DataSource = oAjusteAJE.Detalle
                grdProductosAJE.Refresh()
                grdProductosAJS.Enabled = True
            Case "954"
                grdProductosAJE.Enabled = True
                oAjusteAJS.Detalle.Clear()
                grdProductosAJS.DataSource = oAjusteAJS.Detalle
                grdProductosAJS.Refresh()
                grdProductosAJS.Enabled = False
            Case "953954"
                grdProductosAJE.Enabled = True
                grdProductosAJS.Enabled = True
        End Select

    End Sub

    Private Function ValidaMovES() As Boolean

        Dim bRes As Boolean = False

        Select Case cmbMovimiento.Value
            Case "951", "953", "955", "957", "959", "961", "963", "965", "967", "969"
                If grdProductosAJE.Enabled = False AndAlso grdProductosAJS.Enabled = True Then
                    bRes = True
                End If
            Case "954"
                If grdProductosAJS.Enabled = False AndAlso grdProductosAJE.Enabled = True Then
                    bRes = True
                End If
            Case "953954"
                If grdProductosAJE.Enabled AndAlso grdProductosAJS.Enabled Then
                    bRes = True
                End If
        End Select

        Return bRes

    End Function

    Private Sub InicializarObjetos()
        bolLoadForm = False
        Reajuste = False

        Me.oAjusteAJE = oAjusteMgr.Create("E")
        Me.oAjusteAJS = oAjusteMgr.Create("S")
        oFacturaMgr = New FacturaManager(oAppContext)

        oAjusteAJE.TipoAjuste = "E"
        oAjusteAJS.TipoAjuste = "S"

        '''Obtenemos el Responsable del Movimiento. (El que se logea)
        Me.ebResponsable.Text = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
        Me.ebNombreResponsable.Text = UCase(oAppContext.Security.CurrentUser.Name)
        Me.nbFolio.Value = Me.oAjusteMgr.GetFolioESNuevo()
        Me.nbFolioAUT.Value = 0

        '''Asignamos DataSource a Grid
        oAjusteAJE.Detalle.Columns("Cantidad").DefaultValue = 0
        'oAjusteAJE.Detalle.Columns("Talla").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjusteAJE.Detalle.Columns("Total").Expression = "Cantidad * Importe"
        oAjusteAJE.Detalle.AcceptChanges()

        ''Asignamos DataSource a Grid
        oAjusteAJS.Detalle.Columns("Cantidad").DefaultValue = 0
        'oAjusteAJS.Detalle.Columns("Talla").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("Total").Expression = "Cantidad * Importe"
        oAjusteAJS.Detalle.AcceptChanges()

        grdProductosAJE.DataSource = oAjusteAJE.Detalle
        grdProductosAJS.DataSource = oAjusteAJS.Detalle

        AddHandler oAjusteAJE.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_ChangingAJE)
        AddHandler oAjusteAJS.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_ChangingAJS)

        '''Llenamos Catalogo Articulos.
        Me.oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
        dsCatalogoArticulos = Me.oCatalogoArticulosMgr.GetAll(False)
        Me.dsCatalogoArticulos.Tables(0).Columns("Código").ColumnName = "Codigo"

        grdProductosAJE.DropDowns(0).SetDataBinding(Me.dsCatalogoArticulos, Me.dsCatalogoArticulos.Tables(0).TableName)
        grdProductosAJS.DropDowns(0).SetDataBinding(Me.dsCatalogoArticulos, Me.dsCatalogoArticulos.Tables(0).TableName)

        Me.txtObservaciones.Text = String.Empty
        Me.nbTotalArticulosAJE.Value = 0
        Me.nbTotalArticulosAJS.Value = 0

        Me.nbTotalAJE.Value = 0
        Me.nbTotalAJS.Value = 0

        'Me.ebFolioSAP.Text = String.Empty

        grdProductosAJE.Enabled = True
        grdProductosAJS.Enabled = True

        Me.txtObservaciones.Enabled = True
        cmbMovimiento.Enabled = True
        cmbMotivo.Enabled = True
        bolLoadForm = True
        m_intAJS = 0
        m_intAJE = 0
        Estado = String.Empty
        '-------------------------------------------------------------------------------------------------------------
        'rgermain 08.10.2016: Llenamos los nuevos combos de movimientos y motivos para enviar valores a SAP Retail
        '-------------------------------------------------------------------------------------------------------------
        cmbMotivo.Text = ""
        cmbMovimiento.Text = ""
        FillMovimientos()
    End Sub

    Private Sub AbrirAjuste()
        Try
            If Me.AJE <> 0 Then
                oAjusteAJE.TipoAjuste = "E"
                oAjusteMgr.LoadInto(Me.AJE, Me.oAjusteAJE)
                oAjusteAJE.Detalle.Columns("Total").Expression = "Cantidad * Importe"
                oAjusteAJE.Detalle.AcceptChanges()
                If oAjusteAJE.Detalle.Rows.Count > 0 Then
                    grdProductosAJE.DataSource = oAjusteAJE.Detalle
                    If oAjusteAJE.ClaseMov <> "" Then
                        cmbMovimiento.Value = oAjusteAJE.ClaseMov
                    End If
                    cmbMotivo.Value = oAjusteAJE.Motivo
                Else
                    MessageBox.Show("No se encontró el Ajuste de Entrada con folio: " & Me.AJE, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                AddHandler oAjusteAJE.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_ChangingAJE)

                'blockControls()
            Else
                'blockControls()
            End If

            If Me.AJS <> 0 Then
                oAjusteAJS.TipoAjuste = "S"
                oAjusteMgr.LoadInto(Me.AJS, Me.oAjusteAJS)
                oAjusteAJS.Detalle.Columns("Total").Expression = "Cantidad * Importe"
                oAjusteAJS.Detalle.AcceptChanges()
                grdProductosAJS.DataSource = oAjusteAJS.Detalle
                If oAjusteAJS.Detalle.Rows.Count > 0 Then
                    If oAjusteAJE.ClaseMov <> "" Then
                        cmbMovimiento.Value = oAjusteAJS.ClaseMov
                    End If
                    cmbMotivo.Value = oAjusteAJS.Motivo
                Else
                    MessageBox.Show("No se encontró el Ajuste de Salida con folio: " & Me.AJS, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                AddHandler oAjusteAJS.Detalle.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_ChangingAJS)

                'blockControls()
            Else
                'blockControls()
            End If

            If Me.AJS <> 0 AndAlso Me.AJE <> 0 Then
                cmbMovimiento.Value = "953954"
                cmbMotivo.Value = oAjusteAJE.Motivo
            End If

            blockControls()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub blockControls()
        Me.nbTotalArticulosAJE.Value = Me.oAjusteAJE.TotalCodigos
        grdProductosAJE.Enabled = False
        grdProductosAJS.Enabled = False
        Me.txtObservaciones.Enabled = False
        cmbMotivo.Enabled = False
        cmbMovimiento.Enabled = False
    End Sub

    Private Sub Column_ChangingAJE(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        Try
            If bolLoadForm Then
                Select Case UCase(e.Column.ColumnName)
                    Case UCase("Codigo")
                        ActualizaDatosArticulo(e.Row, e.ProposedValue)
                        grdProductosAJE.Focus()
                        '-----------------------------------------------------------------------------
                        ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                        '-----------------------------------------------------------------------------
                        'Case UCase("Talla")
                        '    If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = String.Empty Then
                        '        MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Exit Sub
                        '    End If
                        '    If Not FindTalla(e.ProposedValue) Then
                        '        MessageBox.Show("La talla no pertecene al Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '        If IsDBNull(e.Row("Talla")) OrElse e.Row("Talla") = String.Empty Then
                        '            e.ProposedValue = ""
                        '        Else
                        '            e.ProposedValue = e.Row("Talla")
                        '        End If
                        '        grdProductosAJE.Focus()
                        '    Else
                        '        If BuscaCodigoEnAjusteAJE(e.Row("Codigo"), e.ProposedValue, grdProductosAJE.Row) > 0 Then
                        '            MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '            grdProductosAJE.Focus()
                        '            e.ProposedValue = e.Row("Talla")
                        '        End If
                        '    End If
                    Case UCase("Cantidad")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = 0 Then
                            MessageBox.Show("Capture Cantidad", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                End Select
            End If


        Catch ex As Exception
            MessageBox.Show("Error :" & ex.ToString)
        End Try


    End Sub

    Private Sub Column_ChangingAJS(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        Try
            If bolLoadForm Then
                Select Case UCase(e.Column.ColumnName)
                    Case UCase("Codigo")
                        ActualizaDatosArticulo(e.Row, e.ProposedValue)
                        grdProductosAJS.Focus()
                        '-----------------------------------------------------------------------------
                        ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                        '-----------------------------------------------------------------------------
                        'Case UCase("Talla")
                        '    If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = String.Empty Then
                        '        MessageBox.Show("Capture la Talla", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Exit Sub
                        '    End If
                        '    If Not FindTalla(e.ProposedValue) Then
                        '        MessageBox.Show("La talla no pertecene al Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '        If IsDBNull(e.Row("Talla")) OrElse e.Row("Talla") = String.Empty Then
                        '            e.ProposedValue = ""
                        '        Else
                        '            e.ProposedValue = e.Row("Talla")
                        '        End If
                        '        grdProductosAJS.Focus()
                        '    Else
                        '        If BuscaCodigoEnAjusteAJS(e.Row("Codigo"), e.ProposedValue, grdProductosAJS.Row) > 0 Then
                        '            MessageBox.Show("El Aticulo ya se encuentra con esa Talla " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '            grdProductosAJS.Focus()
                        '            e.ProposedValue = e.Row("Talla")
                        '        End If
                        '    End If
                    Case UCase("Cantidad")
                        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue = 0 Then
                            MessageBox.Show("Capture Cantidad", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        Dim arts As Decimal = oAjusteMgr.Existencias(e.Row("Codigo")) ', e.Row("Talla"))
                        If e.ProposedValue > arts Then
                            MessageBox.Show("No tiene existencias el Articulo.- " & e.Row("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            e.ProposedValue = arts
                            Exit Sub
                        End If
                End Select
            End If


        Catch ex As Exception
            MessageBox.Show("Error :" & ex.ToString)
        End Try


    End Sub

    Private Sub ActualizaDatosArticulo(ByVal oRow As DataRow, ByVal CodigoArticulo As String)
        If CodigoArticulo <> String.Empty Then
            oArticulo = oCatalogoArticulosMgr.Create()
            oArticulo.ClearFields()
            oCatalogoArticulosMgr.LoadInto(CodigoArticulo, oArticulo)
            oRow("Descripcion") = oArticulo.Descripcion
            oRow("Importe") = oArticulo.CostoProm
            '-----------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
            '-----------------------------------------------------------------------------
            'FillTallasArticulo(oArticulo.CodCorrida)
        End If
    End Sub

    '-----------------------------------------------------------------------------
    ' JNAVA (18.02.2016): Comentado por adecuaciones de Retail
    '-----------------------------------------------------------------------------
    'Private Sub FillTallasArticulo(ByVal vCodCorrida As String)

    '    dsTallas = Nothing

    '    dsTallas = oFacturaMgr.GetTallasArticulo(vCodCorrida)

    '    If dsTallas Is Nothing Then

    '        MsgBox("Corrida del Artículo NO EXISTE.  ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

    '    End If

    'End Sub

    'Private Function FindTalla(ByVal strTalla As String) As Boolean

    '    Dim iCol As Integer
    '    Dim campoTalla As String

    '    If Not (dsTallas Is Nothing) Then

    '        For iCol = 0 To 19

    '            campoTalla = "C" & Format(iCol + 1, "00")

    '            If dsTallas.Tables(0).Rows(0).Item(campoTalla) = strTalla Then

    '                Return True

    '            End If

    '        Next

    '    End If

    '    Return False

    'End Function

    Private Function LoadSearchArticulo() As String

        Dim cArticulo As String
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If oOpenRecordDlg.pbCodigo = String.Empty Then

                cArticulo = oOpenRecordDlg.Record.Item("Código")

            ElseIf oOpenRecordDlg.Record.Item("Código") Is Nothing OrElse oOpenRecordDlg.Record.Item("Código").ToString.Trim = "" Then

                cArticulo = oOpenRecordDlg.pbCodigo

            Else

                cArticulo = oOpenRecordDlg.Record.Item("Código")

            End If

        Else

            cArticulo = ""

        End If

        oOpenRecordDlg.Dispose()
        oOpenRecordDlg = Nothing

        Return cArticulo

    End Function

    Private Function BuscaCodigoEnAjusteAJE(ByVal strCodigo As String, ByVal nRowG As Integer) As Integer

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In Me.oAjusteAJE.Detalle.Rows

            nRow = nRow + 1
            '-----------------------------------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
            '------------------------------------------------------------->--------------------------------------<
            If (nRow - 1) <> nRowG AndAlso oRow("Codigo") = strCodigo Then 'AndAlso oRow("Talla") = strTalla Then

                Return nRow

            End If

        Next

        Return 0

    End Function

    Private Function BuscaCodigoEnAjusteAJS(ByVal strCodigo As String, ByVal nRowG As Integer) As Integer 'ByVal strTalla As String, ByVal nRowG As Integer) As Integer
        '------------------------------------------------------------------------------------------------------
        ' JNAVA (18.02.2016): modificado por adecuaciones de Retail
        '------------------------------------------------------------->--------------------------------------<-

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In Me.oAjusteAJS.Detalle.Rows

            nRow = nRow + 1
            '------------------------------------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
            '------------------------------------------------------------->--------------------------------------<-
            If (nRow - 1) <> nRowG AndAlso oRow("Codigo") = strCodigo Then 'AndAlso oRow("Talla") = strTalla Then

                Return nRow

            End If

        Next

        Return 0

    End Function

    Private Sub AgregarCodigoAJE()
        Me.bolLoadForm = False
        Dim oNewRow As DataRow = Me.oAjusteAJE.Detalle.NewRow
        oAjusteAJE.Detalle.Rows.Add(oNewRow)
        oAjusteAJE.Detalle.AcceptChanges()
        grdProductosAJE.Row = oAjusteAJE.Detalle.Rows.Count - 1
        grdProductosAJE.Col = 0
        Me.bolLoadForm = True
    End Sub

    Private Sub AgregarCodigoAJS()
        Me.bolLoadForm = False
        Dim oNewRow As DataRow = Me.oAjusteAJS.Detalle.NewRow
        oAjusteAJS.Detalle.Rows.Add(oNewRow)
        oAjusteAJS.Detalle.AcceptChanges()
        grdProductosAJS.Row = oAjusteAJS.Detalle.Rows.Count - 1
        grdProductosAJS.Col = 0
        Me.bolLoadForm = True
    End Sub

    Private Function ValidaCodigosEnTE(ByVal dtSalida As DataTable) As Boolean

        oTraspasoEntrada = oTraspasoEntradaMgr.LoadByFolioSAP(Me.nebFolioTEOrigen.Text.Trim)

        If oTraspasoEntrada Is Nothing Then
            MessageBox.Show("El traspaso de entrada no existe o no esta aplicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebFolioTEOrigen.Focus()
            Return False
        Else
            Dim oRowS As DataRow
            Dim oRowE As DataRow
            Dim dtTEDetalle As DataTable = oTraspasoEntrada.Detalle.Tables(0).Copy
            Dim bEnc As Boolean = True
            Dim bCantMayor As Boolean = False

            For Each oRowS In dtSalida.Rows
                bEnc = True
                For Each oRowE In dtTEDetalle.Rows
                    If CStr(oRowS!Codigo).Trim.ToUpper = CStr(oRowE!Codigo).Trim.ToUpper AndAlso CStr(oRowS!Talla).Trim.ToUpper = CStr(oRowE!Talla).Trim.ToUpper Then
                        bEnc = True
                        Exit For
                    Else
                        bEnc = False
                    End If
                Next
                If bEnc = False Then Exit For
            Next
            If bEnc = False Then
                MessageBox.Show("Hay codigos en el Ajuste de Salida que no se encuentran en el traslado de entrada origen." & vbCrLf & vbCrLf & "Favor de verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        Return True

    End Function

    '    Private Function NegarMaterialesPedidosEC(ByVal dtMateriales As DataTable) As DataTable

    '        Dim oRow As DataRow
    '        Dim dtPed As DataTable
    '        Dim dtPedDet As DataTable
    '        'Dim dtTrasModif As DataTable
    '        Dim oFacturaTemp As Factura
    '        Dim dtNegados As DataTable
    '        Dim oNewRow As DataRow
    '        Dim Talla As String = ""

    '        dtPed = oSap.ZPOL_TRASLPEN(oSap.Read_Centros, dtPedDet) ', dtTrasModif)

    '        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
    '            Dim dvPedidoDet As DataView

    '            CreaEstructuraNegados(dtNegados)

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
    '                                If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
    '                                    Talla = CInt(oRow!Talla)
    '                                Else
    '                                    Talla = CStr(oRow!Talla).Trim
    '                                End If
    '                                oFacturaTemp = oFacturaMgr.Create()
    '                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                                If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
    '                                    oNewRow = dtNegados.NewRow
    '                                    With oNewRow
    '                                        !Codigo = CStr(oRowPD!Material).Trim
    '                                        !Talla = CStr(oRowPD!Talla).Trim
    '                                        !Cantidad = 0
    '                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
    '                                        !Motivo = "00012"
    '                                        !MotivoDesc = "Ajuste Salida"
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

    'Private Function ValidarMaterialesDefectuososEC(ByVal dtMateriales As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String) As Boolean

    '    Dim oRowM As DataRow
    '    Dim dtDefEC As DataTable
    '    Dim dtTemp As DataTable
    '    Dim oFacturaTemp As Factura
    '    Dim oNewRow As DataRow
    '    Dim Talla As String = ""
    '    Dim Max As Integer = 0, Min As Integer = 0
    '    Dim bRes As Boolean = True

    '    dtDefEC = oSap.ZPOL_GET_DEFT_CENTRO()

    '    If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then

    '        dtTemp = dtDefEC.Clone
    '        dtTemp.Columns.Add("Minimo", GetType(Integer))
    '        dtTemp.Columns.Add("Maximo", GetType(Integer))
    '        dtTemp.Columns.Add("Motivo", GetType(String))
    '        dtTemp.AcceptChanges()

    '        For Each oRowM In dtMateriales.Rows
    '            For Each oRowDE As DataRow In dtDefEC.Rows
    '                If IsNumeric(oRowM!Talla) Then
    '                    Talla = Format(CDec(oRowM!Talla), "#.0")
    '                Else
    '                    Talla = CStr(oRowM!Talla).Trim
    '                End If
    '                If CStr(oRowDE!Material).Trim.ToUpper = CStr(oRowM!Codigo).Trim.ToUpper AndAlso CStr(oRowDE!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '                    If IsNumeric(Talla) AndAlso InStr(Talla.Trim, ".0") > 0 Then
    '                        Talla = CInt(oRowM!Talla)
    '                    Else
    '                        Talla = CStr(oRowM!Talla).Trim
    '                    End If
    '                    oFacturaTemp = oFacturaMgr.Create()
    '                    oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                    Max = 0 : Min = 0
    '                    If (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad) >= oRowM!Cantidad Then
    '                        Min = 0
    '                    Else
    '                        Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad)
    '                    End If
    '                    Max = IIf(oRowDE!Cantidad < oRowM!Cantidad, oRowDE!Cantidad, oRowM!Cantidad)
    '                    oNewRow = dtTemp.NewRow
    '                    With oNewRow
    '                        !Material = CStr(oRowDE!Material).Trim
    '                        !Talla = CStr(oRowDE!Talla).Trim
    '                        !Cantidad = Min
    '                        !Minimo = Min
    '                        !Maximo = Max
    '                        !Motivo = "Ajustado con folio "
    '                    End With
    '                    dtTemp.Rows.Add(oNewRow)
    '                    oFacturaTemp = Nothing
    '                    Exit For
    '                End If
    '            Next
    '        Next

    '        If dtTemp.Rows.Count > 0 Then
    '            If UserName.Trim = "" Then
    '                If MessageBox.Show("Existen codigos marcados como de baja calidad que podrian ir en el detalle de esta operación." & vbCrLf & "Es necesario especificarlos." & _
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

    Private Sub ValidarCambioStatusPedido(ByVal dtNegados As DataTable, ByVal Responsable As String)

        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oRowN As DataRow, oRowP As DataRow
        Dim Pedidos As String = ""
        Dim dvPedDet As DataView

        dtPed = oSap.ZPOL_TRASLPEN(oSap.Read_Centros, dtPedDet) ', dtTrasModif)

        For Each oRowN In dtNegados.Rows
            If InStr(Pedidos.Trim.ToUpper, CStr(oRowN!PedidoEC).Trim.ToUpper) <= 0 Then
                Pedidos &= CStr(oRowN!PedidoEC).Trim.ToUpper & ","
                dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And (Cant_Pendiente > 0 Or Cant_Entregado > 0)", "", DataViewRowState.CurrentRows)
                'dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
                If dvPedDet.Count <= 0 Then
                    oSap.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, "")
                End If
            End If
        Next

    End Sub

    Public Sub Guardar(Optional ByVal Print As Boolean = True)

        ''********************************************************************
        If Reajuste And Estado <> "AUT" Then
            MessageBox.Show("Tienes que Hacer un Nuevo Ajuste", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf oAjusteAJE.Detalle.Rows.Count <= 0 And oAjusteAJS.Detalle.Rows.Count <= 0 Then
            MessageBox.Show("No hay Articulos para Ajustar", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf Me.txtObservaciones.Text.Trim = String.Empty Then
            MessageBox.Show("Capture observaciones", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservaciones.Focus()
            Exit Sub
        ElseIf Me.chkTraspasoEntrada.Checked AndAlso Me.nebFolioTEOrigen.Value <= 0 Then
            MessageBox.Show("Es necesario indicar el folio SAP del traslado de entrada de los codigos a ajustar de salida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebFolioTEOrigen.Focus()
            Exit Sub
        ElseIf cmbMovimiento.Value = "" OrElse cmbMovimiento.Text.Trim = "" Then
            MessageBox.Show("Es necesario indicar el tipo de movimiento a realizar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbMovimiento.Focus()
            Exit Sub
        ElseIf cmbMotivo.Value = "" OrElse cmbMotivo.Text.Trim = "" Then
            MessageBox.Show("Es necesario indicar el motivo de este movimiento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbMotivo.Focus()
            Exit Sub
        End If
        'End If
        'End If
        ''********************************************************************
        If Me.ValidaAllRecordAJE Or Me.ValidaAllRecordAJS Then
            'si me regresa algun true hay errores no puedo proseguir
            Exit Sub
        Else

            Dim dtNegados As DataTable
            Dim UserNameNiega As String = ""
            Dim dtDefectuososEC As DataTable
            Dim UserNameDesmarca As String = ""

            'If oAjusteAJS.Detalle.Rows.Count > 0 Then
            '    If oConfigCierreFI.SurtirEcommerce Then
            '        '--------------------------------------------------------------------------------------------------------------------------------------------------
            '        'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del ajuste de salida
            '        '--------------------------------------------------------------------------------------------------------------------------------------------------
            '        dtNegados = NegarMaterialesPedidosEC(oAjusteAJS.Detalle)
            '        If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
            '            If MessageBox.Show("Hay codigos en el detalle del ajuste de salida que se negaran a algun pedido solicitado por Ecommerce" & vbCrLf & _
            '            "Sera necesario identificarse para continuar" & vbCrLf & vbCrLf & "¿Desea continuar con el ajuste de salida?", Me.Text, MessageBoxButtons.YesNo, _
            '            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            '                oAppContext.Security.CloseImpersonatedSession()
            '                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") = False Then
            '                    MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                    Exit Sub
            '                Else
            '                    UserNameNiega = oAppContext.Security.CurrentUser.Name
            '                    oAppContext.Security.CloseImpersonatedSession()
            '                End If
            '            Else
            '                Exit Sub
            '            End If
            '        End If
            '    End If
            '    '--------------------------------------------------------------------------------------------------------------------------
            '    'Validamos si los codigos del apartado estan marcados como defectuosos para Ecommerce
            '    '--------------------------------------------------------------------------------------------------------------------------
            '    UserNameDesmarca = UserNameNiega
            '    If ValidarMaterialesDefectuososEC(oAjusteAJS.Detalle, dtDefectuososEC, UserNameDesmarca, "AS") = False Then
            '        Exit Sub
            '    End If
            'End If
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            'si me regresa dos falsos es que puedo proseguir
            '--------------------------------------------------------------------------------------------------------------------------------------------------
            If oAjusteAJE.Detalle.Rows.Count > 0 AndAlso oAjusteAJS.Detalle.Rows.Count = 0 Then

                If Estado = "AUT" Then
                    'Guardar en SAP Ajustes de Entrada
                    GuardarAJESAP()
                    '--------------------------
                    If oAjusteAJE.FolioSAP.Trim <> "" Then
                        GuardarFoliosSAp("E")
                        '--------------------------
                        Me.oAjusteAJE.TipoAjuste = "E"
                        Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
                        '--------------------------
                        oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "GRA")
                        Me.Estado = "GRA"
                        '--------------------------
                        If Print Then
                            ActionPrintAjusteAJE(Me.nbFolioAUT.Text)
                        End If
                        Reajuste = True
                        MessageBox.Show("Ajuste de entrada Guardado con Autorización", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else

                    'Guardar en SAP Ajustes de Entrada
                    GuardarAJESAP()
                    '--------------------------
                    If oAjusteAJE.FolioSAP.Trim <> "" Then
                        'Guardar en DP Ajustes de Entrada
                        GuardarDP("E")
                        '--------------------------
                        Me.oAjusteAJE.TipoAjuste = "E"
                        oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
                        '--------------------------
                        Me.nbFolio.Value = Me.oAjusteMgr.InsertESNuevo(0, Me.oAjusteAJE.FolioAjuste, "GRA", Me.txtObservaciones.Text, Me.CalendarCombo1.Value, Me.ebResponsable.Text)
                        '--------------------------
                        MessageBox.Show("Ajuste de Entrada guardado con Folio: " & Me.nbFolio.Value, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If Print Then
                            ActionPrintAjusteAJE(Me.nbFolio.Text)
                        End If
                        Reajuste = True
                    Else
                        MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                If (oAjusteAJE.Detalle.Rows.Count = 0 AndAlso oAjusteAJS.Detalle.Rows.Count > 0) OrElse _
                ((oAjusteAJE.Detalle.Rows.Count = 0 AndAlso oAjusteAJS.Detalle.Rows.Count > 0) AndAlso Estado = "AUT") Then

                    If Estado = "AUT" Then

                        oAppContext.Security.CloseImpersonatedSession()

                        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AutorizacionAjustes") Then

                            '-----------------------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
                            '-----------------------------------------------------------------------------------------------------------------------------
                            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
                            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(oAjusteAJS.Detalle)
                            If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                                ShowFormNegadosSH(dtNegadosSH)
                                Exit Sub
                            End If
                            '-------------------------------------------------------------------------------------------------------------------
                            'Revisamos si van materiales que estan en un pedido del Ecommerce o codigos marcados como de baja calidad en el 
                            'Ajuste de Salida
                            '-------------------------------------------------------------------------------------------------------------------
                            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oAjusteAJS.Detalle, dtMateriales)
                            If ValidarMaterialesEC(dtDefectuososEC, dtNegados, UserNameNiega, UserNameDesmarca, dtArticuloLibre) = False Then
                                Exit Sub
                            End If

                            '-------------------------------------------------------------------------------------------------------------------
                            'Guardar en SAP Ajustes de Salida
                            '-------------------------------------------------------------------------------------------------------------------
                            GuardarAJSSAP()
                            '-------------------------------------------------------------------------------------------------------------------
                            If oAjusteAJS.FolioSAP.Trim <> "" Then
                                GuardarFoliosSAp("S")
                                '-------------------------------------------------------------------------------------------------------------------
                                Me.oAjusteAJS.TipoAjuste = "S"
                                Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJS)
                                '-------------------------------------------------------------------------------------------------------------------
                                oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "GRA")
                                Me.Estado = "GRA"
                                '-------------------------------------------------------------------------------------------------------------------
                                'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
                                '-------------------------------------------------------------------------------------------------------------------
                                If oConfigCierreFI.SurtirEcommerce Then
                                    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                                        oSap.ZPOL_TRASL_NEGAR(oAjusteAJS.FolioSAP, "AS", UserNameNiega, dtNegados)
                                        ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                                    End If
                                End If
                                '--------------------------------------------------------------------------------------------------------------------------
                                'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en la factura
                                '--------------------------------------------------------------------------------------------------------------------------
                                If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                                    oSap.ZPOL_DEFECTUOSOS_INS(oAjusteAJS.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC)
                                End If
                                If Print Then
                                    ActionPrintAjusteAJS(Me.nbFolioAUT.Text)
                                End If
                                MessageBox.Show("Ajuste Guardado Con Autorización", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Reajuste = True
                            Else
                                MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        End If

                        oAppContext.Security.CloseImpersonatedSession()

                    Else
                        'If DialogResult.Yes = MessageBox.Show("Si el monto del Ajuste de salida es mayor que el de entrada " & Chr(13) & "Se Necesita la Autorización del Auditor, Desea Grabarlo para Autorización", "Guardar Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                        'Guardar en DP Ajustes de Salida
                        GuardarDP("S")
                        '--------------------------
                        Me.nbFolio.Value = Me.oAjusteMgr.InsertESNuevo(Me.oAjusteAJS.FolioAjuste, 0, "AUT", Me.txtObservaciones.Text, Me.CalendarCombo1.Value, Me.ebResponsable.Text)
                        '--------------------------
                        MessageBox.Show("Ajuste de Salida para autorizar guardado con Folio: " & Me.nbFolio.Value, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Reajuste = True
                        'End If
                    End If
                    Reajuste = True
                Else
                    'aqui validar que si la diferencia del ajuste de salida es de 50 pesos
                    Dim band As Boolean = False
                    If Me.nbTotalAJS.Value > Me.nbTotalAJE.Value Then
                        Dim dif As Decimal = Me.nbTotalAJS.Value - Me.nbTotalAJE.Value
                        If dif <= 50 Then
                            'si se hace ajuste sin autorización
                            band = True
                        Else
                            'no se hace ajuste sin autorización
                            band = False
                        End If
                    End If

                    If Me.nbTotalAJE.Value >= Me.nbTotalAJS.Value Or band Then
                        If Estado = "AUT" Then 'Guardar el ajuste con autorización
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'JNAVA 15/11/2013: Se agregaron Validaciones de negados SH
                            '-----------------------------------------------------------------------------------------------------------------------------
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
                            '-----------------------------------------------------------------------------------------------------------------------------
                            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
                            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(oAjusteAJS.Detalle)
                            If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                                ShowFormNegadosSH(dtNegadosSH)
                                Exit Sub
                            End If
                            '-------------------------------------------------------------------------------------------------------------------
                            'Revisamos si van materiales que estan en un pedido del Ecommerce o codigos marcados como de baja calidad en el 
                            'Ajuste de Salida
                            '-------------------------------------------------------------------------------------------------------------------
                            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oAjusteAJS.Detalle, dtMateriales)
                            If ValidarMaterialesEC(dtDefectuososEC, dtNegados, UserNameNiega, UserNameDesmarca, dtArticuloLibre) = False Then
                                Exit Sub
                            End If

                            '-------------------------------------------------------------------------------------------------------------------
                            'Guardar en SAP Ajustes de Entrada y SAlida
                            '-------------------------------------------------------------------------------------------------------------------
                            GuardarAJESAP()
                            GuardarAJSSAP()

                            If oAjusteAJE.FolioSAP.Trim <> "" OrElse oAjusteAJS.FolioSAP.Trim <> "" Then
                                '-------------------------- 
                                If oAjusteAJE.FolioSAP.Trim <> "" Then
                                    Me.oAjusteAJE.TipoAjuste = "E"
                                    Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
                                Else
                                    MessageBox.Show("Ocurrio un error al guardar el ajuste de entrada en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                '--------------------------
                                If oAjusteAJS.FolioSAP.Trim <> "" Then
                                    Me.oAjusteAJS.TipoAjuste = "S"
                                    Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJS)
                                Else
                                    MessageBox.Show("Ocurrio un error al guardar el ajuste de salida en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                '--------------------------
                                oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "GRA")
                                Me.Estado = "GRA"

                                If oAjusteAJS.FolioSAP.Trim <> "" Then
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    If oConfigCierreFI.SurtirEcommerce Then
                                        If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                                            oSap.ZPOL_TRASL_NEGAR(oAjusteAJS.FolioSAP, "AS", UserNameNiega, dtNegados)
                                            ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                                        End If
                                    End If
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en la factura
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                                        oSap.ZPOL_DEFECTUOSOS_INS(oAjusteAJS.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC)
                                    End If
                                End If
                                
                                If Print Then
                                    If oAjusteAJE.FolioSAP.Trim <> "" Then ActionPrintAjusteAJE(Me.nbFolio.Text)
                                    If oAjusteAJS.FolioSAP.Trim = "" Then ActionPrintAjusteAJS(Me.nbFolio.Text)
                                End If
                                Reajuste = True
                            Else
                                MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            
                        Else
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'JNAVA 15/11/2013: Se agregaron Validaciones de negados SH
                            '-----------------------------------------------------------------------------------------------------------------------------
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
                            '-----------------------------------------------------------------------------------------------------------------------------
                            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
                            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(oAjusteAJS.Detalle)
                            If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                                ShowFormNegadosSH(dtNegadosSH)
                                Exit Sub
                            End If
                            '-------------------------------------------------------------------------------------------------------------------
                            'Revisamos si van materiales que estan en un pedido del Ecommerce o codigos marcados como de baja calidad en el 
                            'Ajuste de Salida
                            '-------------------------------------------------------------------------------------------------------------------
                            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oAjusteAJS.Detalle, dtMateriales)
                            If ValidarMaterialesEC(dtDefectuososEC, dtNegados, UserNameNiega, UserNameDesmarca, dtArticuloLibre) = False Then
                                Exit Sub
                            End If

                            '-------------------------------------------------------------------------------------------------------------------
                            'Guardar en SAP Ajustes de Entrada y SAlida
                            '-------------------------------------------------------------------------------------------------------------------
                            GuardarAJESAP()
                            GuardarAJSSAP()
                            '--------------------------
                            If oAjusteAJE.FolioSAP.Trim <> "" OrElse oAjusteAJS.FolioSAP.Trim <> "" Then
                                'Guardar en DP Ajustes de Salida y Entrada
                                If oAjusteAJE.FolioSAP.Trim <> "" Then
                                    GuardarDP("E")
                                    '--------------------------
                                    Me.oAjusteAJE.TipoAjuste = "E"
                                    Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
                                    '--------------------------
                                Else
                                    MessageBox.Show("Ocurrio un error al guardar el ajuste de entrada en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If

                                If oAjusteAJS.FolioSAP.Trim <> "" Then
                                    GuardarDP("S")
                                    '-----------------------------
                                    Me.oAjusteAJS.TipoAjuste = "S"
                                    Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJS)
                                    '--------------------------
                                Else
                                    MessageBox.Show("Ocurrio un error al guardar el ajuste de salida en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                
                                Me.nbFolio.Value = Me.oAjusteMgr.InsertESNuevo(Me.oAjusteAJS.FolioAjuste, Me.oAjusteAJE.FolioAjuste, "GRA", Me.txtObservaciones.Text, Me.CalendarCombo1.Value, Me.ebResponsable.Text)

                                If oAjusteAJS.FolioSAP.Trim <> "" Then
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    'Se niegan los codigos de los pedidos de Ecommerce en caso de ser necesario
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    If oConfigCierreFI.SurtirEcommerce Then
                                        If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                                            oSap.ZPOL_TRASL_NEGAR(oAjusteAJS.FolioSAP, "AS", UserNameNiega, dtNegados)
                                            ValidarCambioStatusPedido(dtNegados, UserNameNiega)
                                        End If
                                    End If
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en la factura
                                    '--------------------------------------------------------------------------------------------------------------------------
                                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                                        oSap.ZPOL_DEFECTUOSOS_INS(oAjusteAJS.FolioSAP, "DD", UserNameDesmarca, dtDefectuososEC)
                                    End If
                                End If
                               
                                If Print Then
                                    If oAjusteAJE.FolioSAP.Trim <> "" Then ActionPrintAjusteAJE(Me.nbFolio.Text)
                                    If oAjusteAJS.FolioSAP.Trim <> "" Then ActionPrintAjusteAJS(Me.nbFolio.Text)
                                End If
                                Reajuste = True
                                MessageBox.Show("Ajuste de Entrada y Salida guardados con Folio: " & Me.nbFolio.Value, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        End If

                    Else
                        If (Me.nbTotalAJE.Value < Me.nbTotalAJS.Value) Or _
                        ((Me.nbTotalAJE.Value < Me.nbTotalAJS.Value) And Estado = "AUT") Then
                            If Estado = "AUT" Then 'Guardar el ajuste con autorización
                                oAppContext.Security.CloseImpersonatedSession()
                                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AutorizacionAjustes") Then
                                    '-----------------------------------------------------------------------------------------------------------------------------
                                    'JNAVA 15/11/2013: Se agregaron Validaciones de negados SH
                                    '-----------------------------------------------------------------------------------------------------------------------------
                                    '-----------------------------------------------------------------------------------------------------------------------------
                                    'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
                                    '-----------------------------------------------------------------------------------------------------------------------------
                                    Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
                                    Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(oAjusteAJS.Detalle)
                                    If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
                                        ShowFormNegadosSH(dtNegadosSH)
                                        Exit Sub
                                    End If
                                    '-------------------------------------------------------------------------------------------------------------------
                                    'Revisamos si van materiales que estan en un pedido del Ecommerce o codigos marcados como de baja calidad en el 
                                    'Ajuste de Salida
                                    '-------------------------------------------------------------------------------------------------------------------
                                    Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(oAjusteAJS.Detalle, dtMateriales)
                                    If ValidarMaterialesEC(dtDefectuososEC, dtNegados, UserNameNiega, UserNameDesmarca, dtArticuloLibre) = False Then
                                        Exit Sub
                                    End If

                                    '-------------------------------------------------------------------------------------------------------------------
                                    'Guardar en SAP Ajustes de Entrada
                                    '-------------------------------------------------------------------------------------------------------------------
                                    GuardarAJESAP()
                                    GuardarAJSSAP()
                                    '--------------------------
                                    If oAjusteAJE.FolioSAP.Trim <> "" OrElse oAjusteAJS.FolioSAP.Trim <> "" Then
                                        If oAjusteAJE.FolioSAP.Trim <> "" Then
                                            GuardarFoliosSAp("E")
                                            Me.oAjusteAJE.TipoAjuste = "E"
                                            Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJE)
                                        End If

                                        If oAjusteAJS.FolioSAP.Trim <> "" Then
                                            GuardarFoliosSAp("S")
                                            Me.oAjusteAJS.TipoAjuste = "S"
                                            Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJS)
                                        End If
                                        '--------------------------
                                        oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "GRA")
                                        Me.Estado = "GRA"
                                        '--------------------------
                                        If Print Then
                                            If oAjusteAJE.FolioSAP.Trim <> "" Then ActionPrintAjusteAJE(Me.nbFolioAUT.Text)
                                            If oAjusteAJS.FolioSAP.Trim <> "" Then ActionPrintAjusteAJS(Me.nbFolioAUT.Text)
                                        End If
                                        Reajuste = True

                                        MessageBox.Show("Ajuste Guardado Con Autorización, ENTRADA y SALIDA ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Ocurrio un error al guardar el movimiento en SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    End If
                                   
                                End If

                                oAppContext.Security.CloseImpersonatedSession()

                            Else
                                'If DialogResult.Yes = MessageBox.Show("Si el monto del Ajuste de salida es mayor que el de entrada " & Chr(13) & "Se Necesita la Autorización del Auditor, Desea Grabarlo para Autorización", "Guardar Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                                'Guardar en DP Ajustes de Salida
                                GuardarDP("S")
                                '--------------------------
                                'Guardar en DP Ajustes de Entrada
                                GuardarDP("E")
                                '--------------------------
                                Me.nbFolio.Value = Me.oAjusteMgr.InsertESNuevo(Me.oAjusteAJS.FolioAjuste, Me.oAjusteAJE.FolioAjuste, "AUT", Me.txtObservaciones.Text, Me.CalendarCombo1.Value, Me.ebResponsable.Text)
                                '--------------------------
                                Reajuste = True
                                MessageBox.Show("Ajuste de Entrada y Salida guardados con Folio: " & Me.nbFolio.Value, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                'End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ValidarMaterialesEC(ByRef dtDefectuososEC As DataTable, ByRef dtNegados As DataTable, ByRef UserNameNiega As String, _
                                         ByRef UserNameDesmarca As String, Optional ByVal dtMateriales As DataTable = Nothing) As Boolean

        Dim bRes As Boolean = True
        Dim dtDefecECSAP As DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Validamos si los codigos del traspaso estan marcados como defectuosos para Ecommerce
        '---------------- -------------------------------------------------------------------------------------------------------------------
        If Not dtMateriales Is Nothing Then
            bRes = ValidarMaterialesDefectuososEC(dtMateriales, dtDefectuososEC, UserNameDesmarca, "AS", dtDefecECSAP)
        Else
            bRes = ValidarMaterialesDefectuososEC(oAjusteAJS.Detalle, dtDefectuososEC, UserNameDesmarca, "AS", dtDefecECSAP)
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del traspaso
        '-----------------------------------------------------------------------------------------------------------------------------------
        If bRes Then
            If Not dtMateriales Is Nothing Then
                bRes = ValidarMaterialesParaNegarEC(dtNegados, dtMateriales, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "AS")
            Else
                bRes = ValidarMaterialesParaNegarEC(dtNegados, oAjusteAJS.Detalle, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "AS")
            End If

        End If

        'If oConfigCierreFI.SurtirEcommerce Then
        '    '-------------------------------------------------------------------------------------------------------------------------
        '    'Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle del ajuste de salida
        '    '-------------------------------------------------------------------------------------------------------------------------
        '    dtNegados = NegarMaterialesPedidosEC(oAjusteAJS.Detalle)
        '    If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
        '        If MessageBox.Show("Hay codigos en el detalle del ajuste de salida que se negaran a algun pedido solicitado por Ecommerce" & vbCrLf & _
        '        "Sera necesario identificarse para continuar" & vbCrLf & vbCrLf & "¿Desea continuar con el ajuste de salida?", Me.Text, MessageBoxButtons.YesNo, _
        '        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '            oAppContext.Security.CloseImpersonatedSession()
        '            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") = False Then
        '                MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                bRes = False
        '                GoTo Final
        '            Else
        '                UserNameNiega = oAppContext.Security.CurrentUser.Name
        '                oAppContext.Security.CloseImpersonatedSession()
        '            End If
        '        Else
        '            Exit Function
        '        End If
        '    End If
        'End If
        ''--------------------------------------------------------------------------------------------------------------------------
        ''Validamos si los codigos del ajuste de salida estan marcados como defectuosos para Ecommerce
        ''--------------------------------------------------------------------------------------------------------------------------
        'UserNameDesmarca = UserNameNiega
        ''If ValidarMaterialesDefectuososEC(oAjusteAJS.Detalle, dtDefectuososEC, UserNameDesmarca, "AS") = False Then
        ''    bRes = False
        ''End If
        ''TODO: Ray modif table
        'bRes = ValidarMaterialesDefectuososEC(oAjusteAJS.Detalle, dtDefectuososEC, UserNameDesmarca, "AS", Nothing)
Final:
        Return bRes

    End Function

    Public Sub GuardarFoliosSAp(ByVal strTipoAjuste As String)
        If strTipoAjuste = "E" Then
            If oAjusteAJE.Detalle.Rows.Count > 0 Then

                For Each erow As DataRow In oAjusteAJE.Detalle.Rows

                    oAjusteMgr.UpdateESNuevoDettalleFolioSAP(erow("folio"), erow("foliosap"), "E")

                Next

            End If
        Else
            If strTipoAjuste = "S" Then

                If oAjusteAJS.Detalle.Rows.Count > 0 Then

                    For Each erow As DataRow In oAjusteAJS.Detalle.Rows

                        oAjusteMgr.UpdateESNuevoDettalleFolioSAP(erow("folio"), erow("FolioSAP"), "S")

                    Next
                End If

            End If

        End If
    End Sub

    Public Sub GuardarDP(ByVal strTipoAjuste As String)

        If strTipoAjuste = "E" Then
            'Guardar en DP Ajustes de Entrada
            Me.oAjusteAJE.Usuario = Me.ebResponsable.Text
            Me.oAjusteAJE.Observaciones = Me.txtObservaciones.Text
            Me.oAjusteAJE.FolioSAP = "1"
            Me.oAjusteAJE.CostoTotal = oAjusteAJE.Detalle.Compute("sum(Total)", "Total>0")
            Me.oAjusteAJE.TipoAjuste = "E"
            Me.oAjusteAJE.TotalCodigos = Me.nbTotalArticulosAJE.Value
            oAjusteAJE.ClaseMov = GetClaseMov("E")
            oAjusteAJE.Motivo = cmbMotivo.Value
            Me.oAjusteMgr.Save(Me.oAjusteAJE)
            Me.AJE = Me.oAjusteAJE.FolioAjuste
        Else
            If strTipoAjuste = "S" Then
                'Guardar en DP Ajustes de Salida
                Me.oAjusteAJS.Usuario = Me.ebResponsable.Text
                Me.oAjusteAJS.Observaciones = Me.txtObservaciones.Text
                Me.oAjusteAJS.FolioSAP = "1"
                Me.oAjusteAJS.CostoTotal = oAjusteAJS.Detalle.Compute("sum(Total)", "Total>0")
                Me.oAjusteAJS.TipoAjuste = "S"
                Me.oAjusteAJS.TotalCodigos = Me.nbTotalArticulosAJS.Value
                Me.oAjusteAJS.TEOrigen = Me.nebFolioTEOrigen.Text.Trim.PadLeft(10, "0")
                oAjusteAJS.ClaseMov = GetClaseMov("S")
                oAjusteAJS.Motivo = cmbMotivo.Value
                Me.oAjusteMgr.Save(Me.oAjusteAJS)
                'Me.nbFolioAUT.Value = Me.oAjusteAJS.FolioAjuste
                Me.AJS = Me.oAjusteAJE.FolioAjuste
            End If
        End If

    End Sub

    Public Sub GuardarAJSSAP()

        oAjusteAJS.TipoAjuste = "S"
        Me.oAjusteAJS.FolioAjuste = oAjusteMgr.GetFolio("S")
        Me.oAjusteAJS.Almacen = oAppContext.ApplicationConfiguration.Almacen
        Me.oAjusteAJS.ClaseMov = GetClaseMov("S")
        Me.oAjusteAJS.Motivo = cmbMotivo.Value

        'son menos o igual a totAjus
        If oAjusteAJS.Detalle.Rows.Count <= 1 Then
            oSap.Write_AJUSTE(Me.oAjusteAJS)
            'Para que llene en todos los registros el folio SAP
            For Each oRow As DataRow In oAjusteAJS.Detalle.Rows
                If oAjusteAJS.FolioSAP Is Nothing Then
                    oRow!foliosap = ""
                Else
                    oRow!foliosap = oAjusteAJS.FolioSAP
                End If
            Next
        Else
            'A dividir
            Dim dtArticulos As New DataTable
            dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
            dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
            dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))

            Dim ren As Integer = 0 : Dim pos As Integer = 0

            For Each oRow As DataRow In oAjusteAJS.Detalle.Rows
                Dim rrow As DataRow = dtArticulos.NewRow
                rrow("Codigo") = oRow!codigo
                rrow("Cantidad") = oRow!cantidad
                'rrow("Talla") = oRow!Talla
                dtArticulos.Rows.Add(rrow)
                dtArticulos.AcceptChanges()
                ren += 1 : pos += 1
                'Marcar los Registros con este folio
                oRow!foliosap = "X"
                If ren = 1 Or oAjusteAJS.Detalle.Rows.Count = pos Then
                    oSap.Write_AJUSTE(oAjusteAJS, dtArticulos)
                    '--------------------Vaciar BD 
                    dtArticulos = Nothing : dtArticulos = New DataTable
                    dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
                    dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
                    'dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))
                    '---------------------
                    'Ponerles el FOlio SAP
                    For Each tmpRow As DataRow In oAjusteAJS.Detalle.Rows
                        If Me.oAjusteAJS.FolioSAP Is Nothing Then
                            If tmpRow!foliosap = "X" Then tmpRow!foliosap = ""
                        Else
                            If tmpRow!foliosap = "X" Then tmpRow!foliosap = oAjusteAJS.FolioSAP
                        End If
                    Next
                    ren = 0
                    '----------------------------------------------------------------------
                End If
            Next
        End If
    End Sub

    Private Function GetClaseMov(TipoAjuste As String) As String
        Dim ClaseMov As String = ""

        Select Case cmbMovimiento.Value
            Case "953954"
                If TipoAjuste = "E" Then
                    ClaseMov = "954"
                Else
                    ClaseMov = "953"
                End If
            Case Else
                ClaseMov = cmbMovimiento.Value
        End Select

        Return ClaseMov

    End Function

    Public Sub GuardarAJESAP()
        oAjusteAJE.TipoAjuste = "E"
        Me.oAjusteAJE.FolioAjuste = oAjusteMgr.GetFolio("E")
        Me.oAjusteAJE.Almacen = oAppContext.ApplicationConfiguration.Almacen
        Me.oAjusteAJE.ClaseMov = GetClaseMov("E")
        Me.oAjusteAJE.Motivo = cmbMotivo.Value
        'son menos o igual a totAjus
        If oAjusteAJE.Detalle.Rows.Count <= 7 Then
            oSap.Write_AJUSTE(oAjusteAJE)
            'Para que llene en todos los registros el folio SAP
            For Each oRow As DataRow In oAjusteAJE.Detalle.Rows
                If oAjusteAJE.FolioSAP Is Nothing Then
                    oRow!foliosap = ""
                Else
                    oRow!foliosap = oAjusteAJE.FolioSAP
                End If
            Next
        Else
            'A dividir
            Dim dtArticulos As New DataTable
            dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
            dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
            dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))

            Dim ren As Integer = 0 : Dim pos As Integer = 0

            For Each oRow As DataRow In oAjusteAJE.Detalle.Rows
                Dim rrow As DataRow = dtArticulos.NewRow
                rrow("Codigo") = oRow!codigo
                rrow("Cantidad") = oRow!cantidad
                'rrow("Talla") = oRow!Talla
                dtArticulos.Rows.Add(rrow)
                dtArticulos.AcceptChanges()
                ren += 1 : pos += 1
                'Marcar los Registros con este folio
                oRow!foliosap = "X"
                If ren = 7 Or oAjusteAJE.Detalle.Rows.Count = pos Then
                    oSap.Write_AJUSTE(oAjusteAJE, dtArticulos)
                    '--------------------Vaciar BD 
                    dtArticulos = Nothing : dtArticulos = New DataTable
                    dtArticulos.Columns.Add("Codigo", System.Type.GetType("System.String"))
                    dtArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
                    dtArticulos.Columns.Add("Talla", System.Type.GetType("System.String"))
                    '---------------------
                    'Ponerles el FOlio SAP
                    For Each tmpRow As DataRow In oAjusteAJE.Detalle.Rows
                        If oAjusteAJE.FolioSAP Is Nothing Then
                            If tmpRow!foliosap = "X" Then tmpRow!foliosap = ""
                        Else
                            If tmpRow!foliosap = "X" Then tmpRow!foliosap = oAjusteAJE.FolioSAP
                        End If
                    Next
                    ren = 0
                    '----------------------------------------------------------------------
                End If
            Next
        End If

    End Sub

    Public Sub ActionPrintAjusteAJE(ByVal intFolio As Integer)

        Dim iRep As AjustesESFrm
        Dim iView As ReportViewerForm

        iRep = New AjustesESFrm
        iRep.Document.Name = "REPORTE DE AJUSTES DE ENTRADA"
        'iView = New ReportViewerForm
        iRep.DataSource = Me.FormatGridToReportAJE
        iRep.Titulo = "REPORTE DE AJUSTES DE ENTRADA"
        iRep.Folio = intFolio 'oAjusteAJE.FolioAjuste
        iRep.Fecha = oAjusteAJE.FechaAjuste
        iRep.Usuario = oAjusteAJE.Usuario

        '''Asigno Almacen.
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oAlmacenMgr.Create
        '-------------------------------------------------
        ' JNAVA (20.02.2015): Adecuaciones por retail
        '-------------------------------------------------
        Dim CentroSAP As String
        CentroSAP = oSap.Read_Centros()
        oAlmacen = oAlmacenMgr.Load(CentroSAP) 'Me.oAjusteAJE.Almacen)
        iRep.CodigoAlmacen = CentroSAP 'oAjusteAJE.Almacen
        iRep.NombreAlmacen = oAlmacen.Descripcion
        '''Asigno Almacen.
        '-------------------------------------------------

        iRep.Observaciones = oAjusteAJE.Observaciones
        iRep.Run()
        iRep.Document.Print(False, False)

        'iView.Report = iRep
        'iView.ShowDialog()
    End Sub

    Public Sub ActionPrintAjusteAJS(ByVal intFolio As Integer)

        Dim iRep As AjustesESFrm
        Dim iView As ReportViewerForm

        iRep = New AjustesESFrm
        iRep.Document.Name = "REPORTE DE AJUSTES DE SALIDA"
        'iView = New ReportViewerForm
        iRep.DataSource = Me.FormatGridToReportAJS

        iRep.Titulo = "REPORTE DE AJUSTES DE SALIDA"

        iRep.Folio = intFolio 'oAjusteAJS.FolioAjuste
        iRep.Fecha = oAjusteAJS.FechaAjuste
        iRep.Usuario = oAjusteAJS.Usuario

        '''Asigno Almacen.
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oAlmacenMgr.Create
        '-------------------------------------------------------------------------
        ' JNAVA (12.05.2016): Se obtiene informacion de almacen
        '-------------------------------------------------------------------------
        'oAlmacen = oAlmacenMgr.Load(Me.oAjusteAJS.Almacen)
        oAlmacen = oAlmacenMgr.Load(oSap.Read_Centros(Me.oAjusteAJS.Almacen))
        '-------------------------------------------------------------------------
        iRep.CodigoAlmacen = oAjusteAJS.Almacen
        iRep.NombreAlmacen = oAlmacen.Descripcion
        '''Asigno Almacen.
        iRep.Observaciones = oAjusteAJS.Observaciones
        iRep.Run()
        iRep.Document.Print(False, False)
        'iView.Report = iRep
        'iView.ShowDialog()
    End Sub

    Public Function FormatGridToReportAJE() As DataTable
        Dim dtReport As New DataTable("Articulos")

        Dim oCol As DataColumn

        oCol = New DataColumn
        With oCol
            .ColumnName = "Codigo"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Descripcion"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        '-------------------------------------------------------------------
        ' JNAVA (17.05.2016): Se agrego color, marca y proveedor
        '-------------------------------------------------------------------
        oCol = New DataColumn
        With oCol
            .ColumnName = "Marca"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Proveedor"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)
        '-------------------------------------------------------------------

        'Dim i As Integer
        'For i = 1 To 10
        '    oCol = New DataColumn
        '    With oCol
        '        .ColumnName = "T" & i
        '        .DataType = GetType(System.String)
        '    End With
        '    dtReport.Columns.Add(oCol)
        'Next

        'For i = 1 To 10
        '    oCol = New DataColumn
        '    With oCol
        '        .ColumnName = "C" & i
        '        .DataType = GetType(System.String)
        '    End With
        '    dtReport.Columns.Add(oCol)
        'Next

        oCol = New DataColumn
        With oCol
            .ColumnName = "Total"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Importe"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "FolioSAP"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With
        dtReport.Columns.Add(oCol)

        For Each oNewRow As DataRow In Me.oAjusteAJE.Detalle.Rows
            Dim dvExiste As New DataView(dtReport, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)
            If dvExiste.Count = 0 Then

                Dim dvAjusteDetalle As New DataView(Me.oAjusteAJE.Detalle, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)

                Dim oAddRow As DataRow = dtReport.NewRow
                oAddRow!Codigo = oNewRow!Codigo
                oAddRow!Descripcion = oNewRow!Descripcion
                oAddRow!FolioSAP = oNewRow!FolioSAP

                '-------------------------------------------------------------------
                ' JNAVA (17.05.2016): Obtenemos el color, marca y proveedor
                '-------------------------------------------------------------------
                Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                Dim oArticulo As Articulo = oArticuloMgr.Create
                oArticulo = oArticuloMgr.Load(CStr(oNewRow!Codigo))
                oAddRow!Marca = oArticulo.CodMarca
                oAddRow!Proveedor = oArticulo.CodArtProv
                oArticulo = Nothing
                oArticuloMgr = Nothing
                '-------------------------------------------------------------------

                Dim IndexView As Integer

                For IndexView = 0 To dvAjusteDetalle.Count - 1
                    'oAddRow("T" & IndexView + 1) = dvAjusteDetalle(IndexView)!Talla
                    'oAddRow("C" & IndexView + 1) = dvAjusteDetalle(IndexView)!Cantidad
                    oAddRow("Total") += dvAjusteDetalle(IndexView)!Cantidad 'Piezas
                    'oAddRow("Importe") += oNewRow("Total") ' Costo Total
                    'Correcion estaba sumando mal el importe cuando el codigo trae mas de 1 talla
                    oAddRow("Importe") += dvAjusteDetalle(IndexView)!Total
                Next
                dtReport.Rows.Add(oAddRow)
                dtReport.AcceptChanges()

            End If
        Next

        Return dtReport

    End Function

    Public Function FormatGridToReportAJS() As DataTable
        Dim dtReport As New DataTable("Articulos")

        Dim oCol As DataColumn

        oCol = New DataColumn
        With oCol
            .ColumnName = "Codigo"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Descripcion"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        '-------------------------------------------------------------------
        ' JNAVA (17.05.2016): Se agrego color, marca y proveedor
        '-------------------------------------------------------------------
        oCol = New DataColumn
        With oCol
            .ColumnName = "Marca"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Proveedor"
            .DataType = GetType(System.String)
        End With
        dtReport.Columns.Add(oCol)
        '-------------------------------------------------------------------

        'Dim i As Integer
        'For i = 1 To 10
        '    oCol = New DataColumn
        '    With oCol
        '        .ColumnName = "T" & i
        '        .DataType = GetType(System.String)
        '    End With
        '    dtReport.Columns.Add(oCol)
        'Next

        'For i = 1 To 10
        '    oCol = New DataColumn
        '    With oCol
        '        .ColumnName = "C" & i
        '        .DataType = GetType(System.String)
        '    End With
        '    dtReport.Columns.Add(oCol)
        'Next

        oCol = New DataColumn
        With oCol
            .ColumnName = "Total"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "Importe"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With
        dtReport.Columns.Add(oCol)

        oCol = New DataColumn
        With oCol
            .ColumnName = "FolioSAP"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With
        dtReport.Columns.Add(oCol)

        For Each oNewRow As DataRow In Me.oAjusteAJS.Detalle.Rows
            Dim dvExiste As New DataView(dtReport, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)
            If dvExiste.Count = 0 Then

                Dim dvAjusteDetalle As New DataView(Me.oAjusteAJS.Detalle, "Codigo like'" & oNewRow("Codigo") & "'", "Codigo", DataViewRowState.CurrentRows)

                Dim oAddRow As DataRow = dtReport.NewRow
                oAddRow!Codigo = oNewRow!Codigo
                oAddRow!Descripcion = oNewRow!Descripcion
                oAddRow!FolioSAP = oNewRow!FolioSAP

                '-------------------------------------------------------------------
                ' JNAVA (17.05.2016): Obtenemos el color, marca y proveedor
                '-------------------------------------------------------------------
                Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                Dim oArticulo As Articulo = oArticuloMgr.Create
                oArticulo = oArticuloMgr.Load(CStr(oNewRow!Codigo))
                oAddRow!Marca = oArticulo.CodMarca
                oAddRow!Proveedor = oArticulo.CodArtProv
                oArticulo = Nothing
                oArticuloMgr = Nothing
                '-------------------------------------------------------------------

                Dim IndexView As Integer

                For IndexView = 0 To dvAjusteDetalle.Count - 1
                    'oAddRow("T" & IndexView + 1) = dvAjusteDetalle(IndexView)!Talla
                    'oAddRow("C" & IndexView + 1) = dvAjusteDetalle(IndexView)!Cantidad
                    oAddRow("Total") += dvAjusteDetalle(IndexView)!Cantidad 'Piezas
                    'oAddRow("Importe") += oNewRow("Total") ' Costo Total
                    'Correcion estaba sumando mal el importe cuando el codigo trae mas de 1 talla
                    oAddRow("Importe") += dvAjusteDetalle(IndexView)!Total
                Next
                dtReport.Rows.Add(oAddRow)
                dtReport.AcceptChanges()

            End If
        Next

        Return dtReport

    End Function

    Private Function ValidaAllRecordAJE() As Boolean
        If bolLoadForm = False Then
            Exit Function
        End If
        Dim i As Integer = 0
        For Each oRow As DataRow In Me.oAjusteAJE.Detalle.Rows

            ActualizaDatosArticulo(oRow, oRow!Codigo)
            '-----------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
            '-----------------------------------------------------------------------------
            'If IsDBNull(oRow!Cantidad) OrElse oRow!Talla = String.Empty Then
            '    MessageBox.Show("Capture Talla para el articulo " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    grdProductosAJE.Select()
            '    grdProductosAJE.Focus()
            '    grdProductosAJE.Row = i
            '    grdProductosAJE.Col = 2
            '    Return True
            '    Exit For
            'Else
            If IsDBNull(oRow!Cantidad) Then
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                'If Not FindTalla(oRow!Talla) Then
                '    MessageBox.Show("La talla no pertecene al Articulo.- " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    grdProductosAJE.Select()
                '    grdProductosAJE.Focus()
                '    grdProductosAJE.Row = i
                '    grdProductosAJE.Col = 2
                '    Return True
                '    Exit For
                'Else
                If BuscaCodigoEnAjusteAJE(oRow("Codigo"), i) > 0 Then
                    'MessageBox.Show("La talla ya fue asignada al Articulo.-  " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("El Articulo " & oRow("Codigo") & " ya fue capturado.", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grdProductosAJE.Select()
                    grdProductosAJE.Focus()
                    grdProductosAJE.Row = i
                    grdProductosAJE.Col = 2
                    Return True
                    Exit For
                Else
                    If IsDBNull(oRow!Cantidad) OrElse oRow!Cantidad = 0 Then
                        MessageBox.Show("Capture Cantidad para el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        grdProductosAJE.Select()
                        grdProductosAJE.Focus()
                        grdProductosAJE.Row = i
                        grdProductosAJE.Col = 3
                        Return True
                        Exit For
                    Else

                    End If
                End If
            End If
            'End If
            i += 1
        Next
        Return False
    End Function

    Private Function ValidaAllRecordAJS() As Boolean
        If bolLoadForm = False Then
            Exit Function
        End If
        Dim i As Integer = 0
        For Each oRow As DataRow In Me.oAjusteAJS.Detalle.Rows

            ActualizaDatosArticulo(oRow, oRow!Codigo)
            '-----------------------------------------------------------------------------
            ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
            '-----------------------------------------------------------------------------
            'If IsDBNull(oRow!Cantidad) OrElse oRow!Talla = String.Empty Then
            '    MessageBox.Show("Capture Talla para el articulo " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    grdProductosAJS.Select()
            '    grdProductosAJS.Focus()
            '    grdProductosAJS.Row = i
            '    grdProductosAJS.Col = 2
            '    Return True
            '    Exit For
            'Else
            If Not IsDBNull(oRow!Cantidad) Then
                '-----------------------------------------------------------------------------
                ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                '-----------------------------------------------------------------------------
                'If Not FindTalla(oRow!Talla) Then
                '    MessageBox.Show("La talla no pertecene al Articulo.- " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    grdProductosAJS.Select()
                '    grdProductosAJS.Focus()
                '    grdProductosAJS.Row = i
                '    grdProductosAJS.Col = 2
                '    Return True
                '    Exit For
                'Else
                If BuscaCodigoEnAjusteAJS(oRow("Codigo"), i) > 0 Then 'oRow!Talla, i) > 0 Then
                    'MessageBox.Show("La talla ya fue asignada al Articulo.-  " & oRow("Codigo"), "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("El Articulo " & oRow("Codigo") & " ya fue capturado.", "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grdProductosAJS.Select()
                    grdProductosAJS.Focus()
                    grdProductosAJS.Row = i
                    grdProductosAJS.Col = 2
                    Return True
                    Exit For
                Else
                    If IsDBNull(oRow!Cantidad) OrElse oRow!Cantidad = 0 Then
                        If Estado = "AUT" Then
                            Dim arts As Decimal = oAjusteMgr.Existencias(oRow!Codigo) ', oRow!Talla)
                            If arts > 0 Then
                                Dim strtxtmsg As String = "El articulo " & oRow!Codigo & " tiene en existencia " & CStr(arts) & " desea que el ajuste sea por esa cantidad?"
                                '"Tiene " & CStr(arts) & " Articulos en Existencias Deseas que el ajuste del codigo .- " & oRow!Codigo & " sea por esa cantidad"
                                If DialogResult.Yes = MessageBox.Show(strtxtmsg, "Ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                    Dim intRecord As Integer = grdProductosAJS.Row
                                    Me.oAjusteAJS.Detalle.Rows.RemoveAt(intRecord)
                                    Me.oAjusteAJS.Detalle.AcceptChanges()
                                    oRow!Cantidad = arts 'lo que tenga de existencias
                                    'Modificar el registro
                                    '-----------------------------------------------------------------------------
                                    ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                                    '-------------------------------------------------->-------------------<------
                                    oAjusteMgr.UpdateCantAJS(Me.AJS, oRow!Codigo, arts) ' oRow!Talla, arts)
                                    Return False
                                Else
                                    Return True
                                End If
                            Else
                                Dim strtxtmsg As String = "Desea eliminar el codigo .- " & oRow!Codigo & "?, No tiene existencias suficientes para dar salida"
                                If DialogResult.Yes = MessageBox.Show(strtxtmsg, "Ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                    'Borrar del ajuste de SALIDA de SQL
                                    '-----------------------------------------------------------------------------
                                    ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                                    '---------------------------------------------->--------------<----------------
                                    oAjusteMgr.DeleteCodigoAJS(Me.AJS, oRow!Codigo) ', oRow!Talla)
                                    'Borrar del GRID
                                    Dim intRecord As Integer = grdProductosAJS.Row
                                    Me.oAjusteAJS.Detalle.Rows.RemoveAt(intRecord)
                                    Me.oAjusteAJS.Detalle.AcceptChanges()
                                    'Para cancelarla si ya no quedo nada
                                    If oAjusteAJE.Detalle.Rows.Count <= 0 And oAjusteAJS.Detalle.Rows.Count <= 0 Then
                                        oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "CAN")
                                    End If
                                    Return False
                                Else
                                    Return True
                                End If
                            End If
                        Else
                            MessageBox.Show("Capture Cantidad para el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            grdProductosAJS.Select()
                            grdProductosAJS.Focus()
                            grdProductosAJS.Row = i
                            grdProductosAJS.Col = 3
                            Return True
                            Exit For
                        End If
                    Else
                        'Para validar la existencia cuando sea un ajuste de salida
                        Dim arts As Integer = oAjusteMgr.Existencias(oRow("Codigo")) ', oRow!Talla)
                        If oRow!Cantidad > arts Then
                            If Estado = "AUT" Then
                                If arts = 0 Then
                                    Dim strtxtmsg As String = "Desea eliminar el codigo .- " & oRow!Codigo & "?, No tiene existencias suficientes para dar salida"
                                    If DialogResult.Yes = MessageBox.Show(strtxtmsg, "Ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                        'Borrar del ajuste de SALIDA de SQL
                                        '-----------------------------------------------------------------------------
                                        ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                                        '---------------------------------------------->--------------<----------------
                                        oAjusteMgr.DeleteCodigoAJS(Me.AJS, oRow!Codigo) ', oRow!Talla)
                                        'Borrar del GRID
                                        Dim intRecord As Integer = grdProductosAJS.Row
                                        Me.oAjusteAJS.Detalle.Rows.RemoveAt(intRecord)
                                        Me.oAjusteAJS.Detalle.AcceptChanges()
                                        'Para cancelarla si ya no quedo nada
                                        If oAjusteAJE.Detalle.Rows.Count <= 0 And oAjusteAJS.Detalle.Rows.Count <= 0 Then
                                            oAjusteMgr.UpdateESNuevoEstado(Me.nbFolioAUT.Value, "CAN")
                                        End If
                                        Return False
                                    Else
                                        Return True
                                    End If
                                Else
                                    Dim strtxtmsg As String = "El articulo " & oRow!Codigo & " tiene en existencia " & CStr(arts) & " desea que el ajuste sea por esa cantidad ?"
                                    ' "Tiene " & CStr(arts) & " Articulos en Existencias Deseas que el ajuste del codigo .- " & oRow!Codigo & " sea por esa cantidad"
                                    If DialogResult.Yes = MessageBox.Show(strtxtmsg, "Ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                        Dim intRecord As Integer = grdProductosAJS.Row
                                        Me.oAjusteAJS.Detalle.Rows.RemoveAt(intRecord)
                                        Me.oAjusteAJS.Detalle.AcceptChanges()
                                        oRow!Cantidad = arts 'lo que tenga de existencias
                                        'Modificar el registro
                                        ' JNAVA (18.02.2016): Conetado por adecuaciones de Retail
                                        '-------------------------------------------------->-------------------<------
                                        oAjusteMgr.UpdateCantAJS(Me.AJS, oRow!Codigo, arts) ' oRow!Talla, arts)
                                        Return False
                                    Else
                                        Return True
                                    End If
                                End If
                            Else
                                MessageBox.Show("No tiene existencias el Articulo.- " & oRow!Codigo, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                grdProductosAJS.Select()
                                grdProductosAJS.Focus()
                                grdProductosAJS.Row = i
                                grdProductosAJS.Col = 3
                                oRow!Cantidad = arts
                                Return True
                                Exit For
                            End If
                        End If
                    End If
                End If
            End If
            'End If
            i += 1
        Next
        Return False
    End Function

#End Region

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal traspaso As DataTable) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        'dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        For Each oRow As DataRow In traspaso.Rows
            Dim row As DataRow = dtArticulos.NewRow()
            row("Codigo") = CStr(oRow!Codigo)
            'row("Talla") = CStr(oRow!Talla)
            row("Cantidad") = CInt(oRow!Cantidad)
            dtArticulos.Rows.Add(row)
        Next
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable, ByVal dtMaterialesLibres As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Not dtMaterialesLibres Is Nothing Then
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!Codigo)
                'Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtMaterialesLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "'") ' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

#End Region

    Private Sub cmbMovimiento_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbMovimiento.ValueChanged
        FillMotivos(cmbMovimiento.Value)
        BloqueaGridES()
    End Sub
End Class
