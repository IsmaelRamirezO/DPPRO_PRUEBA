Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Public Class frmActualizaciones
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rdbArticulos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbDescuentos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbClientes As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbVendedores As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnActualizar As Janus.Windows.EditControls.UIButton
    Friend WithEvents rdbInventario As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbCodigosUPC As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rdbCobranzas As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPromociones As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbAlmacenes As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDescuentosAdicionales As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbMarcas As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRazonesRechazo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbCodigosPostales As Janus.Windows.EditControls.UIRadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActualizaciones))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbCodigosPostales = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRazonesRechazo = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbMarcas = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDescuentosAdicionales = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbAlmacenes = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPromociones = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbCobranzas = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbCodigosUPC = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbInventario = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbVendedores = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbClientes = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbDescuentos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rdbArticulos = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnActualizar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.btnActualizar)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(272, 416)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.rbCodigosPostales)
        Me.UiGroupBox1.Controls.Add(Me.rbRazonesRechazo)
        Me.UiGroupBox1.Controls.Add(Me.rbMarcas)
        Me.UiGroupBox1.Controls.Add(Me.rbDescuentosAdicionales)
        Me.UiGroupBox1.Controls.Add(Me.rbAlmacenes)
        Me.UiGroupBox1.Controls.Add(Me.rbPromociones)
        Me.UiGroupBox1.Controls.Add(Me.rdbCobranzas)
        Me.UiGroupBox1.Controls.Add(Me.rdbCodigosUPC)
        Me.UiGroupBox1.Controls.Add(Me.rdbInventario)
        Me.UiGroupBox1.Controls.Add(Me.rdbVendedores)
        Me.UiGroupBox1.Controls.Add(Me.rdbClientes)
        Me.UiGroupBox1.Controls.Add(Me.rdbDescuentos)
        Me.UiGroupBox1.Controls.Add(Me.rdbArticulos)
        Me.UiGroupBox1.Location = New System.Drawing.Point(32, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(208, 344)
        Me.UiGroupBox1.TabIndex = 8
        Me.UiGroupBox1.Text = "Opciones"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'rbCodigosPostales
        '
        Me.rbCodigosPostales.Location = New System.Drawing.Point(24, 312)
        Me.rbCodigosPostales.Name = "rbCodigosPostales"
        Me.rbCodigosPostales.Size = New System.Drawing.Size(140, 23)
        Me.rbCodigosPostales.TabIndex = 12
        Me.rbCodigosPostales.Text = "Codigos Postales"
        Me.rbCodigosPostales.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbRazonesRechazo
        '
        Me.rbRazonesRechazo.Location = New System.Drawing.Point(24, 288)
        Me.rbRazonesRechazo.Name = "rbRazonesRechazo"
        Me.rbRazonesRechazo.Size = New System.Drawing.Size(140, 23)
        Me.rbRazonesRechazo.TabIndex = 11
        Me.rbRazonesRechazo.Text = "Razones de Rechazo"
        Me.rbRazonesRechazo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbMarcas
        '
        Me.rbMarcas.Location = New System.Drawing.Point(24, 264)
        Me.rbMarcas.Name = "rbMarcas"
        Me.rbMarcas.Size = New System.Drawing.Size(140, 23)
        Me.rbMarcas.TabIndex = 10
        Me.rbMarcas.Text = "Catalogos"
        Me.rbMarcas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbDescuentosAdicionales
        '
        Me.rbDescuentosAdicionales.Location = New System.Drawing.Point(24, 240)
        Me.rbDescuentosAdicionales.Name = "rbDescuentosAdicionales"
        Me.rbDescuentosAdicionales.Size = New System.Drawing.Size(176, 23)
        Me.rbDescuentosAdicionales.TabIndex = 9
        Me.rbDescuentosAdicionales.Text = "Promociones Comerciales"
        Me.rbDescuentosAdicionales.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbAlmacenes
        '
        Me.rbAlmacenes.Location = New System.Drawing.Point(24, 216)
        Me.rbAlmacenes.Name = "rbAlmacenes"
        Me.rbAlmacenes.Size = New System.Drawing.Size(104, 24)
        Me.rbAlmacenes.TabIndex = 8
        Me.rbAlmacenes.Text = "Almacenes"
        Me.rbAlmacenes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbPromociones
        '
        Me.rbPromociones.Location = New System.Drawing.Point(24, 192)
        Me.rbPromociones.Name = "rbPromociones"
        Me.rbPromociones.Size = New System.Drawing.Size(168, 23)
        Me.rbPromociones.TabIndex = 7
        Me.rbPromociones.Text = "Promociones Bancarias"
        Me.rbPromociones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbCobranzas
        '
        Me.rdbCobranzas.Location = New System.Drawing.Point(24, 72)
        Me.rdbCobranzas.Name = "rdbCobranzas"
        Me.rdbCobranzas.Size = New System.Drawing.Size(104, 23)
        Me.rdbCobranzas.TabIndex = 2
        Me.rdbCobranzas.Text = "Cobranza"
        Me.rdbCobranzas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbCodigosUPC
        '
        Me.rdbCodigosUPC.Location = New System.Drawing.Point(24, 168)
        Me.rdbCodigosUPC.Name = "rdbCodigosUPC"
        Me.rdbCodigosUPC.Size = New System.Drawing.Size(88, 24)
        Me.rdbCodigosUPC.TabIndex = 6
        Me.rdbCodigosUPC.Text = "Codigos UPC"
        Me.rdbCodigosUPC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbInventario
        '
        Me.rdbInventario.Location = New System.Drawing.Point(24, 120)
        Me.rdbInventario.Name = "rdbInventario"
        Me.rdbInventario.Size = New System.Drawing.Size(104, 23)
        Me.rdbInventario.TabIndex = 4
        Me.rdbInventario.Text = "Inventario"
        Me.rdbInventario.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbVendedores
        '
        Me.rdbVendedores.Location = New System.Drawing.Point(24, 144)
        Me.rdbVendedores.Name = "rdbVendedores"
        Me.rdbVendedores.Size = New System.Drawing.Size(104, 23)
        Me.rdbVendedores.TabIndex = 5
        Me.rdbVendedores.Text = "Vendedores"
        Me.rdbVendedores.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbClientes
        '
        Me.rdbClientes.Location = New System.Drawing.Point(24, 48)
        Me.rdbClientes.Name = "rdbClientes"
        Me.rdbClientes.Size = New System.Drawing.Size(104, 23)
        Me.rdbClientes.TabIndex = 1
        Me.rdbClientes.Text = "Clientes"
        Me.rdbClientes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbDescuentos
        '
        Me.rdbDescuentos.Location = New System.Drawing.Point(24, 96)
        Me.rdbDescuentos.Name = "rdbDescuentos"
        Me.rdbDescuentos.Size = New System.Drawing.Size(160, 23)
        Me.rdbDescuentos.TabIndex = 3
        Me.rdbDescuentos.Text = "Descuentos y Precios"
        Me.rdbDescuentos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rdbArticulos
        '
        Me.rdbArticulos.Checked = True
        Me.rdbArticulos.Location = New System.Drawing.Point(24, 24)
        Me.rdbArticulos.Name = "rdbArticulos"
        Me.rdbArticulos.Size = New System.Drawing.Size(104, 23)
        Me.rdbArticulos.TabIndex = 0
        Me.rdbArticulos.TabStop = True
        Me.rdbArticulos.Text = "Articulos"
        Me.rdbArticulos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(32, 360)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(208, 40)
        Me.btnActualizar.TabIndex = 7
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmActualizaciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(272, 416)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActualizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizaciones"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click

        Dim oSAPMgr As ProcesoSAPManager
        Dim ofrmLoad As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        ofrmLoad.Timer1.Enabled = False
        If Me.rdbArticulos.Checked Then
            ofrmLoad.ShowDev("Articulos")
        ElseIf Me.rdbClientes.Checked Then
            ofrmLoad.ShowDev("Clientes")
        ElseIf Me.rdbCobranzas.Checked Then
            ofrmLoad.ShowDev("Cobranza")
        ElseIf Me.rdbCodigosUPC.Checked Then
            ofrmLoad.ShowDev("CodigosUPC")
        ElseIf Me.rdbDescuentos.Checked Then
            ofrmLoad.ShowDev("Descuentos")
        ElseIf Me.rdbInventario.Checked Then
            ofrmLoad.ShowDev("Inventarios")
        ElseIf Me.rdbVendedores.Checked Then
            ofrmLoad.ShowDev("Vendedores")
        ElseIf Me.rbPromociones.Checked Then
            ofrmLoad.ShowDev("Promociones")
        ElseIf Me.rbAlmacenes.Checked Then
            ofrmLoad.ShowDev("Almacenes")
        ElseIf Me.rbDescuentosAdicionales.Checked Then
            ofrmLoad.ShowDev("DescuentosAdicionales")
        ElseIf Me.rbMarcas.Checked Then
            ofrmLoad.ShowDev("Marcas")
        ElseIf Me.rbRazonesRechazo.Checked Then
            ofrmLoad.ShowDev("RazonesRechazo")
        ElseIf Me.rbCodigosPostales.Checked Then
            ofrmLoad.ShowDev("CodigosPostales")
        End If

    End Sub


    Private Sub frmActualizaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If oConfigCierreFI.UsarDescargaClientes Then
            Me.rdbClientes.Enabled = True
        Else
            Me.rdbClientes.Enabled = False
        End If


        '-----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (19.12.2014): Validamos que SI aplica el CrossSelling, se deshabilita la descarga de promociones vigentes
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'If Not oConfigCierreFI.AplicaCrossSelling Then
        '    Me.rbDescuentosAdicionales.Enabled = True
        'Else
        '    Me.rbDescuentosAdicionales.Enabled = False
        'End If


    End Sub

End Class
