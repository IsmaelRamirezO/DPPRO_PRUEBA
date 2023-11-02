Public Class frmMensajeOrdenCompra
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents gridArticulos As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.gridArticulos = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.lblMensaje)
        Me.ExplorerBar1.Controls.Add(Me.gridArticulos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(336, 246)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(180, 216)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(8, 168)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(312, 40)
        Me.lblMensaje.TabIndex = 2
        Me.lblMensaje.Text = "Mensaje:"
        '
        'gridArticulos
        '
        Me.gridArticulos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridArticulos.GroupByBoxVisible = False
        Me.gridArticulos.Location = New System.Drawing.Point(0, 0)
        Me.gridArticulos.Name = "gridArticulos"
        Me.gridArticulos.Size = New System.Drawing.Size(336, 160)
        Me.gridArticulos.TabIndex = 1
        Me.gridArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(258, 216)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmMensajeOrdenCompra
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 246)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMensajeOrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje Articulos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Facturacion SiHay"

#Region "Variables de Instancias"
    Dim dtSource As DataTable = Nothing
#End Region

#Region "Propiedades"

    Public Property Source() As DataTable
        Get
            Return dtSource
        End Get
        Set(ByVal Value As DataTable)
            If Not Value Is Nothing Then
                dtSource = Value
                Me.gridArticulos.DataSource = dtSource
                Me.gridArticulos.RetrieveStructure()
            Else
                dtSource = New DataTable
                Me.gridArticulos.RetrieveStructure()
            End If
        End Set
    End Property

#End Region

#Region "Metodos de Clase"
    Public Sub SetAttributesColumnsGrid(ByVal atributos As DataTable)
        For Each column As Janus.Windows.GridEX.GridEXColumn In Me.gridArticulos.RootTable.Columns
            column.Visible = False
        Next
        For Each row As DataRow In atributos.Rows
            Dim nombre As String = CStr(row!NombreColumna)
            If Me.gridArticulos.RootTable.Columns.Contains(nombre) Then
                If row.IsNull("Texto") = False Then
                    Me.gridArticulos.RootTable.Columns(nombre).Caption = CStr(row!Texto)
                End If
                If row.IsNull("Ancho") = False Then
                    Me.gridArticulos.RootTable.Columns(nombre).Width = CInt(row!Ancho)
                End If
                Me.gridArticulos.RootTable.Columns(nombre).Visible = True
                Me.gridArticulos.RootTable.Columns(nombre).EditType = Janus.Windows.GridEX.EditType.NoEdit
            End If
        Next
        Me.gridArticulos.Refresh()
    End Sub

#End Region

#Region "Form Events"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

#End Region

#End Region

    
End Class
