Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports System.IO

Public Class frmReimpresionTickets
    Inherits System.Windows.Forms.Form

    Dim oFacturaFormaPago As FacturaFormaPago
    Dim oFacturaCorridaMgr As FacturaCorridaManager
    Dim oFactura As Factura
    Dim oFacturaMgr As FacturaManager
    Dim oBancos As Bancos
    Dim oBancosMgr As CatalogoBancosManager
    Dim oAbonosApartados As AbonosApartados
    Dim oAbonosApartadosMgr As AbonosApartadosManager
    Dim strVencimiento As String = String.Empty
    Dim strNombre As String = String.Empty
    Dim strCripto As String = ""
    Dim strFirma As String = ""
    Dim strPosEntry As String = ""
    Dim bolReadOnly As Boolean = True

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturaMgr = New FacturaManager(oAppContext)
        oBancosMgr = New CatalogoBancosManager(oAppContext)
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oAbonosApartadosMgr = New AbonosApartadosManager(oAppContext)

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
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblFacturaID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnReimprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebNumAbono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReimpresionTickets))
        Me.menuArchivo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.txtTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebNumAbono = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblFacturaID = New System.Windows.Forms.Label()
        Me.btnReimprimir = New Janus.Windows.EditControls.UIButton()
        Me.ebFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo4 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivo3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuArchivo2
        '
        Me.menuArchivo2.Key = "menuArchivo"
        Me.menuArchivo2.Name = "menuArchivo2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "Archivo"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.IsEditableControl = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        Me.menuArchivo1.Text = "&Archivo"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.txtTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebNumAbono)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.lblFacturaID)
        Me.ExplorerBar1.Controls.Add(Me.btnReimprimir)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioSAP)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 22)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(322, 130)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(272, 64)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 20)
        Me.btnLeerTarjeta.TabIndex = 16
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtTarjeta
        '
        Me.txtTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.txtTarjeta.Location = New System.Drawing.Point(104, 64)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.ReadOnly = True
        Me.txtTarjeta.Size = New System.Drawing.Size(168, 20)
        Me.txtTarjeta.TabIndex = 3
        Me.txtTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "No. Tarjeta:"
        '
        'ebNumAbono
        '
        Me.ebNumAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumAbono.ButtonImage = CType(resources.GetObject("ebNumAbono.ButtonImage"), System.Drawing.Image)
        Me.ebNumAbono.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebNumAbono.Location = New System.Drawing.Point(104, 40)
        Me.ebNumAbono.MaxLength = 4
        Me.ebNumAbono.Name = "ebNumAbono"
        Me.ebNumAbono.Size = New System.Drawing.Size(120, 22)
        Me.ebNumAbono.TabIndex = 2
        Me.ebNumAbono.Text = "0"
        Me.ebNumAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebNumAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.AccessibleDescription = "0"
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(8, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "No. Abono:"
        '
        'lblFacturaID
        '
        Me.lblFacturaID.BackColor = System.Drawing.Color.Transparent
        Me.lblFacturaID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturaID.Location = New System.Drawing.Point(8, 16)
        Me.lblFacturaID.Name = "lblFacturaID"
        Me.lblFacturaID.Size = New System.Drawing.Size(80, 23)
        Me.lblFacturaID.TabIndex = 5
        Me.lblFacturaID.Text = "Factura SAP:"
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Location = New System.Drawing.Point(8, 88)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(304, 32)
        Me.btnReimprimir.TabIndex = 4
        Me.btnReimprimir.Text = "Imprimir Vouchers"
        Me.btnReimprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFolioSAP
        '
        Me.ebFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.ButtonImage = CType(resources.GetObject("ebFolioSAP.ButtonImage"), System.Drawing.Image)
        Me.ebFolioSAP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebFolioSAP.Location = New System.Drawing.Point(104, 16)
        Me.ebFolioSAP.MaxLength = 20
        Me.ebFolioSAP.Name = "ebFolioSAP"
        Me.ebFolioSAP.Size = New System.Drawing.Size(120, 22)
        Me.ebFolioSAP.TabIndex = 1
        Me.ebFolioSAP.Text = "0"
        Me.ebFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Nothing
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(304, 24)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo3, Me.menuArchivoNuevo2})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("d9905ec7-1f0c-4de5-beee-3827763bc718")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 152)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(322, 0)
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo4})
        Me.UiCommandBar2.Key = "CommandBar1"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.Size = New System.Drawing.Size(322, 22)
        Me.UiCommandBar2.Text = "CommandBar1"
        Me.UiCommandBar2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'menuArchivo4
        '
        Me.menuArchivo4.Key = "menuArchivo"
        Me.menuArchivo4.Name = "menuArchivo4"
        '
        'menuArchivo3
        '
        Me.menuArchivo3.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo3})
        Me.menuArchivo3.Key = "menuArchivo"
        Me.menuArchivo3.Name = "menuArchivo3"
        Me.menuArchivo3.Text = "&Archivo"
        '
        'menuArchivoNuevo3
        '
        Me.menuArchivoNuevo3.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo3.Name = "menuArchivoNuevo3"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        Me.menuArchivoNuevo2.Text = "&Nuevo"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 22)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 130)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(322, 22)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 130)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(322, 22)
        '
        'frmReimpresionTickets
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(322, 152)
        Me.Controls.Add(Me.LeftRebar1)
        Me.Controls.Add(Me.RightRebar1)
        Me.Controls.Add(Me.BottomRebar1)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReimpresionTickets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresion Vouchers"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "User Functions"

    Private Function Sm_ValidaFormasPago(ByVal dsFormasPago As DataSet) As DataTable

        Dim dtFormaPagoTACR As New DataTable("FormasPagoTACR")
        Dim i As Integer = 0
        Dim bolTarj As Boolean = False
        Dim bolFormasPagoTACR As Boolean = False

        dtFormaPagoTACR = dsFormasPago.Tables(0).Copy

        Do While i < dtFormaPagoTACR.Rows.Count

            Dim oRow As DataRow

            oRow = dtFormaPagoTACR.Rows(i)

            If UCase(Trim(oRow!CodFormasPago)) <> "TACR" AndAlso UCase(Trim(oRow!CodFormasPago)) <> "TADB" Then

                dtFormaPagoTACR.Rows.Remove(oRow)
                i = 0

            ElseIf Trim(Me.txtTarjeta.Text) <> Trim(oRow!NumeroTarjeta) Then

                dtFormaPagoTACR.Rows.Remove(oRow)
                i = 0
                bolFormasPagoTACR = True

            Else

                i += 1
                bolTarj = True
                bolFormasPagoTACR = True

            End If

        Loop

        If dtFormaPagoTACR.Rows.Count = 0 Then

            If bolFormasPagoTACR = False Then

                MsgBox("No existen formas de pago con tarjeta de crédito o debito en la factura capturada", MsgBoxStyle.Exclamation, "Dportenis PRO")

            ElseIf bolTarj = False Then

                MsgBox("La tarjeta capturada no fue usada en la factura " & Me.ebFolioSAP.Text, MsgBoxStyle.Exclamation, "Dportenis PRO")

            End If

        End If

        Return dtFormaPagoTACR

    End Function

    Private Function ValidaCampos() As Boolean

        ValidaCampos = True

        If oFactura Is Nothing AndAlso oAbonosApartados Is Nothing Then

            'MsgBox("Es necesario capturar el folio de la factura o el folio del abono", MsgBoxStyle.Exclamation, "Dportenis PRO")
            MsgBox("Es necesario capturar el folio de la factura", MsgBoxStyle.Exclamation, "Dportenis PRO")
            Me.ebFolioSAP.Focus()
            GoTo Fin

        End If

        If Trim(Me.txtTarjeta.Text) = "" Or Me.txtTarjeta.Text = "Deslize Tarjeta ..." Then
            MsgBox("Es necesario deslizar la tarjeta", MsgBoxStyle.Exclamation, "Dportenis PRO")
            Me.txtTarjeta.Focus()
            GoTo Fin
        End If

        Exit Function

