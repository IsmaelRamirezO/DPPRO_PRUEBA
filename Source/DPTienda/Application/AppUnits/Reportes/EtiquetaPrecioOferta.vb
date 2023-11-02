Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class EtiquetaPrecioOferta
Inherits DataDynamics.ActiveReports.ActiveReport
	
	#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private tbPrecio As TextBox = Nothing
	Private tbPrecioOferta As TextBox = Nothing
	Private tbCodArticulo As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtiquetaPrecioOferta))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.tbPrecio = New DataDynamics.ActiveReports.TextBox()
            Me.tbPrecioOferta = New DataDynamics.ActiveReports.TextBox()
            Me.tbCodArticulo = New DataDynamics.ActiveReports.TextBox()
            CType(Me.tbPrecio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbPrecio, Me.tbPrecioOferta, Me.tbCodArticulo})
            Me.Detail.Height = 2.625!
            Me.Detail.Name = "Detail"
            '
            'tbPrecio
            '
            Me.tbPrecio.Height = 0.1875!
            Me.tbPrecio.Left = 0.1875!
            Me.tbPrecio.Name = "tbPrecio"
            Me.tbPrecio.OutputFormat = resources.GetString("tbPrecio.OutputFormat")
            Me.tbPrecio.Style = "ddo-char-set: 1; font-weight: normal; font-size: 11.25pt"
            Me.tbPrecio.Text = "tbPrecio"
            Me.tbPrecio.Top = 0!
            Me.tbPrecio.Width = 0.875!
            '
            'tbPrecioOferta
            '
            Me.tbPrecioOferta.Height = 0.1875!
            Me.tbPrecioOferta.Left = 0.125!
            Me.tbPrecioOferta.Name = "tbPrecioOferta"
            Me.tbPrecioOferta.OutputFormat = resources.GetString("tbPrecioOferta.OutputFormat")
            Me.tbPrecioOferta.Style = "font-weight: normal; font-size: 11.25pt"
            Me.tbPrecioOferta.Text = "tbPrecioOferta"
            Me.tbPrecioOferta.Top = 1.125!
            Me.tbPrecioOferta.Width = 0.8125!
            '
            'tbCodArticulo
            '
            Me.tbCodArticulo.Height = 0.1875!
            Me.tbCodArticulo.Left = 0.0625!
            Me.tbCodArticulo.Name = "tbCodArticulo"
            Me.tbCodArticulo.Style = "font-weight: normal; font-size: 9pt"
            Me.tbCodArticulo.Text = "tbCodArticulo"
            Me.tbCodArticulo.Top = 1.9375!
            Me.tbCodArticulo.Width = 1.1875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Left = 0.2!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 10!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.020833!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.tbPrecio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



#Region "Constructores"

    Public Sub New(ByVal dt As DataTable)

        MyBase.New()
        InitializeComponent()

        dtDetalle = dt

        Sm_MostrarInformacion()

    End Sub

#End Region



#Region "Variables Miembros"

    Private dtDetalle As DataTable

#End Region



#Region "Métodos Miembros"

    Private Sub Sm_MostrarInformacion()

        Me.DataSource = dtDetalle

        Me.tbPrecio.DataField = "Precio"
        Me.tbPrecioOferta.DataField = "PrecioOferta"
        Me.tbCodArticulo.DataField = "CodArticulo"

    End Sub

#End Region

End Class
