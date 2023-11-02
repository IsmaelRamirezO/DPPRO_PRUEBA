Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoCiudadesManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoCiudadesDG As CatalogoCiudadesDataGateway

#Region "Properties"

    Public ReadOnly Property ApplicationContext() As DportenisPro.DPTienda.Core.ApplicationContext
        Get
            Return oAppContext
        End Get
    End Property

#End Region

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oAppContext = ApplicationContext

        oCatalogoCiudadesDG = New CatalogoCiudadesDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoCiudadesDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Ciudad

        Dim oNewCiudad As Ciudad
        oNewCiudad = New Ciudad(Me)

        Return oNewCiudad

    End Function

    Public Function Load(ByVal ID As Integer) As Ciudad

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Ciudad")
        End If

        Dim oReadedCiudad As Ciudad

        oReadedCiudad = oCatalogoCiudadesDG.Select(ID)

        Return oReadedCiudad

    End Function


    Public Sub LoadInto(ByVal ID As Integer, ByVal Ciudad As Ciudad)

        oCatalogoCiudadesDG.Select(ID, Ciudad)

    End Sub

    Public Sub Save(ByVal Ciudad As Ciudad)

        If (Ciudad Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Ciudad no puede ser nulo.")
        End If

        If (Ciudad.IsNew) Then
            oCatalogoCiudadesDG.Insert(Ciudad)
        Else
            oCatalogoCiudadesDG.Update(Ciudad)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Ciudad")
        End If

        oCatalogoCiudadesDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Ciudad As Ciudad)

        If (Ciudad Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Ciudad no puede ser nulo.")
        End If

        Try
            oCatalogoCiudadesDG.Delete(Ciudad.CodEstado)

            Ciudad.Clear()

        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar el Estado especificado.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoCiudadesDG.Select(EnabledRecordsOnly)

    End Function

#End Region

End Class
