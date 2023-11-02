
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CatalogoTipoTarjetasManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoTipoTarjetasDG As CatalogoTipoTarjetasDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoTipoTarjetasDG = New CatalogoTipoTarjetasDataGateway(Me)

    End Sub



    Public Sub dispose()

        MyBase.Finalize()

        oCatalogoTipoTarjetasDG = Nothing

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

    Public Function Create() As TipoTarjeta

        Dim oNuevaCaja As TipoTarjeta
        oNuevaCaja = New TipoTarjeta(Me)

        Return oNuevaCaja

    End Function



    Public Function Load(ByVal ID As String) As TipoTarjeta

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Caja")
        End If

        If (ID.Length > 2) Then
            Throw New ArgumentException("El Código de Tipo Tarjeta no debe exceder los 2 caracteres de longitud.")
        End If

        Dim oReadedTipoTarjeta As TipoTarjeta

        oReadedTipoTarjeta = oCatalogoTipoTarjetasDG.SelectByID(ID)

        Return oReadedTipoTarjeta

    End Function



    Public Sub Save(ByVal pTipoTarjeta As TipoTarjeta)

        If (pTipoTarjeta Is Nothing) Then
            Throw New ArgumentNullException("El parámetro TipoTarjeta no puede ser nulo.")
        End If

        If (pTipoTarjeta.IsNew) Then
            oCatalogoTipoTarjetasDG.Insert(pTipoTarjeta)
        Else
            oCatalogoTipoTarjetasDG.Update(pTipoTarjeta)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Tipo Tarjeta")
        End If

        If (ID.Length > 2) Then
            Throw New ArgumentException("El Código de Tipo Tarjeta no debe exceder los 2 caracteres de longitud.")
        End If

        oCatalogoTipoTarjetasDG.Delete(ID)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoTipoTarjetasDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region



End Class
