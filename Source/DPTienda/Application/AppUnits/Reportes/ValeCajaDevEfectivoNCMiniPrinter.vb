Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras

Public Class ValeCajaDevEfectivoNCMiniPrinter
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
	Private Label4 As Label = Nothing
	Private tbDocumentoTipo As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private tbDocumentoFolio As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private tbDocumentoImporte As TextBox = Nothing
	Private tbImporteMoneda As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Label7 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaDevEfectivoMiniPrinter))
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
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoTipo = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoImporte = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporteMoneda = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
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
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte, Me.tbImporteMoneda})
            Me.Detail.Height = 0.7291667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.tbCliente, Me.Label3, Me.Label2, Me.tbFolio, Me.tbFecha})
            Me.PageHeader.Height = 1.208333!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.Line1, Me.Label7})
            Me.GroupFooter1.Height = 0.9166667!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.1574803!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.6437007!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label1.Text = "DEVOLUCIÓN DE DINERO"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 1.811024!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.1889764!
            Me.tbCliente.Left = 0.2559055!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.tbCliente.Text = "tbCliente"
            Me.tbCliente.Top = 1.023622!
            Me.tbCliente.Width = 2.484252!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.2559055!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label3.Text = "FECHA :"
            Me.Label3.Top = 0.722441!
            Me.Label3.Width = 0.5!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.2559055!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label2.Text = "FOLIO :"
            Me.Label2.Top = 0.472441!
            Me.Label2.Width = 0.4375!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 0.8449799!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.tbFolio.Text = "tbFolio"
            Me.tbFolio.Top = 0.472441!
            Me.tbFolio.Width = 1.091044!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 0.8449799!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.tbFecha.Text = "tbFecha"
            Me.tbFecha.Top = 0.722441!
            Me.tbFecha.Width = 1.091044!
            '
            'Label4
            '
            Me.Label4.Height = 0.1732283!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.2559055!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label4.Text = "Docto. Origen :"
            Me.Label4.Top = 0.06299213!
            Me.Label4.Width = 0.8986222!
            '
            'tbDocumentoTipo
            '
            Me.tbDocumentoTipo.Height = 0.1574803!
            Me.tbDocumentoTipo.Left = 1.181102!
            Me.tbDocumentoTipo.Name = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.tbDocumentoTipo.Text = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Top = 0.06299213!
            Me.tbDocumentoTipo.Width = 0.944882!
            '
            'Label5
            '
            Me.Label5.Height = 0.1574803!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.2559055!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label5.Text = "Folio :"
            Me.Label5.Top = 0.3149606!
            Me.Label5.Width = 0.3740158!
            '
            'tbDocumentoFolio
            '
            Me.tbDocumentoFolio.Height = 0.1574803!
            Me.tbDocumentoFolio.Left = 0.6299213!
            Me.tbDocumentoFolio.Name = "tbDocumentoFolio"
            Me.tbDocumentoFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.tbDocumentoFolio.Text = "000000000"
            Me.tbDocumentoFolio.Top = 0.3149606!
            Me.tbDocumentoFolio.Width = 0.7086618!
            '
            'Label6
            '
            Me.Label6.Height = 0.1574803!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.401083!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.Label6.Text = "Importe :"
            Me.Label6.Top = 0.3149606!
            Me.Label6.Width = 0.5511812!
            '
            'tbDocumentoImporte
            '
            Me.tbDocumentoImporte.Height = 0.1574803!
            Me.tbDocumentoImporte.Left = 2.014764!
            Me.tbDocumentoImporte.Name = "tbDocumentoImporte"
            Me.tbDocumentoImporte.OutputFormat = resources.GetString("tbDocumentoImporte.OutputFormat")
            Me.tbDocumentoImporte.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
            Me.tbDocumentoImporte.Text = "$9,999.00"
            Me.tbDocumentoImporte.Top = 0.3149606!
            Me.tbDocumentoImporte.Width = 0.6624017!
            '
            'tbImporteMoneda
            '
            Me.tbImporteMoneda.Height = 0.1574803!
            Me.tbImporteMoneda.Left = 0.2559055!
            Me.tbImporteMoneda.Name = "tbImporteMoneda"
            Me.tbImporteMoneda.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
            Me.tbImporteMoneda.Text = "tbImporteMoneda"
            Me.tbImporteMoneda.Top = 0.551181!
            Me.tbImporteMoneda.Width = 2.42126!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.3149606!
            Me.TextBox1.Left = 0.2559055!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
            Me.TextBox1.Text = """Recibí en efectivo la cantidad arriba mencionada."""
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 2.5!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.7156056!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.7943459!
            Me.Line1.Width = 1.259843!
            Me.Line1.X1 = 1.975449!
            Me.Line1.X2 = 0.7156056!
            Me.Line1.Y1 = 0.7943459!
            Me.Line1.Y2 = 0.7943459!
            '
            'Label7
            '
            Me.Label7.Height = 0.1574803!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.102362!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label7.Text = "FIRMA"
            Me.Label7.Top = 0.3937007!
            Me.Label7.Width = 0.3937008!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.760417!
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
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
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

            Me.tbFolio.Text = CStr(.ValeCajaID).PadLeft(10, "0")

            Me.tbFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoFolio.Text = CStr(.FolioDocumento).PadLeft(10, "0")

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
