Public Class frmArticuloFiltroDescuento
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
    Friend WithEvents btnImprimirEtiqueta As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnFacturarArticulo As Janus.Windows.EditControls.UIButton
    Friend WithEvents panel As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents lblCodArticulo As System.Windows.Forms.Label
    Public WithEvents lblDescripcion As System.Windows.Forms.Label
    Public WithEvents lblPrecioOferta As System.Windows.Forms.Label
    Public WithEvents lblDescuento As System.Windows.Forms.Label
    Public WithEvents lblPrecioNormal As System.Windows.Forms.Label
    Public WithEvents imgArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCodArticulo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblPrecioOferta = New System.Windows.Forms.Label()
        Me.btnImprimirEtiqueta = New Janus.Windows.EditControls.UIButton()
        Me.btnFacturarArticulo = New Janus.Windows.EditControls.UIButton()
        Me.panel = New System.Windows.Forms.Panel()
        Me.imgArticulo = New System.Windows.Forms.PictureBox()
        Me.btnClose = New Janus.Windows.EditControls.UIButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblPrecioNormal = New System.Windows.Forms.Label()
        Me.panel.SuspendLayout()
        CType(Me.imgArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCodArticulo
        '
        Me.lblCodArticulo.AutoSize = True
        Me.lblCodArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArticulo.Location = New System.Drawing.Point(16, 288)
        Me.lblCodArticulo.Name = "lblCodArticulo"
        Me.lblCodArticulo.Size = New System.Drawing.Size(48, 15)
        Me.lblCodArticulo.TabIndex = 1
        Me.lblCodArticulo.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(16, 312)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(176, 19)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripción"
        '
        'lblPrecioOferta
        '
        Me.lblPrecioOferta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioOferta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioOferta.Location = New System.Drawing.Point(208, 336)
        Me.lblPrecioOferta.Name = "lblPrecioOferta"
        Me.lblPrecioOferta.Size = New System.Drawing.Size(80, 16)
        Me.lblPrecioOferta.TabIndex = 5
        Me.lblPrecioOferta.Text = "$0.00"
        Me.lblPrecioOferta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimirEtiqueta
        '
        Me.btnImprimirEtiqueta.Location = New System.Drawing.Point(40, 232)
        Me.btnImprimirEtiqueta.Name = "btnImprimirEtiqueta"
        Me.btnImprimirEtiqueta.Size = New System.Drawing.Size(96, 23)
        Me.btnImprimirEtiqueta.TabIndex = 6
        Me.btnImprimirEtiqueta.Text = "Imprimir Etiqueta"
        Me.btnImprimirEtiqueta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnFacturarArticulo
        '
        Me.btnFacturarArticulo.Location = New System.Drawing.Point(152, 232)
        Me.btnFacturarArticulo.Name = "btnFacturarArticulo"
        Me.btnFacturarArticulo.Size = New System.Drawing.Size(96, 23)
        Me.btnFacturarArticulo.TabIndex = 7
        Me.btnFacturarArticulo.Text = "Facturar Articulo"
        Me.btnFacturarArticulo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'panel
        '
        Me.panel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel.BackColor = System.Drawing.Color.White
        Me.panel.Controls.Add(Me.imgArticulo)
        Me.panel.Controls.Add(Me.btnImprimirEtiqueta)
        Me.panel.Controls.Add(Me.btnFacturarArticulo)
        Me.panel.Controls.Add(Me.btnClose)
        Me.panel.Location = New System.Drawing.Point(0, 0)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(320, 264)
        Me.panel.TabIndex = 8
        '
        'imgArticulo
        '
        Me.imgArticulo.Location = New System.Drawing.Point(8, 24)
        Me.imgArticulo.Name = "imgArticulo"
        Me.imgArticulo.Size = New System.Drawing.Size(280, 192)
        Me.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgArticulo.TabIndex = 0
        Me.imgArticulo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(296, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(24, 16)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "X"
        Me.btnClose.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblDescuento)
        Me.Panel1.Controls.Add(Me.lblPrecioNormal)
        Me.Panel1.Location = New System.Drawing.Point(208, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 48)
        Me.Panel1.TabIndex = 9
        '
        'lblDescuento
        '
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(0, 24)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(64, 16)
        Me.lblDescuento.TabIndex = 6
        Me.lblDescuento.Text = "0.00%"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPrecioNormal
        '
        Me.lblPrecioNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioNormal.Location = New System.Drawing.Point(0, 6)
        Me.lblPrecioNormal.Name = "lblPrecioNormal"
        Me.lblPrecioNormal.Size = New System.Drawing.Size(64, 16)
        Me.lblPrecioNormal.TabIndex = 5
        Me.lblPrecioNormal.Text = "$0.00"
        Me.lblPrecioNormal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmArticuloFiltroDescuento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 360)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panel)
        Me.Controls.Add(Me.lblPrecioOferta)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.lblCodArticulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmArticuloFiltroDescuento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmArticuloFiltroDescuento"
        Me.panel.ResumeLayout(False)
        CType(Me.imgArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Eventos Form"
    Private Sub frmArticuloFiltroDescuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnImprimirEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirEtiqueta.Click
        If lblCodArticulo.Text.Trim() <> "" Then
            Dim frmEtiqueta As New FrmImpresionEtiquetas
            frmEtiqueta.SetCodArticulo(lblCodArticulo.Text)
            frmEtiqueta.Show()
        End If
    End Sub

    Private Sub btnFacturarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturarArticulo.Click
        If lblCodArticulo.Text.Trim() <> "" Then
            '---------------------------------------------------------------------
            ' JNAVA (24.03.2017): Validamos si está activa la nueva facturacion
            '---------------------------------------------------------------------
            If oConfigCierreFI.FacturacionNueva Then
                Dim menuClickB As New frmFacturacionNueva
                menuClickB.Show()
                menuClickB.InsertarCodigo(lblCodArticulo.Text)
            Else
                Dim menuClickB As New frmFacturacion
                menuClickB.Show()
                menuClickB.InsertarCodigo(lblCodArticulo.Text)
            End If
        End If
    End Sub
#End Region
    
    
End Class