Fin:
        ValidaCampos = False

    End Function

    Private Sub Sm_BuscarFactura(ByVal TipoFolio As String, Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        '<Validacón>

        If (oAppContext.ApplicationConfiguration.NoCaja = String.Empty) Then

            MsgBox("No ha sido seleccionado un código de caja.", MsgBoxStyle.Exclamation, "DPortenis Pro")
            Exit Sub

        End If

        '<Validación>

        If (Vpa_bolOpenRecordDialog = True) Then


            'Dim oCancelarFacturaMgr As CancelaFacturaManager
            'oCancelarFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

            Dim oOpenRecordDlg As New OpenRecordDialog

            Dim oFacturaOpenRecordDialogView As New FacturaOpenRecordDialogView
            'oFacturaOpenRecordDialogView.TipoVenta = Me.ebTipoVenta.Value
            oOpenRecordDlg.CurrentView = oFacturaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()
            'me quede en probar el abrir de los folios de las facturas
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                If TipoFolio = "FolioPro" Then
                    'Me.ebFolioFactura.Value = oOpenRecordDlg.Record.Item("FolioFactura")
                Else
                    Me.ebFolioSAP.Text = oOpenRecordDlg.Record.Item("FolioSAP")
                End If

            End If

        ElseIf Not (oFactura Is Nothing) AndAlso UCase(oFactura.FolioSAP.Trim) = UCase(Me.ebFolioSAP.Text.Trim) Then

            Me.txtTarjeta.Focus()
            Exit Sub

        End If

        If ebFolioSAP.Text <> "0" And ebFolioSAP.Text <> "" Then

            oFactura = oFacturaMgr.Create
            oFactura.ClearFields()

            Dim dsFolioCaja As DataSet
            dsFolioCaja = New DataSet

            dsFolioCaja = oFacturaMgr.SelectFolioCaja(ebFolioSAP.Text)
            If dsFolioCaja.Tables(0).Rows.Count > 0 Then
                oFacturaMgr.Load(dsFolioCaja.Tables(0).Rows(0)("FolioFactura"), dsFolioCaja.Tables(0).Rows(0)("CodCaja"), oFactura)
                'ebCodCaja.Text = dsFolioCaja.Tables(0).Rows(0)("CodCaja")
            Else
                GoTo No_Existe
            End If

            If oFactura.FacturaID > 0 Then

                If ValidaFactura() Then

                    'Cargamos los Articulos del Detalle
                    oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
                    oAbonosApartados = Nothing
                    Me.ebNumAbono.Text = "0"

                    Me.txtTarjeta.Focus()

                Else

                    Me.ebFolioSAP.Text = ""
                    Me.ebFolioSAP.Text.PadLeft(10, "0")
                    Me.ebFolioSAP.Focus()

                End If

            Else
No_Existe:
                MsgBox("Folio de Factura NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPortenis Pro")

                'btnAceptar.Enabled = False
                Me.ebFolioSAP.Focus()

            End If

        Else

            'btnAceptar.Enabled = False
            ebFolioSAP.Text = "0"

        End If

    End Sub

    Private Function ValidaFactura() As Boolean

        If oFactura.StatusFactura = "CAN" Then

            MsgBox("Factura " & ebFolioSAP.Text.PadLeft(10, "0") & " está CANCELADA. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPortenis Pro")
            Return False

        End If

        Return True

    End Function

    Private Sub Sm_Nuevo()

        oFactura = Nothing
        oAbonosApartados = Nothing
        Me.txtTarjeta.Text = "Deslize Tarjeta ..."
        Me.ebNumAbono.Text = "0"
        Me.ebFolioSAP.Text = "0"
        Me.txtTarjeta.ReadOnly = True
        bolReadOnly = True

    End Sub

#End Region

#Region "Form Events"

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Nuevo()
                Me.ebFolioSAP.Focus()

        End Select

    End Sub

    Private Sub ebFolioSAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolioSAP.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt AndAlso e.KeyCode = Keys.S Then
            Sm_BuscarFactura("FolioSAP", True)
        End If

    End Sub

    Private Sub ebFolioSAP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioSAP.ButtonClick

        Sm_BuscarFactura("FolioSAP", True)

    End Sub

    Private Sub frmReimpresionTickets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtTarjeta.Text = "Deslize Tarjeta ..."

    End Sub

    Private Sub txtTarjeta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarjeta.LostFocus

        If Me.txtTarjeta.Text = "" Then
            Me.txtTarjeta.Text = "Deslize Tarjeta ..."
        End If

    End Sub

    Private Sub txtTarjeta_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarjeta.GotFocus

        If Me.txtTarjeta.Text = "Deslize Tarjeta ..." Then

            Me.txtTarjeta.Text = String.Empty

        End If

    End Sub

    'Private Sub txtTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTarjeta.KeyDown

    '    If e.KeyCode = Keys.ShiftKey Then

    '        Me.txtTarjeta.ReadOnly = False
    '        bolReadOnly = False

    '    End If

    '    If bolReadOnly = False Then

    '        If e.KeyCode = Keys.Enter Then

    '            If Me.txtTarjeta.Text.Length > 16 Then

    '                Dim strTrack() As String = txtTarjeta.Text.Split(";")
    '                Dim strTarjeta() As String
    '                Dim strSeparadorIni As String, strSeparadorFin As String

    '                If InStr(strTrack(0), "¨") > 0 Then
    '                    strSeparadorFin = "¨"
    '                    If InStr(strTrack(0), "Ä") > 0 Then
    '                        strSeparadorIni = "Ä"
    '                    ElseIf InStr(strTrack(0), "Ë") > 0 Then
    '                        strSeparadorIni = "Ë"
    '                    ElseIf InStr(strTrack(0), "Ï") > 0 Then
    '                        strSeparadorIni = "Ï"
    '                    ElseIf InStr(strTrack(0), "Ö") > 0 Then
    '                        strSeparadorIni = "Ö"
    '                    ElseIf InStr(strTrack(0), "Ü") > 0 Then
    '                        strSeparadorIni = "Ü"
    '                    ElseIf InStr(strTrack(0), "Ÿ") > 0 Then
    '                        strSeparadorIni = "Ÿ"
    '                    Else
    '                        strSeparadorIni = "¨"
    '                    End If
    '                Else
    '                    strSeparadorFin = "^"
    '                    If InStr(strTrack(0), "Â") > 0 Then
    '                        strSeparadorIni = "Â"
    '                    ElseIf InStr(strTrack(0), "Ê") > 0 Then
    '                        strSeparadorIni = "Ê"
    '                    ElseIf InStr(strTrack(0), "Î") > 0 Then
    '                        strSeparadorIni = "Î"
    '                    ElseIf InStr(strTrack(0), "Ô") > 0 Then
    '                        strSeparadorIni = "Ô"
    '                    ElseIf InStr(strTrack(0), "Û") > 0 Then
    '                        strSeparadorIni = "Û"
    '                    Else
    '                        strSeparadorIni = "^"
    '                    End If
    '                End If
    '                strNombre = GetName(strTrack(0), strSeparadorIni, strSeparadorFin)
    '                'strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("¨") - 18)
    '                strTarjeta = strTrack(1).Split("=")
    '                txtTarjeta.Text = strTarjeta(0)

    '                'Dim intPosition As Integer = 0
    '                'Dim strNum As String = (txtTarjeta.Text).Replace(";", "")

    '                'intPosition = InStr(strNum, "=")
    '                'strVencimiento = Mid(strNum, intPosition + 3, 2) & "/" & Mid(strNum, intPosition + 1, 2)
    '                strVencimiento = Mid(strTarjeta(1), 3, 2) & "/" & Mid(strTarjeta(1), 1, 2)
    '                'strNum = Mid(strNum, 1, intPosition - 1)
    '                Me.txtTarjeta.ReadOnly = True
    '                bolReadOnly = True

    '            End If

    '        End If

    '    End If

    'End Sub

    Private Sub GenerarArchivoMonto(ByVal Ruta As String, ByVal monto As String)

        Dim oStreamW As StreamWriter

        oStreamW = New StreamWriter(Ruta)

        oStreamW.Write(monto)

        oStreamW.Close()

    End Sub

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        'File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub LeeTarjeta()

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        Dim Datos() As String
        Dim oProcesos() As Process
        Dim oApp As Process

        oProcesos = Process.GetProcessesByName("eHubEMV")
        For Each oApp In oProcesos
            oApp.CloseMainWindow()
            oApp.WaitForExit()
        Next

        Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

        If File.Exists(Ruta) Then
            Datos = LeerArchivoTarjeta(Ruta)
            File.Delete(Ruta)
        Else
            Me.txtTarjeta.Text = ""
            Exit Sub
        End If

        strNombre = Datos(1)
        txtTarjeta.Text = Datos(0)
        txtTarjeta.Text = txtTarjeta.Text.Split("=")(0)
        strPosEntry = Datos(3) & "1"
        strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
        strCripto = Datos(5)
        strFirma = Datos(6)

        If strPosEntry.Trim = "051" Then
            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
        End If
    End Sub

    Public Function GetName(ByVal strTrack As String, ByVal strSeparadorIni As String, ByVal strSeparadoFin As String)

        Dim strNombre As String
        Dim intIndexIni, intIndexFin As Integer

        intIndexIni = strTrack.IndexOf(strSeparadorIni)
        If intIndexIni > 0 Then
            intIndexFin = strTrack.LastIndexOf(strSeparadoFin)
            strNombre = strTrack.Substring(intIndexIni, intIndexFin - intIndexIni)
        End If
        If InStr(strTrack, "¨") > 0 Then
            strNombre = strNombre.Replace("¨", "").Trim
        Else
            strNombre = strNombre.Replace("^", "").Trim
        End If
        Return strNombre

    End Function

    Private Sub btnReimprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReimprimir.Click

        If ValidaCampos() = False Then
            Exit Sub
        End If

        Try

            If Not oFactura Is Nothing Then

                Dim dsFacturasFP As New DataSet

                dsFacturasFP = oFacturaFormaPago.Load(oFactura.FacturaID)

                Dim dtFormaPagoTACR As DataTable

                dtFormaPagoTACR = Sm_ValidaFormasPago(dsFacturasFP)

                If dtFormaPagoTACR.Rows.Count <> 0 Then

                    Dim Online As Boolean
                    Dim strPromocion As String = ""
                    Dim mAfiliacion As String = ""

                    For Each oRow As DataRow In dtFormaPagoTACR.Rows

                        mAfiliacion = oRow!NoAfiliacion

                        If oRow!CodTipoTarjeta = "TE" Then
                            Online = True
                        Else
                            Online = False
                        End If

                        oBancos = oBancosMgr.Load(Trim(oRow!CodBanco))

                        If oBancos Is Nothing Then
                            oBancos = oBancosMgr.Load(oAppContext.ApplicationConfiguration.BancoParaTarjetas)
                        End If

                        Select Case UCase(Trim(oRow!CodBanco))

                            Case "T3"
