Imports DPSoft.Framework
Imports DPSoft.Framework.ApplicationContext
Imports DPSoft.Framework.Configuration
Imports DPSoft.Framework.Data
Imports DPSoft.Framework.ExceptionReporting
Imports DPSoft.Framework.Security
Imports DportenisPro.DPTienda.Core.ApplicationContext
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports Microsoft.Win32
Imports System.Reflection
Imports System.Net
Imports MSXML2
Imports System.Text

Imports System.Web.Mail
Imports System.Web.Util
Imports System.Security.Authentication
Imports System.Collections.Generic

Module MainModule

    Const _Tls12 As SslProtocols = DirectCast(&HC00, SslProtocols)
    Const Tls12 As SecurityProtocolType = DirectCast(_Tls12, SecurityProtocolType)
    Public oAppContext As DportenisPro.DPTienda.Core.ApplicationContext

    Public oAppSAPConfig As New SAPApplicationConfig
    Public oConfigCierreFI As New SaveConfigArchivos
    Public oConfigFotos As New SaveConfigArchivos
    Public oSecurity As SecurityHash
    Public strDPTiendaPath As String = Application.ExecutablePath & ".cml"
    Private strSAPConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    Private strConfigurationFileFI As String = Application.StartupPath & "\configCierre.cml"
    Private strConfigurationFileFotos As String = Application.StartupPath & "\configFotos.cml"
    Public oLiveMgr As LiveUpdateManager
    Public strVersionSuc As String = "20220907" ' "20220328" ' "20210701" '2021040101" '"20210401" '"2021030101" '"20201000" '20201001 'Modificar tambien Lin 223; anterior 20190705; anterior 2020030101
    Dim strRutaCmls As String = ""
    Public bPedidosRefresh As Boolean = False
    Public gPedidos As Integer, gFacturas As Integer, gGuias As Integer, gCancelados As Integer 'Para mostrar en la pantalla principal en la parte del ecommerce
    Public gBloqueo As Boolean = False
    Dim ofrmSplash As New frmSplash
    Public DashBoard As HomeDash
    Dim oInicioDiaMgr As InicioDiaManager, oCierreCajaMgr As CierreCajaManager

#Region "VariablesSiHay"
    Public surtirSihay As Integer, facturarSiHay As Integer, sinGuiaSiHay As Integer, canceladoSiHay As Integer, recibirSiHay As Integer, insurtiblesSiHay
    Public FacturacionSiHay As Integer = -1
    Public PorcMasDescSH As Decimal = 0, ImporteMinimoSH As Decimal = 10000
#End Region

    Dim owsValidaDPVale As ControlDPValesWS.ControlDPVales
    Public owsDPValeInfo As ControlDPValesWS.DPValeInfo
    Dim oDpvaleSAP As cDPValeSAP

#Region "DPCard Puntos"

    Public Enum DPCardOperation As Integer
        ACTIVAR = 1
        AGREGAR = 2
        TRASPASO = 3
        CANJEAR = 4
        RENOVAR = 5
        CANJEARSIHAY = 6
    End Enum

    Public Enum Proveedor As Integer
        BLUE = 1
        KARUM = 2
    End Enum
#End Region

#Region "Consignacion"

    Public Enum TrasladoConsignacion As Integer
        ORDENCOMPRA = 1
        DEVOLUCION = 2
    End Enum

#End Region

    <STAThread()> _
    Public Sub Main()
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Revisamos que no haya corriendo otro porceso del DPTienda y de ser asi cerramos el actual
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------
        Try
            Dim oProcesos() As Process
            oProcesos = Process.GetProcessesByName("DPTienda")
            If oProcesos.Length >= 2 Then
                Exit Sub
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al revisar el proceso DPTienda.")
        End Try

        Dim bolResult As Boolean

        'TestCrearAlmacen()

        oAppContext = New DportenisPro.DPTienda.Core.ApplicationContext

        '<Agregar Handler de excepciones no controladas>
        AddHandler Application.ThreadException, AddressOf OnThreadException
        '</Agregar Handler de excepciones no controladas>
        ofrmSplash.Show()
        Application.DoEvents()
LoadSettings:
        Try

            oSecurity = New SecurityHash

            'strRutaCmls = GetRutaCmls()

            'strDPTiendaPath = strRutaCmls & "\DPTienda.exe.cml"
            DesencriptarCML(strDPTiendaPath)
            oAppContext.LoadSettings()
            'EncriptarCML(strDPTiendaPath)

        Catch oException As ConfigurationFileNotFoundException

            MsgBox("La aplicación no ha sido configurada.")
            oAppContext.ShowSettingsEditor()

            GoTo LoadSettings

            Exit Sub

        Catch oException As ConfigurationLoadFileException

            oAppContext.ExceptionReporting.HandleException(oException)
            Exit Sub

        Catch oException As Exception

            oAppContext.ExceptionReporting.HandleException(oException)
            Exit Sub

        End Try
        DesencriptarCML(Application.StartupPath & "\configSAP.cml")
        'DesencriptarCML(strRutaCmls & "\configSAP.cml")

        If Not LoadConfigSAP() Then

            MsgBox("Configuración SAP no existe o es incorrecta.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAP")
            Dim oSAPSystemForm As New SAPSystem
            oSAPSystemForm.ShowDialog()

        End If
        'EncriptarCML(Application.StartupPath & "\configSAP.cml")
        'EncriptarCML(strRutaCmls & "\configSAP.cml")
        DesencriptarCML(Application.StartupPath & "\configCierre.cml")
        'DesencriptarCML(Application.StartupPath & "\configFotos.cml")
        'DesencriptarCML(strRutaCmls & "\configCierre.cml")
        'DesencriptarCML(strRutaCmls & "\configFotos.cml")

        ''''****************************************
        CorrigeXML(Application.StartupPath & "\configCierre.cml")
        'CorrigeXML(Application.StartupPath & "\configFotos.cml")
        'CorrigeXML(strRutaCmls & "\configCierre.cml")
        'CorrigeXML(strRutaCmls & "\configFotos.cml")
        ''''****************************************

        If Not LoadConfigCierreFI() Then

            MsgBox("Configuración Carga Dias FI no existe o es incorrecta.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FI")
            Dim oConfigCierre As New FrmConfigCierreSAP
            oConfigCierre.ShowDialog()

        End If
        'If Not LoadConfigFotos() Then

        '    MsgBox("Configuración Descarga de Imagenes no existe o es incorrecta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Fotos")
        '    Dim oConfigFotos As New FrmConfigCierreSAP
        '    oConfigFotos.ShowDialog()

        'End If

        'EncriptarCML(Application.StartupPath & "\configFotos.cml")
        'EncriptarCML(Application.StartupPath & "\configCierre.cml")
        'EncriptarCML(strRutaCmls & "\configFotos.cml")
        'EncriptarCML(strRutaCmls & "\configCierre.cml")

        CrearArchivoConfigPinPad(Application.StartupPath & "\PinpadConfig.txt")

        GetConfigFromServer()

        EncriptarCML(Application.StartupPath & "\configSAP.cml")
        EncriptarCML(Application.StartupPath & "\configCierre.cml")
        EncriptarCML(strDPTiendaPath)

        '-------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (08.02.2017): Validamos que la version de actualizacion en la BD centralizada VersionesSucursales sea igual a la actual del DPPRO
        '-------------------------------------------------------------------------------------------------------------------------------------
        ValidaVersionDPPRO(strVersionSuc)
        '-------------------------------------------------------------------------------------------------------------------------------------

        '-------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (08.02.2017): Validamos que la version de actualizacion en la BD centralizada VersionesSucursales sea igual a la actual del DPPRO
        '-------------------------------------------------------------------------------------------------------------------------------------
        ActualizaVersionWindows_InstanciaSQL()
        '-------------------------------------------------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------------------
        ' JNAVA (06.10.2015): Se agrego configuracion ya que ahora la actualizacion se realiza despues de las descargas 
        '                     nocturnas y se adaptó para enviar correos de error
        '--------------------------------------------------------------------------------------------------------------------

        If oConfigCierreFI.EjecutarLiveUpdateInicio Then
            Dim strErrorAct As String = ""
            If Not VerificarVersion(strErrorAct) Then
                EnviarCorreos(strErrorAct, True)
                Exit Sub
            End If
        End If
        '--------------------------------------------------------------------------------------------------------------------

        strVersionSuc = "20220907" '"20220329" ' "20220328" ' "20210701" '"2021040101" '"20210401" '"2021030101" '"20201000"  '20201001

        If oConfigCierreFI.TPVVirtual Then

            RegisterApplicationUnits()

            If Not (oAppContext.Security.StartPrincipalSession()) Then
                End
            End If

            Dim frmPagoVirtual As New frmPagosVirtual()
            frmPagoVirtual.ShowDialog()
            'Dim ofrmTPVVirtual As New frmTPV
            'ofrmTPVVirtual.ShowDialog()
            End
        End If

        'If bolResult Then

        Try
            oAppContext.MainForm = New MainForm
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al inicializar el punto de venta")
            MessageBox.Show("Ocurrio un error al inicializar el punto de venta." & vbCrLf & "Favor de llamar a Soporte", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        RegisterApplicationUnits()

        'oFrmLoading.Close()
        'Application.DoEvents()

        'Dim oRep As New RptCierredeDia(Now)
        'oRep.Run()

        'Dim oRepView As New ReportViewerForm

        'oRepView.Report = oRep
        'oRepView.ShowDialog()

        If (oAppContext.Security.StartPrincipalSession()) Then
            '----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 26.09.2015: Revisamos si el usuario logueado ya necesita renovar su password por las politicas de seguridad
            '----------------------------------------------------------------------------------------------------------------------------------------
            oInicioDiaMgr = New InicioDiaManager(oAppContext)
            If oInicioDiaMgr.ValidaRenuevaPassword(oAppContext.Security.CurrentUser.ID) Then
                Dim oFrmRP As New frmRenuevaPassword
Renueva:
                If oFrmRP.ShowDialog <> DialogResult.OK Then
                    If MessageBox.Show("Es necesario renovar la contraseña para continuar." & vbCrLf & "¿Desea cancelar y salir de la aplicación?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        GoTo Renueva
                    Else
                        Exit Sub
                    End If
                End If
            End If
            oInicioDiaMgr = Nothing

            Application.Run(oAppContext)
            '------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 16.10.2015: Antes de salir revisamos si ya cerró caja para buscar nuevas versiones de la aplicación
            '------------------------------------------------------------------------------------------------------------------------------
            oCierreCajaMgr = New CierreCajaManager(oAppContext)
            If oCierreCajaMgr.ValidarCierreCaja(Today) = False Then
                Dim strErrorAct As String = ""
                If Not VerificarVersion(strErrorAct) Then EnviarCorreos(strErrorAct, True)
            End If

        End If

        'End If

    End Sub

    Public Function IsOpenFile(ByVal Filename As String) As Boolean
        Dim valid As Boolean = False
        Try
            If File.Exists(Filename) Then
                Dim file As New FileStream(Filename, FileMode.Open)
                file.Close()
            End If
        Catch ex As Exception
            valid = True
        End Try
        Return valid
    End Function

    Public Function EsCatalogo(Material As String) As Boolean
        Dim bRes As Boolean = False
        Dim oArticulo As Articulo, oArticuloMgr As New CatalogoArticuloManager(oAppContext)

        oArticulo = oArticuloMgr.Create
        oArticuloMgr.LoadInto(Material.Trim, oArticulo)
        If (Not oArticulo Is Nothing AndAlso oArticulo.CodArticulo.Trim <> "") AndAlso oArticulo.CodMarca.Trim.ToUpper = "DT" Then
            bRes = True
        End If

        Return bRes
    End Function

#Region "Configuracion"

    Private Sub GetConfigFromServer()

        'Dim ofrmSplash As New frmSplash
        Try
1:          Dim oFacturasMgr As New FacturaManager(oAppContext, oConfigCierreFI)
2:          Dim oSApReader As New SapConfigReader(strSAPConfigurationFile)
3:          Dim oReader As New SaveConfigArchivosReader(strConfigurationFileFI)
            Dim dtConfig As DataTable, i As Integer = 1

            'ofrmSplash.Show()

            'Application.DoEvents()

4:          dtConfig = oFacturasMgr.GetConfigFromServer()

            ofrmSplash.pbAvance.Maximum = dtConfig.Rows.Count + 6

5:          If dtConfig.Rows.Count > 0 Then
6:              For Each oRow As DataRow In dtConfig.Rows
                    ofrmSplash.lblTexto.Text = "Cargando Configuración... " & CStr(oRow!Parametro).Trim
                    Application.DoEvents()
7:                  ActualizaConfigGeneral(oRow)
                    ofrmSplash.pbAvance.Value = i
                    i += 1
                Next

                '------------------------------------------------------------------------
                'JNAVA (08.01.2016): agregamos texto del proceso actual
                '------------------------------------------------------------------------
                ofrmSplash.lblTexto.Text = "Guardando Configuraciones... "
                Application.DoEvents()
8:              oAppContext.SaveSettings()
                ofrmSplash.pbAvance.Value += 1
9:              oSApReader.SaveSettings(oAppSAPConfig)
                ofrmSplash.pbAvance.Value += 1
10:             oReader.SaveSettings(oConfigCierreFI)
                ofrmSplash.pbAvance.Value += 1
                'Else
                '    SaveConfigGeneralInServer()
                '    SaveConfigSAPInServer()
                '    SaveConfigCierreFiInServer()
            End If
11:         SaveConfigGeneralInServer(False)
            ofrmSplash.pbAvance.Value += 1
12:         SaveConfigSAPInServer(False)
            ofrmSplash.pbAvance.Value += 1
13:         SaveConfigCierreFiInServer(False)
            ofrmSplash.pbAvance.Value += 1
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al cargar config from server oAppContext: Linea " & Err.Erl)
        Finally
            If Not ofrmSplash Is Nothing AndAlso ofrmSplash.Visible Then ofrmSplash.Close()
        End Try

    End Sub

    Private Sub ActualizaConfigGeneral(ByVal oRowC As DataRow)
        Dim objTemp As Object
        Dim Propiedad As PropertyInfo
        Dim objValue As Object
        Dim strParam() As String
        Dim strParametro As String = ""
        Dim strPrefijo As String = ""

        Try
            If CInt(oRowC!Tipo) = 1 AndAlso (CStr(oRowC!Parametro).Trim.ToUpper = "ALMACEN" OrElse CStr(oRowC!Parametro).Trim.ToUpper = "NOCAJA") Then
                Exit Sub
            End If

            Select Case CInt(oRowC!Tipo)
                Case 1
                    objTemp = oAppContext.ApplicationConfiguration
                Case 2
                    objTemp = oAppSAPConfig
                Case 3
                    objTemp = oConfigCierreFI
            End Select

            strParam = CStr(oRowC!Parametro).Trim.Split(".")

            If strParam.Length > 1 Then
                strParametro = strParam(0)
            Else
                strParametro = CStr(oRowC!Parametro)
            End If

            Propiedad = objTemp.GetType.GetProperty(strParametro)
            strPrefijo = objTemp.GetType.Name & "." & CStr(oRowC!Parametro)
            Select Case Propiedad.PropertyType.FullName
                Case "System.Decimal"
                    objValue = CDec(oRowC!Valor)
                Case "System.Int32"
                    objValue = CInt(oRowC!Valor)
                Case "System.Boolean"
                    objValue = CBool(oRowC!Valor)
                Case "System.String[]"
                    objValue = CStr(oRowC!Valor).Split("|")
                Case "System.DateTime"
                    objValue = CDate(oRowC!Valor)
                Case "System.Int64"
                    objValue = CLng(oRowC!Valor)
                Case "System.String"
                    objValue = CStr(oRowC!Valor)
                Case "DPSoft.Framework.Data.SQLServer.SQLConnectionHelper"
                    objTemp = Propiedad.GetValue(objTemp, Nothing)
                    ActualizaConfigSQLConnectionHelper(objTemp, strParam(1), CBool(oRowC!IsPassword), oRowC!Valor, strPrefijo)
                    Exit Sub
            End Select

            If CBool(oRowC!IsPassword) = True Then objValue = oSecurity.DesEncriptarCML(CStr(objValue))

            Propiedad.SetValue(objTemp, objValue, Nothing)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al cargar config en propiedad: " & strPrefijo)
        End Try

    End Sub

    Private Function ActualizaConfigSQLConnectionHelper(ByVal objTemp As Object, ByVal strParam As String, ByVal EsPass As Boolean, _
                                                        ByVal Value As String, ByVal strPrefijo As String) As Object

        Dim oProp As PropertyInfo
        Dim objValue As Object

        Try

            oProp = objTemp.GetType.GetProperty(strParam)
            Select Case oProp.PropertyType.FullName
                Case "System.Decimal"
                    objValue = CDec(Value)
                Case "System.Int32"
                    objValue = CInt(Value)
                Case "System.Boolean"
                    objValue = CBool(Value)
                Case "System.String[]"
                    objValue = Value.Split("|")
                Case "System.DateTime"
                    objValue = CDate(Value)
                Case "System.Int64"
                    objValue = CLng(Value)
                Case "System.String"
                    objValue = Value
            End Select

            If EsPass = True Then objValue = oSecurity.DesEncriptarCML(CStr(objValue))

            oProp.SetValue(objTemp, objValue, Nothing)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al cargar config from server SQLConnectionHelper: " & strPrefijo)
        End Try

    End Function

    Public Sub SaveConfigCierreFiInServer(ByVal Actualizar As Boolean)

        Try

1:          Dim Properties As PropertyInfo() = oConfigCierreFI.GetType.GetProperties
2:          Dim oFacturasMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim strError As String
            Dim Valor As String = ""
            Dim bolPass As Boolean

            For Each oProp As PropertyInfo In Properties
                strError = ""
                bolPass = False
                Valor = ""
3:              If oProp.PropertyType.Name = "String[]" Then
4:                  Dim strTemp() As String = oProp.GetValue(oConfigCierreFI, Nothing)
                    For Each str As String In strTemp
5:                      If Not str Is Nothing AndAlso str.Trim <> "" Then Valor &= str.Trim & "|"
                    Next
                Else
6:                  Valor = oProp.GetValue(oConfigCierreFI, Nothing)
                End If
7:              If IsPassword(oProp.Name) Then
8:                  Valor = oSecurity.EncriptarCML(Valor)
9:                  bolPass = True
                End If
10:             strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 3, bolPass, Actualizar)
11:             If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oConfigCierreFI." & oProp.Name)
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar config general in server oConfigCierreFI: Linea " & Err.Erl)
        End Try

    End Sub

    Private Function IsPassword(ByVal Name As String) As Boolean

        Select Case Name.Trim.ToUpper
            Case "PASSEHUB", "PASSHUELLAS", "PASSSEPARACIONES", "PASSFIRMA", "PASSWORD", "PASSWORDIMG", "PASSWORDTRASPASOS", "PASSWORDEMAILS", "PASSWORDBROKER", "PasswordFTPBroker".ToUpper, _
                 "PASSWORDDPCARD", "PASSWORDDPVF", "PASSWORDDPVALEAIO", "PASSWORDDPVALE", "PASSWORDCORREO", "PASSWORDDPTODO"
                Return True
            Case Else
                Return False
        End Select

    End Function

    Public Sub SaveConfigSAPInServer(ByVal Actualizar As Boolean)

        Try

1:          Dim Properties As PropertyInfo() = oAppSAPConfig.GetType.GetProperties
2:          Dim oFacturasMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim strError As String
            Dim Valor As String = ""
            Dim bolPass As Boolean

3:          For Each oProp As PropertyInfo In Properties
                strError = ""
                bolPass = False
4:              Valor = oProp.GetValue(oAppSAPConfig, Nothing)
5:              If oProp.Name.ToUpper.Trim = "PASSWORD" Then
6:                  Valor = oSecurity.EncriptarCML(Valor)
                    bolPass = True
                End If
7:              strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 2, bolPass, Actualizar)
8:              If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oAppSapConfig." & oProp.Name)
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar config general in server oAppSAPConfig: Linea " & Err.Erl)
        End Try

    End Sub

    Public Sub SaveConfigGeneralInServer(ByVal Actualizar As Boolean)

        Try
1:          Dim Properties As PropertyInfo() = oAppContext.ApplicationConfiguration.GetType.GetProperties
            Dim strError As String
            Dim Valor As String = ""
            Dim bolPass As Boolean
