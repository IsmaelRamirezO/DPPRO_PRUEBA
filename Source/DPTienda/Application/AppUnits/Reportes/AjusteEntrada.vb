Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AjusteEntrada
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents grpFolio As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtTitulo As TextBox = Nothing
	Private TxtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtDesde As TextBox = Nothing
	Private txtHasta As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtSucursalNombre As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Line2 As Line = Nothing
	Private txtPag As TextBox = Nothing
	Private Codigo As TextBox = Nothing
	Private Fecha As TextBox = Nothing
	Private Folio As TextBox = Nothing
	Private Color As TextBox = Nothing
	Private Total As TextBox = Nothing
	Private Talla1 As TextBox = Nothing
	Private Talla2 As TextBox = Nothing
	Private Talla3 As TextBox = Nothing
	Private Talla4 As TextBox = Nothing
	Private Talla5 As TextBox = Nothing
	Private Talla6 As TextBox = Nothing
	Private Talla7 As TextBox = Nothing
	Private T8 As TextBox = Nothing
	Private T9 As TextBox = Nothing
	Private Talla10 As TextBox = Nothing
	Private Descripcion As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private C1 As TextBox = Nothing
	Private C2 As TextBox = Nothing
	Private C3 As TextBox = Nothing
	Private C4 As TextBox = Nothing
	Private C5 As TextBox = Nothing
	Private C6 As TextBox = Nothing
	Private C7 As TextBox = Nothing
	Private C8 As TextBox = Nothing
	Private C9 As TextBox = Nothing
	Private C10 As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private Line3 As Line = Nothing
	Private txtTotImporte As TextBox = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "Reportes.AjusteEntrada.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.grpFolio = CType(Me.Sections("grpFolio"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.txtTitulo = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.TxtFecha = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Label2 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.txtDesde = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.txtHasta = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Label4 = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.txtSucursal = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.txtSucursalNombre = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Label5 = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Line)
		Me.Label6 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Line2 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Line)
		Me.txtPag = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.Codigo = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Fecha = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Folio = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.Color = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.Total = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.Talla1 = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.Talla2 = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Talla3 = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.Talla4 = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.Talla5 = CType(Me.Detail.Controls(9),DataDynamics.ActiveReports.TextBox)
		Me.Talla6 = CType(Me.Detail.Controls(10),DataDynamics.ActiveReports.TextBox)
		Me.Talla7 = CType(Me.Detail.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.T8 = CType(Me.Detail.Controls(12),DataDynamics.ActiveReports.TextBox)
		Me.T9 = CType(Me.Detail.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.Talla10 = CType(Me.Detail.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.Descripcion = CType(Me.Detail.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.Label1 = CType(Me.Detail.Controls(16),DataDynamics.ActiveReports.Label)
		Me.C1 = CType(Me.Detail.Controls(17),DataDynamics.ActiveReports.TextBox)
		Me.C2 = CType(Me.Detail.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.C3 = CType(Me.Detail.Controls(19),DataDynamics.ActiveReports.TextBox)
		Me.C4 = CType(Me.Detail.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.C5 = CType(Me.Detail.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.C6 = CType(Me.Detail.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.C7 = CType(Me.Detail.Controls(23),DataDynamics.ActiveReports.TextBox)
		Me.C8 = CType(Me.Detail.Controls(24),DataDynamics.ActiveReports.TextBox)
		Me.C9 = CType(Me.Detail.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.C10 = CType(Me.Detail.Controls(26),DataDynamics.ActiveReports.TextBox)
		Me.TextBox1 = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.txtObservaciones = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.Line3 = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.Line)
		Me.txtTotImporte = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.TextBox)
	End Sub

	#End Region

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub AjusteEntrada_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PageStart
        txtPag.Text = Str$(Val(txtPag.Text) + 1)
    End Sub
    Public Property Almacen() As String
        Get
            Almacen = txtSucursal.Text
        End Get
        Set(ByVal Value As String)
            txtSucursal.Text = Value
        End Set
    End Property
    Public Property NombreAlmacen() As String
        Get
            NombreAlmacen = txtSucursalNombre.Text
        End Get
        Set(ByVal Value As String)
            txtSucursalNombre.Text = Value
        End Set
    End Property
    Public Property Desde() As Date
        Get
            Desde = txtDesde.Value
        End Get
        Set(ByVal Value As Date)
            txtDesde.Value = Value
        End Set
    End Property
    Public Property Hasta() As Date
        Get
            Hasta = txtHasta.Value
        End Get
        Set(ByVal Value As Date)
            txtHasta.Value = Value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Titulo = txtTitulo.Text
        End Get
        Set(ByVal Value As String)
            txtTitulo.Text = Value
        End Set
    End Property
End Class
