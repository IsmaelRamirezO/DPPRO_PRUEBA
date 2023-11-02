Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptTomadeInventario

    Inherits ActiveReport

    Public Sub New(ByVal oTomaInventarioInfo As TomadeInventarioInfo, _
                    ByVal strSucursalDes As String, _
                    ByVal strAdministrativoDes As String, _
                    ByVal strResponsableDes As String)

        MyBase.New()

        InitializeReport()

        With oTomaInventarioInfo

            ebSucursal.Text = "Sucursal: " & strSucursalDes
            ebFolio.Text = ":" & .Folio
            ebAdministrativo.Text = ":" & .Administrativo & " " & strAdministrativoDes
            ebResponsable.Text = ":" & .Responsable & " " & strResponsableDes
            ebAuditoria.Text = .Semana
            ebFecha.Text = Format(.FechaAuditoria, "dd/MM/yyyy")
            ebTotalCodigos.Text = .TotalCodigos
            ResName.Text = strResponsableDes
            AdmName.Text = strAdministrativoDes

            ebLeyenda.Text = _
                    "LOS CODIGOS ARRIBA MENCIONADOS FUERON CONTADOS POR EL ADMINISTRATIVO DE LA PLAZA: " & strAdministrativoDes _
                    & " EN PRESENCIA DEL RESPONSABLE DE LA SUCURSAL: " & strResponsableDes & ", OBTENIENDO LOS RESULTADOS DESCRITOS" _
                    & " EN ESTE FORMATO, LOS CUALES EL RESPONSABLE DE ESTA SUCURSAL CERTIFICA QUE ESTOS SON CORRECTOS " _
                    & "Y QUE ESTA TOTALMENTE DE ACUERDO CON LOS MISMOS."

            Me.DataSource = .Detalle
            Me.DataMember = "Detalle"

            ebCodigo.DataField = "Codigo"
            ebTalla.DataField = "Talla"
            ebSistema.DataField = "Sistema"
            ebFisico.DataField = "Fisico"
            ebDiferencia.DataField = "Diferencia"
            ebTipo.DataField = "Tipo"
            ebMovimiento.DataField = "Movimientos"
            ebFolioDetalle.DataField = "FolioDetalle"
            ebObservaciones.DataField = "Observaciones"

        End With

        With Me.PageSettings.Margins
            .Top = 0.5
            .Left = 0.2
        End With


        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private lblFolio As Label = Nothing
	Private lblAdministrativo As Label = Nothing
	Private lblResponsable As Label = Nothing
	Private lblAuditoria As Label = Nothing
	Private ebFolio As Label = Nothing
	Private ebAdministrativo As Label = Nothing
	Private ebResponsable As Label = Nothing
	Private ebAuditoria As Label = Nothing
	Private lblFecha As Label = Nothing
	Private ebFecha As Label = Nothing
	Private ebSucursal As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private ebCodigo As TextBox = Nothing
	Private ebTalla As TextBox = Nothing
	Private ebSistema As TextBox = Nothing
	Private ebFisico As TextBox = Nothing
	Private ebDiferencia As TextBox = Nothing
	Private ebTipo As TextBox = Nothing
	Private ebMovimiento As TextBox = Nothing
	Private ebFolioDetalle As TextBox = Nothing
	Private ebObservaciones As TextBox = Nothing
	Private ResName As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private Label11 As Label = Nothing
	Private ebTotalCodigos As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private ebLeyenda As TextBox = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private AdmName As Label = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.ApplicationUnits.TomadeInventarioAU.rptTomadeInventario.rpx"& _ 