2:          Dim oFacturasMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim strPrefijo As String = ""

3:          For Each oProp As PropertyInfo In Properties
                strError = ""
                bolPass = False
                Valor = ""
4:              If oProp.PropertyType.Name.Trim = "SQLConnectionHelper" Then
5:                  strPrefijo = oProp.Name & "."
6:                  SaveConfigInServerSQLConnectionHelper(strPrefijo, oProp.GetValue(oAppContext.ApplicationConfiguration, Nothing), oFacturasMgr, Actualizar)
                Else
7:                  Valor = oProp.GetValue(oAppContext.ApplicationConfiguration, Nothing)
8:                  If oProp.Name.ToUpper.Trim = "PASSWORD" Then
9:                      Valor = oSecurity.EncriptarCML(Valor)
10:                     bolPass = True
                    End If
11:                 If oProp.Name.ToUpper.Trim <> "ALMACEN" AndAlso oProp.Name.ToUpper.Trim <> "NOCAJA" Then
12:                     strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 1, bolPass, Actualizar)
13:                     If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oAppContext." & oProp.Name)
                    End If
                End If
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar config general in server oAppContext: Linea " & Err.Erl)
        End Try

    End Sub

    Private Sub SaveConfigInServerSQLConnectionHelper(ByVal strPrefijo As String, ByVal objTemp As Object, ByVal oFacturasMgr As FacturaManager, ByVal Actualizar As Boolean)

        Try
1:          Dim Properties As PropertyInfo() = objTemp.GetType.GetProperties
            Dim strError As String
            Dim Valor As String = ""
            Dim bolPass As Boolean

2:          For Each oProp As PropertyInfo In Properties
                strError = ""
                bolPass = False
3:              Valor = oProp.GetValue(objTemp, Nothing)
4:              If oProp.Name.ToUpper.Trim = "PASSWORD" Then
5:                  Valor = oSecurity.EncriptarCML(Valor)
6:                  bolPass = True
                End If
7:              strError = oFacturasMgr.SaveConfigInServer(strPrefijo & oProp.Name, Valor, 1, bolPass, Actualizar)
8:              If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: " & strPrefijo & oProp.Name)
            Next

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar SQLConnectionHelper in server: " & strPrefijo & " Linea: " & Err.Erl)
        End Try

    End Sub

#End Region

#Region "ZIP"

    Public Sub Descomprimir(ByVal directorio As String, _
                                Optional ByVal zipFic As String = "", _
                                Optional ByVal eliminar As Boolean = False, _
                                Optional ByVal renombrar As Boolean = False)
        ' descomprimir el contenido de zipFic en el directorio indicado.
        ' si zipFic no tiene la extensión .zip, se entenderá que es un directorio y
        ' se procesará el primer fichero .zip de ese directorio.
        ' si eliminar es True se eliminará ese fichero zip después de descomprimirlo.
        ' si renombrar es True se añadirá al final .descomprimido
        If Not zipFic.ToLower.EndsWith(".zip") Then
            zipFic = Directory.GetFiles(zipFic, "*.zip")(0)
        End If
        ' si no se ha indicado el directorio, usar el actual
        If directorio = "" Then directorio = "."
        '
        Dim z As New ZipInputStream(File.OpenRead(zipFic))
        Dim theEntry As ZipEntry
        '
        Do
            theEntry = z.GetNextEntry()
            If Not theEntry Is Nothing Then
                'Dim fileName As String = directorio & "\" & Path.GetFileName(theEntry.Name)
                Dim fileName As String = directorio & "\" & theEntry.Name
                '
                ' dará error si no existe el path
                Dim streamWriter As FileStream
                Try
                    If Not theEntry.IsDirectory Then
                        streamWriter = File.Create(fileName)
                    Else
                        If Not Directory.Exists(fileName) Then Directory.CreateDirectory(fileName)
                    End If
                Catch ex As DirectoryNotFoundException
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName))
                    streamWriter = File.Create(fileName)
                End Try
                '
                If Not theEntry.IsDirectory Then
                    Dim size As Integer
                    Dim data(2048) As Byte
                    Do
                        size = z.Read(data, 0, data.Length)
                        If (size > 0) Then
                            streamWriter.Write(data, 0, size)
                        Else
                            Exit Do
                        End If
                    Loop
                    streamWriter.Close()
                End If
            Else
                Exit Do
            End If
        Loop
        z.Close()
        '
        ' cuando se hayan extraído los ficheros, renombrarlo
        If renombrar Then
            File.Copy(zipFic, zipFic & ".descomprimido")
        End If
        If eliminar Then
            File.Delete(zipFic)
        End If
    End Sub

#End Region


#Region "Actualizacion"

    '----------------------------------------------------------------------------------------
    ' JNAVA (02.10.2015): Se hace la funcion publica para poderla ejecutar en el cierre y
    '                     se agregan paramaetros para obtener el mensaje de error
    '----------------------------------------------------------------------------------------
    Public Function VerificarVersion(Optional ByRef MensajeError As String = "") As Boolean

        Dim UltimaV As Long = 0
        Dim UltimaVLU As Long = 0
        Dim oProceso As New Process
        Dim Result As Boolean = True
        Dim strRutaArchivoZip As String = ""
        Dim strRutaArchivos As String = ""
        Dim bolLive As Boolean, bolVersion As Boolean
        Dim bolCritica As Boolean

        Try

1:          If Directory.Exists(oConfigCierreFI.RutaActualizacion) = False Then Directory.CreateDirectory(oConfigCierreFI.RutaActualizacion)

2:          oLiveMgr = New LiveUpdateManager(oConfigCierreFI)
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Revisamos la ultima versión del Dportenis PRO y la versión del LiveUpdate.exe
            '-------------------------------------------------------------------------------------------------------------------------------------
3:          bolLive = TieneUltimaVersion(UltimaVLU, "LU", "LiveUpdate", bolCritica)
4:          bolVersion = TieneUltimaVersion(UltimaV, "UV", "Version", bolCritica)
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Si hay una versión mas nueva disponible actualizamos versión
            '-------------------------------------------------------------------------------------------------------------------------------------
5:          If UltimaV > 0 AndAlso (bolLive = False OrElse bolVersion = False) Then
                With oConfigCierreFI
6:                  strRutaArchivoZip = .RutaActualizacion & "\DPPROv" & UltimaV & ".zip"
7:                  strRutaArchivos = .RutaActualizacion & "\Archivos"
                End With
8:              Dim oFrmEsp As New FrmEsperar
                '-------------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos si existe el archivo de actualizacion, si no lo descargamos del servidor de internet
                '-------------------------------------------------------------------------------------------------------------------------------------------
9:              If Not File.Exists(strRutaArchivoZip) Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Intentamos realizar la descarga del servidor de internet
                    '---------------------------------------------------------------------------------------------------------------------------
                    oFrmEsp.Label1.Text = "Descargando Archivo de Actualización..."
10:                 oFrmEsp.Show()
11:                 Application.DoEvents()

                    '---------------------------------------------------------------------------------------------------------------------------
                    ' MLVARGAS (23/12/2020) Verificar de que servidor va a realizar la descarga
                    '---------------------------------------------------------------------------------------------------------------------------
                    Dim bDescarga = False
                    Dim bReintento = False
                    If oConfigCierreFI.SeleccionaServidorHTTPS Then
                        bDescarga = DescargarArchivoServidorHTTPS(oConfigCierreFI.ServidorHTTPS.TrimEnd("/") & "/DPPROv" & UltimaV & ".zip", strRutaArchivoZip)
                    Else
                        bDescarga = DescargarArchivoFromInternet(oConfigCierreFI.InternetServer.TrimEnd("/") & "/DPPROv" & UltimaV & ".zip", strRutaArchivoZip)
                    End If

EvaluaRespuesta:
12:                 If bDescarga Then
13:                     oFrmEsp.Close()
                        '-----------------------------------------------------------------------------------------------------------------------
                        'Si se realiza la descarga con exito verificamos de nuevo que exista el archivo en la ruta de actualización
                        '-----------------------------------------------------------------------------------------------------------------------
14:                     If Not File.Exists(strRutaArchivoZip) Then GoTo NoExisteArchivo
                    Else
15:                     oFrmEsp.Close()

                        '---------------------------------------------------------------------------------------------------------------------------
                        ' MLVARGAS (23/12/2020) Si no está seleccionada la descarga del servidor HTTPS se pregunta si reintenta
                        '---------------------------------------------------------------------------------------------------------------------------
                        'SE comento por que aun no se tiene servidor de descarga https
                        'If Not oConfigCierreFI.SeleccionaServidorHTTPS AndAlso bReintento = False Then
                        '    If MessageBox.Show("No se pudo realizar la descarga. ¿Desea reintentar?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        '        bReintento = True
                        '        oFrmEsp = New FrmEsperar
                        '        oFrmEsp.Label1.Text = "Descargando Archivo de Actualización..."
                        '        oFrmEsp.Show()
                        '        Application.DoEvents()
                        '        bDescarga = DescargarArchivoServidorHTTPS(oConfigCierreFI.ServidorHTTPS.TrimEnd("/") & "/DPPROv" & UltimaV & ".zip", strRutaArchivoZip)
                        '        GoTo EvaluaRespuesta
                        '    End If
                        'End If


                        '-----------------------------------------------------------------------------------------------------------------------
                        'Si falló la descarga del archivo y no lo tenemos en la ruta de actualización, entonces
                        'si es critica la actualizacion regresamos false para que no continue abriendo el DportenisPRO, si no es critica solo 
                        'manda una advertencia
                        '-----------------------------------------------------------------------------------------------------------------------
NoExisteArchivo:
                        EscribeLog("No existe el archivo de actualizacion.", "Archivo ZIP")