Imprime_Banamex:
                                Dim oARReporte As New rptTicketBANAMEX(oRow!MontoPago, oRow!NumeroTarjeta, _
                                                                       strVencimiento, oRow!NumeroAutorizacion, _
                                                                       strPromocion, "VENTA", strNombre, _
                                                                       oFactura.CodVendedor, mAfiliacion, _
                                                                       oBancos.Descripcion, "ORIGINAL BANCO", _
                                                                       strFirma, strCripto, online, "", "", "", "")
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBANAMEX(oRow!MontoPago, oRow!NumeroTarjeta, _
                                                                        strVencimiento, oRow!NumeroAutorizacion, _
                                                                        strPromocion, "VENTA", strNombre, _
                                                                        oFactura.CodVendedor, mAfiliacion, _
                                                                        oBancos.Descripcion, "COPIA CLIENTE", _
                                                                        strFirma, strCripto, online, "", "", "", "")
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                            Case "T1"

                                Dim oARReporte As New rptTicketBancomer(oRow!MontoPago, oRow!NumeroTarjeta, _
                                                                        strVencimiento, oRow!NumeroAutorizacion, _
                                                                        strPromocion, "VENTA", Trim(strNombre), _
                                                                        oFactura.CodVendedor, mAfiliacion, _
                                                                        oBancos.Descripcion, "ORIGINAL BANCO", _
                                                                        strPosEntry, True, Online, strCripto, _
                                                                        strFirma)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBancomer(oRow!MontoPago, oRow!NumeroTarjeta, _
                                                                         strVencimiento, oRow!NumeroAutorizacion, _
                                                                         strPromocion, "VENTA", Trim(strNombre), _
                                                                         oFactura.CodVendedor, mAfiliacion, _
                                                                         oBancos.Descripcion, "COPIA CLIENTE", _
                                                                         strPosEntry, True, Online, strCripto, _
                                                                         strFirma)
                                oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                            Case Else

                                GoTo Imprime_Banamex

                        End Select

                    Next

                End If

            Else

                If oAbonosApartados.CodFormaPago = "TACR" OrElse oAbonosApartados.CodFormaPago = "TADB" Then

                    If UCase(oAbonosApartados.NumeroTarjeta.Trim) <> UCase(Me.txtTarjeta.Text.Trim) Then

                        MsgBox("La tarjeta capturada no fue usada en el abono " & Me.ebNumAbono.Text, MsgBoxStyle.Exclamation, "Dportenis Pro")
                        Exit Sub

                    End If

                    Dim strPromocion As String = String.Empty
                    Dim mAfiliacion As String = oAbonosApartados.NumAfiliacion
                    Dim OnLine As Boolean = IIf(oAbonosApartados.TipoTarjeta = "TE", True, False)

                    oBancos = oBancosMgr.Load(Trim(oAbonosApartados.CodBanco))

                    If oBancos Is Nothing Then
                        oBancos = oBancosMgr.Load(oAppContext.ApplicationConfiguration.BancoParaTarjetas)
                    End If

                    Select Case UCase(Trim(oAbonosApartados.CodBanco))

                        Case "T3"
