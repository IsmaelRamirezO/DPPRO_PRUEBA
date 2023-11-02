Imports Janus.Windows.GridEX

Public Class OpenRecordDialog
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents ShowGroupByBox As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ilIcons As System.Windows.Forms.ImageList
    Private WithEvents uibtnActionCancel As Janus.Windows.EditControls.UIButton
    Private WithEvents uibtnActionOK As Janus.Windows.EditControls.UIButton
    Private WithEvents uigbBottomPanel As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ShowGroupByBox1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenRecordDialog))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.ilIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ShowGroupByBox = New Janus.Windows.UI.CommandBars.UICommand("ShowGroupByBox")
        Me.ShowGroupByBox1 = New Janus.Windows.UI.CommandBars.UICommand("ShowGroupByBox")
        Me.uibtnActionCancel = New Janus.Windows.EditControls.UIButton()
        Me.uibtnActionOK = New Janus.Windows.EditControls.UIButton()
        Me.uigbBottomPanel = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbBottomPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbBottomPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarGroupBackground
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.GridEX1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(492, 231)
        Me.UiGroupBox1.TabIndex = 4
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Registros Disponibles:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.GridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.GridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEX1.GridLines = Janus.Windows.GridEX.GridLines.Horizontal
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.GridEX1.Location = New System.Drawing.Point(12, 32)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(468, 192)
        Me.GridEX1.TabIndex = 4
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ilIcons
        '
        Me.ilIcons.ImageStream = CType(resources.GetObject("ilIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilIcons.Images.SetKeyName(0, "")
        Me.ilIcons.Images.SetKeyName(1, "")
        Me.ilIcons.Images.SetKeyName(2, "")
        '
        'ShowGroupByBox
        '
        Me.ShowGroupByBox.ImageIndex = 1
        Me.ShowGroupByBox.Key = "ShowGroupByBox"
        Me.ShowGroupByBox.Name = "ShowGroupByBox"
        Me.ShowGroupByBox.Text = "Agrupar"
        '
        'ShowGroupByBox1
        '
        Me.ShowGroupByBox1.Key = "ShowGroupByBox"
        Me.ShowGroupByBox1.Name = "ShowGroupByBox1"
        '
        'uibtnActionCancel
        '
        Me.uibtnActionCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.uibtnActionCancel.Location = New System.Drawing.Point(408, 8)
        Me.uibtnActionCancel.Name = "uibtnActionCancel"
        Me.uibtnActionCancel.Size = New System.Drawing.Size(72, 24)
        Me.uibtnActionCancel.TabIndex = 2
        Me.uibtnActionCancel.Text = "&Cancelar"
        Me.uibtnActionCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnActionOK
        '
        Me.uibtnActionOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.uibtnActionOK.Enabled = False
        Me.uibtnActionOK.Location = New System.Drawing.Point(328, 8)
        Me.uibtnActionOK.Name = "uibtnActionOK"
        Me.uibtnActionOK.Size = New System.Drawing.Size(72, 24)
        Me.uibtnActionOK.TabIndex = 1
        Me.uibtnActionOK.Text = "&Abrir"
        Me.uibtnActionOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uigbBottomPanel
        '
        Me.uigbBottomPanel.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.uigbBottomPanel.Controls.Add(Me.uibtnActionOK)
        Me.uigbBottomPanel.Controls.Add(Me.uibtnActionCancel)
        Me.uigbBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.uigbBottomPanel.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbBottomPanel.Location = New System.Drawing.Point(0, 231)
        Me.uigbBottomPanel.Name = "uigbBottomPanel"
        Me.uigbBottomPanel.Size = New System.Drawing.Size(492, 40)
        Me.uigbBottomPanel.TabIndex = 1
        Me.uigbBottomPanel.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'OpenRecordDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(492, 271)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.uigbBottomPanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenRecordDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abrir"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbBottomPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbBottomPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim drResult As DataRowView
    Dim oCurrentView As IOpenRecordDialogView
    Dim bandera As Boolean = True
    Public pbNombre As String = String.Empty
    Public pbCodigo As String = String.Empty

    Private bolOpenRecordDialogCliente As Boolean

    Public Property OpenRecordDialogCliente() As Boolean

        Get
            Return bolOpenRecordDialogCliente
        End Get
        Set(ByVal Value As Boolean)
            bolOpenRecordDialogCliente = Value
        End Set

    End Property

    Public Property CurrentView() As IOpenRecordDialogView
        Get
            Return oCurrentView
        End Get
        Set(ByVal Value As IOpenRecordDialogView)
            oCurrentView = Value

            'Verificar que oCurrentView sea una variable tipo ClientesOpenRecordDialogView.

            'If (bolOpenRecordDialogCliente = True) Then

            '   Mostrar el Formulario Filtro.

            '   oCurrentView.SetupDataBinding(GridEX1, CodPlaza, SelCriterio, Criterio)

            'Else

            oCurrentView.SetupDataBinding(GridEX1)

            'End If


            oCurrentView.SetupView(GridEX1)

            If GridEX1.RowCount > 0 Then
                GridEX1.Row = GridEX1.FilterRow.Position
                GridEX1.Col = 0
                Me.uibtnActionOK.Enabled = True
            End If

        End Set

    End Property

    Public ReadOnly Property Record() As DataRowView
        Get
            Return drResult
        End Get
    End Property

    Private Sub GridEX1_RowDoubleClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEX1.RowDoubleClick

        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub GridEX1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEX1.SelectionChanged

        Dim oCurrentRow As GridEXRow

        oCurrentRow = GridEX1.GetRow()

        drResult = Nothing

        uibtnActionOK.Enabled = False

        If (Not oCurrentRow Is Nothing) AndAlso (oCurrentRow.RowType = RowType.Record) Then

            drResult = CType(oCurrentRow.DataRow, DataRowView)
            uibtnActionOK.Enabled = True

        ElseIf (Not oCurrentRow Is Nothing) AndAlso (oCurrentRow.RowType = RowType.GroupHeader) Then

            GridEX1.Row = GridEX1.Row + 1

        End If

        oCurrentRow = Nothing

    End Sub


    Private Sub GridEX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEX1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Not GridEX1.Row = GridEX1.FilterRow.Position Then

                If Not Me.drResult Is Nothing Then

                    If GridEX1.Row > 0 Then

                        GridEX1.Row = GridEX1.Row

                    Else

                        Dim oCurrentRow As GridEXRow

                        oCurrentRow = GridEX1.GetRow(0)

                        Dim drResult As DataRowView = Nothing

                        drResult = CType(oCurrentRow.DataRow, DataRowView)

                        pbCodigo = drResult(0)
                        pbNombre = drResult(1)

                        drResult = Nothing

                    End If

                    Me.DialogResult = DialogResult.OK

                Else

                    Me.DialogResult = DialogResult.Cancel

                End If

            End If
        End If
    End Sub


    Private Sub uibtnActionCancel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles uibtnActionCancel.GotFocus
        If bandera Then
            GridEX1.Focus()
            bandera = False
        End If
    End Sub

End Class
