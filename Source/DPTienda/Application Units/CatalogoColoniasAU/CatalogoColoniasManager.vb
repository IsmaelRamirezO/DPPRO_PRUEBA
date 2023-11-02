Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoColoniasManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoColoniasDG As CatalogoColoniasDataGateway

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

        oCatalogoColoniasDG = New CatalogoColoniasDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoColoniasDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Colonia

        Dim oNewColonia As Colonia
        oNewColonia = New Colonia(Me)

        Return oNewColonia

    End Function

    Public Function Load(ByVal ID As Integer) As Colonia

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Colonia")
        End If

        Dim oReadedColonia As Colonia

        oReadedColonia = oCatalogoColoniasDG.Select(ID)

        Return oReadedColonia

    End Function


    Public Sub LoadInto(ByVal ID As Integer, ByVal Colonia As Colonia)

        oCatalogoColoniasDG.Select(ID, Colonia)

    End Sub

    Public Sub Save(ByVal Colonia As Colonia)

        If (Colonia Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Colonia no puede ser nulo.")
        End If

        If (Colonia.IsNew) Then
            oCatalogoColoniasDG.Insert(Colonia)
        Else
            oCatalogoColoniasDG.Update(Colonia)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Colonia")
        End If

        oCatalogoColoniasDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Colonia As Colonia)

        If (Colonia Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Colonia no puede ser nulo.")
        End If

        Try
            oCatalogoColoniasDG.Delete(Colonia.CodColonia)

            Colonia.Clear()

        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar la Colonia especificada.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoColoniasDG.Select(EnabledRecordsOnly)

    End Function

#End Region


End Class
