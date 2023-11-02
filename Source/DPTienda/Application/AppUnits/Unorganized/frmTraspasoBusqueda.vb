
Imports DPSoft.Framework.Configuration
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class frmTraspasoBusqueda
    Inherits System.Windows.Forms.Form


    Private m_bTipoBusqueda As Boolean

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uibtnActionCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnActionPrint As Janus.Windows.EditControls.UIButton
    Friend WithEvents uibtnActionOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents CCmbToDate As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents CCmbFromDate As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebSucDestinoDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAlmacenDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucDestinoCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAlmacenCod As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents uibtnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFolioTraspaso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasoBusqueda))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.txtFolioTraspaso = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.uibtnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.uibtnActionCancel = New Janus.Windows.EditControls.UIButton()
        Me.uibtnActionPrint = New Janus.Windows.EditControls.UIButton()
        Me.uibtnActionOk = New Janus.Windows.EditControls.UIButton()
        Me.GrdTraspasos = New Janus.Windows.GridEX.GridEX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CCmbToDate = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.CCmbFromDate = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebSucDestinoDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAlmacenDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucDestinoCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAlmacenCod = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.txtFolioTraspaso)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.uibtnBuscar)
        Me.ExplorerBar1.Controls.Add(Me.uibtnActionCancel)
        Me.ExplorerBar1.Controls.Add(Me.uibtnActionPrint)
        Me.ExplorerBar1.Controls.Add(Me.uibtnActionOk)
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.CCmbToDate)
        Me.ExplorerBar1.Controls.Add(Me.CCmbFromDate)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebAlmacenDesc)
        Me.ExplorerBar1.Controls.Add(Me.ebSucDestinoCod)
        Me.ExplorerBar1.Controls.Add(Me.ebAlmacenCod)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Periodo"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(624, 327)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(288, 47)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(64, 24)
        Me.UiButton1.TabIndex = 2
        Me.UiButton1.Text = "&Buscar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtFolioTraspaso
        '
        Me.txtFolioTraspaso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioTraspaso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioTraspaso.Location = New System.Drawing.Point(119, 47)
        Me.txtFolioTraspaso.MaxLength = 10
        Me.txtFolioTraspaso.Name = "txtFolioTraspaso"
        Me.txtFolioTraspaso.Size = New System.Drawing.Size(160, 23)
        Me.txtFolioTraspaso.TabIndex = 1
        Me.txtFolioTraspaso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtFolioTraspaso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Folio Traspaso:"
        '
        'uibtnBuscar
        '
        Me.uibtnBuscar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnBuscar.Image = CType(resources.GetObject("uibtnBuscar.Image"), System.Drawing.Image)
        Me.uibtnBuscar.Location = New System.Drawing.Point(16, 288)
        Me.uibtnBuscar.Name = "uibtnBuscar"
        Me.uibtnBuscar.Size = New System.Drawing.Size(152, 30)
        Me.uibtnBuscar.TabIndex = 3
        Me.uibtnBuscar.Text = "&Buscar Pendientes"
        Me.uibtnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnActionCancel
        '
        Me.uibtnActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.uibtnActionCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnActionCancel.Location = New System.Drawing.Point(520, 288)
        Me.uibtnActionCancel.Name = "uibtnActionCancel"
        Me.uibtnActionCancel.Size = New System.Drawing.Size(96, 30)
        Me.uibtnActionCancel.TabIndex = 6
        Me.uibtnActionCancel.Text = "&Cancelar"
        Me.uibtnActionCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnActionPrint
        '
        Me.uibtnActionPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnActionPrint.Location = New System.Drawing.Point(408, 288)
        Me.uibtnActionPrint.Name = "uibtnActionPrint"
        Me.uibtnActionPrint.Size = New System.Drawing.Size(97, 30)
        Me.uibtnActionPrint.TabIndex = 5
        Me.uibtnActionPrint.Text = "&Imprimir"
        Me.uibtnActionPrint.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uibtnActionOk
        '
        Me.uibtnActionOk.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnActionOk.Location = New System.Drawing.Point(296, 288)
        Me.uibtnActionOk.Name = "uibtnActionOk"
        Me.uibtnActionOk.Size = New System.Drawing.Size(98, 30)
        Me.uibtnActionOk.TabIndex = 4
        Me.uibtnActionOk.Text = "A&ceptar"
        Me.uibtnActionOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GrdTraspasos
        '
        Me.GrdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasos.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdTraspasos.GroupByBoxVisible = False
        Me.GrdTraspasos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdTraspasos.Location = New System.Drawing.Point(8, 80)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(608, 200)
        Me.GrdTraspasos.TabIndex = 7
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(312, 376)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "A"
        Me.Label4.Visible = False
        '
        'CCmbToDate
        '
        '
        '
        '
        Me.CCmbToDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.CCmbToDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CCmbToDate.Location = New System.Drawing.Point(352, 376)
        Me.CCmbToDate.Name = "CCmbToDate"
        Me.CCmbToDate.Size = New System.Drawing.Size(128, 22)
        Me.CCmbToDate.TabIndex = 17
        Me.CCmbToDate.Value = New Date(2007, 5, 3, 0, 0, 0, 0)
        Me.CCmbToDate.Visible = False
        Me.CCmbToDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'CCmbFromDate
        '
        '
        '
        '
        Me.CCmbFromDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.CCmbFromDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CCmbFromDate.Location = New System.Drawing.Point(144, 376)
        Me.CCmbFromDate.Name = "CCmbFromDate"
        Me.CCmbFromDate.Size = New System.Drawing.Size(136, 22)
        Me.CCmbFromDate.TabIndex = 15
        Me.CCmbFromDate.Value = New Date(2007, 5, 3, 0, 0, 0, 0)
        Me.CCmbFromDate.Visible = False
        Me.CCmbFromDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ebSucDestinoDesc
        '
        Me.ebSucDestinoDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebSucDestinoDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoDesc.Location = New System.Drawing.Point(648, 176)
        Me.ebSucDestinoDesc.Name = "ebSucDestinoDesc"
        Me.ebSucDestinoDesc.ReadOnly = True
        Me.ebSucDestinoDesc.Size = New System.Drawing.Size(176, 22)
        Me.ebSucDestinoDesc.TabIndex = 13
        Me.ebSucDestinoDesc.TabStop = False
        Me.ebSucDestinoDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAlmacenDesc
        '
        Me.ebAlmacenDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacenDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacenDesc.BackColor = System.Drawing.Color.Ivory
        Me.ebAlmacenDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlmacenDesc.Location = New System.Drawing.Point(640, 64)
        Me.ebAlmacenDesc.Name = "ebAlmacenDesc"
        Me.ebAlmacenDesc.ReadOnly = True
        Me.ebAlmacenDesc.Size = New System.Drawing.Size(200, 22)
        Me.ebAlmacenDesc.TabIndex = 10
        Me.ebAlmacenDesc.TabStop = False
        Me.ebAlmacenDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacenDesc.Visible = False
        Me.ebAlmacenDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucDestinoCod
        '
        Me.ebSucDestinoCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucDestinoCod.BackColor = System.Drawing.Color.White
        Me.ebSucDestinoCod.ButtonImage = CType(resources.GetObject("ebSucDestinoCod.ButtonImage"), System.Drawing.Image)
        Me.ebSucDestinoCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebSucDestinoCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucDestinoCod.Location = New System.Drawing.Point(648, 152)
        Me.ebSucDestinoCod.Name = "ebSucDestinoCod"
        Me.ebSucDestinoCod.Size = New System.Drawing.Size(72, 22)
        Me.ebSucDestinoCod.TabIndex = 12
        Me.ebSucDestinoCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucDestinoCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAlmacenCod
        '
        Me.ebAlmacenCod.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlmacenCod.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlmacenCod.ButtonImage = CType(resources.GetObject("ebAlmacenCod.ButtonImage"), System.Drawing.Image)
        Me.ebAlmacenCod.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebAlmacenCod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlmacenCod.Location = New System.Drawing.Point(640, 32)
        Me.ebAlmacenCod.MaxLength = 3
        Me.ebAlmacenCod.Name = "ebAlmacenCod"
        Me.ebAlmacenCod.Size = New System.Drawing.Size(192, 22)
        Me.ebAlmacenCod.TabIndex = 9
        Me.ebAlmacenCod.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlmacenCod.Visible = False
        Me.ebAlmacenCod.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(640, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Suc. Destino"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(536, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Suc. Almácen"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 376)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Periodo"
        Me.Label1.Visible = False
        '
        'frmTraspasoBusqueda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 327)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(552, 354)
        Me.Name = "frmTraspasoBusqueda"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de Traspasos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim DtDetalles As New DataTable

