Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class CatalogoAlmacenesManager

    Dim oApplicationContext As ApplicationContext
    Dim oConfigCierre As SaveConfigArchivos
    Public TiendaNueva As Boolean

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal ConfigCierreFI As SaveConfigArchivos = Nothing, Optional ByVal Todos As Boolean = False)
        oApplicationContext = ApplicationContext
        oConfigCierre = ConfigCierreFI
        TiendaNueva = Todos
    End Sub

#End Region

#Region "Methods"

    Public Function GetRazonesRechazo(ByRef bResult As Boolean) As DataTable

        Dim oCatalogoAlmacenesDG As New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelectRazonesRechazo(bResult)

    End Function

    Public Function GetCodigosPostales() As DataTable

        Dim oCatalogoAlmacenesDG As New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelectCodigosPostales

    End Function

    Public Function GetCodigosPostalesByColonia(ByVal CodEstado As String, ByVal CodMunicipio As String, ByVal Colonia As String) As DataSet

        Dim oCatalogoAlmacenesDG As New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelectCodigosPostalesByColonia(CodEstado, CodMunicipio, Colonia)

    End Function

    Public Function Create() As Almacen

        Dim oNuevoAlmacen As Almacen
        oNuevoAlmacen = New Almacen(Me)

        Return oNuevoAlmacen

    End Function

    Public Function Load(ByVal ID As String) As Almacen

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.Select(ID)

    End Function

    Public Function LoadCiudad(ByVal Ciudad As String) As DataSet
        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelByCiudad(Ciudad)

    End Function

    Public Function Loadtienda(ByVal strtienda As String) As String

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SeleccionaCentro(strtienda)

    End Function

    Public Sub LoadInto(ByVal ID As String, ByVal Almacen As Almacen)

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        oCatalogoAlmacenesDG.Select(ID, Almacen)

        oCatalogoAlmacenesDG = Nothing

    End Sub

    Public Sub Save(ByVal pAlmacen As Almacen)

        Dim oCatalogoAlmacenesDG As New CatalogoAlmacenesDataGateway(Me)

        If (pAlmacen.IsNew) Then
            oCatalogoAlmacenesDG.Insert(pAlmacen)
        Else
            oCatalogoAlmacenesDG.Update(pAlmacen)
        End If

    End Sub

    Public Sub SaveCentro(ByVal CentroSAP As String, ByVal OficinaVta As String, ByVal Descripcion As String, ByVal CentroFI As String)

        Dim oCatalogoAlmacenesDG As New CatalogoAlmacenesDataGateway(Me)

        oCatalogoAlmacenesDG.InsertCentro(CentroSAP, OficinaVta, Descripcion, CentroFI)

    End Sub

    Public Sub Delete(ByVal ID As String)

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        oCatalogoAlmacenesDG.Delete(ID)

        oCatalogoAlmacenesDG = Nothing

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.Select(EnabledRecordsOnly)

    End Function

    Public Function GetAllFromServer() As DataSet

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelectFromServer()

    End Function

    Public Function GetAllCentrosFromServer() As DataSet

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SelectCentrosFromServer()

    End Function

    Public Function SeleccionaColor(ByVal strCOdigo As String) As String

        Dim oCatalogoAlmacenesDG As CatalogoAlmacenesDataGateway
        oCatalogoAlmacenesDG = New CatalogoAlmacenesDataGateway(Me)

        Return oCatalogoAlmacenesDG.SeleccionaColor(strCOdigo)

    End Function

#End Region

End Class
