Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptDPCardPuntos
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dpCardDatos As Hashtable)
        MyBase.New()
        InitializeComponent()
        If dpCardDatos.ContainsKey("TipoReporte") = True Then
            Dim tipoRep As String = CStr(dpCardDatos("TipoReporte")).ToUpper()
            Select Case tipoRep
                Case "ACT"
                    Me.lblDPCardPuntos.Text = "Activacion DPCard Puntos"
                Case "BON"
                    Me.lblDPCardPuntos.Text = "Bonificación de Puntos"
                Case "CAN"
                    Me.lblDPCardPuntos.Text = "Canje de Puntos"
                    '-------------------------------------------------------------------------------------------------------------------
                    'JNAVA (15.09.2015): Si es Canje, dejamos de mostrar los puntos en pesos y el total de puntos en pesos.
                    '-------------------------------------------------------------------------------------------------------------------
                    Me.txtPuntosPesos.Visible = False
                    Me.lblPuntosEnPesos.Visible = False

                    Me.lblTotalPuntosPesos.Visible = False
                    Me.txtTotalPuntoPesos.Visible = False

                    Me.lblPuntosGanados.Text = "Puntos Canjeados:"

                Case "DEV"
                    Me.lblDPCardPuntos.Text = "Devolucion de puntos"
            End Select
        End If
        Me.txtFecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
        Me.txtHora.Text = "Hora: " & DateTime.Now.ToString("HH:mm")
        Me.txtNoTienda.Text = oAppContext.ApplicationConfiguration.Almacen
        Me.txtNoCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        Me.txtVendedor.Text = CStr(dpCardDatos("CodVendedor"))
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Me.txtNombreTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        Me.txtNoTarjeta.Text = CStr(dpCardDatos("CardId"))
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
	Private lblNoTarjeta As Label = Nothing
	Private lblNoTienda As Label = Nothing
	Private txtNoTienda As TextBox = Nothing
	Private lblNoCaja As Label = Nothing
	Private txtNoCaja As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtHora As TextBox = Nothing
	Private txtVendedor As TextBox = Nothing
	Private lblVendedor As Label = Nothing
    Private txtNombreTienda As TextBox = Nothing
    Private txtNoTarjeta As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDPCardPuntos))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
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
        Me.lblNoTarjeta = New DataDynamics.ActiveReports.Label()
        Me.lblNoTienda = New DataDynamics.ActiveReports.Label()
        Me.txtNoTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblNoCaja = New DataDynamics.ActiveReports.Label()
        Me.txtNoCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.txtHora = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.lblVendedor = New DataDynamics.ActiveReports.Label()
        Me.txtNombreTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.lblDPCardPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPuntosGanados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosGanados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPuntosEnPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPuntosPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPuntoPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPromocional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMensaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDPCardPuntos, Me.lblPuntosGanados, Me.txtPuntosGanados, Me.lblTotalPuntos, Me.txtTotalPuntos, Me.lblPuntosEnPesos, Me.txtPuntosPesos, Me.lblTotalPuntosPesos, Me.txtTotalPuntoPesos, Me.txtPromocional, Me.txtMensaje, Me.lblNoTarjeta, Me.lblNoTienda, Me.txtNoTienda, Me.lblNoCaja, Me.txtNoCaja, Me.txtFecha, Me.txtHora, Me.txtVendedor, Me.lblVendedor, Me.txtNombreTienda, Me.txtNoTarjeta})
        Me.PageHeader.Height = 5.145833!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblDPCardPuntos
        '
        Me.lblDPCardPuntos.Height = 0.1875!
        Me.lblDPCardPuntos.HyperLink = Nothing
        Me.lblDPCardPuntos.Left = 0.44!
        Me.lblDPCardPuntos.Name = "lblDPCardPuntos"
        Me.lblDPCardPuntos.Style = "font-weight: bold; font-size: 9.75pt; vertical-align: top"
        Me.lblDPCardPuntos.Text = "Activacion DPCard Puntos"
        Me.lblDPCardPuntos.Top = 0.0!
        Me.lblDPCardPuntos.Width = 1.875!
        '
        'lblPuntosGanados
        '
        Me.lblPuntosGanados.Height = 0.1875!
        Me.lblPuntosGanados.HyperLink = Nothing
        Me.lblPuntosGanados.Left = 0.19!
        Me.lblPuntosGanados.Name = "lblPuntosGanados"
        Me.lblPuntosGanados.Style = ""
        Me.lblPuntosGanados.Text = "Puntos Canjeados:"
        Me.lblPuntosGanados.Top = 2.3125!
        Me.lblPuntosGanados.Width = 1.25!
        '
        'txtPuntosGanados
        '
        Me.txtPuntosGanados.Height = 0.1875!
        Me.txtPuntosGanados.Left = 1.44!
        Me.txtPuntosGanados.Name = "txtPuntosGanados"
        Me.txtPuntosGanados.Text = Nothing
        Me.txtPuntosGanados.Top = 2.3125!
        Me.txtPuntosGanados.Width = 1.25!
        '
        'lblTotalPuntos
        '
        Me.lblTotalPuntos.Height = 0.1875!
        Me.lblTotalPuntos.HyperLink = Nothing
        Me.lblTotalPuntos.Left = 0.19!
        Me.lblTotalPuntos.Name = "lblTotalPuntos"
        Me.lblTotalPuntos.Style = ""
        Me.lblTotalPuntos.Text = "Total Puntos:"
        Me.lblTotalPuntos.Top = 2.8125!
        Me.lblTotalPuntos.Width = 1.25!
        '
        'txtTotalPuntos
        '
        Me.txtTotalPuntos.Height = 0.1875!
        Me.txtTotalPuntos.Left = 1.44!
        Me.txtTotalPuntos.Name = "txtTotalPuntos"
        Me.txtTotalPuntos.Text = Nothing
        Me.txtTotalPuntos.Top = 2.8125!
        Me.txtTotalPuntos.Width = 1.25!
        '
        'lblPuntosEnPesos
        '
        Me.lblPuntosEnPesos.Height = 0.1875!
        Me.lblPuntosEnPesos.HyperLink = Nothing
        Me.lblPuntosEnPesos.Left = 0.19!
        Me.lblPuntosEnPesos.Name = "lblPuntosEnPesos"
        Me.lblPuntosEnPesos.Style = ""
        Me.lblPuntosEnPesos.Text = "Puntos en pesos:"
        Me.lblPuntosEnPesos.Top = 2.5!
        Me.lblPuntosEnPesos.Width = 1.25!
        '
        'txtPuntosPesos
        '
        Me.txtPuntosPesos.Height = 0.1875!
        Me.txtPuntosPesos.Left = 1.44!
        Me.txtPuntosPesos.Name = "txtPuntosPesos"
        Me.txtPuntosPesos.OutputFormat = resources.GetString("txtPuntosPesos.OutputFormat")
        Me.txtPuntosPesos.Text = Nothing
        Me.txtPuntosPesos.Top = 2.5!
        Me.txtPuntosPesos.Width = 1.25!
        '
        'lblTotalPuntosPesos
        '
        Me.lblTotalPuntosPesos.Height = 0.1875!
        Me.lblTotalPuntosPesos.HyperLink = Nothing
        Me.lblTotalPuntosPesos.Left = 0.19!
        Me.lblTotalPuntosPesos.Name = "lblTotalPuntosPesos"
        Me.lblTotalPuntosPesos.Style = ""
        Me.lblTotalPuntosPesos.Text = "Total Puntos en pesos:"
        Me.lblTotalPuntosPesos.Top = 3.0!
        Me.lblTotalPuntosPesos.Width = 1.5!
        '
        'txtTotalPuntoPesos
        '
        Me.txtTotalPuntoPesos.Height = 0.1875!
        Me.txtTotalPuntoPesos.Left = 1.69!
        Me.txtTotalPuntoPesos.Name = "txtTotalPuntoPesos"
        Me.txtTotalPuntoPesos.OutputFormat = resources.GetString("txtTotalPuntoPesos.OutputFormat")
        Me.txtTotalPuntoPesos.Text = Nothing
        Me.txtTotalPuntoPesos.Top = 3.0!
        Me.txtTotalPuntoPesos.Width = 1.0!
        '
        'txtPromocional
        '
        Me.txtPromocional.Height = 0.5625!
        Me.txtPromocional.Left = 0.19!
        Me.txtPromocional.Name = "txtPromocional"
        Me.txtPromocional.Text = Nothing
        Me.txtPromocional.Top = 3.375!
        Me.txtPromocional.Width = 2.5!
        '
        'txtMensaje
        '
        Me.txtMensaje.Height = 0.375!
        Me.txtMensaje.Left = 0.19!
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Style = "font-size: 8.25pt"
        Me.txtMensaje.Text = Nothing
        Me.txtMensaje.Top = 4.0625!
        Me.txtMensaje.Width = 2.5!
        '
        'lblNoTarjeta
        '
        Me.lblNoTarjeta.Height = 0.1875!
        Me.lblNoTarjeta.HyperLink = Nothing
        Me.lblNoTarjeta.Left = 0.19!
        Me.lblNoTarjeta.Name = "lblNoTarjeta"
        Me.lblNoTarjeta.Style = ""
        Me.lblNoTarjeta.Text = "No. Tarjeta:"
        Me.lblNoTarjeta.Top = 2.0!
        Me.lblNoTarjeta.Width = 0.8125!
        '
        'lblNoTienda
        '
        Me.lblNoTienda.Height = 0.1875!
        Me.lblNoTienda.HyperLink = Nothing
        Me.lblNoTienda.Left = 0.19!
        Me.lblNoTienda.Name = "lblNoTienda"
        Me.lblNoTienda.Style = ""
        Me.lblNoTienda.Text = "No. Tienda:"
        Me.lblNoTienda.Top = 0.53125!
        Me.lblNoTienda.Width = 0.75!
        '
        'txtNoTienda
        '
        Me.txtNoTienda.Height = 0.1875!
        Me.txtNoTienda.Left = 0.9400001!
        Me.txtNoTienda.Name = "txtNoTienda"
        Me.txtNoTienda.Text = Nothing
        Me.txtNoTienda.Top = 0.531!
        Me.txtNoTienda.Width = 0.6875!
        '
        'lblNoCaja
        '
        Me.lblNoCaja.Height = 0.1875!
        Me.lblNoCaja.HyperLink = Nothing
        Me.lblNoCaja.Left = 0.19!
        Me.lblNoCaja.Name = "lblNoCaja"
        Me.lblNoCaja.Style = ""
        Me.lblNoCaja.Text = "No. Caja:"
        Me.lblNoCaja.Top = 1.46875!
        Me.lblNoCaja.Width = 0.75!
        '
        'txtNoCaja
        '
        Me.txtNoCaja.Height = 0.1875!
        Me.txtNoCaja.Left = 0.9400001!
        Me.txtNoCaja.Name = "txtNoCaja"
        Me.txtNoCaja.Text = Nothing
        Me.txtNoCaja.Top = 1.4685!
        Me.txtNoCaja.Width = 0.6875!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 0.19!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "Fecha:"
        Me.txtFecha.Top = 0.25!
        Me.txtFecha.Width = 1.375!
        '
        'txtHora
        '
        Me.txtHora.Height = 0.1875!
        Me.txtHora.Left = 1.565!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Text = "Hora:"
        Me.txtHora.Top = 0.25!
        Me.txtHora.Width = 1.125!
        '
        'txtVendedor
        '
        Me.txtVendedor.Height = 0.1875!
        Me.txtVendedor.Left = 0.9400001!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Text = Nothing
        Me.txtVendedor.Top = 1.656!
        Me.txtVendedor.Width = 0.6875!
        '
        'lblVendedor
        '
        Me.lblVendedor.Height = 0.1875!
        Me.lblVendedor.HyperLink = Nothing
        Me.lblVendedor.Left = 0.19!
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Style = ""
        Me.lblVendedor.Text = "Vendedor:"
        Me.lblVendedor.Top = 1.65625!
        Me.lblVendedor.Width = 0.75!
        '
        'txtNombreTienda
        '
        Me.txtNombreTienda.Height = 0.565!
        Me.txtNombreTienda.Left = 0.19!
        Me.txtNombreTienda.Name = "txtNombreTienda"
        Me.txtNombreTienda.Text = Nothing
        Me.txtNombreTienda.Top = 0.7925!
        Me.txtNombreTienda.Width = 2.5!
        '
        'txtNoTarjeta
        '
        Me.txtNoTarjeta.Height = 0.1875!
        Me.txtNoTarjeta.Left = 1.0025!
        Me.txtNoTarjeta.Name = "txtNoTarjeta"
        Me.txtNoTarjeta.Text = Nothing
        Me.txtNoTarjeta.Top = 2.0!
        Me.txtNoTarjeta.Width = 1.6875!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptDPCardPuntos
        '
        Me.MasterReport = False
        Me.PageSettings.Gutter = 0.04!
        Me.PageSettings.Margins.Bottom = 0.04!
        Me.PageSettings.Margins.Left = 0.04!
        Me.PageSettings.Margins.Right = 0.04!
        Me.PageSettings.Margins.Top = 0.04!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.813!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.lblDPCardPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPuntosGanados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosGanados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPuntosEnPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPuntosPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPuntoPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPromocional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMensaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