16:                     If bolCritica Then
17:                         MessageBox.Show("No existe el archivo de actualización. Es necesario actualizar la versión para continuar.", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '-----------------------------------------------------------------------------------------------------------------------
                            'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                            '-----------------------------------------------------------------------------------------------------------------------
18:                         MensajeError = "No existe el archivo de actualización. Es necesario actualizar la versión para continuar."
                            '-----------------------------------------------------------------------------------------------------------------------
                            Result = False
                        Else
19:                         MessageBox.Show("No existe el archivo de actualización." & vbCrLf & vbCrLf & "Favor de comunicarse con SOPORTE" & vbCrLf & _
                                            "Para realizar la actualización de versión lo mas pronto posible.", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '-----------------------------------------------------------------------------------------------------------------------
                            'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                            '-----------------------------------------------------------------------------------------------------------------------
                            MensajeError = "No existe el archivo de actualización." & vbCrLf & vbCrLf & "Favor de comunicarse con SOPORTE" & vbCrLf & _
                                           "Para realizar la actualización de versión lo mas pronto posible."
                            '-----------------------------------------------------------------------------------------------------------------------
                        End If
                        GoTo Final
                    End If
                End If
20:             If Not Directory.Exists(strRutaArchivos) Then Directory.CreateDirectory(strRutaArchivos)
21:             Application.DoEvents()
                '-------------------------------------------------------------------------------------------------------------------------------------------
                'Descomprimimos el archivo .ZIP de actualización
                '-------------------------------------------------------------------------------------------------------------------------------------------
                Try
                    oFrmEsp = New FrmEsperar
22:                 oFrmEsp.Label1.Text = "Descomprimiendo Archivo de Actualizacion..."
23:                 oFrmEsp.Show()
24:                 Application.DoEvents()
25:                 Descomprimir(strRutaArchivos, strRutaArchivoZip)
26:                 oFrmEsp.Close()
                Catch ex As Exception
27:                 MessageBox.Show("Ocurrio un error al descomprimir el archivo de actualizacion" & vbCrLf & "Favor de comunicarse con SOPORTE", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
28:                 EscribeLog(ex.ToString, "Error al descomprimir archivo de actualizacion: Linea " & Err.Erl)
29:                 Result = False
                    '-----------------------------------------------------------------------------------------------------------------------
                    'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                    '-----------------------------------------------------------------------------------------------------------------------
                    MensajeError = "Error al descomprimir archivo de actualizacion: Linea " & Err.Erl & vbCrLf & vbCrLf & ex.ToString
                    '-----------------------------------------------------------------------------------------------------------------------
                    GoTo Final
                End Try
                '-------------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos primero si hay que actualizar el LiveUpdate.exe
                '-------------------------------------------------------------------------------------------------------------------------------------------
30:             Application.DoEvents()
31:             If bolLive = False Then
                    Try
32:                     oFrmEsp = New FrmEsperar
33:                     oFrmEsp.Label1.Text = "Actualizando DportenisPro LiveUpdate"
34:                     oFrmEsp.Show()
35:                     Application.DoEvents()
36:                     proActualizaLive(UltimaVLU, strRutaArchivos & "\LiveUpdate.exe")
37:                     oFrmEsp.Close()
                    Catch ex As Exception
38:                     MessageBox.Show("Ocurrio un error al actualizar el archivo LiveUpdate.exe" & vbCrLf & "Favor de comunicarse con SOPORTE", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
39:                     EscribeLog(ex.ToString, "Error al actualizar el archivo LiveUpdate.exe: Linea " & Err.Erl)
40:                     Result = False
                        '-----------------------------------------------------------------------------------------------------------------------
                        'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                        '-----------------------------------------------------------------------------------------------------------------------
                        MensajeError = "Error al actualizar el archivo LiveUpdate.exe: Linea " & Err.Erl & vbCrLf & vbCrLf & ex.ToString
                        '-----------------------------------------------------------------------------------------------------------------------
                        GoTo Final
                    End Try
41:                 Application.DoEvents()
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'Borramos el archivo .ZIP una vez se ha descomprimido
                '---------------------------------------------------------------------------------------------------------------------------------
                Try
44:                 If File.Exists(strRutaArchivoZip) Then File.Delete(strRutaArchivoZip)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al borrar archivo .ZIP: Linea " & Err.Erl)
                    '-----------------------------------------------------------------------------------------------------------------------
                    'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                    '-----------------------------------------------------------------------------------------------------------------------
                    'MensajeError = "Error al borrar archivo .ZIP: Linea " & Err.Erl & vbCrLf & vbCrLf & ex.ToString
                    '-----------------------------------------------------------------------------------------------------------------------
                End Try
                '-------------------------------------------------------------------------------------------------------------------------------------------
                'Revisamos si se debe actualizar versión del DportenisPro
                '-------------------------------------------------------------------------------------------------------------------------------------------
42:             If bolVersion = False Then
                    Try
43:                     oProceso.Start(Application.StartupPath & "\LiveUpdate.exe")
                        End
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al iniciar aplicacion de actualizacion: Linea " & Err.Erl)
                        '-----------------------------------------------------------------------------------------------------------------------
                        'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
                        '-----------------------------------------------------------------------------------------------------------------------
                        MensajeError = "Error al iniciar aplicacion de actualizacion: Linea " & Err.Erl & vbCrLf & vbCrLf & ex.ToString
                        '-----------------------------------------------------------------------------------------------------------------------
                    End Try
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al actualizar la versión: Linea " & Err.Erl)
            '-----------------------------------------------------------------------------------------------------------------------
            'JNAVA (02.10.2015): Obtenemos el detalle del error para enviar el correo a soporte
            '-----------------------------------------------------------------------------------------------------------------------
            MensajeError = "Error al actualizar la versión: Linea " & Err.Erl & vbCrLf & vbCrLf & ex.ToString
            '-----------------------------------------------------------------------------------------------------------------------
        End Try

Final:
        Return Result

    End Function

    Private Sub proActualizaLive(ByVal Version As String, ByVal Ruta As String)
        Try
            If File.Exists(Ruta) Then
                File.Copy(Ruta, Application.StartupPath & "\LiveUpdate.exe", True)
                oLiveMgr.ActualizaVersionSuc(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, _
                                             Version, "LiveUpdate")
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al copiar el archivo LiveUpdate.exe")
        End Try

    End Sub

    Private Function TieneUltimaVersion(ByRef UltimaV As Long, ByVal Sistema As String, ByVal Columna As String, ByRef Critica As Boolean) As Boolean

        Dim VersionSuc As Long

        UltimaV = oLiveMgr.GetUltimaVersion(Sistema, Critica, oAppContext.ApplicationConfiguration.Almacen)
        VersionSuc = oLiveMgr.GetVersionSucursal(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, Columna)

        strVersionSuc = CStr(VersionSuc)

        If UltimaV > VersionSuc Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Function DescargarArchivoServidorHTTPS(ByVal RemotePath As String, ByVal LocalPath As String) As Boolean
        Dim bRes As Boolean = True
        Dim url = RemotePath
        Dim encondedUrl As Uri = New Uri(url, True)
        Dim response As WebResponse = Nothing
        Dim remoteStream As Stream = Nothing
        Dim localStream As Stream = Nothing

        ServicePointManager.SecurityProtocol = Tls12
        Try
            Dim webrequest = CType(System.Net.WebRequest.Create(encondedUrl), HttpWebRequest)
            If webrequest IsNot Nothing Then
                response = webrequest.GetResponse()

                If response IsNot Nothing Then
                    remoteStream = response.GetResponseStream()

                    ' Create the local file
                    localStream = File.Create(LocalPath)

                    Dim buffer As Byte() = New Byte(1023) {}
                    Dim bytesRead As Integer

                    Do
                        ' Read data (up to 1k) from the stream
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length)

                        ' Write the data to the local file
                        localStream.Write(buffer, 0, bytesRead)
                    Loop While bytesRead > 0

                    ' Si no esta seleccionada la descarga del servidor HTTPS se marca por default
                    If Not oConfigCierreFI.SeleccionaServidorHTTPS Then
                        oConfigCierreFI.SeleccionaServidorHTTPS = True
                        Dim oReader As New SaveConfigArchivosReader(strConfigurationFileFI)
                        oReader.SaveSettings(oConfigCierreFI)

                        SaveConfigCierreFiInServer(True)
                    End If

                End If
            End If
        Catch ex As Exception
            bRes = False
            EscribeLog(ex.ToString, "Error al descargar el archivo de la versión. Linea " & Err.Erl)
        Finally
            If response IsNot Nothing Then response.Close()
            If remoteStream IsNot Nothing Then remoteStream.Close()
            If localStream IsNot Nothing Then localStream.Close()
        End Try
        Return bRes
    End Function


    Private Function DescargarArchivoFromInternet(ByVal RemotePath As String, ByVal LocalPath As String) As Boolean

        Dim bRes As Boolean = True

        Try
1:          Dim wr As HttpWebRequest = CType(HttpWebRequest.Create(RemotePath), HttpWebRequest)
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Le asignamos las credenciales del proxy en caso de estar configurado
            '-----------------------------------------------------------------------------------------------------------------------------------
2:          If Not WebProxy.GetDefaultProxy.Address Is Nothing Then
3:              Dim cr As New NetworkCredential(oConfigCierreFI.UserProxy, oConfigCierreFI.PasswordProxy)
4:              Dim proxy As New WebProxy(WebProxy.GetDefaultProxy.Address.Host, WebProxy.GetDefaultProxy.Address.Port)
5:              proxy.Credentials = cr
6:              wr.Proxy = proxy
            End If
            Dim download As New WebClient()
            download.DownloadFile(RemotePath, LocalPath)
            '            '-----------------------------------------------------------------------------------------------------------------------------------
            '            ' Send the HttpWebRequest and wait for response. 
            '            '-----------------------------------------------------------------------------------------------------------------------------------
            '7:          Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            '8:          Dim str As Stream = ws.GetResponseStream()
            '9:          Dim inBuf(30000000) As Byte
            '10:         Dim bytesToRead As Integer = CInt(inBuf.Length)
            '11:         Dim bytesRead As Integer = 0
            '12:         While bytesToRead > 0
            '13:             Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
            '14:             If n = 0 Then
            '                    Exit While
            '                End If
            '15:             bytesRead += n
            '16:             bytesToRead -= n
            '            End While
            '17:         Dim fstr As New FileStream(LocalPath, FileMode.OpenOrCreate, FileAccess.Write)
            '18:         fstr.Write(inBuf, 0, bytesRead)
            '19:         str.Close()
            '20:         fstr.Close()
        Catch ex As Exception
            bRes = False
            EscribeLog(ex.ToString, "Error al descargar el archivo de la versión. Linea " & Err.Erl)
        End Try

        Return bRes

    End Function

    '--------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (08.02.2017): Metodo para determinar si la BD de VersionesSucursal esta actualizada con la version actual del DPPRO
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ValidaVersionDPPRO(ByVal VersionAplicacion As String)
        Dim Almacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim Caja As String = oAppContext.ApplicationConfiguration.NoCaja
        Dim VersionSuc As Long

        Try

            oLiveMgr = New LiveUpdateManager(oConfigCierreFI)

            '-------------------------------------------------------------------------------------
            ' Obtenemos la version que está en la BD Centralizada para la sucursal y caja
            '-------------------------------------------------------------------------------------
            VersionSuc = oLiveMgr.GetVersionSucursal(Almacen, Caja, "Version")

            '-------------------------------------------------------------------------------------
            ' Validamos la version de la aplicacion con la de la BD centralizada
            '-------------------------------------------------------------------------------------
            If VersionAplicacion <> CStr(VersionSuc) Then
                '-------------------------------------------------------------------------------------
                ' Si no es la misma, ponemos la version de la aplicacion en la BD Centralizada
                '-------------------------------------------------------------------------------------
                oLiveMgr.ActualizaVersionSuc(Almacen, Caja, VersionAplicacion, "Version")
            End If
        Catch ex As Exception
            EscribeLog("Error al Validar la Version del DPPRO.", ex.Message)
        End Try

        oLiveMgr = Nothing

    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (05.04.2017): Metodo para actualizar la version de windows y de SQL en el servidor centralizado
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ActualizaVersionWindows_InstanciaSQL()
        Dim Almacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim Caja As String = oAppContext.ApplicationConfiguration.NoCaja

        oLiveMgr = New LiveUpdateManager(oConfigCierreFI)

        '--------------------------------------------------------------------------------------------------------------------------------------
        'Actualizamos Version Windows y SQL
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            oLiveMgr.ActualizaVersionWindowsSQL(Almacen, Caja, VersionWindows(), VersionSQL(), GetCiudadDescripcionByAlmacen())
        Catch ex As Exception
            EscribeLog("Error al actualizar la versión de Windows y/o SQL Server.", ex.Message)
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------

        oLiveMgr = Nothing
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (05.04.2017): Funcion para determinar la versión del sistema operativo
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Function VersionWindows() As String
        Dim strVersion As String = "Desconocido"
        Select Case Environment.OSVersion.Platform
            Case PlatformID.Win32S
                strVersion = "Windows 3.1"
            Case PlatformID.Win32Windows
                Select Case Environment.OSVersion.Version.Minor
                    Case 0
                        strVersion = "Windows 95"
                    Case 10
                        If Environment.OSVersion.Version.Revision.ToString() = "2222A" Then
                            strVersion = "Windows 98 Second Edition"
                        Else
                            strVersion = "Windows 98"
                        End If
                    Case 90
                        strVersion = "Windows ME"
                End Select
            Case PlatformID.Win32NT
                Select Case Environment.OSVersion.Version.Major
                    Case 3
                        strVersion = "Windows NT 3.51"
                    Case 4
                        strVersion = "Windows NT 4.0"
                    Case 5
                        Select Case Environment.OSVersion.Version.Minor
                            Case 0
                                strVersion = "Windows 2000"
                            Case 1
                                strVersion = "Windows XP"
                            Case 2
                                strVersion = "Windows 2003"
                        End Select
                    Case 6
                        Select Case Environment.OSVersion.Version.Minor
                            Case 0
                                strVersion = "Windows Vista"
                            Case 1
                                strVersion = "Windows 7"
                            Case 2
                                strVersion = "Windows 8"
                            Case 3
                                strVersion = "Windows 8.1"
                        End Select
                    Case 10
                        Select Case Environment.OSVersion.Version.Minor
                            Case 0
                                strVersion = "Windows 10"
                        End Select
                End Select
            Case PlatformID.WinCE
                strVersion = "Windows CE"
            Case PlatformID.Unix
                strVersion = "Unix"
        End Select
        Return strVersion
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (05.04.2017): Funcion para determinar la versión de la instanacia de sql 
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Function VersionSQL() As String
        Dim strReturn As String = String.Empty
        Dim sccnnConnection As New System.Data.SqlClient.SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim sccmdSelect As New System.Data.SqlClient.SqlCommand
        Dim scdrReader As System.Data.SqlClient.SqlDataReader

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "Select @@VERSION"
            .CommandType = System.Data.CommandType.Text
        End With

        Try
            sccnnConnection.Open()
            With sccmdSelect
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdrReader.Read()
                If (scdrReader.HasRows) Then
                    With scdrReader
                        strReturn = .GetString(0)

                        Dim Version() As String
                        Version = strReturn.Split("-")
                        If Version.Length > 0 Then
                            strReturn = Version(0).Trim
                        End If

                    End With
                End If
                scdrReader.Close()
            End With
            sccnnConnection.Close()
        Catch oSqlException As System.Data.SqlClient.SqlException
            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)
        Catch ex As Exception
            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If
            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return strReturn

    End Function

    Private Function GetCiudadDescripcionByAlmacen() As String
        Dim desc As String = ""
        Dim AlmacenMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim SapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim Almacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen = AlmacenMgr.Create()
        Almacen = AlmacenMgr.Load(SapMgr.Read_Centros())
        If Almacen.Descripcion.Trim() <> "" Then desc = Almacen.Descripcion & " "
        If Almacen.DireccionCiudad.Trim() <> "" Then desc &= Almacen.DireccionCiudad & " "
        If Almacen.DireccionEstado.Trim() <> "" Then desc &= Almacen.DireccionEstado
        Return desc
    End Function

#End Region

    '--------------------------------------------------------------------------------------------------------------------------------------
    'Metodo para descargar un archivo mediante FTP a una ruta local
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Function DescargarArchivoPorFTP(ByVal Server As String, ByVal User As String, ByVal Password As String, ByVal ArchivoRemoto As String, ByVal ArchivoLocal As String) As Boolean

        Dim bRes As Boolean = False

        Try
            Dim oFTP As New EnterpriseDT.Net.Ftp.FTPConnection
            Dim RutaLocal As String = ""
            Dim Archivo() As String

            'Nos aseguramos que el nombre del archivo en la ruta FTP sea en minusculas
            Archivo = ArchivoRemoto.Split("/")
            If Archivo.Length > 0 Then
                RutaLocal = Archivo(Archivo.Length - 1)
                ArchivoRemoto = ArchivoRemoto.Substring(0, ArchivoRemoto.Trim.Length - RutaLocal.Trim.Length) & RutaLocal.Trim.ToLower
            End If
            'Sacamos la ruta local donde se copiara el archivo local para asegurarnos que la ruta local exista
            Archivo = ArchivoLocal.Split("\")
            If Archivo.Length > 0 Then
                RutaLocal = Archivo(Archivo.Length - 1)
                RutaLocal = ArchivoLocal.Substring(0, ArchivoLocal.Trim.Length - RutaLocal.Trim.Length)
            End If
            oFTP.UserName = User
            oFTP.Password = Password
            oFTP.ServerAddress = IIf(InStr(Server.ToLower, "http://") > 0, Server.Trim.ToLower.Replace("http://", ""), Server)
            oFTP.Connect()
            If oFTP.IsConnected Then
                If RutaLocal.Trim <> "" AndAlso Directory.Exists(RutaLocal) = False Then Directory.CreateDirectory(RutaLocal)
                oFTP.DownloadFile(ArchivoLocal, ArchivoRemoto)
                oFTP.Close()
                bRes = True
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al descargar el archivo " & ArchivoRemoto & " por FTP")
        End Try

        Return bRes

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------
    'Exporta un Datatable a Excel sin necesidad de tener instalado Microsoft Excel en la PC
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Sub DataTableToExcel(ByVal pDataTable As DataTable, ByVal xRuta As String)

        Dim oWriter As StreamWriter
        Dim RutaLocal As String = ""
        Dim Archivo() As String
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Sacamos la ruta local donde se copiara el archivo para asegurarnos que dicha ruta exista
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            Archivo = xRuta.Split("\")
            If Archivo.Length > 0 Then
                RutaLocal = Archivo(Archivo.Length - 1)
                RutaLocal = xRuta.Substring(0, xRuta.Trim.Length - RutaLocal.Trim.Length)
            End If

            If Directory.Exists(RutaLocal) = False Then Directory.CreateDirectory(RutaLocal)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al crear la ruta para depositar el archivo de Excel")
        End Try

        oWriter = New StreamWriter(xRuta, False)
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Sacamos las columnas del Datatable para agregarlas a la primera fila del archivo
        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim sb As String = ""
        Dim dc As DataColumn
        For Each dc In pDataTable.Columns
            sb &= Trim(dc.Caption) & Microsoft.VisualBasic.ControlChars.Tab
        Next
        oWriter.WriteLine(sb)
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Escribimos todo el contenido del datatable en el archivo de Excel
        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    If IsDate(dr(i)) Then
                        sb &= Replace(Convert.ToString(Microsoft.VisualBasic.Format(dr(i), "dd/MM/yyyy")), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                    Else
                        sb &= Replace(Trim(CStr(dr(i))), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                    End If
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next
            oWriter.WriteLine(sb)
        Next
        oWriter.Close()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------
    'Revisa los traspasos de salida generados por faltantes pendientes por autorizar
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Function RevisaTraspasosPendientes() As Boolean

        Dim bRes As Boolean = True
        Dim dtCab As DataTable
        Dim oRow As DataRow
        Dim Dias As Integer = 0
        Dim oTSMgr As TraspasosSalidaManager

        oTSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        dtCab = oTSMgr.GetAllTraspasosPendientes.Tables(0)

        Dias = oConfigCierreFI.DiasParaBloquearTP

        For Each oRow In dtCab.Rows
            If CDate(oRow!Fecha).AddDays(Dias) <= Today Then
                bRes = False
                Exit For
            End If
        Next

        Return bRes

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------
    'Modulo de Acceso del Manager Panel Control
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Sub ManagerPanelControl(ByVal Modulo As String)
        If oConfigCierreFI.ShowManagerPC Then
            Select Case Modulo.Trim
                Case "TOP10"
                    Dim oRepMV As New frmManagerPanelControl
                    oRepMV.Modulo = "T10"
                    oRepMV.strTitulo = "Los 10 Mas Vendidos"
                    oRepMV.Num = 10
                    oRepMV.FechaIni = CDate("01/01/2010")
                    oRepMV.FechaFin = CDate("31/12/2012")
                    oRepMV.ShowDialog()
                Case "LAST10"
                    Dim oRepMV As New frmManagerPanelControl
                    oRepMV.Modulo = "L10"
                    oRepMV.strTitulo = "Los 10 Menos Vendidos"
                    oRepMV.Num = 10
                    oRepMV.FechaIni = CDate("01/01/2010")
                    oRepMV.FechaFin = CDate("31/12/2012")
                    oRepMV.ShowDialog()
            End Select
        End If
    End Sub

#Region "Ecommerce USI"

    Dim oSapMgr As ProcesoSAPManager
    '--------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 22/04/2013: Revisamos si un pedido está cancelado en SAP dependiendo del modulo donde se consulte (Ecommerce o Si Hay)
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Function EstaPedidoCancelado(ByVal FolioPedido As String, ByVal Modulo As String) As Boolean

        Dim dvCan As DataView
        Dim dtPedidosCan As DataTable, dtDetalle As DataTable, dtTemp As DataTable
        Dim bRes As Boolean = False

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Select Case Modulo.Trim.ToUpper
            Case "PPSH", "PRSH", "PFSH" 'Pedidos pendientes por surtir, por recibir y facturar Si Hay
                Dim htStatus As New Hashtable(0)
                Dim strCentroSAP As String = oSapMgr.Read_Centros

                htStatus(1) = "C"
                dtPedidosCan = oSapMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtTemp, dtDetalle, htStatus)
                dtPedidosCan.Columns("VBELN").ColumnName = "Folio_Pedido"
            Case Else
                'dtPedidosCan = oSapMgr.ZPOL_PEDIDOSCANCELADOS(dtDetalle)
        End Select

        'dtPedidosCan = oSapMgr.ZPOL_PEDIDOSCANCELADOS(dtDetalle)

        If Not dtPedidosCan Is Nothing AndAlso dtPedidosCan.Rows.Count > 0 Then
            dvCan = New DataView(dtPedidosCan, "Folio_Pedido = '" & FolioPedido.Trim & "'", "", DataViewRowState.CurrentRows)
            If dvCan.Count > 0 Then bRes = True
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Si no esta en los pedidos cancelados puede ser que haya sido cancelado en status pendiente por lo tanto ya no aparecerá en los pedidos
        'pendientes por surtir de Ecommerce
        '----------------------------------------------------------------------------------------------------------------------------------------
        If bRes = False AndAlso Modulo.Trim = "PP" Then
            dtPedidosCan = oSapMgr.ZPOL_TRASLPEN(oSapMgr.Read_Centros, dtDetalle, dtTemp)
            If dtPedidosCan.Rows.Count > 0 Then
                dvCan = New DataView(dtPedidosCan, "Folio_Pedido = '" & FolioPedido.Trim & "'", "", DataViewRowState.CurrentRows)
                If dvCan.Count <= 0 Then bRes = True
            Else
                bRes = True
            End If
        End If

        Return bRes

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------
    'Consultamos los pedidos pendientes por surtir, facturar, enviar o cancelar de SiHay
    '--------------------------------------------------------------------------------------------------------------------------------------

    Public Sub RefreshPedidosSiHay()
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim strCentro As String = oSapMgr.Read_Centros
        Dim pedidosSiHay As DataSet = oSapMgr.ZSH_PEDIDOS_HOMEDASH(strCentro)
        surtirSihay = 0
        sinGuiaSiHay = 0
        recibirSiHay = 0
        facturarSiHay = 0
        canceladoSiHay = 0
        insurtiblesSiHay = 0
        For Each row As DataRow In pedidosSiHay.Tables("T_CONTEO").Rows
            Dim status As String = CStr(row!STATUS).ToUpper()
            Dim cantidad As Integer = CInt(row!CANTIDAD)
            If status = "P" Or status = "RP" Then
                surtirSihay += cantidad
            ElseIf status = "PE-L" Or status = "PE-F" Then
                sinGuiaSiHay += cantidad
            ElseIf status = "PF" Then
                facturarSiHay += cantidad
            ElseIf status = "PC" Then
                canceladoSiHay += cantidad
            ElseIf status = "PR" Then
                recibirSiHay += cantidad
            ElseIf status = "IP" Then
                insurtiblesSiHay += cantidad
            End If
        Next
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------
    'Consultamos los pedidos pendientes por surtir, facturar, enviar o cancelar de Ecommerce
    '--------------------------------------------------------------------------------------------------------------------------------------
    Public Sub RefreshPedidosEC()

        'Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim strCentro As String = oSapMgr.Read_Centros
        Dim dtPedidosDet As DataTable
        'Dim dtTrasladosModif As DataTable
        Dim dtPedidos As DataTable = oSapMgr.ZPOL_TRASLPEN(strCentro, dtPedidosDet) ', dtTrasladosModif)
        Dim oRow As DataRow

        gPedidos = 0
        gFacturas = 0
        gGuias = 0
        gCancelados = 0

        '--------------------------------------------------------------------------------------------------------------------------------------
        'Consultamos los pedidos pendientes por surtir y facturar solicitados por Ecommerce
        '--------------------------------------------------------------------------------------------------------------------------------------
        If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
            For Each oRow In dtPedidos.Rows
                If CStr(oRow!Status) = "P" Then 'OrElse dtTrasladosModif.Select("Traslado = '" & CStr(oRow!Folio_Traslado).Trim & "'").Length > 0 Then
                    gPedidos += 1
                ElseIf CStr(oRow!Facturar).Trim = "X" Then
                    gFacturas += 1
                End If
            Next
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Consultamos los pedidos pendientes por enviar solicitados por Ecommerce
        '--------------------------------------------------------------------------------------------------------------------------------------
        dtPedidos = oSapMgr.ZPOL_VALIDA_TRAS_ENV(strCentro)

        If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
            For Each oRow In dtPedidos.Rows
                If (CStr(oRow!Facturar).Trim = "X" AndAlso CStr(oRow!Folio_Factura).Trim <> "") OrElse _
                (CStr(oRow!Facturar).Trim = "" AndAlso CStr(oRow!PuestoExpedicion).Trim <> "") Then
                    gGuias += 1
                End If
            Next
            'Guias = dtPedidos.Rows.Count
        End If
        ''--------------------------------------------------------------------------------------------------------------------------------------
        ''Consultamos los pedidos cancelados solicitados por Ecommerce
        ''--------------------------------------------------------------------------------------------------------------------------------------
        'dtPedidos = Nothing
        'dtPedidos = oSapMgr.ZPOL_PEDIDOSCANCELADOS(dtPedidosDet, strCentro)

        'If Not dtPedidos Is Nothing Then 'AndAlso dtPedidos.Rows.Count > 0 Then
        '    gCancelados = dtPedidos.Rows.Count
        'End If

    End Sub



    Private Sub CreaEstructuraNegadosTS(ByRef dtNegados As DataTable)

        dtNegados = New DataTable("Negados")

        With dtNegados
            .Columns.Add(New DataColumn("Codigo", GetType(String)))
            .Columns.Add(New DataColumn("Talla", GetType(String)))
            .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            .Columns.Add(New DataColumn("Negados", GetType(Integer)))
            .Columns.Add(New DataColumn("Motivo", GetType(String)))
            .Columns.Add(New DataColumn("MotivoDesc", GetType(String)))
            .Columns.Add(New DataColumn("PedidoEC", GetType(String)))
            .Columns.Add(New DataColumn("ID_SOLICITUD", GetType(String)))
            .Columns.Add(New DataColumn("Existencias", GetType(Integer)))
            .Columns.Add(New DataColumn("Solicitados", GetType(Integer)))
            .AcceptChanges()
        End With

    End Sub

    Public Function NegarMaterialesPedidosTS(ByVal dtSource As DataTable, ByVal dtDefectuososEC As DataTable, ByVal dtDefECSAP As DataTable, ByVal Modulo As String) As DataTable

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Dim oRow As DataRow
        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oFacturaTemp As Factura
        Dim dtNegados As DataTable
        Dim oNewRow As DataRow
        Dim Talla As String = ""
        Dim dtMateriales As DataTable = dtSource.Copy
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)

        dtPed = oSapMgr.ZPOL_TRASLPEN(oSapMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        If dtPed.Rows.Count > 0 AndAlso dtPedDet.Rows.Count > 0 Then
            Dim dvPedidoDet As DataView
            Dim CantDef As Integer = 0
            Dim MotivoID As String = "", Motivo As String = ""

            CreaEstructuraNegadosTS(dtNegados)

            Select Case Modulo.Trim.ToUpper
                Case "AS", "V"
                    dtMateriales.Columns("Codigo").ColumnName = "CodArticulo"
                    dtMateriales.AcceptChanges()
                Case "AP"
                    dtMateriales.Columns("Numero").ColumnName = "Talla"
                    dtMateriales.AcceptChanges()
            End Select
            '----------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el ID y la descripción de SAP del motivo de negación de los codigos
            '----------------------------------------------------------------------------------------------------------------------------------
            MotivoID = GetMotivoID(Modulo.Trim.ToUpper, Motivo)

            For Each oRow In dtMateriales.Rows
                For Each oRowP As DataRow In dtPed.Rows
                    If CStr(oRowP!Status).Trim.ToUpper = "P" Then
                        dvPedidoDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowP!Folio_Pedido).Trim & "'", "", DataViewRowState.CurrentRows)
                        For Each oRowPD As DataRowView In dvPedidoDet
                            If CInt(oRowPD!Cant_Pendiente) <= 0 Then GoTo SiguienteMaterial
                            'If IsNumeric(oRow!Talla) Then
                            '    Talla = Format(CDec(oRow!Talla), "#.0")
                            'Else
                            '    Talla = CStr(oRow!Talla).Trim
                            'End If
                            If CStr(oRowPD!Material).Trim.ToUpper = CStr(oRow!CodArticulo).Trim.ToUpper Then ' AndAlso CStr(oRowPD!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                                '----------------------------------------------------------------------------------------------------------------
                                'Obtenemos la cantidad marcada en SAP como de baja calidad para Ecommerce
                                '----------------------------------------------------------------------------------------------------------------
                                CantDef = GetCantidadDefectuososECTS(dtDefectuososEC, dtDefECSAP, oRow!CodArticulo, Talla)

                                'If IsNumeric(oRow!Talla) AndAlso InStr(CStr(oRow!Talla).Trim, ".0") > 0 Then
                                '    Talla = CInt(oRow!Talla)
                                'Else
                                '    Talla = CStr(oRow!Talla).Trim
                                'End If
                                oFacturaTemp = oFacturaMgr.Create()
                                oFacturaMgr.GetExistenciaArticulo(CStr(oRow!CodArticulo).Trim, oAppContext.ApplicationConfiguration.Almacen, "", oFacturaTemp)
                                'oFacturaMgr.GetExistenciaArticulo(CStr(oRow!CodArticulo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
                                '----------------------------------------------------------------------------------------------------------------
                                'Le restamos la cantidad de codigos que tiene marcada como defectuosos en SAP para obtener la cantidad realmente 
                                'libre que queda para surtir los pedidos de Ecommerce
                                '----------------------------------------------------------------------------------------------------------------
                                oFacturaTemp.FacturaArticuloExistencia -= CantDef
                                '----------------------------------------------------------------------------------------------------------------
                                'Revisamos si la cantidad libre menos la cantidad de la factura es menor a la cantidad que le estan solicitando
                                'en el pedido de Ecommerce
                                '----------------------------------------------------------------------------------------------------------------
                                'If oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
                                If oRow!Libres - oRow!Cantidad < CInt(oRowPD!Cant_Pendiente) Then
                                    oNewRow = dtNegados.NewRow
                                    With oNewRow
                                        !Codigo = CStr(oRowPD!Material).Trim
                                        !Talla = CStr(oRowPD!Talla).Trim
                                        !Cantidad = 0
                                        '!Negados = CInt(oRowPD!Cant_Pendiente) - (oFacturaTemp.FacturaArticuloExistencia - oRow!Cantidad)
                                        !Negados = CInt(oRowPD!Cant_Pendiente) - (oRow!Libres - oRow!Cantidad)
                                        !Motivo = MotivoID '"00013"
                                        !MotivoDesc = Motivo '"Traspaso Salida"
                                        !PedidoEC = CStr(oRowP!Folio_Pedido).Trim
                                        !ID_SOLICITUD = CStr(oRowP!ID_SOLICITUD)
                                        !Existencias = CInt(oRow!Libres)
                                        !Solicitados = CInt(oRowPD!Cant_Pendiente)
                                    End With
                                    dtNegados.Rows.Add(oNewRow)
                                End If
                                oFacturaTemp = Nothing
                                GoTo Siguiente
                            End If
SiguienteMaterial:
                        Next
                    End If
                Next
Siguiente:
            Next
        End If

        Return dtNegados

    End Function

    Public Function GetMotivoID(ByVal strMotivo As String, ByRef strDescripcion As String) As String

        Dim strID As String = ""

        Dim dtMotivosTemp As DataTable

        dtMotivosTemp = oSapMgr.ZPOL_GET_MOTIVOS(strMotivo.Trim.ToUpper)

        If dtMotivosTemp.Rows.Count > 0 Then
            strID = dtMotivosTemp.Rows(0)!ID
            strDescripcion = dtMotivosTemp.Rows(0)!Motivo
        End If

        Return strID

    End Function

    Private Function GetCantidadDefectuososECTS(ByVal dtDef As DataTable, ByVal dtDefSAP As DataTable, ByVal Codigo As String, ByVal Talla As String) As Integer

        Dim cant As Integer = 0
        Dim Total As Integer = 0

        If Not dtDefSAP Is Nothing AndAlso dtDefSAP.Rows.Count > 0 Then
            Dim dvCod As New DataView(dtDefSAP, "Material = '" & Codigo.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows) ' And Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)

            If dvCod.Count > 0 Then
                Dim oRow As DataRowView
                'Sacamos la cantidad total por codigo y talla sin importar el motivo de marcado
                Total = dvCod(0)!TotalXTalla
                'Sumamos la cantidad de codigos de baja calidad que van en el detalle de la factura
                dvCod = New DataView(dtDef, "Material = '" & Codigo.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows) ' And Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)
                For Each oRow In dvCod
                    cant += oRow!Cantidad
                Next
                'Restamos la cantidad de codigos que van en el detalle de la factura a la cantidad total marcada en SAP
                Total -= cant
            End If
        End If

        Return Total

    End Function

    Public Function GetCodigosDefectuososEC() As DataTable
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Obtenemos los códigos marcados como de baja calidad para Ecommerce para este centro de SAP
        '-----------------------------------------------------------------------------------------------------------------------------------
        Dim dtTemp As DataTable
        'Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        dtTemp = oSapMgr.ZPOL_GET_DEFT_CENTRO
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Quitamos los marcados de baja calidad por faltantes en traspasos de entrada, ya que la única forma de desmarcarlos es autorizando o
        'cancelando el traspaso de salida pendiente generado
        '-----------------------------------------------------------------------------------------------------------------------------------
        Dim MarcadoID As String = ""
        Dim dvFal As DataView
        Dim dtMotivosTemp As DataTable
        Dim oRowV As DataRowView

        dtMotivosTemp = oSapMgr.ZPOL_GET_MOTIVOS("FT")

        If dtMotivosTemp.Rows.Count > 0 Then
            MarcadoID = dtMotivosTemp.Rows(0)!ID
        End If

        dvFal = New DataView(dtTemp, "ID <> '" & MarcadoID & "'", "", DataViewRowState.CurrentRows)

        dtMotivosTemp = dtTemp.Clone
        For Each oRowV In dvFal
            dtMotivosTemp.ImportRow(oRowV.Row)
        Next

        dtTemp = dtMotivosTemp.Copy

        Return dtTemp

    End Function

    Public Function CreateMaterialEnAclaracion() As DataTable
        Dim dtMaterial As New DataTable("MaterialEnAclaracion")
        dtMaterial.Columns.Add("CodArticulo", GetType(String))
        dtMaterial.Columns.Add("Libres", GetType(Integer))
        dtMaterial.Columns.Add("Solicitados", GetType(Integer))
        dtMaterial.Columns.Add("EnReserva", GetType(Integer))
        dtMaterial.AcceptChanges()
        Return dtMaterial
    End Function


    Public Function CreateMaterialFaltanteEC() As DataTable
        Dim dtMaterial As New DataTable("MaterialFaltante")
        dtMaterial.Columns.Add("CodArticulo", GetType(String))
        dtMaterial.Columns.Add("Talla", GetType(String))
        dtMaterial.Columns.Add("Existencia", GetType(Integer))
        dtMaterial.Columns.Add("Solicitado", GetType(Integer))
        dtMaterial.AcceptChanges()
        Return dtMaterial
    End Function

    Public Function ValidarMaterialesBajaCalidad(ByVal dtArticulos As DataTable) As Boolean

        'For Each row As DataRow In odtArticulosTras.Rows
        '    codarticulo = CStr(row!CodArticulo)
        '    dtDetail = CatArticuloMgr.GetDetalleArticuloDefectuosos(codarticulo)
        '    cantidadDefec = CInt(row!Lecturado)
        '    For Each fila As DataRow In dtDetail.Rows
        '        filarow = dtMat.NewRow()
        '        filarow("CodArticulo") = CStr(row("CodArticulo"))
        '        filarow("Talla") = CStr(row("Talla"))
        '        If cantidadDefec >= CInt(fila("Cantidad")) Then
        '            filarow("Cantidad") = fila("Cantidad")
        '        Else
        '            filarow("Cantidad") = cantidadDefec
        '        End If
        '        cantidadDefec -= CInt(fila("Cantidad"))
        '        filarow("MotivoDefectuoso") = CatArticuloMgr.GetCodMoTivoDefectuoso(fila("DefectoNota"))
        '        dtMat.Rows.Add(filarow)
        '        If cantidadDefec <= 0 Then
        '            Exit For
        '        End If
        '    Next
        'Next



    End Function


    Public Function ProductosEnAclaracionLocal(ByVal dtProductos As DataTable) As DataTable
        Dim dtArticulos As DataTable = GetProductosAclaracion()
        Dim oFacturaMgr As FacturaManager
        Dim dtResult As DataTable

        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        For Each oRow As DataRow In dtProductos.Rows
            dtResult = oFacturaMgr.GetArtAclaracion(oRow("Codigo"))
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                dtArticulos.ImportRow(dtResult.Rows(0))
            End If
        Next

        Return dtArticulos
    End Function

    Public Function ValidarProductosEnAclaracionLocal(ByVal dtMateriales As DataTable) As Boolean
        Dim bRes As Boolean = True
        Dim dtAclaracion As DataTable
        Dim dtProductos As DataTable = CreateMaterialEnAclaracion()

        If dtMateriales.Columns.Contains("CodArticulo") Then
            dtMateriales.Columns("CodArticulo").ColumnName = "Codigo"
        End If

        If dtMateriales.Columns.Contains("ConExistencia") Then
            dtMateriales.Columns("ConExistencia").ColumnName = "Libres"
        End If

        If Not dtMateriales Is Nothing AndAlso dtMateriales.Rows.Count > 0 Then
            dtAclaracion = ProductosEnAclaracionLocal(dtMateriales)

            If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then

                For Each oRow As DataRow In dtMateriales.Rows

                    Dim cantidad As Integer = oRow!Cantidad
                    Dim libres As Integer = oRow!Libres
                    Dim reserva As Integer = 0

                    Dim result As Object = (dtAclaracion.Compute("SUM(Cantidad)", "CodArticulo = '" & oRow!Codigo & "'"))

                    If Not result Is DBNull.Value Then
                        reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "CodArticulo = '" & oRow!Codigo & "'"))
                    End If


                    If reserva > 0 Then
                        If (libres - cantidad) < reserva Then
                            '-----------------------------------------------------------------------------------------------------------------------------------
                            ' MLVARGAS (13/07/2022) Agregar a una tabla los artículos en reserva
                            '-----------------------------------------------------------------------------------------------------------------------------------
                            Dim fila As DataRow = dtProductos.NewRow()
                            fila("CodArticulo") = oRow!Codigo
                            fila("Libres") = libres
                            fila("Solicitados") = cantidad
                            fila("EnReserva") = reserva
                            dtProductos.Rows.Add(fila)

                        End If
                    End If
                Next

                If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
                    ShowFormMessage(dtProductos, "Artículos negados por que se encuentran en Aclaración", GetAtributosMaterialEnAclaracion())
                    bRes = False
                End If

            End If
        End If

        Return bRes
    End Function

    Public Function ValidarProductosEnAclaracion(ByVal dtAclaracion As DataTable, ByVal dtMateriales As DataTable, Optional bSiHay As Boolean = False) As Boolean
        Dim bRes As Boolean = True
        Dim dtProductos As DataTable = CreateMaterialEnAclaracion()

        If dtMateriales.Columns.Contains("CodArticulo") Then
            dtMateriales.Columns("CodArticulo").ColumnName = "Codigo"
        End If

        If dtMateriales.Columns.Contains("ConExistencia") Then
            dtMateriales.Columns("ConExistencia").ColumnName = "Libres"
        End If


        If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then
            For Each oRow As DataRow In dtMateriales.Rows

                Dim cantidad As Integer = oRow!Cantidad
                Dim libres As Integer = oRow!Libres
                Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "MATNR = '" & oRow!Codigo & "' And TIPO_RESERVA = 'Aclaracion'"))

                If reserva > 0 Then
                    If (libres - cantidad) < reserva Then
                        '-----------------------------------------------------------------------------------------------------------------------------------
                        ' MLVARGAS (06/06/2022) Agregar a una tabla los artículos en reserva
                        '-----------------------------------------------------------------------------------------------------------------------------------
                        Dim fila As DataRow = dtProductos.NewRow()
                        fila("CodArticulo") = oRow!Codigo
                        fila("Libres") = libres
                        fila("Solicitados") = cantidad
                        fila("EnReserva") = reserva
                        dtProductos.Rows.Add(fila)

                    End If
                End If

            Next

            If bSiHay Then
                dtMateriales.Columns("Libres").ColumnName = "ConExistencia"
            End If

            If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
                ShowFormMessage(dtProductos, "Artículos negados por que se encuentran en Aclaración", GetAtributosMaterialEnAclaracion())
                bRes = False
            End If

        End If
        Return bRes
    End Function


    Public Function ValidarProductosEnNecesidad(ByVal dtAclaracion As DataTable, ByVal dtMateriales As DataTable, Optional bSiHay As Boolean = False) As Boolean
        Dim bRes As Boolean = True
        Dim dtProductos As DataTable = CreateMaterialEnAclaracion()

        If dtMateriales.Columns.Contains("CodArticulo") Then
            dtMateriales.Columns("CodArticulo").ColumnName = "Codigo"
        End If

        If dtMateriales.Columns.Contains("ConExistencia") Then
            dtMateriales.Columns("ConExistencia").ColumnName = "Libres"
        End If


        If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then
            For Each oRow As DataRow In dtMateriales.Rows

                Dim cantidad As Integer = oRow!Cantidad
                Dim libres As Integer = oRow!Libres
                Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "MATNR = '" & oRow!Codigo & "' And TIPO_RESERVA = 'Necesidad'"))

                If reserva > 0 Then
                    If (libres - cantidad) < reserva Then
                        '-----------------------------------------------------------------------------------------------------------------------------------
                        ' MLVARGAS (06/06/2022) Agregar a una tabla los artículos en reserva
                        '-----------------------------------------------------------------------------------------------------------------------------------
                        Dim fila As DataRow = dtProductos.NewRow()
                        fila("CodArticulo") = oRow!Codigo
                        fila("Libres") = libres
                        fila("Solicitados") = cantidad
                        fila("EnReserva") = reserva
                        dtProductos.Rows.Add(fila)

                    End If
                End If

            Next

            If bSiHay Then
                dtMateriales.Columns("Libres").ColumnName = "ConExistencia"
            End If

            If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
                ShowFormMessage(dtProductos, "Artículos negados por que se encuentran en Necesidad", GetAtributosMaterialEnReserva())
                bRes = False
            End If

        End If
        Return bRes
    End Function

    Public Function ValidarMaterialesParaNegarEC(ByRef dtNegados As DataTable, ByVal dtMateriales As DataTable, ByVal dtDefectuososEC As DataTable, _
                                                 ByVal dtDefecECSAP As DataTable, ByVal UserNameDesmarca As String, ByVal Modulo As String) As Boolean

        Dim bRes As Boolean = True
        Dim UserNameNiega As String = ""

        If oConfigCierreFI.SurtirEcommerce Then
            dtNegados = NegarMaterialesPedidosTS(dtMateriales, dtDefectuososEC, dtDefecECSAP, Modulo)
            UserNameNiega = UserNameDesmarca
            If Not dtNegados Is Nothing AndAlso dtNegados.Rows.Count > 0 Then
                Dim strMsg As String = ""

                '-----------------------------------------------------------------------------------------------------------------------------------
                'Versión anterior, se consultaba al usuario si queria vender los materiales apartados de ventas de Ecommerce
                '-----------------------------------------------------------------------------------------------------------------------------------

                'strMsg = "Hay codigos en el detalle de la operación que se negaran a algun pedido solicitado por Ecommerce"
                'If UserNameNiega.Trim = "" Then
                '    strMsg &= vbCrLf & "Sera necesario identificarse para continuar"
                'End If
                'strMsg &= vbCrLf & vbCrLf & "¿Desea continuar con el proceso?"
                'If MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                '    If UserNameNiega.Trim = "" Then
                '        oAppContext.Security.CloseImpersonatedSession()
                '        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") = False Then
                '            MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '            bRes = False
                '        Else
                '            UserNameNiega = oAppContext.Security.CurrentUser.Name
                '            oAppContext.Security.CloseImpersonatedSession()
                '        End If
                '    End If
                'Else
                '    bRes = False
                'End If

                '-----------------------------------------------------------------------------------------------------------------------------------
                ' MLVARGAS (20/05/2022) Agregar a una tabla los artículos vendidos por Ecommerce que se encuentran en el detalle de la venta
                '-----------------------------------------------------------------------------------------------------------------------------------
                Dim dtFaltante As DataTable = CreateMaterialFaltanteEC()

                For Each oRow As DataRow In dtNegados.Rows
                    Dim fila As DataRow = dtFaltante.NewRow()

                    fila("CodArticulo") = oRow!Codigo
                    fila("talla") = oRow!Talla
                    fila("Existencia") = oRow!Existencias
                    fila("Solicitado") = oRow!Solicitados
                    dtFaltante.Rows.Add(fila)
                Next

                ShowFormMessage(dtFaltante, "Artículos Negados porque están pendientes por surtir o Facturar para Ecommerces", GetAtributosMaterialesEcommerce())
                bRes = False

            End If
        End If

        Return bRes

    End Function



    Public Function ValidarMaterialesDefectuososEC(ByVal dtSource As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String, _
                                                   ByVal Modulo As String, ByRef dtDefecSAP As DataTable) As Boolean
        Dim bRes As Boolean = True
        '----------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/06/2015: Solo bloqueara los artículos de baja calidad siempre y cuando la configuracion de bloqueo de articulos sea false
        '----------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.BloqueaBajaCalidad = False Then

            Dim oRowM As DataRow
            Dim dtDefEC As DataTable
            Dim dtTemp As DataTable
            Dim oFacturaTemp As Factura
            Dim oNewRow As DataRow
            Dim Talla As String = ""
            Dim Max As Integer = 0, Min As Integer = 0, CantFactura As Integer = 0
            Dim Libres As Integer = 0
            Dim Solicitados As Integer = 0

            Dim dvMatDef As DataView
            Dim oRowDEC As DataRowView
            Dim MotivoDesmarcado As String = ""
            Dim dtMotivosDes As DataTable
            Dim DesID As String = ""
            Dim CantXTalla As Integer = 0
            'Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim dtMateriales As DataTable = dtSource.Copy

            oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

            'dtDefEC = oSapMgr.ZPOL_GET_DEFT_CENTRO()
            '  dtDefEC = GetCodigosDefectuososEC()

            '--------------------------------------------------------------------------------------------------------------------
            ' MLVARGAS (20.07.2022): Cargar los materiales de baja calidad de la base de datos local
            '--------------------------------------------------------------------------------------------------------------------

            dtDefEC = oFacturaMgr.BajaCalidadSel()


            If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then
                '--------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08.02.2017): Comentamos por que el motivo de desmarcado esel mismo que el de marcado
                '--------------------------------------------------------------------------------------------------------------------
                ''--------------------------------------------------------------------------------------------------------------------
                ''Obtenemos el id de motivo de desmarcado de SAP
                ''--------------------------------------------------------------------------------------------------------------------
                'dtMotivosDes = oSapMgr.ZPOL_GET_MOTIVOS(Modulo.Trim.ToUpper)
                'If dtMotivosDes.Rows.Count > 0 Then
                '    MotivoDesmarcado = dtMotivosDes.Rows(0)!Motivo
                '    DesID = dtMotivosDes.Rows(0)!ID
                'End If
                '--------------------------------------------------------------------------------------------------------------------

                Select Case Modulo.Trim.ToUpper
                    Case "TS"
                        dtMateriales.Columns("CodArticulo").ColumnName = "Codigo"
                        dtMateriales.AcceptChanges()
                    Case "AP"
                        dtMateriales.Columns("CodArticulo").ColumnName = "Codigo"
                        dtMateriales.Columns("Numero").ColumnName = "Talla"
                        dtMateriales.AcceptChanges()
                End Select

                dtTemp = dtDefEC.Clone
                dtTemp.Columns.Add("Minimo", GetType(Integer))
                dtTemp.Columns.Add("Maximo", GetType(Integer))
                dtTemp.Columns.Add("MaximoTotal", GetType(Integer))
                If dtTemp.Columns.Contains("Motivo") = False Then
                    dtTemp.Columns.Add("Motivo", GetType(String))  'Motivo por el que se está desmarcando
                End If
                dtTemp.Columns.Add("MotivoMarc", GetType(String)) 'Motivo por el que estaba marcado
                dtTemp.Columns.Add("DesmarcadoID", GetType(String))
                dtTemp.Columns.Add("MarcadoID", GetType(String))
                dtTemp.Columns.Add("TotalXTalla", GetType(Integer)) 'Cantidad total de un mismo codigo en una misma talla
                dtTemp.AcceptChanges()

                For Each oRowM In dtMateriales.Rows

                    'If IsNumeric(oRowM!Talla) Then
                    '    Talla = Format(CDec(oRowM!Talla), "#.0")
                    'Else
                    '    Talla = CStr(oRowM!Talla).Trim
                    'End If
                    '--------------------------------------------------------------------------------------------------------------------
                    'Filtramos por Codigo y Talla para separarlos por los diferentes motivos de marcado
                    '--------------------------------------------------------------------------------------------------------------------
                    dvMatDef = New DataView(dtDefEC, "Material = '" & CStr(oRowM!Codigo) & "'", "", DataViewRowState.CurrentRows) ' and Talla = '" & Talla.Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)

                    If dvMatDef.Count > 0 Then

                        CantXTalla = dtDefEC.Compute("SUM(Cantidad)", "Material = '" & CStr(oRowM!Codigo) & "'") 'and Talla = '" & Talla.Trim.ToUpper & "'")

                        'If IsNumeric(oRowM!Talla) AndAlso InStr(CStr(oRowM!Talla).Trim, ".0") > 0 Then
                        '    Talla = CInt(oRowM!Talla)
                        'Else
                        '    Talla = CStr(oRowM!Talla).Trim
                        'End If
                        oFacturaTemp = oFacturaMgr.Create()
                        oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, "", oFacturaTemp)
                        'oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)

                        Max = 0 : Min = 0

                        'If (oFacturaTemp.FacturaArticuloExistencia - CantXTalla) >= oRowM!Cantidad Then
                        '---------------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 16.07.2013: Revisamos si la cantidad en la factura es mayor a la que se tiene en existencia (en el caso de los pedidos Si Hay)
                        'entonces la cantidad sobre la que se calcula el minimo es la que se tiene en existencia
                        '---------------------------------------------------------------------------------------------------------------------------------------
                        CantFactura = IIf(oRowM!Cantidad > oRowM!Libres, oRowM!Libres, oRowM!Cantidad)
                        Libres = oRowM!Libres
                        Solicitados = oRowM!Cantidad

                        If (oRowM!Libres - CantXTalla) >= CantFactura Then
                            Min = 0
                        Else
                            'Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - CantXTalla)
                            Min = CantFactura - (oRowM!Libres - CantXTalla)
                        End If

                        oFacturaTemp = Nothing


                        If Libres - CantXTalla < Solicitados Then
                            For Each oRowDEC In dvMatDef
                                Max = IIf(oRowDEC!Cantidad < oRowM!Cantidad, oRowDEC!Cantidad, oRowM!Cantidad)
                                oNewRow = dtTemp.NewRow
                                With oNewRow
                                    !Material = CStr(oRowDEC!Material).Trim
                                    If Not oRowDEC!Talla Is DBNull.Value Then
                                        !Talla = CStr(oRowDEC!Talla).Trim
                                    Else
                                        !Talla = ""
                                    End If
                                    !Cantidad = 0
                                    !Minimo = Min
                                    !Maximo = Max
                                    !MaximoTotal = oRowM!Cantidad
                                    '--------------------------------------------------------------------------------------------------------------------
                                    ' JNAVA (08.02.2017): Obtenemos el id y motivo de desmarcado correcto para baja calidad
                                    '--------------------------------------------------------------------------------------------------------------------
                                    !Motivo = CStr(oRowDEC!Motivo).Trim 'MotivoDesmarcado.Trim
                                    !DesmarcadoID = CStr(oRowDEC!IDMotivo).Trim 'DesID.Trim
                                    '--------------------------------------------------------------------------------------------------------------------
                                    !MarcadoID = CStr(oRowDEC!IDMotivo).Trim
                                    !MotivoMarc = CStr(oRowDEC!Motivo).Trim
                                    !TotalXTalla = CantXTalla
                                End With
                                dtTemp.Rows.Add(oNewRow)
                            Next
                        End If
                    End If
                Next
                'Copiamos el detalle de los codigos que van en la factura que estan marcados en SAP como de baja calidad para EC
                dtDefecSAP = dtTemp.Copy

                If dtTemp.Rows.Count > 0 Then
                    If UserName.Trim = "" Then
                        If MessageBox.Show("Existen codigos marcados como de baja calidad que podrian ir en el detalle de esta operación." & vbCrLf & "Es necesario especificarlos." & _
                        vbCrLf & vbCrLf & "¿Desea continuar con este proceso?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                            bRes = False
                        End If
                    End If
                    If bRes = True Then
                        Dim oFrmDE As New frmDesmarcarDefectuososEC
                        oFrmDE.dtSource = dtTemp
                        oFrmDE.UserDesmarca = UserName.Trim
                        If oFrmDE.ShowDialog() = DialogResult.OK Then
                            dtDefecEC = oFrmDE.dtDefectuososEC.Copy
                            UserName = oFrmDE.UserDesmarca.Trim
                        Else
                            MessageBox.Show("Es necesario especificar las piezas marcadas como baja calidad que van en la operación.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bRes = False
                        End If
                    Else
                        bRes = False
                    End If
                End If
            End If
        End If
        Return bRes
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/06/2015: Truncar totales
    '---------------------------------------------------------------------------------------------------------------------------

    Public Function TruncarTotales(ByVal numero As Decimal) As Decimal
        Dim decimales As Decimal = 0
        decimales = numero - Int(numero)
        If decimales < 0.1 Then
            numero = Decimal.Round(numero, 1)
        End If
        numero = Decimal.Round(numero, 2)
        Return numero
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/06/2015: Trunca Valores dependiendo
    '---------------------------------------------------------------------------------------------------------------------------
    Public Function Truncar(ByVal numero As Decimal, ByVal decimales As Integer)
        Dim dec As Decimal = 0
        Dim strValor As String, concat As String = "", strEntero As String = ""
        Dim i As Integer = 0

        Dim strNumDec() As String

        '------------------------------------------------------------
        'JNAVA (25.06.2015): Si el numero es Cero no hace nada
        '------------------------------------------------------------
        If numero = 0 Then
            Return 0.0
            Exit Function
        End If

        dec = numero - Int(numero)
        If dec = 0 Then
            Return numero
        End If

        strEntero = CStr(Int(numero))
        '------------------------------------------------------------
        'JNAVA (29.07.2015): Obtenemos solo los decimales (sin punto)
        '------------------------------------------------------------
        'strValor = CStr(dec).Replace(".", "")
        strNumDec = CStr(dec).Split(".")
        strValor = strNumDec(strNumDec.Length - 1)

        If strValor.Length > 0 Then

            '------------------------------------------------------------
            'JNAVA (29.07.2015): Validamos los decimales 
            '------------------------------------------------------------
            If CStr(strValor).Length < decimales Then
                decimales = CStr(strValor).Length
            End If

            '------------------------------------------------------------
            'JNAVA (29.07.2015): Obtenemos los nuevos decimales
            '------------------------------------------------------------
            For i = 0 To decimales - 1
                concat &= strValor.ToCharArray()(i)
            Next
            strEntero &= "." & concat
            numero = CDec(strEntero)
        End If
        Return Math.Round(numero, 2)
    End Function

    'Public Function ValidarMaterialesDefectuososTS(ByVal dtMateriales As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String) As Boolean

    '    Dim oRowM As DataRow
    '    Dim dtDefEC As DataTable
    '    Dim dtTemp As DataTable
    '    Dim oFacturaTemp As Factura
    '    Dim oNewRow As DataRow
    '    Dim Talla As String = ""
    '    Dim Max As Integer = 0, Min As Integer = 0
    '    Dim bRes As Boolean = True
    '    Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    '    Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)

    '    dtDefEC = oSap.ZPOL_GET_DEFT_CENTRO()

    '    If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then

    '        dtTemp = dtDefEC.Clone
    '        dtTemp.Columns.Add("Minimo", GetType(Integer))
    '        dtTemp.Columns.Add("Maximo", GetType(Integer))
    '        dtTemp.Columns.Add("Motivo", GetType(String))
    '        dtTemp.AcceptChanges()

    '        For Each oRowM In dtMateriales.Rows
    '            For Each oRowDE As DataRow In dtDefEC.Rows
    '                If IsNumeric(oRowM!Talla) Then
    '                    Talla = Format(CDec(oRowM!Talla), "#.0")
    '                Else
    '                    Talla = CStr(oRowM!Talla).Trim
    '                End If
    '                If CStr(oRowDE!Material).Trim.ToUpper = CStr(oRowM!CodArticulo).Trim.ToUpper AndAlso CStr(oRowDE!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
    '                    If IsNumeric(oRowM!Talla) AndAlso InStr(CStr(oRowM!Talla).Trim, ".0") > 0 Then
    '                        Talla = CInt(oRowM!Talla)
    '                    Else
    '                        Talla = CStr(oRowM!Talla).Trim
    '                    End If
    '                    oFacturaTemp = oFacturaMgr.Create()
    '                    oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!CodArticulo).Trim, oAppContext.ApplicationConfiguration.Almacen, Talla.Trim, oFacturaTemp)
    '                    Max = 0 : Min = 0
    '                    If (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad) >= oRowM!Cantidad Then
    '                        Min = 0
    '                    Else
    '                        Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - oRowDE!Cantidad)
    '                    End If
    '                    Max = IIf(oRowDE!Cantidad < oRowM!Cantidad, oRowDE!Cantidad, oRowM!Cantidad)
    '                    oNewRow = dtTemp.NewRow
    '                    With oNewRow
    '                        !Material = CStr(oRowDE!Material).Trim
    '                        !Talla = CStr(oRowDE!Talla).Trim
    '                        !Cantidad = Min
    '                        !Minimo = Min
    '                        !Maximo = Max
    '                        !Motivo = "Enviado en el traspaso "
    '                    End With
    '                    dtTemp.Rows.Add(oNewRow)
    '                    oFacturaTemp = Nothing
    '                    Exit For
    '                End If
    '            Next
    '        Next

    '        If dtTemp.Rows.Count > 0 Then
    '            If UserName.Trim = "" Then
    '                If MessageBox.Show("Existen codigos marcados como de baja calidad que podrian ir en el detalle de esta operación." & vbCrLf & "Es necesario especificarlos." & _
    '                vbCrLf & vbCrLf & "¿Desea continuar con este proceso?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
    '                    bRes = False
    '                End If
    '            End If
    '            If bRes = True Then
    '                Dim oFrmDE As New frmDesmarcarDefectuososEC
    '                oFrmDE.dtSource = dtTemp
    '                oFrmDE.UserDesmarca = UserName.Trim
    '                If oFrmDE.ShowDialog() = DialogResult.OK Then
    '                    dtDefecEC = oFrmDE.dtDefectuososEC.Copy
    '                    UserName = oFrmDE.UserDesmarca.Trim
    '                Else
    '                    MessageBox.Show("Es necesario especificar las piezas marcadas como baja calidad que van en la operacion.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    bRes = False
    '                End If
    '            Else
    '                bRes = False
    '            End If
    '        End If
    '    End If

    '    Return bRes

    'End Function

    Public Sub ValidarCambioStatusPedidoTS(ByVal dtNegados As DataTable, ByVal Responsable As String)

        Dim dtPed As DataTable
        Dim dtPedDet As DataTable
        'Dim dtTrasModif As DataTable
        Dim oRowN As DataRow, oRowP As DataRow
        Dim Pedidos As String = ""
        Dim dvPedDet As DataView
        'Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        dtPed = oSapMgr.ZPOL_TRASLPEN(oSapMgr.Read_Centros, dtPedDet) ', dtTrasModif)

        For Each oRowN In dtNegados.Rows
            If InStr(Pedidos.Trim.ToUpper, CStr(oRowN!PedidoEC).Trim.ToUpper) <= 0 Then
                Pedidos &= CStr(oRowN!PedidoEC).Trim.ToUpper & ","
                dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And (Cant_Pendiente > 0 Or Cant_Entregado > 0)", "", DataViewRowState.CurrentRows)
                'dvPedDet = New DataView(dtPedDet, "Folio_Pedido = '" & CStr(oRowN!PedidoEC).Trim & "' And Cant_Pendiente > 0", "", DataViewRowState.CurrentRows)
                If dvPedDet.Count <= 0 Then
                    oSapMgr.ZPOL_ACTTRASL(CStr(oRowN!PedidoEC).Trim, "", "N", "", Responsable.Trim, Nothing, "")
                End If
            End If
        Next

    End Sub

