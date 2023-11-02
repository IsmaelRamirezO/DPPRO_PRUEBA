Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja


Public Class rptValeCajaAbonoCredito
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oValeCajaNuevo As ValeCaja, ByVal FolioValeUtilizado As Integer, ByVal dblPagoMovimiento As Double)
        MyBase.New()
        InitializeComponent()

        Me.txtFolioMovimiento.Text = oValeCajaNuevo.FolioDocumento
        Me.txtFolioValeNuevo.Text = oValeCajaNuevo.ValeCajaID
        Me.txtNombre.Text = oValeCajaNuevo.Nombre
        Me.txtFecha.Text = Format(oValeCajaNuevo.Fecha, "dd/mm/yyyy hh:mm:ss")
        Me.txtFolioValeOrigen.Text = FolioValeUtilizado
        Me.txtImporteMovimiento.Text = Format(oValeCajaNuevo.DocumentoImporte, "c")
        Me.txtPagoMovimiento.Text = "(" & Format(dblPagoMovimiento, "c") & ")"
        Me.txtDifenciaMovimiento.Text = Format(oValeCajaNuevo.Importe, "c")
        Me.txtImporteValeOrigen.Text = Format(dblPagoMovimiento + oValeCajaNuevo.Importe, "c")

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private txtFolioValeNuevo As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtNombre As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtFolioValeOrigen As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtImporteValeOrigen As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtFolioMovimiento As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private txtImporteMovimiento As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private txtPagoMovimiento As TextBox = Nothing
	Private Label11 As Label = Nothing
	Private txtDifenciaMovimiento As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptValeCajaAbonoCredito))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioValeNuevo = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioValeOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtImporteValeOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.txtImporteMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.txtPagoMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtDifenciaMovimiento = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioValeNuevo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioValeOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteValeOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPagoMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDifenciaMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0.0625!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.txtFolioValeNuevo, Me.Label2, Me.Label3, Me.txtFecha, Me.txtNombre, Me.Label4, Me.TextBox1, Me.Label5, Me.txtFolioValeOrigen, Me.Label6, Me.txtImporteValeOrigen, Me.Label7, Me.Label8, Me.txtFolioMovimiento, Me.Label9, Me.txtImporteMovimiento, Me.Label10, Me.txtPagoMovimiento, Me.Label11, Me.txtDifenciaMovimiento})
            Me.PageHeader.Height = 2.5!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 3.779528!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Folio:"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 0.5118108!
            '
            'txtFolioValeNuevo
            '
            Me.txtFolioValeNuevo.Height = 0.2!
            Me.txtFolioValeNuevo.Left = 4.370079!
            Me.txtFolioValeNuevo.Name = "txtFolioValeNuevo"
            Me.txtFolioValeNuevo.Style = "font-size: 8.25pt"
            Me.txtFolioValeNuevo.Top = 0.07874014!
            Me.txtFolioValeNuevo.Width = 1.102362!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.771653!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "VALE DE CAJA"
            Me.Label2.Top = 0.488681!
            Me.Label2.Width = 1.299212!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.779528!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Fecha:"
            Me.Label3.Top = 0.3312008!
            Me.Label3.Width = 0.5118108!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 4.370079!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Top = 0.3312008!
            Me.txtFecha.Width = 1.929133!
            '
            'txtNombre
            '
            Me.txtNombre.Height = 0.2!
            Me.txtNombre.Left = 0.1574803!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Style = "font-size: 8.25pt"
            Me.txtNombre.Top = 0.8754923!
            Me.txtNombre.Width = 4.606299!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.1181103!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Documento Origen:"
            Me.Label4.Top = 1.206693!
            Me.Label4.Width = 1.377953!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 1.614173!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-size: 8.25pt"
            Me.TextBox1.Text = "Vale de Caja"
            Me.TextBox1.Top = 1.206693!
            Me.TextBox1.Width = 0.8267716!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.480315!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "Folio:"
            Me.Label5.Top = 1.206693!
            Me.Label5.Width = 0.5118108!
            '
            'txtFolioValeOrigen
            '
            Me.txtFolioValeOrigen.Height = 0.2!
            Me.txtFolioValeOrigen.Left = 3.031496!
            Me.txtFolioValeOrigen.Name = "txtFolioValeOrigen"
            Me.txtFolioValeOrigen.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolioValeOrigen.Top = 1.206693!
            Me.txtFolioValeOrigen.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 4.094488!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Importe:"
            Me.Label6.Top = 1.206693!
            Me.Label6.Width = 0.5905509!
            '
            'txtImporteValeOrigen
            '
            Me.txtImporteValeOrigen.Height = 0.2!
            Me.txtImporteValeOrigen.Left = 4.72441!
            Me.txtImporteValeOrigen.Name = "txtImporteValeOrigen"
            Me.txtImporteValeOrigen.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporteValeOrigen.Top = 1.220472!
            Me.txtImporteValeOrigen.Width = 1!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.1181103!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Movimientos:"
            Me.Label7.Top = 1.505413!
            Me.Label7.Width = 1!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.1574803!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "font-size: 8.25pt"
            Me.Label8.Text = "Folio"
            Me.Label8.Top = 1.850394!
            Me.Label8.Width = 0.3937007!
            '
            'txtFolioMovimiento
            '
            Me.txtFolioMovimiento.Height = 0.2!
            Me.txtFolioMovimiento.Left = 0.6692914!
            Me.txtFolioMovimiento.Name = "txtFolioMovimiento"
            Me.txtFolioMovimiento.Style = "font-size: 8.25pt"
            Me.txtFolioMovimiento.Text = "TextBox3"
            Me.txtFolioMovimiento.Top = 1.850394!
            Me.txtFolioMovimiento.Width = 1.220472!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.125984!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 8.25pt"
            Me.Label9.Text = "Importe"
            Me.Label9.Top = 1.850394!
            Me.Label9.Width = 0.511811!
            '
            'txtImporteMovimiento
            '
            Me.txtImporteMovimiento.Height = 0.2!
            Me.txtImporteMovimiento.Left = 2.755905!
            Me.txtImporteMovimiento.Name = "txtImporteMovimiento"
            Me.txtImporteMovimiento.Style = "font-size: 8.25pt"
            Me.txtImporteMovimiento.Text = "TextBox3"
            Me.txtImporteMovimiento.Top = 1.850394!
            Me.txtImporteMovimiento.Width = 1.299212!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 4.251969!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-size: 8.25pt"
            Me.Label10.Text = "Pago"
            Me.Label10.Top = 1.850394!
            Me.Label10.Width = 0.4330709!
            '
            'txtPagoMovimiento
            '
            Me.txtPagoMovimiento.Height = 0.2!
            Me.txtPagoMovimiento.Left = 4.76378!
            Me.txtPagoMovimiento.Name = "txtPagoMovimiento"
            Me.txtPagoMovimiento.Style = "font-size: 8.25pt"
            Me.txtPagoMovimiento.Text = "TextBox3"
            Me.txtPagoMovimiento.Top = 1.850394!
            Me.txtPagoMovimiento.Width = 1!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 3.110236!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label11.Text = "Importe a Favor"
            Me.Label11.Top = 2.204724!
            Me.Label11.Width = 1.181102!
            '
            'txtDifenciaMovimiento
            '
            Me.txtDifenciaMovimiento.Height = 0.2!
            Me.txtDifenciaMovimiento.Left = 4.448819!
            Me.txtDifenciaMovimiento.Name = "txtDifenciaMovimiento"
            Me.txtDifenciaMovimiento.Style = "font-size: 8.25pt"
            Me.txtDifenciaMovimiento.Text = "TextBox4"
            Me.txtDifenciaMovimiento.Top = 2.204724!
            Me.txtDifenciaMovimiento.Width = 1.338583!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 5.889583!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 8.5!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioValeNuevo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioValeOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteValeOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPagoMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDifenciaMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
