Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports System.Web.Mail
Imports DataDynamics.ActiveReports.Export.Pdf
Imports System.IO

Public Class frmAutorizaTraspasosPendientes
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal FromBloqueo As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar(FromBloqueo)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents uICommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuAutorizar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAutorizar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents grdCabecera As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizaTraspasosPendientes))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdDetalle = New Janus.Windows.GridEX.GridEX()
        Me.grdCabecera = New Janus.Windows.GridEX.GridEX()
        Me.uICommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuAutorizar1 = New Janus.Windows.UI.CommandBars.UICommand("menuAutorizar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCancelar1 = New Janus.Windows.UI.CommandBars.UICommand("menuCancelar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuAutorizar = New Janus.Windows.UI.CommandBars.UICommand("menuAutorizar")
        Me.menuCancelar = New Janus.Windows.UI.CommandBars.UICommand("menuCancelar")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.grdDetalle)
        Me.explorerBar1.Controls.Add(Me.grdCabecera)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(618, 292)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdDetalle
        '
        Me.grdDetalle.AlternatingColors = True
        Me.grdDetalle.AlternatingRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetalle.DesignTimeLayout = GridEXLayout1
        Me.grdDetalle.GroupByBoxVisible = False
        Me.grdDetalle.Location = New System.Drawing.Point(9, 128)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDetalle.Size = New System.Drawing.Size(600, 160)
        Me.grdDetalle.TabIndex = 2
        Me.grdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grdCabecera
        '
        Me.grdCabecera.AlternatingColors = True
        Me.grdCabecera.AlternatingRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdCabecera.DesignTimeLayout = GridEXLayout2
        Me.grdCabecera.GroupByBoxVisible = False
        Me.grdCabecera.Location = New System.Drawing.Point(8, 16)
        Me.grdCabecera.Name = "grdCabecera"
        Me.grdCabecera.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdCabecera.Size = New System.Drawing.Size(600, 104)
        Me.grdCabecera.TabIndex = 1
        Me.grdCabecera.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAutorizar, Me.menuCancelar, Me.menuSalir})
        Me.uICommandManager1.ContainerControl = Me
        '
        '
        '
        Me.uICommandManager1.EditContextMenu.Key = ""
        Me.uICommandManager1.Id = New System.Guid("4284a793-dd2d-485b-9684-1f3752f99a78")
        Me.uICommandManager1.LeftRebar = Me.LeftRebar1
        Me.uICommandManager1.RightRebar = Me.RightRebar1
        Me.uICommandManager1.TopRebar = Me.TopRebar1
        Me.uICommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.uICommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.uICommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAutorizar1, Me.Separator1, Me.menuCancelar1, Me.Separator2, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(313, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuAutorizar1
        '
        Me.menuAutorizar1.Key = "menuAutorizar"
        Me.menuAutorizar1.Name = "menuAutorizar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuCancelar1
        '
        Me.menuCancelar1.Key = "menuCancelar"
        Me.menuCancelar1.Name = "menuCancelar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuAutorizar
        '
        Me.menuAutorizar.Icon = CType(resources.GetObject("menuAutorizar.Icon"), System.Drawing.Icon)
        Me.menuAutorizar.Key = "menuAutorizar"
        Me.menuAutorizar.Name = "menuAutorizar"
        Me.menuAutorizar.Text = "Autorizar Traspaso"
        '
        'menuCancelar
        '
        Me.menuCancelar.Image = CType(resources.GetObject("menuCancelar.Image"), System.Drawing.Image)
        Me.menuCancelar.Key = "menuCancelar"
        Me.menuCancelar.Name = "menuCancelar"
        Me.menuCancelar.Text = "Cancelar Traspaso"
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.uICommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.uICommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.uICommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(618, 28)
        '
        'frmAutorizaTraspasosPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(618, 320)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAutorizaTraspasosPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorizar Traspasos Pendientes"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oTSMgr As TraspasosSalidaManager
    Dim oArticulosMgr As CatalogoArticuloManager
    Dim dtCabecera As DataTable
    Dim dtDetalle As DataTable
    Dim oSAPMgr As ProcesoSAPManager
    Dim UserSessionAplicated As String
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim Bloqueado As Boolean

    Private Sub Inicializar(ByVal FromBloqueado As Boolean)
        oTSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
        oArticulosMgr = New CatalogoArticuloManager(oAppContext)
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Bloqueado = FromBloqueado
    End Sub

    Private Sub GetTraspasosPendientes()

        Dim dsTP As DataSet

        dsTP = oTSMgr.GetAllTraspasosPendientes()

        dtCabecera = dsTP.Tables(0).Copy
        dtDetalle = dsTP.Tables(1).Copy

        Dim oAlmacen As Almacen
        Dim oRow As DataRow

        dtCabecera.Columns.Add("OrigenDesc", GetType(String))
        dtCabecera.Columns.Add("DestinoDesc", GetType(String))
        dtCabecera.AcceptChanges()

        For Each oRow In dtCabecera.Rows
            oAlmacen = Nothing
            oAlmacen = oAlmacenMgr.Load(oRow!Origen)
            If Not oAlmacen Is Nothing Then oRow!OrigenDesc = oRow!Origen & " " & oAlmacen.Descripcion.Trim
            oAlmacen = Nothing
            oAlmacen = oAlmacenMgr.Load(oRow!Destino)
            If Not oAlmacen Is Nothing Then oRow!DestinoDesc = oRow!Destino & " " & oAlmacen.Descripcion.Trim
        Next

        Dim oArt As Articulo

        dtDetalle.Columns.Add("Descripcion", GetType(String))
        dtDetalle.AcceptChanges()

        For Each oRow In dtDetalle.Rows
            oArt = Nothing
            oArt = oArticulosMgr.Load(oRow!CodArticulo)
            If Not oArt Is Nothing Then oRow!Descripcion = oArt.Descripcion.Trim
        Next

        ActualizaGridCabecera()

    End Sub

    Public Function ExportaTraspasoPDF(ByVal oTraspasoSalidaTemp As TraspasoSalida) As String

        Dim RutaPDF As String = ""

        If Not oTraspasoSalidaTemp Is Nothing Then

            Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalidaTemp, "Autorizar Traspasos Pendientes")

            oARReporte.Document.Name = "Reporte de Traspaso de Salida"

            oARReporte.Run()

            Try
                'oARReporte.Document.Print(False, False)
                Dim oPDF As New PdfExport
                RutaPDF = "C:\" & oTraspasoSalidaTemp.FolioSAP.Trim & ".pdf"
                oPDF.Export(oARReporte.Document, RutaPDF)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al imprimir el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID)
            End Try

        End If

        Return RutaPDF.Trim

    End Function

    Private Sub EnviarCorreoResolucion(ByVal oTS As TraspasoSalida, ByVal CentroDesSAP As String, ByVal bPaqueteria As Boolean, _
                                       ByVal FolioTESAP As String)

        Try
            'Mando el correo
