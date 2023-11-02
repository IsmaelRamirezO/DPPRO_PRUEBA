Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports System.Reflection


Public Class FrmConfigCierreSAP

    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturasMgr = New FacturaManager(oAppContext, oConfigCierreFI)
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
    Friend WithEvents btnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSave As Janus.Windows.EditControls.UIButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UITab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkHuellas As System.Windows.Forms.CheckBox
    Friend WithEvents cbServerHuellas As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserHuellas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbHuellas As System.Windows.Forms.PictureBox
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosHuellas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordHuellas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbServerFirmas As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserFirma As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbFirmas As System.Windows.Forms.PictureBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBDFirmas As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ebPassFirma As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PicBxFotos As System.Windows.Forms.PictureBox
    Friend WithEvents UBtnFotos As Janus.Windows.EditControls.UIButton
    Friend WithEvents EdUnidadImg As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EdrutaImg As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EdPassImg As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EdusuarioImg As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicBxFI As System.Windows.Forms.PictureBox
    Friend WithEvents UBtnFi As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebUnidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EbRuta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbServerEhub As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserEhub As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnProbarEhub As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosEhub As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPassEhub As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbEhub As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabPage3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ebServidorSMTP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCuentaCorreo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddMailAud As Janus.Windows.EditControls.UIButton
    Friend WithEvents lstMailsAud As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ebMailAud As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lstMailsUPC As System.Windows.Forms.ListBox
    Friend WithEvents btnAddMailUPC As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMailUPC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbServerSeparaciones As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserSeparaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbSeparaciones As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarSeparaciones As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosSeparaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPwdSeparaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiTabPage4 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerEmails As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserEmails As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbEmails As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarEmails As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosEmails As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordEmails As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ebCorreoActivacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents chkGuardarServer As System.Windows.Forms.CheckBox
    Friend WithEvents chkHuellaOpcional As System.Windows.Forms.CheckBox
    Friend WithEvents chkRegistroPGOpcional As System.Windows.Forms.CheckBox
    Friend WithEvents chkRegistroExpress As System.Windows.Forms.CheckBox
    Friend WithEvents ebDirValidaEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ebDirImagenesEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents UiTabPage5 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMailsErroresCDist As System.Windows.Forms.ListBox
    Friend WithEvents btnMailErrorCDist As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMailErrorCDist As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbServerTraspasos As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserTraspasos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbTraspasos As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarTraspasos As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosTraspasos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPassTraspasos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkRecibirPorBulto As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecibirParcial As System.Windows.Forms.CheckBox
    Friend WithEvents UiTabPage6 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents nebTiempoPedidos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents uIGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents nebMaximoEC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents nebMinimoEC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chkSurtirEC As System.Windows.Forms.CheckBox
    Friend WithEvents chkBloquearPro As System.Windows.Forms.CheckBox
    Friend WithEvents nebDiasBloqueo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel48 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents ebNoCuentaDHL As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCLABEDHL As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebExtensionDHL As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLabel41 As System.Windows.Forms.Label
    Friend WithEvents nebTiempoDescargasNoche As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ebRutaActualizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents nebImporteMaxTarjeta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblImporteMaximoTarjeta As System.Windows.Forms.Label
    Friend WithEvents ccFechaAutoF As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents nebDiasSurtir As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasFacturar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasFacturarConcen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasEnviarEC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents nebTSPorDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chkSoloMismaPlaza As System.Windows.Forms.CheckBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents nebPzasTotalesTS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMailsLogistica As System.Windows.Forms.ListBox
    Friend WithEvents btnAddMailLog As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMailLogistica As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents ebMailGerenteOperaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents ebMailGerentePlaza As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents ebMailGerenteRegional As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents UiTabPage7 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerBroker As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbBroker As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarBroker As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents nebMaxDescApartados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiTabPage8 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents cbDevolverEfectivoSH As System.Windows.Forms.CheckBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents nebDiasPostergarCita As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents nebDiasRecogerReembolso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents nebDiasFacturarSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasRecibirSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasSinGuiaSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasSurtirSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasInsurtiblesSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebDiasCancelarSH As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents txtLimiteDescuentoEmpleado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents grpGroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEtiquetaDP As System.Windows.Forms.CheckBox
    Friend WithEvents chkEtiquetaFactory As System.Windows.Forms.CheckBox
    Friend WithEvents UiTabPage9 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpBx As System.Windows.Forms.GroupBox
    Friend WithEvents cbMotivosRechazoDPVale As System.Windows.Forms.CheckBox
    Friend WithEvents chkNuevaRegla20y30 As System.Windows.Forms.CheckBox
    Friend WithEvents cbCuponDescuentos As System.Windows.Forms.CheckBox
    Friend WithEvents cbPromocionEmpleado As System.Windows.Forms.CheckBox
    Friend WithEvents chkMiniprinterTermica As System.Windows.Forms.CheckBox
    Friend WithEvents chkDescargaClientes As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompreAhoraPDOpcional As System.Windows.Forms.CheckBox
    Friend WithEvents chkBorrarPreciosCierre As System.Windows.Forms.CheckBox
    Friend WithEvents chkNewDosPorUnoYMedio As System.Windows.Forms.CheckBox
    Friend WithEvents chkEtiquetasLaser As System.Windows.Forms.CheckBox
    Friend WithEvents chkDIPNewDescuento As System.Windows.Forms.CheckBox
    Friend WithEvents chkManagerPC As System.Windows.Forms.CheckBox
    Friend WithEvents chkSMS As System.Windows.Forms.CheckBox
    Friend WithEvents chkTPV As System.Windows.Forms.CheckBox
    Friend WithEvents chkSccanerIFE As System.Windows.Forms.CheckBox
    Friend WithEvents chkValidacionFS As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCedula As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBxImpresoraHP As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxMiniPrinter As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxCargaInicial As System.Windows.Forms.CheckBox
    Friend WithEvents cbScoreBoard As System.Windows.Forms.CheckBox
    Friend WithEvents ebImpresoraETIF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents chkModuloTraspasoFisico As System.Windows.Forms.CheckBox
    Friend WithEvents cbEtiquetasTallas As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents nebPuertoBroker As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents ebServerBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents chkEmparejaMayorPrecio2x1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents chkTraspasoEntradaLectora As System.Windows.Forms.CheckBox
    Friend WithEvents ebNombreArchivoLectoraTE As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombreLectoraTE As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkAuditoriaLectoraCS3070 As System.Windows.Forms.CheckBox
    Friend WithEvents nebImporteMaximoDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents chkDPKTPrioridadUso As System.Windows.Forms.CheckBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents ebDPKTCodUso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkPedirCelEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerarReReVale As System.Windows.Forms.CheckBox
    Friend WithEvents ebNotaOPEC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents chkRecibirOtrosPagos As System.Windows.Forms.CheckBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents nebDiasRecibirPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbSiHayDPVale As System.Windows.Forms.CheckBox
    Friend WithEvents chkAplicaCS As System.Windows.Forms.CheckBox
    Friend WithEvents chkMostrarConcenAuditoria As System.Windows.Forms.CheckBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents ebClienteEC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMailsEC As System.Windows.Forms.ListBox
    Friend WithEvents btnAddMailEC As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebMailEC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents gpCierreDia As System.Windows.Forms.GroupBox
    Friend WithEvents cbValidarCierreDia As System.Windows.Forms.CheckBox
    Friend WithEvents lstCierreDia As System.Windows.Forms.ListBox
    Friend WithEvents btnCierreDia As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCuentaCierreDia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCuentaCierreDia As System.Windows.Forms.Label
    Friend WithEvents chkDPCard As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents nebMaxElectronicosVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiTabPage10 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents ebConsecutivoPOS As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerDPCard As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbDPCard As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents pbDPValeTODO As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarDPValeTODO As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosDPValeTODO As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPasswordDPValeTODO As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbServerDPValeTODO As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserDPValeTODO As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerDPVF As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserDPVF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents pbDPVF As System.Windows.Forms.PictureBox
    Friend WithEvents btnProbarDPVF As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosDPVF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordDPVF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents gboxLeyendaNotaVenta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblDpstreet As System.Windows.Forms.Label
    Friend WithEvents lblDportenis As System.Windows.Forms.Label
    Friend WithEvents txtDportenis As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDPStreet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbSurtidoDPStreet As System.Windows.Forms.CheckBox
    Friend WithEvents chkCancelarPagosDPCard As System.Windows.Forms.CheckBox
    Friend WithEvents lblIDTienda As System.Windows.Forms.Label
    Friend WithEvents txtIDTienda As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbDPCardPuntos As System.Windows.Forms.CheckBox
    Friend WithEvents cbMqttPOS As System.Windows.Forms.CheckBox
    Friend WithEvents nebPuertoBrokerNew As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents ebServerBrokerNew As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents cbBloqueoArticulosBajaCalidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecepcionMercanciaTndas As System.Windows.Forms.CheckBox
    Friend WithEvents cbVentaAsistida As System.Windows.Forms.CheckBox
    Friend WithEvents chkValidaDatosDPVL As System.Windows.Forms.CheckBox
    Friend WithEvents cbAjusteAutomaticos As System.Windows.Forms.CheckBox
    Friend WithEvents cbTraspasoEntradaSiHay As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents ebPassFtpBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents ebUserFTPBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents ebFTPBroker As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents nebPuertoREST As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents ebServidorREST As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents UiTabPage11 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents txtRutaProperties As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblRutaProperties As System.Windows.Forms.Label
    Friend WithEvents UiTabPage12 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage13 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents txtOrganizacionCompra As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblOrganizacionCompra As System.Windows.Forms.Label
    Friend WithEvents txtSector As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents txtCanalDistribucion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCanalDistribucion As System.Windows.Forms.Label
    Friend WithEvents chkTPVVirtual As System.Windows.Forms.CheckBox
    Friend WithEvents txtServidorFTPCierre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFtpCierre As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioFTPServer As System.Windows.Forms.Label
    Friend WithEvents lblPasswordFTPCierre As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioFTPCierre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPasswordFTPCierre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDescuentoDips As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoFijoNoCatalogo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbletiqueta As System.Windows.Forms.Label
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGeneraGuiaDHLAutomatica As System.Windows.Forms.CheckBox
    Friend WithEvents txtRutaImagenes As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblRutaImagenes As System.Windows.Forms.Label
    Friend WithEvents ebURLImagenFondo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents ebPassProxy As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents ebUserProxy As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents ebInternetServer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents ebLimiteTiempoLentitud As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents chkGenerarLogTransacciones As System.Windows.Forms.CheckBox
    Friend WithEvents lstMailsLentitud As System.Windows.Forms.ListBox
    Friend WithEvents btnAddMailTimeout As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCorreoTimeout As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkEnviarCorreoLentitud As System.Windows.Forms.CheckBox
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebPaginaDpstreet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPaginaDportenis As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents txtPublicoGeneral As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblClientePublicoGeneral As System.Windows.Forms.Label
    Friend WithEvents lblConsecutivoPuntos As System.Windows.Forms.Label
    Friend WithEvents txtConsecutivoPuntos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents chkAplicaParaleloS2CSAP As System.Windows.Forms.CheckBox
    Friend WithEvents chkAplicaS2Credit As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbDPVLSeguroValidacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerarSeguro As System.Windows.Forms.CheckBox
    Friend WithEvents lblDiasVencimiento As System.Windows.Forms.Label
    Friend WithEvents txtDiasModificarBenef As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbEvitarInicioDia As System.Windows.Forms.CheckBox
    Friend WithEvents UiTabPage14 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents cbPagoBanamex As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserBanamex As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPasswordBanamex As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPasswordBanamex As System.Windows.Forms.Label
    Friend WithEvents lblUserBanamex As System.Windows.Forms.Label
    Friend WithEvents chkArticuloCatalogoSH As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodosArticulosSH As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRegistroApprova As System.Windows.Forms.CheckBox
    Friend WithEvents txtUrlRegistro As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents chkFacturacionNueva As System.Windows.Forms.CheckBox
    Friend WithEvents cbHabilitarDPTicket As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPuertoS2Credit As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPuertoS2Credit As System.Windows.Forms.Label
    Friend WithEvents txtServidorS2Credit As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblServidorS2Credit As System.Windows.Forms.Label
    Friend WithEvents txtDiaQuincena As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDiasxQuincena As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents nebTimeFreeRAM As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chkFreeRAM As System.Windows.Forms.CheckBox
    Friend WithEvents chkVentaFactFiscal As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents txtComisionBancoToka As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblComisionBancoToka As System.Windows.Forms.Label
    Friend WithEvents chActivarToka As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCanje As System.Windows.Forms.CheckBox
    Friend WithEvents txtTransacCan As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents txtCanje As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBonifica As System.Windows.Forms.CheckBox
    Friend WithEvents txtTransacBoni As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents txtBonificacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPuertoSMTP As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPuertoSMTP As System.Windows.Forms.Label
    Friend WithEvents txtPasswordCorreo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPasswordCorreo As System.Windows.Forms.Label
    Friend WithEvents grpConsignacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtReintentoConsignacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblReintentos As System.Windows.Forms.Label
    Friend WithEvents txtIntervaloConsignacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTiempoIntervalo As System.Windows.Forms.Label
    Friend WithEvents cbPedidoCompra As System.Windows.Forms.CheckBox
    Friend WithEvents UiTabPage15 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUsuarioFinanciero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnTestDTodo As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtBaseFinanciero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblBaseFinanciero As System.Windows.Forms.Label
    Friend WithEvents txtPasswordFinanciero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPasswordFinanciero As System.Windows.Forms.Label
    Friend WithEvents lblServidorFinanciero As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioFinanciero As System.Windows.Forms.Label
    Friend WithEvents imgFinanciero As System.Windows.Forms.PictureBox
    Friend WithEvents txtServidorFinanciero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiTabPage16 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordDatosEcomm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtUserDatosEcomm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtBDDatosEcomm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtServerDatosEcomm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnPagoEcomm As Janus.Windows.EditControls.UIButton
    Friend WithEvents imgDBEcomm As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
    Friend WithEvents txtServicioEcomm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents cbMigracionFinanciero As System.Windows.Forms.CheckBox
    Friend WithEvents lblmpresoraEcomm As System.Windows.Forms.Label
    Friend WithEvents txtImpresoraEcommerce As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkHTTPS As System.Windows.Forms.CheckBox
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents ebServidorHTTPS As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents rdbtn_Blue As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtn_Karum As System.Windows.Forms.RadioButton
    Friend WithEvents uiAlmaecenamientoDatos As Janus.Windows.UI.Tab.UITab
    Friend WithEvents uitSqlServer As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServerBlue As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebUserBlue As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnProbarBlue As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebBaseDatosBlue As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents ebPasswordBlue As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents pbBlue As System.Windows.Forms.PictureBox
    Friend WithEvents uitNetezza As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents ebBaseNet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents ebServidorNet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents ebUsuarioNet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPuertoNet As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents ebPassNet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents txt_usr_token_wsBlue As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents nebPuertoLealtad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebServerLealtad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkValidarMatExt As System.Windows.Forms.CheckBox
    Friend WithEvents chkEjecutarLiveUpdateInicio As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigCierreSAP))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancel = New Janus.Windows.EditControls.UIButton()
        Me.btnSave = New Janus.Windows.EditControls.UIButton()
        Me.UITab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cmbServerSeparaciones = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserSeparaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.pbSeparaciones = New System.Windows.Forms.PictureBox()
        Me.btnProbarSeparaciones = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosSeparaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ebPwdSeparaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmbServerEhub = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserEhub = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.pbEhub = New System.Windows.Forms.PictureBox()
        Me.btnProbarEhub = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosEhub = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebPassEhub = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkHuellas = New System.Windows.Forms.CheckBox()
        Me.cbServerHuellas = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserHuellas = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.pbHuellas = New System.Windows.Forms.PictureBox()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosHuellas = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ebPasswordHuellas = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbServerFirmas = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserFirma = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.pbFirmas = New System.Windows.Forms.PictureBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.ebBDFirmas = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ebPassFirma = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UiTabPage4 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.cmbServerDPVF = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserDPVF = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarDPVF = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosDPVF = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.ebPasswordDPVF = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.pbDPVF = New System.Windows.Forms.PictureBox()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.cmbServerDPValeTODO = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserDPValeTODO = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarDPValeTODO = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosDPValeTODO = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.ebPasswordDPValeTODO = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.pbDPValeTODO = New System.Windows.Forms.PictureBox()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.nebMaxElectronicosVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.ebDirImagenesEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.ebDirValidaEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.chkRegistroExpress = New System.Windows.Forms.CheckBox()
        Me.chkRegistroPGOpcional = New System.Windows.Forms.CheckBox()
        Me.chkHuellaOpcional = New System.Windows.Forms.CheckBox()
        Me.chkGuardarServer = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmbServerEmails = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserEmails = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarEmails = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosEmails = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ebPasswordEmails = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.pbEmails = New System.Windows.Forms.PictureBox()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.gpCierreDia = New System.Windows.Forms.GroupBox()
        Me.lstCierreDia = New System.Windows.Forms.ListBox()
        Me.btnCierreDia = New Janus.Windows.EditControls.UIButton()
        Me.txtCuentaCierreDia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCuentaCierreDia = New System.Windows.Forms.Label()
        Me.cbValidarCierreDia = New System.Windows.Forms.CheckBox()
        Me.ebDPKTCodUso = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.nebImporteMaximoDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtLimiteDescuentoEmpleado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.grpGroupBox16 = New System.Windows.Forms.GroupBox()
        Me.chkEtiquetaFactory = New System.Windows.Forms.CheckBox()
        Me.chkEtiquetaDP = New System.Windows.Forms.CheckBox()
        Me.nebMaxDescApartados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.lblLabel41 = New System.Windows.Forms.Label()
        Me.nebTiempoDescargasNoche = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ebRutaActualizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.nebImporteMaxTarjeta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblImporteMaximoTarjeta = New System.Windows.Forms.Label()
        Me.ccFechaAutoF = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PicBxFotos = New System.Windows.Forms.PictureBox()
        Me.UBtnFotos = New Janus.Windows.EditControls.UIButton()
        Me.EdUnidadImg = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EdrutaImg = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EdPassImg = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EdusuarioImg = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicBxFI = New System.Windows.Forms.PictureBox()
        Me.UBtnFi = New Janus.Windows.EditControls.UIButton()
        Me.ebUnidad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EbRuta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiTabPage3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.ebMailGerenteRegional = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.ebMailGerentePlaza = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMailGerenteOperaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.lstMailsLogistica = New System.Windows.Forms.ListBox()
        Me.btnAddMailLog = New Janus.Windows.EditControls.UIButton()
        Me.ebMailLogistica = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.lstMailsUPC = New System.Windows.Forms.ListBox()
        Me.btnAddMailUPC = New Janus.Windows.EditControls.UIButton()
        Me.ebMailUPC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lstMailsAud = New System.Windows.Forms.ListBox()
        Me.btnAddMailAud = New Janus.Windows.EditControls.UIButton()
        Me.ebMailAud = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtPasswordCorreo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPasswordCorreo = New System.Windows.Forms.Label()
        Me.txtPuertoSMTP = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPuertoSMTP = New System.Windows.Forms.Label()
        Me.ebCorreoActivacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.ebServidorSMTP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCuentaCorreo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.UiTabPage5 = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpConsignacion = New System.Windows.Forms.GroupBox()
        Me.txtReintentoConsignacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblReintentos = New System.Windows.Forms.Label()
        Me.txtIntervaloConsignacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTiempoIntervalo = New System.Windows.Forms.Label()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.ebNombreArchivoLectoraTE = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.ebNombreLectoraTE = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.chkTraspasoEntradaLectora = New System.Windows.Forms.CheckBox()
        Me.ebImpresoraETIF = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.chkModuloTraspasoFisico = New System.Windows.Forms.CheckBox()
        Me.nebDiasBloqueo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.nebTSPorDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.chkSoloMismaPlaza = New System.Windows.Forms.CheckBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.nebPzasTotalesTS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebExtensionDHL = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.ebCLABEDHL = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.ebNoCuentaDHL = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lblLabel48 = New System.Windows.Forms.Label()
        Me.chkBloquearPro = New System.Windows.Forms.CheckBox()
        Me.chkRecibirParcial = New System.Windows.Forms.CheckBox()
        Me.chkRecibirPorBulto = New System.Windows.Forms.CheckBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.cmbServerTraspasos = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserTraspasos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarTraspasos = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosTraspasos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.ebPassTraspasos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.pbTraspasos = New System.Windows.Forms.PictureBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.lstMailsErroresCDist = New System.Windows.Forms.ListBox()
        Me.btnMailErrorCDist = New Janus.Windows.EditControls.UIButton()
        Me.ebMailErrorCDist = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.UiTabPage6 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebPaginaDpstreet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPaginaDportenis = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.gboxLeyendaNotaVenta = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDPStreet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDportenis = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblDpstreet = New System.Windows.Forms.Label()
        Me.lblDportenis = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.nebDiasRecibirPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.ebNotaOPEC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.nebDiasEnviarEC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.nebDiasFacturarConcen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.nebDiasFacturar = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.nebDiasSurtir = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.chkSurtirEC = New System.Windows.Forms.CheckBox()
        Me.uIGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nebMaximoEC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.nebMinimoEC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.nebTiempoPedidos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.lstMailsEC = New System.Windows.Forms.ListBox()
        Me.btnAddMailEC = New Janus.Windows.EditControls.UIButton()
        Me.ebMailEC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebClienteEC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.UiTabPage7 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.chkHTTPS = New System.Windows.Forms.CheckBox()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.ebServidorHTTPS = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.chkGeneraGuiaDHLAutomatica = New System.Windows.Forms.CheckBox()
        Me.txtRutaImagenes = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblRutaImagenes = New System.Windows.Forms.Label()
        Me.ebURLImagenFondo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.ebPassProxy = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.ebUserProxy = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.ebInternetServer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.ebLimiteTiempoLentitud = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.chkGenerarLogTransacciones = New System.Windows.Forms.CheckBox()
        Me.lstMailsLentitud = New System.Windows.Forms.ListBox()
        Me.btnAddMailTimeout = New Janus.Windows.EditControls.UIButton()
        Me.ebCorreoTimeout = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.chkEnviarCorreoLentitud = New System.Windows.Forms.CheckBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.ebPassFtpBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.ebUserFTPBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.ebFTPBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.nebPuertoREST = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.ebServidorREST = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.nebPuertoBrokerNew = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.ebServerBrokerNew = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.nebPuertoBroker = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.ebServerBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.cmbServerBroker = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarBroker = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.ebPasswordBroker = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.pbBroker = New System.Windows.Forms.PictureBox()
        Me.UiTabPage8 = New Janus.Windows.UI.Tab.UITabPage()
        Me.chkValidarMatExt = New System.Windows.Forms.CheckBox()
        Me.chkTodosArticulosSH = New System.Windows.Forms.CheckBox()
        Me.chkArticuloCatalogoSH = New System.Windows.Forms.CheckBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.nebDiasInsurtiblesSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.nebDiasCancelarSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.nebDiasPostergarCita = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.nebDiasRecogerReembolso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.nebDiasFacturarSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.nebDiasRecibirSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.nebDiasSinGuiaSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.nebDiasSurtirSH = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.cbDevolverEfectivoSH = New System.Windows.Forms.CheckBox()
        Me.UiTabPage10 = New Janus.Windows.UI.Tab.UITabPage()
        Me.uiAlmaecenamientoDatos = New Janus.Windows.UI.Tab.UITab()
        Me.uitSqlServer = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.cmbServerBlue = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserBlue = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarBlue = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosBlue = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.ebPasswordBlue = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Label146 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.pbBlue = New System.Windows.Forms.PictureBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.cmbServerDPCard = New Janus.Windows.EditControls.UIComboBox()
        Me.ebUserDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnProbarDPCard = New Janus.Windows.EditControls.UIButton()
        Me.ebBaseDatosDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.ebPasswordDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.pbDPCard = New System.Windows.Forms.PictureBox()
        Me.uitNetezza = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.chkRegistroApprova = New System.Windows.Forms.CheckBox()
        Me.txtUrlRegistro = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.chkCanje = New System.Windows.Forms.CheckBox()
        Me.txtTransacCan = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.txtCanje = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
        Me.Label156 = New System.Windows.Forms.Label()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.nebPuertoLealtad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebServerLealtad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.txt_usr_token_wsBlue = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.rdbtn_Blue = New System.Windows.Forms.RadioButton()
        Me.rdbtn_Karum = New System.Windows.Forms.RadioButton()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.chkBonifica = New System.Windows.Forms.CheckBox()
        Me.txtTransacBoni = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.txtBonificacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.txtComisionBancoToka = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblComisionBancoToka = New System.Windows.Forms.Label()
        Me.chActivarToka = New System.Windows.Forms.CheckBox()
        Me.lblConsecutivoPuntos = New System.Windows.Forms.Label()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.txtConsecutivoPuntos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebConsecutivoPOS = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtIDTienda = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblIDTienda = New System.Windows.Forms.Label()
        Me.UiTabPage11 = New Janus.Windows.UI.Tab.UITabPage()
        Me.txtRutaProperties = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblRutaProperties = New System.Windows.Forms.Label()
        Me.UiTabPage12 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.txtPuertoS2Credit = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPuertoS2Credit = New System.Windows.Forms.Label()
        Me.txtServidorS2Credit = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblServidorS2Credit = New System.Windows.Forms.Label()
        Me.chkAplicaParaleloS2CSAP = New System.Windows.Forms.CheckBox()
        Me.chkAplicaS2Credit = New System.Windows.Forms.CheckBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDiaQuincena = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDiasxQuincena = New System.Windows.Forms.Label()
        Me.cbDPVLSeguroValidacion = New System.Windows.Forms.CheckBox()
        Me.chkGenerarSeguro = New System.Windows.Forms.CheckBox()
        Me.lblDiasVencimiento = New System.Windows.Forms.Label()
        Me.txtDiasModificarBenef = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiTabPage13 = New Janus.Windows.UI.Tab.UITabPage()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.nebTimeFreeRAM = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.chkFreeRAM = New System.Windows.Forms.CheckBox()
        Me.chkFacturacionNueva = New System.Windows.Forms.CheckBox()
        Me.txtPublicoGeneral = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblClientePublicoGeneral = New System.Windows.Forms.Label()
        Me.lbletiqueta = New System.Windows.Forms.Label()
        Me.txtDescuentoFijoNoCatalogo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDescuentoDips = New System.Windows.Forms.Label()
        Me.txtPasswordFTPCierre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPasswordFTPCierre = New System.Windows.Forms.Label()
        Me.txtUsuarioFTPCierre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblUsuarioFTPServer = New System.Windows.Forms.Label()
        Me.txtServidorFTPCierre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFtpCierre = New System.Windows.Forms.Label()
        Me.txtSector = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.txtCanalDistribucion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCanalDistribucion = New System.Windows.Forms.Label()
        Me.txtOrganizacionCompra = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblOrganizacionCompra = New System.Windows.Forms.Label()
        Me.UiTabPage14 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.txtUserBanamex = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cbPagoBanamex = New System.Windows.Forms.CheckBox()
        Me.txtPasswordBanamex = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPasswordBanamex = New System.Windows.Forms.Label()
        Me.lblUserBanamex = New System.Windows.Forms.Label()
        Me.UiTabPage15 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.cbMigracionFinanciero = New System.Windows.Forms.CheckBox()
        Me.txtServidorFinanciero = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtUsuarioFinanciero = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnTestDTodo = New Janus.Windows.EditControls.UIButton()
        Me.txtBaseFinanciero = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblBaseFinanciero = New System.Windows.Forms.Label()
        Me.txtPasswordFinanciero = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPasswordFinanciero = New System.Windows.Forms.Label()
        Me.lblServidorFinanciero = New System.Windows.Forms.Label()
        Me.lblUsuarioFinanciero = New System.Windows.Forms.Label()
        Me.imgFinanciero = New System.Windows.Forms.PictureBox()
        Me.UiTabPage9 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpBx = New System.Windows.Forms.GroupBox()
        Me.cbPedidoCompra = New System.Windows.Forms.CheckBox()
        Me.chkVentaFactFiscal = New System.Windows.Forms.CheckBox()
        Me.cbHabilitarDPTicket = New System.Windows.Forms.CheckBox()
        Me.cbEvitarInicioDia = New System.Windows.Forms.CheckBox()
        Me.chkTPVVirtual = New System.Windows.Forms.CheckBox()
        Me.chkEjecutarLiveUpdateInicio = New System.Windows.Forms.CheckBox()
        Me.cbTraspasoEntradaSiHay = New System.Windows.Forms.CheckBox()
        Me.cbAjusteAutomaticos = New System.Windows.Forms.CheckBox()
        Me.chkValidaDatosDPVL = New System.Windows.Forms.CheckBox()
        Me.cbVentaAsistida = New System.Windows.Forms.CheckBox()
        Me.chkRecepcionMercanciaTndas = New System.Windows.Forms.CheckBox()
        Me.cbBloqueoArticulosBajaCalidad = New System.Windows.Forms.CheckBox()
        Me.cbMqttPOS = New System.Windows.Forms.CheckBox()
        Me.cbDPCardPuntos = New System.Windows.Forms.CheckBox()
        Me.chkCancelarPagosDPCard = New System.Windows.Forms.CheckBox()
        Me.cbSurtidoDPStreet = New System.Windows.Forms.CheckBox()
        Me.chkDPCard = New System.Windows.Forms.CheckBox()
        Me.chkMostrarConcenAuditoria = New System.Windows.Forms.CheckBox()
        Me.chkAplicaCS = New System.Windows.Forms.CheckBox()
        Me.cbSiHayDPVale = New System.Windows.Forms.CheckBox()
        Me.chkRecibirOtrosPagos = New System.Windows.Forms.CheckBox()
        Me.chkGenerarReReVale = New System.Windows.Forms.CheckBox()
        Me.chkPedirCelEmail = New System.Windows.Forms.CheckBox()
        Me.chkDPKTPrioridadUso = New System.Windows.Forms.CheckBox()
        Me.chkAuditoriaLectoraCS3070 = New System.Windows.Forms.CheckBox()
        Me.chkEmparejaMayorPrecio2x1 = New System.Windows.Forms.CheckBox()
        Me.cbEtiquetasTallas = New System.Windows.Forms.CheckBox()
        Me.cbScoreBoard = New System.Windows.Forms.CheckBox()
        Me.cbMotivosRechazoDPVale = New System.Windows.Forms.CheckBox()
        Me.chkNuevaRegla20y30 = New System.Windows.Forms.CheckBox()
        Me.cbCuponDescuentos = New System.Windows.Forms.CheckBox()
        Me.cbPromocionEmpleado = New System.Windows.Forms.CheckBox()
        Me.chkMiniprinterTermica = New System.Windows.Forms.CheckBox()
        Me.chkDescargaClientes = New System.Windows.Forms.CheckBox()
        Me.chkCompreAhoraPDOpcional = New System.Windows.Forms.CheckBox()
        Me.chkBorrarPreciosCierre = New System.Windows.Forms.CheckBox()
        Me.chkNewDosPorUnoYMedio = New System.Windows.Forms.CheckBox()
        Me.chkEtiquetasLaser = New System.Windows.Forms.CheckBox()
        Me.chkDIPNewDescuento = New System.Windows.Forms.CheckBox()
        Me.chkManagerPC = New System.Windows.Forms.CheckBox()
        Me.chkSMS = New System.Windows.Forms.CheckBox()
        Me.chkTPV = New System.Windows.Forms.CheckBox()
        Me.chkSccanerIFE = New System.Windows.Forms.CheckBox()
        Me.chkValidacionFS = New System.Windows.Forms.CheckBox()
        Me.chkboxCedula = New System.Windows.Forms.CheckBox()
        Me.ChkBxImpresoraHP = New System.Windows.Forms.CheckBox()
        Me.ChckBxMiniPrinter = New System.Windows.Forms.CheckBox()
        Me.ChckBxCargaInicial = New System.Windows.Forms.CheckBox()
        Me.UiTabPage16 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.txtImpresoraEcommerce = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblmpresoraEcomm = New System.Windows.Forms.Label()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.txtServicioEcomm = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.imgDBEcomm = New System.Windows.Forms.PictureBox()
        Me.btnPagoEcomm = New Janus.Windows.EditControls.UIButton()
        Me.txtPasswordDatosEcomm = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtUserDatosEcomm = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtBDDatosEcomm = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtServerDatosEcomm = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label155 = New System.Windows.Forms.Label()
        Me.ebBaseNet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label154 = New System.Windows.Forms.Label()
        Me.ebServidorNet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label153 = New System.Windows.Forms.Label()
        Me.ebUsuarioNet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPuertoNet = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.ebPassNet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.Label150 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UITab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UITab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.pbSeparaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.pbEhub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.pbHuellas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbFirmas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage4.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        CType(Me.pbDPVF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox21.SuspendLayout()
        CType(Me.pbDPValeTODO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.pbEmails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.gpCierreDia.SuspendLayout()
        Me.grpGroupBox16.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicBxFotos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBxFI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage3.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.UiTabPage5.SuspendLayout()
        Me.grpConsignacion.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.pbTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.UiTabPage6.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gboxLeyendaNotaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxLeyendaNotaVenta.SuspendLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uIGroupBox1.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.UiTabPage7.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.pbBroker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage8.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.UiTabPage10.SuspendLayout()
        CType(Me.uiAlmaecenamientoDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uiAlmaecenamientoDatos.SuspendLayout()
        Me.uitSqlServer.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        CType(Me.pbBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox19.SuspendLayout()
        CType(Me.pbDPCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uitNetezza.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox35.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.UiTabPage11.SuspendLayout()
        Me.UiTabPage12.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        Me.UiTabPage13.SuspendLayout()
        Me.UiTabPage14.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.UiTabPage15.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        CType(Me.imgFinanciero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage9.SuspendLayout()
        Me.GrpBx.SuspendLayout()
        Me.UiTabPage16.SuspendLayout()
        Me.GroupBox34.SuspendLayout()
        Me.GroupBox33.SuspendLayout()
        CType(Me.imgDBEcomm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnCancel)
        Me.ExplorerBar1.Controls.Add(Me.btnSave)
        Me.ExplorerBar1.Controls.Add(Me.UITab1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(706, 504)
        Me.ExplorerBar1.TabIndex = 6
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(584, 456)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 32)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "&Salir"
        Me.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(8, 456)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 32)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UITab1
        '
        Me.UITab1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UITab1.FirstTabOffset = 3
        Me.UITab1.Location = New System.Drawing.Point(0, 0)
        Me.UITab1.Name = "UITab1"
        Me.UITab1.Size = New System.Drawing.Size(706, 450)
        Me.UITab1.TabIndex = 7
        Me.UITab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage4, Me.UiTabPage2, Me.UiTabPage3, Me.UiTabPage5, Me.UiTabPage6, Me.UiTabPage7, Me.UiTabPage8, Me.UiTabPage10, Me.UiTabPage11, Me.UiTabPage12, Me.UiTabPage13, Me.UiTabPage14, Me.UiTabPage15, Me.UiTabPage9, Me.UiTabPage16})
        Me.UITab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.GroupBox9)
        Me.UiTabPage1.Controls.Add(Me.GroupBox6)
        Me.UiTabPage1.Controls.Add(Me.GroupBox5)
        Me.UiTabPage1.Controls.Add(Me.GroupBox3)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Bases Datos"
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.cmbServerSeparaciones)
        Me.GroupBox9.Controls.Add(Me.ebUserSeparaciones)
        Me.GroupBox9.Controls.Add(Me.pbSeparaciones)
        Me.GroupBox9.Controls.Add(Me.btnProbarSeparaciones)
        Me.GroupBox9.Controls.Add(Me.ebBaseDatosSeparaciones)
        Me.GroupBox9.Controls.Add(Me.Label26)
        Me.GroupBox9.Controls.Add(Me.ebPwdSeparaciones)
        Me.GroupBox9.Controls.Add(Me.Label27)
        Me.GroupBox9.Controls.Add(Me.Label28)
        Me.GroupBox9.Controls.Add(Me.Label29)
        Me.GroupBox9.Location = New System.Drawing.Point(360, 160)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(336, 168)
        Me.GroupBox9.TabIndex = 33
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Configuración Separaciones"
        '
        'cmbServerSeparaciones
        '
        Me.cmbServerSeparaciones.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerSeparaciones.Name = "cmbServerSeparaciones"
        Me.cmbServerSeparaciones.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerSeparaciones.TabIndex = 12
        Me.cmbServerSeparaciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserSeparaciones
        '
        Me.ebUserSeparaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserSeparaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserSeparaciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserSeparaciones.Location = New System.Drawing.Point(88, 80)
        Me.ebUserSeparaciones.MaxLength = 30
        Me.ebUserSeparaciones.Name = "ebUserSeparaciones"
        Me.ebUserSeparaciones.Size = New System.Drawing.Size(144, 22)
        Me.ebUserSeparaciones.TabIndex = 14
        Me.ebUserSeparaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserSeparaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbSeparaciones
        '
        Me.pbSeparaciones.BackColor = System.Drawing.Color.Transparent
        Me.pbSeparaciones.Location = New System.Drawing.Point(280, 40)
        Me.pbSeparaciones.Name = "pbSeparaciones"
        Me.pbSeparaciones.Size = New System.Drawing.Size(32, 32)
        Me.pbSeparaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSeparaciones.TabIndex = 29
        Me.pbSeparaciones.TabStop = False
        '
        'btnProbarSeparaciones
        '
        Me.btnProbarSeparaciones.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarSeparaciones.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarSeparaciones.Name = "btnProbarSeparaciones"
        Me.btnProbarSeparaciones.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarSeparaciones.TabIndex = 4
        Me.btnProbarSeparaciones.Text = "Probar"
        Me.btnProbarSeparaciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosSeparaciones
        '
        Me.ebBaseDatosSeparaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosSeparaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosSeparaciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosSeparaciones.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosSeparaciones.MaxLength = 50
        Me.ebBaseDatosSeparaciones.Name = "ebBaseDatosSeparaciones"
        Me.ebBaseDatosSeparaciones.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosSeparaciones.TabIndex = 13
        Me.ebBaseDatosSeparaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosSeparaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 56)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 16)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "Base de Datos"
        '
        'ebPwdSeparaciones
        '
        Me.ebPwdSeparaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPwdSeparaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPwdSeparaciones.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPwdSeparaciones.Location = New System.Drawing.Point(88, 104)
        Me.ebPwdSeparaciones.MaxLength = 30
        Me.ebPwdSeparaciones.Name = "ebPwdSeparaciones"
        Me.ebPwdSeparaciones.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPwdSeparaciones.Size = New System.Drawing.Size(144, 22)
        Me.ebPwdSeparaciones.TabIndex = 15
        Me.ebPwdSeparaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPwdSeparaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 104)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 16)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Password"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 16)
        Me.Label28.TabIndex = 24
        Me.Label28.Text = "Servidor"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(45, 16)
        Me.Label29.TabIndex = 25
        Me.Label29.Text = "Usuario"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.cmbServerEhub)
        Me.GroupBox6.Controls.Add(Me.ebUserEhub)
        Me.GroupBox6.Controls.Add(Me.pbEhub)
        Me.GroupBox6.Controls.Add(Me.btnProbarEhub)
        Me.GroupBox6.Controls.Add(Me.ebBaseDatosEhub)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.ebPassEhub)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Location = New System.Drawing.Point(360, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox6.TabIndex = 32
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Configuración EHUB"
        '
        'cmbServerEhub
        '
        Me.cmbServerEhub.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerEhub.Name = "cmbServerEhub"
        Me.cmbServerEhub.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerEhub.TabIndex = 12
        Me.cmbServerEhub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserEhub
        '
        Me.ebUserEhub.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserEhub.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserEhub.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserEhub.Location = New System.Drawing.Point(88, 80)
        Me.ebUserEhub.MaxLength = 30
        Me.ebUserEhub.Name = "ebUserEhub"
        Me.ebUserEhub.Size = New System.Drawing.Size(144, 22)
        Me.ebUserEhub.TabIndex = 14
        Me.ebUserEhub.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserEhub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbEhub
        '
        Me.pbEhub.BackColor = System.Drawing.Color.Transparent
        Me.pbEhub.Location = New System.Drawing.Point(280, 40)
        Me.pbEhub.Name = "pbEhub"
        Me.pbEhub.Size = New System.Drawing.Size(32, 32)
        Me.pbEhub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEhub.TabIndex = 29
        Me.pbEhub.TabStop = False
        '
        'btnProbarEhub
        '
        Me.btnProbarEhub.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarEhub.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarEhub.Name = "btnProbarEhub"
        Me.btnProbarEhub.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarEhub.TabIndex = 4
        Me.btnProbarEhub.Text = "Probar"
        Me.btnProbarEhub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosEhub
        '
        Me.ebBaseDatosEhub.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosEhub.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosEhub.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosEhub.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosEhub.MaxLength = 50
        Me.ebBaseDatosEhub.Name = "ebBaseDatosEhub"
        Me.ebBaseDatosEhub.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosEhub.TabIndex = 13
        Me.ebBaseDatosEhub.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosEhub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 16)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Base de Datos"
        '
        'ebPassEhub
        '
        Me.ebPassEhub.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassEhub.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassEhub.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassEhub.Location = New System.Drawing.Point(88, 104)
        Me.ebPassEhub.MaxLength = 30
        Me.ebPassEhub.Name = "ebPassEhub"
        Me.ebPassEhub.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPassEhub.Size = New System.Drawing.Size(144, 22)
        Me.ebPassEhub.TabIndex = 15
        Me.ebPassEhub.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassEhub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 16)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "Password"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 16)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "Servidor"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 16)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Usuario"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.chkHuellas)
        Me.GroupBox5.Controls.Add(Me.cbServerHuellas)
        Me.GroupBox5.Controls.Add(Me.ebUserHuellas)
        Me.GroupBox5.Controls.Add(Me.pbHuellas)
        Me.GroupBox5.Controls.Add(Me.UiButton2)
        Me.GroupBox5.Controls.Add(Me.ebBaseDatosHuellas)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.ebPasswordHuellas)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 160)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(336, 168)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuración Huellas Digitales"
        '
        'chkHuellas
        '
        Me.chkHuellas.BackColor = System.Drawing.Color.Transparent
        Me.chkHuellas.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHuellas.Location = New System.Drawing.Point(8, 24)
        Me.chkHuellas.Name = "chkHuellas"
        Me.chkHuellas.Size = New System.Drawing.Size(168, 24)
        Me.chkHuellas.TabIndex = 16
        Me.chkHuellas.Text = "Usar Huellas Digitales"
        Me.chkHuellas.UseVisualStyleBackColor = False
        '
        'cbServerHuellas
        '
        Me.cbServerHuellas.Location = New System.Drawing.Point(88, 56)
        Me.cbServerHuellas.Name = "cbServerHuellas"
        Me.cbServerHuellas.Size = New System.Drawing.Size(144, 26)
        Me.cbServerHuellas.TabIndex = 17
        Me.cbServerHuellas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserHuellas
        '
        Me.ebUserHuellas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserHuellas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserHuellas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserHuellas.Location = New System.Drawing.Point(88, 108)
        Me.ebUserHuellas.MaxLength = 30
        Me.ebUserHuellas.Name = "ebUserHuellas"
        Me.ebUserHuellas.Size = New System.Drawing.Size(144, 22)
        Me.ebUserHuellas.TabIndex = 19
        Me.ebUserHuellas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserHuellas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbHuellas
        '
        Me.pbHuellas.BackColor = System.Drawing.Color.Transparent
        Me.pbHuellas.Location = New System.Drawing.Point(280, 64)
        Me.pbHuellas.Name = "pbHuellas"
        Me.pbHuellas.Size = New System.Drawing.Size(32, 32)
        Me.pbHuellas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbHuellas.TabIndex = 29
        Me.pbHuellas.TabStop = False
        '
        'UiButton2
        '
        Me.UiButton2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton2.Location = New System.Drawing.Point(272, 128)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(40, 24)
        Me.UiButton2.TabIndex = 4
        Me.UiButton2.Text = "Probar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosHuellas
        '
        Me.ebBaseDatosHuellas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosHuellas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosHuellas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosHuellas.Location = New System.Drawing.Point(88, 84)
        Me.ebBaseDatosHuellas.MaxLength = 50
        Me.ebBaseDatosHuellas.Name = "ebBaseDatosHuellas"
        Me.ebBaseDatosHuellas.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosHuellas.TabIndex = 18
        Me.ebBaseDatosHuellas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosHuellas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Base de Datos"
        '
        'ebPasswordHuellas
        '
        Me.ebPasswordHuellas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordHuellas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordHuellas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordHuellas.Location = New System.Drawing.Point(88, 132)
        Me.ebPasswordHuellas.MaxLength = 30
        Me.ebPasswordHuellas.Name = "ebPasswordHuellas"
        Me.ebPasswordHuellas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordHuellas.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordHuellas.TabIndex = 20
        Me.ebPasswordHuellas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordHuellas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 16)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Password"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 16)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Servidor"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 108)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 16)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Usuario"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cbServerFirmas)
        Me.GroupBox3.Controls.Add(Me.ebUserFirma)
        Me.GroupBox3.Controls.Add(Me.pbFirmas)
        Me.GroupBox3.Controls.Add(Me.UiButton1)
        Me.GroupBox3.Controls.Add(Me.ebBDFirmas)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ebPassFirma)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Configuración Firmas DPVALE"
        '
        'cbServerFirmas
        '
        Me.cbServerFirmas.Location = New System.Drawing.Point(88, 28)
        Me.cbServerFirmas.Name = "cbServerFirmas"
        Me.cbServerFirmas.Size = New System.Drawing.Size(144, 26)
        Me.cbServerFirmas.TabIndex = 12
        Me.cbServerFirmas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserFirma
        '
        Me.ebUserFirma.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserFirma.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserFirma.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserFirma.Location = New System.Drawing.Point(88, 80)
        Me.ebUserFirma.MaxLength = 30
        Me.ebUserFirma.Name = "ebUserFirma"
        Me.ebUserFirma.Size = New System.Drawing.Size(144, 22)
        Me.ebUserFirma.TabIndex = 14
        Me.ebUserFirma.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserFirma.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbFirmas
        '
        Me.pbFirmas.BackColor = System.Drawing.Color.Transparent
        Me.pbFirmas.Location = New System.Drawing.Point(280, 40)
        Me.pbFirmas.Name = "pbFirmas"
        Me.pbFirmas.Size = New System.Drawing.Size(32, 32)
        Me.pbFirmas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFirmas.TabIndex = 29
        Me.pbFirmas.TabStop = False
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(272, 96)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(40, 24)
        Me.UiButton1.TabIndex = 4
        Me.UiButton1.Text = "Probar"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBDFirmas
        '
        Me.ebBDFirmas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBDFirmas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBDFirmas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBDFirmas.Location = New System.Drawing.Point(88, 56)
        Me.ebBDFirmas.MaxLength = 50
        Me.ebBDFirmas.Name = "ebBDFirmas"
        Me.ebBDFirmas.Size = New System.Drawing.Size(144, 22)
        Me.ebBDFirmas.TabIndex = 13
        Me.ebBDFirmas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBDFirmas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 16)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Base de Datos"
        '
        'ebPassFirma
        '
        Me.ebPassFirma.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassFirma.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassFirma.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassFirma.Location = New System.Drawing.Point(88, 104)
        Me.ebPassFirma.MaxLength = 30
        Me.ebPassFirma.Name = "ebPassFirma"
        Me.ebPassFirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPassFirma.Size = New System.Drawing.Size(144, 22)
        Me.ebPassFirma.TabIndex = 15
        Me.ebPassFirma.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassFirma.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Password"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Servidor"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 16)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Usuario"
        '
        'UiTabPage4
        '
        Me.UiTabPage4.Controls.Add(Me.GroupBox22)
        Me.UiTabPage4.Controls.Add(Me.GroupBox21)
        Me.UiTabPage4.Controls.Add(Me.GroupBox20)
        Me.UiTabPage4.Controls.Add(Me.ebDirImagenesEmail)
        Me.UiTabPage4.Controls.Add(Me.Label39)
        Me.UiTabPage4.Controls.Add(Me.ebDirValidaEmail)
        Me.UiTabPage4.Controls.Add(Me.Label38)
        Me.UiTabPage4.Controls.Add(Me.chkRegistroExpress)
        Me.UiTabPage4.Controls.Add(Me.chkRegistroPGOpcional)
        Me.UiTabPage4.Controls.Add(Me.chkHuellaOpcional)
        Me.UiTabPage4.Controls.Add(Me.chkGuardarServer)
        Me.UiTabPage4.Controls.Add(Me.GroupBox10)
        Me.UiTabPage4.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage4.Name = "UiTabPage4"
        Me.UiTabPage4.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage4.TabStop = True
        Me.UiTabPage4.Text = "CRM"
        '
        'GroupBox22
        '
        Me.GroupBox22.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox22.Controls.Add(Me.cmbServerDPVF)
        Me.GroupBox22.Controls.Add(Me.ebUserDPVF)
        Me.GroupBox22.Controls.Add(Me.btnProbarDPVF)
        Me.GroupBox22.Controls.Add(Me.ebBaseDatosDPVF)
        Me.GroupBox22.Controls.Add(Me.Label116)
        Me.GroupBox22.Controls.Add(Me.ebPasswordDPVF)
        Me.GroupBox22.Controls.Add(Me.Label117)
        Me.GroupBox22.Controls.Add(Me.Label118)
        Me.GroupBox22.Controls.Add(Me.Label119)
        Me.GroupBox22.Controls.Add(Me.pbDPVF)
        Me.GroupBox22.Location = New System.Drawing.Point(360, 152)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox22.TabIndex = 45
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Configuración DPVale Financiero"
        '
        'cmbServerDPVF
        '
        Me.cmbServerDPVF.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerDPVF.Name = "cmbServerDPVF"
        Me.cmbServerDPVF.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerDPVF.TabIndex = 12
        Me.cmbServerDPVF.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserDPVF
        '
        Me.ebUserDPVF.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserDPVF.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserDPVF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserDPVF.Location = New System.Drawing.Point(88, 80)
        Me.ebUserDPVF.MaxLength = 30
        Me.ebUserDPVF.Name = "ebUserDPVF"
        Me.ebUserDPVF.Size = New System.Drawing.Size(144, 22)
        Me.ebUserDPVF.TabIndex = 14
        Me.ebUserDPVF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserDPVF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarDPVF
        '
        Me.btnProbarDPVF.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarDPVF.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarDPVF.Name = "btnProbarDPVF"
        Me.btnProbarDPVF.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarDPVF.TabIndex = 4
        Me.btnProbarDPVF.Text = "Probar"
        Me.btnProbarDPVF.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosDPVF
        '
        Me.ebBaseDatosDPVF.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPVF.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPVF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosDPVF.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosDPVF.MaxLength = 50
        Me.ebBaseDatosDPVF.Name = "ebBaseDatosDPVF"
        Me.ebBaseDatosDPVF.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosDPVF.TabIndex = 13
        Me.ebBaseDatosDPVF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosDPVF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label116.Location = New System.Drawing.Point(8, 56)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(77, 16)
        Me.Label116.TabIndex = 27
        Me.Label116.Text = "Base de Datos"
        '
        'ebPasswordDPVF
        '
        Me.ebPasswordDPVF.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPVF.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPVF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordDPVF.Location = New System.Drawing.Point(88, 104)
        Me.ebPasswordDPVF.MaxLength = 30
        Me.ebPasswordDPVF.Name = "ebPasswordDPVF"
        Me.ebPasswordDPVF.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordDPVF.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordDPVF.TabIndex = 15
        Me.ebPasswordDPVF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordDPVF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.BackColor = System.Drawing.Color.Transparent
        Me.Label117.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.Location = New System.Drawing.Point(8, 104)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(55, 16)
        Me.Label117.TabIndex = 26
        Me.Label117.Text = "Password"
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.BackColor = System.Drawing.Color.Transparent
        Me.Label118.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.Location = New System.Drawing.Point(8, 32)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(49, 16)
        Me.Label118.TabIndex = 24
        Me.Label118.Text = "Servidor"
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.BackColor = System.Drawing.Color.Transparent
        Me.Label119.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.Location = New System.Drawing.Point(8, 80)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(45, 16)
        Me.Label119.TabIndex = 25
        Me.Label119.Text = "Usuario"
        '
        'pbDPVF
        '
        Me.pbDPVF.BackColor = System.Drawing.Color.Transparent
        Me.pbDPVF.Location = New System.Drawing.Point(280, 40)
        Me.pbDPVF.Name = "pbDPVF"
        Me.pbDPVF.Size = New System.Drawing.Size(32, 32)
        Me.pbDPVF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDPVF.TabIndex = 29
        Me.pbDPVF.TabStop = False
        '
        'GroupBox21
        '
        Me.GroupBox21.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox21.Controls.Add(Me.cmbServerDPValeTODO)
        Me.GroupBox21.Controls.Add(Me.ebUserDPValeTODO)
        Me.GroupBox21.Controls.Add(Me.btnProbarDPValeTODO)
        Me.GroupBox21.Controls.Add(Me.ebBaseDatosDPValeTODO)
        Me.GroupBox21.Controls.Add(Me.Label112)
        Me.GroupBox21.Controls.Add(Me.ebPasswordDPValeTODO)
        Me.GroupBox21.Controls.Add(Me.Label113)
        Me.GroupBox21.Controls.Add(Me.Label114)
        Me.GroupBox21.Controls.Add(Me.Label115)
        Me.GroupBox21.Controls.Add(Me.pbDPValeTODO)
        Me.GroupBox21.Location = New System.Drawing.Point(360, 8)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox21.TabIndex = 44
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Configuración DPVale Todo"
        '
        'cmbServerDPValeTODO
        '
        Me.cmbServerDPValeTODO.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerDPValeTODO.Name = "cmbServerDPValeTODO"
        Me.cmbServerDPValeTODO.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerDPValeTODO.TabIndex = 12
        Me.cmbServerDPValeTODO.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserDPValeTODO
        '
        Me.ebUserDPValeTODO.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserDPValeTODO.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserDPValeTODO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserDPValeTODO.Location = New System.Drawing.Point(88, 80)
        Me.ebUserDPValeTODO.MaxLength = 30
        Me.ebUserDPValeTODO.Name = "ebUserDPValeTODO"
        Me.ebUserDPValeTODO.Size = New System.Drawing.Size(144, 22)
        Me.ebUserDPValeTODO.TabIndex = 14
        Me.ebUserDPValeTODO.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserDPValeTODO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarDPValeTODO
        '
        Me.btnProbarDPValeTODO.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarDPValeTODO.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarDPValeTODO.Name = "btnProbarDPValeTODO"
        Me.btnProbarDPValeTODO.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarDPValeTODO.TabIndex = 4
        Me.btnProbarDPValeTODO.Text = "Probar"
        Me.btnProbarDPValeTODO.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosDPValeTODO
        '
        Me.ebBaseDatosDPValeTODO.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPValeTODO.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPValeTODO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosDPValeTODO.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosDPValeTODO.MaxLength = 50
        Me.ebBaseDatosDPValeTODO.Name = "ebBaseDatosDPValeTODO"
        Me.ebBaseDatosDPValeTODO.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosDPValeTODO.TabIndex = 13
        Me.ebBaseDatosDPValeTODO.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosDPValeTODO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.Location = New System.Drawing.Point(8, 56)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(77, 16)
        Me.Label112.TabIndex = 27
        Me.Label112.Text = "Base de Datos"
        '
        'ebPasswordDPValeTODO
        '
        Me.ebPasswordDPValeTODO.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPValeTODO.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPValeTODO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordDPValeTODO.Location = New System.Drawing.Point(88, 104)
        Me.ebPasswordDPValeTODO.MaxLength = 30
        Me.ebPasswordDPValeTODO.Name = "ebPasswordDPValeTODO"
        Me.ebPasswordDPValeTODO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordDPValeTODO.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordDPValeTODO.TabIndex = 15
        Me.ebPasswordDPValeTODO.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordDPValeTODO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.Location = New System.Drawing.Point(8, 104)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(55, 16)
        Me.Label113.TabIndex = 26
        Me.Label113.Text = "Password"
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.BackColor = System.Drawing.Color.Transparent
        Me.Label114.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.Location = New System.Drawing.Point(8, 32)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(49, 16)
        Me.Label114.TabIndex = 24
        Me.Label114.Text = "Servidor"
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.BackColor = System.Drawing.Color.Transparent
        Me.Label115.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label115.Location = New System.Drawing.Point(8, 80)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(45, 16)
        Me.Label115.TabIndex = 25
        Me.Label115.Text = "Usuario"
        '
        'pbDPValeTODO
        '
        Me.pbDPValeTODO.BackColor = System.Drawing.Color.Transparent
        Me.pbDPValeTODO.Location = New System.Drawing.Point(280, 40)
        Me.pbDPValeTODO.Name = "pbDPValeTODO"
        Me.pbDPValeTODO.Size = New System.Drawing.Size(32, 32)
        Me.pbDPValeTODO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDPValeTODO.TabIndex = 29
        Me.pbDPValeTODO.TabStop = False
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox20.Controls.Add(Me.nebMaxElectronicosVale)
        Me.GroupBox20.Controls.Add(Me.Label107)
        Me.GroupBox20.Location = New System.Drawing.Point(8, 152)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(336, 56)
        Me.GroupBox20.TabIndex = 43
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Electronicos DPVale"
        '
        'nebMaxElectronicosVale
        '
        Me.nebMaxElectronicosVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebMaxElectronicosVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebMaxElectronicosVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebMaxElectronicosVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebMaxElectronicosVale.Location = New System.Drawing.Point(184, 24)
        Me.nebMaxElectronicosVale.Name = "nebMaxElectronicosVale"
        Me.nebMaxElectronicosVale.Size = New System.Drawing.Size(88, 22)
        Me.nebMaxElectronicosVale.TabIndex = 67
        Me.nebMaxElectronicosVale.Text = "$0.00"
        Me.nebMaxElectronicosVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebMaxElectronicosVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.Location = New System.Drawing.Point(8, 24)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(122, 16)
        Me.Label107.TabIndex = 25
        Me.Label107.Text = "Importe Máximo DPVale"
        '
        'ebDirImagenesEmail
        '
        Me.ebDirImagenesEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDirImagenesEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDirImagenesEmail.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDirImagenesEmail.Location = New System.Drawing.Point(152, 378)
        Me.ebDirImagenesEmail.MaxLength = 0
        Me.ebDirImagenesEmail.Name = "ebDirImagenesEmail"
        Me.ebDirImagenesEmail.Size = New System.Drawing.Size(536, 22)
        Me.ebDirImagenesEmail.TabIndex = 40
        Me.ebDirImagenesEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirImagenesEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(16, 378)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(129, 16)
        Me.Label39.TabIndex = 41
        Me.Label39.Text = "Dirección Imagenes Email"
        '
        'ebDirValidaEmail
        '
        Me.ebDirValidaEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDirValidaEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDirValidaEmail.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDirValidaEmail.Location = New System.Drawing.Point(152, 352)
        Me.ebDirValidaEmail.MaxLength = 0
        Me.ebDirValidaEmail.Name = "ebDirValidaEmail"
        Me.ebDirValidaEmail.Size = New System.Drawing.Size(536, 22)
        Me.ebDirValidaEmail.TabIndex = 38
        Me.ebDirValidaEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirValidaEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(16, 352)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(112, 16)
        Me.Label38.TabIndex = 39
        Me.Label38.Text = "Dirección Valida Email"
        '
        'chkRegistroExpress
        '
        Me.chkRegistroExpress.BackColor = System.Drawing.Color.Transparent
        Me.chkRegistroExpress.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRegistroExpress.Location = New System.Drawing.Point(16, 288)
        Me.chkRegistroExpress.Name = "chkRegistroExpress"
        Me.chkRegistroExpress.Size = New System.Drawing.Size(209, 24)
        Me.chkRegistroExpress.TabIndex = 37
        Me.chkRegistroExpress.Text = "Registro PG Express"
        Me.chkRegistroExpress.UseVisualStyleBackColor = False
        '
        'chkRegistroPGOpcional
        '
        Me.chkRegistroPGOpcional.BackColor = System.Drawing.Color.Transparent
        Me.chkRegistroPGOpcional.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRegistroPGOpcional.Location = New System.Drawing.Point(16, 264)
        Me.chkRegistroPGOpcional.Name = "chkRegistroPGOpcional"
        Me.chkRegistroPGOpcional.Size = New System.Drawing.Size(209, 24)
        Me.chkRegistroPGOpcional.TabIndex = 36
        Me.chkRegistroPGOpcional.Text = "Registro de Clientes PG Opcional"
        Me.chkRegistroPGOpcional.UseVisualStyleBackColor = False
        '
        'chkHuellaOpcional
        '
        Me.chkHuellaOpcional.BackColor = System.Drawing.Color.Transparent
        Me.chkHuellaOpcional.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHuellaOpcional.Location = New System.Drawing.Point(16, 240)
        Me.chkHuellaOpcional.Name = "chkHuellaOpcional"
        Me.chkHuellaOpcional.Size = New System.Drawing.Size(152, 24)
        Me.chkHuellaOpcional.TabIndex = 35
        Me.chkHuellaOpcional.Text = "Huella Opcional"
        Me.chkHuellaOpcional.UseVisualStyleBackColor = False
        '
        'chkGuardarServer
        '
        Me.chkGuardarServer.BackColor = System.Drawing.Color.Transparent
        Me.chkGuardarServer.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGuardarServer.Location = New System.Drawing.Point(16, 216)
        Me.chkGuardarServer.Name = "chkGuardarServer"
        Me.chkGuardarServer.Size = New System.Drawing.Size(157, 24)
        Me.chkGuardarServer.TabIndex = 34
        Me.chkGuardarServer.Text = "Guardar En Servidor"
        Me.chkGuardarServer.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.cmbServerEmails)
        Me.GroupBox10.Controls.Add(Me.ebUserEmails)
        Me.GroupBox10.Controls.Add(Me.btnProbarEmails)
        Me.GroupBox10.Controls.Add(Me.ebBaseDatosEmails)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Controls.Add(Me.ebPasswordEmails)
        Me.GroupBox10.Controls.Add(Me.Label34)
        Me.GroupBox10.Controls.Add(Me.Label35)
        Me.GroupBox10.Controls.Add(Me.Label36)
        Me.GroupBox10.Controls.Add(Me.pbEmails)
        Me.GroupBox10.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox10.TabIndex = 33
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Configuración Emails Clientes"
        '
        'cmbServerEmails
        '
        Me.cmbServerEmails.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerEmails.Name = "cmbServerEmails"
        Me.cmbServerEmails.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerEmails.TabIndex = 12
        Me.cmbServerEmails.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserEmails
        '
        Me.ebUserEmails.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserEmails.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserEmails.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserEmails.Location = New System.Drawing.Point(88, 80)
        Me.ebUserEmails.MaxLength = 30
        Me.ebUserEmails.Name = "ebUserEmails"
        Me.ebUserEmails.Size = New System.Drawing.Size(144, 22)
        Me.ebUserEmails.TabIndex = 14
        Me.ebUserEmails.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserEmails.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarEmails
        '
        Me.btnProbarEmails.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarEmails.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarEmails.Name = "btnProbarEmails"
        Me.btnProbarEmails.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarEmails.TabIndex = 4
        Me.btnProbarEmails.Text = "Probar"
        Me.btnProbarEmails.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosEmails
        '
        Me.ebBaseDatosEmails.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosEmails.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosEmails.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosEmails.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosEmails.MaxLength = 50
        Me.ebBaseDatosEmails.Name = "ebBaseDatosEmails"
        Me.ebBaseDatosEmails.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosEmails.TabIndex = 13
        Me.ebBaseDatosEmails.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosEmails.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(8, 56)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(77, 16)
        Me.Label33.TabIndex = 27
        Me.Label33.Text = "Base de Datos"
        '
        'ebPasswordEmails
        '
        Me.ebPasswordEmails.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordEmails.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordEmails.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordEmails.Location = New System.Drawing.Point(88, 104)
        Me.ebPasswordEmails.MaxLength = 30
        Me.ebPasswordEmails.Name = "ebPasswordEmails"
        Me.ebPasswordEmails.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordEmails.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordEmails.TabIndex = 15
        Me.ebPasswordEmails.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordEmails.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 104)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(55, 16)
        Me.Label34.TabIndex = 26
        Me.Label34.Text = "Password"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(8, 32)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(49, 16)
        Me.Label35.TabIndex = 24
        Me.Label35.Text = "Servidor"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(8, 80)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(45, 16)
        Me.Label36.TabIndex = 25
        Me.Label36.Text = "Usuario"
        '
        'pbEmails
        '
        Me.pbEmails.BackColor = System.Drawing.Color.Transparent
        Me.pbEmails.Location = New System.Drawing.Point(280, 40)
        Me.pbEmails.Name = "pbEmails"
        Me.pbEmails.Size = New System.Drawing.Size(32, 32)
        Me.pbEmails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEmails.TabIndex = 29
        Me.pbEmails.TabStop = False
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.GroupBox13)
        Me.UiTabPage2.Controls.Add(Me.GroupBox2)
        Me.UiTabPage2.Controls.Add(Me.GroupBox1)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "Otras Configuraciones"
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox13.Controls.Add(Me.gpCierreDia)
        Me.GroupBox13.Controls.Add(Me.ebDPKTCodUso)
        Me.GroupBox13.Controls.Add(Me.Label100)
        Me.GroupBox13.Controls.Add(Me.nebImporteMaximoDPVale)
        Me.GroupBox13.Controls.Add(Me.Label99)
        Me.GroupBox13.Controls.Add(Me.txtLimiteDescuentoEmpleado)
        Me.GroupBox13.Controls.Add(Me.Label92)
        Me.GroupBox13.Controls.Add(Me.grpGroupBox16)
        Me.GroupBox13.Controls.Add(Me.nebMaxDescApartados)
        Me.GroupBox13.Controls.Add(Me.Label75)
        Me.GroupBox13.Controls.Add(Me.lblLabel41)
        Me.GroupBox13.Controls.Add(Me.nebTiempoDescargasNoche)
        Me.GroupBox13.Controls.Add(Me.Label40)
        Me.GroupBox13.Controls.Add(Me.ebRutaActualizacion)
        Me.GroupBox13.Controls.Add(Me.Label32)
        Me.GroupBox13.Controls.Add(Me.nebImporteMaxTarjeta)
        Me.GroupBox13.Controls.Add(Me.lblImporteMaximoTarjeta)
        Me.GroupBox13.Controls.Add(Me.ccFechaAutoF)
        Me.GroupBox13.Controls.Add(Me.Label9)
        Me.GroupBox13.Location = New System.Drawing.Point(8, 160)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(688, 256)
        Me.GroupBox13.TabIndex = 30
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Otras Configuraciones"
        '
        'gpCierreDia
        '
        Me.gpCierreDia.BackColor = System.Drawing.Color.Transparent
        Me.gpCierreDia.Controls.Add(Me.lstCierreDia)
        Me.gpCierreDia.Controls.Add(Me.btnCierreDia)
        Me.gpCierreDia.Controls.Add(Me.txtCuentaCierreDia)
        Me.gpCierreDia.Controls.Add(Me.lblCuentaCierreDia)
        Me.gpCierreDia.Controls.Add(Me.cbValidarCierreDia)
        Me.gpCierreDia.Location = New System.Drawing.Point(328, 72)
        Me.gpCierreDia.Name = "gpCierreDia"
        Me.gpCierreDia.Size = New System.Drawing.Size(336, 176)
        Me.gpCierreDia.TabIndex = 80
        Me.gpCierreDia.TabStop = False
        Me.gpCierreDia.Text = "Cierre de dia y año"
        '
        'lstCierreDia
        '
        Me.lstCierreDia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCierreDia.ItemHeight = 20
        Me.lstCierreDia.Location = New System.Drawing.Point(8, 80)
        Me.lstCierreDia.Name = "lstCierreDia"
        Me.lstCierreDia.Size = New System.Drawing.Size(320, 80)
        Me.lstCierreDia.TabIndex = 74
        '
        'btnCierreDia
        '
        Me.btnCierreDia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCierreDia.Location = New System.Drawing.Point(296, 48)
        Me.btnCierreDia.Name = "btnCierreDia"
        Me.btnCierreDia.Size = New System.Drawing.Size(32, 24)
        Me.btnCierreDia.TabIndex = 73
        Me.btnCierreDia.Text = "Add"
        Me.btnCierreDia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtCuentaCierreDia
        '
        Me.txtCuentaCierreDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCuentaCierreDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCuentaCierreDia.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaCierreDia.Location = New System.Drawing.Point(104, 48)
        Me.txtCuentaCierreDia.MaxLength = 100
        Me.txtCuentaCierreDia.Name = "txtCuentaCierreDia"
        Me.txtCuentaCierreDia.Size = New System.Drawing.Size(192, 26)
        Me.txtCuentaCierreDia.TabIndex = 71
        Me.txtCuentaCierreDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCuentaCierreDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCuentaCierreDia
        '
        Me.lblCuentaCierreDia.AutoSize = True
        Me.lblCuentaCierreDia.BackColor = System.Drawing.Color.Transparent
        Me.lblCuentaCierreDia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaCierreDia.Location = New System.Drawing.Point(8, 62)
        Me.lblCuentaCierreDia.Name = "lblCuentaCierreDia"
        Me.lblCuentaCierreDia.Size = New System.Drawing.Size(97, 16)
        Me.lblCuentaCierreDia.TabIndex = 72
        Me.lblCuentaCierreDia.Text = "Cuenta de Correo:"
        '
        'cbValidarCierreDia
        '
        Me.cbValidarCierreDia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValidarCierreDia.Location = New System.Drawing.Point(8, 24)
        Me.cbValidarCierreDia.Name = "cbValidarCierreDia"
        Me.cbValidarCierreDia.Size = New System.Drawing.Size(168, 24)
        Me.cbValidarCierreDia.TabIndex = 70
        Me.cbValidarCierreDia.Text = "Evitar validar cierre de día"
        '
        'ebDPKTCodUso
        '
        Me.ebDPKTCodUso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDPKTCodUso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDPKTCodUso.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDPKTCodUso.Location = New System.Drawing.Point(592, 48)
        Me.ebDPKTCodUso.MaxLength = 30
        Me.ebDPKTCodUso.Name = "ebDPKTCodUso"
        Me.ebDPKTCodUso.Size = New System.Drawing.Size(88, 22)
        Me.ebDPKTCodUso.TabIndex = 79
        Me.ebDPKTCodUso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDPKTCodUso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(392, 48)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(142, 16)
        Me.Label100.TabIndex = 78
        Me.Label100.Text = "Codigo Uso DPKT Prioridad"
        '
        'nebImporteMaximoDPVale
        '
        Me.nebImporteMaximoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebImporteMaximoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebImporteMaximoDPVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebImporteMaximoDPVale.Location = New System.Drawing.Point(592, 16)
        Me.nebImporteMaximoDPVale.Name = "nebImporteMaximoDPVale"
        Me.nebImporteMaximoDPVale.Size = New System.Drawing.Size(88, 26)
        Me.nebImporteMaximoDPVale.TabIndex = 77
        Me.nebImporteMaximoDPVale.Text = "$0.00"
        Me.nebImporteMaximoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebImporteMaximoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(392, 16)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(142, 16)
        Me.Label99.TabIndex = 76
        Me.Label99.Text = "Importe Máximo con DPVale"
        '
        'txtLimiteDescuentoEmpleado
        '
        Me.txtLimiteDescuentoEmpleado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtLimiteDescuentoEmpleado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtLimiteDescuentoEmpleado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimiteDescuentoEmpleado.Location = New System.Drawing.Point(208, 168)
        Me.txtLimiteDescuentoEmpleado.Name = "txtLimiteDescuentoEmpleado"
        Me.txtLimiteDescuentoEmpleado.Size = New System.Drawing.Size(40, 22)
        Me.txtLimiteDescuentoEmpleado.TabIndex = 75
        Me.txtLimiteDescuentoEmpleado.Text = "3"
        Me.txtLimiteDescuentoEmpleado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimiteDescuentoEmpleado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtLimiteDescuentoEmpleado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.Location = New System.Drawing.Point(8, 168)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(149, 16)
        Me.Label92.TabIndex = 74
        Me.Label92.Text = "Limite de Articulos Empleados:"
        '
        'grpGroupBox16
        '
        Me.grpGroupBox16.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox16.Controls.Add(Me.chkEtiquetaFactory)
        Me.grpGroupBox16.Controls.Add(Me.chkEtiquetaDP)
        Me.grpGroupBox16.Location = New System.Drawing.Point(8, 192)
        Me.grpGroupBox16.Name = "grpGroupBox16"
        Me.grpGroupBox16.Size = New System.Drawing.Size(296, 56)
        Me.grpGroupBox16.TabIndex = 74
        Me.grpGroupBox16.TabStop = False
        Me.grpGroupBox16.Text = "Diseño Etiquetas Precio"
        '
        'chkEtiquetaFactory
        '
        Me.chkEtiquetaFactory.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEtiquetaFactory.Location = New System.Drawing.Point(80, 24)
        Me.chkEtiquetaFactory.Name = "chkEtiquetaFactory"
        Me.chkEtiquetaFactory.Size = New System.Drawing.Size(136, 24)
        Me.chkEtiquetaFactory.TabIndex = 69
        Me.chkEtiquetaFactory.Text = "Factory"
        '
        'chkEtiquetaDP
        '
        Me.chkEtiquetaDP.Checked = True
        Me.chkEtiquetaDP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEtiquetaDP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEtiquetaDP.Location = New System.Drawing.Point(8, 24)
        Me.chkEtiquetaDP.Name = "chkEtiquetaDP"
        Me.chkEtiquetaDP.Size = New System.Drawing.Size(136, 24)
        Me.chkEtiquetaDP.TabIndex = 68
        Me.chkEtiquetaDP.Text = "Dportenis"
        '
        'nebMaxDescApartados
        '
        Me.nebMaxDescApartados.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebMaxDescApartados.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebMaxDescApartados.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebMaxDescApartados.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.nebMaxDescApartados.Location = New System.Drawing.Point(208, 136)
        Me.nebMaxDescApartados.Name = "nebMaxDescApartados"
        Me.nebMaxDescApartados.Size = New System.Drawing.Size(56, 22)
        Me.nebMaxDescApartados.TabIndex = 73
        Me.nebMaxDescApartados.Text = "0.00 %"
        Me.nebMaxDescApartados.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebMaxDescApartados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(8, 136)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(149, 16)
        Me.Label75.TabIndex = 72
        Me.Label75.Text = "Porcentaje Máximo Apartados"
        '
        'lblLabel41
        '
        Me.lblLabel41.AutoSize = True
        Me.lblLabel41.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel41.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel41.Location = New System.Drawing.Point(248, 112)
        Me.lblLabel41.Name = "lblLabel41"
        Me.lblLabel41.Size = New System.Drawing.Size(44, 16)
        Me.lblLabel41.TabIndex = 71
        Me.lblLabel41.Text = "Minutos"
        '
        'nebTiempoDescargasNoche
        '
        Me.nebTiempoDescargasNoche.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTiempoDescargasNoche.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTiempoDescargasNoche.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebTiempoDescargasNoche.Location = New System.Drawing.Point(208, 112)
        Me.nebTiempoDescargasNoche.Name = "nebTiempoDescargasNoche"
        Me.nebTiempoDescargasNoche.Size = New System.Drawing.Size(40, 22)
        Me.nebTiempoDescargasNoche.TabIndex = 70
        Me.nebTiempoDescargasNoche.Text = "20"
        Me.nebTiempoDescargasNoche.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTiempoDescargasNoche.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebTiempoDescargasNoche.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(8, 112)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(185, 16)
        Me.Label40.TabIndex = 69
        Me.Label40.Text = "Tiempo Espera Descargas Nocturnas"
        '
        'ebRutaActualizacion
        '
        Me.ebRutaActualizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRutaActualizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRutaActualizacion.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.ebRutaActualizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRutaActualizacion.Location = New System.Drawing.Point(64, 88)
        Me.ebRutaActualizacion.MaxLength = 100
        Me.ebRutaActualizacion.Name = "ebRutaActualizacion"
        Me.ebRutaActualizacion.Size = New System.Drawing.Size(224, 22)
        Me.ebRutaActualizacion.TabIndex = 67
        Me.ebRutaActualizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRutaActualizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(8, 88)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(50, 16)
        Me.Label32.TabIndex = 68
        Me.Label32.Text = "Ruta Act:"
        '
        'nebImporteMaxTarjeta
        '
        Me.nebImporteMaxTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebImporteMaxTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebImporteMaxTarjeta.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebImporteMaxTarjeta.Location = New System.Drawing.Point(200, 56)
        Me.nebImporteMaxTarjeta.Name = "nebImporteMaxTarjeta"
        Me.nebImporteMaxTarjeta.Size = New System.Drawing.Size(88, 26)
        Me.nebImporteMaxTarjeta.TabIndex = 66
        Me.nebImporteMaxTarjeta.Text = "$0.00"
        Me.nebImporteMaxTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebImporteMaxTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblImporteMaximoTarjeta
        '
        Me.lblImporteMaximoTarjeta.AutoSize = True
        Me.lblImporteMaximoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblImporteMaximoTarjeta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteMaximoTarjeta.Location = New System.Drawing.Point(8, 56)
        Me.lblImporteMaximoTarjeta.Name = "lblImporteMaximoTarjeta"
        Me.lblImporteMaximoTarjeta.Size = New System.Drawing.Size(139, 16)
        Me.lblImporteMaximoTarjeta.TabIndex = 65
        Me.lblImporteMaximoTarjeta.Text = "Importe Máximo con Tarjeta"
        '
        'ccFechaAutoF
        '
        '
        '
        '
        Me.ccFechaAutoF.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccFechaAutoF.Location = New System.Drawing.Point(168, 24)
        Me.ccFechaAutoF.Name = "ccFechaAutoF"
        Me.ccFechaAutoF.Size = New System.Drawing.Size(120, 26)
        Me.ccFechaAutoF.TabIndex = 64
        Me.ccFechaAutoF.Value = New Date(2012, 11, 24, 0, 0, 0, 0)
        Me.ccFechaAutoF.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Fecha Autofacturación"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.PicBxFotos)
        Me.GroupBox2.Controls.Add(Me.UBtnFotos)
        Me.GroupBox2.Controls.Add(Me.EdUnidadImg)
        Me.GroupBox2.Controls.Add(Me.EdrutaImg)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.EdPassImg)
        Me.GroupBox2.Controls.Add(Me.EdusuarioImg)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 144)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuración Descarga Imagenes"
        '
        'PicBxFotos
        '
        Me.PicBxFotos.BackColor = System.Drawing.Color.Transparent
        Me.PicBxFotos.Location = New System.Drawing.Point(248, 40)
        Me.PicBxFotos.Name = "PicBxFotos"
        Me.PicBxFotos.Size = New System.Drawing.Size(32, 32)
        Me.PicBxFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBxFotos.TabIndex = 37
        Me.PicBxFotos.TabStop = False
        '
        'UBtnFotos
        '
        Me.UBtnFotos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UBtnFotos.Location = New System.Drawing.Point(112, 112)
        Me.UBtnFotos.Name = "UBtnFotos"
        Me.UBtnFotos.Size = New System.Drawing.Size(40, 24)
        Me.UBtnFotos.TabIndex = 9
        Me.UBtnFotos.Text = "Probar"
        Me.UBtnFotos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EdUnidadImg
        '
        Me.EdUnidadImg.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdUnidadImg.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdUnidadImg.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdUnidadImg.Location = New System.Drawing.Point(80, 112)
        Me.EdUnidadImg.MaxLength = 2
        Me.EdUnidadImg.Name = "EdUnidadImg"
        Me.EdUnidadImg.Size = New System.Drawing.Size(24, 22)
        Me.EdUnidadImg.TabIndex = 8
        Me.EdUnidadImg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdUnidadImg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EdrutaImg
        '
        Me.EdrutaImg.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdrutaImg.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdrutaImg.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdrutaImg.Location = New System.Drawing.Point(80, 88)
        Me.EdrutaImg.MaxLength = 100
        Me.EdrutaImg.Name = "EdrutaImg"
        Me.EdrutaImg.Size = New System.Drawing.Size(224, 22)
        Me.EdrutaImg.TabIndex = 7
        Me.EdrutaImg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdrutaImg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Unidad"
        '
        'EdPassImg
        '
        Me.EdPassImg.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdPassImg.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdPassImg.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdPassImg.Location = New System.Drawing.Point(80, 64)
        Me.EdPassImg.MaxLength = 30
        Me.EdPassImg.Name = "EdPassImg"
        Me.EdPassImg.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.EdPassImg.Size = New System.Drawing.Size(144, 22)
        Me.EdPassImg.TabIndex = 6
        Me.EdPassImg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdPassImg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EdusuarioImg
        '
        Me.EdusuarioImg.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdusuarioImg.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdusuarioImg.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EdusuarioImg.Location = New System.Drawing.Point(80, 40)
        Me.EdusuarioImg.MaxLength = 30
        Me.EdusuarioImg.Name = "EdusuarioImg"
        Me.EdusuarioImg.Size = New System.Drawing.Size(144, 22)
        Me.EdusuarioImg.TabIndex = 5
        Me.EdusuarioImg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdusuarioImg.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 16)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Ruta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Usuario"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PicBxFI)
        Me.GroupBox1.Controls.Add(Me.UBtnFi)
        Me.GroupBox1.Controls.Add(Me.ebUnidad)
        Me.GroupBox1.Controls.Add(Me.EbRuta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ebPassword)
        Me.GroupBox1.Controls.Add(Me.ebUsuario)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(360, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 144)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración Dias FI"
        '
        'PicBxFI
        '
        Me.PicBxFI.BackColor = System.Drawing.Color.Transparent
        Me.PicBxFI.Location = New System.Drawing.Point(248, 40)
        Me.PicBxFI.Name = "PicBxFI"
        Me.PicBxFI.Size = New System.Drawing.Size(32, 32)
        Me.PicBxFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBxFI.TabIndex = 29
        Me.PicBxFI.TabStop = False
        '
        'UBtnFi
        '
        Me.UBtnFi.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UBtnFi.Location = New System.Drawing.Point(112, 112)
        Me.UBtnFi.Name = "UBtnFi"
        Me.UBtnFi.Size = New System.Drawing.Size(40, 24)
        Me.UBtnFi.TabIndex = 4
        Me.UBtnFi.Text = "Probar"
        Me.UBtnFi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUnidad
        '
        Me.ebUnidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUnidad.Location = New System.Drawing.Point(80, 112)
        Me.ebUnidad.MaxLength = 2
        Me.ebUnidad.Name = "ebUnidad"
        Me.ebUnidad.Size = New System.Drawing.Size(24, 22)
        Me.ebUnidad.TabIndex = 3
        Me.ebUnidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EbRuta
        '
        Me.EbRuta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EbRuta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EbRuta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EbRuta.Location = New System.Drawing.Point(80, 88)
        Me.EbRuta.MaxLength = 100
        Me.EbRuta.Name = "EbRuta"
        Me.EbRuta.Size = New System.Drawing.Size(224, 22)
        Me.EbRuta.TabIndex = 2
        Me.EbRuta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EbRuta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Unidad"
        '
        'ebPassword
        '
        Me.ebPassword.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassword.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassword.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(80, 64)
        Me.ebPassword.MaxLength = 30
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPassword.Size = New System.Drawing.Size(144, 22)
        Me.ebPassword.TabIndex = 1
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUsuario
        '
        Me.ebUsuario.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuario.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuario.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuario.Location = New System.Drawing.Point(80, 40)
        Me.ebUsuario.MaxLength = 30
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.Size = New System.Drawing.Size(144, 22)
        Me.ebUsuario.TabIndex = 0
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Ruta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Usuario"
        '
        'UiTabPage3
        '
        Me.UiTabPage3.Controls.Add(Me.Label64)
        Me.UiTabPage3.Controls.Add(Me.ebMailGerenteRegional)
        Me.UiTabPage3.Controls.Add(Me.Label67)
        Me.UiTabPage3.Controls.Add(Me.ebMailGerentePlaza)
        Me.UiTabPage3.Controls.Add(Me.ebMailGerenteOperaciones)
        Me.UiTabPage3.Controls.Add(Me.Label66)
        Me.UiTabPage3.Controls.Add(Me.GroupBox14)
        Me.UiTabPage3.Controls.Add(Me.GroupBox8)
        Me.UiTabPage3.Controls.Add(Me.GroupBox7)
        Me.UiTabPage3.Controls.Add(Me.GroupBox4)
        Me.UiTabPage3.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage3.Name = "UiTabPage3"
        Me.UiTabPage3.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage3.TabStop = True
        Me.UiTabPage3.Text = "Cuentas Correo"
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(352, 371)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(95, 40)
        Me.Label64.TabIndex = 43
        Me.Label64.Text = "Correo Gerente Plaza"
        '
        'ebMailGerenteRegional
        '
        Me.ebMailGerenteRegional.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailGerenteRegional.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailGerenteRegional.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailGerenteRegional.Location = New System.Drawing.Point(464, 331)
        Me.ebMailGerenteRegional.MaxLength = 100
        Me.ebMailGerenteRegional.Name = "ebMailGerenteRegional"
        Me.ebMailGerenteRegional.Size = New System.Drawing.Size(224, 26)
        Me.ebMailGerenteRegional.TabIndex = 44
        Me.ebMailGerenteRegional.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailGerenteRegional.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(352, 331)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(95, 40)
        Me.Label67.TabIndex = 45
        Me.Label67.Text = "Correo Gerente Regional"
        '
        'ebMailGerentePlaza
        '
        Me.ebMailGerentePlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailGerentePlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailGerentePlaza.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailGerentePlaza.Location = New System.Drawing.Point(464, 371)
        Me.ebMailGerentePlaza.MaxLength = 100
        Me.ebMailGerentePlaza.Name = "ebMailGerentePlaza"
        Me.ebMailGerentePlaza.Size = New System.Drawing.Size(224, 26)
        Me.ebMailGerentePlaza.TabIndex = 42
        Me.ebMailGerentePlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailGerentePlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMailGerenteOperaciones
        '
        Me.ebMailGerenteOperaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailGerenteOperaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailGerenteOperaciones.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailGerenteOperaciones.Location = New System.Drawing.Point(464, 291)
        Me.ebMailGerenteOperaciones.MaxLength = 100
        Me.ebMailGerenteOperaciones.Name = "ebMailGerenteOperaciones"
        Me.ebMailGerenteOperaciones.Size = New System.Drawing.Size(224, 26)
        Me.ebMailGerenteOperaciones.TabIndex = 40
        Me.ebMailGerenteOperaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailGerenteOperaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(352, 291)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(120, 40)
        Me.Label66.TabIndex = 41
        Me.Label66.Text = "Correo Gerente Operaciones"
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox14.Controls.Add(Me.lstMailsLogistica)
        Me.GroupBox14.Controls.Add(Me.btnAddMailLog)
        Me.GroupBox14.Controls.Add(Me.ebMailLogistica)
        Me.GroupBox14.Controls.Add(Me.Label65)
        Me.GroupBox14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(8, 283)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(336, 128)
        Me.GroupBox14.TabIndex = 39
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Cuentas de Correo de Logística"
        '
        'lstMailsLogistica
        '
        Me.lstMailsLogistica.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMailsLogistica.ItemHeight = 20
        Me.lstMailsLogistica.Location = New System.Drawing.Point(8, 56)
        Me.lstMailsLogistica.Name = "lstMailsLogistica"
        Me.lstMailsLogistica.Size = New System.Drawing.Size(320, 60)
        Me.lstMailsLogistica.TabIndex = 36
        '
        'btnAddMailLog
        '
        Me.btnAddMailLog.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMailLog.Location = New System.Drawing.Point(296, 24)
        Me.btnAddMailLog.Name = "btnAddMailLog"
        Me.btnAddMailLog.Size = New System.Drawing.Size(32, 24)
        Me.btnAddMailLog.TabIndex = 35
        Me.btnAddMailLog.Text = "Add"
        Me.btnAddMailLog.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMailLogistica
        '
        Me.ebMailLogistica.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailLogistica.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailLogistica.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailLogistica.Location = New System.Drawing.Point(104, 24)
        Me.ebMailLogistica.MaxLength = 100
        Me.ebMailLogistica.Name = "ebMailLogistica"
        Me.ebMailLogistica.Size = New System.Drawing.Size(192, 26)
        Me.ebMailLogistica.TabIndex = 10
        Me.ebMailLogistica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailLogistica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(8, 28)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(97, 16)
        Me.Label65.TabIndex = 33
        Me.Label65.Text = "Cuenta de Correo:"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.lstMailsUPC)
        Me.GroupBox8.Controls.Add(Me.btnAddMailUPC)
        Me.GroupBox8.Controls.Add(Me.ebMailUPC)
        Me.GroupBox8.Controls.Add(Me.Label24)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(352, 155)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(336, 128)
        Me.GroupBox8.TabIndex = 38
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Cuentas de Correo de UPC"
        '
        'lstMailsUPC
        '
        Me.lstMailsUPC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMailsUPC.ItemHeight = 20
        Me.lstMailsUPC.Location = New System.Drawing.Point(8, 56)
        Me.lstMailsUPC.Name = "lstMailsUPC"
        Me.lstMailsUPC.Size = New System.Drawing.Size(320, 60)
        Me.lstMailsUPC.TabIndex = 36
        '
        'btnAddMailUPC
        '
        Me.btnAddMailUPC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMailUPC.Location = New System.Drawing.Point(296, 24)
        Me.btnAddMailUPC.Name = "btnAddMailUPC"
        Me.btnAddMailUPC.Size = New System.Drawing.Size(32, 24)
        Me.btnAddMailUPC.TabIndex = 35
        Me.btnAddMailUPC.Text = "Add"
        Me.btnAddMailUPC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMailUPC
        '
        Me.ebMailUPC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailUPC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailUPC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailUPC.Location = New System.Drawing.Point(104, 24)
        Me.ebMailUPC.MaxLength = 100
        Me.ebMailUPC.Name = "ebMailUPC"
        Me.ebMailUPC.Size = New System.Drawing.Size(192, 26)
        Me.ebMailUPC.TabIndex = 10
        Me.ebMailUPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailUPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 28)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 16)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Cuenta de Correo:"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.lstMailsAud)
        Me.GroupBox7.Controls.Add(Me.btnAddMailAud)
        Me.GroupBox7.Controls.Add(Me.ebMailAud)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(8, 155)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(336, 128)
        Me.GroupBox7.TabIndex = 33
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Cuentas de Correo de Auditoria"
        '
        'lstMailsAud
        '
        Me.lstMailsAud.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMailsAud.ItemHeight = 20
        Me.lstMailsAud.Location = New System.Drawing.Point(8, 56)
        Me.lstMailsAud.Name = "lstMailsAud"
        Me.lstMailsAud.Size = New System.Drawing.Size(320, 60)
        Me.lstMailsAud.TabIndex = 36
        '
        'btnAddMailAud
        '
        Me.btnAddMailAud.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMailAud.Location = New System.Drawing.Point(296, 24)
        Me.btnAddMailAud.Name = "btnAddMailAud"
        Me.btnAddMailAud.Size = New System.Drawing.Size(32, 24)
        Me.btnAddMailAud.TabIndex = 35
        Me.btnAddMailAud.Text = "Add"
        Me.btnAddMailAud.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMailAud
        '
        Me.ebMailAud.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailAud.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailAud.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailAud.Location = New System.Drawing.Point(104, 24)
        Me.ebMailAud.MaxLength = 100
        Me.ebMailAud.Name = "ebMailAud"
        Me.ebMailAud.Size = New System.Drawing.Size(192, 26)
        Me.ebMailAud.TabIndex = 10
        Me.ebMailAud.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailAud.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 16)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "Cuenta de Correo:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txtPasswordCorreo)
        Me.GroupBox4.Controls.Add(Me.lblPasswordCorreo)
        Me.GroupBox4.Controls.Add(Me.txtPuertoSMTP)
        Me.GroupBox4.Controls.Add(Me.lblPuertoSMTP)
        Me.GroupBox4.Controls.Add(Me.ebCorreoActivacion)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.ebServidorSMTP)
        Me.GroupBox4.Controls.Add(Me.ebCuentaCorreo)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(680, 141)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Configuración Envio de Correos"
        '
        'txtPasswordCorreo
        '
        Me.txtPasswordCorreo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPasswordCorreo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPasswordCorreo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordCorreo.Location = New System.Drawing.Point(104, 55)
        Me.txtPasswordCorreo.MaxLength = 100
        Me.txtPasswordCorreo.Name = "txtPasswordCorreo"
        Me.txtPasswordCorreo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordCorreo.Size = New System.Drawing.Size(224, 26)
        Me.txtPasswordCorreo.TabIndex = 128
        Me.txtPasswordCorreo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPasswordCorreo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPasswordCorreo
        '
        Me.lblPasswordCorreo.AutoSize = True
        Me.lblPasswordCorreo.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordCorreo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordCorreo.Location = New System.Drawing.Point(8, 60)
        Me.lblPasswordCorreo.Name = "lblPasswordCorreo"
        Me.lblPasswordCorreo.Size = New System.Drawing.Size(95, 16)
        Me.lblPasswordCorreo.TabIndex = 127
        Me.lblPasswordCorreo.Text = "Password Correo:"
        '
        'txtPuertoSMTP
        '
        Me.txtPuertoSMTP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPuertoSMTP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPuertoSMTP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuertoSMTP.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtPuertoSMTP.Location = New System.Drawing.Point(104, 116)
        Me.txtPuertoSMTP.Name = "txtPuertoSMTP"
        Me.txtPuertoSMTP.Size = New System.Drawing.Size(50, 22)
        Me.txtPuertoSMTP.TabIndex = 126
        Me.txtPuertoSMTP.Text = "0"
        Me.txtPuertoSMTP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPuertoSMTP.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtPuertoSMTP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPuertoSMTP
        '
        Me.lblPuertoSMTP.AutoSize = True
        Me.lblPuertoSMTP.BackColor = System.Drawing.Color.Transparent
        Me.lblPuertoSMTP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuertoSMTP.Location = New System.Drawing.Point(8, 118)
        Me.lblPuertoSMTP.Name = "lblPuertoSMTP"
        Me.lblPuertoSMTP.Size = New System.Drawing.Size(75, 16)
        Me.lblPuertoSMTP.TabIndex = 36
        Me.lblPuertoSMTP.Text = "Puerto SMTP:"
        '
        'ebCorreoActivacion
        '
        Me.ebCorreoActivacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorreoActivacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorreoActivacion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCorreoActivacion.Location = New System.Drawing.Point(448, 24)
        Me.ebCorreoActivacion.MaxLength = 100
        Me.ebCorreoActivacion.Name = "ebCorreoActivacion"
        Me.ebCorreoActivacion.Size = New System.Drawing.Size(224, 26)
        Me.ebCorreoActivacion.TabIndex = 34
        Me.ebCorreoActivacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorreoActivacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(352, 24)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(95, 40)
        Me.Label37.TabIndex = 35
        Me.Label37.Text = "Correo Envío Activación:"
        '
        'ebServidorSMTP
        '
        Me.ebServidorSMTP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServidorSMTP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServidorSMTP.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServidorSMTP.Location = New System.Drawing.Point(104, 85)
        Me.ebServidorSMTP.MaxLength = 100
        Me.ebServidorSMTP.Name = "ebServidorSMTP"
        Me.ebServidorSMTP.Size = New System.Drawing.Size(224, 26)
        Me.ebServidorSMTP.TabIndex = 11
        Me.ebServidorSMTP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorSMTP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCuentaCorreo
        '
        Me.ebCuentaCorreo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCuentaCorreo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCuentaCorreo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCuentaCorreo.Location = New System.Drawing.Point(104, 24)
        Me.ebCuentaCorreo.MaxLength = 100
        Me.ebCuentaCorreo.Name = "ebCuentaCorreo"
        Me.ebCuentaCorreo.Size = New System.Drawing.Size(224, 26)
        Me.ebCuentaCorreo.TabIndex = 10
        Me.ebCuentaCorreo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCuentaCorreo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 86)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 16)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Servidor SMTP:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Cuenta de Correo:"
        '
        'UiTabPage5
        '
        Me.UiTabPage5.Controls.Add(Me.grpConsignacion)
        Me.UiTabPage5.Controls.Add(Me.GroupBox17)
        Me.UiTabPage5.Controls.Add(Me.ebImpresoraETIF)
        Me.UiTabPage5.Controls.Add(Me.Label93)
        Me.UiTabPage5.Controls.Add(Me.chkModuloTraspasoFisico)
        Me.UiTabPage5.Controls.Add(Me.nebDiasBloqueo)
        Me.UiTabPage5.Controls.Add(Me.Label62)
        Me.UiTabPage5.Controls.Add(Me.nebTSPorDia)
        Me.UiTabPage5.Controls.Add(Me.chkSoloMismaPlaza)
        Me.UiTabPage5.Controls.Add(Me.Label63)
        Me.UiTabPage5.Controls.Add(Me.nebPzasTotalesTS)
        Me.UiTabPage5.Controls.Add(Me.ebExtensionDHL)
        Me.UiTabPage5.Controls.Add(Me.Label50)
        Me.UiTabPage5.Controls.Add(Me.ebCLABEDHL)
        Me.UiTabPage5.Controls.Add(Me.Label49)
        Me.UiTabPage5.Controls.Add(Me.ebNoCuentaDHL)
        Me.UiTabPage5.Controls.Add(Me.Label48)
        Me.UiTabPage5.Controls.Add(Me.lblLabel48)
        Me.UiTabPage5.Controls.Add(Me.chkBloquearPro)
        Me.UiTabPage5.Controls.Add(Me.chkRecibirParcial)
        Me.UiTabPage5.Controls.Add(Me.chkRecibirPorBulto)
        Me.UiTabPage5.Controls.Add(Me.GroupBox12)
        Me.UiTabPage5.Controls.Add(Me.GroupBox11)
        Me.UiTabPage5.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage5.Name = "UiTabPage5"
        Me.UiTabPage5.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage5.TabStop = True
        Me.UiTabPage5.Text = "Traspasos"
        '
        'grpConsignacion
        '
        Me.grpConsignacion.BackColor = System.Drawing.Color.Transparent
        Me.grpConsignacion.Controls.Add(Me.txtReintentoConsignacion)
        Me.grpConsignacion.Controls.Add(Me.lblReintentos)
        Me.grpConsignacion.Controls.Add(Me.txtIntervaloConsignacion)
        Me.grpConsignacion.Controls.Add(Me.lblTiempoIntervalo)
        Me.grpConsignacion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConsignacion.Location = New System.Drawing.Point(16, 325)
        Me.grpConsignacion.Name = "grpConsignacion"
        Me.grpConsignacion.Size = New System.Drawing.Size(336, 90)
        Me.grpConsignacion.TabIndex = 71
        Me.grpConsignacion.TabStop = False
        Me.grpConsignacion.Text = "Consignación"
        '
        'txtReintentoConsignacion
        '
        Me.txtReintentoConsignacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtReintentoConsignacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtReintentoConsignacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReintentoConsignacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtReintentoConsignacion.Location = New System.Drawing.Point(132, 47)
        Me.txtReintentoConsignacion.Name = "txtReintentoConsignacion"
        Me.txtReintentoConsignacion.Size = New System.Drawing.Size(82, 22)
        Me.txtReintentoConsignacion.TabIndex = 115
        Me.txtReintentoConsignacion.Text = "0"
        Me.txtReintentoConsignacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtReintentoConsignacion.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtReintentoConsignacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblReintentos
        '
        Me.lblReintentos.AutoSize = True
        Me.lblReintentos.BackColor = System.Drawing.Color.Transparent
        Me.lblReintentos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReintentos.Location = New System.Drawing.Point(8, 47)
        Me.lblReintentos.Name = "lblReintentos"
        Me.lblReintentos.Size = New System.Drawing.Size(121, 16)
        Me.lblReintentos.TabIndex = 114
        Me.lblReintentos.Text = "Reintentos de guardado"
        '
        'txtIntervaloConsignacion
        '
        Me.txtIntervaloConsignacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtIntervaloConsignacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtIntervaloConsignacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIntervaloConsignacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtIntervaloConsignacion.Location = New System.Drawing.Point(132, 20)
        Me.txtIntervaloConsignacion.Name = "txtIntervaloConsignacion"
        Me.txtIntervaloConsignacion.Size = New System.Drawing.Size(82, 22)
        Me.txtIntervaloConsignacion.TabIndex = 113
        Me.txtIntervaloConsignacion.Text = "0"
        Me.txtIntervaloConsignacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtIntervaloConsignacion.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtIntervaloConsignacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTiempoIntervalo
        '
        Me.lblTiempoIntervalo.AutoSize = True
        Me.lblTiempoIntervalo.BackColor = System.Drawing.Color.Transparent
        Me.lblTiempoIntervalo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempoIntervalo.Location = New System.Drawing.Point(8, 22)
        Me.lblTiempoIntervalo.Name = "lblTiempoIntervalo"
        Me.lblTiempoIntervalo.Size = New System.Drawing.Size(86, 16)
        Me.lblTiempoIntervalo.TabIndex = 71
        Me.lblTiempoIntervalo.Text = "Tiempo intervalo"
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox17.Controls.Add(Me.ebNombreArchivoLectoraTE)
        Me.GroupBox17.Controls.Add(Me.Label70)
        Me.GroupBox17.Controls.Add(Me.ebNombreLectoraTE)
        Me.GroupBox17.Controls.Add(Me.Label69)
        Me.GroupBox17.Controls.Add(Me.chkTraspasoEntradaLectora)
        Me.GroupBox17.Location = New System.Drawing.Point(360, 312)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(336, 104)
        Me.GroupBox17.TabIndex = 68
        Me.GroupBox17.TabStop = False
        '
        'ebNombreArchivoLectoraTE
        '
        Me.ebNombreArchivoLectoraTE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreArchivoLectoraTE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreArchivoLectoraTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombreArchivoLectoraTE.Location = New System.Drawing.Point(112, 72)
        Me.ebNombreArchivoLectoraTE.MaxLength = 0
        Me.ebNombreArchivoLectoraTE.Name = "ebNombreArchivoLectoraTE"
        Me.ebNombreArchivoLectoraTE.Size = New System.Drawing.Size(216, 22)
        Me.ebNombreArchivoLectoraTE.TabIndex = 71
        Me.ebNombreArchivoLectoraTE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreArchivoLectoraTE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(8, 72)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(100, 16)
        Me.Label70.TabIndex = 72
        Me.Label70.Text = "Nombre de Archivo"
        '
        'ebNombreLectoraTE
        '
        Me.ebNombreLectoraTE.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombreLectoraTE.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombreLectoraTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombreLectoraTE.Location = New System.Drawing.Point(112, 40)
        Me.ebNombreLectoraTE.MaxLength = 0
        Me.ebNombreLectoraTE.Name = "ebNombreLectoraTE"
        Me.ebNombreLectoraTE.Size = New System.Drawing.Size(216, 22)
        Me.ebNombreLectoraTE.TabIndex = 69
        Me.ebNombreLectoraTE.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreLectoraTE.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(8, 40)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(99, 16)
        Me.Label69.TabIndex = 70
        Me.Label69.Text = "Nombre de Lectora"
        '
        'chkTraspasoEntradaLectora
        '
        Me.chkTraspasoEntradaLectora.BackColor = System.Drawing.Color.Transparent
        Me.chkTraspasoEntradaLectora.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTraspasoEntradaLectora.Location = New System.Drawing.Point(8, 8)
        Me.chkTraspasoEntradaLectora.Name = "chkTraspasoEntradaLectora"
        Me.chkTraspasoEntradaLectora.Size = New System.Drawing.Size(320, 32)
        Me.chkTraspasoEntradaLectora.TabIndex = 68
        Me.chkTraspasoEntradaLectora.Text = "Traspaso de Entrada con Lectora"
        Me.chkTraspasoEntradaLectora.UseVisualStyleBackColor = False
        '
        'ebImpresoraETIF
        '
        Me.ebImpresoraETIF.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImpresoraETIF.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImpresoraETIF.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImpresoraETIF.Location = New System.Drawing.Point(472, 280)
        Me.ebImpresoraETIF.MaxLength = 0
        Me.ebImpresoraETIF.Name = "ebImpresoraETIF"
        Me.ebImpresoraETIF.Size = New System.Drawing.Size(216, 22)
        Me.ebImpresoraETIF.TabIndex = 61
        Me.ebImpresoraETIF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebImpresoraETIF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.BackColor = System.Drawing.Color.Transparent
        Me.Label93.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.Location = New System.Drawing.Point(368, 280)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(101, 16)
        Me.Label93.TabIndex = 62
        Me.Label93.Text = "Impresora Etiquetas"
        '
        'chkModuloTraspasoFisico
        '
        Me.chkModuloTraspasoFisico.BackColor = System.Drawing.Color.Transparent
        Me.chkModuloTraspasoFisico.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkModuloTraspasoFisico.Location = New System.Drawing.Point(368, 248)
        Me.chkModuloTraspasoFisico.Name = "chkModuloTraspasoFisico"
        Me.chkModuloTraspasoFisico.Size = New System.Drawing.Size(224, 24)
        Me.chkModuloTraspasoFisico.TabIndex = 60
        Me.chkModuloTraspasoFisico.Text = "Mostrar módulo de traspasos virtuales"
        Me.chkModuloTraspasoFisico.UseVisualStyleBackColor = False
        '
        'nebDiasBloqueo
        '
        Me.nebDiasBloqueo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasBloqueo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasBloqueo.Enabled = False
        Me.nebDiasBloqueo.Location = New System.Drawing.Point(120, 214)
        Me.nebDiasBloqueo.Name = "nebDiasBloqueo"
        Me.nebDiasBloqueo.Size = New System.Drawing.Size(40, 26)
        Me.nebDiasBloqueo.TabIndex = 39
        Me.nebDiasBloqueo.Text = "0"
        Me.nebDiasBloqueo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasBloqueo.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasBloqueo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(16, 291)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(97, 16)
        Me.Label62.TabIndex = 56
        Me.Label62.Text = "Traspasos Por Día"
        '
        'nebTSPorDia
        '
        Me.nebTSPorDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTSPorDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTSPorDia.Location = New System.Drawing.Point(168, 288)
        Me.nebTSPorDia.Name = "nebTSPorDia"
        Me.nebTSPorDia.Size = New System.Drawing.Size(40, 26)
        Me.nebTSPorDia.TabIndex = 55
        Me.nebTSPorDia.Text = "0"
        Me.nebTSPorDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTSPorDia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebTSPorDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkSoloMismaPlaza
        '
        Me.chkSoloMismaPlaza.BackColor = System.Drawing.Color.Transparent
        Me.chkSoloMismaPlaza.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloMismaPlaza.Location = New System.Drawing.Point(16, 242)
        Me.chkSoloMismaPlaza.Name = "chkSoloMismaPlaza"
        Me.chkSoloMismaPlaza.Size = New System.Drawing.Size(320, 18)
        Me.chkSoloMismaPlaza.TabIndex = 54
        Me.chkSoloMismaPlaza.Text = "Permitir traspasos solo misma plaza"
        Me.chkSoloMismaPlaza.UseVisualStyleBackColor = False
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(16, 263)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(149, 16)
        Me.Label63.TabIndex = 53
        Me.Label63.Text = "Piezas Permitidas para Enviar"
        '
        'nebPzasTotalesTS
        '
        Me.nebPzasTotalesTS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPzasTotalesTS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPzasTotalesTS.Location = New System.Drawing.Point(168, 260)
        Me.nebPzasTotalesTS.Name = "nebPzasTotalesTS"
        Me.nebPzasTotalesTS.Size = New System.Drawing.Size(40, 26)
        Me.nebPzasTotalesTS.TabIndex = 52
        Me.nebPzasTotalesTS.Text = "0"
        Me.nebPzasTotalesTS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPzasTotalesTS.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebPzasTotalesTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebExtensionDHL
        '
        Me.ebExtensionDHL.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebExtensionDHL.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebExtensionDHL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebExtensionDHL.Location = New System.Drawing.Point(520, 216)
        Me.ebExtensionDHL.MaxLength = 30
        Me.ebExtensionDHL.Name = "ebExtensionDHL"
        Me.ebExtensionDHL.Size = New System.Drawing.Size(72, 22)
        Me.ebExtensionDHL.TabIndex = 45
        Me.ebExtensionDHL.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebExtensionDHL.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(368, 216)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(142, 16)
        Me.Label50.TabIndex = 46
        Me.Label50.Text = "Extensión Reclamación DHL"
        '
        'ebCLABEDHL
        '
        Me.ebCLABEDHL.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCLABEDHL.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCLABEDHL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCLABEDHL.Location = New System.Drawing.Point(472, 192)
        Me.ebCLABEDHL.MaxLength = 30
        Me.ebCLABEDHL.Name = "ebCLABEDHL"
        Me.ebCLABEDHL.Size = New System.Drawing.Size(120, 22)
        Me.ebCLABEDHL.TabIndex = 43
        Me.ebCLABEDHL.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCLABEDHL.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(368, 192)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(105, 16)
        Me.Label49.TabIndex = 44
        Me.Label49.Text = "Cuenta CLABE DHL"
        '
        'ebNoCuentaDHL
        '
        Me.ebNoCuentaDHL.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoCuentaDHL.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoCuentaDHL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoCuentaDHL.Location = New System.Drawing.Point(472, 168)
        Me.ebNoCuentaDHL.MaxLength = 30
        Me.ebNoCuentaDHL.Name = "ebNoCuentaDHL"
        Me.ebNoCuentaDHL.Size = New System.Drawing.Size(120, 22)
        Me.ebNoCuentaDHL.TabIndex = 41
        Me.ebNoCuentaDHL.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoCuentaDHL.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(368, 168)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(87, 16)
        Me.Label48.TabIndex = 42
        Me.Label48.Text = "No. Cuenta DHL"
        '
        'lblLabel48
        '
        Me.lblLabel48.AutoSize = True
        Me.lblLabel48.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel48.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel48.Location = New System.Drawing.Point(16, 220)
        Me.lblLabel48.Name = "lblLabel48"
        Me.lblLabel48.Size = New System.Drawing.Size(101, 16)
        Me.lblLabel48.TabIndex = 40
        Me.lblLabel48.Text = "Dias Para Bloquear"
        '
        'chkBloquearPro
        '
        Me.chkBloquearPro.BackColor = System.Drawing.Color.Transparent
        Me.chkBloquearPro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBloquearPro.Location = New System.Drawing.Point(16, 195)
        Me.chkBloquearPro.Name = "chkBloquearPro"
        Me.chkBloquearPro.Size = New System.Drawing.Size(320, 24)
        Me.chkBloquearPro.TabIndex = 38
        Me.chkBloquearPro.Text = "Bloquear Sistema Por Traspasos Pendientes"
        Me.chkBloquearPro.UseVisualStyleBackColor = False
        '
        'chkRecibirParcial
        '
        Me.chkRecibirParcial.BackColor = System.Drawing.Color.Transparent
        Me.chkRecibirParcial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecibirParcial.Location = New System.Drawing.Point(16, 180)
        Me.chkRecibirParcial.Name = "chkRecibirParcial"
        Me.chkRecibirParcial.Size = New System.Drawing.Size(187, 18)
        Me.chkRecibirParcial.TabIndex = 37
        Me.chkRecibirParcial.Text = "Recibir Traspasos Parcialmente"
        Me.chkRecibirParcial.UseVisualStyleBackColor = False
        '
        'chkRecibirPorBulto
        '
        Me.chkRecibirPorBulto.BackColor = System.Drawing.Color.Transparent
        Me.chkRecibirPorBulto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecibirPorBulto.Location = New System.Drawing.Point(16, 160)
        Me.chkRecibirPorBulto.Name = "chkRecibirPorBulto"
        Me.chkRecibirPorBulto.Size = New System.Drawing.Size(125, 24)
        Me.chkRecibirPorBulto.TabIndex = 36
        Me.chkRecibirPorBulto.Text = "Recibir por Bulto"
        Me.chkRecibirPorBulto.UseVisualStyleBackColor = False
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox12.Controls.Add(Me.cmbServerTraspasos)
        Me.GroupBox12.Controls.Add(Me.ebUserTraspasos)
        Me.GroupBox12.Controls.Add(Me.btnProbarTraspasos)
        Me.GroupBox12.Controls.Add(Me.ebBaseDatosTraspasos)
        Me.GroupBox12.Controls.Add(Me.Label42)
        Me.GroupBox12.Controls.Add(Me.ebPassTraspasos)
        Me.GroupBox12.Controls.Add(Me.Label43)
        Me.GroupBox12.Controls.Add(Me.Label44)
        Me.GroupBox12.Controls.Add(Me.Label45)
        Me.GroupBox12.Controls.Add(Me.pbTraspasos)
        Me.GroupBox12.Location = New System.Drawing.Point(360, 16)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(336, 144)
        Me.GroupBox12.TabIndex = 35
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Configuración Traspasos"
        '
        'cmbServerTraspasos
        '
        Me.cmbServerTraspasos.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerTraspasos.Name = "cmbServerTraspasos"
        Me.cmbServerTraspasos.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerTraspasos.TabIndex = 12
        Me.cmbServerTraspasos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserTraspasos
        '
        Me.ebUserTraspasos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserTraspasos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserTraspasos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserTraspasos.Location = New System.Drawing.Point(88, 80)
        Me.ebUserTraspasos.MaxLength = 30
        Me.ebUserTraspasos.Name = "ebUserTraspasos"
        Me.ebUserTraspasos.Size = New System.Drawing.Size(144, 22)
        Me.ebUserTraspasos.TabIndex = 14
        Me.ebUserTraspasos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarTraspasos
        '
        Me.btnProbarTraspasos.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarTraspasos.Location = New System.Drawing.Point(272, 96)
        Me.btnProbarTraspasos.Name = "btnProbarTraspasos"
        Me.btnProbarTraspasos.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarTraspasos.TabIndex = 4
        Me.btnProbarTraspasos.Text = "Probar"
        Me.btnProbarTraspasos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosTraspasos
        '
        Me.ebBaseDatosTraspasos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosTraspasos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosTraspasos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosTraspasos.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosTraspasos.MaxLength = 50
        Me.ebBaseDatosTraspasos.Name = "ebBaseDatosTraspasos"
        Me.ebBaseDatosTraspasos.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosTraspasos.TabIndex = 13
        Me.ebBaseDatosTraspasos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(8, 56)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(77, 16)
        Me.Label42.TabIndex = 27
        Me.Label42.Text = "Base de Datos"
        '
        'ebPassTraspasos
        '
        Me.ebPassTraspasos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassTraspasos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassTraspasos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassTraspasos.Location = New System.Drawing.Point(88, 104)
        Me.ebPassTraspasos.MaxLength = 30
        Me.ebPassTraspasos.Name = "ebPassTraspasos"
        Me.ebPassTraspasos.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPassTraspasos.Size = New System.Drawing.Size(144, 22)
        Me.ebPassTraspasos.TabIndex = 15
        Me.ebPassTraspasos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(8, 104)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(55, 16)
        Me.Label43.TabIndex = 26
        Me.Label43.Text = "Password"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(8, 32)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(49, 16)
        Me.Label44.TabIndex = 24
        Me.Label44.Text = "Servidor"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(8, 80)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(45, 16)
        Me.Label45.TabIndex = 25
        Me.Label45.Text = "Usuario"
        '
        'pbTraspasos
        '
        Me.pbTraspasos.BackColor = System.Drawing.Color.Transparent
        Me.pbTraspasos.Location = New System.Drawing.Point(280, 40)
        Me.pbTraspasos.Name = "pbTraspasos"
        Me.pbTraspasos.Size = New System.Drawing.Size(32, 32)
        Me.pbTraspasos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbTraspasos.TabIndex = 29
        Me.pbTraspasos.TabStop = False
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox11.Controls.Add(Me.lstMailsErroresCDist)
        Me.GroupBox11.Controls.Add(Me.btnMailErrorCDist)
        Me.GroupBox11.Controls.Add(Me.ebMailErrorCDist)
        Me.GroupBox11.Controls.Add(Me.Label41)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(336, 144)
        Me.GroupBox11.TabIndex = 34
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Cuentas de Correo Errores CDist"
        '
        'lstMailsErroresCDist
        '
        Me.lstMailsErroresCDist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMailsErroresCDist.ItemHeight = 20
        Me.lstMailsErroresCDist.Location = New System.Drawing.Point(8, 56)
        Me.lstMailsErroresCDist.Name = "lstMailsErroresCDist"
        Me.lstMailsErroresCDist.Size = New System.Drawing.Size(320, 80)
        Me.lstMailsErroresCDist.TabIndex = 36
        '
        'btnMailErrorCDist
        '
        Me.btnMailErrorCDist.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMailErrorCDist.Location = New System.Drawing.Point(296, 24)
        Me.btnMailErrorCDist.Name = "btnMailErrorCDist"
        Me.btnMailErrorCDist.Size = New System.Drawing.Size(32, 24)
        Me.btnMailErrorCDist.TabIndex = 35
        Me.btnMailErrorCDist.Text = "Add"
        Me.btnMailErrorCDist.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMailErrorCDist
        '
        Me.ebMailErrorCDist.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailErrorCDist.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailErrorCDist.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailErrorCDist.Location = New System.Drawing.Point(104, 24)
        Me.ebMailErrorCDist.MaxLength = 100
        Me.ebMailErrorCDist.Name = "ebMailErrorCDist"
        Me.ebMailErrorCDist.Size = New System.Drawing.Size(192, 26)
        Me.ebMailErrorCDist.TabIndex = 10
        Me.ebMailErrorCDist.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailErrorCDist.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(8, 28)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(97, 16)
        Me.Label41.TabIndex = 33
        Me.Label41.Text = "Cuenta de Correo:"
        '
        'UiTabPage6
        '
        Me.UiTabPage6.Controls.Add(Me.UiGroupBox3)
        Me.UiTabPage6.Controls.Add(Me.gboxLeyendaNotaVenta)
        Me.UiTabPage6.Controls.Add(Me.Label102)
        Me.UiTabPage6.Controls.Add(Me.nebDiasRecibirPago)
        Me.UiTabPage6.Controls.Add(Me.Label103)
        Me.UiTabPage6.Controls.Add(Me.ebNotaOPEC)
        Me.UiTabPage6.Controls.Add(Me.Label101)
        Me.UiTabPage6.Controls.Add(Me.Label58)
        Me.UiTabPage6.Controls.Add(Me.nebDiasEnviarEC)
        Me.UiTabPage6.Controls.Add(Me.Label59)
        Me.UiTabPage6.Controls.Add(Me.Label56)
        Me.UiTabPage6.Controls.Add(Me.nebDiasFacturarConcen)
        Me.UiTabPage6.Controls.Add(Me.Label57)
        Me.UiTabPage6.Controls.Add(Me.Label54)
        Me.UiTabPage6.Controls.Add(Me.nebDiasFacturar)
        Me.UiTabPage6.Controls.Add(Me.Label55)
        Me.UiTabPage6.Controls.Add(Me.Label52)
        Me.UiTabPage6.Controls.Add(Me.nebDiasSurtir)
        Me.UiTabPage6.Controls.Add(Me.Label53)
        Me.UiTabPage6.Controls.Add(Me.chkSurtirEC)
        Me.UiTabPage6.Controls.Add(Me.uIGroupBox1)
        Me.UiTabPage6.Controls.Add(Me.Label46)
        Me.UiTabPage6.Controls.Add(Me.nebTiempoPedidos)
        Me.UiTabPage6.Controls.Add(Me.Label47)
        Me.UiTabPage6.Controls.Add(Me.GroupBox18)
        Me.UiTabPage6.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage6.Name = "UiTabPage6"
        Me.UiTabPage6.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage6.TabStop = True
        Me.UiTabPage6.Text = "Ecommerce"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.ebPaginaDpstreet)
        Me.UiGroupBox3.Controls.Add(Me.ebPaginaDportenis)
        Me.UiGroupBox3.Controls.Add(Me.Label127)
        Me.UiGroupBox3.Controls.Add(Me.Label128)
        Me.UiGroupBox3.Location = New System.Drawing.Point(373, 309)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(320, 103)
        Me.UiGroupBox3.TabIndex = 84
        Me.UiGroupBox3.Text = "Paginas Web"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ebPaginaDpstreet
        '
        Me.ebPaginaDpstreet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPaginaDpstreet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPaginaDpstreet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPaginaDpstreet.Location = New System.Drawing.Point(64, 62)
        Me.ebPaginaDpstreet.MaxLength = 0
        Me.ebPaginaDpstreet.Name = "ebPaginaDpstreet"
        Me.ebPaginaDpstreet.Size = New System.Drawing.Size(240, 26)
        Me.ebPaginaDpstreet.TabIndex = 83
        Me.ebPaginaDpstreet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPaginaDpstreet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPaginaDportenis
        '
        Me.ebPaginaDportenis.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPaginaDportenis.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPaginaDportenis.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPaginaDportenis.Location = New System.Drawing.Point(64, 26)
        Me.ebPaginaDportenis.MaxLength = 0
        Me.ebPaginaDportenis.Name = "ebPaginaDportenis"
        Me.ebPaginaDportenis.Size = New System.Drawing.Size(240, 26)
        Me.ebPaginaDportenis.TabIndex = 82
        Me.ebPaginaDportenis.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPaginaDportenis.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.BackColor = System.Drawing.Color.Transparent
        Me.Label127.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.Location = New System.Drawing.Point(8, 64)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(53, 16)
        Me.Label127.TabIndex = 49
        Me.Label127.Text = "DPStreet:"
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.BackColor = System.Drawing.Color.Transparent
        Me.Label128.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label128.Location = New System.Drawing.Point(8, 32)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(56, 16)
        Me.Label128.TabIndex = 47
        Me.Label128.Text = "Dportenis:"
        '
        'gboxLeyendaNotaVenta
        '
        Me.gboxLeyendaNotaVenta.BackColor = System.Drawing.Color.Transparent
        Me.gboxLeyendaNotaVenta.Controls.Add(Me.txtDPStreet)
        Me.gboxLeyendaNotaVenta.Controls.Add(Me.txtDportenis)
        Me.gboxLeyendaNotaVenta.Controls.Add(Me.lblDpstreet)
        Me.gboxLeyendaNotaVenta.Controls.Add(Me.lblDportenis)
        Me.gboxLeyendaNotaVenta.Location = New System.Drawing.Point(376, 200)
        Me.gboxLeyendaNotaVenta.Name = "gboxLeyendaNotaVenta"
        Me.gboxLeyendaNotaVenta.Size = New System.Drawing.Size(320, 103)
        Me.gboxLeyendaNotaVenta.TabIndex = 83
        Me.gboxLeyendaNotaVenta.Text = "Leyenda de Nota de ventas"
        Me.gboxLeyendaNotaVenta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtDPStreet
        '
        Me.txtDPStreet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDPStreet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDPStreet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDPStreet.Location = New System.Drawing.Point(64, 62)
        Me.txtDPStreet.MaxLength = 0
        Me.txtDPStreet.Name = "txtDPStreet"
        Me.txtDPStreet.Size = New System.Drawing.Size(240, 26)
        Me.txtDPStreet.TabIndex = 83
        Me.txtDPStreet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtDPStreet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtDportenis
        '
        Me.txtDportenis.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDportenis.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDportenis.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDportenis.Location = New System.Drawing.Point(64, 26)
        Me.txtDportenis.MaxLength = 0
        Me.txtDportenis.Name = "txtDportenis"
        Me.txtDportenis.Size = New System.Drawing.Size(240, 26)
        Me.txtDportenis.TabIndex = 82
        Me.txtDportenis.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtDportenis.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDpstreet
        '
        Me.lblDpstreet.AutoSize = True
        Me.lblDpstreet.BackColor = System.Drawing.Color.Transparent
        Me.lblDpstreet.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDpstreet.Location = New System.Drawing.Point(8, 64)
        Me.lblDpstreet.Name = "lblDpstreet"
        Me.lblDpstreet.Size = New System.Drawing.Size(53, 16)
        Me.lblDpstreet.TabIndex = 49
        Me.lblDpstreet.Text = "DPStreet:"
        '
        'lblDportenis
        '
        Me.lblDportenis.AutoSize = True
        Me.lblDportenis.BackColor = System.Drawing.Color.Transparent
        Me.lblDportenis.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDportenis.Location = New System.Drawing.Point(8, 32)
        Me.lblDportenis.Name = "lblDportenis"
        Me.lblDportenis.Size = New System.Drawing.Size(56, 16)
        Me.lblDportenis.TabIndex = 47
        Me.lblDportenis.Text = "Dportenis:"
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.Location = New System.Drawing.Point(272, 168)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(27, 16)
        Me.Label102.TabIndex = 79
        Me.Label102.Text = "días"
        '
        'nebDiasRecibirPago
        '
        Me.nebDiasRecibirPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasRecibirPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasRecibirPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasRecibirPago.Location = New System.Drawing.Point(224, 168)
        Me.nebDiasRecibirPago.Name = "nebDiasRecibirPago"
        Me.nebDiasRecibirPago.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasRecibirPago.TabIndex = 78
        Me.nebDiasRecibirPago.Text = "10"
        Me.nebDiasRecibirPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasRecibirPago.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasRecibirPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.Location = New System.Drawing.Point(8, 168)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(175, 16)
        Me.Label103.TabIndex = 77
        Me.Label103.Text = "Dias permitidos para pagar pedidos"
        '
        'ebNotaOPEC
        '
        Me.ebNotaOPEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNotaOPEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNotaOPEC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNotaOPEC.Location = New System.Drawing.Point(456, 104)
        Me.ebNotaOPEC.MaxLength = 0
        Me.ebNotaOPEC.Multiline = True
        Me.ebNotaOPEC.Name = "ebNotaOPEC"
        Me.ebNotaOPEC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ebNotaOPEC.Size = New System.Drawing.Size(240, 72)
        Me.ebNotaOPEC.TabIndex = 75
        Me.ebNotaOPEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNotaOPEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.Location = New System.Drawing.Point(352, 104)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(91, 16)
        Me.Label101.TabIndex = 76
        Me.Label101.Text = "Nota Otros Pagos"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(272, 144)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(27, 16)
        Me.Label58.TabIndex = 74
        Me.Label58.Text = "días"
        '
        'nebDiasEnviarEC
        '
        Me.nebDiasEnviarEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasEnviarEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasEnviarEC.Enabled = False
        Me.nebDiasEnviarEC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasEnviarEC.Location = New System.Drawing.Point(224, 144)
        Me.nebDiasEnviarEC.Name = "nebDiasEnviarEC"
        Me.nebDiasEnviarEC.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasEnviarEC.TabIndex = 73
        Me.nebDiasEnviarEC.Text = "5"
        Me.nebDiasEnviarEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasEnviarEC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasEnviarEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(8, 144)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(137, 16)
        Me.Label59.TabIndex = 72
        Me.Label59.Text = "Dias permitidos para enviar"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(272, 120)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(27, 16)
        Me.Label56.TabIndex = 71
        Me.Label56.Text = "días"
        '
        'nebDiasFacturarConcen
        '
        Me.nebDiasFacturarConcen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturarConcen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturarConcen.Enabled = False
        Me.nebDiasFacturarConcen.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasFacturarConcen.Location = New System.Drawing.Point(224, 120)
        Me.nebDiasFacturarConcen.Name = "nebDiasFacturarConcen"
        Me.nebDiasFacturarConcen.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasFacturarConcen.TabIndex = 70
        Me.nebDiasFacturarConcen.Text = "5"
        Me.nebDiasFacturarConcen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasFacturarConcen.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasFacturarConcen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(8, 120)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(210, 16)
        Me.Label57.TabIndex = 69
        Me.Label57.Text = "Dias permitidos para facturar concentración"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(272, 96)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(27, 16)
        Me.Label54.TabIndex = 68
        Me.Label54.Text = "días"
        '
        'nebDiasFacturar
        '
        Me.nebDiasFacturar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturar.Enabled = False
        Me.nebDiasFacturar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasFacturar.Location = New System.Drawing.Point(224, 96)
        Me.nebDiasFacturar.Name = "nebDiasFacturar"
        Me.nebDiasFacturar.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasFacturar.TabIndex = 67
        Me.nebDiasFacturar.Text = "5"
        Me.nebDiasFacturar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasFacturar.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasFacturar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(8, 96)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(142, 16)
        Me.Label55.TabIndex = 66
        Me.Label55.Text = "Dias permitidos para facturar"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(272, 72)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(27, 16)
        Me.Label52.TabIndex = 65
        Me.Label52.Text = "días"
        '
        'nebDiasSurtir
        '
        Me.nebDiasSurtir.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasSurtir.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasSurtir.Enabled = False
        Me.nebDiasSurtir.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasSurtir.Location = New System.Drawing.Point(224, 72)
        Me.nebDiasSurtir.Name = "nebDiasSurtir"
        Me.nebDiasSurtir.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasSurtir.TabIndex = 64
        Me.nebDiasSurtir.Text = "5"
        Me.nebDiasSurtir.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasSurtir.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasSurtir.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(8, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(130, 16)
        Me.Label53.TabIndex = 63
        Me.Label53.Text = "Dias permitidos para surtir"
        '
        'chkSurtirEC
        '
        Me.chkSurtirEC.BackColor = System.Drawing.Color.Transparent
        Me.chkSurtirEC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSurtirEC.Location = New System.Drawing.Point(8, 16)
        Me.chkSurtirEC.Name = "chkSurtirEC"
        Me.chkSurtirEC.Size = New System.Drawing.Size(149, 21)
        Me.chkSurtirEC.TabIndex = 62
        Me.chkSurtirEC.Text = "Surtido Para Ecommerce"
        Me.chkSurtirEC.UseVisualStyleBackColor = False
        '
        'uIGroupBox1
        '
        Me.uIGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.uIGroupBox1.Controls.Add(Me.nebMaximoEC)
        Me.uIGroupBox1.Controls.Add(Me.Label31)
        Me.uIGroupBox1.Controls.Add(Me.nebMinimoEC)
        Me.uIGroupBox1.Controls.Add(Me.Label30)
        Me.uIGroupBox1.Location = New System.Drawing.Point(352, 8)
        Me.uIGroupBox1.Name = "uIGroupBox1"
        Me.uIGroupBox1.Size = New System.Drawing.Size(208, 88)
        Me.uIGroupBox1.TabIndex = 61
        Me.uIGroupBox1.Text = "Rango de Folios Traspaso EC"
        Me.uIGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'nebMaximoEC
        '
        Me.nebMaximoEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebMaximoEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebMaximoEC.Location = New System.Drawing.Point(56, 56)
        Me.nebMaximoEC.Name = "nebMaximoEC"
        Me.nebMaximoEC.Size = New System.Drawing.Size(128, 26)
        Me.nebMaximoEC.TabIndex = 50
        Me.nebMaximoEC.Text = "0"
        Me.nebMaximoEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebMaximoEC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebMaximoEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 64)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 16)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Maximo"
        '
        'nebMinimoEC
        '
        Me.nebMinimoEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebMinimoEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebMinimoEC.Location = New System.Drawing.Point(56, 24)
        Me.nebMinimoEC.Name = "nebMinimoEC"
        Me.nebMinimoEC.Size = New System.Drawing.Size(128, 26)
        Me.nebMinimoEC.TabIndex = 48
        Me.nebMinimoEC.Text = "0"
        Me.nebMinimoEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebMinimoEC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebMinimoEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 32)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 16)
        Me.Label30.TabIndex = 47
        Me.Label30.Text = "Minimo"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(272, 40)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(44, 16)
        Me.Label46.TabIndex = 60
        Me.Label46.Text = "Minutos"
        '
        'nebTiempoPedidos
        '
        Me.nebTiempoPedidos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTiempoPedidos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTiempoPedidos.Enabled = False
        Me.nebTiempoPedidos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebTiempoPedidos.Location = New System.Drawing.Point(224, 40)
        Me.nebTiempoPedidos.Name = "nebTiempoPedidos"
        Me.nebTiempoPedidos.Size = New System.Drawing.Size(40, 22)
        Me.nebTiempoPedidos.TabIndex = 59
        Me.nebTiempoPedidos.Text = "5"
        Me.nebTiempoPedidos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTiempoPedidos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebTiempoPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(8, 40)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(168, 16)
        Me.Label47.TabIndex = 58
        Me.Label47.Text = "Tiempo Revisa Pedidos Por Surtir"
        '
        'GroupBox18
        '
        Me.GroupBox18.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox18.Controls.Add(Me.Label105)
        Me.GroupBox18.Controls.Add(Me.lstMailsEC)
        Me.GroupBox18.Controls.Add(Me.btnAddMailEC)
        Me.GroupBox18.Controls.Add(Me.ebMailEC)
        Me.GroupBox18.Controls.Add(Me.ebClienteEC)
        Me.GroupBox18.Controls.Add(Me.Label104)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(8, 208)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(336, 176)
        Me.GroupBox18.TabIndex = 82
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Pagos Ecommerce"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.Location = New System.Drawing.Point(8, 64)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(93, 16)
        Me.Label105.TabIndex = 82
        Me.Label105.Text = "Correos Error DZ"
        '
        'lstMailsEC
        '
        Me.lstMailsEC.ItemHeight = 20
        Me.lstMailsEC.Location = New System.Drawing.Point(8, 88)
        Me.lstMailsEC.Name = "lstMailsEC"
        Me.lstMailsEC.Size = New System.Drawing.Size(320, 84)
        Me.lstMailsEC.TabIndex = 36
        '
        'btnAddMailEC
        '
        Me.btnAddMailEC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMailEC.Location = New System.Drawing.Point(296, 56)
        Me.btnAddMailEC.Name = "btnAddMailEC"
        Me.btnAddMailEC.Size = New System.Drawing.Size(32, 24)
        Me.btnAddMailEC.TabIndex = 35
        Me.btnAddMailEC.Text = "Add"
        Me.btnAddMailEC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMailEC
        '
        Me.ebMailEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMailEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMailEC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMailEC.Location = New System.Drawing.Point(104, 56)
        Me.ebMailEC.MaxLength = 100
        Me.ebMailEC.Name = "ebMailEC"
        Me.ebMailEC.Size = New System.Drawing.Size(192, 26)
        Me.ebMailEC.TabIndex = 10
        Me.ebMailEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMailEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteEC
        '
        Me.ebClienteEC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteEC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteEC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteEC.Location = New System.Drawing.Point(104, 24)
        Me.ebClienteEC.MaxLength = 0
        Me.ebClienteEC.Name = "ebClienteEC"
        Me.ebClienteEC.Size = New System.Drawing.Size(224, 26)
        Me.ebClienteEC.TabIndex = 81
        Me.ebClienteEC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteEC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.Location = New System.Drawing.Point(8, 24)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(98, 16)
        Me.Label104.TabIndex = 80
        Me.Label104.Text = "Cliente Ecommerce"
        '
        'UiTabPage7
        '
        Me.UiTabPage7.Controls.Add(Me.GroupBox25)
        Me.UiTabPage7.Controls.Add(Me.GroupBox24)
        Me.UiTabPage7.Controls.Add(Me.GroupBox23)
        Me.UiTabPage7.Controls.Add(Me.GroupBox16)
        Me.UiTabPage7.Controls.Add(Me.GroupBox15)
        Me.UiTabPage7.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage7.Name = "UiTabPage7"
        Me.UiTabPage7.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage7.TabStop = True
        Me.UiTabPage7.Text = "Servicios Web"
        '
        'GroupBox25
        '
        Me.GroupBox25.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox25.Controls.Add(Me.chkHTTPS)
        Me.GroupBox25.Controls.Add(Me.Label142)
        Me.GroupBox25.Controls.Add(Me.ebServidorHTTPS)
        Me.GroupBox25.Controls.Add(Me.chkGeneraGuiaDHLAutomatica)
        Me.GroupBox25.Controls.Add(Me.txtRutaImagenes)
        Me.GroupBox25.Controls.Add(Me.lblRutaImagenes)
        Me.GroupBox25.Controls.Add(Me.ebURLImagenFondo)
        Me.GroupBox25.Controls.Add(Me.Label68)
        Me.GroupBox25.Controls.Add(Me.ebPassProxy)
        Me.GroupBox25.Controls.Add(Me.Label60)
        Me.GroupBox25.Controls.Add(Me.ebUserProxy)
        Me.GroupBox25.Controls.Add(Me.Label61)
        Me.GroupBox25.Controls.Add(Me.ebInternetServer)
        Me.GroupBox25.Controls.Add(Me.Label51)
        Me.GroupBox25.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(360, 194)
        Me.GroupBox25.TabIndex = 114
        Me.GroupBox25.TabStop = False
        '
        'chkHTTPS
        '
        Me.chkHTTPS.BackColor = System.Drawing.Color.Transparent
        Me.chkHTTPS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHTTPS.Location = New System.Drawing.Point(250, 171)
        Me.chkHTTPS.Name = "chkHTTPS"
        Me.chkHTTPS.Size = New System.Drawing.Size(104, 18)
        Me.chkHTTPS.TabIndex = 125
        Me.chkHTTPS.Text = "Utilizar HTTPS"
        Me.chkHTTPS.UseVisualStyleBackColor = False
        '
        'Label142
        '
        Me.Label142.AutoSize = True
        Me.Label142.BackColor = System.Drawing.Color.Transparent
        Me.Label142.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label142.Location = New System.Drawing.Point(8, 47)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(88, 16)
        Me.Label142.TabIndex = 124
        Me.Label142.Text = "Servidor HTTPS"
        '
        'ebServidorHTTPS
        '
        Me.ebServidorHTTPS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServidorHTTPS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServidorHTTPS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServidorHTTPS.Location = New System.Drawing.Point(128, 47)
        Me.ebServidorHTTPS.MaxLength = 100
        Me.ebServidorHTTPS.Name = "ebServidorHTTPS"
        Me.ebServidorHTTPS.Size = New System.Drawing.Size(226, 22)
        Me.ebServidorHTTPS.TabIndex = 123
        Me.ebServidorHTTPS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorHTTPS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkGeneraGuiaDHLAutomatica
        '
        Me.chkGeneraGuiaDHLAutomatica.BackColor = System.Drawing.Color.Transparent
        Me.chkGeneraGuiaDHLAutomatica.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGeneraGuiaDHLAutomatica.Location = New System.Drawing.Point(8, 169)
        Me.chkGeneraGuiaDHLAutomatica.Name = "chkGeneraGuiaDHLAutomatica"
        Me.chkGeneraGuiaDHLAutomatica.Size = New System.Drawing.Size(176, 18)
        Me.chkGeneraGuiaDHLAutomatica.TabIndex = 122
        Me.chkGeneraGuiaDHLAutomatica.Text = "Generar Guia DHL Automatica"
        Me.chkGeneraGuiaDHLAutomatica.UseVisualStyleBackColor = False
        '
        'txtRutaImagenes
        '
        Me.txtRutaImagenes.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtRutaImagenes.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtRutaImagenes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaImagenes.Location = New System.Drawing.Point(128, 143)
        Me.txtRutaImagenes.MaxLength = 100
        Me.txtRutaImagenes.Name = "txtRutaImagenes"
        Me.txtRutaImagenes.Size = New System.Drawing.Size(226, 22)
        Me.txtRutaImagenes.TabIndex = 121
        Me.txtRutaImagenes.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtRutaImagenes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblRutaImagenes
        '
        Me.lblRutaImagenes.AutoSize = True
        Me.lblRutaImagenes.BackColor = System.Drawing.Color.Transparent
        Me.lblRutaImagenes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaImagenes.Location = New System.Drawing.Point(8, 143)
        Me.lblRutaImagenes.Name = "lblRutaImagenes"
        Me.lblRutaImagenes.Size = New System.Drawing.Size(79, 16)
        Me.lblRutaImagenes.TabIndex = 120
        Me.lblRutaImagenes.Text = "Ruta Imagenes"
        '
        'ebURLImagenFondo
        '
        Me.ebURLImagenFondo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebURLImagenFondo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebURLImagenFondo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebURLImagenFondo.Location = New System.Drawing.Point(128, 119)
        Me.ebURLImagenFondo.MaxLength = 100
        Me.ebURLImagenFondo.Name = "ebURLImagenFondo"
        Me.ebURLImagenFondo.Size = New System.Drawing.Size(226, 22)
        Me.ebURLImagenFondo.TabIndex = 118
        Me.ebURLImagenFondo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebURLImagenFondo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(8, 119)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(102, 16)
        Me.Label68.TabIndex = 119
        Me.Label68.Text = "URL Imagen Fondo"
        '
        'ebPassProxy
        '
        Me.ebPassProxy.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassProxy.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassProxy.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassProxy.Location = New System.Drawing.Point(128, 95)
        Me.ebPassProxy.Name = "ebPassProxy"
        Me.ebPassProxy.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassProxy.Size = New System.Drawing.Size(136, 22)
        Me.ebPassProxy.TabIndex = 117
        Me.ebPassProxy.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassProxy.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(8, 95)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(87, 16)
        Me.Label60.TabIndex = 116
        Me.Label60.Text = "Password Proxy"
        '
        'ebUserProxy
        '
        Me.ebUserProxy.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserProxy.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserProxy.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserProxy.Location = New System.Drawing.Point(128, 71)
        Me.ebUserProxy.Name = "ebUserProxy"
        Me.ebUserProxy.Size = New System.Drawing.Size(136, 22)
        Me.ebUserProxy.TabIndex = 115
        Me.ebUserProxy.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserProxy.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(8, 71)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(77, 16)
        Me.Label61.TabIndex = 114
        Me.Label61.Text = "Usuario Proxy"
        '
        'ebInternetServer
        '
        Me.ebInternetServer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebInternetServer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebInternetServer.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebInternetServer.Location = New System.Drawing.Point(128, 23)
        Me.ebInternetServer.MaxLength = 100
        Me.ebInternetServer.Name = "ebInternetServer"
        Me.ebInternetServer.Size = New System.Drawing.Size(226, 22)
        Me.ebInternetServer.TabIndex = 112
        Me.ebInternetServer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebInternetServer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(8, 23)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(73, 16)
        Me.Label51.TabIndex = 113
        Me.Label51.Text = "Servidor Web"
        '
        'GroupBox24
        '
        Me.GroupBox24.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox24.Controls.Add(Me.Label126)
        Me.GroupBox24.Controls.Add(Me.ebLimiteTiempoLentitud)
        Me.GroupBox24.Controls.Add(Me.Label125)
        Me.GroupBox24.Controls.Add(Me.chkGenerarLogTransacciones)
        Me.GroupBox24.Controls.Add(Me.lstMailsLentitud)
        Me.GroupBox24.Controls.Add(Me.btnAddMailTimeout)
        Me.GroupBox24.Controls.Add(Me.ebCorreoTimeout)
        Me.GroupBox24.Controls.Add(Me.Label124)
        Me.GroupBox24.Controls.Add(Me.chkEnviarCorreoLentitud)
        Me.GroupBox24.Location = New System.Drawing.Point(5, 207)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(362, 211)
        Me.GroupBox24.TabIndex = 113
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Configuración de Log de Transacciones"
        '
        'Label126
        '
        Me.Label126.AutoSize = True
        Me.Label126.BackColor = System.Drawing.Color.Transparent
        Me.Label126.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label126.Location = New System.Drawing.Point(190, 82)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(66, 16)
        Me.Label126.TabIndex = 132
        Me.Label126.Text = "Segundos"
        '
        'ebLimiteTiempoLentitud
        '
        Me.ebLimiteTiempoLentitud.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLimiteTiempoLentitud.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLimiteTiempoLentitud.Enabled = False
        Me.ebLimiteTiempoLentitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLimiteTiempoLentitud.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebLimiteTiempoLentitud.Location = New System.Drawing.Point(128, 80)
        Me.ebLimiteTiempoLentitud.Name = "ebLimiteTiempoLentitud"
        Me.ebLimiteTiempoLentitud.Size = New System.Drawing.Size(56, 22)
        Me.ebLimiteTiempoLentitud.TabIndex = 131
        Me.ebLimiteTiempoLentitud.Text = "120"
        Me.ebLimiteTiempoLentitud.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebLimiteTiempoLentitud.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebLimiteTiempoLentitud.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label125
        '
        Me.Label125.AutoSize = True
        Me.Label125.BackColor = System.Drawing.Color.Transparent
        Me.Label125.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label125.Location = New System.Drawing.Point(10, 82)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(93, 16)
        Me.Label125.TabIndex = 130
        Me.Label125.Text = "Tiempo Limite:"
        '
        'chkGenerarLogTransacciones
        '
        Me.chkGenerarLogTransacciones.AutoSize = True
        Me.chkGenerarLogTransacciones.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.chkGenerarLogTransacciones.Location = New System.Drawing.Point(8, 32)
        Me.chkGenerarLogTransacciones.Name = "chkGenerarLogTransacciones"
        Me.chkGenerarLogTransacciones.Size = New System.Drawing.Size(266, 20)
        Me.chkGenerarLogTransacciones.TabIndex = 75
        Me.chkGenerarLogTransacciones.Text = "Generar Log de Transacciones BUS/SAP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lstMailsLentitud
        '
        Me.lstMailsLentitud.Enabled = False
        Me.lstMailsLentitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lstMailsLentitud.ItemHeight = 16
        Me.lstMailsLentitud.Location = New System.Drawing.Point(10, 133)
        Me.lstMailsLentitud.Name = "lstMailsLentitud"
        Me.lstMailsLentitud.Size = New System.Drawing.Size(346, 68)
        Me.lstMailsLentitud.TabIndex = 74
        '
        'btnAddMailTimeout
        '
        Me.btnAddMailTimeout.Enabled = False
        Me.btnAddMailTimeout.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMailTimeout.Location = New System.Drawing.Point(322, 105)
        Me.btnAddMailTimeout.Name = "btnAddMailTimeout"
        Me.btnAddMailTimeout.Size = New System.Drawing.Size(32, 22)
        Me.btnAddMailTimeout.TabIndex = 73
        Me.btnAddMailTimeout.Text = "Add"
        Me.btnAddMailTimeout.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCorreoTimeout
        '
        Me.ebCorreoTimeout.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorreoTimeout.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorreoTimeout.ButtonFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCorreoTimeout.Enabled = False
        Me.ebCorreoTimeout.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.ebCorreoTimeout.Location = New System.Drawing.Point(128, 105)
        Me.ebCorreoTimeout.MaxLength = 100
        Me.ebCorreoTimeout.Name = "ebCorreoTimeout"
        Me.ebCorreoTimeout.Size = New System.Drawing.Size(190, 22)
        Me.ebCorreoTimeout.TabIndex = 71
        Me.ebCorreoTimeout.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorreoTimeout.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.BackColor = System.Drawing.Color.Transparent
        Me.Label124.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label124.Location = New System.Drawing.Point(10, 107)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(113, 16)
        Me.Label124.TabIndex = 72
        Me.Label124.Text = "Cuenta de Correo:"
        '
        'chkEnviarCorreoLentitud
        '
        Me.chkEnviarCorreoLentitud.AutoSize = True
        Me.chkEnviarCorreoLentitud.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnviarCorreoLentitud.Location = New System.Drawing.Point(8, 58)
        Me.chkEnviarCorreoLentitud.Name = "chkEnviarCorreoLentitud"
        Me.chkEnviarCorreoLentitud.Size = New System.Drawing.Size(172, 20)
        Me.chkEnviarCorreoLentitud.TabIndex = 70
        Me.chkEnviarCorreoLentitud.Text = "Enviar Correo de Lentitud"
        '
        'GroupBox23
        '
        Me.GroupBox23.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox23.Controls.Add(Me.ebPassFtpBroker)
        Me.GroupBox23.Controls.Add(Me.Label96)
        Me.GroupBox23.Controls.Add(Me.ebUserFTPBroker)
        Me.GroupBox23.Controls.Add(Me.Label95)
        Me.GroupBox23.Controls.Add(Me.ebFTPBroker)
        Me.GroupBox23.Controls.Add(Me.Label94)
        Me.GroupBox23.Location = New System.Drawing.Point(373, 320)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(328, 98)
        Me.GroupBox23.TabIndex = 112
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "Descargas PDFs"
        '
        'ebPassFtpBroker
        '
        Me.ebPassFtpBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassFtpBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassFtpBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassFtpBroker.Location = New System.Drawing.Point(90, 70)
        Me.ebPassFtpBroker.MaxLength = 0
        Me.ebPassFtpBroker.Name = "ebPassFtpBroker"
        Me.ebPassFtpBroker.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassFtpBroker.Size = New System.Drawing.Size(112, 22)
        Me.ebPassFtpBroker.TabIndex = 122
        Me.ebPassFtpBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassFtpBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.Location = New System.Drawing.Point(10, 70)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(79, 16)
        Me.Label96.TabIndex = 123
        Me.Label96.Text = "Password FTP"
        '
        'ebUserFTPBroker
        '
        Me.ebUserFTPBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserFTPBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserFTPBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserFTPBroker.Location = New System.Drawing.Point(90, 46)
        Me.ebUserFTPBroker.MaxLength = 0
        Me.ebUserFTPBroker.Name = "ebUserFTPBroker"
        Me.ebUserFTPBroker.Size = New System.Drawing.Size(112, 22)
        Me.ebUserFTPBroker.TabIndex = 120
        Me.ebUserFTPBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserFTPBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(10, 46)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(69, 16)
        Me.Label95.TabIndex = 121
        Me.Label95.Text = "Usuario FTP"
        '
        'ebFTPBroker
        '
        Me.ebFTPBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFTPBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFTPBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFTPBroker.Location = New System.Drawing.Point(90, 22)
        Me.ebFTPBroker.MaxLength = 0
        Me.ebFTPBroker.Name = "ebFTPBroker"
        Me.ebFTPBroker.Size = New System.Drawing.Size(224, 22)
        Me.ebFTPBroker.TabIndex = 118
        Me.ebFTPBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFTPBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.BackColor = System.Drawing.Color.Transparent
        Me.Label94.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(10, 22)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(54, 16)
        Me.Label94.TabIndex = 119
        Me.Label94.Text = "Ruta FTP"
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox16.Controls.Add(Me.nebPuertoREST)
        Me.GroupBox16.Controls.Add(Me.Label122)
        Me.GroupBox16.Controls.Add(Me.ebServidorREST)
        Me.GroupBox16.Controls.Add(Me.Label123)
        Me.GroupBox16.Controls.Add(Me.nebPuertoBrokerNew)
        Me.GroupBox16.Controls.Add(Me.Label120)
        Me.GroupBox16.Controls.Add(Me.ebServerBrokerNew)
        Me.GroupBox16.Controls.Add(Me.Label121)
        Me.GroupBox16.Controls.Add(Me.nebPuertoBroker)
        Me.GroupBox16.Controls.Add(Me.Label97)
        Me.GroupBox16.Controls.Add(Me.ebServerBroker)
        Me.GroupBox16.Controls.Add(Me.Label98)
        Me.GroupBox16.Location = New System.Drawing.Point(373, 7)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(328, 177)
        Me.GroupBox16.TabIndex = 109
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Configuración Broker"
        '
        'nebPuertoREST
        '
        Me.nebPuertoREST.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPuertoREST.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPuertoREST.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebPuertoREST.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebPuertoREST.Location = New System.Drawing.Point(126, 145)
        Me.nebPuertoREST.Name = "nebPuertoREST"
        Me.nebPuertoREST.Size = New System.Drawing.Size(40, 22)
        Me.nebPuertoREST.TabIndex = 125
        Me.nebPuertoREST.Text = "0"
        Me.nebPuertoREST.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPuertoREST.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPuertoREST.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.BackColor = System.Drawing.Color.Transparent
        Me.Label122.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.Location = New System.Drawing.Point(6, 145)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(71, 16)
        Me.Label122.TabIndex = 124
        Me.Label122.Text = "Puerto REST"
        '
        'ebServidorREST
        '
        Me.ebServidorREST.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServidorREST.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServidorREST.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServidorREST.Location = New System.Drawing.Point(126, 121)
        Me.ebServidorREST.MaxLength = 0
        Me.ebServidorREST.Name = "ebServidorREST"
        Me.ebServidorREST.Size = New System.Drawing.Size(196, 22)
        Me.ebServidorREST.TabIndex = 122
        Me.ebServidorREST.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorREST.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.BackColor = System.Drawing.Color.Transparent
        Me.Label123.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.Location = New System.Drawing.Point(6, 121)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(116, 16)
        Me.Label123.TabIndex = 123
        Me.Label123.Text = "Servidor Broker REST"
        '
        'nebPuertoBrokerNew
        '
        Me.nebPuertoBrokerNew.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPuertoBrokerNew.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPuertoBrokerNew.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebPuertoBrokerNew.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebPuertoBrokerNew.Location = New System.Drawing.Point(126, 96)
        Me.nebPuertoBrokerNew.Name = "nebPuertoBrokerNew"
        Me.nebPuertoBrokerNew.Size = New System.Drawing.Size(40, 22)
        Me.nebPuertoBrokerNew.TabIndex = 121
        Me.nebPuertoBrokerNew.Text = "0"
        Me.nebPuertoBrokerNew.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPuertoBrokerNew.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPuertoBrokerNew.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.BackColor = System.Drawing.Color.Transparent
        Me.Label120.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label120.Location = New System.Drawing.Point(6, 96)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(48, 16)
        Me.Label120.TabIndex = 120
        Me.Label120.Text = "Puerto 2"
        '
        'ebServerBrokerNew
        '
        Me.ebServerBrokerNew.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServerBrokerNew.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServerBrokerNew.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServerBrokerNew.Location = New System.Drawing.Point(126, 72)
        Me.ebServerBrokerNew.MaxLength = 0
        Me.ebServerBrokerNew.Name = "ebServerBrokerNew"
        Me.ebServerBrokerNew.Size = New System.Drawing.Size(196, 22)
        Me.ebServerBrokerNew.TabIndex = 118
        Me.ebServerBrokerNew.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServerBrokerNew.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.BackColor = System.Drawing.Color.Transparent
        Me.Label121.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label121.Location = New System.Drawing.Point(6, 72)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(93, 16)
        Me.Label121.TabIndex = 119
        Me.Label121.Text = "Servidor Broker 2"
        '
        'nebPuertoBroker
        '
        Me.nebPuertoBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPuertoBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPuertoBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebPuertoBroker.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebPuertoBroker.Location = New System.Drawing.Point(126, 47)
        Me.nebPuertoBroker.Name = "nebPuertoBroker"
        Me.nebPuertoBroker.Size = New System.Drawing.Size(40, 22)
        Me.nebPuertoBroker.TabIndex = 111
        Me.nebPuertoBroker.Text = "0"
        Me.nebPuertoBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPuertoBroker.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPuertoBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.Location = New System.Drawing.Point(6, 47)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(39, 16)
        Me.Label97.TabIndex = 110
        Me.Label97.Text = "Puerto"
        '
        'ebServerBroker
        '
        Me.ebServerBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServerBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServerBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServerBroker.Location = New System.Drawing.Point(126, 23)
        Me.ebServerBroker.MaxLength = 0
        Me.ebServerBroker.Name = "ebServerBroker"
        Me.ebServerBroker.Size = New System.Drawing.Size(196, 22)
        Me.ebServerBroker.TabIndex = 108
        Me.ebServerBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServerBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.BackColor = System.Drawing.Color.Transparent
        Me.Label98.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(6, 23)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(84, 16)
        Me.Label98.TabIndex = 109
        Me.Label98.Text = "Servidor Broker"
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox15.Controls.Add(Me.cmbServerBroker)
        Me.GroupBox15.Controls.Add(Me.ebUserBroker)
        Me.GroupBox15.Controls.Add(Me.btnProbarBroker)
        Me.GroupBox15.Controls.Add(Me.ebBaseDatosBroker)
        Me.GroupBox15.Controls.Add(Me.Label71)
        Me.GroupBox15.Controls.Add(Me.ebPasswordBroker)
        Me.GroupBox15.Controls.Add(Me.Label72)
        Me.GroupBox15.Controls.Add(Me.Label73)
        Me.GroupBox15.Controls.Add(Me.Label74)
        Me.GroupBox15.Controls.Add(Me.pbBroker)
        Me.GroupBox15.Location = New System.Drawing.Point(375, 187)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(326, 127)
        Me.GroupBox15.TabIndex = 101
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Configuración BD Broker"
        '
        'cmbServerBroker
        '
        Me.cmbServerBroker.Location = New System.Drawing.Point(88, 28)
        Me.cmbServerBroker.Name = "cmbServerBroker"
        Me.cmbServerBroker.Size = New System.Drawing.Size(144, 26)
        Me.cmbServerBroker.TabIndex = 12
        Me.cmbServerBroker.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserBroker
        '
        Me.ebUserBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserBroker.Location = New System.Drawing.Point(88, 80)
        Me.ebUserBroker.MaxLength = 30
        Me.ebUserBroker.Name = "ebUserBroker"
        Me.ebUserBroker.Size = New System.Drawing.Size(144, 22)
        Me.ebUserBroker.TabIndex = 14
        Me.ebUserBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarBroker
        '
        Me.btnProbarBroker.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarBroker.Location = New System.Drawing.Point(256, 96)
        Me.btnProbarBroker.Name = "btnProbarBroker"
        Me.btnProbarBroker.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarBroker.TabIndex = 4
        Me.btnProbarBroker.Text = "Probar"
        Me.btnProbarBroker.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebBaseDatosBroker
        '
        Me.ebBaseDatosBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosBroker.Location = New System.Drawing.Point(88, 56)
        Me.ebBaseDatosBroker.MaxLength = 50
        Me.ebBaseDatosBroker.Name = "ebBaseDatosBroker"
        Me.ebBaseDatosBroker.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosBroker.TabIndex = 13
        Me.ebBaseDatosBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(8, 56)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(77, 16)
        Me.Label71.TabIndex = 27
        Me.Label71.Text = "Base de Datos"
        '
        'ebPasswordBroker
        '
        Me.ebPasswordBroker.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordBroker.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordBroker.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordBroker.Location = New System.Drawing.Point(88, 104)
        Me.ebPasswordBroker.MaxLength = 30
        Me.ebPasswordBroker.Name = "ebPasswordBroker"
        Me.ebPasswordBroker.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordBroker.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordBroker.TabIndex = 15
        Me.ebPasswordBroker.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordBroker.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(8, 104)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(55, 16)
        Me.Label72.TabIndex = 26
        Me.Label72.Text = "Password"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(8, 32)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(49, 16)
        Me.Label73.TabIndex = 24
        Me.Label73.Text = "Servidor"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(8, 80)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(45, 16)
        Me.Label74.TabIndex = 25
        Me.Label74.Text = "Usuario"
        '
        'pbBroker
        '
        Me.pbBroker.BackColor = System.Drawing.Color.Transparent
        Me.pbBroker.Location = New System.Drawing.Point(264, 40)
        Me.pbBroker.Name = "pbBroker"
        Me.pbBroker.Size = New System.Drawing.Size(32, 32)
        Me.pbBroker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBroker.TabIndex = 29
        Me.pbBroker.TabStop = False
        '
        'UiTabPage8
        '
        Me.UiTabPage8.Controls.Add(Me.chkValidarMatExt)
        Me.UiTabPage8.Controls.Add(Me.chkTodosArticulosSH)
        Me.UiTabPage8.Controls.Add(Me.chkArticuloCatalogoSH)
        Me.UiTabPage8.Controls.Add(Me.Label90)
        Me.UiTabPage8.Controls.Add(Me.nebDiasInsurtiblesSH)
        Me.UiTabPage8.Controls.Add(Me.Label91)
        Me.UiTabPage8.Controls.Add(Me.nebDiasCancelarSH)
        Me.UiTabPage8.Controls.Add(Me.Label89)
        Me.UiTabPage8.Controls.Add(Me.Label88)
        Me.UiTabPage8.Controls.Add(Me.UiGroupBox2)
        Me.UiTabPage8.Controls.Add(Me.Label80)
        Me.UiTabPage8.Controls.Add(Me.nebDiasFacturarSH)
        Me.UiTabPage8.Controls.Add(Me.Label81)
        Me.UiTabPage8.Controls.Add(Me.Label82)
        Me.UiTabPage8.Controls.Add(Me.nebDiasRecibirSH)
        Me.UiTabPage8.Controls.Add(Me.Label83)
        Me.UiTabPage8.Controls.Add(Me.Label84)
        Me.UiTabPage8.Controls.Add(Me.nebDiasSinGuiaSH)
        Me.UiTabPage8.Controls.Add(Me.Label85)
        Me.UiTabPage8.Controls.Add(Me.Label86)
        Me.UiTabPage8.Controls.Add(Me.nebDiasSurtirSH)
        Me.UiTabPage8.Controls.Add(Me.Label87)
        Me.UiTabPage8.Controls.Add(Me.cbDevolverEfectivoSH)
        Me.UiTabPage8.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage8.Name = "UiTabPage8"
        Me.UiTabPage8.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage8.TabStop = True
        Me.UiTabPage8.Text = "Si Hay"
        '
        'chkValidarMatExt
        '
        Me.chkValidarMatExt.AutoSize = True
        Me.chkValidarMatExt.BackColor = System.Drawing.Color.Transparent
        Me.chkValidarMatExt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValidarMatExt.Location = New System.Drawing.Point(8, 214)
        Me.chkValidarMatExt.Name = "chkValidarMatExt"
        Me.chkValidarMatExt.Size = New System.Drawing.Size(210, 20)
        Me.chkValidarMatExt.TabIndex = 129
        Me.chkValidarMatExt.Text = "Validar materiales extendidos en tienda"
        Me.chkValidarMatExt.UseVisualStyleBackColor = False
        '
        'chkTodosArticulosSH
        '
        Me.chkTodosArticulosSH.AutoSize = True
        Me.chkTodosArticulosSH.BackColor = System.Drawing.Color.Transparent
        Me.chkTodosArticulosSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosArticulosSH.Location = New System.Drawing.Point(352, 167)
        Me.chkTodosArticulosSH.Name = "chkTodosArticulosSH"
        Me.chkTodosArticulosSH.Size = New System.Drawing.Size(164, 20)
        Me.chkTodosArticulosSH.TabIndex = 128
        Me.chkTodosArticulosSH.Text = "Validar todos los Artículos SH"
        Me.chkTodosArticulosSH.UseVisualStyleBackColor = False
        '
        'chkArticuloCatalogoSH
        '
        Me.chkArticuloCatalogoSH.AutoSize = True
        Me.chkArticuloCatalogoSH.BackColor = System.Drawing.Color.Transparent
        Me.chkArticuloCatalogoSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArticuloCatalogoSH.Location = New System.Drawing.Point(352, 143)
        Me.chkArticuloCatalogoSH.Name = "chkArticuloCatalogoSH"
        Me.chkArticuloCatalogoSH.Size = New System.Drawing.Size(175, 20)
        Me.chkArticuloCatalogoSH.TabIndex = 127
        Me.chkArticuloCatalogoSH.Text = "Validar Artículo de Catalogo SH"
        Me.chkArticuloCatalogoSH.UseVisualStyleBackColor = False
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.Location = New System.Drawing.Point(288, 168)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(27, 16)
        Me.Label90.TabIndex = 125
        Me.Label90.Text = "días"
        '
        'nebDiasInsurtiblesSH
        '
        Me.nebDiasInsurtiblesSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasInsurtiblesSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasInsurtiblesSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasInsurtiblesSH.Location = New System.Drawing.Point(240, 168)
        Me.nebDiasInsurtiblesSH.Name = "nebDiasInsurtiblesSH"
        Me.nebDiasInsurtiblesSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasInsurtiblesSH.TabIndex = 124
        Me.nebDiasInsurtiblesSH.Text = "5"
        Me.nebDiasInsurtiblesSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasInsurtiblesSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasInsurtiblesSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.BackColor = System.Drawing.Color.Transparent
        Me.Label91.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.Location = New System.Drawing.Point(288, 144)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(27, 16)
        Me.Label91.TabIndex = 123
        Me.Label91.Text = "días"
        '
        'nebDiasCancelarSH
        '
        Me.nebDiasCancelarSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasCancelarSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasCancelarSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasCancelarSH.Location = New System.Drawing.Point(240, 144)
        Me.nebDiasCancelarSH.Name = "nebDiasCancelarSH"
        Me.nebDiasCancelarSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasCancelarSH.TabIndex = 122
        Me.nebDiasCancelarSH.Text = "5"
        Me.nebDiasCancelarSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasCancelarSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasCancelarSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(8, 168)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(218, 16)
        Me.Label89.TabIndex = 121
        Me.Label89.Text = "Dias permitidos para reembolsar (Insurtibles)"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(8, 120)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(142, 16)
        Me.Label88.TabIndex = 120
        Me.Label88.Text = "Dias permitidos para facturar"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.Label78)
        Me.UiGroupBox2.Controls.Add(Me.nebDiasPostergarCita)
        Me.UiGroupBox2.Controls.Add(Me.Label79)
        Me.UiGroupBox2.Controls.Add(Me.Label76)
        Me.UiGroupBox2.Controls.Add(Me.nebDiasRecogerReembolso)
        Me.UiGroupBox2.Controls.Add(Me.Label77)
        Me.UiGroupBox2.Location = New System.Drawing.Point(352, 8)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(336, 120)
        Me.UiGroupBox2.TabIndex = 119
        Me.UiGroupBox2.Text = "Concretar Cita"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(287, 80)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(27, 16)
        Me.Label78.TabIndex = 86
        Me.Label78.Text = "días"
        '
        'nebDiasPostergarCita
        '
        Me.nebDiasPostergarCita.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasPostergarCita.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasPostergarCita.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasPostergarCita.Location = New System.Drawing.Point(239, 80)
        Me.nebDiasPostergarCita.Name = "nebDiasPostergarCita"
        Me.nebDiasPostergarCita.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasPostergarCita.TabIndex = 85
        Me.nebDiasPostergarCita.Text = "20"
        Me.nebDiasPostergarCita.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasPostergarCita.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasPostergarCita.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(23, 80)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(199, 16)
        Me.Label79.TabIndex = 84
        Me.Label79.Text = "Dias limite para postergar fecha de la cita"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.BackColor = System.Drawing.Color.Transparent
        Me.Label76.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(287, 40)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(27, 16)
        Me.Label76.TabIndex = 83
        Me.Label76.Text = "días"
        '
        'nebDiasRecogerReembolso
        '
        Me.nebDiasRecogerReembolso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasRecogerReembolso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasRecogerReembolso.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasRecogerReembolso.Location = New System.Drawing.Point(239, 40)
        Me.nebDiasRecogerReembolso.Name = "nebDiasRecogerReembolso"
        Me.nebDiasRecogerReembolso.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasRecogerReembolso.TabIndex = 82
        Me.nebDiasRecogerReembolso.Text = "6"
        Me.nebDiasRecogerReembolso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasRecogerReembolso.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasRecogerReembolso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(23, 40)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(150, 16)
        Me.Label77.TabIndex = 81
        Me.Label77.Text = "Dias para recoger Reembolso"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(288, 120)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(27, 16)
        Me.Label80.TabIndex = 118
        Me.Label80.Text = "días"
        '
        'nebDiasFacturarSH
        '
        Me.nebDiasFacturarSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturarSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasFacturarSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasFacturarSH.Location = New System.Drawing.Point(240, 120)
        Me.nebDiasFacturarSH.Name = "nebDiasFacturarSH"
        Me.nebDiasFacturarSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasFacturarSH.TabIndex = 117
        Me.nebDiasFacturarSH.Text = "5"
        Me.nebDiasFacturarSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasFacturarSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasFacturarSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.Location = New System.Drawing.Point(8, 72)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(188, 16)
        Me.Label81.TabIndex = 116
        Me.Label81.Text = "Dias permitidos para enviar (Sin Guia)"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(288, 96)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(27, 16)
        Me.Label82.TabIndex = 115
        Me.Label82.Text = "días"
        '
        'nebDiasRecibirSH
        '
        Me.nebDiasRecibirSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasRecibirSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasRecibirSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasRecibirSH.Location = New System.Drawing.Point(240, 96)
        Me.nebDiasRecibirSH.Name = "nebDiasRecibirSH"
        Me.nebDiasRecibirSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasRecibirSH.TabIndex = 114
        Me.nebDiasRecibirSH.Text = "5"
        Me.nebDiasRecibirSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasRecibirSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasRecibirSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.Location = New System.Drawing.Point(8, 96)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(136, 16)
        Me.Label83.TabIndex = 113
        Me.Label83.Text = "Dias permitidos para recibir"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.Location = New System.Drawing.Point(288, 72)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(27, 16)
        Me.Label84.TabIndex = 112
        Me.Label84.Text = "días"
        '
        'nebDiasSinGuiaSH
        '
        Me.nebDiasSinGuiaSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasSinGuiaSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasSinGuiaSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasSinGuiaSH.Location = New System.Drawing.Point(240, 72)
        Me.nebDiasSinGuiaSH.Name = "nebDiasSinGuiaSH"
        Me.nebDiasSinGuiaSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasSinGuiaSH.TabIndex = 111
        Me.nebDiasSinGuiaSH.Text = "5"
        Me.nebDiasSinGuiaSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasSinGuiaSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasSinGuiaSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(8, 144)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(147, 16)
        Me.Label85.TabIndex = 110
        Me.Label85.Text = "Dias permitidos para cancelar"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(288, 48)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(27, 16)
        Me.Label86.TabIndex = 109
        Me.Label86.Text = "días"
        '
        'nebDiasSurtirSH
        '
        Me.nebDiasSurtirSH.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDiasSurtirSH.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDiasSurtirSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebDiasSurtirSH.Location = New System.Drawing.Point(240, 48)
        Me.nebDiasSurtirSH.Name = "nebDiasSurtirSH"
        Me.nebDiasSurtirSH.Size = New System.Drawing.Size(40, 22)
        Me.nebDiasSurtirSH.TabIndex = 108
        Me.nebDiasSurtirSH.Text = "5"
        Me.nebDiasSurtirSH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebDiasSurtirSH.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDiasSurtirSH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(8, 48)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(130, 16)
        Me.Label87.TabIndex = 107
        Me.Label87.Text = "Dias permitidos para surtir"
        '
        'cbDevolverEfectivoSH
        '
        Me.cbDevolverEfectivoSH.BackColor = System.Drawing.Color.Transparent
        Me.cbDevolverEfectivoSH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDevolverEfectivoSH.ForeColor = System.Drawing.Color.Black
        Me.cbDevolverEfectivoSH.Location = New System.Drawing.Point(8, 16)
        Me.cbDevolverEfectivoSH.Name = "cbDevolverEfectivoSH"
        Me.cbDevolverEfectivoSH.Size = New System.Drawing.Size(200, 29)
        Me.cbDevolverEfectivoSH.TabIndex = 103
        Me.cbDevolverEfectivoSH.Text = "Devolución Total de Efectivo"
        Me.cbDevolverEfectivoSH.UseVisualStyleBackColor = False
        '
        'UiTabPage10
        '
        Me.UiTabPage10.Controls.Add(Me.uiAlmaecenamientoDatos)
        Me.UiTabPage10.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage10.Name = "UiTabPage10"
        Me.UiTabPage10.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage10.TabStop = True
        Me.UiTabPage10.Text = "DP Card"
        '
        'uiAlmaecenamientoDatos
        '
        Me.uiAlmaecenamientoDatos.FirstTabOffset = 3
        Me.uiAlmaecenamientoDatos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uiAlmaecenamientoDatos.Location = New System.Drawing.Point(-1, 0)
        Me.uiAlmaecenamientoDatos.Name = "uiAlmaecenamientoDatos"
        Me.uiAlmaecenamientoDatos.Size = New System.Drawing.Size(706, 421)
        Me.uiAlmaecenamientoDatos.TabIndex = 133
        Me.uiAlmaecenamientoDatos.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.uitSqlServer, Me.uitNetezza})
        Me.uiAlmaecenamientoDatos.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'uitSqlServer
        '
        Me.uitSqlServer.Controls.Add(Me.GroupBox36)
        Me.uitSqlServer.Controls.Add(Me.GroupBox19)
        Me.uitSqlServer.Location = New System.Drawing.Point(1, 22)
        Me.uitSqlServer.Name = "uitSqlServer"
        Me.uitSqlServer.Size = New System.Drawing.Size(704, 398)
        Me.uitSqlServer.TabStop = True
        Me.uitSqlServer.Text = "SQL SERVER"
        '
        'GroupBox36
        '
        Me.GroupBox36.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox36.Controls.Add(Me.cmbServerBlue)
        Me.GroupBox36.Controls.Add(Me.ebUserBlue)
        Me.GroupBox36.Controls.Add(Me.btnProbarBlue)
        Me.GroupBox36.Controls.Add(Me.ebBaseDatosBlue)
        Me.GroupBox36.Controls.Add(Me.Label144)
        Me.GroupBox36.Controls.Add(Me.ebPasswordBlue)
        Me.GroupBox36.Controls.Add(Me.Label145)
        Me.GroupBox36.Controls.Add(Me.Label146)
        Me.GroupBox36.Controls.Add(Me.Label147)
        Me.GroupBox36.Controls.Add(Me.pbBlue)
        Me.GroupBox36.Location = New System.Drawing.Point(369, 23)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox36.TabIndex = 46
        Me.GroupBox36.TabStop = False
        Me.GroupBox36.Text = "Configuración Promociones DP Card Blue"
        '
        'cmbServerBlue
        '
        Me.cmbServerBlue.Location = New System.Drawing.Point(96, 27)
        Me.cmbServerBlue.Name = "cmbServerBlue"
        Me.cmbServerBlue.Size = New System.Drawing.Size(144, 22)
        Me.cmbServerBlue.TabIndex = 31
        Me.cmbServerBlue.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserBlue
        '
        Me.ebUserBlue.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserBlue.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserBlue.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserBlue.Location = New System.Drawing.Point(96, 80)
        Me.ebUserBlue.MaxLength = 30
        Me.ebUserBlue.Name = "ebUserBlue"
        Me.ebUserBlue.Size = New System.Drawing.Size(144, 22)
        Me.ebUserBlue.TabIndex = 33
        Me.ebUserBlue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserBlue.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarBlue
        '
        Me.btnProbarBlue.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarBlue.Location = New System.Drawing.Point(280, 96)
        Me.btnProbarBlue.Name = "btnProbarBlue"
        Me.btnProbarBlue.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarBlue.TabIndex = 30
        Me.btnProbarBlue.Text = "Probar"
        '
        'ebBaseDatosBlue
        '
        Me.ebBaseDatosBlue.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosBlue.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosBlue.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosBlue.Location = New System.Drawing.Point(96, 56)
        Me.ebBaseDatosBlue.MaxLength = 50
        Me.ebBaseDatosBlue.Name = "ebBaseDatosBlue"
        Me.ebBaseDatosBlue.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosBlue.TabIndex = 32
        Me.ebBaseDatosBlue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosBlue.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label144
        '
        Me.Label144.AutoSize = True
        Me.Label144.BackColor = System.Drawing.Color.Transparent
        Me.Label144.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label144.Location = New System.Drawing.Point(16, 56)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(77, 16)
        Me.Label144.TabIndex = 38
        Me.Label144.Text = "Base de Datos"
        '
        'ebPasswordBlue
        '
        Me.ebPasswordBlue.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordBlue.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordBlue.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordBlue.Location = New System.Drawing.Point(96, 104)
        Me.ebPasswordBlue.MaxLength = 30
        Me.ebPasswordBlue.Name = "ebPasswordBlue"
        Me.ebPasswordBlue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordBlue.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordBlue.TabIndex = 34
        Me.ebPasswordBlue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordBlue.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label145
        '
        Me.Label145.AutoSize = True
        Me.Label145.BackColor = System.Drawing.Color.Transparent
        Me.Label145.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label145.Location = New System.Drawing.Point(16, 104)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(55, 16)
        Me.Label145.TabIndex = 37
        Me.Label145.Text = "Password"
        '
        'Label146
        '
        Me.Label146.AutoSize = True
        Me.Label146.BackColor = System.Drawing.Color.Transparent
        Me.Label146.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label146.Location = New System.Drawing.Point(16, 32)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(49, 16)
        Me.Label146.TabIndex = 35
        Me.Label146.Text = "Servidor"
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.BackColor = System.Drawing.Color.Transparent
        Me.Label147.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label147.Location = New System.Drawing.Point(16, 80)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(45, 16)
        Me.Label147.TabIndex = 36
        Me.Label147.Text = "Usuario"
        '
        'pbBlue
        '
        Me.pbBlue.BackColor = System.Drawing.Color.Transparent
        Me.pbBlue.Location = New System.Drawing.Point(288, 40)
        Me.pbBlue.Name = "pbBlue"
        Me.pbBlue.Size = New System.Drawing.Size(32, 32)
        Me.pbBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBlue.TabIndex = 39
        Me.pbBlue.TabStop = False
        '
        'GroupBox19
        '
        Me.GroupBox19.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox19.Controls.Add(Me.cmbServerDPCard)
        Me.GroupBox19.Controls.Add(Me.ebUserDPCard)
        Me.GroupBox19.Controls.Add(Me.btnProbarDPCard)
        Me.GroupBox19.Controls.Add(Me.ebBaseDatosDPCard)
        Me.GroupBox19.Controls.Add(Me.Label108)
        Me.GroupBox19.Controls.Add(Me.ebPasswordDPCard)
        Me.GroupBox19.Controls.Add(Me.Label109)
        Me.GroupBox19.Controls.Add(Me.Label110)
        Me.GroupBox19.Controls.Add(Me.Label111)
        Me.GroupBox19.Controls.Add(Me.pbDPCard)
        Me.GroupBox19.Location = New System.Drawing.Point(15, 23)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox19.TabIndex = 45
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Configuración Promociones DP Card"
        '
        'cmbServerDPCard
        '
        Me.cmbServerDPCard.Location = New System.Drawing.Point(96, 27)
        Me.cmbServerDPCard.Name = "cmbServerDPCard"
        Me.cmbServerDPCard.Size = New System.Drawing.Size(144, 22)
        Me.cmbServerDPCard.TabIndex = 31
        Me.cmbServerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebUserDPCard
        '
        Me.ebUserDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUserDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUserDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUserDPCard.Location = New System.Drawing.Point(96, 80)
        Me.ebUserDPCard.MaxLength = 30
        Me.ebUserDPCard.Name = "ebUserDPCard"
        Me.ebUserDPCard.Size = New System.Drawing.Size(144, 22)
        Me.ebUserDPCard.TabIndex = 33
        Me.ebUserDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUserDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnProbarDPCard
        '
        Me.btnProbarDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProbarDPCard.Location = New System.Drawing.Point(280, 96)
        Me.btnProbarDPCard.Name = "btnProbarDPCard"
        Me.btnProbarDPCard.Size = New System.Drawing.Size(40, 24)
        Me.btnProbarDPCard.TabIndex = 30
        Me.btnProbarDPCard.Text = "Probar"
        '
        'ebBaseDatosDPCard
        '
        Me.ebBaseDatosDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseDatosDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBaseDatosDPCard.Location = New System.Drawing.Point(96, 56)
        Me.ebBaseDatosDPCard.MaxLength = 50
        Me.ebBaseDatosDPCard.Name = "ebBaseDatosDPCard"
        Me.ebBaseDatosDPCard.Size = New System.Drawing.Size(144, 22)
        Me.ebBaseDatosDPCard.TabIndex = 32
        Me.ebBaseDatosDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBaseDatosDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.Location = New System.Drawing.Point(16, 56)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(77, 16)
        Me.Label108.TabIndex = 38
        Me.Label108.Text = "Base de Datos"
        '
        'ebPasswordDPCard
        '
        Me.ebPasswordDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPasswordDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPasswordDPCard.Location = New System.Drawing.Point(96, 104)
        Me.ebPasswordDPCard.MaxLength = 30
        Me.ebPasswordDPCard.Name = "ebPasswordDPCard"
        Me.ebPasswordDPCard.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.ebPasswordDPCard.Size = New System.Drawing.Size(144, 22)
        Me.ebPasswordDPCard.TabIndex = 34
        Me.ebPasswordDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPasswordDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.BackColor = System.Drawing.Color.Transparent
        Me.Label109.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.Location = New System.Drawing.Point(16, 104)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(55, 16)
        Me.Label109.TabIndex = 37
        Me.Label109.Text = "Password"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.BackColor = System.Drawing.Color.Transparent
        Me.Label110.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.Location = New System.Drawing.Point(16, 32)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(49, 16)
        Me.Label110.TabIndex = 35
        Me.Label110.Text = "Servidor"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.BackColor = System.Drawing.Color.Transparent
        Me.Label111.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.Location = New System.Drawing.Point(16, 80)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(45, 16)
        Me.Label111.TabIndex = 36
        Me.Label111.Text = "Usuario"
        '
        'pbDPCard
        '
        Me.pbDPCard.BackColor = System.Drawing.Color.Transparent
        Me.pbDPCard.Location = New System.Drawing.Point(288, 40)
        Me.pbDPCard.Name = "pbDPCard"
        Me.pbDPCard.Size = New System.Drawing.Size(32, 32)
        Me.pbDPCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDPCard.TabIndex = 39
        Me.pbDPCard.TabStop = False
        '
        'uitNetezza
        '
        Me.uitNetezza.Controls.Add(Me.GroupBox27)
        Me.uitNetezza.Controls.Add(Me.GroupBox31)
        Me.uitNetezza.Controls.Add(Me.GroupBox35)
        Me.uitNetezza.Controls.Add(Me.GroupBox30)
        Me.uitNetezza.Controls.Add(Me.GroupBox29)
        Me.uitNetezza.Controls.Add(Me.lblConsecutivoPuntos)
        Me.uitNetezza.Controls.Add(Me.Label106)
        Me.uitNetezza.Controls.Add(Me.txtConsecutivoPuntos)
        Me.uitNetezza.Controls.Add(Me.ebConsecutivoPOS)
        Me.uitNetezza.Controls.Add(Me.txtIDTienda)
        Me.uitNetezza.Controls.Add(Me.lblIDTienda)
        Me.uitNetezza.Location = New System.Drawing.Point(1, 22)
        Me.uitNetezza.Name = "uitNetezza"
        Me.uitNetezza.Size = New System.Drawing.Size(704, 398)
        Me.uitNetezza.TabStop = True
        Me.uitNetezza.Text = "Configuración DP Card Puntos"
        '
        'GroupBox27
        '
        Me.GroupBox27.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox27.Controls.Add(Me.chkRegistroApprova)
        Me.GroupBox27.Controls.Add(Me.txtUrlRegistro)
        Me.GroupBox27.Controls.Add(Me.Label130)
        Me.GroupBox27.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(336, 87)
        Me.GroupBox27.TabIndex = 55
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Configuración Registro Approva DP Card Puntos"
        '
        'chkRegistroApprova
        '
        Me.chkRegistroApprova.AutoSize = True
        Me.chkRegistroApprova.BackColor = System.Drawing.Color.Transparent
        Me.chkRegistroApprova.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRegistroApprova.Location = New System.Drawing.Point(11, 31)
        Me.chkRegistroApprova.Name = "chkRegistroApprova"
        Me.chkRegistroApprova.Size = New System.Drawing.Size(149, 20)
        Me.chkRegistroApprova.TabIndex = 86
        Me.chkRegistroApprova.Text = "Registrar Cliente Approva"
        Me.chkRegistroApprova.UseVisualStyleBackColor = False
        '
        'txtUrlRegistro
        '
        Me.txtUrlRegistro.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUrlRegistro.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUrlRegistro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUrlRegistro.Location = New System.Drawing.Point(101, 57)
        Me.txtUrlRegistro.MaxLength = 0
        Me.txtUrlRegistro.Name = "txtUrlRegistro"
        Me.txtUrlRegistro.Size = New System.Drawing.Size(227, 22)
        Me.txtUrlRegistro.TabIndex = 54
        Me.txtUrlRegistro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtUrlRegistro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.BackColor = System.Drawing.Color.Transparent
        Me.Label130.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label130.Location = New System.Drawing.Point(8, 57)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(87, 16)
        Me.Label130.TabIndex = 55
        Me.Label130.Text = "URL de Registro"
        '
        'GroupBox31
        '
        Me.GroupBox31.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox31.Controls.Add(Me.chkCanje)
        Me.GroupBox31.Controls.Add(Me.txtTransacCan)
        Me.GroupBox31.Controls.Add(Me.Label137)
        Me.GroupBox31.Controls.Add(Me.Label134)
        Me.GroupBox31.Controls.Add(Me.Label133)
        Me.GroupBox31.Controls.Add(Me.txtCanje)
        Me.GroupBox31.Location = New System.Drawing.Point(346, 247)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(336, 133)
        Me.GroupBox31.TabIndex = 92
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "Canje"
        '
        'chkCanje
        '
        Me.chkCanje.AutoSize = True
        Me.chkCanje.Location = New System.Drawing.Point(253, 99)
        Me.chkCanje.Name = "chkCanje"
        Me.chkCanje.Size = New System.Drawing.Size(15, 14)
        Me.chkCanje.TabIndex = 65
        Me.chkCanje.UseVisualStyleBackColor = True
        '
        'txtTransacCan
        '
        Me.txtTransacCan.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTransacCan.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTransacCan.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransacCan.Location = New System.Drawing.Point(253, 67)
        Me.txtTransacCan.Name = "txtTransacCan"
        Me.txtTransacCan.Size = New System.Drawing.Size(75, 22)
        Me.txtTransacCan.TabIndex = 64
        Me.txtTransacCan.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTransacCan.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.BackColor = System.Drawing.Color.Transparent
        Me.Label137.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label137.Location = New System.Drawing.Point(8, 97)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(75, 16)
        Me.Label137.TabIndex = 63
        Me.Label137.Text = "Alerta de Uso:"
        '
        'Label134
        '
        Me.Label134.AutoSize = True
        Me.Label134.BackColor = System.Drawing.Color.Transparent
        Me.Label134.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label134.Location = New System.Drawing.Point(8, 67)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(131, 16)
        Me.Label134.TabIndex = 63
        Me.Label134.Text = "Transacciones Permitidas:"
        '
        'Label133
        '
        Me.Label133.AutoSize = True
        Me.Label133.BackColor = System.Drawing.Color.Transparent
        Me.Label133.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label133.Location = New System.Drawing.Point(8, 38)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(129, 16)
        Me.Label133.TabIndex = 58
        Me.Label133.Text = "Días Permitidos de Canje:"
        '
        'txtCanje
        '
        Me.txtCanje.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCanje.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCanje.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanje.Location = New System.Drawing.Point(253, 36)
        Me.txtCanje.Name = "txtCanje"
        Me.txtCanje.Size = New System.Drawing.Size(75, 22)
        Me.txtCanje.TabIndex = 62
        Me.txtCanje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCanje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'GroupBox35
        '
        Me.GroupBox35.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox35.Controls.Add(Me.Label156)
        Me.GroupBox35.Controls.Add(Me.Label149)
        Me.GroupBox35.Controls.Add(Me.nebPuertoLealtad)
        Me.GroupBox35.Controls.Add(Me.ebServerLealtad)
        Me.GroupBox35.Controls.Add(Me.Label148)
        Me.GroupBox35.Controls.Add(Me.txt_usr_token_wsBlue)
        Me.GroupBox35.Controls.Add(Me.Label143)
        Me.GroupBox35.Controls.Add(Me.rdbtn_Blue)
        Me.GroupBox35.Controls.Add(Me.rdbtn_Karum)
        Me.GroupBox35.Location = New System.Drawing.Point(345, 110)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(334, 131)
        Me.GroupBox35.TabIndex = 93
        Me.GroupBox35.TabStop = False
        Me.GroupBox35.Text = "Configuraciones varias"
        '
        'Label156
        '
        Me.Label156.AutoSize = True
        Me.Label156.BackColor = System.Drawing.Color.Transparent
        Me.Label156.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label156.Location = New System.Drawing.Point(9, 85)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(86, 16)
        Me.Label156.TabIndex = 124
        Me.Label156.Text = "Servidor Lealtad"
        '
        'Label149
        '
        Me.Label149.AutoSize = True
        Me.Label149.BackColor = System.Drawing.Color.Transparent
        Me.Label149.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label149.Location = New System.Drawing.Point(9, 109)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(39, 16)
        Me.Label149.TabIndex = 123
        Me.Label149.Text = "Puerto"
        '
        'nebPuertoLealtad
        '
        Me.nebPuertoLealtad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPuertoLealtad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPuertoLealtad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebPuertoLealtad.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebPuertoLealtad.Location = New System.Drawing.Point(132, 103)
        Me.nebPuertoLealtad.Name = "nebPuertoLealtad"
        Me.nebPuertoLealtad.Size = New System.Drawing.Size(40, 22)
        Me.nebPuertoLealtad.TabIndex = 122
        Me.nebPuertoLealtad.Text = "0"
        Me.nebPuertoLealtad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPuertoLealtad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPuertoLealtad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebServerLealtad
        '
        Me.ebServerLealtad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServerLealtad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServerLealtad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServerLealtad.Location = New System.Drawing.Point(132, 79)
        Me.ebServerLealtad.MaxLength = 0
        Me.ebServerLealtad.Name = "ebServerLealtad"
        Me.ebServerLealtad.Size = New System.Drawing.Size(196, 22)
        Me.ebServerLealtad.TabIndex = 119
        Me.ebServerLealtad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServerLealtad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label148
        '
        Me.Label148.AutoSize = True
        Me.Label148.BackColor = System.Drawing.Color.Transparent
        Me.Label148.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label148.Location = New System.Drawing.Point(130, 53)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(78, 16)
        Me.Label148.TabIndex = 91
        Me.Label148.Text = "Usuario Token"
        '
        'txt_usr_token_wsBlue
        '
        Me.txt_usr_token_wsBlue.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txt_usr_token_wsBlue.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txt_usr_token_wsBlue.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_usr_token_wsBlue.Location = New System.Drawing.Point(214, 51)
        Me.txt_usr_token_wsBlue.Name = "txt_usr_token_wsBlue"
        Me.txt_usr_token_wsBlue.Size = New System.Drawing.Size(114, 22)
        Me.txt_usr_token_wsBlue.TabIndex = 90
        Me.txt_usr_token_wsBlue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txt_usr_token_wsBlue.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label143
        '
        Me.Label143.AutoSize = True
        Me.Label143.BackColor = System.Drawing.Color.Transparent
        Me.Label143.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label143.Location = New System.Drawing.Point(8, 23)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(142, 16)
        Me.Label143.TabIndex = 89
        Me.Label143.Text = "Configuración de Proveedor"
        '
        'rdbtn_Blue
        '
        Me.rdbtn_Blue.AutoSize = True
        Me.rdbtn_Blue.Location = New System.Drawing.Point(76, 51)
        Me.rdbtn_Blue.Name = "rdbtn_Blue"
        Me.rdbtn_Blue.Size = New System.Drawing.Size(48, 18)
        Me.rdbtn_Blue.TabIndex = 1
        Me.rdbtn_Blue.TabStop = True
        Me.rdbtn_Blue.Text = "Blue"
        Me.rdbtn_Blue.UseVisualStyleBackColor = True
        '
        'rdbtn_Karum
        '
        Me.rdbtn_Karum.AutoSize = True
        Me.rdbtn_Karum.Location = New System.Drawing.Point(11, 51)
        Me.rdbtn_Karum.Name = "rdbtn_Karum"
        Me.rdbtn_Karum.Size = New System.Drawing.Size(59, 18)
        Me.rdbtn_Karum.TabIndex = 0
        Me.rdbtn_Karum.TabStop = True
        Me.rdbtn_Karum.Text = "Karum"
        Me.rdbtn_Karum.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox30.Controls.Add(Me.chkBonifica)
        Me.GroupBox30.Controls.Add(Me.txtTransacBoni)
        Me.GroupBox30.Controls.Add(Me.Label136)
        Me.GroupBox30.Controls.Add(Me.Label131)
        Me.GroupBox30.Controls.Add(Me.Label132)
        Me.GroupBox30.Controls.Add(Me.txtBonificacion)
        Me.GroupBox30.Location = New System.Drawing.Point(7, 247)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(333, 133)
        Me.GroupBox30.TabIndex = 91
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Bonificacion"
        '
        'chkBonifica
        '
        Me.chkBonifica.AutoSize = True
        Me.chkBonifica.Location = New System.Drawing.Point(242, 99)
        Me.chkBonifica.Name = "chkBonifica"
        Me.chkBonifica.Size = New System.Drawing.Size(15, 14)
        Me.chkBonifica.TabIndex = 64
        Me.chkBonifica.UseVisualStyleBackColor = True
        '
        'txtTransacBoni
        '
        Me.txtTransacBoni.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTransacBoni.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTransacBoni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransacBoni.Location = New System.Drawing.Point(242, 67)
        Me.txtTransacBoni.Name = "txtTransacBoni"
        Me.txtTransacBoni.Size = New System.Drawing.Size(75, 22)
        Me.txtTransacBoni.TabIndex = 63
        Me.txtTransacBoni.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTransacBoni.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.BackColor = System.Drawing.Color.Transparent
        Me.Label136.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label136.Location = New System.Drawing.Point(13, 97)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(75, 16)
        Me.Label136.TabIndex = 62
        Me.Label136.Text = "Alerta de Uso:"
        '
        'Label131
        '
        Me.Label131.AutoSize = True
        Me.Label131.BackColor = System.Drawing.Color.Transparent
        Me.Label131.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label131.Location = New System.Drawing.Point(13, 67)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(131, 16)
        Me.Label131.TabIndex = 61
        Me.Label131.Text = "Transacciones Permitidas:"
        '
        'Label132
        '
        Me.Label132.AutoSize = True
        Me.Label132.BackColor = System.Drawing.Color.Transparent
        Me.Label132.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label132.Location = New System.Drawing.Point(13, 38)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(156, 16)
        Me.Label132.TabIndex = 57
        Me.Label132.Text = "Días Permitidos de Bonificación:"
        '
        'txtBonificacion
        '
        Me.txtBonificacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtBonificacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtBonificacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonificacion.Location = New System.Drawing.Point(242, 36)
        Me.txtBonificacion.Name = "txtBonificacion"
        Me.txtBonificacion.Size = New System.Drawing.Size(75, 22)
        Me.txtBonificacion.TabIndex = 60
        Me.txtBonificacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtBonificacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'GroupBox29
        '
        Me.GroupBox29.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox29.Controls.Add(Me.txtComisionBancoToka)
        Me.GroupBox29.Controls.Add(Me.lblComisionBancoToka)
        Me.GroupBox29.Controls.Add(Me.chActivarToka)
        Me.GroupBox29.Location = New System.Drawing.Point(345, 15)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(334, 89)
        Me.GroupBox29.TabIndex = 90
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Configuracion Dispersiones"
        '
        'txtComisionBancoToka
        '
        Me.txtComisionBancoToka.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtComisionBancoToka.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtComisionBancoToka.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtComisionBancoToka.Location = New System.Drawing.Point(123, 25)
        Me.txtComisionBancoToka.Name = "txtComisionBancoToka"
        Me.txtComisionBancoToka.Size = New System.Drawing.Size(85, 22)
        Me.txtComisionBancoToka.TabIndex = 89
        Me.txtComisionBancoToka.Text = "$0.00"
        Me.txtComisionBancoToka.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtComisionBancoToka.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblComisionBancoToka
        '
        Me.lblComisionBancoToka.AutoSize = True
        Me.lblComisionBancoToka.BackColor = System.Drawing.Color.Transparent
        Me.lblComisionBancoToka.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionBancoToka.Location = New System.Drawing.Point(6, 30)
        Me.lblComisionBancoToka.Name = "lblComisionBancoToka"
        Me.lblComisionBancoToka.Size = New System.Drawing.Size(111, 16)
        Me.lblComisionBancoToka.TabIndex = 88
        Me.lblComisionBancoToka.Text = "Comisión Banco Toka"
        '
        'chActivarToka
        '
        Me.chActivarToka.AutoSize = True
        Me.chActivarToka.BackColor = System.Drawing.Color.Transparent
        Me.chActivarToka.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chActivarToka.Location = New System.Drawing.Point(9, 60)
        Me.chActivarToka.Name = "chActivarToka"
        Me.chActivarToka.Size = New System.Drawing.Size(86, 20)
        Me.chActivarToka.TabIndex = 87
        Me.chActivarToka.Text = "Activar Toka"
        Me.chActivarToka.UseVisualStyleBackColor = False
        '
        'lblConsecutivoPuntos
        '
        Me.lblConsecutivoPuntos.AutoSize = True
        Me.lblConsecutivoPuntos.BackColor = System.Drawing.Color.Transparent
        Me.lblConsecutivoPuntos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivoPuntos.Location = New System.Drawing.Point(11, 173)
        Me.lblConsecutivoPuntos.Name = "lblConsecutivoPuntos"
        Me.lblConsecutivoPuntos.Size = New System.Drawing.Size(116, 16)
        Me.lblConsecutivoPuntos.TabIndex = 50
        Me.lblConsecutivoPuntos.Text = "Consecutivo DPPuntos"
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(11, 110)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(91, 16)
        Me.Label106.TabIndex = 27
        Me.Label106.Text = "Consecutivo POS"
        '
        'txtConsecutivoPuntos
        '
        Me.txtConsecutivoPuntos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtConsecutivoPuntos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtConsecutivoPuntos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsecutivoPuntos.Location = New System.Drawing.Point(155, 173)
        Me.txtConsecutivoPuntos.Name = "txtConsecutivoPuntos"
        Me.txtConsecutivoPuntos.Size = New System.Drawing.Size(75, 22)
        Me.txtConsecutivoPuntos.TabIndex = 51
        Me.txtConsecutivoPuntos.Text = "0001"
        Me.txtConsecutivoPuntos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtConsecutivoPuntos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebConsecutivoPOS
        '
        Me.ebConsecutivoPOS.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebConsecutivoPOS.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebConsecutivoPOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebConsecutivoPOS.Location = New System.Drawing.Point(155, 110)
        Me.ebConsecutivoPOS.Name = "ebConsecutivoPOS"
        Me.ebConsecutivoPOS.Size = New System.Drawing.Size(75, 22)
        Me.ebConsecutivoPOS.TabIndex = 28
        Me.ebConsecutivoPOS.Text = "0001"
        Me.ebConsecutivoPOS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebConsecutivoPOS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtIDTienda
        '
        Me.txtIDTienda.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtIDTienda.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtIDTienda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDTienda.Location = New System.Drawing.Point(155, 142)
        Me.txtIDTienda.Name = "txtIDTienda"
        Me.txtIDTienda.Size = New System.Drawing.Size(75, 22)
        Me.txtIDTienda.TabIndex = 47
        Me.txtIDTienda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtIDTienda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblIDTienda
        '
        Me.lblIDTienda.AutoSize = True
        Me.lblIDTienda.BackColor = System.Drawing.Color.Transparent
        Me.lblIDTienda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDTienda.Location = New System.Drawing.Point(11, 142)
        Me.lblIDTienda.Name = "lblIDTienda"
        Me.lblIDTienda.Size = New System.Drawing.Size(52, 16)
        Me.lblIDTienda.TabIndex = 46
        Me.lblIDTienda.Text = "IDTienda"
        '
        'UiTabPage11
        '
        Me.UiTabPage11.Controls.Add(Me.txtRutaProperties)
        Me.UiTabPage11.Controls.Add(Me.lblRutaProperties)
        Me.UiTabPage11.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage11.Name = "UiTabPage11"
        Me.UiTabPage11.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage11.TabStop = True
        Me.UiTabPage11.Text = "MQTT"
        '
        'txtRutaProperties
        '
        Me.txtRutaProperties.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtRutaProperties.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtRutaProperties.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtRutaProperties.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaProperties.Location = New System.Drawing.Point(155, 18)
        Me.txtRutaProperties.MaxLength = 100
        Me.txtRutaProperties.Name = "txtRutaProperties"
        Me.txtRutaProperties.Size = New System.Drawing.Size(538, 22)
        Me.txtRutaProperties.TabIndex = 69
        Me.txtRutaProperties.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtRutaProperties.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblRutaProperties
        '
        Me.lblRutaProperties.AutoSize = True
        Me.lblRutaProperties.BackColor = System.Drawing.Color.Transparent
        Me.lblRutaProperties.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaProperties.Location = New System.Drawing.Point(11, 18)
        Me.lblRutaProperties.Name = "lblRutaProperties"
        Me.lblRutaProperties.Size = New System.Drawing.Size(138, 16)
        Me.lblRutaProperties.TabIndex = 70
        Me.lblRutaProperties.Text = "Ruta de Archivo Properties:"
        '
        'UiTabPage12
        '
        Me.UiTabPage12.AccessibleName = "tabDPSeguro"
        Me.UiTabPage12.Controls.Add(Me.UiGroupBox5)
        Me.UiTabPage12.Controls.Add(Me.UiGroupBox4)
        Me.UiTabPage12.Key = "tabDPSeguro"
        Me.UiTabPage12.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage12.Name = "UiTabPage12"
        Me.UiTabPage12.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage12.TabStop = True
        Me.UiTabPage12.Text = "DPSeguro / S2Credit"
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox5.Controls.Add(Me.GroupBox28)
        Me.UiGroupBox5.Controls.Add(Me.chkAplicaParaleloS2CSAP)
        Me.UiGroupBox5.Controls.Add(Me.chkAplicaS2Credit)
        Me.UiGroupBox5.Location = New System.Drawing.Point(9, 213)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(687, 204)
        Me.UiGroupBox5.TabIndex = 64
        Me.UiGroupBox5.Text = "S2Credit"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'GroupBox28
        '
        Me.GroupBox28.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox28.Controls.Add(Me.txtPuertoS2Credit)
        Me.GroupBox28.Controls.Add(Me.lblPuertoS2Credit)
        Me.GroupBox28.Controls.Add(Me.txtServidorS2Credit)
        Me.GroupBox28.Controls.Add(Me.lblServidorS2Credit)
        Me.GroupBox28.Location = New System.Drawing.Point(353, 15)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(328, 86)
        Me.GroupBox28.TabIndex = 110
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Configuración Broker"
        '
        'txtPuertoS2Credit
        '
        Me.txtPuertoS2Credit.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPuertoS2Credit.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPuertoS2Credit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuertoS2Credit.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtPuertoS2Credit.Location = New System.Drawing.Point(126, 47)
        Me.txtPuertoS2Credit.Name = "txtPuertoS2Credit"
        Me.txtPuertoS2Credit.Size = New System.Drawing.Size(40, 22)
        Me.txtPuertoS2Credit.TabIndex = 111
        Me.txtPuertoS2Credit.Text = "0"
        Me.txtPuertoS2Credit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPuertoS2Credit.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtPuertoS2Credit.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPuertoS2Credit
        '
        Me.lblPuertoS2Credit.AutoSize = True
        Me.lblPuertoS2Credit.BackColor = System.Drawing.Color.Transparent
        Me.lblPuertoS2Credit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuertoS2Credit.Location = New System.Drawing.Point(6, 47)
        Me.lblPuertoS2Credit.Name = "lblPuertoS2Credit"
        Me.lblPuertoS2Credit.Size = New System.Drawing.Size(39, 16)
        Me.lblPuertoS2Credit.TabIndex = 110
        Me.lblPuertoS2Credit.Text = "Puerto"
        '
        'txtServidorS2Credit
        '
        Me.txtServidorS2Credit.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtServidorS2Credit.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtServidorS2Credit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServidorS2Credit.Location = New System.Drawing.Point(126, 23)
        Me.txtServidorS2Credit.MaxLength = 0
        Me.txtServidorS2Credit.Name = "txtServidorS2Credit"
        Me.txtServidorS2Credit.Size = New System.Drawing.Size(196, 22)
        Me.txtServidorS2Credit.TabIndex = 108
        Me.txtServidorS2Credit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtServidorS2Credit.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblServidorS2Credit
        '
        Me.lblServidorS2Credit.AutoSize = True
        Me.lblServidorS2Credit.BackColor = System.Drawing.Color.Transparent
        Me.lblServidorS2Credit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServidorS2Credit.Location = New System.Drawing.Point(6, 23)
        Me.lblServidorS2Credit.Name = "lblServidorS2Credit"
        Me.lblServidorS2Credit.Size = New System.Drawing.Size(93, 16)
        Me.lblServidorS2Credit.TabIndex = 109
        Me.lblServidorS2Credit.Text = "Servidor S2Credit"
        '
        'chkAplicaParaleloS2CSAP
        '
        Me.chkAplicaParaleloS2CSAP.AutoSize = True
        Me.chkAplicaParaleloS2CSAP.BackColor = System.Drawing.Color.Transparent
        Me.chkAplicaParaleloS2CSAP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAplicaParaleloS2CSAP.Location = New System.Drawing.Point(9, 51)
        Me.chkAplicaParaleloS2CSAP.Name = "chkAplicaParaleloS2CSAP"
        Me.chkAplicaParaleloS2CSAP.Size = New System.Drawing.Size(140, 20)
        Me.chkAplicaParaleloS2CSAP.TabIndex = 100
        Me.chkAplicaParaleloS2CSAP.Text = "Paralelo S2Credit / SAP"
        Me.chkAplicaParaleloS2CSAP.UseVisualStyleBackColor = False
        Me.chkAplicaParaleloS2CSAP.Visible = False
        '
        'chkAplicaS2Credit
        '
        Me.chkAplicaS2Credit.AutoSize = True
        Me.chkAplicaS2Credit.BackColor = System.Drawing.Color.Transparent
        Me.chkAplicaS2Credit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAplicaS2Credit.Location = New System.Drawing.Point(9, 25)
        Me.chkAplicaS2Credit.Name = "chkAplicaS2Credit"
        Me.chkAplicaS2Credit.Size = New System.Drawing.Size(99, 20)
        Me.chkAplicaS2Credit.TabIndex = 99
        Me.chkAplicaS2Credit.Text = "Aplica S2Credit"
        Me.chkAplicaS2Credit.UseVisualStyleBackColor = False
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox4.Controls.Add(Me.txtDiaQuincena)
        Me.UiGroupBox4.Controls.Add(Me.lblDiasxQuincena)
        Me.UiGroupBox4.Controls.Add(Me.cbDPVLSeguroValidacion)
        Me.UiGroupBox4.Controls.Add(Me.chkGenerarSeguro)
        Me.UiGroupBox4.Controls.Add(Me.lblDiasVencimiento)
        Me.UiGroupBox4.Controls.Add(Me.txtDiasModificarBenef)
        Me.UiGroupBox4.Location = New System.Drawing.Point(9, 3)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(687, 204)
        Me.UiGroupBox4.TabIndex = 63
        Me.UiGroupBox4.Text = "DP Seguros"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtDiaQuincena
        '
        Me.txtDiaQuincena.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDiaQuincena.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDiaQuincena.Enabled = False
        Me.txtDiaQuincena.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiaQuincena.Location = New System.Drawing.Point(320, 35)
        Me.txtDiaQuincena.Name = "txtDiaQuincena"
        Me.txtDiaQuincena.Size = New System.Drawing.Size(40, 22)
        Me.txtDiaQuincena.TabIndex = 104
        Me.txtDiaQuincena.Text = "15"
        Me.txtDiaQuincena.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiaQuincena.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtDiaQuincena.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDiasxQuincena
        '
        Me.lblDiasxQuincena.AutoSize = True
        Me.lblDiasxQuincena.BackColor = System.Drawing.Color.Transparent
        Me.lblDiasxQuincena.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasxQuincena.Location = New System.Drawing.Point(225, 35)
        Me.lblDiasxQuincena.Name = "lblDiasxQuincena"
        Me.lblDiasxQuincena.Size = New System.Drawing.Size(94, 16)
        Me.lblDiasxQuincena.TabIndex = 103
        Me.lblDiasxQuincena.Text = "Dias por quincena"
        '
        'cbDPVLSeguroValidacion
        '
        Me.cbDPVLSeguroValidacion.AutoSize = True
        Me.cbDPVLSeguroValidacion.BackColor = System.Drawing.Color.Transparent
        Me.cbDPVLSeguroValidacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDPVLSeguroValidacion.Location = New System.Drawing.Point(9, 97)
        Me.cbDPVLSeguroValidacion.Name = "cbDPVLSeguroValidacion"
        Me.cbDPVLSeguroValidacion.Size = New System.Drawing.Size(172, 20)
        Me.cbDPVLSeguroValidacion.TabIndex = 98
        Me.cbDPVLSeguroValidacion.Text = "Validar Seguro de vidas DPVL"
        Me.cbDPVLSeguroValidacion.UseVisualStyleBackColor = False
        '
        'chkGenerarSeguro
        '
        Me.chkGenerarSeguro.AutoSize = True
        Me.chkGenerarSeguro.BackColor = System.Drawing.Color.Transparent
        Me.chkGenerarSeguro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGenerarSeguro.Location = New System.Drawing.Point(9, 71)
        Me.chkGenerarSeguro.Name = "chkGenerarSeguro"
        Me.chkGenerarSeguro.Size = New System.Drawing.Size(148, 20)
        Me.chkGenerarSeguro.TabIndex = 97
        Me.chkGenerarSeguro.Text = "Aplica Seguro Vida DPVL"
        Me.chkGenerarSeguro.UseVisualStyleBackColor = False
        '
        'lblDiasVencimiento
        '
        Me.lblDiasVencimiento.AutoSize = True
        Me.lblDiasVencimiento.BackColor = System.Drawing.Color.Transparent
        Me.lblDiasVencimiento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasVencimiento.Location = New System.Drawing.Point(6, 35)
        Me.lblDiasVencimiento.Name = "lblDiasVencimiento"
        Me.lblDiasVencimiento.Size = New System.Drawing.Size(154, 16)
        Me.lblDiasVencimiento.TabIndex = 29
        Me.lblDiasVencimiento.Text = "Dias para modificar beneficiario"
        '
        'txtDiasModificarBenef
        '
        Me.txtDiasModificarBenef.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDiasModificarBenef.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDiasModificarBenef.Enabled = False
        Me.txtDiasModificarBenef.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasModificarBenef.Location = New System.Drawing.Point(166, 35)
        Me.txtDiasModificarBenef.Name = "txtDiasModificarBenef"
        Me.txtDiasModificarBenef.Size = New System.Drawing.Size(40, 22)
        Me.txtDiasModificarBenef.TabIndex = 60
        Me.txtDiasModificarBenef.Text = "5"
        Me.txtDiasModificarBenef.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasModificarBenef.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtDiasModificarBenef.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiTabPage13
        '
        Me.UiTabPage13.Controls.Add(Me.Label129)
        Me.UiTabPage13.Controls.Add(Me.nebTimeFreeRAM)
        Me.UiTabPage13.Controls.Add(Me.chkFreeRAM)
        Me.UiTabPage13.Controls.Add(Me.chkFacturacionNueva)
        Me.UiTabPage13.Controls.Add(Me.txtPublicoGeneral)
        Me.UiTabPage13.Controls.Add(Me.lblClientePublicoGeneral)
        Me.UiTabPage13.Controls.Add(Me.lbletiqueta)
        Me.UiTabPage13.Controls.Add(Me.txtDescuentoFijoNoCatalogo)
        Me.UiTabPage13.Controls.Add(Me.lblDescuentoDips)
        Me.UiTabPage13.Controls.Add(Me.txtPasswordFTPCierre)
        Me.UiTabPage13.Controls.Add(Me.lblPasswordFTPCierre)
        Me.UiTabPage13.Controls.Add(Me.txtUsuarioFTPCierre)
        Me.UiTabPage13.Controls.Add(Me.lblUsuarioFTPServer)
        Me.UiTabPage13.Controls.Add(Me.txtServidorFTPCierre)
        Me.UiTabPage13.Controls.Add(Me.lblFtpCierre)
        Me.UiTabPage13.Controls.Add(Me.txtSector)
        Me.UiTabPage13.Controls.Add(Me.lblSector)
        Me.UiTabPage13.Controls.Add(Me.txtCanalDistribucion)
        Me.UiTabPage13.Controls.Add(Me.lblCanalDistribucion)
        Me.UiTabPage13.Controls.Add(Me.txtOrganizacionCompra)
        Me.UiTabPage13.Controls.Add(Me.lblOrganizacionCompra)
        Me.UiTabPage13.Key = "tabSapRetail"
        Me.UiTabPage13.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage13.Name = "UiTabPage13"
        Me.UiTabPage13.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage13.TabStop = True
        Me.UiTabPage13.Text = "SAP Retail"
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.BackColor = System.Drawing.Color.Transparent
        Me.Label129.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label129.Location = New System.Drawing.Point(213, 271)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(44, 16)
        Me.Label129.TabIndex = 119
        Me.Label129.Text = "Minutos"
        '
        'nebTimeFreeRAM
        '
        Me.nebTimeFreeRAM.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTimeFreeRAM.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTimeFreeRAM.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.nebTimeFreeRAM.FormatString = "#0.0"
        Me.nebTimeFreeRAM.Location = New System.Drawing.Point(170, 270)
        Me.nebTimeFreeRAM.Name = "nebTimeFreeRAM"
        Me.nebTimeFreeRAM.Size = New System.Drawing.Size(40, 22)
        Me.nebTimeFreeRAM.TabIndex = 118
        Me.nebTimeFreeRAM.Text = "20.0"
        Me.nebTimeFreeRAM.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTimeFreeRAM.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkFreeRAM
        '
        Me.chkFreeRAM.AutoSize = True
        Me.chkFreeRAM.BackColor = System.Drawing.Color.Transparent
        Me.chkFreeRAM.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFreeRAM.Location = New System.Drawing.Point(31, 270)
        Me.chkFreeRAM.Name = "chkFreeRAM"
        Me.chkFreeRAM.Size = New System.Drawing.Size(114, 20)
        Me.chkFreeRAM.TabIndex = 117
        Me.chkFreeRAM.Text = "Liberar RAM cada"
        Me.chkFreeRAM.UseVisualStyleBackColor = False
        '
        'chkFacturacionNueva
        '
        Me.chkFacturacionNueva.AutoSize = True
        Me.chkFacturacionNueva.BackColor = System.Drawing.Color.Transparent
        Me.chkFacturacionNueva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFacturacionNueva.Location = New System.Drawing.Point(31, 244)
        Me.chkFacturacionNueva.Name = "chkFacturacionNueva"
        Me.chkFacturacionNueva.Size = New System.Drawing.Size(152, 20)
        Me.chkFacturacionNueva.TabIndex = 116
        Me.chkFacturacionNueva.Text = "Activar Nueva Facturación"
        Me.chkFacturacionNueva.UseVisualStyleBackColor = False
        '
        'txtPublicoGeneral
        '
        Me.txtPublicoGeneral.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPublicoGeneral.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPublicoGeneral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPublicoGeneral.Location = New System.Drawing.Point(149, 216)
        Me.txtPublicoGeneral.MaxLength = 30
        Me.txtPublicoGeneral.Name = "txtPublicoGeneral"
        Me.txtPublicoGeneral.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPublicoGeneral.Size = New System.Drawing.Size(144, 22)
        Me.txtPublicoGeneral.TabIndex = 115
        Me.txtPublicoGeneral.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPublicoGeneral.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblClientePublicoGeneral
        '
        Me.lblClientePublicoGeneral.AutoSize = True
        Me.lblClientePublicoGeneral.BackColor = System.Drawing.Color.Transparent
        Me.lblClientePublicoGeneral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientePublicoGeneral.Location = New System.Drawing.Point(28, 218)
        Me.lblClientePublicoGeneral.Name = "lblClientePublicoGeneral"
        Me.lblClientePublicoGeneral.Size = New System.Drawing.Size(101, 16)
        Me.lblClientePublicoGeneral.TabIndex = 114
        Me.lblClientePublicoGeneral.Text = "Público en General:"
        '
        'lbletiqueta
        '
        Me.lbletiqueta.AutoSize = True
        Me.lbletiqueta.BackColor = System.Drawing.Color.Transparent
        Me.lbletiqueta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbletiqueta.Location = New System.Drawing.Point(213, 190)
        Me.lbletiqueta.Name = "lbletiqueta"
        Me.lbletiqueta.Size = New System.Drawing.Size(19, 16)
        Me.lbletiqueta.TabIndex = 113
        Me.lbletiqueta.Text = "%"
        '
        'txtDescuentoFijoNoCatalogo
        '
        Me.txtDescuentoFijoNoCatalogo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDescuentoFijoNoCatalogo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDescuentoFijoNoCatalogo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuentoFijoNoCatalogo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtDescuentoFijoNoCatalogo.Location = New System.Drawing.Point(170, 188)
        Me.txtDescuentoFijoNoCatalogo.Name = "txtDescuentoFijoNoCatalogo"
        Me.txtDescuentoFijoNoCatalogo.Size = New System.Drawing.Size(40, 22)
        Me.txtDescuentoFijoNoCatalogo.TabIndex = 112
        Me.txtDescuentoFijoNoCatalogo.Text = "0"
        Me.txtDescuentoFijoNoCatalogo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDescuentoFijoNoCatalogo.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtDescuentoFijoNoCatalogo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDescuentoDips
        '
        Me.lblDescuentoDips.AutoSize = True
        Me.lblDescuentoDips.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuentoDips.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuentoDips.Location = New System.Drawing.Point(28, 188)
        Me.lblDescuentoDips.Name = "lblDescuentoDips"
        Me.lblDescuentoDips.Size = New System.Drawing.Size(141, 16)
        Me.lblDescuentoDips.TabIndex = 51
        Me.lblDescuentoDips.Text = "Descuento Fijo no Catalogo:"
        '
        'txtPasswordFTPCierre
        '
        Me.txtPasswordFTPCierre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPasswordFTPCierre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPasswordFTPCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordFTPCierre.Location = New System.Drawing.Point(148, 160)
        Me.txtPasswordFTPCierre.MaxLength = 30
        Me.txtPasswordFTPCierre.Name = "txtPasswordFTPCierre"
        Me.txtPasswordFTPCierre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordFTPCierre.Size = New System.Drawing.Size(144, 22)
        Me.txtPasswordFTPCierre.TabIndex = 50
        Me.txtPasswordFTPCierre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPasswordFTPCierre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPasswordFTPCierre
        '
        Me.lblPasswordFTPCierre.AutoSize = True
        Me.lblPasswordFTPCierre.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordFTPCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordFTPCierre.Location = New System.Drawing.Point(28, 160)
        Me.lblPasswordFTPCierre.Name = "lblPasswordFTPCierre"
        Me.lblPasswordFTPCierre.Size = New System.Drawing.Size(115, 16)
        Me.lblPasswordFTPCierre.TabIndex = 49
        Me.lblPasswordFTPCierre.Text = "Password FTP Cierre:"
        '
        'txtUsuarioFTPCierre
        '
        Me.txtUsuarioFTPCierre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUsuarioFTPCierre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUsuarioFTPCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioFTPCierre.Location = New System.Drawing.Point(148, 132)
        Me.txtUsuarioFTPCierre.MaxLength = 50
        Me.txtUsuarioFTPCierre.Name = "txtUsuarioFTPCierre"
        Me.txtUsuarioFTPCierre.Size = New System.Drawing.Size(144, 22)
        Me.txtUsuarioFTPCierre.TabIndex = 48
        Me.txtUsuarioFTPCierre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtUsuarioFTPCierre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblUsuarioFTPServer
        '
        Me.lblUsuarioFTPServer.AutoSize = True
        Me.lblUsuarioFTPServer.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuarioFTPServer.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioFTPServer.Location = New System.Drawing.Point(28, 133)
        Me.lblUsuarioFTPServer.Name = "lblUsuarioFTPServer"
        Me.lblUsuarioFTPServer.Size = New System.Drawing.Size(105, 16)
        Me.lblUsuarioFTPServer.TabIndex = 47
        Me.lblUsuarioFTPServer.Text = "Usuario FTP Cierre:"
        '
        'txtServidorFTPCierre
        '
        Me.txtServidorFTPCierre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtServidorFTPCierre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtServidorFTPCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServidorFTPCierre.Location = New System.Drawing.Point(148, 106)
        Me.txtServidorFTPCierre.MaxLength = 50
        Me.txtServidorFTPCierre.Name = "txtServidorFTPCierre"
        Me.txtServidorFTPCierre.Size = New System.Drawing.Size(419, 22)
        Me.txtServidorFTPCierre.TabIndex = 46
        Me.txtServidorFTPCierre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtServidorFTPCierre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFtpCierre
        '
        Me.lblFtpCierre.AutoSize = True
        Me.lblFtpCierre.BackColor = System.Drawing.Color.Transparent
        Me.lblFtpCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFtpCierre.Location = New System.Drawing.Point(28, 107)
        Me.lblFtpCierre.Name = "lblFtpCierre"
        Me.lblFtpCierre.Size = New System.Drawing.Size(109, 16)
        Me.lblFtpCierre.TabIndex = 45
        Me.lblFtpCierre.Text = "Servidor FTP Cierre:"
        '
        'txtSector
        '
        Me.txtSector.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtSector.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtSector.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSector.Location = New System.Drawing.Point(148, 79)
        Me.txtSector.MaxLength = 50
        Me.txtSector.Name = "txtSector"
        Me.txtSector.Size = New System.Drawing.Size(49, 22)
        Me.txtSector.TabIndex = 43
        Me.txtSector.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtSector.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblSector
        '
        Me.lblSector.AutoSize = True
        Me.lblSector.BackColor = System.Drawing.Color.Transparent
        Me.lblSector.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(28, 82)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(41, 16)
        Me.lblSector.TabIndex = 44
        Me.lblSector.Text = "Sector:"
        '
        'txtCanalDistribucion
        '
        Me.txtCanalDistribucion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCanalDistribucion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCanalDistribucion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanalDistribucion.Location = New System.Drawing.Point(148, 53)
        Me.txtCanalDistribucion.MaxLength = 50
        Me.txtCanalDistribucion.Name = "txtCanalDistribucion"
        Me.txtCanalDistribucion.Size = New System.Drawing.Size(49, 22)
        Me.txtCanalDistribucion.TabIndex = 41
        Me.txtCanalDistribucion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCanalDistribucion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCanalDistribucion
        '
        Me.lblCanalDistribucion.AutoSize = True
        Me.lblCanalDistribucion.BackColor = System.Drawing.Color.Transparent
        Me.lblCanalDistribucion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCanalDistribucion.Location = New System.Drawing.Point(28, 53)
        Me.lblCanalDistribucion.Name = "lblCanalDistribucion"
        Me.lblCanalDistribucion.Size = New System.Drawing.Size(96, 16)
        Me.lblCanalDistribucion.TabIndex = 42
        Me.lblCanalDistribucion.Text = "Canal Distribucion:"
        '
        'txtOrganizacionCompra
        '
        Me.txtOrganizacionCompra.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtOrganizacionCompra.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtOrganizacionCompra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizacionCompra.Location = New System.Drawing.Point(148, 26)
        Me.txtOrganizacionCompra.MaxLength = 50
        Me.txtOrganizacionCompra.Name = "txtOrganizacionCompra"
        Me.txtOrganizacionCompra.Size = New System.Drawing.Size(49, 22)
        Me.txtOrganizacionCompra.TabIndex = 39
        Me.txtOrganizacionCompra.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtOrganizacionCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblOrganizacionCompra
        '
        Me.lblOrganizacionCompra.AutoSize = True
        Me.lblOrganizacionCompra.BackColor = System.Drawing.Color.Transparent
        Me.lblOrganizacionCompra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizacionCompra.Location = New System.Drawing.Point(28, 26)
        Me.lblOrganizacionCompra.Name = "lblOrganizacionCompra"
        Me.lblOrganizacionCompra.Size = New System.Drawing.Size(114, 16)
        Me.lblOrganizacionCompra.TabIndex = 40
        Me.lblOrganizacionCompra.Text = "Organización Compra:"
        '
        'UiTabPage14
        '
        Me.UiTabPage14.Controls.Add(Me.GroupBox26)
        Me.UiTabPage14.Key = "tabBanamex"
        Me.UiTabPage14.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage14.Name = "UiTabPage14"
        Me.UiTabPage14.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage14.TabStop = True
        Me.UiTabPage14.Text = "Banamex"
        '
        'GroupBox26
        '
        Me.GroupBox26.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox26.Controls.Add(Me.txtUserBanamex)
        Me.GroupBox26.Controls.Add(Me.cbPagoBanamex)
        Me.GroupBox26.Controls.Add(Me.txtPasswordBanamex)
        Me.GroupBox26.Controls.Add(Me.lblPasswordBanamex)
        Me.GroupBox26.Controls.Add(Me.lblUserBanamex)
        Me.GroupBox26.Location = New System.Drawing.Point(24, 18)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(261, 112)
        Me.GroupBox26.TabIndex = 101
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "Configuración de Banamex"
        '
        'txtUserBanamex
        '
        Me.txtUserBanamex.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUserBanamex.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUserBanamex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserBanamex.Location = New System.Drawing.Point(96, 25)
        Me.txtUserBanamex.MaxLength = 30
        Me.txtUserBanamex.Name = "txtUserBanamex"
        Me.txtUserBanamex.Size = New System.Drawing.Size(144, 22)
        Me.txtUserBanamex.TabIndex = 33
        Me.txtUserBanamex.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtUserBanamex.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbPagoBanamex
        '
        Me.cbPagoBanamex.AutoSize = True
        Me.cbPagoBanamex.BackColor = System.Drawing.Color.Transparent
        Me.cbPagoBanamex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPagoBanamex.Location = New System.Drawing.Point(19, 77)
        Me.cbPagoBanamex.Name = "cbPagoBanamex"
        Me.cbPagoBanamex.Size = New System.Drawing.Size(141, 20)
        Me.cbPagoBanamex.TabIndex = 100
        Me.cbPagoBanamex.Text = "Pagos Tarjeta Banamex"
        Me.cbPagoBanamex.UseVisualStyleBackColor = False
        '
        'txtPasswordBanamex
        '
        Me.txtPasswordBanamex.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPasswordBanamex.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPasswordBanamex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordBanamex.Location = New System.Drawing.Point(96, 49)
        Me.txtPasswordBanamex.MaxLength = 30
        Me.txtPasswordBanamex.Name = "txtPasswordBanamex"
        Me.txtPasswordBanamex.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.txtPasswordBanamex.Size = New System.Drawing.Size(144, 22)
        Me.txtPasswordBanamex.TabIndex = 34
        Me.txtPasswordBanamex.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPasswordBanamex.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPasswordBanamex
        '
        Me.lblPasswordBanamex.AutoSize = True
        Me.lblPasswordBanamex.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordBanamex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordBanamex.Location = New System.Drawing.Point(16, 49)
        Me.lblPasswordBanamex.Name = "lblPasswordBanamex"
        Me.lblPasswordBanamex.Size = New System.Drawing.Size(55, 16)
        Me.lblPasswordBanamex.TabIndex = 37
        Me.lblPasswordBanamex.Text = "Password"
        '
        'lblUserBanamex
        '
        Me.lblUserBanamex.AutoSize = True
        Me.lblUserBanamex.BackColor = System.Drawing.Color.Transparent
        Me.lblUserBanamex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserBanamex.Location = New System.Drawing.Point(16, 25)
        Me.lblUserBanamex.Name = "lblUserBanamex"
        Me.lblUserBanamex.Size = New System.Drawing.Size(45, 16)
        Me.lblUserBanamex.TabIndex = 36
        Me.lblUserBanamex.Text = "Usuario"
        '
        'UiTabPage15
        '
        Me.UiTabPage15.Controls.Add(Me.GroupBox32)
        Me.UiTabPage15.Key = "tabDPVFinanciero"
        Me.UiTabPage15.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage15.Name = "UiTabPage15"
        Me.UiTabPage15.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage15.TabStop = True
        Me.UiTabPage15.Text = "DPVFinanciero"
        '
        'GroupBox32
        '
        Me.GroupBox32.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox32.Controls.Add(Me.cbMigracionFinanciero)
        Me.GroupBox32.Controls.Add(Me.txtServidorFinanciero)
        Me.GroupBox32.Controls.Add(Me.txtUsuarioFinanciero)
        Me.GroupBox32.Controls.Add(Me.btnTestDTodo)
        Me.GroupBox32.Controls.Add(Me.txtBaseFinanciero)
        Me.GroupBox32.Controls.Add(Me.lblBaseFinanciero)
        Me.GroupBox32.Controls.Add(Me.txtPasswordFinanciero)
        Me.GroupBox32.Controls.Add(Me.lblPasswordFinanciero)
        Me.GroupBox32.Controls.Add(Me.lblServidorFinanciero)
        Me.GroupBox32.Controls.Add(Me.lblUsuarioFinanciero)
        Me.GroupBox32.Controls.Add(Me.imgFinanciero)
        Me.GroupBox32.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(336, 166)
        Me.GroupBox32.TabIndex = 46
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "Configuración DPVale Financiero"
        '
        'cbMigracionFinanciero
        '
        Me.cbMigracionFinanciero.AutoSize = True
        Me.cbMigracionFinanciero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMigracionFinanciero.Location = New System.Drawing.Point(19, 132)
        Me.cbMigracionFinanciero.Name = "cbMigracionFinanciero"
        Me.cbMigracionFinanciero.Size = New System.Drawing.Size(149, 24)
        Me.cbMigracionFinanciero.TabIndex = 42
        Me.cbMigracionFinanciero.Text = "Migración Financiero"
        Me.cbMigracionFinanciero.UseVisualStyleBackColor = True
        '
        'txtServidorFinanciero
        '
        Me.txtServidorFinanciero.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtServidorFinanciero.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtServidorFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServidorFinanciero.Location = New System.Drawing.Point(96, 32)
        Me.txtServidorFinanciero.MaxLength = 50
        Me.txtServidorFinanciero.Name = "txtServidorFinanciero"
        Me.txtServidorFinanciero.Size = New System.Drawing.Size(144, 22)
        Me.txtServidorFinanciero.TabIndex = 40
        Me.txtServidorFinanciero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtServidorFinanciero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtUsuarioFinanciero
        '
        Me.txtUsuarioFinanciero.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUsuarioFinanciero.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUsuarioFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioFinanciero.Location = New System.Drawing.Point(96, 80)
        Me.txtUsuarioFinanciero.MaxLength = 30
        Me.txtUsuarioFinanciero.Name = "txtUsuarioFinanciero"
        Me.txtUsuarioFinanciero.Size = New System.Drawing.Size(144, 22)
        Me.txtUsuarioFinanciero.TabIndex = 33
        Me.txtUsuarioFinanciero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtUsuarioFinanciero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnTestDTodo
        '
        Me.btnTestDTodo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestDTodo.Location = New System.Drawing.Point(280, 96)
        Me.btnTestDTodo.Name = "btnTestDTodo"
        Me.btnTestDTodo.Size = New System.Drawing.Size(40, 24)
        Me.btnTestDTodo.TabIndex = 30
        Me.btnTestDTodo.Text = "Probar"
        '
        'txtBaseFinanciero
        '
        Me.txtBaseFinanciero.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtBaseFinanciero.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtBaseFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseFinanciero.Location = New System.Drawing.Point(96, 56)
        Me.txtBaseFinanciero.MaxLength = 50
        Me.txtBaseFinanciero.Name = "txtBaseFinanciero"
        Me.txtBaseFinanciero.Size = New System.Drawing.Size(144, 22)
        Me.txtBaseFinanciero.TabIndex = 32
        Me.txtBaseFinanciero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtBaseFinanciero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblBaseFinanciero
        '
        Me.lblBaseFinanciero.AutoSize = True
        Me.lblBaseFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.lblBaseFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseFinanciero.Location = New System.Drawing.Point(16, 56)
        Me.lblBaseFinanciero.Name = "lblBaseFinanciero"
        Me.lblBaseFinanciero.Size = New System.Drawing.Size(77, 16)
        Me.lblBaseFinanciero.TabIndex = 38
        Me.lblBaseFinanciero.Text = "Base de Datos"
        '
        'txtPasswordFinanciero
        '
        Me.txtPasswordFinanciero.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPasswordFinanciero.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPasswordFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordFinanciero.Location = New System.Drawing.Point(96, 104)
        Me.txtPasswordFinanciero.MaxLength = 30
        Me.txtPasswordFinanciero.Name = "txtPasswordFinanciero"
        Me.txtPasswordFinanciero.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.txtPasswordFinanciero.Size = New System.Drawing.Size(144, 22)
        Me.txtPasswordFinanciero.TabIndex = 34
        Me.txtPasswordFinanciero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPasswordFinanciero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPasswordFinanciero
        '
        Me.lblPasswordFinanciero.AutoSize = True
        Me.lblPasswordFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordFinanciero.Location = New System.Drawing.Point(16, 104)
        Me.lblPasswordFinanciero.Name = "lblPasswordFinanciero"
        Me.lblPasswordFinanciero.Size = New System.Drawing.Size(55, 16)
        Me.lblPasswordFinanciero.TabIndex = 37
        Me.lblPasswordFinanciero.Text = "Password"
        '
        'lblServidorFinanciero
        '
        Me.lblServidorFinanciero.AutoSize = True
        Me.lblServidorFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.lblServidorFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServidorFinanciero.Location = New System.Drawing.Point(16, 32)
        Me.lblServidorFinanciero.Name = "lblServidorFinanciero"
        Me.lblServidorFinanciero.Size = New System.Drawing.Size(49, 16)
        Me.lblServidorFinanciero.TabIndex = 35
        Me.lblServidorFinanciero.Text = "Servidor"
        '
        'lblUsuarioFinanciero
        '
        Me.lblUsuarioFinanciero.AutoSize = True
        Me.lblUsuarioFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuarioFinanciero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioFinanciero.Location = New System.Drawing.Point(16, 80)
        Me.lblUsuarioFinanciero.Name = "lblUsuarioFinanciero"
        Me.lblUsuarioFinanciero.Size = New System.Drawing.Size(45, 16)
        Me.lblUsuarioFinanciero.TabIndex = 36
        Me.lblUsuarioFinanciero.Text = "Usuario"
        '
        'imgFinanciero
        '
        Me.imgFinanciero.BackColor = System.Drawing.Color.Transparent
        Me.imgFinanciero.Location = New System.Drawing.Point(288, 40)
        Me.imgFinanciero.Name = "imgFinanciero"
        Me.imgFinanciero.Size = New System.Drawing.Size(32, 32)
        Me.imgFinanciero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFinanciero.TabIndex = 39
        Me.imgFinanciero.TabStop = False
        '
        'UiTabPage9
        '
        Me.UiTabPage9.Controls.Add(Me.GrpBx)
        Me.UiTabPage9.Key = "Diseno"
        Me.UiTabPage9.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage9.Name = "UiTabPage9"
        Me.UiTabPage9.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage9.TabStop = True
        Me.UiTabPage9.Text = "Pilotos"
        '
        'GrpBx
        '
        Me.GrpBx.BackColor = System.Drawing.Color.Transparent
        Me.GrpBx.Controls.Add(Me.cbPedidoCompra)
        Me.GrpBx.Controls.Add(Me.chkVentaFactFiscal)
        Me.GrpBx.Controls.Add(Me.cbHabilitarDPTicket)
        Me.GrpBx.Controls.Add(Me.cbEvitarInicioDia)
        Me.GrpBx.Controls.Add(Me.chkTPVVirtual)
        Me.GrpBx.Controls.Add(Me.chkEjecutarLiveUpdateInicio)
        Me.GrpBx.Controls.Add(Me.cbTraspasoEntradaSiHay)
        Me.GrpBx.Controls.Add(Me.cbAjusteAutomaticos)
        Me.GrpBx.Controls.Add(Me.chkValidaDatosDPVL)
        Me.GrpBx.Controls.Add(Me.cbVentaAsistida)
        Me.GrpBx.Controls.Add(Me.chkRecepcionMercanciaTndas)
        Me.GrpBx.Controls.Add(Me.cbBloqueoArticulosBajaCalidad)
        Me.GrpBx.Controls.Add(Me.cbMqttPOS)
        Me.GrpBx.Controls.Add(Me.cbDPCardPuntos)
        Me.GrpBx.Controls.Add(Me.chkCancelarPagosDPCard)
        Me.GrpBx.Controls.Add(Me.cbSurtidoDPStreet)
        Me.GrpBx.Controls.Add(Me.chkDPCard)
        Me.GrpBx.Controls.Add(Me.chkMostrarConcenAuditoria)
        Me.GrpBx.Controls.Add(Me.chkAplicaCS)
        Me.GrpBx.Controls.Add(Me.cbSiHayDPVale)
        Me.GrpBx.Controls.Add(Me.chkRecibirOtrosPagos)
        Me.GrpBx.Controls.Add(Me.chkGenerarReReVale)
        Me.GrpBx.Controls.Add(Me.chkPedirCelEmail)
        Me.GrpBx.Controls.Add(Me.chkDPKTPrioridadUso)
        Me.GrpBx.Controls.Add(Me.chkAuditoriaLectoraCS3070)
        Me.GrpBx.Controls.Add(Me.chkEmparejaMayorPrecio2x1)
        Me.GrpBx.Controls.Add(Me.cbEtiquetasTallas)
        Me.GrpBx.Controls.Add(Me.cbScoreBoard)
        Me.GrpBx.Controls.Add(Me.cbMotivosRechazoDPVale)
        Me.GrpBx.Controls.Add(Me.chkNuevaRegla20y30)
        Me.GrpBx.Controls.Add(Me.cbCuponDescuentos)
        Me.GrpBx.Controls.Add(Me.cbPromocionEmpleado)
        Me.GrpBx.Controls.Add(Me.chkMiniprinterTermica)
        Me.GrpBx.Controls.Add(Me.chkDescargaClientes)
        Me.GrpBx.Controls.Add(Me.chkCompreAhoraPDOpcional)
        Me.GrpBx.Controls.Add(Me.chkBorrarPreciosCierre)
        Me.GrpBx.Controls.Add(Me.chkNewDosPorUnoYMedio)
        Me.GrpBx.Controls.Add(Me.chkEtiquetasLaser)
        Me.GrpBx.Controls.Add(Me.chkDIPNewDescuento)
        Me.GrpBx.Controls.Add(Me.chkManagerPC)
        Me.GrpBx.Controls.Add(Me.chkSMS)
        Me.GrpBx.Controls.Add(Me.chkTPV)
        Me.GrpBx.Controls.Add(Me.chkSccanerIFE)
        Me.GrpBx.Controls.Add(Me.chkValidacionFS)
        Me.GrpBx.Controls.Add(Me.chkboxCedula)
        Me.GrpBx.Controls.Add(Me.ChkBxImpresoraHP)
        Me.GrpBx.Controls.Add(Me.ChckBxMiniPrinter)
        Me.GrpBx.Controls.Add(Me.ChckBxCargaInicial)
        Me.GrpBx.Location = New System.Drawing.Point(8, 8)
        Me.GrpBx.Name = "GrpBx"
        Me.GrpBx.Size = New System.Drawing.Size(688, 408)
        Me.GrpBx.TabIndex = 30
        Me.GrpBx.TabStop = False
        Me.GrpBx.Text = "Otras Configuraciones"
        '
        'cbPedidoCompra
        '
        Me.cbPedidoCompra.AutoSize = True
        Me.cbPedidoCompra.BackColor = System.Drawing.Color.Transparent
        Me.cbPedidoCompra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPedidoCompra.Location = New System.Drawing.Point(448, 384)
        Me.cbPedidoCompra.Name = "cbPedidoCompra"
        Me.cbPedidoCompra.Size = New System.Drawing.Size(113, 20)
        Me.cbPedidoCompra.TabIndex = 101
        Me.cbPedidoCompra.Text = "Pedido de compra"
        Me.cbPedidoCompra.UseVisualStyleBackColor = False
        '
        'chkVentaFactFiscal
        '
        Me.chkVentaFactFiscal.AutoSize = True
        Me.chkVentaFactFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkVentaFactFiscal.Location = New System.Drawing.Point(247, 384)
        Me.chkVentaFactFiscal.Name = "chkVentaFactFiscal"
        Me.chkVentaFactFiscal.Size = New System.Drawing.Size(181, 20)
        Me.chkVentaFactFiscal.TabIndex = 100
        Me.chkVentaFactFiscal.Text = "Tipo de Venta Facturación Fiscal"
        Me.chkVentaFactFiscal.UseVisualStyleBackColor = True
        '
        'cbHabilitarDPTicket
        '
        Me.cbHabilitarDPTicket.AutoSize = True
        Me.cbHabilitarDPTicket.BackColor = System.Drawing.Color.Transparent
        Me.cbHabilitarDPTicket.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHabilitarDPTicket.Location = New System.Drawing.Point(16, 384)
        Me.cbHabilitarDPTicket.Name = "cbHabilitarDPTicket"
        Me.cbHabilitarDPTicket.Size = New System.Drawing.Size(110, 20)
        Me.cbHabilitarDPTicket.TabIndex = 99
        Me.cbHabilitarDPTicket.Text = "Habilitar DPTicket"
        Me.cbHabilitarDPTicket.UseVisualStyleBackColor = False
        '
        'cbEvitarInicioDia
        '
        Me.cbEvitarInicioDia.AutoSize = True
        Me.cbEvitarInicioDia.BackColor = System.Drawing.Color.Transparent
        Me.cbEvitarInicioDia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEvitarInicioDia.Location = New System.Drawing.Point(448, 360)
        Me.cbEvitarInicioDia.Name = "cbEvitarInicioDia"
        Me.cbEvitarInicioDia.Size = New System.Drawing.Size(115, 20)
        Me.cbEvitarInicioDia.TabIndex = 98
        Me.cbEvitarInicioDia.Text = "Evitar Inicio de Día"
        Me.cbEvitarInicioDia.UseVisualStyleBackColor = False
        '
        'chkTPVVirtual
        '
        Me.chkTPVVirtual.AutoSize = True
        Me.chkTPVVirtual.BackColor = System.Drawing.Color.Transparent
        Me.chkTPVVirtual.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTPVVirtual.Location = New System.Drawing.Point(448, 336)
        Me.chkTPVVirtual.Name = "chkTPVVirtual"
        Me.chkTPVVirtual.Size = New System.Drawing.Size(80, 20)
        Me.chkTPVVirtual.TabIndex = 97
        Me.chkTPVVirtual.Text = "TPV Virtual"
        Me.chkTPVVirtual.UseVisualStyleBackColor = False
        '
        'chkEjecutarLiveUpdateInicio
        '
        Me.chkEjecutarLiveUpdateInicio.AutoSize = True
        Me.chkEjecutarLiveUpdateInicio.BackColor = System.Drawing.Color.Transparent
        Me.chkEjecutarLiveUpdateInicio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEjecutarLiveUpdateInicio.Location = New System.Drawing.Point(448, 312)
        Me.chkEjecutarLiveUpdateInicio.Name = "chkEjecutarLiveUpdateInicio"
        Me.chkEjecutarLiveUpdateInicio.Size = New System.Drawing.Size(159, 20)
        Me.chkEjecutarLiveUpdateInicio.TabIndex = 95
        Me.chkEjecutarLiveUpdateInicio.Text = "Ejecutar LiveUpdate al inicio"
        Me.chkEjecutarLiveUpdateInicio.UseVisualStyleBackColor = False
        '
        'cbTraspasoEntradaSiHay
        '
        Me.cbTraspasoEntradaSiHay.AutoSize = True
        Me.cbTraspasoEntradaSiHay.BackColor = System.Drawing.Color.Transparent
        Me.cbTraspasoEntradaSiHay.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTraspasoEntradaSiHay.Location = New System.Drawing.Point(247, 360)
        Me.cbTraspasoEntradaSiHay.Name = "cbTraspasoEntradaSiHay"
        Me.cbTraspasoEntradaSiHay.Size = New System.Drawing.Size(157, 20)
        Me.cbTraspasoEntradaSiHay.TabIndex = 94
        Me.cbTraspasoEntradaSiHay.Text = "Traspaso de entrada si hay"
        Me.cbTraspasoEntradaSiHay.UseVisualStyleBackColor = False
        '
        'cbAjusteAutomaticos
        '
        Me.cbAjusteAutomaticos.AutoSize = True
        Me.cbAjusteAutomaticos.BackColor = System.Drawing.Color.Transparent
        Me.cbAjusteAutomaticos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAjusteAutomaticos.Location = New System.Drawing.Point(16, 360)
        Me.cbAjusteAutomaticos.Name = "cbAjusteAutomaticos"
        Me.cbAjusteAutomaticos.Size = New System.Drawing.Size(172, 20)
        Me.cbAjusteAutomaticos.TabIndex = 93
        Me.cbAjusteAutomaticos.Text = "Ajuste Automatico de sobrantes"
        Me.cbAjusteAutomaticos.UseVisualStyleBackColor = False
        '
        'chkValidaDatosDPVL
        '
        Me.chkValidaDatosDPVL.AutoSize = True
        Me.chkValidaDatosDPVL.BackColor = System.Drawing.Color.Transparent
        Me.chkValidaDatosDPVL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValidaDatosDPVL.Location = New System.Drawing.Point(448, 288)
        Me.chkValidaDatosDPVL.Name = "chkValidaDatosDPVL"
        Me.chkValidaDatosDPVL.Size = New System.Drawing.Size(183, 20)
        Me.chkValidaDatosDPVL.TabIndex = 92
        Me.chkValidaDatosDPVL.Text = "Valida Datos Obligatorios DPVale"
        Me.chkValidaDatosDPVL.UseVisualStyleBackColor = False
        '
        'cbVentaAsistida
        '
        Me.cbVentaAsistida.AutoSize = True
        Me.cbVentaAsistida.BackColor = System.Drawing.Color.Transparent
        Me.cbVentaAsistida.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVentaAsistida.Location = New System.Drawing.Point(247, 336)
        Me.cbVentaAsistida.Name = "cbVentaAsistida"
        Me.cbVentaAsistida.Size = New System.Drawing.Size(92, 20)
        Me.cbVentaAsistida.TabIndex = 91
        Me.cbVentaAsistida.Text = "Venta Asistida"
        Me.cbVentaAsistida.UseVisualStyleBackColor = False
        '
        'chkRecepcionMercanciaTndas
        '
        Me.chkRecepcionMercanciaTndas.AutoSize = True
        Me.chkRecepcionMercanciaTndas.BackColor = System.Drawing.Color.Transparent
        Me.chkRecepcionMercanciaTndas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecepcionMercanciaTndas.Location = New System.Drawing.Point(16, 336)
        Me.chkRecepcionMercanciaTndas.Name = "chkRecepcionMercanciaTndas"
        Me.chkRecepcionMercanciaTndas.Size = New System.Drawing.Size(192, 20)
        Me.chkRecepcionMercanciaTndas.TabIndex = 90
        Me.chkRecepcionMercanciaTndas.Text = "Recepción de Mercancia en Tndas"
        Me.chkRecepcionMercanciaTndas.UseVisualStyleBackColor = False
        '
        'cbBloqueoArticulosBajaCalidad
        '
        Me.cbBloqueoArticulosBajaCalidad.AutoSize = True
        Me.cbBloqueoArticulosBajaCalidad.BackColor = System.Drawing.Color.Transparent
        Me.cbBloqueoArticulosBajaCalidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBloqueoArticulosBajaCalidad.Location = New System.Drawing.Point(247, 312)
        Me.cbBloqueoArticulosBajaCalidad.Name = "cbBloqueoArticulosBajaCalidad"
        Me.cbBloqueoArticulosBajaCalidad.Size = New System.Drawing.Size(195, 20)
        Me.cbBloqueoArticulosBajaCalidad.TabIndex = 87
        Me.cbBloqueoArticulosBajaCalidad.Text = "Bloqueo a Artículos de Baja Calidad"
        Me.cbBloqueoArticulosBajaCalidad.UseVisualStyleBackColor = False
        '
        'cbMqttPOS
        '
        Me.cbMqttPOS.AutoSize = True
        Me.cbMqttPOS.BackColor = System.Drawing.Color.Transparent
        Me.cbMqttPOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMqttPOS.Location = New System.Drawing.Point(16, 312)
        Me.cbMqttPOS.Name = "cbMqttPOS"
        Me.cbMqttPOS.Size = New System.Drawing.Size(83, 20)
        Me.cbMqttPOS.TabIndex = 86
        Me.cbMqttPOS.Text = "MQTT POS"
        Me.cbMqttPOS.UseVisualStyleBackColor = False
        '
        'cbDPCardPuntos
        '
        Me.cbDPCardPuntos.AutoSize = True
        Me.cbDPCardPuntos.BackColor = System.Drawing.Color.Transparent
        Me.cbDPCardPuntos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDPCardPuntos.Location = New System.Drawing.Point(448, 262)
        Me.cbDPCardPuntos.Name = "cbDPCardPuntos"
        Me.cbDPCardPuntos.Size = New System.Drawing.Size(132, 20)
        Me.cbDPCardPuntos.TabIndex = 85
        Me.cbDPCardPuntos.Text = "Aplica DPCard Puntos"
        Me.cbDPCardPuntos.UseVisualStyleBackColor = False
        '
        'chkCancelarPagosDPCard
        '
        Me.chkCancelarPagosDPCard.AutoSize = True
        Me.chkCancelarPagosDPCard.BackColor = System.Drawing.Color.Transparent
        Me.chkCancelarPagosDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancelarPagosDPCard.Location = New System.Drawing.Point(247, 288)
        Me.chkCancelarPagosDPCard.Name = "chkCancelarPagosDPCard"
        Me.chkCancelarPagosDPCard.Size = New System.Drawing.Size(148, 20)
        Me.chkCancelarPagosDPCard.TabIndex = 84
        Me.chkCancelarPagosDPCard.Text = "Cancelar Pagos DP Card"
        Me.chkCancelarPagosDPCard.UseVisualStyleBackColor = False
        '
        'cbSurtidoDPStreet
        '
        Me.cbSurtidoDPStreet.AutoSize = True
        Me.cbSurtidoDPStreet.BackColor = System.Drawing.Color.Transparent
        Me.cbSurtidoDPStreet.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSurtidoDPStreet.Location = New System.Drawing.Point(16, 288)
        Me.cbSurtidoDPStreet.Name = "cbSurtidoDPStreet"
        Me.cbSurtidoDPStreet.Size = New System.Drawing.Size(136, 20)
        Me.cbSurtidoDPStreet.TabIndex = 83
        Me.cbSurtidoDPStreet.Text = "Aplica Surtido DPStreet"
        Me.cbSurtidoDPStreet.UseVisualStyleBackColor = False
        '
        'chkDPCard
        '
        Me.chkDPCard.AutoSize = True
        Me.chkDPCard.BackColor = System.Drawing.Color.Transparent
        Me.chkDPCard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDPCard.Location = New System.Drawing.Point(247, 262)
        Me.chkDPCard.Name = "chkDPCard"
        Me.chkDPCard.Size = New System.Drawing.Size(100, 20)
        Me.chkDPCard.TabIndex = 82
        Me.chkDPCard.Text = "Aplica DP Card"
        Me.chkDPCard.UseVisualStyleBackColor = False
        '
        'chkMostrarConcenAuditoria
        '
        Me.chkMostrarConcenAuditoria.AutoSize = True
        Me.chkMostrarConcenAuditoria.BackColor = System.Drawing.Color.Transparent
        Me.chkMostrarConcenAuditoria.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMostrarConcenAuditoria.Location = New System.Drawing.Point(16, 264)
        Me.chkMostrarConcenAuditoria.Name = "chkMostrarConcenAuditoria"
        Me.chkMostrarConcenAuditoria.Size = New System.Drawing.Size(171, 20)
        Me.chkMostrarConcenAuditoria.TabIndex = 81
        Me.chkMostrarConcenAuditoria.Text = "Mostrar Concentrado Auditoria"
        Me.chkMostrarConcenAuditoria.UseVisualStyleBackColor = False
        '
        'chkAplicaCS
        '
        Me.chkAplicaCS.AutoSize = True
        Me.chkAplicaCS.BackColor = System.Drawing.Color.Transparent
        Me.chkAplicaCS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAplicaCS.Location = New System.Drawing.Point(448, 240)
        Me.chkAplicaCS.Name = "chkAplicaCS"
        Me.chkAplicaCS.Size = New System.Drawing.Size(120, 20)
        Me.chkAplicaCS.TabIndex = 80
        Me.chkAplicaCS.Text = "Aplica Cross Selling"
        Me.chkAplicaCS.UseVisualStyleBackColor = False
        '
        'cbSiHayDPVale
        '
        Me.cbSiHayDPVale.AutoSize = True
        Me.cbSiHayDPVale.BackColor = System.Drawing.Color.Transparent
        Me.cbSiHayDPVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSiHayDPVale.Location = New System.Drawing.Point(448, 216)
        Me.cbSiHayDPVale.Name = "cbSiHayDPVale"
        Me.cbSiHayDPVale.Size = New System.Drawing.Size(98, 20)
        Me.cbSiHayDPVale.TabIndex = 79
        Me.cbSiHayDPVale.Text = "Si Hay DPVale"
        Me.cbSiHayDPVale.UseVisualStyleBackColor = False
        '
        'chkRecibirOtrosPagos
        '
        Me.chkRecibirOtrosPagos.AutoSize = True
        Me.chkRecibirOtrosPagos.BackColor = System.Drawing.Color.Transparent
        Me.chkRecibirOtrosPagos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecibirOtrosPagos.Location = New System.Drawing.Point(448, 192)
        Me.chkRecibirOtrosPagos.Name = "chkRecibirOtrosPagos"
        Me.chkRecibirOtrosPagos.Size = New System.Drawing.Size(151, 20)
        Me.chkRecibirOtrosPagos.TabIndex = 78
        Me.chkRecibirOtrosPagos.Text = "Recibir Pagos Ecommerce"
        Me.chkRecibirOtrosPagos.UseVisualStyleBackColor = False
        '
        'chkGenerarReReVale
        '
        Me.chkGenerarReReVale.AutoSize = True
        Me.chkGenerarReReVale.BackColor = System.Drawing.Color.Transparent
        Me.chkGenerarReReVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGenerarReReVale.Location = New System.Drawing.Point(448, 168)
        Me.chkGenerarReReVale.Name = "chkGenerarReReVale"
        Me.chkGenerarReReVale.Size = New System.Drawing.Size(119, 20)
        Me.chkGenerarReReVale.TabIndex = 77
        Me.chkGenerarReReVale.Text = "Generar ReReVale"
        Me.chkGenerarReReVale.UseVisualStyleBackColor = False
        '
        'chkPedirCelEmail
        '
        Me.chkPedirCelEmail.AutoSize = True
        Me.chkPedirCelEmail.BackColor = System.Drawing.Color.Transparent
        Me.chkPedirCelEmail.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPedirCelEmail.Location = New System.Drawing.Point(448, 144)
        Me.chkPedirCelEmail.Name = "chkPedirCelEmail"
        Me.chkPedirCelEmail.Size = New System.Drawing.Size(149, 20)
        Me.chkPedirCelEmail.TabIndex = 76
        Me.chkPedirCelEmail.Text = "Pedir Cel Email Comienzo"
        Me.chkPedirCelEmail.UseVisualStyleBackColor = False
        '
        'chkDPKTPrioridadUso
        '
        Me.chkDPKTPrioridadUso.AutoSize = True
        Me.chkDPKTPrioridadUso.BackColor = System.Drawing.Color.Transparent
        Me.chkDPKTPrioridadUso.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDPKTPrioridadUso.Location = New System.Drawing.Point(448, 120)
        Me.chkDPKTPrioridadUso.Name = "chkDPKTPrioridadUso"
        Me.chkDPKTPrioridadUso.Size = New System.Drawing.Size(162, 20)
        Me.chkDPKTPrioridadUso.TabIndex = 75
        Me.chkDPKTPrioridadUso.Text = "Prioridad Uso en DPaquetes"
        Me.chkDPKTPrioridadUso.UseVisualStyleBackColor = False
        '
        'chkAuditoriaLectoraCS3070
        '
        Me.chkAuditoriaLectoraCS3070.AutoSize = True
        Me.chkAuditoriaLectoraCS3070.BackColor = System.Drawing.Color.Transparent
        Me.chkAuditoriaLectoraCS3070.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAuditoriaLectoraCS3070.Location = New System.Drawing.Point(448, 96)
        Me.chkAuditoriaLectoraCS3070.Name = "chkAuditoriaLectoraCS3070"
        Me.chkAuditoriaLectoraCS3070.Size = New System.Drawing.Size(174, 20)
        Me.chkAuditoriaLectoraCS3070.TabIndex = 74
        Me.chkAuditoriaLectoraCS3070.Text = "Usar Auditoria Lectora CS3070"
        Me.chkAuditoriaLectoraCS3070.UseVisualStyleBackColor = False
        '
        'chkEmparejaMayorPrecio2x1
        '
        Me.chkEmparejaMayorPrecio2x1.AutoSize = True
        Me.chkEmparejaMayorPrecio2x1.BackColor = System.Drawing.Color.Transparent
        Me.chkEmparejaMayorPrecio2x1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmparejaMayorPrecio2x1.Location = New System.Drawing.Point(448, 72)
        Me.chkEmparejaMayorPrecio2x1.Name = "chkEmparejaMayorPrecio2x1"
        Me.chkEmparejaMayorPrecio2x1.Size = New System.Drawing.Size(169, 20)
        Me.chkEmparejaMayorPrecio2x1.TabIndex = 73
        Me.chkEmparejaMayorPrecio2x1.Text = "Empareja Mayor Precio 2x1½"
        Me.chkEmparejaMayorPrecio2x1.UseVisualStyleBackColor = False
        '
        'cbEtiquetasTallas
        '
        Me.cbEtiquetasTallas.AutoSize = True
        Me.cbEtiquetasTallas.BackColor = System.Drawing.Color.Transparent
        Me.cbEtiquetasTallas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEtiquetasTallas.Location = New System.Drawing.Point(448, 48)
        Me.cbEtiquetasTallas.Name = "cbEtiquetasTallas"
        Me.cbEtiquetasTallas.Size = New System.Drawing.Size(140, 20)
        Me.cbEtiquetasTallas.TabIndex = 72
        Me.cbEtiquetasTallas.Text = "Imprimir Etiquetas Tallas"
        Me.cbEtiquetasTallas.UseVisualStyleBackColor = False
        '
        'cbScoreBoard
        '
        Me.cbScoreBoard.AutoSize = True
        Me.cbScoreBoard.BackColor = System.Drawing.Color.Transparent
        Me.cbScoreBoard.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbScoreBoard.Location = New System.Drawing.Point(448, 24)
        Me.cbScoreBoard.Name = "cbScoreBoard"
        Me.cbScoreBoard.Size = New System.Drawing.Size(123, 20)
        Me.cbScoreBoard.TabIndex = 71
        Me.cbScoreBoard.Text = "Mostrar ScoreBoard"
        Me.cbScoreBoard.UseVisualStyleBackColor = False
        '
        'cbMotivosRechazoDPVale
        '
        Me.cbMotivosRechazoDPVale.AutoSize = True
        Me.cbMotivosRechazoDPVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMotivosRechazoDPVale.Location = New System.Drawing.Point(247, 240)
        Me.cbMotivosRechazoDPVale.Name = "cbMotivosRechazoDPVale"
        Me.cbMotivosRechazoDPVale.Size = New System.Drawing.Size(162, 20)
        Me.cbMotivosRechazoDPVale.TabIndex = 70
        Me.cbMotivosRechazoDPVale.Text = "Motivos de Rechazo DPVale"
        '
        'chkNuevaRegla20y30
        '
        Me.chkNuevaRegla20y30.AutoSize = True
        Me.chkNuevaRegla20y30.BackColor = System.Drawing.Color.Transparent
        Me.chkNuevaRegla20y30.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNuevaRegla20y30.Location = New System.Drawing.Point(16, 240)
        Me.chkNuevaRegla20y30.Name = "chkNuevaRegla20y30"
        Me.chkNuevaRegla20y30.Size = New System.Drawing.Size(129, 20)
        Me.chkNuevaRegla20y30.TabIndex = 69
        Me.chkNuevaRegla20y30.Text = "Nueva Regla 20 y 30"
        Me.chkNuevaRegla20y30.UseVisualStyleBackColor = False
        '
        'cbCuponDescuentos
        '
        Me.cbCuponDescuentos.AutoSize = True
        Me.cbCuponDescuentos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCuponDescuentos.Location = New System.Drawing.Point(247, 216)
        Me.cbCuponDescuentos.Name = "cbCuponDescuentos"
        Me.cbCuponDescuentos.Size = New System.Drawing.Size(135, 20)
        Me.cbCuponDescuentos.TabIndex = 68
        Me.cbCuponDescuentos.Text = "Cupon con descuentos"
        '
        'cbPromocionEmpleado
        '
        Me.cbPromocionEmpleado.AutoSize = True
        Me.cbPromocionEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.cbPromocionEmpleado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPromocionEmpleado.Location = New System.Drawing.Point(16, 216)
        Me.cbPromocionEmpleado.Name = "cbPromocionEmpleado"
        Me.cbPromocionEmpleado.Size = New System.Drawing.Size(127, 20)
        Me.cbPromocionEmpleado.TabIndex = 67
        Me.cbPromocionEmpleado.Text = "Promocion Empleado"
        Me.cbPromocionEmpleado.UseVisualStyleBackColor = False
        '
        'chkMiniprinterTermica
        '
        Me.chkMiniprinterTermica.AutoSize = True
        Me.chkMiniprinterTermica.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMiniprinterTermica.Location = New System.Drawing.Point(247, 192)
        Me.chkMiniprinterTermica.Name = "chkMiniprinterTermica"
        Me.chkMiniprinterTermica.Size = New System.Drawing.Size(117, 20)
        Me.chkMiniprinterTermica.TabIndex = 67
        Me.chkMiniprinterTermica.Text = "Miniprinter Termica"
        '
        'chkDescargaClientes
        '
        Me.chkDescargaClientes.AutoSize = True
        Me.chkDescargaClientes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDescargaClientes.Location = New System.Drawing.Point(247, 168)
        Me.chkDescargaClientes.Name = "chkDescargaClientes"
        Me.chkDescargaClientes.Size = New System.Drawing.Size(139, 20)
        Me.chkDescargaClientes.TabIndex = 40
        Me.chkDescargaClientes.Text = "Usar Descarga Clientes"
        '
        'chkCompreAhoraPDOpcional
        '
        Me.chkCompreAhoraPDOpcional.AutoSize = True
        Me.chkCompreAhoraPDOpcional.BackColor = System.Drawing.Color.Transparent
        Me.chkCompreAhoraPDOpcional.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompreAhoraPDOpcional.Location = New System.Drawing.Point(16, 192)
        Me.chkCompreAhoraPDOpcional.Name = "chkCompreAhoraPDOpcional"
        Me.chkCompreAhoraPDOpcional.Size = New System.Drawing.Size(223, 20)
        Me.chkCompreAhoraPDOpcional.TabIndex = 66
        Me.chkCompreAhoraPDOpcional.Text = "Compre ahora y pague después opcional"
        Me.chkCompreAhoraPDOpcional.UseVisualStyleBackColor = False
        '
        'chkBorrarPreciosCierre
        '
        Me.chkBorrarPreciosCierre.AutoSize = True
        Me.chkBorrarPreciosCierre.BackColor = System.Drawing.Color.Transparent
        Me.chkBorrarPreciosCierre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBorrarPreciosCierre.Location = New System.Drawing.Point(247, 144)
        Me.chkBorrarPreciosCierre.Name = "chkBorrarPreciosCierre"
        Me.chkBorrarPreciosCierre.Size = New System.Drawing.Size(141, 20)
        Me.chkBorrarPreciosCierre.TabIndex = 65
        Me.chkBorrarPreciosCierre.Text = "Borrar Precios Al Cierre"
        Me.chkBorrarPreciosCierre.UseVisualStyleBackColor = False
        '
        'chkNewDosPorUnoYMedio
        '
        Me.chkNewDosPorUnoYMedio.AutoSize = True
        Me.chkNewDosPorUnoYMedio.BackColor = System.Drawing.Color.Transparent
        Me.chkNewDosPorUnoYMedio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNewDosPorUnoYMedio.Location = New System.Drawing.Point(247, 120)
        Me.chkNewDosPorUnoYMedio.Name = "chkNewDosPorUnoYMedio"
        Me.chkNewDosPorUnoYMedio.Size = New System.Drawing.Size(129, 20)
        Me.chkNewDosPorUnoYMedio.TabIndex = 64
        Me.chkNewDosPorUnoYMedio.Text = "Nueva Regla 2 x 1 ½"
        Me.chkNewDosPorUnoYMedio.UseVisualStyleBackColor = False
        '
        'chkEtiquetasLaser
        '
        Me.chkEtiquetasLaser.AutoSize = True
        Me.chkEtiquetasLaser.BackColor = System.Drawing.Color.Transparent
        Me.chkEtiquetasLaser.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEtiquetasLaser.Location = New System.Drawing.Point(247, 96)
        Me.chkEtiquetasLaser.Name = "chkEtiquetasLaser"
        Me.chkEtiquetasLaser.Size = New System.Drawing.Size(139, 20)
        Me.chkEtiquetasLaser.TabIndex = 61
        Me.chkEtiquetasLaser.Text = "Imprimir Etiquetas Laser"
        Me.chkEtiquetasLaser.UseVisualStyleBackColor = False
        '
        'chkDIPNewDescuento
        '
        Me.chkDIPNewDescuento.AutoSize = True
        Me.chkDIPNewDescuento.BackColor = System.Drawing.Color.Transparent
        Me.chkDIPNewDescuento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDIPNewDescuento.Location = New System.Drawing.Point(247, 72)
        Me.chkDIPNewDescuento.Name = "chkDIPNewDescuento"
        Me.chkDIPNewDescuento.Size = New System.Drawing.Size(148, 20)
        Me.chkDIPNewDescuento.TabIndex = 60
        Me.chkDIPNewDescuento.Text = "Nuevos Descuentos DIPs"
        Me.chkDIPNewDescuento.UseVisualStyleBackColor = False
        '
        'chkManagerPC
        '
        Me.chkManagerPC.AutoSize = True
        Me.chkManagerPC.BackColor = System.Drawing.Color.Transparent
        Me.chkManagerPC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManagerPC.Location = New System.Drawing.Point(247, 48)
        Me.chkManagerPC.Name = "chkManagerPC"
        Me.chkManagerPC.Size = New System.Drawing.Size(178, 20)
        Me.chkManagerPC.TabIndex = 59
        Me.chkManagerPC.Text = "Muestra Manager Panel Control"
        Me.chkManagerPC.UseVisualStyleBackColor = False
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.BackColor = System.Drawing.Color.Transparent
        Me.chkSMS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSMS.Location = New System.Drawing.Point(247, 24)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(106, 20)
        Me.chkSMS.TabIndex = 58
        Me.chkSMS.Text = "Capturar Celular"
        Me.chkSMS.UseVisualStyleBackColor = False
        '
        'chkTPV
        '
        Me.chkTPV.AutoSize = True
        Me.chkTPV.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTPV.Location = New System.Drawing.Point(16, 168)
        Me.chkTPV.Name = "chkTPV"
        Me.chkTPV.Size = New System.Drawing.Size(74, 20)
        Me.chkTPV.TabIndex = 39
        Me.chkTPV.Text = "Usar TPV"
        '
        'chkSccanerIFE
        '
        Me.chkSccanerIFE.AutoSize = True
        Me.chkSccanerIFE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSccanerIFE.Location = New System.Drawing.Point(16, 144)
        Me.chkSccanerIFE.Name = "chkSccanerIFE"
        Me.chkSccanerIFE.Size = New System.Drawing.Size(158, 20)
        Me.chkSccanerIFE.TabIndex = 38
        Me.chkSccanerIFE.Text = "Usar Scanner Credenciales"
        '
        'chkValidacionFS
        '
        Me.chkValidacionFS.AutoSize = True
        Me.chkValidacionFS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkValidacionFS.Location = New System.Drawing.Point(16, 120)
        Me.chkValidacionFS.Name = "chkValidacionFS"
        Me.chkValidacionFS.Size = New System.Drawing.Size(173, 20)
        Me.chkValidacionFS.TabIndex = 37
        Me.chkValidacionFS.Text = "No Validar Sobrantes/Faltantes"
        '
        'chkboxCedula
        '
        Me.chkboxCedula.AutoSize = True
        Me.chkboxCedula.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxCedula.Location = New System.Drawing.Point(16, 96)
        Me.chkboxCedula.Name = "chkboxCedula"
        Me.chkboxCedula.Size = New System.Drawing.Size(131, 20)
        Me.chkboxCedula.TabIndex = 24
        Me.chkboxCedula.Text = "Imprimir Cedula Fiscal"
        '
        'ChkBxImpresoraHP
        '
        Me.ChkBxImpresoraHP.AutoSize = True
        Me.ChkBxImpresoraHP.BackColor = System.Drawing.Color.Transparent
        Me.ChkBxImpresoraHP.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBxImpresoraHP.Location = New System.Drawing.Point(16, 48)
        Me.ChkBxImpresoraHP.Name = "ChkBxImpresoraHP"
        Me.ChkBxImpresoraHP.Size = New System.Drawing.Size(92, 20)
        Me.ChkBxImpresoraHP.TabIndex = 22
        Me.ChkBxImpresoraHP.Text = "Impresora Hp"
        Me.ChkBxImpresoraHP.UseVisualStyleBackColor = False
        '
        'ChckBxMiniPrinter
        '
        Me.ChckBxMiniPrinter.AutoSize = True
        Me.ChckBxMiniPrinter.BackColor = System.Drawing.Color.Transparent
        Me.ChckBxMiniPrinter.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxMiniPrinter.Location = New System.Drawing.Point(16, 72)
        Me.ChckBxMiniPrinter.Name = "ChckBxMiniPrinter"
        Me.ChckBxMiniPrinter.Size = New System.Drawing.Size(77, 20)
        Me.ChckBxMiniPrinter.TabIndex = 23
        Me.ChckBxMiniPrinter.Text = "MiniPrinter"
        Me.ChckBxMiniPrinter.UseVisualStyleBackColor = False
        '
        'ChckBxCargaInicial
        '
        Me.ChckBxCargaInicial.AutoSize = True
        Me.ChckBxCargaInicial.BackColor = System.Drawing.Color.Transparent
        Me.ChckBxCargaInicial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxCargaInicial.Location = New System.Drawing.Point(16, 24)
        Me.ChckBxCargaInicial.Name = "ChckBxCargaInicial"
        Me.ChckBxCargaInicial.Size = New System.Drawing.Size(86, 20)
        Me.ChckBxCargaInicial.TabIndex = 21
        Me.ChckBxCargaInicial.Text = "Carga Inicial"
        Me.ChckBxCargaInicial.UseVisualStyleBackColor = False
        '
        'UiTabPage16
        '
        Me.UiTabPage16.Controls.Add(Me.GroupBox34)
        Me.UiTabPage16.Controls.Add(Me.GroupBox33)
        Me.UiTabPage16.Location = New System.Drawing.Point(1, 28)
        Me.UiTabPage16.Name = "UiTabPage16"
        Me.UiTabPage16.Size = New System.Drawing.Size(704, 421)
        Me.UiTabPage16.TabStop = True
        Me.UiTabPage16.Text = "Pagos Ecomm"
        '
        'GroupBox34
        '
        Me.GroupBox34.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox34.Controls.Add(Me.txtImpresoraEcommerce)
        Me.GroupBox34.Controls.Add(Me.lblmpresoraEcomm)
        Me.GroupBox34.Controls.Add(Me.Label141)
        Me.GroupBox34.Controls.Add(Me.txtServicioEcomm)
        Me.GroupBox34.Location = New System.Drawing.Point(400, 20)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(295, 142)
        Me.GroupBox34.TabIndex = 1
        Me.GroupBox34.TabStop = False
        Me.GroupBox34.Text = "Servicio Ecommerce"
        '
        'txtImpresoraEcommerce
        '
        Me.txtImpresoraEcommerce.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtImpresoraEcommerce.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtImpresoraEcommerce.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpresoraEcommerce.Location = New System.Drawing.Point(136, 81)
        Me.txtImpresoraEcommerce.MaxLength = 50
        Me.txtImpresoraEcommerce.Name = "txtImpresoraEcommerce"
        Me.txtImpresoraEcommerce.Size = New System.Drawing.Size(153, 22)
        Me.txtImpresoraEcommerce.TabIndex = 45
        Me.txtImpresoraEcommerce.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtImpresoraEcommerce.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblmpresoraEcomm
        '
        Me.lblmpresoraEcomm.AutoSize = True
        Me.lblmpresoraEcomm.BackColor = System.Drawing.Color.Transparent
        Me.lblmpresoraEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmpresoraEcomm.Location = New System.Drawing.Point(19, 82)
        Me.lblmpresoraEcomm.Name = "lblmpresoraEcomm"
        Me.lblmpresoraEcomm.Size = New System.Drawing.Size(117, 16)
        Me.lblmpresoraEcomm.TabIndex = 44
        Me.lblmpresoraEcomm.Text = "Impresora Ecommerce:"
        '
        'Label141
        '
        Me.Label141.AutoSize = True
        Me.Label141.BackColor = System.Drawing.Color.Transparent
        Me.Label141.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label141.Location = New System.Drawing.Point(19, 44)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(25, 16)
        Me.Label141.TabIndex = 43
        Me.Label141.Text = "Url:"
        '
        'txtServicioEcomm
        '
        Me.txtServicioEcomm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtServicioEcomm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtServicioEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicioEcomm.Location = New System.Drawing.Point(64, 40)
        Me.txtServicioEcomm.MaxLength = 50
        Me.txtServicioEcomm.Name = "txtServicioEcomm"
        Me.txtServicioEcomm.Size = New System.Drawing.Size(225, 22)
        Me.txtServicioEcomm.TabIndex = 42
        Me.txtServicioEcomm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtServicioEcomm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'GroupBox33
        '
        Me.GroupBox33.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox33.Controls.Add(Me.imgDBEcomm)
        Me.GroupBox33.Controls.Add(Me.btnPagoEcomm)
        Me.GroupBox33.Controls.Add(Me.txtPasswordDatosEcomm)
        Me.GroupBox33.Controls.Add(Me.txtUserDatosEcomm)
        Me.GroupBox33.Controls.Add(Me.txtBDDatosEcomm)
        Me.GroupBox33.Controls.Add(Me.txtServerDatosEcomm)
        Me.GroupBox33.Controls.Add(Me.Label140)
        Me.GroupBox33.Controls.Add(Me.Label139)
        Me.GroupBox33.Controls.Add(Me.Label138)
        Me.GroupBox33.Controls.Add(Me.Label135)
        Me.GroupBox33.Location = New System.Drawing.Point(11, 20)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(354, 142)
        Me.GroupBox33.TabIndex = 0
        Me.GroupBox33.TabStop = False
        Me.GroupBox33.Text = "Configuración"
        '
        'imgDBEcomm
        '
        Me.imgDBEcomm.BackColor = System.Drawing.Color.Transparent
        Me.imgDBEcomm.Location = New System.Drawing.Point(297, 31)
        Me.imgDBEcomm.Name = "imgDBEcomm"
        Me.imgDBEcomm.Size = New System.Drawing.Size(32, 32)
        Me.imgDBEcomm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgDBEcomm.TabIndex = 46
        Me.imgDBEcomm.TabStop = False
        '
        'btnPagoEcomm
        '
        Me.btnPagoEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagoEcomm.Location = New System.Drawing.Point(297, 104)
        Me.btnPagoEcomm.Name = "btnPagoEcomm"
        Me.btnPagoEcomm.Size = New System.Drawing.Size(40, 24)
        Me.btnPagoEcomm.TabIndex = 45
        Me.btnPagoEcomm.Text = "Probar"
        '
        'txtPasswordDatosEcomm
        '
        Me.txtPasswordDatosEcomm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPasswordDatosEcomm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPasswordDatosEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordDatosEcomm.Location = New System.Drawing.Point(95, 106)
        Me.txtPasswordDatosEcomm.MaxLength = 50
        Me.txtPasswordDatosEcomm.Name = "txtPasswordDatosEcomm"
        Me.txtPasswordDatosEcomm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(174)
        Me.txtPasswordDatosEcomm.Size = New System.Drawing.Size(144, 22)
        Me.txtPasswordDatosEcomm.TabIndex = 44
        Me.txtPasswordDatosEcomm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPasswordDatosEcomm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtUserDatosEcomm
        '
        Me.txtUserDatosEcomm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUserDatosEcomm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUserDatosEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserDatosEcomm.Location = New System.Drawing.Point(95, 81)
        Me.txtUserDatosEcomm.MaxLength = 50
        Me.txtUserDatosEcomm.Name = "txtUserDatosEcomm"
        Me.txtUserDatosEcomm.Size = New System.Drawing.Size(144, 22)
        Me.txtUserDatosEcomm.TabIndex = 43
        Me.txtUserDatosEcomm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtUserDatosEcomm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtBDDatosEcomm
        '
        Me.txtBDDatosEcomm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtBDDatosEcomm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtBDDatosEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBDDatosEcomm.Location = New System.Drawing.Point(95, 56)
        Me.txtBDDatosEcomm.MaxLength = 50
        Me.txtBDDatosEcomm.Name = "txtBDDatosEcomm"
        Me.txtBDDatosEcomm.Size = New System.Drawing.Size(144, 22)
        Me.txtBDDatosEcomm.TabIndex = 42
        Me.txtBDDatosEcomm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtBDDatosEcomm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtServerDatosEcomm
        '
        Me.txtServerDatosEcomm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtServerDatosEcomm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtServerDatosEcomm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerDatosEcomm.Location = New System.Drawing.Point(95, 31)
        Me.txtServerDatosEcomm.MaxLength = 50
        Me.txtServerDatosEcomm.Name = "txtServerDatosEcomm"
        Me.txtServerDatosEcomm.Size = New System.Drawing.Size(144, 22)
        Me.txtServerDatosEcomm.TabIndex = 41
        Me.txtServerDatosEcomm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtServerDatosEcomm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label140
        '
        Me.Label140.AutoSize = True
        Me.Label140.BackColor = System.Drawing.Color.Transparent
        Me.Label140.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label140.Location = New System.Drawing.Point(17, 107)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(58, 16)
        Me.Label140.TabIndex = 39
        Me.Label140.Text = "Password:"
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.BackColor = System.Drawing.Color.Transparent
        Me.Label139.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label139.Location = New System.Drawing.Point(17, 82)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(48, 16)
        Me.Label139.TabIndex = 38
        Me.Label139.Text = "Usuario:"
        '
        'Label138
        '
        Me.Label138.AutoSize = True
        Me.Label138.BackColor = System.Drawing.Color.Transparent
        Me.Label138.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label138.Location = New System.Drawing.Point(17, 58)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(80, 16)
        Me.Label138.TabIndex = 37
        Me.Label138.Text = "Base de Datos:"
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.BackColor = System.Drawing.Color.Transparent
        Me.Label135.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label135.Location = New System.Drawing.Point(17, 37)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(52, 16)
        Me.Label135.TabIndex = 36
        Me.Label135.Text = "Servidor:"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'Label155
        '
        Me.Label155.BackColor = System.Drawing.Color.Transparent
        Me.Label155.Location = New System.Drawing.Point(11, 98)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(104, 20)
        Me.Label155.TabIndex = 87
        Me.Label155.Text = "Puerto:"
        Me.Label155.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebBaseNet
        '
        Me.ebBaseNet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBaseNet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBaseNet.Location = New System.Drawing.Point(118, 67)
        Me.ebBaseNet.Name = "ebBaseNet"
        Me.ebBaseNet.Size = New System.Drawing.Size(98, 20)
        Me.ebBaseNet.TabIndex = 91
        Me.ebBaseNet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label154
        '
        Me.Label154.BackColor = System.Drawing.Color.Transparent
        Me.Label154.Location = New System.Drawing.Point(11, 73)
        Me.Label154.Name = "Label154"
        Me.Label154.Size = New System.Drawing.Size(104, 20)
        Me.Label154.TabIndex = 86
        Me.Label154.Text = "Base de Datos:"
        Me.Label154.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebServidorNet
        '
        Me.ebServidorNet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebServidorNet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebServidorNet.Location = New System.Drawing.Point(119, 39)
        Me.ebServidorNet.Name = "ebServidorNet"
        Me.ebServidorNet.Size = New System.Drawing.Size(98, 20)
        Me.ebServidorNet.TabIndex = 90
        Me.ebServidorNet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label153
        '
        Me.Label153.BackColor = System.Drawing.Color.Transparent
        Me.Label153.Location = New System.Drawing.Point(11, 39)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(104, 20)
        Me.Label153.TabIndex = 85
        Me.Label153.Text = "Servidor:"
        Me.Label153.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebUsuarioNet
        '
        Me.ebUsuarioNet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuarioNet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuarioNet.Location = New System.Drawing.Point(118, 123)
        Me.ebUsuarioNet.Name = "ebUsuarioNet"
        Me.ebUsuarioNet.Size = New System.Drawing.Size(98, 20)
        Me.ebUsuarioNet.TabIndex = 92
        Me.ebUsuarioNet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ebPuertoNet
        '
        Me.ebPuertoNet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPuertoNet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPuertoNet.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebPuertoNet.Location = New System.Drawing.Point(118, 95)
        Me.ebPuertoNet.Name = "ebPuertoNet"
        Me.ebPuertoNet.Size = New System.Drawing.Size(72, 20)
        Me.ebPuertoNet.TabIndex = 94
        Me.ebPuertoNet.Text = "0"
        Me.ebPuertoNet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPuertoNet.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label152
        '
        Me.Label152.BackColor = System.Drawing.Color.Transparent
        Me.Label152.Location = New System.Drawing.Point(11, 131)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(104, 20)
        Me.Label152.TabIndex = 88
        Me.Label152.Text = "Usuario:"
        Me.Label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPassNet
        '
        Me.ebPassNet.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassNet.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassNet.Location = New System.Drawing.Point(118, 151)
        Me.ebPassNet.Name = "ebPassNet"
        Me.ebPassNet.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassNet.Size = New System.Drawing.Size(98, 20)
        Me.ebPassNet.TabIndex = 93
        Me.ebPassNet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label151
        '
        Me.Label151.BackColor = System.Drawing.Color.Transparent
        Me.Label151.Location = New System.Drawing.Point(8, 161)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(104, 20)
        Me.Label151.TabIndex = 89
        Me.Label151.Text = "Contraseña:"
        Me.Label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label150
        '
        Me.Label150.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label150.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.Location = New System.Drawing.Point(8, 6)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(305, 23)
        Me.Label150.TabIndex = 84
        Me.Label150.Text = "NETEZZA"
        Me.Label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmConfigCierreSAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 19)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(706, 504)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfigCierreSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuraciones Varias"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UITab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UITab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.pbSeparaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.pbEhub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.pbHuellas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pbFirmas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage4.ResumeLayout(False)
        Me.UiTabPage4.PerformLayout()
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        CType(Me.pbDPVF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        CType(Me.pbDPValeTODO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.pbEmails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.gpCierreDia.ResumeLayout(False)
        Me.gpCierreDia.PerformLayout()
        Me.grpGroupBox16.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicBxFotos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicBxFI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage3.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.UiTabPage5.ResumeLayout(False)
        Me.UiTabPage5.PerformLayout()
        Me.grpConsignacion.ResumeLayout(False)
        Me.grpConsignacion.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.pbTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.UiTabPage6.ResumeLayout(False)
        Me.UiTabPage6.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.gboxLeyendaNotaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxLeyendaNotaVenta.ResumeLayout(False)
        Me.gboxLeyendaNotaVenta.PerformLayout()
        CType(Me.uIGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uIGroupBox1.ResumeLayout(False)
        Me.uIGroupBox1.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.UiTabPage7.ResumeLayout(False)
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.pbBroker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage8.ResumeLayout(False)
        Me.UiTabPage8.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.UiTabPage10.ResumeLayout(False)
        CType(Me.uiAlmaecenamientoDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uiAlmaecenamientoDatos.ResumeLayout(False)
        Me.uitSqlServer.ResumeLayout(False)
        Me.GroupBox36.ResumeLayout(False)
        Me.GroupBox36.PerformLayout()
        CType(Me.pbBlue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        CType(Me.pbDPCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uitNetezza.ResumeLayout(False)
        Me.uitNetezza.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox31.PerformLayout()
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox35.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.UiTabPage11.ResumeLayout(False)
        Me.UiTabPage11.PerformLayout()
        Me.UiTabPage12.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        Me.UiTabPage13.ResumeLayout(False)
        Me.UiTabPage13.PerformLayout()
        Me.UiTabPage14.ResumeLayout(False)
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.UiTabPage15.ResumeLayout(False)
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        CType(Me.imgFinanciero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage9.ResumeLayout(False)
        Me.GrpBx.ResumeLayout(False)
        Me.GrpBx.PerformLayout()
        Me.UiTabPage16.ResumeLayout(False)
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox34.PerformLayout()
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox33.PerformLayout()
        CType(Me.imgDBEcomm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private strConfigurationFileFI As String = Application.StartupPath & "\configCierre.cml"
    Private strConfigurationFileFotos As String = Application.StartupPath & "\configFotos.cml"
    Private oFacturasMgr As FacturaManager


#Region "Metodos"

    Private Sub ShowConfigCierreFI()

        With oConfigCierreFI

            Me.ebUnidad.Text = .Unidad
            Me.EbRuta.Text = .Ruta
            Me.ebUsuario.Text = .Usuario
            Me.ebPassword.Text = .Password
            Me.ChckBxCargaInicial.Checked = .CargaInicial
            Me.chkVentaFactFiscal.Checked = .TipoVentaFactFiscal
            Me.ChckBxMiniPrinter.Checked = .MiniPrinter
            Me.ChkBxImpresoraHP.Checked = .PrinterHP
            Me.ccFechaAutoF.Value = .FechaAutoF
            Me.chkboxCedula.Checked = .ImprimirCedula
            Me.cbServerFirmas.Text = .ServerFirma
            Me.ebBDFirmas.Text = .BaseDatosFirmas
            Me.ebUserFirma.Text = .UserFirma
            Me.ebPassFirma.Text = .PassFirma
            Me.ebCuentaCorreo.Text = .CuentaCorreo
            Me.ebServidorSMTP.Text = .ServidorSMTP
            Me.cbServerHuellas.Text = .ServerHuellas
            Me.ebBaseDatosHuellas.Text = .BaseDatosHuellas
            Me.ebUserHuellas.Text = .UserHuellas
            Me.ebPasswordHuellas.Text = .PassHuellas
            Me.chkHuellas.Checked = .UsarHuellas
            If .UsarHuellas = True Then
                'Me.chkHuellas.CheckState = CheckState.Checked
                ActivarCamposHuella()
            Else
                'Me.chkHuellas.CheckState = CheckState.Unchecked
                DesactivarCamposHuella()
            End If
            Me.chkSccanerIFE.Checked = .UsarSccanerIFE
            Me.chkValidacionFS.Checked = .ValidacionFS
            Me.chkTPV.Checked = .UsarTPV
            Me.chkDescargaClientes.Checked = .UsarDescargaClientes
            Me.cmbServerEhub.Text = .ServerEhub
            Me.ebBaseDatosEhub.Text = .BaseDatosEhub
            Me.ebUserEhub.Text = .UserEhub
            Me.ebPassEhub.Text = .PassEhub
            Me.cmbServerSeparaciones.Text = .ServerSeparaciones
            Me.ebBaseDatosSeparaciones.Text = .BDSeparaciones
            Me.ebUserSeparaciones.Text = .UserSeparaciones
            Me.ebPwdSeparaciones.Text = .PassSeparaciones
            Me.nebImporteMaxTarjeta.Value = .MontoMaxTarjetas
            Me.nebMinimoEC.Value = .MinimoEC
            Me.nebMaximoEC.Value = .MaximoEC
            Me.ebRutaActualizacion.Text = .RutaActualizacion
            Me.cmbServerEmails.Text = .ServerEmails
            Me.ebBaseDatosEmails.Text = .BaseDatosEmails
            Me.ebUserEmails.Text = .UserEmails
            Me.ebPasswordEmails.Text = .PasswordEmails
            Me.ebCorreoActivacion.Text = .CorreoActivacion
            Me.chkGuardarServer.Checked = .GuardarInServer
            Me.chkHuellaOpcional.Checked = .HuellaOpcional
            Me.chkRegistroExpress.Checked = .RegistroExpressPG
            Me.chkRegistroPGOpcional.Checked = .RegistroPGOpcional
            Me.ebDirImagenesEmail.Text = .DireccionImagenesEmail
            Me.ebDirValidaEmail.Text = .DireccionValidaEmail
            Me.nebTiempoDescargasNoche.Value = .TiempoEsperaDescargasNoche
            Me.cmbServerTraspasos.Text = .ServerTraspasos
            Me.ebBaseDatosTraspasos.Text = .BaseDatosTraspasos
            Me.ebUserTraspasos.Text = .UserTraspasos
            Me.ebPassTraspasos.Text = .PasswordTraspasos
            Me.chkRecibirPorBulto.Checked = .RecibirPorBultos
            Me.chkRecibirParcial.Checked = .RecibirParcialmente
            Me.nebTiempoPedidos.Value = .TiempoRevisaPedidos
            Me.chkSMS.Checked = .PromoSMS
            Me.chkSurtirEC.Checked = .SurtirEcommerce
            Me.chkManagerPC.Checked = .ShowManagerPC
            Me.chkDIPNewDescuento.Checked = .AplicaNewDescuentosDIPs
            Me.chkBloquearPro.Checked = .BloquearXTP
            Me.nebDiasBloqueo.Value = .DiasParaBloquearTP
            Me.ebNoCuentaDHL.Text = .NoCuentaDHL
            Me.ebCLABEDHL.Text = .CuentaCLABE_DHL
            Me.ebExtensionDHL.Text = .ExtensionDHL
            Me.ebInternetServer.Text = .InternetServer
            Me.ebServidorHTTPS.Text = .ServidorHTTPS
            Me.nebDiasSurtir.Value = .DiasParaSurtirEC
            Me.nebDiasFacturar.Value = .DiasParaFacturarEC
            Me.nebDiasFacturarConcen.Value = .DiasParaFacturarConcenEC
            Me.nebDiasEnviarEC.Value = .DiasParaEnviarEC
            Me.ebUserProxy.Text = .UserProxy
            Me.ebPassProxy.Text = .PasswordProxy
            Me.chkEtiquetasLaser.Checked = .ImprimirEtiquetasEnLaser
            Me.nebPzasTotalesTS.Value = .PzasTotalesTS
            Me.chkSoloMismaPlaza.Checked = .SoloMismaPlazaTS
            Me.nebTSPorDia.Value = .TraspasosSalidaXDia
            Me.ebMailGerentePlaza.Text = .MailGerentePlaza
            Me.ebMailGerenteOperaciones.Text = .MailGerenteOperaciones
            Me.ebMailGerenteRegional.Text = .MailGerenteRegional
            Me.ebURLImagenFondo.Text = .ImagenFondoURL
            Me.ebServerBroker.Text = .ServerBroker
            Me.nebPuertoBroker.Value = .PuertoBroker
            Me.chkGeneraGuiaDHLAutomatica.Checked = .GenerarGuiaDHLAutomatica
            Me.chkHTTPS.Checked = .SeleccionaServidorHTTPS
            Me.cmbServerBroker.Text = .ServerSQLBroker
            Me.ebBaseDatosBroker.Text = .BaseDatosBroker
            Me.ebUserBroker.Text = .UserBroker
            Me.ebPasswordBroker.Text = .PasswordBroker
            Me.nebMaxDescApartados.Value = .MaxDescApartados
            Me.chkNewDosPorUnoYMedio.Checked = .NuevaRegla2x1yMedio
            Me.chkBorrarPreciosCierre.Checked = .BorrarPreciosCierre
            Me.chkCompreAhoraPDOpcional.Checked = .CompreAhoraPDOpcional
            Me.chkEtiquetaFactory.Checked = .EtiquetaPrecioFactory
            Me.chkEtiquetaDP.Checked = .EtiquetaPrecioDP
            Me.chkMiniprinterTermica.Checked = .MiniprinterTermica
            '---------------------------------------------------------------------------------------
            'JNAVA (06/05/2014): Motivos de Rechazo DPVL
            '---------------------------------------------------------------------------------------
            Me.cbMotivosRechazoDPVale.Checked = .MotivosRechazoDPVL
            '---------------------------------------------------------------------------------------
            Me.EdUnidadImg.Text = .UnidadIMG
            Me.EdrutaImg.Text = .RutaIMG
            Me.EdusuarioImg.Text = .UsuarioIMG
            Me.EdPassImg.Text = .PasswordIMG
            '---------------------------------------------------------------------------------------
            'JNAVA (10/06/2013): Configuraciones Si Hay
            '---------------------------------------------------------------------------------------
            'Concretar Cita SiHay
            Me.nebDiasRecogerReembolso.Value = .DiasRecogerReembolsoSH
            Me.nebDiasPostergarCita.Value = .DiasPostergarCitaSH

            Me.cbDevolverEfectivoSH.Checked = .DevolverEfectivoSH
            Me.nebDiasSurtirSH.Value = .DiasSurtirSH
            Me.nebDiasSinGuiaSH.Value = .DiasSinGuiaSH
            Me.nebDiasRecibirSH.Value = .DiasRecibirSH
            Me.nebDiasFacturarSH.Value = .DiasFacturarSH
            Me.nebDiasCancelarSH.Value = .DiasCancelarSH
            Me.nebDiasInsurtiblesSH.Value = .DiasInsurtiblesSH

        

            '-----------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/11/2013: Carga configuraciones de nueva promoción de descuento de Empleados
            '-----------------------------------------------------------------------------------------------
            Me.txtLimiteDescuentoEmpleado.Value = .LimiteArticulosEmpleados
            Me.cbPromocionEmpleado.Checked = .PromocionEmpleado
            '-----------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/02/2014: Carga configuración de nueva promoción de cupones
            '-----------------------------------------------------------------------------------------------
            Me.cbCuponDescuentos.Checked = .CuponDescuentos
            '---------------------------------------------------------------------------------------
            'RGERMAIN 04.04.2014: Configuracion para aplicar nueva regla de la promocion 20 y 30
            '---------------------------------------------------------------------------------------
            Me.chkNuevaRegla20y30.Checked = .NuevaRegla20y30
            '---------------------------------------------------------------------------------------
            'RGERMAIN 12.05.2014: Configuracion para mostrar o no el modulo de traspasos fisicos
            '---------------------------------------------------------------------------------------
            Me.chkModuloTraspasoFisico.Checked = .MostrarTF
            '---------------------------------------------------------------------------------------
            'JNAVA 15.05.2014: Configuracion de Impresora de etiquetas del modulo de traspasos fisico
            '---------------------------------------------------------------------------------------
            Me.ebImpresoraETIF.Text = .ImpresoraETIF
            '-----------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/05/2014: Configuración de Score Board
            '-----------------------------------------------------------------------------------------------
            Me.cbScoreBoard.Checked = .ScoreBoard
            '-----------------------------------------------------------------------------------------------
            'RGERMAIN 28.05.2014: Configuracion FTP Broker
            '-----------------------------------------------------------------------------------------------
            Me.ebUserFTPBroker.Text = .UserFTPBroker
            Me.ebPassFtpBroker.Text = .PasswordFTPBroker
            Me.ebFTPBroker.Text = .RutaFTPDHL
            '-----------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/05/2014: Configuración Etiquetas Tallas
            '-----------------------------------------------------------------------------------------------
            Me.cbEtiquetasTallas.Checked = .EtiquetasTallas
            '---------------------------------------------------------------------------------------
            'JNAVA 13.06.2014: Configuracion de traspaso de entrada desde lectora
            '---------------------------------------------------------------------------------------
            Me.chkTraspasoEntradaLectora.Checked = .TraspasoEntradaLectora
            '--------------------------------------------------------------------------------------------------------
            'RGERMAIN 16.06.2014: Configuracion para emparejar los 2 articulos de mayor precio en la promocion 2x1½
            '--------------------------------------------------------------------------------------------------------
            Me.chkEmparejaMayorPrecio2x1.Checked = .EmparejarMayorPrecio2x1
            '---------------------------------------------------------------------------------------
            'JNAVA 13.06.2014: Configuracion de traspaso de entrada desde lectora
            '---------------------------------------------------------------------------------------
            Me.chkTraspasoEntradaLectora.Checked = .TraspasoEntradaLectora
            Me.ebNombreLectoraTE.Text = .NombreLectoraTE
            Me.ebNombreArchivoLectoraTE.Text = .NombreArchivoLectoraTE
            '---------------------------------------------------------------------------------------
            'JNAVA 25.06.2014: Configuracion para usar en auditoria, la lectora CS3070
            '---------------------------------------------------------------------------------------
            Me.chkAuditoriaLectoraCS3070.Checked = .AuditoriaLectoraCS3070
            '---------------------------------------------------------------------------------------
            'RGERMAIN 01.07.2014: Configuracion del importe maximo a pagar con DPVale
            '---------------------------------------------------------------------------------------
            Me.nebImporteMaximoDPVale.Value = .ImporteMaximoDPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 31.07.2014: Configuracion para aplicar los dpaquetes dando prioridad al coduso configurado
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebDPKTCodUso.Text = .DPKTCodUso
            Me.chkDPKTPrioridadUso.Checked = .DPKTPrioridadCodUso
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Configuracion para pedir los datos para enviar promociones a los clientes desde el principio de la venta
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkPedirCelEmail.Checked = .PedirDatosPromoComienzo
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA    19.08.2014: Configuracion para Generar o no ReRevale en Ventas de DPVALE
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkGenerarReReVale.Checked = .GenerarReRevale
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 27.09.2014: Configuracion para mostrar al final del ticket que se imprime cuando se reciben pagos de pedidos Ecommerce
            'y activar la opcion de recibir otros pagos
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkRecibirOtrosPagos.Checked = .RecibirOtrosPagos
            Me.ebNotaOPEC.Text = .NotaOtrosPagosEC
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 30.09.2014: Configuracion para validar los días de vigencia para recibir un pago de un pedido de Ecommerce
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.nebDiasRecibirPago.Value = .DiasRecibirPagosEC
            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/10/2014: Configuracion para ventas Si Hay con tipo de ventas y formas de pago DPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbSiHayDPVale.Checked = .DPValeSiHay
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 10.11.2014: Config para aplicar los descuentos adicionales desde SAP con el sistema Cross Selling
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkAplicaCS.Checked = .AplicaCrossSelling
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 26.11.2014: Config para mostrar el concentrado de ingresos de auditoria en el corte del cierre de dia
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkMostrarConcenAuditoria.Checked = .MostrarConcenAUD
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 12.12.2014: Config del numero de cliente para pagos de Ecommerce
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebClienteEC.Text = .ClienteEC
            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 15/12/2014: Ruta de catalogo de imagenes
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtRutaImagenes.Text = .ImagenesExistencia
            Me.cbValidarCierreDia.Checked = .EvitarCierreDia
            Dim strMail As String = ""

            If Not .CuentasCorreoAuditoria Is Nothing AndAlso .CuentasCorreoAuditoria.Length > 0 Then
                'For i As Integer = 0 To .CuentasCorreoAuditoria.Length - 2
                For Each strMail In .CuentasCorreoAuditoria
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsAud.Items.Add(strMail.Trim)
                    End If
                Next
            End If
            If Not .CuentasCorreoUPC Is Nothing AndAlso .CuentasCorreoUPC.Length > 0 Then
                'For i As Integer = 0 To .CuentasCorreoUPC.Length - 2
                For Each strMail In .CuentasCorreoUPC
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsUPC.Items.Add(strMail.Trim)
                    End If
                Next
            End If
            If Not .CuentasCorreoErroresCDist Is Nothing AndAlso .CuentasCorreoErroresCDist.Length > 0 Then
                'For i As Integer = 0 To .CuentasCorreoErroresCDist.Length - 2
                For Each strMail In .CuentasCorreoErroresCDist
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsErroresCDist.Items.Add(strMail.Trim)
                    End If
                Next
            End If
            If Not .CuentasCorreoLogistica Is Nothing AndAlso .CuentasCorreoLogistica.Length > 0 Then
                For Each strMail In .CuentasCorreoLogistica
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsLogistica.Items.Add(strMail.Trim)
                    End If
                Next
            End If
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 15.12.2014: Config del correos para pagos de Ecommerce
            '-------------------------------------------------------------------------------------------------------------------------------
            If Not .CuentasCorreoEC Is Nothing AndAlso .CuentasCorreoEC.Length > 0 Then
                For Each strMail In .CuentasCorreoEC
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsEC.Items.Add(strMail.Trim)
                    End If
                Next
            End If

            If Not .MailCierreDia Is Nothing AndAlso .MailCierreDia.Length > 0 Then
                'For i As Integer = 0 To .CuentasCorreoUPC.Length - 2
                For Each strMail In .MailCierreDia
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstCierreDia.Items.Add(strMail.Trim)
                    End If
                Next
            End If

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 07.01.2015: Config para pagos con tarjetas Karum
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkDPCard.Checked = .AplicaDPCard

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA 15.01.2015: Config para obtener consecutivo POS DPCARD
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebConsecutivoPOS.Text = .ConsecutivoPOS

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Config para obtener consecutivo POS DPCard Puntos Karum
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtConsecutivoPuntos.Text = .ConsecutivoPuntosPOS

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (27.01.2015): Importe Maximo para ventas con electronico de DPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.nebMaxElectronicosVale.Value = .ImporteMaximoElectronicosDPVale

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (03.02.2015): Importe Maximo para ventas con electronico de DPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cmbServerDPCard.Text = .ServerDPCard
            Me.ebBaseDatosDPCard.Text = .BaseDatosDPCard
            Me.ebUserDPCard.Text = .UserDPCard
            Me.ebPasswordDPCard.Text = .PasswordDPCard

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 05/02/2014: Leyenda de Nota de Venta de Ecommerce
            '-------------------------------------------------------------------------------------------------------------------------------

            Me.txtDportenis.Text = .LeyendaDportenis
            Me.txtDPStreet.Text = .LeyendaDPStreet
            Me.cbSurtidoDPStreet.Checked = .AplicarSurtidoDPStreet
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (05.01.2015): config para generar seguros DPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkGenerarSeguro.Checked = .GenerarSeguro

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (05.02.2015): config de datos para server dpvale todo
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cmbServerDPValeTODO.Text = .ServerDPValeAIO
            Me.ebBaseDatosDPValeTODO.Text = .BaseDatosDPValeAIO
            Me.ebUserDPValeTODO.Text = .UserDPValeAIO
            Me.ebPasswordDPValeTODO.Text = .PasswordDPValeAIO

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (10.02.2015): Config para Datos de Base de datos de DPVale Financiero
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cmbServerDPVF.Text = .ServerDPVF
            Me.ebBaseDatosDPVF.Text = .BaseDatosDPVF
            Me.ebUserDPVF.Text = .UserDPVF
            Me.ebPasswordDPVF.Text = .PasswordDPVF

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (11.03.2015): Config para Cancelacion de Pagos DP Card
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkCancelarPagosDPCard.Checked = .CancelarPagosDPCard

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/03/2015: Config para el IDTienda de DPCard Credit
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtIDTienda.Text = .IDTienda

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 01/04/2015: Config para Aplicar DPCard Puntos
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbDPCardPuntos.Checked = .DPCardPuntos

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 21/05/2015: Config para Aplicar MQTT POS
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbMqttPOS.Checked = .MQTTPOS
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 05.06.2015: Config para conectarse al servidor nuevo del broker IBM
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebServerBrokerNew.Text = .ServerBrokerNew
            Me.nebPuertoBrokerNew.Value = .PuertoBrokerNew

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/06/2015: Config Bloquea Artículos de Baja Calidad
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbBloqueoArticulosBajaCalidad.Checked = .BloqueaBajaCalidad
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (20.07.2015): Config para permitir arituculos de catalogo en Si Hay
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkArticuloCatalogoSH.Checked = .ArticuloCatalogoSH
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (24.07.2015): Config para permitir la recepcion de mercancia en tiendas de proveedor
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkRecepcionMercanciaTndas.Checked = .RecepcionMercanciaTndas
            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 17/08/2015: Config para la carga de venta asistida
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbVentaAsistida.Checked = .VentaAsistida
            '-------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 07.09.2015: Config para activar la validacion de datos obligatorios de los clientes de DPVale
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkValidaDatosDPVL.Checked = .ValidaDatosDPVL

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/09/2015: Config para registrar traspasos de entrada si hay al surtir
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbTraspasoEntradaSiHay.Checked = .RegistrosTraspasoSiHay
            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/09/2015: Config para activar el bloqueo de ajustes de sobrantes
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbAjusteAutomaticos.Checked = .AjusteAutomatico

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (06.10.2015): Configuracion para ejecutar el LiveUpdate al Inicio
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkEjecutarLiveUpdateInicio.Checked = .EjecutarLiveUpdateInicio

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/11/2015: Configuracion para la ruta del archivo properties de MQTT
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtRutaProperties.Text = .RutaArchivoProperties

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/11/2015: Configuracion para validacion del Seguro DPVL
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbDPVLSeguroValidacion.Checked = .ValidaSeguroDPVL

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/11/2015: Configuracion para modificacion de Beneficiario de DPSeguro
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtDiasModificarBenef.Value = .DiasModificacionBeneficiario

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (11.12.2015): Configuracion de servidor y puerto para servicios REST
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebServidorREST.Text = .ServidorREST
            Me.nebPuertoREST.Value = .PuertoREST

            Me.txtOrganizacionCompra.Text = .OrganizacionCompra
            Me.txtCanalDistribucion.Text = .CanalDistribucion
            Me.txtSector.Text = .Sector

            Me.chkTPVVirtual.Checked = .TPVVirtual

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 06/04/2016: Configuración de Servidor FTP Cierre
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtServidorFTPCierre.Text = .ServidorFTPCierre
            Me.txtUsuarioFTPCierre.Text = .UsuarioFTPCierre
            Me.txtPasswordFTPCierre.Text = .PasswordFTPCierre

            ''-------------------------------------------------------------------------------------------------------------------------------
            ''JNAVA (28.01.2016): Configuracion para activar o desactivar el servicio de S2Credit
            ''-------------------------------------------------------------------------------------------------------------------------------
            'Me.chkAplicaS2Credit.Checked = .AplicaS2Credit

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/04/2016: Configuración para Descuentos Fijos para artículos que no son de Catalogo
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtDescuentoFijoNoCatalogo.Value = .DescuentoFijoNoCatalogo

            '-------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Configuración de Log de Transacciones
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkGenerarLogTransacciones.Checked = .GenerarLogTransacciones

            '-------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (08.06.2016): Configuración para enviar correo de timeout
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkEnviarCorreoLentitud.Checked = .EnviarCorreoLentitud
            Me.ebLimiteTiempoLentitud.Value = .LimiteTiempoLentitud

            If Not .MailLentitud Is Nothing AndAlso .MailLentitud.Length > 0 Then
                For Each strMail In .MailLentitud
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        Me.lstMailsLentitud.Items.Add(strMail.Trim)
                    End If
                Next
            End If

            '-------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (28.06.2016): Configuración para paginas de dpstreet y dportenis
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.ebPaginaDportenis.Text = .PaginaDportenis
            Me.ebPaginaDpstreet.Text = .PaginaDpStreet

            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 28/07/2016: Configuración de Público en General
            '--------------------------------------------------------------------------------------------------------------------------------
            Me.txtPublicoGeneral.Text = .PublicoGeneral

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (07.07.2016): Configuracion para activar o desactivar el servicio de S2Credit o en Paralelo (S2CREDIT-SAP)
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkAplicaS2Credit.Checked = .AplicarS2Credit
            Me.chkAplicaParaleloS2CSAP.Checked = .AplicarParaleroS2CSAP

            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 15/11/2016: Evita el inicio de día
            '--------------------------------------------------------------------------------------------------------------------------------
            Me.cbEvitarInicioDia.Checked = .EvitarInicioDia

            '--------------------------------------------------------------------------------------------------------------------------------
            'JEMO 16/11/2016 Configuracion para registro de clientes dpcard
            '--------------------------------------------------------------------------------------------------------------------------------
            'Me.chkActivarRegDPC.Checked = .ActivarRegistroDPCard
            Me.txtUrlRegistro.Text = .UrlRegistroDPCard

            '-------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (15.03.2017): Config para activar registro Approva
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkRegistroApprova.Checked = .RegistroApprova

            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/01/2017: Configuración para pagos de Banamex
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.cbPagoBanamex.Checked = .PagosBanamex
            Me.txtUserBanamex.Text = .UserBanamex
            Me.txtPasswordBanamex.Text = .PasswordBanamex

            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (22.03.2017): Configuracion para validar si se agregan articulos sin existencia en SH
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.chkTodosArticulosSH.Checked = .TodosArticulosSH

            '-------------------------------------------------------------------------------------------------------------------------------
            'MLVARGAS (20.05.2022): Configuracion para validar los materiales extendidos en las ventas de Si Hay
            '-------------------------------------------------------------------------------------------------------------------------------

            Me.chkValidarMatExt.Checked = .ValidarMaterialesExtendidos

            '-------------------------------------------------------------------------------------
            'JNAVA (02.03.2017): Nueva Facturacion
            '-------------------------------------------------------------------------------------
            Me.chkFacturacionNueva.Checked = .FacturacionNueva

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 24/07/2017: Configuración para DPTicket
            '-------------------------------------------------------------------------------------
            Me.cbHabilitarDPTicket.Checked = .HabilitarDPTicket

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 16/08/2017: Configuración de servidor de servicios de S2credit
            '-------------------------------------------------------------------------------------
            Me.txtServidorS2Credit.Text = .ServidorS2credit
            Me.txtPuertoS2Credit.Value = .PuertoS2Credit
            '-------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 14/07/2017: Configuración para los días por quincena
            '-------------------------------------------------------------------------------------------------------------------------------
            Me.txtDiaQuincena.Value = .DiasQuincena

            '-------------------------------------------------------------------------------------
            'JNAVA (04.09.2017): Liberar RAM
            '-------------------------------------------------------------------------------------
            Me.chkFreeRAM.Checked = .FreeRAM
            Me.nebTimeFreeRAM.Value = .TimeFreeRAM

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA  17/10/2017: Configuración para activar el servicio de TOKA
            '-------------------------------------------------------------------------------------
            chActivarToka.Checked = .ActivarToka
            txtComisionBancoToka.Value = .ComisionBancoToka


            '-------------------------------------------------------------------------------------
            'DARCOS (05.12.2017): alertas Dpcard
            '-------------------------------------------------------------------------------------
            Me.txtBonificacion.Text = .DiasPermitidosBonificacion
            Me.txtTransacBoni.Text = .transaccionesPermitidasBonifica
            Me.chkBonifica.Checked = .alertUsoBonifica
            Me.txtCanje.Text = .DiasPermitidosCanje
            Me.txtTransacCan.Text = .transaccionesPermitidasCanje
            Me.chkCanje.Checked = .alertUsoCanje

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 18/01/2018: Configuración de cuentas de correo
            '-------------------------------------------------------------------------------------
            Me.txtPuertoSMTP.Value = .PuertoSMTP
            Me.txtPasswordCorreo.Text = .PasswordCorreo

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 02/05/2018: Configuración de consignación
            '-------------------------------------------------------------------------------------
            Me.txtIntervaloConsignacion.Value = .TiempoIntervaloConsignacion
            Me.txtReintentoConsignacion.Value = .ReintentoConsignacion
            Me.cbPedidoCompra.Checked = .PedidoCompra

            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 27/03/2019: Configuración DPValeTodo descarga de Almacenes
            '-------------------------------------------------------------------------------------
            Me.txtServidorFinanciero.Text = .ServidorFinanciero
            Me.txtBaseFinanciero.Text = .BaseFinanciero
            Me.txtUsuarioFinanciero.Text = .UsuarioFinanciero
            Me.txtPasswordFinanciero.Text = .PasswordFinanciero
            Me.cbMigracionFinanciero.Checked = .MigracionFinanciero

            '-------------------------------------------------------------------------------------
            'DARCOS 15/04/2019: Configuración BD DatosEComm
            '-------------------------------------------------------------------------------------
            Me.txtServerDatosEcomm.Text = .ServerDatosEcomm
            Me.txtBDDatosEcomm.Text = .BaseDatosDatosEcomm
            Me.txtUserDatosEcomm.Text = .UserDatosEcomm
            Me.txtPasswordDatosEcomm.Text = .PasswordDatosEcomm

            Me.txtServicioEcomm.Text = .ServicioEcomm
            '-------------------------------------------------------------------------------------
            'FLIZARRAGA 14/07/2019: Configuración de Impresora Ecommerce
            '-------------------------------------------------------------------------------------
            Me.txtImpresoraEcommerce.Text = .ImpresoraEcommerce
            '-------------------------------------------------------------------------------------
            'ASANCHEZ 26/03/2021: Configuración de los servicios de blue y karum en la bonificación de puntos
            '-------------------------------------------------------------------------------------
            If .ServiciosBlueBonificacion = "False" Then
                rdbtn_Karum.Checked = True
            Else
                rdbtn_Blue.Checked = True
            End If
            '-----
            'ASANCHEZ 29/03/2021: Configuración de la base de datos de blue
            Me.cmbServerBlue.Text = .ServerBlue
            Me.ebBaseDatosBlue.Text = .BaseDatosDBlue
            Me.ebUserBlue.Text = .UserBlue
            Me.ebPasswordBlue.Text = .PassBlue
            Me.txt_usr_token_wsBlue.Text = .UsrTokenBlue
            'ASANCHEZ nuevos puerto y servidor de lealda
            Me.ebServerLealtad.Text = .ServerLealtad
            Me.nebPuertoLealtad.Value = .PuertoLealtad
        End With

    End Sub

    Private Sub ShowConfigFotos()

        With oConfigFotos
            Me.EdUnidadImg.Text = .Unidad
            Me.EdrutaImg.Text = .Ruta
            Me.EdusuarioImg.Text = .Usuario
            Me.EdPassImg.Text = .Password
        End With

    End Sub

    Private Sub LoadServers()
        Dim oServer As DPSoft.Framework.Data.SQLServer.SQLConnectionHelper
        oServer = New DPSoft.Framework.Data.SQLServer.SQLConnectionHelper
        Me.cbServerFirmas.DataSource = oServer.GetAvailableInstances
        Me.cbServerHuellas.DataSource = oServer.GetAvailableInstances
        Me.cmbServerEhub.DataSource = oServer.GetAvailableInstances
        Me.cmbServerSeparaciones.DataSource = oServer.GetAvailableInstances

    End Sub

    Private Sub ActivarCamposHuella()
        Me.cbServerHuellas.Enabled = True
        Me.ebBaseDatosHuellas.Enabled = True
        Me.ebUserHuellas.Enabled = True
        Me.ebPasswordHuellas.Enabled = True
    End Sub

    Private Sub DesactivarCamposHuella()
        Me.cbServerHuellas.Enabled = False
        Me.ebBaseDatosHuellas.Enabled = False
        Me.ebUserHuellas.Enabled = False
        Me.ebPasswordHuellas.Enabled = False
    End Sub

    Private Function ValidaCorreo(ByVal eb As Janus.Windows.GridEX.EditControls.EditBox, ByVal lst As System.Windows.Forms.ListBox) As Boolean

        If eb.Text = "" Then
            Return False
        Else
            For i As Integer = 0 To lst.Items.Count - 1
                If lst.Items.Item(i) = eb.Text Then
                    MsgBox("El correo " & eb.Text & " ya está agregado.", MsgBoxStyle.Exclamation, "Dportenis Pro")
                    eb.Focus()
                    eb.SelectAll()
                    Return False
                End If
            Next
        End If

        Return True

    End Function

#End Region


#Region "Eventos"

    Private Sub chkBloquearPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBloquearPro.CheckedChanged
        Me.nebDiasBloqueo.Enabled = Me.chkBloquearPro.Checked
    End Sub

    Private Sub chkSurtirEC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSurtirEC.CheckedChanged

        Me.nebTiempoPedidos.Enabled = Me.chkSurtirEC.Checked
        Me.nebDiasSurtir.Enabled = Me.chkSurtirEC.Checked
        Me.nebDiasFacturar.Enabled = Me.chkSurtirEC.Checked
        Me.nebDiasFacturarConcen.Enabled = Me.chkSurtirEC.Checked
        Me.nebDiasEnviarEC.Enabled = Me.chkSurtirEC.Checked

    End Sub

    Private Sub ebRutaActualizacion_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oFolderDialog As New FolderBrowserDialog

        If oFolderDialog.ShowDialog = DialogResult.OK Then
            Me.ebRutaActualizacion.Text = oFolderDialog.SelectedPath
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        Dim bRes As Boolean = True
        Dim oTSMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        If Me.chkBloquearPro.Checked AndAlso Me.nebDiasBloqueo.Value <= 0 Then
            MessageBox.Show("Es necesario especificar el número de días para bloquear el sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
            Me.nebDiasBloqueo.Focus()
        ElseIf (Me.chkRecibirParcial.Checked = False OrElse Me.chkBloquearPro.Checked = False) AndAlso oTSMgr.GetAllTraspasosPendientes.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("No es posible desactivar la opción de recibir traspasos parcialmente ni bloqueo del sistema" & vbCrLf & "Existen traspasos pendientes por autorizar en este momento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'para guardar Configuracion FI cierre dia
        If ebUsuario.Text <> String.Empty And ebPassword.Text <> String.Empty And EbRuta.Text <> String.Empty And ebUnidad.Text <> String.Empty Then
            If ValidaCampos() = False Then Exit Sub
            Dim oReader As New SaveConfigArchivosReader(strConfigurationFileFI)
            Dim oSettings As New SaveConfigArchivos
            With oSettings
                .Ruta = Me.EbRuta.Text
                .Usuario = Me.ebUsuario.Text
                .Password = Me.ebPassword.Text
                .Unidad = Me.ebUnidad.Text
                If Me.ChckBxCargaInicial.Checked Then
                    .CargaInicial = True
                Else
                    .CargaInicial = False
                End If
                If Me.chkVentaFactFiscal.Checked Then
                    .TipoVentaFactFiscal = True
                Else
                    .TipoVentaFactFiscal = False
                End If
                If Me.ChckBxMiniPrinter.Checked Then
                    .MiniPrinter = True
                Else
                    .MiniPrinter = False
                End If

                If Me.ChkBxImpresoraHP.Checked Then
                    .PrinterHP = True
                Else
                    .PrinterHP = False
                End If
                If Me.chkValidacionFS.Checked Then
                    .ValidacionFS = True
                Else
                    .ValidacionFS = False
                End If
                .FechaAutoF = ccFechaAutoF.Value.ToShortDateString
                If Me.chkboxCedula.Checked Then
                    .ImprimirCedula = True
                Else
                    .ImprimirCedula = False
                End If
                .ServerFirma = Me.cbServerFirmas.Text
                .BaseDatosFirmas = Me.ebBDFirmas.Text
                .UserFirma = Me.ebUserFirma.Text
                .PassFirma = Me.ebPassFirma.Text
                .CuentaCorreo = Me.ebCuentaCorreo.Text
                .ServidorSMTP = Me.ebServidorSMTP.Text
                .ServerHuellas = Me.cbServerHuellas.Text
                .BaseDatosHuellas = Me.ebBaseDatosHuellas.Text
                .UserHuellas = Me.ebUserHuellas.Text
                .PassHuellas = Me.ebPasswordHuellas.Text
                If Me.chkHuellas.Checked Then
                    .UsarHuellas = True
                Else
                    .UsarHuellas = False
                End If
                If Me.chkSccanerIFE.Checked = True Then
                    .UsarSccanerIFE = True
                Else
                    .UsarSccanerIFE = False
                End If
                If Me.chkTPV.Checked = True Then
                    .UsarTPV = True
                Else
                    .UsarTPV = False
                End If
                If Me.chkDescargaClientes.Checked Then
                    .UsarDescargaClientes = True
                Else
                    .UsarDescargaClientes = False
                End If
                If Me.txtBonificacion.Text.Trim <> "" Then
                    .DiasPermitidosBonificacion = Me.txtBonificacion.Text
                End If
                If Me.txtCanje.Text.Trim <> "" Then
                    .DiasPermitidosCanje = Me.txtCanje.Text
                End If
                If Me.txtTransacBoni.Text.Trim <> "" Then
                    .transaccionesPermitidasBonifica = Me.txtTransacBoni.Text
                End If
                If Me.txtTransacCan.Text.Trim <> "" Then
                    .transaccionesPermitidasCanje = Me.txtTransacCan.Text
                End If
                .alertUsoCanje = Me.chkCanje.Checked
                .alertUsoBonifica = Me.chkBonifica.Checked
                .ServerEhub = Me.cmbServerEhub.Text
                .BaseDatosEhub = Me.ebBaseDatosEhub.Text
                .UserEhub = Me.ebUserEhub.Text
                .PassEhub = Me.ebPassEhub.Text
                .ServerSeparaciones = Me.cmbServerSeparaciones.Text
                .BDSeparaciones = Me.ebBaseDatosSeparaciones.Text
                .UserSeparaciones = Me.ebUserSeparaciones.Text
                .PassSeparaciones = Me.ebPwdSeparaciones.Text
                .ServerEmails = Me.cmbServerEmails.Text
                .BaseDatosEmails = Me.ebBaseDatosEmails.Text
                .UserEmails = Me.ebUserEmails.Text
                .PasswordEmails = Me.ebPasswordEmails.Text
                .MontoMaxTarjetas = Me.nebImporteMaxTarjeta.Value
                .MinimoEC = Me.nebMinimoEC.Value
                .MaximoEC = Me.nebMaximoEC.Value
                .RutaActualizacion = Me.ebRutaActualizacion.Text
                .CorreoActivacion = Me.ebCorreoActivacion.Text.Trim
                .GuardarInServer = Me.chkGuardarServer.Checked
                .HuellaOpcional = Me.chkHuellaOpcional.Checked
                .RegistroExpressPG = Me.chkRegistroExpress.Checked
                .RegistroPGOpcional = Me.chkRegistroPGOpcional.Checked
                .DireccionImagenesEmail = Me.ebDirImagenesEmail.Text.Trim
                .DireccionValidaEmail = Me.ebDirValidaEmail.Text.Trim
                .TiempoEsperaDescargasNoche = Me.nebTiempoDescargasNoche.Value
                .ServerTraspasos = Me.cmbServerTraspasos.Text
                .BaseDatosTraspasos = Me.ebBaseDatosTraspasos.Text
                .UserTraspasos = Me.ebUserTraspasos.Text
                .PasswordTraspasos = Me.ebPassTraspasos.Text
                .RecibirParcialmente = Me.chkRecibirParcial.Checked
                .RecibirPorBultos = Me.chkRecibirPorBulto.Checked
                .TiempoRevisaPedidos = Me.nebTiempoPedidos.Value
                .PromoSMS = Me.chkSMS.Checked
                .ShowManagerPC = Me.chkManagerPC.Checked
                .SurtirEcommerce = Me.chkSurtirEC.Checked
                .AplicaNewDescuentosDIPs = Me.chkDIPNewDescuento.Checked
                .BloquearXTP = Me.chkBloquearPro.Checked
                .DiasParaBloquearTP = Me.nebDiasBloqueo.Value
                .NoCuentaDHL = Me.ebNoCuentaDHL.Text
                .CuentaCLABE_DHL = Me.ebCLABEDHL.Text
                .ExtensionDHL = Me.ebExtensionDHL.Text
                .InternetServer = Me.ebInternetServer.Text.Trim
                .ServidorHTTPS = Me.ebServidorHTTPS.Text.Trim
                .DiasParaSurtirEC = Me.nebDiasSurtir.Value
                .DiasParaFacturarEC = Me.nebDiasFacturar.Value
                .DiasParaFacturarConcenEC = Me.nebDiasFacturarConcen.Value
                .DiasParaEnviarEC = Me.nebDiasEnviarEC.Value
                .UserProxy = Me.ebUserProxy.Text
                .PasswordProxy = Me.ebPassProxy.Text
                .ImprimirEtiquetasEnLaser = Me.chkEtiquetasLaser.Checked
                .PzasTotalesTS = Me.nebPzasTotalesTS.Value
                .SoloMismaPlazaTS = Me.chkSoloMismaPlaza.Checked
                .TraspasosSalidaXDia = Me.nebTSPorDia.Value
                .MailGerentePlaza = Me.ebMailGerentePlaza.Text
                .MailGerenteOperaciones = Me.ebMailGerenteOperaciones.Text
                .MailGerenteRegional = Me.ebMailGerenteRegional.Text
                .ImagenFondoURL = Me.ebURLImagenFondo.Text
                .ServerBroker = Me.ebServerBroker.Text.Trim
                .PuertoBroker = Me.nebPuertoBroker.Value
                .GenerarGuiaDHLAutomatica = Me.chkGeneraGuiaDHLAutomatica.Checked
                .SeleccionaServidorHTTPS = Me.chkHTTPS.Checked
                .ServerSQLBroker = Me.cmbServerBroker.Text
                .BaseDatosBroker = Me.ebBaseDatosBroker.Text
                .UserBroker = Me.ebUserBroker.Text
                .PasswordBroker = Me.ebPasswordBroker.Text
                .MaxDescApartados = Me.nebMaxDescApartados.Value
                .NuevaRegla2x1yMedio = Me.chkNewDosPorUnoYMedio.Checked
                .BorrarPreciosCierre = Me.chkBorrarPreciosCierre.Checked
                .CompreAhoraPDOpcional = Me.chkCompreAhoraPDOpcional.Checked
                .MiniprinterTermica = Me.chkMiniprinterTermica.Checked
                .EtiquetaPrecioDP = Me.chkEtiquetaDP.Checked
                .EtiquetaPrecioFactory = Me.chkEtiquetaFactory.Checked
                .MotivosRechazoDPVL = Me.cbMotivosRechazoDPVale.Checked

                .RutaIMG = Me.EdrutaImg.Text
                .UsuarioIMG = Me.EdusuarioImg.Text
                .PasswordIMG = Me.EdPassImg.Text
                .UnidadIMG = Me.EdUnidadImg.Text
                .ImagenesExistencia = txtRutaImagenes.Text.Trim()

                ReDim .CuentasCorreoAuditoria(Me.lstMailsAud.Items.Count)
                ReDim .CuentasCorreoUPC(Me.lstMailsUPC.Items.Count)
                ReDim .CuentasCorreoErroresCDist(Me.lstMailsErroresCDist.Items.Count)
                ReDim .CuentasCorreoLogistica(Me.lstMailsLogistica.Items.Count)
                ReDim .MailCierreDia(Me.lstCierreDia.Items.Count)
                Dim i As Integer

                For i = 0 To Me.lstMailsAud.Items.Count - 1
                    .CuentasCorreoAuditoria(i) = CStr(Me.lstMailsAud.Items.Item(i))
                Next
                For i = 0 To Me.lstMailsUPC.Items.Count - 1
                    .CuentasCorreoUPC(i) = CStr(Me.lstMailsUPC.Items.Item(i))
                Next
                For i = 0 To Me.lstMailsErroresCDist.Items.Count - 1
                    .CuentasCorreoErroresCDist(i) = CStr(Me.lstMailsErroresCDist.Items.Item(i))
                Next
                For i = 0 To Me.lstMailsLogistica.Items.Count - 1
                    .CuentasCorreoLogistica(i) = CStr(Me.lstMailsLogistica.Items.Item(i))
                Next

                '---------------------------------------------------------------------------------------
                'JNAVA (10/06/2013): Configuraciones Si Hay
                '---------------------------------------------------------------------------------------
                'Concretar Cita SiHay
                .DiasRecogerReembolsoSH = Me.nebDiasRecogerReembolso.Value
                .DiasPostergarCitaSH = Me.nebDiasPostergarCita.Value

                .DevolverEfectivoSH = Me.cbDevolverEfectivoSH.Checked
                .DiasSurtirSH = Me.nebDiasSurtirSH.Value
                .DiasSinGuiaSH = Me.nebDiasSinGuiaSH.Value
                .DiasRecibirSH = Me.nebDiasRecibirSH.Value
                .DiasFacturarSH = Me.nebDiasFacturarSH.Value
                .DiasCancelarSH = Me.nebDiasCancelarSH.Value
                .DiasInsurtiblesSH = Me.nebDiasInsurtiblesSH.Value
                '--------------------------------------------------------------------------------------

                '---------------------------------------------------------------------------------------
                'FLIZARRAGA 07/11/2013: Configuraciones para la nuevos descuentos de Empleados
                '---------------------------------------------------------------------------------------
                .LimiteArticulosEmpleados = CInt(Me.txtLimiteDescuentoEmpleado.Value)
                .PromocionEmpleado = Me.cbPromocionEmpleado.Checked
                '---------------------------------------------------------------------------------------
                'FLIZARRAGA 25/02/2014: Configuraciones para los nuevos descuentos de cupones
                '---------------------------------------------------------------------------------------
                .CuponDescuentos = Me.cbCuponDescuentos.Checked
                '---------------------------------------------------------------------------------------
                'RGERMAIN 04.04.2014: Configuracion para aplicar nueva regla de la promocion 20 y 30
                '---------------------------------------------------------------------------------------
                .NuevaRegla20y30 = Me.chkNuevaRegla20y30.Checked
                '---------------------------------------------------------------------------------------
                'FLIZARRAGA 19/04/2014: Configuracion para el Score Board
                '---------------------------------------------------------------------------------------
                .ScoreBoard = Me.cbScoreBoard.Checked
                '---------------------------------------------------------------------------------------
                'RGERMAIN 12.05.2014: Configuracion para mostrar o no el modulo de traspasos fisicos
                '---------------------------------------------------------------------------------------
                .MostrarTF = Me.chkModuloTraspasoFisico.Checked
                '---------------------------------------------------------------------------------------
                'JNAVA 15.05.2014: Configuracion de Impresora de etiquetas del modulo de traspasos fisico
                '---------------------------------------------------------------------------------------
                .ImpresoraETIF = Me.ebImpresoraETIF.Text
                '---------------------------------------------------------------------------------------
                'FLIZARRAGA 22/05/2014: Configuración de impresion etiquetas con tallas
                '---------------------------------------------------------------------------------------
                .EtiquetasTallas = Me.cbEtiquetasTallas.Checked
                '-----------------------------------------------------------------------------------------------
                'RGERMAIN 28.05.2014: Configuracion FTP Broker
                '-----------------------------------------------------------------------------------------------
                .UserFTPBroker = Me.ebUserFTPBroker.Text.Trim
                .PasswordFTPBroker = Me.ebPassFtpBroker.Text.Trim
                .RutaFTPDHL = Me.ebFTPBroker.Text.Trim
                '---------------------------------------------------------------------------------------
                'JNAVA 13.06.2014: Configuracion de traspaso de entrada desde lectora
                '---------------------------------------------------------------------------------------
                .ImpresoraETIF = Me.ebImpresoraETIF.Text
                '--------------------------------------------------------------------------------------------------------
                'RGERMAIN 16.06.2014: Configuracion para emparejar los 2 articulos de mayor precio en la promocion 2x1½
                '--------------------------------------------------------------------------------------------------------
                .EmparejarMayorPrecio2x1 = Me.chkEmparejaMayorPrecio2x1.Checked
                '---------------------------------------------------------------------------------------
                'JNAVA 13.06.2014: Configuracion de traspaso de entrada desde lectora
                '---------------------------------------------------------------------------------------
                .TraspasoEntradaLectora = Me.chkTraspasoEntradaLectora.Checked
                .NombreLectoraTE = Me.ebNombreLectoraTE.Text
                .NombreArchivoLectoraTE = Me.ebNombreArchivoLectoraTE.Text
                '---------------------------------------------------------------------------------------
                'JNAVA 25.06.2014: Configuracion para usar en auditoria, la lectora CS3070
                '---------------------------------------------------------------------------------------
                .AuditoriaLectoraCS3070 = Me.chkAuditoriaLectoraCS3070.Checked
                '---------------------------------------------------------------------------------------
                'RGERMAIN 01.07.2014: Configuracion del importe maximo a pagar con DPVale
                '---------------------------------------------------------------------------------------
                .ImporteMaximoDPVale = Me.nebImporteMaximoDPVale.Value
                '---------------------------------------------------------------------------------------
                'RGERMAIN 31.07.2014: Configuracion para aplicar los dpaquetes dando prioridad al coduso configurado
                '---------------------------------------------------------------------------------------
                .DPKTPrioridadCodUso = Me.chkDPKTPrioridadUso.Checked
                .DPKTCodUso = Me.ebDPKTCodUso.Text.Trim
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 29.08.2014: Configuracion para pedir los datos para enviar promociones a los clientes desde el principio de la venta
                '-------------------------------------------------------------------------------------------------------------------------------
                .PedirDatosPromoComienzo = Me.chkPedirCelEmail.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 19.09.2014: Configuracion para Generar o no ReRevale en Venta con DPVALE
                '-------------------------------------------------------------------------------------------------------------------------------
                .GenerarReRevale = Me.chkGenerarReReVale.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 27.09.2014: Configuracion para mostrar al final del ticket que se imprime cuando se reciben pagos de pedidos Ecommerce
                'y para activar la opcion de recibir otros pagos
                '-------------------------------------------------------------------------------------------------------------------------------
                .RecibirOtrosPagos = Me.chkRecibirOtrosPagos.Checked
                .NotaOtrosPagosEC = Me.ebNotaOPEC.Text.Trim
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 30.09.2014: Configuracion para validar los días de vigencia para recibir un pago de un pedido de Ecommerce
                '-------------------------------------------------------------------------------------------------------------------------------
                .DiasRecibirPagosEC = Me.nebDiasRecibirPago.Value
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 16/10/2014: Configuracion para validar si acepta ventas del si hay con tipo y forma de pago DPVale
                '-------------------------------------------------------------------------------------------------------------------------------
                .DPValeSiHay = Me.cbSiHayDPVale.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 10.11.2014: Config para aplicar los descuentos adicionales desde SAP con el sistema Cross Selling
                '-------------------------------------------------------------------------------------------------------------------------------
                .AplicaCrossSelling = Me.chkAplicaCS.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 26.11.2014: Config para mostrar el concentrado de ingresos de auditoria en el corte del cierre de dia
                '-------------------------------------------------------------------------------------------------------------------------------
                .MostrarConcenAUD = Me.chkMostrarConcenAuditoria.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 12.12.2014: Config del numero de cliente para pagos de Ecommerce
                '-------------------------------------------------------------------------------------------------------------------------------
                .ClienteEC = Me.ebClienteEC.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 15/12/2014: Ruta de catalogo de imagenes
                '-------------------------------------------------------------------------------------------------------------------------------
                .ImagenesExistencia = txtRutaImagenes.Text.Trim()
                .EvitarCierreDia = Me.cbValidarCierreDia.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 15.12.2014: Config correos para pagos de Ecommerce
                '-------------------------------------------------------------------------------------------------------------------------------
                ReDim .CuentasCorreoEC(Me.lstMailsLogistica.Items.Count)
                For x As Integer = 0 To Me.lstMailsEC.Items.Count - 1
                    .CuentasCorreoEC(x) = CStr(Me.lstMailsEC.Items.Item(x))
                Next
                '-------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/12/2014: Cuentas de correos cuando se evita el cierre dia para que queden enterados que hubo un error en compensaciones
                '-------------------------------------------------------------------------------------------------------------------------------------
                For x As Integer = 0 To Me.lstCierreDia.Items.Count - 1
                    .MailCierreDia(x) = CStr(Me.lstCierreDia.Items.Item(x))
                Next
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 07.01.2015: Config para pagos con tarjetas Karum
                '-------------------------------------------------------------------------------------------------------------------------------
                .AplicaDPCard = Me.chkDPCard.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 15.01.2015: Config para Obetener Consecutivo POS DPCARD
                '-------------------------------------------------------------------------------------------------------------------------------
                .ConsecutivoPOS = Me.ebConsecutivoPOS.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/08/2016: Config para obtener Consecutivos POS DPPuntos KARUM
                '-------------------------------------------------------------------------------------------------------------------------------
                .ConsecutivoPuntosPOS = Me.txtConsecutivoPuntos.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (27.01.2015): Importe Maximo para ventas con electronico de DPVale
                '-------------------------------------------------------------------------------------------------------------------------------
                .ImporteMaximoElectronicosDPVale = Me.nebMaxElectronicosVale.Value
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (03.02.2015): Config para Datos de Base de datos de DP Card
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServerDPCard = Me.cmbServerDPCard.Text
                .BaseDatosDPCard = Me.ebBaseDatosDPCard.Text
                .UserDPCard = Me.ebUserDPCard.Text
                .PasswordDPCard = Me.ebPasswordDPCard.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 05/02/2014: Leyenda de Nota de Ventas DPStreet
                '-------------------------------------------------------------------------------------------------------------------------------
                .LeyendaDportenis = Me.txtDportenis.Text.Trim()
                .LeyendaDPStreet = Me.txtDPStreet.Text.Trim()
                .AplicarSurtidoDPStreet = Me.cbSurtidoDPStreet.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (05.01.2015): config para generar seguros DPVale
                '-------------------------------------------------------------------------------------------------------------------------------
                .GenerarSeguro = Me.chkGenerarSeguro.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (05.02.2015): Config para Datos de Base de datos de DPValeTodo
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServerDPValeAIO = Me.cmbServerDPValeTODO.Text
                .BaseDatosDPValeAIO = Me.ebBaseDatosDPValeTODO.Text
                .UserDPValeAIO = Me.ebUserDPValeTODO.Text
                .PasswordDPValeAIO = Me.ebPasswordDPValeTODO.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (10.02.2015): Config para Datos de Base de datos de DPVale Financiero
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServerDPVF = Me.cmbServerDPVF.Text
                .BaseDatosDPVF = Me.ebBaseDatosDPVF.Text
                .UserDPVF = Me.ebUserDPVF.Text
                .PasswordDPVF = Me.ebPasswordDPVF.Text
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (11.02.2015): Config para Cancelacion de Pagos DP Card
                '-------------------------------------------------------------------------------------------------------------------------------
                .CancelarPagosDPCard = Me.chkCancelarPagosDPCard.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 26/03/2015: IDTienda para pagos con dpcard credit
                '-------------------------------------------------------------------------------------------------------------------------------
                .IDTienda = Me.txtIDTienda.Text.Trim()
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 01/04/2015: Config para aplicar DPCard Puntos
                '-------------------------------------------------------------------------------------------------------------------------------
                .DPCardPuntos = Me.cbDPCardPuntos.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 21/05/2015: Config para aplicar MQTT POS
                '-------------------------------------------------------------------------------------------------------------------------------
                .MQTTPOS = Me.cbMqttPOS.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 05.06.2015: Config para conectarse al servidor nuevo del broker IBM
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServerBrokerNew = Me.ebServerBrokerNew.Text.Trim
                .PuertoBrokerNew = Me.nebPuertoBrokerNew.Value
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 10/06/2015: Config Para Bloquear Artículos de Baja Calidad
                '-------------------------------------------------------------------------------------------------------------------------------
                .BloqueaBajaCalidad = Me.cbBloqueoArticulosBajaCalidad.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (20.07.2015): Config para permitir arituculos de catalogo en Si Hay
                '-------------------------------------------------------------------------------------------------------------------------------
                .ArticuloCatalogoSH = Me.chkArticuloCatalogoSH.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (24.07.2015): Config para permitir la recepcion de mercancia en tiendas de proveedor
                '-------------------------------------------------------------------------------------------------------------------------------
                .RecepcionMercanciaTndas = Me.chkRecepcionMercanciaTndas.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 17/08/2015: Config de Venta Asistida
                '-------------------------------------------------------------------------------------------------------------------------------
                .VentaAsistida = Me.cbVentaAsistida.Checked
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 07.09.2015: Config para activar la validacion de datos obligatorios de los clientes de DPVale
                '-------------------------------------------------------------------------------------------------------------------------------
                .ValidaDatosDPVL = Me.chkValidaDatosDPVL.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 17/09/2015: Config para los traspasos de entrada del si hay
                '-------------------------------------------------------------------------------------------------------------------------------
                .RegistrosTraspasoSiHay = Me.cbTraspasoEntradaSiHay.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 11/09/2015: Config para anulas los ajustes automaticos por sobrantes
                '-------------------------------------------------------------------------------------------------------------------------------
                .AjusteAutomatico = Me.cbAjusteAutomaticos.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (06.10.2015): Configuracion para ejecutar el LiveUpdate al Inicio
                '-------------------------------------------------------------------------------------------------------------------------------
                .EjecutarLiveUpdateInicio = Me.chkEjecutarLiveUpdateInicio.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 11/10/2015: Configuracion para el archivo properties de MQTT
                '-------------------------------------------------------------------------------------------------------------------------------
                If txtRutaProperties.Text.Trim() <> "" Then
                    .RutaArchivoProperties = txtRutaProperties.Text.Trim()
                Else
                    .RutaArchivoProperties = Environment.CurrentDirectory & "/Propiedades/agente.properties"
                End If

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 11/10/2015: Configuracion para validacion de Seguro de Vida DPVL
                '-------------------------------------------------------------------------------------------------------------------------------
                .ValidaSeguroDPVL = Me.cbDPVLSeguroValidacion.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/11/2015: Configuración para modificacion de beneficiario en DPSeguro
                '-------------------------------------------------------------------------------------------------------------------------------
                .DiasModificacionBeneficiario = Me.txtDiasModificarBenef.Value

                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (11.12.2015): Configuracion de servidor y puerto para servicios REST
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServidorREST = Me.ebServidorREST.Text
                .PuertoREST = Me.nebPuertoREST.Value
                .OrganizacionCompra = Me.txtOrganizacionCompra.Text.Trim()
                .CanalDistribucion = Me.txtCanalDistribucion.Text.Trim()
                .Sector = Me.txtSector.Text.Trim()
                '---------
                '
                '----------
                .TPVVirtual = Me.chkTPVVirtual.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 06/04/2016: Cargando configuracion de Servidor FTP de Cierre 
                '-------------------------------------------------------------------------------------------------------------------------------
                .ServidorFTPCierre = Me.txtServidorFTPCierre.Text.Trim()
                .UsuarioFTPCierre = Me.txtUsuarioFTPCierre.Text.Trim()
                .PasswordFTPCierre = Me.txtPasswordFTPCierre.Text.Trim()

                ''-------------------------------------------------------------------------------------------------------------------------------
                ''JNAVA (11.04.2016): Configuracion para activar o desactivar el servicio de S2Credit
                ''-------------------------------------------------------------------------------------------------------------------------------
                '.AplicaS2Credit = Me.chkAplicaS2Credit.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/04/2016: Configuración de descuentos DIPS fijos para Artículos que no sean de catalogo
                '-------------------------------------------------------------------------------------------------------------------------------
                .DescuentoFijoNoCatalogo = CDec(txtDescuentoFijoNoCatalogo.Value)

                '-------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08.06.2016): Configuración de Log de Transacciones
                '-------------------------------------------------------------------------------------------------------------------------------
                .GenerarLogTransacciones = Me.chkGenerarLogTransacciones.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08.06.2016): Configuración para enviar correo de timeout
                '-------------------------------------------------------------------------------------------------------------------------------
                .EnviarCorreoLentitud = Me.chkEnviarCorreoLentitud.Checked
                .LimiteTiempoLentitud = Me.ebLimiteTiempoLentitud.Value
                ReDim .MailLentitud(Me.lstMailsLentitud.Items.Count)
                For x As Integer = 0 To Me.lstMailsLentitud.Items.Count - 1
                    .MailLentitud(x) = CStr(Me.lstMailsLentitud.Items.Item(x))
                Next

                '-------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (28.06.2016): Configuración para paginas de dpstreet y dportenis
                '-------------------------------------------------------------------------------------------------------------------------------
                .PaginaDportenis = Me.ebPaginaDportenis.Text
                .PaginaDpStreet = Me.ebPaginaDpstreet.Text

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 28/07/2016: Configuración de Público en general
                '-------------------------------------------------------------------------------------------------------------------------------
                .PublicoGeneral = Me.txtPublicoGeneral.Text.Trim()

                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (07.07.2016): Configuracion para activar o desactivar el servicio de S2Credit o en Paralelo (S2CREDIT-SAP)
                '-------------------------------------------------------------------------------------------------------------------------------
                .AplicarS2Credit = Me.chkAplicaS2Credit.Checked
                .AplicarParaleroS2CSAP = Me.chkAplicaParaleloS2CSAP.Checked

                '-------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 15/11/2016: Evita el inicio de día
                '-------------------------------------------------------------------------------------------------------------------------------
                .EvitarInicioDia = Me.cbEvitarInicioDia.Checked

                '-------------------------------------------------------------------------------------
                'JEMO 16/11/2016 Configuracion para registro de clientes DPCard
                '-------------------------------------------------------------------------------------
                '.ActivarRegistroDPCard = Me.chkActivarRegDPC.Checked
                .UrlRegistroDPCard = Me.txtUrlRegistro.Text

                '-------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (15.03.2017): Config para activar registro Approva
                '-------------------------------------------------------------------------------------------------------------------------------
                .RegistroApprova = Me.chkRegistroApprova.Checked

                '--------------------------------------------------------------------------------------
                'FLIZARRAGA 16/01/2017: Configuración para pagos de Banamex
                '--------------------------------------------------------------------------------------
                .PagosBanamex = cbPagoBanamex.Checked
                .UserBanamex = Me.txtUserBanamex.Text.Trim()
                .PasswordBanamex = Me.txtPasswordBanamex.Text.Trim()

                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (22.03.2017): Configuracion para validar si se agregan articulos sin existencia en SH
                '-------------------------------------------------------------------------------------------------------------------------------
                .TodosArticulosSH = Me.chkTodosArticulosSH.Checked


                '-------------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS (20.05.2022): Configuracion para validar los materiales extendidos en las ventas de Si Hay
                '-------------------------------------------------------------------------------------------------------------------------------

                .ValidarMaterialesExtendidos = Me.chkValidarMatExt.Checked

                '-------------------------------------------------------------------------------------
                'JNAVA (02.03.2017): Nueva Facturacion
                '-------------------------------------------------------------------------------------
                .FacturacionNueva = Me.chkFacturacionNueva.Checked

                '--------------------------------------------------------------------------------------
                'FLIZARRAGA 14/07/2017: Configuración para días por quincena
                '--------------------------------------------------------------------------------------
                .DiasQuincena = Me.txtDiaQuincena.Value

                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 24/07/2014: Configuración para DPTicket
                '-------------------------------------------------------------------------------------
                .HabilitarDPTicket = Me.cbHabilitarDPTicket.Checked

                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 16/08/2017: Configuración de lo servicios Rest de S2Credit
                '-------------------------------------------------------------------------------------
                .ServidorS2credit = Me.txtServidorS2Credit.Text.Trim()
                .PuertoS2Credit = Me.txtPuertoS2Credit.Value

                '-------------------------------------------------------------------------------------
                ' JNAVA (04.09.2017): Liberar RAM
                '-------------------------------------------------------------------------------------
                .FreeRAM = Me.chkFreeRAM.Checked
                .TimeFreeRAM = Me.nebTimeFreeRAM.Value

                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 18/01/2018: Configuración para la autenticación de correos
                '-------------------------------------------------------------------------------------
                .PuertoSMTP = txtPuertoSMTP.Value
                .PasswordCorreo = txtPasswordCorreo.Text.Trim()

                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 02/05/2018: Configuracion para consignacion
                '-------------------------------------------------------------------------------------
                .TiempoIntervaloConsignacion = txtIntervaloConsignacion.Value
                .ReintentoConsignacion = txtIntervaloConsignacion.Value
                .PedidoCompra = cbPedidoCompra.Checked

                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 27/03/2019: Configuración DPVFinanciero Descarga de almacen
                '-------------------------------------------------------------------------------------
                .ServidorFinanciero = txtServidorFinanciero.Text.Trim()
                .BaseFinanciero = txtBaseFinanciero.Text.Trim()
                .UsuarioFinanciero = txtUsuarioFinanciero.Text.Trim()
                .PasswordFinanciero = txtPasswordFinanciero.Text.Trim()

                '--------------------------------------------------------------------------------------
                'FLIZARRAGA 15/04/2019: Configuracion para migracion de base de datos financiero
                '--------------------------------------------------------------------------------------
                .MigracionFinanciero = cbMigracionFinanciero.Checked

                '-------------------------------------------------------------------------------------
                'DARCOS 15/04/2019: Configuración BD DatosEcomm
                '-------------------------------------------------------------------------------------
                .ServerDatosEcomm = txtServerDatosEcomm.Text.Trim()
                .BaseDatosDatosEcomm = txtBDDatosEcomm.Text.Trim()
                .UserDatosEcomm = txtUserDatosEcomm.Text.Trim()
                .PasswordDatosEcomm = txtPasswordDatosEcomm.Text.Trim()
                '-------------------------------------------------------------------------------------
                'FLIZARRAGA 14/07/2019: Configuración de Impresora Ecommerce
                '-------------------------------------------------------------------------------------
                .ImpresoraEcommerce = Me.txtImpresoraEcommerce.Text.Trim()

                .ServicioEcomm = txtServicioEcomm.Text.Trim()
                '-------------------------------------------------------------------------------------
                'ASANCHEZ 26/03/2021: Configuración de los servicios de bonificación de puntos karum o blue
                '---
                If rdbtn_Karum.Checked Then
                    .ServiciosBlueBonificacion = "False"
                Else
                    .ServiciosBlueBonificacion = "True"
                End If
                'ASANCHEZ 29/03/2021: Configuración de la base de datos de blue
                .ServerBlue = cmbServerBlue.Text
                .BaseDatosDBlue = ebBaseDatosBlue.Text
                .UserBlue = ebUserBlue.Text
                .PassBlue = ebPasswordBlue.Text
                .UsrTokenBlue = txt_usr_token_wsBlue.Text

                .ServerLealtad = ebServerLealtad.Text
                .PuertoLealtad = nebPuertoLealtad.Value
            End With
            oReader.SaveSettings(oSettings)
            oSettings = Nothing
            oReader = Nothing
            '''Cargamos nuevamente en el objeto global los datos
            LoadConfigCierreFI()
            '----------------------------------------------------------------------------------------------------------------
            'Guardamos Configuracion En Server
            '----------------------------------------------------------------------------------------------------------------
            SaveConfigCierreFiInServer(True)
            '----------------------------------------------------------------------------------------------------------------
            'MsgBox("Se guardó configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPTienda")
            EncriptarCML(strConfigurationFileFI)

            MsgBox("Se guardó configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DPTienda")
        Else
            If ebUsuario.Text = String.Empty Then
                MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                ebUsuario.Focus()
                Exit Sub
            Else
                If Me.ebPassword.Text = String.Empty Then
                    MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                    ebPassword.Focus()
                    Exit Sub
                Else
                    If Me.EbRuta.Text = String.Empty Then
                        MsgBox("Falta IP", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                        EbRuta.Focus()
                        Exit Sub
                    Else
                        If Me.ebUnidad.Text = String.Empty Then
                            MsgBox("Falta Unidad", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                            ebUnidad.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        '------------------------------------------------------------
        'Guarda COnfiguracion FOtos
        'If Me.EdusuarioImg.Text <> String.Empty And Me.EdPassImg.Text <> String.Empty And Me.EdrutaImg.Text <> String.Empty And Me.EdUnidadImg.Text <> String.Empty Then
        '    Dim oReader As New SaveConfigArchivosReader(strConfigurationFileFotos)
        '    Dim oSettings As New SaveConfigArchivos
        '    With oSettings
        '        .Ruta = Me.EdrutaImg.Text
        '        .Usuario = Me.EdusuarioImg.Text
        '        .Password = Me.EdPassImg.Text
        '        .Unidad = Me.EdUnidadImg.Text
        '    End With
        '    oReader.SaveSettings(oSettings)
        '    oSettings = Nothing
        '    oReader = Nothing
        '    '''Cargamos nuevamente en el objeto global los datos
        '    LoadConfigFotos()

        '    EncriptarCML(strConfigurationFileFotos)

        'Else
        '    If EdusuarioImg.Text = String.Empty Then
        '        MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
        '        EdusuarioImg.Focus()
        '        Exit Sub
        '    Else
        '        If Me.EdPassImg.Text = String.Empty Then
        '            MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
        '            EdPassImg.Focus()
        '            Exit Sub
        '        Else
        '            If Me.EdrutaImg.Text = String.Empty Then
        '                MsgBox("Falta IP", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
        '                EdrutaImg.Focus()
        '                Exit Sub
        '            Else
        '                If Me.EdUnidadImg.Text = String.Empty Then
        '                    MsgBox("Falta Unidad", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
        '                    EdUnidadImg.Focus()
        '                    Exit Sub
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    '    Private Sub SaveConfigInServer()

    '        Try

    '1:          Dim Properties As PropertyInfo() = oConfigCierreFI.GetType.GetProperties
    '            Dim strError As String
    '            Dim Valor As String = ""
    '            Dim bolPass As Boolean

    '            For Each oProp As PropertyInfo In Properties
    '                strError = ""
    '                bolPass = False
    '                Valor = ""
    '2:              If oProp.PropertyType.Name = "String[]" Then
    '3:                  Dim strTemp() As String = oProp.GetValue(oConfigCierreFI, Nothing)
    '                    For Each str As String In strTemp
    '4:                      If Not str Is Nothing AndAlso str.Trim <> "" Then Valor &= str.Trim & "|"
    '                    Next
    '                Else
    '5:                  Valor = oProp.GetValue(oConfigCierreFI, Nothing)
    '                End If
    '6:              If IsPassword(oProp.Name) Then
    '7:                  Valor = oSecurity.EncriptarCML(Valor)
    '8:                  bolPass = True
    '                End If
    '9:              strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 3, bolPass)
    '10:             If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oConfigCierreFI." & oProp.Name)
    '            Next

    '        Catch ex As Exception
    '            EscribeLog(ex.ToString, "Error al guardar config general in server oConfigCierreFI: Linea " & Err.Erl)
    '        End Try

    '    End Sub

    '    Private Function IsPassword(ByVal Name As String) As Boolean

    '        Select Case Name.Trim.ToUpper
    '            Case "PASSEHUB", "PASSHUELLAS", "PASSSEPARACIONES", "PASSFIRMA", "PASSWORD", "PASSWORDIMG"
    '                Return True
    '            Case Else
    '                Return False
    '        End Select

    '    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmConfigCierreSAP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadServers()

        If File.Exists(strConfigurationFileFI) Then
            ShowConfigCierreFI()
        End If

        'If File.Exists(strConfigurationFileFotos) Then
        '    ShowConfigFotos()
        'End If


    End Sub

    Private Sub UBtnFi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UBtnFi.Click
        Try
            Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(Me.ebPassword.Text, Me.ebUsuario.Text, Me.ebUnidad.Text, Me.EbRuta.Text)

            Me.PicBxFI.Image = Nothing

            If ebUsuario.Text <> String.Empty And ebPassword.Text <> String.Empty And EbRuta.Text <> String.Empty And ebUnidad.Text <> String.Empty Then
                If oMontarURed.Conecta() Then
                    Me.PicBxFI.Image = Me.ImageList1.Images(0)
                Else
                    Me.PicBxFI.Image = Me.ImageList1.Images(1)
                End If
                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
            Else
                If ebUsuario.Text = String.Empty Then
                    MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                    ebUsuario.Focus()
                Else
                    If Me.ebPassword.Text = String.Empty Then
                        MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                        ebPassword.Focus()
                    Else
                        If Me.EbRuta.Text = String.Empty Then
                            MsgBox("Falta Ruta", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                            EbRuta.Focus()
                        Else
                            If Me.ebUnidad.Text = String.Empty Then
                                MsgBox("Falta Unidad", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                                ebUnidad.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UBtnFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UBtnFotos.Click
        Try
            Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(Me.EdPassImg.Text, Me.EdusuarioImg.Text, Me.EdUnidadImg.Text, Me.EdrutaImg.Text)
            Me.PicBxFotos.Image = Nothing
            If Me.EdusuarioImg.Text <> String.Empty And Me.EdPassImg.Text <> String.Empty And Me.EdrutaImg.Text <> String.Empty And Me.EdUnidadImg.Text <> String.Empty Then
                If oMontarURed.Conecta Then
                    Me.PicBxFotos.Image = Me.ImageList1.Images(0)
                Else
                    Me.PicBxFotos.Image = Me.ImageList1.Images(1)
                End If
                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
            Else
                If EdusuarioImg.Text = String.Empty Then
                    MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                    EdusuarioImg.Focus()
                Else
                    If Me.EdPassImg.Text = String.Empty Then
                        MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                        EdPassImg.Focus()
                    Else
                        If Me.EdrutaImg.Text = String.Empty Then
                            MsgBox("Falta IP", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                            EdrutaImg.Focus()
                        Else
                            If Me.EdUnidadImg.Text = String.Empty Then
                                MsgBox("Falta Unidad", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "DpTienda")
                                EdUnidadImg.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

        If Me.cbServerFirmas.Text <> String.Empty And Me.ebBDFirmas.Text <> String.Empty And Me.ebUserFirma.Text <> String.Empty And Me.ebPassFirma.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cbServerFirmas.Text & "; Initial Catalog=" & Me.ebBDFirmas.Text & "; User Id=" & Me.ebUserFirma.Text & " ;Password=" & Me.ebPassFirma.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbFirmas.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbFirmas.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If

            End Try
        End If

    End Sub

    Private Sub UiButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton2.Click

        If Me.cbServerHuellas.Text <> String.Empty And Me.ebBaseDatosHuellas.Text <> String.Empty And Me.ebUserHuellas.Text <> String.Empty And Me.ebPasswordHuellas.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cbServerHuellas.Text & "; Initial Catalog=" & Me.ebBaseDatosHuellas.Text & "; User Id=" & Me.ebUserHuellas.Text & " ;Password=" & Me.ebPasswordHuellas.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbHuellas.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbHuellas.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If

            End Try
        End If

    End Sub

    Private Sub chkHuellas_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHuellas.CheckStateChanged

        If Me.chkHuellas.Checked Then
            ActivarCamposHuella()
        Else
            DesactivarCamposHuella()
        End If

    End Sub

    Private Sub FrmConfigCierreSAP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub btnProbarEhub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarEhub.Click

        If Me.cmbServerEhub.Text <> String.Empty And Me.ebBaseDatosEhub.Text <> String.Empty And Me.ebUserEhub.Text <> String.Empty And Me.ebPassEhub.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerEhub.Text & "; Initial Catalog=" & Me.ebBaseDatosEhub.Text & "; User Id=" & Me.ebUserEhub.Text & " ;Password=" & Me.ebPassEhub.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbEhub.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbEhub.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If

    End Sub

    Private Sub btnAddMailAud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMailAud.Click

        If ValidaCorreo(Me.ebMailAud, Me.lstMailsAud) = True Then

            Me.lstMailsAud.Items.Add(Me.ebMailAud.Text)
            Me.ebMailAud.Text = ""
            Me.ebMailAud.Focus()

        End If

    End Sub

    Private Sub btnAddMailUPC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMailUPC.Click

        If ValidaCorreo(Me.ebMailUPC, Me.lstMailsUPC) = True Then

            Me.lstMailsUPC.Items.Add(Me.ebMailUPC.Text)
            Me.ebMailUPC.Text = ""
            Me.ebMailUPC.Focus()

        End If

    End Sub

    Private Sub lstMailsAud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstMailsAud.KeyDown

        If e.KeyCode = Keys.Delete Then 'AndAlso Me.lstMailsAud.Items.Count > 0 Then

            'Me.lstMailsAud.Items.RemoveAt(Me.lstMailsAud.SelectedIndex)
            EliminaItemLista(Me.lstMailsAud)

        End If

    End Sub

    Private Sub lstMailsUPC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstMailsUPC.KeyDown

        If e.KeyCode = Keys.Delete Then 'AndAlso Me.lstMailsUPC.Items.Count > 0 andalThen

            'Me.lstMailsUPC.Items.RemoveAt(Me.lstMailsUPC.SelectedIndex)
            EliminaItemLista(Me.lstMailsUPC)

        End If

    End Sub

    Private Sub EliminaItemLista(ByVal lstTemp As System.Windows.Forms.ListBox)

        If lstTemp.Items.Count > 0 AndAlso lstTemp.SelectedIndex >= 0 Then
            lstTemp.Items.RemoveAt(lstTemp.SelectedIndex)
        End If

    End Sub

    Private Sub ebMailAud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebMailAud.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call btnAddMailAud_Click(sender, Nothing)
        End If

    End Sub

    Private Sub ebMailUPC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebMailUPC.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call btnAddMailUPC_Click(sender, Nothing)
        End If

    End Sub

    Private Sub btnProbarSeparaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarSeparaciones.Click

        If Me.cmbServerSeparaciones.Text <> String.Empty And Me.ebBaseDatosSeparaciones.Text <> String.Empty And Me.ebUserSeparaciones.Text <> String.Empty And Me.ebPwdSeparaciones.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerSeparaciones.Text & "; Initial Catalog=" & Me.ebBaseDatosSeparaciones.Text & "; User Id=" & Me.ebUserSeparaciones.Text & " ;Password=" & Me.ebPwdSeparaciones.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbSeparaciones.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbSeparaciones.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If

            End Try
        End If

    End Sub

    Private Sub btnProbarEmails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProbarEmails.Click
        If Me.cmbServerEmails.Text <> String.Empty And Me.ebBaseDatosEmails.Text <> String.Empty And Me.ebUserEmails.Text <> String.Empty And Me.ebPasswordEmails.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerEmails.Text & "; Initial Catalog=" & Me.ebBaseDatosEmails.Text & "; User Id=" & Me.ebUserEmails.Text & " ;Password=" & Me.ebPasswordEmails.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbEmails.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbEmails.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnProbarTraspasos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarTraspasos.Click
        If Me.cmbServerTraspasos.Text <> String.Empty And Me.ebBaseDatosTraspasos.Text <> String.Empty And Me.ebUserTraspasos.Text <> String.Empty And Me.ebPassTraspasos.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerTraspasos.Text & "; Initial Catalog=" & Me.ebBaseDatosTraspasos.Text & "; User Id=" & Me.ebUserTraspasos.Text & " ;Password=" & Me.ebPassTraspasos.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbTraspasos.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbTraspasos.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnMailErrorCDist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMailErrorCDist.Click

        If ValidaCorreo(Me.ebMailErrorCDist, Me.lstMailsErroresCDist) = True Then
            Me.lstMailsErroresCDist.Items.Add(Me.ebMailErrorCDist.Text)
            Me.ebMailErrorCDist.Text = ""
            Me.ebMailErrorCDist.Focus()
        End If

    End Sub

    Private Sub lstMailsErroresCDist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstMailsErroresCDist.KeyDown

        If e.KeyCode = Keys.Delete Then 'AndAlso Me.lstMailsErroresCDist.Items.Count > 0 Then

            'Me.lstMailsErroresCDist.Items.RemoveAt(Me.lstMailsErroresCDist.SelectedIndex)
            EliminaItemLista(Me.lstMailsErroresCDist)

        End If

    End Sub

    Private Sub ebMailErrorCDist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebMailErrorCDist.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnMailErrorCDist.PerformClick()
        End If
    End Sub

    Private Sub chkRecibirParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecibirParcial.CheckedChanged
        Me.chkBloquearPro.Checked = Me.chkRecibirParcial.Checked
    End Sub

    Private Sub btnAddMailLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMailLog.Click

        If ValidaCorreo(Me.ebMailLogistica, Me.lstMailsLogistica) = True Then
            Me.lstMailsLogistica.Items.Add(Me.ebMailLogistica.Text)
            Me.ebMailLogistica.Text = ""
            Me.ebMailLogistica.Focus()
        End If

    End Sub

    Private Sub btnAddMailLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnAddMailLog.KeyDown

        If e.KeyCode = Keys.Delete Then

            EliminaItemLista(Me.lstMailsLogistica)

        End If

    End Sub

#End Region

    Private Sub btnProbarBroker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarBroker.Click

        If Me.cmbServerBroker.Text <> String.Empty And Me.ebBaseDatosBroker.Text <> String.Empty And Me.ebUserBroker.Text <> String.Empty And Me.ebPasswordBroker.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerBroker.Text & "; Initial Catalog=" & Me.ebBaseDatosBroker.Text & "; User Id=" & Me.ebUserBroker.Text & " ;Password=" & Me.ebPasswordBroker.Text & ";")
            Try
                oConn.Open()
                Me.pbBroker.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbBroker.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If

    End Sub

    Private Sub chkEtiquetaDP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEtiquetaDP.CheckedChanged, chkEtiquetaFactory.CheckedChanged

        If Me.chkEtiquetaDP.Checked = False AndAlso Me.chkEtiquetaFactory.Checked = False Then
            Me.chkEtiquetaDP.Checked = True
        End If

    End Sub

    Private Sub chkEtiquetasLaser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.chkEtiquetasLaser.Checked = False Then
            Me.chkEtiquetaDP.Checked = True
            Me.chkEtiquetaFactory.Checked = False
            Me.grpGroupBox16.Enabled = False
        End If

    End Sub

    Private Sub btnAddMailEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMailEC.Click

        If ValidaCorreo(Me.ebMailEC, Me.lstMailsEC) = True Then
            Me.lstMailsEC.Items.Add(Me.ebMailEC.Text)
            Me.ebMailEC.Text = ""
            Me.ebMailEC.Focus()
        End If

    End Sub

    Private Sub lstMailsEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstMailsEC.KeyDown

        If e.KeyCode = Keys.Delete Then

            EliminaItemLista(Me.lstMailsEC)

        End If

    End Sub

    Private Sub btnCierreDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreDia.Click
        If ValidaCorreo(Me.txtCuentaCierreDia, Me.lstCierreDia) = True Then

            Me.lstCierreDia.Items.Add(Me.txtCuentaCierreDia.Text)
            Me.txtCuentaCierreDia.Text = ""
            Me.txtCuentaCierreDia.Focus()

        End If
    End Sub

    Private Sub lstCierreDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstCierreDia.KeyDown
        If e.KeyCode = Keys.Delete Then 'AndAlso Me.lstMailsUPC.Items.Count > 0 andalThen

            'Me.lstMailsUPC.Items.RemoveAt(Me.lstMailsUPC.SelectedIndex)
            EliminaItemLista(Me.lstCierreDia)

        End If
    End Sub

    Private Sub btnProbarDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarDPCard.Click
        If Me.cmbServerDPCard.Text <> String.Empty And Me.ebBaseDatosDPCard.Text <> String.Empty And Me.ebUserDPCard.Text <> String.Empty And Me.ebPasswordDPCard.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerDPCard.Text & "; Initial Catalog=" & Me.ebBaseDatosDPCard.Text & "; User Id=" & Me.ebUserDPCard.Text & " ;Password=" & Me.ebPasswordDPCard.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbDPCard.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbDPCard.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnProbarDPValeTODO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarDPValeTODO.Click
        If Me.cmbServerDPValeTODO.Text <> String.Empty And Me.ebBaseDatosDPValeTODO.Text <> String.Empty And Me.ebUserDPValeTODO.Text <> String.Empty And Me.ebPasswordDPValeTODO.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerDPValeTODO.Text & "; Initial Catalog=" & Me.ebBaseDatosDPValeTODO.Text & "; User Id=" & Me.ebUserDPValeTODO.Text & " ;Password=" & Me.ebPasswordDPValeTODO.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbDPValeTODO.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbDPValeTODO.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnProbarDPVF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarDPVF.Click
        If Me.cmbServerDPVF.Text <> String.Empty And Me.ebBaseDatosDPVF.Text <> String.Empty And Me.ebUserDPVF.Text <> String.Empty And Me.ebPasswordDPVF.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerDPVF.Text & "; Initial Catalog=" & Me.ebBaseDatosDPVF.Text & "; User Id=" & Me.ebUserDPVF.Text & " ;Password=" & Me.ebPasswordDPVF.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbDPVF.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbDPVF.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub txtRutaProperties_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRutaProperties.ButtonClick
        Dim open As New OpenFileDialog
        open.Multiselect = False
        open.Filter = "Properties Files (*.properties)|*.properties"
        If open.ShowDialog() = DialogResult.OK Then
            txtRutaProperties.Text = open.FileName
        End If
    End Sub

    Private Sub btnAddMailTimeout_Click(sender As System.Object, e As System.EventArgs) Handles btnAddMailTimeout.Click
        If ValidaCorreo(Me.ebCorreoTimeout, Me.lstMailsLentitud) = True Then
            Me.lstMailsLentitud.Items.Add(Me.ebCorreoTimeout.Text)
            Me.ebCorreoTimeout.Text = ""
            Me.ebCorreoTimeout.Focus()
        End If
    End Sub

    Private Sub chkEnviarCorreoTimeout_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnviarCorreoLentitud.CheckedChanged

        Me.ebLimiteTiempoLentitud.Enabled = Me.chkEnviarCorreoLentitud.Checked
        Me.ebCorreoTimeout.Enabled = Me.chkEnviarCorreoLentitud.Checked
        Me.btnAddMailTimeout.Enabled = Me.chkEnviarCorreoLentitud.Checked
        Me.lstMailsLentitud.Enabled = Me.chkEnviarCorreoLentitud.Checked

    End Sub

    Private Sub lstMailsLentitud_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lstMailsLentitud.KeyDown

        If e.KeyCode = Keys.Delete Then

            EliminaItemLista(Me.lstMailsLentitud)

        End If

    End Sub

    Private Sub btnTestDTodo_Click(sender As System.Object, e As System.EventArgs) Handles btnTestDTodo.Click
        If Me.txtServidorFinanciero.Text <> String.Empty And Me.txtBaseFinanciero.Text <> String.Empty And Me.txtUsuarioFinanciero.Text <> String.Empty And Me.txtPasswordFinanciero.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.txtServidorFinanciero.Text & "; Initial Catalog=" & Me.txtBaseFinanciero.Text & "; User Id=" & Me.txtUsuarioFinanciero.Text & " ;Password=" & Me.txtPasswordFinanciero.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.imgFinanciero.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.imgFinanciero.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnPagoEcomm_Click(sender As System.Object, e As System.EventArgs) Handles btnPagoEcomm.Click
        If Me.txtServerDatosEcomm.Text <> String.Empty And Me.txtBDDatosEcomm.Text <> String.Empty And Me.txtUserDatosEcomm.Text <> String.Empty And Me.txtPasswordDatosEcomm.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.txtServerDatosEcomm.Text & "; Initial Catalog=" & Me.txtBDDatosEcomm.Text & "; User Id=" & Me.txtUserDatosEcomm.Text & " ;Password=" & Me.txtPasswordDatosEcomm.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.imgDBEcomm.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.imgDBEcomm.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If

    End Sub

   
    Private Sub btnProbarBlue_Click(sender As System.Object, e As System.EventArgs) Handles btnProbarBlue.Click
        If Me.cmbServerBlue.Text <> String.Empty And Me.ebBaseDatosBlue.Text <> String.Empty And Me.ebUserBlue.Text <> String.Empty And Me.ebPasswordBlue.Text <> String.Empty Then
            Dim oConn As New SqlClient.SqlConnection("Data Source=" & Me.cmbServerBlue.Text & "; Initial Catalog=" & Me.ebBaseDatosBlue.Text & "; User Id=" & Me.ebUserBlue.Text & " ;Password=" & Me.ebPasswordBlue.Text & ";TimeOut=120;")
            Try
                oConn.Open()
                Me.pbBlue.Image = Me.ImageList1.Images(0)
            Catch ex As Exception
                Me.pbBlue.Image = Me.ImageList1.Images(1)
            Finally
                If oConn.State <> ConnectionState.Closed Then
                    oConn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub UITab1_SelectedTabChanged(sender As System.Object, e As Janus.Windows.UI.Tab.TabEventArgs) Handles UITab1.SelectedTabChanged

    End Sub
End Class
