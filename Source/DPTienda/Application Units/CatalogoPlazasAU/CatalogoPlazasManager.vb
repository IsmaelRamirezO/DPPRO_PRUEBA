Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoPlazasManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoPlazasDG As CatalogoPlazasDataGateway

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

        oCatalogoPlazasDG = New CatalogoPlazasDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoPlazasDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Plaza

        Dim oNewPlaza As Plaza
        oNewPlaza = New Plaza(Me)

        Return oNewPlaza

    End Function

    Public Function Load(ByVal ID As String) As Plaza

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Plaza")
        End If

        Dim oReadedPlaza As Plaza

        oReadedPlaza = oCatalogoPlazasDG.Select(ID)

        Return oReadedPlaza

    End Function


    Public Sub LoadInto(ByVal ID As String, ByVal Plaza As Plaza)

        oCatalogoPlazasDG.Select(ID, Plaza)

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoPlazasDG.Select(EnabledRecordsOnly)

    End Function

#End Region

End Class
