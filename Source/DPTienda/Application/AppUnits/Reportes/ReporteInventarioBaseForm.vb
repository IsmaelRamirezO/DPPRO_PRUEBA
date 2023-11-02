Public Class ReporteInventarioBaseForm
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
    Friend WithEvents uicmEnvironment As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents uicbEnvironmentMenusBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents uicbEnvironmentStandardBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents ArchivoSalirCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoSalirCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents btnGenerateReport As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteInventarioBaseForm))
        Me.uicmEnvironment = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.uicbEnvironmentMenusBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ArchivoCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCommand")
        Me.uicbEnvironmentStandardBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ArchivoCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCommand")
        Me.ArchivoSalirCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoSalirCommand")
        Me.ArchivoSalirCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoSalirCommand")
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnGenerateReport = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uicbEnvironmentStandardBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'uicmEnvironment
        '
        Me.uicmEnvironment.BottomRebar = Me.BottomRebar1
        UiCommandCategory1.CategoryName = "Archivo"
        UiCommandCategory2.CategoryName = "Ayuda"
        UiCommandCategory3.CategoryName = "Menús Integrados"
        Me.uicmEnvironment.Categories.AddRange(New Janus.Windows.UI.CommandBars.UICommandCategory() {UiCommandCategory1, UiCommandCategory2, UiCommandCategory3})
        Me.uicmEnvironment.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar, Me.uicbEnvironmentStandardBar})
        Me.uicmEnvironment.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoCommand, Me.ArchivoSalirCommand})
        Me.uicmEnvironment.ContainerControl = Me
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        Me.uicmEnvironment.Id = New System.Guid("cde494d7-1b47-454c-9ecf-b70a6cc9737f")
        Me.uicmEnvironment.LeftRebar = Me.LeftRebar1
        Me.uicmEnvironment.RightRebar = Me.RightRebar1
        Me.uicmEnvironment.TopRebar = Me.TopRebar1
        Me.uicmEnvironment.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uicbEnvironmentMenusBar
        '
        Me.uicbEnvironmentMenusBar.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.uicbEnvironmentMenusBar.CommandManager = Me.uicmEnvironment
        Me.uicbEnvironmentMenusBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoCommand1})
        Me.uicbEnvironmentMenusBar.Key = "Barra de Menus"
        Me.uicbEnvironmentMenusBar.Location = New System.Drawing.Point(0, 0)
        Me.uicbEnvironmentMenusBar.Name = "uicbEnvironmentMenusBar"
        Me.uicbEnvironmentMenusBar.RowIndex = 0
        Me.uicbEnvironmentMenusBar.Size = New System.Drawing.Size(512, 22)
        Me.uicbEnvironmentMenusBar.Text = "Barra de Menús"
        '
        'ArchivoCommand1
        '
        Me.ArchivoCommand1.Key = "ArchivoCommand"
        Me.ArchivoCommand1.Name = "ArchivoCommand1"
        '
        'uicbEnvironmentStandardBar
        '
        Me.uicbEnvironmentStandardBar.CommandManager = Me.uicmEnvironment
        Me.uicbEnvironmentStandardBar.Key = "Standard"
        Me.uicbEnvironmentStandardBar.Location = New System.Drawing.Point(0, 22)
        Me.uicbEnvironmentStandardBar.Name = "uicbEnvironmentStandardBar"
        Me.uicbEnvironmentStandardBar.RowIndex = 1
        Me.uicbEnvironmentStandardBar.Size = New System.Drawing.Size(49, 26)
        Me.uicbEnvironmentStandardBar.Text = "Standard"
        '
        'ArchivoCommand
        '
        Me.ArchivoCommand.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoSalirCommand1})
        Me.ArchivoCommand.Key = "ArchivoCommand"
        Me.ArchivoCommand.Name = "ArchivoCommand"
        Me.ArchivoCommand.Text = "&Archivo"
        '
        'ArchivoSalirCommand1
        '
        Me.ArchivoSalirCommand1.Key = "ArchivoSalirCommand"
        Me.ArchivoSalirCommand1.Name = "ArchivoSalirCommand1"
        '
        'ArchivoSalirCommand
        '
        Me.ArchivoSalirCommand.CategoryName = "Archivo"
        Me.ArchivoSalirCommand.Key = "ArchivoSalirCommand"
        Me.ArchivoSalirCommand.Name = "ArchivoSalirCommand"
        Me.ArchivoSalirCommand.Text = "&Salir"
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar, Me.uicbEnvironmentStandardBar})
        Me.TopRebar1.CommandManager = Me.uicmEnvironment
        Me.TopRebar1.Controls.Add(Me.uicbEnvironmentMenusBar)
        Me.TopRebar1.Controls.Add(Me.uicbEnvironmentStandardBar)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(512, 48)
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.uicmEnvironment
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.uicmEnvironment
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.uicmEnvironment
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Rebar
        Me.UiGroupBox1.Controls.Add(Me.btnGenerateReport)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 48)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(512, 64)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateReport.Location = New System.Drawing.Point(432, 32)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(72, 24)
        Me.btnGenerateReport.TabIndex = 0
        Me.btnGenerateReport.Text = "Generar"
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.UiGroupBox2.Controls.Add(Me.GridEX1)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 112)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.UiGroupBox2.Size = New System.Drawing.Size(512, 149)
        Me.UiGroupBox2.TabIndex = 3
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'GridEX1
        '
        Me.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEX1.EmptyRows = True
        Me.GridEX1.Location = New System.Drawing.Point(4, 4)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.Size = New System.Drawing.Size(504, 141)
        Me.GridEX1.TabIndex = 0
        '
        'ReporteInventarioBaseForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 261)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReporteInventarioBaseForm"
        Me.Text = "Reporte de Inventario"
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uicbEnvironmentStandardBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
