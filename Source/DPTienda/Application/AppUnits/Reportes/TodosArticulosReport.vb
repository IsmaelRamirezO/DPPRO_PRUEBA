Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.ReportTodosArticulos

Public Class TodosArticulosReport
    Inherits DataDynamics.ActiveReports.ActiveReport
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape2 As Shape = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private LblFecha As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private Label5 As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lbFechaInicio As Label = Nothing
	Private Label7 As Label = Nothing
	Private lbFechaFin As Label = Nothing
	Private Label9 As Label = Nothing
	Private tbDescripcion As TextBox = Nothing
	Private tbExistencia As TextBox = Nothing
	Private tbCodigo As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Label10 As Label = Nothing
	Private tbTotalArticulos As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TodosArticulosReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
            Me.lbFechaInicio = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.lbFechaFin = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.tbDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.tbExistencia = New DataDynamics.ActiveReports.TextBox()
            Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.tbTotalArticulos = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbFechaInicio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbFechaFin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbExistencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalArticulos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbDescripcion, Me.tbExistencia, Me.tbCodigo})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Shape1, Me.Label1, Me.LblFecha, Me.lblFieldArticulo, Me.lblFieldFolio, Me.Label5, Me.lblReportTitle, Me.LblSucursal, Me.lblFieldDescuento, Me.lbFechaInicio, Me.Label7, Me.lbFechaFin, Me.Label9})
            Me.GroupHeader1.Height = 1.28125!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label10, Me.tbTotalArticulos})
            Me.GroupFooter1.Height = 0.3645833!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3331693!
            Me.Shape2.Left = 0!
            Me.Shape2.LineWeight = 2!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.8971459!
            Me.Shape2.Width = 6.988188!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.9104334!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.988188!
            '
            'Label1
            '
            Me.Label1.Height = 0.1811025!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.2288385!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label1.Text = "Fecha:"
            Me.Label1.Top = 0.07381889!
            Me.Label1.Width = 0.5625!
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1811025!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 0.7288389!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFecha.Text = "LblFecha"
            Me.LblFecha.Top = 0.07381889!
            Me.LblFecha.Width = 1.0625!
            '
            'lblFieldArticulo
            '
            Me.lblFieldArticulo.Height = 0.1811025!
            Me.lblFieldArticulo.HyperLink = Nothing
            Me.lblFieldArticulo.Left = 2.332677!
            Me.lblFieldArticulo.Name = "lblFieldArticulo"
            Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldArticulo.Text = "Descripción"
            Me.lblFieldArticulo.Top = 0.9936021!
            Me.lblFieldArticulo.Width = 0.6875!
            '
            'lblFieldFolio
            '
            Me.lblFieldFolio.Height = 0.181!
            Me.lblFieldFolio.HyperLink = Nothing
            Me.lblFieldFolio.Left = 0.973425!
            Me.lblFieldFolio.Name = "lblFieldFolio"
            Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFolio.Text = "Código"
            Me.lblFieldFolio.Top = 0.9936021!
            Me.lblFieldFolio.Width = 0.4842521!
            '
            'Label5
            '
            Me.Label5.Height = 0.1811025!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.603838!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label5.Text = "Sucursal:"
            Me.Label5.Top = 0.323819!
            Me.Label5.Width = 0.5625!
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.3444882!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 2.4375!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "ddo-char-set: 1; font-size: 10pt; white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Artículos Con Movimientos"
            Me.lblReportTitle.Top = -0.0625!
            Me.lblReportTitle.Width = 2.697835!
            '
            'LblSucursal
            '
            Me.LblSucursal.Height = 0.1811025!
            Me.LblSucursal.HyperLink = Nothing
            Me.LblSucursal.Left = 3.291339!
            Me.LblSucursal.Name = "LblSucursal"
            Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblSucursal.Text = "LblSucursal"
            Me.LblSucursal.Top = 0.323819!
            Me.LblSucursal.Width = 2.260826!
            '
            'lblFieldDescuento
            '
            Me.lblFieldDescuento.Height = 0.1811025!
            Me.lblFieldDescuento.HyperLink = Nothing
            Me.lblFieldDescuento.Left = 4.84498!
            Me.lblFieldDescuento.Name = "lblFieldDescuento"
            Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldDescuento.Text = "Existencias"
            Me.lblFieldDescuento.Top = 0.9936021!
            Me.lblFieldDescuento.Width = 0.6875!
            '
            'lbFechaInicio
            '
            Me.lbFechaInicio.Height = 0.1811025!
            Me.lbFechaInicio.HyperLink = Nothing
            Me.lbFechaInicio.Left = 2.603839!
            Me.lbFechaInicio.Name = "lbFechaInicio"
            Me.lbFechaInicio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.lbFechaInicio.Text = "lbFechaInicio"
            Me.lbFechaInicio.Top = 0.573819!
            Me.lbFechaInicio.Width = 1.0625!
            '
            'Label7
            '
            Me.Label7.Height = 0.1811025!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 2.291338!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label7.Text = "Del :"
            Me.Label7.Top = 0.573819!
            Me.Label7.Width = 0.3125!
            '
            'lbFechaFin
            '
            Me.lbFechaFin.Height = 0.1811025!
            Me.lbFechaFin.HyperLink = Nothing
            Me.lbFechaFin.Left = 4.103839!
            Me.lbFechaFin.Name = "lbFechaFin"
            Me.lbFechaFin.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.lbFechaFin.Text = "lbFechaFin"
            Me.lbFechaFin.Top = 0.573819!
            Me.lbFechaFin.Width = 1.0625!
            '
            'Label9
            '
            Me.Label9.Height = 0.1811025!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.791338!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label9.Text = "Al :"
            Me.Label9.Top = 0.573819!
            Me.Label9.Width = 0.25!
            '
            'tbDescripcion
            '
            Me.tbDescripcion.Height = 0.1968504!
            Me.tbDescripcion.Left = 2.309055!
            Me.tbDescripcion.Name = "tbDescripcion"
            Me.tbDescripcion.Style = "font-size: 8.25pt"
            Me.tbDescripcion.Text = "tbDescripcion"
            Me.tbDescripcion.Top = 0!
            Me.tbDescripcion.Width = 2.320866!
            '
            'tbExistencia
            '
            Me.tbExistencia.Height = 0.1968504!
            Me.tbExistencia.Left = 4.897638!
            Me.tbExistencia.Name = "tbExistencia"
            Me.tbExistencia.OutputFormat = resources.GetString("tbExistencia.OutputFormat")
            Me.tbExistencia.Style = "text-align: right; font-size: 8.25pt"
            Me.tbExistencia.Text = "tbExistencia"
            Me.tbExistencia.Top = 0!
            Me.tbExistencia.Width = 0.383366!
            '
            'tbCodigo
            '
            Me.tbCodigo.Height = 0.1968504!
            Me.tbCodigo.Left = 0.973425!
            Me.tbCodigo.Name = "tbCodigo"
            Me.tbCodigo.Style = "font-size: 8.25pt"
            Me.tbCodigo.Text = "tbCodigo"
            Me.tbCodigo.Top = 0!
            Me.tbCodigo.Width = 1.054626!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.3331693!
            Me.Shape3.Left = 0.01041667!
            Me.Shape3.LineWeight = 2!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 6.988188!
            '
            'Label10
            '
            Me.Label10.Height = 0.181!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.035925!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label10.Text = "Total Artículos :"
            Me.Label10.Top = 0.0625!
            Me.Label10.Width = 0.9138778!
            '
            'tbTotalArticulos
            '
            Me.tbTotalArticulos.Height = 0.1968504!
            Me.tbTotalArticulos.Left = 2.118602!
            Me.tbTotalArticulos.Name = "tbTotalArticulos"
            Me.tbTotalArticulos.OutputFormat = resources.GetString("tbTotalArticulos.OutputFormat")
            Me.tbTotalArticulos.Style = "text-align: right; font-size: 8.25pt"
            Me.tbTotalArticulos.Top = 0.0625!
            Me.tbTotalArticulos.Width = 0.383366!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.5902778!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.104167!
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
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbFechaInicio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbFechaFin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbExistencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalArticulos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Public Sub New(ByVal strSucursal As String, ByVal datFechaInicio As Date, ByVal datFechaFin As Date)

        MyBase.New()
        InitializeComponent()


        'Header :

        LblSucursal.Text = strSucursal

        LblFecha.Text = Format(Date.Now, "dd-MMM-yyyy")

        lbFechaInicio.Text = Format(datFechaInicio, "dd-MMM-yyyy")

        lbFechaFin.Text = Format(datFechaFin, "dd-MMM-yyyy")


        'Detail :

        Dim oDG As New TodosArticulosDataGateway(oAppContext)

        Dim dtDetalle As DataTable = oDG.TodosArticulosDetalleSel(datFechaInicio, datFechaFin)

        Me.DataSource = dtDetalle

        tbCodigo.DataField = "Codigo"

        tbDescripcion.DataField = "Descripcion"

        'tbColor.DataField = "Color"

        tbExistencia.DataField = "Existencia"

        tbTotalArticulos.Text = dtDetalle.Rows.Count

    End Sub

End Class
