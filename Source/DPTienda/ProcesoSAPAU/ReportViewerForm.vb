Imports DataDynamics.ActiveReports

Public Class ReportViewerForm
    Inherits System.Windows.Forms.Form

    Private m_arReport As ActiveReport

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
    Friend WithEvents EnvironmentManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents EnvironmentMenuesBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents EnvironmentStandardBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents FileMenu As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ViewMenu As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileCloseCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileExportMenu As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileExportMenu1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileCloseCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileMenu1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ViewMenu1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Viewer1 As DataDynamics.ActiveReports.Viewer.Viewer
    Friend WithEvents Imprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Imprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ImprimirPartes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ImprimirPartes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents FileExportMenu2 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportViewerForm))
        Me.EnvironmentManager = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.EnvironmentMenuesBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.FileMenu1 = New Janus.Windows.UI.CommandBars.UICommand("FileMenu")
        Me.ViewMenu1 = New Janus.Windows.UI.CommandBars.UICommand("ViewMenu")
        Me.EnvironmentStandardBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.Imprimir1 = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ImprimirPartes1 = New Janus.Windows.UI.CommandBars.UICommand("ImprimirPartes")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.FileExportMenu2 = New Janus.Windows.UI.CommandBars.UICommand("FileExportMenu")
        Me.FileMenu = New Janus.Windows.UI.CommandBars.UICommand("FileMenu")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.FileExportMenu1 = New Janus.Windows.UI.CommandBars.UICommand("FileExportMenu")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.FileCloseCommand1 = New Janus.Windows.UI.CommandBars.UICommand("FileCloseCommand")
        Me.FileExportMenu = New Janus.Windows.UI.CommandBars.UICommand("FileExportMenu")
        Me.FileCloseCommand = New Janus.Windows.UI.CommandBars.UICommand("FileCloseCommand")
        Me.ViewMenu = New Janus.Windows.UI.CommandBars.UICommand("ViewMenu")
        Me.Imprimir = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.ImprimirPartes = New Janus.Windows.UI.CommandBars.UICommand("ImprimirPartes")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.Viewer1 = New DataDynamics.ActiveReports.Viewer.Viewer()
        CType(Me.EnvironmentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnvironmentMenuesBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnvironmentStandardBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnvironmentManager
        '
        Me.EnvironmentManager.BottomRebar = Me.BottomRebar1
        Me.EnvironmentManager.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><Customize>&amp;Person" & _
    "alizar...</Customize></LocalizableData>"
        UiCommandCategory1.CategoryName = "Archivo"
        UiCommandCategory2.CategoryName = "Ver"
        UiCommandCategory3.CategoryName = "Menús Integrados"
        Me.EnvironmentManager.Categories.AddRange(New Janus.Windows.UI.CommandBars.UICommandCategory() {UiCommandCategory1, UiCommandCategory2, UiCommandCategory3})
        Me.EnvironmentManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.EnvironmentMenuesBar, Me.EnvironmentStandardBar})
        Me.EnvironmentManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.FileMenu, Me.FileExportMenu, Me.FileCloseCommand, Me.ViewMenu, Me.Imprimir, Me.ImprimirPartes})
        Me.EnvironmentManager.ContainerControl = Me
        '
        '
        '
        Me.EnvironmentManager.EditContextMenu.Key = ""
        Me.EnvironmentManager.Id = New System.Guid("9a0924dc-d8aa-4425-89c0-764328fe2146")
        Me.EnvironmentManager.LeftRebar = Me.LeftRebar1
        Me.EnvironmentManager.RightRebar = Me.RightRebar1
        Me.EnvironmentManager.TopRebar = Me.TopRebar1
        Me.EnvironmentManager.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.EnvironmentManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'EnvironmentMenuesBar
        '
        Me.EnvironmentMenuesBar.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.EnvironmentMenuesBar.CommandManager = Me.EnvironmentManager
        Me.EnvironmentMenuesBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.FileMenu1, Me.ViewMenu1})
        Me.EnvironmentMenuesBar.Key = "Barra de Menús"
        Me.EnvironmentMenuesBar.Location = New System.Drawing.Point(0, 0)
        Me.EnvironmentMenuesBar.Name = "EnvironmentMenuesBar"
        Me.EnvironmentMenuesBar.RowIndex = 0
        Me.EnvironmentMenuesBar.Size = New System.Drawing.Size(848, 22)
        Me.EnvironmentMenuesBar.Text = "Barra de Menús"
        '
        'FileMenu1
        '
        Me.FileMenu1.Key = "FileMenu"
        Me.FileMenu1.Name = "FileMenu1"
        '
        'ViewMenu1
        '
        Me.ViewMenu1.Key = "ViewMenu"
        Me.ViewMenu1.Name = "ViewMenu1"
        '
        'EnvironmentStandardBar
        '
        Me.EnvironmentStandardBar.CommandManager = Me.EnvironmentManager
        Me.EnvironmentStandardBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Imprimir1, Me.Separator3, Me.ImprimirPartes1, Me.Separator4, Me.FileExportMenu2})
        Me.EnvironmentStandardBar.Key = "Estándar"
        Me.EnvironmentStandardBar.Location = New System.Drawing.Point(0, 22)
        Me.EnvironmentStandardBar.Name = "EnvironmentStandardBar"
        Me.EnvironmentStandardBar.RowIndex = 1
        Me.EnvironmentStandardBar.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.EnvironmentStandardBar.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.EnvironmentStandardBar.Size = New System.Drawing.Size(422, 28)
        Me.EnvironmentStandardBar.Text = "Estándar"
        '
        'Imprimir1
        '
        Me.Imprimir1.Key = "Imprimir"
        Me.Imprimir1.Name = "Imprimir1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'ImprimirPartes1
        '
        Me.ImprimirPartes1.Key = "ImprimirPartes"
        Me.ImprimirPartes1.Name = "ImprimirPartes1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'FileExportMenu2
        '
        Me.FileExportMenu2.Key = "FileExportMenu"
        Me.FileExportMenu2.Name = "FileExportMenu2"
        '
        'FileMenu
        '
        Me.FileMenu.CategoryName = "Menús Integrados"
        Me.FileMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Separator1, Me.FileExportMenu1, Me.Separator2, Me.FileCloseCommand1})
        Me.FileMenu.Key = "FileMenu"
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Text = "&Archivo"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'FileExportMenu1
        '
        Me.FileExportMenu1.Key = "FileExportMenu"
        Me.FileExportMenu1.Name = "FileExportMenu1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'FileCloseCommand1
        '
        Me.FileCloseCommand1.Key = "FileCloseCommand"
        Me.FileCloseCommand1.Name = "FileCloseCommand1"
        '
        'FileExportMenu
        '
        Me.FileExportMenu.CategoryName = "Archivo"
        Me.FileExportMenu.Image = CType(resources.GetObject("FileExportMenu.Image"), System.Drawing.Image)
        Me.FileExportMenu.Key = "FileExportMenu"
        Me.FileExportMenu.Name = "FileExportMenu"
        Me.FileExportMenu.Text = "&Exportar"
        '
        'FileCloseCommand
        '
        Me.FileCloseCommand.CategoryName = "Archivo"
        Me.FileCloseCommand.Key = "FileCloseCommand"
        Me.FileCloseCommand.Name = "FileCloseCommand"
        Me.FileCloseCommand.Text = "&Cerrar"
        '
        'ViewMenu
        '
        Me.ViewMenu.CategoryName = "Menús Integrados"
        Me.ViewMenu.Key = "ViewMenu"
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Text = "&Ver"
        '
        'Imprimir
        '
        Me.Imprimir.Image = CType(resources.GetObject("Imprimir.Image"), System.Drawing.Image)
        Me.Imprimir.Key = "Imprimir"
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Text = "&Imprimir Todo   "
        '
        'ImprimirPartes
        '
        Me.ImprimirPartes.CategoryName = "Archivo"
        Me.ImprimirPartes.Image = CType(resources.GetObject("ImprimirPartes.Image"), System.Drawing.Image)
        Me.ImprimirPartes.Key = "ImprimirPartes"
        Me.ImprimirPartes.Name = "ImprimirPartes"
        Me.ImprimirPartes.Text = "Im&primir (Personalizado)   "
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.EnvironmentManager
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.EnvironmentManager
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.EnvironmentMenuesBar, Me.EnvironmentStandardBar})
        Me.TopRebar1.CommandManager = Me.EnvironmentManager
        Me.TopRebar1.Controls.Add(Me.EnvironmentMenuesBar)
        Me.TopRebar1.Controls.Add(Me.EnvironmentStandardBar)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(848, 50)
        '
        'Viewer1
        '
        Me.Viewer1.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer1.Document = New DataDynamics.ActiveReports.Document.Document("ARNet Document")
        Me.Viewer1.Location = New System.Drawing.Point(0, 50)
        Me.Viewer1.Name = "Viewer1"
        Me.Viewer1.ReportViewer.CurrentPage = 0
        Me.Viewer1.ReportViewer.MultiplePageCols = 3
        Me.Viewer1.ReportViewer.MultiplePageRows = 2
        Me.Viewer1.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.Viewer1.Size = New System.Drawing.Size(848, 387)
        Me.Viewer1.TabIndex = 2
        Me.Viewer1.TableOfContents.Text = "Contents"
        Me.Viewer1.TableOfContents.Width = 200
        Me.Viewer1.TabTitleLength = 35
        Me.Viewer1.Toolbar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ReportViewerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(848, 437)
        Me.Controls.Add(Me.Viewer1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportViewerForm"
        Me.Text = "Vista preliminar"
        CType(Me.EnvironmentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnvironmentMenuesBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnvironmentStandardBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property Report() As ActiveReport
        Get
            Return m_arReport
        End Get
        Set(ByVal Value As ActiveReport)
            m_arReport = Value

            SetUpViewer()
        End Set
    End Property

    Private Sub SetUpViewer()

        If (Not m_arReport Is Nothing) Then

            Viewer1.Document = m_arReport.Document

            If (m_arReport.Document.Name <> "ActiveReport Document") Then

                Me.Text = "Vista preliminar - " & m_arReport.Document.Name

            End If

        End If

    End Sub

    Private Sub EnvironmentManager_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles EnvironmentManager.CommandClick

        Select Case e.Command.Key

            Case FileExportMenu.Key

                ActionExportFile()

                'Viewer1.Document = Nothing
                'Viewer1.Refresh()

            Case Imprimir.Key

                Me.Report.Document.Print(False, False)

            Case ImprimirPartes.Key

                Me.Report.Document.Print(True, True)

            Case FileCloseCommand.Key

                Me.Close()

        End Select

    End Sub

    Public Sub ActionExportFile()

        If (Viewer1.Document Is Nothing) Then
            Exit Sub
        End If

        Dim f As ExportForm = New ExportForm(Viewer1.Document)
        f.ShowDialog(Me)


    End Sub

    Private Sub Viewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Viewer1.Load

        Viewer1.Toolbar.Tools(1).Visible = False
        Viewer1.Toolbar.Tools(2).Visible = False

    End Sub

End Class