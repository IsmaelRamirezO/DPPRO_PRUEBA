Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
'Imports NITGEN.SDK.NBioBSP
Imports System.IO

Public Class FingerPrintManager

    Private oApplicationContext As ApplicationContext
    Private oConfigCierreFI As SaveConfigArchivos
    Private oFingerPrintDG As FingerPrintDataGateWay
    Private m_strFilePath As String = "C:\BDFingerPrint\BDFP.ISDB"
    Private m_strFilePath2 As String = "C:\BDFingerPrint\BDFP.FDB"
    'Private m_NBioApi As New NBioAPI
    'Private m_NSearch As New NBioAPI.NSearch(m_NBioApi)
    'Private m_IndexSearch As New NBioAPI.IndexSearch(m_NBioApi)
    Dim res As UInt32


#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos
        Get
            Return oConfigCierreFI
        End Get
    End Property

    Public ReadOnly Property FilePath() As String
        Get
            Return m_strFilePath
        End Get
    End Property

#End Region

#Region "Constructor / Destructor"

    Public Sub New(ByVal application As ApplicationContext, ByVal ConfigCierreFI As SaveConfigArchivos)

        oApplicationContext = application
        oConfigCierreFI = ConfigCierreFI
        'oFingerPrintDG = New FingerPrintDataGateWay(Me)

        'res = m_IndexSearch.InitEngine()

        'If res.ToString <> "0" Then
        '    MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Information, "Dportenis PRO")
        'End If

        'res = m_NSearch.InitEngine()

        'If res.ToString <> "0" Then
        '    MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Information, "Dportenis PRO")
        'End If


    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oFingerPrintDG = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As FingerPrint

        Dim oFP As FingerPrint

        oFP = New FingerPrint(Me)

        Return oFP

    End Function

    'Public Function GetCongif(ByVal param As String) As String

    '    oFingerPrintDG = New FingerPrintDataGateWay(Me)

    '    Return oFingerPrintDG.SelectConfig(param)

    'End Function

    Public Function IsClientePGEnFactura(ByVal ClienteID As Integer, ByRef FolioSAP As String) As Boolean

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.SelectVentasPGByClienteID(ClienteID, FolioSAP)

    End Function

    Public Function Load(ByVal UserID As Long) As FingerPrint

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.SelectByID(UserID)

    End Function

    Public Function LoadByClienteID(ByVal IDCliente As String) As FingerPrint

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.SelectByClienteID(IDCliente)

    End Function

    Public Function GetClientesIDs(ByVal UnicoID As Int64) As DataTable

        Dim dtIDs As New DataTable
        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        dtIDs = oFingerPrintDG.GetClienteIDs(UnicoID)

        Return dtIDs

    End Function

    Public Function LoadFP() As DataSet

        Dim dsHuellas As New DataSet

        dsHuellas = oFingerPrintDG.ObtenerHuellas

        Return dsHuellas

    End Function

    Public Function LoadTodayFP() As DataSet

        Dim dsHuellasHoy As New DataSet

        dsHuellasHoy = oFingerPrintDG.ObtenerHuellasHoy

        Return dsHuellasHoy

    End Function

    Public Sub Save(ByRef oFingerP As FingerPrint, ByVal TipoVenta As String, ByVal NumDatos As Integer)

        If oFingerP.IsNew = True Then
            oFingerPrintDG.GuardarCliente(oFingerP, TipoVenta, NumDatos)
            oFingerPrintDG.GuardarHuella(oFingerP)
        Else
            oFingerPrintDG.Update(oFingerP, TipoVenta, NumDatos)
        End If

    End Sub

    Public Function SaveClienteVenta(ByVal oFactura As Factura) As Boolean

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.GuardarClienteVenta(oFactura)

    End Function

    Public Sub SaveAutorizacion(ByVal Usuario As String, ByVal Nombre As String, ByVal Modulo As String, ByVal Tienda As String, ByVal Caja As String)

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        oFingerPrintDG.SaveAutorizacion(Usuario, Nombre, Modulo, Tienda, Caja)

    End Sub

    Public Function CancelaClienteVenta(ByVal FolioSAP As String, ByVal FCFolioSAP As String, ByVal FCFolioFISAP As String) As Boolean

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.ClienteVentaUpdate(FolioSAP, FCFolioSAP, FCFolioFISAP)

    End Function

    Public Function SaveClienteDevolucion(ByVal oNotaCredito As NotaCredito, ByVal FolioSAP As String) As Boolean

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.GuardarClienteDevolucion(oNotaCredito, FolioSAP)

    End Function

    Public Function GetIDClient(ByVal IDUser As Integer) As String

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.SelectByUser(IDUser)

    End Function

    Public Function GetUserID() As Long

        oFingerPrintDG = New FingerPrintDataGateWay(Me)

        Return oFingerPrintDG.SelectUserID

    End Function

    'Busqueda de huella digital para cuando es una huella por id de cliente
    '    Private Function BuscarHuella2() As String 'Finger

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        Dim txtCapFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim bolDescarga As Boolean = False
    '        Dim ClienteID As String = ""

    '        Try

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then
    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin
    '            End If

    '            m_IndexSearch.ClearDB()
    '            m_IndexSearch.LoadDBFromFile(Me.FilePath)

    '            m_NBioApi.OpenDevice(m_NBioApi.Type.DEVICE_ID.AUTO)
    '            res = m_NBioApi.Capture(capFIR)
    '            m_NBioApi.CloseDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '            If res.ToString = "516" Then

    '                MsgBox("Error al escanear la huella, favor de intentarlo nuevamente.", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                GoTo Fin

    '            ElseIf res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '            Else

    '                m_NBioApi.OpenDevice(m_NBioApi.Type.DEVICE_ID.AUTO)
    '                m_NBioApi.GetTextFIRFromHandle(capFIR, txtCapFIR, True)
    '                m_NBioApi.CloseDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '            End If

    'Reintentar:
    '            Dim cbInfo0 As New NBioAPI.IndexSearch.CALLBACK_INFO_0

    '            Dim fpInfo As NBioAPI.IndexSearch.FP_INFO

    '            res = m_IndexSearch.IdentifyData(capFIR, Convert.ToUInt32(NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL), fpInfo, cbInfo0)

    '            If res.ToString = "0" Then

    '                ClienteID = fpInfo.ID.ToString.PadLeft(10, "0")

    '            ElseIf res.ToString = "1286" Then

    '                If bolDescarga = True Then
    '                    MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                Else
    '                    bolDescarga = True
    '                    Me.DescargarHuellas()
    '                    m_IndexSearch.LoadDBFromFile(Me.FilePath)
    '                    GoTo Reintentar
    '                End If

    '            End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("Ocurrió un error al buscar al cliente mediante la huella digital", ex)

    '        End Try
    'Fin:
    '        Return ClienteID

    '    End Function

    'Busqueda de huella digital para cuando una misma huella tiene diferentes id de clientes
    '    Private Function BuscarHuella3() As DataTable

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        'Dim txtCapFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim dtClientesID As DataTable
    '        Dim bolDescarga As Boolean = False

    '        Try

    '            Me.CreaEsctructuraTabla(dtClientesID)

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then
    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin
    '            End If

    '            m_NSearch.ClearDB()
    '            m_NSearch.LoadDBFromFile(m_strFilePath2)

    '            m_NBioApi.OpenDevice(m_NBioApi.Type.DEVICE_ID.AUTO)
    '            res = m_NBioApi.Capture(capFIR)
    '            m_NBioApi.CloseDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '            If res.ToString = "516" Then

    '                MsgBox("Error al escanear la huella, favor de intentarlo nuevamente.", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                GoTo Fin

    '            ElseIf res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '                'Else

    '                '    m_NBioApi.OpenDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '                '    m_NBioApi.GetTextFIRFromHandle(capFIR, txtCapFIR, True)

    '                '    m_NBioApi.CloseDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '            End If

    '            Dim candidate As NBioAPI.NSearch.CANDIDATE()
    '            Dim candInfo As NBioAPI.NSearch.CANDIDATE
    'Reintentar:
    '            'Search FIR to NSearch DB
    '            candidate = Nothing
    '            candInfo = Nothing
    '            res = m_NSearch.SearchData(capFIR, candidate)
    '            If res.ToString = "0" Then
    '                'Add item to list of result
    '                Dim oRow As DataRow
    '                Dim IDs As String = ""
    '                For Each candInfo In candidate   ' CandidateList or Result object
    '                    If candInfo.ID.ToString.Trim <> "0" AndAlso InStr(IDs, candInfo.ID.ToString.Trim) <= 0 Then
    '                        oRow = dtClientesID.NewRow
    '                        oRow!ClienteID = Me.GetIDClient(candInfo.ID.ToString.Trim).Trim
    '                        dtClientesID.Rows.Add(oRow)
    '                        IDs &= candInfo.ID.ToString.Trim & ","
    '                    End If
    '                Next
    '                dtClientesID.AcceptChanges()

    '                If dtClientesID.Rows.Count <= 0 Then
    '                    If bolDescarga = True Then
    '                        MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                    Else
    '                        bolDescarga = True
    '                        Me.DescargarHuellas2()
    '                        m_NSearch.LoadDBFromFile(m_strFilePath2)
    '                        GoTo Reintentar
    '                    End If
    '                End If
    '            Else
    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin
    '            End If

    '        Catch ex As Exception
    '            Throw New ApplicationException("Ocurrió un error al buscar al cliente mediante la huella digital", ex)
    '        End Try
    'Fin:
    '        Return dtClientesID

    '    End Function

    '    'Busqueda de huella digital para cuando es una huella por id de cliente mejorado
    '    Public Function BuscarHuella(Optional ByRef Encontrada As Boolean = True) As DataTable

    '        Dim capFIR As NBioAPI.Type.HFIR
    '        Dim dtClientesID As New DataTable
    '        Dim bolDescarga As Boolean = False
    '        Dim UnicoID As Int64

    '        Try

    '            'Me.CreaEsctructuraTabla(dtClientesID)

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then
    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin
    '            End If

    '            m_IndexSearch.ClearDB()
    '            m_IndexSearch.LoadDBFromFile(FilePath)

    '            m_NBioApi.OpenDevice(m_NBioApi.Type.DEVICE_ID.AUTO)
    '            res = m_NBioApi.Capture(capFIR)
    '            m_NBioApi.CloseDevice(m_NBioApi.Type.DEVICE_ID.AUTO)

    '            If res.ToString = "516" Then

    '                MsgBox("Error al escanear la huella, favor de intentarlo nuevamente.", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                GoTo Fin

    '            ElseIf res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo Fin

    '            ElseIf res.ToString = "513" Then

    '                GoTo Fin

    '            End If

    '            Dim cbInfo0 As New NBioAPI.IndexSearch.CALLBACK_INFO_0
    '            Dim fpInfo As NBioAPI.IndexSearch.FP_INFO
    'Reintentar:

    '            res = m_IndexSearch.IdentifyData(capFIR, Convert.ToUInt32(NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL), fpInfo, cbInfo0)

    '            If res.ToString = "0" Then

    '                UnicoID = Convert.ToInt64(fpInfo.ID.ToString.Trim)
    '                dtClientesID = Me.GetClientesIDs(UnicoID).Copy

    '            ElseIf res.ToString = "1286" Then

    '                If bolDescarga = True Then
    '                    MsgBox("La huella no ha sido registrada", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                    Encontrada = False
    '                Else
    '                    bolDescarga = True
    '                    DescargarHuellas()
    '                    m_IndexSearch.LoadDBFromFile(FilePath)
    '                    GoTo Reintentar
    '                End If

    '            End If

    '        Catch ex As Exception
    '            Throw New ApplicationException("Ocurrió un error al buscar al cliente mediante la huella digital", ex)
    '        End Try
    'Fin:
    '        Return dtClientesID

    '    End Function

    Private Sub CreaEsctructuraTabla(ByRef dtTemp As DataTable)

        dtTemp = New DataTable("ClientesID")

        Dim oNewCol As DataColumn

        oNewCol = New DataColumn("ClienteID", Type.GetType("System.String"))
        oNewCol.DefaultValue = ""

        dtTemp.Columns.Add(oNewCol)

        dtTemp.AcceptChanges()

    End Sub

    'Descarga de huellas para cuando una huella tiene asignado solo un id de cliente
    'Public Sub DescargarHuellas()

    '    Dim txtSavedFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '    Dim dsHuellas As New DataSet
    '    Dim Path As String = "C:\BDFingerPrint"
    '    Dim FilePath As String = Path & "\BDFP.ISDB"
    '    Dim fpinfo As NBioAPI.IndexSearch.FP_INFO()

    '    m_IndexSearch.ClearDB()

    '    If Not Directory.Exists(Path) Then
    '        MkDir(Path)
    '    End If
    '    If Not File.Exists(FilePath) Then
    '        dsHuellas = Me.LoadFP
    '    Else
    '        dsHuellas = Me.LoadTodayFP
    '        m_IndexSearch.LoadDBFromFile(FilePath)
    '    End If

    '    For Each oRow As DataRow In dsHuellas.Tables(0).Rows

    '        txtSavedFIR.TextFIR = oRow!Template

    '        'm_IndexSearch.RemoveUser(Convert.ToUInt32(Me.GetIDClient(oRow!ID_User)))
    '        m_IndexSearch.RemoveUser(Convert.ToUInt32(oRow!ID_User))
    '        Try
    '            'res = m_IndexSearch.AddFIR(txtSavedFIR, Convert.ToUInt32(Me.GetIDClient(oRow!ID_User)), fpinfo)
    '            res = m_IndexSearch.AddFIR(txtSavedFIR, Convert.ToUInt32(oRow!ID_User), fpinfo)
    '        Catch ex As Exception
    '        End Try

    '        If res.ToString <> "0" AndAlso res.ToString <> "1287" Then

    '            'MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis Pro")
    '            'Exit Sub

    '        End If

    '    Next

    '    If File.Exists(FilePath) Then

    '        File.Delete(FilePath)

    '    End If

    '    m_IndexSearch.SaveDBToFile(FilePath)

    '    m_IndexSearch.ClearDB()

    'End Sub

    'Descarga las huellas para cuando una misma huella tiene asignados muchos ids de clientes

    'Public Sub DescargarHuellas2()

    '    Dim txtSavedFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '    Dim dsHuellas As New DataSet
    '    Dim Path As String = "C:\BDFingerPrint"
    '    Dim FilePath As String = Path & "\BDFP.FDB"
    '    Dim fpinfo As NBioAPI.NSearch.FP_INFO()

    '    m_NSearch.ClearDB()

    '    If Not Directory.Exists(Path) Then
    '        MkDir(Path)
    '    End If
    '    If Not File.Exists(FilePath) Then
    '        dsHuellas = Me.LoadFP
    '    Else
    '        dsHuellas = Me.LoadTodayFP
    '        m_NSearch.LoadDBFromFile(FilePath)
    '    End If

    '    Dim ClienteID As String = ""

    '    For Each oRow As DataRow In dsHuellas.Tables(0).Rows

    '        txtSavedFIR.TextFIR = oRow!Template

    '        'm_NSearch.RemoveUser(Convert.ToUInt32(Me.GetIDClient(oRow!ID_User)))
    '        m_NSearch.RemoveUser(Convert.ToUInt32(CLng(oRow!ID_User)))
    '        Try
    '            'res = m_NSearch.AddFIR(txtSavedFIR, Convert.ToUInt32(Me.GetIDClient(oRow!ID_User)), fpinfo)
    '            res = m_NSearch.AddFIR(txtSavedFIR, Convert.ToUInt32(CLng(oRow!ID_User)), fpinfo)
    '        Catch ex As Exception
    '        End Try

    '        If res.ToString <> "0" AndAlso res.ToString <> "1287" Then

    '            'MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis Pro")
    '            'Exit Sub

    '        End If

    '    Next

    '    If File.Exists(FilePath) Then File.Delete(FilePath)

    '    m_NSearch.SaveDBToFile(FilePath)

    '    m_NSearch.ClearDB()

    'End Sub

    'Guardado de huella cuando solo se le asigna un id de cliente
    '    Private Sub GuardarHuella2(ByVal ClienteID As String, ByVal EsClienteSAP As Boolean, ByVal TipoVenta As String, ByVal NumDatos As Integer)

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        Dim txtFIR As NBioAPI.Type.FIR_TEXTENCODE
    '        Dim oFingerP As FingerPrint

    '        Try
    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then

    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            End If

    '            m_IndexSearch.ClearDB()
    '            If Not File.Exists(Me.FilePath) Then
    '                Me.DescargarHuellas()
    '            End If
    '            m_IndexSearch.LoadDBFromFile(Me.FilePath)

    '            oFingerP = Me.LoadByClienteID(Trim(ClienteID).PadLeft(10, "0"))

    '            If oFingerP.IsNew = False Then

    '                If MsgBox("El cliente " & Trim(ClienteID) & " ya tiene la huella registrada" & _
    '                          vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '                          "Dportenis PRO") = MsgBoxResult.No Then

    '                    GoTo fin

    '                End If

    '            End If
    'GuardarHuella:
    '            Dim m_WinOption As New NBioAPI.Type.WINDOW_OPTION

    '            m_WinOption.CaptionMsg = "Cancelar"
    '            m_WinOption.CancelMsg = "¿Estas seguro de cancelar el registro de la huella?"
    '            m_WinOption.WindowStyle = Convert.ToUInt32(NBioAPI.Type.WINDOW_STYLE.NO_WELCOME)
    '            m_NBioApi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            'res = m_NBioApi.Enroll(NewFIR, Nothing)
    '            res = m_NBioApi.Enroll(CType(Nothing, NBioAPI.Type.HFIR), NewFIR, Nothing, NBioAPI.Type.TIMEOUT.DEFAULT, Nothing, m_WinOption)

    '            m_NBioApi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin

    '            ElseIf res.ToString = "513" Then

    '                If Me.ConfigCierreFI.HuellaOpcional = False Then
    '                    MsgBox("Es necesario guardar la huella digital", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                    GoTo GuardarHuella
    '                Else
    '                    GoTo Fin
    '                End If

    '            Else

    '                Dim fpInfo() As NBioAPI.IndexSearch.FP_INFO
    '                m_NBioApi.GetTextFIRFromHandle(NewFIR, txtFIR, True)

    '                If Not oFingerP.IsNew Then
    'Remove:
    '                    m_IndexSearch.RemoveUser(Convert.ToUInt32(ClienteID))
    '                End If

    '                m_IndexSearch.AddFIR(txtFIR, Convert.ToUInt32(ClienteID), fpInfo)
    '                If fpInfo Is Nothing Then
    '                    GoTo Remove
    '                End If
    '                If File.Exists(Me.FilePath) Then
    '                    File.Delete(FilePath)
    '                End If
    '                m_IndexSearch.SaveDBToFile(Me.FilePath)

    '                oFingerP.IDCliente = Trim(ClienteID).PadLeft(10, "0")
    '                oFingerP.FingerID = fpInfo(0).FingerID
    '                oFingerP.SampleNum = fpInfo(0).SampleNumber
    '                oFingerP.Template = txtFIR.TextFIR
    '                oFingerP.EsClienteSAP = EsClienteSAP

    '                Me.Save(oFingerP, TipoVenta, NumDatos)

    '            End If

    '        Catch ex As Exception

    '            Throw New ApplicationException("No se pudo guardar la huella digital.", ex)

    '        End Try
    'Fin:
    '        'oMontarURed.Desconecta()
    '        'oMontarURed = Nothing

    '    End Sub

    '    'Guardado de huella cuando se le asignan muchos id de clientes a una misma
    '    Private Sub GuardarHuella3(ByVal ClienteID As String, ByVal EsClienteSAP As Boolean, ByVal TipoVenta As String, ByVal NumDatos As Integer, ByRef strError As String, _
    '                             Optional ByRef oCapFingerP As FingerPrint = Nothing)

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        Dim txtFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '        Dim oFingerP As FingerPrint
    '        Dim fpinfo As NBioAPI.NSearch.FP_INFO()

    '        Try
    '            If Not oCapFingerP Is Nothing AndAlso oCapFingerP.IsNew = True Then
    '                oFingerP = oCapFingerP
    '                oFingerP.IDCliente = ClienteID
    '                oFingerP.EsClienteSAP = EsClienteSAP
    '                txtFIR.TextFIR = oFingerP.Template
    '                GoTo GuardarSinEnroll
    '            End If

    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then
    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin
    '            End If

    '            m_NSearch.ClearDB()

    '            If Not File.Exists(m_strFilePath2) Then Me.DescargarHuellas2()

    '            m_NSearch.LoadDBFromFile(m_strFilePath2)

    '            oFingerP = Me.LoadByClienteID(Trim(ClienteID).PadLeft(10, "0"))

    '            'If oFingerP.IsNew = False Then
    '            '    If MsgBox("El cliente " & Trim(ClienteID) & " ya tiene la huella registrada" & _
    '            '              vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '            '              "Dportenis PRO") = MsgBoxResult.No Then
    '            '        GoTo fin
    '            '    End If
    '            'End If
    'GuardarHuella:
    '            Dim m_WinOption As New NBioAPI.Type.WINDOW_OPTION
    '            m_WinOption.Option2 = New NBioAPI.Type.WINDOW_OPTION_2

    '            m_WinOption.CaptionMsg = "Cancelar"
    '            m_WinOption.CancelMsg = "¿Estas seguro de cancelar el registro de la huella?"
    '            m_WinOption.WindowStyle = Convert.ToUInt32(NBioAPI.Type.WINDOW_STYLE.NO_WELCOME)
    '            'Select finger for enrollment
    '            m_WinOption.Option2.DisableFingerForEnroll(0) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(1) = Convert.ToByte(NBioAPI.Type.FALSE)
    '            m_WinOption.Option2.DisableFingerForEnroll(2) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(3) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(4) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(5) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(6) = Convert.ToByte(NBioAPI.Type.FALSE)
    '            m_WinOption.Option2.DisableFingerForEnroll(7) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(8) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(9) = Convert.ToByte(NBioAPI.Type.TRUE)

    '            m_NBioApi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)
    '            res = m_NBioApi.Enroll(CType(Nothing, NBioAPI.Type.HFIR), NewFIR, Nothing, NBioAPI.Type.TIMEOUT.DEFAULT, Nothing, m_WinOption)
    '            m_NBioApi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                strError = NBioAPI.Error.GetErrorDescription(res).Trim
    '                GoTo fin

    '            ElseIf res.ToString = "513" Then

    '                If Me.ConfigCierreFI.HuellaOpcional = False Then
    '                    MsgBox("Es necesario guardar la huella digital", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                    GoTo GuardarHuella
    '                Else
    '                    GoTo Fin
    '                End If

    '            Else

    '                m_NBioApi.GetTextFIRFromHandle(NewFIR, txtFIR, True)
    'GuardarSinEnroll:
    '                If oFingerP.IsNew = False Then
    'Remove:
    '                    m_NSearch.RemoveUser(Convert.ToUInt32(oFingerP.UserID))
    '                    'Else
    '                    '    oFingerP.UserID = Me.GetUserID
    '                End If

    '                'Guardar Huella en el servidor
    '                If oCapFingerP Is Nothing Then
    '                    oFingerP.IDCliente = Trim(ClienteID).PadLeft(10, "0")
    '                    oFingerP.EsClienteSAP = EsClienteSAP
    '                End If

    '                Me.Save(oFingerP, TipoVenta, NumDatos)

    '                ' Regist FIR to NSearch DB
    '                res = m_NSearch.AddFIR(txtFIR, Convert.ToUInt32(oFingerP.UserID), fpinfo)
    '                If (res.ToString = "0") Then
    '                    If fpinfo Is Nothing Then GoTo Remove

    '                    If oCapFingerP Is Nothing Then
    '                        oFingerP.FingerID = fpinfo(0).FingerID
    '                        oFingerP.SampleNum = fpinfo(0).SampleNumber
    '                        oFingerP.Template = txtFIR.TextFIR
    '                        Me.Save(oFingerP, TipoVenta, NumDatos)
    '                        oCapFingerP = oFingerP
    '                    End If

    '                    If File.Exists(m_strFilePath2) Then File.Delete(m_strFilePath2)
    '                    m_NSearch.SaveDBToFile(m_strFilePath2)
    '                Else
    '                    strError = NBioAPI.Error.GetErrorDescription(res).Trim
    '                    GoTo Fin
    '                End If

    '            End If

    '        Catch ex As Exception
    '            'Throw New ApplicationException("No se pudo guardar la huella digital.", ex)
    '            strError = ex.ToString.Trim
    '        End Try
    'Fin:
    '    End Sub

    'Guardado de huella cuando solo se le asigna un id de cliente mejorado
    '    Public Sub GuardarHuella(ByVal ClienteID As String, ByVal EsClienteSAP As Boolean, ByVal TipoVenta As String, ByVal NumDatos As Integer, ByRef strError As String, _
    '                             ByVal bGuardarBD As Boolean, Optional ByRef oCapFingerP As FingerPrint = Nothing)

    '        Dim NewFIR As NBioAPI.Type.HFIR
    '        Dim txtFIR As New NBioAPI.Type.FIR_TEXTENCODE
    '        Dim oFingerP As FingerPrint

    '        Try
    '            Dim nNumDevice As UInt32
    '            Dim nDeviceID() As Short
    '            Dim deviceInfoEx() As NBioAPI.Type.DEVICE_INFO_EX

    '            m_NBioApi.EnumerateDevice(nNumDevice, nDeviceID, deviceInfoEx)

    '            If nNumDevice.ToString = "0" Then
    '                MsgBox("No se encontró el lector de huellas digitales, Favor de conectarlo", MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                GoTo fin
    '            End If

    '            m_IndexSearch.ClearDB()

    '            If Not File.Exists(m_strFilePath) Then Me.DescargarHuellas()

    '            m_IndexSearch.LoadDBFromFile(m_strFilePath)

    '            If Not oCapFingerP Is Nothing AndAlso oCapFingerP.IsNew = True Then
    '                oFingerP = oCapFingerP
    '                oFingerP.IDCliente = ClienteID
    '                oFingerP.EsClienteSAP = EsClienteSAP
    '                txtFIR.TextFIR = oFingerP.Template
    '                GoTo GuardarSinEnroll
    '            End If

    '            oFingerP = Me.LoadByClienteID(Trim(ClienteID).PadLeft(10, "0"))

    '            'If oFingerP.IsNew = False Then
    '            '    If MsgBox("El cliente " & Trim(ClienteID) & " ya tiene la huella registrada" & _
    '            '              vbLf & "¿Desea registrarla de nuevo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
    '            '              "Dportenis PRO") = MsgBoxResult.No Then
    '            '        GoTo fin
    '            '    End If
    '            'End If
    'GuardarHuella:
    '            Dim m_WinOption As New NBioAPI.Type.WINDOW_OPTION
    '            m_WinOption.Option2 = New NBioAPI.Type.WINDOW_OPTION_2

    '            m_WinOption.CaptionMsg = "Cancelar"
    '            m_WinOption.CancelMsg = "¿Estas seguro de cancelar el registro de la huella?"
    '            m_WinOption.WindowStyle = Convert.ToUInt32(NBioAPI.Type.WINDOW_STYLE.NO_WELCOME)
    '            'Select finger for enrollment
    '            m_WinOption.Option2.DisableFingerForEnroll(0) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(1) = Convert.ToByte(NBioAPI.Type.FALSE)
    '            m_WinOption.Option2.DisableFingerForEnroll(2) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(3) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(4) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(5) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(6) = Convert.ToByte(NBioAPI.Type.FALSE)
    '            m_WinOption.Option2.DisableFingerForEnroll(7) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(8) = Convert.ToByte(NBioAPI.Type.TRUE)
    '            m_WinOption.Option2.DisableFingerForEnroll(9) = Convert.ToByte(NBioAPI.Type.TRUE)

    '            m_NBioApi.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO)
    '            res = m_NBioApi.Enroll(CType(Nothing, NBioAPI.Type.HFIR), NewFIR, Nothing, NBioAPI.Type.TIMEOUT.DEFAULT, Nothing, m_WinOption)
    '            m_NBioApi.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO)

    '            If res.ToString <> "0" AndAlso res.ToString <> "513" Then

    '                MsgBox(NBioAPI.Error.GetErrorDescription(res), MsgBoxStyle.Exclamation, "Dportenis PRO")
    '                strError = NBioAPI.Error.GetErrorDescription(res).Trim
    '                GoTo fin

    '            ElseIf res.ToString = "513" Then

    '                'If Me.oConfigCierreFI.HuellaOpcional = False Then
    '                '    MsgBox("Es necesario guardar la huella digital", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                '    GoTo GuardarHuella
    '                'Else
    '                '    GoTo Fin
    '                'End If
    '                GoTo Fin

    '            Else

    '                Dim fpInfo() As NBioAPI.IndexSearch.FP_INFO
    '                m_NBioApi.GetTextFIRFromHandle(NewFIR, txtFIR, True)
    'GuardarSinEnroll:
    '                If oFingerP.IsNew = False OrElse Not oCapFingerP Is Nothing Then
    'Remove:
    '                    m_IndexSearch.RemoveUser(Convert.ToUInt32(oFingerP.UserID))
    '                    'Else
    '                    '    oFingerP.UserID = Me.GetUserID
    '                End If

    '                'Guardar Huella en el servidor
    '                If oCapFingerP Is Nothing Then
    '                    oFingerP.IDCliente = Trim(ClienteID).PadLeft(10, "0")
    '                    oFingerP.EsClienteSAP = EsClienteSAP
    '                End If

    '                If bGuardarBD Then
    '                    Me.Save(oFingerP, TipoVenta, NumDatos)
    '                End If

    '                'If oCapFingerP Is Nothing Then
    '                If Not oCapFingerP Is Nothing Then
    '                    res = m_IndexSearch.AddFIR(txtFIR, Convert.ToUInt32(oFingerP.UserID), fpInfo)
    '                Else
    '                    res = Convert.ToUInt32(0)
    '                End If
    '                If (res.ToString = "0") Then
    '                    'If fpInfo Is Nothing AndAlso Not NewFIR Is Nothing Then GoTo Remove
    '                    If fpInfo Is Nothing AndAlso Not oCapFingerP Is Nothing Then GoTo Remove

    '                    If oCapFingerP Is Nothing Then
    '                        oFingerP.Template = txtFIR.TextFIR
    '                        'oCapFingerP = oFingerP
    '                    Else
    '                        oFingerP.FingerID = fpInfo(0).FingerID
    '                        oFingerP.SampleNum = fpInfo(0).SampleNumber
    '                        'oFingerP.Template = txtFIR.TextFIR
    '                        If bGuardarBD Then Me.Save(oFingerP, TipoVenta, NumDatos)
    '                        'oCapFingerP = oFingerP
    '                    End If

    '                    oCapFingerP = oFingerP

    '                    If File.Exists(m_strFilePath) Then File.Delete(m_strFilePath)
    '                    m_IndexSearch.SaveDBToFile(m_strFilePath)
    '                Else
    '                    strError = NBioAPI.Error.GetErrorDescription(res).Trim
    '                    GoTo Fin
    '                End If

    '            End If

    '        Catch ex As Exception
    '            'Throw New ApplicationException("No se pudo guardar la huella digital.", ex)
    '            strError = ex.ToString.Trim
    '        End Try
    'Fin:
    '    End Sub

#End Region

End Class
