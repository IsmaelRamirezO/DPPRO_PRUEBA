Option Explicit On 

Imports DportenisPro.DPTienda.Core

Public Class PolizaManager
    Private oApplicationContext As ApplicationContext
    Private oPolizaDG As PolizaDataGateWay

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oPolizaDG = New PolizaDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oPolizaDG = Nothing

    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property


#End Region

    Public Function GetRetiros(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Return oPolizaDG.GetRetiros(CodCaja, Fecha)

    End Function

    Public Function GetVentasTotales(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Return oPolizaDG.GetVentasTotales(CodCaja, Fecha)

    End Function

    Public Function GetVentasTarjetas(ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet

        Return oPolizaDG.GetVentasTarjetas(CodCaja, Fecha)

    End Function


End Class
