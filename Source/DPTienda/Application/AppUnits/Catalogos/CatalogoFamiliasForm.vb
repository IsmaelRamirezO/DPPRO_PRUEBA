
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias

Public Class CatalogoFamiliasForm
    Inherits System.Windows.Forms.Form

#Region " C�digo generado por el Dise�ador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Dise�ador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicializaci�n despu�s de la llamada a InitializeComponent()

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

    'Requerido por el Dise�ador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Dise�ador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Dise�ador de Windows Forms. 
    'No lo modifique con el editor de c�digo.
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema3 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoFamiliasForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaAcerca1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema3 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalogo, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAyudaTema, Me.menuAyudaAcerca, Me.menuAbrir})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("126e35d0-2390-4cfa-ba06-41328dcc3560")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.TabIndex = 0
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(416, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        Me.menuAyuda1.Text = "Ayu&da"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir2, Me.Separator1, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(116, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Image = CType(resources.GetObject("menuAyudaTema2.Image"), System.Drawing.Image)
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        Me.menuAyudaTema2.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1, Me.menuAyudaAcerca1})
        Me.menuCatalogo.Key = "menuCatalogo"
        Me.menuCatalogo.Name = "menuCatalogo"
        Me.menuCatalogo.Text = "&Catalogo"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'menuAyudaAcerca1
        '
        Me.menuAyudaAcerca1.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca1.Name = "menuAyudaAcerca1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema3})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
        '
        'menuAyudaTema3
        '
        Me.menuAyudaTema3.Image = CType(resources.GetObject("menuAyudaTema3.Image"), System.Drawing.Image)
        Me.menuAyudaTema3.Key = "menuAyudaTema"
        Me.menuAyudaTema3.Name = "menuAyudaTema3"
        Me.menuAyudaTema3.Text = "&Temas de Ayuda"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Ay&uda"
        '
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "Ay&uda"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.TabIndex = 0
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.TabIndex = 0
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(416, 50)
        Me.TopRebar1.TabIndex = 0
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(416, 131)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Familias"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(424, 156)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.BackColor = System.Drawing.Color.Ivory
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(128, 85)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.ReadOnly = True
        Me.EditBox2.Size = New System.Drawing.Size(224, 22)
        Me.EditBox2.TabIndex = 4
        Me.EditBox2.TabStop = False
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.ButtonImage = CType(resources.GetObject("EditBox1.ButtonImage"), System.Drawing.Image)
        Me.EditBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(128, 56)
        Me.EditBox1.MaxLength = 2
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(104, 22)
        Me.EditBox1.TabIndex = 3
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(40, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'CatalogoFamiliasForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 181)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(424, 208)
        Me.MinimumSize = New System.Drawing.Size(424, 208)
        Me.Name = "CatalogoFamiliasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo de Familias"
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    Private oCatalogoFamiliasMgr As CatalogoFamiliasManager

    Private oFamilias As Familias

#End Region



#Region "M�todos Privados"

    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EditBox1.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoFamiliasOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oFamilias = Nothing
                oFamilias = oCatalogoFamiliasMgr.Load(oOpenRecordDlg.Record.Item("CodFamilia"))

                EditBox1.Text = oFamilias.ID
                EditBox2.Text = oFamilias.Descripcion

            End If

        Else

            On Error Resume Next

            oFamilias = Nothing
            oFamilias = oCatalogoFamiliasMgr.Load(EditBox1.Text.Trim)

            If oFamilias.IsDirty Then
                MessageBox.Show("C�digo no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                EditBox1.Text = oFamilias.ID
                EditBox2.Text = oFamilias.Descripcion

            End If


        End If

    End Sub

#End Region



#Region "M�todos Privados [Eventos]"

    Private Sub CatalogoFamiliasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oCatalogoFamiliasMgr = New CatalogoFamiliasManager(oAppContext)

    End Sub



    Private Sub CatalogoFamiliasForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        On Error Resume Next

        oFamilias = Nothing

        oCatalogoFamiliasMgr = Nothing

    End Sub



    'Men� and ToolsBar :
    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuAbrir"

                Sm_Buscar(True)
                EditBox1.Focus()
                EditBox1.SelectAll()


            Case "menuAyudaTema"


            Case "menuSalir"

                Me.Close()

        End Select

    End Sub



    'Bot�n Buscar :
    Private Sub EditBox1_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox1.ButtonClick

        Sm_Buscar(True)
        EditBox1.Focus()
        EditBox1.SelectAll()

    End Sub



    'EditBox C�digo :
    Private Sub EditBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditBox1.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            Sm_Buscar()
            EditBox1.Focus()
            EditBox1.SelectAll()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)
            EditBox1.Focus()
            EditBox1.SelectAll()

        End If

    End Sub

#End Region

 
    Private Sub CatalogoFamiliasForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
