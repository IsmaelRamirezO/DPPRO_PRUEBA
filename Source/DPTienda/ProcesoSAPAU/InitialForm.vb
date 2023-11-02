Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos.SaveConfigArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoPromocionesAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFamilias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCategorias
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas
Imports System.IO
Imports System.Windows.Forms

Public Class InitialForm

    Inherits System.Windows.Forms.Form

    Private oApplicationContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oSAPConfiguration As SAPApplicationConfig
    Private oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos
    Private oProcesoSAPManager As ProcesoSAPManager
    Dim oSeparacionesMgr As SeparacionesManager
    Dim oCatPromoMgr As CatalogoPromocionesManager
    Public strOpcion As String = String.Empty
    Dim oServerUPCMgr As ServerUPCManager
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oMarcasMgr As CatalogoMarcasManager
    Public FechaDA As Date = Date.Today
    Public OpcDescAdi As Integer = -1 'Se utiliza cuando algun descuento adicional fue modificado durante el dia para hacer solo la descarga de ese
    Public bPorCodigo As Boolean = False
    Public dtMateriales As DataTable
    Public Nocturna As Boolean = False
    Public bMostrarMensaje As Boolean = True
    Public OrganizacionCompra As String
    Public Canal As String
    Public Sector As String
    Public CierreDia As Boolean = False


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal ApplicationContext As DportenisPro.DPTienda.Core.ApplicationContext, ByVal SAPConfiguration As SAPApplicationConfig, ByVal ConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos)

        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigCierreFI = ConfigCierreFI
        oServerUPCMgr = New ServerUPCManager(oApplicationContext, oConfigCierreFI)
        oSeparacionesMgr = New SeparacionesManager(oApplicationContext, oConfigCierreFI)
        oCatPromoMgr = New CatalogoPromocionesManager(oApplicationContext, oConfigCierreFI)
        oAlmacenMgr = New CatalogoAlmacenesManager(oApplicationContext, oConfigCierreFI, oSAPConfiguration.TdaNueva)
        oMarcasMgr = New CatalogoMarcasManager(oApplicationContext)

    End Sub


    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents gbOperacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbProgreso As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents pbProceso As Janus.Windows.EditControls.UIProgressBar
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InitialForm))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gbProgreso = New Janus.Windows.EditControls.UIGroupBox()
        Me.pbProceso = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.gbOperacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
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
        Me.ExplorerBar1.Size = New System.Drawing.Size(370, 160)
        Me.ExplorerBar1.TabIndex = 0
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'InitialForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InitialForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Inicial de Datos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProgreso.ResumeLayout(False)
        CType(Me.gbOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOperacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        oServerUPCMgr.SetCargasIniciales(oApplicationContext.ApplicationConfiguration.Almacen)

        Timer1.Enabled = False
        Console.WriteLine(Now.ToLongTimeString)
        oProcesoSAPManager = New ProcesoSAPManager(oApplicationContext, oSAPConfiguration)

        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Almacenes
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarAlmacenes()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Almacenes")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Vendedores
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarVendedores()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Vendedores")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Clientes
        '--------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.UsarDescargaClientes Then
            Try
                ProcesarClientes()
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al realizar la descarga de Clientes")
            End Try
        End If
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Articulos
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarArticulos()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Articulos")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo EXISTENCIAS
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
                ProcesarExistencias()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Inventario")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Promociones
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarPromociones()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Promociones de Bines")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo Marcas
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarMarcas()
            ProcesarCatalogos()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de catalogos")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Descuentos Adicionales
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarDescuentosAdicionales(FechaDA)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Descuentos Adicionales")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Razones de Rechazo
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarRazonesRechazo()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Razones de Rechazo")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Codigos Postales
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarCodigosPostales()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Codigos Postales")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo ZPP_COBRANZAS
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarZPP_COBRANZAS()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Cobranza")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo CondicionesVenta 
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            
                Console.WriteLine(Now.ToLongTimeString)

                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)

                oProcesoSAPManager.Delete_CondicionesPreDectos()
                'Limpiar la Tabla de Condiciones de Venta
                If oSAPConfiguration.TdaNueva = True OrElse Nocturna Then oProcesoSAPManager.DeleteCatalogo("CondicionesVenta")

                Console.WriteLine(Now.ToLongTimeString)

                If oApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    GoTo Cambio_053
                    'ProcesarCondicionesVta("J3AP", "Z0") 'Precio Con IVA
                    'ProcesarCondicionesVta("J3AP", "C1") 'Precio Con 10% Descuento
                    'ProcesarCondicionesVta("J3AP", "C2") 'Precio Con 25% Descuento
                    'ProcesarCondicionesVta("Z521", "C1") 'Lista Precios C1
                    'ProcesarCondicionesVta("Z521", "C2") 'Lista Precios C2
                Else
