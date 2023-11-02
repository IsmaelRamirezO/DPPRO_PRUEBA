Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoLineasManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoLineasDG As CatalogoLineasDataGateway

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

        oCatalogoLineasDG = New CatalogoLineasDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoLineasDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Linea

        Dim oNewLinea As Linea
        oNewLinea = New Linea(Me)

        Return oNewLinea

    End Function

    Public Function Load(ByVal ID As String) As Linea

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Línea")
        End If

        If (ID.Length > 3) Then
            Throw New ArgumentException("El Código de Línea no debe exceder los 3 caracteres de longitud.")
        End If

        Dim oReadedLinea As Linea

        oReadedLinea = oCatalogoLineasDG.Select(ID)

        Return oReadedLinea

    End Function


    Public Sub LoadInto(ByVal ID As String, ByVal Linea As Linea)

        oCatalogoLineasDG.Select(ID, Linea)

    End Sub

    Public Sub Save(ByVal Linea As Linea)

        If (Linea Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Linea no puede ser nulo.")
        End If

        If (Linea.IsNew) Then
            oCatalogoLineasDG.Insert(Linea)
        Else
            oCatalogoLineasDG.Update(Linea)
        End If

    End Sub

    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Línea")
        End If

        If (ID.Length > 2) Then
            Throw New ArgumentException("El Código de Línea no debe exceder los 2 caracteres de longitud.")
        End If

        oCatalogoLineasDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Linea As Linea)

        If (Linea Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Linea no puede ser nulo.")
        End If

        Try
            oCatalogoLineasDG.Delete(Linea.ID)

            Linea.Clear()
        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar la Linea especificada.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoLineasDG.Select(EnabledRecordsOnly)

    End Function

#End Region


End Class
