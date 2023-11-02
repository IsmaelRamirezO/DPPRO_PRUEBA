Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro
Imports System.IO
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.ApplicationUnits
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmInitialForm


    Inherits System.Windows.Forms.Form

    Private oApplicationContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oSAPConfiguration As SAPApplicationConfig
    Private oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos
    Private oProcesoSAPManager As ProcesoSAPManager


    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents gbProgreso As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents pbProceso As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents gbOperacion As Janus.Windows.EditControls.UIGroupBox
    Public WithEvents Timer2 As System.Windows.Forms.Timer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Public Nocturna As Boolean = False
    Public CierreDia As Boolean = False

    Dim strCentro As String
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Public strTipo As String = "0"
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public strOpcion As String = String.Empty
    Dim oServerUPCMgr As ServerUPCManager



    Public Sub New(ByVal ApplicationContext As DportenisPro.DPTienda.Core.ApplicationContext, ByVal SAPConfiguration As SAPApplicationConfig, ByVal ConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos)

        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigCierreFI = ConfigCierreFI
        oProcesoSAPManager = New ProcesoSAPManager(oApplicationContext, oSAPConfiguration)
        oAlmacenMgr = New CatalogoAlmacenesManager(oApplicationContext, oConfigCierreFI, oSAPConfiguration.TdaNueva)
        oServerUPCMgr = New ServerUPCManager(oApplicationContext, oConfigCierreFI)
        strCentro = oProcesoSAPManager.Read_Centros

    End Sub



    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gbProgreso = New Janus.Windows.EditControls.UIGroupBox()
        Me.pbProceso = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.gbOperacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProgreso.SuspendLayout()
        CType(Me.gbOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOperacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.gbProgreso)
        Me.ExplorerBar1.Controls.Add(Me.gbOperacion)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(382, 184)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'gbProgreso
        '
        Me.gbProgreso.BackColor = System.Drawing.Color.Transparent
        Me.gbProgreso.Controls.Add(Me.pbProceso)
        Me.gbProgreso.Controls.Add(Me.lblProgreso)
        Me.gbProgreso.Location = New System.Drawing.Point(24, 78)
        Me.gbProgreso.Name = "gbProgreso"
        Me.gbProgreso.Size = New System.Drawing.Size(322, 74)
        Me.gbProgreso.TabIndex = 2
        Me.gbProgreso.Text = " Progreso "
        Me.gbProgreso.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'pbProceso
        '
        Me.pbProceso.BackgroundFormatStyle.BackColor = System.Drawing.Color.White
        Me.pbProceso.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Lavender
        Me.pbProceso.BackgroundFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbProceso.Location = New System.Drawing.Point(8, 32)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.ProgressFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackColorAlphaMode = Janus.Windows.UI.AlphaMode.Opaque
        Me.pbProceso.ProgressFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ProgressFormatStyle.BackgroundImageDrawMode = Janus.Windows.UI.BackgroundImageDrawMode.Center
        Me.pbProceso.ProgressFormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        Me.pbProceso.ShowPercentage = True
        Me.pbProceso.Size = New System.Drawing.Size(294, 24)
        Me.pbProceso.TabIndex = 0
        Me.pbProceso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblProgreso
        '
        Me.lblProgreso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgreso.Location = New System.Drawing.Point(11, 16)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(291, 40)
        Me.lblProgreso.TabIndex = 2
        Me.lblProgreso.Visible = False
        '
        'gbOperacion
        '
        Me.gbOperacion.BackColor = System.Drawing.Color.Transparent
        Me.gbOperacion.Controls.Add(Me.lblProceso)
        Me.gbOperacion.Location = New System.Drawing.Point(24, 16)
        Me.gbOperacion.Name = "gbOperacion"
        Me.gbOperacion.Size = New System.Drawing.Size(322, 48)
        Me.gbOperacion.TabIndex = 1
        Me.gbOperacion.Text = " Proceso "
        Me.gbOperacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblProceso
        '
        Me.lblProceso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.Location = New System.Drawing.Point(8, 19)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(291, 17)
        Me.lblProceso.TabIndex = 0
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'frmInitialForm
        '
        Me.ClientSize = New System.Drawing.Size(382, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInitialForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descarga Inicial"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProgreso.ResumeLayout(False)
        CType(Me.gbOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOperacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub DeleteAlmacenIsDownload(ByVal descarga As String)
        Dim conexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Try
            command.CommandText = "DELETE FROM Descarga WHERE Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & _
                                  "' AND Caja='" & oApplicationContext.ApplicationConfiguration.NoCaja & _
                                  "' AND Descarga='" & descarga.ToUpper() & "'"
            command.Connection = conexion
            conexion.Open()
            command.ExecuteNonQuery()
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Sub ShowDev(ByVal Opcion As String)
        'Timer1.Enabled = False
        Me.Timer2.Enabled = True
        strOpcion = Opcion
        Me.ShowDialog()
    End Sub


    Private Sub ProcesarAlmacenes()

        Dim dtTemp As New DataTable
        Dim oAlmacen As Almacen
        Dim oRow As DataRow

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Almc", "NO", oSAPConfiguration.TdaNueva, "Catalogo Almacenes", Nocturna, CierreDia)

        oProcesoSAPManager.DeleteCatalogo("CatalogoAlmacenes")
        '-----------------------------------------------------------------------------------------------------------------------------------------------------
        'Llenamos catalogo almacenes
        '-----------------------------------------------------------------------------------------------------------------------------------------------------
        Me.lblProceso.Text = "CATALOGO ALMACENES"

        Me.lblProceso.Refresh()

        dtTemp = oAlmacenMgr.GetAllFromServer.Tables(0)

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow In dtTemp.Rows

            oAlmacen = oAlmacenMgr.Create

            With oAlmacen
                .ID = oRow!CodAlmacen
                .Descripcion = oRow!Descripcion
                .DireccionCalle = oRow!Calle
                .DireccionNumExt = oRow!NumExterior
                .DireccionCP = oRow!CP
                .DireccionCiudad = oRow!Ciudad
                .DireccionEstado = oRow!Estado
                .TelefonoNum = oRow!Telefono
                .MostrarEnSeparaciones = oRow!MostrarSeparaciones
                .PlazaID = oRow!CodPlaza
                .OficinaVta = oRow!OficinaVta
                oAlmacenMgr.Save(oAlmacen)
            End With
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next
        '-----------------------------------------------------------------------------------------------------------------------------------------------------
        'Llenamos catalogo centros
        '-----------------------------------------------------------------------------------------------------------------------------------------------------
        oProcesoSAPManager.DeleteCatalogo("CatalogoCentros")

        Me.lblProceso.Text = "CATALOGO CENTROS"

        Me.lblProceso.Refresh()

        dtTemp = oAlmacenMgr.GetAllCentrosFromServer.Tables(0)

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow In dtTemp.Rows

            oAlmacenMgr.SaveCentro(oRow!CentroSAP, oRow!OficinaVtas, oRow!Descripcion, oRow!CentroFI)

            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Almc", "SI", oSAPConfiguration.TdaNueva, "Catalogo Almacenes", Nocturna, CierreDia)

    End Sub



    Private Sub ProcesarRazonesRechazo()

        Dim dtTemp As New DataTable
        Dim bResult As Boolean = False

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Razo", "NO", oSAPConfiguration.TdaNueva, "Catalogo Razones", Nocturna, CierreDia)

        oProcesoSAPManager.DeleteCatalogo("CatalogoRazones")

        'Llenamos catalogo almacenes

        Me.lblProceso.Text = "CATALOGO RAZONES RECHAZO"

        Me.lblProceso.Refresh()

        dtTemp = oAlmacenMgr.GetRazonesRechazo(bResult)

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oProcesoSAPManager.Write_RazonesRechazo(oRow!RazonRechazoID, oRow!Razon, oRow!Modulo)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Razo", "SI", oSAPConfiguration.TdaNueva, "Catalogo Razones", Nocturna, CierreDia)

    End Sub



    Private Sub frmInitialForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load      
        Me.Refresh()
    End Sub


    Private Sub CreateZip(ByVal text As String)
        Dim strPath = "C:\DPPRO"
        Dim strZipFile As String = strPath & "\" & "download.zip"

        Dim zipBytes As Byte() = Convert.FromBase64String(text)

        'Grabar archivo .ZIP
        Using fs As FileStream = New FileStream(strZipFile, FileMode.Create)
            fs.Write(zipBytes, 0, zipBytes.Length)
        End Using

        'Descomprimir archivo
        Descomprimir(strPath, strZipFile, True)

        'Procesar archivo

    End Sub

    Private Function GetFileFromStr64(ByVal Centro As String, ByVal File As String) As DataTable
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable
        Dim oRetail As ProcesosRetail
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty
        Dim strFile As String = String.Empty


        Dim cadena As String = "(CentroIn eq '" & Centro & "' and FileTypeIn eq '" & File & "')"

        htParams.Add("$filter", cadena)
        htParams.Add("$format", "json")

        oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZOS_COMMX_GET_FILE_STORE_SRV/GetFileStr64Set", "GET")

        dtDatos = oRetail.GetFileStr64(htParams)

        Return dtDatos
    End Function


    Private Sub GetFileStr64(ByVal Centro As String, ByVal File As String)
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable
        Dim oRetail As ProcesosRetail
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty
        Dim strFile As String = String.Empty


        Dim cadena As String = "(CentroIn eq '" & Centro & "' and FileTypeIn eq '" & File & "')"

        htParams.Add("$filter", cadena)
        htParams.Add("$format", "json")

        oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZOS_COMMX_GET_FILE_STORE_SRV/GetFileStr64Set", "GET")

        dtDatos = oRetail.GetFileStr64(htParams)

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            Dim oRow As DataRow = dtDatos.Rows(0)
            CreateZip(oRow!FileStr64Out)

            'Procesar Archivo

            Dim fileValue As Integer = 0

            Select Case File
                Case "01"
                    strFile = "CA"
                    fileValue = 5
                    Me.lblProceso.Text = "CATALOGO ARTICULOS SAP"
                    Me.lblProceso.Refresh()
                Case "02"
                    strFile = "PR01"
                    fileValue = 2
                    Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA" & " " & strFile
                    Me.lblProceso.Refresh()
                Case "03"
                    strFile = "ZPRL"
                    fileValue = 4
                    Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA" & " " & strFile
                    Me.lblProceso.Refresh()
                Case "04"
                    strFile = "DESC" '"ZDP1"
                    fileValue = 6
                    Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA" & " " & strFile
                    Me.lblProceso.Refresh()
                Case "05"
                    strFile = "UPC"
                    fileValue = 8
                    Me.lblProceso.Text = "CATALOGO UPC"
                    Me.lblProceso.Refresh()
                Case "06"
                    strFile = "INV"
                    fileValue = 7
                    Me.lblProceso.Text = "CATALOGO EXISTENCIAS"
                    Me.lblProceso.Refresh()
            End Select

            fullPath = strRuta & strFile & ".txt"
            oProcesoSAPManager.LoadDataFromSAPtoDBNew(fullPath, fileValue)
            If Me.pbProceso.Value < 6 Then Me.pbProceso.Value += 1

        End If
        Threading.Thread.Sleep(2000)

    End Sub



    Private Sub frmInitialForm_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Me.Refresh()
        '    CargaDatos()
        '   Me.Close()
    End Sub

    Private Sub ProcesarArticulos()
        Dim dtDatos As DataTable
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty
        Dim strFile As String = "CA"
        Dim fileValue As Integer = 5

        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "NO", True, "Catalogo Articulos", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "NO", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna, CierreDia)
        End If

        dtDatos = GetFileFromStr64(strCentro, "01")
        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = 1

        Me.lblProceso.Text = "CATALOGO ARTICULOS SAP"
        Me.lblProceso.Refresh()

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then

            'Crear archivo
            Dim oRow As DataRow = dtDatos.Rows(0)
            CreateZip(oRow!FileStr64Out)

            'Actualizar datos
            fullPath = strRuta & strFile & ".txt"
            oProcesoSAPManager.LoadDataFromSAPtoDBNew(fullPath, fileValue)

        End If
        Me.pbProceso.Value += 1

        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status del catalogo Articulos en servidor de Operaciones
        '------------------------------------------------------------------------------------------------------------------

        If oSAPConfiguration.DercargaManual Then

            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "SI", True, "Catalogo Articulos", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "SI", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna, CierreDia)

        End If

    End Sub


    Private Sub ProcesarDescuentos(ByVal strFile As String, ByVal Opcion As String, ByVal fileValue As Integer)
        Dim dtDatos As DataTable
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty



        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", True, "Descuentos", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)
        End If

        dtDatos = GetFileFromStr64(strCentro, Opcion)
        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = 1

        Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA " & strFile
        Me.lblProceso.Refresh()

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then

            'Crear archivo
            Dim oRow As DataRow = dtDatos.Rows(0)
            CreateZip(oRow!FileStr64Out)

            'Actualizar datos
            fullPath = strRuta & strFile & ".txt"
            oProcesoSAPManager.LoadDataFromSAPtoDBNew(fullPath, fileValue)

        End If
        Me.pbProceso.Value += 1

        '-------------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status del catalogo descuentos en servidor de Operaciones
        '-------------------------------------------------------------------------------------------------------------------------

        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", True, "Descuentos", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)
        End If

    End Sub


    Private Sub ProcesarUPC()
        Dim dtDatos As DataTable
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty
        Dim strFile As String = "UPC"
        Dim fileValue As Integer = 8

        dtDatos = GetFileFromStr64(strCentro, "05")
        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = 1

        Me.lblProceso.Text = "CATALOGO UPC"
        Me.lblProceso.Refresh()


        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "NO", True, "Catalogo UPC", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "NO", oSAPConfiguration.TdaNueva, "Catalogo UPC", Nocturna, CierreDia)
        End If

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then

            'Crear archivo
            Dim oRow As DataRow = dtDatos.Rows(0)
            CreateZip(oRow!FileStr64Out)

            'Actualizar datos
            fullPath = strRuta & strFile & ".txt"
            oProcesoSAPManager.LoadDataFromSAPtoDBNew(fullPath, fileValue)

        End If
        Me.pbProceso.Value += 1

        'Actualizamos el status del catalogo Upc en servidor de Operaciones
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "SI", oSAPConfiguration.TdaNueva, "Catalogo UPC", Nocturna, CierreDia)

    End Sub

    Private Sub ProcesarExistencias()
        Dim dtDatos As DataTable
        Dim strRuta As String = "C:\DPPRO\"
        Dim fullPath As String = String.Empty
        Dim strFile As String = "INV"
        Dim fileValue As Integer = 7


        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "NO", True, "Inventario", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "NO", oSAPConfiguration.TdaNueva, "Inventario", Nocturna, CierreDia)
        End If

        dtDatos = GetFileFromStr64(strCentro, "06")
        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = 1

        Me.lblProceso.Text = "CATALOGO DE EXISTENCIAS"
        Me.lblProceso.Refresh()

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then

            'Crear archivo
            Dim oRow As DataRow = dtDatos.Rows(0)
            CreateZip(oRow!FileStr64Out)

            'Actualizar datos
            fullPath = strRuta & strFile & ".txt"
            oProcesoSAPManager.LoadDataFromSAPtoDBNew(fullPath, fileValue)

        End If
        Me.pbProceso.Value += 1

        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status de la existencia en servidor de Operaciones
        '------------------------------------------------------------------------------------------------------------------

        If oSAPConfiguration.DercargaManual Then
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "SI", True, "Inventario", Nocturna, CierreDia)
        Else
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "SI", oSAPConfiguration.TdaNueva, "Inventario", Nocturna, CierreDia)

        End If


    End Sub

   

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Try
            Select Case UCase(strOpcion)
                Case UCase("01") 'Articulos
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarArticulos()
                    Catch ex As Exception

                        EscribeLog(ex.ToString, "Error al descargar los articulos de SAP")
                        MsgBox("Error al realizar la descarga de Artículos", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("02") 'Descuentos PRO1
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarDescuentos("PR01", "02", 2)
                    Catch ex As Exception

                        EscribeLog(ex.ToString, "Error al descargar los articulos de SAP")
                        MsgBox("Error al realizar la descarga de Descuentos PR01", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("03") 'Descuentos ZPRL
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarDescuentos("ZPRL", "03", 4)
                    Catch ex As Exception

                        EscribeLog(ex.ToString, "Error al descargar los articulos de SAP")
                        MsgBox("Error al realizar la descarga de Descuentos ZPRL", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("04") 'Descuentos DESC
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarDescuentos("DESC", "04", 6)
                    Catch ex As Exception

                        EscribeLog(ex.ToString, "Error al descargar los articulos de SAP")
                        MsgBox("Error al realizar la descarga de Descuentos DESC", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("05")  'Codigos UPC
                    ''''***Procesar Catalogo UPC
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarUPC()
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al descargar los codigos UPC de SQL")
                        MsgBox("Error al realizar la descarga de Códigos UPC", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("06")  'Existencias
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarExistencias()
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al descargar los codigos UPC de SQL")
                        MsgBox("Error al realizar la descarga de Existencias", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("Almacenes") '***Procesar Catalogo Almacenes
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarAlmacenes()
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al descargar los almacenes de SQL")
                        MsgBox("Error al realizar la descarga de Almacenes", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

                Case UCase("RazonesRechazo") '***Procesar Catalogo Razones Rechazo
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarRazonesRechazo()
                    Catch ex As Exception
                        MsgBox("Error al realizar la descarga de Razones de Rechazo", MsgBoxStyle.Exclamation, Me.Text)
                        EscribeLog(ex.ToString, "Error al descargar las razones rechazo de SAP")
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)

            End Select
            Threading.Thread.Sleep(1000)
            DeleteAlmacenIsDownload(strOpcion)
            ' MsgBox("Proceso de Carga finalizó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAP")
            Me.Close()

        Catch ex As Exception
            DeleteAlmacenIsDownload(strOpcion)
            EscribeLog(ex.Message, "Error de descarga") ', ex1)

        End Try
    End Sub

   
End Class