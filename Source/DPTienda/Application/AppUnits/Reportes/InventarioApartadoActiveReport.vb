Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class InventarioApartadoActiveReport
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
	Private Detail As DataDynamics.ActiveReports.Detail
        Private PageHeader As DataDynamics.ActiveReports.PageHeader
        Private PageFooter As DataDynamics.ActiveReports.PageFooter

		Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioApartadoActiveReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 2!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0.25!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
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
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub
	#End Region
End Class
