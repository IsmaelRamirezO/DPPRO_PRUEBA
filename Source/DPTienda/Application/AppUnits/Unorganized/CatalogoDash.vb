Public Class CatalogoDash
    Inherits System.Windows.Forms.UserControl

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoDash))
        Dim ExplorerBarItem1 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem2 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem3 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem4 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem5 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem6 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem7 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem8 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem9 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem10 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem11 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem12 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem13 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem14 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem15 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem16 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem17 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem18 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Dim ExplorerBarItem19 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(688, 600)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.ColumnSeparation = 20
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarItem1.Image = CType(resources.GetObject("ExplorerBarItem1.Image"), System.Drawing.Image)
        ExplorerBarItem1.Key = "Almacen"
        ExplorerBarItem1.Text = "Almacen"
        ExplorerBarItem2.Image = CType(resources.GetObject("ExplorerBarItem2.Image"), System.Drawing.Image)
        ExplorerBarItem2.Key = "Artículo"
        ExplorerBarItem2.Text = "Articulo"
        ExplorerBarItem3.Image = CType(resources.GetObject("ExplorerBarItem3.Image"), System.Drawing.Image)
        ExplorerBarItem3.Key = "Bancos"
        ExplorerBarItem3.Text = "Bancos"
        ExplorerBarItem4.Image = CType(resources.GetObject("ExplorerBarItem4.Image"), System.Drawing.Image)
        ExplorerBarItem4.Key = "Caja"
        ExplorerBarItem4.Text = "Caja"
        ExplorerBarItem5.Image = CType(resources.GetObject("ExplorerBarItem5.Image"), System.Drawing.Image)
        ExplorerBarItem5.Key = "Categorias"
        ExplorerBarItem5.Text = "Categorias"
        ExplorerBarItem6.Image = CType(resources.GetObject("ExplorerBarItem6.Image"), System.Drawing.Image)
        ExplorerBarItem6.Key = "Ciudades"
        ExplorerBarItem6.Text = "Ciudades"
        ExplorerBarItem7.Image = CType(resources.GetObject("ExplorerBarItem7.Image"), System.Drawing.Image)
        ExplorerBarItem7.Key = "Clientes"
        ExplorerBarItem7.Text = "Clientes"
        ExplorerBarItem8.Image = CType(resources.GetObject("ExplorerBarItem8.Image"), System.Drawing.Image)
        ExplorerBarItem8.Key = "Colonias"
        ExplorerBarItem8.Text = "Colonias"
        ExplorerBarItem9.Image = CType(resources.GetObject("ExplorerBarItem9.Image"), System.Drawing.Image)
        ExplorerBarItem9.Key = "Estados"
        ExplorerBarItem9.Text = "Estados"
        ExplorerBarItem10.Image = CType(resources.GetObject("ExplorerBarItem10.Image"), System.Drawing.Image)
        ExplorerBarItem10.Key = "Familia"
        ExplorerBarItem10.Text = "Familia"
        ExplorerBarItem11.Image = CType(resources.GetObject("ExplorerBarItem11.Image"), System.Drawing.Image)
        ExplorerBarItem11.Key = "Forma de Pago"
        ExplorerBarItem11.Text = "Forma de Pago"
        ExplorerBarItem12.Image = CType(resources.GetObject("ExplorerBarItem12.Image"), System.Drawing.Image)
        ExplorerBarItem12.Key = "Lineas"
        ExplorerBarItem12.Text = "Lineas"
        ExplorerBarItem13.Image = CType(resources.GetObject("ExplorerBarItem13.Image"), System.Drawing.Image)
        ExplorerBarItem13.Key = "Marcas"
        ExplorerBarItem13.Text = "Marcas"
        ExplorerBarItem14.Image = CType(resources.GetObject("ExplorerBarItem14.Image"), System.Drawing.Image)
        ExplorerBarItem14.Key = "Player"
        ExplorerBarItem14.Text = "Player"
        ExplorerBarItem15.Image = CType(resources.GetObject("ExplorerBarItem15.Image"), System.Drawing.Image)
        ExplorerBarItem15.Key = "Plaza"
        ExplorerBarItem15.Text = "Plaza"
        ExplorerBarItem16.Image = CType(resources.GetObject("ExplorerBarItem16.Image"), System.Drawing.Image)
        ExplorerBarItem16.Key = "Tipo Descuento"
        ExplorerBarItem16.Text = "Tipo Descuento"
        ExplorerBarItem17.Image = CType(resources.GetObject("ExplorerBarItem17.Image"), System.Drawing.Image)
        ExplorerBarItem17.Key = "Tipo Tarjeta"
        ExplorerBarItem17.Text = "Tipo Tarjeta"
        ExplorerBarItem18.Image = CType(resources.GetObject("ExplorerBarItem18.Image"), System.Drawing.Image)
        ExplorerBarItem18.Key = "Tipo Venta"
        ExplorerBarItem18.Text = "Tipo Venta"
        ExplorerBarItem19.Image = CType(resources.GetObject("ExplorerBarItem19.Image"), System.Drawing.Image)
        ExplorerBarItem19.Key = "Usos"
        ExplorerBarItem19.Text = "Usos"
        ExplorerBarGroup1.Items.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarItem() {ExplorerBarItem1, ExplorerBarItem2, ExplorerBarItem3, ExplorerBarItem4, ExplorerBarItem5, ExplorerBarItem6, ExplorerBarItem7, ExplorerBarItem8, ExplorerBarItem9, ExplorerBarItem10, ExplorerBarItem11, ExplorerBarItem12, ExplorerBarItem13, ExplorerBarItem14, ExplorerBarItem15, ExplorerBarItem16, ExplorerBarItem17, ExplorerBarItem18, ExplorerBarItem19})
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.StateStyles.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Text = "Coleccion de Catalogos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(3, 8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(682, 589)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'CatalogoDash
        '
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Name = "CatalogoDash"
        Me.Size = New System.Drawing.Size(688, 600)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

        Select Case e.Item.Key

            Case "Almacen"
                Dim oAlmacenForm As New CatalogoAlmacenesForm
                oAlmacenForm.Show()
            Case "Artículo"
                Dim oAlmacenForm As New CatalogoArticulosForm
                oAlmacenForm.Show()
            Case "Bancos"
                Dim oAlmacenForm As New CatalogoBancosForm
                oAlmacenForm.Show()
            Case "Caja"
                Dim oAlmacenForm As New CatalogoCajaForm
                oAlmacenForm.Show()
            Case "Categorias"
                Dim oAlmacenForm As New CatalogoCategoriasForm
                oAlmacenForm.Show()
            Case "Ciudades"
                Dim oAlmacenForm As New CatalogoCiudadesForm
                oAlmacenForm.Show()
            Case "Clientes"
                Dim oAlmacenForm As New CatalogoClientesForm
                oAlmacenForm.Show()
            Case "Codigo UPC"
                Dim oAlmacenForm As New CodigoUPCForm
                oAlmacenForm.Show()
            Case "Colonias"
                Dim oAlmacenForm As New frmColonias
                oAlmacenForm.Show()
            Case "Corridas"
                Dim oAlmacenForm As New frmCorridas
                oAlmacenForm.Show()
            Case "Estados"
                Dim oAlmacenForm As New frmEstado
                oAlmacenForm.Show()
            Case "Familia"
                Dim oAlmacenForm As New CatalogoFamiliasForm
                oAlmacenForm.Show()
            Case "Forma de Pago"
                Dim oAlmacenForm As New frmformadepago
                oAlmacenForm.Show()
            Case "Lineas"
                Dim oAlmacenForm As New CatalogoLineasForm
                oAlmacenForm.Show()
            Case "Marcas"
                Dim oAlmacenForm As New CatalogoMarcasForm
                oAlmacenForm.Show()
            Case "Origines"
                Dim oAlmacenForm As New frmOrigen
                oAlmacenForm.Show()
            Case "Plaza"
                Dim oAlmacenForm As New CatalogoPlazasForm
                oAlmacenForm.Show()
            Case "Player"
                Dim oAlmacenForm As New CatalogoPlayer
                oAlmacenForm.Show()
            Case "Publicaciones"
                Dim oAlmacenForm As New frmPublicaciones
                oAlmacenForm.Show()
            Case "Status del Articulo"
                Dim oAlmacenForm As New frmStatus
                oAlmacenForm.Show()
            Case "Tipo Cliente"
                Dim oAlmacenForm As New frmTipoCliente
                oAlmacenForm.Show()
            Case "Tipo Descuento"
                Dim oAlmacenForm As New frmTipoDescuento
                oAlmacenForm.Show()
            Case "Tipo Movimiento"
                Dim oAlmacenForm As New frmTipoMovimiento
                oAlmacenForm.Show()
            Case "Tipo Tarjeta"
                Dim oAlmacenForm As New frmTipoTarjeta
                oAlmacenForm.Show()
            Case "Tipo Venta"
                Dim oAlmacenForm As New frmTipoVenta
                oAlmacenForm.Show()
            Case "Unidades"
                Dim oAlmacenForm As New CatalogoUnidadForm
                oAlmacenForm.Show()
            Case "Usos"
                Dim oAlmacenForm As New CatalogoUsosForm
                oAlmacenForm.Show()
            Case "Vales"
                Dim oAlmacenForm As New frmVales
                oAlmacenForm.Show()

        End Select

    End Sub

End Class
