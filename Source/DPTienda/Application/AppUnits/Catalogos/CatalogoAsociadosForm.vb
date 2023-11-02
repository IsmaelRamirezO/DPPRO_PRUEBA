Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class CatalogoAsociadosForm
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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents npFotoDigital As PureComponents.NicePanel.NicePanel
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ebApeMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ebApePaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnCapturaFoto As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage4 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar5 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebLimiteDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebLimiteMayoreo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents chkDPVale As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkMayoreo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents npPicture As PureComponents.NicePanel.NicePanel
    Friend WithEvents pbFotografia As System.Windows.Forms.PictureBox
    Friend WithEvents ebSexo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebPlaza As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebFechaNacimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebCiudad As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUsuarioFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnVerDatosDPVale As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnVerDatosDTienda As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnVerDatosMayoreo As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkDTienda As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebCedulaFiscal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ebLimiteDTienda As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoVencidoDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoVencidoDTienda As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoVencidoMayoreo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoDTienda As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoMayoreo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodigoAsociado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodigoCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents pbActivo As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbInactivo As System.Windows.Forms.PictureBox
    Friend WithEvents chkStatus As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebTelefonoTrabajo As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebTelefonoOtro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents lblLabel17 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents btnDatosCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoAsociadosForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim ContainerImage2 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage3 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage4 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle2 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle2 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle3 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle4 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem14 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivoNuevo4 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTemas2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTemas1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.menuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuAyudaTemas = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ebObservaciones = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnDatosCliente = New Janus.Windows.EditControls.UIButton
        Me.ebTelefonoOtro = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.lblLabel1 = New System.Windows.Forms.Label
        Me.lblLabel17 = New System.Windows.Forms.Label
        Me.ebTelefonoTrabajo = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.pbActivo = New System.Windows.Forms.PictureBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.ebCodigoCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCodigoAsociado = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebCedulaFiscal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.npFotoDigital = New PureComponents.NicePanel.NicePanel
        Me.npPicture = New PureComponents.NicePanel.NicePanel
        Me.pbFotografia = New System.Windows.Forms.PictureBox
        Me.ebSexo = New Janus.Windows.EditControls.UIComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.ebEstado = New Janus.Windows.EditControls.UIComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ebCP = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.ebApeMaterno = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.ebApePaterno = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.btnCapturaFoto = New Janus.Windows.EditControls.UIButton
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.ebPlaza = New Janus.Windows.EditControls.UIComboBox
        Me.ebFechaNacimiento = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebCiudad = New Janus.Windows.EditControls.UIComboBox
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkStatus = New Janus.Windows.EditControls.UICheckBox
        Me.pbInactivo = New System.Windows.Forms.PictureBox
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.UiTabPage4 = New Janus.Windows.UI.Tab.UITabPage
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ExplorerBar5 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ebSaldoVencidoDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebSaldoVencidoDTienda = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebSaldoVencidoMayoreo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ebSaldoDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebSaldoDTienda = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebSaldoMayoreo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ebLimiteDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebLimiteDTienda = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebLimiteMayoreo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.ebUsuarioFecha = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.btnVerDatosDPVale = New Janus.Windows.EditControls.UIButton
        Me.btnVerDatosDTienda = New Janus.Windows.EditControls.UIButton
        Me.btnVerDatosMayoreo = New Janus.Windows.EditControls.UIButton
        Me.chkDPVale = New Janus.Windows.EditControls.UICheckBox
        Me.chkDTienda = New Janus.Windows.EditControls.UICheckBox
        Me.chkMayoreo = New Janus.Windows.EditControls.UICheckBox
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.npFotoDigital.SuspendLayout()
        Me.npPicture.SuspendLayout()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        Me.UiTabPage4.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.ExplorerBar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar5.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuArchivoAbrir, Me.menuArchivoGuardar, Me.menuArchivoEliminar, Me.menuArchivoImprimir, Me.menuAyudaTemas, Me.menuArchivoSalir, Me.menuArchivoNuevo})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("be3e375e-f2db-450d-a8ba-a37a392a5328")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.TabIndex = 0
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuArchivoSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(706, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo4, Me.Separator10, Me.menuArchivoNuevo2, Me.Separator4, Me.menuArchivoGuardar2, Me.Separator5, Me.menuArchivoEliminar2, Me.Separator6, Me.menuArchivoImprimir2, Me.Separator7, Me.menuAyudaTemas2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.ShowToolTips = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(401, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo4
        '
        Me.menuArchivoNuevo4.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo4.Name = "menuArchivoNuevo4"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoAbrir"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        Me.menuArchivoNuevo2.Text = "A&brir"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuArchivoImprimir2
        '
        Me.menuArchivoImprimir2.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir2.Name = "menuArchivoImprimir2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuAyudaTemas2
        '
        Me.menuAyudaTemas2.Key = "menuAyudaTemas"
        Me.menuAyudaTemas2.Name = "menuAyudaTemas2"
        Me.menuAyudaTemas2.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo3, Me.Separator9, Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator2, Me.menuArchivoEliminar1, Me.Separator3, Me.menuArchivoImprimir1, Me.Separator8})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo3
        '
        Me.menuArchivoNuevo3.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo3.Name = "menuArchivoNuevo3"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoAbrir"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoImprimir1
        '
        Me.menuArchivoImprimir1.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir1.Name = "menuArchivoImprimir1"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTemas1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTemas1
        '
        Me.menuAyudaTemas1.Key = "menuAyudaTemas"
        Me.menuAyudaTemas1.Name = "menuAyudaTemas1"
        '
        'menuArchivoAbrir
        '
        Me.menuArchivoAbrir.Image = CType(resources.GetObject("menuArchivoAbrir.Image"), System.Drawing.Image)
        Me.menuArchivoAbrir.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Name = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Text = "&Abrir"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Image = CType(resources.GetObject("menuArchivoEliminar.Image"), System.Drawing.Image)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "&Eliminar"
        '
        'menuArchivoImprimir
        '
        Me.menuArchivoImprimir.Image = CType(resources.GetObject("menuArchivoImprimir.Image"), System.Drawing.Image)
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "&Imprimir"
        '
        'menuAyudaTemas
        '
        Me.menuAyudaTemas.Image = CType(resources.GetObject("menuAyudaTemas.Image"), System.Drawing.Image)
        Me.menuAyudaTemas.Key = "menuAyudaTemas"
        Me.menuAyudaTemas.Name = "menuAyudaTemas"
        Me.menuAyudaTemas.Text = "Ay&uda"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.TabIndex = 0
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.TabIndex = 0
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(706, 50)
        Me.TopRebar1.TabIndex = 1
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebObservaciones)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.btnDatosCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefonoOtro)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel17)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefonoTrabajo)
        Me.ExplorerBar1.Controls.Add(Me.pbActivo)
        Me.ExplorerBar1.Controls.Add(Me.lblStatus)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigoCliente)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigoAsociado)
        Me.ExplorerBar1.Controls.Add(Me.ebCedulaFiscal)
        Me.ExplorerBar1.Controls.Add(Me.Label38)
        Me.ExplorerBar1.Controls.Add(Me.npFotoDigital)
        Me.ExplorerBar1.Controls.Add(Me.ebSexo)
        Me.ExplorerBar1.Controls.Add(Me.Label40)
        Me.ExplorerBar1.Controls.Add(Me.ebColonia)
        Me.ExplorerBar1.Controls.Add(Me.Label39)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.Label37)
        Me.ExplorerBar1.Controls.Add(Me.ebApeMaterno)
        Me.ExplorerBar1.Controls.Add(Me.Label31)
        Me.ExplorerBar1.Controls.Add(Me.ebApePaterno)
        Me.ExplorerBar1.Controls.Add(Me.Label29)
        Me.ExplorerBar1.Controls.Add(Me.btnCapturaFoto)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefono)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebPlaza)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaNacimiento)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.ebEmail)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.chkStatus)
        Me.ExplorerBar1.Controls.Add(Me.pbInactivo)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales del Asociado"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(816, 632)
        Me.ExplorerBar1.TabIndex = 7
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebObservaciones
        '
        Me.ebObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.Location = New System.Drawing.Point(176, 392)
        Me.ebObservaciones.Multiline = True
        Me.ebObservaciones.Name = "ebObservaciones"
        Me.ebObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ebObservaciones.Size = New System.Drawing.Size(272, 64)
        Me.ebObservaciones.TabIndex = 146
        Me.ebObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 392)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 23)
        Me.Label17.TabIndex = 145
        Me.Label17.Text = "Obsevaciones:"
        '
        'btnDatosCliente
        '
        Me.btnDatosCliente.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosCliente.Location = New System.Drawing.Point(280, 64)
        Me.btnDatosCliente.Name = "btnDatosCliente"
        Me.btnDatosCliente.Size = New System.Drawing.Size(144, 24)
        Me.btnDatosCliente.TabIndex = 2
        Me.btnDatosCliente.Text = "Datos del Cliente"
        Me.btnDatosCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebTelefonoOtro
        '
        Me.ebTelefonoOtro.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefonoOtro.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefonoOtro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefonoOtro.Location = New System.Drawing.Point(336, 365)
        Me.ebTelefonoOtro.Mask = "!(###) 000-0000"
        Me.ebTelefonoOtro.Name = "ebTelefonoOtro"
        Me.ebTelefonoOtro.Size = New System.Drawing.Size(112, 22)
        Me.ebTelefonoOtro.TabIndex = 4
        Me.ebTelefonoOtro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefonoOtro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(290, 368)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(48, 23)
        Me.lblLabel1.TabIndex = 144
        Me.lblLabel1.Text = "Otro :"
        '
        'lblLabel17
        '
        Me.lblLabel17.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel17.Location = New System.Drawing.Point(32, 368)
        Me.lblLabel17.Name = "lblLabel17"
        Me.lblLabel17.Size = New System.Drawing.Size(128, 23)
        Me.lblLabel17.TabIndex = 143
        Me.lblLabel17.Text = "Telefono Trabajo:"
        '
        'ebTelefonoTrabajo
        '
        Me.ebTelefonoTrabajo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefonoTrabajo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefonoTrabajo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefonoTrabajo.Location = New System.Drawing.Point(176, 365)
        Me.ebTelefonoTrabajo.Mask = "!(###) 000-0000"
        Me.ebTelefonoTrabajo.Name = "ebTelefonoTrabajo"
        Me.ebTelefonoTrabajo.Size = New System.Drawing.Size(112, 22)
        Me.ebTelefonoTrabajo.TabIndex = 3
        Me.ebTelefonoTrabajo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefonoTrabajo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbActivo
        '
        Me.pbActivo.BackColor = System.Drawing.Color.Transparent
        Me.pbActivo.Image = CType(resources.GetObject("pbActivo.Image"), System.Drawing.Image)
        Me.pbActivo.Location = New System.Drawing.Point(648, 32)
        Me.pbActivo.Name = "pbActivo"
        Me.pbActivo.Size = New System.Drawing.Size(24, 24)
        Me.pbActivo.TabIndex = 138
        Me.pbActivo.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(576, 32)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(72, 23)
        Me.lblStatus.TabIndex = 137
        Me.lblStatus.Text = "ACTIVO"
        '
        'ebCodigoCliente
        '
        Me.ebCodigoCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoCliente.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoCliente.ButtonImage = CType(resources.GetObject("ebCodigoCliente.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoCliente.DecimalDigits = 0
        Me.ebCodigoCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoCliente.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebCodigoCliente.Location = New System.Drawing.Point(176, 65)
        Me.ebCodigoCliente.MaxLength = 8
        Me.ebCodigoCliente.Name = "ebCodigoCliente"
        Me.ebCodigoCliente.Size = New System.Drawing.Size(96, 22)
        Me.ebCodigoCliente.TabIndex = 1
        Me.ebCodigoCliente.Text = "0"
        Me.ebCodigoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoCliente.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCodigoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoAsociado
        '
        Me.ebCodigoAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoAsociado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoAsociado.ButtonImage = CType(resources.GetObject("ebCodigoAsociado.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoAsociado.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoAsociado.DecimalDigits = 0
        Me.ebCodigoAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoAsociado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebCodigoAsociado.Location = New System.Drawing.Point(176, 40)
        Me.ebCodigoAsociado.MaxLength = 8
        Me.ebCodigoAsociado.Name = "ebCodigoAsociado"
        Me.ebCodigoAsociado.Size = New System.Drawing.Size(96, 22)
        Me.ebCodigoAsociado.TabIndex = 0
        Me.ebCodigoAsociado.Text = "0"
        Me.ebCodigoAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoAsociado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCodigoAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCedulaFiscal
        '
        Me.ebCedulaFiscal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCedulaFiscal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCedulaFiscal.BackColor = System.Drawing.Color.Ivory
        Me.ebCedulaFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCedulaFiscal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCedulaFiscal.Location = New System.Drawing.Point(176, 340)
        Me.ebCedulaFiscal.Name = "ebCedulaFiscal"
        Me.ebCedulaFiscal.ReadOnly = True
        Me.ebCedulaFiscal.Size = New System.Drawing.Size(272, 22)
        Me.ebCedulaFiscal.TabIndex = 16
        Me.ebCedulaFiscal.TabStop = False
        Me.ebCedulaFiscal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCedulaFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(32, 70)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(136, 18)
        Me.Label38.TabIndex = 56
        Me.Label38.Text = "Codigo Cliente:"
        '
        'npFotoDigital
        '
        Me.npFotoDigital.BackColor = System.Drawing.Color.Transparent
        Me.npFotoDigital.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.TopCenter
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.npFotoDigital.ContainerImage = ContainerImage1
        Me.npFotoDigital.ContextMenuButton = False
        Me.npFotoDigital.Controls.Add(Me.npPicture)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.npFotoDigital.FooterImage = HeaderImage1
        Me.npFotoDigital.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npFotoDigital.FooterVisible = False
        Me.npFotoDigital.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.npFotoDigital.HeaderImage = HeaderImage2
        Me.npFotoDigital.HeaderText = "Fotografía Digital"
        Me.npFotoDigital.IsExpanded = True
        Me.npFotoDigital.Location = New System.Drawing.Point(456, 56)
        Me.npFotoDigital.Name = "npFotoDigital"
        Me.npFotoDigital.OriginalFooterVisible = False
        Me.npFotoDigital.OriginalHeight = 0
        Me.npFotoDigital.Size = New System.Drawing.Size(240, 256)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(142, Byte), CType(179, Byte), CType(231, Byte))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(1, Byte), CType(45, Byte), CType(150, Byte))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(217, Byte), CType(232, Byte), CType(252, Byte))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(169, Byte), CType(198, Byte), CType(237, Byte))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(215, Byte), CType(230, Byte), CType(251, Byte))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.npFotoDigital.Style = PanelStyle1
        Me.npFotoDigital.TabIndex = 55
        Me.npFotoDigital.TabStop = False
        '
        'npPicture
        '
        Me.npPicture.BackColor = System.Drawing.Color.Transparent
        ContainerImage2.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage2.Image = Nothing
        ContainerImage2.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage2.Transparency = 50
        Me.npPicture.ContainerImage = ContainerImage2
        Me.npPicture.Controls.Add(Me.pbFotografia)
        HeaderImage3.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage3.Image = Nothing
        Me.npPicture.FooterImage = HeaderImage3
        Me.npPicture.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npPicture.FooterVisible = False
        Me.npPicture.ForeColor = System.Drawing.Color.Black
        HeaderImage4.ClipArt = PureComponents.NicePanel.ImageClipArt.PureComponents
        HeaderImage4.Image = Nothing
        Me.npPicture.HeaderImage = HeaderImage4
        Me.npPicture.HeaderText = "NicePanel1"
        Me.npPicture.HeaderVisible = False
        Me.npPicture.IsExpanded = True
        Me.npPicture.Location = New System.Drawing.Point(2, 26)
        Me.npPicture.Name = "npPicture"
        Me.npPicture.OriginalFooterVisible = False
        Me.npPicture.OriginalHeight = 0
        Me.npPicture.Size = New System.Drawing.Size(235, 227)
        ContainerStyle2.BackColor = System.Drawing.SystemColors.Control
        ContainerStyle2.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle2.BorderColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        ContainerStyle2.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle2.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))
        ContainerStyle2.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle2.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle2.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        ContainerStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle2.ForeColor = System.Drawing.Color.Black
        ContainerStyle2.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle2.ContainerStyle = ContainerStyle2
        PanelHeaderStyle3.BackColor = System.Drawing.SystemColors.Control
        PanelHeaderStyle3.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle3.FadeColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle3.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle3.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle3.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle3.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(169, Byte), CType(198, Byte), CType(237, Byte))
        PanelHeaderStyle3.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle2.FooterStyle = PanelHeaderStyle3
        PanelHeaderStyle4.BackColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle4.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle4.FadeColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle4.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle4.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle4.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle4.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(215, Byte), CType(230, Byte), CType(251, Byte))
        PanelHeaderStyle4.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle2.HeaderStyle = PanelHeaderStyle4
        Me.npPicture.Style = PanelStyle2
        Me.npPicture.TabIndex = 0
        Me.npPicture.TabStop = False
        '
        'pbFotografia
        '
        Me.pbFotografia.BackColor = System.Drawing.Color.Transparent
        Me.pbFotografia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbFotografia.Location = New System.Drawing.Point(0, 0)
        Me.pbFotografia.Name = "pbFotografia"
        Me.pbFotografia.Size = New System.Drawing.Size(235, 227)
        Me.pbFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFotografia.TabIndex = 0
        Me.pbFotografia.TabStop = False
        '
        'ebSexo
        '
        Me.ebSexo.BackColor = System.Drawing.Color.Ivory
        Me.ebSexo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebSexo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.Text = "MASCULINO"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.Text = "FEMENINO"
        Me.ebSexo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.ebSexo.Location = New System.Drawing.Point(360, 266)
        Me.ebSexo.Name = "ebSexo"
        Me.ebSexo.ReadOnly = True
        Me.ebSexo.Size = New System.Drawing.Size(88, 22)
        Me.ebSexo.TabIndex = 12
        Me.ebSexo.TabStop = False
        Me.ebSexo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(312, 272)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(40, 16)
        Me.Label40.TabIndex = 53
        Me.Label40.Text = "Sexo:"
        '
        'ebColonia
        '
        Me.ebColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColonia.BackColor = System.Drawing.Color.Ivory
        Me.ebColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColonia.Location = New System.Drawing.Point(176, 190)
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.ReadOnly = True
        Me.ebColonia.Size = New System.Drawing.Size(272, 22)
        Me.ebColonia.TabIndex = 7
        Me.ebColonia.TabStop = False
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(32, 190)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(144, 23)
        Me.Label39.TabIndex = 51
        Me.Label39.Text = "Colonia:"
        '
        'ebEstado
        '
        Me.ebEstado.BackColor = System.Drawing.Color.Ivory
        Me.ebEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.Text = "CHIAPAS"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.Text = "JALISCO"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.Text = "MEXICO"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.Text = "MICHOACAN"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.Text = "SINALOA"
        Me.ebEstado.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7})
        Me.ebEstado.Location = New System.Drawing.Point(176, 215)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.ReadOnly = True
        Me.ebEstado.Size = New System.Drawing.Size(168, 22)
        Me.ebEstado.TabIndex = 8
        Me.ebEstado.TabStop = False
        Me.ebEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 23)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Estado:"
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.BackColor = System.Drawing.Color.Ivory
        Me.ebCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCP.Location = New System.Drawing.Point(384, 241)
        Me.ebCP.Name = "ebCP"
        Me.ebCP.ReadOnly = True
        Me.ebCP.Size = New System.Drawing.Size(64, 22)
        Me.ebCP.TabIndex = 10
        Me.ebCP.TabStop = False
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(350, 245)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 23)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "C.P."
        '
        'ebApeMaterno
        '
        Me.ebApeMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApeMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApeMaterno.BackColor = System.Drawing.Color.Ivory
        Me.ebApeMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApeMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApeMaterno.Location = New System.Drawing.Point(176, 140)
        Me.ebApeMaterno.Name = "ebApeMaterno"
        Me.ebApeMaterno.ReadOnly = True
        Me.ebApeMaterno.Size = New System.Drawing.Size(248, 22)
        Me.ebApeMaterno.TabIndex = 5
        Me.ebApeMaterno.TabStop = False
        Me.ebApeMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApeMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(32, 144)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(128, 16)
        Me.Label31.TabIndex = 43
        Me.Label31.Text = "Apellido Materno:"
        '
        'ebApePaterno
        '
        Me.ebApePaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApePaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApePaterno.BackColor = System.Drawing.Color.Ivory
        Me.ebApePaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApePaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApePaterno.Location = New System.Drawing.Point(176, 115)
        Me.ebApePaterno.Name = "ebApePaterno"
        Me.ebApePaterno.ReadOnly = True
        Me.ebApePaterno.Size = New System.Drawing.Size(248, 22)
        Me.ebApePaterno.TabIndex = 4
        Me.ebApePaterno.TabStop = False
        Me.ebApePaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApePaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(32, 119)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 16)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "Apellido Paterno:"
        '
        'btnCapturaFoto
        '
        Me.btnCapturaFoto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFoto.Location = New System.Drawing.Point(456, 320)
        Me.btnCapturaFoto.Name = "btnCapturaFoto"
        Me.btnCapturaFoto.Size = New System.Drawing.Size(240, 31)
        Me.btnCapturaFoto.TabIndex = 5
        Me.btnCapturaFoto.Text = "Capturar Fotografia"
        Me.btnCapturaFoto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebTelefono
        '
        Me.ebTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefono.BackColor = System.Drawing.Color.Ivory
        Me.ebTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefono.Location = New System.Drawing.Point(176, 265)
        Me.ebTelefono.Mask = "!(###) 000-0000"
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.ReadOnly = True
        Me.ebTelefono.Size = New System.Drawing.Size(112, 22)
        Me.ebTelefono.TabIndex = 11
        Me.ebTelefono.TabStop = False
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(32, 268)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 23)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Telefono Particular:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 18)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Codigo Asociados:"
        '
        'ebPlaza
        '
        Me.ebPlaza.BackColor = System.Drawing.Color.Ivory
        Me.ebPlaza.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebPlaza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.Text = "MZT"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.Text = "CLN"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.Text = "IRA"
        Me.ebPlaza.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10})
        Me.ebPlaza.Location = New System.Drawing.Point(360, 291)
        Me.ebPlaza.Name = "ebPlaza"
        Me.ebPlaza.ReadOnly = True
        Me.ebPlaza.Size = New System.Drawing.Size(88, 22)
        Me.ebPlaza.TabIndex = 14
        Me.ebPlaza.TabStop = False
        Me.ebPlaza.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebFechaNacimiento
        '
        Me.ebFechaNacimiento.BackColor = System.Drawing.Color.Ivory
        Me.ebFechaNacimiento.Checked = False
        '
        'ebFechaNacimiento.DropDownCalendar
        '
        Me.ebFechaNacimiento.DropDownCalendar.Location = New System.Drawing.Point(0, 0)
        Me.ebFechaNacimiento.DropDownCalendar.Name = ""
        Me.ebFechaNacimiento.DropDownCalendar.Size = New System.Drawing.Size(170, 173)
        Me.ebFechaNacimiento.DropDownCalendar.TabIndex = 0
        Me.ebFechaNacimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ebFechaNacimiento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaNacimiento.Location = New System.Drawing.Point(176, 290)
        Me.ebFechaNacimiento.Name = "ebFechaNacimiento"
        Me.ebFechaNacimiento.ReadOnly = True
        Me.ebFechaNacimiento.Size = New System.Drawing.Size(112, 22)
        Me.ebFechaNacimiento.TabIndex = 13
        Me.ebFechaNacimiento.TabStop = False
        Me.ebFechaNacimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'ebCiudad
        '
        Me.ebCiudad.BackColor = System.Drawing.Color.Ivory
        Me.ebCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCiudad.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.Text = "CULIACA"
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.Text = "GUASAVE"
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.Text = "MAZATLAN"
        UiComboBoxItem14.FormatStyle.Alpha = 0
        UiComboBoxItem14.Text = "MOCHIS"
        Me.ebCiudad.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem11, UiComboBoxItem12, UiComboBoxItem13, UiComboBoxItem14})
        Me.ebCiudad.Location = New System.Drawing.Point(176, 240)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.ReadOnly = True
        Me.ebCiudad.Size = New System.Drawing.Size(168, 22)
        Me.ebCiudad.TabIndex = 9
        Me.ebCiudad.TabStop = False
        Me.ebCiudad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.BackColor = System.Drawing.Color.Ivory
        Me.ebEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(176, 315)
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.ReadOnly = True
        Me.ebEmail.Size = New System.Drawing.Size(272, 22)
        Me.ebEmail.TabIndex = 15
        Me.ebEmail.TabStop = False
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.BackColor = System.Drawing.Color.Ivory
        Me.ebDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(176, 165)
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.ReadOnly = True
        Me.ebDomicilio.Size = New System.Drawing.Size(272, 22)
        Me.ebDomicilio.TabIndex = 6
        Me.ebDomicilio.TabStop = False
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.BackColor = System.Drawing.Color.Ivory
        Me.ebNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(176, 90)
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.ReadOnly = True
        Me.ebNombre.Size = New System.Drawing.Size(248, 22)
        Me.ebNombre.TabIndex = 3
        Me.ebNombre.TabStop = False
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(32, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 23)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Cédula Fiscal:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(312, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 23)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Plaza:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Email:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Ciudad:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Domicilio:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fecha de Nacimiento:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nombre:"
        '
        'chkStatus
        '
        Me.chkStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkStatus.Location = New System.Drawing.Point(608, 64)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(72, 16)
        Me.chkStatus.TabIndex = 140
        Me.chkStatus.Text = "Status"
        '
        'pbInactivo
        '
        Me.pbInactivo.BackColor = System.Drawing.Color.Transparent
        Me.pbInactivo.Image = CType(resources.GetObject("pbInactivo.Image"), System.Drawing.Image)
        Me.pbInactivo.Location = New System.Drawing.Point(648, 32)
        Me.pbInactivo.Name = "pbInactivo"
        Me.pbInactivo.Size = New System.Drawing.Size(24, 24)
        Me.pbInactivo.TabIndex = 139
        Me.pbInactivo.TabStop = False
        Me.pbInactivo.Visible = False
        '
        'UiTab1
        '
        Me.UiTab1.Controls.Add(Me.UiTabPage1)
        Me.UiTab1.Controls.Add(Me.UiTabPage4)
        Me.UiTab1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiTab1.Location = New System.Drawing.Point(0, 48)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.SelectedIndex = 0
        Me.UiTab1.Size = New System.Drawing.Size(736, 488)
        Me.UiTab1.TabIndex = 2
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage4})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar1)
        Me.UiTabPage1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(734, 464)
        Me.UiTabPage1.TabIndex = 0
        Me.UiTabPage1.Text = "Datos del Asociado    "
        Me.UiTabPage1.Visible = False
        '
        'UiTabPage4
        '
        Me.UiTabPage4.Controls.Add(Me.ExplorerBar4)
        Me.UiTabPage4.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage4.Name = "UiTabPage4"
        Me.UiTabPage4.Size = New System.Drawing.Size(734, 408)
        Me.UiTabPage4.TabIndex = 3
        Me.UiTabPage4.Text = "Datos de Crédito"
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar4.Controls.Add(Me.ExplorerBar5)
        Me.ExplorerBar4.Controls.Add(Me.btnVerDatosDPVale)
        Me.ExplorerBar4.Controls.Add(Me.btnVerDatosDTienda)
        Me.ExplorerBar4.Controls.Add(Me.btnVerDatosMayoreo)
        Me.ExplorerBar4.Controls.Add(Me.chkDPVale)
        Me.ExplorerBar4.Controls.Add(Me.chkDTienda)
        Me.ExplorerBar4.Controls.Add(Me.chkMayoreo)
        Me.ExplorerBar4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Expanded = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Opciones de Credito"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(816, 504)
        Me.ExplorerBar4.TabIndex = 40
        Me.ExplorerBar4.Text = "ExplorerBar4"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ExplorerBar5
        '
        Me.ExplorerBar5.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar5.Controls.Add(Me.Label16)
        Me.ExplorerBar5.Controls.Add(Me.Label15)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoVencidoDPVale)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoVencidoDTienda)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoVencidoMayoreo)
        Me.ExplorerBar5.Controls.Add(Me.Label14)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoDPVale)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoDTienda)
        Me.ExplorerBar5.Controls.Add(Me.ebSaldoMayoreo)
        Me.ExplorerBar5.Controls.Add(Me.Label10)
        Me.ExplorerBar5.Controls.Add(Me.Label9)
        Me.ExplorerBar5.Controls.Add(Me.Label6)
        Me.ExplorerBar5.Controls.Add(Me.ebLimiteDPVale)
        Me.ExplorerBar5.Controls.Add(Me.ebLimiteDTienda)
        Me.ExplorerBar5.Controls.Add(Me.ebLimiteMayoreo)
        Me.ExplorerBar5.Controls.Add(Me.Label32)
        Me.ExplorerBar5.Controls.Add(Me.Label34)
        Me.ExplorerBar5.Controls.Add(Me.Label36)
        Me.ExplorerBar5.Controls.Add(Me.ebUsuarioFecha)
        Me.ExplorerBar5.Controls.Add(Me.ebUsuario)
        Me.ExplorerBar5.Controls.Add(Me.Label30)
        Me.ExplorerBar5.Controls.Add(Me.Label41)
        Me.ExplorerBar5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Limites de Credito"
        Me.ExplorerBar5.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar5.Location = New System.Drawing.Point(0, 128)
        Me.ExplorerBar5.Name = "ExplorerBar5"
        Me.ExplorerBar5.Size = New System.Drawing.Size(712, 384)
        Me.ExplorerBar5.TabIndex = 122
        Me.ExplorerBar5.Text = "ExplorerBar5"
        Me.ExplorerBar5.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(432, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 23)
        Me.Label16.TabIndex = 133
        Me.Label16.Text = "Saldo Vencido:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(432, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 23)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Saldo Vencido:"
        '
        'ebSaldoVencidoDPVale
        '
        Me.ebSaldoVencidoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoDPVale.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoVencidoDPVale.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoVencidoDPVale.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoVencidoDPVale.ForeColor = System.Drawing.Color.Red
        Me.ebSaldoVencidoDPVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoVencidoDPVale.Location = New System.Drawing.Point(536, 112)
        Me.ebSaldoVencidoDPVale.Name = "ebSaldoVencidoDPVale"
        Me.ebSaldoVencidoDPVale.ReadOnly = True
        Me.ebSaldoVencidoDPVale.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoVencidoDPVale.TabIndex = 131
        Me.ebSaldoVencidoDPVale.TabStop = False
        Me.ebSaldoVencidoDPVale.Text = "$0.00"
        Me.ebSaldoVencidoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoVencidoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoVencidoDTienda
        '
        Me.ebSaldoVencidoDTienda.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoDTienda.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoDTienda.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoVencidoDTienda.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoVencidoDTienda.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoVencidoDTienda.ForeColor = System.Drawing.Color.Red
        Me.ebSaldoVencidoDTienda.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoVencidoDTienda.Location = New System.Drawing.Point(536, 80)
        Me.ebSaldoVencidoDTienda.Name = "ebSaldoVencidoDTienda"
        Me.ebSaldoVencidoDTienda.ReadOnly = True
        Me.ebSaldoVencidoDTienda.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoVencidoDTienda.TabIndex = 130
        Me.ebSaldoVencidoDTienda.TabStop = False
        Me.ebSaldoVencidoDTienda.Text = "$0.00"
        Me.ebSaldoVencidoDTienda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoVencidoDTienda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoVencidoMayoreo
        '
        Me.ebSaldoVencidoMayoreo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoMayoreo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoVencidoMayoreo.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoVencidoMayoreo.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoVencidoMayoreo.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoVencidoMayoreo.ForeColor = System.Drawing.Color.Red
        Me.ebSaldoVencidoMayoreo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoVencidoMayoreo.Location = New System.Drawing.Point(536, 48)
        Me.ebSaldoVencidoMayoreo.Name = "ebSaldoVencidoMayoreo"
        Me.ebSaldoVencidoMayoreo.ReadOnly = True
        Me.ebSaldoVencidoMayoreo.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoVencidoMayoreo.TabIndex = 129
        Me.ebSaldoVencidoMayoreo.TabStop = False
        Me.ebSaldoVencidoMayoreo.Text = "$0.00"
        Me.ebSaldoVencidoMayoreo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoVencidoMayoreo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(432, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 23)
        Me.Label14.TabIndex = 128
        Me.Label14.Text = "Saldo Vencido:"
        '
        'ebSaldoDPVale
        '
        Me.ebSaldoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPVale.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoDPVale.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoDPVale.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoDPVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoDPVale.Location = New System.Drawing.Point(304, 112)
        Me.ebSaldoDPVale.Name = "ebSaldoDPVale"
        Me.ebSaldoDPVale.ReadOnly = True
        Me.ebSaldoDPVale.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoDPVale.TabIndex = 127
        Me.ebSaldoDPVale.TabStop = False
        Me.ebSaldoDPVale.Text = "$0.00"
        Me.ebSaldoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoDTienda
        '
        Me.ebSaldoDTienda.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoDTienda.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoDTienda.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoDTienda.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoDTienda.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoDTienda.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoDTienda.Location = New System.Drawing.Point(304, 80)
        Me.ebSaldoDTienda.Name = "ebSaldoDTienda"
        Me.ebSaldoDTienda.ReadOnly = True
        Me.ebSaldoDTienda.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoDTienda.TabIndex = 126
        Me.ebSaldoDTienda.TabStop = False
        Me.ebSaldoDTienda.Text = "$0.00"
        Me.ebSaldoDTienda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoDTienda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoMayoreo
        '
        Me.ebSaldoMayoreo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoMayoreo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoMayoreo.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoMayoreo.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebSaldoMayoreo.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebSaldoMayoreo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSaldoMayoreo.Location = New System.Drawing.Point(304, 48)
        Me.ebSaldoMayoreo.Name = "ebSaldoMayoreo"
        Me.ebSaldoMayoreo.ReadOnly = True
        Me.ebSaldoMayoreo.Size = New System.Drawing.Size(112, 23)
        Me.ebSaldoMayoreo.TabIndex = 125
        Me.ebSaldoMayoreo.TabStop = False
        Me.ebSaldoMayoreo.Text = "$0.00"
        Me.ebSaldoMayoreo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoMayoreo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(248, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 23)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Saldo:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(248, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 23)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "Saldo:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(248, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 23)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Saldo:"
        '
        'ebLimiteDPVale
        '
        Me.ebLimiteDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLimiteDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLimiteDPVale.BackColor = System.Drawing.Color.Ivory
        Me.ebLimiteDPVale.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebLimiteDPVale.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebLimiteDPVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebLimiteDPVale.Location = New System.Drawing.Point(120, 112)
        Me.ebLimiteDPVale.Name = "ebLimiteDPVale"
        Me.ebLimiteDPVale.ReadOnly = True
        Me.ebLimiteDPVale.Size = New System.Drawing.Size(112, 23)
        Me.ebLimiteDPVale.TabIndex = 114
        Me.ebLimiteDPVale.TabStop = False
        Me.ebLimiteDPVale.Text = "$0.00"
        Me.ebLimiteDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebLimiteDTienda
        '
        Me.ebLimiteDTienda.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLimiteDTienda.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLimiteDTienda.BackColor = System.Drawing.Color.Ivory
        Me.ebLimiteDTienda.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebLimiteDTienda.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebLimiteDTienda.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebLimiteDTienda.Location = New System.Drawing.Point(120, 80)
        Me.ebLimiteDTienda.Name = "ebLimiteDTienda"
        Me.ebLimiteDTienda.ReadOnly = True
        Me.ebLimiteDTienda.Size = New System.Drawing.Size(112, 23)
        Me.ebLimiteDTienda.TabIndex = 113
        Me.ebLimiteDTienda.TabStop = False
        Me.ebLimiteDTienda.Text = "$0.00"
        Me.ebLimiteDTienda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteDTienda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebLimiteMayoreo
        '
        Me.ebLimiteMayoreo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLimiteMayoreo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLimiteMayoreo.BackColor = System.Drawing.Color.Ivory
        Me.ebLimiteMayoreo.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.ebLimiteMayoreo.FlatBorderColor = System.Drawing.SystemColors.ControlDark
        Me.ebLimiteMayoreo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebLimiteMayoreo.Location = New System.Drawing.Point(120, 48)
        Me.ebLimiteMayoreo.Name = "ebLimiteMayoreo"
        Me.ebLimiteMayoreo.ReadOnly = True
        Me.ebLimiteMayoreo.Size = New System.Drawing.Size(112, 23)
        Me.ebLimiteMayoreo.TabIndex = 112
        Me.ebLimiteMayoreo.TabStop = False
        Me.ebLimiteMayoreo.Text = "$0.00"
        Me.ebLimiteMayoreo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteMayoreo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(40, 112)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 23)
        Me.Label32.TabIndex = 117
        Me.Label32.Text = "DpVale:"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(40, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 23)
        Me.Label34.TabIndex = 116
        Me.Label34.Text = "Tienda:"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(40, 48)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(72, 23)
        Me.Label36.TabIndex = 115
        Me.Label36.Text = "Mayoreo:"
        '
        'ebUsuarioFecha
        '
        Me.ebUsuarioFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuarioFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuarioFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebUsuarioFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuarioFecha.Location = New System.Drawing.Point(248, 199)
        Me.ebUsuarioFecha.Name = "ebUsuarioFecha"
        Me.ebUsuarioFecha.ReadOnly = True
        Me.ebUsuarioFecha.Size = New System.Drawing.Size(152, 22)
        Me.ebUsuarioFecha.TabIndex = 121
        Me.ebUsuarioFecha.TabStop = False
        Me.ebUsuarioFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuarioFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUsuario
        '
        Me.ebUsuario.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuario.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuario.BackColor = System.Drawing.Color.Ivory
        Me.ebUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuario.Location = New System.Drawing.Point(248, 168)
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.ReadOnly = True
        Me.ebUsuario.Size = New System.Drawing.Size(312, 22)
        Me.ebUsuario.TabIndex = 120
        Me.ebUsuario.TabStop = False
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(88, 202)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(136, 23)
        Me.Label30.TabIndex = 119
        Me.Label30.Text = "Fecha del Registro:"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(88, 176)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(160, 23)
        Me.Label41.TabIndex = 118
        Me.Label41.Text = "Usuario que Registró:"
        '
        'btnVerDatosDPVale
        '
        Me.btnVerDatosDPVale.Enabled = False
        Me.btnVerDatosDPVale.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDatosDPVale.Location = New System.Drawing.Point(544, 56)
        Me.btnVerDatosDPVale.Name = "btnVerDatosDPVale"
        Me.btnVerDatosDPVale.Size = New System.Drawing.Size(96, 32)
        Me.btnVerDatosDPVale.TabIndex = 119
        Me.btnVerDatosDPVale.Text = "Ver Datos"
        '
        'btnVerDatosDTienda
        '
        Me.btnVerDatosDTienda.Enabled = False
        Me.btnVerDatosDTienda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDatosDTienda.Location = New System.Drawing.Point(344, 56)
        Me.btnVerDatosDTienda.Name = "btnVerDatosDTienda"
        Me.btnVerDatosDTienda.Size = New System.Drawing.Size(96, 32)
        Me.btnVerDatosDTienda.TabIndex = 118
        Me.btnVerDatosDTienda.Text = "Ver Datos"
        '
        'btnVerDatosMayoreo
        '
        Me.btnVerDatosMayoreo.Enabled = False
        Me.btnVerDatosMayoreo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDatosMayoreo.Location = New System.Drawing.Point(136, 56)
        Me.btnVerDatosMayoreo.Name = "btnVerDatosMayoreo"
        Me.btnVerDatosMayoreo.Size = New System.Drawing.Size(96, 32)
        Me.btnVerDatosMayoreo.TabIndex = 117
        Me.btnVerDatosMayoreo.Text = "Ver Datos"
        '
        'chkDPVale
        '
        Me.chkDPVale.BackColor = System.Drawing.Color.Transparent
        Me.chkDPVale.Enabled = False
        Me.chkDPVale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDPVale.Location = New System.Drawing.Point(472, 64)
        Me.chkDPVale.Name = "chkDPVale"
        Me.chkDPVale.Size = New System.Drawing.Size(72, 23)
        Me.chkDPVale.TabIndex = 114
        Me.chkDPVale.Text = "DPVale"
        '
        'chkDTienda
        '
        Me.chkDTienda.BackColor = System.Drawing.Color.Transparent
        Me.chkDTienda.Enabled = False
        Me.chkDTienda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDTienda.Location = New System.Drawing.Point(264, 64)
        Me.chkDTienda.Name = "chkDTienda"
        Me.chkDTienda.Size = New System.Drawing.Size(80, 23)
        Me.chkDTienda.TabIndex = 113
        Me.chkDTienda.Text = "DTienda"
        '
        'chkMayoreo
        '
        Me.chkMayoreo.BackColor = System.Drawing.Color.Transparent
        Me.chkMayoreo.Enabled = False
        Me.chkMayoreo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMayoreo.Location = New System.Drawing.Point(56, 64)
        Me.chkMayoreo.Name = "chkMayoreo"
        Me.chkMayoreo.Size = New System.Drawing.Size(80, 23)
        Me.chkMayoreo.TabIndex = 112
        Me.chkMayoreo.Text = "Mayoreo"
        '
        'CatalogoAsociadosForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(706, 535)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CatalogoAsociadosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogos de Asociados"
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.npFotoDigital.ResumeLayout(False)
        Me.npPicture.ResumeLayout(False)
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.UiTabPage4.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        CType(Me.ExplorerBar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

    Dim msPicture As MemoryStream

    Private oClientesMgr As ClientesManager
    Private oCliente As Clientes

    Private oAsociadosMgr As AsociadosManager
    Private oAsociado As Asociado

    Dim LoadFromCliente As Boolean = False

#End Region

#Region "Inicializa Objetos"

    Private Sub InitializeObjects()

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.Create
        oCliente.Clear()

        oAsociadosMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadosMgr.Create
        oAsociado.Clear()

    End Sub

    Private Sub InitializeDataBindings()

        'Datos Asociado - Binding
        ebCodigoAsociado.DataBindings.Add(New Binding("Value", oAsociado, "AsociadoID"))
        ebCodigoCliente.DataBindings.Add(New Binding("Value", oAsociado, "ClienteID"))
        chkMayoreo.DataBindings.Add(New Binding("Checked", oAsociado, "EsCreditoMayoreo"))
        chkDTienda.DataBindings.Add(New Binding("Checked", oAsociado, "EsCreditoDirectoTienda"))
        chkDPVale.DataBindings.Add(New Binding("Checked", oAsociado, "EsCreditoDPVale"))
        ebLimiteMayoreo.DataBindings.Add(New Binding("Value", oAsociado, "LimiteCreditoMayoreo"))
        ebLimiteDPVale.DataBindings.Add(New Binding("Value", oAsociado, "LimiteCreditoDPVale"))
        ebLimiteDTienda.DataBindings.Add(New Binding("Value", oAsociado, "LimiteCreditoDirectoTienda"))
        ebSaldoMayoreo.DataBindings.Add(New Binding("Value", oAsociado, "SaldoMayoreo"))
        ebSaldoDTienda.DataBindings.Add(New Binding("Value", oAsociado, "SaldoDirectoTienda"))
        ebSaldoDPVale.DataBindings.Add(New Binding("Value", oAsociado, "SaldoDPVale"))
        ebSaldoVencidoMayoreo.DataBindings.Add(New Binding("Value", oAsociado, "SaldoVencMayoreo"))
        ebSaldoVencidoDTienda.DataBindings.Add(New Binding("Value", oAsociado, "SaldoVencDirectoTienda"))
        ebSaldoVencidoDPVale.DataBindings.Add(New Binding("Value", oAsociado, "SaldoVencDPVale"))
        oAsociado.Usuario = oAppContext.Security.CurrentUser.Name
        chkStatus.DataBindings.Add(New Binding("Checked", oAsociado, "StatusRegistro"))
        ebTelefonoTrabajo.DataBindings.Add(New Binding("Text", oAsociado, "TeleFonoTrabajo"))
        ebTelefonoOtro.DataBindings.Add(New Binding("Text", oAsociado, "TeleFonoOtro"))
        ebObservaciones.DataBindings.Add(New Binding("Text", oAsociado, "Observaciones"))

        'Datos Cliente - Binding
        ebNombre.DataBindings.Add(New Binding("Text", oCliente, "Nombre"))
        ebApePaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoPaterno"))
        ebApeMaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoMaterno"))
        ebDomicilio.DataBindings.Add(New Binding("Text", oCliente, "Domicilio"))
        ebColonia.DataBindings.Add(New Binding("Text", oCliente, "Colonia"))
        ebEstado.DataBindings.Add(New Binding("Text", oCliente, "Estado"))
        ebCiudad.DataBindings.Add(New Binding("Text", oCliente, "Ciudad"))
        ebCP.DataBindings.Add(New Binding("Text", oCliente, "CP"))
        ebTelefono.DataBindings.Add(New Binding("Text", oCliente, "Telefono"))
        ebSexo.DataBindings.Add(New Binding("Text", oCliente, "Sexo"))
        ebFechaNacimiento.DataBindings.Add(New Binding("Value", oCliente, "FechaNac"))
        ebPlaza.DataBindings.Add(New Binding("Text", oCliente, "CodPlaza"))
        ebEmail.DataBindings.Add(New Binding("Text", oCliente, "Email"))
        ebCedulaFiscal.DataBindings.Add(New Binding("Text", oCliente, "CedulaFiscal"))

    End Sub

#End Region

    Public Sub Limpiar()

        ebNombre.Text = String.Empty
        Me.ebApePaterno.Text = String.Empty
        Me.ebApeMaterno.Text = String.Empty
        Me.ebDomicilio.Text = String.Empty
        Me.ebColonia.Text = String.Empty
        Me.ebEstado.Text = String.Empty
        Me.ebCiudad.Text = String.Empty
        Me.ebCP.Text = String.Empty
        Me.ebTelefono.Text = String.Empty
        Me.ebSexo.Text = String.Empty
        Me.ebFechaNacimiento.Text = String.Empty
        Me.ebPlaza.Text = String.Empty
        Me.ebEmail.Text = String.Empty
        Me.pbFotografia.Image = Nothing
        Me.ebCedulaFiscal.Text = String.Empty
        Me.ebCodigoCliente.Enabled = True
        Me.ebCodigoCliente.ReadOnly = False
        Me.ebTelefonoOtro.Text = String.Empty
        Me.ebTelefonoTrabajo.Text = String.Empty
        Me.ebObservaciones.Text = String.Empty

        ebCodigoAsociado.Text = 0
        Me.ebCodigoCliente.Focus()
        Me.ebCodigoCliente.SelectAll()

        oAsociado.Clear()
        oCliente.Clear()


    End Sub

#Region "Methods"

    Private Sub CatalogoAsociadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not LoadFromCliente Then

            InitializeObjects()

            InitializeDataBindings()

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoSalir"

                Me.Close()

            Case "menuArchivoAbrir"

                Nuevo()

            Case "menuArchivoGuardar"

                Guardar()

            Case "menuArchivoNuevo"

                Nuevo()

            Case "menuArchivoEliminar"

                Eliminar()

            Case Else

                MsgBox(e.Command.Key.ToString)

        End Select

    End Sub

    Private Sub ebCodigoCliente_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCodigoCliente.ButtonClick

        LoadSearchFormClientes()

    End Sub

    Private Sub LoadSearchFormClientes()

        Me.ebTelefonoOtro.Text = String.Empty
        Me.ebTelefonoTrabajo.Text = String.Empty

        Dim oOpenRecordDlg As New OpenRecordDialogClientes
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            oClientesMgr.LoadInto(oOpenRecordDlg.Record.Item("ClienteID"), oCliente)

            If oCliente.ClienteID = 0 Then

                MsgBox("Cliente no está registrado. Verifique. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Clientes")
                oAsociado.ClienteID = oCliente.ClienteID
                ebCodigoCliente.Focus()

            Else


                oAsociado.ClienteID = oCliente.ClienteID

                ''''''''''''''Se busca si el cliente ya es Asociado
                BuscaClienteAsociado(oCliente.ClienteID)
                ''''''''''''''Fin Busqueda de Cliente como Asociado

                btnCapturaFoto.Focus()

            End If

        End If

    End Sub

    Private Sub BuscaClienteAsociado(ByVal ClienteID As String)
        ''''''''''''''Se busca si el cliente ya es Asociado
        Me.ebCodigoAsociado.Text = String.Empty
        Dim dsAsociados As DataSet
        dsAsociados = oAsociadosMgr.GetAll(False)

        Dim row() As DataRow

        row = dsAsociados.Tables("Asociados").Select("ClienteID=" & ClienteID)

        If row.Length > 0 Then
            oAsociadosMgr.LoadInto(row(0).Item(0), oAsociado)


            If Not (oAsociado.Foto Is Nothing) Then

                Dim oFotoAsociado() As Byte = CType(oAsociado.Foto, Byte())
                Dim msFotoAsociado As New MemoryStream(oFotoAsociado)

                pbFotografia.Image = Image.FromStream(msFotoAsociado)

            Else

                pbFotografia.Image = Nothing

            End If

            ebUsuario.Text = oAsociado.Usuario
            ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")

            oAsociado.Usuario = oAppContext.Security.CurrentUser.Name
            oAsociado.Fecha = Date.Today
            Me.ebTelefonoTrabajo.Text = oAsociado.TeleFonoTrabajo
            Me.ebTelefonoOtro.Text = oAsociado.TeleFonoOtro
            Me.ebObservaciones.Text = oAsociado.Observaciones

            oAsociado.ResetFlagNew()
        Else
            Me.ebTelefonoTrabajo.Text = String.Empty
            Me.ebTelefonoOtro.Text = String.Empty
            Me.ebObservaciones.Text = String.Empty
            oAsociado.SetFlagNew()
        End If

        ''''''''''''''Fin Busqueda de Cliente como Asociado
    End Sub

    Private Sub BuscarCliente()

        Me.ebTelefonoOtro.Text = String.Empty
        Me.ebTelefonoTrabajo.Text = String.Empty

        If ebCodigoCliente.Value <> oCliente.ClienteID Then

            If ebCodigoCliente.Value > 0 Then

                oCliente.Clear()

                oClientesMgr.LoadInto(ebCodigoCliente.Value, oCliente)

                If oCliente.ClienteID = 0 Then

                    MsgBox("Codigo de Cliente No Existe. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                    ebCodigoCliente.Value = 0

                    oAsociado.ClienteID = oCliente.ClienteID

                    oCliente.Clear()

                    ebCodigoCliente.Focus()

                Else

                    oAsociado.ClienteID = oCliente.ClienteID

                    ''''''''''''''Se busca si el cliente ya es Asociado
                    BuscaClienteAsociado(oCliente.ClienteID)
                    ''''''''''''''Fin Busqueda de Cliente como Asociado
                End If



            End If

        Else

            If ebCodigoCliente.Value <> 0 Then

                MsgBox("Codigo de Cliente Incorrecto. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                ebCodigoCliente.Value = 0

                oAsociado.ClienteID = oCliente.ClienteID

                ebCodigoCliente.Focus()

            Else

                oCliente.Clear()

            End If

        End If


    End Sub

    Private Sub btnCapturaFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapturaFoto.Click

        Dim oPictureFile As New OpenFileDialog

        With oPictureFile
            .InitialDirectory = "C:\"
            .Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif"
            .FilterIndex = 2
        End With

        If oPictureFile.ShowDialog() = DialogResult.OK Then

            With pbFotografia
                .Image = System.Drawing.Image.FromFile(oPictureFile.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.None
            End With

            Dim ms As New MemoryStream
            pbFotografia.Image.Save(ms, pbFotografia.Image.RawFormat)
            Dim Image() As Byte = ms.GetBuffer
            ms.Close()

            oAsociado.Foto = Image

        Else

            oAsociado.Foto = Nothing

        End If

        btnCapturaFoto.Focus()

    End Sub

    Private Sub BuscarAsociado()

        Me.ebTelefonoOtro.Text = String.Empty
        Me.ebTelefonoTrabajo.Text = String.Empty

        If ebCodigoAsociado.Value <> oAsociado.AsociadoID Then

            If ebCodigoAsociado.Value > 0 Then

                oAsociado.Clear()

                oCliente.Clear()

                pbFotografia.Image = Nothing

                oAsociadosMgr.LoadInto(ebCodigoAsociado.Value, oAsociado)

                If oAsociado.AsociadoID = 0 Then

                    MsgBox("Codigo de Asociado No Existe. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                    ebCodigoAsociado.Value = 0

                    ebCodigoCliente.Enabled = True

                    ebCodigoAsociado.Focus()

                Else

                    If oAsociado.ClienteID <> 0 Then

                        oCliente.Clear()

                        oClientesMgr.LoadInto(ebCodigoCliente.Value, oCliente)

                        If Not (oCliente.ClienteID = 0) Then

                            oAsociado.ClienteID = oCliente.ClienteID

                            ebCodigoCliente.Enabled = False

                        End If

                    End If

                    If Not (oAsociado.Foto Is Nothing) Then

                        Dim oFotoAsociado() As Byte = CType(oAsociado.Foto, Byte())
                        Dim msFotoAsociado As New MemoryStream(oFotoAsociado)

                        pbFotografia.Image = Image.FromStream(msFotoAsociado)

                    Else

                        pbFotografia.Image = Nothing

                    End If

                    ebUsuario.Text = oAsociado.Usuario
                    ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")

                    oAsociado.Usuario = oAppContext.Security.CurrentUser.Name
                    oAsociado.Fecha = Date.Today

                    oAsociado.AsociadoID = ebCodigoAsociado.Value

                    oAsociado.ResetFlagNew()

                End If

            Else

                If ebCodigoAsociado.Value <> 0 Then

                    MsgBox("Codigo de Asociado Incorrecto. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                    ebCodigoAsociado.Value = 0

                    ebCodigoCliente.Enabled = True

                    ebCodigoAsociado.Focus()

                End If

            End If

        End If

    End Sub

    Private Sub Nuevo()

        UiTabPage1.Select()

        UiTabPage1.Selected = True

        UiTabPage1.Show()

        chkStatus.Checked = True

        ebCodigoCliente.Value = 0

        ebCodigoCliente.Enabled = True

        ebCodigoAsociado.Value = 0

        ebUsuario.Text = String.Empty

        ebUsuarioFecha.Text = String.Empty

        Limpiar()

        oCliente.Clear()

        oAsociado.Clear()

        pbFotografia.Image = Nothing

        ebCodigoAsociado.Focus()

    End Sub

    Private Sub Guardar()

        If ebCodigoCliente.Value = 0 Then

            MsgBox("Debe ingresar Código de Cliente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

            ebCodigoCliente.Focus()

            Exit Sub
        ElseIf Me.ebCodigoCliente.Value = 1 Then

            MsgBox("El cliente no puede ser dado de alta como Asociado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

            ebCodigoCliente.Focus()

            Exit Sub

        ElseIf Me.ebTelefonoTrabajo.Text = String.Empty Then

            MsgBox("Debe ingresar Telefono de Trabajo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

            Me.ebTelefonoTrabajo.Focus()

            Exit Sub

        ElseIf Me.ebTelefonoOtro.Text = String.Empty Then

            MsgBox("Debe ingresar Telefono Otro. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

            Me.ebTelefonoOtro.Focus()

            Exit Sub

        End If

        Me.oAsociado.TeleFonoTrabajo = Me.ebTelefonoTrabajo.Text
        Me.oAsociado.TeleFonoOtro = Me.ebTelefonoOtro.Text
        Me.oAsociado.Observaciones = Me.ebObservaciones.Text

        Me.Cursor = Cursors.WaitCursor

        Dim myID As Integer

        myID = oAsociadosMgr.Save(oAsociado.AsociadoID, oAsociado)

        Me.Cursor = Cursors.Default

        oAsociado.AsociadoID = myID

        If oAsociado.IsNew Then

            ebUsuario.Text = oAsociado.Usuario
            ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")

            MsgBox("Asociado " & Format(myID, "000000") & " se guardó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

        Else

            ebUsuario.Text = oAsociado.Usuario
            ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")
            MsgBox("Asociado " & Format(myID, "000000") & " se actualizó satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Asociado")

        End If

        oAsociado.ResetFlagNew()

        ebCodigoAsociado.Focus()



    End Sub

    Private Sub chkMayoreo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMayoreo.CheckedChanged

        If chkMayoreo.Checked = True Then

            btnVerDatosMayoreo.Enabled = True

        Else

            btnVerDatosMayoreo.Enabled = False

        End If

    End Sub

    Private Sub chkDTienda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDTienda.CheckedChanged

        If chkDTienda.Checked = True Then

            btnVerDatosDTienda.Enabled = True

        Else

            btnVerDatosDTienda.Enabled = False

        End If

    End Sub

    Private Sub chkDPVale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDPVale.CheckedChanged

        If chkDPVale.Checked = True Then

            btnVerDatosDPVale.Enabled = True

        Else

            btnVerDatosDPVale.Enabled = False

        End If

    End Sub

    Private Sub btnVerDatosDTienda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDatosDTienda.Click

        Dim frmCreditoEnTienda As CreditoDirectoEnTienda

        frmCreditoEnTienda = New CreditoDirectoEnTienda

        frmCreditoEnTienda.ShowDialog()

    End Sub

    Private Sub btnVerDatosDPVale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDatosDPVale.Click

        Dim frmCreditoDPVale As CreditoDPVale

        frmCreditoDPVale = New CreditoDPVale

        frmCreditoDPVale.ShowDialog()

    End Sub

    Private Sub Eliminar()

        If oAsociado.IsNew Then

            MsgBox("No puede eliminar un Asociado que aun no está registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Eliminar Asociado")

        Else

            If oAsociado.ClienteID <> 0 Then

                Dim oMsgResult As MsgBoxResult

                oMsgResult = MsgBox("¿Esta seguro que desea eliminar al Asociado? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "  Eliminar Asociado")

                If oMsgResult = MsgBoxResult.Yes Then

                    Dim myID As Integer = oAsociado.AsociadoID

                    oAsociadosMgr.Delete(myID)

                    MsgBox("Se eliminó el Asociado : " & Format(myID, "000000"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Eliminar Asociado")

                    Nuevo()

                Else

                    ebCodigoAsociado.Focus()

                End If

            Else

                MsgBox("Debe cargar un Asociado para poder eliminarlo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Eliminar Asociado")

            End If

        End If

    End Sub

    Private Sub ebCodigoAsociado_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigoAsociado.ButtonClick

        LoadSearchFormAsociado()
        Me.ebCodigoAsociado.SelectAll()
    End Sub

    Private Sub LoadSearchFormAsociado()

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New AsociadosOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oAsociado.Clear()

            oCliente.Clear()

            oAsociadosMgr.LoadInto(oOpenRecordDlg.Record.Item("AsociadoID"), oAsociado)

            If oAsociado.AsociadoID = 0 Then

                MsgBox("Codigo de Asociado No Existe. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                ebCodigoCliente.Enabled = True

                ebCodigoAsociado.Value = 0

                ebCodigoAsociado.Focus()

            Else

                If oAsociado.ClienteID <> 0 Then

                    oCliente.Clear()

                    oClientesMgr.LoadInto(ebCodigoCliente.Value, oCliente)

                    If Not (oCliente.ClienteID = 0) Then

                        ebCodigoCliente.Enabled = False

                        oAsociado.ClienteID = oCliente.ClienteID

                    End If

                End If

                If Not (oAsociado.Foto Is Nothing) Then

                    Dim oFotoAsociado() As Byte = CType(oAsociado.Foto, Byte())
                    Dim msFotoAsociado As New MemoryStream(oFotoAsociado)

                    pbFotografia.Image = Image.FromStream(msFotoAsociado)

                Else

                    pbFotografia.Image = Nothing

                End If

                ebUsuario.Text = oAsociado.Usuario
                ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")

                oAsociado.Usuario = oAppContext.Security.CurrentUser.Name
                oAsociado.Fecha = Date.Today

                oAsociado.ResetFlagNew()

            End If

        End If

    End Sub

    Private Sub ebCodigoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoCliente.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormClientes()

        ElseIf e.KeyCode = Keys.Enter Then

            BuscarCliente()

        End If

    End Sub

    Private Sub ebCodigoAsociado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoAsociado.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormAsociado()

        End If

    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged

        If chkStatus.Checked Then

            lblStatus.Text = "ACTIVO"
            pbActivo.Visible = True
            pbInactivo.Visible = False
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True

        Else

            lblStatus.Text = "INACTIVO"
            pbActivo.Visible = False
            pbInactivo.Visible = True
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False

        End If

    End Sub

    Private Sub CatalogoAsociadosForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "Special Methods"

    Friend Overloads Sub [ShowDialog](ByVal IDAsociado As Integer)

        If IDAsociado > 0 Then

            LoadFromCliente = True

            InitializeObjects()

            InitializeDataBindings()

            oAsociado.Clear()

            oCliente.Clear()

            pbFotografia.Image = Nothing

            oAsociadosMgr.LoadInto(IDAsociado, oAsociado)

            If oAsociado.AsociadoID = 0 Then

                MsgBox("Codigo de Asociado No Existe. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                ebCodigoAsociado.Value = 0

                ebCodigoAsociado.Focus()

            Else

                If oAsociado.ClienteID <> 0 Then

                    oCliente.Clear()

                    oClientesMgr.LoadInto(oAsociado.ClienteID, oCliente)

                    If Not (oCliente.ClienteID = 0) Then

                        oAsociado.ClienteID = oCliente.ClienteID

                    End If

                End If

                If Not (oAsociado.Foto Is Nothing) Then

                    Dim oFotoAsociado() As Byte = CType(oAsociado.Foto, Byte())
                    Dim msFotoAsociado As New MemoryStream(oFotoAsociado)

                    pbFotografia.Image = Image.FromStream(msFotoAsociado)

                Else

                    pbFotografia.Image = Nothing

                End If

                ebUsuario.Text = oAsociado.Usuario
                ebUsuarioFecha.Text = Format(oAsociado.Fecha, "dd/MM/yyyy")

                oAsociado.Usuario = oAppContext.Security.CurrentUser.Name
                oAsociado.Fecha = Date.Today

                oAsociado.ResetFlagNew()

            End If

        Else

            If ebCodigoAsociado.Value <> 0 Then

                MsgBox("Codigo de Asociado Incorrecto. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Asociados")

                ebCodigoAsociado.Value = 0

                ebCodigoAsociado.Focus()

            End If

        End If

        Me.ShowDialog()

    End Sub

#End Region


    Private Sub ebCodigoAsociado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigoAsociado.Validating

        If ebCodigoAsociado.Value > 0 Then

            If oAsociado.AsociadoID <> ebCodigoAsociado.Value Then

                BuscarAsociado()

            End If

        End If

    End Sub

    Private Sub btnDatosCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosCliente.Click

        If oCliente.ClienteID > 0 Then

            Dim frmCliente As New CatalogoClientesForm

            frmCliente.ShowMeforAsociado(ebCodigoCliente.Value)

            If frmCliente.DialogResult = DialogResult.OK Then

                oCliente.Clear()

                oClientesMgr.LoadInto(ebCodigoCliente.Value, oCliente)

            End If

            frmCliente.Dispose()

            frmCliente = Nothing

        End If

    End Sub

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub
End Class
