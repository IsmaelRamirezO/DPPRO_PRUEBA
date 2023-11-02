Option Explicit On 

'Imports DPSoft.Core

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext

Public Class PeriodosManager

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

    Public Function Create() As Periodos

        Dim oNuevoPeriodo As Periodos
        oNuevoPeriodo = New Periodos(Me)

        Return oNuevoPeriodo

    End Function

    Public Function Load(ByVal ID As Integer) As Periodos

        Dim oPeriodosDG As PeriodosDataGateway
        oPeriodosDG = New PeriodosDataGateway(Me)

        Return oPeriodosDG.Select(ID)

    End Function

    Public Sub LoadInto(ByVal ID As Integer, ByVal Periodos As Periodos)

        Dim oPeriodosDG As PeriodosDataGateway
        oPeriodosDG = New PeriodosDataGateway(Me)

        oPeriodosDG.Select(ID, Periodos)

        oPeriodosDG = Nothing

    End Sub

    Public Sub Save(ByVal pPeriodos As Periodos)

        Dim oPeriodosDG As New PeriodosDataGateway(Me)

        If (pPeriodos.IsNew) Then
            oPeriodosDG.Insert(pPeriodos)
        Else
            oPeriodosDG.Update(pPeriodos)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim oPeriodosDG As PeriodosDataGateway
        oPeriodosDG = New PeriodosDataGateway(Me)

        oPeriodosDG.Delete(ID)

        oPeriodosDG = Nothing

    End Sub

   

    'Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    '    Dim oPeriodosDG As PeriodosDataGateway
    '    oPeriodosDG = New PeriodosDataGateway(Me)

    '    Return oPeriodosDG.Select(EnabledRecordsOnly)

    'End Function





#End Region

End Class
