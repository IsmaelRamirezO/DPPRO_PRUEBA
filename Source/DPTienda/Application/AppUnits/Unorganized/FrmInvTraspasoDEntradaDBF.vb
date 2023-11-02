
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Imports Janus.Windows.GridEX



Public Class FrmInvTraspasoDEntradaDBF
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents npArticulo As PureComponents.NicePanel.NicePanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebSucOrigen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestino As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GrdTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents btGenerarCorrida As Janus.Windows.EditControls.UIButton
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btNuevo As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvTraspasoDEntradaDBF))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.npArticulo = New PureComponents.NicePanel.NicePanel()
        Me.btNuevo = New Janus.Windows.EditControls.UIButton()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrdTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.btGenerarCorrida = New Janus.Windows.EditControls.UIButton()
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebSucDestino = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebSucOrigen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.npArticulo.SuspendLayout()
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'npArticulo
        '
        Me.npArticulo.BackColor = System.Drawing.Color.Transparent
        Me.npArticulo.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.npArticulo.ContainerImage = ContainerImage1
        Me.npArticulo.ContextMenuButton = False
        Me.npArticulo.Controls.Add(Me.btNuevo)
        Me.npArticulo.Controls.Add(Me.ebFolio)
        Me.npArticulo.Controls.Add(Me.Label6)
        Me.npArticulo.Controls.Add(Me.btGuardar)
        Me.npArticulo.Controls.Add(Me.GrdTraspasoCorrida)
        Me.npArticulo.Controls.Add(Me.btGenerarCorrida)
        Me.npArticulo.Controls.Add(Me.ebImporte)
        Me.npArticulo.Controls.Add(Me.ebFecha)
        Me.npArticulo.Controls.Add(Me.Label5)
        Me.npArticulo.Controls.Add(Me.ebGuia)
        Me.npArticulo.Controls.Add(Me.Label4)
        Me.npArticulo.Controls.Add(Me.ebUsuario)
        Me.npArticulo.Controls.Add(Me.Label3)
        Me.npArticulo.Controls.Add(Me.Label2)
        Me.npArticulo.Controls.Add(Me.ebSucDestino)
        Me.npArticulo.Controls.Add(Me.Label1)
        Me.npArticulo.Controls.Add(Me.ebSucOrigen)
        Me.npArticulo.Controls.Add(Me.Label11)
        Me.npArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.npArticulo.FooterImage = HeaderImage1
        Me.npArticulo.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npArticulo.FooterVisible = False
        Me.npArticulo.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Block
        HeaderImage2.Image = Nothing
        Me.npArticulo.HeaderImage = HeaderImage2
        Me.npArticulo.HeaderText = "Traspaso Entrada DBF"
        Me.npArticulo.IsExpanded = True
        Me.npArticulo.Location = New System.Drawing.Point(-8, -1)
        Me.npArticulo.Name = "npArticulo"
        Me.npArticulo.OriginalFooterVisible = False
        Me.npArticulo.OriginalHeight = 0
        Me.npArticulo.Size = New System.Drawing.Size(864, 457)
        ContainerStyle1.BackColor = System.Drawing.SystemColors.Control
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.SystemColors.ControlDark
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Dot
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.SystemColors.ControlLightLight
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.Transparent
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.SystemColors.ControlLightLight
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.npArticulo.Style = PanelStyle1
        Me.npArticulo.TabIndex = 54
        Me.npArticulo.TabStop = False
        '
        'btNuevo
        '
        Me.btNuevo.Image = CType(resources.GetObject("btNuevo.Image"), System.Drawing.Image)
        Me.btNuevo.Location = New System.Drawing.Point(256, 416)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(104, 32)
        Me.btNuevo.TabIndex = 70
        Me.btNuevo.Text = "Nuevo"
        Me.btNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.Color.White
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.Location = New System.Drawing.Point(752, 32)
        Me.ebFolio.MaxLength = 3
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(96, 22)
        Me.ebFolio.TabIndex = 68
        Me.ebFolio.TabStop = False
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(656, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Suc. Destino"
        '
        'btGuardar
        '
        Me.btGuardar.Image = CType(resources.GetObject("btGuardar.Image"), System.Drawing.Image)
        Me.btGuardar.Location = New System.Drawing.Point(136, 416)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 32)
        Me.btGuardar.TabIndex = 7
        Me.btGuardar.Text = "Guardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GrdTraspasoCorrida
        '
        Me.GrdTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GrdTraspasoCorrida.BorderStyle = Janus.Windows.GridEX.BorderStyle.None
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasoCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdTraspasoCorrida.GroupByBoxVisible = False
        Me.GrdTraspasoCorrida.Location = New System.Drawing.Point(15, 144)
        Me.GrdTraspasoCorrida.Name = "GrdTraspasoCorrida"
        Me.GrdTraspasoCorrida.Size = New System.Drawing.Size(840, 256)
        Me.GrdTraspasoCorrida.TabIndex = 67
        Me.GrdTraspasoCorrida.TabStop = False
        Me.GrdTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btGenerarCorrida
        '
        Me.btGenerarCorrida.Image = CType(resources.GetObject("btGenerarCorrida.Image"), System.Drawing.Image)
        Me.btGenerarCorrida.Location = New System.Drawing.Point(16, 416)
        Me.btGenerarCorrida.Name = "btGenerarCorrida"
        Me.btGenerarCorrida.Size = New System.Drawing.Size(104, 32)
        Me.btGenerarCorrida.TabIndex = 6
        Me.btGenerarCorrida.Text = "Generar Corrida"
        Me.btGenerarCorrida.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebImporte
        '
        Me.ebImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporte.BackColor = System.Drawing.Color.White
        Me.ebImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporte.Location = New System.Drawing.Point(105, 62)
        Me.ebImporte.MaxLength = 9
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.Size = New System.Drawing.Size(112, 22)
        Me.ebImporte.TabIndex = 2
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(360, 94)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(136, 22)
        Me.ebFecha.TabIndex = 5
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(264, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Fecha"
        '
        'ebGuia
        '
        Me.ebGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebGuia.BackColor = System.Drawing.Color.White
        Me.ebGuia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebGuia.Location = New System.Drawing.Point(104, 88)
        Me.ebGuia.MaxLength = 20
        Me.ebGuia.Name = "ebGuia"
        Me.ebGuia.Size = New System.Drawing.Size(80, 22)
        Me.ebGuia.TabIndex = 4
        Me.ebGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 19)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Guia"
        '
        'ebUsuario
        '
        Me.ebUsuario.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuario.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuario.BackColor = System.Drawing.Color.White
        Me.ebUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuario.Location = New System.Drawing.Point(360, 65)
        Me.ebUsuario.MaxLength = 20
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.Size = New System.Drawing.Size(136, 22)
        Me.ebUsuario.TabIndex = 3
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Importe"
        '
        'ebSucDestino
        '
        Me.ebSucDestino.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestino.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestino.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucDestino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestino.Location = New System.Drawing.Point(360, 36)
        Me.ebSucDestino.MaxLength = 3
        Me.ebSucDestino.Name = "ebSucDestino"
        Me.ebSucDestino.ReadOnly = True
        Me.ebSucDestino.Size = New System.Drawing.Size(69, 22)
        Me.ebSucDestino.TabIndex = 1
        Me.ebSucDestino.TabStop = False
        Me.ebSucDestino.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(264, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Suc. Destino"
        '
        'ebSucOrigen
        '
        Me.ebSucOrigen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucOrigen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucOrigen.BackColor = System.Drawing.Color.White
        Me.ebSucOrigen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucOrigen.Location = New System.Drawing.Point(104, 36)
        Me.ebSucOrigen.MaxLength = 3
        Me.ebSucOrigen.Name = "ebSucOrigen"
        Me.ebSucOrigen.Size = New System.Drawing.Size(69, 22)
        Me.ebSucOrigen.TabIndex = 0
        Me.ebSucOrigen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucOrigen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Suc. Origen"
        '
        'FrmInvTraspasoDEntradaDBF
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(848, 453)
        Me.Controls.Add(Me.npArticulo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInvTraspasoDEntradaDBF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInvTraspasoDEntradaDBF"
        Me.npArticulo.ResumeLayout(False)
        Me.npArticulo.PerformLayout()
        CType(Me.GrdTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region




#Region "Variables Miembros"

    Private oTraspasoSalida As TraspasoSalida

    Private oTraspasoSalidaMgr As TraspasosSalidaManager

    Private dsTraspasoCorrida As DataSet

#End Region




#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oTraspasoSalidaMgr = New TraspasosSalidaManager(oAppContext)

        ebFecha.Value = Date.Today

        ebSucDestino.Text = oAppContext.ApplicationConfiguration.Almacen

    End Sub




    Private Sub Sm_Finalizar()

        oTraspasoSalida = Nothing

        oTraspasoSalidaMgr = Nothing

        dsTraspasoCorrida = Nothing

    End Sub




    Private Sub Sm_GuardarTraspaso()

        oTraspasoSalida = Nothing

        oTraspasoSalida = oTraspasoSalidaMgr.Create



        With oTraspasoSalida

            oTraspasoSalida.Observaciones = String.Empty

            oTraspasoSalida.Guia = ebGuia.Text

            oTraspasoSalida.Cargos = 0

            oTraspasoSalida.SubTotal = ebImporte.Text

            oTraspasoSalida.TraspasoCreadoEl = Format(ebFecha.Value, "Short Date")

            oTraspasoSalida.Status = "TRA"

            oTraspasoSalida.AlmacenDestinoID = ebSucDestino.Text 'oAlmacenDestino.ID

            oTraspasoSalida.AlmacenOrigenID = ebSucOrigen.Text  'oAppContext.ApplicationConfiguration.Almacen

            oTraspasoSalida.TraspasoID = 0

            oTraspasoSalida.Folio = String.Empty

            oTraspasoSalida.Detalle = dsTraspasoCorrida

            oTraspasoSalidaMgr.SaveDBF(oTraspasoSalida)

            ebFolio.Text = oTraspasoSalida.Folio

        End With


        MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub




    Private Sub Sm_GenerarCorrida()

        dsTraspasoCorrida = Nothing

        dsTraspasoCorrida = oTraspasoSalidaMgr.GenerarTraspasoCorridaDBF("[RefCruzTraspasoDBF]")


        GrdTraspasoCorrida.DataSource = dsTraspasoCorrida.Tables(0)
        GrdTraspasoCorrida.RetrieveStructure()

        Sm_SetpView()

    End Sub



    Private Sub Sm_SetpView()

        With GrdTraspasoCorrida.Tables(0)

            .Columns("CodArticulo").Width = 100
            .Columns("CodArticulo").Caption = "Código"
            .Columns("CodArticulo").Visible = True

            .Columns("CodCorrida").Width = 45
            .Columns("CodCorrida").Caption = "Corrida"
            .Columns("CodCorrida").Visible = True

            .Columns("CostoUnit").Width = 60
            .Columns("CostoUnit").Caption = "CostoUnit"
            .Columns("CostoUnit").Visible = True
            .Columns("CostoUnit").FormatString = "n"

            .Columns("TraspasoID").Visible = False
            .Columns("CodUnidad").Visible = False
            .Columns("CodAlmacen").Visible = False

            .Columns("Folio").Visible = False

            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("Cantidad").Width = 50
            .Columns("Cantidad").Caption = "Cantidad"
            .Columns("Cantidad").Visible = True

            .Columns("CostoTotal").Width = 60
            .Columns("CostoTotal").Caption = "CostoTotal"
            .Columns("CostoTotal").Visible = True
            .Columns("CostoTotal").FormatString = "n"

            .Columns("C01").Width = 30
            .Columns("C01").FormatString = "n"
            .Columns("C01").Visible = True

            .Columns("C02").Width = 30
            .Columns("C02").FormatString = "n"
            .Columns("C02").Visible = True

            .Columns("C03").Width = 30
            .Columns("C03").FormatString = "n"
            .Columns("C03").Visible = True

            .Columns("C04").Width = 30
            .Columns("C04").FormatString = "n"
            .Columns("C04").Visible = True

            .Columns("C05").Width = 30
            .Columns("C05").FormatString = "n"
            .Columns("C05").Visible = True

            .Columns("C06").Width = 30
            .Columns("C06").FormatString = "n"
            .Columns("C06").Visible = True

            .Columns("C07").Width = 30
            .Columns("C07").FormatString = "n"
            .Columns("C07").Visible = True

            .Columns("C08").Width = 30
            .Columns("C08").FormatString = "n"
            .Columns("C08").Visible = True

            .Columns("C09").Width = 30
            .Columns("C09").FormatString = "n"
            .Columns("C09").Visible = True

            .Columns("C10").Width = 30
            .Columns("C10").FormatString = "n"
            .Columns("C10").Visible = True

            .Columns("C11").Width = 30
            .Columns("C11").FormatString = "n"
            .Columns("C11").Visible = True

            .Columns("C12").Width = 30
            .Columns("C12").FormatString = "n"
            .Columns("C12").Visible = True

            .Columns("C13").Width = 30
            .Columns("C13").FormatString = "n"
            .Columns("C13").Visible = True

            .Columns("C14").Width = 30
            .Columns("C14").FormatString = "n"
            .Columns("C14").Visible = True

            .Columns("C15").Width = 30
            .Columns("C15").FormatString = "n"
            .Columns("C15").Visible = True

            .Columns("C16").Width = 30
            .Columns("C16").FormatString = "n"
            .Columns("C16").Visible = True

            .Columns("C17").Width = 30
            .Columns("C17").FormatString = "n"
            .Columns("C17").Visible = True

            .Columns("C18").Width = 30
            .Columns("C18").FormatString = "n"
            .Columns("C18").Visible = True

            .Columns("C19").Width = 30
            .Columns("C19").FormatString = "n"
            .Columns("C19").Visible = True

            .Columns("C20").Width = 30
            .Columns("C20").FormatString = "n"
            .Columns("C20").Visible = True



            On Error Resume Next

            .Columns("NumInicio").Visible = False
            .Columns("NumFin").Visible = False
            .Columns("Salto").Visible = False
            .Columns("Tope").Visible = False

        End With

    End Sub




    Private Sub Sm_Nuevo()

        ebSucOrigen.Text = String.Empty

        ebImporte.Text = String.Empty

        ebUsuario.Text = String.Empty

        ebGuia.Text = String.Empty

        GrdTraspasoCorrida.DataSource = Nothing



        ebSucDestino.Text = oAppContext.ApplicationConfiguration.Almacen

        ebFecha.Value = Date.Today

        ebSucOrigen.Focus()

    End Sub

#End Region





#Region "Métodos Privados [Eventos]"

    Private Sub FrmInvTraspasoDEntradaDBF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub




    Private Sub FrmInvTraspasoDEntradaDBF_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub




    Private Sub FrmInvTraspasoDEntradaDBF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub




    Private Sub btGenerarCorrida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGenerarCorrida.Click

        Sm_GenerarCorrida()

    End Sub




    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click

        Sm_GuardarTraspaso()

    End Sub



    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click

        Sm_Nuevo()

    End Sub

#End Region

End Class
