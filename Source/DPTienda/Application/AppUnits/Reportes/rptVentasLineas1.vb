Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AnalisDeVentas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class rptVentasLineas1
    Inherits ActiveReport

#Region "Variables"

    Public dsVentas As DataSet

#End Region

    Public Sub New(ByVal TipoVenta As String, ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime)
        MyBase.New()
        InitializeReport()

        txtFechaDe.Text = Format(FechaDe, "dd-MM-yyy")
        txtFechaA.Text = Format(FechaHasta, "dd-MM-yyy")
        txtFechaReporte.Text = Format(Now.Date, "dd-MM-yyy")

        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        oAlmacen = oCatalogoAlmacenMgr.Load(oAppContext.ApplicationConfiguration.Almacen)

        txtSucursal.Text = oAlmacen.ID & Space(1) & oAlmacen.Descripcion

        Dim oAnalisisVentasMgr As New AnalisisDeVentasMgr(oAppContext)

        Me.DataSource = oAnalisisVentasMgr.GenerarAnalisisVentasLineas(TipoVenta, FechaDe, FechaHasta, "Codigo")
        Me.Run()


    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Shape1 As Shape = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private txtFechaReporte As TextBox = Nothing
    Private txtFechaDe As TextBox = Nothing
    Private txtFechaA As TextBox = Nothing
    Private Label4 As Label = Nothing
    Private txtSucursal As TextBox = Nothing
    Private Label14 As Label = Nothing
    Private Shape6 As Shape = Nothing
    Private Label16 As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label18 As Label = Nothing
    Private Label19 As Label = Nothing
    Private Label20 As Label = Nothing
    Private Label21 As Label = Nothing
    Private Label22 As Label = Nothing
    Private Label23 As Label = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private TextBox5 As TextBox = Nothing
    Private TextBox6 As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox8 As TextBox = Nothing
    Private TextBox9 As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private Line6 As Line = Nothing
    Private Line7 As Line = Nothing
    Private Shape4 As Shape = Nothing
    Private TextBox1 As TextBox = Nothing
    Private txtSumINeto As TextBox = Nothing
    Private txtSumPzasNC As TextBox = Nothing
    Private txtSumINC As TextBox = Nothing
    Private txtSumITotal As TextBox = Nothing
    Private Line3 As Line = Nothing
    Public Sub InitializeReport()
        Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.rptVentasLineas.rpx")
        Me.ReportHeader = CType(Me.Sections("ReportHeader"), DataDynamics.ActiveReports.ReportHeader)
        Me.PageHeader = CType(Me.Sections("PageHeader"), DataDynamics.ActiveReports.PageHeader)
        Me.Detail = CType(Me.Sections("Detail"), DataDynamics.ActiveReports.Detail)
        Me.PageFooter = CType(Me.Sections("PageFooter"), DataDynamics.ActiveReports.PageFooter)
        Me.ReportFooter = CType(Me.Sections("ReportFooter"), DataDynamics.ActiveReports.ReportFooter)
        Me.Shape1 = CType(Me.ReportHeader.Controls(0), DataDynamics.ActiveReports.Shape)
        Me.Label1 = CType(Me.ReportHeader.Controls(1), DataDynamics.ActiveReports.Label)
        Me.Label2 = CType(Me.ReportHeader.Controls(2), DataDynamics.ActiveReports.Label)
        Me.Label3 = CType(Me.ReportHeader.Controls(3), DataDynamics.ActiveReports.Label)
        Me.txtFechaReporte = CType(Me.ReportHeader.Controls(4), DataDynamics.ActiveReports.TextBox)
        Me.txtFechaDe = CType(Me.ReportHeader.Controls(5), DataDynamics.ActiveReports.TextBox)
        Me.txtFechaA = CType(Me.ReportHeader.Controls(6), DataDynamics.ActiveReports.TextBox)
        Me.Label4 = CType(Me.ReportHeader.Controls(7), DataDynamics.ActiveReports.Label)
        Me.txtSucursal = CType(Me.ReportHeader.Controls(8), DataDynamics.ActiveReports.TextBox)
        Me.Label14 = CType(Me.ReportHeader.Controls(9), DataDynamics.ActiveReports.Label)
        Me.Shape6 = CType(Me.PageHeader.Controls(0), DataDynamics.ActiveReports.Shape)
        Me.Label16 = CType(Me.PageHeader.Controls(1), DataDynamics.ActiveReports.Label)
        Me.Label17 = CType(Me.PageHeader.Controls(2), DataDynamics.ActiveReports.Label)
        Me.Label18 = CType(Me.PageHeader.Controls(3), DataDynamics.ActiveReports.Label)
        Me.Label19 = CType(Me.PageHeader.Controls(4), DataDynamics.ActiveReports.Label)
        Me.Label20 = CType(Me.PageHeader.Controls(5), DataDynamics.ActiveReports.Label)
        Me.Label21 = CType(Me.PageHeader.Controls(6), DataDynamics.ActiveReports.Label)
        Me.Label22 = CType(Me.PageHeader.Controls(7), DataDynamics.ActiveReports.Label)
        Me.Label23 = CType(Me.PageHeader.Controls(8), DataDynamics.ActiveReports.Label)
        Me.TextBox3 = CType(Me.Detail.Controls(0), DataDynamics.ActiveReports.TextBox)
        Me.TextBox4 = CType(Me.Detail.Controls(1), DataDynamics.ActiveReports.TextBox)
        Me.TextBox5 = CType(Me.Detail.Controls(2), DataDynamics.ActiveReports.TextBox)
        Me.TextBox6 = CType(Me.Detail.Controls(3), DataDynamics.ActiveReports.TextBox)
        Me.TextBox7 = CType(Me.Detail.Controls(4), DataDynamics.ActiveReports.TextBox)
        Me.TextBox8 = CType(Me.Detail.Controls(5), DataDynamics.ActiveReports.TextBox)
        Me.TextBox9 = CType(Me.Detail.Controls(6), DataDynamics.ActiveReports.TextBox)
        Me.TextBox10 = CType(Me.Detail.Controls(7), DataDynamics.ActiveReports.TextBox)
        Me.Line6 = CType(Me.Detail.Controls(8), DataDynamics.ActiveReports.Line)
        Me.Line7 = CType(Me.Detail.Controls(9), DataDynamics.ActiveReports.Line)
        Me.Shape4 = CType(Me.ReportFooter.Controls(0), DataDynamics.ActiveReports.Shape)
        Me.TextBox1 = CType(Me.ReportFooter.Controls(1), DataDynamics.ActiveReports.TextBox)
        Me.txtSumINeto = CType(Me.ReportFooter.Controls(2), DataDynamics.ActiveReports.TextBox)
        Me.txtSumPzasNC = CType(Me.ReportFooter.Controls(3), DataDynamics.ActiveReports.TextBox)
        Me.txtSumINC = CType(Me.ReportFooter.Controls(4), DataDynamics.ActiveReports.TextBox)
        Me.txtSumITotal = CType(Me.ReportFooter.Controls(5), DataDynamics.ActiveReports.TextBox)
        Me.Line3 = CType(Me.ReportFooter.Controls(6), DataDynamics.ActiveReports.Line)
    End Sub

#End Region

End Class
