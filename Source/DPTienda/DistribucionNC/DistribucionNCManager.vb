
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU


Public Class DistribucionNCManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region



#Region "Properties"

    Private oApplicationContext As ApplicationContext


    Public Property ApplicationContext() As ApplicationContext

        Get

            Return oApplicationContext

        End Get


        Set(ByVal Value As ApplicationContext)

            oApplicationContext = Value

        End Set

    End Property

#End Region



#Region "Métodos"

    Public Function LoadAnticipoCliente(ByVal pNotaCredito As NotaCredito) As DistribucionNC

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        'Return oDistribucionNCDG.NotaCreditoAnticipoClienteSelect(pNotaCredito)

        oDistribucionNCDG = Nothing

    End Function

    Public Function SelectNombreTiendaBanco(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.SelectNombreTienda(strTipoPago, strCentro)

        oDistribucionNCDG = Nothing

    End Function


    Public Function SelectCentro() As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.SeleccionaCentro

        oDistribucionNCDG = Nothing

    End Function

    Public Function DivisionSel() As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.DivisionSel

        oDistribucionNCDG = Nothing

    End Function

    Public Function GetDpValeIDDP(ByVal FolioFactura As Integer) As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.GetDpValeIDDP(FolioFactura)

        oDistribucionNCDG = Nothing

    End Function

    Public Function GetDpVale(ByVal FolioFactura As Integer) As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.GetDpVale(FolioFactura)

        oDistribucionNCDG = Nothing

    End Function

    Public Function GetFacturaByNCID(ByVal ID As Integer) As String

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.GetFacturaByNCID(ID)

        oDistribucionNCDG = Nothing

    End Function

    Public Sub ActualizaDOCNUMFB01xFolioAbono(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        oDistribucionNCDG.ActualizaDOCNUMFB01xFolioAbono(ApartadoID, DOCNUMFB01)

        oDistribucionNCDG = Nothing

    End Sub

    Public Sub InsertaValeCajaDPVL(ByVal ValeCajaID As Integer, ByVal DocFI As String)

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        oDistribucionNCDG.InsertaValeCajaDPVL(ValeCajaID, DocFI)

        oDistribucionNCDG = Nothing

    End Sub


    'Public Function LoadAnticipoCliente(ByVal intAnticipoClienteID As Integer) As DistribucionNC

    '    Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

    '    Return oDistribucionNCDG.NotaCreditoAnticipoClienteSelect(intAnticipoClienteID)

    '    oDistribucionNCDG = Nothing

    'End Function



    Public Function LoadAnticipoCliente(ByVal intAnticipoID As Integer, ByVal strModulo As String) As DistribucionNC

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.ContratoAnticipoClienteSelect(intAnticipoID, strModulo)

        oDistribucionNCDG = Nothing

    End Function

    Public Function LoadAnticipoCliente(ByVal FolioRef As Integer, ByVal CodCaja As String, ByVal strModulo As String) As DistribucionNC

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        Return oDistribucionNCDG.ContratoAnticipoClienteSelectByRef(FolioRef, CodCaja, strModulo)

        oDistribucionNCDG = Nothing

    End Function

    Public Sub CapturarNoCancelacion(ByVal dsNotaCreditoDetalle As DataSet)

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        oDistribucionNCDG.NotaCreditoAnticipoClienteNoCancelacionUpd(dsNotaCreditoDetalle)

        oDistribucionNCDG = Nothing

    End Sub



    Public Sub ContratoAnticipoClienteNoCancelacionUpd(ByVal dsNotaCreditoDetalle As DataSet)

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        oDistribucionNCDG.ContratoAnticipoClienteNoCancelacionUpd(dsNotaCreditoDetalle)

        oDistribucionNCDG = Nothing

    End Sub



    Public Sub ContratoMotivoCancelacionUpd(ByVal intAnticipoID As Integer, ByVal strMotivoCancelacion As String)

        Dim oDistribucionNCDG As New DistribucionNCDataGateway(Me)

        oDistribucionNCDG.ContratoMotivoCancelacionUpd(intAnticipoID, strMotivoCancelacion)

        oDistribucionNCDG = Nothing

    End Sub


#End Region


End Class