"")
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.GroupHeader1 = CType(Me.Sections("GroupHeader1"),DataDynamics.ActiveReports.GroupHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.GroupFooter1 = CType(Me.Sections("GroupFooter1"),DataDynamics.ActiveReports.GroupFooter)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.Shape1 = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Shape)
		Me.Label1 = CType(Me.PageHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.lblFolio = CType(Me.PageHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.lblAdministrativo = CType(Me.PageHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.lblResponsable = CType(Me.PageHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.lblAuditoria = CType(Me.PageHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.ebFolio = CType(Me.PageHeader.Controls(6),DataDynamics.ActiveReports.Label)
		Me.ebAdministrativo = CType(Me.PageHeader.Controls(7),DataDynamics.ActiveReports.Label)
		Me.ebResponsable = CType(Me.PageHeader.Controls(8),DataDynamics.ActiveReports.Label)
		Me.ebAuditoria = CType(Me.PageHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.lblFecha = CType(Me.PageHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.ebFecha = CType(Me.PageHeader.Controls(11),DataDynamics.ActiveReports.Label)
		Me.ebSucursal = CType(Me.PageHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.Label2 = CType(Me.PageHeader.Controls(13),DataDynamics.ActiveReports.Label)
		Me.Label3 = CType(Me.PageHeader.Controls(14),DataDynamics.ActiveReports.Label)
		Me.Label4 = CType(Me.PageHeader.Controls(15),DataDynamics.ActiveReports.Label)
		Me.Label5 = CType(Me.PageHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.Label6 = CType(Me.PageHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.Label7 = CType(Me.PageHeader.Controls(18),DataDynamics.ActiveReports.Label)
		Me.Label8 = CType(Me.PageHeader.Controls(19),DataDynamics.ActiveReports.Label)
		Me.Label9 = CType(Me.PageHeader.Controls(20),DataDynamics.ActiveReports.Label)
		Me.Label10 = CType(Me.PageHeader.Controls(21),DataDynamics.ActiveReports.Label)
		Me.Line1 = CType(Me.PageHeader.Controls(22),DataDynamics.ActiveReports.Line)
		Me.Line2 = CType(Me.PageHeader.Controls(23),DataDynamics.ActiveReports.Line)
		Me.Line3 = CType(Me.PageHeader.Controls(24),DataDynamics.ActiveReports.Line)
		Me.Line4 = CType(Me.PageHeader.Controls(25),DataDynamics.ActiveReports.Line)
		Me.Line5 = CType(Me.PageHeader.Controls(26),DataDynamics.ActiveReports.Line)
		Me.Line6 = CType(Me.PageHeader.Controls(27),DataDynamics.ActiveReports.Line)
		Me.Line7 = CType(Me.PageHeader.Controls(28),DataDynamics.ActiveReports.Line)
		Me.Line8 = CType(Me.PageHeader.Controls(29),DataDynamics.ActiveReports.Line)
		Me.Line9 = CType(Me.PageHeader.Controls(30),DataDynamics.ActiveReports.Line)
		Me.ebCodigo = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.ebTalla = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.ebSistema = CType(Me.Detail.Controls(2),DataDynamics.ActiveReports.TextBox)
		Me.ebFisico = CType(Me.Detail.Controls(3),DataDynamics.ActiveReports.TextBox)
		Me.ebDiferencia = CType(Me.Detail.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.ebTipo = CType(Me.Detail.Controls(5),DataDynamics.ActiveReports.TextBox)
		Me.ebMovimiento = CType(Me.Detail.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.ebFolioDetalle = CType(Me.Detail.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.ebObservaciones = CType(Me.Detail.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.ResName = CType(Me.GroupFooter1.Controls(0),DataDynamics.ActiveReports.Label)
		Me.Shape2 = CType(Me.GroupFooter1.Controls(1),DataDynamics.ActiveReports.Shape)
		Me.Label11 = CType(Me.GroupFooter1.Controls(2),DataDynamics.ActiveReports.Label)
		Me.ebTotalCodigos = CType(Me.GroupFooter1.Controls(3),DataDynamics.ActiveReports.Label)
		Me.Label12 = CType(Me.GroupFooter1.Controls(4),DataDynamics.ActiveReports.Label)
		Me.Label13 = CType(Me.GroupFooter1.Controls(5),DataDynamics.ActiveReports.Label)
		Me.ebLeyenda = CType(Me.GroupFooter1.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.Line10 = CType(Me.GroupFooter1.Controls(7),DataDynamics.ActiveReports.Line)
		Me.Line11 = CType(Me.GroupFooter1.Controls(8),DataDynamics.ActiveReports.Line)
		Me.AdmName = CType(Me.GroupFooter1.Controls(9),DataDynamics.ActiveReports.Label)
	End Sub

#End Region

End Class
