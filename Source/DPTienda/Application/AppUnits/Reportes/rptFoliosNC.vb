Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja

Public Class rptFoliosNC
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Fecha As Date)
        MyBase.New()
        InitializeComponent()

        Dim dtFolios As New DataTable
        Dim oCierreCajaMgr As New CierreCajaManager(oAppContext)

        dtFolios = oCierreCajaMgr.NotasCreditoFoliosGETREP(Fecha).Tables(0).Copy

        Me.DataSource = dtFolios
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private txtFolio As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFoliosNC))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FiDocument"
            Me.txtFolio.Height = 0.1574803!
            Me.txtFolio.Left = 0.01476383!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Top = 0.01870078!
            Me.txtFolio.Width = 0.867618!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 0.90625!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
