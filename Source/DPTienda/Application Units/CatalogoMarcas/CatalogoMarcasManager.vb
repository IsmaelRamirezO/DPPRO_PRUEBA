Imports DportenisPro.DPTienda.Core

Public Class CatalogoMarcasManager
    Dim oApplicationContext As ApplicationContext
    Private oCatalogoMarcasDG As CatalogoMarcasDataGateway

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)
        oApplicationContext = ApplicationContext
    End Sub

    Public Sub dispose()

        MyBase.Finalize()

        oCatalogoMarcasDG = Nothing

    End Sub
#End Region

#Region "Methods"

    Public Function Create() As Marca

        Dim oNuevoAlmacen As Marca
        oNuevoAlmacen = New Marca(Me)

        Return oNuevoAlmacen

    End Function

    Public Function Load(ByVal ID As String) As Marca

        Dim oCatalogoAlmacenesDG As CatalogoMarcasDataGateway
        oCatalogoAlmacenesDG = New CatalogoMarcasDataGateway(Me)

        Return oCatalogoAlmacenesDG.Select(ID)

    End Function

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oCatalogoMarcasDG As CatalogoMarcasDataGateway
        oCatalogoMarcasDG = New CatalogoMarcasDataGateway(Me)

        Return oCatalogoMarcasDG.Select(EnabledRecordsOnly)

    End Function

    Public Sub Save(ByVal oMarca As Marca)

        Dim oCatalogoMarcasDG As CatalogoMarcasDataGateway
        oCatalogoMarcasDG = New CatalogoMarcasDataGateway(Me)

        oCatalogoMarcasDG.Insert(oMarca)

    End Sub

#End Region

End Class
