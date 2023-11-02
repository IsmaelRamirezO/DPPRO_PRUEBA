Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago

Public Class ReporteDetalleFormasPago

    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oFacturaFormaPago As FacturaFormaPago
    Dim dsFormaPago As New DataSet

    Public Sub New(ByVal ID As Integer, Optional ByVal Opcion As Integer = 0)

        MyBase.New()

        InitializeComponent()

        InicializaObjetos()
        Select Case Opcion
            Case 0
                dsFormaPago = oFacturaFormaPago.LoadRptCierre(ID)
            Case 1
                dsFormaPago = oFacturaFormaPago.LoadRptCierreByPedidoID(ID)
            Case 2
                dsFormaPago = oFacturaFormaPago.LoadRptCierrePedidosFacturadosByPedidoID(ID)
            Case 3
                dsFormaPago = oFacturaFormaPago.LoadRptCierrePedidosNoFacturadosByPedidoID(ID)
            Case 4
                dsFormaPago = oFacturaFormaPago.LoadRptCierrePagosEcommerceByOtrosPagosID(ID)
        End Select

        '---------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: Truncamos el monto de cada pago par aeliminar centavos de mas (KARUM)
        '---------------------------------------------------------------------------------------
        dsFormaPago = TruncarFormasPago(dsFormaPago)

        Me.DataSource = dsFormaPago
        Me.DataMember = "FacturasFormasPago"

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteDetalleFormasPago))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.CanGrow = false
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2})
            Me.Detail.Height = 0.15625!
            Me.Detail.Name = "Detail"
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "MontoPago"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 0.5536417!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.TextBox1.Text = "FormaPago"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.7588583!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "CodFormasPago"
            Me.TextBox2.Height = 0.25!
            Me.TextBox2.Left = 0.0625!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.TextBox2.Text = "CodFormaPago"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.7249014!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 1.479167!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Private Sub InicializaObjetos()

        oFacturaFormaPago = New FacturaFormaPago(oAppContext)

    End Sub

    '---------------------------------------------------------------------------------------
    ' JNAVA 24.06.2015. Funcion para truncar el monto de pago de cada forma de pago 
    '---------------------------------------------------------------------------------------
    Private Function TruncarFormasPago(ByVal dsFormatPago As DataSet) As DataSet

        For Each oRow As DataRow In dsFormatPago.Tables(0).Rows
            If CStr(oRow!CodFormasPago) = "DPCA" Then
                oRow!CodFormasPago = "DP CARD"
            End If
        Next
        dsFormatPago.AcceptChanges()

        Return dsFormatPago

    End Function


End Class
