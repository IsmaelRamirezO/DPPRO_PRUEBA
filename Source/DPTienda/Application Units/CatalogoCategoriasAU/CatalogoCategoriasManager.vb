Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core


Public Class CatalogoCategoriasManager

    Private oCatalogoCategoriasDG As CatalogoCategoriasDataGateway
    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    'Private oCatalogoLineasDG As CatalogoCategoriasDataGateway

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

        oCatalogoCategoriasDG = New CatalogoCategoriasDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoCategoriasDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Categoria

        Dim oNewCategoria As Categoria
        oNewCategoria = New Categoria(Me)

        Return oNewCategoria

    End Function

    Public Function Load(ByVal ID As Integer) As Categoria

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Categoria.")
        End If

        Dim oReadedCategoria As Categoria

        oReadedCategoria = oCatalogoCategoriasDG.SelectByID(ID)

        Return oReadedCategoria

    End Function

    Public Sub Save(ByVal Categoria As Categoria)

        If (Categoria Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Categoria no puede ser nulo.")
        End If

        If (Categoria.IsNew) Then
            oCatalogoCategoriasDG.Insert(Categoria)
        Else
            oCatalogoCategoriasDG.Update(Categoria)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Categoria")
        End If

        oCatalogoCategoriasDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Categoria As Categoria)

        If (Categoria Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Categoria no puede ser nulo.")
        End If

        Try
            oCatalogoCategoriasDG.Delete(Categoria.ID)

            Categoria.Clear()
        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar la Categoria especificada.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoCategoriasDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
