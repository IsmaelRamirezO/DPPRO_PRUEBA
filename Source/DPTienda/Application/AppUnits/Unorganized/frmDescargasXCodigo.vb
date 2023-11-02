Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class frmDescargasXCodigo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        CreaEstructuraTabla()

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
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents rbExistencias As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDescuentos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnDescargar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebArticuloID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarLista As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdMateriales As Janus.Windows.GridEX.GridEX
    Friend WithEvents rbCodUpc As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescargasXCodigo))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.rbCodUpc = New Janus.Windows.EditControls.UIRadioButton()
        Me.grdMateriales = New Janus.Windows.GridEX.GridEX()
        Me.btnLimpiarLista = New Janus.Windows.EditControls.UIButton()
        Me.btnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.btnDescargar = New Janus.Windows.EditControls.UIButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDescuentos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbExistencias = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.ebArticuloID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.rbCodUpc)
        Me.explorerBar1.Controls.Add(Me.grdMateriales)
        Me.explorerBar1.Controls.Add(Me.btnLimpiarLista)
        Me.explorerBar1.Controls.Add(Me.btnEliminar)
        Me.explorerBar1.Controls.Add(Me.btnDescargar)
        Me.explorerBar1.Controls.Add(Me.rbTodos)
        Me.explorerBar1.Controls.Add(Me.rbDescuentos)
        Me.explorerBar1.Controls.Add(Me.rbExistencias)
        Me.explorerBar1.Controls.Add(Me.btnAgregar)
        Me.explorerBar1.Controls.Add(Me.ebArticuloID)
        Me.explorerBar1.Controls.Add(Me.lblCodigo)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(274, 352)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'rbCodUpc
        '
        Me.rbCodUpc.BackColor = System.Drawing.Color.Transparent
        Me.rbCodUpc.Location = New System.Drawing.Point(120, 80)
        Me.rbCodUpc.Name = "rbCodUpc"
        Me.rbCodUpc.Size = New System.Drawing.Size(96, 24)
        Me.rbCodUpc.TabIndex = 10
        Me.rbCodUpc.Text = "Códigos UPC"
        Me.rbCodUpc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdMateriales
        '
        Me.grdMateriales.AllowCardSizing = False
        Me.grdMateriales.AllowColumnDrag = False
        Me.grdMateriales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdMateriales.AlternatingColors = True
        Me.grdMateriales.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdMateriales.DesignTimeLayout = GridEXLayout1
        Me.grdMateriales.GroupByBoxVisible = False
        Me.grdMateriales.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdMateriales.Location = New System.Drawing.Point(16, 128)
        Me.grdMateriales.Name = "grdMateriales"
        Me.grdMateriales.Size = New System.Drawing.Size(240, 144)
        Me.grdMateriales.TabIndex = 9
        Me.grdMateriales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnLimpiarLista
        '
        Me.btnLimpiarLista.Location = New System.Drawing.Point(152, 272)
        Me.btnLimpiarLista.Name = "btnLimpiarLista"
        Me.btnLimpiarLista.Size = New System.Drawing.Size(104, 20)
        Me.btnLimpiarLista.TabIndex = 3
        Me.btnLimpiarLista.Text = "Limpiar Lista"
        Me.btnLimpiarLista.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(17, 272)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(95, 20)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar Codigo"
        Me.btnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnDescargar
        '
        Me.btnDescargar.Location = New System.Drawing.Point(16, 304)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(240, 40)
        Me.btnDescargar.TabIndex = 4
        Me.btnDescargar.Text = "Descargar"
        Me.btnDescargar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbTodos
        '
        Me.rbTodos.BackColor = System.Drawing.Color.Transparent
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(16, 80)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(96, 24)
        Me.rbTodos.TabIndex = 2
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbDescuentos
        '
        Me.rbDescuentos.BackColor = System.Drawing.Color.Transparent
        Me.rbDescuentos.Location = New System.Drawing.Point(120, 104)
        Me.rbDescuentos.Name = "rbDescuentos"
        Me.rbDescuentos.Size = New System.Drawing.Size(132, 24)
        Me.rbDescuentos.TabIndex = 4
        Me.rbDescuentos.Text = "Descuentos y Precios"
        Me.rbDescuentos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbExistencias
        '
        Me.rbExistencias.BackColor = System.Drawing.Color.Transparent
        Me.rbExistencias.Location = New System.Drawing.Point(16, 104)
        Me.rbExistencias.Name = "rbExistencias"
        Me.rbExistencias.Size = New System.Drawing.Size(96, 24)
        Me.rbExistencias.TabIndex = 3
        Me.rbExistencias.Text = "Existencias"
        Me.rbExistencias.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(16, 40)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(240, 32)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebArticuloID
        '
        Me.ebArticuloID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebArticuloID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebArticuloID.ButtonImage = CType(resources.GetObject("ebArticuloID.ButtonImage"), System.Drawing.Image)
        Me.ebArticuloID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebArticuloID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebArticuloID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ebArticuloID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebArticuloID.ForeColor = System.Drawing.Color.Black
        Me.ebArticuloID.Location = New System.Drawing.Point(72, 16)
        Me.ebArticuloID.MaxLength = 20
        Me.ebArticuloID.Name = "ebArticuloID"
        Me.ebArticuloID.Size = New System.Drawing.Size(184, 22)
        Me.ebArticuloID.TabIndex = 0
        Me.ebArticuloID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebArticuloID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(16, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 24)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Codigo:"
        '
        'frmDescargasXCodigo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(274, 352)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDescargasXCodigo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descargas Individuales"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oSAPMgr As ProcesoSAPManager
    Dim dtMateriales As DataTable
    Dim oArticulo As Articulo
    Public MostrarMensajes As Boolean = False

