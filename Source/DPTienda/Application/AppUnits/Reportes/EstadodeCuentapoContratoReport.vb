Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class EstadodeCuentapoContratoReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal strAlmacen As String, _
                    ByVal strClienteID As String, _
                    ByVal strCliente As String, _
                    ByVal datFechaApartado As Date, _
                    ByVal decImporte As Decimal, _
                    ByVal decSaldo As Decimal, _
                    ByVal dtAbonos As DataTable)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = dtAbonos
        Me.DataMember = "Abonos"

        lblFecha.Text = Format(Date.Now, "short date")
        lblPagina.Text = "Pag.: " & Me.PageNumber
        lblCodCliente.Text = "Cod. Cliente : " & strClienteID
        lblCliente.Text = "Cliente : " & UCase(strCliente)
        lblFechaApartado.Text = "Fecha de Apartado : " & Format(datFechaApartado, "short date")
        lblSucursal.Text = "SUCURSAL : " & UCase(strAlmacen)
        lblCImporte.Text = Format(decImporte, "currency")
        lblCsaldo.Text = Format(decSaldo, "currency")
        txtTotalSaldo.Text = Format(decSaldo, "currency")

        Me.Run()

    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblTitulo As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblPagina As Label = Nothing
	Private lblCodCliente As Label = Nothing
	Private lblCliente As Label = Nothing
	Private lblFechaApartado As Label = Nothing
	Private lblImporte As Label = Nothing
	Private lblSaldo As Label = Nothing
	Private lblCImporte As Label = Nothing
	Private lblCsaldo As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtContrato As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtHora As TextBox = Nothing
	Private txtPlayer As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTotalSaldo As TextBox = Nothing
	Private txtTotalImporte As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadodeCuentapoContratoReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.lblCodCliente = New DataDynamics.ActiveReports.Label()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblFechaApartado = New DataDynamics.ActiveReports.Label()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.lblSaldo = New DataDynamics.ActiveReports.Label()
            Me.lblCImporte = New DataDynamics.ActiveReports.Label()
            Me.lblCsaldo = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtContrato = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtHora = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotalSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCodCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCsaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtContrato,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtContrato, Me.txtFecha, Me.txtHora, Me.txtPlayer, Me.txtImporte, Me.txtSaldo})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblTitulo, Me.lblFecha, Me.lblPagina, Me.lblCodCliente, Me.lblCliente, Me.lblFechaApartado, Me.lblImporte, Me.lblSaldo, Me.lblCImporte, Me.lblCsaldo, Me.lblSucursal, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7})
            Me.PageHeader.Height = 1.322222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotalSaldo, Me.txtTotalImporte, Me.Label8})
            Me.GroupFooter1.Height = 0.3222222!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.3125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.9375!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center"
            Me.lblTitulo.Text = "REPORTE DETALLADO DE ABONOS"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 3.25!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 1.3125!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.9375!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = "text-align: right"
            Me.lblPagina.Text = "Pag."
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 1!
            '
            'lblCodCliente
            '
            Me.lblCodCliente.Height = 0.2!
            Me.lblCodCliente.HyperLink = Nothing
            Me.lblCodCliente.Left = 0.0625!
            Me.lblCodCliente.Name = "lblCodCliente"
            Me.lblCodCliente.Style = ""
            Me.lblCodCliente.Text = "Cod. Cliente :"
            Me.lblCodCliente.Top = 0.3125!
            Me.lblCodCliente.Width = 1.875!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.2!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 0.0625!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = ""
            Me.lblCliente.Text = "Cliente"
            Me.lblCliente.Top = 0.5625!
            Me.lblCliente.Width = 4.1875!
            '
            'lblFechaApartado
            '
            Me.lblFechaApartado.Height = 0.2!
            Me.lblFechaApartado.HyperLink = Nothing
            Me.lblFechaApartado.Left = 1.9375!
            Me.lblFechaApartado.Name = "lblFechaApartado"
            Me.lblFechaApartado.Style = "text-align: center"
            Me.lblFechaApartado.Text = "Fecha de Apartado :"
            Me.lblFechaApartado.Top = 0.3125!
            Me.lblFechaApartado.Width = 3.25!
            '
            'lblImporte
            '
            Me.lblImporte.Height = 0.2!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 5.25!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = ""
            Me.lblImporte.Text = "Importe"
            Me.lblImporte.Top = 0.3125!
            Me.lblImporte.Width = 0.625!
            '
            'lblSaldo
            '
            Me.lblSaldo.Height = 0.2!
            Me.lblSaldo.HyperLink = Nothing
            Me.lblSaldo.Left = 5.25!
            Me.lblSaldo.Name = "lblSaldo"
            Me.lblSaldo.Style = ""
            Me.lblSaldo.Text = "Saldo"
            Me.lblSaldo.Top = 0.5625!
            Me.lblSaldo.Width = 0.625!
            '
            'lblCImporte
            '
            Me.lblCImporte.Height = 0.2!
            Me.lblCImporte.HyperLink = Nothing
            Me.lblCImporte.Left = 5.9375!
            Me.lblCImporte.Name = "lblCImporte"
            Me.lblCImporte.Style = "text-align: right"
            Me.lblCImporte.Text = ""
            Me.lblCImporte.Top = 0.3125!
            Me.lblCImporte.Width = 1!
            '
            'lblCsaldo
            '
            Me.lblCsaldo.Height = 0.2!
            Me.lblCsaldo.HyperLink = Nothing
            Me.lblCsaldo.Left = 5.9375!
            Me.lblCsaldo.Name = "lblCsaldo"
            Me.lblCsaldo.Style = "text-align: right"
            Me.lblCsaldo.Text = ""
            Me.lblCsaldo.Top = 0.5625!
            Me.lblCsaldo.Width = 1!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.375!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center"
            Me.lblSucursal.Text = "Sucursal"
            Me.lblSucursal.Top = 0.8125!
            Me.lblSucursal.Width = 6.25!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "Folio"
            Me.Label1.Top = 1.0625!
            Me.Label1.Width = 0.5!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center"
            Me.Label2.Text = "Contrato"
            Me.Label2.Top = 1.0625!
            Me.Label2.Width = 0.6875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.375!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center"
            Me.Label3.Text = "Fecha"
            Me.Label3.Top = 1.0625!
            Me.Label3.Width = 0.75!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 2.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center"
            Me.Label4.Text = "Hora"
            Me.Label4.Top = 1.0625!
            Me.Label4.Width = 0.5625!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.8125!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "Player"
            Me.Label5.Top = 1.0625!
            Me.Label5.Width = 2.25!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5.125!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Importe"
            Me.Label6.Top = 1.0625!
            Me.Label6.Width = 0.875!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 6.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "Saldo"
            Me.Label7.Top = 1.0625!
            Me.Label7.Width = 0.875!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1.0625!
            Me.Line1.Width = 7!
            Me.Line1.X1 = 7!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 1.0625!
            Me.Line1.Y2 = 1.0625!
            '
            'Line2
            '
            Me.Line2.Height = 0.25!
            Me.Line2.Left = 6.0625!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.0625!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 6.0625!
            Me.Line2.X2 = 6.0625!
            Me.Line2.Y1 = 1.0625!
            Me.Line2.Y2 = 1.3125!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 5.131945!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.069444!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 5.131945!
            Me.Line3.X2 = 5.131945!
            Me.Line3.Y1 = 1.069444!
            Me.Line3.Y2 = 1.319444!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 2.756944!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.069444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 2.756944!
            Me.Line4.X2 = 2.756944!
            Me.Line4.Y1 = 1.069444!
            Me.Line4.Y2 = 1.319444!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 2.131944!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 1.069444!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 2.131944!
            Me.Line5.X2 = 2.131944!
            Me.Line5.Y1 = 1.069444!
            Me.Line5.Y2 = 1.319444!
            '
            'Line6
            '
            Me.Line6.Height = 0.25!
            Me.Line6.Left = 1.319444!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 1.069444!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 1.319444!
            Me.Line6.X2 = 1.319444!
            Me.Line6.Y1 = 1.069444!
            Me.Line6.Y2 = 1.319444!
            '
            'Line7
            '
            Me.Line7.Height = 0.25!
            Me.Line7.Left = 0.6319444!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 1.069444!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 0.6319444!
            Me.Line7.X2 = 0.6319444!
            Me.Line7.Y1 = 1.069444!
            Me.Line7.Y2 = 1.319444!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FolioAbono"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = -0.0625!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right; font-size: 9pt"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.625!
            '
            'txtContrato
            '
            Me.txtContrato.DataField = "FolioContrato"
            Me.txtContrato.Height = 0.2!
            Me.txtContrato.Left = 0.625!
            Me.txtContrato.Name = "txtContrato"
            Me.txtContrato.Style = "text-align: right; font-size: 9pt"
            Me.txtContrato.Text = "Contrato"
            Me.txtContrato.Top = 0!
            Me.txtContrato.Width = 0.625!
            '
            'txtFecha
            '
            Me.txtFecha.DataField = "FechaAbono"
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 1.375!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center; font-size: 9pt"
            Me.txtFecha.Text = "Fecha"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 0.75!
            '
            'txtHora
            '
            Me.txtHora.DataField = "FechaAbono"
            Me.txtHora.Height = 0.2!
            Me.txtHora.Left = 2.1875!
            Me.txtHora.Name = "txtHora"
            Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
            Me.txtHora.Style = "text-align: center; font-size: 9pt"
            Me.txtHora.Text = "Hora"
            Me.txtHora.Top = 0!
            Me.txtHora.Width = 0.5625!
            '
            'txtPlayer
            '
            Me.txtPlayer.CanGrow = false
            Me.txtPlayer.DataField = "PlayerAbono"
            Me.txtPlayer.Height = 0.2!
            Me.txtPlayer.Left = 2.8125!
            Me.txtPlayer.MultiLine = false
            Me.txtPlayer.Name = "txtPlayer"
            Me.txtPlayer.Style = "font-size: 9pt"
            Me.txtPlayer.Text = "Player"
            Me.txtPlayer.Top = 0!
            Me.txtPlayer.Width = 2.3125!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "ImporteAbono"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 5.125!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 9pt"
            Me.txtImporte.Text = "Importe"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.875!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "SaldoContrato"
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 6.0625!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right; font-size: 9pt"
            Me.txtSaldo.Text = "Saldo"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.875!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 7!
            '
            'txtTotalSaldo
            '
            Me.txtTotalSaldo.Height = 0.2!
            Me.txtTotalSaldo.Left = 6.0625!
            Me.txtTotalSaldo.Name = "txtTotalSaldo"
            Me.txtTotalSaldo.OutputFormat = resources.GetString("txtTotalSaldo.OutputFormat")
            Me.txtTotalSaldo.Style = "text-align: right; font-size: 9pt"
            Me.txtTotalSaldo.Text = "Saldo"
            Me.txtTotalSaldo.Top = 0.0625!
            Me.txtTotalSaldo.Width = 0.875!
            '
            'txtTotalImporte
            '
            Me.txtTotalImporte.DataField = "ImporteAbono"
            Me.txtTotalImporte.Height = 0.2!
            Me.txtTotalImporte.Left = 5.125!
            Me.txtTotalImporte.Name = "txtTotalImporte"
            Me.txtTotalImporte.OutputFormat = resources.GetString("txtTotalImporte.OutputFormat")
            Me.txtTotalImporte.Style = "text-align: right; font-size: 9pt"
            Me.txtTotalImporte.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalImporte.Text = "Importe"
            Me.txtTotalImporte.Top = 0.0625!
            Me.txtTotalImporte.Width = 0.875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.8125!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "TOTALES       :"
            Me.Label8.Top = 0.0625!
            Me.Label8.Width = 1.3125!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.010417!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCodCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCsaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtContrato,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
