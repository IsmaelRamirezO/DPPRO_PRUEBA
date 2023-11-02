
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX


Public Class frmCapturaTraspasos
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uibtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnQuitar As Janus.Windows.EditControls.UIButton
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebUnidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCosto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTotalArticulos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GridTraspasoCorrida As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebTalla As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents prgProgressBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaTraspasos))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.prgProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebTalla = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.uibtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.uibtnQuitar = New Janus.Windows.EditControls.UIButton()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.ebUnidad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCosto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTotalArticulos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GridTraspasoCorrida = New Janus.Windows.GridEX.GridEX()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.prgProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.ebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.ebTalla)
        Me.ExplorerBar1.Controls.Add(Me.uibtnSalir)
        Me.ExplorerBar1.Controls.Add(Me.uibtnQuitar)
        Me.ExplorerBar1.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.ebUnidad)
        Me.ExplorerBar1.Controls.Add(Me.ebCosto)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Captura de Traspasos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(328, 320)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(12, 264)
        Me.prgProgressBar1.Name = "prgProgressBar1"
        Me.prgProgressBar1.Size = New System.Drawing.Size(304, 3)
        Me.prgProgressBar1.TabIndex = 26
        '
        'ebCantidad
        '
        Me.ebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidad.Location = New System.Drawing.Point(87, 142)
        Me.ebCantidad.MaxLength = 7
        Me.ebCantidad.Name = "ebCantidad"
        Me.ebCantidad.Size = New System.Drawing.Size(56, 23)
        Me.ebCantidad.TabIndex = 3
        Me.ebCantidad.Text = "0"
        Me.ebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTalla
        '
        Me.ebTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTalla.Location = New System.Drawing.Point(87, 112)
        Me.ebTalla.MaxLength = 5
        Me.ebTalla.Name = "ebTalla"
        Me.ebTalla.Size = New System.Drawing.Size(56, 23)
        Me.ebTalla.TabIndex = 2
        Me.ebTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnSalir
        '
        Me.uibtnSalir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.uibtnSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnSalir.Location = New System.Drawing.Point(224, 280)
        Me.uibtnSalir.Name = "uibtnSalir"
        Me.uibtnSalir.Size = New System.Drawing.Size(80, 24)
        Me.uibtnSalir.TabIndex = 6
        Me.uibtnSalir.Text = "Salir"
        Me.uibtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnQuitar
        '
        Me.uibtnQuitar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnQuitar.Location = New System.Drawing.Point(128, 280)
        Me.uibtnQuitar.Name = "uibtnQuitar"
        Me.uibtnQuitar.Size = New System.Drawing.Size(80, 24)
        Me.uibtnQuitar.TabIndex = 5
        Me.uibtnQuitar.Text = "Quitar"
        Me.uibtnQuitar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Location = New System.Drawing.Point(32, 280)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.uitnAgregar.TabIndex = 4
        Me.uitnAgregar.Text = "Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUnidad
        '
        Me.ebUnidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidad.BackColor = System.Drawing.Color.Ivory
        Me.ebUnidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUnidad.Location = New System.Drawing.Point(87, 201)
        Me.ebUnidad.Name = "ebUnidad"
        Me.ebUnidad.ReadOnly = True
        Me.ebUnidad.Size = New System.Drawing.Size(56, 22)
        Me.ebUnidad.TabIndex = 5
        Me.ebUnidad.TabStop = False
        Me.ebUnidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCosto
        '
        Me.ebCosto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCosto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCosto.BackColor = System.Drawing.Color.Ivory
        Me.ebCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCosto.Location = New System.Drawing.Point(87, 172)
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
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(87, 85)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(216, 20)
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
        Me.ebCodigo.Location = New System.Drawing.Point(87, 56)
        Me.ebCodigo.MaxLength = 20
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(216, 22)
        Me.ebCodigo.TabIndex = 0
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Unidad:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Costo:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Talla:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebTotalArticulos)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.GridTraspasoCorrida)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Detalle del Traspaso"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(328, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(384, 320)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTotalArticulos
        '
        Me.ebTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalArticulos.Location = New System.Drawing.Point(272, 280)
        Me.ebTotalArticulos.Name = "ebTotalArticulos"
        Me.ebTotalArticulos.Size = New System.Drawing.Size(88, 22)
        Me.ebTotalArticulos.TabIndex = 11
        Me.ebTotalArticulos.TabStop = False
        Me.ebTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalArticulos.Visible = False
        Me.ebTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(152, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Total de Articulos:"
        Me.Label7.Visible = False
        '
        'GridTraspasoCorrida
        '
        Me.GridTraspasoCorrida.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridTraspasoCorrida.DesignTimeLayout = GridEXLayout1
        Me.GridTraspasoCorrida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTraspasoCorrida.GroupByBoxVisible = False
        Me.GridTraspasoCorrida.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTraspasoCorrida.Location = New System.Drawing.Point(8, 40)
        Me.GridTraspasoCorrida.Name = "GridTraspasoCorrida"
        Me.GridTraspasoCorrida.Size = New System.Drawing.Size(352, 232)
        Me.GridTraspasoCorrida.TabIndex = 1
        Me.GridTraspasoCorrida.TabStop = False
        Me.GridTraspasoCorrida.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridTraspasoCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmCapturaTraspasos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 306)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(720, 344)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(720, 344)
        Me.Name = "frmCapturaTraspasos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Traspasos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.GridTraspasoCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "Variables Miembros"

    Private oTraspasoSalida As TraspasoSalida

    Private oTraspasoSalidaMgr As TraspasosSalidaManager

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager


    Private strTablaTmp As String = "TraspasoDetalleTmp" & oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & oAppContext.Security.CurrentUser.ID