#End Region

    Public Function ValidaDatosObligatoriosCliente(ByVal oClienteTemp As ClienteAlterno, Optional ByVal DPVale As Boolean = False) As Boolean

        Dim bRes As Boolean = True
        Dim oFingerTemp As FingerPrint
        Dim oFingerPMgr As FingerPrintManager

        If oConfigCierreFI.UsarHuellas OrElse oConfigCierreFI.ValidaDatosDPVL OrElse DPVale Then
            If Not oClienteTemp Is Nothing Then

                With oClienteTemp
                    If .TipoVenta.Trim = "" Then
                        bRes = False
                    ElseIf .Nombre.Trim = "" Then
                        bRes = False
                    ElseIf .ApellidoPaterno.Trim = "" AndAlso .Sexo.Trim() <> "E" Then
                        bRes = False
                    ElseIf .ApellidoMaterno.Trim = "" AndAlso .Sexo.Trim() <> "E" Then
                        bRes = False
                    ElseIf .Direccion.Trim = "" Then
                        bRes = False
                    ElseIf .TipoVenta = "P" AndAlso .NumExt.Trim = "" Then
                        bRes = False
                    ElseIf .Colonia.Trim = "" Then
                        bRes = False
                    ElseIf .Estado.Trim = "" Then
                        bRes = False
                    ElseIf .Ciudad.Trim = "" Then
                        bRes = False
                    ElseIf .CP.Trim = "" Then
                        bRes = False
                    ElseIf String.Compare(oClienteTemp.Sexo.Trim, "", True) = 0 Then
                        bRes = False
                    ElseIf CStr(.FechaNacimiento).Trim = "" Then
                        bRes = False
                    ElseIf IsDate(.FechaNacimiento) = False OrElse (.EsEmpresa = False AndAlso .FechaNacimiento > Today.AddYears(-7)) OrElse .FechaNacimiento > Today Then
                        bRes = False
                        'ElseIf .CodPlayer.Trim = "" Then
                        '    bRes = False
                    ElseIf .RFC.Trim = "" Then
                        bRes = False
                        'ElseIf oConfigCierreFI.HuellaOpcional = False AndAlso .EsEmpresa = False Then
                        '    oFingerPMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)
                        '    oFingerTemp = oFingerPMgr.LoadByClienteID(.CodigoAlterno.Trim)
                        '    If oFingerTemp.IsNew Then bRes = False
                        '    oFingerPMgr.Dispose()
                        '    oFingerPMgr = Nothing
                    End If
                End With
            Else
                bRes = False
            End If
        End If

        Return bRes

    End Function

    Public Function GetRutaCmls() As String

        Dim reg As RegistryKey
        Dim strRuta As String = ""

        reg = Registry.CurrentUser.OpenSubKey("Software\DportenisPro", False)
        If Not reg Is Nothing Then
            strRuta = CStr(reg.GetValue("RutaCmls")).Trim
        End If

        If strRuta.Trim = "" Then strRuta = Application.StartupPath

        reg = Nothing

        Return strRuta.Trim

    End Function

    Public Sub CrearArchivoConfigPinPad(ByVal strRuta As String)

        If File.Exists(strRuta) = False Then

            Dim oStreamW As New StreamWriter(strRuta, True)

            oStreamW.WriteLine("PINPADTIMEOUT:10")
            oStreamW.WriteLine("NOMBREPUERTO:COM3")
            oStreamW.WriteLine("NOMBRECOMERCIO:DPORTENIS")
            oStreamW.WriteLine("DIRECCIONBINES:")
            oStreamW.Close()
            oStreamW = Nothing

        End If

    End Sub

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)
        Dim StreamW As New StreamWriter(Application.StartupPath & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub


    '-------------------------------------------------------------------------------------------------
    ' JNAVA (03.06.2016): Escribe log con tiempos por de transacciones de DPPRO a BUS/SAP y Viceversa
    '-------------------------------------------------------------------------------------------------
    Public Sub EscribeLogTransacciones(ByVal EsInicio As Boolean, _
                                       ByVal Fecha As DateTime, _
                                       ByVal NombreTransaccion As String, _
                                       Optional ByVal SerialID As String = "", _
                                       Optional ByVal Mensaje As String = "", _
                                       Optional ByVal TotalTiempo As Long = 0)

        Dim NombreArchivo As String = "\TransaccionesBUSLogFile.txt"
        Dim StreamW As New StreamWriter(Application.StartupPath & NombreArchivo, True)
        If EsInicio Then
            StreamW.WriteLine("".PadLeft(150, "*"))
            StreamW.WriteLine()
            StreamW.WriteLine("--------> " & NombreTransaccion & "  " & SerialID)
            StreamW.WriteLine("INICIO -> " & Fecha)
        Else
            StreamW.WriteLine("FIN ----> " & Fecha)
            StreamW.WriteLine("INFO ---> " & Mensaje)
            StreamW.WriteLine("--------> Tiempo Total de Espera: " & TotalTiempo & " Seg.")
            StreamW.WriteLine()
        End If

        StreamW.Close()

    End Sub

    Public Sub DesencriptarCML(ByVal RutaArchivo As String)

        Dim strCont As String = ""
        Dim StreamR As StreamReader
        Dim StreamW As StreamWriter

        If File.Exists(RutaArchivo) Then

Desencriptar:

            StreamR = New StreamReader(RutaArchivo, System.Text.Encoding.Default)
            strCont = StreamR.ReadToEnd
            StreamR.Close()

            Try
                strCont = oSecurity.DesEncriptarCML(strCont)
            Catch ex As Exception
                EncriptarCML(RutaArchivo)
                GoTo Desencriptar
            End Try

            StreamW = New StreamWriter(RutaArchivo, False)
            StreamW.Write(strCont)
            StreamW.Close()

        End If

    End Sub

    Public Sub EncriptarCML(ByVal RutaArchivo As String)

        Dim strCont As String = ""
        Dim StreamR As StreamReader
        Dim StreamW As StreamWriter

        If File.Exists(RutaArchivo) Then

            StreamR = New StreamReader(RutaArchivo, System.Text.Encoding.Default)
            strCont = StreamR.ReadToEnd
            StreamR.Close()

            Try
                strCont = oSecurity.EncriptarCML(strCont)
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al encriptar el archivo.", "Consultor Saldo DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End Try

            StreamW = New StreamWriter(RutaArchivo, False)
            StreamW.Write(strCont)
            StreamW.Close()

        End If

    End Sub

    Private Sub CorrigeXML(ByVal strRuta As String)
        If Not IO.File.Exists(strRuta) Then
            Exit Sub
        End If
        Dim txtbx As New TextBox
        Dim sr As StreamReader = New StreamReader(strRuta)
        txtbx.Text = sr.ReadToEnd()
        sr.Close()
        If txtbx.Text.IndexOf("ConfigSaveArchivos") <> -1 Then
            txtbx.Text = txtbx.Text.Replace("ConfigSaveArchivos", "SaveConfigArchivos")
            Dim fSave As New StreamWriter(strRuta)
            fSave.WriteLine(txtbx.Text)
            fSave.Flush()
            fSave.Close()
        End If
    End Sub

    Private Sub GenerateSettings()

        With oAppContext.ApplicationConfiguration

            With .DataStorageConfiguration

                .ApplicationName = Application.ProductName
                .Server = "OPERACIONES"
                .Database = "DPTienda"
                .User = "sa"
                .Password = "sa"
                .ConnectionTimeout = 15

                MsgBox(.IsConnectionValid.ToString)

            End With

        End With

        oAppContext.SaveSettings()

    End Sub

    Public Sub OnThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)

        EscribeLog(e.Exception.ToString, "Error general en Dportenis PRO")
        oAppContext.ExceptionReporting.HandleException(e.Exception)

    End Sub

    Public Sub TestCrearAlmacen()

        Dim oCatalogoAlmacenesDG As DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager
        oCatalogoAlmacenesDG = New DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)

        Dim oAlmacen As DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen



        Dim intAlmacen As Integer

        For intAlmacen = 0 To 10

            oAlmacen = oCatalogoAlmacenesDG.Create

            With oAlmacen
                .ID = intAlmacen.ToString("000")
                .Descripcion = "Almacen de prueba " & intAlmacen.ToString
                .EsTienda = False
                .MostrarEnSeparaciones = True
                .PlazaID = "MZT"

                Try
                    .Save()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End With

        Next

    End Sub

    Public Sub TestLeerAlmacen()

        Dim oCatalogoAlmacenesDG As DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager
        oCatalogoAlmacenesDG = New DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)

        Dim oAlmacen As DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen

        oAlmacen = oCatalogoAlmacenesDG.Load("000")
        MsgBox(oAlmacen.ID & " - " & oAlmacen.Descripcion)

        oAlmacen.Descripcion = Date.Now.ToString()

        oAlmacen.Save()

        oAlmacen = oCatalogoAlmacenesDG.Load("000")
        MsgBox(oAlmacen.ID & " - " & oAlmacen.Descripcion)

        oCatalogoAlmacenesDG.Delete("000")

    End Sub

    Public Function GetClientePedidoSH(ByVal oPedido As Pedidos) As String
        Dim strClienteID As String = ""

        Select Case oPedido.CodTipoVenta
            Case "P", "E"
                strClienteID = "0010000000"
            Case "A"
                strClienteID = "0010000015"
            Case "I"
                strClienteID = "0000100020"
            Case "S", "D"
                strClienteID = CStr(oPedido.ClienteID).PadLeft(10, "0")
            Case "F", "K"
                strClienteID = "0010000017"
            Case "O"
                strClienteID = "0010000016"
            Case "V"
                'If Not dtDPVale Is Nothing AndAlso dtDPVale.Rows.Count > 0 Then
                '    arDatosDPVale = GetDPValeSAP()
                '    'Se toma el codigo del distribuidor porque es a quien se le pone el saldo a favor cuando se hace una devolucion de dpvale
                'strClienteID = GetCodigoSAPASociado(owsDPValeInfo.AsociadoID)
                'Else
                '    strClienteID = ""
                'End If
        End Select

        Return strClienteID.Trim

    End Function

    Public Function GetListaMeses() As ArrayList
        Dim lstMeses As New ArrayList
        lstMeses.Add(1)
        lstMeses.Add(3)
        lstMeses.Add(5)
        lstMeses.Add(7)
        lstMeses.Add(8)
        lstMeses.Add(10)
        lstMeses.Add(12)
        Return lstMeses
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/12/2014: Descarga imagen web desde ruta
    '-------------------------------------------------------------------------------------------------------------------------------------------
    Public Function DownloadImageFromWeb(ByVal articulo As String) As Image
        Dim imagen As Image = Nothing
        Try
            Dim strFileName As String = oConfigCierreFI.ImagenesExistencia & articulo & "V1.jpg"
            Dim strRutaLocal As String = Application.StartupPath.TrimEnd("\")
            Dim strDefault As String = strRutaLocal & "\no_photo.jpg"

            Dim wr As HttpWebRequest = CType(HttpWebRequest.Create(strFileName), HttpWebRequest)
            '-----------------------------------------------------------------------------------------------------------------------------------
            'Le asignamos las credenciales del proxy en caso de estar configurado
            '-----------------------------------------------------------------------------------------------------------------------------------
            If Not WebProxy.GetDefaultProxy.Address Is Nothing Then
                Dim cr As New NetworkCredential(oConfigCierreFI.UserProxy, oConfigCierreFI.PasswordProxy)
                Dim proxy As New WebProxy(WebProxy.GetDefaultProxy.Address.Host, WebProxy.GetDefaultProxy.Address.Port)
                proxy.Credentials = cr
                wr.Proxy = proxy
            End If

            '--------------------------------------------------------------------------------------------------------------------------------
            'Intentamos acceder al archivo en la ruta de internet configurada
            '--------------------------------------------------------------------------------------------------------------------------------
            Try
                Dim ws As HttpWebResponse = CType(wr.GetResponse, HttpWebResponse)
                Dim str As Stream = ws.GetResponseStream()
                Dim inBuf(5000000) As Byte
                Dim bytesToRead As Integer = CInt(inBuf.Length)
                Dim bytesRead As Integer = 0
                While bytesToRead > 0
                    Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
                    If n = 0 Then
                        Exit While
                    End If
                    bytesRead += n
                    bytesToRead -= n
                End While
                '-----------------------------------------------------------------------------------------------------------------------------
                'CREATE A MEMORY STREAM USING THE BYTES
                '-----------------------------------------------------------------------------------------------------------------------------
                Dim ImageStream As New IO.MemoryStream(inBuf)
                '----------------------------------------------------------------------------------------------------------------------------------
                'CREATE A BITMAP FROM THE MEMORY STREAM
                '----------------------------------------------------------------------------------------------------------------------------------
                imagen = New System.Drawing.Bitmap(ImageStream)
                'If strFileName <> "" Then
                'Me.pbFondo.Image.Save(strRutaLocal & "\" & strFileName)
                'Else
                '    Me.pbFondo.Image.Save(strDefault)
                'End If
                If Directory.Exists(Application.StartupPath & "\Fotos\") = False Then
                    Directory.CreateDirectory(Application.StartupPath & "\Fotos\")
                End If
                If System.IO.File.Exists(Application.StartupPath & "\Fotos\" & articulo & ".JPG") = False Then
                    Dim file As New FileStream(Application.StartupPath & "\Fotos\" & articulo & ".JPG", FileMode.CreateNew)
                    file.Write(inBuf, 0, inBuf.Length)
                End If
                'AS U SEE, NO FILE NEEDS TO BE WRITTEN TO THE HARD DRIVE, ITS ALL DONE IN MEMORY
            Catch ex As Exception
                '---------------------------------------------------------------------------------------------------------------------------
                'Si obtenemos algun error y no es posible realizar la descarga entonces intentamos cargar la imagen por default
                '---------------------------------------------------------------------------------------------------------------------------
                EscribeLog(ex.ToString, "Error al descargar la imagen del articulo")
                If File.Exists(strDefault) Then imagen = Image.FromFile(strDefault)
            End Try
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al descargar la imagen del articulo")
        End Try
        Return imagen
    End Function

    Public Sub EnviarCorreos(ByVal mensaje As String, Optional ByVal Actualizacion As Boolean = False)
        Try
            If oConfigCierreFI.EvitarCierreDia = True OrElse Actualizacion = True Then
                Dim objSmtpServer As SmtpMail
                Dim SmtpClient As New System.Net.Mail.SmtpClient
                Dim Credencial As New NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
                Dim message As New System.Net.Mail.MailMessage()
                Dim Mail As New System.Net.Mail.MailAddress(oConfigCierreFI.CuentaCorreo)
                Dim Body As String = "", strSubject As String = "", strMail As String = ""

                SmtpClient.Host = oConfigCierreFI.ServidorSMTP
                SmtpClient.Port = oConfigCierreFI.PuertoSMTP
                SmtpClient.UseDefaultCredentials = False
                SmtpClient.Credentials = Credencial
                SmtpClient.EnableSsl = True

                message.From = Mail
                message.IsBodyHtml = False
                message.BodyEncoding = System.Text.Encoding.UTF8

                '------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/12/2014: Agregamos los correos de los encargados del cierre del dia
                '------------------------------------------------------------------------------------------------------------------------------
                For Each strMail In oConfigCierreFI.MailCierreDia
                    If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
                        message.To.Add(strMail)
                    End If
                Next

                '------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (02.10.2015): Validamos si es actualizacion para cambiar textos
                '------------------------------------------------------------------------------------------------------------------------------
                If Actualizacion Then
                    strSubject = "Error en la Actualización del Dportenis PRO en el almacén: " & oAppContext.ApplicationConfiguration.Almacen
                    Body = mensaje
                Else
                    strSubject = "Hubo problemas en el cierre del día en el almacén: " & oAppContext.ApplicationConfiguration.Almacen
                    Body = "Hubo problemas al cierre del día este es el log del error: " & mensaje
                End If
                message.Subject = strSubject '"Hubo problemas en el cierre del día en el almacen: " & oAppContext.ApplicationConfiguration.Almacen
                message.Body = Body
                Try
                    SmtpClient.Send(message)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al enviar los correos del cierre de día")
                End Try
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al enviar los correos del cierre de día")
        End Try
    End Sub


#Region "Methods Xtras"

    Public Sub KillExcel()

        Dim vProccs() As Process
        Dim vProceso As Process
        Dim progID As Integer = 0

        'vProccs = Process.GetProcesses
        'For Each vProceso In vProccs
        '    If UCase(vProceso.ProcessName) = "EXCEL" Then
        '        progID += 1
        '    End If
        'Next


        Dim ExcelProceso() As Process = Process.GetProcessesByName("EXCEL")
        progID = ExcelProceso.Length() - 1
        ExcelProceso(progID).CloseMainWindow()
        If ExcelProceso(progID).HasExited = False Then
            ExcelProceso(progID).Kill()
            ExcelProceso(progID).Close()
        End If

    End Sub

    Public Function LoadConfigSAP() As Boolean

        Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
        'Dim strConfigurationFile As String = strRutaCmls & "\configSAP.cml"

        If File.Exists(strConfigurationFile) Then

            Dim oSApReader As New SapConfigReader(strConfigurationFile)
            oAppSAPConfig = oSApReader.LoadSettings
            oSApReader = Nothing

            Return True
        Else
            Return False
        End If

    End Function

    Public Function LoadConfigCierreFI() As Boolean
        Dim strConfigurationFile As String = Application.StartupPath & "\configCierre.cml"
        'Dim strConfigurationFile As String = strRutaCmls & "\configCierre.cml"

        If File.Exists(strConfigurationFile) Then
            Dim oReader As New SaveConfigArchivosReader(strConfigurationFile)
            oConfigCierreFI = oReader.LoadSettings
            oReader = Nothing
            Return True
        Else
            Return False
        End If
    End Function

    Public Function LoadConfigFotos() As Boolean
        Dim strConfigurationFile As String = Application.StartupPath & "\configFotos.cml"
        'Dim strConfigurationFile As String = strRutaCmls & "\configFotos.cml"

        If File.Exists(strConfigurationFile) Then
            Dim oReader As New SaveConfigArchivosReader(strConfigurationFile)
            oConfigFotos = oReader.LoadSettings
            oReader = Nothing
            Return True
        Else
            Return False
        End If
    End Function

    'Public Function GetClienteAlterno(ByVal strCodCliente As String, ByVal TipoVenta As String) As ClienteAlterno

    '    Dim dtClientesSap As DataTable
    '    Dim oClienteSAP As ClienteAlterno
    '    Dim oSAPMgr As ProcesoSAPManager
    '    Dim oClienteMgr As New ClientesManager(oAppContext)

    '    oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    '    dtClientesSap = oSAPMgr.ZBAPI_GET_CLIENTE(strCodCliente, TipoVenta)

    '    oClienteSAP = oClienteMgr.CreateAlterno
    '    If dtClientesSap.Rows.Count > 0 Then

    '        Dim oRow As DataRow
    '        Dim intCount As Integer = 0
    '        'Dim strApepApemNom() As String
    '        Dim strNombre As String
    '        ' Dim strApellidos As String
    '        Dim strApeM As String = ""
    '        Dim strApeP As String = ""
    '        'Dim digitregex As Regex = New Regex("(?<digit>[A-Z]|[a-z])")

    '        For Each oRow In dtClientesSap.Rows
    '            If CStr(oRow!Sexo).Trim.ToUpper <> "E".ToUpper Then
    '                'strApepApemNom = Split(oRow!NAME1, "_")
    '                'Select Case strApepApemNom.Length
    '                '    Case 6
    '                '        strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
    '                '        strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2) & " " & strApepApemNom(3)
    '                '        strApeP = strApepApemNom(0) & " " & strApepApemNom(1)
    '                '        strApeM = strApepApemNom(2) & " " & strApepApemNom(3)
    '                '    Case 5
    '                '        strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
    '                '        strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2)
    '                '        strApeP = strApepApemNom(0) & " " & strApepApemNom(1)
    '                '        strApeM = strApepApemNom(2)
    '                '    Case 4
    '                '        strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
    '                '        strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
    '                '        strApeP = strApepApemNom(0)
    '                '        strApeM = strApepApemNom(1)
    '                '    Case 3
    '                '        strNombre = Trim(strApepApemNom(2))
    '                '        strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
    '                '        strApeP = strApepApemNom(0)
    '                '        strApeM = strApepApemNom(1)
    '                '    Case 2
    '                '        strNombre = strApepApemNom(1)
    '                '        strApellidos = Trim(strApepApemNom(0))
    '                '        strApeP = strApepApemNom(0)
    '                '    Case 1
    '                '        strNombre = ""
    '                '        strApellidos = Trim(strApepApemNom(0))
    '                '        strApeP = strApepApemNom(0)
    '                '    Case Else
    '                '        strNombre = ""
    '                '        strApellidos = ""
    '                'End Select

    '                strNombre = CStr(oRow!NAME1).Trim().Replace("_", " ")
    '                strApeP = CStr(oRow!NAME2)
    '                strApeM = CStr(oRow!NAME3)
    '            Else
    '                strNombre = CStr(oRow!NAME1).Trim.Replace("_", " ")
    '                strApeP = CStr(oRow!NAME2)
    '                strApeM = CStr(oRow!NAME3)
    '            End If
    '            '''Insertamos los valor del cliente a la Clase
    '            With oClienteSAP
    '                .CodigoAlterno = oRow!KUNNR
    '                .CodigoCliente = CLng(oRow!KUNNR)

    '                If CStr(oRow!FENAC).Trim = "00000000" OrElse CStr(oRow!FENAC).Trim = "" Then
    '                    .FechaNacimiento = Today
    '                Else
    '                    .FechaNacimiento = CDate(Mid(oRow!FENAC, 7, 2) & "/" & Mid(oRow!FENAC, 5, 2) & "/" & Mid(oRow!FENAC, 1, 4))
    '                End If

    '                .Nombre = strNombre
    '                .ApellidoMaterno = strApeM.Trim
    '                .ApellidoPaterno = strApeP.Trim

    '                '.Sexo = oRow!DEAR1
    '                .Sexo = CStr(oRow!Sexo).Trim.ToUpper()
    '                'Select Case CStr(oRow!Sexo).Trim.ToUpper
    '                '    Case "SEÑOR"
    '                '        .Sexo = "M"
    '                '    Case "SEÑORA"
    '                '        .Sexo = "F"
    '                '    Case "EMPRESA"
    '                '        .Sexo = "E"
    '                '    Case Else
    '                '        .Sexo = ""
    '                'End Select

    '                'If CStr(oRow!ANRED).Trim <> "" AndAlso CStr(oRow!ANRED).Trim.ToUpper <> "Empresa".ToUpper Then
    '                '    .Sexo = IIf(CStr(oRow!ANRED).Trim.ToUpper = "SEÑORA", "F", "M")
    '                'Else
    '                '    .Sexo = ""
    '                'End If
    '                '.Estadocivil = oRow!DATLT
    '                .Direccion = oRow!STREET

    '                .Estado = oRow!REGIO
    '                .Ciudad = oRow!ORT01
    '                .Colonia = CStr(oRow!DISTRI)
    '                .CP = oRow!PSTLZ

    '                .Telefono = oRow!TELF1

    '                'If oRow!UPDAT = "00000000" Then
    '                '    .Fechanac = Now.Date.ToShortDateString
    '                'Else
    '                '    .Fechanac = Mid(oRow!UPDAT, 7, 2) & "/" & Mid(oRow!UPDAT, 5, 2) & "/" & Mid(oRow!UPDAT, 1, 4)
    '                'End If

    '                .EstadoCivil = CStr(oRow!ECIVIL).Trim

    '                .NumExt = CStr(oRow!NUMEXT).Trim
    '                .NumInt = CStr(oRow!NUMINT).Trim

    '                .EMail = oRow!EMAIL
    '                '.CodAlmacen = digitregex.Replace(oRow!VWERK, "").Trim 'oRow!VWERK
    '                '.CodPlaza = oRow!VKBUR
    '                .CodAlmacen = ""
    '                .CodPlaza = ""
    '                '.Usuario = oRow!TELBX

    '                If oRow!ERDAT = "00000000" Then

    '                    .RecordCreatedOn = Now.Date.ToShortDateString
    '                Else
    '                    .RecordCreatedOn = Mid(oRow!ERDAT, 7, 2) & "/" & Mid(oRow!ERDAT, 5, 2) & "/" & Mid(oRow!ERDAT, 1, 4)

    '                End If

    '                '.Statusregistr0 = True
    '                .RFC = oRow!RFC

    '                '.ClaveAnterior = oRow!ALTKN
    '                '.TipoVenta = getTipoventa(oRow!BZIRK)
    '                .TipoVenta = oRow!TIPO_CLIENTE

    '                .CodPlayer = oRow!ERNAM

    '                .ResetFlagNew()

    '            End With

    '            'oSAPMgr.Write_Clientes(oClienteSAP)

    '        Next

    '    End If

    '    Return oClienteSAP

    'End Function

    Public Function GetCliente(ByVal strCodCliente As String, ByVal TipoVenta As String) As ClientesSAP

        Dim dtClientesSap As DataTable
        Dim oClienteSAP As New ClientesSAP
        Dim oSAPMgr As ProcesoSAPManager

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oSAPMgr.ConfigCierreFI = oConfigCierreFI
        dtClientesSap = oSAPMgr.ZBAPI_GET_CLIENTE(strCodCliente, TipoVenta)

        If dtClientesSap.Rows.Count > 0 Then

            Dim oRow As DataRow
            Dim intCount As Integer = 0
            Dim strApepApemNom() As String
            Dim strNombre As String
            Dim strApellidos As String

            For Each oRow In dtClientesSap.Rows

                If CStr(oRow!Sexo).Trim.ToUpper <> "E".ToUpper Then

                    strNombre = CStr(oRow!NAME1).Trim().Replace("_", " ")
                    strApellidos = CStr(oRow!NAME2) & " " & CStr(oRow!NAME3)
                Else
                    strNombre = CStr(oRow!NAME1).Trim.Replace("_", " ")
                    strApellidos = CStr(oRow!NAME2) & " " & CStr(oRow!NAME3)
                End If
                '''Insertamos los valor del cliente a la Clase
                With oClienteSAP
                    .Clienteid = oRow!KUNNR
                    .Nombre = strNombre
                    .Apellidos = strApellidos
                    '.Sexo = oRow!DEAR1
                    .Sexo = CStr(oRow!Sexo).Trim.ToUpper()
                    'Select Case CStr(oRow!Sexo).Trim.ToUpper
                    '    Case "SEÑOR"
                    '        .Sexo = "M"
                    '    Case "SEÑORA"
                    '        .Sexo = "F"
                    '    Case "EMPRESA"
                    '        .Sexo = "E"
                    '    Case Else
                    '        .Sexo = ""
                    'End Select
                    'If CStr(oRow!ANRED).Trim <> "" AndAlso CStr(oRow!ANRED).Trim.ToUpper <> "Empresa".ToUpper Then
                    '    .Sexo = IIf(CStr(oRow!ANRED).Trim.ToUpper = "SEÑORA", "F", "M")
                    'Else
                    '    .Sexo = ""
                    'End If
                    '.Estadocivil = oRow!DATLT
                    .Domicilio = CStr(oRow!STREET) '& " " & CStr(oRow!NUMEXT)
                    .Estado = oRow!REGIO
                    .Ciudad = oRow!ORT01
                    .Colonia = CStr(oRow!DISTRI)
                    .Cp = oRow!PSTLZ
                    .Telefono = oRow!TELF1

                    'If oRow!UPDAT = "00000000" Then
                    '    .Fechanac = Now.Date.ToShortDateString
                    'Else
                    '    .Fechanac = Mid(oRow!UPDAT, 7, 2) & "/" & Mid(oRow!UPDAT, 5, 2) & "/" & Mid(oRow!UPDAT, 1, 4)
                    'End If}
                    .Estadocivil = CStr(oRow!ECIVIL).Trim
                    .NumeroExterior = CStr(oRow!NUMEXT).Trim
                    .NumeroInterior = CStr(oRow!NUMINT).Trim

                    If CStr(oRow!FENAC).Trim = "" OrElse oRow!FENAC = "00000000" Then
                        .Fechanac = Now.Date.ToShortDateString
                    Else
                        .Fechanac = CDate(Mid(oRow!FENAC, 7, 2) & "/" & Mid(oRow!FENAC, 5, 2) & "/" & Mid(oRow!FENAC, 1, 4))
                    End If

                    .Email = oRow!EMAIL
                    '.Codalmacen = oRow!VWERK
                    '.CodPlaza = oRow!VKBUR
                    .Codalmacen = ""
                    .CodPlaza = ""
                    .Usuario = oRow!ERNAM

                    If oRow!FENAC = "00000000" Or oRow!FENAC = "" Then
                        .Fecha = Now.Date.ToShortDateString
                    Else
                        .Fecha = Mid(oRow!FENAC, 7, 2) & "/" & Mid(oRow!FENAC, 5, 2) & "/" & Mid(oRow!FENAC, 1, 4)
                    End If

                    .Statusregistro = True
                    .RFC = CStr(oRow!RFC).Trim
                    '.ClaveAnterior = oRow!ALTKN
                    '.TipoVenta = getTipoventa(oRow!BZIRK)
                    Select Case TipoVenta
                        Case "D"
                            .TipoVenta = "D"
                        Case Else
                            .TipoVenta = "C"
                    End Select
                    '.TipoVenta = oRow!TIPO_CLIENTE
                    .Player = oRow!ERNAM
                End With
                oSAPMgr.Write_Clientes(oClienteSAP)

            Next

        End If

        Return oClienteSAP

    End Function

    Public Function GetClienteDPVale(ByVal strCodCliente As String) As ClientesSAP

        Dim dtClientesSap As DataTable
        Dim oClienteSAP As New ClientesSAP
        Dim oSAPMgr As ProcesoSAPManager

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        '-------------------------------------------------------------------
        ' JNAVA (12.08.2016): Si esta activo si está activo s2credit
        '-------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            Dim oS2Credit As New ProcesosS2Credit
            oClienteSAP = oS2Credit.ObtenerClientePorID(strCodCliente)

            If Not oClienteSAP Is Nothing Then
                '-------------------------------------------------------------------
                ' Guardamos el cliente en SQL
                '-------------------------------------------------------------------
                oSAPMgr.Write_Clientes(oClienteSAP)
            End If

            GoTo Continua
        End If
        '-------------------------------------------------------------------

        dtClientesSap = oSAPMgr.ZBAPI_GET_CLIENTE_DPVALE(strCodCliente)

        If dtClientesSap.Rows.Count > 0 Then

            Dim oRow As DataRow
            Dim intCount As Integer = 0
            Dim strApepApemNom() As String
            Dim strNombre As String
            Dim strApellidos As String

            For Each oRow In dtClientesSap.Rows

                If CStr(oRow!ANRED).Trim.ToUpper <> "Empresa".ToUpper Then
                    strApepApemNom = Split(oRow!NAME1, "_")
                    Select Case strApepApemNom.Length
                        Case 6
                            strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                            strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2) & " " & strApepApemNom(3)
                        Case 5
                            strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                            strApellidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2)
                        Case 4
                            strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                            strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                        Case 3
                            strNombre = Trim(strApepApemNom(2))
                            strApellidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                        Case 2
                            strNombre = strApepApemNom(1)
                            strApellidos = Trim(strApepApemNom(0))
                        Case 1
                            strNombre = ""
                            strApellidos = Trim(strApepApemNom(0))
                        Case Else
                            strNombre = ""
                            strApellidos = ""
                    End Select
                Else
                    strNombre = CStr(oRow!NAME1).Trim.Replace("_", " ")
                    strApellidos = ""
                End If
                '''Insertamos los valor del cliente a la Clase
                With oClienteSAP
                    .Clienteid = oRow!KUNNR
                    .Nombre = strNombre
                    .Apellidos = strApellidos.Trim.Replace("_", " ")
                    '.Sexo = oRow!DEAR1
                    Select Case CStr(oRow!ANRED).Trim.ToUpper
                        Case "SEÑOR"
                            .Sexo = "M"
                        Case "SEÑORA"
                            .Sexo = "F"
                        Case "EMPRESA"
                            .Sexo = "E"
                        Case Else
                            .Sexo = ""
                    End Select
                    'If CStr(oRow!ANRED).Trim <> "" AndAlso CStr(oRow!ANRED).Trim.ToUpper <> "Empresa".ToUpper Then
                    '    .Sexo = IIf(CStr(oRow!ANRED).Trim.ToUpper = "SEÑORA", "F", "M")
                    'Else
                    '    .Sexo = ""
                    'End If
                    '.Estadocivil = oRow!DATLT
                    .Domicilio = oRow!STRAS
                    .Estado = oRow!REGIO
                    .Ciudad = oRow!ORT01
                    .Colonia = oRow!ORT02
                    .Cp = oRow!PSTLZ
                    .Telefono = oRow!TELF1

                    'If oRow!UPDAT = "00000000" Then
                    '    .Fechanac = Now.Date.ToShortDateString
                    'Else
                    '    .Fechanac = Mid(oRow!UPDAT, 7, 2) & "/" & Mid(oRow!UPDAT, 5, 2) & "/" & Mid(oRow!UPDAT, 1, 4)
                    'End If}
                    .Estadocivil = CStr(oRow!EDOCIVIL).Trim
                    .NumeroExterior = CStr(oRow!NUMEXT).Trim
                    .NumeroInterior = CStr(oRow!NUMINT).Trim

                    If CStr(oRow!TELX1).Trim = "" Then
                        .Fechanac = Now.Date.ToShortDateString
                    Else
                        .Fechanac = CDate(Mid(oRow!TELX1, 7, 2) & "/" & Mid(oRow!TELX1, 5, 2) & "/" & Mid(oRow!TELX1, 1, 4))
                    End If

                    .Email = oRow!KNURL
                    .Codalmacen = oRow!VWERK
                    .CodPlaza = oRow!VKBUR
                    .Usuario = oRow!TELBX

                    If oRow!ERDAT = "00000000" Then
                        .Fecha = Now.Date.ToShortDateString
                    Else
                        .Fecha = Mid(oRow!ERDAT, 7, 2) & "/" & Mid(oRow!ERDAT, 5, 2) & "/" & Mid(oRow!ERDAT, 1, 4)
                    End If

                    .Statusregistro = True
                    .RFC = oRow!STCD1
                    .ClaveAnterior = oRow!ALTKN
                    .TipoVenta = getTipoventa(oRow!BZIRK)
                    .Player = oRow!VKGRP

                    .TipoVenta = "V"
                End With
                oSAPMgr.Write_Clientes(oClienteSAP)

            Next

        End If

Continua:

        Return oClienteSAP

    End Function

    Public Sub GetClientePG(ByVal strCodCliente As String)

        Dim oClientePG As ClienteAlterno
        Dim oClientesMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        oClientePG = oClientesMgr.CreateAlterno
        oClientesMgr.LoadPGFromServer(strCodCliente, oClientePG)

        If oClientePG.CodigoCliente > 0 Then

            oClientePG.TipoVenta = "P"
            oClientesMgr.Save(oClientePG, False, True)

        End If

    End Sub

    Private Function getTipoventa(ByVal strtipovta As String) As String
        Select Case strtipovta
            Case "TFON" : Return "K"
            Case "FONA" : Return "F"
            Case "FACI" : Return "O"
        End Select
    End Function

    Public Function GetName(ByVal strTrack As String) As String ', ByVal strSeparadorIni As String, ByVal strSeparadoFin As String)

        Dim strNombre As String
        Dim intIndexIni, intIndexFin As Integer
        Dim strSeparadorIni As String, strSeparadorFin As String

        If InStr(strTrack, "¨") > 0 Then
            strSeparadorFin = "¨"
            If InStr(strTrack, "Ä") > 0 Then
                strSeparadorIni = "Ä"
            ElseIf InStr(strTrack, "Ë") > 0 Then
                strSeparadorIni = "Ë"
            ElseIf InStr(strTrack, "Ï") > 0 Then
                strSeparadorIni = "Ï"
            ElseIf InStr(strTrack, "Ö") > 0 Then
                strSeparadorIni = "Ö"
            ElseIf InStr(strTrack, "Ü") > 0 Then
                strSeparadorIni = "Ü"
            ElseIf InStr(strTrack, "Ÿ") > 0 Then
                strSeparadorIni = "Ÿ"
            Else
                strSeparadorIni = "¨"
            End If
        Else
            strSeparadorFin = "^"
            If InStr(strTrack, "Â") > 0 Then
                strSeparadorIni = "Â"
            ElseIf InStr(strTrack, "Ê") > 0 Then
                strSeparadorIni = "Ê"
            ElseIf InStr(strTrack, "Î") > 0 Then
                strSeparadorIni = "Î"
            ElseIf InStr(strTrack, "Ô") > 0 Then
                strSeparadorIni = "Ô"
            ElseIf InStr(strTrack, "Û") > 0 Then
                strSeparadorIni = "Û"
            Else
                strSeparadorIni = "^"
            End If

        End If

        intIndexIni = strTrack.IndexOf(strSeparadorIni)
        If intIndexIni > 0 Then
            intIndexFin = strTrack.LastIndexOf(strSeparadorFin)
            strNombre = strTrack.Substring(intIndexIni, intIndexFin - intIndexIni)
        End If
        If InStr(strTrack, "¨") > 0 Then
            strNombre = strNombre.Replace("¨", "").Trim
        Else
            strNombre = strNombre.Replace("^", "").Trim
        End If
        Return strNombre

    End Function

#End Region

#Region "DPSoft Security Manager"

#Region "Permission"


    Private Sub RegisterApplicationUnits()

        PermissionRegisterIntoApplication()

        '* Este   método   aplicaria  si   cada  opción   del  sistema
        '* tuviera una unidad de aplicación. Algunos no se programaron
        '* de esa manera

        'Dim oCatalogoLineasAU As New DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas.ApplicationUnit
        'oCatalogoLineasAU.RegisterIntoApplication(oAppContext)

    End Sub

    Private Sub PermissionRegisterIntoApplication()

        Dim intIndex As Integer = 0

        With oAppContext.Security.Features

            intIndex = .Add("DportenisPro.DPTienda.Ventas.ReasignarPlayer", "Reasignar Player a Facturas")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.CancelarFactura", "Cancelar Facturas")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.DevolverFactura", "Devoluciones (Nota de Crédito)")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.CerrarCaja", "Cierre de Caja")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.CerrarDia", "Cierre de Día")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA", "Aplicar Descuentos (DMA)")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.TeclearDpVale", "Teclear DPVALE")

            intIndex = .Add("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial", "Captura Manual de Material")

            '------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 21/02/2018: Permiso nuevo para Reducción de Facturación
            '------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Ventas.Facturacion", "Facturacion")

            intIndex = .Add("DportenisPro.DPTienda.Auditoria.Auditoria", "Movimientos de Auditoria")

            With .Item(intIndex).Operations

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.AjusteGeneral", "Ajustes Generales")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.AjusteEntrada", "Ajustes de Entrada")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.AjusteSalida", "Ajustes de Salida")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.AjusteEntradaSalida", "Ajustes Entrada - Salida")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.RevisionApartados", "Revisión de Apartados")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.TomadeInventario", "Toma de Inventario")

                .Add("DportenisPro.DPTienda.Auditoria.Auditoria.AutorizacionAjustes", "Autorización de Ajustes")

                .Add("DportenisPRO.DPTienda.Auditoria.Auditoria.ReporteCostosInventarios", "Reporte de Costos de Inventarios")

            End With

            intIndex = .Add("DportenisPro.DPTienda.Apartados.AgregarAbono", "Registrar Abono de Apartado")

            intIndex = .Add("DportenisPro.DPTienda.Apartados.CancelaAbonoApartado", "Cancelar Abono de Apartado")

            intIndex = .Add("DportenisPro.DPTienda.Apartados.Contrato", "Registrar Contrato")

            intIndex = .Add("DportenisPro.DPTienda.Apartados.CancelaContrato", "Cancelar Contrato")

            With .Item(intIndex).Operations

                .Add("DportenisPro.DPTienda.Apartados.CancelaContrato.DefinitivoDia", "Definitivo del Día")
                .Add("DportenisPro.DPTienda.Apartados.CancelaContrato.DefinitivoAnterior", "Definitivo Días Anteriores")
                .Add("DportenisPro.DPTienda.Apartados.CancelaContrato.ParaNotaDeCredito", "Para Nota de Crédito")

            End With

            intIndex = .Add("DportenisPro.DPTienda.Inventarios.ExportarInformacionAuditoria", "Exportar Informacion Auditoria(AUDBAS)")

            intIndex = .Add("DportenisPro.DPTienda.Inventarios.DesmarcarDefectuoso", "Desmarcar Defectuosos")

            intIndex = .Add("DportenisPro.DPTienda.Inventarios.TraspasosEntrada", "Traspasos de Entrada")
            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/05/2013: Permisos para las ordenes de compra
            '--------------------------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPRO.DPTienda.Inventarios.OrdenesCompra", "Ordenes de compra")

            '-----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 28/07/2015: Se agrego el permiso de traspaso de entrada de mercancia
            '-----------------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia", "Recepción de Mercancía en Tiendas de Proveedores")
            With .Item(intIndex).Operations
                '-----------------------------------------------------------------------------------------------------------------------
                'JNAVA 10/08/2015: Se agrego el permiso para generar reporte de resguardo y dar salida de resguarrdo EMT
                '-----------------------------------------------------------------------------------------------------------------------
                .Add("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia.ReporteResguardo", "Generar Reporte de Materiales en Resguardo (EMT)")
                .Add("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia.SalidaResguardo", "Dar Salida a Materiales en Resguardo (EMT)")
            End With

            intIndex = .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida", "Traspasos de Salida")
            With .Item(intIndex).Operations

                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen000", "Almacen 000")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen091", "Almacen 091")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen092", "Almacen 092")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen093", "Almacen 093")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen094", "Almacen 094")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen095", "Almacen 095")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen096", "Almacen 096")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen097", "Almacen 097")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen098", "Almacen 098")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Almacen099", "Almacen 099")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.Tiendas", "Entre Tiendas")
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.ConcenVentas", "Concentracion de Ventas")
                '--------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 10/05/2013: Permisos para las devoluciones de proveedor
                '--------------------------------------------------------------------------------------------------------------------------------
                .Add("DportenisPro.DPTienda.Inventarios.TraspasosSalida.DevolucionProveedor", "Devolución a Proveedor")

            End With

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.Opciones.CargaInicial", "Carga Inicial")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.Opciones", "Opciones del Sistema")

            intIndex = .Add("DportenisPro.DPTienda.Administrator", "Administración del Sistema")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.GenerarArchivosCierre", "Generar Archivos de Cierre de Día")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.CargarDiasSAP", "Cargar Archivos Dias en SAP")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.Contabilizacion", "Contabilización del Sistema")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.Desbloqueo", "Desbloquear el Sistema")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.Opciones.SistemaGerencial", "Sistema Gerencial")

            With .Item(intIndex).Operations

                .Add("DportenisPro.DPTienda.Utilerias.Contabilizacion.SegmentoContable", "Segmentos Contables")

                .Add("DportenisPro.DPTienda.Utilerias.Contabilizacion.DefinicionAsiento", "Definición de Asientos")

                .Add("DportenisPro.DPTienda.Utilerias.Contabilizacion.AsignacionAsiento", "Asignación de Asientos")

            End With

            intIndex = .Add("DportenisPro.DPTienda.Facturacion.Descuentos", "Descuentos")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.Facturacion.Descuentos.Dips", "Descuentos Especiales Dips")
            End With

            'PEDIDOS INSURTIBLES
            intIndex = .Add("DportenisPro.DPTienda.SiHay.PedidosInsurtibles", "Pedidos Insurtibles")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.SiHay.PedidosInsurtibles.ReembolsarPedido", "Reembolsar Pedido")
                .Add("DportenisPro.DPTienda.SiHay.PedidosInsurtibles.DevolucionEfectivo", "Devolución de Efectivo")
                .Add("DportenisPro.DPTienda.SiHay.PedidosInsurtibles.CancelacionDefinitiva", "Cancelación Definitiva")
            End With
            '--------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 06/05/2013: Permisos Envio de Guia SH
            '--------------------------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.SiHay.AsignarGuia", "Asignar Guía Pedidos SH")

            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 30/09/2014: Permiso para realizar pago de Ecommerce
            '--------------------------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.OtrosPagos", "Otros Pagos")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.OtrosPagos.RecibirPagosEcommerce", "Recibir Pagos Ecommerce")
                '--------------------------------------------------------------------------------------------------------------------------------
                'JNAVA 20/01/2015: Permiso para realizar pago de DPCard
                '--------------------------------------------------------------------------------------------------------------------------------
                .Add("DportenisPro.DPTienda.OtrosPagos.RecibirPagosDPCard", "Recibir Pagos DPCard")
                .Add("DportenisPro.DPTienda.OtrosPagos.CancelarPagosDPCard", "Cancelar Pagos DPCard")
            End With

            '--------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 10/05/2013: Permisos para la cancelación del Pedido SiHay
            '--------------------------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.SiHay.CancelacionPedidos", "Cancelacion de Pedidos")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.SiHay.CancelacionPedidos.GuardarCancelacionPedido", "Cancelar Pedido")
                .Add("DportenisPro.DPTienda.SiHay.CancelacionPedidos.DevolucionEfectivo", "Devolución de Efectivo")
            End With
            'MPERAZA 22/05/2013: PERMISOS PARA LA CANCELACION DE FACTURA SH
            intIndex = .Add("DportenisPro.DPTienda.SiHay.CancelacionFacturaSH", "Cancelación de Factura Si Hay")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.SiHay.CancelacionFacturaSH.DevolucionEfectivo", "Devolución de Efectivo")
            End With
            intIndex = .Add("DportenisPro.DPTienda.MetasTienda", "Metas de Tienda")
            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 11/05/2015: Menú para DPCard Puntos
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.DPCardPuntos", "DPCard Puntos")
            With .Item(intIndex).Operations
                .Add("DportenisPro.DPTienda.DPCardPuntos.Bonificacion", "Aplicar puntos cuando excede limite")
                .Add("DportenisPro.DPTienda.DPCardPuntos.Canje", "Aplica Canje cuando exceda limite")
                '-----------------------------------------------------------------------------------------------------------------
                'JNAVA (15.09.2015): Permiso para traspaso de DPCARD Puntos
                '-----------------------------------------------------------------------------------------------------------------
                .Add("DportenisPro.DPTienda.DPCardPuntos.Traspaso", "Traspaso de Puntos")

                '-----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 22/10/2017: Permiso para autorizar mas de una transacción en tarjeta de lealtad
                '-----------------------------------------------------------------------------------------------------------------
                intIndex = .Add("DportenisPro.DPTienda.DPCardPuntos.Autorizacion", "Autoriza canje y bonificación de puntos")
                '-----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/09/2018: Permiso para activar la tarjeta de punto en caso de que no este activa en la bonificación
                '-----------------------------------------------------------------------------------------------------------------
                intIndex = .Add("DportenisPro.DPTienda.DPCardPuntos.ActivacionBonificacion", "Autoriza la activación y bonificación")
            End With
            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/05/2015: Permisos para marcar y desmarcar Artículos de Baja Calidad
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Inventarios.MarcarDesmarcarDefectuosoBajaCalidad", "Desmarcar Defectuosos de Baja Calidad")
            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 12/08/2015: Permisos para modificar el beneficiario del seguro de vida del dpvale
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Facturacion.ModificarBeneficiario", "Modificar Beneficiarios de Seguro de Vida DPVale")
            '-----------------------------------------------------------------------------------------------------------------
            'AFAJARDO 05/10/2016: Permisos para cargar la pantalla de notas de crédito
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Utilerias.CargaNotasCredito", "Carga Notas de Crédito")

            intIndex = .Add("DportenisPro.DPTienda.Utilerias.ConfiguracionBanamex", "Configuracion Tarjeta Banamex")

            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/10/2017: Permiso para realizar prestamos club dp
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Utileria.Dispersion", "Configuracion de Prestamos ClubDP")

            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 26/01/2018: Permiso para devolución de tarjetas.
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Utilerias.DevolucionTarjeta", "Devolución Tarjeta")

            '-----------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 20/10/2017: Permiso para realizar prestamos club dp
            '-----------------------------------------------------------------------------------------------------------------
            intIndex = .Add("DportenisPro.DPTienda.Utileria.MonitoreoReproceso", "Configuracion de Monitoreo y reproceso")
        End With

    End Sub

