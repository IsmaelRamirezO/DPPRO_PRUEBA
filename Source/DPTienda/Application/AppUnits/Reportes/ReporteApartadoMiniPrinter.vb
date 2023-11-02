Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class ReporteApartadoMiniPrinter
Inherits ActiveReport

    Public Sub New(ByVal oForm As frmContratos, ByVal oFormClientes As ClienteAlterno, ByVal strDocFi As String)
        MyBase.New()
        InitializeReport()
        With oForm
            tbFolio.Text = .ebFolio.Text
            tbNombre.Text = oFormClientes.Nombre & " " & oFormClientes.ApellidoMaterno & " " & oFormClientes.ApellidoPaterno
            tbDomicilio.Text = oFormClientes.Direccion
            tbCiudad.Text = oFormClientes.Ciudad
            tbRFC.Text = oFormClientes.RFC
            tbTelefono.Text = oFormClientes.Telefono
            Me.txtFecha.Text = .ebFecha.Text
            Me.TxtBxDocFi.Text = "FI: " & strDocFi
            'tbPlayer.Text = .ebNumPlayer.Text
            'tbSubTotal.Text = .ebSubTotal.Text
            'tbIVA.Text = .ebIVA.Text
            tbImporteTotal.Text = .ebImporteTotal.Text
            Me.ebCodCaja.Text += " " & oAppContext.ApplicationConfiguration.NoCaja
        End With
    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbNombre As TextBox = Nothing
	Private tbDomicilio As TextBox = Nothing
	Private tbCiudad As TextBox = Nothing
	Private tbRFC As TextBox = Nothing
	Private tbTelefono As TextBox = Nothing
	Private ebCodCaja As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private TxtBxDocFi As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private tbImporteTotal As TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.ReporteApartadoMiniPrinter.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.tbFolio = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.tbNombre = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.tbDomicilio = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.tbCiudad = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.tbRFC = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.tbTelefono = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.ebCodCaja = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.txtFecha = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.TxtBxDocFi = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.TextBox7 = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TextBox8 = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.TextBox10 = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.TextBox11 = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.TextBox12 = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.TextBox13 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.tbImporteTotal = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region
End Class
