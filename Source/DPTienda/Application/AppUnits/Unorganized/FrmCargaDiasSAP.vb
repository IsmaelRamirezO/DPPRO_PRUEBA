Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU

Public Class FrmCargaDiasSAP
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
    Friend WithEvents btnGenArch As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargaDiasSAP))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenArch = New Janus.Windows.EditControls.UIButton()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnGenArch)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-4, -1)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(320, 177)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenArch
        '
        Me.btnGenArch.Icon = CType(resources.GetObject("btnGenArch.Icon"), System.Drawing.Icon)
        Me.btnGenArch.Location = New System.Drawing.Point(108, 128)
        Me.btnGenArch.Name = "btnGenArch"
        Me.btnGenArch.Size = New System.Drawing.Size(104, 32)
        Me.btnGenArch.TabIndex = 3
        Me.btnGenArch.Text = "&Cargar"
        Me.btnGenArch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Location = New System.Drawing.Point(120, 56)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(142, 23)
        Me.ebFecha.TabIndex = 0
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(65, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 72)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'FrmCargaDiasSAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 178)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(318, 206)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(318, 206)
        Me.Name = "FrmCargaDiasSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar Dias en SAP"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oCierreDiasMgr As CierreDiaManager

    Private Sub btnGenArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenArch.Click

        oCierreDiasMgr = New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        ''Guardar en SAP los archivos Polizas
        If Not oCierreDiasMgr.EjecutarZBAPIFI05_VENTASDIA(ebFecha.Value) Then
            'Si no se carga COrrectamente mandar mensajes
            MessageBox.Show("No se cargo correctamente el Archivo de Cierre de Dia en SAP Favor de Avisar a SOPORTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Se cargo correctamente el Archivo de Cierre de Dia en SAP ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
End Class
