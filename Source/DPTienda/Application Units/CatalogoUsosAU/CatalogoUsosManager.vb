Imports DportenisPro.DPTienda.Core

Public Class UsosCatalogManager


    Dim oApplicationContext As ApplicationContext

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Private oUsosCatalogDG As UsosCatalogDataGateway

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oUsosCatalogDG = New UsosCatalogDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oUsosCatalogDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Uso

        Dim oNewUso As Uso
        oNewUso = New Uso(Me)

        Return oNewUso

    End Function

    Public Function Load(ByVal ID As Integer) As Uso

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Uso.")
        End If

        Dim oReadedUso As Uso

        oReadedUso = oUsosCatalogDG.SelectByID(ID)

        Return oReadedUso

    End Function

    Public Sub Save(ByVal Uso As Uso)

        If (Uso Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Uso no puede ser nulo.")
        End If

        If (Uso.IsNew) Then
            oUsosCatalogDG.Insert(Uso)
        Else
            oUsosCatalogDG.Update(Uso)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Uso")
        End If

        oUsosCatalogDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Uso As Uso)

        If (Uso Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Uso no puede ser nulo.")
        End If

        Try
            oUsosCatalogDG.Delete(Uso.ID)

            Uso.Clear()
        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar la Uso especificada.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oUsosCatalogDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
