Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptSaldoDPCardPuntos
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Datos As Hashtable)
        MyBase.New()
        InitializeComponent()

        '-------------------------------------------------------------
        'JNAVA (21.01.2014): Mostramos Datos para imprimir Saldo
        '-------------------------------------------------------------
        Me.lblFecha.Text = "Fecha: " & Date.Today.ToShortDateString
        Me.lblHora.Text = "Hora: " & Format(Date.Now, "HH:mm:ss")

        'Me.txtConsecutivoPOS.Text = CStr(Datos("ConsecutivoPOS"))

        Me.txtTarjeta.Text = "**** **** ****" & CStr(Datos("CardID")).Substring(12, 4)
        Me.txtNombre.Text = CStr(Datos("CustomerName"))

        Me.txtSaldoActual.Text = Format(CDec(Datos("BalancePoints")), "c")

        Me.txtSaldoActualPesos.Text = Format(CDec(Datos("BalanceAmount")), "c")

        Me.txtFechaActivacion.Text = CDate(Datos("Activate")).ToLongDateString

        Me.txtFechaExpiracion.Text = CDate(Datos("Expire")).ToLongDateString

        Me.txtPersonalMessage.Text = CStr(Datos("PersonalMessage")).Trim

        If Me.txtPersonalMessage.Text.Trim <> "" Then Me.txtPersonalMessage.Text &= vbCrLf & vbCrLf

        '-----------------------------------------------------------------------------------
        ' JNAVA (11.08.2015): Verificamos si existe el campo para setearlo o no setearlo
        '-----------------------------------------------------------------------------------
        If Datos.ContainsKey("PromotionalMessage") Then
            Me.txtPersonalMessage.Text &= CStr(Datos("PromotionalMessage")).Trim
        End If

        Me.txtExpirationMessage.Text = CStr(Datos("ExpireStatusDescriptionCustomer")).Trim

        '-----------------------------------------------------------------------------------
        ' JNAVA (12.12.2015): Seteamos los puntos a expirar obtenidos ya que siempre se fijo
        '-----------------------------------------------------------------------------------
        Me.txtPuntosExpirar.Text = CStr(Datos("PointsToExpire")).Trim

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Label1 As Label = Nothing
    Private lblFecha As Label = Nothing
    Private lblHora As Label = Nothing
    Private Label2 As Label = Nothing
    Private txtTarjeta As TextBox = Nothing
    Private Label7 As Label = Nothing
    Private txtNombre As TextBox = Nothing
    Private Label8 As Label = Nothing
    Private txtSaldoActual As TextBox = Nothing
    Private Label9 As Label = Nothing
    Private txtSaldoActualPesos As TextBox = Nothing
    Private Label10 As Label = Nothing
    Private txtFechaActivacion As TextBox = Nothing
    Private Label11 As Label = Nothing
    Private txtFechaExpiracion As TextBox = Nothing
    Private txtPersonalMessage As TextBox = Nothing
    Private Label12 As Label = Nothing
    Private txtPuntosExpirar As TextBox = Nothing
    Private txtExpirationMessage As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSaldoDPCardPuntos))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.lblHora = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txtSaldoActual = New DataDynamics.ActiveReports.TextBox()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtSaldoActualPesos = New DataDynamics.ActiveReports.TextBox()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaActivacion = New DataDynamics.ActiveReports.TextBox()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaExpiracion = New DataDynamics.ActiveReports.TextBox()
        Me.txtPersonalMessage = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtPuntosExpirar = New DataDynamics.ActiveReports.TextBox()
        Me.txtExpirationMessage = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoActualPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaActivacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaExpiracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersonalMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosExpirar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExpirationMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.lblFecha, Me.lblHora, Me.Label2, Me.txtTarjeta, Me.Label7, Me.txtNombre, Me.Label8, Me.txtSaldoActual, Me.Label9, Me.txtSaldoActualPesos, Me.Label10, Me.txtFechaActivacion, Me.Label11, Me.txtFechaExpiracion, Me.txtPersonalMessage, Me.Label12, Me.txtPuntosExpirar, Me.txtExpirationMessage})
        Me.PageHeader.Height = 3.625!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.721!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9pt"
        Me.Label1.Text = "Saldo DP Card"
        Me.Label1.Top = 0.125!
        Me.Label1.Width = 1.588091!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2362205!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.316473!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-family: Tahoma"
        Me.lblFecha.Text = "Fecha: 25/08/2007"
        Me.lblFecha.Top = 0.4197845!
        Me.lblFecha.Width = 1.259842!
        '
        'lblHora
        '
        Me.lblHora.Height = 0.2362205!
        Me.lblHora.HyperLink = Nothing
        Me.lblHora.Left = 1.638815!
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Style = "font-family: Tahoma"
        Me.lblHora.Text = "Hora: 16:43"
        Me.lblHora.Top = 0.4197845!
        Me.lblHora.Width = 1.06939!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.270705!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "Tarjeta:"
        Me.Label2.Top = 0.8125!
        Me.Label2.Width = 1.0!
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Height = 0.1875!
        Me.txtTarjeta.Left = 1.270705!
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtTarjeta.Text = "Tarjeta"
        Me.txtTarjeta.Top = 0.8125!
        Me.txtTarjeta.Width = 1.5!
        '
        'Label7
        '
        Me.Label7.Height = 0.3125!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.270705!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label7.Text = "Nombre Tarjetahabiente:"
        Me.Label7.Top = 1.0625!
        Me.Label7.Width = 1.0!
        '
        'txtNombre
        '
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 1.270705!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtNombre.Text = "Nombre"
        Me.txtNombre.Top = 1.1875!
        Me.txtNombre.Width = 1.5!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.270705!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "Saldo Actual Puntos:"
        Me.Label8.Top = 1.4375!
        Me.Label8.Width = 1.25!
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.Height = 0.1875!
        Me.txtSaldoActual.Left = 1.583205!
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtSaldoActual.Text = "$0.00"
        Me.txtSaldoActual.Top = 1.4375!
        Me.txtSaldoActual.Width = 1.1875!
        '
        'Label9
        '
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.270705!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label9.Text = "Saldo Actual Pesos:"
        Me.Label9.Top = 1.6875!
        Me.Label9.Width = 1.25!
        '
        'txtSaldoActualPesos
        '
        Me.txtSaldoActualPesos.Height = 0.1875!
        Me.txtSaldoActualPesos.Left = 1.583205!
        Me.txtSaldoActualPesos.Name = "txtSaldoActualPesos"
        Me.txtSaldoActualPesos.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtSaldoActualPesos.Text = "$0.00"
        Me.txtSaldoActualPesos.Top = 1.6875!
        Me.txtSaldoActualPesos.Width = 1.1875!
        '
        'Label10
        '
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.270705!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label10.Text = "Activación:"
        Me.Label10.Top = 1.9375!
        Me.Label10.Width = 1.0!
        '
        'txtFechaActivacion
        '
        Me.txtFechaActivacion.Height = 0.1875!
        Me.txtFechaActivacion.Left = 1.270705!
        Me.txtFechaActivacion.Name = "txtFechaActivacion"
        Me.txtFechaActivacion.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtFechaActivacion.Text = "15/04/2015"
        Me.txtFechaActivacion.Top = 1.9375!
        Me.txtFechaActivacion.Width = 1.5!
        '
        'Label11
        '
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.270705!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label11.Text = "Expira:"
        Me.Label11.Top = 2.1875!
        Me.Label11.Width = 1.0!
        '
        'txtFechaExpiracion
        '
        Me.txtFechaExpiracion.Height = 0.1875!
        Me.txtFechaExpiracion.Left = 1.270705!
        Me.txtFechaExpiracion.Name = "txtFechaExpiracion"
        Me.txtFechaExpiracion.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtFechaExpiracion.Text = "31/12/2015"
        Me.txtFechaExpiracion.Top = 2.1875!
        Me.txtFechaExpiracion.Width = 1.5!
        '
        'txtPersonalMessage
        '
        Me.txtPersonalMessage.Height = 0.4375!
        Me.txtPersonalMessage.Left = 0.270705!
        Me.txtPersonalMessage.Name = "txtPersonalMessage"
        Me.txtPersonalMessage.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtPersonalMessage.Text = "Mensaje personalizado para el Socio"
        Me.txtPersonalMessage.Top = 3.125!
        Me.txtPersonalMessage.Width = 2.5!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.270705!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "Puntos a expirar:"
        Me.Label12.Top = 2.5!
        Me.Label12.Width = 1.1875!
        '
        'txtPuntosExpirar
        '
        Me.txtPuntosExpirar.Height = 0.1875!
        Me.txtPuntosExpirar.Left = 1.520705!
        Me.txtPuntosExpirar.Name = "txtPuntosExpirar"
        Me.txtPuntosExpirar.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtPuntosExpirar.Text = "1524"
        Me.txtPuntosExpirar.Top = 2.5!
        Me.txtPuntosExpirar.Width = 1.25!
        '
        'txtExpirationMessage
        '
        Me.txtExpirationMessage.Height = 0.3125!
        Me.txtExpirationMessage.Left = 0.270705!
        Me.txtExpirationMessage.Name = "txtExpirationMessage"
        Me.txtExpirationMessage.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtExpirationMessage.Text = "Mensaje descriptivo del vencimiento de la Dpcard para ser impreso en el ticket de" & _
    " compra"
        Me.txtExpirationMessage.Top = 2.75!
        Me.txtExpirationMessage.Width = 2.5!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptSaldoDPCardPuntos
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 39.34028!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperWidth = 2.95!
        Me.PrintWidth = 2.885!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoActualPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaActivacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaExpiracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersonalMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosExpirar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExpirationMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