Imprime_Banamex_Abono:
                            Dim oARReporte As New rptTicketBANAMEX(oAbonosApartados.Abono, oAbonosApartados.NumeroTarjeta, strVencimiento, _
                                                                   oAbonosApartados.NumeroAutorizacion, strPromocion, "VENTA", _
                                                                   strNombre, oAbonosApartados.CodVendedor, mAfiliacion, oBancos.Descripcion, _
                                                                   "ORIGINAL BANCO", strFirma, strCripto, online, "", "", "", "")
                            oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporte.Run()
                            oARReporte.Document.Print(False, False)

                            'Copia Cliente
                            Dim oARReporteC As New rptTicketBANAMEX(oAbonosApartados.Abono, oAbonosApartados.NumeroTarjeta, strVencimiento, _
                                                                   oAbonosApartados.NumeroAutorizacion, strPromocion, "VENTA", _
                                                                   strNombre, oAbonosApartados.CodVendedor, mAfiliacion, oBancos.Descripcion, _
                                                                   "COPIA CLIENTE", strCripto, strFirma, online, "", "", "", "")
                            oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporteC.Run()
                            oARReporteC.Document.Print(False, False)

                        Case "T1"

                            Dim oARReporte As New rptTicketBancomer(oAbonosApartados.Abono, oAbonosApartados.NumeroTarjeta, strVencimiento, _
                                                                   oAbonosApartados.NumeroAutorizacion, strPromocion, "VENTA", _
                                                                   strNombre, oAbonosApartados.CodVendedor, mAfiliacion, oBancos.Descripcion, _
                                                                   "ORIGINAL BANCO", strPosEntry, True, online, strCripto, strFirma)
                            oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporte.Run()
                            oARReporte.Document.Print(False, False)

                            'Copia Cliente
                            Dim oARReporteC As New rptTicketBancomer(oAbonosApartados.Abono, oAbonosApartados.NumeroTarjeta, strVencimiento, _
                                                                   oAbonosApartados.NumeroAutorizacion, strPromocion, "VENTA", _
                                                                   strNombre, oAbonosApartados.CodVendedor, mAfiliacion, oBancos.Descripcion, _
                                                                   "COPIA CLIENTE", strPosEntry, True, online, strCripto, strFirma)
                            oARReporteC.Document.Name = "Pagaré Tarjeta de Crédito"
                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                            oARReporteC.Run()
                            oARReporteC.Document.Print(False, False)

                        Case Else

                            GoTo Imprime_Banamex_Abono

                    End Select

                    'Next

                End If

            End If

        Catch ex As Exception

            Throw New ApplicationException("No se pudo imprimir el ticket")

        End Try

    End Sub

