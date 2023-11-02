
Option Explicit On 

Imports DportenisPro.DpTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU



Public Class DefectuososManager

    Private oApplicationContext As ApplicationContext
    Private oDefectuososDG As DefectuososDataGateway
    Dim oSAPConfiguration As SAPApplicationConfig


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration

        oDefectuososDG = New DefectuososDataGateway(Me)

    End Sub


    Public Sub dispose()

        MyBase.Finalize()

        oDefectuososDG = Nothing

    End Sub

#End Region


#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig
        Get
            Return oSAPConfiguration
        End Get
    End Property

#End Region


#Region "Methods"

    Public Function Create() As Defectuoso

        Dim oNuevoDefectuoso As Defectuoso
        oNuevoDefectuoso = New Defectuoso(Me)

        Return oNuevoDefectuoso

    End Function

    Public Function Load(ByVal ID As Integer) As Defectuoso

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un folio de Defectuoso.")
        End If

        If (ID < 0) Then
            Throw New ArgumentException("El folio del Defectuoso debe ser mayor a cero.")
        End If

        Dim oReadedDefectuoso As Defectuoso

        oReadedDefectuoso = oDefectuososDG.SelectByID(ID)

        Return oReadedDefectuoso

    End Function

    Public Sub LoadInto(ByVal ID As Integer, ByVal oDefectuoso As Defectuoso)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un folio de Defectuoso.")
        End If

        If (ID < 0) Then
            Throw New ArgumentException("El folio del Defectuoso debe ser mayor a cero.")
        End If

        oDefectuososDG.SelectByID(ID, oDefectuoso)

    End Sub

    Public Function Save(ByVal pDefectuoso As Defectuoso) As Integer

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        If (pDefectuoso.IsNew) Then
            'Verifico que exista información en el objeto
            If Not CheckValues(pDefectuoso) Then

                Save = oDefectuosoDG.Insert(pDefectuoso)

            Else

                MsgBox("Faltan datos por capturar en para el marcado del defectuoso.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Defectuosos")

            End If
        End If

    End Function

    Public Sub Delete(ByVal ID As Integer)

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        oDefectuosoDG.Delete(ID)

        oDefectuosoDG = Nothing

    End Sub

    Public Function GetDetailFactura(ByVal FolioFactura As Integer, ByVal CodCaja As String) As DataSet

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        Return oDefectuosoDG.LoadDataFactura(FolioFactura, CodCaja)

        oDefectuosoDG = Nothing

    End Function

    Public Function GetTallas(ByVal IDCorrida As String) As DataSet

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        Return oDefectuosoDG.LoadDataTallas(IDCorrida)

        oDefectuosoDG = Nothing

    End Function

    Public Function GetStock(ByVal CodAlmacen As String, _
                                ByVal CodArticulo As String, _
                                    ByVal Talla As String) As Integer


        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        Return oDefectuosoDG.LoadStock(CodAlmacen, CodArticulo, Talla)

        oDefectuosoDG = Nothing

    End Function

    Public Sub SaveMoveInOut(ByVal Codtipomov As Integer, _
                                ByVal TipoMovimiento As String, _
                                    ByVal Numero As String, _
                                        ByVal pDefectuoso As Defectuoso)

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        oDefectuosoDG.InsertMoveInOut(Codtipomov, TipoMovimiento, Numero, pDefectuoso)

    End Sub

    Public Function ListFactura(ByVal EnabledRecordOnly As Boolean, Optional ByVal strTipoVenta As String = "") As DataSet

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        Return oDefectuosoDG.LoadListFactura(EnabledRecordOnly, strTipoVenta)

        oDefectuosoDG = Nothing

    End Function

    Public Function LoadFacturaByID(ByVal FacturaID As Integer) As DataSet

        Dim oDefectuosoDG As DefectuososDataGateway
        oDefectuosoDG = New DefectuososDataGateway(Me)

        Return oDefectuosoDG.LoadFacturaByID(FacturaID)

        oDefectuosoDG = Nothing

    End Function

    Public Function GetAll(ByVal DefectuosID As Integer) As DataSet
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectAll(False)

        oDefectuososDG = Nothing

    End Function


    Public Function GetAllCodigos(ByVal EnabledRecordOnly As Boolean) As DataSet
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectAllCodigos(EnabledRecordOnly)

        oDefectuososDG = Nothing

    End Function

    Public Function GetDataGeneral(ByVal CodArticulo As String) As DataRow
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectDataGeneral(CodArticulo)

        oDefectuososDG = Nothing

    End Function

    Public Function GetDataDetail(ByVal CodArticulo As String) As DataRowCollection
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectDataDetail(CodArticulo)

        oDefectuososDG = Nothing

    End Function

    Public Function CheckValues(ByVal pDefectuoso As Defectuoso) As Boolean
        With pDefectuoso
            If .CodArticulo = String.Empty Then Return True
            If .Cantidad = 0 Then Return True
            If .Autorizo = String.Empty Then Return True
            If .CodAlmacen = String.Empty Then Return True
            If .CodCaja = String.Empty Then Return True
            If .DefectoNota = String.Empty Then Return True
            If .Usuario = String.Empty Then Return True
        End With
    End Function

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/03/2014: Actualiza en la base de datos Local los marcados
    '-------------------------------------------------------------------------------------------------------------------

    Public Sub UpdateDesmarcado(ByVal Folio As Integer, ByVal FIDOCUMENT As String)
        Dim oDefectuososDG As New DefectuososDataGateway(Me)
        oDefectuososDG.UpdateDesmarcado(Folio, FIDOCUMENT)
    End Sub

    Public Function DesmarcarDefectuosos(ByVal dsDefectuosos As DataSet, ByVal Cantidad As Integer, _
                                         ByVal strUser As String, ByVal bolDesmarcar As Boolean, Optional ByVal motivo As String = "0008", _
                                         Optional ByVal bDesmarcarEnSAP As Boolean = True, Optional ByVal bajaCalidad As Boolean = False) As Integer
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.DesmarcarDefectuosos(dsDefectuosos, Cantidad, strUser, bolDesmarcar, motivo, bDesmarcarEnSAP, bajaCalidad)

        oDefectuososDG = Nothing
    End Function

    '-------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 15/05/2018: Actualiza en la base de datos los artículos desmarcados
    '-------------------------------------------------------------------------------------------------------------------

    Public Sub ActualizarDesmarcado(ByVal dsDefectuosos As DataSet)
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)
        oDefectuososDG.ActualizarDesmarcado(dsDefectuosos)
        oDefectuososDG = Nothing
    End Sub



    Public Function SelectAllDefectuososG(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectAllDefectuososG(EnabledRecordsOnly)

        oDefectuososDG = Nothing

    End Function

    Public Function SelectAllDesmarcadosD(ByVal Folio As Integer) As DataRowCollection
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectAllDesmarcadosD(Folio)

        oDefectuososDG = Nothing

    End Function

    Public Function SelectAllDesmarcadosG(ByVal Folio As Integer) As DataRowCollection
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectAllDesmarcadosG(Folio)

        oDefectuososDG = Nothing

    End Function

    Public Function [SelectFolio]() As Integer

        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectFolio

        oDefectuososDG = Nothing

    End Function

    Public Function [SelectFolioDesmarcado]() As Integer

        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        Return oDefectuososDG.SelectFolioDesmarcado

        oDefectuososDG = Nothing

    End Function

#End Region

#Region "Bloqueos de Baja Calidad"

    Public Function GetBloqueadosECSiHay(ByVal CodArticulo As String) As DataTable
        Dim dtBloqueados As DataTable
        Dim oDefectuososDG As DefectuososDataGateway
        oDefectuososDG = New DefectuososDataGateway(Me)

        dtBloqueados = oDefectuososDG.GetBloqueadosECSiHay(CodArticulo)
        Return dtBloqueados
    End Function

#End Region


End Class
