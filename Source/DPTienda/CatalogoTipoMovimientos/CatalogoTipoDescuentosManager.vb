
Imports DportenisPro.DPTienda.Core


Public Class CatalogoTipoDescuentosManager

    Private oApplicationContext As ApplicationContext

    Private oCatalogoTipoDescuentosDG As CatalogoTipoDescuentosDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoTipoDescuentosDG = New CatalogoTipoDescuentosDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoTipoDescuentosDG = Nothing

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

    Public Function Create() As TipoDescuento

        Dim oNuevoTipoMovimiento As TipoDescuento
        oNuevoTipoMovimiento = New TipoDescuento(Me)

        Return oNuevoTipoMovimiento

    End Function



    Public Function Load(ByVal ID As String) As TipoDescuento

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Caja")
        End If

        If (ID.Length > 3) Then
            Throw New ArgumentException("El Código de Tipo Descuento no debe exceder los 3 caracteres de longitud.")
        End If

        Dim oReadedTipoDescuento As TipoDescuento

        oReadedTipoDescuento = oCatalogoTipoDescuentosDG.SelectByID(ID)

        Return oReadedTipoDescuento

    End Function



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoTipoDescuentosDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class