1:          Dim mmMail As New MailMessage
2:          Dim oAttachment As MailAttachment ' = New MailAttachment(strruta)
3:          Dim objSmtpServer As SmtpMail
            Dim strTo As String = ""
            Dim str As String = ""
            Dim RutaPDF As String = ""

            '---------------------------------------------------------------------------------------------------------------------------
            'Adjuntamos los correos de los auditores como destinatarios
            '---------------------------------------------------------------------------------------------------------------------------
4:          For Each str In oConfigCierreFI.CuentasCorreoAuditoria
5:              If Not str Is Nothing AndAlso str.Trim <> "" Then
6:                  strTo &= str & ";"
                End If
            Next
            '---------------------------------------------------------------------------------------------------------------------------
            'Generamos el archivo del traspaso de salida en PDF y lo adjuntamos
            '---------------------------------------------------------------------------------------------------------------------------
7:          RutaPDF = ExportaTraspasoPDF(oTS)
8:          If RutaPDF.Trim <> "" Then
9:              oAttachment = New MailAttachment(RutaPDF)
10:             mmMail.Attachments.Add(oAttachment)
            End If
            '---------------------------------------------------------------------------------------------------------------------------
            'Si es al CDIST al que se le devolveran los faltantes o existe una reclamación a la paqueteria se le envia el correo a los 
            'configurados por errores del CDIST también
            '---------------------------------------------------------------------------------------------------------------------------
