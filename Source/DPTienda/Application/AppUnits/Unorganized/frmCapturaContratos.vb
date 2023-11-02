
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoDescuento
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Imports Janus.Windows.GridEX



Public Class frmCapturaContratos
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
    Friend WithEvents ebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents uibtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnQuitar As Janus.Windows.EditControls.UIButton
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCosto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents LblTallas As System.Windows.Forms.Label
    Friend WithEvents prgProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ebNTalla As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaContratos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.prgProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblTallas = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.ebDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.uibtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.uibtnQuitar = New Janus.Windows.EditControls.UIButton()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.ebCosto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebNTalla)
        Me.ExplorerBar1.Controls.Add(Me.prgProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.lblDescuento)
        Me.ExplorerBar1.Controls.Add(Me.ebDescuento)
        Me.ExplorerBar1.Controls.Add(Me.ebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.uibtnSalir)
        Me.ExplorerBar1.Controls.Add(Me.uibtnQuitar)
        Me.ExplorerBar1.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.ebCosto)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.LblTallas)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Captura de Contratos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(328, 368)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNTalla
        '
        Me.ebNTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNTalla.Location = New System.Drawing.Point(96, 113)
        Me.ebNTalla.MaxLength = 4
        Me.ebNTalla.Name = "ebNTalla"
        Me.ebNTalla.Size = New System.Drawing.Size(88, 23)
        Me.ebNTalla.TabIndex = 2
        Me.ebNTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNTalla.Visible = False
        Me.ebNTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(12, 296)
        Me.prgProgressBar1.Name = "prgProgressBar1"
        Me.prgProgressBar1.Size = New System.Drawing.Size(304, 3)
        Me.prgProgressBar1.TabIndex = 26
        '
        'LblTallas
        '
        Me.LblTallas.BackColor = System.Drawing.Color.Transparent
        Me.LblTallas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTallas.Location = New System.Drawing.Point(7, 145)
        Me.LblTallas.Name = "LblTallas"
        Me.LblTallas.Size = New System.Drawing.Size(209, 16)
        Me.LblTallas.TabIndex = 20
        Me.LblTallas.Text = "Tallas:"
        Me.LblTallas.Visible = False
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(9, 194)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(209, 16)
        Me.lblDescuento.TabIndex = 18
        Me.lblDescuento.Text = "Descto.        0.0% "
        '
        'ebDescuento
        '
        Me.ebDescuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescuento.BackColor = System.Drawing.SystemColors.Info
        Me.ebDescuento.FormatString = "#,###0.00"
        Me.ebDescuento.Location = New System.Drawing.Point(96, 164)
        Me.ebDescuento.MaxLength = 5
        Me.ebDescuento.Name = "ebDescuento"
        Me.ebDescuento.ReadOnly = True
        Me.ebDescuento.Size = New System.Drawing.Size(56, 23)
        Me.ebDescuento.TabIndex = 5
        Me.ebDescuento.TabStop = False
        Me.ebDescuento.Text = "0.00"
        Me.ebDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCantidad
        '
        Me.ebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidad.Location = New System.Drawing.Point(96, 114)
        Me.ebCantidad.MaxLength = 7
        Me.ebCantidad.Name = "ebCantidad"
        Me.ebCantidad.Size = New System.Drawing.Size(56, 23)
        Me.ebCantidad.TabIndex = 3
        Me.ebCantidad.Text = "0"
        Me.ebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnSalir
        '
        Me.uibtnSalir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.uibtnSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnSalir.Location = New System.Drawing.Point(216, 312)
        Me.uibtnSalir.Name = "uibtnSalir"
        Me.uibtnSalir.Size = New System.Drawing.Size(88, 32)
        Me.uibtnSalir.TabIndex = 8
        Me.uibtnSalir.Text = "Salir"
        Me.uibtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnQuitar
        '
        Me.uibtnQuitar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnQuitar.Location = New System.Drawing.Point(112, 312)
        Me.uibtnQuitar.Name = "uibtnQuitar"
        Me.uibtnQuitar.Size = New System.Drawing.Size(88, 32)
        Me.uibtnQuitar.TabIndex = 7
        Me.uibtnQuitar.Text = "Quitar"
        Me.uibtnQuitar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Location = New System.Drawing.Point(24, 312)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(80, 32)
        Me.uitnAgregar.TabIndex = 6
        Me.uitnAgregar.Text = "Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCosto
        '
        Me.ebCosto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCosto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCosto.BackColor = System.Drawing.SystemColors.Info
        Me.ebCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCosto.Location = New System.Drawing.Point(96, 141)
        Me.ebCosto.Name = "ebCosto"
        Me.ebCosto.ReadOnly = True
        Me.ebCosto.Size = New System.Drawing.Size(88, 22)
        Me.ebCosto.TabIndex = 4
        Me.ebCosto.TabStop = False
        Me.ebCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(96, 86)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(216, 22)
        Me.ebDescripcion.TabIndex = 1
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(96, 56)
        Me.ebCodigo.MaxLength = 20
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.ReadOnly = True
        Me.ebCodigo.Size = New System.Drawing.Size(216, 22)
        Me.ebCodigo.TabIndex = 0
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Desc Aplicar:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Precio:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Talla:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'GridTraspasoCorrida
        '
        Me.GridTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.GridTraspasoCorrida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridTraspasoCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridTraspasoCorrida.GroupByBoxVisible = False
        Me.GridTraspasoCorrida.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridTraspasoCorrida.Location = New System.Drawing.Point(8, 40)
        Me.GridTraspasoCorrida.Name = "GridTraspasoCorrida"
        Me.GridTraspasoCorrida.Size = New System.Drawing.Size(424, 296)
        Me.GridTraspasoCorrida.TabIndex = 1
        Me.GridTraspasoCorrida.TabStop = False
        Me.GridTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.GridTraspasoCorrida)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Detalle del Contrato"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(328, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(440, 368)
        Me.ExplorerBar2.TabIndex = 3
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'frmCapturaContratos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(768, 357)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Contratos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Variables Miembros"

    Private oContrato As Contrato

    Private oContratoMgr As ContratoManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    'Private oCatalogoTipoDescuentosMgr As CatalogoTipoDescuentosManager

    'Private oTipoDescuento As TipoDescuento

    Private odsCatalogoCorridas As DataSet

    Private strTablaTmp As String = "ContratoDetalleTmp" & oAppContext.ApplicationConfiguration.NoCaja

    Private decDescuento As Decimal

    'Captura Manual
    'ALLOW
    Dim str As String = ""
    Dim strNumero As String = ""

    'Motivos de captura manual
    Dim boolManual As Boolean = False

    Private oFacturaMgr As FacturaManager

    Private oCondicionVenta As CondicionesVtaSAP

