Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes


Public Class rptAjusteGeneral
    Inherits ActiveReport

    Public Sub New(ByVal oAjusteInfo As AjusteGeneralInfo)

        MyBase.New()

        InitializeReport()

        lblPagina.Text = "Pag.:" & Me.PageNumber
        lblFecha.Text = Format(oAjusteInfo.FechaAjuste, "dd/MM/yyyy")
        lblAjuste.Text = "Ajuste No.:" & oAjusteInfo.FolioAjuste
        lblSucursal.Text = "Sucursal : " & GetAlmacen()
        lblHecho.Text = "Elaboró: " & oAjusteInfo.Usuario
        lblTCantidadE.Text = oAjusteInfo.TotalCodigos
        lblTCantidadS.Text = oAjusteInfo.TotalCodigos
        lblTCostoE.Text = Format(oAjusteInfo.AE_CostoTotal, "###,##0.00")
        lblTCostoS.Text = Format(oAjusteInfo.AS_CostoTotal, "###,##0.00")
        txtObservaciones.Text = oAjusteInfo.Observaciones

        Me.DataSource = oAjusteInfo.Detalle
        Me.DataMember = "Detalle"

        Me.txtCodigoE.DataField = "AE_Codigo"
        Me.txtTallaE.DataField = "AE_Talla"
        Me.txtCantidadE.DataField = "AE_Cantidad"
        Me.txtCostoE.DataField = "AE_Costo"
        Me.txtCodigoS.DataField = "AS_Codigo"
        Me.txtTallaS.DataField = "AS_Talla"
        Me.txtCantidadS.DataField = "AS_Cantidad"
        Me.txtCostoS.DataField = "AS_Costo"

        Me.Run()

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        oAlmacen = oAlmacenMgr.Create

        oAlmacenMgr.LoadInto(oAppContext.ApplicationConfiguration.Almacen, oAlmacen)

        Return oAppContext.ApplicationConfiguration.Almacen & " " & oAlmacen.Descripcion

    End Function

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label9 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label1 As Label = Nothing
	Private lblPagina As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblAjuste As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblHecho As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Shape5 As Shape = Nothing
	Private Shape1 As Shape = Nothing
	Private txtCodigoE As TextBox = Nothing
	Private txtTallaE As TextBox = Nothing
	Private txtCantidadE As TextBox = Nothing
	Private txtCostoE As TextBox = Nothing
	Private txtCodigoS As TextBox = Nothing
	Private txtTallaS As TextBox = Nothing
	Private txtCantidadS As TextBox = Nothing
	Private txtCostoS As TextBox = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private Label16 As Label = Nothing
	Private lblTCantidadE As Label = Nothing
	Private lblTCostoE As Label = Nothing
	Private lblTCantidadS As Label = Nothing
	Private lblTCostoS As Label = Nothing
	Private Line1 As Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.rptAjusteGeneral.rpx")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Label9 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label1 = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.lblPagina = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.lblFecha = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.lblAjuste = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.lblSucursal = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.lblHecho = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.Label11 = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label14 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Shape5 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Shape)
		Me.Shape1 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Shape)
		Me.txtCodigoE = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.txtTallaE = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.txtCantidadE = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.txtCostoE = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.txtCodigoS = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.txtTallaS = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.txtCantidadS = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.txtCostoS = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.txtObservaciones = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.Label16 = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.Label)
		Me.lblTCantidadE = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.Label)
		Me.lblTCostoE = CType(Me.PageFooter.Controls(3),DataDynamics.ActiveReports.Label)
		Me.lblTCantidadS = CType(Me.PageFooter.Controls(4),DataDynamics.ActiveReports.Label)
		Me.lblTCostoS = CType(Me.PageFooter.Controls(5),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageFooter.Controls(6),DataDynamics.ActiveReports.Line)
	End Sub

#End Region

End Class
