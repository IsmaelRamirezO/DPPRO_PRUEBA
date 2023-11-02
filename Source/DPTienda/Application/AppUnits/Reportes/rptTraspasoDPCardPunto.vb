Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptTraspasoDPCardPunto
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dpCardDatos As Hashtable)
        MyBase.New()
        InitializeComponent()
        Me.txtFecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
        Me.txtHora.Text = "Hora: " & DateTime.Now.ToString("HH:mm")
        Me.txtNoTienda.Text = oAppContext.ApplicationConfiguration.Almacen
        Me.txtNoCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        Me.txtVendedor.Text = CStr(dpCardDatos("CodVendedor"))
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        Me.txtNombreTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        Me.txtNoTarjeta.Text = CStr(dpCardDatos("OldCardId"))
        Me.txtNewCard.Text = CStr(dpCardDatos("NewCardId"))
        Me.txtPuntosGanados.Text = CStr(dpCardDatos("TransactionPoints"))
        Me.txtPuntosPesos.Text = CStr(dpCardDatos("TransactionPointsInCash"))
        Me.txtTotalPuntos.Text = CStr(dpCardDatos("TotalPoints"))
        Me.txtTotalPuntoPesos.Text = CStr(dpCardDatos("TotalPointsInCash"))
        Me.txtPromocional.Text = CStr(dpCardDatos("PromotinalMessage"))
        Me.txtMensaje.Text = CStr(dpCardDatos("PersonalMessage"))
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private lblDPCardPuntos As Label = Nothing
    Private lblPuntosGanados As Label = Nothing
    Private txtPuntosGanados As TextBox = Nothing
    Private lblTotalPuntos As Label = Nothing
    Private txtTotalPuntos As TextBox = Nothing
    Private lblPuntosEnPesos As Label = Nothing
    Private txtPuntosPesos As TextBox = Nothing
    Private lblTotalPuntosPesos As Label = Nothing
    Private txtTotalPuntoPesos As TextBox = Nothing
    Private txtPromocional As TextBox = Nothing
    Private txtMensaje As TextBox = Nothing
    Private lblOldCard As Label = Nothing
    Private txtNoTarjeta As TextBox = Nothing
    Private lblNoTienda As Label = Nothing
    Private txtNoTienda As TextBox = Nothing
    Private lblNoCaja As Label = Nothing
    Private txtNoCaja As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private txtHora As TextBox = Nothing
    Private txtVendedor As TextBox = Nothing
    Private lblVendedor As Label = Nothing
    Private txtNombreTienda As TextBox = Nothing
    Private lblNewCard As Label = Nothing
    Private txtNewCard As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTraspasoDPCardPunto))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblDPCardPuntos = New DataDynamics.ActiveReports.Label()
            Me.lblPuntosGanados = New DataDynamics.ActiveReports.Label()
            Me.txtPuntosGanados = New DataDynamics.ActiveReports.TextBox()
            Me.lblTotalPuntos = New DataDynamics.ActiveReports.Label()
            Me.txtTotalPuntos = New DataDynamics.ActiveReports.TextBox()
            Me.lblPuntosEnPesos = New DataDynamics.ActiveReports.Label()
            Me.txtPuntosPesos = New DataDynamics.ActiveReports.TextBox()
            Me.lblTotalPuntosPesos = New DataDynamics.ActiveReports.Label()
            Me.txtTotalPuntoPesos = New DataDynamics.ActiveReports.TextBox()
            Me.txtPromocional = New DataDynamics.ActiveReports.TextBox()
            Me.txtMensaje = New DataDynamics.ActiveReports.TextBox()
            Me.lblOldCard = New DataDynamics.ActiveReports.Label()
            Me.txtNoTarjeta = New DataDynamics.ActiveReports.TextBox()
            Me.lblNoTienda = New DataDynamics.ActiveReports.Label()
            Me.txtNoTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblNoCaja = New DataDynamics.ActiveReports.Label()
            Me.txtNoCaja = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtHora = New DataDynamics.ActiveReports.TextBox()
            Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.lblVendedor = New DataDynamics.ActiveReports.Label()
            Me.txtNombreTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblNewCard = New DataDynamics.ActiveReports.Label()
            Me.txtNewCard = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblDPCardPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPuntosGanados,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPuntosGanados,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTotalPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPuntosEnPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPuntosPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTotalPuntosPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalPuntoPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPromocional,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMensaje,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblOldCard,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoTarjeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNewCard,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNewCard,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDPCardPuntos, Me.lblPuntosGanados, Me.txtPuntosGanados, Me.lblTotalPuntos, Me.txtTotalPuntos, Me.lblPuntosEnPesos, Me.txtPuntosPesos, Me.lblTotalPuntosPesos, Me.txtTotalPuntoPesos, Me.txtPromocional, Me.txtMensaje, Me.lblOldCard, Me.txtNoTarjeta, Me.lblNoTienda, Me.txtNoTienda, Me.lblNoCaja, Me.txtNoCaja, Me.txtFecha, Me.txtHora, Me.txtVendedor, Me.lblVendedor, Me.txtNombreTienda, Me.lblNewCard, Me.txtNewCard})
            Me.PageHeader.Height = 4.603472!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblDPCardPuntos
            '
            Me.lblDPCardPuntos.Height = 0.1875!
            Me.lblDPCardPuntos.HyperLink = Nothing
            Me.lblDPCardPuntos.Left = 0.25!
            Me.lblDPCardPuntos.Name = "lblDPCardPuntos"
            Me.lblDPCardPuntos.Style = "font-weight: bold; font-size: 9.75pt; vertical-align: top"
            Me.lblDPCardPuntos.Text = "Traspaso DPCard Puntos"
            Me.lblDPCardPuntos.Top = 0!
            Me.lblDPCardPuntos.Width = 1.875!
            '
            'lblPuntosGanados
            '
            Me.lblPuntosGanados.Height = 0.1875!
            Me.lblPuntosGanados.HyperLink = Nothing
            Me.lblPuntosGanados.Left = 0!
            Me.lblPuntosGanados.Name = "lblPuntosGanados"
            Me.lblPuntosGanados.Style = ""
            Me.lblPuntosGanados.Text = "Puntos Ganados:"
            Me.lblPuntosGanados.Top = 2.4375!
            Me.lblPuntosGanados.Width = 1.125!
            '
            'txtPuntosGanados
            '
            Me.txtPuntosGanados.Height = 0.1875!
            Me.txtPuntosGanados.Left = 1.125!
            Me.txtPuntosGanados.Name = "txtPuntosGanados"
            Me.txtPuntosGanados.Top = 2.4375!
            Me.txtPuntosGanados.Width = 1.375!
            '
            'lblTotalPuntos
            '
            Me.lblTotalPuntos.Height = 0.1875!
            Me.lblTotalPuntos.HyperLink = Nothing
            Me.lblTotalPuntos.Left = 0!
            Me.lblTotalPuntos.Name = "lblTotalPuntos"
            Me.lblTotalPuntos.Style = ""
            Me.lblTotalPuntos.Text = "Total Puntos:"
            Me.lblTotalPuntos.Top = 2.9375!
            Me.lblTotalPuntos.Width = 1.125!
            '
            'txtTotalPuntos
            '
            Me.txtTotalPuntos.Height = 0.1875!
            Me.txtTotalPuntos.Left = 1.125!
            Me.txtTotalPuntos.Name = "txtTotalPuntos"
            Me.txtTotalPuntos.Top = 2.9375!
            Me.txtTotalPuntos.Width = 1.375!
            '
            'lblPuntosEnPesos
            '
            Me.lblPuntosEnPesos.Height = 0.1875!
            Me.lblPuntosEnPesos.HyperLink = Nothing
            Me.lblPuntosEnPesos.Left = 0!
            Me.lblPuntosEnPesos.Name = "lblPuntosEnPesos"
            Me.lblPuntosEnPesos.Style = ""
            Me.lblPuntosEnPesos.Text = "Puntos en pesos:"
            Me.lblPuntosEnPesos.Top = 2.625!
            Me.lblPuntosEnPesos.Width = 1.125!
            '
            'txtPuntosPesos
            '
            Me.txtPuntosPesos.Height = 0.1875!
            Me.txtPuntosPesos.Left = 1.125!
            Me.txtPuntosPesos.Name = "txtPuntosPesos"
            Me.txtPuntosPesos.OutputFormat = resources.GetString("txtPuntosPesos.OutputFormat")
            Me.txtPuntosPesos.Top = 2.625!
            Me.txtPuntosPesos.Width = 1.375!
            '
            'lblTotalPuntosPesos
            '
            Me.lblTotalPuntosPesos.Height = 0.1875!
            Me.lblTotalPuntosPesos.HyperLink = Nothing
            Me.lblTotalPuntosPesos.Left = 0!
            Me.lblTotalPuntosPesos.Name = "lblTotalPuntosPesos"
            Me.lblTotalPuntosPesos.Style = ""
            Me.lblTotalPuntosPesos.Text = "Total Puntos en pesos:"
            Me.lblTotalPuntosPesos.Top = 3.125!
            Me.lblTotalPuntosPesos.Width = 1.5!
            '
            'txtTotalPuntoPesos
            '
            Me.txtTotalPuntoPesos.Height = 0.1875!
            Me.txtTotalPuntoPesos.Left = 1.5!
            Me.txtTotalPuntoPesos.Name = "txtTotalPuntoPesos"
            Me.txtTotalPuntoPesos.OutputFormat = resources.GetString("txtTotalPuntoPesos.OutputFormat")
            Me.txtTotalPuntoPesos.Top = 3.125!
            Me.txtTotalPuntoPesos.Width = 1!
            '
            'txtPromocional
            '
            Me.txtPromocional.Height = 0.5625!
            Me.txtPromocional.Left = 0!
            Me.txtPromocional.Name = "txtPromocional"
            Me.txtPromocional.Top = 3.4375!
            Me.txtPromocional.Width = 2.5!
            '
            'txtMensaje
            '
            Me.txtMensaje.Height = 0.375!
            Me.txtMensaje.Left = 0!
            Me.txtMensaje.Name = "txtMensaje"
            Me.txtMensaje.Style = "font-size: 8.25pt"
            Me.txtMensaje.Top = 4.125!
            Me.txtMensaje.Width = 2.5!
            '
            'lblOldCard
            '
            Me.lblOldCard.Height = 0.1875!
            Me.lblOldCard.HyperLink = Nothing
            Me.lblOldCard.Left = 0!
            Me.lblOldCard.Name = "lblOldCard"
            Me.lblOldCard.Style = ""
            Me.lblOldCard.Text = "Tarjeta Anterior:"
            Me.lblOldCard.Top = 1.9375!
            Me.lblOldCard.Width = 1.0625!
            '
            'txtNoTarjeta
            '
            Me.txtNoTarjeta.Height = 0.1875!
            Me.txtNoTarjeta.Left = 1.0625!
            Me.txtNoTarjeta.Name = "txtNoTarjeta"
            Me.txtNoTarjeta.Top = 1.9375!
            Me.txtNoTarjeta.Width = 1.4375!
            '
            'lblNoTienda
            '
            Me.lblNoTienda.Height = 0.1875!
            Me.lblNoTienda.HyperLink = Nothing
            Me.lblNoTienda.Left = 0!
            Me.lblNoTienda.Name = "lblNoTienda"
            Me.lblNoTienda.Style = ""
            Me.lblNoTienda.Text = "No. Tienda:"
            Me.lblNoTienda.Top = 0.53125!
            Me.lblNoTienda.Width = 0.75!
            '
            'txtNoTienda
            '
            Me.txtNoTienda.Height = 0.1875!
            Me.txtNoTienda.Left = 0.75!
            Me.txtNoTienda.Name = "txtNoTienda"
            Me.txtNoTienda.Top = 0.531!
            Me.txtNoTienda.Width = 0.6875!
            '
            'lblNoCaja
            '
            Me.lblNoCaja.Height = 0.1875!
            Me.lblNoCaja.HyperLink = Nothing
            Me.lblNoCaja.Left = 0!
            Me.lblNoCaja.Name = "lblNoCaja"
            Me.lblNoCaja.Style = ""
            Me.lblNoCaja.Text = "No. Caja:"
            Me.lblNoCaja.Top = 1.46875!
            Me.lblNoCaja.Width = 0.75!
            '
            'txtNoCaja
            '
            Me.txtNoCaja.Height = 0.1875!
            Me.txtNoCaja.Left = 0.75!
            Me.txtNoCaja.Name = "txtNoCaja"
            Me.txtNoCaja.Top = 1.4685!
            Me.txtNoCaja.Width = 0.6875!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1875!
            Me.txtFecha.Left = 0!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "Fecha:"
            Me.txtFecha.Top = 0.25!
            Me.txtFecha.Width = 1.375!
            '
            'txtHora
            '
            Me.txtHora.Height = 0.1875!
            Me.txtHora.Left = 1.375!
            Me.txtHora.Name = "txtHora"
            Me.txtHora.Text = "Hora:"
            Me.txtHora.Top = 0.25!
            Me.txtHora.Width = 1.125!
            '
            'txtVendedor
            '
            Me.txtVendedor.Height = 0.1875!
            Me.txtVendedor.Left = 0.75!
            Me.txtVendedor.Name = "txtVendedor"
            Me.txtVendedor.Top = 1.656!
            Me.txtVendedor.Width = 0.6875!
            '
            'lblVendedor
            '
            Me.lblVendedor.Height = 0.1875!
            Me.lblVendedor.HyperLink = Nothing
            Me.lblVendedor.Left = 0!
            Me.lblVendedor.Name = "lblVendedor"
            Me.lblVendedor.Style = ""
            Me.lblVendedor.Text = "Vendedor:"
            Me.lblVendedor.Top = 1.65625!
            Me.lblVendedor.Width = 0.75!
            '
            'txtNombreTienda
            '
            Me.txtNombreTienda.Height = 0.565!
            Me.txtNombreTienda.Left = 0!
            Me.txtNombreTienda.Name = "txtNombreTienda"
            Me.txtNombreTienda.Top = 0.7925!
            Me.txtNombreTienda.Width = 2.5!
            '
            'lblNewCard
            '
            Me.lblNewCard.Height = 0.1875!
            Me.lblNewCard.HyperLink = Nothing
            Me.lblNewCard.Left = 0!
            Me.lblNewCard.Name = "lblNewCard"
            Me.lblNewCard.Style = ""
            Me.lblNewCard.Text = "Nueva. Tarjeta:"
            Me.lblNewCard.Top = 2.125!
            Me.lblNewCard.Width = 1.0625!
            '
            'txtNewCard
            '
            Me.txtNewCard.Height = 0.1875!
            Me.txtNewCard.Left = 1.0625!
            Me.txtNewCard.Name = "txtNewCard"
            Me.txtNewCard.Top = 2.125!
            Me.txtNewCard.Width = 1.4375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.646!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblDPCardPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPuntosGanados,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPuntosGanados,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTotalPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPuntosEnPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPuntosPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTotalPuntosPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalPuntoPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPromocional,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMensaje,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblOldCard,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoTarjeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNewCard,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNewCard,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region
End Class
