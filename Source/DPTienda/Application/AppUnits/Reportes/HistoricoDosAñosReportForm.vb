
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ReportHistoricoDosAñosAU
Imports Janus.Windows.GridEX

Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class HistoricoDosAñosReportForm
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebNumFin As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebTotalArticulos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebNumInicio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebSaldoFinal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSaldoInicial As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoricoDosAñosReportForm))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.ebSaldoFinal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSaldoInicial = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebNumFin = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.uibtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.ebTotalArticulos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.grDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ebNumInicio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel5)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel2)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoFinal)
        Me.ExplorerBar1.Controls.Add(Me.ebSaldoInicial)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursal)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebNumFin)
        Me.ExplorerBar1.Controls.Add(Me.uibtnEliminar)
        Me.ExplorerBar1.Controls.Add(Me.ebTotalArticulos)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.grDetalle)
        Me.ExplorerBar1.Controls.Add(Me.ebNumInicio)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Histórico de Dos Años"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(624, 400)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(128, 376)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Exportar"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(104, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 24)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "F5"
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(240, 376)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(48, 16)
        Me.lblLabel5.TabIndex = 92
        Me.lblLabel5.Text = "Salir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(31, 376)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 91
        Me.lblLabel2.Text = "Imprimir"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(208, 376)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 90
        Me.lblLabel1.Text = "Esc"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(7, 376)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 89
        Me.lblLabel4.Text = "F9"
        '
        'ebSaldoFinal
        '
        Me.ebSaldoFinal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoFinal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoFinal.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoFinal.Location = New System.Drawing.Point(468, 86)
        Me.ebSaldoFinal.Name = "ebSaldoFinal"
        Me.ebSaldoFinal.ReadOnly = True
        Me.ebSaldoFinal.Size = New System.Drawing.Size(65, 20)
        Me.ebSaldoFinal.TabIndex = 20
        Me.ebSaldoFinal.TabStop = False
        Me.ebSaldoFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoFinal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoInicial
        '
        Me.ebSaldoInicial.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoInicial.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoInicial.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoInicial.Location = New System.Drawing.Point(468, 63)
        Me.ebSaldoInicial.Name = "ebSaldoInicial"
        Me.ebSaldoInicial.ReadOnly = True
        Me.ebSaldoInicial.Size = New System.Drawing.Size(65, 20)
        Me.ebSaldoInicial.TabIndex = 18
        Me.ebSaldoInicial.TabStop = False
        Me.ebSaldoInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSaldoInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursal.Location = New System.Drawing.Point(468, 41)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(64, 20)
        Me.ebSucursal.TabIndex = 16
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Descripción"
        '
        'ebNumFin
        '
        Me.ebNumFin.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumFin.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumFin.BackColor = System.Drawing.Color.Ivory
        Me.ebNumFin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumFin.Location = New System.Drawing.Point(168, 88)
        Me.ebNumFin.Name = "ebNumFin"
        Me.ebNumFin.ReadOnly = True
        Me.ebNumFin.Size = New System.Drawing.Size(48, 22)
        Me.ebNumFin.TabIndex = 14
        Me.ebNumFin.TabStop = False
        Me.ebNumFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumFin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uibtnEliminar
        '
        Me.uibtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnEliminar.Image = CType(resources.GetObject("uibtnEliminar.Image"), System.Drawing.Image)
        Me.uibtnEliminar.Location = New System.Drawing.Point(191, 483)
        Me.uibtnEliminar.Name = "uibtnEliminar"
        Me.uibtnEliminar.Size = New System.Drawing.Size(176, 32)
        Me.uibtnEliminar.TabIndex = 4
        Me.uibtnEliminar.Text = "&Eliminar"
        Me.uibtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebTotalArticulos
        '
        Me.ebTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalArticulos.Location = New System.Drawing.Point(518, 490)
        Me.ebTotalArticulos.Name = "ebTotalArticulos"
        Me.ebTotalArticulos.ReadOnly = True
        Me.ebTotalArticulos.Size = New System.Drawing.Size(88, 22)
        Me.ebTotalArticulos.TabIndex = 13
        Me.ebTotalArticulos.TabStop = False
        Me.ebTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(398, 498)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Total de Articulos:"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Image = CType(resources.GetObject("uitnAgregar.Image"), System.Drawing.Image)
        Me.uitnAgregar.Location = New System.Drawing.Point(9, 483)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(176, 32)
        Me.uitnAgregar.TabIndex = 3
        Me.uitnAgregar.Text = "&Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'grDetalle
        '
        Me.grDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grDetalle.DesignTimeLayout = GridEXLayout1
        Me.grDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.grDetalle.GroupByBoxVisible = False
        Me.grDetalle.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grDetalle.Location = New System.Drawing.Point(8, 126)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.Size = New System.Drawing.Size(608, 240)
        Me.grDetalle.TabIndex = 2
        Me.grDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNumInicio
        '
        Me.ebNumInicio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumInicio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumInicio.BackColor = System.Drawing.Color.Ivory
        Me.ebNumInicio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumInicio.Location = New System.Drawing.Point(88, 88)
        Me.ebNumInicio.Name = "ebNumInicio"
        Me.ebNumInicio.ReadOnly = True
        Me.ebNumInicio.Size = New System.Drawing.Size(48, 22)
        Me.ebNumInicio.TabIndex = 4
        Me.ebNumInicio.TabStop = False
        Me.ebNumInicio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumInicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(88, 66)
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
        Me.ebCodigo.Location = New System.Drawing.Point(88, 41)
        Me.ebCodigo.MaxLength = 20
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(176, 22)
        Me.ebCodigo.TabIndex = 0
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(143, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Al"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Corrida"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(376, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Saldo Inicial"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(376, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 23)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Saldo Final"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(376, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Sucursal"
        '
        'HistoricoDosAñosReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 397)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "HistoricoDosAñosReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta General de Movimientos por Artículo a Dos Años"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Members Variables"

    Private oDG As HistoricoDosAñosDataGateway

    Private oArticulo As Articulo

    Private oCatalogoArticulosMgr As CatalogoArticuloManager

    Private oAlmacen As Almacen

    Private oCatalogoAlmacenes As CatalogoAlmacenesManager

    Private oContratoMgr As ContratoManager

    Private dsCatalogoCorridas As DataSet

    Private dtDetalle As DataTable

#End Region



#Region "Private Methods"

    Private Sub Sm_Inicializar()

        oDG = New HistoricoDosAñosDataGateway(oAppContext)

        oContratoMgr = New ContratoManager(oAppContext)

        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oCatalogoAlmacenes = New CatalogoAlmacenesManager(oAppContext)

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        dsCatalogoCorridas = oContratoMgr.ExtraerCatalogoCorridas

        oAlmacen = oCatalogoAlmacenes.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        ebSucursal.Text = oAlmacen.ID

        'grDetalle.SetDataBinding(dtDetalle, "Apartados")

    End Sub


    Private Sub Sm_Finalizar()

        oDG = Nothing

        oContratoMgr = Nothing

        oArticulo = Nothing
        oCatalogoArticulosMgr = Nothing

        oAlmacen = Nothing
        oCatalogoAlmacenes = Nothing

        dsCatalogoCorridas.Dispose()
        dsCatalogoCorridas = Nothing

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
                oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                With oArticulo

                    ebCodigo.Text = .CodArticulo
                    ebDescripcion.Text = .Descripcion

                    Sm_MostrarCorrida()
                    Sm_MostrarSaldos()
                    Sm_MostrarDetalle()

                End With

            Catch ex As Exception

                Return

            End Try

        Else

            oArticulo = Nothing
            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()
                ebCodigo.Focus()

                Exit Sub

            End If

            With oArticulo

                ebCodigo.Text = .CodArticulo
                ebDescripcion.Text = .Descripcion

            End With

            Sm_MostrarCorrida()
            Sm_MostrarSaldos()
            Sm_MostrarDetalle()

        End If

    End Sub


    Private Sub Sm_MostrarCorrida()

        Dim drFiltro() As DataRow

        'Articulo Tallas :
        drFiltro = dsCatalogoCorridas.Tables("CatalogoCorridas").Select("CodCorrida = '" & oArticulo.CodCorrida & "'")

        ebNumInicio.Text = drFiltro(0).Item("NumInicio")
        ebNumFin.Text = drFiltro(0).Item("NumFin")

        drFiltro = Nothing

    End Sub


    Private Sub Sm_MostrarSaldos()

        Dim intSaldoInicial As Integer
        Dim intSaldoFinal As Integer


        oDG.TotalSaldos(oArticulo.CodArticulo, intSaldoInicial, intSaldoFinal)

        ebSaldoInicial.Text = intSaldoInicial
        ebSaldoFinal.Text = intSaldoFinal

    End Sub


    Private Sub Sm_MostrarDetalle()

        dtDetalle = Nothing
        grDetalle.DataSource = Nothing

        dtDetalle = oDG.HistoricoDosAñosDetalleSel(oArticulo.CodArticulo)

        'grDetalle.DataSource = dtDetalle
        grDetalle.DataSource = dtDetalle.DefaultView

        grDetalle.RetrieveStructure()

        With grDetalle.Tables(0)

            .Columns("Origen").Width = 40
            .Columns("Referencia").Width = 80
            .Columns("Fecha").Width = 80
            .Columns("Descripcion").Width = 230

            .Columns("Entrada").Width = 55
            .Columns("Entrada").FormatString = "n"

            .Columns("Salida").Width = 45
            .Columns("Salida").FormatString = "n"

            .Columns("Saldo").Width = 40
            .Columns("Saldo").FormatString = "n"

        End With

    End Sub



    Private Sub Sm_TxtLimpiar()

        With oArticulo

            ebDescripcion.Text = String.Empty
            ebNumInicio.Text = String.Empty
            ebNumFin.Text = String.Empty
            ebSaldoInicial.Text = String.Empty
            ebSaldoFinal.Text = String.Empty

            On Error Resume Next
            dtDetalle.Dispose()
            dtDetalle = Nothing

        End With

    End Sub


    Private Sub Sm_CapturarArticuloScanner(ByVal strCodArticulo As String)

        Dim strTalla As String


        If (Microsoft.VisualBasic.Len(strCodArticulo) < 2) Then

            MsgBox("La longitud del Código Artículo debe ser mayor a 1 Carater.", MsgBoxStyle.Exclamation, "DPTienda")
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

        Else

            Sm_BuscarArticulo()

            If (oArticulo Is Nothing) Then

                Exit Sub

            End If

        End If

    End Sub


    Public Sub Sm_ActionPrint()

        Try
            If (oArticulo Is Nothing) Then

                MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodigo.Focus()
                Exit Sub

            End If


            If (dtDetalle.Rows.Count = 0) Then

                MsgBox("El Artículo no cuenta con Movimientos.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodigo.Focus()
                Exit Sub

            End If


            Dim oARReporte As New HistoricoDosAñosReport(oAlmacen, oArticulo.CodArticulo, oArticulo.Descripcion, _
                                                   ebNumInicio.Text & " AL " & ebNumFin.Text, ebSaldoInicial.Text, _
                                                   ebSaldoFinal.Text, dtDetalle)

            Dim oReportViewer As New ReportViewerForm


            oARReporte.Document.Name = "Histórico de Artículos Dos Años"
            oARReporte.Run()

            'Visualizar Reporte :

            oReportViewer.Report = oARReporte
            oReportViewer.Show()



            '    'Imprimir Directo :
            '    oARReporte.Document.Print(False, False)

        Catch ex As Exception

            Throw New ApplicationException(ex.Message, ex)

        End Try

        'oARReporte = Nothing

    End Sub


    Private Sub Sm_ExportarEXCEL()

        If (oArticulo Is Nothing) Then

            MsgBox("No ha sido seleccionado un Artículo.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()
            Exit Sub

        End If


        If (dtDetalle.Rows.Count = 0) Then

            MsgBox("El Artículo no cuenta con Movimientos.", MsgBoxStyle.Exclamation, "DPTienda")
            ebCodigo.Focus()
            Exit Sub

        End If


        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty


        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer 'counter

        Dim oRow As DataRow

        On Error Resume Next

        xlapp = GetObject(, "Excel.Application")

        If xlapp Is Nothing Then
            xlapp = CreateObject("Excel.Application")
            If xlapp Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Movimientos de Artículos Dos Años")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "REPORTE DE MOVIMIENTOS DE ARTÍCULOS DOS AÑOS"

        '****************************************
        'HOJA DE CALCULO APARTADOS EN TOTALES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE MOVIMIENTOS DE ARTÍCULOS DOS AÑOS"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:M1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:M1").BorderAround(, 2, 0, )
        wsxl.Range("A1:M1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Value = "SUCURSAL : " & oAlmacen.ID & "   " & oAlmacen.Descripcion
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True
        wsxl.Range("A2:M2").Merge()
        wsxl.Range("A2:M2").HorizontalAlignment = 3

        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Cells(3, 1).Value = "Fecha:"

        wsxl.Cells(3, 2).Font.Size = 10
        'wsxl.Cells(2, 2).Font.Bold = True
        wsxl.Cells(3, 2).Value = Format(Date.Now, "short date")

        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Cells(4, 1).Value = "Código:"

        wsxl.Cells(4, 2).Font.Size = 10
        'wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Cells(4, 2).Value = oArticulo.CodArticulo

        wsxl.Cells(5, 1).Font.Size = 10
        wsxl.Cells(5, 1).Font.Bold = True
        wsxl.Cells(5, 1).Value = "Descripción"

        wsxl.Cells(5, 2).Font.Size = 10
        'wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Cells(5, 2).Value = oArticulo.Descripcion

        wsxl.Cells(5, 8).Font.Size = 10
        wsxl.Cells(5, 8).Font.Bold = True
        wsxl.Cells(5, 8).Value = "Saldo Inicial"

        wsxl.Cells(5, 9).Font.Size = 10
        wsxl.Cells(5, 9).Value = ebSaldoInicial.Text

        wsxl.Cells(6, 8).Font.Size = 10
        wsxl.Cells(6, 8).Font.Bold = True
        wsxl.Cells(6, 8).Value = "Saldo Final"

        wsxl.Cells(6, 9).Font.Size = 10
        wsxl.Cells(6, 9).Value = ebSaldoFinal.Text

        wsxl.Cells(6, 1).Font.Size = 10
        wsxl.Cells(6, 1).Font.Bold = True
        wsxl.Cells(6, 1).Value = "Corrida"

        wsxl.Cells(6, 2).Font.Size = 10
        'wsxl.Cells(5, 1).Font.Bold = True
        wsxl.Cells(6, 2).Value = ebNumInicio.Text & " AL " & ebNumFin.Text

        'Encabezado
        Dim Columna As Integer = 0
        While Columna < grDetalle.RootTable.Columns.Count
            'wsxl.Cells(6, Columna + 1).Value = grDetalle.RootTable.Columns(Columna).Caption
            wsxl.Cells(8, Columna + 1).Value = grDetalle.RootTable.Columns(Columna).Caption
            wsxl.Columns(Columna + 1).AutoFitColumns()
            Columna = Columna + 1
        End While

        'wsxl.Range("A6:M6").Font.Bold = True
        'wsxl.Range("A6:M6").HorizontalAlignment = 3
        'wsxl.Range("A6:M6").Font.Size = 8
        'wsxl.Range("A6:M6").Interior.Color = RGB(255, 255, 192)
        'wsxl.Range("A6:M6").BorderAround(, 2, 0, )

        wsxl.Range("A8:M8").Font.Bold = True
        wsxl.Range("A8:M8").HorizontalAlignment = 3
        wsxl.Range("A8:M8").Font.Size = 8
        wsxl.Range("A8:M8").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A8:M8").BorderAround(, 2, 0, )

        intRow = 0

        For Each oCurrentRow As GridEXRow In grDetalle.GetRows

            Dim odrDataRow As DataRowView
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            For Each column As DataColumn In odrDataRow.DataView.Table.Columns

                wsxl.Cells(oCurrentRow.Position + 9, grDetalle.RootTable.Columns(column.ColumnName).Position + 1).value = _
                  odrDataRow(column.ColumnName)
            Next
            intRow += 1
        Next


        'wsxl.Range("D7:D" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        'wsxl.Range("F7:F" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        'wsxl.Range("G7:G" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        'wsxl.Range("I7:I" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        'wsxl.Range("J7:J" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"
        'wsxl.Range("K7:K" & Trim(Str(8 + intRow))).NumberFormat = "$ ###,###,##0.00"

        'wsxl.Cells(8 + intRow, 4).Value = "=SUMA(D7:D" & Trim(Str(7 + intRow)) & ")"
        wsxl.Cells(9 + intRow, 5).Value = "=SUMA(E9:E" & Trim(Str(8 + intRow)) & ")"
        wsxl.Cells(9 + intRow, 5).Font.Bold = True
        wsxl.Cells(9 + intRow, 6).Value = "=SUMA(F9:F" & Trim(Str(8 + intRow)) & ")"
        wsxl.Cells(9 + intRow, 6).Font.Bold = True

        wsxl.Cells(9 + intRow, 1).Value = "Totales . . ."
        wsxl.Cells(9 + intRow, 1).Font.Bold = True

        'wsxl.Cells(8 + intRow, 9).Value = "=SUMA(I7:I" & Trim(Str(7 + intRow)) & ")"
        'wsxl.Cells(8 + intRow, 10).Value = "=SUMA(J7:J" & Trim(Str(7 + intRow)) & ")"
        'wsxl.Cells(8 + intRow, 11).Value = "=SUMA(K7:K" & Trim(Str(7 + intRow)) & ")"

        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"

        If SaveDialog.ShowDialog = DialogResult.OK Then
            wbxl.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " DPTienda")
        End If

        wbxl.Close()
        wsxl = Nothing
        xlapp.Quit()
        xlapp = Nothing

        KillExcel()

    End Sub

#End Region



#Region "Members Methods [Events]"

    Private Sub HistoricoDosAñosReportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub


    Private Sub HistoricoDosAñosReportForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub


    Private Sub HistoricoDosAñosReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.F9) Then

            Sm_ActionPrint()

        End If


        If (e.KeyCode = Keys.F5) Then

            Me.Cursor.Current = Cursors.WaitCursor
            Sm_ExportarEXCEL()
            Me.Cursor.Current = Cursors.Default

        End If


        If (e.KeyCode = Keys.Escape) Then

            Me.Close()

        End If

    End Sub


    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick

        Sm_BuscarArticulo(True)

    End Sub


    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarArticulo(True)

        End If


        If (e.KeyCode = Keys.Enter) Then

            If (ebCodigo.Text.Trim <> String.Empty) Then

                Sm_CapturarArticuloScanner(ebCodigo.Text.Trim)

                If (oArticulo Is Nothing) Then

                    ebCodigo.Focus()

                End If

            Else

                MsgBox("El Artículo no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
                ebCodigo.Focus()

            End If

        End If

    End Sub

#End Region

End Class
