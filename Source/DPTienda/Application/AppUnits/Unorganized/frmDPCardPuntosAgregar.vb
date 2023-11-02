Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Pinpad
Imports System.Web.Mail
Imports System.Net
Imports System.Net.Mail
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class frmDPCardPuntosAgregar
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal operacion As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.operacion = operacion
        Select Case Me.operacion
            Case DPCardOperation.AGREGAR
                Me.Size = New Size(392, 112)
                Me.InfoTarjeta.Visible = False
                Me.txtCardID.ReadOnly = True
                Me.btnReadQr.Visible = True

            Case DPCardOperation.CANJEAR
                Me.Size = New Size(392, 440)
                Me.InfoTarjeta.Visible = True
                Me.txtCardID.ReadOnly = True
                Me.btnReadQr.Visible = True
            Case Else
                Me.Size = New Size(392, 112)
                Me.InfoTarjeta.Visible = False



        End Select
        Me.txtCardID.Focus()
        Me.txtCardID.BringToFront()



        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents expDPCardPunto As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCardID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCardID As System.Windows.Forms.Label
    Friend WithEvents InfoTarjeta As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCanjear As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCantidadCanjear As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents txtClienteID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblClienteID As System.Windows.Forms.Label
    Friend WithEvents cmbFechaExpiracion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFechaExpiracion As System.Windows.Forms.Label
    Friend WithEvents cmbFechaActivacion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblExpedicion As System.Windows.Forms.Label
    Friend WithEvents txtStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents txtTotalPuntos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTotalPuntos As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnReadQr As Janus.Windows.EditControls.UIButton
    Friend WithEvents boxReadQr As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSearch As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDPCardPuntosAgregar))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.expDPCardPunto = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.boxReadQr = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnReadQr = New Janus.Windows.EditControls.UIButton()
        Me.btnSearch = New Janus.Windows.EditControls.UIButton()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.txtCardID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCardID = New System.Windows.Forms.Label()
        Me.InfoTarjeta = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnCanjear = New Janus.Windows.EditControls.UIButton()
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCantidadCanjear = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.txtClienteID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblClienteID = New System.Windows.Forms.Label()
        Me.cmbFechaExpiracion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFechaExpiracion = New System.Windows.Forms.Label()
        Me.cmbFechaActivacion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblExpedicion = New System.Windows.Forms.Label()
        Me.txtStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.txtTotalPuntos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTotalPuntos = New System.Windows.Forms.Label()
        CType(Me.expDPCardPunto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expDPCardPunto.SuspendLayout()
        CType(Me.InfoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InfoTarjeta.SuspendLayout()
        Me.SuspendLayout()
        '
        'expDPCardPunto
        '
        Me.expDPCardPunto.Controls.Add(Me.boxReadQr)
        Me.expDPCardPunto.Controls.Add(Me.btnReadQr)
        Me.expDPCardPunto.Controls.Add(Me.btnSearch)
        Me.expDPCardPunto.Controls.Add(Me.btnLeerDPCard)
        Me.expDPCardPunto.Controls.Add(Me.txtCardID)
        Me.expDPCardPunto.Controls.Add(Me.lblCardID)
        Me.expDPCardPunto.Dock = System.Windows.Forms.DockStyle.Top
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "DPCardDesliza"
        ExplorerBarGroup1.Text = "Desliza Tarjeta"
        Me.expDPCardPunto.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.expDPCardPunto.Location = New System.Drawing.Point(0, 0)
        Me.expDPCardPunto.Name = "expDPCardPunto"
        Me.expDPCardPunto.Size = New System.Drawing.Size(386, 96)
        Me.expDPCardPunto.TabIndex = 0
        Me.expDPCardPunto.Text = "ExplorerBar1"
        Me.expDPCardPunto.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'boxReadQr
        '
        Me.boxReadQr.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.boxReadQr.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.boxReadQr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.boxReadQr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxReadQr.Location = New System.Drawing.Point(70, 41)
        Me.boxReadQr.Name = "boxReadQr"
        Me.boxReadQr.Size = New System.Drawing.Size(216, 21)
        Me.boxReadQr.TabIndex = 232
        Me.boxReadQr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.boxReadQr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnReadQr
        '
        Me.btnReadQr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadQr.Image = CType(resources.GetObject("btnReadQr.Image"), System.Drawing.Image)
        Me.btnReadQr.Location = New System.Drawing.Point(320, 40)
        Me.btnReadQr.Name = "btnReadQr"
        Me.btnReadQr.Size = New System.Drawing.Size(40, 22)
        Me.btnReadQr.TabIndex = 235
        Me.btnReadQr.Visible = False
        Me.btnReadQr.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(320, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(40, 22)
        Me.btnSearch.TabIndex = 233
        Me.btnSearch.Visible = False
        Me.btnSearch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(288, 40)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 232
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtCardID
        '
        Me.txtCardID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCardID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCardID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCardID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardID.Location = New System.Drawing.Point(70, 41)
        Me.txtCardID.Name = "txtCardID"
        Me.txtCardID.Size = New System.Drawing.Size(216, 21)
        Me.txtCardID.TabIndex = 231
        Me.txtCardID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCardID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCardID
        '
        Me.lblCardID.BackColor = System.Drawing.Color.Transparent
        Me.lblCardID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardID.Location = New System.Drawing.Point(8, 40)
        Me.lblCardID.Name = "lblCardID"
        Me.lblCardID.Size = New System.Drawing.Size(72, 16)
        Me.lblCardID.TabIndex = 230
        Me.lblCardID.Text = "Card ID:"
        '
        'InfoTarjeta
        '
        Me.InfoTarjeta.Controls.Add(Me.btnCancelar)
        Me.InfoTarjeta.Controls.Add(Me.btnCanjear)
        Me.InfoTarjeta.Controls.Add(Me.txtSaldo)
        Me.InfoTarjeta.Controls.Add(Me.txtImporteTotal)
        Me.InfoTarjeta.Controls.Add(Me.lblCantidadCanjear)
        Me.InfoTarjeta.Controls.Add(Me.txtNombreCliente)
        Me.InfoTarjeta.Controls.Add(Me.lblNombreCliente)
        Me.InfoTarjeta.Controls.Add(Me.txtClienteID)
        Me.InfoTarjeta.Controls.Add(Me.lblClienteID)
        Me.InfoTarjeta.Controls.Add(Me.cmbFechaExpiracion)
        Me.InfoTarjeta.Controls.Add(Me.lblFechaExpiracion)
        Me.InfoTarjeta.Controls.Add(Me.cmbFechaActivacion)
        Me.InfoTarjeta.Controls.Add(Me.lblExpedicion)
        Me.InfoTarjeta.Controls.Add(Me.txtStatus)
        Me.InfoTarjeta.Controls.Add(Me.lblStatus)
        Me.InfoTarjeta.Controls.Add(Me.lblSaldo)
        Me.InfoTarjeta.Controls.Add(Me.txtTotalPuntos)
        Me.InfoTarjeta.Controls.Add(Me.lblTotalPuntos)
        Me.InfoTarjeta.Dock = System.Windows.Forms.DockStyle.Bottom
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "InfoTarjeta"
        ExplorerBarGroup2.Text = "Info Tarjeta"
        Me.InfoTarjeta.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.InfoTarjeta.Location = New System.Drawing.Point(0, 72)
        Me.InfoTarjeta.Name = "InfoTarjeta"
        Me.InfoTarjeta.Size = New System.Drawing.Size(386, 320)
        Me.InfoTarjeta.TabIndex = 254
        Me.InfoTarjeta.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(216, 280)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(160, 32)
        Me.btnCancelar.TabIndex = 268
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCanjear
        '
        Me.btnCanjear.Image = CType(resources.GetObject("btnCanjear.Image"), System.Drawing.Image)
        Me.btnCanjear.Location = New System.Drawing.Point(8, 280)
        Me.btnCanjear.Name = "btnCanjear"
        Me.btnCanjear.Size = New System.Drawing.Size(176, 32)
        Me.btnCanjear.TabIndex = 267
        Me.btnCanjear.Text = "&Canjear"
        Me.btnCanjear.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtSaldo
        '
        Me.txtSaldo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtSaldo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtSaldo.BackColor = System.Drawing.SystemColors.Info
        Me.txtSaldo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.ForeColor = System.Drawing.Color.Black
        Me.txtSaldo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtSaldo.Location = New System.Drawing.Point(137, 72)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(88, 22)
        Me.txtSaldo.TabIndex = 266
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "$0.00"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.Black
        Me.txtImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtImporteTotal.Location = New System.Drawing.Point(241, 224)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.Size = New System.Drawing.Size(136, 33)
        Me.txtImporteTotal.TabIndex = 265
        Me.txtImporteTotal.Text = "$0.00"
        Me.txtImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCantidadCanjear
        '
        Me.lblCantidadCanjear.BackColor = System.Drawing.Color.Transparent
        Me.lblCantidadCanjear.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadCanjear.Location = New System.Drawing.Point(9, 224)
        Me.lblCantidadCanjear.Name = "lblCantidadCanjear"
        Me.lblCantidadCanjear.Size = New System.Drawing.Size(224, 24)
        Me.lblCantidadCanjear.TabIndex = 264
        Me.lblCantidadCanjear.Text = "Cantidad a Canjear:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.Location = New System.Drawing.Point(137, 192)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(240, 22)
        Me.txtNombreCliente.TabIndex = 263
        Me.txtNombreCliente.TabStop = False
        Me.txtNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(9, 192)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(128, 16)
        Me.lblNombreCliente.TabIndex = 262
        Me.lblNombreCliente.Text = "Cliente:"
        '
        'txtClienteID
        '
        Me.txtClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtClienteID.BackColor = System.Drawing.SystemColors.Info
        Me.txtClienteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClienteID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteID.Location = New System.Drawing.Point(137, 168)
        Me.txtClienteID.Name = "txtClienteID"
        Me.txtClienteID.ReadOnly = True
        Me.txtClienteID.Size = New System.Drawing.Size(240, 22)
        Me.txtClienteID.TabIndex = 261
        Me.txtClienteID.TabStop = False
        Me.txtClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblClienteID
        '
        Me.lblClienteID.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteID.Location = New System.Drawing.Point(9, 168)
        Me.lblClienteID.Name = "lblClienteID"
        Me.lblClienteID.Size = New System.Drawing.Size(128, 16)
        Me.lblClienteID.TabIndex = 260
        Me.lblClienteID.Text = "Id del Cliente:"
        '
        'cmbFechaExpiracion
        '
        Me.cmbFechaExpiracion.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFechaExpiracion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaExpiracion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaExpiracion.Location = New System.Drawing.Point(137, 144)
        Me.cmbFechaExpiracion.Name = "cmbFechaExpiracion"
        Me.cmbFechaExpiracion.ReadOnly = True
        Me.cmbFechaExpiracion.Size = New System.Drawing.Size(104, 22)
        Me.cmbFechaExpiracion.TabIndex = 259
        Me.cmbFechaExpiracion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblFechaExpiracion
        '
        Me.lblFechaExpiracion.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaExpiracion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaExpiracion.Location = New System.Drawing.Point(9, 144)
        Me.lblFechaExpiracion.Name = "lblFechaExpiracion"
        Me.lblFechaExpiracion.Size = New System.Drawing.Size(128, 16)
        Me.lblFechaExpiracion.TabIndex = 258
        Me.lblFechaExpiracion.Text = "Fecha Expiración:"
        '
        'cmbFechaActivacion
        '
        Me.cmbFechaActivacion.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFechaActivacion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaActivacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaActivacion.Location = New System.Drawing.Point(137, 120)
        Me.cmbFechaActivacion.Name = "cmbFechaActivacion"
        Me.cmbFechaActivacion.ReadOnly = True
        Me.cmbFechaActivacion.Size = New System.Drawing.Size(104, 22)
        Me.cmbFechaActivacion.TabIndex = 257
        Me.cmbFechaActivacion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblExpedicion
        '
        Me.lblExpedicion.BackColor = System.Drawing.Color.Transparent
        Me.lblExpedicion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpedicion.Location = New System.Drawing.Point(9, 120)
        Me.lblExpedicion.Name = "lblExpedicion"
        Me.lblExpedicion.Size = New System.Drawing.Size(128, 16)
        Me.lblExpedicion.TabIndex = 256
        Me.lblExpedicion.Text = "Fecha Activación:"
        '
        'txtStatus
        '
        Me.txtStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Info
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(137, 96)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(216, 22)
        Me.txtStatus.TabIndex = 255
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(9, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(96, 16)
        Me.lblStatus.TabIndex = 254
        Me.lblStatus.Text = "Status:"
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(9, 72)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(96, 16)
        Me.lblSaldo.TabIndex = 253
        Me.lblSaldo.Text = "Saldo:"
        '
        'txtTotalPuntos
        '
        Me.txtTotalPuntos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalPuntos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalPuntos.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalPuntos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPuntos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPuntos.Location = New System.Drawing.Point(137, 48)
        Me.txtTotalPuntos.Name = "txtTotalPuntos"
        Me.txtTotalPuntos.ReadOnly = True
        Me.txtTotalPuntos.Size = New System.Drawing.Size(88, 22)
        Me.txtTotalPuntos.TabIndex = 252
        Me.txtTotalPuntos.TabStop = False
        Me.txtTotalPuntos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTotalPuntos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalPuntos
        '
        Me.lblTotalPuntos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPuntos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPuntos.Location = New System.Drawing.Point(9, 48)
        Me.lblTotalPuntos.Name = "lblTotalPuntos"
        Me.lblTotalPuntos.Size = New System.Drawing.Size(96, 16)
        Me.lblTotalPuntos.TabIndex = 251
        Me.lblTotalPuntos.Text = "Total Puntos:"
        '
        'frmDPCardPuntosAgregar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(386, 392)
        Me.Controls.Add(Me.InfoTarjeta)
        Me.Controls.Add(Me.expDPCardPunto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDPCardPuntosAgregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deslizar DPCard Puntos"
        CType(Me.expDPCardPunto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expDPCardPunto.ResumeLayout(False)
        CType(Me.InfoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InfoTarjeta.ResumeLayout(False)
        Me.InfoTarjeta.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private operacion As Integer = DPCardOperation.ACTIVAR
    Private m_params As Hashtable
    '----------------------------------------------------------------
    'FLIZARRAGA 08/03/2018: Parametro extra para la activación.
    '----------------------------------------------------------------
    Private m_ParamsAdd As Hashtable
    Private m_DatosPuntosActivacion As Hashtable

    Private m_DatosPuntos As Hashtable
    Private accion As Boolean = False
    Private m_Provider As Integer
    Private m_deslizada As Boolean = False
    Private m_readQr As Boolean = False
    Private m_PagoDPCard As Boolean = False
    Private m_ingresoManualDPCard As Boolean = False
    Private m_userManualAuth As String = ""
    Private m_player As String = ""
    Private m_auth As Boolean = True
    Private m_ErrorDPCard As String = "Se genero un error al aplicar los puntos"
    '-----------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2017: Se agrega la lista de errores de la pinpad
    '-----------------------------------------------------------------------------------------
    Private ListaErroresBanamex As New List(Of String)() From {"02", "06", "08", "10", "11", "16", "17", "40", "79"}
    Private Success As Boolean = False

    '-----------------------------------------------------------------------------------------
    'FLIZARRAGA 22/01/2018: Se agrega autorización de puntos en las alertas
    '-----------------------------------------------------------------------------------------
    Private m_Autorizado As Boolean = False

    '-----------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/09/2018: Obtener nombre para imprimir el nombre del tarjetahabiente en el ticket
    '-----------------------------------------------------------------------------------------------
    Private m_NombreCliente As String = "Tarjetahabiente"
    Private m_CodTipoVenta As String

    '-----------------------------------------------------------------------------------------------
    'MLVARGAS 25/11/2019: Obtener el valor del parámetro customerName del servicio GetBalance
    '-----------------------------------------------------------------------------------------------

    Private CustomerName As String = String.Empty

    '-----------------------------------------------------------------------------------------------
    'MLVARGAS 08/11/2019: Obtener el motivo por el que se tecleo la tarjeta
    '-----------------------------------------------------------------------------------------------
    Private m_Motivo As String = String.Empty
    Dim oFactMgr As FacturaManager
    Public monto As Decimal
    Public codVendedor As String
    Dim sClientName As String = String.Empty

    '-----------------------------------------------------------------------------------------------
    'MLVARGAS 28/02/2020: Listado de Id's de registros grabados en TransaccionesSinTarjeta
    '-----------------------------------------------------------------------------------------------
    Public lstIds As New List(Of Integer)

#End Region

#Region "Propiedades"

    Public Property DPCardManual As Boolean
        Get
            Return m_ingresoManualDPCard
        End Get
        Set(ByVal value As Boolean)
            m_ingresoManualDPCard = value
        End Set
    End Property
    Public Property Auth As Boolean
        Get
            Return m_auth
        End Get
        Set(ByVal value As Boolean)
            m_auth = value
        End Set
    End Property

    Public Property userAuth As String
        Get
            Return m_userManualAuth
        End Get
        Set(ByVal value As String)
            m_userManualAuth = value
        End Set
    End Property

    Public Property player As String
        Get
            Return m_player
        End Get
        Set(ByVal value As String)
            m_player = value
        End Set
    End Property

    Private Property Deslizada As Boolean
        Get
            Return m_deslizada
        End Get
        Set(ByVal value As Boolean)
            m_deslizada = value
        End Set
    End Property

    Private Property ReadQr As Boolean
        Get
            Return m_readQr
        End Get
        Set(ByVal value As Boolean)
            m_readQr = value
        End Set
    End Property

    Public Property Params() As Hashtable
        Get
            Return m_params
        End Get
        Set(ByVal Value As Hashtable)
            m_params = Value
        End Set
    End Property

    Public Property ParamsAdd As Hashtable
        Get
            Return m_ParamsAdd
        End Get
        Set(ByVal value As Hashtable)
            m_ParamsAdd = value
        End Set
    End Property

    Public Property DatosPuntosActivacion As Hashtable
        Get
            Return m_DatosPuntosActivacion
        End Get
        Set(ByVal value As Hashtable)
            m_DatosPuntosActivacion = value
        End Set
    End Property

    Public Property DatosPuntos() As Hashtable
        Get
            Return m_DatosPuntos
        End Get
        Set(ByVal Value As Hashtable)
            m_DatosPuntos = Value
        End Set
    End Property

    Public Property Provider As Integer
        Get
            Return m_Provider
        End Get
        Set(ByVal value As Integer)
            m_Provider = value
        End Set
    End Property

    '-----------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/03/2017: Propiedad para saber si la venta tuvo al menos una forma DPCard Credit
    '-----------------------------------------------------------------------------------------------------------------------
    Public Property PagoDPCard As Boolean
        Get
            Return m_PagoDPCard
        End Get
        Set(ByVal value As Boolean)
            m_PagoDPCard = value
        End Set
    End Property

    Public Property ErrorDPCard As String
        Get
            Return m_ErrorDPCard
        End Get
        Set(ByVal value As String)
            m_ErrorDPCard = value
        End Set
    End Property

    Public Property Autorizado As Boolean
        Get
            Return m_Autorizado
        End Get
        Set(ByVal value As Boolean)
            m_Autorizado = value
        End Set
    End Property

    Public Property CodTipoVenta As String
        Get
            Return m_CodTipoVenta
        End Get
        Set(value As String)
            m_CodTipoVenta = value
        End Set
    End Property


#End Region

#Region "Eventos Form"
    Private Sub btnLeerDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerDPCard.Click
        Dim cardid As String = ""
        LeerDatosPinPad(cardid)
    End Sub

    Private Sub btnReadQr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReadQr.Click
        Me.boxReadQr.ReadOnly = False
        boxReadQr.Focus()
        'Me.boxReadQr.Select()
        Me.boxReadQr.Text = ""
    End Sub


    Private Sub boxReadQr_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles boxReadQr.KeyPress
        ValidarNumeros(e)
    End Sub


    Private Sub boxReadQr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles boxReadQr.KeyDown
        If e.KeyCode = Keys.Enter Then
            If boxReadQr.Text.Length = 13 Then
                Me.txtCardID.Text = boxReadQr.Text
                ReadQr = True
                Action()
                'txtCardID.Focus()
                'Else
                '    MessageBox.Show("La tarjeta debe contener 13 dígitos", "Tarjeta no valida")
                '    boxReadQr.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCardID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCardID.Click
        'Me.txtCardID.ReadOnly = False
        'txtCardID.Focus()
        'If Me.Auth AndAlso Me.operacion = DPCardOperation.AGREGAR Then
        If Me.Auth AndAlso (Me.operacion = DPCardOperation.AGREGAR Or Me.operacion = DPCardOperation.CANJEAR Or Me.operacion = DPCardOperation.CANJEARSIHAY) Then

            Dim btn As DialogResult = MessageBox.Show("Es necesario que el Gerente/Asistente autorize el ingreso manual de la tarjeta", "Autorización Requerida", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If btn = DialogResult.OK Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos") Then
                    Dim id As Integer = oAppContext.Security.CurrentUser.Role.ID
                    If id = 1 Or id = 3 Or id = 4 Then
                        Me.txtCardID.ReadOnly = False
                        DPCardManual = True
                        userAuth = oAppContext.Security.CurrentUser.SessionLoginName
                        txtCardID.Focus()
                        Me.Auth = False
                    Else
                        DPCardManual = False
                        MessageBox.Show("Solo el Gerente o Asistente pueden habilitar la lectura manual", "Acceso no autorizado")
                    End If

                End If
                oAppContext.Security.CloseImpersonatedSession()
            End If
        End If
    End Sub

    Private Sub txtCardID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCardID.KeyDown
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        'MessageBox.Show("keyDown", "Ingresando por teclado")
        If e.KeyCode = Keys.Enter Then
            If txtCardID.Text.Trim() <> String.Empty Then
                Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                '------------------------------------------------------------------------------------
                'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                '------------------------------------------------------------------------------------
                'If ValidacionLuhn(txtCardID.Text.Trim()) Then
                Deslizada = False
                ReadQr = False
                ' MLVARGAS Solicitar el motivo por el que fue tecleada solo si el proveedor es KARUM
                '31/04/2021 ASANCHEZ valida que sea de tipo bonificación de Blue 
                If oConfigCierreFI.ServiciosBlueBonificacion = "True" Then
                    Dim tipo_ As String = String.Empty
                    tipo_ = consulta_bin_tipo_blue(txtCardID.Text.Trim())
                    If tipo_ = "CFB" Then
                        Dim frmMotivo As New frmMotivoCaptura()
                        frmMotivo.ShowDialog()
                        m_Motivo = frmMotivo.strMotivo
                    ElseIf tipo_ = "CFK" Then
                        Dim frmMotivo As New frmMotivoCaptura()
                        frmMotivo.ShowDialog()
                        m_Motivo = frmMotivo.strMotivo
                    End If
                Else
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Dim frmMotivo As New frmMotivoCaptura()
                        frmMotivo.ShowDialog()
                        m_Motivo = frmMotivo.strMotivo
                    End If
                End If


                'validacion de usos de la dpcard
                Action()
                'End If
            End If
        ElseIf e.KeyCode = Keys.Escape AndAlso Me.operacion = DPCardOperation.AGREGAR Then
            If MessageBox.Show("¿Esta seguro que desea salir sin bonificar puntos", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Success = True
                Me.Dispose()
                Me.DialogResult = DialogResult.Cancel
                Me.ErrorDPCard = "Bonificación de puntos cancelada por el usuario"
            End If
        End If
        Select Case e.KeyCode
            Case e.Alt And Keys.C
                Dim btn As DialogResult = MessageBox.Show("Es necesario que el Gerente/Asistente autorize el ingreso manual de la tarjeta", "Autorización Requerida", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If btn = DialogResult.OK Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos") Then
                        Dim id As Integer = oAppContext.Security.CurrentUser.Role.ID
                        If id = 1 Or id = 3 Or id = 4 Then
                            Me.txtCardID.ReadOnly = False
                            DPCardManual = True
                            userAuth = oAppContext.Security.CurrentUser.SessionLoginName
                            txtCardID.Focus()
                            Me.Auth = False
                        Else
                            DPCardManual = False
                            MessageBox.Show("Solo el Gerente o Asistente pueden habilitar la lectura manual", "Acceso no autorizado")
                        End If

                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                End If
        End Select
    End Sub

    Private Sub frmDPCardPuntosAgregar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If accion = False Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub btnCanjear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanjear.Click
        CanjearPuntos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then


            Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
            Dim idTransaccion As Integer = 0

            If Deslizada = False AndAlso Me.txtCardID.Text.Trim.Length = 16 AndAlso ReadQr = False Then
                If oFactMgr.IsDPCardPuntosKarum(bin) Then
                    idTransaccion = FacturaMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                     Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                End If
            End If
        End If
        Me.Dispose()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Busqueda()
    End Sub

    Private Sub txtNewCardID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            RenewMembership()
        End If
    End Sub

    Private Sub txtImporteTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            CanjearPuntos()
        End If
    End Sub

    Private Sub txtCardID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardID.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub frmDPCardPuntosAgregar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Success = False AndAlso Me.operacion = DPCardOperation.AGREGAR Then
            MessageBox.Show("Para poder salir de la pantalla es necesario deslizar la tarjeta o presionar ESC", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub frmDPCardPuntosAgregar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Me.operacion = DPCardOperation.AGREGAR Then
                    If MessageBox.Show("¿Esta seguro que desea salir sin bonificar puntos", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.Dispose()
                    End If
                End If
        End Select
    End Sub

    Private Sub expDPCardPunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles expDPCardPunto.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.operacion = DPCardOperation.AGREGAR Then
            If MessageBox.Show("¿Esta seguro que desea salir sin bonificar puntos", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Success = True
                Me.Dispose()
                Me.DialogResult = DialogResult.Cancel
                Me.ErrorDPCard = "Bonificación de puntos cancelada por el usuario"
            End If
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Sub LeerDatosPinPad(ByRef texto As String)
        Dim valido As Boolean = False
        '------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/04/2015: Leemos datos de DPCard Puntos con la Pinpad
        '------------------------------------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/02/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
        '--------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.PagosBanamex = True Then
            Dim pinpad As New Pinpad.Pinpad()
            Dim bin As String = ""
            'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
            Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
            If ListaErroresBanamex.Contains(code.Trim()) = False Then
                'Dim Name As String = pinpad.getAppLabel()
                Dim Name As String = pinpad.getName(code)
                bin = pinpad.getCardNumber(code)
                Deslizada = True
                txtCardID.Text = bin
                If Me.operacion = DPCardOperation.CANJEAR Then
                    Me.txtNombreCliente.Text = Name
                    Me.m_NombreCliente = Name
                End If
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
                '------------------------------------------------------------------------------------
                'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                '------------------------------------------------------------------------------------
                If ValidacionLuhn(txtCardID.Text.Trim()) Then
                    Action()
                End If
            Else
                MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                If code.Trim() = "10" Or code.Trim() = "40" Then
                    pinpad.Respuesta("0", "", "")
                End If
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            End If
        Else
            Dim oOtrosPagos As New OtrosPagos
            valido = oOtrosPagos.LeerDatosDPCard(txtCardID.Text)
            If valido Then
                '------------------------------------------------------------------------------------
                'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
                '------------------------------------------------------------------------------------
                If ValidacionLuhn(txtCardID.Text.Trim()) Then
                    Deslizada = True
                    Action()
                End If
            Else
                Me.DialogResult = DialogResult.Cancel
                MessageBox.Show("Hubo un error al lecturar la tarjeta DPCard Puntos", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/04/2015: Lectura por medio de la pinpad pero la renovacion de DPCard Puntos
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub LeerDatosPinPadNewMembership(ByRef texto As String)
        Dim valido As Boolean = False
        '------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/04/2015: Leemos datos de DPCard Puntos con la Pinpad
        '------------------------------------------------------------------------------------------------------------------------
        Dim oOtrosPagos As New OtrosPagos
        valido = oOtrosPagos.LeerDatosDPCard(texto)

        If valido Then
            If ValidacionLuhn(texto) Then
                RenewMembership()
            End If
        Else
            Me.DialogResult = DialogResult.Cancel
            MessageBox.Show("Hubo un error al lecturar la tarjeta DPCard Puntos", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' MLVARGAS (06.03.2020): Aunque exista una falla al autorizar la tarjeta se graba a transacciones sin tarjeta
    '--------------------------------------------------------------------------------------------------------------
    Private Sub RegistraTransaccionInconclusa(ByVal Operacion As String, ByVal bin As Integer)
        If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
            oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                         Me.txtCardID.Text, monto, Operacion, "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
        End If
    End Sub

    Private Sub Action()

        oFactMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        Try
            Select Case Me.operacion
                Case DPCardOperation.ACTIVAR
                    ActivateDPCard()
                    Me.DialogResult = DialogResult.OK
                    Me.accion = True
                    Me.Dispose()
                Case DPCardOperation.AGREGAR
                    EscribeLog("Empezara a bonificar", "Bonificacion")
                    Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                    Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                    EscribeLog("Obtuvo el bin", "Bonificacion")
                    If oConfigCierreFI.alertUsoBonifica Then
                        Dim Dpcard As String = Me.txtCardID.Text.Trim
                        EscribeLog("Carga la tarjeta", "Bonificacion")
                        Dim card_number As String
                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                            card_number = Dpcard.Remove(0, 4)
                        Else
                            card_number = Dpcard
                        End If
                        If validaTransaccionesDPCard(card_number, 1) Then
                            '-------------------------------------------------------------------------------------
                            'FLIZARRAGA 17/09/2018: Validar si la tarjeta esta activa
                            '-------------------------------------------------------------------------------------
                            EscribeLog("Paso ValidaTransaccionesDPCard", "Bonificacion")
                            If ValidarTarjeta() Then
                                EscribeLog("Tarjeta Valida", "Bonificacion")


                                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                                    '-------------------------------------------------------------------------------------
                                    'MLVARGAS 11/11/2019: Si la tarjeta fue tecleada se graba a TransaccionesSinTarjeta
                                    '-------------------------------------------------------------------------------------
                                    If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
                                        Dim idTransaccion As Integer = 0
                                        idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                     Me.txtCardID.Text, monto, "Bonificación", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                        lstIds.Add(idTransaccion)
                                    End If
                                Else
                                    'ASANCHEZ 29/03/2021 validamos el bin 
                                    Dim tipo_ As String = String.Empty
                                    tipo_ = consulta_bin_tipo_blue(txtCardID.Text.Trim())
                                    If Deslizada = False AndAlso tipo_ = "CFB" AndAlso ReadQr = False Then
                                        Dim idTransaccion As Integer = 0
                                        idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                     Me.txtCardID.Text, monto, "Bonificación", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                        lstIds.Add(idTransaccion)
                                    End If
                                End If
                                If CollectDPCard() Then
                                    EscribeLog("Bonifica la tarjeta", "Bonificacion")
                                    Me.DialogResult = DialogResult.OK
                                    Me.accion = True
                                    Me.Dispose()
                                Else
                                    EscribeLog("No se bonifico la tarjeta", "Bonificacion")
                                    Me.txtCardID.Text = ""
                                End If
                            Else
                                EscribeLog("Tarjeta no valida", "Bonificacion")
                                If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                                    EscribeLog("Entro al approval", "Bonificacion")
                                    'RegisterApproval()
                                End If
                                RegistraTransaccionInconclusa("Bonificación", bin)
                            End If
                        Else
                            EscribeLog("Autorizacion de tarjeta", "Bonificacion")
                            MessageBox.Show("Tarjeta en revisión. Número de transacciones excedido.", "Revisión Tarjeta Lealtad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            MessageBox.Show("Los puntos NO se acumularon.", "Acumulación no exitosa", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            EnviarCorreoAlertaDPcard("Tarjeta de Lealtad con acumulación de puntos excedida", "Alerta Uso Acumulación Puntos", "abono", 1)
                            If MessageBox.Show("¿Deseas autorizar la transacción para Bonificar?", "Autorización de Alerta de uso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                EscribeLog("Acepto autorizacion", "Bonificacion")
                                oAppContext.Security.CloseImpersonatedSession()
                                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Autorizacion") = True Then
                                    EscribeLog("Se valida la tarjeta si esta activa", "Bonificacion")
                                    If ValidarTarjeta() Then
                                        EscribeLog("Si esta activa la tarjeta", "Bonificacion")


                                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                                            If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
                                                '-------------------------------------------------------------------------------------
                                                'MLVARGAS 29/11/2019: Si la tarjeta fue tecleada se graba a TransaccionesSinTarjeta
                                                '-------------------------------------------------------------------------------------
                                                Dim idTransaccion As Integer = 0

                                                idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                             Me.txtCardID.Text, monto, "Bonificación", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                                lstIds.Add(idTransaccion)

                                            End If
                                        Else
                                            'ASANCHEZ 29/03/2021 validamos el bin 
                                            Dim tipo_ As String = String.Empty
                                            tipo_ = consulta_bin_tipo_blue(txtCardID.Text.Trim())
                                            If Deslizada = False AndAlso tipo_ = "CFB" AndAlso ReadQr = False Then
                                                Dim idTransaccion As Integer = 0
                                                idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                             Me.txtCardID.Text, monto, "Bonificación", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                                lstIds.Add(idTransaccion)
                                            End If
                                        End If


                                        If CollectDPCard() Then
                                            EscribeLog("Bonifico puntos", "Bonificacion")
                                            Me.DialogResult = DialogResult.OK
                                            Me.accion = True
                                            userAuth = oAppContext.Security.CurrentUser.SessionLoginName
                                            Me.Autorizado = True
                                            Me.Dispose()
                                        Else
                                            EscribeLog("No Bonifico puntos", "Bonificacion")
                                            Me.txtCardID.Text = ""
                                        End If
                                    Else
                                        EscribeLog("Tarjeta no valida", "Bonificacion")
                                        If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                                            EscribeLog("Entro al approval", "Bonificacion")
                                            'RegisterApproval()
                                        End If
                                        RegistraTransaccionInconclusa("Bonificación", bin)
                                    End If
                                Else
                                    EscribeLog("No tiene permisos de bonificacion", "Bonificacion")
                                    Me.DialogResult = DialogResult.Cancel
                                    Me.accion = False
                                    Me.Dispose()
                                End If
                                oAppContext.Security.CloseImpersonatedSession()
                            Else
                                EscribeLog("No se autorizo la transaccion de bonificacion", "Bonificacion")
                                Me.DialogResult = DialogResult.Cancel
                                Me.accion = False
                                RegistraTransaccionInconclusa("Bonificación", bin)
                                Me.Dispose()
                            End If
                        End If
                    Else
                        RegistraTransaccionInconclusa("Bonificación", bin)
                        EscribeLog("No se autorizo la transaccion de bonificacion", "Bonificacion")
                        If ValidarTarjeta() Then
                            If CollectDPCard() Then
                                Me.DialogResult = DialogResult.OK
                                Me.accion = True
                                Me.Dispose()
                            Else
                                Me.txtCardID.Text = ""
                            End If
                        Else
                            EscribeLog("tarjeta no valida", "Bonificacion")
                            If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                                'RegisterApproval()
                            End If
                        End If
                    End If

                Case DPCardOperation.CANJEAR
                    Me.txtCardID.Text = Me.txtCardID.Text.Trim()
                    GetBalanceDPCard()
                Case DPCardOperation.TRASPASO
                Case DPCardOperation.RENOVAR
                    If ValidateCardIdExpire() = True Then
                        RenewMembership()
                    End If
                Case DPCardOperation.CANJEARSIHAY
                    Me.txtCardID.Text = Me.txtCardID.Text.Trim()
                    GetBalanceDPCard()
            End Select

        Catch ex As Exception
            Me.DialogResult = DialogResult.Cancel
            EscribeLog(ex.Message, "Error en DPCard Puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Function validaTransaccionesDPCard(ByVal Card As String, ByVal opcion As Integer) As Boolean

        Dim valido As Boolean = False
        Dim firstDay As New DateTime(Date.Now.Year, Date.Now.Month, 1)
        Dim lastDay As DateTime = firstDay.AddMonths(1).AddDays(-1)
        Dim diasMes As Integer = Date.Now.DaysInMonth(Date.Now.Year, Date.Now.Month)
        Dim oFacturaMgr As FacturaManager
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        Dim periodosBonifica As Integer = diasMes / oConfigCierreFI.DiasPermitidosBonificacion
        Dim resDiasMesBon As Long = diasMes Mod oConfigCierreFI.DiasPermitidosBonificacion

        Dim periodosCanje As Integer = diasMes / oConfigCierreFI.DiasPermitidosCanje
        Dim resDiasMesCan As Long = diasMes Mod oConfigCierreFI.DiasPermitidosCanje

        Dim today As DateTime = DateTime.Now
        Select Case opcion
            Case 1
                Dim startBonifica As DateTime = firstDay
                Dim deadlineBonifica As DateTime = firstDay.AddDays((oConfigCierreFI.DiasPermitidosBonificacion - 1)).AddHours(23).AddMinutes(59)
                For period As Integer = 1 To periodosBonifica Step 1
                    If today.CompareTo(startBonifica) >= 0 And today.CompareTo(deadlineBonifica) <= 0 Then
                        Exit For
                    Else
                        Dim diff As Long = DateDiff(DateInterval.Day, deadlineBonifica, lastDay)
                        If resDiasMesBon < diff Then
                            startBonifica = deadlineBonifica.AddDays(1)
                            deadlineBonifica = deadlineBonifica.AddDays(oConfigCierreFI.DiasPermitidosBonificacion)
                        Else
                            deadlineBonifica = deadlineBonifica.AddDays(resDiasMesBon)
                        End If

                    End If
                Next
                'Valida que tipo los intentos en blue o karum
                Dim count As Integer
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    count = oFacturaMgr.GetTransaccionesDPCard(Card, startBonifica, deadlineBonifica, opcion)
                Else
                    count = oFacturaMgr.GetTransaccionesDPCardBlueFinal(Card, startBonifica, deadlineBonifica, opcion)
                End If


                'Dim count As Integer = oFacturaMgr.GetTransaccionesDPCard(Card, startBonifica, deadlineBonifica, opcion)
                If count < oConfigCierreFI.transaccionesPermitidasBonifica Then
                    valido = True
                End If
            Case 0
                Dim startCanje As DateTime = firstDay
                Dim deadlineCanje As DateTime = firstDay.AddDays((oConfigCierreFI.DiasPermitidosCanje - 1)).AddHours(23).AddMinutes(59)
                For period As Integer = 1 To periodosCanje Step 1
                    If today.CompareTo(startCanje) >= 0 And today.CompareTo(deadlineCanje) <= 0 Then
                        Exit For
                    Else
                        Dim diff As Long = DateDiff(DateInterval.Day, deadlineCanje, lastDay)
                        If resDiasMesCan < diff Then
                            startCanje = deadlineCanje.AddDays(1)
                            deadlineCanje = deadlineCanje.AddDays(oConfigCierreFI.DiasPermitidosCanje)
                        Else
                            deadlineCanje = deadlineCanje.AddDays(resDiasMesCan)
                        End If

                    End If
                Next
                'Valida que tipo los intentos en blue o karum
                Dim count As Integer
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    count = oFacturaMgr.GetTransaccionesDPCard(Card, startCanje, deadlineCanje, opcion)
                Else
                    count = oFacturaMgr.GetTransaccionesDPCardBlueFinal(Card, startCanje, deadlineCanje, opcion)
                End If


                If count < oConfigCierreFI.transaccionesPermitidasCanje Then
                    valido = True
                End If
        End Select

        Return valido
    End Function

    'Public Sub EnviarCorreoAlertaDPcard(ByVal subject As String, ByVal subject2 As String, ByVal transac As String, ByVal opcion As Integer)
    '    Try

    '        Dim mmMail As New MailMessage
    '        Dim objSmtpServer As SmtpMail
    '        Dim mail As String = ""
    '        Dim mails As String = ""

    '        For Each mail In oConfigCierreFI.CuentasCorreoAuditoria
    '            If Not mail Is Nothing AndAlso mail.Trim <> "" Then
    '                mails &= mail & ";"
    '            End If
    '        Next
    '        If oConfigCierreFI.MailGerenteOperaciones <> "" Then
    '            mail &= oConfigCierreFI.MailGerenteOperaciones & ";"
    '        End If
    '        If oConfigCierreFI.MailGerenteRegional <> "" Then
    '            mail &= oConfigCierreFI.MailGerenteRegional & ";"
    '        End If
    '        If oConfigCierreFI.MailGerentePlaza <> "" Then
    '            mail &= oConfigCierreFI.MailGerentePlaza & ";"
    '        End If

    '        mails &= oConfigCierreFI.CuentaCorreo.Trim & ";"
    '        mmMail.From = oConfigCierreFI.CuentaCorreo
    '        mmMail.To = mails
    '        mmMail.Subject = subject
    '        If opcion = 1 Then
    '            mmMail.Body = subject2 & vbNewLine &
    '            "El número de tarjeta ClubDP Lealtad número: " & Me.txtCardID.Text.Trim &
    '            " fue utilizada en la sucursal " & oAppContext.ApplicationConfiguration.Almacen &
    '            ", en la caja " & oAppContext.ApplicationConfiguration.NoCaja & ", por el player " &
    '            Me.player & ", con un monto de $" & CStr(Me.Params("TotalAmount")) & " para realizar un " & transac & " de puntos."

    '        Else
    '            mmMail.Body = subject2 & vbNewLine &
    '            "El número de tarjeta ClubDP Lealtad número: " & Me.txtCardID.Text.Trim &
    '            " fue utilizada en la sucursal " & oAppContext.ApplicationConfiguration.Almacen &
    '            ", en la caja " & oAppContext.ApplicationConfiguration.NoCaja & ", por el player " &
    '            Me.player & ", con un monto de $" & Me.txtImporteTotal.Value & " para realizar un " & transac & " de puntos."

    '        End If
    '        objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
    '        Try
    '            objSmtpServer.Send(mmMail)
    '        Catch ex As Exception
    '            EscribeLog(ex.ToString, "Error al enviar correo de Alertas DPCard")
    '        End Try
    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "Error al generar correo de Alertas DPCard")
    '    End Try
    'End Sub

    Public Sub EnviarCorreoAlertaDPcard(ByVal subject As String, ByVal subject2 As String, ByVal transac As String, ByVal opcion As Integer)
        Try

            'Dim mmMail As New MailMessage
            Dim objSmtpServer As SmtpMail
            Dim SmtpClient As New SmtpClient
            Dim Credencial As New NetworkCredential(oConfigCierreFI.CuentaCorreo, oConfigCierreFI.PasswordCorreo)
            Dim message As New System.Net.Mail.MailMessage()
            Dim Mail As New MailAddress(oConfigCierreFI.CuentaCorreo)
            Dim Body As String = ""

            SmtpClient.Host = oConfigCierreFI.ServidorSMTP
            SmtpClient.Port = oConfigCierreFI.PuertoSMTP
            SmtpClient.UseDefaultCredentials = False
            SmtpClient.Credentials = Credencial
            SmtpClient.EnableSsl = True

            message.From = Mail
            message.Subject = subject
            message.IsBodyHtml = False
            message.BodyEncoding = System.Text.Encoding.UTF8

            For Each MailAuditoria As String In oConfigCierreFI.CuentasCorreoAuditoria
                If Not MailAuditoria Is Nothing AndAlso MailAuditoria.Trim <> "" Then
                    message.To.Add(MailAuditoria)
                End If
            Next

            If oConfigCierreFI.MailGerenteOperaciones <> "" Then
                message.To.Add(oConfigCierreFI.MailGerenteOperaciones)
            End If

            If oConfigCierreFI.MailGerenteRegional <> "" Then
                message.To.Add(oConfigCierreFI.MailGerenteRegional)
            End If

            If oConfigCierreFI.MailGerentePlaza <> "" Then
                message.To.Add(oConfigCierreFI.MailGerentePlaza)
            End If
            If opcion = 1 Then
                Body = subject2 & vbNewLine &
                "El número de tarjeta ClubDP Lealtad número: " & Me.txtCardID.Text.Trim &
                " fue utilizada en la sucursal " & oAppContext.ApplicationConfiguration.Almacen &
                ", en la caja " & oAppContext.ApplicationConfiguration.NoCaja & ", por el player " &
                Me.player & ", con un monto de $" & CStr(Me.Params("TotalAmount")) & " para realizar un " & transac & " de puntos."

            Else
                Body = subject2 & vbNewLine &
                "El número de tarjeta ClubDP Lealtad número: " & Me.txtCardID.Text.Trim &
                " fue utilizada en la sucursal " & oAppContext.ApplicationConfiguration.Almacen &
                ", en la caja " & oAppContext.ApplicationConfiguration.NoCaja & ", por el player " &
                Me.player & ", con un monto de $" & Me.txtImporteTotal.Value & " para realizar un " & transac & " de puntos."

            End If
            message.Body = Body
            Try
                SmtpClient.Send(message)
            Catch ex As Exception
                EscribeLog(ex.ToString, "Error al enviar correo de Alertas DPCard")
            End Try
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al generar correo de Alertas DPCard")
        End Try
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Invoca el metodo de Blue Engine para activar la tarjeta.
    '-----------------------------------------------------------------------------------------------------------------------------

    Private Function ActivateDPCard() As Boolean
        Dim valido As Boolean = False
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim parameter As New Hashtable
        Dim resultado As Hashtable
        Try
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            Dim size As Integer = txtCardID.Text.Length
            Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
            If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                Me.Provider = Proveedor.KARUM
            Else
                Me.Provider = Proveedor.BLUE
            End If
            parameter("CardId") = Me.txtCardID.Text.Trim()
            parameter("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            parameter("TicketId") = CStr(Me.Params("TicketId"))
            '-----------------------------------------------------------------------------
            'FLIZARRAGA 02/09/2016: Correccion de Almacen (storeID)
            '-----------------------------------------------------------------------------
            If Me.Provider = Proveedor.BLUE Then
                parameter("storeid") = oAppContext.ApplicationConfiguration.Almacen
                parameter("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                parameter("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            Else
                parameter("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                parameter("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                parameter("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                If Deslizada = True Then
                    parameter("tipo") = "00"
                Else
                    parameter("tipo") = "01"
                End If
            End If
            parameter("ReferenceId3") = CStr(Me.Params("ReferenceId3"))
            If Me.Provider = Proveedor.BLUE Then
                parameter("ReferenceId4") = CStr(Me.Params("ReferenceId4"))
            Else
                Dim datos() As String = CStr(Me.Params("ReferenceId4")).Split(New Char() {"|"}, StringSplitOptions.RemoveEmptyEntries)
                If datos.Length > 2 Then
                    parameter("ReferenceId4") = datos(2)
                Else
                    parameter("ReferenceId4") = ""
                End If
            End If
            parameter("SupervisorCode") = CStr(Me.Params("SupervisorCode"))
            parameter("SupervisorName") = CStr(Me.Params("SupervisorName"))
            parameter("SellerCode") = CStr(Me.Params("SellerCode"))
            parameter("SellerName") = CStr(Me.Params("SellerName"))
            If Me.Provider = Proveedor.BLUE Then
                parameter("NoAssigned1") = CStr(Me.Params("NoAssigned1"))
                parameter("NoAssigned2") = CStr(Me.Params("NoAssigned2"))
            Else
                parameter("NoAssigned1") = oConfigCierreFI.ConsecutivoPuntosPOS
                parameter("NoAssigned2") = ""
            End If

            resultado = ws.Activate(parameter)
            'If Me.Provider = Proveedor.KARUM Then
            '    ActualizarConsecutivoPuntosPOS()
            'End If
            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultId") = True Then
                    If CInt(resultado("ResultId")) >= 0 Then
                        resultado("NoTienda") = oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                        If Me.Provider = Proveedor.KARUM Then
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                        Else
                            resultado("ConsecutivoPOS") = CStr(parameter("NoAssigned1")).PadLeft(4, "0")
                        End If
                        resultado("CardId") = Me.txtCardID.Text.Trim()
                        resultado("CodVendedor") = CStr(parameter("SellerCode"))
                        Me.DatosPuntos = New Hashtable()
                        AddValuesToHashable(Me.DatosPuntos, resultado)
                        If Not Me.ParamsAdd Is Nothing Then
                            CollectDPCardActivacion()
                        End If
                        valido = True
                        'Me.DatosPuntos = resultado
                    Else
                        Me.DatosPuntos = Nothing
                        valido = False
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Activar la tarjeta")
            valido = False
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2015: Invoca el metodo Collect de Blue Engine para la bonificación de puntos.
    '-----------------------------------------------------------------------------------------------------------------------------

    Private Function CollectDPCard() As Boolean
        Dim valido As Boolean = False
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        Try
            'wgomez quitar validacion de 16 digitos 
            'EscribeLog("Validamos si la tarjeta tiene 16 caracteres", "Bonificacion")
            If txtCardID.Text.Length = 16 Or txtCardID.Text.Length = 13 Then
                EscribeLog("si tiene 16 digitos", "Bonificacion")
                Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                EscribeLog("Obtuvo el bin", "Bonificacion")
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        EscribeLog("Es karum", "Bonificacion")
                        Me.Provider = Proveedor.KARUM
                    Else
                        EscribeLog("Es blue", "Bonificacion")
                        Me.Provider = Proveedor.BLUE
                    End If
                Else
                    EscribeLog("Es blue", "Bonificacion")
                    Me.Provider = Proveedor.BLUE
                End If

                CardId = Me.txtCardID.Text
            Else
                EscribeLog("no tiene 16 digitos", "Bonificacion")
                Me.Provider = Proveedor.KARUM
                CardId = Me.txtCardID.Text.PadLeft(16, "0")
                Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            'If Me.Provider = Proveedor.KARUM AndAlso Me.PagoDPCard = True Then
            '    Me.ErrorDPCard = "Los puntos ya fueron acumulados en la venta"
            '    Exit Function
            'End If
            EscribeLog("Antes de fecha", "Bonificacion")
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            EscribeLog("Despues de fecha", "Bonificacion")
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then


                params("CardId") = CardId
                'params("CardId") = Me.txtCardID.Text.Trim()
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("Amount") = CStr(Me.Params("Amount"))
                params("TotalAmount") = CStr(Me.Params("TotalAmount"))
                params("TicketId") = CStr(Me.Params("TicketId"))
                EscribeLog("Carga datos basicos", "Bonificacion")
                '-----------------------------------------------------------------------------
                'FLIZARRAGA 02/09/2016: Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                If Me.Provider = Proveedor.BLUE Then
                    EscribeLog("Empieza datos blue", "Bonificacion")
                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    EscribeLog("Termina datos de blue", "Bonificacion")
                Else
                    EscribeLog("Empieza datos karum", "Bonificacion")
                    params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    If Deslizada = True Then
                        params("tipo") = "00"
                    Else
                        params("tipo") = "01"
                    End If
                    EscribeLog("Termina datos karum", "Bonificacion")
                End If
                'params("StoreId") = "004"
                '-----------------------------------------------------------------------------
                params("Products") = CStr(Me.Params("Products"))
                params("ReferenceId3") = "" 'CStr(Me.Params("FormasPago"))
                params("ReferenceId4") = CStr(Me.Params("ReferenciaId4"))
                params("SupervisorCode") = CStr(Me.Params("SupervisorCode"))
                params("SupervisorName") = CStr(Me.Params("SupervisorName"))
                params("SellerCode") = CStr(Me.Params("SellerCode"))
                params("SellerName") = CStr(Me.Params("SellerName"))
                params("NoAssigned1") = CStr(Me.Params("NoAssigned"))
                EscribeLog("Datos basicos de bonificacion 2", "Bonificacion")
                If Me.Provider = Proveedor.KARUM Then
                    params("ReferenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS.PadLeft(4, "0")
                End If
                params("NoAssigned2") = CStr(Me.Params("NoAssigned2"))
                If Me.Provider = Proveedor.BLUE Then
                    EscribeLog("Dispara evento blue", "Bonificacion")
                    resultado = ws.ValidateDPCardPuntos(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) > 0 Then
                                params("ReferenceId3") = CStr(Me.Params("FormasPago"))
                                resultado = ws.Collect(params)
                                If resultado.Count > 0 Then
                                    If resultado.ContainsKey("ResultID") = True Then
                                        EscribeLog("Evento blue exitoso", "Bonificacion")
                                        EscribeLog(CStr(resultado("ResultID")), "Bonificacion")
                                        If CStr(resultado("ResultID")).Trim() <> "" Then
                                            If CInt(resultado("ResultID")) >= 0 Then
                                                PrintHashtable(resultado)
                                                resultado("CardId") = Me.txtCardID.Text.Trim()
                                                Me.DatosPuntos = resultado
                                            Else
                                                If CInt(resultado("ResultID")) = -27 Then
                                                    oAppContext.Security.CloseImpersonatedSession()
                                                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Bonificacion") = True Then
                                                        params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                                        resultado = ws.Collect(params)
                                                        If resultado.Count > 0 Then
                                                            If resultado.ContainsKey("ResultID") = True Then
                                                                If CInt(resultado("ResultID")) > 0 Then
                                                                    PrintHashtable(resultado)
                                                                    resultado("CardId") = Me.txtCardID.Text.Trim()
                                                                    Me.DatosPuntos = resultado
                                                                    valido = True
                                                                Else
                                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            End If
                                                        End If
                                                    Else
                                                        params("CardId") = ""
                                                        resultado = ws.Collect(params)
                                                        If resultado.Count > 0 Then
                                                            If resultado.ContainsKey("ResultID") = True Then
                                                                If CInt(resultado("ResultID")) > 0 Then
                                                                    PrintHashtable(resultado)
                                                                    resultado("CardId") = Me.txtCardID.Text.Trim()
                                                                    Me.DatosPuntos = resultado
                                                                    valido = True
                                                                Else
                                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                    oAppContext.Security.CloseImpersonatedSession()
                                                Else
                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If

                                            End If
                                        Else
                                            MessageBox.Show("Ocurrió un error al consultar el saldo de puntos.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    End If
                                End If
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                ElseIf Me.Provider = Proveedor.KARUM Then
                    EscribeLog("dispara evento karum", "Bonificacion")
                    resultado = ws.Collect(params)
                    'ActualizarConsecutivoPuntosPOS()
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultId") Then
                            If CInt(resultado("ResultId")) > 0 Then
                                EscribeLog("Evento karum exitoso", "Bonificacion")
                                resultado("CardId") = Me.txtCardID.Text.Trim()
                                resultado("CustomerName") = CustomerName
                                resultado("BonusAmount") = CStr(Me.Params("TotalAmount"))
                                '-----------------------------------------------------------
                                'FLIZARRAGA 30/10/2017: Consecutivo POS
                                '-----------------------------------------------------------
                                resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                                Me.DatosPuntos = resultado
                                Success = True
                                valido = True
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                    ''----------------------------------------------------------------------------------------------------------------
                    ''FLIZARRAGA 23/03/2017: Se valida que la tarjeta este activa
                    ''----------------------------------------------------------------------------------------------------------------
                    'Dim AccountStatus = New Hashtable
                    'Dim status As New Hashtable
                    'AccountStatus("cardId") = CardId
                    'AccountStatus("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    'AccountStatus("ticketid") = ""
                    'AccountStatus("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    'AccountStatus("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    'AccountStatus("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                    'If Deslizada = True Then
                    '    AccountStatus("tipo") = "00"
                    'Else
                    '    AccountStatus("tipo") = "01"
                    'End If
                    'AccountStatus("cashierCode") = oAppContext.Security.CurrentUser.ID
                    'AccountStatus("cashierName") = oAppContext.Security.CurrentUser.Name.Trim
                    'AccountStatus("supervisorCode") = oAppContext.Security.CurrentUser.ID
                    'AccountStatus("supervisorName") = oAppContext.Security.CurrentUser.Name.Trim
                    'AccountStatus("sellerCode") = oAppContext.Security.CurrentUser.ID
                    'AccountStatus("sellerName") = oAppContext.Security.CurrentUser.Name.Trim
                    'status = ws.GetBalance(AccountStatus)
                    ''ActualizarConsecutivoPuntosPOS()
                    'If status.Count > 0 Then
                    '    If status.ContainsKey("ResultId") Then
                    '        If CInt(status("ResultId")) > 0 Then
                    '            resultado = ws.Collect(params)
                    '            'ActualizarConsecutivoPuntosPOS()
                    '            If resultado.Count > 0 Then
                    '                If resultado.ContainsKey("ResultId") Then
                    '                    If CInt(resultado("ResultId")) > 0 Then
                    '                        resultado("CardId") = Me.txtCardID.Text.Trim()
                    '                        resultado("ConsecutivoPOS") = params("ReferenceId4")
                    '                        Me.DatosPuntos = resultado
                    '                    Else
                    '                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '                    End If
                    '                End If
                    '            End If
                    '        End If
                    '    End If
                    'End If
                End If
            Else
                '05/04/2021 nueva bonificación de puntos BLUE collect
                Dim tipo_ As String = String.Empty
                tipo_ = consulta_bin_tipo_blue(CardId)
                If tipo_.Trim() = "DB" Then
                    params("CardId") = CardId
                    'params("CardId") = Me.txtCardID.Text.Trim()
                    params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("Amount") = CStr(Me.Params("Amount"))
                    params("TotalAmount") = CStr(Me.Params("TotalAmount"))
                    params("TicketId") = CStr(Me.Params("TicketId"))
                    EscribeLog("Carga datos basicos", "Bonificacion")
                    EscribeLog("Empieza datos blue", "Bonificacion")
                    params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                    params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    EscribeLog("Termina datos de blue", "Bonificacion")
                    params("Products") = CStr(Me.Params("Products"))
                    params("ReferenceId3") = "" 'CStr(Me.Params("FormasPago"))
                    params("ReferenceId4") = CStr(Me.Params("ReferenciaId4"))
                    params("SupervisorCode") = CStr(Me.Params("SupervisorCode"))
                    params("SupervisorName") = CStr(Me.Params("SupervisorName"))
                    params("SellerCode") = CStr(Me.Params("SellerCode"))
                    params("SellerName") = CStr(Me.Params("SellerName"))
                    params("NoAssigned1") = CStr(Me.Params("NoAssigned"))
                    EscribeLog("Datos basicos de bonificacion 2", "Bonificacion")
                    params("NoAssigned2") = CStr(Me.Params("NoAssigned2"))
                    EscribeLog("Dispara evento blue", "Bonificacion")
                    resultado = ws.ValidateDPCardPuntos(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) > 0 Then
                                params("ReferenceId3") = CStr(Me.Params("FormasPago"))
                                resultado = ws.Collect(params)
                                If resultado.Count > 0 Then
                                    If resultado.ContainsKey("ResultID") = True Then
                                        EscribeLog("Evento blue exitoso", "Bonificacion")
                                        EscribeLog(CStr(resultado("ResultID")), "Bonificacion")
                                        If CStr(resultado("ResultID")).Trim() <> "" Then
                                            If CInt(resultado("ResultID")) >= 0 Then
                                                PrintHashtable(resultado)
                                                resultado("CardId") = Me.txtCardID.Text.Trim()
                                                Me.DatosPuntos = resultado
                                            Else
                                                If CInt(resultado("ResultID")) = -27 Then
                                                    oAppContext.Security.CloseImpersonatedSession()
                                                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Bonificacion") = True Then
                                                        params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                                        resultado = ws.Collect(params)
                                                        If resultado.Count > 0 Then
                                                            If resultado.ContainsKey("ResultID") = True Then
                                                                If CInt(resultado("ResultID")) > 0 Then
                                                                    PrintHashtable(resultado)
                                                                    resultado("CardId") = Me.txtCardID.Text.Trim()
                                                                    Me.DatosPuntos = resultado
                                                                    valido = True
                                                                Else
                                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            End If
                                                        End If
                                                    Else
                                                        params("CardId") = ""
                                                        resultado = ws.Collect(params)
                                                        If resultado.Count > 0 Then
                                                            If resultado.ContainsKey("ResultID") = True Then
                                                                If CInt(resultado("ResultID")) > 0 Then
                                                                    PrintHashtable(resultado)
                                                                    resultado("CardId") = Me.txtCardID.Text.Trim()
                                                                    Me.DatosPuntos = resultado
                                                                    valido = True
                                                                Else
                                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                    oAppContext.Security.CloseImpersonatedSession()
                                                Else
                                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If

                                            End If
                                        Else
                                            MessageBox.Show("Ocurrió un error al consultar el saldo de puntos.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    End If
                                End If
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetCollect As Dictionary(Of String, Object)
                    oBluegetCollect = New Dictionary(Of String, Object)
                    oBluegetCollect.Add("cardId", CardId.Trim())
                    oBluegetCollect.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                    oBluegetCollect.Add("amount", CStr(Me.Params("Amount")))
                    oBluegetCollect.Add("totalAmount", CStr(Me.Params("TotalAmount")))
                    oBluegetCollect.Add("ticketId", CStr(Me.Params("TicketId")))
                    oBluegetCollect.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    oBluegetCollect.Add("referenceId3", CStr(Me.Params("FormasPago")))
                    oBluegetCollect.Add("referenceId4", CStr(Me.Params("ReferenciaId4")))
                    oBluegetCollect.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                    oBluegetCollect.Add("supervisorCod", CStr(Me.Params("SupervisorCode")))
                    oBluegetCollect.Add("supervisorName", CStr(Me.Params("SupervisorName")))
                    oBluegetCollect.Add("sellerCode", CStr(Me.Params("SellerCode")))
                    oBluegetCollect.Add("sellerName", CStr(Me.Params("SellerName")))
                    oBluegetCollect.Add("products", CStr(Me.Params("Products")))
                    'oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                    oBluegetCollect.Add("version", "X")


                    Dim ws_1 As New WSBroker("blue_api_s1", "Collect")
                    Dim rs_ As Dictionary(Of String, Object)
                    'MessageBox.Show(oBluegetCollect.ToString())
                    resultado = ws_1.nuevos_servicios_blue(oBluegetCollect)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) > 0 Then
                                PrintHashtable(resultado)
                                resultado("CustomerName") = CustomerName
                                resultado("ConsecutivoPOS") = CStr(resultado("ResultID"))
                                resultado("CardId") = Me.txtCardID.Text.Trim()
                                Me.DatosPuntos = New Hashtable()
                                AddValuesToHashable(Me.DatosPuntos, resultado)
                                Me.DatosPuntos = resultado
                                Success = True
                                valido = True
                                oAppContext.Security.CloseImpersonatedSession()
                            Else
                                MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EscribeLog(CStr(resultado("Description")) + " - en el servicio de collect blue" + oBluegetCollect.ToString(), "Bonificacion WS Collect Blue")
                            End If

                        End If


                    Else

                    End If

                End If

            End If

        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Bonificar Puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/04/2015: Consultamos la tarjeta de DPCard Puntos para obtener su total de puntos.
    '----------------------------------------------------------------------------------------------------------------------------

    Public Sub GetBalanceDPCard()
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        '31/03/2021 ASANCHEZ agregue la nueva variable de tipo_
        Dim tipo_ As String = String.Empty
        Try
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
            '----------------------------------------------------------------------------------------------------------------------
            If Me.txtCardID.Text.Length = 16 Or Me.txtCardID.Text.Length = 13 Then
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Me.Provider = Proveedor.KARUM
                    Else
                        Me.Provider = Proveedor.BLUE
                    End If
                Else
                    If Me.txtCardID.Text.Trim().Length = 13 Then
                        tipo_ = "CFB"
                    Else
                        tipo_ = consulta_bin_tipo_blue(Me.txtCardID.Text.Trim())
                    End If
                    'tipo_ = consulta_bin_tipo_blue(Me.txtCardID.Text.Trim())
                End If
                CardId = Me.txtCardID.Text
            Else
                Me.Provider = Proveedor.KARUM
                CardId = Me.txtCardID.Text.PadLeft(16, "0")
                'Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            '31/03/2021 ASANCHEZ valida si est activa el nuevo servicio de BLUE
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then


                params("cardId") = CardId
                'params("cardId") = Me.txtCardID.Text.Trim()
                params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("ticketid") = ""
                '----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
                '----------------------------------------------------------------------------------------------------------------------
                If Me.Provider = Proveedor.BLUE Then
                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                Else
                    params("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    params("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    If Deslizada = True Then
                        params("tipo") = "00"
                    Else
                        params("tipo") = "01"
                    End If
                End If
                'params("storeid") = "004"
                '-----------------------------------------------------------------------------

                params("supervisorCode") = CStr(Me.Params("SupervisorCode"))
                params("supervisorName") = CStr(Me.Params("SupervisorName"))
                params("sellerCode") = CStr(Me.Params("SellerCode"))
                params("sellerName") = CStr(Me.Params("SellerName"))
                resultado = ws.GetBalance(params)
                'If Me.Provider = Proveedor.KARUM Then
                '    ActualizarConsecutivoPuntosPOS()
                'End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultId") = True Then
                        If CInt(resultado("ResultId")) > 0 Then

                            '-----------------------------------------------------------------------------
                            'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                            '-----------------------------------------------------------------------------
                            CustomerName = CStr(resultado("CustomerName"))

                            '-----------------------------------------------------------------------------------------------
                            'MLVARGAS (22.11.2019): Tomar el nombre del cliente para almacenar en  TransaccionesSinTarjetas
                            '-----------------------------------------------------------------------------------------------
                            sClientName = CStr(resultado("CustomerName"))

                            '-----------------------------------------------------------------------------------------------
                            'JNAVA (17.11.2016): Validamos el proveedor para obtener los puntos
                            '-----------------------------------------------------------------------------
                            If Me.Provider = Proveedor.KARUM Then
                                '-----------------------------------------------------------------------------
                                '  Validamos si los puntos y el saldo son numerico o no
                                '-----------------------------------------------------------------------------
                                If IsNumeric(resultado("SaldoPuntos").ToString.Trim) Then
                                    Me.txtTotalPuntos.Text = CDec(resultado("SaldoPuntos")).ToString()
                                Else
                                    Me.txtTotalPuntos.Text = 0
                                End If
                                If IsNumeric(resultado("SaldoDinero").ToString.Trim) Then
                                    Me.txtSaldo.Text = Format(CDec(resultado("SaldoDinero")), "c")
                                Else
                                    Me.txtSaldo.Text = 0
                                End If
                            Else
                                Me.txtTotalPuntos.Text = CDec(resultado("BalancePoints")).ToString()
                                Me.txtSaldo.Text = Format(CDec(resultado("BalanceAmount")), "c")
                            End If
                            '-----------------------------------------------------------------------------

                            If Me.Provider = Proveedor.BLUE Then
                                Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                                Dim mensaje As String = CStr(resultado("PersonalMessage"))
                                If mensaje <> "" Then
                                    MessageBox.Show(CStr(resultado("PersonalMessage")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Else
                                Me.txtStatus.Enabled = False
                                Me.cmbFechaActivacion.Enabled = False
                                Me.cmbFechaExpiracion.Enabled = False
                                Me.txtClienteID.Enabled = False
                                Me.txtNombreCliente.Enabled = False
                                ' MLVARGAS (17/03/2020): Mostrar los datos del cliente para tarjetas de KARUM
                                Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                            End If
                            Me.txtImporteTotal.Focus()

                        Else
                            MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                'validamos el tipo que nos regresa el servicio de bin
                If tipo_.Trim() = "DB" Then
                    params("cardId") = CardId
                    'params("cardId") = Me.txtCardID.Text.Trim()
                    params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("ticketid") = ""
                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    params("supervisorCode") = CStr(Me.Params("SupervisorCode"))
                    params("supervisorName") = CStr(Me.Params("SupervisorName"))
                    params("sellerCode") = CStr(Me.Params("SellerCode"))
                    params("sellerName") = CStr(Me.Params("SellerName"))
                    resultado = ws.GetBalance(params)
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultId") = True Then
                            If CInt(resultado("ResultId")) > 0 Then

                                '-----------------------------------------------------------------------------
                                'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                                '-----------------------------------------------------------------------------
                                CustomerName = CStr(resultado("CustomerName"))

                                '-----------------------------------------------------------------------------------------------
                                'MLVARGAS (22.11.2019): Tomar el nombre del cliente para almacenar en  TransaccionesSinTarjetas
                                '-----------------------------------------------------------------------------------------------
                                sClientName = CStr(resultado("CustomerName"))

                                '-----------------------------------------------------------------------------------------------
                                'JNAVA (17.11.2016): Validamos el proveedor para obtener los puntos
                                '-----------------------------------------------------------------------------
                                If Me.Provider = Proveedor.KARUM Then
                                    '-----------------------------------------------------------------------------
                                    '  Validamos si los puntos y el saldo son numerico o no
                                    '-----------------------------------------------------------------------------
                                    If IsNumeric(resultado("SaldoPuntos").ToString.Trim) Then
                                        Me.txtTotalPuntos.Text = CDec(resultado("SaldoPuntos")).ToString()
                                    Else
                                        Me.txtTotalPuntos.Text = 0
                                    End If
                                    If IsNumeric(resultado("SaldoDinero").ToString.Trim) Then
                                        Me.txtSaldo.Text = Format(CDec(resultado("SaldoDinero")), "c")
                                    Else
                                        Me.txtSaldo.Text = 0
                                    End If
                                Else
                                    Me.txtTotalPuntos.Text = CDec(resultado("BalancePoints")).ToString()
                                    Me.txtSaldo.Text = Format(CDec(resultado("BalanceAmount")), "c")
                                End If
                                '-----------------------------------------------------------------------------


                                Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                                Dim mensaje As String = CStr(resultado("PersonalMessage"))
                                If mensaje <> "" Then
                                    MessageBox.Show(CStr(resultado("PersonalMessage")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                Me.txtImporteTotal.Focus()

                            Else
                                MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetBalance As Dictionary(Of String, Object)
                    oBluegetBalance = New Dictionary(Of String, Object)
                    oBluegetBalance.Add("cardId", CardId)
                    'oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                    oBluegetBalance.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))
                    oBluegetBalance.Add("ticketId", "")
                    oBluegetBalance.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    oBluegetBalance.Add("referenceId3", "")
                    oBluegetBalance.Add("referenceId4", "")
                    oBluegetBalance.Add("cashierCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("supervisorCod", oAppContext.Security.CurrentUser.Name.Trim)
                    oBluegetBalance.Add("supervisorName", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerName", oAppContext.Security.CurrentUser.Name.Trim)
                    Dim ws_1 As New WSBroker("blue_api_s1", "GetBalance")
                    Dim rs_ As Dictionary(Of String, Object)
                    resultado = ws_1.nuevos_servicios_blue(oBluegetBalance)
                    If resultado.Count = 0 Then
                        MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) < 0 Then
                                If CInt(resultado("ResultID")) = -1 Then
                                    MessageBox.Show("Tarjeta no es válida, favor de generar tarjeta en Portal.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Else
                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                'MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                CustomerName = CStr(resultado("CustomerName"))
                                sClientName = CStr(resultado("CustomerName"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerID"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))

                                Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerID"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                                Me.txtTotalPuntos.Text = CDec(resultado("BalancePoints")).ToString()
                                Me.txtSaldo.Text = Format(CDec(resultado("BalanceAmount")), "c")

                            End If
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al obtener el saldo de puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/04/2015: Valida si la tarjeta es valida para renovación.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Function ValidateCardIdExpire() As Boolean
        Dim valido As Boolean = False
        GetBalanceDPCard()
        Dim hoy As DateTime = DateTime.Now
        Dim expiracion As DateTime = CDate(Me.cmbFechaExpiracion.Value)
        Dim dif As Long = DateDiff(DateInterval.Month, hoy, expiracion)
        If dif <= 2 Then
            valido = True
        Else
            MessageBox.Show("La tarjeta no ha expirado todavia", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCardID.Focus()
        End If
        Return valido
    End Function


    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/04/2014: Envia el pago para ser agregado a las formas de pago.
    '----------------------------------------------------------------------------------------------------------------------------
    Private Sub CanjearPuntos()
        Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
        monto = Me.txtImporteTotal.Value
        oFactMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        If Me.txtCardID.Text.Trim() = "" Then
            MessageBox.Show("El número de tarjeta esta vacio", "Club DP Lealtad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If oConfigCierreFI.alertUsoCanje Then
            Dim card_number As String
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                card_number = Me.txtCardID.Text.Trim.Remove(0, 4)
            Else
                card_number = Me.txtCardID.Text.Trim()
            End If
            If validaTransaccionesDPCard(card_number, 0) Then
                If Me.txtImporteTotal.Value <= 0 Then
                    MessageBox.Show("El importe debe ser mayor a 0", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                ElseIf Me.txtSaldo.Value <= 0 Then
                    RegistraTransaccionInconclusa("Canje", bin)
                    MessageBox.Show("La tarjeta no tiene saldo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                'If Me.txtImporteTotal.Value > txtSaldo.Value Then
                '    MessageBox.Show("El importe debe ser menor o igual al Saldo obtenido de los puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Return
                'End If
                Select Case Me.operacion
                    Case DPCardOperation.CANJEAR
                        Dim resultado As New Hashtable
                        resultado("CardId") = Me.txtCardID.Text.Trim()
                        resultado("CodFormasPago") = "DPPT"
                        resultado("Monto") = txtImporteTotal.Value
                        resultado("NombreCliente") = m_NombreCliente
                        resultado("CustomerName") = CustomerName
                        If Deslizada = True Then
                            resultado("tipo") = "00"
                        Else
                            resultado("tipo") = "01"
                        End If
                        Me.DatosPuntos = resultado
                        Me.DialogResult = DialogResult.OK


                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                            'MLVARGAS (11/11/2019): Si la tarjeta fue tecleada grabar a la tabla de TransaccionSinTarjeta   
                            If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
                                Dim idTransaccion As Integer = 0
                                idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                     Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                lstIds.Add(idTransaccion)
                            End If
                        Else
                            Dim tipo_ As String = String.Empty
                            tipo_ = consulta_bin_tipo_blue(Me.txtCardID.Text.Trim())

                            Dim idTransaccion As Integer = 0
                            If Deslizada = False AndAlso tipo_ = "CFB" AndAlso ReadQr = False Then
                                idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                lstIds.Add(idTransaccion)
                            End If

                        End If


                        Me.accion = True
                        Me.Dispose()
                    Case DPCardOperation.CANJEARSIHAY
                        Dim ws As New WSBroker("WS_BLUE", True)
                        Dim params As New Hashtable
                        Dim resultado As Hashtable

                End Select
            Else
                MessageBox.Show("Tarjeta en revisión. Número de transacciones excedido.", "Revisión Tarjeta Lealtad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show("No se pudo realizar el canje de puntos.", "Canje de Puntos NO exitoso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                EnviarCorreoAlertaDPcard("Tarjeta de Lealtad con canje de puntos excedida", "Tarjeta de Lealtad con canje de puntos excedida", "canje", 0)
                If MessageBox.Show("¿Deseas autorizar la transacción para canje?", "Autorización de Alerta de uso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Autorizacion") = True Then
                        If Me.txtImporteTotal.Value <= 0 Then
                            MessageBox.Show("El importe debe ser mayor a 0", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        ElseIf Me.txtSaldo.Value <= 0 Then
                            MessageBox.Show("La tarjeta no tiene saldo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            RegistraTransaccionInconclusa("Canje", bin)
                            Return
                        End If
                        'If Me.txtImporteTotal.Value > txtSaldo.Value Then
                        '    MessageBox.Show("El importe debe ser menor o igual al Saldo obtenido de los puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    Return
                        'End If
                        Select Case Me.operacion
                            Case DPCardOperation.CANJEAR
                                Dim resultado As New Hashtable
                                resultado("CardId") = Me.txtCardID.Text.Trim()
                                resultado("CodFormasPago") = "DPPT"
                                resultado("Monto") = txtImporteTotal.Value
                                resultado("NombreCliente") = m_NombreCliente
                                resultado("CustomerName") = CustomerName
                                If Deslizada = True Then
                                    resultado("tipo") = "00"
                                Else
                                    resultado("tipo") = "01"
                                End If
                                Me.DatosPuntos = resultado
                                Me.DialogResult = DialogResult.OK

                                'MLVARGAS (11/11/2019): Si la tarjeta fue tecleada grabar a la tabla de TransaccionSinTarjeta                                
                                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                                    If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
                                        Dim idTransaccion As Integer = 0

                                        idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                             Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                        lstIds.Add(idTransaccion)
                                    End If
                                Else
                                    Dim tipo_ As String = String.Empty
                                    tipo_ = consulta_bin_tipo_blue(Me.txtCardID.Text.Trim())
                                    'If tipo_.Trim() = "DB" Then
                                    Dim idTransaccion As Integer = 0
                                    If Deslizada = False AndAlso tipo_ = "CFB" AndAlso ReadQr = False Then
                                        idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                         Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                                        lstIds.Add(idTransaccion)
                                    End If

                                End If


                                Me.accion = True
                                Me.Dispose()
                            Case DPCardOperation.CANJEARSIHAY
                                Dim ws As New WSBroker("WS_BLUE", True)
                                Dim params As New Hashtable
                                Dim resultado As Hashtable

                        End Select
                        Me.Autorizado = True
                        userAuth = oAppContext.Security.CurrentUser.SessionLoginName
                    Else
                        Me.DialogResult = DialogResult.Cancel
                        Me.accion = False
                        Me.Dispose()
                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                Else
                    RegistraTransaccionInconclusa("Canje", bin)
                    Me.DialogResult = DialogResult.Cancel
                    Me.accion = False
                    Me.Dispose()
                End If
            End If
        Else
            If Me.txtImporteTotal.Value <= 0 Then
                MessageBox.Show("El importe debe ser mayor a 0", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            ElseIf Me.txtSaldo.Value <= 0 Then
                RegistraTransaccionInconclusa("Canje", bin)
                MessageBox.Show("La tarjeta no tiene saldo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            'If Me.txtImporteTotal.Value > txtSaldo.Value Then
            '    MessageBox.Show("El importe debe ser menor o igual al Saldo obtenido de los puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return
            'End If
            Select Case Me.operacion
                Case DPCardOperation.CANJEAR
                    Dim resultado As New Hashtable
                    resultado("CardId") = Me.txtCardID.Text.Trim()
                    resultado("CodFormasPago") = "DPPT"
                    resultado("Monto") = txtImporteTotal.Value
                    resultado("NombreCliente") = m_NombreCliente
                    resultado("CustomerName") = CustomerName
                    If Deslizada = True Then
                        resultado("tipo") = "00"
                    Else
                        resultado("tipo") = "01"
                    End If
                    Me.DatosPuntos = resultado
                    Me.DialogResult = DialogResult.OK


                    If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                        'MLVARGAS (29/11/2019): Si la tarjeta fue tecleada grabar a la tabla de TransaccionSinTarjeta
                        If Deslizada = False AndAlso oFactMgr.IsDPCardPuntosKarum(bin) AndAlso ReadQr = False Then
                            Dim idTransaccion As Integer = 0
                            idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                                 Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                            If idTransaccion <> 0 Then
                                lstIds.Add(idTransaccion)
                            End If
                        End If
                    Else
                        Dim tipo_ As String = String.Empty
                        tipo_ = consulta_bin_tipo_blue(Me.txtCardID.Text.Trim())
                        'If tipo_.Trim() = "DB" Then
                        Dim idTransaccion As Integer = 0
                        If Deslizada = False AndAlso tipo_ = "CFB" AndAlso ReadQr = False Then
                            idTransaccion = oFactMgr.AddTransaccionSinTarjeta(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja, String.Empty, _
                                             Me.txtCardID.Text, monto, "Canje", "Transacción inconclusa", sClientName, m_Motivo, codVendedor, userAuth)
                            lstIds.Add(idTransaccion)
                        End If
                    End If


                    Me.accion = True
                    Me.Dispose()
                Case DPCardOperation.CANJEARSIHAY
                    Dim ws As New WSBroker("WS_BLUE", True)
                    Dim params As New Hashtable
                    Dim resultado As Hashtable

            End Select
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2015: Busqueda de Tarjeta por medio del apellido paterno y los ultimos 4 digitos del telefono
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Busqueda()
        Dim frmSearch As New frmDPCardPuntoSearch
        frmSearch.ShowDialog()
        If frmSearch.DialogResult = DialogResult.OK Then
            Me.txtCardID.Text = frmSearch.CardId
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/04/2015: Renovacion de Membresia de DPCard Puntos
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub RenewMembership()
        Try
            If Me.txtCardID.Text.Trim() <> "" Then
                Dim resultado As New Hashtable
                resultado("CardId") = Me.txtCardID.Text.Trim()
                Me.DatosPuntos = resultado
                Me.DialogResult = DialogResult.OK
                accion = True
                Me.Dispose()
            Else
                MessageBox.Show("Tiene que digitalizar o deslizar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al pedir los datos de renovación")
        End Try
        'Dim ws As New WSBroker("WS_BLUE")
        'Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        'Dim params As New Hashtable
        'Dim resultado As Hashtable
        'Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        'params("CardId") = Me.txtNewCardID.Text.Trim()
        'params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
        'params("ticketid") = CStr(Me.Params("TicketId"))
        'params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
        'params("ReferenceId3") = ""
        'params("ReferenceId4") = ""
        'params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
        'params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
        'params("SupervisorCode") = CStr(Me.Params("SupervisorCode"))
        'params("SupervisorName") = CStr(Me.Params("SupervisorName"))
        'params("SellerCode") = CStr(Me.Params("SellerCode"))
        'params("SellerName") = CStr(Me.Params("SellerName"))
        'params("Amount") = CStr(Me.Params("Amount"))
        'resultado = ws.RenewMembership(params)
        'If resultado.Count > 0 Then
        '    If resultado.ContainsKey("ResultID") = True Then
        '        If CInt(resultado("ResultID")) >= 0 Then
        '            Me.DatosPuntos("CardId") = Me.txtNewCardID.Text.Trim()
        '            Me.DialogResult = DialogResult.OK
        '            accion = True
        '            Me.Dispose()
        '        Else
        '            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End If
        'End If
    End Sub

#End Region

#Region "Activación de tarjeta y acumulación de puntos"

    Private Function CollectDPCardActivacion() As Boolean
        Dim valido As Boolean = False
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        Try
            If txtCardID.Text.Length = 16 Then
                Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                    Me.Provider = Proveedor.KARUM
                Else
                    Me.Provider = Proveedor.BLUE
                End If
                CardId = Me.txtCardID.Text
            Else
                Me.Provider = Proveedor.KARUM
                CardId = Me.txtCardID.Text.PadLeft(16, "0")
                'Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
            params("CardId") = CardId
            'params("CardId") = Me.txtCardID.Text.Trim()
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            params("Amount") = CStr(Me.ParamsAdd("Amount"))
            params("TotalAmount") = CStr(Me.ParamsAdd("TotalAmount"))
            params("TicketId") = CStr(Me.ParamsAdd("TicketId"))
            '-----------------------------------------------------------------------------
            'FLIZARRAGA 02/09/2016: Correccion de Almacen (storeID)
            '-----------------------------------------------------------------------------
            If Me.Provider = Proveedor.BLUE Then
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja

            Else
                params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                If Deslizada = True Then
                    params("tipo") = "00"
                Else
                    params("tipo") = "01"
                End If
            End If
            'params("StoreId") = "004"
            '-----------------------------------------------------------------------------
            params("Products") = CStr(Me.ParamsAdd("Products"))
            params("ReferenceId3") = "" 'CStr(Me.Params("FormasPago"))
            params("ReferenceId4") = CStr(Me.ParamsAdd("ReferenciaId4"))
            params("SupervisorCode") = CStr(Me.ParamsAdd("SupervisorCode"))
            params("SupervisorName") = CStr(Me.ParamsAdd("SupervisorName"))
            params("SellerCode") = CStr(Me.ParamsAdd("SellerCode"))
            params("SellerName") = CStr(Me.ParamsAdd("SellerName"))
            params("NoAssigned1") = CStr(Me.ParamsAdd("NoAssigned"))
            If Me.Provider = Proveedor.KARUM Then
                params("ReferenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS.PadLeft(4, "0")
            End If
            params("NoAssigned2") = CStr(Me.ParamsAdd("NoAssigned2"))
            If Me.Provider = Proveedor.BLUE Then
                resultado = ws.ValidateDPCardPuntos(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) > 0 Then
                            params("ReferenceId3") = CStr(Me.ParamsAdd("FormasPago"))
                            resultado = ws.Collect(params)
                            If resultado.Count > 0 Then
                                If resultado.ContainsKey("ResultID") = True Then
                                    If CInt(resultado("ResultID")) >= 0 Then
                                        PrintHashtable(resultado)
                                        resultado("CardId") = Me.txtCardID.Text.Trim()
                                        Me.DatosPuntosActivacion = New Hashtable()
                                        AddValuesToHashable(Me.DatosPuntosActivacion, resultado)
                                        'Me.DatosPuntos = resultado
                                    Else
                                        If CInt(resultado("ResultID")) = -27 Then
                                            oAppContext.Security.CloseImpersonatedSession()
                                            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Bonificacion") = True Then
                                                params("ReferenceId4") = oAppContext.Security.CurrentUser.SessionLoginName.Trim
                                                resultado = ws.Collect(params)
                                                If resultado.Count > 0 Then
                                                    If resultado.ContainsKey("ResultID") = True Then
                                                        If CInt(resultado("ResultID")) > 0 Then
                                                            PrintHashtable(resultado)
                                                            resultado("CardId") = Me.txtCardID.Text.Trim()
                                                            Me.DatosPuntosActivacion = New Hashtable()
                                                            AddValuesToHashable(Me.DatosPuntosActivacion, resultado)
                                                            'Me.DatosPuntos = resultado
                                                            valido = True
                                                        Else
                                                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        End If
                                                    End If
                                                End If
                                            Else
                                                params("CardId") = ""
                                                resultado = ws.Collect(params)
                                                If resultado.Count > 0 Then
                                                    If resultado.ContainsKey("ResultID") = True Then
                                                        If CInt(resultado("ResultID")) > 0 Then
                                                            PrintHashtable(resultado)
                                                            resultado("CardId") = Me.txtCardID.Text.Trim()
                                                            Me.DatosPuntosActivacion = New Hashtable()
                                                            AddValuesToHashable(Me.DatosPuntosActivacion, resultado)
                                                            'Me.DatosPuntos = resultado
                                                            valido = True
                                                        Else
                                                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                            oAppContext.Security.CloseImpersonatedSession()
                                        Else
                                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            ElseIf Me.Provider = Proveedor.KARUM Then
                resultado = ws.Collect(params)
                'ActualizarConsecutivoPuntosPOS()
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultId") Then
                        If CInt(resultado("ResultId")) > 0 Then
                            resultado("CardId") = Me.txtCardID.Text.Trim()
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                            Me.DatosPuntosActivacion = New Hashtable()
                            AddValuesToHashable(Me.DatosPuntosActivacion, resultado)
                            'Me.DatosPuntos = resultado
                            Success = True
                            valido = True
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al Bonificar Puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Private Sub AddValuesToHashable(ByRef ObjetoOrigen As Hashtable, ByVal Valores As Hashtable)
        For Each atributo As String In Valores.Keys
            ObjetoOrigen(atributo) = Valores(atributo)
        Next
    End Sub

#End Region

#Region "Mejoras Programa Lealtad"

    Private Function ValidarTarjeta() As Boolean
        Dim valido As Boolean = False
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        Try
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
            '----------------------------------------------------------------------------------------------------------------------
            'wgomez quitar validacion de 16 digitos
            If Me.txtCardID.Text.Length = 16 Or Me.txtCardID.Text.Length = 13 Then
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(Me.txtCardID.Text.Trim().Substring(0, 6))
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Me.Provider = Proveedor.KARUM
                    Else
                        Me.Provider = Proveedor.BLUE
                    End If
                Else
                    Me.Provider = Proveedor.BLUE
                End If

                CardId = Me.txtCardID.Text
            Else
                Me.Provider = Proveedor.KARUM
                CardId = Me.txtCardID.Text.PadLeft(16, "0")
                'Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            'ASANCHEZ 05/04/2021 validamos que sea de BLUE o en caso contrario seguimos usando WS de karum
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                params("cardId") = CardId
                'params("cardId") = Me.txtCardID.Text.Trim()
                params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("ticketid") = ""
                '----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
                '----------------------------------------------------------------------------------------------------------------------
                If Me.Provider = Proveedor.BLUE Then
                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                Else
                    params("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    params("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    If Deslizada = True Then
                        params("tipo") = "00"
                    Else
                        params("tipo") = "01"
                    End If
                End If
                'params("storeid") = "004"
                '-----------------------------------------------------------------------------

                params("supervisorCode") = CStr(Me.Params("SupervisorCode"))
                params("supervisorName") = CStr(Me.Params("SupervisorName"))
                params("sellerCode") = CStr(Me.Params("SellerCode"))
                params("sellerName") = CStr(Me.Params("SellerName"))
                resultado = ws.GetBalance(params)
                'If Me.Provider = Proveedor.KARUM Then
                '    ActualizarConsecutivoPuntosPOS()
                'End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultId") = True Then

                        '-----------------------------------------------------------------------------
                        'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                        '-----------------------------------------------------------------------------
                        CustomerName = CStr(resultado("CustomerName"))

                        If CInt(resultado("ResultId")) > 0 Then
                            valido = True
                            ' MLVARGAS (11/11/2019): Obtener el nombre del cliente para grabar a TransaccionesSinTarjeta
                            sClientName = CStr(resultado("CustomerName"))
                            ' MLVARGAS (17/03/2020): Mostrar los datos del cliente para el servicio de Karum
                            Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                            Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))

                            If Me.Provider = Proveedor.BLUE Then
                                Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                            End If
                        Else
                            MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            valido = False
                        End If
                    End If
                End If
            Else
                'ASANCHEZ consume el nuevo servicio de BLue
                'ASANCHEZ 29/03/2021 empiezo armar la nueva petición de blue
                Dim tipo_ As String = String.Empty
                tipo_ = consulta_bin_tipo_blue(txtCardID.Text.Trim())
                If tipo_.Trim() = "DB" Then
                    params("cardId") = CardId
                    'params("cardId") = Me.txtCardID.Text.Trim()
                    params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("ticketid") = ""
                    '----------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
                    '----------------------------------------------------------------------------------------------------------------------

                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    'params("storeid") = "004"
                    '-----------------------------------------------------------------------------

                    params("supervisorCode") = CStr(Me.Params("SupervisorCode"))
                    params("supervisorName") = CStr(Me.Params("SupervisorName"))
                    params("sellerCode") = CStr(Me.Params("SellerCode"))
                    params("sellerName") = CStr(Me.Params("SellerName"))
                    resultado = ws.GetBalance(params)
                    'If Me.Provider = Proveedor.KARUM Then
                    '    ActualizarConsecutivoPuntosPOS()
                    'End If
                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultId") = True Then

                            '-----------------------------------------------------------------------------
                            'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                            '-----------------------------------------------------------------------------
                            CustomerName = CStr(resultado("CustomerName"))

                            If CInt(resultado("ResultId")) > 0 Then
                                valido = True
                                ' MLVARGAS (11/11/2019): Obtener el nombre del cliente para grabar a TransaccionesSinTarjeta
                                sClientName = CStr(resultado("CustomerName"))
                                ' MLVARGAS (17/03/2020): Mostrar los datos del cliente para el servicio de Karum
                                Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))

                                If Me.Provider = Proveedor.BLUE Then
                                    Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                    Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                    Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                    Me.txtClienteID.Text = CStr(resultado("CustomerId"))
                                    Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                                End If
                            Else
                                MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                valido = False
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetBalance As Dictionary(Of String, Object)
                    oBluegetBalance = New Dictionary(Of String, Object)
                    oBluegetBalance.Add("cardId", CardId)
                    'oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                    oBluegetBalance.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))
                    oBluegetBalance.Add("ticketId", "")
                    oBluegetBalance.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    oBluegetBalance.Add("referenceId3", "")
                    oBluegetBalance.Add("referenceId4", "")
                    oBluegetBalance.Add("cashierCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("supervisorCod", oAppContext.Security.CurrentUser.Name.Trim)
                    oBluegetBalance.Add("supervisorName", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerName", oAppContext.Security.CurrentUser.Name.Trim)
                    Dim ws_1 As New WSBroker("blue_api_s1", "GetBalance")
                    Dim rs_ As Dictionary(Of String, Object)
                    resultado = ws_1.nuevos_servicios_blue(oBluegetBalance)
                    If resultado.Count = 0 Then
                        MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        valido = False
                    Else
                        If resultado.ContainsKey("ResultID") = True Then
                            If CInt(resultado("ResultID")) < 0 Then
                                valido = False
                                If CInt(resultado("ResultID")) = -1 Then
                                    MessageBox.Show("Trjeta no es válida, favor de generar tarjeta en Portal", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Else
                                    MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                'MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                valido = True
                                CustomerName = CStr(resultado("CustomerName"))
                                sClientName = CStr(resultado("CustomerName"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerID"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))

                                Me.txtStatus.Text = CStr(resultado("StatusDescription"))
                                Me.cmbFechaActivacion.Value = CDate(resultado("Activate"))
                                Me.cmbFechaExpiracion.Value = CDate(resultado("Expire"))
                                Me.txtClienteID.Text = CStr(resultado("CustomerID"))
                                Me.txtNombreCliente.Text = CStr(resultado("CustomerName"))
                            End If
                        End If


                    End If
                End If

            End If

        Catch ex As Exception
            EscribeLog(ex.Message, "Error al obtener el saldo de puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Private Function RegisterApproval() As Boolean
        Dim valido As Boolean = False
        If MessageBox.Show("Esta tarjeta no está activada" & vbCrLf & " ¿Desea activarla?", "Dportenis Pro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.ActivacionBonificacion") = True Then
                Dim frmClientes As New frmClientesSAP
                frmClientes.ActivacionPuntos = True
                If frmClientes.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If frmClientes.EsClienteApproval Then
                        Dim CteSap As ClientesSAP = GetCliente(frmClientes.ClienteID, "P")
                        Dim ClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                        Dim oCliente As ClienteAlterno = ClienteMgr.CreateAlterno()
                        ClienteMgr.Load(frmClientes.ClienteID, oCliente)
                        Me.Params("ReferenceId4") = oCliente.Nombre & "|" & oCliente.ApellidoPaterno & "|" & oCliente.Telefono.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")
                        If ActivateDPCard() Then
                            If CollectDPCard() Then
                                Me.DialogResult = DialogResult.OK
                                Me.accion = True
                                Me.Dispose()
                                valido = True
                            End If
                        End If
                    Else
                        MessageBox.Show("No registro el cliente con el approval, no se puede realizar la bonificación", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        End If
        Return valido
    End Function
    
#End Region

    Private Sub expDPCardPunto_ItemClick(sender As System.Object, e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles expDPCardPunto.ItemClick

    End Sub

    Private Sub boxReadQr_Click(sender As System.Object, e As System.EventArgs) Handles boxReadQr.Click

    End Sub
End Class
