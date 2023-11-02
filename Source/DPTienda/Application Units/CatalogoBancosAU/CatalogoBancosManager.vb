
Option Explicit On 

Imports DportenisPro.DpTienda.Core


Public Class CatalogoBancosManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoBancosDG As CatalogoBancosDataGateWay



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoBancosDG = New CatalogoBancosDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoBancosDG = Nothing

    End Sub

#End Region



#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

#End Region



#Region "Methods"

    Public Function Create() As Bancos

        Dim oNuevoBanco As Bancos
        oNuevoBanco = New Bancos(Me)

        Return oNuevoBanco

    End Function



    Public Function Load(ByVal ID As String) As Bancos

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Banco")
        End If

        If (ID.Length > 4) Then
            Throw New ArgumentException("El Código de Banco no debe exceder los 4 caracteres de longitud.")
        End If

        Dim oReadedBanco As Bancos

        oReadedBanco = oCatalogoBancosDG.SelectByID(ID)

        Return oReadedBanco

    End Function



    Public Sub Save(ByVal pBanco As Bancos)

        If (pBanco Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Banco no puede ser nulo.")
        End If

        If (pBanco.IsNew) Then
            oCatalogoBancosDG.Insert(pBanco)
        Else
            oCatalogoBancosDG.Update(pBanco)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Banco")
        End If

        If (ID.Length > 4) Then
            Throw New ArgumentException("El Código de Banco no debe exceder los 4 caracteres de longitud.")
        End If

        oCatalogoBancosDG.Delete(ID)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoBancosDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
