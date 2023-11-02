
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC

Imports Janus.Windows.GridEX





Public Class frmInvTSxDefectuososCaptura

    Inherits System.Windows.Forms.Form

    Private m_datdtMotivosDet As DataTable
    Dim strline As String = ""
    Dim dsMaterialTalla As DataSet
    Dim strCodArticulo As String = ""
    Dim strNumero As String = ""
    Dim strDescripcion As String = ""

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal AlmacenDestino As String)

        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        vAlmacenDestino = AlmacenDestino
        'dtMotivos
        m_datdtMotivosDet = Nothing
        m_datdtMotivosDet = New DataTable

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
    Friend WithEvents ebUnidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCosto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grArticuloCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents grTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebTotalArticulos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uibtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebTotalLecturado As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvTSxDefectuososCaptura))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTotalLecturado = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.grTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.uibtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.ebTotalArticulos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.grArticuloCorrida = New Janus.Windows.GridEX.GridEX()
        Me.ebUnidad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCosto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grArticuloCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebTotalLecturado)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.grTraspasoCorrida)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.uibtnEliminar)
        Me.ExplorerBar1.Controls.Add(Me.ebTotalArticulos)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.grArticuloCorrida)
        Me.ExplorerBar1.Controls.Add(Me.ebUnidad)
        Me.ExplorerBar1.Controls.Add(Me.ebCosto)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Articulos Defectuosos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(664, 608)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTotalLecturado
        '
        Me.ebTotalLecturado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalLecturado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalLecturado.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalLecturado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalLecturado.ForeColor = System.Drawing.Color.Maroon
        Me.ebTotalLecturado.Location = New System.Drawing.Point(152, 536)
        Me.ebTotalLecturado.Name = "ebTotalLecturado"
        Me.ebTotalLecturado.ReadOnly = True
        Me.ebTotalLecturado.Size = New System.Drawing.Size(88, 22)
        Me.ebTotalLecturado.TabIndex = 5
        Me.ebTotalLecturado.TabStop = False
        Me.ebTotalLecturado.Text = "0"
        Me.ebTotalLecturado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTotalLecturado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 536)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Articulos Lecturados:"
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(336, 512)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(144, 32)
        Me.UiButton1.TabIndex = 0
        Me.UiButton1.Text = "&Generar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grTraspasoCorrida
        '
        Me.grTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.grTraspasoCorrida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grTraspasoCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grTraspasoCorrida.GroupByBoxVisible = False
        Me.grTraspasoCorrida.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grTraspasoCorrida.Location = New System.Drawing.Point(8, 40)
        Me.grTraspasoCorrida.Name = "grTraspasoCorrida"
        Me.grTraspasoCorrida.Size = New System.Drawing.Size(632, 456)
        Me.grTraspasoCorrida.TabIndex = 6
        Me.grTraspasoCorrida.TabStop = False
        Me.grTraspasoCorrida.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(496, 512)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(144, 32)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "A&ceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnEliminar
        '
        Me.uibtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnEliminar.Image = CType(resources.GetObject("uibtnEliminar.Image"), System.Drawing.Image)
        Me.uibtnEliminar.Location = New System.Drawing.Point(464, 568)
        Me.uibtnEliminar.Name = "uibtnEliminar"
        Me.uibtnEliminar.Size = New System.Drawing.Size(176, 32)
        Me.uibtnEliminar.TabIndex = 8
        Me.uibtnEliminar.Text = "&Eliminar"
        Me.uibtnEliminar.Visible = False
        Me.uibtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebTotalArticulos
        '
        Me.ebTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalArticulos.ForeColor = System.Drawing.Color.Maroon
        Me.ebTotalArticulos.Location = New System.Drawing.Point(152, 504)
        Me.ebTotalArticulos.Name = "ebTotalArticulos"
        Me.ebTotalArticulos.ReadOnly = True
        Me.ebTotalArticulos.Size = New System.Drawing.Size(88, 22)
        Me.ebTotalArticulos.TabIndex = 4
        Me.ebTotalArticulos.TabStop = False
        Me.ebTotalArticulos.Text = "0"
        Me.ebTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 504)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total de Articulos:"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Image = CType(resources.GetObject("uitnAgregar.Image"), System.Drawing.Image)
        Me.uitnAgregar.Location = New System.Drawing.Point(264, 568)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(191, 32)
        Me.uitnAgregar.TabIndex = 6
        Me.uitnAgregar.Text = "&Agregar"
        Me.uitnAgregar.Visible = False
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'grArticuloCorrida
        '
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grArticuloCorrida.DesignTimeLayout = GridEXLayout2
        Me.grArticuloCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grArticuloCorrida.GroupByBoxVisible = False
        Me.grArticuloCorrida.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grArticuloCorrida.Location = New System.Drawing.Point(9, 107)
        Me.grArticuloCorrida.Name = "grArticuloCorrida"
        Me.grArticuloCorrida.Size = New System.Drawing.Size(191, 384)
        Me.grArticuloCorrida.TabIndex = 13
        Me.grArticuloCorrida.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grArticuloCorrida.Visible = False
        Me.grArticuloCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUnidad
        '
        Me.ebUnidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidad.BackColor = System.Drawing.Color.Ivory
        Me.ebUnidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUnidad.Location = New System.Drawing.Point(328, 71)
        Me.ebUnidad.Name = "ebUnidad"
        Me.ebUnidad.ReadOnly = True
        Me.ebUnidad.Size = New System.Drawing.Size(72, 22)
        Me.ebUnidad.TabIndex = 12
        Me.ebUnidad.TabStop = False
        Me.ebUnidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebUnidad.Visible = False
        Me.ebUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCosto
        '
        Me.ebCosto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCosto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCosto.BackColor = System.Drawing.Color.Ivory
        Me.ebCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCosto.Location = New System.Drawing.Point(72, 71)
        Me.ebCosto.Name = "ebCosto"
        Me.ebCosto.ReadOnly = True
        Me.ebCosto.Size = New System.Drawing.Size(120, 22)
        Me.ebCosto.TabIndex = 10
        Me.ebCosto.TabStop = False
        Me.ebCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCosto.Visible = False
        Me.ebCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(261, 42)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(379, 22)
        Me.ebDescripcion.TabIndex = 8
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.Visible = False
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(72, 41)
        Me.ebCodigo.MaxLength = 22
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.ReadOnly = True
        Me.ebCodigo.Size = New System.Drawing.Size(184, 22)
        Me.ebCodigo.TabIndex = 7
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.Visible = False
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(264, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Unidad:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Costo:"
        Me.Label5.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        Me.Label1.Visible = False
        '
        'frmInvTSxDefectuososCaptura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 565)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvTSxDefectuososCaptura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Traspasos por Defectuosos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grArticuloCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Variables Miembros"

    Private oTraspasoSalida As TraspasoSalida

    Private oTraspasoSalidaMgr As TraspasosSalidaManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private dtCorridaArticulo As DataTable

    Private dtTraspasoDetalle As DataTable

    Private strTablaTmp As String = "TraspasoDetalleTmp" & oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & oAppContext.Security.CurrentUser.ID

    'Almacen Destino del Traspaso
    Dim vAlmacenDestino As String = String.Empty

    'Captura Manual
    'ALLOW
    Dim str As String = ""
    'Dim strNumero As String = ""

    'Motivos de captura manual
    Dim boolManual As Boolean = False


#End Region



#Region "Propiedades [WriteOnly]"

    Private intTraspasoID As Integer


    Public WriteOnly Property TraspasoID() As Integer

        Set(ByVal Valor As Integer)

            intTraspasoID = Valor
        End Set

    End Property

    Public Property dtMotivosDet() As DataTable
        Get
            Return m_datdtMotivosDet
        End Get
        Set(ByVal Value As DataTable)
            m_datdtMotivosDet = Value
        End Set
    End Property

#End Region



#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oTraspasoSalidaMgr = New TraspasosSalidaManager(oAppContext)

        oTraspasoSalida = New TraspasoSalida(oTraspasoSalidaMgr)

        oTraspasoSalida.dtMotivos = Me.dtMotivosDet.Copy

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)


        Sm_ActualizarGRID()

        If (dtTraspasoDetalle.Rows.Count > 0) Then

            ebTotalArticulos.Text = Format(dtTraspasoDetalle.Compute("SUM(SCantidad)", ""), "#,##0")

        End If

    End Sub



    Private Sub Sm_Finalizar()

        oTraspasoSalida = Nothing

        oTraspasoSalidaMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

    End Sub



    Private Sub Sm_ActualizarGRID()

        grTraspasoCorrida.DataSource = Nothing

        dtTraspasoDetalle = Nothing

        dtTraspasoDetalle = oTraspasoSalidaMgr.ActualizarDataSet("[TraspasoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp)

        grTraspasoCorrida.DataSource = dtTraspasoDetalle

    End Sub



    Private Sub Sm_TxtLimpiar()

        ebCodigo.Text = String.Empty

        ebDescripcion.Text = String.Empty

        ebCosto.Text = String.Empty

        ebUnidad.Text = String.Empty

        ebCodigo.Focus()

    End Sub



    Private Sub Sm_BuscarArticulo(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog2


            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.Cancel) Then
                Exit Sub
            End If


            Try

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If


                oArticulo = Nothing
                'oArticulo = oCatalogoArticulosMgr.Load(oOpenRecordDlg.Record.Item("Código"))
                oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                Sm_GenerarArticuloCorrida()

            Catch ex As Exception

                Return

            End Try

        Else

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                'MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()

                Exit Sub

            End If

        End If

        With oArticulo

            ebCodigo.Text = .CodArticulo
            ebDescripcion.Text = .CodArticulo & " - " & .Descripcion
            ebCosto.Text = Format(.CostoProm, "Standard")
            ebUnidad.Text = .CodUnidadVta

        End With

        Sm_GenerarArticuloCorrida()

    End Sub



    Private Sub Sm_CapturarArticuloScanner(ByVal strCodArticulo As String)

        Dim strTalla As String


        If (Microsoft.VisualBasic.Len(strCodArticulo) < 2) Then

            MsgBox("La longitud del Código Artículo debe ser mayor a 1 Carater.", MsgBoxStyle.Exclamation, "DPTienda")
            Me.ebCodigo.Text = ""
            Exit Sub

        End If


        strTalla = Microsoft.VisualBasic.Left(strCodArticulo.Trim, 2)

        If (IsNumeric(strTalla) = True) Then

            ebCodigo.Text = Microsoft.VisualBasic.Right(strCodArticulo, Microsoft.VisualBasic.Len(strCodArticulo) - 2)

            Sm_BuscarArticulo()

            '<Validación>

            If (oArticulo Is Nothing) Then

                Exit Sub

            End If

            '</Validación>

            'Sm_GenerarArticuloCorrida()

        Else

            Sm_BuscarArticulo()

            If (oArticulo Is Nothing) Then

                Exit Sub

            End If

            'Sm_GenerarArticuloCorrida()

        End If

    End Sub



    Private Sub Sm_GenerarArticuloCorrida()

        grArticuloCorrida.DataSource = Nothing

        dtCorridaArticulo = Nothing


        dtCorridaArticulo = oTraspasoSalidaMgr.GenerarArticuloCorrida(ebCodigo.Text, vAlmacenDestino).Tables("Existencias")

        dtCorridaArticulo.Columns.Add("Cantidad", GetType(Integer))

        'Captura manual
        'Allow
        If Not boolManual And Not dtCorridaArticulo Is Nothing Then
            Dim odataview As New DataView(dtCorridaArticulo, "Talla = '" & strNumero & "'", "Talla", DataViewRowState.CurrentRows)
            If odataview.Count > 0 Then

                odataview(0)("Cantidad") = 1
                dtCorridaArticulo.AcceptChanges()

                Me.uitnAgregar.PerformClick()

                Me.ebCodigo.Text = "" : Me.ebDescripcion.Text = ""
                Me.ebCosto.Text = "" : Me.ebUnidad.Text = ""
                dtCorridaArticulo = Nothing

            Else
                Me.ebCodigo.Text = "" : Me.ebDescripcion.Text = ""
                Me.ebCosto.Text = "" : Me.ebUnidad.Text = ""
                dtCorridaArticulo = Nothing
                MsgBox("No hay existencia en Talla " & strNumero, MsgBoxStyle.Information, Me.Text)
                Me.ebCodigo.Focus()
            End If
            'boolManual = False
            'Me.ebCodigo.ReadOnly = True
        End If

        grArticuloCorrida.DataSource = dtCorridaArticulo

    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        If (oArticulo Is Nothing) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Function

        End If


        If (dtCorridaArticulo.Rows.Count = 0) Then

            MsgBox("El Artículo no cuenta con Existencias.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Function

        End If


        Dim dr As DataRow
        Dim intCurrentRow As Integer
        Dim intCantidad As Integer


        For Each dr In dtCorridaArticulo.Rows

            If Not (IsDBNull(dr!Cantidad) = True) Then

                intCantidad = 0

                Dim drDataRow() As DataRow

                drDataRow = dtTraspasoDetalle.Select("CodArticulo ='" & oArticulo.CodArticulo & "' and Talla ='" & dr!Talla & "'")


                If (drDataRow.Length = 0) Then

                    intCantidad += dr!Cantidad
                    drDataRow = Nothing

                Else

                    intCantidad = CType(drDataRow(0)!SCantidad, Integer) + dr!Cantidad
                    drDataRow = Nothing

                End If

                '<Validacion>

                If (dr!Existencia < intCantidad) Then

                    MsgBox("Verifique la Cantidad en la Talla " & dr!Talla, MsgBoxStyle.Exclamation, "DPTienda")
                    'grArticuloCorrida.Focus()

                    'ALLOW --Comente el foco del control grArticuloCorrida
                    Me.ebCodigo.Focus()

                    Exit Function

                End If

                '</Validacion>

            End If

        Next


        Return True

    End Function

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub frmInvTraspasosDSalidaCaptura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

        Me.grTraspasoCorrida.AllowEdit = InheritableBoolean.True
        Me.grTraspasoCorrida.RootTable.Columns.Item(0).EditType = EditType.NoEdit
        Me.grTraspasoCorrida.RootTable.Columns.Item(1).EditType = EditType.NoEdit
        Me.grTraspasoCorrida.RootTable.Columns.Item(2).EditType = EditType.NoEdit
        Me.grTraspasoCorrida.RootTable.Columns.Item(3).EditType = EditType.NoEdit
        Me.grTraspasoCorrida.RootTable.Columns.Item(4).EditType = EditType.TextBox
        'Me.UiButton1.Enabled = True
    End Sub



    Private Sub frmInvTraspasosDSalidaCaptura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub



    Private Sub frmInvTraspasosDSalidaCaptura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim intLargo As Integer = 0
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If


        If (e.KeyCode = Keys.Escape) Then

            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        End If

        'Captura Manual
        'ALLOW
        If Me.ActiveControl Is Me.ebCodigo And Not e.KeyCode = Keys.Enter And Me.ebCodigo.ReadOnly = True Then
            If e.KeyCode = 189 Then
                str = str & "-"
            Else
                str = str & Chr(e.KeyCode)
            End If


            'ALLOW
        ElseIf Me.ActiveControl Is Me.ebCodigo And Me.ebCodigo.ReadOnly = True And Me.ebCodigo.Text = "" Then
            str = str.Trim
            str = str.Replace("", "")
            intLargo = str.Length - 1
            str = str.PadLeft(18, "0")

            If str <> "" And str.Length > 1 Then
                str = str.PadLeft(18, "0")
                str = Mid(str, str.Length - 17)
                If IsNumeric(str) Then
                    str = Mid(str, str.Length - 17)
                Else
                    If str.Length > intLargo Then
                        str = Mid(str, str.Length - intLargo)
                    Else
                        str = Mid(str, str.Length - 11)
                    End If
                End If
                Me.ebCodigo.Text = str
                str = ""
                SendKeys.Send("{TAB}")
            Else
                str = ""
            End If

        End If

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick
        If boolManual Then
            Sm_BuscarArticulo(True)
        End If


    End Sub



    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarArticulo(True)

        End If

        'Captura Manual
        'ALLOW
        If e.KeyCode = Keys.F2 Then
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                boolManual = True
                Me.ebCodigo.ReadOnly = False
            Else
                boolManual = False
                Me.ebCodigo.ReadOnly = True
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If


    End Sub



    Private Sub ebCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigo.Validating
        'Captura manual
        'ALLOW
        If (ebCodigo.Text.Trim <> String.Empty) And boolManual = False Then

            ebCodigo.Text = LoadCodigo(ebCodigo.Text)

            If ebCodigo.Text = String.Empty Then

                ebCodigo.Focus()
                Exit Sub

            End If

        End If
        ''''


        If (ebCodigo.Text.Trim <> String.Empty) Then

            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)


            If boolManual Then
                'boolManual = False
                Me.ebCodigo.ReadOnly = True
            End If

            If (oArticulo Is Nothing) Then

                MsgBox("El Artículo no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
                Me.ebCodigo.Text = ""
                e.Cancel = True

            End If

        Else

            If grTraspasoCorrida.RowCount > 0 Then

                'grTraspasoCorrida.Focus()
                Me.ebCodigo.Focus()

            Else

                MsgBox("El Artículo no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
                e.Cancel = True

            End If

        End If

    End Sub
    Private Function LoadCodigo(ByVal strCodigo As String) As String
        'Captura Manual ---toda la funcion
        'ALLOW
        Dim strResult As String = String.Empty

        If IsNumeric(strCodigo) Then
            'Buscamos Codigo UPC
            Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            Dim oUPC As UPC
            oUPC = oUPCMgr.Create

            oUPC = oUPCMgr.Load(strCodigo)

            If oUPC.CodArticulo <> String.Empty Then

                strResult = oUPC.CodArticulo
                strNumero = oUPC.Numero

                'btnAccionBusqueda.PerformClick()

            Else
                MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Consulta Existencias")
                strResult = String.Empty
                Sm_TxtLimpiar()

            End If

            oUPCMgr.dispose()
            oUPCMgr = Nothing
            oUPC = Nothing

        Else

            'Verificamos si tiene talla
            If IsNumeric(Microsoft.VisualBasic.Left(Trim(strCodigo), 2)) Then

                strResult = Microsoft.VisualBasic.Right((strCodigo.Trim), Len(Trim(strCodigo)) - 2)
                strNumero = Microsoft.VisualBasic.Left(Trim(strCodigo), 2)

                'Se agrego para que buscara en los codigos anteriores
                Dim oArticulo As Articulo
                Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                oArticulo = oArticuloMgr.Create
                oArticulo.ClearFields()

                oArticuloMgr.LoadInto(strResult, oArticulo, True)
                If oArticulo.CodArticulo <> String.Empty Then
                    strCodigo = oArticulo.CodArticulo

                    'btnAccionBusqueda.PerformClick()
                Else
                    oArticulo.ClearFields()
                    oArticuloMgr.LoadInto(strCodigo, oArticulo)
                    If oArticulo.CodArticulo <> String.Empty Then
                        strCodigo = oArticulo.CodArticulo
                    End If
                End If
                strResult = strCodigo


                'Se cambia la talla del material si es accesorio o textil
                If oArticulo.CodCorrida = "ACC" OrElse oArticulo.CodCorrida = "TEX" OrElse oArticulo.CodCorrida = "AC1" Then

                    Select Case strNumero
                        Case "10"
                            strNumero = "XXL"
                        Case "8"
                            strNumero = "XL"
                        Case "6"
                            strNumero = "L"
                        Case "4"
                            strNumero = "M"
                        Case "2"
                            strNumero = "S"
                        Case "1"
                            strNumero = "XS"
                        Case "0", "00"
                            strNumero = "U"
                        Case Else
                            strNumero = strNumero
                    End Select

                End If
            Else

                Dim oArticulo As Articulo
                Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                oArticulo = oArticuloMgr.Create
                oArticulo.ClearFields()

                oArticuloMgr.LoadInto(strCodigo, oArticulo, True)
                If oArticulo.CodArticulo <> String.Empty Then
                    strCodigo = oArticulo.CodArticulo

                    'btnAccionBusqueda.PerformClick()
                Else
                    oArticulo.ClearFields()
                    oArticuloMgr.LoadInto(strCodigo, oArticulo)
                    If oArticulo.CodArticulo <> String.Empty Then
                        strCodigo = oArticulo.CodArticulo
                    End If
                End If
                strResult = strCodigo

            End If

        End If

        Return strResult

    End Function


    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnAgregar.Click

        '<Validación>

        If (Fm_bolTxtValidar() = False) Then

            Exit Sub

        End If

        '</Validación>


        Dim dr As DataRow

        '.:: Se recorre la Corrida del Articulo ::.

        For Each dr In dtCorridaArticulo.Rows

            If Not (IsDBNull(dr!Cantidad) = True) Then

                If (dr!Cantidad > 0) Then

                    oTraspasoSalidaMgr.AgregarArticulo(oArticulo, dr!Talla, dr!Cantidad, (oArticulo.CostoProm * dr!Cantidad), intTraspasoID)

                    If boolManual Then

                        'Mando llamar la pantalla de motivos de captura manual
                        Dim oForm As New frmMotivosFactura

                        oForm.Motivos = oTraspasoSalida.dtMotivos
                        oForm.ExplorerBar1.Groups(0).Text = oForm.ExplorerBar1.Groups(0).Text & "       Articulo: " & ebCodigo.Text & "       Talla: " & dr!Talla
                        oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                        oForm.Articulo = ebCodigo.Text
                        oForm.Talla = dr!Talla

                        oForm.ShowDialog()

                    End If
                End If

            End If

        Next


        Sm_ActualizarGRID()


        If (dtTraspasoDetalle.Rows.Count > 0) Then

            ebTotalArticulos.Text = Format(dtTraspasoDetalle.Compute("SUM(SCantidad)", ""), "Standard")

        End If
        'Captura manual
        'ALLOW

        Me.ebCodigo.Text = "" : Me.ebDescripcion.Text = ""
        Me.ebCosto.Text = "" : Me.ebUnidad.Text = ""
        dtCorridaArticulo = Nothing
        grArticuloCorrida.DataSource = dtCorridaArticulo
        boolManual = False
        Me.ebCodigo.ReadOnly = True
        '''
        ebCodigo.Focus()

    End Sub



    Private Sub uibtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnEliminar.Click

        DeleteRowTC()

    End Sub

#End Region



    Private Sub grArticuloCorrida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grArticuloCorrida.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                grTraspasoCorrida.Focus()

            Case Keys.Escape

                Me.DialogResult = DialogResult.OK
                Me.Close()

        End Select

    End Sub


    Private Sub grTraspasoCorrida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grTraspasoCorrida.KeyDown


        If e.KeyCode = Keys.Enter And strline <> String.Empty And strline <> "000000000000000000" And Not Me.grTraspasoCorrida.Col = 4 Then

            'Buscar Codigo de articulo en catalogo UPC
            strline = strline.PadLeft(18, "0")

            strline = Mid(strline, strline.Length - 17)
            Dim catUPC As New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            If catUPC.IsSkuOrMaterial(strline) = "S" Then
                'If IsNumeric(strline) Then
                dsMaterialTalla = New DataSet
                dsMaterialTalla = Me.oTraspasoSalidaMgr.SelectMaterialTalla(strline)
                If dsMaterialTalla.Tables(0).Rows.Count > 0 Then
                    strCodArticulo = dsMaterialTalla.Tables(0).Rows(0).Item("CodArticulo")
                    strNumero = dsMaterialTalla.Tables(0).Rows(0).Item("Numero")
                    strDescripcion = dsMaterialTalla.Tables(0).Rows(0).Item("Descripcion")
                Else
                    MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                    Exit Sub
                End If
            Else
                '////////////////// CODIGOS VIEJOS \\\\\\\\\\\\\\\\\\\

                Dim vCodArticulo As String
                Dim vNumStringArticulo As String
                Dim vNumeroArticulo As String

                vCodArticulo = UCase(strline)
                vNumStringArticulo = Mid(vCodArticulo, 1, 2)
                If catUPC.IsSkuOrMaterial(vNumStringArticulo) = "S" Then
                    'If IsNumeric(vNumStringArticulo) Then
                    vCodArticulo = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                    If vNumStringArticulo <> "00" Then
                        vNumeroArticulo = CDec(vNumStringArticulo) / 2
                    Else
                        vNumeroArticulo = "00"
                    End If

                    Dim oArticulo As Articulo
                    Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                    oArticulo = oArticuloMgr.Create
                    oArticulo.ClearFields()

                    oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                    If oArticulo.CodArticulo <> String.Empty Then
                        vCodArticulo = oArticulo.CodArticulo
                    Else
                        oArticulo.ClearFields()
                        oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                        If oArticulo.CodArticulo <> String.Empty Then
                            vCodArticulo = oArticulo.CodArticulo
                        Else
                            MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    End If

                    'vCodArticulo " Codigo de articulo.
                    'vNumeroArticulo " Numero de Material.
                    strCodArticulo = vCodArticulo
                    strNumero = vNumeroArticulo
                    strDescripcion = oArticulo.Descripcion
                Else
                    MsgBox("El Código UPC no Existe.", MsgBoxStyle.Information, Me.Text)
                    Exit Sub

                End If 'fin del IsNumeric(vNumStringArticulo)

                '/////////////////// CODIGOS VIEJOS \\\\\\\\\\\\\\\\\\\\ 

            End If ' Fin del IsNumeric(strLine)

                strline = ""
                'Agregamos la cantidad al grid dependiendo del material
                Dim oDataView As New DataView(dtTraspasoDetalle, "CodArticulo ='" & strCodArticulo & "' and " & _
                        "Talla='" & strNumero & "' ", "CodArticulo", DataViewRowState.CurrentRows)

                If oDataView.Count > 0 Then
                    For Each oDataRowViewF As DataRowView In oDataView
                        If oDataRowViewF.Row.Item("Lecturado") < oDataRowViewF.Row.Item("sCantidad") Then
                            oDataRowViewF.Row.Item("lecturado") += 1
                        Else
                            MsgBox("La lectura del material " & strCodArticulo & " , Talla: " & strNumero & Microsoft.VisualBasic.vbCrLf & " se completo.", MsgBoxStyle.Information, Me.Text)
                            'Me.grTraspasoCorrida.Select()
                        End If
                    Next
                    dtTraspasoDetalle.AcceptChanges()

                    Me.ebTotalLecturado.Text = CStr(dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0"))

                    '
                    'Me.grTraspasoCorrida.RootTable.SortKeys = Me.grTraspasoCorrida.RootTable.SortKeys
                    'Me.grTraspasoCorrida.RootTable.SortKeys(0).SortOrder = SortOrder.Descending


                    Me.grTraspasoCorrida.Select()
                Else
                    ''A peticion de Manuel Camacho si no existe el codigo upc en el Grid, que lo agregue
                    'Dim oRow As DataRow = dtTraspasoDetalle.NewRow
                    'With oRow
                    '    .Item("Codigo") = strCodArticulo
                    '    .Item("Descripcion") = strDescripcion
                    '    .Item("Talla") = strNumero
                    '    .Item("Cantidad") = 0
                    '    .Item("Lecturado") = 1
                    '    .Item("Agregado") = 1
                    '    .Item("Origen") = Me.ebSucOrigenCod.Text
                    '    .Item("Destino") = Me.ebSucDestinoCod.Text
                    '    .Item("Fecha") = Date.Today.ToShortDateString
                    'End With
                    'dtTraspasoDetalle.Rows.Add(oRow)
                    'dtTraspasoDetalle.AcceptChanges()

                    'Me.ebTotalLecturado.Text = CStr(dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0"))

                    ''MsgBox("El código UPC no se encontró en el detalle del traslado.", MsgBoxStyle.Information, Me.Text)
                    'Me.grTraspasoCorrida.Refresh()
                    'Me.grTraspasoCorrida.Select()

                End If



        Else
                If e.KeyCode <> Keys.Enter Then
                    strline += Chr(e.KeyCode)
                End If


        End If


            Select Case e.KeyCode

                Case Keys.Enter

                    'uitnAgregar.Focus()

                Case Keys.Delete

                    'DeleteRowTC()

                Case Keys.Escape

                    Me.DialogResult = DialogResult.OK
                    Me.Close()

            End Select

    End Sub

    Private Sub DeleteRowTC()

        Dim dt As DataTable
        Dim oCurrentRow As GridEXRow
        Dim odrDataRow As DataRowView


        '<Validación>

        dt = CType(grTraspasoCorrida.DataSource, DataTable)

        If (dt.Rows.Count = 0) Then

            MsgBox("No se cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        '</Validación>


        oCurrentRow = grTraspasoCorrida.GetRow()

        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        With odrDataRow
            oTraspasoSalidaMgr.EliminarArticulo(.Item("CodArticulo"), .Item("Talla"))

            'ALLOW
            'Elimino del dtMotivos el registro
            If .Item("CodArticulo") <> "" Then
                Dim oDataView As New DataView(oTraspasoSalida.dtMotivos, "Articulo = '" & .Item("CodArticulo") & "' and Talla = '" & .Item("Talla") & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                If oDataView.Count > 0 Then
                    oDataView.Delete(0)
                    oTraspasoSalida.dtMotivos.AcceptChanges()
                End If
            End If
        End With

        oCurrentRow = Nothing
        odrDataRow = Nothing


        Sm_ActualizarGRID()


        If (dtTraspasoDetalle.Rows.Count > 0) Then

            ebTotalArticulos.Text = Format(dtTraspasoDetalle.Compute("SUM(SCantidad)", ""), "Standard")

        Else

            ebTotalArticulos.Text = 0.0

        End If

    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        m_datdtMotivosDet = oTraspasoSalida.dtMotivos.Copy
        Me.DialogResult = DialogResult.OK

        'Me.Close()

    End Sub

    Private Sub ebCodigo_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles ebCodigo.Layout

    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Dim dr As DataRow
        Dim dsDefec As New DataSet

        'Llenamos el dataset con los articulos defectuosos
        dsDefec = oTraspasoSalidaMgr.GetDefectuosos(oAppContext.ApplicationConfiguration.Almacen)

        'Validamos que el dataset contenga datos
        If dsDefec Is Nothing Then
            MsgBox("No hay articulos defectuosos en existencia", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
        If dsDefec.Tables(0).Rows.Count = 0 Then
            MsgBox("No hay articulos defectuosos en existencia", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        'Barremos el dataset para asignarlo a la tabla temporal
        For Each dr In dsDefec.Tables(0).Rows

            If Not (IsDBNull(dr!TotalMes) = True) Then

                If (dr!TotalMes > 0) Then

                    oArticulo = Nothing
                    oArticulo = oCatalogoArticulosMgr.Load(dr!CodArticulo)

                    oTraspasoSalidaMgr.AgregarArticulo(oArticulo, dr!Numero, dr!TotalMes, (oArticulo.CostoProm * dr!TotalMes), intTraspasoID)

                End If

            End If

        Next


        Sm_ActualizarGRID()


        If (dtTraspasoDetalle.Rows.Count > 0) Then

            ebTotalArticulos.Text = Format(dtTraspasoDetalle.Compute("SUM(SCantidad)", ""), "#,#00")

        End If

        Me.grTraspasoCorrida.Select()

        Me.UiButton1.Enabled = False
    End Sub

    Private Sub grTraspasoCorrida_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grTraspasoCorrida.CurrentCellChanged
        Dim bandera As Boolean

        If Me.strCodArticulo <> "" Then
            Dim oCurrentRow As GridEXRow
            Dim odrDataRow As DataRowView
            Dim lecturado, Cantidad As Integer

            oCurrentRow = grTraspasoCorrida.GetRow()
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            Cantidad = CType(odrDataRow.Item("sCantidad"), Integer)
            lecturado = CType(odrDataRow.Item("Lecturado"), Integer)

            If lecturado > Cantidad Then
                odrDataRow.Item("Lecturado") = Cantidad
                lecturado = Cantidad
                bandera = False
            Else
                bandera = True
            End If

            'Cambiamos el campo lecturado de la tabla temporal
            If Not bandera Then
                oTraspasoSalidaMgr.ActualizarLecturado(strCodArticulo, strNumero, lecturado)
            Else
                oTraspasoSalidaMgr.ActualizarLecturado(strCodArticulo, strNumero, lecturado + 1)
            End If


            Me.ebTotalLecturado.Text = IIf(IsDBNull(dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0")), 0, dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0"))


        Else
            Dim oCurrentRow As GridEXRow
            Dim odrDataRow As DataRowView
            Dim Cantidad As Integer
            Dim lecturado As Integer
            Dim Articulo, Talla As String

            oCurrentRow = grTraspasoCorrida.GetRow()
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            Cantidad = CType(odrDataRow.Item("sCantidad"), Integer)
            lecturado = CType(odrDataRow.Item("Lecturado"), Integer)
            Articulo = CType(odrDataRow.Item("CodArticulo"), String)
            Talla = CType(odrDataRow.Item("Talla"), String)


            If lecturado > Cantidad Then
                odrDataRow.Item("Lecturado") = Cantidad
                lecturado = Cantidad
            End If


            'Cambiamos el campo lecturado de la tabla temporal
            oTraspasoSalidaMgr.ActualizarLecturado(Articulo, Talla, lecturado)


            Me.ebTotalLecturado.Text = IIf(IsDBNull(dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0")), 0, dtTraspasoDetalle.Compute("SUM(Lecturado)", "Lecturado > 0"))

        End If
        strCodArticulo = ""
        strNumero = ""

    End Sub
End Class
