Option Explicit On 

'Imports DPSoft.Core

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext

Public Class RevisionApartadosManager

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

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oRevisionApartadosDG As RevisionApartadosDataGateWay
        oRevisionApartadosDG = New RevisionApartadosDataGateWay(Me)

        Return oRevisionApartadosDG.Select(EnabledRecordsOnly)

    End Function

    Public Function Insert(ByVal oRevisionApartados As RevisionApartados) As Integer

        Dim oRevisionApartadosDG As RevisionApartadosDataGateWay
        oRevisionApartadosDG = New RevisionApartadosDataGateWay(Me)

        Return oRevisionApartadosDG.Insert(oRevisionApartados)

    End Function

    Public Function [SelectByID](ByVal Folio As Integer) As RevisionApartados

        Dim oRevisionApartadosDG As RevisionApartadosDataGateWay
        oRevisionApartadosDG = New RevisionApartadosDataGateWay(Me)

        Return oRevisionApartadosDG.SelectByID(Folio)

    End Function

    Public Function [SelectFolio]() As Integer

        Dim oRevisionApartadosDG As RevisionApartadosDataGateWay
        oRevisionApartadosDG = New RevisionApartadosDataGateWay(Me)

        Return oRevisionApartadosDG.SelectFolio

    End Function
End Class
