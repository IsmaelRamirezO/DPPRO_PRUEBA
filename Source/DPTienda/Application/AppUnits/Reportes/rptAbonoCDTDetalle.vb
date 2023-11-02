Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda

Public Class rptAbonoCDTDetalle
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal AbonoID As Integer)
        MyBase.New()
        InitializeComponent()

        Dim dsAbonos As DataSet
        Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)
        dsAbonos = oAbonoCreditoDirectoMgr.AbonosCDTFacturasByIDAbonos(AbonoID)

        'Dim dcFolioSAP As New DataColumn
        'With dcFolioSAP
        '    .ColumnName = "FolioSAP1"
        '    .Caption = "Folio SAP"
        '    .DataType = GetType(String)
        '    .DefaultValue = ""
        'End With

        'dsAbonos.Tables(0).AcceptChanges()

        For Each oRow As DataRow In dsAbonos.Tables(0).Rows
            Dim dsFolioSAP As DataSet = oAbonoCreditoDirectoMgr.FolioSAPGET(oRow.Item("FolioFactura"), oRow.Item("CodCaja"))
            If dsFolioSAP.Tables(0).Rows.Count > 0 Then
                oRow("FolioSAP") = dsFolioSAP.Tables(0).Rows(0).Item("FolioSAP")
            End If
        Next
        dsAbonos.Tables(0).AcceptChanges()

        Dim dvFechaAutoF As New DataView(dsAbonos.Tables(0), "Fecha >='" & oConfigCierreFI.FechaAutoF & "'", "FolioFactura", DataViewRowState.CurrentRows)
        For Each oView As DataRowView In dvFechaAutoF
            oView.Row.Item("FolioFactura") = 0
        Next
        dsAbonos.Tables(0).AcceptChanges()

        Me.DataSource = dsAbonos
        Me.DataMember = "AbonosCreditoDirecto"

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private txtFolioFactura As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private txtAbonoFactura As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonoCDTDetalle))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonoFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonoFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioFactura, Me.txtFolioSAP, Me.txtAbonoFactura, Me.txtSaldo, Me.TextBox1})
            Me.Detail.Height = 0.15625!
            Me.Detail.Name = "Detail"
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.DataField = "FolioFactura"
            Me.txtFolioFactura.Height = 0.1259842!
            Me.txtFolioFactura.Left = 0.0625!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFolioFactura.Text = "FolioFactura"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 0.6692914!
            '
            'txtFolioSAP
            '
            Me.txtFolioSAP.DataField = "FolioFI"
            Me.txtFolioSAP.Height = 0.125!
            Me.txtFolioSAP.Left = 1.4375!
            Me.txtFolioSAP.Name = "txtFolioSAP"
            Me.txtFolioSAP.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFolioSAP.Text = "FolioFactura"
            Me.txtFolioSAP.Top = 0!
            Me.txtFolioSAP.Width = 0.7291667!
            '
            'txtAbonoFactura
            '
            Me.txtAbonoFactura.DataField = "MontoAbono"
            Me.txtAbonoFactura.Height = 0.125!
            Me.txtAbonoFactura.Left = 2.1875!
            Me.txtAbonoFactura.Name = "txtAbonoFactura"
            Me.txtAbonoFactura.OutputFormat = resources.GetString("txtAbonoFactura.OutputFormat")
            Me.txtAbonoFactura.Style = "text-align: right; font-size: 8.25pt"
            Me.txtAbonoFactura.Text = "TextBox3"
            Me.txtAbonoFactura.Top = 0!
            Me.txtAbonoFactura.Width = 0.8125!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "Saldo"
            Me.txtSaldo.Height = 0.125!
            Me.txtSaldo.Left = 3.0625!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSaldo.Text = "TextBox3"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.6875!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "FolioSAP"
            Me.TextBox1.Height = 0.1259842!
            Me.TextBox1.Left = 0.75!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox1.Text = "FolioFactura"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.6692914!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 3.822917!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonoFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