11:         If InStr("Z000,Z001", CentroDesSAP.Trim.ToUpper) > 0 OrElse bPaqueteria Then
12:             For Each str In oConfigCierreFI.CuentasCorreoErroresCDist
13:                 If Not str Is Nothing AndAlso str.Trim <> "" Then
14:                     strTo &= str & ";"
                    End If
                Next
            End If
            '---------------------------------------------------------------------------------------------------------------------------
            'Si es una tienda a la que se le devolveran los faltantes se le envia el correo también
            '---------------------------------------------------------------------------------------------------------------------------
            Dim dtCliente As DataTable
15:         If CentroDesSAP.Trim.ToUpper.Substring(0, 1) <> "Z" Then

                '---------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (11.02.2016): Adaptacion por retail
                '---------------------------------------------------------------------------------------------------------------------------
                '16:             dtCliente = oSAPMgr.ZBAPI_GET_CLIENTE(CentroDesSAP.Trim.Substring(1, 3).PadLeft(10, "0"), "")
                '17:             If dtCliente.Rows.Count > 0 Then
                '18:                 str = CStr(dtCliente.Rows(0)!KNURL).Trim
                '19:                 If str.Trim <> "" Then strTo &= str & ";"
                '                End If
                Dim Correo As String
16:             Correo = oSAPMgr.ZSD_OBTENER_CORREO_OFI_VENTA(CentroDesSAP.Trim.Substring(1, 3).PadLeft(10, "0"))
17:             str = Correo.Trim
18:             If str.Trim <> "" Then strTo &= str & ";"
                '---------------------------------------------------------------------------------------------------------------------------
            End If
            '---------------------------------------------------------------------------------------------------------------------------
            'Se adjunta el correo de la tienda origen
            '---------------------------------------------------------------------------------------------------------------------------
20:         strTo &= oConfigCierreFI.CuentaCorreo.Trim & ";"

21:         mmMail.From = oConfigCierreFI.CuentaCorreo
22:         mmMail.To = strTo
23:         mmMail.Subject = "Traspaso " & FolioTESAP.Trim & " Resuelto " & oTS.FolioSAP.Trim
24:         mmMail.Body = "En al archivo adjunto viene el traspaso de salida " & oTS.FolioSAP.Trim & " generado para resolver faltantes en traspaso de entrada " & _
            FolioTESAP.Trim
            'Dim oAttachment As MailAttachment = New MailAttachment(strruta)
            'oAttachment = New MailAttachment(strruta)
            'mmMail.Attachments.Add(oAttachment)
25:         objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
            Try
