Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptNotaCreditoBonificacion
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oForm As frmAbonoCreditoDirectoTienda)
        MyBase.New()
        InitializeComponent()
        Me.tbCliente.Text = oForm.EBAsociado.Text
        Me.tbFecha.Text = Now.Today

        Me.DataMember = "Facturas"


        Me.lbFecha.DataField = "FechaFactura"
        Me.lbIDFactura.DataField = "FolioFactura"
        Me.lbImporte.DataField = "PagoEstablecido"
        Me.lbBonificacion.DataField = "Bonificacion"

        Me.lbTotal.Text = oForm.txtTotalBonificacion.Text



    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private tbAplicada As TextBox = Nothing
	Private tbSucOrigen As TextBox = Nothing
	Private tbNumeroControl As TextBox = Nothing
	Private tbSucursal As TextBox = Nothing
	Private tbRFC As TextBox = Nothing
	Private tbTipoDevolucion As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbFolio As TextBox = Nothing
	Private lbFecha As Label = Nothing
	Private lbIDFactura As Label = Nothing
	Private lbImporte As Label = Nothing
	Private lbBonificacion As Label = Nothing
	Private lbTotal As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptNotaCreditoBonificacion))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.tbAplicada = New DataDynamics.ActiveReports.TextBox()
            Me.tbSucOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.tbNumeroControl = New DataDynamics.ActiveReports.TextBox()
            Me.tbSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.tbRFC = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoDevolucion = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.lbFecha = New DataDynamics.ActiveReports.Label()
            Me.lbIDFactura = New DataDynamics.ActiveReports.Label()
            Me.lbImporte = New DataDynamics.ActiveReports.Label()
            Me.lbBonificacion = New DataDynamics.ActiveReports.Label()
            Me.lbTotal = New DataDynamics.ActiveReports.Label()
            CType(Me.tbAplicada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSucOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNumeroControl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbRFC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoDevolucion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbIDFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbBonificacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lbFecha, Me.lbIDFactura, Me.lbImporte, Me.lbBonificacion})
            Me.Detail.Height = 0.3125!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbAplicada, Me.tbSucOrigen, Me.tbNumeroControl, Me.tbSucursal, Me.tbRFC, Me.tbTipoDevolucion, Me.tbFecha, Me.tbCliente, Me.tbFolio})
            Me.PageHeader.Height = 2.197917!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lbTotal})
            Me.PageFooter.Height = 0.3125!
            Me.PageFooter.Name = "PageFooter"
            '
            'tbAplicada
            '
            Me.tbAplicada.Height = 0.2!
            Me.tbAplicada.Left = 0.25!
            Me.tbAplicada.Name = "tbAplicada"
            Me.tbAplicada.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbAplicada.Top = 1.4375!
            Me.tbAplicada.Width = 4.438!
            '
            'tbSucOrigen
            '
            Me.tbSucOrigen.Height = 0.2!
            Me.tbSucOrigen.Left = 3.1875!
            Me.tbSucOrigen.Name = "tbSucOrigen"
            Me.tbSucOrigen.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbSucOrigen.Top = 1.0625!
            Me.tbSucOrigen.Width = 1.479!
            '
            'tbNumeroControl
            '
            Me.tbNumeroControl.Height = 0.2!
            Me.tbNumeroControl.Left = 1.6875!
            Me.tbNumeroControl.Name = "tbNumeroControl"
            Me.tbNumeroControl.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbNumeroControl.Top = 1.0625!
            Me.tbNumeroControl.Width = 1.479!
            '
            'tbSucursal
            '
            Me.tbSucursal.Height = 0.2!
            Me.tbSucursal.Left = 0.25!
            Me.tbSucursal.Name = "tbSucursal"
            Me.tbSucursal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbSucursal.Top = 1.0625!
            Me.tbSucursal.Width = 1.479!
            '
            'tbRFC
            '
            Me.tbRFC.Height = 0.2!
            Me.tbRFC.Left = 0.25!
            Me.tbRFC.Name = "tbRFC"
            Me.tbRFC.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbRFC.Top = 0.6875!
            Me.tbRFC.Width = 1.479!
            '
            'tbTipoDevolucion
            '
            Me.tbTipoDevolucion.Height = 0.2!
            Me.tbTipoDevolucion.Left = 1.6875!
            Me.tbTipoDevolucion.Name = "tbTipoDevolucion"
            Me.tbTipoDevolucion.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbTipoDevolucion.Top = 0.6875!
            Me.tbTipoDevolucion.Width = 1.479!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.2!
            Me.tbFecha.Left = 3.1875!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbFecha.Top = 0.6875!
            Me.tbFecha.Width = 1.479!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.2!
            Me.tbCliente.Left = 1.25!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbCliente.Top = 0.25!
            Me.tbCliente.Width = 3.4375!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.2!
            Me.tbFolio.Left = 0.25!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbFolio.Top = 0.25!
            Me.tbFolio.Width = 1!
            '
            'lbFecha
            '
            Me.lbFecha.Height = 0.1875!
            Me.lbFecha.HyperLink = Nothing
            Me.lbFecha.Left = 0.0625!
            Me.lbFecha.Name = "lbFecha"
            Me.lbFecha.Style = ""
            Me.lbFecha.Text = "Fecha"
            Me.lbFecha.Top = 0.0625!
            Me.lbFecha.Width = 0.6875!
            '
            'lbIDFactura
            '
            Me.lbIDFactura.Height = 0.1875!
            Me.lbIDFactura.HyperLink = Nothing
            Me.lbIDFactura.Left = 1!
            Me.lbIDFactura.Name = "lbIDFactura"
            Me.lbIDFactura.Style = ""
            Me.lbIDFactura.Text = "IDFactura"
            Me.lbIDFactura.Top = 0.0625!
            Me.lbIDFactura.Width = 0.6875!
            '
            'lbImporte
            '
            Me.lbImporte.Height = 0.1875!
            Me.lbImporte.HyperLink = Nothing
            Me.lbImporte.Left = 3.0625!
            Me.lbImporte.Name = "lbImporte"
            Me.lbImporte.Style = ""
            Me.lbImporte.Text = "Importe"
            Me.lbImporte.Top = 0.0625!
            Me.lbImporte.Width = 0.6875!
            '
            'lbBonificacion
            '
            Me.lbBonificacion.Height = 0.1875!
            Me.lbBonificacion.HyperLink = Nothing
            Me.lbBonificacion.Left = 3.9375!
            Me.lbBonificacion.Name = "lbBonificacion"
            Me.lbBonificacion.Style = ""
            Me.lbBonificacion.Text = "Bonificacion"
            Me.lbBonificacion.Top = 0.0625!
            Me.lbBonificacion.Width = 0.6875!
            '
            'lbTotal
            '
            Me.lbTotal.Height = 0.1875!
            Me.lbTotal.HyperLink = Nothing
            Me.lbTotal.Left = 4!
            Me.lbTotal.Name = "lbTotal"
            Me.lbTotal.Style = ""
            Me.lbTotal.Text = "Total"
            Me.lbTotal.Top = 0.0625!
            Me.lbTotal.Width = 0.625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.PaperHeight = 9.03125!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 4.760417!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.tbAplicada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSucOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNumeroControl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbRFC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoDevolucion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbIDFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbBonificacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

   
End Class
