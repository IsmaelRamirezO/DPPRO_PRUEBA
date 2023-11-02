
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU


Public Class FrmSegmentoContable
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
    Friend WithEvents btAlmacen As Janus.Windows.EditControls.UIButton
    Friend WithEvents btBanco As Janus.Windows.EditControls.UIButton
    Friend WithEvents btClientes As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCuentaBancaria As Janus.Windows.EditControls.UIButton
    Friend WithEvents btDescuentos As Janus.Windows.EditControls.UIButton
    Friend WithEvents btFormaPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents btTipoVenta As Janus.Windows.EditControls.UIButton
    Friend WithEvents grSegmentoContable As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSegmentoContable))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.grSegmentoContable = New Janus.Windows.GridEX.GridEX()
        Me.btFormaPago = New Janus.Windows.EditControls.UIButton()
        Me.btDescuentos = New Janus.Windows.EditControls.UIButton()
        Me.btCuentaBancaria = New Janus.Windows.EditControls.UIButton()
        Me.btClientes = New Janus.Windows.EditControls.UIButton()
        Me.btBanco = New Janus.Windows.EditControls.UIButton()
        Me.btAlmacen = New Janus.Windows.EditControls.UIButton()
        Me.btTipoVenta = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grSegmentoContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.grSegmentoContable)
        Me.ExplorerBar1.Controls.Add(Me.btFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.btDescuentos)
        Me.ExplorerBar1.Controls.Add(Me.btCuentaBancaria)
        Me.ExplorerBar1.Controls.Add(Me.btClientes)
        Me.ExplorerBar1.Controls.Add(Me.btBanco)
        Me.ExplorerBar1.Controls.Add(Me.btAlmacen)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Definición de Segmentos Contables"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(504, 320)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(407, 287)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 25)
        Me.btnGuardar.TabIndex = 14
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grSegmentoContable
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grSegmentoContable.DesignTimeLayout = GridEXLayout1
        Me.grSegmentoContable.GroupByBoxVisible = False
        Me.grSegmentoContable.Location = New System.Drawing.Point(160, 40)
        Me.grSegmentoContable.Name = "grSegmentoContable"
        Me.grSegmentoContable.Size = New System.Drawing.Size(328, 239)
        Me.grSegmentoContable.TabIndex = 13
        Me.grSegmentoContable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btFormaPago
        '
        Me.btFormaPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFormaPago.Image = CType(resources.GetObject("btFormaPago.Image"), System.Drawing.Image)
        Me.btFormaPago.Location = New System.Drawing.Point(16, 210)
        Me.btFormaPago.Name = "btFormaPago"
        Me.btFormaPago.Size = New System.Drawing.Size(128, 32)
        Me.btFormaPago.TabIndex = 12
        Me.btFormaPago.Text = "Formas de Pago"
        Me.btFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btDescuentos
        '
        Me.btDescuentos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDescuentos.Image = CType(resources.GetObject("btDescuentos.Image"), System.Drawing.Image)
        Me.btDescuentos.Location = New System.Drawing.Point(16, 176)
        Me.btDescuentos.Name = "btDescuentos"
        Me.btDescuentos.Size = New System.Drawing.Size(128, 32)
        Me.btDescuentos.TabIndex = 11
        Me.btDescuentos.Text = "Descuentos"
        Me.btDescuentos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btCuentaBancaria
        '
        Me.btCuentaBancaria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCuentaBancaria.Image = CType(resources.GetObject("btCuentaBancaria.Image"), System.Drawing.Image)
        Me.btCuentaBancaria.Location = New System.Drawing.Point(16, 142)
        Me.btCuentaBancaria.Name = "btCuentaBancaria"
        Me.btCuentaBancaria.Size = New System.Drawing.Size(128, 32)
        Me.btCuentaBancaria.TabIndex = 10
        Me.btCuentaBancaria.Text = "Ctas. Bancarias"
        Me.btCuentaBancaria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btClientes
        '
        Me.btClientes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClientes.Image = CType(resources.GetObject("btClientes.Image"), System.Drawing.Image)
        Me.btClientes.Location = New System.Drawing.Point(16, 108)
        Me.btClientes.Name = "btClientes"
        Me.btClientes.Size = New System.Drawing.Size(128, 32)
        Me.btClientes.TabIndex = 9
        Me.btClientes.Text = "Clientes"
        Me.btClientes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btBanco
        '
        Me.btBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btBanco.Image = CType(resources.GetObject("btBanco.Image"), System.Drawing.Image)
        Me.btBanco.Location = New System.Drawing.Point(16, 74)
        Me.btBanco.Name = "btBanco"
        Me.btBanco.Size = New System.Drawing.Size(128, 32)
        Me.btBanco.TabIndex = 8
        Me.btBanco.Text = "Bancos"
        Me.btBanco.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btAlmacen
        '
        Me.btAlmacen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAlmacen.Image = CType(resources.GetObject("btAlmacen.Image"), System.Drawing.Image)
        Me.btAlmacen.Location = New System.Drawing.Point(16, 40)
        Me.btAlmacen.Name = "btAlmacen"
        Me.btAlmacen.Size = New System.Drawing.Size(128, 32)
        Me.btAlmacen.TabIndex = 7
        Me.btAlmacen.Text = "Almacén"
        Me.btAlmacen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btTipoVenta
        '
        Me.btTipoVenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTipoVenta.Image = CType(resources.GetObject("btTipoVenta.Image"), System.Drawing.Image)
        Me.btTipoVenta.Location = New System.Drawing.Point(16, 244)
        Me.btTipoVenta.Name = "btTipoVenta"
        Me.btTipoVenta.Size = New System.Drawing.Size(128, 32)
        Me.btTipoVenta.TabIndex = 8
        Me.btTipoVenta.Text = "Tipo de Venta"
        Me.btTipoVenta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmSegmentoContable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 318)
        Me.Controls.Add(Me.btTipoVenta)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSegmentoContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Segmentos Contables"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grSegmentoContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Members Variables"

    Private oSegmentoContable As SegmentoContable

    Private dsSegmentoContable As DataSet