#Region "Variables Miembros"

    Dim oCatalogoAlmacenMgr As CatalogoAlmacenesManager
    Dim oAlmacen As Almacen

    Dim oTraspasoEntradaMgr As TraspasosEntradaManager

    Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

#End Region



#Region "Constantes Miembros"

    Const Cm_bolTraspasoEntrada As Boolean = False

    Const Cm_bolTraspasoSalida As Boolean = True

#End Region

#Region "Propiedades GET & SET"

    Public Property TipoBusqueda() As Boolean
        Get
            Return m_bTipoBusqueda
        End Get
        Set(ByVal Value As Boolean)
            m_bTipoBusqueda = Value
        End Set
    End Property


#End Region


#Region "Propiedades [ReadOnly]"

    Dim drResult As DataRowView

    Public ReadOnly Property Record() As DataRowView
        Get
            Return drResult
        End Get
    End Property

#End Region


#Region "Propiedades [WriteOnly]"

    Private bolTipoTraspaso As Boolean




    Public WriteOnly Property TipoTraspaso() As Boolean
        Set(ByVal Valor As Boolean)
            bolTipoTraspaso = Valor
        End Set
    End Property


#End Region



#Region "Métodos Privados"

    Private Sub Sm_InitializeObjects()

        oCatalogoAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext)

        With Me

            Sm_Configuracion()

            .CCmbFromDate.Value = Date.Today.AddMonths(-1)
            .CCmbToDate.Value = Date.Today

        End With



        'Dim dt As DataTable = oTraspasoEntradaMgr.TraspasoEntradaPendientesSelectAll.Tables("Traspaso")

        'Se comento todo esto por ke estaba lento el SAP
        'DtDetalles = oSap.Read_TraspasosEspera(Date.Today.AddYears(-5), Date.Today, "", "S")
        'If (DtDetalles.Rows.Count = 0) Then
        '    Exit Sub
        'End If


        'With GrdTraspasos

        '    .DataSource = DtDetalles

        '    .RetrieveStructure()
        '    SetupView()

        'End With

    End Sub



    Private Sub Sm_FinalizeObjects()

        On Error Resume Next

        oAlmacen = Nothing
        oCatalogoAlmacenMgr = Nothing

        oTraspasoEntradaMgr = Nothing

    End Sub



    Private Sub Sm_Configuracion()

        oAlmacen = oCatalogoAlmacenMgr.Load(oSap.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)


        If Not oAlmacen Is Nothing Then

            If (bolTipoTraspaso = Cm_bolTraspasoSalida) Then

                'Almácen = Yo [CML File] :

                ebAlmacenCod.ButtonStyle = EditControls.EditButtonStyle.NoButton
                ebAlmacenCod.ReadOnly = True
                ebAlmacenCod.BackColor = ebAlmacenDesc.BackColor  'Color.Yellow
                ebAlmacenCod.TabStop = False

                ebAlmacenCod.Text = oAlmacen.ID
                ebAlmacenDesc.Text = oAlmacen.Descripcion


                ebSucDestinoCod.ButtonStyle = EditControls.EditButtonStyle.Image
                ebSucDestinoCod.ReadOnly = False
                ebSucDestinoCod.BackColor = Color.White

            ElseIf (bolTipoTraspaso = Cm_bolTraspasoEntrada) Then

                'Destino = Yo [CML File] :

                ebAlmacenCod.ButtonStyle = EditControls.EditButtonStyle.Image
                ebAlmacenCod.ReadOnly = False
                ebAlmacenCod.BackColor = Color.White


                ebSucDestinoCod.ButtonStyle = EditControls.EditButtonStyle.NoButton
                ebSucDestinoCod.ReadOnly = True
                ebSucDestinoCod.BackColor = ebSucDestinoDesc.BackColor  'Color.Yellow
                ebSucDestinoCod.TabStop = False

                ebSucDestinoCod.Text = oAlmacen.ID
                ebSucDestinoDesc.Text = oAlmacen.Descripcion

            End If
        Else
            MsgBox("El Almácen no ha sido encontrado, debe realizar la descarga de almacenes para poder continuar.", MsgBoxStyle.Exclamation, "DPTienda")
        End If
    End Sub



    Private Sub Sm_BuscarAlmacen(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then 'Or (ebAlmacenCod.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As OpenRecordDialog
            oOpenRecordDlg = New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Dim strAlmacenID As String

                strAlmacenID = oOpenRecordDlg.Record.Item("CodAlmacen")


                oAlmacen = Nothing
                oAlmacen = oCatalogoAlmacenMgr.Load(oSap.Read_Centros(strAlmacenID))

                With Me

                    .ebAlmacenCod.Text = oAlmacen.ID
                    .ebAlmacenDesc.Text = oAlmacen.Descripcion

                    'uibtnBuscar.Focus()

                End With

            End If

            oOpenRecordDlg = Nothing

        Else

            oAlmacen = Nothing
            oAlmacen = oCatalogoAlmacenMgr.Load(ebAlmacenCod.Text.Trim)

            '<Validación>
            If (oAlmacen Is Nothing) Then

                MsgBox("El Almácen no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                ebAlmacenCod.Text = String.Empty
                ebAlmacenDesc.Text = String.Empty
                ebAlmacenCod.Focus()

                Exit Sub

            End If
            '</Validación>


            With Me

                .ebAlmacenCod.Text = oAlmacen.ID
                .ebAlmacenDesc.Text = oAlmacen.Descripcion

                'uibtnBuscar.Focus()

            End With

        End If

    End Sub



    Private Sub Sm_BuscarSucDestino(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then 'Or (ebSucDestinoCod.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As OpenRecordDialog


            oOpenRecordDlg = New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Dim strAlmacenID As String

                strAlmacenID = oOpenRecordDlg.Record.Item("CodAlmacen")

                oAlmacen = Nothing
                oAlmacen = oCatalogoAlmacenMgr.Load(strAlmacenID)

                With Me

                    .ebSucDestinoCod.Text = oAlmacen.ID
                    .ebSucDestinoDesc.Text = oAlmacen.Descripcion

                    'uibtnBuscar.Focus()

                End With

            End If

            oOpenRecordDlg = Nothing

        Else

            oAlmacen = Nothing
            oAlmacen = oCatalogoAlmacenMgr.Load(ebSucDestinoCod.Text.Trim)

            '<Validación>
            If (oAlmacen Is Nothing) Then

                MsgBox("El Almácen no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                ebSucDestinoCod.Text = String.Empty
                ebSucDestinoDesc.Text = String.Empty
                ebSucDestinoCod.Focus()

                Exit Sub

            End If
            '</Validación>


            With Me

                .ebSucDestinoCod.Text = oAlmacen.ID
                .ebSucDestinoDesc.Text = oAlmacen.Descripcion

                'uibtnBuscar.Focus()

            End With

        End If

    End Sub



    Public Sub SetupView()

        'With GrdTraspasos.Tables("Traspaso")

        '.Columns("Referencia").Visible = True
        '.Columns("Referencia").Width = 100

        ''.Columns("TraspasoID").Visible = False

        ''.Columns("Folio").Width = 70
        ''.Columns("Folio").Caption = "Folio"
        ''.Columns("Folio").Visible = False

        '.Columns("Status").TextAlignment = TextAlignment.Center

        ''.Columns("Fecha").Caption = "Creado el"
        ''.Columns("Fecha").FormatString = "dd / MMM / yyyy"
        ''.Columns("Fecha").TextAlignment = TextAlignment.Center
        ''.Columns("Fecha").Width = 90
        ''.Columns("Fecha").Visible = True

        ''.Columns("Usuario").Width = 54
        ''.Columns("Usuario").Caption = "Usuario"
        ''.Columns("Usuario").Visible = True

        '.Columns("S.Destino").Width = 80
        '.Columns("S.Destino").Caption = "S.Destino"
        '.Columns("S.Destino").TextAlignment = TextAlignment.Center
        ''.Columns("Origen").Visible = True
        '.Columns("S.Destino").Visible = True

        ''.Columns("Almacen").Width = 80
        '.Columns("S. Almacen").Width = 80
        '.Columns("S. Almacen").Caption = "S.Almacén"
        '.Columns("S. Almacen").TextAlignment = TextAlignment.Center
        '.Columns("S. Almacen").Visible = True

        ''.Columns("Cantidad").Width = 60
        ''.Columns("Cantidad").Caption = "Cantidad"
        ''.Columns("Cantidad").Visible = True
        ''.Columns("Cantidad").FormatString = "n"

        ''.Columns("Importe").Width = 75
        ''.Columns("Importe").Caption = "Importe"
        ''.Columns("Importe").Visible = True
        '''.Columns("Importe").FormatString = "###,###,###.##"
        ''.Columns("Importe").FormatString = "n"

        '.Columns("Status").Width = 45
        '.Columns("Status").Caption = "Status"
        '.Columns("Status").Visible = True


        'End With

    End Sub



    Private Sub Sm_BuscarTraspasos()

        Dim dtTraspasoEntrada As DataTable
        Dim datFromDate As Date
        Dim datToDate As Date

        '        Dim dt As DataTable


        datFromDate = CCmbFromDate.Value
        datToDate = DateAdd(DateInterval.Day, 1, CCmbToDate.Value)


        With GrdTraspasos

            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            If (bolTipoTraspaso = Cm_bolTraspasoEntrada) Then

                'dt = oTraspasoEntradaMgr.GetAll(ebSucDestinoCod.Text, oAlmacen.ID, datFromDate, datToDate, "TRA").Tables("Traspaso")
                DtDetalles = oSap.Read_TraspasosEspera(datFromDate, datToDate, "", "S", oConfigCierreFI.RecibirParcialmente)

            ElseIf (bolTipoTraspaso = Cm_bolTraspasoSalida) Then

                'dt = oTraspasoEntradaMgr.GetAll(oAlmacen.ID, ebAlmacenCod.Text, datFromDate, datToDate, "GRA").Tables("Traspaso")
                DtDetalles = oSap.Read_TraspasosEspera(datFromDate, datToDate, "", "S", oConfigCierreFI.RecibirParcialmente)

            End If


            If (DtDetalles.Rows.Count = 0) Then

                .DataSource = Nothing

                MsgBox("No se tienen Traspasos pendientes.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub

            End If


            .DataSource = DtDetalles

            .RetrieveStructure()
            SetupView()

            GrdTraspasos.Focus()

        End With

    End Sub

#End Region



#Region "Métodos Privados [Eventos]"

    Private Sub frmTraspasoBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub



    Private Sub frmTraspasoBusqueda_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_FinalizeObjects()

    End Sub



    Private Sub ebAlmacenCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebAlmacenCod.ButtonClick

        Sm_BuscarAlmacen(True)

    End Sub



    Private Sub ebAlmacenCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebAlmacenCod.KeyDown

        If (ebAlmacenCod.ReadOnly = True) Then
            Exit Sub
        End If



        If (e.KeyCode = Keys.Enter) Then

            'Sm_BuscarAlmacen()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarAlmacen(True)

        End If

    End Sub



    Private Sub ebAlmacenCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebAlmacenCod.Validating

        If (ebAlmacenCod.Text.Trim = String.Empty) Then

            oAlmacen = Nothing
            oAlmacen = oCatalogoAlmacenMgr.Create

            Exit Sub

        End If

        Sm_BuscarAlmacen()

    End Sub



    Private Sub ebSucDestinoCod_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebSucDestinoCod.ButtonClick

        Sm_BuscarSucDestino(True)

    End Sub



    Private Sub ebSucDestinoCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebSucDestinoCod.KeyDown

        If (ebSucDestinoCod.ReadOnly = True) Then
            Exit Sub
        End If


        If (e.KeyCode = Keys.Enter) Then

            'Sm_BuscarSucDestino()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarSucDestino(True)

        End If

    End Sub



    Private Sub ebSucDestinoCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSucDestinoCod.Validating

        If (ebSucDestinoCod.Text.Trim = String.Empty) Then

            oAlmacen = Nothing
            oAlmacen = oCatalogoAlmacenMgr.Create

            Exit Sub

        End If

        Sm_BuscarSucDestino()

    End Sub



    Private Sub uibtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnBuscar.Click

        '<Validación>
        'If (bolTipoTraspaso = Cm_bolTraspasoSalida) And (ebSucDestinoDesc.Text = String.Empty) Then

        '    MessageBox.Show("No ha sido seleccionado una Suc. Destino.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub

        'ElseIf (bolTipoTraspaso = Cm_bolTraspasoSalida) And (ebAlmacenCod.Text = String.Empty) Then

        '    MessageBox.Show("No ha sido seleccionado una Suc. Almácen.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub

        'End If


        'If (CCmbFromDate.Value > CCmbToDate.Value) Then

        '    MsgBox("La Fecha de Inicio es mayor a la Fecha Final.", MsgBoxStyle.Exclamation, "DPTienda")
        '    CCmbFromDate.Focus()

        '    Exit Sub

        'End If
        '</Validación>


        Cursor.Current = Cursors.WaitCursor

        Sm_BuscarTraspasos()

        Cursor.Current = Cursors.Default

    End Sub



    Private Sub GrdTraspasos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdTraspasos.SelectionChanged
        Dim oCurrentRow As GridEXRow

        oCurrentRow = GrdTraspasos.GetRow()

        drResult = Nothing

        drResult = CType(oCurrentRow.DataRow, DataRowView)
        oCurrentRow = Nothing

    End Sub



    Private Sub GrdTraspasos_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GrdTraspasos.RowDoubleClick

        Me.DialogResult = DialogResult.OK

    End Sub

#End Region


    Private Sub frmTraspasoBusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub uibtnActionPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnActionPrint.Click
        Try

            If Not Me.DtDetalles Is Nothing Then

                Dim oARReporte As New ActRptTrapasosPendientes(Me.DtDetalles)
                Dim oReportViewer As New ReportViewerForm



                oARReporte.Document.Name = "Traspasos Pendientes"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()



                Try

                    'oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception


            Throw ex


        End Try




    End Sub

    Private Sub GrdTraspasos_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GrdTraspasos.FormattingRow

    End Sub



    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

        If Me.txtFolioTraspaso.Text = "" Then
            MsgBox("Se necesita folio de Traspaso.", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If

        With GrdTraspasos

            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            DtDetalles = oSap.Read_TraspasosEspera(Date.Today.ToShortDateString, Date.Today.ToShortDateString, Me.txtFolioTraspaso.Text.PadLeft(10, "0"), "N", oConfigCierreFI.RecibirParcialmente)

            If (DtDetalles.Rows.Count = 0) Then

                .DataSource = Nothing

                MsgBox("El folio del Traspaso no esta pendiente.", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub

            End If

            TipoBusqueda = True

            Me.DialogResult = DialogResult.OK

        End With
    End Sub

    Private Sub uibtnActionOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uibtnActionOk.Click
        TipoBusqueda = False

        If DtDetalles.Rows.Count > 0 Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Debe seleccionar un Traspaso pendiente.", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If
    End Sub
    
End Class
