
Option Explicit On 

Imports DportenisPro.DpTienda.Core


Public Class CatalogoTipoMonedaManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoTipoMonedaDG As CatalogoTipoMonedaDataGateWay



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoTipoMonedaDG = New CatalogoTipoMonedaDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoTipoMonedaDG = Nothing

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

    Public Function Create() As TipoMoneda

        Dim oNuevoTipoMoneda As TipoMoneda
        oNuevoTipoMoneda = New TipoMoneda(Me)

        Return oNuevoTipoMoneda

    End Function



    Public Function Load(ByVal ID As String) As TipoMoneda

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Moneda")
        End If

        If (ID.Length > 4) Then
            Throw New ArgumentException("El Código de Moneda no debe exceder los 4 caracteres de longitud.")
        End If

        Dim oReadedTipoMoneda As TipoMoneda

        oReadedTipoMoneda = oCatalogoTipoMonedaDG.SelectByID(ID)

        Return oReadedTipoMoneda

    End Function



    Public Sub Save(ByVal pTipoMoneda As TipoMoneda)

        If (pTipoMoneda Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Tipo Moneda no puede ser nulo.")
        End If

        If (pTipoMoneda.IsNew) Then
            'oCatalogoTipoMonedaDG.Insert(pTipoMoneda)
        Else
            'oCatalogoTipoMonedaDG.Update(pTipoMoneda)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Moneda")
        End If

        If (ID.Length > 4) Then
            Throw New ArgumentException("El Código de Moneda no debe exceder los 4 caracteres de longitud.")
        End If

        'oCatalogoTipoMonedaDG.Delete(ID)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoTipoMonedaDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
