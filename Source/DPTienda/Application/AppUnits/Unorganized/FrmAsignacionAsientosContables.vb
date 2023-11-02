
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU


Public Class FrmAsignacionAsientosContables
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
    Friend WithEvents grAsientoContable As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignacionAsientosContables))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grAsientoContable = New Janus.Windows.GridEX.GridEX()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grAsientoContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.grAsientoContable)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.ShowGroupCaption = False
        ExplorerBarGroup1.Text = "Datos Generales del Asiento Contable"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(376, 272)
        Me.ExplorerBar1.TabIndex = 6
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grAsientoContable
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grAsientoContable.DesignTimeLayout = GridEXLayout1
        Me.grAsientoContable.GroupByBoxVisible = False
        Me.grAsientoContable.Location = New System.Drawing.Point(16, 16)
        Me.grAsientoContable.Name = "grAsientoContable"
        Me.grAsientoContable.Size = New System.Drawing.Size(344, 216)
        Me.grAsientoContable.TabIndex = 1
        Me.grAsientoContable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(279, 238)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 25)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmAsignacionAsientosContables
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 270)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsignacionAsientosContables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de Asientos Contables"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grAsientoContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Members Variables"

    Private oAsientoContable As AsignacionAsientoContable

    Private dsAsientoContable As DataSet

#End Region




#Region "Member Methods"

    Private Sub Sm_InitializeObjects()

        oAsientoContable = New AsignacionAsientoContable(oAppContext)

        dsAsientoContable = oAsientoContable.Select

        grAsientoContable.SetDataBinding(dsAsientoContable, "AsientoContableAsignacion")


        'MultiCombo.
        grAsientoContable.DropDowns("AsientoContable").SetDataBinding(dsAsientoContable, "AsientoContable")

    End Sub



    Private Sub Sm_FinalizeObjetcs()

        oAsientoContable = Nothing

        dsAsientoContable = Nothing

    End Sub



    Private Sub Sm_GuardarAsientosContables()

        oAsientoContable.AsientosContablesUpd(dsAsientoContable)

        MsgBox("Los Registros han sido Guardados.", MsgBoxStyle.Information, "DPTienda")

    End Sub

#End Region




#Region "Member Methods [Events]"

    Private Sub FrmAsignacionAsientosContables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub



    Private Sub FrmAsignacionAsientosContables_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_FinalizeObjetcs()

    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_GuardarAsientosContables()

    End Sub

#End Region

End Class
