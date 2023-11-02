Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras


Public Class ValeCajaDevEfectivo
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private tbCliente As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label2 As Label = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Label4 As Label = Nothing
	Private tbDocumentoTipo As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private tbDocumentoFolio As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private tbDocumentoImporte As TextBox = Nothing
	Private tbImporteMoneda As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaDevEfectivo))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoTipo = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoImporte = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporteMoneda = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoTipo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporteMoneda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte, Me.tbImporteMoneda})
            Me.Detail.Height = 0.6666667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.tbCliente, Me.Label3, Me.Label2, Me.tbFolio, Me.tbFecha, Me.Line1})
            Me.PageHeader.Height = 0.7694445!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.Line2})
            Me.GroupFooter1.Height = 0.2388889!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.25!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label1.Text = "Devolución de Dinero"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.1875!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.1875!
            Me.tbCliente.Left = 0.125!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbCliente.Text = "tbCliente"
            Me.tbCliente.Top = 0.5!
            Me.tbCliente.Width = 4.375!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 4.8125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label3.Text = "Fecha :"
            Me.Label3.Top = 0.5625!
            Me.Label3.Width = 0.5!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 4.8125!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Folio :"
            Me.Label2.Top = 0.3125!
            Me.Label2.Width = 0.4375!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 5.375!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFolio.Text = "tbFolio"
            Me.tbFolio.Top = 0.3125!
            Me.tbFolio.Width = 0.875!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 5.375!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFecha.Text = "tbFecha"
            Me.tbFecha.Top = 0.5625!
            Me.tbFecha.Width = 0.9375!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0246063!
            Me.Line1.LineWeight = 3!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.0246063!
            Me.Line1.Width = 6.422245!
            Me.Line1.X1 = 0.0246063!
            Me.Line1.X2 = 6.446851!
            Me.Line1.Y1 = 0.0246063!
            Me.Line1.Y2 = 0.0246063!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Docto. Origen :"
            Me.Label4.Top = 0.0625!
            Me.Label4.Width = 1!
            '
            'tbDocumentoTipo
            '
            Me.tbDocumentoTipo.Height = 0.1875!
            Me.tbDocumentoTipo.Left = 1.1875!
            Me.tbDocumentoTipo.Name = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoTipo.Text = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Top = 0.0625!
            Me.tbDocumentoTipo.Width = 1.0625!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.3125!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label5.Text = "Folio :"
            Me.Label5.Top = 0.0625!
            Me.Label5.Width = 0.4375!
            '
            'tbDocumentoFolio
            '
            Me.tbDocumentoFolio.Height = 0.1875!
            Me.tbDocumentoFolio.Left = 2.8125!
            Me.tbDocumentoFolio.Name = "tbDocumentoFolio"
            Me.tbDocumentoFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoFolio.Text = "tbDocumentoFolio"
            Me.tbDocumentoFolio.Top = 0.0625!
            Me.tbDocumentoFolio.Width = 1.0625!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.9375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label6.Text = "Importe :"
            Me.Label6.Top = 0.0625!
            Me.Label6.Width = 0.6875!
            '
            'tbDocumentoImporte
            '
            Me.tbDocumentoImporte.Height = 0.1875!
            Me.tbDocumentoImporte.Left = 4.6875!
            Me.tbDocumentoImporte.Name = "tbDocumentoImporte"
            Me.tbDocumentoImporte.OutputFormat = resources.GetString("tbDocumentoImporte.OutputFormat")
            Me.tbDocumentoImporte.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoImporte.Text = "tbDocumentoImporte"
            Me.tbDocumentoImporte.Top = 0.0625!
            Me.tbDocumentoImporte.Width = 1.25!
            '
            'tbImporteMoneda
            '
            Me.tbImporteMoneda.Height = 0.1875!
            Me.tbImporteMoneda.Left = 0.125!
            Me.tbImporteMoneda.Name = "tbImporteMoneda"
            Me.tbImporteMoneda.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbImporteMoneda.Text = "tbImporteMoneda"
            Me.tbImporteMoneda.Top = 0.4375!
            Me.tbImporteMoneda.Width = 5.9375!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.1875!
            Me.TextBox1.Left = 0.03125!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.TextBox1.Text = """Recibí en efectivo la cantidad arriba mencionada."""
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 3.875!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0.0492126!
            Me.Line2.LineWeight = 3!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.2214567!
            Me.Line2.Width = 6.373032!
            Me.Line2.X1 = 0.0492126!
            Me.Line2.X2 = 6.422244!
            Me.Line2.Y1 = 0.2214567!
            Me.Line2.Y2 = 0.2214567!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoTipo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporteMoneda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



#Region "Members Variables"

    Private oValeCaja As ValeCaja

#End Region



#Region "Constructors"

    Public Sub New(ByVal pValeCaja As ValeCaja)

        MyBase.New()
        InitializeComponent()


        oValeCaja = pValeCaja

        Sm_MostrarInformacion()


    End Sub

#End Region



#Region "Methods"

    Private Sub Sm_MostrarInformacion()

        With oValeCaja

            Me.tbFolio.Text = .ValeCajaID

            Me.tbFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoFolio.Text = .FolioDocumento

            Me.tbDocumentoImporte.Text = Format(.Importe, "Currency")


            Dim Cantidad() As String = CStr(.Importe).Split(".")
            Dim oNumeroLetra As New Letras

            If Cantidad.Length < 2 Then

                Me.tbImporteMoneda.Text = "(" & oNumeroLetra.Letras(Cantidad(0)) & " Pesos 00/100 M.N.)"

            Else
                Cantidad(1) = Cantidad(1).PadRight(2, "0")
                Me.tbImporteMoneda.Text = "(" & oNumeroLetra.Letras(Cantidad(0)) & " Pesos " & Cantidad(1).Substring(0, 2) & "/100 M.N.)"

            End If

        End With

    End Sub

#End Region

End Class
