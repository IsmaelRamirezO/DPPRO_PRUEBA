Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmConsultaSiHay
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InicializarVariables()
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
    Friend WithEvents gridExistencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaSiHay))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.gridExistencia = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnActualizar)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.gridExistencia)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(466, 256)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "grupoExistencia"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.Location = New System.Drawing.Point(48, 224)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 5
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(376, 224)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        Me.btnCancelar.WordWrap = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(288, 224)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        Me.btnAceptar.WordWrap = False
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(288, 224)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 24)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'gridExistencia
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridExistencia.DesignTimeLayout = GridEXLayout1
        Me.gridExistencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridExistencia.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridExistencia.GroupByBoxVisible = False
        Me.gridExistencia.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.gridExistencia.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.gridExistencia.Location = New System.Drawing.Point(0, 0)
        Me.gridExistencia.Name = "gridExistencia"
        Me.gridExistencia.Size = New System.Drawing.Size(466, 216)
        Me.gridExistencia.TabIndex = 1
        Me.gridExistencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmConsultaSiHay
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(466, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConsultaSiHay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Existencias de productos en Almacenes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gridExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables de Instancias"
    Private dtExistencias As DataTable
    Private dtArticulos As DataTable
    Private CodAlmacen As String
    Private view As DataView
    Private AceptarMinimos As Boolean = True
    Private ValidarMinimos As Boolean = False
    Private source_minimo As DataTable = Nothing

#End Region

#Region "Propiedades"

    Public Property Almacen() As String
        Get
            Return CodAlmacen
        End Get
        Set(ByVal Value As String)
            CodAlmacen = Value
        End Set
    End Property

    Public Property SourceMinimo() As DataTable
        Get
            Return source_minimo
        End Get
        Set(ByVal Value As DataTable)
            source_minimo = Value
        End Set
    End Property

#End Region

#Region "Metodos"

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Se inicializan las variables 
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        dtExistencias = New DataTable("ExistenciasMinimas")
        dtExistencias.Columns.Add("CodArticulo", GetType(String))
        dtExistencias.Columns.Add("Numero", GetType(String))
        dtExistencias.Columns.Add("Sucursal", GetType(String))
        dtExistencias.Columns.Add("Existencia", GetType(Integer))
        dtExistencias.Columns.Add("Prioridad", GetType(Integer))
        dtExistencias.Columns.Add("Telefono", GetType(String))
        dtExistencias.Columns.Add("Checado", GetType(Boolean))
        dtExistencias.AcceptChanges()
        Me.gridExistencia.DataSource = dtExistencias
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Función para cargar las existencias de todos los almacenes
    '-------------------------------------------------------------------------------------------------------------------------------------

    Public Function CargarExistencias(ByVal articulos As DataTable)
        dtArticulos = articulos
        dtExistencias.Rows.Clear()
        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim source As DataSet = procesoMgr.ZSH_DISPONIBILIDAD(dtArticulos)
        If Not source Is Nothing Then
            Dim dtMinimaExistencia As DataTable = source.Tables("T_MINIMAEXISTENCIA")
            Dim almacen As almacen
            For Each row As DataRow In source.Tables("T_DISPONIBLES").Rows
                Dim CodArticulo As String = CStr(row!MATNR)
                Dim fila As DataRow = Nothing
                fila = dtExistencias.NewRow()
                fila("CodArticulo") = CStr(row!MATNR)
                fila("Numero") = CStr(row!TALLA)
                fila("Sucursal") = CStr(row!WERKS)
                fila("Existencia") = CInt(row!CANTIDAD)
                fila("Prioridad") = CInt(row!PRIORIDAD)
                almacen = CargarAlmacen(CStr(row!WERKS))
                fila("Telefono") = almacen.TelefonoLada & almacen.TelefonoNum
                fila("Checado") = False
                dtExistencias.Rows.Add(fila)
            Next
            Me.Size = New Size(New Point(368, 288))
            Me.btnAceptar.Visible = False
            Me.btnCancelar.Visible = False
            Me.btnSalir.Visible = True
            Me.gridExistencia.RootTable.Columns("Telefono").Visible = False
            Me.gridExistencia.RootTable.Columns("Checado").Visible = False
        End If
        dtExistencias.AcceptChanges()
        Dim view As New DataView(dtExistencias)
        view.Sort = "Prioridad"
        Me.gridExistencia.DataSource = Nothing
        Me.gridExistencia.DataSource = view
        Me.gridExistencia.Refresh()

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Funcion para cargar las sucursales que tienen las minimas existencias del producto
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function CargarExistenciasMinimos(ByVal articulos As DataTable, Optional ByVal show As Boolean = True)
        dtArticulos = articulos
        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim minimos As DataTable = Nothing
        Dim source As DataSet = procesoMgr.ZSH_DISPONIBILIDAD(dtArticulos, True)
        dtExistencias.Rows.Clear()
        If Not source Is Nothing Then
            Dim dtMinimaExistencia As DataTable = source.Tables("T_MINIMAEXISTENCIA")
            Dim almacen As almacen
            For Each row As DataRow In dtMinimaExistencia.Rows
                Dim fila As DataRow = dtExistencias.NewRow()
                fila = dtExistencias.NewRow()
                fila("CodArticulo") = CStr(row!MATNR)
                fila("Numero") = CStr(row!TALLA)
                fila("Sucursal") = CStr(row!WERKS)
                fila("Existencia") = CInt(row!CANTIDAD)
                fila("Prioridad") = CInt(row!PRIORIDAD)
                almacen = CargarAlmacen(CStr(row!WERKS))
                fila("Telefono") = almacen.TelefonoLada & almacen.TelefonoNum
                fila("Checado") = False
                dtExistencias.Rows.Add(fila)
            Next
            If dtMinimaExistencia.Rows.Count > 0 Then
                Me.Size = New Size(New Point(472, 288))
                Me.btnAceptar.Visible = True
                Me.btnCancelar.Visible = True
                Me.btnSalir.Visible = False
                Me.gridExistencia.RootTable.Columns("Telefono").Visible = True
                Me.gridExistencia.RootTable.Columns("Checado").Visible = True
                Me.gridExistencia.GroupMode = Janus.Windows.GridEX.GroupMode.Expanded
                dtExistencias.AcceptChanges()
                view = New DataView(dtExistencias)
                view.Sort = "Prioridad"
                Me.gridExistencia.DataSource = Nothing
                Me.gridExistencia.DataSource = view
                Me.gridExistencia.Refresh()
                minimos = view.Table.Copy()
                Me.ValidarMinimos = True
                If show = True Then Me.ShowDialog()
            End If
        End If
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 19/04/2013: Obtiene el DataSource de las consultas de existencias
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function GetDataSourceMinimo() As DataTable
        If Not Me.SourceMinimo Is Nothing AndAlso Me.SourceMinimo.Rows.Count > 0 Then
            Return Me.SourceMinimo
        Else
            Return Nothing
        End If
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Función para obtener el objeto Almacen
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function CargarAlmacen(ByVal codigo As String) As Almacen
        Dim AlmacenMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim sap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim restService As New ProcesosRetail("pos/tienda", "POST")

        Dim arrayAlmacen = sap.Read_CentrosSAP(codigo)
        Dim stock As Almacen
        stock = AlmacenMgr.Create()
        AlmacenMgr.LoadInto(arrayAlmacen(0), stock)
        Return stock
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Función que revisa si ya existe un articulo en el detalle
    '------------------------------------------------------------------------------------------------------------------------------------

    Private Function ExisteArticuloEnDetalle(ByVal codigo As String) As Boolean
        For Each row As DataRow In dtExistencias.Rows
            Dim articulo As String = CStr(row!CodArticulo)
            If articulo = codigo Then
                Return True
            End If
        Next
        Return False
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Función para obtener el objeto del Articulo
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Function GetArticuloEnDetalle(ByVal Codigo As String) As DataRow
        For Each row As DataRow In dtExistencias.Rows
            Dim articulo As String = CStr(row!CodArticulo)
            If articulo = Codigo Then
                Return row
            End If
        Next
        Return Nothing
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA Fecha:16/04/2013: Función para eliminar articulos que ya fueron eliminadas de la factura
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Function EliminarArticuloNoExistentes(ByVal articulos As DataTable)
        Dim i As Integer = 0, j As Integer = 0
        If dtExistencias.Rows.Count > 0 Then
            For i = dtExistencias.Rows.Count - 1 To 0
                Dim valido As Boolean = False
                Dim row As DataRow = dtExistencias.Rows(i)
                Dim codigo As String = CStr(row!CodArticulo)
                For Each oRow As DataRow In articulos.Rows
                    Dim art As String = CStr(oRow!CodArticulo)
                    If art = codigo Then
                        valido = True
                    End If
                Next
                If valido = False Then
                    dtExistencias.Rows.Remove(row)
                End If
            Next
        End If
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Valida si los minimos fueron aceptados
    '----------------------------------------------------------------------------------------------------------------------------------

    Public Function FueAceptadoMinimos() As Boolean
        Dim valido As Boolean = Me.AceptarMinimos

        Me.Dispose()
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Valida que los articulos pedidos coincidad con las existencias de las tiendas seleccionadas
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function ValidarCantidadesMinimas() As Boolean
        Dim valido As Boolean = True
        Dim minimos As DataTable = view.Table.Copy()
        Dim msg As String = "En estos articulos no coinciden la cantidad pedida con la de la cantidad de las tiendas seleccionada" & vbCrLf
        For Each row As DataRow In Me.dtArticulos.Rows
            Dim codigo As String = CStr(row!CodArticulo)
            Dim cantidad As Integer = CInt(row!Cantidad)
            Dim talla As String = ""
            If IsNumeric(CStr(row!Numero)) Then
                talla = Format(CDec(row!Numero), "#.0")
            Else
                talla = CStr(row!Numero).Trim()
            End If
            Dim rows() As DataRow = minimos.Select("CodArticulo='" & codigo & "' AND Numero='" & talla & "'")
            If rows.Length > 0 Then
                'Dim sumCantidad As Integer = minimos.Compute("SUM(Existencia)", "CodArticulo='" & codigo & "' AND Numero='" & talla & "' AND Checado=1")
                Dim sumCantidad As Integer = 0
                For Each rowEx As DataRow In minimos.Rows
                    Dim codigoEx As String = CStr(rowEx!CodArticulo)
                    Dim cantEx As Integer = CInt(rowEx!Existencia)
                    Dim tallaEx As String = CStr(rowEx!Numero)
                    Dim checked As Boolean = CBool(rowEx!Checado)
                    If codigo = codigoEx AndAlso talla = tallaEx AndAlso checked = True Then
                        sumCantidad += cantEx
                    End If
                Next
                If cantidad > sumCantidad Then
                    valido = False
                    msg &= codigo & " cantidad: " & CStr(cantidad) & " Existencia Seleccionada: " & CStr(sumCantidad) & vbCrLf
                End If
            End If
        Next
        If valido = False Then
            MessageBox.Show(msg, "DportenisPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 19/04/2013: Funcion para obtener las cantidades seleccionadas de las ventas minimas
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function GetCantidadesMinimas() As DataTable
        Dim minimos As DataTable = view.Table.Copy()
        Dim dtArt As New DataTable("ArticulosMinimos")
        dtArt.Columns.Add("CodArticulo", GetType(String))
        dtArt.Columns.Add("Talla", GetType(String))
        dtArt.Columns.Add("Sucursal", GetType(String))
        dtArt.Columns.Add("Cantidad", GetType(Integer))
        dtArt.AcceptChanges()
        For Each row As DataRow In Me.dtArticulos.Rows
            Dim codigo As String = CStr(row!CodArticulo)
            Dim cantidad As Integer = CInt(row!Cantidad)

            Dim talla As String = ""
            If IsNumeric(CStr(row!Numero)) Then
                talla = Format(CDec(row!Numero), "#.0")
            Else
                talla = CStr(row!Numero).Trim()
            End If
            Dim sumCantidad As Integer = 0
            For Each rowEx As DataRow In minimos.Rows
                Dim sucursalEx As String = CStr(rowEx!Sucursal)
                Dim codigoEx As String = CStr(rowEx!CodArticulo)
                Dim cantEx As Integer = CInt(rowEx!Existencia)
                Dim tallaEx As String = CStr(rowEx!Numero)
                Dim checked As Boolean = CBool(rowEx!Checado)
                If codigo = codigoEx AndAlso talla = tallaEx AndAlso checked = True Then
                    Dim fila As DataRow = dtArt.NewRow()
                    fila("CodArticulo") = codigo
                    fila("Talla") = tallaEx
                    fila("Sucursal") = sucursalEx
                    If cantidad > cantEx Then
                        fila("Cantidad") = cantEx
                        cantidad -= cantEx
                        dtArt.Rows.Add(fila)
                        Console.WriteLine("Codigo: " + codigo)
                        Console.WriteLine("Talla: " + tallaEx)
                        Console.WriteLine("Sucursal: " + sucursalEx)
                        Console.WriteLine("Cantidad: " + cantEx.ToString())
                    Else
                        fila("Cantidad") = cantidad
                        dtArt.Rows.Add(fila)
                        Console.WriteLine("Codigo: " + codigo)
                        Console.WriteLine("Talla: " + tallaEx)
                        Console.WriteLine("Sucursal: " + sucursalEx)
                        Console.WriteLine("Cantidad: " + cantidad.ToString())
                        Exit For
                    End If
                End If
            Next
        Next
        Return dtArt
    End Function

#End Region

#Region "Events Forms"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frmConsultaSiHay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Me.ValidarMinimos = True Then
                    If ValidarCantidadesMinimas() = True Then
                        Me.Dispose()
                    End If
                Else
                    Me.Dispose()
                End If
        End Select
    End Sub

    Private Sub gridExistencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridExistencia.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Me.ValidarMinimos = True Then
                    If ValidarCantidadesMinimas() = True Then
                        Me.Dispose()
                    End If
                Else
                    Me.Dispose()
                End If
        End Select
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.AceptarMinimos = False
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarCantidadesMinimas() = True Then
            Dim source As DataTable = GetCantidadesMinimas().Copy()
            Me.Dispose()
            Me.SourceMinimo = source
            Me.AceptarMinimos = True
        End If
    End Sub

    Private Sub frmConsultaSiHay_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.ValidarMinimos = True Then

            'Me.AceptarMinimos = False
            'If ValidarCantidadesMinimas() = False Then
            '    e.Cancel = True
            'End If
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Me.btnActualizar.Enabled = False
        CargarExistenciasMinimos(Me.dtArticulos, False)
        Me.btnActualizar.Enabled = True
    End Sub

#End Region



End Class
