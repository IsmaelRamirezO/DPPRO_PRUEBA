Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AcrRptDifSAPyDP
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private TxtBxCodArt As TextBox = Nothing
	Private TxtBxTalla As TextBox = Nothing
	Private TxtBxDef As TextBox = Nothing
	Private TxtBxDefAparDP As TextBox = Nothing
	Private TxtBxApart As TextBox = Nothing
	Private TxtBxSAP As TextBox = Nothing
	Private TxtBxTotal As TextBox = Nothing
	Private Label8 As Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU.AcrRptDifSAPyDP.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Shape1 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Shape)
		Me.Label1 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Line)
		Me.TxtBxCodArt = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxTalla = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxDef = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxDefAparDP = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxApart = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxSAP = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxTotal = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label8 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.Label)
	End Sub

	#End Region

   
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.TxtBxDefAparDP.Text = CStr(Math.Abs((CInt(TxtBxDef.Text) + CInt(Me.TxtBxApart.Text)) - CInt(Me.TxtBxSAP.Text)))
    End Sub
End Class