#End Region



#Region "Propiedades [WriteOnly]"

    Private intTraspasoID As Integer


    Public WriteOnly Property TraspasoID() As Integer

        Set(ByVal Valor As Integer)

            intTraspasoID = Valor
        End Set

    End Property

#End Region



#Region "Métodos Privados"

    Private Sub Sm_ActualizarGRID()

        GridTraspasoCorrida.DataSource = Nothing
        GridTraspasoCorrida.DataSource = oTraspasoSalidaMgr.ActualizarDataSet("[TraspasoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp)

    End Sub



    Private Sub Sm_TxtLimpiar()

        ebCodigo.Text = String.Empty

        ebDescripcion.Text = String.Empty

        ebTalla.Text = 0.0

        ebCantidad.Text = 0

        ebCosto.Text = String.Empty

        ebUnidad.Text = String.Empty

        ebCodigo.Focus()

    End Sub



    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then     'Or (ebCodigo.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog2


            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If


                oArticulo = Nothing
                'oArticulo = oCatalogoArticulosMgr.Load(oOpenRecordDlg.Record.Item("Código"))
                oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                With oArticulo

                    ebCodigo.Text = .CodArticulo
                    ebDescripcion.Text = .CodArticulo & " - " & .Descripcion
                    ebCosto.Text = Format(.CostoProm, "Standard")
                    ebUnidad.Text = .CodUnidadVta

                End With

            End If

        Else

            On Error Resume Next

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                Exit Sub

            End If

            With oArticulo

                ebCodigo.Text = .CodArticulo
                ebDescripcion.Text = .CodArticulo & " - " & .Descripcion
                ebCosto.Text = Format(.CostoProm, "Standard")
                ebUnidad.Text = .CodUnidadVta

            End With

        End If

    End Sub



    Private Function Fm_bolTxtValidar() As Boolean

        If (oArticulo Is Nothing) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()

            Exit Function

        End If


        If (oTraspasoSalidaMgr.ValidarTalla(CType(ebTalla.Text, Decimal), oArticulo.CodCorrida) = False) Then

            MsgBox("La Talla del Artículo No es correcta.", MsgBoxStyle.Exclamation, "DPTienda")
            ebTalla.Focus()

            Exit Function

        End If


        If (ebCantidad.Text <= 0) Then

            MsgBox("La Cantidad debe ser Mayor a Cero.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCantidad.Focus()

            Exit Function

        End If


        Dim drDataRow() As DataRow

        drDataRow = oTraspasoSalidaMgr.ActualizarDataSet("[TraspasoDetalleTmpSel]", strTablaTmp).Tables(strTablaTmp).Select("CodArticulo ='" & oArticulo.CodArticulo & "' and Talla = " & ebTalla.Text)


        Dim intTotalporArticulo As Integer

        If (drDataRow.Length = 0) Then

            intTotalporArticulo += ebCantidad.Text
            drDataRow = Nothing

        Else

            intTotalporArticulo = CType(drDataRow(0).Item("SCantidad"), Integer) + ebCantidad.Text
            drDataRow = Nothing

        End If


        If (oTraspasoSalidaMgr.ValidarCantidad(intTotalporArticulo, oArticulo.CodArticulo, ebTalla.Text, "099") = False) Then

            MsgBox("El Artículo no cuenta con Existencias suficientes.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()
            Sm_TxtLimpiar()

            Exit Function

        End If


        Return True

    End Function



    Private Function Fm_bolValidarExistenciaRegistros() As Boolean

        Dim dsRegistros As DataSet



        dsRegistros = oTraspasoSalidaMgr.ActualizarDataSet("[TraspasoDetalleTmpSel]", strTablaTmp)

        If (dsRegistros.Tables(strTablaTmp).Rows.Count = 0) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            dsRegistros.Dispose()
            dsRegistros = Nothing

            Exit Function

        End If


        Return True

    End Function



    Private Sub Sm_CapturarArticuloScanner(ByVal strCodArticulo As String)

        Dim strTalla As String



        If (Microsoft.VisualBasic.Len(strCodArticulo) < 2) Then

            MsgBox("La longitud del Código Artículo debe ser mayor a 1 Carater.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        strTalla = Microsoft.VisualBasic.Left(strCodArticulo.Trim, 2)

        If (IsNumeric(strTalla) = True) Then

            ebCodigo.Text = Microsoft.VisualBasic.Right(strCodArticulo, Microsoft.VisualBasic.Len(strCodArticulo) - 2)
            ebTalla.Text = CType(strTalla, Decimal) / 2
            ebCantidad.Text = 1

            Sm_Buscar()

            '<Validación>
            If (oArticulo Is Nothing) Then

                Exit Sub

            End If


            If (Fm_bolTxtValidar() = False) Then

                ebCodigo.Focus()
                ebCodigo.Text = String.Empty

                Exit Sub

            End If
            '</Validación>

            oTraspasoSalidaMgr.AgregarArticulo(oArticulo, CType(ebTalla.Text, Decimal), CType(ebCantidad.Text, Integer), _
                                              (CType(ebCantidad.Text, Integer) * CType(ebCosto.Text, Decimal)), intTraspasoID)

            Sm_ActualizarGRID()

            ebCodigo.Focus()
            ebCodigo.Text = String.Empty

        Else

            Sm_Buscar()

            If (oArticulo Is Nothing) Then

                Exit Sub

            End If

            ebTalla.Text = 0.0
            ebCantidad.Text = 0

            ebTalla.Focus()

        End If

    End Sub

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub frmCapturaTraspasos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oTraspasoSalidaMgr = New TraspasosSalidaManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)


        Sm_ActualizarGRID()

    End Sub



    Private Sub frmCapturaTraspasos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oTraspasoSalida = Nothing

        oTraspasoSalidaMgr = Nothing

        oArticulo = Nothing

        oCatalogoArticulosMgr = Nothing

    End Sub



    Private Sub frmCapturaTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If


        If (e.KeyCode = Keys.Escape) Then

            Me.DialogResult = DialogResult.OK
            Me.Close()

        End If

    End Sub



    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnAgregar.Click

        '<Validación>
        If (Fm_bolTxtValidar() = False) Then
            Exit Sub
        End If
        '</Validación>


        oTraspasoSalidaMgr.AgregarArticulo(oArticulo, CType(ebTalla.Text, Decimal), CType(ebCantidad.Text, Integer), _
                                          (CType(ebCantidad.Text, Integer) * CType(ebCosto.Text, Decimal)), intTraspasoID)

        Sm_ActualizarGRID()

        ebCodigo.Focus()
        ebCodigo.Text = String.Empty

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
            oTraspasoSalidaMgr.EliminarArticulo(.Item("CodArticulo"), .Item("Talla"))
        End With

        oCurrentRow = Nothing
        odrDataRow = Nothing

        Sm_ActualizarGRID()

    End Sub



    Private Sub uibtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnSalir.Click

        Me.Close()

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick

        Sm_Buscar(True)

        ebTalla.Text = 0.0
        ebCantidad.Text = 0

        ebTalla.Focus()
        ebCantidad.Focus()
        ebTalla.Focus()

    End Sub



    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

            ebTalla.Text = 0.0
            ebCantidad.Text = 0

            ebTalla.Focus()
            ebCantidad.Focus()
            ebTalla.Focus()

            'Else

            '    If (e.KeyCode = Keys.Enter) Then

            '        If (Microsoft.VisualBasic.Len(ebCodigo.Text.Trim) > 0) Then

            '            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

            '        End If

            '    End If

        End If

    End Sub



    Private Sub ebCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigo.Validating

        If (ebCodigo.Text.Trim <> String.Empty) Then

            Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

        End If

    End Sub



    Private Sub ebCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.GotFocus

        ebCodigo.Text = String.Empty

    End Sub

#End Region

End Class
