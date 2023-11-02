Imports DportenisPro.DPTienda.Core
Public Class AjusteGeneralTallaManager

    Private oApplicationContext As ApplicationContext
    Private oAjusGDG As AjusteGeneralTallaGateway

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oAjusGDG = New AjusteGeneralTallaGateway(Me)

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

    Public Function Create() As AjusteGeneralTallaInfo

        Dim oNuevoAjusteTalla As AjusteGeneralTallaInfo
        oNuevoAjusteTalla = New AjusteGeneralTallaInfo(Me)

        Return oNuevoAjusteTalla

    End Function

    Public Sub LoadInto(ByVal intFolioAjuste As Integer, ByVal oAjusteGeneralInfo As AjusteGeneralTallaInfo)

        oAjusGDG.LoadInto(intFolioAjuste, oAjusteGeneralInfo)

    End Sub

    Public Sub Save(ByVal pAjusteGeneralInfo As AjusteGeneralTallaInfo, Optional ByVal NotaCreditoID As Integer = 0, _
        Optional ByVal bolMenuUtilerias As Boolean = False)

        If (pAjusteGeneralInfo.IsNew) Then

            oAjusGDG.Insert(pAjusteGeneralInfo, NotaCreditoID, bolMenuUtilerias)

        End If

    End Sub

    Public Function GetFolio() As Integer

        Return oAjusGDG.GetFolioAjuste()

    End Function

    Public Sub PutMovimiento(ByVal oAjusteInfo As AjusteGeneralTallaInfo, ByVal strMov As String)

        oAjusGDG.InsertMovimiento(oAjusteInfo, strMov)

    End Sub

    Public Function GetAll() As DataSet
        Return oAjusGDG.GetAll()
    End Function

    Public Function ValidaExistenciasCambiosTalla(ByVal FolioSAP As String, ByVal Talla As String, ByVal CodArticulo As String, _
                                                  ByVal CantDev As Integer) As Boolean

        Return oAjusGDG.ValidarExistenciasCambiosTalla(FolioSAP, Talla, CodArticulo, CantDev)

    End Function

    Public Sub SaveAjustesAutomaticosPendientes(ByVal dtAjustesPend As DataTable, ByVal NCID As Integer)

        oAjusGDG.SaveAjustesAutomaticosPendientes(dtAjustesPend, NCID)

    End Sub

    Public Function LoadAjustesPendientesAllNC() As DataTable

        Return oAjusGDG.SelectAjustesPendNCAll()

    End Function

    Public Function LoadAjustesPendientesByNotaCreditoID_All(ByVal NotaCreditoID As Integer) As DataTable

        Return oAjusGDG.SelectAjustesPendByNCID_All(NotaCreditoID)

    End Function

    Public Sub UpdateStatusAjustesAutomaticosPendientes(ByVal CodArticulo As String, ByVal TallaReal As String)

        oAjusGDG.UpdateStatusAjustesAutomaticosPendientes(CodArticulo, TallaReal)

    End Sub


#End Region




End Class
