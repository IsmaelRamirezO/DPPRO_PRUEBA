<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemColor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemColor))
        Me.gridItemsColor = New Janus.Windows.GridEX.GridEX()
        Me.expBottom = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnSeleccionar = New Janus.Windows.EditControls.UIButton()
        CType(Me.gridItemsColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.expBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridItemsColor
        '
        Me.gridItemsColor.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridItemsColor.DesignTimeLayout = GridEXLayout1
        Me.gridItemsColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridItemsColor.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gridItemsColor.GroupByBoxVisible = False
        Me.gridItemsColor.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridItemsColor.Location = New System.Drawing.Point(0, 0)
        Me.gridItemsColor.Name = "gridItemsColor"
        Me.gridItemsColor.Size = New System.Drawing.Size(360, 125)
        Me.gridItemsColor.TabIndex = 25
        Me.gridItemsColor.TabStop = False
        Me.gridItemsColor.TotalRowFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridItemsColor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'expBottom
        '
        Me.expBottom.Controls.Add(Me.btnCancelar)
        Me.expBottom.Controls.Add(Me.btnSeleccionar)
        Me.expBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.expBottom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expBottom.Location = New System.Drawing.Point(0, 86)
        Me.expBottom.Name = "expBottom"
        Me.expBottom.Size = New System.Drawing.Size(360, 39)
        Me.expBottom.TabIndex = 26
        Me.expBottom.Text = "ExplorerBar1"
        Me.expBottom.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(273, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 31)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Location = New System.Drawing.Point(183, 5)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(84, 31)
        Me.btnSeleccionar.TabIndex = 27
        Me.btnSeleccionar.Text = "&Seleccionar"
        Me.btnSeleccionar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmItemColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 125)
        Me.Controls.Add(Me.expBottom)
        Me.Controls.Add(Me.gridItemsColor)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos por colores"
        CType(Me.gridItemsColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.expBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridItemsColor As Janus.Windows.GridEX.GridEX
    Friend WithEvents expBottom As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSeleccionar As Janus.Windows.EditControls.UIButton
End Class
