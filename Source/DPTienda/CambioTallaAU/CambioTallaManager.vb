Imports DportenisPro.DPTienda.Core

Public Class CambioTallaManager

    Dim oApplicationContext As ApplicationContext


    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)
        oApplicationContext = ApplicationContext
    End Sub

#End Region


#Region "Methods"

    Public Function Create() As CambioTalla

        Dim oNuevoCambioTalla As CambioTalla
        oNuevoCambioTalla = New CambioTalla(Me)

        Return oNuevoCambioTalla

    End Function

    Public Function Load(ByVal ID As Integer) As CambioTalla

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.SelectByID(ID)

    End Function


    Public Function Save(ByVal pCambioTalla As CambioTalla) As Integer

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.Insert(pCambioTalla)

    End Function

    Public Sub Delete(ByVal ID As Integer)

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        oCambioTallaDG.Delete(ID)

        oCambioTallaDG = Nothing

    End Sub

    Public Function GetDetailFactura(ByVal IDFactura As Integer, ByVal IDCaja As String) As DataSet

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.LoadDataFactura(IDFactura, IDCaja)

        oCambioTallaDG = Nothing

    End Function

    Public Function GetTallas(ByVal IDCorrida As String) As DataSet

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.LoadDataTallas(IDCorrida)

        oCambioTallaDG = Nothing

    End Function

    Public Function GetStock(ByVal CodAlmacen As String, _
                                ByVal CodArticulo As String, _
                                    ByVal Talla As Decimal) As Integer


        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.LoadStock(CodAlmacen, CodArticulo, Talla)

        oCambioTallaDG = Nothing

    End Function

    Public Sub SaveMoveInOut(ByVal Codtipomov As Integer, _
                                ByVal TipoMovimiento As String, _
                                    ByVal Numero As Decimal, _
                                        ByVal pCambioTalla As CambioTalla)

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        oCambioTallaDG.InsertMoveInOut(Codtipomov, TipoMovimiento, Numero, pCambioTalla)

    End Sub

    Public Function ListFactura(ByVal EnabledRecordOnly As Boolean) As DataSet

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.LoadListFactura(EnabledRecordOnly)

        oCambioTallaDG = Nothing

    End Function

    Public Function LoadFacturaByID(ByVal FacturaID As Integer) As DataSet

        Dim oCambioTallaDG As CambioTallaDataGateway
        oCambioTallaDG = New CambioTallaDataGateway(Me)

        Return oCambioTallaDG.LoadFacturaByID(FacturaID)

        oCambioTallaDG = Nothing

    End Function


#End Region

#Region "Cambios de Talla DPVales"

    Public Function SaveCambiosTallaDPVale(ByVal CambioTalla As CambioTallaDPVale) As Boolean
        Dim oCambioTallaDG As New CambioTallaDataGateway(Me)
        Return oCambioTallaDG.SaveCambiosTallaDPVale(CambioTalla)
    End Function

    Public Sub LoadCambioTallaDPVale(ByVal CambioTalla As CambioTallaDPVale)
        Dim oCambioTallaDG As New CambioTallaDataGateway(Me)
        oCambioTallaDG.LoadCambioTallaDPVale(CambioTalla)
    End Sub

    Public Function GetCambiosTallaDPValeByRefOrigen(ByVal RefOrigen As String) As DataTable
        Dim oCambioTallaDG As New CambioTallaDataGateway(Me)
        Return oCambioTallaDG.GetCambiosTallaDPValeByRefOrigen(RefOrigen)
    End Function

    Public Function GetCambiosTallaByValeId(ByVal ValeId As String) As DataTable
        Dim oCambioTallaDG As New CambioTallaDataGateway(Me)
        Return oCambioTallaDG.GetCambiosTallaByValeId(ValeId)
    End Function

#End Region

End Class