Cambio_053:
                        ProcesarCondicionesVta("ZPRL") ', "Z1") 'Precio Sin IVA
                        ProcesarCondicionesVta("PR01") ', "Z0") 'Precio Con IVA      
                        ProcesarCondicionesVta("ZDP1") ', "Z1") 'Lista Precios Z1

                        '-------------------------------------------------------------------------------------------------------------------------------------
                        'Actualizamos el status del catalogo descuentos en servidor de Operaciones
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        If bPorCodigo = False Then
                            If oSAPConfiguration.DercargaManual Then
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", True, "Descuentos", Nocturna, CierreDia)
                            Else
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)
                            End If
                        End If
                    End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de Condiciones de Venta")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Validar los Apartados y Defectuosos
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Try
        '    ValidarDefectuososApartados()
        'Catch ex As Exception
        '    EscribeLog(ex.ToString, "Error al realizar la validacion de apartados y defectuosos")
        'End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Procesar Catalogo UPC
        '--------------------------------------------------------------------------------------------------------------------------------------
        Try
            ProcesarUPC()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar la descarga de UPCs")
        End Try
        '--------------------------------------------------------------------------------------------------------------------------------------
        Console.WriteLine(Now.ToLongTimeString)
        If bMostrarMensaje = True Then MsgBox("Proceso de Carga Inicial finalizó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "SAP")

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Public Function AlmacenIsDownloading(ByVal descarga As String) As Hashtable
        Dim conexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim reader As SqlClient.SqlDataReader
        Dim count As Integer = 0
        Dim almacen As Hashtable = New Hashtable(2)
        Try
            command.CommandText = "SELECT Caja,Fecha FROM Descarga " & _
                                      "WHERE Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & _
                                      "' AND Descarga='" & descarga.ToUpper() & "'"
            command.Connection = conexion
            conexion.Open()
            reader = command.ExecuteReader()
            If (reader.HasRows) Then
                almacen("IsDownloading") = True
                reader.Read()
                almacen("Caja") = reader("Caja")
                almacen("Fecha") = reader("Fecha")
            Else
                almacen("IsDownloading") = False
            End If
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return almacen
    End Function

    Public Function InsertAlmacenDownload(ByVal descarga As String)
        Dim conexion As SqlClient.SqlConnection = New SqlClient.SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Try
            command.CommandText = "INSERT INTO Descarga(Almacen,Caja,Descarga,Fecha)VALUES('" & _
                                 oApplicationContext.ApplicationConfiguration.Almacen & _
                                 "','" & oApplicationContext.ApplicationConfiguration.NoCaja & "','" & descarga.ToUpper() & _
                                 "',GetDate());"
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
    End Function

    Public Function DeleteAlmacenIsDownload(ByVal descarga As String)
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
    End Function

    Private Sub ProcesarVendedores()

        'Procesamos vendedores
        Dim dtVendedoresSAP As DataTable
        Me.lblProceso.Text = "CATALOGO VENDEDORES"
        Me.lblProceso.Refresh()

        'oProcesoSAPManager.DeleteCatalogo("CatalogoVendedores")
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Vend", "NO", oSAPConfiguration.TdaNueva, "Catalogo Vendedores", Nocturna, CierreDia)

        dtVendedoresSAP = oProcesoSAPManager.Read_Vendedores

        If dtVendedoresSAP.Rows.Count > 0 Then

            Me.pbProceso.Value = 0

            Me.pbProceso.Maximum = dtVendedoresSAP.Rows.Count

            Dim oRow As DataRow : Dim intCount As Integer = 0

            For Each oRow In dtVendedoresSAP.Rows

                Me.pbProceso.Value += 1
                '''Insertamos o Actualizamos Vendedores Local
                oProcesoSAPManager.Write_Vendedores(oRow!Clave, oRow!Nombre)

            Next

        End If

        'Actualizamos el status del catalogo vendedores en servidor de Operaciones
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Vend", "SI", oSAPConfiguration.TdaNueva, "Catalogo Vendedores", Nocturna, CierreDia)

    End Sub

    Private Sub ValidarDefectuososApartados()

        'Procesamos vendedores
        Dim dsResult As New DataSet
        Me.lblProceso.Text = "APARTADOS DEFECTUOSOS"
        Me.lblProceso.Refresh()
        dsResult = oProcesoSAPManager.ApartadosDefectuosos()
        If Not dsResult Is Nothing Then
            If dsResult.Tables(0).Rows.Count > 0 Then
                'Mostrar Reporte
                'Dim iRep As AcrRptDifSAPyDP
                'Dim iView As ReportViewerForm
                'iRep = New AcrRptDifSAPyDP
                'iView = New ReportViewerForm
                'iRep.Document.Name = "Reporte Diferencias Apartados y Defectusos con SAP"
                'iRep.DataSource = dsResult.Tables(0)
                'iRep.Run()
                'iView.Report = iRep
                'iView.Show()
            End If
        End If

    End Sub

    Private Sub ProcesarClientes()
        'Procesamos Clientes
        Dim dtClientesSAP As DataTable
        Dim oCliente As New ClientesSAP
        Me.lblProceso.Text = "CATALOGO CLIENTES SAP"
        Me.lblProceso.Refresh()
        dtClientesSAP = oProcesoSAPManager.Read_Clientes(oConfigCierreFI.OrganizacionCompra, oConfigCierreFI.CanalDistribucion, oConfigCierreFI.Sector)
        Dim strApepApemNom() As String
        Dim strNombre As String
        Dim strApelidos As String


        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Clie", "NO", oSAPConfiguration.TdaNueva, "Catalogo Clientes", Nocturna, CierreDia)

        If dtClientesSAP.Rows.Count > 0 Then

            Me.pbProceso.Value = 0

            Me.pbProceso.Maximum = dtClientesSAP.Rows.Count

            Dim oRow As DataRow : Dim intCount As Integer = 0

            For Each oRow In dtClientesSAP.Rows

                Me.pbProceso.Value += 1
                'Separamos el Nombre de loos Apellidos 
                '
                strApepApemNom = Split(oRow!NAME1, "_")
                Select Case strApepApemNom.Length
                    Case 6
                        strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                        strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2) & " " & strApepApemNom(3)
                    Case 5
                        strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                        strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & "_" & strApepApemNom(2)
                    Case 4
                        strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                        strApelidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                    Case 3
                        strNombre = Trim(strApepApemNom(2))
                        strApelidos = strApepApemNom(0) & "_" & strApepApemNom(1)
                    Case 2
                        strNombre = strApepApemNom(1)
                        strApelidos = Trim(strApepApemNom(0))
                    Case 1
                        strNombre = ""
                        strApelidos = Trim(strApepApemNom(0))
                    Case Else
                        strNombre = ""
                        strApelidos = ""
                End Select
                '''Insertamos los valor del cliente a la Clase
                With oCliente
                    .Clienteid = oRow!KUNNR
                    .Nombre = oRow!NAME1
                    .Apellidos = CStr(oRow!NAME2)
                    '.Sexo = oRow!DEAR1
                    Select Case CStr(oRow!ANRED).Trim().ToUpper()
                        Case "SEÑORA"
                            .Sexo = "F"
                        Case "SEÑOR"
                            .Sexo = "M"
                        Case "E"
                            .Sexo = "E"
                        Case Else
                            .Sexo = CStr(oRow!ANRED).Trim().ToUpper()
                    End Select
                    .Estadocivil = oRow!DATLT
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
                    'End If
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
                    '.ClaveAnterior = oRow!ALTKN
                    '.TipoVenta = getTipoventa(oRow!BZIRK)
                    .TipoVenta = oRow!KTOKD
                    .Player = oRow!VKGRP
                End With
                oProcesoSAPManager.Write_Clientes(oCliente)
                Me.pbProceso.Refresh()
            Next

        End If

        'Actualizamos el status del catalogo clientes en servidor de Operaciones
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Clie", "SI", oSAPConfiguration.TdaNueva, "Catalogo Clientes", Nocturna, CierreDia)

    End Sub

    Private Function getTipoventa(ByVal strtipovta As String) As String
        Select Case strtipovta
            Case "TFON" : Return "K"
            Case "FONA" : Return "F"
            Case "FACI" : Return "O"
        End Select
    End Function

    '    Private Sub ProcesarArticulos()
    '        'Procesamos articulo
    '        Dim fechaIni As Date = Date.Now
    '        Dim fechaFin As Date = Date.Now
    '        Dim dtArticulosSAP As DataTable
    '        Dim dtArticulos As New ArticulosSAP
    '        Dim dtTemp As DataTable

    '        Me.lblProceso.Text = "CATALOGO ARTICULOS"
    '        Me.lblProceso.Refresh()

    '        '------------------------------------------------------------------------------------------------------------------
    '        'Obtenemos la info de SAP
    '        '------------------------------------------------------------------------------------------------------------------
    '        If bPorCodigo = False Then
    '            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "NO", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna)

    '            dtArticulosSAP = oProcesoSAPManager.Read_Articulos(fechaIni, fechaFin)
    '        Else
    '            For Each oRowM As DataRow In dtMateriales.Rows
    '                dtTemp = oProcesoSAPManager.ZRFC_CARGAARTICULO_XCODIGO(oRowM!Material)
    '                If dtArticulosSAP Is Nothing Then
    '                    dtArticulosSAP = dtTemp.Copy
    '                Else
    '                    For Each oRowT As DataRow In dtTemp.Rows
    '                        dtArticulosSAP.ImportRow(oRowT)
    '                    Next
    '                    dtArticulosSAP.AcceptChanges()
    '                End If
    '            Next
    '        End If
    '        '------------------------------------------------------------------------------------------------------------------
    '        'Actualizamos la tabla con la info recibida de SAP
    '        '------------------------------------------------------------------------------------------------------------------
    '        If dtArticulosSAP.Rows.Count > 0 Then

    '            Me.pbProceso.Value = 0

    '            Me.pbProceso.Maximum = dtArticulosSAP.Rows.Count

    '            Dim oRow As DataRow : Dim intCount As Integer = 0

    '            For Each oRow In dtArticulosSAP.Rows

    '                Me.pbProceso.Value += 1
    '                '''Insertamos los datos del articulo a la clase
    '                With dtArticulos

    '                    .Codarticulo = oRow!MATNR
    '                    .Codartprov = oRow!MATNR
    '                    .Descripcion = oRow!MAKTX
    '                    .Codlinea = Mid(CStr(oRow!PRDHA), 5, 3)
    '                    .Codcorrida = oRow!J_3APGNR

    '                    If Mid(CStr(oRow!PRDHA), 8, 3) = "" Then
    '                        .Codcategoria = 0 'int
    '                    Else
    '                        .Codcategoria = Mid(CStr(oRow!PRDHA), 8, 3) 'int
    '                    End If

    '                    .Codfamilia = Mid(CStr(oRow!PRDHA), 3, 2)
    '                    .CodUso = Mid(CStr(oRow!PRDHA), 11, 8)
    '                    .Costopromedio = oRow!STPRS 'money
    '                    .Codunidadcom = oRow!MEINS
    '                    .Codunidadvta = oRow!MEINS
    '                    .Jerarquia = oRow!PRDHA
    '                    .CodigoAnterior = oRow!IDNLF
    '                    If oRow!FORMT = "01" Then
    '                        .Dip = 1
    '                    Else 'If oRow!DIP = String.Empty Then
    '                        .Dip = 0
    '                    End If

    '                End With
    '                oProcesoSAPManager.Write_Articulos(dtArticulos)
    '                Me.pbProceso.Refresh()
    '            Next

    '        End If
    '        '------------------------------------------------------------------------------------------------------------------
    '        'Actualizamos el status del catalogo Articulos en servidor de Operaciones
    '        '------------------------------------------------------------------------------------------------------------------
    '        If bPorCodigo = False Then oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "SI", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna,CierreDia)

    '    End Sub

    '    Private Sub ProcesarCondicionesVta(ByVal strCondicionVta As String, ByVal strLstPrecio As String)
    '        'Procesamos Condiciones de venta
    '        Dim dtCondicionesVta As DataTable
    '        Dim oCondicionesVta As New CondicionesVtaSAP
    '        Dim dtTemp As DataTable

    '        Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA" & " " & strCondicionVta & " " & strLstPrecio
    '        Me.lblProceso.Refresh()

    '        If bPorCodigo = False Then
    '            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna)
    '            dtCondicionesVta = oProcesoSAPManager.Read_CondicionesPreDectos(strCondicionVta, strLstPrecio, Nocturna)
    '        Else
    '            For Each oRowM As DataRow In dtMateriales.Rows
    '                oProcesoSAPManager.VenceDescuentoSistema(oRowM!Material)
    '                dtTemp = oProcesoSAPManager.Read_CondicionesPreDectosXCodigo(strCondicionVta, strLstPrecio, oRowM!Material)
    '                If dtCondicionesVta Is Nothing Then
    '                    dtCondicionesVta = dtTemp.Copy
    '                Else
    '                    For Each oRowT As DataRow In dtTemp.Rows
    '                        dtCondicionesVta.ImportRow(oRowT)
    '                    Next
    '                    dtCondicionesVta.AcceptChanges()
    '                End If
    '            Next
    '        End If
    '        'Dim strRuta As String = "C:\CondicionesVta" & strCondicionVta & " " & strLstPrecio & ".csv"
    '        'Dim txtWriter As System.IO.StreamWriter = New System.IO.StreamWriter(strRuta, False)

    '        If dtCondicionesVta.Rows.Count > 0 Then

    '            Me.pbProceso.Value = 0

    '            Me.pbProceso.Maximum = dtCondicionesVta.Rows.Count

    '            Dim oRow As DataRow : Dim intCount As Integer = 0

    '            For Each oRow In dtCondicionesVta.Rows

    '                Me.pbProceso.Value += 1

    '                If strCondicionVta = "J3AP" Then
    '                    Select Case strLstPrecio
    '                        Case "Z1"
    '                            'si la condicion es J3AP y Z1 se actualiza el precio 
    '                            'de(venta) en la tabla Catalogo de articulos campo PrecioVenta
    '                            oProcesoSAPManager.Write_ArticulosPrecioVenta(oRow!Material, oRow!Importe)
    '                            oProcesoSAPManager.Write_ArticulosPrecioSocio(oRow!Material, oRow!Importe)
    '                        Case "Z0"
    '                            'para 053 y demas
    '                            'si la condicion es J3AP y Z0 se actualiza el precio 
    '                            'de(venta) en la tabla Catalogo de articulos campo PrecioconIVA
    '                            oProcesoSAPManager.Write_ArticulosPrecioIVA(oRow!Material, oRow!Importe)
    '                        Case "C1"
    '                            'Precio Venta 10% de descuento para 053
    '                            oProcesoSAPManager.Write_ArticulosPrecioVenta(oRow!Material, oRow!Importe)
    '                        Case "C2"
    '                            'Precio Socio 25% de Descuento para 053
    '                            oProcesoSAPManager.Write_ArticulosPrecioSocio(oRow!Material, oRow!Importe)
    '                    End Select

    '                Else
    '                    'Si es otra condicion se mandan los datos a la
    '                    'tabla de Condiciones de Venta
    '                    With oCondicionesVta
    '                        .Condicion = strCondicionVta
    '                        .OrgVtas = "CDPT"
    '                        If oApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                            GoTo Cambio_053
    '                            '.CanalDist = "C1"
    '                        Else
    'Cambio_053:
    '                            .CanalDist = "T1"
    '                        End If
    '                        .OficinaVtas = oRow!OficinaVentas
    '                        .ListPrec = oRow!ListaPrecios
    '                        .Material = oRow!Material
    '                        .Jerarquia = oRow!Jerarquia
    '                        .CondMat = oRow!GpoMater
    '                        .CondPrec = oRow!GpoPrecios
    '                        If strCondicionVta = "Z501" Then
    '                            .Descmonto = oRow!Importe
    '                            .DescPorcentaje = 0
    '                        Else
    '                            If strCondicionVta = "Z521" Or strCondicionVta = "Z522" Then
    '                                .Descmonto = 0
    '                                .DescPorcentaje = (CDec(oRow!Importe) / 10)
    '                            End If
    '                        End If
    '                        .FechaIni = oRow!FechaIni
    '                        .FechaFin = oRow!FechaFin
    '                    End With
    '                    oProcesoSAPManager.Write_CondicionesPreDectos(oCondicionesVta)
    '                End If
    '                Me.pbProceso.Refresh()
    '                'txtWriter.WriteLine(oRow!Material & "," & oRow!Importe & "," & oRow!FechaIni & "," & oRow!FechaFin & "," & oRow!OficinaVentas & "," & oRow!Jerarquia & "," & oRow!GpoMater & "," & oRow!GpoPrecios & "," & oRow!ListaPrecios)
    '            Next
    '            'txtWriter.Close()

    '        End If
    '        '-------------------------------------------------------------------------------------------------------------------------------------------------
    '        'Actualizamos el status del catalogo descuentos en servidor de Operaciones
    '        '-------------------------------------------------------------------------------------------------------------------------------------------------
    '        If bPorCodigo = False Then oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna)

    '    End Sub

    Private Sub ProcesarArticulos()
        'Procesamos articulo
        Dim fechaIni As Date = Date.Now
        Dim fechaFin As Date = Date.Now
        Dim dtArticulosSAP As DataTable
        Dim dtArticulos As New ArticulosSAP
        Dim dtTemp As DataTable

        Me.lblProceso.Text = "CATALOGO ARTICULOS"
        Me.lblProceso.Refresh()

        '------------------------------------------------------------------------------------------------------------------
        'Obtenemos la info de SAP
        '------------------------------------------------------------------------------------------------------------------
        Me.lblProgreso.Text = "Extrayendo la información de SAP. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If bPorCodigo = False Then
            If oSAPConfiguration.DercargaManual Then
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "NO", True, "Catalogo Articulos", Nocturna, CierreDia)
            Else
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "NO", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna, CierreDia)
            End If

            dtArticulosSAP = oProcesoSAPManager.Read_Articulos(fechaIni, fechaFin)
        Else
            For Each oRowM As DataRow In dtMateriales.Rows
                dtTemp = oProcesoSAPManager.ZRFC_CARGAARTICULO_XCODIGO(oRowM!Material)
                If dtArticulosSAP Is Nothing Then
                    dtArticulosSAP = dtTemp.Copy
                Else
                    For Each oRowT As DataRow In dtTemp.Rows
                        dtArticulosSAP.ImportRow(oRowT)
                    Next
                    dtArticulosSAP.AcceptChanges()
                End If
            Next
        End If
        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos la tabla con la info recibida de SAP
        '------------------------------------------------------------------------------------------------------------------
        Me.lblProgreso.Text = "Cargando la información. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If dtArticulosSAP.Rows.Count > 0 Then

            'GenerarArchivoDataLoad("CA", dtArticulosSAP)

            'Me.pbProceso.Value = 0

            'Me.pbProceso.Maximum = dtArticulosSAP.Rows.Count

            'Dim oRow As DataRow : Dim intCount As Integer = 0

            'For Each oRow In dtArticulosSAP.Rows

            '    Me.pbProceso.Value += 1
            '    '''Insertamos los datos del articulo a la clase
            '    With dtArticulos

            '        .Codarticulo = oRow!MATNR
            '        .Codartprov = oRow!MATNR
            '        .Descripcion = oRow!MAKTX
            '        .Codlinea = Mid(CStr(oRow!PRDHA), 5, 3)
            '        .Codcorrida = oRow!J_3APGNR

            '        If Mid(CStr(oRow!PRDHA), 8, 3) = "" Then
            '            .Codcategoria = 0 'int
            '        Else
            '            .Codcategoria = Mid(CStr(oRow!PRDHA), 8, 3) 'int
            '        End If

            '        .Codfamilia = Mid(CStr(oRow!PRDHA), 3, 2)
            '        .CodUso = Mid(CStr(oRow!PRDHA), 11, 8)
            '        .Costopromedio = oRow!STPRS 'money
            '        .Codunidadcom = oRow!MEINS
            '        .Codunidadvta = oRow!MEINS
            '        .Jerarquia = oRow!PRDHA
            '        .CodigoAnterior = oRow!IDNLF
            '        If oRow!FORMT = "01" Then
            '            .Dip = 1
            '        Else 'If oRow!DIP = String.Empty Then
            '            .Dip = 0
            '        End If

            '    End With
            '    oProcesoSAPManager.Write_Articulos(dtArticulos)
            '    Me.pbProceso.Refresh()
            'Next
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.08.2014: Se modifico la forma de hacer la carga de informacíon para agilizarla, ahora se hace de manera masiva
            '---------------------------------------------------------------------------------------------------------------------------------

            If bPorCodigo = False Then
                Dim strFile As String = "CA"

                GenerarArchivoDataLoad(strFile, dtArticulosSAP)
                oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 5)
            Else
                oProcesoSAPManager.InsertUpdCatalogoArticulos(dtArticulosSAP)
            End If


        End If
        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status del catalogo Articulos en servidor de Operaciones
        '------------------------------------------------------------------------------------------------------------------
        If bPorCodigo = False Then
            If oSAPConfiguration.DercargaManual Then

                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "SI", True, "Catalogo Articulos", Nocturna, CierreDia)
            Else
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Arti", "SI", oSAPConfiguration.TdaNueva, "Catalogo Articulos", Nocturna, CierreDia)

            End If
        End If
    End Sub


    Private Sub ProcesarCondicionesVta(ByVal strCondicionVta As String) ', ByVal strLstPrecio As String)
        'Procesamos Condiciones de venta
        Dim dtCondicionesVta As DataTable
        Dim oCondicionesVta As New CondicionesVtaSAP
        Dim dtTemp As DataTable

        Me.lblProceso.Text = "CATALOGO CONDICIONES DE VENTA" & " " & strCondicionVta '& " " & strLstPrecio
        Me.lblProceso.Refresh()

        Me.lblProgreso.Text = "Extrayendo la información de SAP. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If bPorCodigo = False Then
            'dtCondicionesVta = oProcesoSAPManager.Read_CondicionesPreDectos(strCondicionVta, strLstPrecio, Nocturna)
            dtCondicionesVta = oProcesoSAPManager.ZBAPI_Extraer_PreciosCondiciones(strCondicionVta, "", Nocturna)
        Else
            For Each oRowM As DataRow In dtMateriales.Rows
                oProcesoSAPManager.VenceDescuentoSistema(oRowM!Material)
                'dtTemp = oProcesoSAPManager.Read_CondicionesPreDectosXCodigo(strCondicionVta, "", oRowM!Material)
                dtTemp = oProcesoSAPManager.ZBAPI_Extraer_PreciosCondiciones(strCondicionVta, "", Nocturna, oRowM!Material)
                If dtCondicionesVta Is Nothing Then
                    dtCondicionesVta = dtTemp.Copy
                Else
                    For Each oRowT As DataRow In dtTemp.Rows
                        dtCondicionesVta.ImportRow(oRowT)
                    Next
                    dtCondicionesVta.AcceptChanges()
                End If
            Next
        End If
        'Dim strRuta As String = "C:\CondicionesVta" & strCondicionVta & " " & strLstPrecio & ".csv"
        'Dim txtWriter As System.IO.StreamWriter = New System.IO.StreamWriter(strRuta, False)
        Me.lblProgreso.Text = "Cargando la información. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If dtCondicionesVta.Rows.Count > 0 Then

            'Me.pbProceso.Value = 0

            'Me.pbProceso.Maximum = dtCondicionesVta.Rows.Count

            Dim strFile As String = ""
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.08.2014: Se modifico la forma de hacer la carga de informacíon para agilizarla, ahora se hace de manera masiva
            '---------------------------------------------------------------------------------------------------------------------------------
            'If strCondicionVta = "J3AP" Then
            Select Case strCondicionVta
                Case "ZPRL"
                    'si la condicion es J3AP y Z1 se actualiza el precio 
                    'de(venta) en la tabla Catalogo de articulos campo PrecioVenta

                    If bPorCodigo = False Then
                        strFile = "ZPRL"
                        GenerarArchivoDataLoad(strFile, dtCondicionesVta)
                        oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 4)
                    Else
                        oProcesoSAPManager.UpdateCostoPromedio(dtCondicionesVta, 4)
                    End If

                    'oProcesoSAPManager.Write_ArticulosPrecioVenta(dtCondicionesVta, Me, 4)


                    'oProcesoSAPManager.Write_ArticulosPrecioSocio(oRow!Material, oRow!Importe)
                Case "PR01"
                    'para 053 y demas
                    'si la condicion es J3AP y Z0 se actualiza el precio 
                    'de(venta) en la tabla Catalogo de articulos campo PrecioconIVA
                    'oProcesoSAPManager.Write_ArticulosPrecioIVA(dtCondicionesVta, Me)


                    If bPorCodigo = False Then
                        strFile = "PR01"
                        GenerarArchivoDataLoad(strFile, dtCondicionesVta)
                        oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 2)
                    Else
                        oProcesoSAPManager.UpdateCostoPromedio(dtCondicionesVta, 2)
                    End If


                    'oProcesoSAPManager.Write_ArticulosPrecioVenta(dtCondicionesVta, Me, 2)
                Case "C1"
                    'Precio Venta 10% de descuento para 053

                    strFile = "PVC1"
                    GenerarArchivoDataLoad(strFile, dtCondicionesVta)
                    oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 1)

                    'oProcesoSAPManager.Write_ArticulosPrecioVenta(dtCondicionesVta, Me, 1)
                Case "C2"
                    'Precio Socio 25% de Descuento para 053

                    strFile = "PVC2"
                    GenerarArchivoDataLoad(strFile, dtCondicionesVta)
                    oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 3)

                    'oProcesoSAPManager.Write_ArticulosPrecioVenta(dtCondicionesVta, Me, 3)
                Case "ZDP1"
                    'Descuentos
                    If bPorCodigo = False Then
                        strFile = "DESC"
                        GenerarArchivoDataLoad(strFile, dtCondicionesVta)
                        oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 6)
                    Else
                        oProcesoSAPManager.UpdateCondicionesVenta(dtCondicionesVta)
                    End If

            End Select
            'Else
            'Si es otra condicion se mandan los datos a la
            'tabla de Condiciones de Venta

            'oProcesoSAPManager.Write_CondicionesPreDectos(dtCondicionesVta, strCondicionVta, Me)
            'End If

        End If

    End Sub

    Private Sub GenerarArchivoDataLoad(ByRef strFile As String, ByVal dtDescarga As DataTable)
        Dim strRuta As String = "C:\DPPRO\"
        Dim oWriter As StreamWriter
        Dim oRow As DataRow, strLinea As String = "", oItem As Object
        Dim strOrigen As String = strFile

        If Not Directory.Exists(strRuta) Then Directory.CreateDirectory(strRuta)

        strFile = strRuta & strFile & ".txt"
        oWriter = New StreamWriter(strFile)

        Select Case strOrigen.Trim.ToUpper
            Case "PR01"
                For Each oRow In dtDescarga.Rows
                    strLinea = oRow!Material & ";" & oRow!Importe & "".PadLeft(18, ";") &
                    ";;;" ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
            Case "ZPRL", "PVC1", "PVC2"
                For Each oRow In dtDescarga.Rows
                    strLinea = oRow!Material & "".PadLeft(9, ";") & oRow!Importe & "".PadLeft(10, ";") &
                    ";;;" ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
            Case "DESC" 'Descuento por sistema
                Dim DescPorc As Decimal = 0, DescMonto As Decimal = 0, strCondVta = ""
                For Each oRow In dtDescarga.Rows
                    strCondVta = oRow!CondVta
                    If strCondVta = "Z501" Then
                        DescPorc = 0
                        DescMonto = Math.Round(Math.Abs(oRow!Importe), 2)
                    Else
                        If strCondVta = "ZDP1" OrElse strCondVta = "Z522" Then
                            DescPorc = Math.Round(Math.Abs(CDec(oRow!Importe) / 10), 2)
                            DescMonto = 0
                        End If
                    End If
                    'strLinea = oRow!Material & "|" & strCondVta & "|CDPT|T1|" & oRow!Jerarquia & "|" & oRow!GpoMater & "|" & oRow!GpoPrecios & _
                    '            "|" & oRow!OficinaVentas & "|" & oRow!ListaPrecios & "|" & oRow!FechaIni & "|" & oRow!FechaFin & "|" & DescPorc & _
                    '            "|" & DescMonto
                    strLinea = oRow!Material & ";" & DescPorc & ";" & strCondVta & ";CDPT;T1;" & oRow!GpoMater & ";" & oRow!GpoPrecios & ";;" & _
                               oRow!ListaPrecios & ";" & DescMonto & ";;;" & oRow!Jerarquia & ";;" & oRow!OficinaVentas & ";;" & Format(oRow!FechaIni, "yyyy-MM-dd") & ";" & _
                               Format(oRow!FechaFin, "yyyy-MM-dd") & ";;" &
                    ";;;" ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
            Case "CA" 'Catalogo Articulos
                Dim strCodCat As String = "", Dip As Integer = 0, gpomcia As String = ""
                For Each oRow In dtDescarga.Rows

                    If Mid(CStr(oRow!PRDHA), 13, 6) = "" Then
                        strCodCat = "0"
                    Else
                        strCodCat = Mid(CStr(oRow!PRDHA), 13, 6)
                    End If

                    If CStr(oRow!FORMT).Trim <> "" Then
                        If IsNumeric(CStr(oRow!FORMT).Trim) AndAlso CInt(CStr(oRow!FORMT).Trim) = 1 Then
                            Dip = 1
                        End If
                    Else
                        Dip = 0
                    End If
                    If CStr(oRow!WGLIF).Trim() <> "" Then
                        If IsNumeric(oRow!WGLIF) Then
                            If CInt(oRow!WGLIF) > 0 Then
                                gpomcia = "-" & CStr(oRow!WGLIF)
                            Else
                                gpomcia = ""
                            End If
                        Else
                            gpomcia = "-" & CStr(oRow!WGLIF)
                        End If
                    Else
                        gpomcia = ""
                    End If
                    '---------------------------------------------------------------------------------------------
                    ' MLVARGAS (16/03/2021): QUITAR COMAS Y COMILLAS DEL NOMBRE DEL PRODUCTO
                    '---------------------------------------------------------------------------------------------
                    Dim productName As String = CStr(oRow!MAKTX).Trim
                    Dim product1 As String = productName.Trim.Replace(",", " ")
                    Dim product2 As String = product1.Trim.Replace("'", "")

                    strLinea = CStr(oRow!MATNR).Trim & ";;" & CStr(oRow!IDNLF).Trim & gpomcia & ";" & product2.Trim.Replace(";", "") & ";" & Mid(CStr(oRow!PRDHA), 5, 4) & ";" & oRow!J_3APGNR & _
                               ";" & strCodCat & ";" & Mid(CStr(oRow!PRDHA), 1, 4) & ";" & Mid(CStr(oRow!PRDHA), 9, 4) & ";" & oRow!STPRS & _
                               ";" & oRow!MEINS & ";" & oRow!MEINS & ";" & oRow!PRDHA & ";" & Dip & ";" & oRow!IDNLF & gpomcia & ";;;;" & oRow!NORMT & ";" & oRow!MATKL &
                               ";;;" ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
                
                
            Case "INV" 'Existencias
                Dim strNumero As String = ""
                For Each oRow In dtDescarga.Rows
                    If IsNumeric(oRow!J_3ASIZE) Then
                        If InStr(CStr(oRow!J_3ASIZE), ".5") = 0 Then
                            strNumero = Format(CDec(oRow!J_3ASIZE), "###0")
                        Else
                            strNumero = oRow!J_3ASIZE
                        End If
                    Else
                        strNumero = oRow!J_3ASIZE
                    End If
                    Dim G_merc As String = ""
                    Dim ArrayID() As String
                    ArrayID = Split(oRow!ID_MATR, "-")
                    Dim valStr As String
                    valStr = oRow!ID_MATR
                    If valStr.Length > 0 Then
                        valStr = Microsoft.VisualBasic.Right(oRow!ID_MATR, 1)
                    End If
                    If valStr <> "-" Then
                        If ArrayID.Length >= 3 Then
                            G_merc = ArrayID(ArrayID.Length - 1)
                        End If
                    End If
                    'strLinea = oRow!MATNR & ";" & CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS) & ";" & oApplicationContext.ApplicationConfiguration.Almacen & ";" & _  ' SF EAHM comentado, se quita el apartado
                    strLinea = oRow!MATNR & ";" & CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS) & ";" & oApplicationContext.ApplicationConfiguration.Almacen & ";" & _
                              oApplicationContext.Security.CurrentUser.SessionLoginName & ";" & Mid(CStr(oRow!PRDHA), 5, 4) & _
                              ";" & CStr(oRow!KLABS).Trim & ";" & Mid(CStr(oRow!PRDHA), 13, 6) & ";" & Mid(CStr(oRow!PRDHA), 1, 4) & ";;" & oRow!STPRS & _
                              ";;;" & CDec(oRow!APARTADO) & ";;" & strNumero & ";" & CDec(oRow!DEFECTUOSO) & ";;;;" & oRow!MATKL & ";" &
                                oRow!ID_MATR & ";" & oRow!COLORES & ";" & G_merc  ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
            Case "UPC" 'UPCs
                Dim strNumero As String = ""
                For Each oRow In dtDescarga.Rows
                    If IsNumeric(oRow!Talla) Then
                        If InStr(CStr(oRow!Talla), ".5") = 0 Then
                            strNumero = Format(CDec(oRow!Talla), "###0")
                        Else
                            strNumero = oRow!Talla
                        End If
                    Else
                        strNumero = oRow!Talla
                    End If
                    strLinea = oRow!Matnr & ";;" & oRow!Matnr & ";" & CStr(oRow!MAKTX).Trim.Replace(";", "") & ";;;;;" & _
                               strNumero & ";;;;;;" & CStr(oRow!EAN11).PadLeft(18, "0") & ";;;;;" &
                               ";;;" ' SF EAHM 13/06/2016
                    oWriter.WriteLine(strLinea)
                Next
        End Select

        oWriter.Close()
        oWriter = Nothing

    End Sub


    'Private Sub GenerarArchivoDataLoad(ByRef strFile As String, ByVal dtDescarga As DataTable)
    '    Dim strRuta As String = "C:\DPPRO\"
    '    Dim oWriter As StreamWriter
    '    Dim oRow As DataRow, strLinea As String = "", oItem As Object
    '    Dim strOrigen As String = strFile

    '    If Not Directory.Exists(strRuta) Then Directory.CreateDirectory(strRuta)

    '    strFile = strRuta & strFile & ".txt"
    '    oWriter = New StreamWriter(strFile)

    '    Select Case strOrigen.Trim.ToUpper
    '        Case "PR01"
    '            For Each oRow In dtDescarga.Rows
    '                strLinea = oRow!Material & ";" & oRow!Importe & "".PadLeft(18, ";")
    '                oWriter.WriteLine(strLinea)
    '            Next
    '        Case "ZPRL", "PVC1", "PVC2"
    '            For Each oRow In dtDescarga.Rows
    '                strLinea = oRow!Material & "".PadLeft(9, ";") & oRow!Importe & "".PadLeft(10, ";")
    '                oWriter.WriteLine(strLinea)
    '            Next
    '        Case "DESC" 'Descuento por sistema
    '            Dim DescPorc As Decimal = 0, DescMonto As Decimal = 0, strCondVta = ""
    '            For Each oRow In dtDescarga.Rows
    '                strCondVta = oRow!CondVta
    '                If strCondVta = "Z501" Then
    '                    DescPorc = 0
    '                    DescMonto = Math.Round(Math.Abs(oRow!Importe), 2)
    '                Else
    '                    If strCondVta = "ZDP1" OrElse strCondVta = "Z522" Then
    '                        DescPorc = Math.Round(Math.Abs(CDec(oRow!Importe) / 10), 2)
    '                        DescMonto = 0
    '                    End If
    '                End If
    '                'strLinea = oRow!Material & "|" & strCondVta & "|CDPT|T1|" & oRow!Jerarquia & "|" & oRow!GpoMater & "|" & oRow!GpoPrecios & _
    '                '            "|" & oRow!OficinaVentas & "|" & oRow!ListaPrecios & "|" & oRow!FechaIni & "|" & oRow!FechaFin & "|" & DescPorc & _
    '                '            "|" & DescMonto
    '                strLinea = oRow!Material & ";" & DescPorc & ";" & strCondVta & ";CDPT;T1;" & oRow!GpoMater & ";" & oRow!GpoPrecios & ";;" & _
    '                           oRow!ListaPrecios & ";" & DescMonto & ";;;" & oRow!Jerarquia & ";;" & oRow!OficinaVentas & ";;" & Format(oRow!FechaIni, "yyyy-MM-dd") & ";" & _
    '                           Format(oRow!FechaFin, "yyyy-MM-dd") & ";;"
    '                oWriter.WriteLine(strLinea)
    '            Next
    '        Case "CA" 'Catalogo Articulos
    '            Dim strCodCat As String = "", Dip As Integer = 0
    '            For Each oRow In dtDescarga.Rows

    '                If Mid(CStr(oRow!PRDHA), 13, 6) = "" Then
    '                    strCodCat = "0"
    '                Else
    '                    strCodCat = Mid(CStr(oRow!PRDHA), 13, 6)
    '                End If

    '                If CStr(oRow!FORMT).Trim <> "" Then
    '                    If IsNumeric(CStr(oRow!FORMT).Trim) AndAlso CInt(CStr(oRow!FORMT).Trim) = 1 Then
    '                        Dip = 1
    '                    End If
    '                Else
    '                    Dip = 0
    '                End If

    '                strLinea = CStr(oRow!MATNR).Trim & ";;" & CStr(oRow!IDNLF).Trim & ";" & CStr(oRow!MAKTX).Trim.Replace(";", "") & ";" & Mid(CStr(oRow!PRDHA), 5, 4) & ";" & oRow!J_3APGNR & _
    '                           ";" & strCodCat & ";" & Mid(CStr(oRow!PRDHA), 1, 4) & ";" & Mid(CStr(oRow!PRDHA), 9, 4) & ";" & oRow!STPRS & _
    '                           ";" & oRow!MEINS & ";" & oRow!MEINS & ";" & oRow!PRDHA & ";" & Dip & ";" & oRow!IDNLF & ";;;;" & oRow!NORMT & ";" & oRow!MATKL

    '                oWriter.WriteLine(strLinea)
    '            Next
    '        Case "INV" 'Existencias
    '            Dim strNumero As String = ""
    '            For Each oRow In dtDescarga.Rows
    '                If IsNumeric(oRow!J_3ASIZE) Then
    '                    If InStr(CStr(oRow!J_3ASIZE), ".5") = 0 Then
    '                        strNumero = Format(CDec(oRow!J_3ASIZE), "###0")
    '                    Else
    '                        strNumero = oRow!J_3ASIZE
    '                    End If
    '                Else
    '                    strNumero = oRow!J_3ASIZE
    '                End If
    '                strLinea = oRow!MATNR & ";" & CDec(oRow!LABST) + CDec(oRow!DEFECTUOSO) + CDec(oRow!APARTADO) + CDec(oRow!KLABS) & ";" & oApplicationContext.ApplicationConfiguration.Almacen & ";" & _
    '                          oApplicationContext.Security.CurrentUser.SessionLoginName & ";" & Mid(CStr(oRow!PRDHA), 5, 4) & _
    '                          ";" & CStr(oRow!KLABS).Trim & ";" & Mid(CStr(oRow!PRDHA), 13, 6) & ";" & Mid(CStr(oRow!PRDHA), 1, 4) & ";;" & oRow!STPRS & _
    '                          ";;;" & CDec(oRow!APARTADO) & ";;" & strNumero & ";" & CDec(oRow!DEFECTUOSO) & ";;;;" & oRow!MATKL
    '                oWriter.WriteLine(strLinea)
    '            Next
    '        Case "UPC" 'UPCs
    '            Dim strNumero As String = ""
    '            For Each oRow In dtDescarga.Rows
    '                If IsNumeric(oRow!Talla) Then
    '                    If InStr(CStr(oRow!Talla), ".5") = 0 Then
    '                        strNumero = Format(CDec(oRow!Talla), "###0")
    '                    Else
    '                        strNumero = oRow!Talla
    '                    End If
    '                Else
    '                    strNumero = oRow!Talla
    '                End If
    '                strLinea = oRow!Matnr & ";;" & oRow!Matnr & ";" & CStr(oRow!MAKTX).Trim.Replace(";", "") & ";;;;;" & _
    '                           strNumero & ";;;;;;" & CStr(oRow!EAN11).PadLeft(18, "0") & ";;;;;"
    '                oWriter.WriteLine(strLinea)
    '            Next
    '    End Select

    '    oWriter.Close()
    '    oWriter = Nothing

    'End Sub

    Private Sub ProcesarZPP_COBRANZAS()

        'Procesamos vendedores
        Dim dtZPP_CobranzasSAP As DataTable
        Me.lblProceso.Text = "CATALOGO ZPP_COBRANZAS"
        Me.lblProceso.Refresh()

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cobr", "NO", oSAPConfiguration.TdaNueva, "Cobranza", Nocturna, CierreDia)

        oProcesoSAPManager.DeleteCatalogo("ZPP_COBRANZAS")

        dtZPP_CobranzasSAP = oProcesoSAPManager.Read_ZPP_COBRANZAS

        If dtZPP_CobranzasSAP.Rows.Count > 0 Then

            Me.pbProceso.Value = 0

            Me.pbProceso.Maximum = dtZPP_CobranzasSAP.Rows.Count

            Dim oRow As DataRow : Dim intCount As Integer = 0

            For Each oRow In dtZPP_CobranzasSAP.Rows

                Me.pbProceso.Value += 1

                oProcesoSAPManager.Write_ZPP_COBRANZAS(oRow!Tienda, oRow!CLACOBR, oRow!Banco, oRow!HKONT, oRow!WERKS, oRow!GSBER)
                Me.pbProceso.Refresh()
            Next

        End If

        'Actualizamos el status de la cobranza en servidor de Operaciones
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cobr", "SI", oSAPConfiguration.TdaNueva, "Cobranza", Nocturna, CierreDia)

    End Sub

    'Private Sub ProcesarExistencias()
    '    'Procesamos articulo
    '    Dim dtExistenciasSAP As DataTable
    '    Dim dtTemp As DataTable

    '    Me.lblProceso.Text = "CATALOGO EXISTENCIAS"
    '    Me.lblProceso.Refresh()

    '    '------------------------------------------------------------------------------------------------------------------
    '    'Obtenemos la info de SAP
    '    '------------------------------------------------------------------------------------------------------------------
    '    If bPorCodigo = False Then
    '        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "NO", oSAPConfiguration.TdaNueva, "Inventario", Nocturna)
    '        'oProcesoSAPManager.DeleteCatalogo("Existencias")
    '        oProcesoSAPManager.DeleteTotalesExistencias()

    '        dtExistenciasSAP = oProcesoSAPManager.Read_Existencias
    '    Else
    '        For Each oRowM As DataRow In dtMateriales.Rows
    '            oProcesoSAPManager.DeleteTotalesExistencias(oRowM!Material)
    '            dtTemp = oProcesoSAPManager.Read_ExistenciasXCodigos(oRowM!Material)
    '            If dtExistenciasSAP Is Nothing Then
    '                dtExistenciasSAP = dtTemp.Copy
    '            Else
    '                For Each oRowT As DataRow In dtTemp.Rows
    '                    dtExistenciasSAP.ImportRow(oRowT)
    '                Next
    '                dtExistenciasSAP.AcceptChanges()
    '            End If
    '        Next
    '    End If
    '    '------------------------------------------------------------------------------------------------------------------
    '    'Actualizamos la tabla con la info recibida de SAP
    '    '------------------------------------------------------------------------------------------------------------------
    '    If dtExistenciasSAP.Rows.Count > 0 Then

    '        Me.pbProceso.Value = 0

    '        Me.pbProceso.Maximum = dtExistenciasSAP.Rows.Count

    '        Dim oRow As DataRow : Dim intCount As Integer = 0

    '        For Each oRow In dtExistenciasSAP.Rows

    '            Me.pbProceso.Value += 1

    '            oProcesoSAPManager.Write_Existencias(oRow)

    '            Me.pbProceso.Refresh()
    '        Next

    '    End If
    '    '------------------------------------------------------------------------------------------------------------------
    '    'Actualizamos los Saldos y los campos Entro y Salio
    '    '------------------------------------------------------------------------------------------------------------------
    '    dtExistenciasSAP.Rows.Clear()
    '    If bPorCodigo Then
    '        dtTemp.Rows.Clear()
    '        For Each oRowM As DataRow In dtMateriales.Rows
    '            dtTemp = oProcesoSAPManager.GetAllExistencias(oRowM!Material)
    '            If dtExistenciasSAP.Rows.Count <= 0 Then
    '                dtExistenciasSAP = dtTemp.Copy
    '            Else
    '                For Each oRowT As DataRow In dtTemp.Rows
    '                    dtExistenciasSAP.ImportRow(oRowT)
    '                Next
    '                dtExistenciasSAP.AcceptChanges()
    '            End If
    '        Next
    '    Else
    '        dtExistenciasSAP = oProcesoSAPManager.GetAllExistencias
    '    End If
    '    If dtExistenciasSAP.Rows.Count > 0 Then
    '        If bPorCodigo Then
    '            For Each oRow As DataRow In dtExistenciasSAP.Rows
    '                oProcesoSAPManager.ActualizaSaldosExistenciaPorCodigo(orow!CodArticulo, orow!Numero, CInt(Format(Today, "MM")))
    '            Next
    '        Else
    '            oProcesoSAPManager.ActualizaSaldosExistencia(CInt(Format(Today, "MM")))
    '        End If
    '    End If
    '    '------------------------------------------------------------------------------------------------------------------
    '    'Actualizamos el status de la existencia en servidor de Operaciones
    '    '------------------------------------------------------------------------------------------------------------------
    '    If bPorCodigo = False Then oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "SI", oSAPConfiguration.TdaNueva, "Inventario", Nocturna)

    'End Sub

    Private Sub ProcesarExistencias()
        'Procesamos articulo
        Dim dtExistenciasSAP As DataTable
        Dim dtTemp As DataTable

        Me.lblProceso.Text = "CATALOGO EXISTENCIAS"
        Me.lblProceso.Refresh()

        '------------------------------------------------------------------------------------------------------------------
        'Obtenemos la info de SAP
        '------------------------------------------------------------------------------------------------------------------
        Me.lblProgreso.Text = "Extrayendo la información de SAP. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If bPorCodigo = False Then
            If oSAPConfiguration.DercargaManual Then
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "NO", True, "Inventario", Nocturna, CierreDia)
            Else
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "NO", oSAPConfiguration.TdaNueva, "Inventario", Nocturna, CierreDia)
            End If

            'oProcesoSAPManager.DeleteCatalogo("Existencias")
            oProcesoSAPManager.DeleteTotalesExistencias()

            dtExistenciasSAP = oProcesoSAPManager.Read_Existencias
        Else
            For Each oRowM As DataRow In dtMateriales.Rows
                oProcesoSAPManager.DeleteTotalesExistencias(oRowM!Material)
                dtTemp = oProcesoSAPManager.Read_ExistenciasXCodigos(oRowM!Material)

                If Not dtTemp Is Nothing AndAlso dtTemp.Rows.Count > 0 Then
                    Dim oRow As DataRow = dtTemp.Rows(0)
                    oProcesoSAPManager.UpdateInsertExistencias(oRow)
                End If

                If dtExistenciasSAP Is Nothing Then
                    dtExistenciasSAP = dtTemp.Copy
                Else
                    For Each oRowT As DataRow In dtTemp.Rows
                        dtExistenciasSAP.ImportRow(oRowT)
                    Next
                    dtExistenciasSAP.AcceptChanges()
                End If
            Next
        End If
        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos la tabla con la info recibida de SAP
        '------------------------------------------------------------------------------------------------------------------
        Me.lblProgreso.Text = "Cargando la información. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If Not dtExistenciasSAP Is Nothing AndAlso dtExistenciasSAP.Rows.Count > 0 Then

            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.08.2014: Se modifico la forma de hacer la carga de informacíon para agilizarla, ahora se hace de manera masiva
            '---------------------------------------------------------------------------------------------------------------------------------
            Dim strFile As String = "INV"

            GenerarArchivoDataLoad(strFile, dtExistenciasSAP)
            oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 7)

        End If
        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos los Saldos y los campos Entro y Salio
        '------------------------------------------------------------------------------------------------------------------
        If Not dtExistenciasSAP Is Nothing Then
            dtExistenciasSAP.Rows.Clear()
        Else
            dtExistenciasSAP = dtTemp.Copy
            dtExistenciasSAP.Rows.Clear()
        End If

        If bPorCodigo Then
            dtTemp.Rows.Clear()
            For Each oRowM As DataRow In dtMateriales.Rows
                dtTemp = oProcesoSAPManager.GetAllExistencias(oRowM!Material)
                If dtExistenciasSAP.Rows.Count <= 0 Then
                    dtExistenciasSAP = dtTemp.Copy
                Else
                    For Each oRowT As DataRow In dtTemp.Rows
                        dtExistenciasSAP.ImportRow(oRowT)
                    Next
                    dtExistenciasSAP.AcceptChanges()
                End If
            Next
        Else
            dtExistenciasSAP = oProcesoSAPManager.GetAllExistencias
        End If
        If dtExistenciasSAP.Rows.Count > 0 Then
            If bPorCodigo Then
                For Each oRow As DataRow In dtExistenciasSAP.Rows
                    oProcesoSAPManager.ActualizaSaldosExistenciaPorCodigo(oRow!CodArticulo, oRow!Numero, CInt(Format(Today, "MM")))
                Next
            Else
                oProcesoSAPManager.ActualizaSaldosExistencia(CInt(Format(Today, "MM")))
            End If
        End If
        '------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status de la existencia en servidor de Operaciones
        '------------------------------------------------------------------------------------------------------------------
        If bPorCodigo = False Then
            If oSAPConfiguration.DercargaManual Then
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "SI", True, "Inventario", Nocturna, CierreDia)
            Else
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Inve", "SI", oSAPConfiguration.TdaNueva, "Inventario", Nocturna, CierreDia)

            End If
        End If
    End Sub

    Private Sub ProcesarDescuentosAdicionales(ByVal fecha As Date, Optional ByVal Opcion As Integer = -1)


        Dim dtDescuentosAdiSAP As DataTable
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (19.12.2014): Validamos que SI aplica el CrossSelling, no se revisan las promociones vigentes, excepto los descuentos fijos de
        '                    los clientes DIPs
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicaCrossSelling Then GoTo DescuentoDIPFijo

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "DesA", "NO", oSAPConfiguration.TdaNueva, "Descuentos Adicionales", Nocturna, CierreDia)
        '------------------------------------------------------------------------------------------------------------
        'Borramos los registros de la tabla de descuentos adicionales
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 Then oProcesoSAPManager.DeleteCatalogo("DescuentosAdicionales")
        '------------------------------------------------------------------------------------------------------------
        'Descuento Adicional General
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 6 Then
            Me.lblProceso.Text = "Descuentos Adicionales General"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(6)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_DescuentosAdicionalesGeneral(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_DescuentoAdicionalGeneral(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        'Descuento Adicional Por Codigo
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 7 Then
            Me.lblProceso.Text = "Descuentos Adicionales Por Articulo"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(7)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_DescuentosAdicionales(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_DescuentoAdicional(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        'Descuentos Adicionales por sucursal y marca
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 5 Then
            Me.lblProceso.Text = "Descuentos Adicionales Por Marca"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(5)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_DescuentosAdicionalesPorMarca(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_DescuentoAdicionalPorMarca(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        ' 20% y 30% General Por Sucursal (Todas las marcas por sucursal)
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 4 Then
            Me.lblProceso.Text = "Promocion 20% y 30%"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(4)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_Promocion20y30(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_Promocion20y30(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        '2 x 1 ½ General Por Sucursal (Todas las marcas por sucursal)
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 1 Then
            Me.lblProceso.Text = "Promocion 2 x 1 y Medio"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(1)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_PromocionDosPorUnoMedioYMedio(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_PromocionDosPorUnoYMedio(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        '2 x 1 ½ Por marca y sucursal
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 2 Then
            Me.lblProceso.Text = "Promocion 2 x 1 y Medio"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(2)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_PromocionDosPorUnoMedioYMedioPorMarca(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_PromocionDosPorUnoYMedioPorMarca(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        '2 x 1 ½ Por codigo y sucursal
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 3 Then
            Me.lblProceso.Text = "Promocion 2 x 1 y Medio"

            Me.lblProceso.Refresh()

            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(3)

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_PromocionDosPorUnoMedioYMedioPorCodigo(fecha)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_PromocionDosPorUnoYMedioPorCodigo(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
DescuentoDIPFijo:
        '------------------------------------------------------------------------------------------------------------
        ' Descuento Adicional Fijo por Cliente 
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 0 Then
            Me.lblProceso.Text = "Descuentos Fijos Clientes"

            Me.lblProceso.Refresh()

            oProcesoSAPManager.DeleteDescuentosAdicionalesFijos()

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_DescuentosFijosClientesDIPs

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow : Dim intCount As Integer = 0

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_DescuentosAdicionalesFijos(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 13.03.2015: Si aplica Cross Selling solo descargamos los descuentos fijos de los clientes DIPs
        '-----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicaCrossSelling Then Exit Sub
        '------------------------------------------------------------------------------------------------------------
        'DPaketes y Street Packs por sucursal
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 8 Then

            Dim dtDescuentosDet As DataTable

            Me.lblProceso.Text = "DPaketes y Street Packs"

            Me.lblProceso.Refresh()

            oProcesoSAPManager.DeleteCatalogo("DPaketes")
            oProcesoSAPManager.DeleteCatalogo("DPaketesDetalle")

            dtDescuentosAdiSAP = oProcesoSAPManager.Read_PromocionDpaketesStreetPacks(fecha, dtDescuentosDet)

            If dtDescuentosAdiSAP.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosAdiSAP.Rows.Count

                Dim oRow As DataRow

                For Each oRow In dtDescuentosAdiSAP.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_PromocionDpaketes(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If

            If dtDescuentosDet.Rows.Count > 0 Then

                Me.pbProceso.Value = 0

                Me.pbProceso.Maximum = dtDescuentosDet.Rows.Count

                Dim oRow As DataRow

                For Each oRow In dtDescuentosDet.Rows

                    Me.pbProceso.Value += 1

                    oProcesoSAPManager.Write_PromocionDpaketesDetalle(oRow)

                    Me.pbProceso.Refresh()

                Next

            End If
        End If
        '------------------------------------------------------------------------------------------------------------
        'Bonificacion Producto Mas Caro
        '------------------------------------------------------------------------------------------------------------
        If Opcion < 0 OrElse Opcion = 9 Then
            Dim dtDescuentosBon As DataTable

            Me.lblProceso.Text = "Descuentos de Bonificación"
            Me.lblProceso.Refresh()
            If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(9)
            dtDescuentosBon = oProcesoSAPManager.Read_promocionBonificacionDescuento(oConfigCierreFI)
            If dtDescuentosBon.Rows.Count > 0 Then
                Me.pbProceso.Value = 0
                Me.pbProceso.Maximum = dtDescuentosBon.Rows.Count
                For Each row As DataRow In dtDescuentosBon.Rows
                    Me.pbProceso.Value += 1
                    oProcesoSAPManager.Write_BonificacionDescuento(row)
                    Me.pbProceso.Refresh()
                Next
            End If

        End If

        '------------------------------------------------------------------------------------------------------------
        'JNAVA 07/11/2013 - Descuento de Proximá Compra - 10
        '------------------------------------------------------------------------------------------------------------
        'If Opcion < 0 OrElse Opcion = 10 Then
        '    Dim dsDescuentoPC As DataSet
        '    Me.lblProceso.Text = "Descuento de Proximá Compra"
        '    Me.lblProceso.Refresh()
        '    If Opcion >= 0 Then oProcesoSAPManager.DeleteDescuentosAdicionales(10)
        '    dsDescuentoPC = oProcesoSAPManager.Read_DescuentoProximaCompra(fecha)

        '    If dsDescuentoPC.Tables.Count = 3 Then
        '        Dim T_DESCUENTOS As DataTable = dsDescuentoPC.Tables("T_DESCUENTOS")
        '        Dim T_TIPOSVTA As DataTable = dsDescuentoPC.Tables("T_TIPOSVTA")
        '        Dim T_FPAGO As DataTable = dsDescuentoPC.Tables("T_FPAGO")

        '        'Creamos Tabla para cargar los datos en SQL
        '        Dim dtDPC As New DataTable("T_DPC")
        '        dtDPC.Columns.Add("FECHASAPI", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("FECHASAPF", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("DESCUENTO", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("P", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("V", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("I", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("O", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("F", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("K", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("S", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("D", Type.GetType("System.String"))
        '        dtDPC.Columns.Add("FPAGOS", Type.GetType("System.String"))
        '        dtDPC.AcceptChanges()

        '        'Preparamos datos antes de cargarlos a BD
        '        For Each drDescuentos As DataRow In T_DESCUENTOS.Rows
        '            Dim oRowDPC As DataRow = dtDPC.NewRow
        '            oRowDPC("FECHASAPI") = drDescuentos!FECHASAPI
        '            oRowDPC("FECHASAPF") = drDescuentos!FECHASAPF
        '            oRowDPC("DESCUENTO") = Decimal.Zero
        '            For Each drTiposVta As DataRow In T_TIPOSVTA.Rows
        '                If drTiposVta!TIPO_VENTA = "P" Then oRowDPC("P") = "X" Else oRowDPC("P") = ""
        '                If drTiposVta!TIPO_VENTA = "V" Then oRowDPC("V") = "X" Else oRowDPC("V") = ""
        '                If drTiposVta!TIPO_VENTA = "I" Then oRowDPC("I") = "X" Else oRowDPC("I") = ""
        '                If drTiposVta!TIPO_VENTA = "O" Then oRowDPC("O") = "X" Else oRowDPC("O") = ""
        '                If drTiposVta!TIPO_VENTA = "F" Then oRowDPC("F") = "X" Else oRowDPC("F") = ""
        '                If drTiposVta!TIPO_VENTA = "K" Then oRowDPC("K") = "X" Else oRowDPC("K") = ""
        '                If drTiposVta!TIPO_VENTA = "S" Then oRowDPC("S") = "X" Else oRowDPC("S") = ""
        '                If drTiposVta!TIPO_VENTA = "D" Then oRowDPC("D") = "X" Else oRowDPC("D") = ""
        '            Next
        '            Dim strFPAGO As String = ""
        '            For Each drFP As DataRow In T_FPAGO.Rows
        '                strFPAGO += drFP!FORMA_PAGO & ","
        '            Next
        '            strFPAGO = strFPAGO.Remove(strFPAGO.Length - 1, 1)
        '            oRowDPC("FPAGOS") = strFPAGO
        '            dtDPC.Rows.Add(oRowDPC)
        '            dtDPC.AcceptChanges()
        '        Next

        '        'Cargamos Promocion a BD
        '        If dtDPC.Rows.Count > 0 Then
        '            Me.pbProceso.Value = 0
        '            Me.pbProceso.Maximum = dtDPC.Rows.Count
        '            Dim oRow As DataRow : Dim intCount As Integer = 0
        '            For Each oRow In dtDPC.Rows
        '                Me.pbProceso.Value += 1
        '                oProcesoSAPManager.Write_DescuentoProximaCompra(oRow)
        '                Me.pbProceso.Refresh()
        '            Next
        '        End If
        '    End If
        'End If

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "DesA", "SI", oSAPConfiguration.TdaNueva, "Descuentos Adicionales", Nocturna, CierreDia)

    End Sub

    Private Sub ProcesarPromociones()

        Dim dtTemp As New DataTable
        Dim oPromo As Promocion
        Dim oAfil As Afiliacion
        Dim oPromoBin As PromoBin
        Dim oEmisor As Emisor

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Bin", "NO", oSAPConfiguration.TdaNueva, "Bines", Nocturna, CierreDia)

        'Llenamos catalogo afiliaciones

        Me.lblProceso.Text = "CATALOGO AFILIACIONES"

        Me.lblProceso.Refresh()

        oCatPromoMgr.DeleteAllAfiliaciones()

        dtTemp = oCatPromoMgr.GetAllAfiliaciones

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oAfil = oCatPromoMgr.CreateAfiliacion
            oAfil.IDEmisor = oRow!Id_Num_Emisor
            oAfil.IDPromo = oRow!Ids_Num_Promo
            oAfil.NoAfiliacion = oRow!Num_Afiliacion
            oCatPromoMgr.SaveAfiliacion(oAfil)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        'Llenamos catalogo emisores

        Me.lblProceso.Text = "CATALOGO EMISORES"

        Me.lblProceso.Refresh()

        oCatPromoMgr.DeleteAllEmisores()

        dtTemp = oCatPromoMgr.GetAllEmisores

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oEmisor = oCatPromoMgr.CreateEmisor
            oEmisor.ID = oRow!Id_Num_Emisor
            oEmisor.Descripcion = oRow!Nom_Emisor
            oEmisor.Abrevacion = oRow!Abrev_Emisor
            oCatPromoMgr.SaveEmisor(oEmisor)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        'Llenamos catalogo de bines promociones

        Me.lblProceso.Text = "CATALOGO BINES"

        Me.lblProceso.Refresh()

        oCatPromoMgr.DeleteAllPromoBin()

        dtTemp = oCatPromoMgr.GetAllPromoBin

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oPromoBin = oCatPromoMgr.CreatePromoBin
            oPromoBin.Bin = oRow!Id_Num_Bin
            oPromoBin.IDPromo = oRow!Ids_Num_Promo
            oPromoBin.ImporteMinimo = oRow!Imp_MinProm
            oPromoBin.ImporteMaximo = orow!Imp_MaxProm
            oCatPromoMgr.SavePromoBin(oPromoBin)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        'Llenamos catalogo promociones

        Me.lblProceso.Text = "CATALOGO PROMOCIONES"

        Me.lblProceso.Refresh()

        oCatPromoMgr.DeleteAllPromociones()

        dtTemp = oCatPromoMgr.GetAllPromociones

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oPromo = oCatPromoMgr.CreatePromocion
            oPromo.ID = oRow!Ids_Num_Promo
            oPromo.Promocion = oRow!Id_Num_Promo
            oPromo.Descripcion = oRow!Desc_Promo
            oPromo.AbrevPromo = orow!Abrev_Promo
            oCatPromoMgr.SavePromocion(oPromo)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Bin", "SI", oSAPConfiguration.TdaNueva, "Bines", Nocturna, CierreDia)

    End Sub

    'Private Sub ProcesarAlmacenesDesdeSAP()

    '    Dim dtTemp As New DataTable
    '    Dim oAlmacen As Almacen
    '    Dim oRow As DataRow

    '    oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Almc", "NO", oSAPConfiguration.TdaNueva, "Catalogo Almacenes", Nocturna)

    '    'oProcesoSAPManager.DeleteCatalogo("CatalogoAlmacenes")

    '    ''Llenamos catalogo almacenes

    '    'Me.lblProceso.Text = "CATALOGO ALMACENES"

    '    'Me.lblProceso.Refresh()

    '    'dtTemp = oAlmacenMgr.GetAllFromServer.Tables(0)

    '    'Me.pbProceso.Value = 0
    '    'Me.pbProceso.Maximum = dtTemp.Rows.Count

    '    'For Each oRow In dtTemp.Rows

    '    '    oAlmacen = oAlmacenMgr.Create

    '    '    With oAlmacen
    '    '        .ID = oRow!CodAlmacen
    '    '        .Descripcion = oRow!Descripcion
    '    '        .DireccionCalle = oRow!Calle
    '    '        .DireccionNumExt = oRow!NumExterior
    '    '        .DireccionCP = oRow!CP
    '    '        .DireccionCiudad = oRow!Ciudad
    '    '        .DireccionEstado = oRow!Estado
    '    '        .TelefonoNum = oRow!Telefono
    '    '        .MostrarEnSeparaciones = oRow!MostrarSeparaciones
    '    '        .PlazaID = oRow!CodPlaza
    '    '        .OficinaVta = oRow!OficinaVta
    '    '        oAlmacenMgr.Save(oAlmacen)
    '    '    End With
    '    '    Me.pbProceso.Value += 1
    '    '    Me.pbProceso.Refresh()

    '    'Next

    '    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    '    'Llenamos catalogo centros
    '    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    '    oProcesoSAPManager.DeleteCatalogoCentros()

    '    Me.lblProceso.Text = "CATALOGO CENTROS"

    '    Me.lblProceso.Refresh()

    '    dtTemp = oProcesoSAPManager.Read_CentrosSAP

    '    Me.pbProceso.Value = 0
    '    Me.pbProceso.Maximum = dtTemp.Rows.Count

    '    For Each oRow In dtTemp.Rows

    '        oAlmacenMgr.SaveCentro(oRow!WERKS, CStr(oRow!VSTEL).Substring(1, 3), oRow!VTEXT)

    '        Me.pbProceso.Value += 1
    '        Me.pbProceso.Refresh()

    '    Next
    '    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    '    'Llenamos catalogo almacenes
    '    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    '    oProcesoSAPManager.DeleteCatalogo("CatalogoAlmacenes")

    '    Me.lblProceso.Text = "CATALOGO ALMACENES"

    '    Me.lblProceso.Refresh()

    '    'dtTemp = oAlmacenMgr.GetAllFromServer.Tables(0)

    '    Me.pbProceso.Value = 0
    '    Me.pbProceso.Maximum = dtTemp.Rows.Count
    '    Dim oClienteSAP As ClientesSAP
    '    Dim NumExt() As String
    '    Dim strNumExt As String = ""

    '    For Each oRow In dtTemp.Rows

    '        oClienteSAP = GetCliente(CStr(oRow!VSTEL).Trim.Substring(1, 3))
    '        If Not oClienteSAP Is Nothing Then
    '            oAlmacen = oAlmacenMgr.Create

    '            With oAlmacen
    '                .ID = CStr(oRow!VSTEL).Trim.Substring(1, 3)
    '                .Descripcion = CStr(oClienteSAP.Apellidos & oClienteSAP.Nombre).Replace("_", " ").Trim
    '                .DireccionCalle = oClienteSAP.Domicilio.Trim
    '                NumExt = oClienteSAP.Domicilio.Trim.Split("#")
    '                If NumExt.Length > 1 Then
    '                    NumExt = NumExt(1).Trim.Split(" ")
    '                    If NumExt.Length > 0 Then
    '                        strNumExt = NumExt(0).Trim
    '                    End If
    '                End If
    '                .DireccionNumExt = strNumExt
    '                .DireccionCP = oClienteSAP.Cp.Trim
    '                .DireccionCiudad = oClienteSAP.Ciudad.Trim
    '                .DireccionEstado = oClienteSAP.Estado.Trim
    '                .TelefonoNum = oClienteSAP.Telefono.Trim
    '                .MostrarEnSeparaciones = 1
    '                .PlazaID = "" 'SOLO ME FALTA ESTE DATO
    '                .OficinaVta = oRow!VSTEL
    '                oAlmacenMgr.Save(oAlmacen)
    '            End With
    '        End If
    '        strNumExt = ""

    '        Me.pbProceso.Value += 1
    '        Me.pbProceso.Refresh()

    '    Next

    '    'oProcesoSAPManager.DeleteCatalogo("CatalogoCentros")

    '    ''Llenamos catalogo centros

    '    'Me.lblProceso.Text = "CATALOGO CENTROS"

    '    'Me.lblProceso.Refresh()

    '    'dtTemp = oAlmacenMgr.GetAllCentrosFromServer.Tables(0)

    '    'Me.pbProceso.Value = 0
    '    'Me.pbProceso.Maximum = dtTemp.Rows.Count

    '    'For Each oRow In dtTemp.Rows

    '    '    oAlmacenMgr.SaveCentro(oRow!CentroSAP, oRow!OficinaVtas, oRow!Descripcion)

    '    '    Me.pbProceso.Value += 1
    '    '    Me.pbProceso.Refresh()

    '    'Next

    '    oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Almc", "SI", oSAPConfiguration.TdaNueva, "Catalogo Almacenes", Nocturna)

    'End Sub

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


    Public Function GetCliente(ByVal strCodCliente As String, ByVal TipoCliente As String) As ClientesSAP

        Dim dtClientesSap As DataTable
        Dim oClienteSAP As ClientesSAP

        dtClientesSap = oProcesoSAPManager.ZBAPI_GET_CLIENTE(strCodCliente, TipoCliente)

        If dtClientesSap.Rows.Count > 0 Then

            oClienteSAP = New ClientesSAP

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
                    .Apellidos = strApellidos
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
                End With
            Next

        End If

        Return oClienteSAP

    End Function

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

    Private Sub ProcesarCodigosPostales()

        Dim dtTemp As New DataTable
        Dim bResult As Boolean = False

        'oProcesoSAPManager.DeleteCatalogo("CatalogoRazones")

        'Llenamos catalogo codigos postales

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cps", "NO", oSAPConfiguration.TdaNueva, "Catalogo CPs", Nocturna, CierreDia)

        Me.lblProceso.Text = "CATALOGO CODIGOS POSTALES"

        Me.lblProceso.Refresh()

        dtTemp = oAlmacenMgr.GetCodigosPostales()

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        Application.DoEvents()
        For Each oRow As DataRow In dtTemp.Rows

            oProcesoSAPManager.Write_CodigosPostales(oRow)
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next
        Application.DoEvents()

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cps", "SI", oSAPConfiguration.TdaNueva, "Catalogo CPs", Nocturna, CierreDia)

    End Sub

    Private Sub ProcesarMarcas()

        Dim dtTemp As New DataTable
        Dim oMarca As Marca

        'Llenamos catalogo marcas

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Marc", "NO", oSAPConfiguration.TdaNueva, "Catalogo Marcas", Nocturna, CierreDia)

        Me.lblProceso.Text = "CATALOGO MARCAS"

        Me.lblProceso.Refresh()

        dtTemp = oProcesoSAPManager.Read_Marcas

        Me.pbProceso.Value = 0
        Me.pbProceso.Maximum = dtTemp.Rows.Count

        For Each oRow As DataRow In dtTemp.Rows

            oMarca = oMarcasMgr.Create

            With oMarca
                .CodMarca = oRow!Marca
                .Descripcion = oRow!Descrip
                .CodOrigen = IIf(CStr(oRow!Nacional).Trim = "X", "N", "I")
                oMarcasMgr.Save(oMarca)
            End With
            Me.pbProceso.Value += 1
            Me.pbProceso.Refresh()

        Next

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Marc", "SI", oSAPConfiguration.TdaNueva, "Catalogo Marcas", Nocturna, CierreDia)

    End Sub

    Private Sub ProcesarCatalogos()

        Dim dtTemp As New DataTable, dtCatalogos As DataTable
        Dim oFamilia As Familias, dvValores As DataView, oFamMgr As CatalogoFamiliasManager

        'Llenamos catalogo marcas

        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Marc", "NO", oSAPConfiguration.TdaNueva, "Catalogo Marcas", Nocturna, CierreDia)

        Me.lblProceso.Text = "CATALOGO FAMILIAS"

        Me.lblProceso.Refresh()

        dtCatalogos = oProcesoSAPManager.ZMF_JERARQUIASYATRIBUTOS("TODAS", dtTemp)

        dvValores = New DataView(dtTemp, "ATNAM = 'FAMILIA'", "", DataViewRowState.CurrentRows)

        If dvValores.Count > 0 Then
            Me.pbProceso.Value = 0
            Me.pbProceso.Maximum = dvValores.Count

            oFamMgr = New CatalogoFamiliasManager(oApplicationContext)

            For Each oRow As DataRowView In dvValores

                oFamilia = oFamMgr.Create

                With oFamilia
                    .ID = oRow!Valor
                    .Descripcion = oRow!Texto

                    oFamMgr.Save(oFamilia)
                End With
                Me.pbProceso.Value += 1
                Me.pbProceso.Refresh()

            Next
        End If

        Me.lblProceso.Text = "CATALOGO CATEGORIAS"

        Me.lblProceso.Refresh()

        dvValores = New DataView(dtTemp, "ATNAM = 'CATEGORIA'", "", DataViewRowState.CurrentRows)

        If dvValores.Count > 0 Then
            Me.pbProceso.Value = 0
            Me.pbProceso.Maximum = dvValores.Count

            Dim oCategMgr As New CatalogoCategoriasManager(oApplicationContext), oCategoria As Categoria

            For Each oRow As DataRowView In dvValores

                oCategoria = oCategMgr.Create

                With oCategoria
                    .SetID(oRow!Valor)
                    .Descripcion = oRow!Texto

                    oCategMgr.Save(oCategoria)
                End With
                Me.pbProceso.Value += 1
                Me.pbProceso.Refresh()

            Next
        End If

        Me.lblProceso.Text = "CATALOGO LINEAS"

        Me.lblProceso.Refresh()

        dvValores = New DataView(dtTemp, "ATNAM = 'LINEA'", "", DataViewRowState.CurrentRows)

        If dvValores.Count > 0 Then
            Me.pbProceso.Value = 0
            Me.pbProceso.Maximum = dvValores.Count

            Dim oLineaMgr As New CatalogoLineasManager(oApplicationContext), oLinea As Linea

            For Each oRow As DataRowView In dvValores

                oLinea = oLineaMgr.Create

                With oLinea
                    .ID = oRow!Valor
                    .Descripcion = oRow!Texto

                    oLineaMgr.Save(oLinea)
                End With
                Me.pbProceso.Value += 1
                Me.pbProceso.Refresh()

            Next
        End If
        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 04/03/2016: Se hace la descarga del Catalogo Corridas
        '--------------------------------------------------------------------------------------------------------------------------
        Me.lblProceso.Text = "CATALOGO CORRIDAS"

        Me.lblProceso.Refresh()
        dtTemp.CaseSensitive = True
        Dim dtDatos As New DataTable()
        oProcesoSAPManager.ZMF_JERARQUIASYATRIBUTOS("TALLAS", dtDatos)
        If dtDatos.Rows.Count > 0 Then
            Me.pbProceso.Value = 0
            Me.pbProceso.Maximum = dtDatos.Rows.Count
            Dim corrida As DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU.Corrida
            Dim name As String = ""
            Dim cont As Integer = 1
            Dim param As String = ""
            Dim paramAnt As String
            For Each fila As DataRow In dtDatos.Rows
                If name <> CStr(fila("ATNAM")) Then
                    cont = 1
                    name = CStr(fila("ATNAM"))
                    corrida = New DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU.Corrida(oApplicationContext)
                    corrida.CodCorrida = CStr(fila("ATNAM"))
                    corrida.Descripcion = CStr(fila("ATNAM"))
                    If IsNumeric(fila("VALOR")) Then
                        corrida.NumInicio = CDec(fila("VALOR"))
                    Else
                        corrida.NumInicio = 0
                    End If
                    corrida.Salto = 0.5
                    corrida.Tope = 0
                    param = "C" & CStr(cont).PadLeft(2, "0")
                    corrida.Tallas(param) = CStr(fila("VALOR"))
                Else
                    param = "C" & CStr(cont).PadLeft(2, "0")
                    corrida.Tallas(param) = CStr(fila("VALOR"))
                    paramAnt = "C" & CStr(cont - 1).PadLeft(2, "0")
                    If IsNumeric(corrida.Tallas(param)) And IsNumeric(corrida.Tallas(paramAnt)) Then
                        If (CDec(corrida.Tallas(param)) - CDec(corrida.Tallas(paramAnt))) > 0.5 Then
                            corrida.Salto = CDec(corrida.Tallas(param)) - CDec(corrida.Tallas(paramAnt))
                        Else
                            corrida.Salto = CDec(corrida.Tallas(param)) - CDec(corrida.Tallas(paramAnt))
                        End If
                        corrida.NumFin = CDec(fila("VALOR"))
                    Else
                        corrida.Salto = 1
                        corrida.NumInicio = 0
                        corrida.NumFin = 0
                    End If
                End If
                corrida.Save()
                cont += 1
                Me.pbProceso.Value += 1
                Me.pbProceso.Refresh()
            Next
        End If
        oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Marc", "SI", oSAPConfiguration.TdaNueva, "Catalogo Marcas", Nocturna, CierreDia)

    End Sub

    Private Sub ProcesarUPC()

        Dim dsUPCSEP As DataSet
        Dim dtTemp As DataTable

        Me.lblProceso.Text = "CATALOGO UPC"
        Me.lblProceso.Refresh()

        Me.lblProgreso.Text = "Extrayendo la información de Códigos UPC. Por favor espere ..."
        Me.lblProgreso.Refresh()
        If bPorCodigo = False Then
            If oSAPConfiguration.DercargaManual Then
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "NO", True, "Catalogo UPC", Nocturna, CierreDia)
            Else
                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "NO", oSAPConfiguration.TdaNueva, "Catalogo UPC", Nocturna, CierreDia)
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.08.2014: Modificamos la consulta de los codigos UPCs, segun el tipo, si es descarga nocturna descargamos los ultimos 6 meses
            'si es tienda nueva descargamos todo el catalogo y si es normal solo lo de ayer y hoy
            '----------------------------------------------------------------------------------------------------------------------------------------
            If Nocturna Then
                dsUPCSEP = oProcesoSAPManager.ZMM_CAMBIOSMATERIALES(Today.AddMonths(-6), Today, False)
                'dsUPCSEP = oSeparacionesMgr.SelectUPCNuevo(Today.AddMonths(-6).ToShortDateString, Today.ToShortDateString, False)
            ElseIf oSAPConfiguration.TdaNueva Then
                dsUPCSEP = oProcesoSAPManager.ZMM_CAMBIOSMATERIALES(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, True)
                'dsUPCSEP = oSeparacionesMgr.SelectUPCNuevo(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, True)
            Else
                dsUPCSEP = oProcesoSAPManager.ZMM_CAMBIOSMATERIALES(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, False)
                'dsUPCSEP = oSeparacionesMgr.SelectUPCNuevo(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, False)
            End If
        Else
            For Each oRowM As DataRow In dtMateriales.Rows
                'dtTemp = oProcesoSAPManager.ZRFC_CARGAARTICULO_XCODIGO(oRowM!Material)
                dtTemp = oProcesoSAPManager.ZMM_CAMBIOSMATERIALES(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, False, oRowM!Material).Tables(0).Copy()
                'dtTemp = oSeparacionesMgr.SelectUPCNuevo(Today.AddDays(-1).ToShortDateString, Today.ToShortDateString, False, oRowM!Material).Tables(0).Copy
                If dsUPCSEP Is Nothing Then
                    dsUPCSEP = New DataSet("CodigosUPC")
                    dsUPCSEP.Tables.Add(dtTemp)
                Else
                    For Each oRowT As DataRow In dtTemp.Rows
                        dsUPCSEP.Tables(0).ImportRow(oRowT)
                    Next
                    dsUPCSEP.AcceptChanges()
                End If
            Next
        End If
            '------------------------------------------------------------------------------------------------------------------
            'Actualizamos la tabla con la info recibida
            '------------------------------------------------------------------------------------------------------------------
            Me.lblProgreso.Text = "Cargando la información. Por favor espere ..."
            Me.lblProgreso.Refresh()
            If dsUPCSEP.Tables(0).Rows.Count > 0 Then

                'oProcesoSAPManager.DeleteCatalogo("CatalogoUPC")

                'Me.pbProceso.Value = 0

                'Me.pbProceso.Maximum = dsUPCSEP.Tables(0).Rows.Count

                'Dim oRow As DataRow : Dim intCount As Integer = 0

                'For Each oRow In dsUPCSEP.Tables(0).Rows

                '    Me.pbProceso.Value += 1
                '    oProcesoSAPManager.Write_UPC_From_Separaciones(oRow)

                '    'oProcesoSAPManager.Write_UPCDirecto()
                '    Me.pbProceso.Refresh()
                'Next
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18.08.2014: Se modifico la forma de hacer la carga de informacíon para agilizarla, ahora se hace de manera masiva
            '---------------------------------------------------------------------------------------------------------------------------------
            If bPorCodigo = False Then
                Dim strFile As String = "UPC"

                GenerarArchivoDataLoad(strFile, dsUPCSEP.Tables(0))
                oProcesoSAPManager.LoadDataFromSAPtoDB(strFile, 8)
            Else
                oProcesoSAPManager.InsertUpdCatalogoUPC(dsUPCSEP.Tables(0))
            End If


        End If

            'Actualizamos el status del catalogo Upc en servidor de Operaciones
            oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Cupc", "SI", oSAPConfiguration.TdaNueva, "Catalogo UPC", Nocturna, CierreDia)

    End Sub

    Public Sub ShowDev(ByVal Opcion As String)
        Timer1.Enabled = False
        Me.Timer2.Enabled = True
        strOpcion = Opcion
        Me.ShowDialog()
    End Sub

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New StreamWriter(System.Environment.CurrentDirectory.TrimEnd("\") & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer1.Enabled = False
        Timer2.Enabled = False
        Dim IsDownLoad As Hashtable = AlmacenIsDownloading(strOpcion.ToUpper())
        If CBool(IsDownLoad("IsDownloading")) Then
            MessageBox.Show("La caja " & CStr(IsDownLoad("Caja")) & " esta descargando este modulo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
            Exit Sub
        End If
        oProcesoSAPManager = New ProcesoSAPManager(oApplicationContext, oSAPConfiguration)
        Try
            Select Case UCase(strOpcion)

                Case UCase("Articulos")
                    '''***Procesar Catalogo Articulos
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarArticulos()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los articulos de SAP")
                        MsgBox("Error al realizar la descarga de Artículos", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Clientes")
                    '''***Procesar Catalogo Clientes
                    If oConfigCierreFI.UsarDescargaClientes Then
                        Console.WriteLine(Now.ToLongTimeString)
                        Try
                            ProcesarClientes()
                        Catch ex As Exception
                            bMostrarMensaje = False
                            EscribeLog(ex.ToString, "Error al descargar los clientes de SAP")
                            MsgBox("Error al realizar la descarga de Clientes", MsgBoxStyle.Exclamation, Me.Text)
                        End Try
                        Console.WriteLine(Now.ToLongTimeString)
                    End If
                Case UCase("Cobranza")
                    '''***Procesar Catalogo ZPP_COBRANZAS
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarZPP_COBRANZAS()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar la cobranza de SAP")
                        MsgBox("Error al realizar la descarga de Cobranza", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("CodigosUPC")
                    ''''***Procesar Catalogo UPC
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarUPC()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los codigos UPC de SQL")
                        MsgBox("Error al realizar la descarga de Códigos UPC", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Descuentos")
                    Try
                        If bPorCodigo = False Then
                            If oSAPConfiguration.DercargaManual Then
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", True, "Descuentos", Nocturna, CierreDia)
                            Else
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "NO", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)
                            End If
                        End If

                        '''***Limpiar la Tabla de Condiciones de Venta
                        oProcesoSAPManager.Delete_CondicionesPreDectos()
                        If oSAPConfiguration.TdaNueva = True Then
                            oProcesoSAPManager.DeleteCatalogo("CondicionesVenta")
                        End If
                        '''***Procesar Catalogo CondicionesVenta
                        If oApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                            GoTo Cambio_053
                            'ProcesarCondicionesVta("J3AP", "Z0") 'Precio Con IVA
                            'ProcesarCondicionesVta("J3AP", "C1") 'Precio Con 10% Descuento
                            'ProcesarCondicionesVta("J3AP", "C2") 'Precio Con 25% Descuento
                            'ProcesarCondicionesVta("Z521", "C1") 'Lista Precios C1
                            'ProcesarCondicionesVta("Z521", "C2") 'Lista Precios C2
                        Else
Cambio_053:
                            ProcesarCondicionesVta("ZPRL") ', "Z1") 'Precio Sin IVA
                            ProcesarCondicionesVta("PR01") ', "Z0") 'Precio Con IVA      
                            ProcesarCondicionesVta("ZDP1") ', "Z1") 'Lista Precios Z1
                        End If
                        '-------------------------------------------------------------------------------------------------------------------------
                        'Actualizamos el status del catalogo descuentos en servidor de Operaciones
                        '-------------------------------------------------------------------------------------------------------------------------
                        If bPorCodigo = False Then
                            If oSAPConfiguration.DercargaManual Then
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", True, "Descuentos", Nocturna, CierreDia)
                            Else
                                oServerUPCMgr.CargasInicialesUpdByCatalogo(oApplicationContext.ApplicationConfiguration.Almacen, "Desc", "SI", oSAPConfiguration.TdaNueva, "Descuentos", Nocturna, CierreDia)
                            End If
                        End If
                        'ProcesarCondicionesVta("Z501", String.Empty) 'Vacio por que no lo ocupa
                        'ProcesarCondicionesVta("Z522", String.Empty) 'Vacio por que no lo ocupa
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al realizar la descarga de precios y descuentos SAP")
                        MsgBox("Error al realizar la descarga de Precios y Descuentos", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                Case UCase("Inventarios")
                    ''''***Procesar Catalogo EXISTENCIAS
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarExistencias()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar el inventario de SAP")
                        MsgBox("Error al realizar la descarga de Inventario", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    'Para Separar los Apartados de los Defectuosos
                    'Try
                    '    ValidarDefectuososApartados()
                    'Catch ex As Exception
                    '    EscribeLog(ex.ToString, "Error al validar los apartados y defectuosos de SAP")
                    'End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Vendedores")
                    '''***Procesar Catalogo Vendedores
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarVendedores()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los vendedores de SAP")
                        MsgBox("Error al realizar la descarga de Vendedores", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Promociones")
                    '''***Procesar Catalogo Promociones
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarPromociones()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los promociones de ls tarjetas de SQL")
                        MsgBox("Error al realizar la descarga de Promociones de Bines", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Almacenes")
                    '''***Procesar Catalogo Almacenes
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarAlmacenes()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los almacenes de SQL")
                        MsgBox("Error al realizar la descarga de Almacenes", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("DescuentosAdicionales")
                    '''***Procesar Descuentos Adicionales
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarDescuentosAdicionales(FechaDA, OpcDescAdi)
                    Catch ex As Exception
                        bMostrarMensaje = False
                        EscribeLog(ex.ToString, "Error al descargar los descuentos adicionales de SAP")
                        MsgBox("Error al realizar la descarga de Descuentos Adicionales", MsgBoxStyle.Exclamation, Me.Text)
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("Marcas")
                    '''***Procesar Catalogo Marcas
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarMarcas()
                        ProcesarCatalogos()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        MsgBox("Error al realizar la descarga de Catalogos", MsgBoxStyle.Exclamation, Me.Text)
                        EscribeLog(ex.ToString, "Error al descargar los Catalogos de SAP")
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case UCase("RazonesRechazo")
                    '''***Procesar Catalogo Razones Rechazo
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarRazonesRechazo()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        MsgBox("Error al realizar la descarga de Razones de Rechazo", MsgBoxStyle.Exclamation, Me.Text)
                        EscribeLog(ex.ToString, "Error al descargar las razones rechazo de SAP")
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
                Case "CodigosPostales".ToUpper
                    '''***Procesar Catalogo Codigos Postales
                    Console.WriteLine(Now.ToLongTimeString)
                    Try
                        ProcesarCodigosPostales()
                    Catch ex As Exception
                        bMostrarMensaje = False
                        MsgBox("Error al realizar la descarga de Códigos Postales", MsgBoxStyle.Exclamation, Me.Text)
                        EscribeLog(ex.ToString, "Error al descargar los codigos postales de SQL")
                    End Try
                    Console.WriteLine(Now.ToLongTimeString)
            End Select

            DeleteAlmacenIsDownload(strOpcion)
            If OpcDescAdi < 0 AndAlso bMostrarMensaje = True Then MsgBox("Proceso de Carga finalizó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "SAP")
            Me.Close()
        Catch ex1 As Exception
            DeleteAlmacenIsDownload(strOpcion)
            EscribeLog(ex1.Message, "Error de descarga") ', ex1)
            Throw ex1
        End Try

        'If OpcDescAdi < 0 AndAlso bMostrarMensaje = True Then MsgBox("Proceso de Carga finalizó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "SAP")
        'Me.Close()

    End Sub

    Private Sub InitialForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case strOpcion.Trim.ToUpper
            Case "Articulos".ToUpper, "Descuentos".ToUpper, "Inventarios".ToUpper, "CodigosUPC".ToUpper
                Me.pbProceso.Visible = False
                Me.lblProgreso.Visible = True
            Case "Clientes".ToUpper, "Cobranza".ToUpper, "Vendedores".ToUpper, "Promociones".ToUpper, "Almacenes".ToUpper, "DescuentosAdicionales".ToUpper, "Marcas".ToUpper, "RazonesRechazo".ToUpper, "CodigosPostales".ToUpper
                Me.pbProceso.Visible = True
                Me.lblProgreso.Visible = False
        End Select

    End Sub

End Class