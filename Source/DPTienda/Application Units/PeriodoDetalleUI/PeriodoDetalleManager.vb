Option Explicit On 

'Imports DPSoft.Core

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext

Public Class PeriodoDetalleManager

    Dim oApplicationContext As ApplicationContext

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As PeriodoDetalle

        Dim oNuevoPeriodo As PeriodoDetalle
        oNuevoPeriodo = New PeriodoDetalle(Me)

        Return oNuevoPeriodo

    End Function

    Public Function Load(ByVal ID As Integer) As PeriodoDetalle

        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)

        Return oPeriodosDG.Select(ID)

    End Function

    Public Sub LoadInto(ByVal ID As Integer, ByVal Periodos As PeriodoDetalle)

        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)

        oPeriodosDG.Select(ID, Periodos)

        oPeriodosDG = Nothing

    End Sub

    Public Sub Save(ByVal pPeriodos As PeriodoDetalle)

        Dim oPeriodosDG As New PeriodoDetalleDataGateway(Me)

        If (pPeriodos.IsNew) Then
            oPeriodosDG.Insert(pPeriodos)
        Else
            oPeriodosDG.Update(pPeriodos)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)

        oPeriodosDG.Delete(ID)

        oPeriodosDG = Nothing

    End Sub

    Public Sub Liquidar(ByVal ID As Integer, ByVal Liquidado As Boolean, ByVal PagoMin As Decimal, ByVal AsociadoID As Integer)

        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)

        oPeriodosDG.Liquidar(ID, Liquidado, PagoMin, AsociadoID)

        oPeriodosDG = Nothing

    End Sub

    Public Function SelectByNumPeriodo(ByVal NumPeriodo As Integer, ByVal AsociadoID As Integer) As PeriodoDetalle

        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)

        Return oPeriodosDG.SelectByNumPeriodo(NumPeriodo, AsociadoID)

    End Function

    'Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    '    Dim oPeriodosDG As PeriodosDataGateway
    '    oPeriodosDG = New PeriodosDataGateway(Me)

    '    Return oPeriodosDG.Select(EnabledRecordsOnly)

    'End Function

    Public Function SelectPeriodoActual(ByVal Fecha As DateTime) As Integer
        Dim oPeriodosDG As PeriodoDetalleDataGateway
        oPeriodosDG = New PeriodoDetalleDataGateway(Me)
        Return oPeriodosDG.SelectPeriodoActual(Fecha)
    End Function




#End Region
End Class
