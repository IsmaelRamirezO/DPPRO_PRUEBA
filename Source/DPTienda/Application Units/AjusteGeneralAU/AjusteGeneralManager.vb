Imports DportenisPro.DPTienda.Core

Public Class AjusteGeneralManager

    Private oApplicationContext As ApplicationContext
    Private oAjusGDG As AjusteGeneralDataGateway

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

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

    Public Sub Save(ByVal pAjusteGeneralInfo As AjusteGeneralInfo)

        If (pAjusteGeneralInfo.IsNew) Then

            oAjusGDG.Insert(pAjusteGeneralInfo)

        End If

    End Sub
    Public Sub SaveFolios(ByVal LimiteInferior As Integer, ByVal LimiteSuperior As Integer, ByVal TotalFolios As Integer, ByVal CodCaja As String)
        oAjusGDG.Save(LimiteInferior, LimiteSuperior, TotalFolios, CodCaja)
    End Sub
    Public Function GetFolio(ByVal strTipoajuste As String) As Integer

        Return oAjusGDG.GetFolioAjuste(strTipoajuste)

    End Function

    Public Sub PutMovimiento(ByVal oAjusteInfo As AjusteGeneralInfo)

        oAjusGDG.InsertMovimiento(oAjusteInfo)

    End Sub

    Public Function GetAll(ByVal strTipoAjuste) As DataSet
        Return oAjusGDG.GetAll(strTipoAjuste)
    End Function

    Public Function Existencias(ByVal strCodArt As String, ByVal strtalla As String) As Decimal
        Return oAjusGDG.GetExistencias(strCodArt, strtalla)
    End Function
    Public Function LoadLimiteInferiorInicioCaja() As Integer
        Return oAjusGDG.GetLimiteInferiorInicioCaja()
    End Function
    Public Function LoadLimiteInferior() As Integer
        Return oAjusGDG.GetLimiteInferior()
    End Function
    Public Function GetDateServer() As DateTime
        Dim oResult As DateTime
        Dim oAjusGDG As AjusteGeneralDataGateway
        oAjusGDG = New AjusteGeneralDataGateway(Me)
        oResult = oAjusGDG.SelectFechaServidor()
        oAjusGDG = Nothing
        Return oResult
    End Function
    Public Function BuscarFolio(ByVal Folio As Integer) As Integer

        Dim Existe As Integer
        Dim oAjusGDG As AjusteGeneralDataGateway
        oAjusGDG = New AjusteGeneralDataGateway(Me)
        Existe = oAjusGDG.BuscarFolio(Folio)
        Return Existe
    End Function
    Public Sub UpdStatusRegNotaVenta(ByVal Folio As Integer)
        Dim oAjusteGDG As AjusteGeneralDataGateway
        oAjusteGDG = New AjusteGeneralDataGateway(Me)
        oAjusteGDG.FolioNotaVentaUPD(Folio)
    End Sub

#End Region

#Region "Reporte"
    Public Function [SelectToReporte](ByVal FechaDel As DateTime, ByVal FechaAl As DateTime) As DataSet
        Return oAjusGDG.SelectToReporte(FechaDel, FechaAl)
    End Function
#End Region



End Class