#End Region

    Private Sub ebNumAbono_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumAbono.ButtonClick

        Sm_BuscarAbono(True)

    End Sub

    Private Sub Sm_BuscarAbono(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New AbonosApartadosOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oAbonosApartados = Nothing
                oAbonosApartados = oAbonosApartadosMgr.Load(oOpenRecordDlg.Record.Item("FolioAbono"))

                ebNumAbono.Text = oAbonosApartados.FolioAbono
                oFactura = Nothing
                Me.ebFolioSAP.Text = "0"
                Me.txtTarjeta.Focus()

            End If

        Else

            On Error Resume Next
            oAbonosApartados = Nothing

            oAbonosApartados = oAbonosApartadosMgr.Load(ebNumAbono.Text.Trim)

            If Not (oAbonosApartados Is Nothing) Then

                oFactura = Nothing
                Me.ebFolioSAP.Text = "0"
                Me.txtTarjeta.Focus()

            End If

        End If

    End Sub

    Private Sub ebNumAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumAbono.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarAbono(True)

        ElseIf e.KeyCode = Keys.Enter Then

            ValidaNumAbono()

        End If

    End Sub

    Private Sub ValidaNumAbono()

        If (ebNumAbono.Text.Trim = String.Empty) Then
            Exit Sub
        End If
        oAbonosApartados = Nothing
        If (ebNumAbono.Text > 0 AndAlso oAbonosApartados Is Nothing) Then

            Dim myID As Integer = ebNumAbono.Text

            oAbonosApartados = oAbonosApartadosMgr.Load(myID)

            If oAbonosApartados Is Nothing Then
                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abonos")
                ebNumAbono.Text = ""
                ebNumAbono.Focus()
                Exit Sub
            End If

            If oAbonosApartados.ID = 0 Then

                MsgBox("Abono " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abonos")
                ebNumAbono.Text = ""
                ebNumAbono.Focus()

            Else

                oFactura = Nothing
                Me.ebFolioSAP.Text = "0"
                Me.txtTarjeta.Focus()

            End If

        Else

            If ebNumAbono.Text <= 0 Then

                Me.txtTarjeta.Focus()

            Else

                ebNumAbono.Text = oAbonosApartados.ID

            End If

        End If

    End Sub

    Private Sub ebNumAbono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumAbono.Validating

        Sm_BuscarAbono(False)

    End Sub

    Private Sub ebFolioSAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioSAP.Validating

        Sm_BuscarFactura("FolioSAP", False)

    End Sub

    Private Sub frmReimpresionTickets_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Me.Close()

        End Select

    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click

        Me.btnLeerTarjeta.Enabled = False
        LeeTarjeta()
        Me.btnLeerTarjeta.Enabled = True

    End Sub

End Class
