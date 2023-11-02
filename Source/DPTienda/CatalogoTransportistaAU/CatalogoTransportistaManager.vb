
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CatalogoTransportistaManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoTransportistaDG As CatalogoTransportistaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoTransportistaDG = New CatalogoTransportistaDataGateway(Me)

    End Sub



    Public Sub dispose()

        MyBase.Finalize()

        oCatalogoTransportistaDG = Nothing

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

    Public Function Create() As Transportista

        Dim oNuevoTransportista As Transportista
        oNuevoTransportista = New Transportista(Me)

        Return oNuevoTransportista

    End Function



    Public Function Load(ByVal ID As String) As Transportista

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Transportista")
        End If

        If (ID.Length > 3) Then
            Throw New ArgumentException("El Código de Transportista no debe exceder los 3 caracteres de longitud.")
        End If

        Dim oReadedTransportista As Transportista

        oReadedTransportista = oCatalogoTransportistaDG.SelectByID(ID)

        Return oReadedTransportista

    End Function



    Public Sub Save(ByVal pTransportista As Transportista)

        '    If (pTransportista Is Nothing) Then
        '        Throw New ArgumentNullException("El parámetro Trasnportista no puede ser nulo.")
        '    End If

        '    If (pTransportista.IsNew) Then
        '        oCatalogoTransportistaDG.Insert(pTransportista)
        '    Else
        '        oCatalogoTransportistaDG.Update(pTransportista)
        '    End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        'If (ID = String.Empty) Then
        '    Throw New ArgumentException("Debe especificar un Código de Transportista")
        'End If

        'If (ID.Length > 3) Then
        '    Throw New ArgumentException("El Código de Transportista no debe exceder los 3 caracteres de longitud.")
        'End If

        'oCatalogoTransportistaDG.Delete(ID)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoTransportistaDG.SelectAll(EnabledRecordsOnly)

    End Function


#End Region

End Class
