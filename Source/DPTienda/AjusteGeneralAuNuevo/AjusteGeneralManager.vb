Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class AjusteGeneralManager

    Private oApplicationContext As ApplicationContext
    Private oAjusGDG As AjusteGeneralDataGateway
    Private oConfigCierre As SaveConfigArchivos

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal ConfigCierreFI As SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext

        oConfigCierre = ConfigCierreFI

        oAjusGDG = New AjusteGeneralDataGateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oAjusGDG = Nothing

    End Sub

#End Region

#Region "Properties"

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

#End Region

#Region "Methods"

    Public Function Create(ByVal strTipoajuste As String) As AjusteGeneralInfo

        Dim oNuevoValeCaja As AjusteGeneralInfo
        oNuevoValeCaja = New AjusteGeneralInfo(Me, strTipoAjuste)

        Return oNuevoValeCaja

    End Function

    Public Sub LoadInto(ByVal intFolioAjuste As Integer, ByVal oAjusteGeneralInfo As AjusteGeneralInfo)

        oAjusGDG.LoadInto(intFolioAjuste, oAjusteGeneralInfo)

    End Sub

    Public Function AjusteESNuevoSel(ByVal intFolioAjuste As Integer, ByVal strEstado As String) As DataTable

        Return oAjusGDG.AjusteESNuevoSel(intFolioAjuste, strEstado)

    End Function

    Public Sub Save(ByVal pAjusteGeneralInfo As AjusteGeneralInfo)

        If (pAjusteGeneralInfo.IsNew) Then

            oAjusGDG.Insert(pAjusteGeneralInfo)

        End If

    End Sub

    Public Sub SaveInServer(ByVal pAjusteGeneralInfo As AjusteGeneralInfo)

        oAjusGDG = New AjusteGeneralDataGateway(Me)

        oAjusGDG.InsertInServer(pAjusteGeneralInfo)

    End Sub

    Public Function InsertESNuevo(ByVal intFolioAJS As Integer, ByVal intFolioAJE As Integer, ByVal strEstado As String, ByVal strObservaciones As String, ByVal datFecha As DateTime, ByVal strUsuario As String) As Integer

        Return oAjusGDG.InsertESNuevo(intFolioAJS, intFolioAJE, strEstado, strObservaciones, datFecha, strUsuario)

    End Function

    Public Function GetFolio(ByVal strTipoajuste As String) As Integer

        Return oAjusGDG.GetFolioAjuste(strTipoajuste)

    End Function

    Public Function GetAllESNuevo(ByVal strTipoConsulta As String) As DataSet
        Return oAjusGDG.GetAllESNuevo(strTipoConsulta)
    End Function

    Public Function GetFolioESNuevo() As Integer

        Return oAjusGDG.GetFolioAjusteESNuevo()

    End Function

    Public Sub UpdateESNuevoEstado(ByVal intFolio As Integer, ByVal strEstado As String)

        oAjusGDG.UpdateESNuevoEstado(intFolio, strEstado)

    End Sub

    Public Sub UpdateESNuevoDettalleFolioSAP(ByVal intFolio As Integer, ByVal strFolioSAP As String, ByVal strTipoAjuste As String)

        oAjusGDG.UpdateESNuevoDettalleFolioSAP(intFolio, strFolioSAP, strTipoAjuste)

    End Sub

    Public Sub PutMovimiento(ByVal oAjusteInfo As AjusteGeneralInfo)

        oAjusGDG.InsertMovimiento(oAjusteInfo)

    End Sub

    Public Function GetAll(ByVal strTipoAjuste) As DataSet
        Return oAjusGDG.GetAll(strTipoAjuste)
    End Function

    Public Function Existencias(ByVal strCodArt As String) As Decimal
        Return oAjusGDG.GetExistencias(strCodArt)
    End Function

    Public Sub UpdateCantAJS(ByVal intFolioAjuste As Integer, ByVal strCodigo As String, ByVal intCantidad As Integer)

        oAjusGDG.UpdateCantAJS(intFolioAjuste, strCodigo, intCantidad)

    End Sub

    Public Sub DeleteCodigoAJS(ByVal intFolioAjuste As Integer, ByVal strCodigo As String) ', ByVal strTalla As String)
        '-----------------------------------------------------------------------------
        ' JNAVA (18.02.2016): modificado por adecuaciones de Retail
        '-----------------------------------------------------------------------------

        oAjusGDG.DeleteCodigoAJS(intFolioAjuste, strCodigo) ', strTalla)

    End Sub

#End Region

#Region "Reporte"
    Public Function [SelectToReporte](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime) As DataSet
        Return oAjusGDG.SelectToReporte(FechaDel, FechaAl)
    End Function
#End Region



End Class