#Region "Metodos"

    Private Function EstaEnGrid(ByVal Material As String) As Boolean
        Dim bRes As Boolean = False
        Dim str As String = ""

        For Each oRow As DataRow In dtMateriales.Rows
            str = CStr(oRow!Material)
            If str.Trim.ToUpper = Material.Trim.ToUpper Then
                bRes = True
                Exit For
            End If
        Next

        Return bRes

    End Function

    Private Function LoadCodigo(ByVal strCodigo As String) As Articulo

        Dim bPrimera As Boolean = True
        Dim oCatalogoUPCMgr As New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        If oCatalogoUPCMgr.IsSkuOrMaterial(strCodigo.PadLeft(18, "0")) = "S" Then
            'Buscamos Codigo UPC
            Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            Dim oUPC As UPC
            oUPC = oUPCMgr.Create

            oUPC = oUPCMgr.Load(strCodigo)

            If oUPC.CodArticulo <> String.Empty Then

                Me.ebArticuloID.Text = oUPC.CodArticulo
                strCodigo = oUPC.CodArticulo
                GoTo ValidaCodigo

            Else

                MessageBox.Show("Código UPC No Existe. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oArticulo = Nothing
                Me.ebArticuloID.Text = ""
                Me.ebArticuloID.Focus()

            End If

            oUPCMgr.dispose()
            oUPCMgr = Nothing
            oUPC = Nothing
        Else
ValidaCodigo:
            oArticulo = Nothing
            If Me.ebArticuloID.Text.Trim <> "" Then
                Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                oArticulo = oArticuloMgr.Create
                oArticulo.ClearFields()

                oArticuloMgr.LoadInto(strCodigo, oArticulo, True)
                If oArticulo.CodArticulo = String.Empty Then
                    oArticulo.ClearFields()
                    oArticuloMgr.LoadInto(strCodigo, oArticulo)
                    If oArticulo.CodArticulo = String.Empty Then
                        If bPrimera Then

                            bPrimera = False

                            Dim dtTemp As DataTable
                            Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                            frmDescargas.Timer1.Enabled = False
                            frmDescargas.bPorCodigo = True
                            frmDescargas.bMostrarMensaje = False

                            dtTemp = dtMateriales.Copy
                            dtMateriales.Clear()
                            AgregarCodigo(Me.ebArticuloID.Text.Trim, "")
                            frmDescargas.dtMateriales = dtMateriales

                            frmDescargas.ShowDev("Articulos")
                            dtMateriales = dtTemp.Copy
                            ActualizarGrid()
                            GoTo ValidaCodigo
                        End If

                        MessageBox.Show("El Codigo especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        oArticulo = Nothing
                        Me.ebArticuloID.Text = ""
                        Me.ebArticuloID.Focus()
                    End If
                End If

            End If
        End If

        Return oArticulo

    End Function

    Private Sub Descargar()

        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

        frmDescargas.Timer1.Enabled = False
        frmDescargas.bPorCodigo = True
        frmDescargas.dtMateriales = dtMateriales
        frmDescargas.bMostrarMensaje = MostrarMensajes

        If Me.rbTodos.Checked Then
            frmDescargas.ShowDev("Descuentos")
            frmDescargas.ShowDev("Inventarios")
            frmDescargas.ShowDev("CodigosUPC")
        ElseIf Me.rbDescuentos.Checked Then
            frmDescargas.ShowDev("Descuentos")
        ElseIf Me.rbExistencias.Checked Then
            frmDescargas.ShowDev("Inventarios")
        ElseIf Me.rbCodUpc.Checked Then
            frmDescargas.ShowDev("CodigosUPC")
        End If

    End Sub

    Private Sub AgregarCodigo(ByVal strCodigo As String, ByVal Desc As String)

        Dim oRow As DataRow = dtMateriales.NewRow
        oRow!Material = strCodigo.Trim.ToUpper
        oRow!Descripcion = Desc.Trim
        dtMateriales.Rows.Add(oRow)
        dtMateriales.AcceptChanges()
        ActualizarGrid()

    End Sub

    Private Sub CreaEstructuraTabla()

        dtMateriales = New DataTable("Materiales")
        dtMateriales.Columns.Add("Material", Type.GetType("System.String"))
        dtMateriales.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtMateriales.AcceptChanges()

    End Sub

    Private Sub EliminarCodigo(ByVal index As Integer)

        dtMateriales.Rows.RemoveAt(index)
        dtMateriales.AcceptChanges()
        ActualizarGrid()

    End Sub

    Private Sub EliminarItemGrid()
        If Me.dtMateriales.Rows.Count > 0 Then
            Dim index As Integer = Me.grdMateriales.Row
            EliminarCodigo(index)
        End If
    End Sub

    Private Sub ActualizarGrid()

        Me.grdMateriales.DataSource = dtMateriales
        Me.grdMateriales.Refresh()

    End Sub

    '--------------------------------------------------------------------------------------
    ' JNAVA (12.04.2016): Se grego funcion para agregar codigo para la descargar
    '--------------------------------------------------------------------------------------
    Public Sub AgregarClick()
        If Me.ebArticuloID.Text.Trim <> "" Then
            If EstaEnGrid(Me.ebArticuloID.Text) = False Then
                oArticulo = LoadCodigoActualizado(Me.ebArticuloID.Text.Trim())
                'oArticulo = LoadCodigo(Me.ebArticuloID.Text)
                AgregarCodigo(Me.ebArticuloID.Text, oArticulo.Descripcion)
                Me.ebArticuloID.Text = ""
            Else
                MessageBox.Show("El Código ya se encuentra en la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebArticuloID.Text = ""
                oArticulo = Nothing
            End If
        End If
        Me.ebArticuloID.Focus()
    End Sub

    Private Function LoadCodigoActualizado(ByVal strCodigo As String) As Articulo
        Dim oCatalogoUPCMgr As New CatalogoUPCManager(oAppContext, oConfigCierreFI)
        If oCatalogoUPCMgr.IsSkuOrMaterial(strCodigo.PadLeft(18, "0")) = "S" Then
            Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            Dim oUPC As UPC
            oUPC = oUPCMgr.Create

            oUPC = oUPCMgr.Load(strCodigo)

            If oUPC.CodArticulo <> String.Empty Then

                Me.ebArticuloID.Text = oUPC.CodArticulo
                strCodigo = oUPC.CodArticulo
                UpdateCode(strCodigo)
                CargarArticulo(strCodigo)
            Else
                MessageBox.Show("Código UPC No Existe. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oArticulo = Nothing
                Me.ebArticuloID.Text = ""
                Me.ebArticuloID.Focus()
            End If
            oUPCMgr.dispose()
            oUPCMgr = Nothing
            oUPC = Nothing
        Else
            UpdateCode(strCodigo)
            CargarArticulo(strCodigo)
        End If
        Return oArticulo
    End Function


    Private Sub UpdateCode(ByVal Codigo As String)
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim dtMateriales As New DataTable()
        dtMateriales.Columns.Add("Material", GetType(String))
        dtMateriales.Columns.Add("Descripcion", GetType(String))
        dtMateriales.AcceptChanges()
        Dim row As DataRow = dtMateriales.NewRow()
        row("Material") = Codigo
        row("Descripcion") = ""
        dtMateriales.Rows.Add(row)
        frmDescargas.Timer1.Enabled = False
        frmDescargas.bPorCodigo = True
        frmDescargas.bMostrarMensaje = False
        frmDescargas.dtMateriales = dtMateriales
        frmDescargas.ShowDev("Articulos")
    End Sub

    Private Sub CargarArticulo(ByVal strCodigo As String)
        If Me.ebArticuloID.Text.Trim <> "" Then
            Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
            oArticulo = oArticuloMgr.Create
            oArticulo.ClearFields()

            oArticuloMgr.LoadInto(strCodigo, oArticulo)
            If oArticulo.CodArticulo = String.Empty Then
                MessageBox.Show("El Código especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oArticulo = Nothing
                Me.ebArticuloID.Text = ""
                Me.ebArticuloID.Focus()
            End If
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        AgregarClick()
        'If Me.ebArticuloID.Text.Trim <> "" Then
        '    If EstaEnGrid(Me.ebArticuloID.Text) = False Then
        '        oArticulo = LoadCodigo(Me.ebArticuloID.Text)
        '        AgregarCodigo(Me.ebArticuloID.Text, oArticulo.Descripcion)
        '        Me.ebArticuloID.Text = ""
        '    Else
        '        MessageBox.Show("El Codigo ya se encuentra en la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.ebArticuloID.Text = ""
        '        oArticulo = Nothing
        '    End If
        'End If
        'Me.ebArticuloID.Focus()

    End Sub

    Private Sub ebArticuloID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebArticuloID.ButtonClick

        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If oOpenRecordDlg.DialogResult = DialogResult.OK Then

            Me.ebArticuloID.Text = ""
            Me.ebArticuloID.Text = oOpenRecordDlg.Record.Item("Código")
            'Me.btnAgregar.PerformClick()
            Me.AgregarClick()

        End If

    End Sub

    Private Sub btnDescargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescargar.Click

        If dtMateriales.Rows.Count > 0 Then
            Descargar()
        Else
            MessageBox.Show("Es necesario al menos un Codigo para realizar la descarga", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub ebArticuloID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebArticuloID.KeyDown

        If e.KeyCode = Keys.Enter AndAlso Me.ebArticuloID.Text.Trim <> "" Then
            SendKeys.Send("{TAB}")
        ElseIf e.Alt AndAlso e.KeyCode = Keys.S Then
            ebArticuloID_ButtonClick(Nothing, Nothing)
        End If

    End Sub

    Private Sub ebArticuloID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebArticuloID.Validating
        If Me.ebArticuloID.Text.Trim() <> "" Then
            oArticulo = LoadCodigoActualizado(Me.ebArticuloID.Text.Trim())
            'oArticulo = LoadCodigo(Me.ebArticuloID.Text)
            If Not oArticulo Is Nothing Then
                Me.ebArticuloID.Text = oArticulo.CodArticulo
                'Me.btnAgregar.PerformClick()
                Me.AgregarClick()
            Else

            End If
        End If
    End Sub

    Private Sub btnLimpiarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarLista.Click
        dtMateriales.Rows.Clear()
        dtMateriales.AcceptChanges()
        ActualizarGrid()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Me.grdMateriales.Row < 0 Then
            MessageBox.Show("Debe seleccionar un codigo de la lista para eliminar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            EliminarItemGrid()
        End If
    End Sub

    Private Sub grdMateriales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdMateriales.KeyDown

        If e.KeyCode = Keys.Delete Then
            EliminarItemGrid()
        End If

    End Sub

    Private Sub frmDescargasXCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub frmDescargasXCodigo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SendKeys.Send("{TAB}")
    End Sub

#End Region

End Class
