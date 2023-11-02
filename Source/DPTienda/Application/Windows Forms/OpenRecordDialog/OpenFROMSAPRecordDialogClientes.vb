Imports Janus.Windows.GridEX

Public Class OpenFROMSAPRecordDialogClientes
    Inherits System.Windows.Forms.Form

    Private m_strGrupoDeCuentas As String
    'este

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
    Friend WithEvents uibtnActionOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnActionCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents uigbBottomPanel As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenFROMSAPRecordDialogClientes))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.uigbBottomPanel = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.uibtnActionOK = New Janus.Windows.EditControls.UIButton()
        Me.uibtnActionCancel = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.uigbBottomPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbBottomPanel.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarGroupBackground
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(492, 271)
        Me.UiGroupBox1.TabIndex = 9
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarGroupBackground
        Me.UiGroupBox2.Controls.Add(Me.uigbBottomPanel)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.GridEX1)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox2.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(492, 271)
        Me.UiGroupBox2.TabIndex = 7
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'uigbBottomPanel
        '
        Me.uigbBottomPanel.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.uigbBottomPanel.Controls.Add(Me.UiButton1)
        Me.uigbBottomPanel.Controls.Add(Me.UiButton2)
        Me.uigbBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.uigbBottomPanel.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbBottomPanel.Location = New System.Drawing.Point(0, 231)
        Me.uigbBottomPanel.Name = "uigbBottomPanel"
        Me.uigbBottomPanel.Size = New System.Drawing.Size(492, 40)
        Me.uigbBottomPanel.TabIndex = 6
        Me.uigbBottomPanel.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.UiButton1.Enabled = False
        Me.UiButton1.Location = New System.Drawing.Point(328, 8)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(72, 24)
        Me.UiButton1.TabIndex = 1
        Me.UiButton1.Text = "&Abrir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UiButton2.Location = New System.Drawing.Point(408, 8)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(72, 24)
        Me.UiButton2.TabIndex = 2
        Me.UiButton2.Text = "&Cancelar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 5)
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
        Me.GridEX1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridEX1.EmptyRows = True
        Me.GridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.GridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEX1.GridLines = Janus.Windows.GridEX.GridLines.Horizontal
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.GridEX1.Location = New System.Drawing.Point(12, 32)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.Size = New System.Drawing.Size(468, 184)
        Me.GridEX1.TabIndex = 4
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnActionOK
        '
        Me.uibtnActionOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.uibtnActionOK.Location = New System.Drawing.Point(328, 8)
        Me.uibtnActionOK.Name = "uibtnActionOK"
        Me.uibtnActionOK.Size = New System.Drawing.Size(72, 24)
        Me.uibtnActionOK.TabIndex = 7
        Me.uibtnActionOK.Text = "&Abrir"
        Me.uibtnActionOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'uibtnActionCancel
        '
        Me.uibtnActionCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uibtnActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.uibtnActionCancel.Location = New System.Drawing.Point(408, 8)
        Me.uibtnActionCancel.Name = "uibtnActionCancel"
        Me.uibtnActionCancel.Size = New System.Drawing.Size(72, 24)
        Me.uibtnActionCancel.TabIndex = 8
        Me.uibtnActionCancel.Text = "&Cancelar"
        Me.uibtnActionCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'OpenFROMSAPRecordDialogClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(492, 271)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.uibtnActionOK)
        Me.Controls.Add(Me.uibtnActionCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OpenFROMSAPRecordDialogClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.uigbBottomPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbBottomPanel.ResumeLayout(False)
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim drResult As DataRowView
    Dim oCurrentView As IOpenFromSAPRecordDialogViewClientes
    Dim bandera As Boolean = True
    Public pbNombre As String = String.Empty
    Public pbCodigo As String = String.Empty
    Dim m_strTipoVenta As String
    Dim GrupoDeCuentas As String = ""

    Public Property TipoVenta() As String

        Get
            Return m_strTipoVenta
        End Get

        Set(ByVal Value As String)
            m_strTipoVenta = Value

            'If Value = "O" Then

            '    Me.GrupoDeCuentas = "FA"

            'ElseIf Value = "K" Then

            '    Me.GrupoDeCuentas = "FO"

            'ElseIf Value = "I" Then

            '    Me.GrupoDeCuentas = "FF"

            'ElseIf Value = "A" Then

            '    Me.GrupoDeCuentas = "AP"

            'Else
            If Value = "D" Then

                Me.GrupoDeCuentas = "D005"

                'ElseIf Value = "V" Then

                '    Me.GrupoDeCuentas = "VL"

                '    'ElseIf Value = "S" Then

                '    '    Me.GrupoDeCuentas = "DP"

                'ElseIf Value = "P" Then

                '    Me.GrupoDeCuentas = "PG"
            Else

                Me.GrupoDeCuentas = ""

            End If

        End Set

    End Property

    Public Property CurrentView() As IOpenFromSAPRecordDialogViewClientes
        Get
            Return oCurrentView
        End Get

        Set(ByVal Value As IOpenFromSAPRecordDialogViewClientes)

            '   Mostrar el Formulario Filtro.

            Dim frmClientesFiltroSAP As New FrmClientesFiltroSAP
            frmClientesFiltroSAP.TipoVenta = TipoVenta

            frmClientesFiltroSAP.ShowDialog()

            If (frmClientesFiltroSAP.DialogResult <> DialogResult.OK) Then
                Exit Property
            End If

            Cursor.Current = Cursors.WaitCursor

            oCurrentView = Value

            oCurrentView.SetupDataBinding(GridEX1, frmClientesFiltroSAP.Criterio, Me.GrupoDeCuentas, frmClientesFiltroSAP.Tipo, TipoVenta)

            oCurrentView.SetupView(GridEX1)

            If GridEX1.RowCount > 0 Then
                GridEX1.Row = GridEX1.FilterRow.Position
                GridEX1.Col = 0
                Me.UiButton1.Enabled = True
            End If

            Cursor.Current = Cursors.Default

        End Set

    End Property

    Public ReadOnly Property Record() As DataRowView
        Get
            Return drResult
        End Get
    End Property

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEX1.RowDoubleClick

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

    Private Sub uibtnActionCancel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles uibtnActionCancel.GotFocus

        If bandera Then
            GridEX1.Focus()
            bandera = False
        End If

    End Sub

    Private Sub GridEX1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEX1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Not GridEX1.Row = GridEX1.FilterRow.Position Then

                If Not Me.drResult Is Nothing Then

                    If GridEX1.Row > 0 Then

                        GridEX1.Row = GridEX1.Row '- 1

                    Else

                        Dim oCurrentRow As GridEXRow

                        oCurrentRow = GridEX1.GetRow(0)

                        Dim drResult As DataRowView = Nothing

                        drResult = CType(oCurrentRow.DataRow, DataRowView)

                        pbCodigo = drResult("KUNNR")
                        pbNombre = drResult("NAME1") & " " & drResult("NAME2") & " " & drResult("NAME3")
                        drResult = Nothing

                    End If

                    Me.DialogResult = DialogResult.OK

                Else

                    Me.DialogResult = DialogResult.Cancel

                End If

            End If
        End If
    End Sub


    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

    End Sub
End Class
