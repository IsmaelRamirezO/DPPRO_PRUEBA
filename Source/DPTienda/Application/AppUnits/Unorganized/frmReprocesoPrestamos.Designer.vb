<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReprocesoPrestamos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReprocesoPrestamos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel2 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel3 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ToolbarReprocesoPrestamo = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.tbNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.MnuActualizar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuActualizar")
        Me.tbReproceso1 = New Janus.Windows.UI.CommandBars.UICommand("tbReproceso")
        Me.tbSalir1 = New Janus.Windows.UI.CommandBars.UICommand("tbSalir")
        Me.tbNuevo = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.tbReproceso = New Janus.Windows.UI.CommandBars.UICommand("tbReproceso")
        Me.tbCancelar = New Janus.Windows.UI.CommandBars.UICommand("tbCancelar")
        Me.tbSalir = New Janus.Windows.UI.CommandBars.UICommand("tbSalir")
        Me.MnuActualizar = New Janus.Windows.UI.CommandBars.UICommand("MnuActualizar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.gridCreditos = New Janus.Windows.GridEX.GridEX()
        Me.EstatusPrestamo = New Janus.Windows.UI.StatusBar.UIStatusBar()
        CType(Me.ToolbarReprocesoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.gridCreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolbarReprocesoPrestamo
        '
        Me.ToolbarReprocesoPrestamo.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarReprocesoPrestamo.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarReprocesoPrestamo.AllowMerge = False
        Me.ToolbarReprocesoPrestamo.BottomRebar = Me.BottomRebar1
        Me.ToolbarReprocesoPrestamo.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.ToolbarReprocesoPrestamo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbNuevo, Me.tbReproceso, Me.tbCancelar, Me.tbSalir, Me.MnuActualizar})
        Me.ToolbarReprocesoPrestamo.ContainerControl = Me
        '
        '
        '
        Me.ToolbarReprocesoPrestamo.EditContextMenu.Key = ""
        Me.ToolbarReprocesoPrestamo.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.ToolbarReprocesoPrestamo.LeftRebar = Me.LeftRebar1
        Me.ToolbarReprocesoPrestamo.LockCommandBars = True
        Me.ToolbarReprocesoPrestamo.RightRebar = Me.RightRebar1
        Me.ToolbarReprocesoPrestamo.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarReprocesoPrestamo.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarReprocesoPrestamo.ShowQuickCustomizeMenu = False
        Me.ToolbarReprocesoPrestamo.TopRebar = Me.TopRebar1
        Me.ToolbarReprocesoPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.ToolbarReprocesoPrestamo
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.ToolbarReprocesoPrestamo
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbNuevo1, Me.MnuActualizar1, Me.tbReproceso1, Me.tbSalir1})
        Me.UiCommandBar2.Key = "tbDispersion"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.Size = New System.Drawing.Size(222, 28)
        Me.UiCommandBar2.Text = "CommandBar1"
        '
        'tbNuevo1
        '
        Me.tbNuevo1.Image = CType(resources.GetObject("tbNuevo1.Image"), System.Drawing.Image)
        Me.tbNuevo1.Key = "tbNuevo"
        Me.tbNuevo1.Name = "tbNuevo1"
        Me.tbNuevo1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MnuActualizar1
        '
        Me.MnuActualizar1.Image = CType(resources.GetObject("MnuActualizar1.Image"), System.Drawing.Image)
        Me.MnuActualizar1.Key = "MnuActualizar"
        Me.MnuActualizar1.Name = "MnuActualizar1"
        '
        'tbReproceso1
        '
        Me.tbReproceso1.Image = CType(resources.GetObject("tbReproceso1.Image"), System.Drawing.Image)
        Me.tbReproceso1.Key = "tbReproceso"
        Me.tbReproceso1.Name = "tbReproceso1"
        '
        'tbSalir1
        '
        Me.tbSalir1.Image = CType(resources.GetObject("tbSalir1.Image"), System.Drawing.Image)
        Me.tbSalir1.Key = "tbSalir"
        Me.tbSalir1.Name = "tbSalir1"
        '
        'tbNuevo
        '
        Me.tbNuevo.Key = "tbNuevo"
        Me.tbNuevo.Name = "tbNuevo"
        Me.tbNuevo.Text = "Nuevo"
        '
        'tbReproceso
        '
        Me.tbReproceso.Key = "tbReproceso"
        Me.tbReproceso.Name = "tbReproceso"
        Me.tbReproceso.Text = "Reproceso"
        '
        'tbCancelar
        '
        Me.tbCancelar.Key = "tbCancelar"
        Me.tbCancelar.Name = "tbCancelar"
        Me.tbCancelar.Text = "Cancelar"
        '
        'tbSalir
        '
        Me.tbSalir.Key = "tbSalir"
        Me.tbSalir.Name = "tbSalir"
        Me.tbSalir.Text = "Salir"
        '
        'MnuActualizar
        '
        Me.MnuActualizar.Key = "MnuActualizar"
        Me.MnuActualizar.Name = "MnuActualizar"
        Me.MnuActualizar.Text = "Actualizar"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.ToolbarReprocesoPrestamo
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.ToolbarReprocesoPrestamo
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.ToolbarReprocesoPrestamo
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(908, 28)
        '
        'gridCreditos
        '
        Me.gridCreditos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridCreditos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridCreditos.DesignTimeLayout = GridEXLayout1
        Me.gridCreditos.ErrorImageIndex = -1
        Me.gridCreditos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridCreditos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.gridCreditos.GroupByBoxVisible = False
        Me.gridCreditos.Location = New System.Drawing.Point(0, 28)
        Me.gridCreditos.Name = "gridCreditos"
        Me.gridCreditos.Size = New System.Drawing.Size(908, 273)
        Me.gridCreditos.TabIndex = 188
        Me.gridCreditos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EstatusPrestamo
        '
        Me.EstatusPrestamo.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstatusPrestamo.Dock = System.Windows.Forms.DockStyle.None
        Me.EstatusPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstatusPrestamo.Location = New System.Drawing.Point(0, 299)
        Me.EstatusPrestamo.Name = "EstatusPrestamo"
        UiStatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Width = 239
        UiStatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel2.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel2.Key = "PanelPrestamo"
        UiStatusBarPanel2.ProgressBarValue = 0
        UiStatusBarPanel2.Text = "F2 Reproceso"
        UiStatusBarPanel2.Width = 239
        UiStatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel3.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel3.Key = ""
        UiStatusBarPanel3.ProgressBarValue = 0
        UiStatusBarPanel3.Text = "ESC  Salir"
        UiStatusBarPanel3.Width = 239
        Me.EstatusPrestamo.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1, UiStatusBarPanel2, UiStatusBarPanel3})
        Me.EstatusPrestamo.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.EstatusPrestamo.Size = New System.Drawing.Size(908, 27)
        Me.EstatusPrestamo.TabIndex = 189
        Me.EstatusPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmReprocesoPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(908, 323)
        Me.Controls.Add(Me.EstatusPrestamo)
        Me.Controls.Add(Me.gridCreditos)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReprocesoPrestamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reprocesar Prestamos"
        CType(Me.ToolbarReprocesoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.gridCreditos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolbarReprocesoPrestamo As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents tbNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbReproceso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbReproceso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents gridCreditos As Janus.Windows.GridEX.GridEX
    Friend WithEvents EstatusPrestamo As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents MnuActualizar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuActualizar As Janus.Windows.UI.CommandBars.UICommand
End Class
