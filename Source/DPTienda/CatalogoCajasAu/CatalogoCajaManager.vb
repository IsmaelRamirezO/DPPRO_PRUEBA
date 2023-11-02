
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CatalogoCajaManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoCajaDG As CatalogoCajaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoCajaDG = New CatalogoCajaDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoCajaDG = Nothing

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

    Public Function Create() As Caja

        Dim oNuevaCaja As Caja
        oNuevaCaja = New Caja(Me)

        Return oNuevaCaja

    End Function



    Public Function Load(ByVal ID As String) As Caja

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Caja")
        End If

        If (ID.Length > 2) Then
            Throw New ArgumentException("El Código de Caja no debe exceder los 2 caracteres de longitud.")
        End If

        Dim oReadedCaja As Caja

        oReadedCaja = oCatalogoCajaDG.SelectByID(ID)

        Return oReadedCaja

    End Function



    Public Sub Save(ByVal pCaja As Caja)

        If (pCaja Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Caja no puede ser nulo.")
        End If

        If (pCaja.IsNew) Then
            oCatalogoCajaDG.Insert(pCaja)
        Else
            oCatalogoCajaDG.Update(pCaja)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Caja")
        End If

        If (ID.Length > 2) Then
            Throw New ArgumentException("El Código de Caja no debe exceder los 2 caracteres de longitud.")
        End If

        oCatalogoCajaDG.Delete(ID)

    End Sub

    Public Sub UpdateIP(ByVal ID As String, ByVal IP As String)
        oCatalogoCajaDG.UpdateIP(ID, IP)
    End Sub


    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoCajaDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