#End Region

#End Region

#Region "Facturacion SiHay"

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Función para Validar si no hay Articulos Pendientes por facturar y por Surtir
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarMaterialesNegadosSH(ByRef dtMateriales As DataTable, ByRef dtMaterialesNegados As DataTable, ByVal StatusStr As String, Optional ByVal ApartadoInstance As Boolean = False) As Boolean
        Dim valido As Boolean = True
        Dim ProcesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dtPedido As DataTable, dtCabecera As DataTable, dtDetalle As DataTable
        Dim status As New Hashtable
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oFactura As Factura = FacturaMgr.Create()
        Dim strArray() As String = StatusStr.Split(",")
        If dtMateriales.Columns.Contains("Libres") = False Then
            dtMateriales.Columns.Add("Libres", GetType(Integer))
        End If
        For Each str As String In strArray
            status(str) = str
        Next
        dtPedido = ProcesoMgr.ZSH_PEDIDOS_PENDIENTES(ProcesoMgr.Read_Centros(), dtCabecera, dtDetalle, status, dtMateriales)
        For Each rowNe As DataRow In dtMateriales.Rows
            Dim codigo As String = CStr(rowNe!Codigo)
            'Dim size As String = CStr(rowNe!Talla)
            'Dim talla As String = ""
            'If IsNumeric(CStr(rowNe!Talla)) Then
            '    talla = Format(CDec(rowNe!Talla), "#.0")
            'Else
            '    talla = CStr(rowNe!Talla).Trim()
            'End If
            Dim cantidad As Integer = CInt(rowNe!Cantidad)
            oFactura.FacturaArticuloExistencia = 0
            FacturaMgr.GetExistenciaArticulo(codigo, oAppContext.ApplicationConfiguration.Almacen, "", oFactura)
            Dim existencia As Decimal = oFactura.FacturaArticuloExistencia
            If ApartadoInstance = True Then
                Dim apartados As Decimal = oFactura.ExistenciaApartado
                existencia = existencia + apartados
            End If
            For Each pRow As DataRow In dtPedido.Rows
                Dim estado As String = CStr(pRow!STATUS)
                Dim folio As String = CStr(pRow!VBELN)
                Dim rows() As DataRow = dtDetalle.Select("VBELN='" & folio & "' AND MATNR='" & codigo & "'") ' AND J_3ASIZE='" & talla & "'")
                If rows.Length > 0 Then
                    Select Case estado
                        Case "PF"
                            existencia -= CDec(rows(0)!RECIBIDO)
                        Case "P"
                            existencia -= CDec(rows(0)!PENDIENTE)
                        Case "RP"
                            existencia -= CDec(rows(0)!PENDIENTE)
                    End Select
                End If
            Next
            rowNe("Libres") = IIf(existencia < 0, 0, existencia)
            '----------------------------------------------------------------------------------------------------
            'JNAVA 06/03/2014: Se agrego validacion de si hay o no pedidos del si hay para que no marque pedidos 
            '                  pendientes por facturar o surtir en los traspasos de salida por defectuosos
            '----------------------------------------------------------------------------------------------------
            If Not dtPedido Is Nothing AndAlso dtPedido.Rows.Count > 0 Then
                If cantidad > existencia Then
                    Dim row As DataRow = dtMaterialesNegados.NewRow()
                    '--------------------------------------------------------------------------------------------------
                    ' JNAVA (08.03.2017): Se valida si se pone el codigo proveedor o el codigo articulo
                    '--------------------------------------------------------------------------------------------------
                    If dtMateriales.Columns.Contains("CodProveedor") Then
                        '-------------------------------------------------
                        ' JNAVA (13.02.2016): Se pone el codigo proveedor
                        '-------------------------------------------------
                        row("CodArticulo") = rowNe!CodProveedor 'codigo
                        '-------------------------------------------------
                    Else
                        row("CodArticulo") = codigo
                    End If
                    '--------------------------------------------------------------------------------------------------
                    'row("Talla") = talla
                    row("Pedido") = cantidad
                    row("Existencia") = IIf(existencia < 0, 0, existencia)
                    dtMaterialesNegados.Rows.Add(row)
                    valido = False
                End If
            End If
        Next
        dtMateriales.AcceptChanges()
        Return valido
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 13/07/2022: Función para Obtener la estructura en Tabla de los productos en Aclaración
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Function GetProductosAclaracion() As DataTable
        Dim dtAclaracion As New DataTable("ArticulosAclaracion")
        dtAclaracion.Columns.Add("CodArticulo", GetType(String))
        dtAclaracion.Columns.Add("Cantidad", GetType(Integer))
        dtAclaracion.AcceptChanges()
        Return dtAclaracion
    End Function


    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Función para Obtener la estructura en Tabla de los Articulos Negados en el SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Function GetStructureMaterialesNegados() As DataTable
        Dim dtNegados As New DataTable("ArticulosNegados")
        dtNegados.Columns.Add("CodArticulo", GetType(String))
        dtNegados.Columns.Add("Talla", GetType(String))
        dtNegados.Columns.Add("Pedido", GetType(Integer))
        dtNegados.Columns.Add("Existencia", GetType(Integer))
        dtNegados.AcceptChanges()
        Return dtNegados
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Muestra los articulos que fueron negados en el SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Sub ShowFormNegadosSH(ByVal dtMaterialesNegados As DataTable)
        Dim frmNegados As New frmMostrarMensajeArticulos
        frmNegados.Source = dtMaterialesNegados
        frmNegados.lblMensaje.Text = "Articulos Negados porque estan pendientes por surtir o Facturar"
        frmNegados.SetAttributesColumnsGrid(GetAtributosMensajesSH())
        frmNegados.ShowDialog()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/05/2013: Muestra los articulos que no cuentan con existencia Valida
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Sub ShowFormMessage(ByVal dtMateriales As DataTable, ByVal mensaje As String, ByVal atributos As DataTable)
        Dim form As New frmMostrarMensajeArticulos
        form.Source = dtMateriales
        form.lblMensaje.Text = mensaje
        form.SetAttributesColumnsGrid(atributos)
        form.ShowDialog()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Obtiene los atributos del grid donde se muestran los Articulos Negados
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Function GetAtributosMensajesSH() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Talla"
        row("Ancho") = 67
        row("Texto") = "Talla"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Pedido"
        row("Ancho") = 67
        row("Texto") = "Pedido"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Existencia"
        row("Ancho") = 81
        row("Texto") = "Existencia"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Obtiene los atributos del grid donde se muestran los Articulos Negados
    '-----------------------------------------------------------------------------------------------------------------------------------

    Public Function GetAtributosMaterialNoValido() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Talla"
        row("Ancho") = 67
        row("Texto") = "Talla"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Existencia"
        row("Ancho") = 67
        row("Texto") = "Existencia"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Faltante"
        row("Ancho") = 81
        row("Texto") = "Faltante"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function

    Public Function GetAtributosMaterialEnReserva() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Libres"
        row("Ancho") = 67
        row("Texto") = "Libres"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Solicitados"
        row("Ancho") = 67
        row("Texto") = "Solicitados"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "EnReserva"
        row("Ancho") = 67
        row("Texto") = "En Reserva"
        atributos.Rows.Add(row)
        row = Nothing
        atributos.AcceptChanges()
        Return atributos
    End Function

    Public Function GetAtributosMaterialEnAclaracion() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Libres"
        row("Ancho") = 67
        row("Texto") = "Libres"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Solicitados"
        row("Ancho") = 67
        row("Texto") = "Solicitados"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "EnReserva"
        row("Ancho") = 67
        row("Texto") = "En Aclaración"
        atributos.Rows.Add(row)
        row = Nothing
        atributos.AcceptChanges()
        Return atributos
    End Function


    Public Function GetAtributosMaterialesEcommerce() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Talla"
        row("Ancho") = 67
        row("Texto") = "Talla"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Existencia"
        row("Ancho") = 67
        row("Texto") = "Existencia"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Solicitado"
        row("Ancho") = 81
        row("Texto") = "Solicitados"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function


    Public Function GetAtributosMaterialesNoEncontrados() As DataTable
        Dim atributos As New DataTable("Atributos")
        atributos.Columns.Add("NombreColumna", GetType(String))
        atributos.Columns.Add("Texto", GetType(String))
        atributos.Columns.Add("Ancho", GetType(Integer))
        atributos.Columns.Add("Visible", GetType(Boolean))
        atributos.AcceptChanges()
        Dim row As DataRow = atributos.NewRow()
        row("NombreColumna") = "CodArticulo"
        row("Ancho") = 105
        row("Texto") = "Código"
        atributos.Rows.Add(row)
        row = Nothing
        row = atributos.NewRow()
        row("NombreColumna") = "Descripcion"
        row("Ancho") = 200
        row("Texto") = "Descripción"
        atributos.Rows.Add(row)
        atributos.AcceptChanges()
        Return atributos
    End Function




    Public Sub AgruparPedidosSH(ByRef dtPed As DataTable)

        Dim dtTemp As DataTable = dtPed.Clone
        Dim oRow As DataRow, strPedidos As String = ""

        For Each oRow In dtPed.Rows
            If InStr(strPedidos.Trim, CStr(oRow!VBELN).Trim) <= 0 Then
                strPedidos &= CStr(oRow!VBELN).Trim & ","
                dtTemp.ImportRow(oRow)
            End If
        Next

        dtPed = dtTemp.Copy

    End Sub