26:             objSmtpServer.Send(mmMail)
27:             If File.Exists(RutaPDF) Then File.Delete(RutaPDF)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al enviar correo de resolución por autorizacion de traspaso " & oTS.FolioSAP & ": Linea " & Err.Erl)
            End Try
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar correo de resolución por autorizacion de traspaso " & oTS.FolioSAP & ": Linea " & Err.Erl)
        End Try

    End Sub

    Private Sub ActualizaGridCabecera()
        Me.grdCabecera.DataSource = dtCabecera
        Me.grdCabecera.Refresh()
        Me.ActualizaGridDetalle(0)
    End Sub

    Private Sub ActualizaGridDetalle(ByVal TraspasoID As Integer)

        Me.grdDetalle.DataSource = Nothing

        If TraspasoID > 0 Then
            Dim dvDet As New DataView(dtDetalle, "TraspasoPendID = " & TraspasoID, "", DataViewRowState.CurrentRows)

            Me.grdDetalle.DataSource = dvDet
        End If

        Me.grdDetalle.Refresh()

    End Sub

    Public Function CrearDetalleTraspasoSalida(ByVal dvFaltantes As DataView) As DataSet

        Dim oRow As DataRowView
        Dim oArticuloTemp As Articulo
        Dim dsTraspasoSalidaDetalle As DataSet

        oTSMgr.CrearTablaTmp()

        For Each oRow In dvFaltantes
            oArticuloTemp = Nothing
            oArticuloTemp = oArticulosMgr.Load(CStr(oRow!CodArticulo))
            If Not oArticuloTemp Is Nothing Then
                oTSMgr.AgregarArticulo(oArticuloTemp, oRow!Talla, oRow!Cantidad, oRow!Costo, 0)
            End If
        Next

        dsTraspasoSalidaDetalle = Nothing
        dsTraspasoSalidaDetalle = oTSMgr.GenerarTraspasoCorrida("[RefCruzTraspaso]")

        oArticuloTemp = Nothing

        Return dsTraspasoSalidaDetalle

    End Function

    Private Function Validar() As Boolean

        Dim bRes As Boolean = True

        If Me.grdDetalle.GetRows.Length <= 0 Then
            MessageBox.Show("Es necesario seleccionar un traspaso pendiente para autorizar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.grdCabecera.Focus()
            bRes = False
        Else
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") Then
                bRes = False
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If

        Return bRes

    End Function

    Private Sub GenerarTraspasoSalida(ByVal Centro As String, ByVal dvFaltantes As DataView, ByVal FolioTESAP As String, _
                                      ByVal strCodAlmacenDes As String, ByVal strResponsableID As String, _
                                      ByVal strTransportistaID As String, ByVal bPaqueteria As Boolean, ByVal NumGuia As String, _
                                      ByVal NumBultos As String, ByVal TransportistaDesc As String, ByVal TraspasoPID As Integer)

        Dim oTraspasoSalida As TraspasoSalida
        Dim dsTraspasoCorrida As New DataSet
        Dim dtDetalleSAP As DataTable
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para la base local
        '-------------------------------------------------------------------------------------------------------------------------------------
        dsTraspasoCorrida = CrearDetalleTraspasoSalida(dvFaltantes)
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Creamos el detalle del traspaso de salida para SAP
        '-------------------------------------------------------------------------------------------------------------------------------------
        dtDetalleSAP = oTSMgr.FillTablaParaSAP

        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(dvFaltantes)
        If ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP") = False Then
            ShowFormNegadosSH(dtNegadosSH)
            Exit Sub
        End If
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Generamos la tabla con los codigos para desmarcar como de baja calidad para EC por el traspaso de salida
        '-------------------------------------------------------------------------------------------------------------------------------------
        Dim dtDefectuososEC As DataTable
        Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(dvFaltantes, dtMateriales)
        GenerarEstructuraBajaCalidad(dtDefectuososEC, New DataView(dtArticuloLibre), "TS")

        'Dim dtMateriales As DataTable
        'Dim oRow As DataRowView

        'dtMateriales = dvFaltantes.Table.Clone
        'For Each oRow In dvFaltantes
        '    dtMateriales.ImportRow(oRow.Row)
        'Next
        'dtMateriales.AcceptChanges()
        'If ValidarMaterialesDefectuososEC(dtMateriales, dtDefectuososEC, UserSessionAplicated, "TS") = False Then
        '    Exit Sub
        'End If

        'With dtDefectuososEC
        '    .Columns.Add("Material", GetType(String))
        '    .Columns.Add("Talla", GetType(String))
        '    .Columns.Add("Cantidad", GetType(Integer))
        '    .Columns.Add("Motivo", GetType(String))
        '    .Columns.Add("DesmarcadoID", GetType(String))
        '    .Columns.Add("MarcadoID", GetType(String))
        'End With

        'Dim oNewRow As DataRow
        'Dim MotivoDesmarcado As String = ""
        'Dim DesID As String = ""
        'Dim dtMotivosDes As DataTable
        ''--------------------------------------------------------------------------------------------------------------------
        ''Obtenemos el id de motivo de desmarcado de SAP
        ''--------------------------------------------------------------------------------------------------------------------
        'dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS("TS")
        'If dtMotivosDes.Rows.Count > 0 Then
        '    MotivoDesmarcado = dtMotivosDes.Rows(0)!Motivo
        '    DesID = dtMotivosDes.Rows(0)!ID
        'End If

        'For Each oRow In dvFaltantes
        '    oNewRow = dtDefectuososEC.NewRow
        '    With oNewRow
        '        !Material = CStr(oRow!Codigo).Trim
        '        !Talla = CStr(oRow!Talla).Trim
        '        !Cantidad = oRow!Cantidad
        '        !Motivo = MotivoDesmarcado.Trim
        '        !DesmarcadoID = DesID.Trim
        '        !MarcadoID = "FTE01"
        '    End With
        'Next
        '-------------------------------------------------------------------------------------------------------------------------------------
        'Generamos el pedido de Traslado en SAP
        '-------------------------------------------------------------------------------------------------------------------------------------
        Dim FolioPedidoTraspasoSAP As String = ""
        Dim strObservaciones As String = ""

        FolioPedidoTraspasoSAP = oSAPMgr.pedido_trasladomm02(dtDetalleSAP, Centro.Trim, "A001")

        If FolioPedidoTraspasoSAP.Trim = "" Then
            '---------------------------------------------------------------------------------------------------------------------------------
            'No se grabo en sap
            '---------------------------------------------------------------------------------------------------------------------------------
            EscribeLog("Error al realizar el pedido de traspaso en sap por los faltantes del traspaso de entrada " & FolioTESAP.Trim, "Error al realizar pedido de traslado")
            MsgBox("No se Realizo el PEDIDO DE TRAPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
            Exit Sub
        Else
            '---------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos movimiento 351 en SAP
            '---------------------------------------------------------------------------------------------------------------------------------
            Dim strNumTras As String = ""

            If bPaqueteria Then
                strObservaciones = "TO: " & FolioTESAP.Trim & " R Paqueteria"
            Else
                strObservaciones = "TO: " & FolioTESAP.Trim & ", Faltantes"
            End If
            strNumTras = oSAPMgr.trasladomm02(FolioPedidoTraspasoSAP.Trim, strObservaciones.Trim, strCodAlmacenDes.Trim)

            If strNumTras = "" Then
                '-----------------------------------------------------------------------------------------------------------------------------
                'no se grabo en sap
                '-----------------------------------------------------------------------------------------------------------------------------
                EscribeLog("No se realizo el movimiento 351 en SAP del traslado de salida " & FolioPedidoTraspasoSAP.Trim, "Error al aplicar 351 a traspaso de salida")
                MsgBox("No se Realizo el TRASPASO en SAP", MsgBoxStyle.Exclamation, "Error SAP")
                Exit Sub
            End If
            If bPaqueteria Then
                strObservaciones = "Traslado generado por faltantes, reclamación paqueteria, folio origen: " & FolioTESAP.Trim
            Else
                strObservaciones = "Traslado generado por faltantes en traspaso de entrada con folio: " & FolioTESAP.Trim
            End If
        End If
        '--------------------------------------------------------------------------------------------------------------------------
        'Se desmarcan los codigos marcados como defectuosos para ecommerce que van en el traspaso
        '--------------------------------------------------------------------------------------------------------------------------
        If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
            oSAPMgr.ZPOL_DEFECTUOSOS_INS(FolioPedidoTraspasoSAP, "DD", UserSessionAplicated, dtDefectuososEC)
        End If
        '---------------------------------------------------------------------------------------------------------------------------
        'GUIA BULTOS PAQUETERIA
        '---------------------------------------------------------------------------------------------------------------------------
        'Guia       F01
        'Bultos     F02
        'Paqueteria F03
        '----------------------------------------------------------------------------------------------------------------------------
        '-----------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
        '-----------------------------------------------------------------------------------------------------------------------------------
        'oSAPMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, NumGuia, "F01")
        'oSAPMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, NumBultos, "F02")
        'oSAPMgr.SaveInfoPaqueteria(FolioPedidoTraspasoSAP.Trim, TransportistaDesc, "F03")
        '----------------------------------------------------------------------------------------------------------------------------
        'Guardar traspaso de salida en la base local
        '----------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida = Nothing
        oTraspasoSalida = oTSMgr.Create

        oTraspasoSalida.Observaciones = strObservaciones.Trim

        oTraspasoSalida.TraspasoRecibidoEl = Date.Now.Date
        oTraspasoSalida.Guia = NumGuia.Trim
        oTraspasoSalida.TotalBultos = NumBultos.Trim
        oTraspasoSalida.AutorizadoPorID = strResponsableID
        oTraspasoSalida.Cargos = 0
        oTraspasoSalida.SubTotal = 0
        oTraspasoSalida.MonedaID = "1"
        oTraspasoSalida.TraspasoCreadoEl = Date.Now.Date
        oTraspasoSalida.TransportistaID = strTransportistaID.Trim
        oTraspasoSalida.Status = "GRA"
        oTraspasoSalida.AlmacenDestinoID = strCodAlmacenDes.Trim
        oTraspasoSalida.AlmacenOrigenID = oAppContext.ApplicationConfiguration.Almacen
        oTraspasoSalida.Referencia = ""
        oTraspasoSalida.TraspasoID = 0
        oTraspasoSalida.Folio = ""
        oTraspasoSalida.FolioSAP = FolioPedidoTraspasoSAP.Trim
        oTraspasoSalida.TEOrigen = FolioTESAP.Trim

        oTraspasoSalida.Detalle = dsTraspasoCorrida

        oTraspasoSalida.Save()
        '----------------------------------------------------------------------------------------------------------------------------
        'Actualizamos el status del traspaso pendiente por autorizar
        '----------------------------------------------------------------------------------------------------------------------------
        oTSMgr.ActualizaTraspasoPendiente(TraspasoPID, UserSessionAplicated, "A")
        '----------------------------------------------------------------------------------------------------------------------------
        'Guardamos el traspaso de salida en el servidor
        '----------------------------------------------------------------------------------------------------------------------------
        Try
            oTSMgr.SaveInServer(oTraspasoSalida, dtDetalleSAP)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar el traspaso de salida " & oTraspasoSalida.TraspasoID & " en el server.")
        End Try
        '-----------------------------------------------------------------------------------------------------------------------------
        'Actualizamos la informacion en la base local y afectamos el inventario
        '-----------------------------------------------------------------------------------------------------------------------------
        Sm_AplicarTraspasoSalida(oTraspasoSalida)
        '-----------------------------------------------------------------------------------------------------------------------------
        'Imprimir Traspaso
        '-----------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalida.Detalle.Tables(0).TableName = "TraspasoCorrida"
        PrintComprobanteTraspasoSalida(oTraspasoSalida)
        '-----------------------------------------------------------------------------------------------------------------------------
        'Enviamos correo a todos los involucrados con el traspaso de salida generado
        '-----------------------------------------------------------------------------------------------------------------------------
        EnviarCorreoResolucion(oTraspasoSalida, Centro, bPaqueteria, FolioTESAP)

        oTraspasoSalida = Nothing

        MsgBox("El Traspaso de Salida ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda")

    End Sub

    Private Sub GenerarEstructuraBajaCalidad(ByRef dtDefectuososEC As DataTable, ByVal dvFaltantes As DataView, ByVal Modulo As String)

        dtDefectuososEC = New DataTable("DefectuososEC")

        With dtDefectuososEC
            .Columns.Add("Material", GetType(String))
            .Columns.Add("Talla", GetType(String))
            .Columns.Add("Cantidad", GetType(Integer))
            .Columns.Add("Motivo", GetType(String))
            .Columns.Add("DesmarcadoID", GetType(String))
            .Columns.Add("MarcadoID", GetType(String))
            .AcceptChanges()
        End With

        Dim oNewRow As DataRow
        Dim MotivoDesmarcado As String = ""
        Dim DesID As String = "", MarID As String = ""
        Dim dtMotivosDes As DataTable
        '--------------------------------------------------------------------------------------------------------------------
        'Obtenemos el id de motivo de desmarcado y de marcado de SAP
        '--------------------------------------------------------------------------------------------------------------------
        dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS(Modulo.Trim)
        If dtMotivosDes.Rows.Count > 0 Then
            MotivoDesmarcado = dtMotivosDes.Rows(0)!Motivo
            DesID = dtMotivosDes.Rows(0)!ID
        End If
        dtMotivosDes = oSAPMgr.ZPOL_GET_MOTIVOS("FT")
        If dtMotivosDes.Rows.Count > 0 Then
            MarID = dtMotivosDes.Rows(0)!ID
        End If
        '--------------------------------------------------------------------------------------------------------------------
        'Llenamos la tabla de los defectuosos de Ecommerce
        '--------------------------------------------------------------------------------------------------------------------
        Dim oRow As DataRowView

        For Each oRow In dvFaltantes
            oNewRow = dtDefectuososEC.NewRow
            With oNewRow
                !Material = CStr(oRow!CodArticulo).Trim
                !Talla = CStr(oRow!Talla).Trim
                !Cantidad = oRow!Cantidad
                !Motivo = MotivoDesmarcado.Trim
                !DesmarcadoID = DesID.Trim
                !MarcadoID = MarID.Trim
            End With
            dtDefectuososEC.Rows.Add(oNewRow)
        Next
        dtDefectuososEC.AcceptChanges()

    End Sub

    Private Sub Sm_AplicarTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)
        '------------------------------------------------------------------------------------------------------------------------------------
        'Validación
        '------------------------------------------------------------------------------------------------------------------------------------
        If (oTraspasoSalidaTemp Is Nothing) Then
            EscribeLog("No hay un traspaso de salida selecciona oTraspasoSalidaTemp Is Nothing", "Error al aplicar traspaso de salida")
            MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        ElseIf oTraspasoSalidaTemp.Status.Trim.ToUpper <> "GRA" Then
            EscribeLog("El traspaso ya habia sido aplicado anteriormente. Status <> GRA", "Error al aplicar traspaso de salida " & oTraspasoSalidaTemp.TraspasoID)
            MsgBox("El Traspaso ya fue Aplicado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If
        '------------------------------------------------------------------------------------------------------------------------------------
        'Actualizar Traspaso [General].
        '------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoSalidaTemp.TraspasoRecibidoEl = "01/01/1900"
        oTraspasoSalidaTemp.Status = "TRA"

        If (oTSMgr.AplicarEntrada(oTraspasoSalidaTemp) = True) Then

            'oTraspasoSalidaTemp = Nothing

            'MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")
        Else
            EscribeLog("No se pudo aplicar el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID, "Error al aplicar traspaso salida automatico")
            MsgBox("El Traspaso de Salida no se Aplicó.", MsgBoxStyle.Exclamation, "DPTienda")
        End If

    End Sub

    Public Sub PrintComprobanteTraspasoSalida(ByVal oTraspasoSalidaTemp As TraspasoSalida)

        If Not oTraspasoSalidaTemp Is Nothing Then

            Dim oARReporte As New rptReporteTraspasoDeSalida(oTraspasoSalidaTemp, "Autorizar Traspasos Pendientes")
            'Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Reporte de Traspaso de Salida"

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.Print(False, False)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al imprimir el traspaso de salida con folio: " & oTraspasoSalidaTemp.TraspasoID)
            End Try

        End If

    End Sub

    Private Sub Autorizar()

        If Validar() Then

            Dim FolioTE As String = Me.grdCabecera.GetValue("TEOrigen")
            Dim dvCab As New DataView(dtCabecera, "TEOrigen = '" & FolioTE.Trim & "'", "", DataViewRowState.CurrentRows)
            Dim oRowV As DataRowView = dvCab(0)
            Dim dvDet As New DataView(dtDetalle, "TraspasoPendID = " & oRowV!TraspasoPendID, "", DataViewRowState.CurrentRows)

            Dim CentroSAP As String = oSAPMgr.Read_Centros(oRowV!Destino)

            Me.GenerarTraspasoSalida(CentroSAP, dvDet, FolioTE, oRowV!Destino, Me.UserSessionAplicated, oRowV!Transportista, oRowV!Reclamacion, _
                                    oRowV!Guia, oRowV!Bultos, oRowV!Transportista, oRowV!TraspasoPendID)

            RevisaTPBloquean()

            GetTraspasosPendientes()

        End If

    End Sub

    Private Sub RevisaTPBloquean()
        If Bloqueado AndAlso RevisaTraspasosPendientes() Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub Cancelar()
        If Not grdCabecera.GetRow() Is Nothing Then
            Dim TraspasoID As Integer = Me.grdCabecera.GetRow.DataRow!TraspasoPendID
            Dim FolioTE As String = Me.grdCabecera.GetValue("TEOrigen")
            Dim dvDet As New DataView(dtDetalle, "TraspasoPendID = " & TraspasoID, "", DataViewRowState.CurrentRows)

            If Me.grdDetalle.GetRows.Length <= 0 Then
                MessageBox.Show("Es necesario seleccionar el traspaso para cancelar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.grdCabecera.Focus()
            ElseIf TraspasoID > 0 AndAlso MessageBox.Show("¿Estas seguro que deseas cancelar el traspaso pendiente generado" & vbCrLf & "por el " & _
            "traspaso de entrada con folio " & Me.grdCabecera.GetValue("TEOrigen") & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, _
            MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                oAppContext.Security.CloseImpersonatedSession()
                If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") Then
                    oAppContext.Security.CloseImpersonatedSession()
                Else
                    UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Actualizamos el status del traspaso pendiente de salida a cancelado
                    '-------------------------------------------------------------------------------------------------------------------------
                    oTSMgr.ActualizaTraspasoPendiente(TraspasoID, UserSessionAplicated, "C")
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Desmarcamos los codigos como de baja calidad para EC ya que al cancelarlo se asume que si llegaron y no eran faltantes 
                    'en realidad
                    '-------------------------------------------------------------------------------------------------------------------------
                    Dim dtDefectuososEC As DataTable

                    GenerarEstructuraBajaCalidad(dtDefectuososEC, dvDet, "CT")

                    If Not dtDefectuososEC Is Nothing AndAlso dtDefectuososEC.Rows.Count > 0 Then
                        oSAPMgr.ZPOL_DEFECTUOSOS_INS(FolioTE, "DD", UserSessionAplicated, dtDefectuososEC)
                    End If

                    MessageBox.Show("El traspaso pendiente se ha cancelado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Revisamos si el sistema esta bloqueado, para desbloquear o seguir bloqueado segun sea el caso
                    '-------------------------------------------------------------------------------------------------------------------------
                    RevisaTPBloquean()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Refrescamos si quedan traspasos pendientes por autorizar
                    '-------------------------------------------------------------------------------------------------------------------------
                    GetTraspasosPendientes()

                End If
                oAppContext.Security.CloseImpersonatedSession()

            End If
        End If
    End Sub

    Private Sub uICommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick

        Select Case e.Command.Key.ToUpper
            Case "menuAutorizar".ToUpper
                Autorizar()
            Case "menuCancelar".ToUpper
                Cancelar()
            Case "menuSalir".ToUpper
                Me.Close()
        End Select

    End Sub

    Private Sub frmAutorizaTraspasosPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetTraspasosPendientes()

    End Sub

    'Private Sub grdCabecera_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdCabecera.Validating

    '    ActualizaGridDetalle(Me.grdCabecera.GetRow.DataRow!TraspasoPendID)

    'End Sub

    Private Sub grdCabecera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCabecera.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub grdCabecera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCabecera.Click
        If Me.grdCabecera.GetRows.Length > 0 Then
            ActualizaGridDetalle(Me.grdCabecera.GetRow.DataRow!TraspasoPendID)
        End If
    End Sub

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal traspaso As DataView) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        For Each oRow As DataRowView In traspaso
            Dim row As DataRow = dtArticulos.NewRow()
            row("Codigo") = CStr(oRow!CodArticulo)
            row("Talla") = CStr(oRow!Talla)
            row("Cantidad") = CInt(oRow!Cantidad)
            dtArticulos.Rows.Add(row)
        Next
        Return dtArticulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 08/05/2013: Envia el detalle con las cantidades libres Negadas
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataView, ByVal dtMaterialesLibres As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Table.Copy()
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Not dtMaterialesLibres Is Nothing Then
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!CodArticulo)
                Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtMaterialesLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function

#End Region

End Class
