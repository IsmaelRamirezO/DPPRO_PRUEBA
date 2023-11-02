Imports DportenisPro.DPTienda.Core

Public Class TiposVentaManager

    Private oApplicationContext As ApplicationContext
    Private oTipoVentaDG As TiposVentaDatagateway

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oTipoVentaDG = New TiposVentaDatagateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oTipoVentaDG = Nothing

    End Sub

#End Region

#Region "Properties"

    Friend ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

#End Region


#Region "Methods"

    Public Function Load() As DataSet

        Return oTipoVentaDG.Select

    End Function

#End Region

End Class