#End Region

#Region "Consume Web Service Broker"

    'Public Function ConsumeWSBroker(ByVal UrlWS As String, ByVal strSoapEnvelope As String) As DataSet
    '    Dim objXMLHttp As XMLHTTP40
    '    Dim TextResponse As String = String.Empty
    '    Dim Status As String = String.Empty
    '    Dim StatusText As String = String.Empty

    '    Try
    '        objXMLHttp = New XMLHTTP40
    '        objXMLHttp.open("POST", UrlWS, False, "", "")
    '        objXMLHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
    '        objXMLHttp.send(strSoapEnvelope.ToString())
    '        'objXMLHttp.send()
    '        Status = objXMLHttp.status
    '        StatusText = objXMLHttp.statusText
    '        TextResponse = objXMLHttp.responseText.ToString

    '        '/////////////////////////////////////////////
    '        'Preparamos datos de respuesta
    '        '/////////////////////////////////////////////
    '        Dim XMLReader As New StringReader(TextResponse)
    '        Dim dsXML As New DataSet
    '        dsXML.ReadXml(XMLReader)

    '        '/////////////////////////////////////////////
    '        'Verificamos respuesta del servidor
    '        '/////////////////////////////////////////////
    '        If Status = 200 Then '// Si conexion HTTP es buena regresamos el DataSet
    '            Return dsXML
    '        Else '// De lo contrario mostramos Excepcion generada en el Servicio Web
    '            ShowExceptionXMLHTTP40(dsXML)
    '        End If

    '        'Eliminamos la conexion abierta dandole valor nulo al objeto
    '        objXMLHttp = Nothing

    '    Catch ex0 As Xml.XmlException
    '        Throw ex0
    '    Catch ex1 As ObjectDisposedException
    '        Throw ex1
    '    Catch ex2 As Exception
    '        Throw ex2
    '    Finally
    '        'Eliminamos la conexion abierta dandole valor nulo al objet
    '        objXMLHttp = Nothing
    '    End Try

    '    Return Nothing

    'End Function

    Public Function ConsumeXML(ByVal URL As String, ByVal strSoapEnvelope As String) As DataSet
        Dim oRequest As HttpWebRequest
        Dim oStream As Stream
        Dim oResponse As HttpWebResponse
        Dim oReader As StreamReader
        Dim strResponse As String
        Dim dsXML As New DataSet
        Try
            Dim data() As Byte
            'Instanciamos Objeto y seteamos parametros necesarios para consumir correctamente el REST
            oRequest = TryCast(WebRequest.Create(URL), HttpWebRequest)
            oRequest.Timeout = -1
            oRequest.Method = "POST"
            data = UTF8Encoding.UTF8.GetBytes(strSoapEnvelope)
            oRequest.ContentLength = data.Length
            oRequest.ContentType = "text/xml; charset=utf-8"
            oRequest.Accept = "text/xml; charset=utf-8"
            oStream = oRequest.GetRequestStream
            oStream.Write(data, 0, data.Length)
            'Obtenemos Respuesta
            oResponse = TryCast(oRequest.GetResponse(), HttpWebResponse)
            oReader = New StreamReader(oResponse.GetResponseStream())
            strResponse = oReader.ReadToEnd()
            oStream.Close()
            oReader.Close()
            Dim XMLReader As New StringReader(strResponse)
            dsXML.ReadXml(XMLReader)
        Catch web As System.Web.HttpException
            If web.ErrorCode = 404 Then
                Throw New Exception(Convert.ToString("WebService no encontrado") & URL)
            Else
                Throw web
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dsXML
    End Function

    Private Sub ShowExceptionXMLHTTP40(ByVal dsXML As DataSet)
        Dim FaultCode As String = dsXML.Tables(1).Rows(0).Item(0).ToString() 'faultCode
        Dim FaultString As String = dsXML.Tables(1).Rows(0).Item(1).ToString() 'faultString
        Dim Exception As String = dsXML.Tables(2).Rows(0).Item(0).ToString() 'Exception
        Dim Ex As New Exception(FaultString & vbCrLf & vbCrLf & Exception)
        Throw Ex
    End Sub

