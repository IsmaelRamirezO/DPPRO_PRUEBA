Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports System.Collections.Generic

Public Class rptTicketSeguroConfigurable
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal htDatosTicket As Hashtable)
        MyBase.New()
        InitializeComponent()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim Texto As String = FacturaMgr.GetDPValeAviso("Poliza")
        Texto = Texto.Replace("{Plaza}", CStr(htDatosTicket("Plaza")).Trim())
        Texto = Texto.Replace("{Expedido}", CStr(htDatosTicket("Ciudad")).Trim())
        Texto = Texto.Replace("{TiendaDomicilio}", CStr(htDatosTicket("Direccion")).Trim())
        Texto = Texto.Replace("{Caja}", CStr(htDatosTicket("Caja")).Trim())
        Texto = Texto.Replace("{Fecha}", DateTime.Now.ToShortDateString())
        Texto = Texto.Replace("{Hora}", Format(DateTime.Now, "HH:mm:ss"))
        Texto = Texto.Replace("{CodigoCliente}", CStr(htDatosTicket("NoCanjeante")).Trim())
        Texto = Texto.Replace("{NombreCliente}", CStr(htDatosTicket("Canjeante")).Trim())
        Texto = Texto.Replace("{RFC}", CStr(htDatosTicket("RFC")).Trim())
        Texto = Texto.Replace("{Sexo}", CStr(htDatosTicket("Sexo")).Trim())
        Texto = Texto.Replace("{MontoQuincenal}", "$" & CDec(htDatosTicket("ImporteSeguroQuin")).ToString("##,##0.00"))
        Texto = Texto.Replace("{ImporteSeguro}", "$" & CDec(htDatosTicket("ImporteSeguro")).ToString("##,##0.00"))
        Texto = Texto.Replace("{TotalSeguro}", "$" & CDec(htDatosTicket("MontoSeguro")).ToString("##,##0.00"))
        Texto = Texto.Replace("{FechaInicio}", CDate(htDatosTicket("FechaInicio")).ToString("dd/MM/yyyy"))
        Texto = Texto.Replace("{FechaFin}", CDate(htDatosTicket("FechaFin")).ToString("dd/MM/yyyy"))
        Texto = Texto.Replace("{NoPoliza}", CStr(htDatosTicket("NoPoliza")))
        Texto = Texto.Replace("{Beneficiario}", CStr(htDatosTicket("Beneficiarios")).Trim())
        Me.txtPolizaSeguro.Html = Texto
        'txtPlaza.Text = htDatosTicket("Plaza")
        'txtCiudad.Text = htDatosTicket("Ciudad")
        'txtDireccion.Text = htDatosTicket("Direccion")

        'txtCaja.Text = htDatosTicket("Caja")

        'txtFecha.Text = Date.Now.ToShortDateString
        'txtHora.Text = Format(Date.Now, "HH:mm:ss")

        'txtAseguradora.Text = htDatosTicket("Aseguradora")

        'txtNoCanjeante.Text = htDatosTicket("NoCanjeante")
        'txtCanjeante.Text = htDatosTicket("Canjeante")

        'txtRFC.Text = htDatosTicket("RFC")
        'txtSexo.Text = htDatosTicket("Sexo")
        'Dim leyenda As String = Me.lblLeyendaSeguro.Text.Trim()
        'leyenda = leyenda.Replace("{0}", "$" & CDec(htDatosTicket("ImporteSeguroQuin")).ToString("##,##0.00"))
        'leyenda = leyenda.Replace("{1}", "$" & CDec(htDatosTicket("ImporteSeguro")).ToString("##,##0.00"))
        'leyenda = leyenda.Replace("{2}", "$" & CDec(htDatosTicket("MontoSeguro")).ToString("##,##0.00"))
        'leyenda = leyenda.Replace("{3}", CDate(htDatosTicket("FechaInicio")).ToString("dd/MM/yyyy"))
        'leyenda = leyenda.Replace("{4}", CDate(htDatosTicket("FechaFin")).ToString("dd/MM/yyyy"))
        'Me.lblLeyendaSeguro.Text = leyenda
        ''txtImporteFinanciamiento.Text = CStr(htDatosTicket("ImporteSeguro")) & ","
        ' ''txtImporteFinanciamiento.Text = htDatosTicket("ImporteFin") & ","
        ''txtMontoSeguro.Text = htDatosTicket("MontoSeguro")
        ''txtVigencia.Text = Format(CDate(htDatosTicket("Vigencia")), "dd/MM/yyyy") ' & "."
        'txtNoPoliza.Text = htDatosTicket("NoPoliza")
        'txtBeneficiarios.Text = htDatosTicket("Beneficiarios")
        'txtDireccionFinanciador.Text = htDatosTicket("DireccionFinanciador")
        'txtTelefonoFinanciador.Text = htDatosTicket("TelefonoFinanciador") & ","
        'txtTelefonoInformacion.Text = htDatosTicket("TelefonoInformacion")
        'txtAseguradora2.Text = htDatosTicket("Aseguradora2") & ","
        'txtDireccionFinanciador2.Text = htDatosTicket("DireccionFinanciador")

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents txtPolizaSeguro As DataDynamics.ActiveReports.RichTextBox
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTicketSeguroConfigurable))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtPolizaSeguro = New DataDynamics.ActiveReports.RichTextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPolizaSeguro})
        Me.Detail.Height = 12.238!
        Me.Detail.Name = "Detail"
        '
        'txtPolizaSeguro
        '
        Me.txtPolizaSeguro.AutoReplaceFields = True
        Me.txtPolizaSeguro.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtPolizaSeguro.Height = 12.116!
        Me.txtPolizaSeguro.Left = 0.0!
        Me.txtPolizaSeguro.Name = "txtPolizaSeguro"
        Me.txtPolizaSeguro.RTF = resources.GetString("txtPolizaSeguro.RTF")
        Me.txtPolizaSeguro.Top = 0.0!
        Me.txtPolizaSeguro.Width = 2.623!
        '
        'rptTicketSeguroConfigurable
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.874917!
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
