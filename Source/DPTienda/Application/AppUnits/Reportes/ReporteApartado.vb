Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class ReporteApartado
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oForm As frmContratos, ByVal oFormClientes As ClienteAlterno, ByVal strDocFi As String, Optional ByVal Reimpresion As Boolean = False)
        MyBase.New()
        InitializeComponent()
        lblReimpresion.Visible = Reimpresion
        With oForm
            tbFolio.Text = .ebFolio.Text
            'tbLugarFecha.Text = .ebFechaFactura.Text
            tbNombre.Text = oFormClientes.Nombre & " " & oFormClientes.ApellidoMaterno & " " & oFormClientes.ApellidoPaterno
            tbDomicilio.Text = oFormClientes.Direccion
            tbCiudad.Text = oFormClientes.Ciudad
            tbRFC.Text = oFormClientes.RFC

            tbTelefono.Text = oFormClientes.Telefono
            Me.txtFecha.Text = .ebFecha.Text
            Me.TxtBxDocFi.Text = "DOCFI SAP: " & strDocFi
            'tbPlayer.Text = .ebNumPlayer.Text
            'tbSubTotal.Text = .ebSubTotal.Text
            'tbIVA.Text = .ebIVA.Text
            tbImporteTotal.Text = .ebImporteTotal.Text
            Me.ebCodCaja.Text += " " & oAppContext.ApplicationConfiguration.NoCaja
        End With

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private tbFolio As TextBox = Nothing
    Private tbNombre As TextBox = Nothing
    Private tbDomicilio As TextBox = Nothing
    Private tbCiudad As TextBox = Nothing
    Private tbRFC As TextBox = Nothing
    Private tbTelefono As TextBox = Nothing
    Private ebCodCaja As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private TxtBxDocFi As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox8 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private TextBox11 As TextBox = Nothing
    Private TextBox12 As TextBox = Nothing
    Private TextBox13 As TextBox = Nothing
    Friend WithEvents lblReimpresion As DataDynamics.ActiveReports.TextBox
    Private tbImporteTotal As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteApartado))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombre = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.tbCiudad = New DataDynamics.ActiveReports.TextBox()
        Me.tbRFC = New DataDynamics.ActiveReports.TextBox()
        Me.tbTelefono = New DataDynamics.ActiveReports.TextBox()
        Me.ebCodCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.TxtBxDocFi = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.tbImporteTotal = New DataDynamics.ActiveReports.TextBox()
        Me.lblReimpresion = New DataDynamics.ActiveReports.TextBox()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ebCodCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxDocFi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox7, Me.TextBox8, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13})
        Me.Detail.Height = 0.2076389!
        Me.Detail.Name = "Detail"
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "Cantidad"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 0.0625!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-size: 8.25pt"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.4375!
        '
        'TextBox8
        '
        Me.TextBox8.DataField = "CodArticulo"
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 0.5!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "font-size: 8.25pt"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 1.3125!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "Numero"
        Me.TextBox10.Height = 0.2!
        Me.TextBox10.Left = 2.125!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.375!
        '
        'TextBox11
        '
        Me.TextBox11.DataField = "Precio"
        Me.TextBox11.Height = 0.2!
        Me.TextBox11.Left = 2.5!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.75!
        '
        'TextBox12
        '
        Me.TextBox12.DataField = "Importe"
        Me.TextBox12.Height = 0.2!
        Me.TextBox12.Left = 3.25!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 0.625!
        '
        'TextBox13
        '
        Me.TextBox13.DataField = "Descuento"
        Me.TextBox13.Height = 0.2!
        Me.TextBox13.Left = 4.0625!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 1; font-size: 8.25pt"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Visible = False
        Me.TextBox13.Width = 0.625!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.tbNombre, Me.tbDomicilio, Me.tbCiudad, Me.tbRFC, Me.tbTelefono, Me.ebCodCaja, Me.txtFecha, Me.TxtBxDocFi, Me.lblReimpresion})
        Me.PageHeader.Height = 1.427083!
        Me.PageHeader.Name = "PageHeader"
        '
        'tbFolio
        '
        Me.tbFolio.Height = 0.2!
        Me.tbFolio.Left = 5.063!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "font-size: 8.25pt"
        Me.tbFolio.Text = Nothing
        Me.tbFolio.Top = 0.125!
        Me.tbFolio.Width = 1.0625!
        '
        'tbNombre
        '
        Me.tbNombre.Height = 0.2!
        Me.tbNombre.Left = 0.5!
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Style = "font-size: 8.25pt"
        Me.tbNombre.Text = Nothing
        Me.tbNombre.Top = 0.25!
        Me.tbNombre.Width = 3.125!
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Height = 0.2!
        Me.tbDomicilio.Left = 0.5!
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Style = "font-size: 8.25pt"
        Me.tbDomicilio.Text = Nothing
        Me.tbDomicilio.Top = 0.375!
        Me.tbDomicilio.Width = 1.0!
        '
        'tbCiudad
        '
        Me.tbCiudad.Height = 0.2!
        Me.tbCiudad.Left = 0.512!
        Me.tbCiudad.Name = "tbCiudad"
        Me.tbCiudad.Style = "font-size: 8.25pt"
        Me.tbCiudad.Text = Nothing
        Me.tbCiudad.Top = 0.591!
        Me.tbCiudad.Width = 1.0!
        '
        'tbRFC
        '
        Me.tbRFC.Height = 0.2!
        Me.tbRFC.Left = 0.5!
        Me.tbRFC.Name = "tbRFC"
        Me.tbRFC.Style = "font-size: 8.25pt"
        Me.tbRFC.Text = Nothing
        Me.tbRFC.Top = 0.75!
        Me.tbRFC.Width = 1.6875!
        '
        'tbTelefono
        '
        Me.tbTelefono.Height = 0.2!
        Me.tbTelefono.Left = 3.063!
        Me.tbTelefono.Name = "tbTelefono"
        Me.tbTelefono.Style = "font-size: 8.25pt"
        Me.tbTelefono.Text = Nothing
        Me.tbTelefono.Top = 0.75!
        Me.tbTelefono.Width = 1.3125!
        '
        'ebCodCaja
        '
        Me.ebCodCaja.Height = 0.2!
        Me.ebCodCaja.Left = 0.5!
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Text = "Caja.: "
        Me.ebCodCaja.Top = 0.063!
        Me.ebCodCaja.Width = 1.0!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 2.938!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt"
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.063!
        Me.txtFecha.Width = 1.629429!
        '
        'TxtBxDocFi
        '
        Me.TxtBxDocFi.Height = 0.2!
        Me.TxtBxDocFi.Left = 4.5625!
        Me.TxtBxDocFi.Name = "TxtBxDocFi"
        Me.TxtBxDocFi.Style = "font-size: 8.25pt"
        Me.TxtBxDocFi.Text = Nothing
        Me.TxtBxDocFi.Top = 0.75!
        Me.TxtBxDocFi.Visible = False
        Me.TxtBxDocFi.Width = 1.5625!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbImporteTotal})
        Me.PageFooter.Height = 0.2076389!
        Me.PageFooter.Name = "PageFooter"
        '
        'tbImporteTotal
        '
        Me.tbImporteTotal.Height = 0.2!
        Me.tbImporteTotal.Left = 3.125!
        Me.tbImporteTotal.Name = "tbImporteTotal"
        Me.tbImporteTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.tbImporteTotal.Text = Nothing
        Me.tbImporteTotal.Top = 0.0!
        Me.tbImporteTotal.Width = 1.0!
        '
        'lblReimpresion
        '
        Me.lblReimpresion.Height = 0.2!
        Me.lblReimpresion.Left = 0.5!
        Me.lblReimpresion.Name = "lblReimpresion"
        Me.lblReimpresion.Style = "font-weight: bold"
        Me.lblReimpresion.Text = "Reimpresion"
        Me.lblReimpresion.Top = 1.083!
        Me.lblReimpresion.Width = 1.0!
        '
        'ReporteApartado
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 5.0!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperWidth = 6.0!
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
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ebCodCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxDocFi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