#End Region



#Region "Propiedades [WriteOnly]"

    Private intContratoID As Integer


    Public WriteOnly Property ContratoID() As Integer

        Set(ByVal Valor As Integer)

            intContratoID = Valor
        End Set

    End Property

#End Region



#Region "Métodos Privados"

    Private Sub Sm_Inicializar()


        oContratoMgr = New ContratoManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        odsCatalogoCorridas = oContratoMgr.ExtraerCatalogoCorridas

        oArticulo = oCatalogoArticulosMgr.Create

        oArticulo.ClearFields()

        Sm_ActualizarGRID()

        lblDescuento.Text = "Descto.         0.00%"

        oFacturaMgr = New FacturaManager(oAppContext)

    End Sub



    Private Sub Sm_Finalizar()

        oContrato = Nothing

        oContratoMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

    End Sub


    Private Sub Sm_ActualizarGRID()

        GridTraspasoCorrida.DataSource = Nothing
        GridTraspasoCorrida.DataSource = oContratoMgr.ActualizarDataSet("[ContratoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp)

    End Sub



    Private Sub Sm_TxtLimpiar()

        ebCodigo.Text = String.Empty

        ebDescripcion.Text = String.Empty

        ebNTalla.Text = "0"

        ebCantidad.Text = 0

        ebCosto.Text = String.Empty

        ebDescuento.Text = 0.0

        lblDescuento.Text = "Descto.         0.00%"

        ebCodigo.Focus()

    End Sub



    Private Sub Sm_BuscarArticulo(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)
        oArticulo.ClearFields()

        Dim odrFiltro() As DataRow

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog2

            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo <> String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If

                Me.ebCodigo.Text = cArticulo.Trim
                GoTo BuscarArticulo

                'oArticulo = Nothing
                ''oArticulo = oCatalogoArticulosMgr.Load(oOpenRecordDlg.Record.Item("Código"))
                'oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                'ebCodigo.Text = oArticulo.CodArticulo
                'ebDescripcion.Text = oArticulo.Descripcion
                'ebCosto.Text = Format(oArticulo.PrecioOferta, "Currency")
                'lblDescuento.Text = "Descuento " & Format(oArticulo.Descuento, "Standard") & "% sin incluir."

                ''Articulo Tallas :
                'If oArticulo.CodCorrida = "ACC" Or oArticulo.CodCorrida = "TEX" Then
                '    LblTallas.Text = "Tallas:          Del XS  Al  U"
                'Else
                '    odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")
                '    LblTallas.Text = "Tallas:          Del " & odrFiltro(0).Item("NumInicio") & "  Al  " & odrFiltro(0).Item("NumFin")
                'End If

                ''Traemos descuento por sistema automáticamnte
                'oCondicionVenta = CargaCondicionVenta(oArticulo)
                'If oCondicionVenta.DescPorcentaje > 0 Then
                '    Me.ebDescuento.Value = oCondicionVenta.DescPorcentaje
                'Else
                '    Me.ebDescuento.Value = 0
                '    Me.ebDescuento.Text = 0.0
                'End If

                'ebNTalla.Text = "0"
                'ebCantidad.Text = 0
                ''ebDescuento.Text = 0.0

                'ebDescuento.Focus()
                'ebNTalla.Focus()

            End If

            Else
BuscarArticulo:
                On Error Resume Next

                'Buscamos Codigo UPC
                Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
                Dim oUPC As UPC
                oUPC = oUPCMgr.Create

                oUPC = oUPCMgr.Load(ebCodigo.Text.Trim)

                If oUPC.CodArticulo <> String.Empty Then
                    ebCodigo.Text = oUPC.CodArticulo
                    ebNTalla.Text = oUPC.Numero
                    ebCantidad.Text = "1"
                    ebDescuento.Focus()
                Else
                    'If ebNTalla.Text <> "0" Then
                    'ebNTalla.Text = "0"
                    'ebCantidad.Text = 0
                    'ebDescuento.Text = 0.0
                    'ebNTalla.Focus()
                    'End If
                End If

                oCatalogoArticulosMgr.LoadInto(ebCodigo.Text.Trim, oArticulo, True)

                If oArticulo.CodArticulo = String.Empty Then
                    oCatalogoArticulosMgr.LoadInto(ebCodigo.Text.Trim, oArticulo)
                    'oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)
                    If oArticulo.CodArticulo = String.Empty Then
                        MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                        Sm_TxtLimpiar()
                        Exit Sub
                    End If
                End If
                'ebNTalla.Text = oArticulo.t
                ebCodigo.Text = oArticulo.CodArticulo
                ebDescripcion.Text = oArticulo.Descripcion

                'Articulo Tallas :
                If oArticulo.CodCorrida = "ACC" Or oArticulo.CodCorrida = "TEX" Then
                    LblTallas.Text = "Tallas:          Del XS  Al  U"
                Else
                    odrFiltro = odsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")
                    LblTallas.Text = "Tallas:          Del " & odrFiltro(0).Item("NumInicio") & "  Al  " & odrFiltro(0).Item("NumFin")
                End If

                'ebCosto.Text = Format(oArticulo.PrecioOferta, "Standard")
                ebCosto.Text = Format(oArticulo.PrecioVenta, "Currency")
                lblDescuento.Text = "Descuento " & Format(oArticulo.Descuento, "Standard") & "% sin incluir."

                'Traemos descuento por sistema automáticamnte
                oCondicionVenta = CargaCondicionVenta(oArticulo)
                If oCondicionVenta.DescPorcentaje > 0 Then
                    Me.ebDescuento.Value = oCondicionVenta.DescPorcentaje
                Else
                    Me.ebDescuento.Value = 0
                    Me.ebDescuento.Text = 0.0
                End If

                ebNTalla.Text = "0"
                ebCantidad.Text = 0
                'ebDescuento.Text = 0.0

                ebDescuento.Focus()
                ebNTalla.Focus()

            End If

            odrFiltro = Nothing

    End Sub

    Private Function CargaCondicionVenta(ByVal objArticulo As Articulo) As CondicionesVtaSAP

        Dim oResult As New CondicionesVtaSAP

        With oResult

            If Not oAppContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                .OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
            Else
                GoTo Cambio_053
                '.OficinaVtas = "C053"
            End If
            .Jerarquia = objArticulo.Jerarquia
            .CondMat = objArticulo.CodMarca
            .CondPrec = 12 'strCondicionVenta
            .Material = objArticulo.CodArticulo
            .ListPrec = "Z1" 'strListaPrecios
        End With

        oFacturaMgr.GetCondicionVenta(oResult)

        CargaCondicionVenta = oResult

        oResult = Nothing

    End Function

    Private Function Fm_bolTxtValidar() As Boolean

        If (oArticulo Is Nothing) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Function

        End If

        If ebDescuento.Text = "" Then
            'Por si esta vacio el campo
            MsgBox("El Descuento No puede estar Vacio.", MsgBoxStyle.Exclamation, "DPTienda")
            ebDescuento.Focus()
            Exit Function
        End If

        'If (ebDescuento.Text > (oAppContext.ApplicationConfiguration.DescApartado * 100)) Then

        '    MsgBox("El Artículo no puede ser apartado por que tiene un Porcentaje mayor al " & (oAppContext.ApplicationConfiguration.DescApartado * 100) & "%.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebDescuento.Focus()

        '    Exit Function

        'End If
        'If (oContratoMgr.ValidarTalla(ebNTalla.Text, oArticulo.CodCorrida) = False) Then
        '    'If (oContratoMgr.ValidarTalla(CType(ebTalla.Text, Decimal), oArticulo.CodCorrida) = False) Then
        '    MsgBox("La Talla del Artículo No es correcta.", MsgBoxStyle.Exclamation, "DPTienda")
        '    ebNTalla.Focus()

        '    Exit Function

        'End If

        If CDec(Me.ebCosto.Text) < 1 Then

            MsgBox("El precio debe ser mayor a 1 peso.", MsgBoxStyle.Exclamation, "DPTienda")
            Me.ebCodigo.Focus()

            Exit Function

        End If

        If oArticulo.CostoProm <= 0 Then

            MsgBox("El artículo no tiene costo.", MsgBoxStyle.Exclamation, "DPTienda")
            Me.ebCodigo.Focus()

            Exit Function

        End If

        If (ebCantidad.Text <= 0) Then

            MsgBox("La Cantidad debe ser Mayor a Cero.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCantidad.Focus()

            Exit Function

        End If

        If Me.ebDescuento.Value > (oConfigCierreFI.MaxDescApartados * 100) Then
            MessageBox.Show("El artículo seleccionado no puede ser apartado ya que tiene un porcentaje de descuento mayor al permitido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebCodigo.Focus()
            Exit Function
        End If

        Dim drDataRow() As DataRow
        'Ramiro       
        drDataRow = oContratoMgr.ActualizarDataSet("[ContratoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp).Select("CodArticulo ='" & oArticulo.CodArticulo & "' and Numero = '" & ebNTalla.Text & "'")


        Dim intTotalporArticulo As Integer

        If (drDataRow.Length = 0) Then

            intTotalporArticulo += ebCantidad.Text
            drDataRow = Nothing

        Else

            intTotalporArticulo = CType(drDataRow(0).Item("Cantidad"), Integer) + ebCantidad.Text
            drDataRow = Nothing

        End If

        'If (oContratoMgr.ValidarCantidad(intTotalporArticulo, oArticulo.CodArticulo, ebTalla.Text) = False) Then
        If (oContratoMgr.ValidarCantidad(intTotalporArticulo, oArticulo.CodArticulo, ebNTalla.Text) = False) Then

            MsgBox("El Artículo no cuenta con Existencias suficientes.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()
            Sm_TxtLimpiar()

            Exit Function

        End If


        'Utilizar el mismo Porcentaje de Descuento de un Artículo previamente capturado.
        decDescuento = oContratoMgr.BuscarArticuloTmp(oArticulo.CodArticulo, ebNTalla.Text)

        If (decDescuento = 0) Then 'No se encontro el Articulo.            

            decDescuento = ebDescuento.Text

        End If


        Return True

    End Function



    Private Sub Sm_CapturarArticuloScanner(ByVal strCodArticulo As String)

        Dim strTalla As String
        If (Microsoft.VisualBasic.Len(strCodArticulo) < 2) Then

            MsgBox("La longitud del Código Artículo debe ser mayor a 1 Carater.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        If Not IsNumeric(strCodArticulo) Then
            If IsNumeric(Mid(strCodArticulo, 1, 2)) Then
                ebCodigo.Text = Trim(Mid(strCodArticulo, 3, strCodArticulo.Length - 2))
                ebNTalla.Text = CType(Mid(strCodArticulo, 1, 2), Decimal) / 2
                ebCantidad.Text = 1
                ebDescuento.Focus()
            End If
        End If

        '    ebCodigo.Text = Microsoft.VisualBasic.Right(strCodArticulo, Microsoft.VisualBasic.Len(strCodArticulo) - 2)
        '    Ramiro()
        '    fALTA VER QUE ONDAS CON ESTO 
        '    If (CType(strTalla, Decimal) > 0) Then
        '        ebNTalla.Text = CType(strTalla, Decimal) / 2
        '    ElseIf (CType(strTalla, Decimal) = 0) Then
        '        ebNTalla.Text = CType(strTalla, Decimal)
        '    End If


        '    ebCantidad.Text = 1

        '    Sm_BuscarArticulo()

        '    <Validación>
        '    If (oArticulo Is Nothing) Then
        '        ebCodigo.Focus()
        '        Exit Sub
        '    End If
        '    </Validación>

        '    Sm_ActualizarGRID()

        '    ebDescuento.Text = 0.0
        '    ebDescuento.Focus()
        '    ebCantidad.Focus()

        '''Else

        Sm_BuscarArticulo()

        If (oArticulo Is Nothing) Then
            Exit Sub
        End If


        'End If

    End Sub



    Private Function Fm_bolValidarExistenciaRegistros() As Boolean

        Dim dsRegistros As DataSet



        dsRegistros = oContratoMgr.ActualizarDataSet("[ContratoDetalleTmpSel]", strTablaTmp)

        If (dsRegistros.Tables(strTablaTmp).Rows.Count = 0) Then

            MsgBox("No sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            dsRegistros.Dispose()
            dsRegistros = Nothing

            Exit Function

        End If

        dsRegistros.Dispose()
        dsRegistros = Nothing


        Return True

    End Function

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub frmCapturaContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub



    Private Sub frmCapturaContratos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_Finalizar()

    End Sub



    Private Sub frmCapturaContratos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim intLargo As Integer = 0
        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If


        If (e.KeyCode = Keys.Escape) Then

            Me.DialogResult = DialogResult.OK
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



    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnAgregar.Click

        If Me.ebCodigo.Text.Trim <> "" AndAlso Me.ebCosto.Text.Trim <> "" Then
            'Convierte a mayusculas si son letras
            Me.ebNTalla.Text = UCase(Me.ebNTalla.Text)

            If InStr(Me.ebNTalla.Text, ".5", CompareMethod.Text) = 0 And InStr(Me.ebNTalla.Text, ".0", CompareMethod.Text) <> 0 And IsNumeric(Me.ebNTalla.Text) Then
                Me.ebNTalla.Text = CInt(Me.ebNTalla.Text)
            End If

            '<Validación>
            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If
            '</Validación>


            oContratoMgr.AgregarArticulo(intContratoID, oArticulo, ebNTalla.Text, CType(ebCantidad.Text, Integer), _
                                         CType(decDescuento, Decimal), oAppContext.Security.CurrentUser.Name)


            Sm_ActualizarGRID()
            boolManual = False
            Me.ebCodigo.ReadOnly = True
            'TODO: RAMIRO ver si va a quedar asi
            Sm_TxtLimpiar()
            ebCodigo.Focus()
            ebCodigo.Text = String.Empty
        End If

    End Sub



    Private Sub uibtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnQuitar.Click

        Dim oCurrentRow As GridEXRow

        Dim odrDataRow As DataRowView


        '<Validación>
        If (Fm_bolValidarExistenciaRegistros() = False) Then
            Exit Sub
        End If
        '/<Validación>


        oCurrentRow = GridTraspasoCorrida.GetRow()

        odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

        With odrDataRow
            'Ramiro
            oContratoMgr.EliminarArticulo(.Item("CodArticulo"), .Item("Numero"))

        End With

        oCurrentRow = Nothing
        odrDataRow = Nothing

        Sm_ActualizarGRID()

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick
        If boolManual Then
            Sm_BuscarArticulo(True)

            ebNTalla.Text = "0"
            ebCantidad.Text = 0

            ebNTalla.Focus()
            ebCantidad.Focus()
            ebNTalla.Focus()

        End If
        
    End Sub



    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown
        
        If e.Alt And e.KeyCode = Keys.S Then
            If boolManual Then
                Sm_BuscarArticulo(True)

                ebNTalla.Text = "0"
                ebCantidad.Text = 0

                ebNTalla.Focus()
                ebCantidad.Focus()
                ebNTalla.Focus()
            End If


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

        If (ebCodigo.Text.Trim <> String.Empty) Then

            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                e.Cancel = True

            End If

        End If

    End Sub



    Private Sub ebCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.GotFocus

        ebCodigo.Text = String.Empty

    End Sub



    Private Sub uibtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnSalir.Click

        Me.Close()

    End Sub

#End Region


    Private Sub ebNTalla_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNTalla.Enter
        Me.ebNTalla.SelectAll()
    End Sub


    Private Sub ebNTalla_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNTalla.GotFocus
        Me.ebNTalla.SelectAll()
        ebNTalla.SelectionStart = 0
        ebNTalla.SelectionLength = Len(ebNTalla.Text)

    End Sub

    Private Sub ebNTalla_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNTalla.LostFocus
        Me.ebNTalla.Text = UCase(Me.ebNTalla.Text)
    End Sub
End Class