#End Region

#Region "DP Card"

    '-----------------------------------------------------------------------------
    'JNAVA (18.02.2015): Actualizamos el consecutivo POS
    '-----------------------------------------------------------------------------
    Public Function ActualizarConsecutivoPOS() As Boolean

        Dim bResp As Boolean = True

        Try

            Dim strConfigurationFile As String = Application.StartupPath & "\configCierre.cml"
            Dim oConfigReader As New SaveConfigArchivosReader(strConfigurationFile)

            'Revisamos si llego al limite del Consecutivo POS
            If oConfigCierreFI.ConsecutivoPOS = "9999" Then
                'Si llego al limite, reseteamos
                oConfigCierreFI.ConsecutivoPOS = "0001"
            Else
                'Si no llego al limite, aumentamos
                oConfigCierreFI.ConsecutivoPOS = CStr(oConfigCierreFI.ConsecutivoPOS + 1).PadLeft(4, "0")
            End If

            oConfigReader.SaveSettings(oConfigCierreFI)
            oConfigReader = Nothing
            LoadConfigCierreFI()
            '----------------------------------------------------------------------------------------------------------------
            'Guardamos Configuracion En Server
            '----------------------------------------------------------------------------------------------------------------
            SaveConfigCierreFiInServer(True)
            '----------------------------------------------------------------------------------------------------------------
            'EncriptarCML(strConfigurationFileFI)

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al Actualizar Consecutivo POS ", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Error al Actualizar Consecutivo POS " & Err.Erl)
            bResp = False
        End Try

        Return bResp

    End Function

    '-----------------------------------------------------------------------------
    'FLIZARRAGA 24/08/2016: Actualizamos el consecutivo DPCard Puntos
    '-----------------------------------------------------------------------------
    Public Function ActualizarConsecutivoPuntosPOS() As Boolean

        Dim bResp As Boolean = True

        Try

            Dim strConfigurationFile As String = Application.StartupPath & "\configCierre.cml"
            Dim oConfigReader As New SaveConfigArchivosReader(strConfigurationFile)

            'Revisamos si llego al limite del Consecutivo POS
            If oConfigCierreFI.ConsecutivoPuntosPOS = "9999" Then
                'Si llego al limite, reseteamos
                oConfigCierreFI.ConsecutivoPuntosPOS = "0001"
            Else
                'Si no llego al limite, aumentamos
                oConfigCierreFI.ConsecutivoPuntosPOS = CStr(oConfigCierreFI.ConsecutivoPuntosPOS + 1).PadLeft(4, "0")
            End If

            oConfigReader.SaveSettings(oConfigCierreFI)
            oConfigReader = Nothing
            LoadConfigCierreFI()
            '----------------------------------------------------------------------------------------------------------------
            'Guardamos Configuracion En Server
            '----------------------------------------------------------------------------------------------------------------
            SaveConfigCierreFiInServer(True)
            '----------------------------------------------------------------------------------------------------------------
            'EncriptarCML(strConfigurationFileFI)

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al Actualizar Consecutivo POS ", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Error al Actualizar Consecutivo POS " & Err.Erl)
            bResp = False
        End Try

        Return bResp

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/05/2017: Validacion de Luhn para las tarjetas Club DP
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidacionLuhn(ByVal NoTarjeta As String) As Boolean
        Dim valido As Boolean = True
        '----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
        '----------------------------------------------------------------------------------------------------------------------
        If NoTarjeta.Trim() <> "" Then
            If NoTarjeta.Trim().Length = 16 Then
                Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                Dim bin As Integer = CInt(NoTarjeta.Trim().Substring(0, 6))
                'ASANCHEZ 30/03/2021 nueva validación del bin ahora se validara en la bd de blue y tendra 3 validaciones de bin                
                Dim tipo_ As String = String.Empty
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        'ASANCHEZ 30/03/2021                     
                        Dim pares(7) As Integer
                        Dim impar(7) As Integer
                        Dim i As Integer
                        Dim suma As Integer = 0
                        Dim suma2 As Integer = 0

                        For i = 0 To 7
                            impar(i) = (Integer.Parse(NoTarjeta.Substring((i * 2) + 1, 1)))
                            pares(i) = Integer.Parse(NoTarjeta.Substring(i * 2, 1)) * 2
                            If (pares(i) > 9) Then
                                pares(i) = pares(i) - 9
                            End If
                            suma += pares(i) + impar(i)
                        Next i

                        suma2 = suma - impar(7)
                        suma2 = suma2 * 9
                        Dim dig_v As String
                        dig_v = suma2.ToString()
                        dig_v = dig_v.Substring(dig_v.Length - 1, 1)
                        If (suma Mod 10 <> 0) Or (Not dig_v.Equals(NoTarjeta.Substring(15))) Then
                            MsgBox("Número de Tarjeta Incorrecto. Favor de ingresar otra", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                            valido = False
                        End If
                    Else
                        'tipo_ = consulta_bin_tipo_blue(NoTarjeta.Trim())
                    End If
                End If

            Else
                MessageBox.Show("El número de tarjeta debe contener 16 digitos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                valido = False
            End If
        End If
        Return valido
    End Function

    Public Sub ValidarNumeros(e As System.Windows.Forms.KeyPressEventArgs)
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
            'ElseIf (Char.IsSeparator(e.KeyChar)) Then
            '    e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Public Sub TransaccionLogToka(ByVal strTransact As String)
        Dim exists As Boolean
        exists = System.IO.Directory.Exists("c:\LayoutTOKA")
        If Not exists Then
            My.Computer.FileSystem.CreateDirectory("c:\LayoutTOKA")
        End If
        Dim Day As DateTime = DateTime.Today
        Dim fileName As String = "LogToka" & Day.ToString("ddMMyyyy")
        Dim path As String = "c:\LayoutTOKA\" & fileName & ".txt"
        Dim StreamW As New StreamWriter(path, True)
        StreamW.WriteLine("Detalle --> " & strTransact)
        StreamW.Close()
    End Sub
    'funcion privada para ver el tipo de servicio en la consulta del bin en BLUE
    Public Function consulta_bin_tipo_blue(card_number As String) As String
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim bin8 As Integer = CInt(card_number.Trim().Substring(0, 8))
        Dim bin9 As Integer = CInt(card_number.Trim().Substring(0, 9))
        Dim bin6 As Integer = CInt(card_number.Trim().Substring(0, 3))
        Dim dt_9 As DataTable
        Dim dt_6 As DataTable
        Dim dt_8 As DataTable
        Dim tipo_ As String = String.Empty
        dt_8 = FacturaMgr.IsDPCardPuntosBlue(bin8)
        If dt_8.Rows.Count = 0 Then
            dt_9 = FacturaMgr.IsDPCardPuntosBlue(bin9)
            If dt_9.Rows.Count = 0 Then
                dt_6 = FacturaMgr.IsDPCardPuntosBlue(bin6)
                If dt_6.Rows.Count > 0 Then
                    For Each row As DataRow In dt_6.Rows
                        tipo_ = CStr(row!tipo).ToUpper()
                    Next
                End If
            Else
                For Each row As DataRow In dt_9.Rows
                    tipo_ = CStr(row!tipo).ToUpper()
                Next
            End If
        Else
            For Each row As DataRow In dt_8.Rows
                tipo_ = CStr(row!tipo).ToUpper()
            Next
        End If
        Return tipo_
    End Function
#End Region

#Region "Logueo"

    Public Sub EscribeLogTiempo(ByVal strError As String, ByVal Titulo As String)
        Dim StreamW As New StreamWriter(Application.StartupPath & "\TiemposRFC.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub

#End Region

End Module
