
Option Explicit On 

Imports DportenisPro.DPTienda.Core



Public Class CatalogoTipoVentaManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoTipoVentaDG As CatalogoTipoVentaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoTipoVentaDG = New CatalogoTipoVentaDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoTipoVentaDG = Nothing

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

    Public Function Create() As TipoVenta

        Dim oNuevaTipoVenta As TipoVenta
        oNuevaTipoVenta = New TipoVenta(Me)

        Return oNuevaTipoVenta

    End Function



    Public Function Load(ByVal ID As String) As TipoVenta

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Tipo Venta")
        End If

        If (ID.Length > 1) Then
            Throw New ArgumentException("El Código de Tipo Venta no debe exceder los 1 caracteres de longitud.")
        End If

        Dim oReadedTipoVenta As TipoVenta

        oReadedTipoVenta = oCatalogoTipoVentaDG.SelectByID(ID)

        Return oReadedTipoVenta

    End Function



    Public Sub Save(ByVal pTipoVenta As TipoVenta)

        If (pTipoVenta Is Nothing) Then
            Throw New ArgumentNullException("El parámetro TipoVenta no puede ser nulo.")
        End If

        If (pTipoVenta.IsNew) Then
            oCatalogoTipoVentaDG.Insert(pTipoVenta)
        Else
            oCatalogoTipoVentaDG.Update(pTipoVenta)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Tipo Venta")
        End If

        If (ID.Length > 1) Then
            Throw New ArgumentException("El Código de Tipo Venta no debe exceder los 1 caracteres de longitud.")
        End If

        oCatalogoTipoVentaDG.Delete(ID)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoTipoVentaDG.SelectAll(EnabledRecordsOnly)

    End Function

    Public Function GetTipoCliente(ByVal CodTipoVenta As String) As String
        Return oCatalogoTipoVentaDG.GetTipoCliente(CodTipoVenta)
    End Function

    Public Function GetMotivoPedidoByTipoVenta(ByVal CodTipoVenta As String) As String
        Return oCatalogoTipoVentaDG.GetMotivoPedidoByTipoVenta(CodTipoVenta)
    End Function

#End Region

End Class
