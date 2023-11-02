
Imports DportenisPro.DPTienda.Core

Public Class ValeCajaManager

    Private oApplicationContext As ApplicationContext
    Private oValeCajaDG As ValeCajaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oValeCajaDG = New ValeCajaDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oValeCajaDG = Nothing

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

    Public Function Create() As ValeCaja

        Dim oNuevoValeCaja As ValeCaja
        oNuevoValeCaja = New ValeCaja(Me)

        Return oNuevoValeCaja

    End Function



    Public Function Load(ByVal ID As Integer) As ValeCaja

        'If (ID = 0) Then
        '    Throw New ArgumentException("Debe especificar un Código de Vale de Caja")
        'End If


        Dim oReadedValeCaja As ValeCaja

        oReadedValeCaja = oValeCajaDG.SelectByID(ID)

        Return oReadedValeCaja

    End Function

    Public Function GetFolioFI(ByVal TipoDoc As String, ByVal Folio As String, ByRef FolioFIVta As String) As String

        oValeCajaDG = New ValeCajaDataGateway(Me)

        Return oValeCajaDG.SelectFolioFI(TipoDoc, Folio, FolioFIVta)

    End Function

    Public Sub Save(ByVal pValeCaja As ValeCaja)

        oValeCajaDG = New ValeCajaDataGateway(Me)

        If (pValeCaja Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Vale Caja no puede ser nulo.")
        End If

        If (pValeCaja.IsNew) Then

            oValeCajaDG.Insert(pValeCaja)

        Else

            oValeCajaDG.Update(pValeCaja)

        End If

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        oValeCajaDG = New ValeCajaDataGateway(Me)

        Return oValeCajaDG.SelectAll(EnabledRecordsOnly)

    End Function

    'Public Function GetByFolioDocumento(ByVal FolioDocumento As Integer, ByVal TipoDocumento As String) As DataSet

    '    Return oValeCajaDG.SelectByFolioDocumento(FolioDocumento, TipoDocumento)

    'End Function

    Public Function GetByFolioDocumento(ByVal FolioDocumento As String) As ValeCaja

        oValeCajaDG = New ValeCajaDataGateway(Me)

        Return oValeCajaDG.SelectByFolioDocumento(FolioDocumento)

    End Function

    Public Function GetByValeCajaId(ByVal ValeCajaId As Integer) As ValeCaja
        oValeCajaDG = New ValeCajaDataGateway(Me)
        Return oValeCajaDG.GetByValeCajaId(ValeCajaId)
    End Function

    Public Sub Delete(ByVal ValeCajaID As Integer, ByVal TipoDocumento As String)
        If (ValeCajaID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Vale de Caja")
        ElseIf TipoDocumento = String.Empty Then
            Throw New ArgumentException("Debe especificar un Tipo de Documento")
        End If

        oValeCajaDG.Delete(ValeCajaID, TipoDocumento)
    End Sub

    Public Sub UpdateMontoToCero(ByVal ValeCajaID As Integer, ByVal TipoDocumento As String)
        If (ValeCajaID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Vale de Caja")
        ElseIf TipoDocumento = String.Empty Then
            Throw New ArgumentException("Debe especificar un Tipo de Documento")
        End If

        oValeCajaDG.UpdateMontoToCero(ValeCajaID, TipoDocumento)
    End Sub

    Public Sub UpdateFolioFITS(ByVal ValeCajaID As Integer, ByVal FolioFITS As String)

        oValeCajaDG = New ValeCajaDataGateway(Me)

        oValeCajaDG.UpdateFolioFITS(ValeCajaID, FolioFITS)

    End Sub

    Public Function Folios() As Integer

        Return oValeCajaDG.Folios

    End Function

    Public Function SelectNCID(ByVal intFolioID As Integer) As String

        Return oValeCajaDG.SelectNCID(intFolioID)

        oValeCajaDG = Nothing

    End Function


    Public Function DevEfvoVal(ByVal strComandSQL As String, ByVal strTabla As String) As DataSet

        Return oValeCajaDG.DevEfvoVal(strComandSQL, strTabla)

    End Function

#End Region

#Region "Facturacion SiHay"

    Public Function ActualizarDocumentoFIValeCaja(ByVal ValeCajaID As Integer, ByVal DocFI As String)
        Dim vale As New ValeCajaDataGateway(Me)
        vale.ActualizarDocumentoFIValeCaja(ValeCajaID, DocFI)
    End Function

#End Region

End Class