#End Region




#Region "Member Methods"

    Private Sub Sm_InitializeObjects()

        oSegmentoContable = New SegmentoContable(oAppContext)

        dsSegmentoContable = oSegmentoContable.Select

        grSegmentoContable.SetDataBinding(dsSegmentoContable, "SegmentosCont")

    End Sub



    Private Sub Sm_FinalizeObjetcs()

        oSegmentoContable = Nothing

        dsSegmentoContable = Nothing

    End Sub



    Private Function Fm_bolValidar() As Boolean

        Dim dr As DataRow

        For Each dr In dsSegmentoContable.Tables("SegmentosCont").Rows

            If IsDBNull(dr!Segmento) = True Then

                MsgBox("En el Registro " & dr!Concepto & " falta información.")
                Exit Function

            ElseIf (Trim(dr!Segmento) = String.Empty) Then

                MsgBox("En el Registro " & dr!Concepto & " falta información.")
                Exit Function

            End If

        Next

        Return True

    End Function



    Private Sub Sm_GuardarSegmentosContables()

        If (Fm_bolValidar() = False) Then
            Return
        End If

        oSegmentoContable.SegmentosContablesUpd(dsSegmentoContable)

        MsgBox("Registros Guardados", MsgBoxStyle.Exclamation, "DPTienda")

    End Sub


#End Region




#Region "Member Methods [Events]"

    Private Sub FrmSegmentoContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub




    Private Sub FrmSegmentoContable_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_FinalizeObjetcs()

    End Sub




    Private Sub btAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAlmacen.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "Almacen"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub



    Private Sub btBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBanco.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "Banco"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub




    Private Sub btDescuentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDescuentos.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "TipoDescuento"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub




    Private Sub btFormaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFormaPago.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "FormaPago"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub




    Private Sub btTipoVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTipoVenta.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "TipoVenta"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub




    Private Sub btClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClientes.Click

        Dim oFrmSegmentoContableDetalle As New FrmSegmentoContableDetalle


        oFrmSegmentoContableDetalle.Cuenta = "Cliente"

        oFrmSegmentoContableDetalle.ShowDialog()

        oFrmSegmentoContableDetalle.Dispose()

        oFrmSegmentoContableDetalle = Nothing

    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_GuardarSegmentosContables()

    End Sub

#End Region
End Class
