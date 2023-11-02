Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptFacturacionNoFacturadoSH
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "Variables Facturacion SiHay"

    Public CodTipoVenta As String
    Dim intIndex As Integer = 0
    Dim bAnterior As Boolean
    Friend WithEvents txtCodProveedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Dim x As Double = 0.001

#End Region

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "PrecioOferta"
        Me.tbDesc.DataField = "Descuento"
        Me.tbTotal.DataField = "Total"
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbCodigo As TextBox = Nothing
	Private tbConcepto As TextBox = Nothing
	Private tbNumero As TextBox = Nothing
	Private label34 As TextBox = Nothing
	Private tbPUnitario As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbDesc As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFacturacionNoFacturadoSH))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.tbConcepto = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumero = New DataDynamics.ActiveReports.TextBox()
        Me.label34 = New DataDynamics.ActiveReports.TextBox()
        Me.tbPUnitario = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbDesc = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodProveedor = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbCantidad, Me.tbCodigo, Me.tbConcepto, Me.tbNumero, Me.label34, Me.tbPUnitario, Me.tbTotal, Me.tbDesc, Me.txtCodProveedor, Me.TextBox1})
        Me.Detail.Height = 0.595139!
        Me.Detail.Name = "Detail"
        '
        'tbCantidad
        '
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 0.06840548!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.OutputFormat = resources.GetString("tbCantidad.OutputFormat")
        Me.tbCantidad.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCantidad.Text = "99"
        Me.tbCantidad.Top = -0.0625!
        Me.tbCantidad.Visible = False
        Me.tbCantidad.Width = 0.1574803!
        '
        'tbCodigo
        '
        Me.tbCodigo.CanShrink = True
        Me.tbCodigo.Height = 0.2!
        Me.tbCodigo.Left = 0.006000013!
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCodigo.Text = "KS-001289-1671"
        Me.tbCodigo.Top = 0.0!
        Me.tbCodigo.Width = 1.0565!
        '
        'tbConcepto
        '
        Me.tbConcepto.Height = 0.2!
        Me.tbConcepto.Left = 0.006!
        Me.tbConcepto.MultiLine = False
        Me.tbConcepto.Name = "tbConcepto"
        Me.tbConcepto.Style = "ddo-char-set: 0; font-size: 6.75pt; font-family: Tahoma"
        Me.tbConcepto.Text = "Concepto"
        Me.tbConcepto.Top = 0.394!
        Me.tbConcepto.Width = 1.312!
        '
        'tbNumero
        '
        Me.tbNumero.Height = 0.2!
        Me.tbNumero.Left = 1.049705!
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNumero.Text = "25.5"
        Me.tbNumero.Top = 0.0!
        Me.tbNumero.Width = 0.2559055!
        '
        'label34
        '
        Me.label34.CanShrink = True
        Me.label34.Height = 0.2!
        Me.label34.Left = 1.3185!
        Me.label34.Name = "label34"
        Me.label34.Style = "ddo-char-set: 1; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.label34.Text = "AHORRO"
        Me.label34.Top = 0.394!
        Me.label34.Width = 0.563!
        '
        'tbPUnitario
        '
        Me.tbPUnitario.Height = 0.2!
        Me.tbPUnitario.Left = 1.301673!
        Me.tbPUnitario.Name = "tbPUnitario"
        Me.tbPUnitario.OutputFormat = resources.GetString("tbPUnitario.OutputFormat")
        Me.tbPUnitario.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbPUnitario.Text = "$5,200.31"
        Me.tbPUnitario.Top = 0.0!
        Me.tbPUnitario.Width = 0.551181!
        '
        'tbTotal
        '
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 1.859744!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotal.Text = "$99,999.00"
        Me.tbTotal.Top = 0.0!
        Me.tbTotal.Width = 0.6102362!
        '
        'tbDesc
        '
        Me.tbDesc.CanShrink = True
        Me.tbDesc.Height = 0.2!
        Me.tbDesc.Left = 1.875!
        Me.tbDesc.MultiLine = False
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDesc.Text = "$0.00 -"
        Me.tbDesc.Top = 0.4075!
        Me.tbDesc.Width = 0.6190944!
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.CanShrink = True
        Me.txtCodProveedor.DataField = "CodArtProv"
        Me.txtCodProveedor.Height = 0.2!
        Me.txtCodProveedor.Left = 0.01!
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.txtCodProveedor.Text = Nothing
        Me.txtCodProveedor.Top = 0.2!
        Me.txtCodProveedor.Width = 1.0565!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.DataField = "Marca"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 1.066!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.208!
        Me.TextBox1.Width = 1.3835!
        '
        'rptFacturacionNoFacturadoSH
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.45!
        Me.Sections.Add(Me.Detail)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Eventos SiHay"
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        intIndex += 1

        If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
        OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
            Me.tbPUnitario.Value = Math.Round(CDbl(Me.tbPUnitario.Text) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            Me.tbPUnitario.Text = Format(Me.tbPUnitario.Value, "Currency")
            Me.tbTotal.Value = CInt(tbCantidad.Text) * CDbl(tbPUnitario.Text)
            Me.tbTotal.Text = Format(Me.tbTotal.Value, "Currency")

            Me.tbDesc.Value = Math.Round(CDbl(Me.tbDesc.Text) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency")
        End If
        If DirectCast(Detail.Controls("tbDesc"), TextBox).Value > 0 Then
            'Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency") & " -"
            DirectCast(Detail.Controls("label34"), TextBox).Text = "AHORRO"
            'DirectCast(Detail.Controls("label34"), TextBox).Text.re
            DirectCast(Detail.Controls("tbDesc"), TextBox).Text = Format(DirectCast(Detail.Controls("tbDesc"), TextBox).Value, "Currency") & " -"
            'If InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
            'DirectCast(Detail.Controls("tbTotal"), TextBox).Text = DirectCast(Detail.Controls("tbTotalConDesc"), TextBox).Text
            'End If
            DirectCast(Detail.Controls("label34"), TextBox).Visible = True
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = True
            'Me.tbTotalConDesc.Text = Format((CDbl(Me.tbTotal.Text) - CDbl(Me.tbDesc.Text)), "Currency")
            'Me.tbCantDesc.Text = Me.tbDesc.Text '& " -"
            'Me.label34.Text = "AHORRO"
        Else
            DirectCast(Detail.Controls("label34"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = False
        End If
    End Sub


#End Region

    Private Sub Detail_Format(sender As Object, e As System.EventArgs) Handles Detail.Format
        Me.tbCodigo.Text = CLng(tbCodigo.Text.Trim()).ToString()
    End Sub
End Class
