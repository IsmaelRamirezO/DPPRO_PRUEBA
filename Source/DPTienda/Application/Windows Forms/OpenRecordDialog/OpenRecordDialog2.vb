
Imports Janus.Windows.GridEX


Public Class OpenRecordDialog2
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
    Friend WithEvents ShowGroupByBox1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ShowGroupByBox As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ilIcons As System.Windows.Forms.ImageList
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents uibtnActionOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnActionCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents rdDescripcion As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbCodProveedor As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdCodigo As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenRecordDialog2))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ShowGroupByBox1 = New Janus.Windows.UI.CommandBars.UICommand("ShowGroupByBox")
        Me.ShowGroupByBox = New Janus.Windows.UI.CommandBars.UICommand("ShowGroupByBox")
        Me.ilIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.uibtnActionOK = New Janus.Windows.EditControls.UIButton()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.uibtnActionCancel = New Janus.Windows.EditControls.UIButton()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.rbCodProveedor = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdDescripcion = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdCodigo = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShowGroupByBox1
        '
        Me.ShowGroupByBox1.Key = "ShowGroupByBox"
        Me.ShowGroupByBox1.Name = "ShowGroupByBox1"
        '
        'ShowGroupByBox
        '
        Me.ShowGroupByBox.ImageIndex = 1
        Me.ShowGroupByBox.Key = "ShowGroupByBox"
        Me.ShowGroupByBox.Name = "ShowGroupByBox"
        Me.ShowGroupByBox.Text = "Agrupar"
        '
        'ilIcons
        '
        Me.ilIcons.ImageStream = CType(resources.GetObject("ilIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilIcons.Images.SetKeyName(0, "")
        Me.ilIcons.Images.SetKeyName(1, "")
        Me.ilIcons.Images.SetKeyName(2, "")
        '
        'GridEX1
        '
        Me.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEX1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEX1.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><GroupByBoxInfo>Arrast" & _
    "re una columna para agrupar</GroupByBoxInfo></LocalizableData>"
        Me.GridEX1.EmptyRows = True
        Me.GridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEX1.GridLines = Janus.Windows.GridEX.GridLines.Horizontal
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.GridEX1.Location = New System.Drawing.Point(12, 77)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(654, 266)
        Me.GridEX1.TabIndex = 1
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnActionOK
        '
        Me.uibtnActionOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.uibtnActionOK.Location = New System.Drawing.Point(515, 346)
        Me.uibtnActionOK.Name = "uibtnActionOK"
        Me.uibtnActionOK.Size = New System.Drawing.Size(72, 23)
        Me.uibtnActionOK.TabIndex = 2
        Me.uibtnActionOK.Text = "&Abrir"
        Me.uibtnActionOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodigo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(144, 6)
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(264, 21)
        Me.ebCodigo.TabIndex = 0
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnActionCancel
        '
        Me.uibtnActionCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.uibtnActionCancel.Location = New System.Drawing.Point(595, 346)
        Me.uibtnActionCancel.Name = "uibtnActionCancel"
        Me.uibtnActionCancel.Size = New System.Drawing.Size(72, 23)
        Me.uibtnActionCancel.TabIndex = 3
        Me.uibtnActionCancel.Text = "&Cancelar"
        Me.uibtnActionCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.rbCodProveedor)
        Me.ExplorerBar1.Controls.Add(Me.uibtnActionOK)
        Me.ExplorerBar1.Controls.Add(Me.uibtnActionCancel)
        Me.ExplorerBar1.Controls.Add(Me.rdDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.rdCodigo)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.ShowGroupCaption = False
        ExplorerBarGroup1.Text = "Datos Generales del Asiento Contable"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-1, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(681, 377)
        Me.ExplorerBar1.TabIndex = 15
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'rbCodProveedor
        '
        Me.rbCodProveedor.BackColor = System.Drawing.Color.Transparent
        Me.rbCodProveedor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCodProveedor.Location = New System.Drawing.Point(16, 30)
        Me.rbCodProveedor.Name = "rbCodProveedor"
        Me.rbCodProveedor.Size = New System.Drawing.Size(135, 18)
        Me.rbCodProveedor.TabIndex = 18
        Me.rbCodProveedor.Text = "Cod. Proveedor"
        Me.rbCodProveedor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdDescripcion
        '
        Me.rdDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.rdDescripcion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDescripcion.Location = New System.Drawing.Point(16, 56)
        Me.rdDescripcion.Name = "rdDescripcion"
        Me.rdDescripcion.Size = New System.Drawing.Size(112, 16)
        Me.rdDescripcion.TabIndex = 16
        Me.rdDescripcion.Text = "Descripción"
        Me.rdDescripcion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdCodigo
        '
        Me.rdCodigo.BackColor = System.Drawing.Color.Transparent
        Me.rdCodigo.Checked = True
        Me.rdCodigo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCodigo.Location = New System.Drawing.Point(16, 8)
        Me.rdCodigo.Name = "rdCodigo"
        Me.rdCodigo.Size = New System.Drawing.Size(112, 16)
        Me.rdCodigo.TabIndex = 15
        Me.rdCodigo.TabStop = True
        Me.rdCodigo.Text = "Código"
        Me.rdCodigo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'OpenRecordDialog2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(678, 375)
        Me.Controls.Add(Me.GridEX1)
        Me.Controls.Add(Me.ebCodigo)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenRecordDialog2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abrir"
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim drResult As DataRowView
    Dim oCurrentView As IOpenRecordDialogView2
    Dim bandera As Boolean = True
    Public pbNombre As String = String.Empty
    Public pbCodigo As String = String.Empty
    Public pbCodProv As String = String.Empty

    Dim dsBuscar As DataSet

    Dim strFieldSeek As String


    Public Property CurrentView() As IOpenRecordDialogView2
        Get
            Return oCurrentView
        End Get
        Set(ByVal Value As IOpenRecordDialogView2)
            oCurrentView = Value

            dsBuscar = oCurrentView.SetupDataBinding
            GridEX1.DataSource = dsBuscar.Tables(0).DefaultView
            GridEX1.RetrieveStructure()

            oCurrentView.SetupView(GridEX1)

            If GridEX1.RowCount > 0 Then
                GridEX1.Row = GridEX1.FilterRow.Position
                GridEX1.Col = 0
            End If

            strFieldSeek = oCurrentView.FieldCodigo

        End Set

    End Property



    Public ReadOnly Property Record() As DataRowView
        Get
            Return drResult
        End Get
    End Property

    Public Property Codigo() As String
        Get
            Codigo = ebCodigo.Text
        End Get
        Set(ByVal Value As String)
            ebCodigo.Text = Value
        End Set
    End Property


    Private Sub OpenRecordDialog2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If

    End Sub



    Private Sub ebCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.TextChanged
        Dim oRows As DataRow()
        dsBuscar.Tables(0).DefaultView.RowFilter = strFieldSeek & " LIKE '" & ebCodigo.Text & "*'"
        oRows = dsBuscar.Tables(0).Select(strFieldSeek & " LIKE '" & ebCodigo.Text & "*'")
        pbCodigo = ebCodigo.Text

        If oRows.Length = 1 Then
            pbCodigo = oRows(0).Item("Código")
        End If

    End Sub



    Private Sub GridEX1_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEX1.DoubleClick
        Dim oCurrentRow As GridEXRow
        ebCodigo.Focus()


        oCurrentRow = GridEX1.GetRow()
        If (Not oCurrentRow Is Nothing) AndAlso (oCurrentRow.RowType = RowType.Record) Then
            drResult = CType(oCurrentRow.DataRow, DataRowView)
            pbCodigo = drResult.Item("Código")
        End If


        Me.DialogResult = DialogResult.OK

    End Sub



    Private Sub GridEX1_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEX1.SelectionChanged

        Dim oCurrentRow As GridEXRow

        oCurrentRow = GridEX1.GetRow()

        drResult = Nothing

        uibtnActionOK.Enabled = False

        If (Not oCurrentRow Is Nothing) AndAlso (oCurrentRow.RowType = RowType.Record) Then

            drResult = CType(oCurrentRow.DataRow, DataRowView)
            pbCodigo = drResult.Item("Código")
            uibtnActionOK.Enabled = True

        ElseIf (Not oCurrentRow Is Nothing) AndAlso (oCurrentRow.RowType = RowType.GroupHeader) Then

            GridEX1.Row = GridEX1.Row + 1

        End If

        oCurrentRow = Nothing

    End Sub



    Private Sub GridEX1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEX1.KeyDown

        If e.KeyCode = Keys.Enter Then
            If GridEX1.Row < 0 Then
                Exit Sub
            End If

            If Not GridEX1.Row = GridEX1.FilterRow.Position Then

                If Not Me.drResult Is Nothing Then

                    If GridEX1.Row > 0 Then

                        pbCodigo = String.Empty
                        GridEX1.Row = GridEX1.Row - 1

                    Else

                        Dim oCurrentRow As GridEXRow

                        oCurrentRow = GridEX1.GetRow(0)

                        Dim drResult As DataRowView = Nothing

                        drResult = CType(oCurrentRow.DataRow, DataRowView)

                        pbCodigo = drResult(0)
                        pbCodProv = drResult(1)
                        pbNombre = drResult(2)

                        drResult = Nothing

                    End If

                    Me.DialogResult = DialogResult.OK

                Else

                    Me.DialogResult = DialogResult.Cancel

                End If
                ebCodigo.Focus()
            End If

        End If

    End Sub



    Private Sub uibtnActionCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnActionCancel.Click

        If bandera Then
            GridEX1.Focus()
            bandera = False
        End If

    End Sub



    Private Sub rdCodigo_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCodigo.CheckedChanged

        If Not (oCurrentView Is Nothing) Then

            strFieldSeek = oCurrentView.FieldCodigo

            dsBuscar.Tables(0).DefaultView.Sort = oCurrentView.FieldCodigo

            ebCodigo.Focus()

        End If

    End Sub



    Private Sub rdDescripcion_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDescripcion.CheckedChanged

        If Not (oCurrentView Is Nothing) Then

            strFieldSeek = oCurrentView.FieldDescripcion

            dsBuscar.Tables(0).DefaultView.Sort = oCurrentView.FieldDescripcion

            ebCodigo.Focus()

        End If

    End Sub

    Private Sub uibtnActionOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles uibtnActionOK.Click
        ebCodigo.Focus()
    End Sub

    Private Sub rbCodProveedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCodProveedor.CheckedChanged
        If Not (oCurrentView Is Nothing) Then

            strFieldSeek = oCurrentView.FieldCodProveedor

            dsBuscar.Tables(0).DefaultView.Sort = oCurrentView.FieldCodProveedor

            ebCodigo.Focus()

        End If
    End Sub

    Private Sub ebCodigo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown
        ebCodigo.Focus()
    End Sub
End Class
