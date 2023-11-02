Imports DportenisPro.DPTienda.Reports.Inventario
Imports System.IO

Public Class frmManagerPanelControl
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdRep As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.grdRep = New Janus.Windows.GridEX.GridEX
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grdRep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.grdRep)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(648, 400)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'grdRep
        '
        Me.grdRep.AllowColumnDrag = False
        Me.grdRep.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        Me.grdRep.AlternatingColors = True
        Me.grdRep.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.grdRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdRep.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdRep.GroupByBoxVisible = False
        Me.grdRep.Location = New System.Drawing.Point(0, 0)
        Me.grdRep.Name = "grdRep"
        Me.grdRep.Size = New System.Drawing.Size(648, 400)
        Me.grdRep.TabIndex = 1
        Me.grdRep.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmManagerPanelControl
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 400)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmManagerPanelControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManagerPanelControl"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grdRep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public strTitulo As String = ""
    Public Modulo As String = ""
    Public Num As Integer = 0
    Public FechaIni As Date, FechaFin As Date
    Dim dtSource As DataTable
    Dim oReporter As InventarioReportesVarios

    Private Sub Inicializar()
        oReporter = New InventarioReportesVarios(oAppContext)
    End Sub

    Private Sub RevisarModulo()
        Select Case Modulo.Trim
            Case "T10", "L10"
                Dim TopTen As Boolean
                If Modulo.Trim = "T10" Then
                    TopTen = True
                Else
                    TopTen = False
                End If
                dtSource = oReporter.CodigosMasVendidos(Num, FechaIni, FechaFin, TopTen)
                AgregarDatos()
        End Select
        RefreshGrid()
        FormatGrid()
    End Sub

    Private Sub RefreshGrid()
        Me.grdRep.DataSource = dtSource
        Me.grdRep.RetrieveStructure()
        Me.grdRep.Refresh()
    End Sub

    Private Sub AgregarDatos()

        dtSource.Columns.Add("Imagen", GetType(Image))
        dtSource.Columns.Add("Numero", GetType(Integer))
        dtSource.AcceptChanges()

        Dim oRow As DataRow
        Dim i As Integer = 1

        For Each oRow In dtSource.Rows
            If File.Exists(Application.StartupPath & "\Fotos\" & oRow!Codigo & ".JPG") Then
                oRow!Imagen = Image.FromFile(Application.StartupPath & "\Fotos\" & oRow!Codigo & ".JPG")
            End If
            oRow!Numero = i
            i += 1
        Next

        dtSource.AcceptChanges()

    End Sub

    Private Sub FormatGrid()

        Select Case Modulo.Trim
            Case "T10", "L10"
                With grdRep.Tables(0)
                    .Columns("Talla").Width = 40
                    .Columns("Talla").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .Columns("Descripcion").Width = 200
                    .Columns("Vendidos").Width = 70
                    .Columns("Vendidos").FormatString = "#,##0"
                    .Columns("Vendidos").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .Columns("Existencia").Width = 70
                    .Columns("Existencia").FormatString = "#,##0"
                    .Columns("Existencia").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .Columns("Imagen").CardCaption = False
                    .Columns("Imagen").Position = 0
                    .Columns("Imagen").CardIcon = True
                    .Columns("Imagen").Caption = "Imagen"
                    .Columns("Imagen").Width = 100
                    .Columns("Imagen").BoundImageSize = New Size(100, 100)
                    .HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .Columns("Numero").Position = 0
                    .Columns("Numero").CellStyle.FontSize = 16
                    .Columns("Numero").TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .Columns("Numero").Width = 40
                    .Columns("Numero").Caption = ""
                    .HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
                End With
        End Select

    End Sub

    Private Sub KeyDownForm(ByVal k As Keys)
        Select Case k
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub frmManagerPanelControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = strTitulo.Trim

        RevisarModulo()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmManagerPanelControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        KeyDownForm(e.KeyCode)
    End Sub

    Private Sub grdRep_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdRep.KeyDown
        KeyDownForm(e.KeyCode)
    End Sub

End Class
