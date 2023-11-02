Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU

Public Class ReporteAvisosFactura

    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oAvisosFacturaMrg As AvisosFacturaManager
    Dim dsAvisoFactura As New DataSet

    Public Sub New(ByVal ModuloID As String, ByVal Disponible As Boolean)

        MyBase.New()

        InitializeComponent()

        InicializaObjetos()

        dsAvisoFactura = oAvisosFacturaMrg.LoadEnabled(ModuloID, Disponible)

        Me.DataSource = dsAvisoFactura
        Me.DataMember = "AvisosFactura"

        Me.tbAvisoFactura.DataField = "Nota"


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private tbAvisoFactura As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteAvisosFactura))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.tbAvisoFactura = New DataDynamics.ActiveReports.TextBox()
            CType(Me.tbAvisoFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbAvisoFactura})
            Me.Detail.Height = 0.1451389!
            Me.Detail.Name = "Detail"
            '
            'tbAvisoFactura
            '
            Me.tbAvisoFactura.CanShrink = true
            Me.tbAvisoFactura.Height = 0.125!
            Me.tbAvisoFactura.Left = 0!
            Me.tbAvisoFactura.Name = "tbAvisoFactura"
            Me.tbAvisoFactura.Style = "ddo-char-set: 1; text-align: justify; font-size: 6pt; vertical-align: middle"
            Me.tbAvisoFactura.Top = 0!
            Me.tbAvisoFactura.Width = 4.1875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 4.208333!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.tbAvisoFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Private Sub InicializaObjetos()

        oAvisosFacturaMrg = New AvisosFacturaManager(oAppContext)

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

    End Sub

End Class
