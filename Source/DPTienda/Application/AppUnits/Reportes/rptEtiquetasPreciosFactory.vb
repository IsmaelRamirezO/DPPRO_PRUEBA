Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiquetasPreciosFactory

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal dtCodigos As DataTable, ByVal Index As Integer)

        MyBase.New()
        InitializeComponent()

        LimpiarCampos()

        Dim Talla As String = ""

        For Each oRow As DataRow In dtCodigos.Rows

            DirectCast(ReportHeader.Controls("Barcode" & Index), Barcode).Text = CStr(oRow!UPC).Trim
            DirectCast(ReportHeader.Controls("bcQR" & Index), Barcode).Text = CStr(oRow!UPC).Trim
            Talla = CStr(oRow!Talla)
            If IsNumeric(Talla) Then
                Talla = Format(CDec(Talla), "#.0")
            End If
            DirectCast(ReportHeader.Controls("txtTalla" & Index), TextBox).Text = Talla.Trim
            DirectCast(ReportHeader.Controls("txtPrecioP" & Index), TextBox).Text = Format(CDec(oRow!Precio), "$ #,###0.00")
            DirectCast(ReportHeader.Controls("txtPrecioF" & Index), TextBox).Text = Format(CDec(oRow!PrecioOferta), "$ #,###0.00")
            DirectCast(ReportHeader.Controls("txtModelo" & Index), TextBox).Text = CStr(oRow!CodArticulo).Trim
            DirectCast(ReportHeader.Controls("lblTalla" & Index), Label).Text = "Talla"
            DirectCast(ReportHeader.Controls("lblPrecioP" & Index), Label).Text = "Precio Público"
            DirectCast(ReportHeader.Controls("lblPrecioF" & Index), Label).Text = "Precio Factory"

            Index += 1

        Next

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtTalla1 As TextBox = Nothing
	Private txtPrecioF1 As TextBox = Nothing
	Private lblTalla1 As Label = Nothing
	Private lblPrecioP1 As Label = Nothing
	Private txtPrecioP1 As TextBox = Nothing
	Private lblPrecioF1 As Label = Nothing
	Private txtModelo1 As TextBox = Nothing
	Private txtTalla2 As TextBox = Nothing
	Private txtPrecioF2 As TextBox = Nothing
	Private lblTalla2 As Label = Nothing
	Private lblPrecioP2 As Label = Nothing
	Private txtPrecioP2 As TextBox = Nothing
	Private lblPrecioF2 As Label = Nothing
	Private txtModelo2 As TextBox = Nothing
	Private txtTalla3 As TextBox = Nothing
	Private txtPrecioF3 As TextBox = Nothing
	Private lblTalla3 As Label = Nothing
	Private lblPrecioP3 As Label = Nothing
	Private txtPrecioP3 As TextBox = Nothing
	Private lblPrecioF3 As Label = Nothing
	Private txtModelo3 As TextBox = Nothing
	Private txtTalla4 As TextBox = Nothing
	Private txtPrecioF4 As TextBox = Nothing
	Private lblTalla4 As Label = Nothing
	Private lblPrecioP4 As Label = Nothing
	Private txtPrecioP4 As TextBox = Nothing
	Private lblPrecioF4 As Label = Nothing
	Private txtModelo4 As TextBox = Nothing
	Private Barcode1 As Barcode = Nothing
	Private Barcode2 As Barcode = Nothing
	Private Barcode3 As Barcode = Nothing
	Private Barcode4 As Barcode = Nothing
	Private bcQR2 As Barcode = Nothing
	Private bcQR1 As Barcode = Nothing
	Private bcQR3 As Barcode = Nothing
	Private bcQR4 As Barcode = Nothing
	Private txtTalla5 As TextBox = Nothing
	Private txtPrecioF5 As TextBox = Nothing
	Private lblTalla5 As Label = Nothing
	Private lblPrecioP5 As Label = Nothing
	Private txtPrecioP5 As TextBox = Nothing
	Private lblPrecioF5 As Label = Nothing
	Private txtTalla6 As TextBox = Nothing
	Private txtPrecioF6 As TextBox = Nothing
	Private lblTalla6 As Label = Nothing
	Private lblPrecioP6 As Label = Nothing
	Private txtPrecioP6 As TextBox = Nothing
	Private lblPrecioF6 As Label = Nothing
	Private txtTalla7 As TextBox = Nothing
	Private txtPrecioF7 As TextBox = Nothing
	Private lblTalla7 As Label = Nothing
	Private lblPrecioP7 As Label = Nothing
	Private txtPrecioP7 As TextBox = Nothing
	Private lblPrecioF7 As Label = Nothing
	Private txtTalla8 As TextBox = Nothing
	Private txtPrecioF8 As TextBox = Nothing
	Private lblTalla8 As Label = Nothing
	Private lblPrecioP8 As Label = Nothing
	Private txtPrecioP8 As TextBox = Nothing
	Private lblPrecioF8 As Label = Nothing
	Private txtTalla9 As TextBox = Nothing
	Private txtPrecioF9 As TextBox = Nothing
	Private Barcode5 As Barcode = Nothing
	Private lblTalla9 As Label = Nothing
	Private lblPrecioP9 As Label = Nothing
	Private txtPrecioP9 As TextBox = Nothing
	Private lblPrecioF9 As Label = Nothing
	Private txtTalla10 As TextBox = Nothing
	Private txtPrecioF10 As TextBox = Nothing
	Private Barcode6 As Barcode = Nothing
	Private lblTalla10 As Label = Nothing
	Private lblPrecioP10 As Label = Nothing
	Private txtPrecioP10 As TextBox = Nothing
	Private lblPrecioF10 As Label = Nothing
	Private txtTalla11 As TextBox = Nothing
	Private txtPrecioF11 As TextBox = Nothing
	Private Barcode7 As Barcode = Nothing
	Private lblTalla11 As Label = Nothing
	Private lblPrecioP11 As Label = Nothing
	Private txtPrecioP11 As TextBox = Nothing
	Private lblPrecioF11 As Label = Nothing
	Private txtTalla12 As TextBox = Nothing
	Private txtPrecioF12 As TextBox = Nothing
	Private Barcode8 As Barcode = Nothing
	Private lblTalla12 As Label = Nothing
	Private lblPrecioP12 As Label = Nothing
	Private txtPrecioP12 As TextBox = Nothing
	Private lblPrecioF12 As Label = Nothing
	Private txtTalla13 As TextBox = Nothing
	Private txtPrecioF13 As TextBox = Nothing
	Private Barcode9 As Barcode = Nothing
	Private lblTalla13 As Label = Nothing
	Private lblPrecioP13 As Label = Nothing
	Private txtPrecioP13 As TextBox = Nothing
	Private lblPrecioF13 As Label = Nothing
	Private txtTalla14 As TextBox = Nothing
	Private txtPrecioF14 As TextBox = Nothing
	Private Barcode10 As Barcode = Nothing
	Private lblTalla14 As Label = Nothing
	Private lblPrecioP14 As Label = Nothing
	Private txtPrecioP14 As TextBox = Nothing
	Private lblPrecioF14 As Label = Nothing
	Private txtTalla15 As TextBox = Nothing
	Private txtPrecioF15 As TextBox = Nothing
	Private Barcode11 As Barcode = Nothing
	Private lblTalla15 As Label = Nothing
	Private lblPrecioP15 As Label = Nothing
	Private txtPrecioP15 As TextBox = Nothing
	Private lblPrecioF15 As Label = Nothing
	Private txtTalla16 As TextBox = Nothing
	Private txtPrecioF16 As TextBox = Nothing
	Private Barcode12 As Barcode = Nothing
	Private lblTalla16 As Label = Nothing
	Private lblPrecioP16 As Label = Nothing
	Private txtPrecioP16 As TextBox = Nothing
	Private lblPrecioF16 As Label = Nothing
	Private Barcode13 As Barcode = Nothing
	Private Barcode14 As Barcode = Nothing
	Private Barcode15 As Barcode = Nothing
	Private Barcode16 As Barcode = Nothing
	Private txtModelo5 As TextBox = Nothing
	Private txtModelo6 As TextBox = Nothing
	Private txtModelo7 As TextBox = Nothing
	Private txtModelo8 As TextBox = Nothing
	Private txtModelo9 As TextBox = Nothing
	Private txtModelo10 As TextBox = Nothing
	Private txtModelo11 As TextBox = Nothing
	Private txtModelo12 As TextBox = Nothing
	Private txtModelo13 As TextBox = Nothing
	Private txtModelo14 As TextBox = Nothing
	Private txtModelo15 As TextBox = Nothing
	Private txtModelo16 As TextBox = Nothing
	Private bcQR5 As Barcode = Nothing
	Private bcQR6 As Barcode = Nothing
	Private bcQR7 As Barcode = Nothing
	Private bcQR8 As Barcode = Nothing
	Private bcQR9 As Barcode = Nothing
	Private bcQR10 As Barcode = Nothing
	Private bcQR11 As Barcode = Nothing
	Private bcQR12 As Barcode = Nothing
	Private bcQR13 As Barcode = Nothing
	Private bcQR14 As Barcode = Nothing
	Private bcQR15 As Barcode = Nothing
	Private bcQR16 As Barcode = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEtiquetasPreciosFactory))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.txtTalla1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF1 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla1 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP1 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP1 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF1 = New DataDynamics.ActiveReports.Label()
            Me.txtModelo1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF2 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla2 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP2 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP2 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF2 = New DataDynamics.ActiveReports.Label()
            Me.txtModelo2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF3 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla3 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP3 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP3 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF3 = New DataDynamics.ActiveReports.Label()
            Me.txtModelo3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF4 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla4 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP4 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP4 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF4 = New DataDynamics.ActiveReports.Label()
            Me.txtModelo4 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode1 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode2 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode3 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode4 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR2 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR1 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR3 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR4 = New DataDynamics.ActiveReports.Barcode()
            Me.txtTalla5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF5 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla5 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP5 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP5 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF5 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF6 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla6 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP6 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP6 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF6 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF7 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla7 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP7 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP7 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF7 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF8 = New DataDynamics.ActiveReports.TextBox()
            Me.lblTalla8 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP8 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP8 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF8 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF9 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode5 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla9 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP9 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP9 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF9 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF10 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode6 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla10 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP10 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP10 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF10 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF11 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode7 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla11 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP11 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP11 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF11 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF12 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode8 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla12 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP12 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP12 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF12 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF13 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode9 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla13 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP13 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP13 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF13 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF14 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode10 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla14 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP14 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP14 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF14 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF15 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode11 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla15 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP15 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP15 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF15 = New DataDynamics.ActiveReports.Label()
            Me.txtTalla16 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioF16 = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode12 = New DataDynamics.ActiveReports.Barcode()
            Me.lblTalla16 = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioP16 = New DataDynamics.ActiveReports.Label()
            Me.txtPrecioP16 = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioF16 = New DataDynamics.ActiveReports.Label()
            Me.Barcode13 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode14 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode15 = New DataDynamics.ActiveReports.Barcode()
            Me.Barcode16 = New DataDynamics.ActiveReports.Barcode()
            Me.txtModelo5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo16 = New DataDynamics.ActiveReports.TextBox()
            Me.bcQR5 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR6 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR7 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR8 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR9 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR10 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR11 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR12 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR13 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR14 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR15 = New DataDynamics.ActiveReports.Barcode()
            Me.bcQR16 = New DataDynamics.ActiveReports.Barcode()
            CType(Me.txtTalla1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioF16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioP16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioP16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioF16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTalla1, Me.txtPrecioF1, Me.lblTalla1, Me.lblPrecioP1, Me.txtPrecioP1, Me.lblPrecioF1, Me.txtModelo1, Me.txtTalla2, Me.txtPrecioF2, Me.lblTalla2, Me.lblPrecioP2, Me.txtPrecioP2, Me.lblPrecioF2, Me.txtModelo2, Me.txtTalla3, Me.txtPrecioF3, Me.lblTalla3, Me.lblPrecioP3, Me.txtPrecioP3, Me.lblPrecioF3, Me.txtModelo3, Me.txtTalla4, Me.txtPrecioF4, Me.lblTalla4, Me.lblPrecioP4, Me.txtPrecioP4, Me.lblPrecioF4, Me.txtModelo4, Me.Barcode1, Me.Barcode2, Me.Barcode3, Me.Barcode4, Me.bcQR2, Me.bcQR1, Me.bcQR3, Me.bcQR4, Me.txtTalla5, Me.txtPrecioF5, Me.lblTalla5, Me.lblPrecioP5, Me.txtPrecioP5, Me.lblPrecioF5, Me.txtTalla6, Me.txtPrecioF6, Me.lblTalla6, Me.lblPrecioP6, Me.txtPrecioP6, Me.lblPrecioF6, Me.txtTalla7, Me.txtPrecioF7, Me.lblTalla7, Me.lblPrecioP7, Me.txtPrecioP7, Me.lblPrecioF7, Me.txtTalla8, Me.txtPrecioF8, Me.lblTalla8, Me.lblPrecioP8, Me.txtPrecioP8, Me.lblPrecioF8, Me.txtTalla9, Me.txtPrecioF9, Me.Barcode5, Me.lblTalla9, Me.lblPrecioP9, Me.txtPrecioP9, Me.lblPrecioF9, Me.txtTalla10, Me.txtPrecioF10, Me.Barcode6, Me.lblTalla10, Me.lblPrecioP10, Me.txtPrecioP10, Me.lblPrecioF10, Me.txtTalla11, Me.txtPrecioF11, Me.Barcode7, Me.lblTalla11, Me.lblPrecioP11, Me.txtPrecioP11, Me.lblPrecioF11, Me.txtTalla12, Me.txtPrecioF12, Me.Barcode8, Me.lblTalla12, Me.lblPrecioP12, Me.txtPrecioP12, Me.lblPrecioF12, Me.txtTalla13, Me.txtPrecioF13, Me.Barcode9, Me.lblTalla13, Me.lblPrecioP13, Me.txtPrecioP13, Me.lblPrecioF13, Me.txtTalla14, Me.txtPrecioF14, Me.Barcode10, Me.lblTalla14, Me.lblPrecioP14, Me.txtPrecioP14, Me.lblPrecioF14, Me.txtTalla15, Me.txtPrecioF15, Me.Barcode11, Me.lblTalla15, Me.lblPrecioP15, Me.txtPrecioP15, Me.lblPrecioF15, Me.txtTalla16, Me.txtPrecioF16, Me.Barcode12, Me.lblTalla16, Me.lblPrecioP16, Me.txtPrecioP16, Me.lblPrecioF16, Me.Barcode13, Me.Barcode14, Me.Barcode15, Me.Barcode16, Me.txtModelo5, Me.txtModelo6, Me.txtModelo7, Me.txtModelo8, Me.txtModelo9, Me.txtModelo10, Me.txtModelo11, Me.txtModelo12, Me.txtModelo13, Me.txtModelo14, Me.txtModelo15, Me.txtModelo16, Me.bcQR5, Me.bcQR6, Me.bcQR7, Me.bcQR8, Me.bcQR9, Me.bcQR10, Me.bcQR11, Me.bcQR12, Me.bcQR13, Me.bcQR14, Me.bcQR15, Me.bcQR16})
            Me.ReportHeader.Height = 9.875!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'txtTalla1
            '
            Me.txtTalla1.DataField = "Medidas"
            Me.txtTalla1.Height = 0.2!
            Me.txtTalla1.Left = 0.1254999!
            Me.txtTalla1.Name = "txtTalla1"
            Me.txtTalla1.OutputFormat = resources.GetString("txtTalla1.OutputFormat")
            Me.txtTalla1.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla1.Text = "29.0"
            Me.txtTalla1.Top = 1.0175!
            Me.txtTalla1.Width = 0.7495!
            '
            'txtPrecioF1
            '
            Me.txtPrecioF1.DataField = "Precio"
            Me.txtPrecioF1.Height = 0.2!
            Me.txtPrecioF1.Left = 0.125!
            Me.txtPrecioF1.Name = "txtPrecioF1"
            Me.txtPrecioF1.OutputFormat = resources.GetString("txtPrecioF1.OutputFormat")
            Me.txtPrecioF1.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF1.Text = "1102.46"
            Me.txtPrecioF1.Top = 1.55!
            Me.txtPrecioF1.Width = 1.9375!
            '
            'lblTalla1
            '
            Me.lblTalla1.Height = 0.1875!
            Me.lblTalla1.HyperLink = Nothing
            Me.lblTalla1.Left = 0.125!
            Me.lblTalla1.Name = "lblTalla1"
            Me.lblTalla1.Style = "text-align: center"
            Me.lblTalla1.Text = "Talla"
            Me.lblTalla1.Top = 0.8125!
            Me.lblTalla1.Width = 0.75!
            '
            'lblPrecioP1
            '
            Me.lblPrecioP1.Height = 0.1875!
            Me.lblPrecioP1.HyperLink = Nothing
            Me.lblPrecioP1.Left = 1.3125!
            Me.lblPrecioP1.Name = "lblPrecioP1"
            Me.lblPrecioP1.Style = "text-align: center"
            Me.lblPrecioP1.Text = "Precio Público"
            Me.lblPrecioP1.Top = 0.8125!
            Me.lblPrecioP1.Width = 0.75!
            '
            'txtPrecioP1
            '
            Me.txtPrecioP1.DataField = "Medidas"
            Me.txtPrecioP1.Height = 0.2!
            Me.txtPrecioP1.Left = 1.313!
            Me.txtPrecioP1.Name = "txtPrecioP1"
            Me.txtPrecioP1.OutputFormat = resources.GetString("txtPrecioP1.OutputFormat")
            Me.txtPrecioP1.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP1.Text = "1501.23"
            Me.txtPrecioP1.Top = 1.0175!
            Me.txtPrecioP1.Width = 0.7495!
            '
            'lblPrecioF1
            '
            Me.lblPrecioF1.Height = 0.1875!
            Me.lblPrecioF1.HyperLink = Nothing
            Me.lblPrecioF1.Left = 0.125!
            Me.lblPrecioF1.Name = "lblPrecioF1"
            Me.lblPrecioF1.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF1.Text = "Precio Factory"
            Me.lblPrecioF1.Top = 1.3125!
            Me.lblPrecioF1.Width = 1.9375!
            '
            'txtModelo1
            '
            Me.txtModelo1.DataField = "CodArticulo"
            Me.txtModelo1.Height = 0.2!
            Me.txtModelo1.Left = 0.25!
            Me.txtModelo1.Name = "txtModelo1"
            Me.txtModelo1.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo1.Text = "MODELO"
            Me.txtModelo1.Top = 0.5!
            Me.txtModelo1.Width = 1.25!
            '
            'txtTalla2
            '
            Me.txtTalla2.DataField = "Medidas"
            Me.txtTalla2.Height = 0.2!
            Me.txtTalla2.Left = 2.188!
            Me.txtTalla2.Name = "txtTalla2"
            Me.txtTalla2.OutputFormat = resources.GetString("txtTalla2.OutputFormat")
            Me.txtTalla2.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla2.Text = "29.0"
            Me.txtTalla2.Top = 1.0175!
            Me.txtTalla2.Width = 0.7495!
            '
            'txtPrecioF2
            '
            Me.txtPrecioF2.DataField = "Precio"
            Me.txtPrecioF2.Height = 0.2!
            Me.txtPrecioF2.Left = 2.1875!
            Me.txtPrecioF2.Name = "txtPrecioF2"
            Me.txtPrecioF2.OutputFormat = resources.GetString("txtPrecioF2.OutputFormat")
            Me.txtPrecioF2.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF2.Text = "1102.46"
            Me.txtPrecioF2.Top = 1.55!
            Me.txtPrecioF2.Width = 1.9375!
            '
            'lblTalla2
            '
            Me.lblTalla2.Height = 0.1875!
            Me.lblTalla2.HyperLink = Nothing
            Me.lblTalla2.Left = 2.1875!
            Me.lblTalla2.Name = "lblTalla2"
            Me.lblTalla2.Style = "text-align: center"
            Me.lblTalla2.Text = "Talla"
            Me.lblTalla2.Top = 0.8125!
            Me.lblTalla2.Width = 0.75!
            '
            'lblPrecioP2
            '
            Me.lblPrecioP2.Height = 0.1875!
            Me.lblPrecioP2.HyperLink = Nothing
            Me.lblPrecioP2.Left = 3.375!
            Me.lblPrecioP2.Name = "lblPrecioP2"
            Me.lblPrecioP2.Style = "text-align: center"
            Me.lblPrecioP2.Text = "Precio Público"
            Me.lblPrecioP2.Top = 0.8125!
            Me.lblPrecioP2.Width = 0.75!
            '
            'txtPrecioP2
            '
            Me.txtPrecioP2.DataField = "Medidas"
            Me.txtPrecioP2.Height = 0.2!
            Me.txtPrecioP2.Left = 3.3755!
            Me.txtPrecioP2.Name = "txtPrecioP2"
            Me.txtPrecioP2.OutputFormat = resources.GetString("txtPrecioP2.OutputFormat")
            Me.txtPrecioP2.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP2.Text = "1501.23"
            Me.txtPrecioP2.Top = 1.0175!
            Me.txtPrecioP2.Width = 0.7495!
            '
            'lblPrecioF2
            '
            Me.lblPrecioF2.Height = 0.1875!
            Me.lblPrecioF2.HyperLink = Nothing
            Me.lblPrecioF2.Left = 2.1875!
            Me.lblPrecioF2.Name = "lblPrecioF2"
            Me.lblPrecioF2.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF2.Text = "Precio Factory"
            Me.lblPrecioF2.Top = 1.3125!
            Me.lblPrecioF2.Width = 1.9375!
            '
            'txtModelo2
            '
            Me.txtModelo2.DataField = "CodArticulo"
            Me.txtModelo2.Height = 0.2!
            Me.txtModelo2.Left = 2.3125!
            Me.txtModelo2.Name = "txtModelo2"
            Me.txtModelo2.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo2.Text = "MODELO"
            Me.txtModelo2.Top = 0.5!
            Me.txtModelo2.Width = 1.25!
            '
            'txtTalla3
            '
            Me.txtTalla3.DataField = "Medidas"
            Me.txtTalla3.Height = 0.2!
            Me.txtTalla3.Left = 4.313!
            Me.txtTalla3.Name = "txtTalla3"
            Me.txtTalla3.OutputFormat = resources.GetString("txtTalla3.OutputFormat")
            Me.txtTalla3.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla3.Text = "29.0"
            Me.txtTalla3.Top = 1.0175!
            Me.txtTalla3.Width = 0.7495!
            '
            'txtPrecioF3
            '
            Me.txtPrecioF3.DataField = "Precio"
            Me.txtPrecioF3.Height = 0.2!
            Me.txtPrecioF3.Left = 4.3125!
            Me.txtPrecioF3.Name = "txtPrecioF3"
            Me.txtPrecioF3.OutputFormat = resources.GetString("txtPrecioF3.OutputFormat")
            Me.txtPrecioF3.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF3.Text = "1102.46"
            Me.txtPrecioF3.Top = 1.55!
            Me.txtPrecioF3.Width = 1.9375!
            '
            'lblTalla3
            '
            Me.lblTalla3.Height = 0.1875!
            Me.lblTalla3.HyperLink = Nothing
            Me.lblTalla3.Left = 4.3125!
            Me.lblTalla3.Name = "lblTalla3"
            Me.lblTalla3.Style = "text-align: center"
            Me.lblTalla3.Text = "Talla"
            Me.lblTalla3.Top = 0.8125!
            Me.lblTalla3.Width = 0.75!
            '
            'lblPrecioP3
            '
            Me.lblPrecioP3.Height = 0.1875!
            Me.lblPrecioP3.HyperLink = Nothing
            Me.lblPrecioP3.Left = 5.5!
            Me.lblPrecioP3.Name = "lblPrecioP3"
            Me.lblPrecioP3.Style = "text-align: center"
            Me.lblPrecioP3.Text = "Precio Público"
            Me.lblPrecioP3.Top = 0.8125!
            Me.lblPrecioP3.Width = 0.75!
            '
            'txtPrecioP3
            '
            Me.txtPrecioP3.DataField = "Medidas"
            Me.txtPrecioP3.Height = 0.2!
            Me.txtPrecioP3.Left = 5.5005!
            Me.txtPrecioP3.Name = "txtPrecioP3"
            Me.txtPrecioP3.OutputFormat = resources.GetString("txtPrecioP3.OutputFormat")
            Me.txtPrecioP3.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP3.Text = "1501.23"
            Me.txtPrecioP3.Top = 1.0175!
            Me.txtPrecioP3.Width = 0.7495!
            '
            'lblPrecioF3
            '
            Me.lblPrecioF3.Height = 0.1875!
            Me.lblPrecioF3.HyperLink = Nothing
            Me.lblPrecioF3.Left = 4.3125!
            Me.lblPrecioF3.Name = "lblPrecioF3"
            Me.lblPrecioF3.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF3.Text = "Precio Factory"
            Me.lblPrecioF3.Top = 1.3125!
            Me.lblPrecioF3.Width = 1.9375!
            '
            'txtModelo3
            '
            Me.txtModelo3.DataField = "CodArticulo"
            Me.txtModelo3.Height = 0.2!
            Me.txtModelo3.Left = 4.4375!
            Me.txtModelo3.Name = "txtModelo3"
            Me.txtModelo3.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo3.Text = "MODELO"
            Me.txtModelo3.Top = 0.5!
            Me.txtModelo3.Width = 1.25!
            '
            'txtTalla4
            '
            Me.txtTalla4.DataField = "Medidas"
            Me.txtTalla4.Height = 0.2!
            Me.txtTalla4.Left = 6.3755!
            Me.txtTalla4.Name = "txtTalla4"
            Me.txtTalla4.OutputFormat = resources.GetString("txtTalla4.OutputFormat")
            Me.txtTalla4.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla4.Text = "29.0"
            Me.txtTalla4.Top = 1.0175!
            Me.txtTalla4.Width = 0.7495!
            '
            'txtPrecioF4
            '
            Me.txtPrecioF4.DataField = "Precio"
            Me.txtPrecioF4.Height = 0.2!
            Me.txtPrecioF4.Left = 6.375!
            Me.txtPrecioF4.Name = "txtPrecioF4"
            Me.txtPrecioF4.OutputFormat = resources.GetString("txtPrecioF4.OutputFormat")
            Me.txtPrecioF4.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF4.Text = "1102.46"
            Me.txtPrecioF4.Top = 1.55!
            Me.txtPrecioF4.Width = 1.9375!
            '
            'lblTalla4
            '
            Me.lblTalla4.Height = 0.1875!
            Me.lblTalla4.HyperLink = Nothing
            Me.lblTalla4.Left = 6.375!
            Me.lblTalla4.Name = "lblTalla4"
            Me.lblTalla4.Style = "text-align: center"
            Me.lblTalla4.Text = "Talla"
            Me.lblTalla4.Top = 0.8125!
            Me.lblTalla4.Width = 0.75!
            '
            'lblPrecioP4
            '
            Me.lblPrecioP4.Height = 0.1875!
            Me.lblPrecioP4.HyperLink = Nothing
            Me.lblPrecioP4.Left = 7.5625!
            Me.lblPrecioP4.Name = "lblPrecioP4"
            Me.lblPrecioP4.Style = "text-align: center"
            Me.lblPrecioP4.Text = "Precio Público"
            Me.lblPrecioP4.Top = 0.8125!
            Me.lblPrecioP4.Width = 0.75!
            '
            'txtPrecioP4
            '
            Me.txtPrecioP4.DataField = "Medidas"
            Me.txtPrecioP4.Height = 0.2!
            Me.txtPrecioP4.Left = 7.563!
            Me.txtPrecioP4.Name = "txtPrecioP4"
            Me.txtPrecioP4.OutputFormat = resources.GetString("txtPrecioP4.OutputFormat")
            Me.txtPrecioP4.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP4.Text = "1501.23"
            Me.txtPrecioP4.Top = 1.0175!
            Me.txtPrecioP4.Width = 0.7495!
            '
            'lblPrecioF4
            '
            Me.lblPrecioF4.Height = 0.1875!
            Me.lblPrecioF4.HyperLink = Nothing
            Me.lblPrecioF4.Left = 6.375!
            Me.lblPrecioF4.Name = "lblPrecioF4"
            Me.lblPrecioF4.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF4.Text = "Precio Factory"
            Me.lblPrecioF4.Top = 1.3125!
            Me.lblPrecioF4.Width = 1.9375!
            '
            'txtModelo4
            '
            Me.txtModelo4.DataField = "CodArticulo"
            Me.txtModelo4.Height = 0.2!
            Me.txtModelo4.Left = 6.5!
            Me.txtModelo4.Name = "txtModelo4"
            Me.txtModelo4.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo4.Text = "MODELO"
            Me.txtModelo4.Top = 0.5!
            Me.txtModelo4.Width = 1.25!
            '
            'Barcode1
            '
            Me.Barcode1.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode1.Height = 0.3125!
            Me.Barcode1.Left = 0.25!
            Me.Barcode1.Name = "Barcode1"
            Me.Barcode1.Text = "000000097621674901"
            Me.Barcode1.Top = 0.125!
            Me.Barcode1.Width = 1.25!
            '
            'Barcode2
            '
            Me.Barcode2.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode2.Height = 0.3125!
            Me.Barcode2.Left = 2.3125!
            Me.Barcode2.Name = "Barcode2"
            Me.Barcode2.Text = "1234567890"
            Me.Barcode2.Top = 0.125!
            Me.Barcode2.Width = 1.25!
            '
            'Barcode3
            '
            Me.Barcode3.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode3.Height = 0.3125!
            Me.Barcode3.Left = 4.4375!
            Me.Barcode3.Name = "Barcode3"
            Me.Barcode3.Text = "Barcode1"
            Me.Barcode3.Top = 0.125!
            Me.Barcode3.Width = 1.25!
            '
            'Barcode4
            '
            Me.Barcode4.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode4.Height = 0.3125!
            Me.Barcode4.Left = 6.5!
            Me.Barcode4.Name = "Barcode4"
            Me.Barcode4.Text = "Barcode1"
            Me.Barcode4.Top = 0.125!
            Me.Barcode4.Width = 1.25!
            '
            'bcQR2
            '
            Me.bcQR2.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR2.Height = 0.5!
            Me.bcQR2.Left = 3.625!
            Me.bcQR2.Name = "bcQR2"
            Me.bcQR2.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR2.Text = "000000097621674901"
            Me.bcQR2.Top = 0.0625!
            Me.bcQR2.Width = 0.5!
            '
            'bcQR1
            '
            Me.bcQR1.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR1.Height = 0.5!
            Me.bcQR1.Left = 1.5625!
            Me.bcQR1.Name = "bcQR1"
            Me.bcQR1.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR1.Text = "000000097621674901"
            Me.bcQR1.Top = 0.0625!
            Me.bcQR1.Width = 0.5!
            '
            'bcQR3
            '
            Me.bcQR3.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR3.Height = 0.5!
            Me.bcQR3.Left = 5.75!
            Me.bcQR3.Name = "bcQR3"
            Me.bcQR3.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR3.Text = "000000097621674901"
            Me.bcQR3.Top = 0.0625!
            Me.bcQR3.Width = 0.5!
            '
            'bcQR4
            '
            Me.bcQR4.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR4.Height = 0.5!
            Me.bcQR4.Left = 7.8125!
            Me.bcQR4.Name = "bcQR4"
            Me.bcQR4.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR4.Text = "000000097621674901"
            Me.bcQR4.Top = 0.0625!
            Me.bcQR4.Width = 0.5!
            '
            'txtTalla5
            '
            Me.txtTalla5.DataField = "Medidas"
            Me.txtTalla5.Height = 0.2!
            Me.txtTalla5.Left = 0.1254999!
            Me.txtTalla5.Name = "txtTalla5"
            Me.txtTalla5.OutputFormat = resources.GetString("txtTalla5.OutputFormat")
            Me.txtTalla5.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla5.Text = "29.0"
            Me.txtTalla5.Top = 3.705!
            Me.txtTalla5.Width = 0.7495!
            '
            'txtPrecioF5
            '
            Me.txtPrecioF5.DataField = "Precio"
            Me.txtPrecioF5.Height = 0.2!
            Me.txtPrecioF5.Left = 0.125!
            Me.txtPrecioF5.Name = "txtPrecioF5"
            Me.txtPrecioF5.OutputFormat = resources.GetString("txtPrecioF5.OutputFormat")
            Me.txtPrecioF5.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF5.Text = "1102.46"
            Me.txtPrecioF5.Top = 4.2375!
            Me.txtPrecioF5.Width = 1.9375!
            '
            'lblTalla5
            '
            Me.lblTalla5.Height = 0.1875!
            Me.lblTalla5.HyperLink = Nothing
            Me.lblTalla5.Left = 0.125!
            Me.lblTalla5.Name = "lblTalla5"
            Me.lblTalla5.Style = "text-align: center"
            Me.lblTalla5.Text = "Talla"
            Me.lblTalla5.Top = 3.5!
            Me.lblTalla5.Width = 0.75!
            '
            'lblPrecioP5
            '
            Me.lblPrecioP5.Height = 0.1875!
            Me.lblPrecioP5.HyperLink = Nothing
            Me.lblPrecioP5.Left = 1.3125!
            Me.lblPrecioP5.Name = "lblPrecioP5"
            Me.lblPrecioP5.Style = "text-align: center"
            Me.lblPrecioP5.Text = "Precio Público"
            Me.lblPrecioP5.Top = 3.5!
            Me.lblPrecioP5.Width = 0.75!
            '
            'txtPrecioP5
            '
            Me.txtPrecioP5.DataField = "Medidas"
            Me.txtPrecioP5.Height = 0.2!
            Me.txtPrecioP5.Left = 1.313!
            Me.txtPrecioP5.Name = "txtPrecioP5"
            Me.txtPrecioP5.OutputFormat = resources.GetString("txtPrecioP5.OutputFormat")
            Me.txtPrecioP5.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP5.Text = "1501.23"
            Me.txtPrecioP5.Top = 3.705!
            Me.txtPrecioP5.Width = 0.7495!
            '
            'lblPrecioF5
            '
            Me.lblPrecioF5.Height = 0.1875!
            Me.lblPrecioF5.HyperLink = Nothing
            Me.lblPrecioF5.Left = 0.125!
            Me.lblPrecioF5.Name = "lblPrecioF5"
            Me.lblPrecioF5.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF5.Text = "Precio Factory"
            Me.lblPrecioF5.Top = 4!
            Me.lblPrecioF5.Width = 1.9375!
            '
            'txtTalla6
            '
            Me.txtTalla6.DataField = "Medidas"
            Me.txtTalla6.Height = 0.2!
            Me.txtTalla6.Left = 2.188!
            Me.txtTalla6.Name = "txtTalla6"
            Me.txtTalla6.OutputFormat = resources.GetString("txtTalla6.OutputFormat")
            Me.txtTalla6.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla6.Text = "29.0"
            Me.txtTalla6.Top = 3.705!
            Me.txtTalla6.Width = 0.7495!
            '
            'txtPrecioF6
            '
            Me.txtPrecioF6.DataField = "Precio"
            Me.txtPrecioF6.Height = 0.2!
            Me.txtPrecioF6.Left = 2.188!
            Me.txtPrecioF6.Name = "txtPrecioF6"
            Me.txtPrecioF6.OutputFormat = resources.GetString("txtPrecioF6.OutputFormat")
            Me.txtPrecioF6.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF6.Text = "1102.46"
            Me.txtPrecioF6.Top = 4.2375!
            Me.txtPrecioF6.Width = 1.937!
            '
            'lblTalla6
            '
            Me.lblTalla6.Height = 0.1875!
            Me.lblTalla6.HyperLink = Nothing
            Me.lblTalla6.Left = 2.188!
            Me.lblTalla6.Name = "lblTalla6"
            Me.lblTalla6.Style = "text-align: center"
            Me.lblTalla6.Text = "Talla"
            Me.lblTalla6.Top = 3.5!
            Me.lblTalla6.Width = 0.75!
            '
            'lblPrecioP6
            '
            Me.lblPrecioP6.Height = 0.1875!
            Me.lblPrecioP6.HyperLink = Nothing
            Me.lblPrecioP6.Left = 3.375!
            Me.lblPrecioP6.Name = "lblPrecioP6"
            Me.lblPrecioP6.Style = "text-align: center"
            Me.lblPrecioP6.Text = "Precio Público"
            Me.lblPrecioP6.Top = 3.5!
            Me.lblPrecioP6.Width = 0.75!
            '
            'txtPrecioP6
            '
            Me.txtPrecioP6.DataField = "Medidas"
            Me.txtPrecioP6.Height = 0.2!
            Me.txtPrecioP6.Left = 3.375!
            Me.txtPrecioP6.Name = "txtPrecioP6"
            Me.txtPrecioP6.OutputFormat = resources.GetString("txtPrecioP6.OutputFormat")
            Me.txtPrecioP6.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP6.Text = "1501.23"
            Me.txtPrecioP6.Top = 3.705!
            Me.txtPrecioP6.Width = 0.7495!
            '
            'lblPrecioF6
            '
            Me.lblPrecioF6.Height = 0.1875!
            Me.lblPrecioF6.HyperLink = Nothing
            Me.lblPrecioF6.Left = 2.188!
            Me.lblPrecioF6.Name = "lblPrecioF6"
            Me.lblPrecioF6.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF6.Text = "Precio Factory"
            Me.lblPrecioF6.Top = 4!
            Me.lblPrecioF6.Width = 1.937!
            '
            'txtTalla7
            '
            Me.txtTalla7.DataField = "Medidas"
            Me.txtTalla7.Height = 0.2!
            Me.txtTalla7.Left = 4.313!
            Me.txtTalla7.Name = "txtTalla7"
            Me.txtTalla7.OutputFormat = resources.GetString("txtTalla7.OutputFormat")
            Me.txtTalla7.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla7.Text = "29.0"
            Me.txtTalla7.Top = 3.705!
            Me.txtTalla7.Width = 0.7495!
            '
            'txtPrecioF7
            '
            Me.txtPrecioF7.DataField = "Precio"
            Me.txtPrecioF7.Height = 0.2!
            Me.txtPrecioF7.Left = 4.3125!
            Me.txtPrecioF7.Name = "txtPrecioF7"
            Me.txtPrecioF7.OutputFormat = resources.GetString("txtPrecioF7.OutputFormat")
            Me.txtPrecioF7.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF7.Text = "1102.46"
            Me.txtPrecioF7.Top = 4.2375!
            Me.txtPrecioF7.Width = 1.9375!
            '
            'lblTalla7
            '
            Me.lblTalla7.Height = 0.1875!
            Me.lblTalla7.HyperLink = Nothing
            Me.lblTalla7.Left = 4.3125!
            Me.lblTalla7.Name = "lblTalla7"
            Me.lblTalla7.Style = "text-align: center"
            Me.lblTalla7.Text = "Talla"
            Me.lblTalla7.Top = 3.5!
            Me.lblTalla7.Width = 0.75!
            '
            'lblPrecioP7
            '
            Me.lblPrecioP7.Height = 0.1875!
            Me.lblPrecioP7.HyperLink = Nothing
            Me.lblPrecioP7.Left = 5.5!
            Me.lblPrecioP7.Name = "lblPrecioP7"
            Me.lblPrecioP7.Style = "text-align: center"
            Me.lblPrecioP7.Text = "Precio Público"
            Me.lblPrecioP7.Top = 3.5!
            Me.lblPrecioP7.Width = 0.75!
            '
            'txtPrecioP7
            '
            Me.txtPrecioP7.DataField = "Medidas"
            Me.txtPrecioP7.Height = 0.2!
            Me.txtPrecioP7.Left = 5.5005!
            Me.txtPrecioP7.Name = "txtPrecioP7"
            Me.txtPrecioP7.OutputFormat = resources.GetString("txtPrecioP7.OutputFormat")
            Me.txtPrecioP7.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP7.Text = "1501.23"
            Me.txtPrecioP7.Top = 3.705!
            Me.txtPrecioP7.Width = 0.7495!
            '
            'lblPrecioF7
            '
            Me.lblPrecioF7.Height = 0.1875!
            Me.lblPrecioF7.HyperLink = Nothing
            Me.lblPrecioF7.Left = 4.3125!
            Me.lblPrecioF7.Name = "lblPrecioF7"
            Me.lblPrecioF7.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF7.Text = "Precio Factory"
            Me.lblPrecioF7.Top = 4!
            Me.lblPrecioF7.Width = 1.9375!
            '
            'txtTalla8
            '
            Me.txtTalla8.DataField = "Medidas"
            Me.txtTalla8.Height = 0.2!
            Me.txtTalla8.Left = 6.3755!
            Me.txtTalla8.Name = "txtTalla8"
            Me.txtTalla8.OutputFormat = resources.GetString("txtTalla8.OutputFormat")
            Me.txtTalla8.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla8.Text = "29.0"
            Me.txtTalla8.Top = 3.705!
            Me.txtTalla8.Width = 0.7495!
            '
            'txtPrecioF8
            '
            Me.txtPrecioF8.DataField = "Precio"
            Me.txtPrecioF8.Height = 0.2!
            Me.txtPrecioF8.Left = 6.375!
            Me.txtPrecioF8.Name = "txtPrecioF8"
            Me.txtPrecioF8.OutputFormat = resources.GetString("txtPrecioF8.OutputFormat")
            Me.txtPrecioF8.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF8.Text = "1102.46"
            Me.txtPrecioF8.Top = 4.2375!
            Me.txtPrecioF8.Width = 1.9375!
            '
            'lblTalla8
            '
            Me.lblTalla8.Height = 0.1875!
            Me.lblTalla8.HyperLink = Nothing
            Me.lblTalla8.Left = 6.375!
            Me.lblTalla8.Name = "lblTalla8"
            Me.lblTalla8.Style = "text-align: center"
            Me.lblTalla8.Text = "Talla"
            Me.lblTalla8.Top = 3.5!
            Me.lblTalla8.Width = 0.75!
            '
            'lblPrecioP8
            '
            Me.lblPrecioP8.Height = 0.1875!
            Me.lblPrecioP8.HyperLink = Nothing
            Me.lblPrecioP8.Left = 7.5625!
            Me.lblPrecioP8.Name = "lblPrecioP8"
            Me.lblPrecioP8.Style = "text-align: center"
            Me.lblPrecioP8.Text = "Precio Público"
            Me.lblPrecioP8.Top = 3.5!
            Me.lblPrecioP8.Width = 0.75!
            '
            'txtPrecioP8
            '
            Me.txtPrecioP8.DataField = "Medidas"
            Me.txtPrecioP8.Height = 0.2!
            Me.txtPrecioP8.Left = 7.563!
            Me.txtPrecioP8.Name = "txtPrecioP8"
            Me.txtPrecioP8.OutputFormat = resources.GetString("txtPrecioP8.OutputFormat")
            Me.txtPrecioP8.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP8.Text = "1501.23"
            Me.txtPrecioP8.Top = 3.705!
            Me.txtPrecioP8.Width = 0.7495!
            '
            'lblPrecioF8
            '
            Me.lblPrecioF8.Height = 0.1875!
            Me.lblPrecioF8.HyperLink = Nothing
            Me.lblPrecioF8.Left = 6.375!
            Me.lblPrecioF8.Name = "lblPrecioF8"
            Me.lblPrecioF8.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF8.Text = "Precio Factory"
            Me.lblPrecioF8.Top = 4!
            Me.lblPrecioF8.Width = 1.9375!
            '
            'txtTalla9
            '
            Me.txtTalla9.DataField = "Medidas"
            Me.txtTalla9.Height = 0.2!
            Me.txtTalla9.Left = 0.1255!
            Me.txtTalla9.Name = "txtTalla9"
            Me.txtTalla9.OutputFormat = resources.GetString("txtTalla9.OutputFormat")
            Me.txtTalla9.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla9.Text = "29.0"
            Me.txtTalla9.Top = 6.3925!
            Me.txtTalla9.Width = 0.7495!
            '
            'txtPrecioF9
            '
            Me.txtPrecioF9.DataField = "Precio"
            Me.txtPrecioF9.Height = 0.2!
            Me.txtPrecioF9.Left = 0.1255!
            Me.txtPrecioF9.Name = "txtPrecioF9"
            Me.txtPrecioF9.OutputFormat = resources.GetString("txtPrecioF9.OutputFormat")
            Me.txtPrecioF9.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF9.Text = "1102.46"
            Me.txtPrecioF9.Top = 6.925!
            Me.txtPrecioF9.Width = 1.937!
            '
            'Barcode5
            '
            Me.Barcode5.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode5.Height = 0.3125!
            Me.Barcode5.Left = 0.25!
            Me.Barcode5.Name = "Barcode5"
            Me.Barcode5.Text = "Barcode1"
            Me.Barcode5.Top = 2.8125!
            Me.Barcode5.Width = 1.25!
            '
            'lblTalla9
            '
            Me.lblTalla9.Height = 0.1875!
            Me.lblTalla9.HyperLink = Nothing
            Me.lblTalla9.Left = 0.1255!
            Me.lblTalla9.Name = "lblTalla9"
            Me.lblTalla9.Style = "text-align: center"
            Me.lblTalla9.Text = "Talla"
            Me.lblTalla9.Top = 6.1875!
            Me.lblTalla9.Width = 0.75!
            '
            'lblPrecioP9
            '
            Me.lblPrecioP9.Height = 0.1875!
            Me.lblPrecioP9.HyperLink = Nothing
            Me.lblPrecioP9.Left = 1.3125!
            Me.lblPrecioP9.Name = "lblPrecioP9"
            Me.lblPrecioP9.Style = "text-align: center"
            Me.lblPrecioP9.Text = "Precio Público"
            Me.lblPrecioP9.Top = 6.1875!
            Me.lblPrecioP9.Width = 0.75!
            '
            'txtPrecioP9
            '
            Me.txtPrecioP9.DataField = "Medidas"
            Me.txtPrecioP9.Height = 0.2!
            Me.txtPrecioP9.Left = 1.3125!
            Me.txtPrecioP9.Name = "txtPrecioP9"
            Me.txtPrecioP9.OutputFormat = resources.GetString("txtPrecioP9.OutputFormat")
            Me.txtPrecioP9.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP9.Text = "1501.23"
            Me.txtPrecioP9.Top = 6.3925!
            Me.txtPrecioP9.Width = 0.7495!
            '
            'lblPrecioF9
            '
            Me.lblPrecioF9.Height = 0.1875!
            Me.lblPrecioF9.HyperLink = Nothing
            Me.lblPrecioF9.Left = 0.1255!
            Me.lblPrecioF9.Name = "lblPrecioF9"
            Me.lblPrecioF9.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF9.Text = "Precio Factory"
            Me.lblPrecioF9.Top = 6.6875!
            Me.lblPrecioF9.Width = 1.937!
            '
            'txtTalla10
            '
            Me.txtTalla10.DataField = "Medidas"
            Me.txtTalla10.Height = 0.2!
            Me.txtTalla10.Left = 2.188!
            Me.txtTalla10.Name = "txtTalla10"
            Me.txtTalla10.OutputFormat = resources.GetString("txtTalla10.OutputFormat")
            Me.txtTalla10.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla10.Text = "29.0"
            Me.txtTalla10.Top = 6.3925!
            Me.txtTalla10.Width = 0.7495!
            '
            'txtPrecioF10
            '
            Me.txtPrecioF10.DataField = "Precio"
            Me.txtPrecioF10.Height = 0.2!
            Me.txtPrecioF10.Left = 2.1875!
            Me.txtPrecioF10.Name = "txtPrecioF10"
            Me.txtPrecioF10.OutputFormat = resources.GetString("txtPrecioF10.OutputFormat")
            Me.txtPrecioF10.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF10.Text = "1102.46"
            Me.txtPrecioF10.Top = 6.925!
            Me.txtPrecioF10.Width = 1.9375!
            '
            'Barcode6
            '
            Me.Barcode6.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode6.Height = 0.3125!
            Me.Barcode6.Left = 2.313!
            Me.Barcode6.Name = "Barcode6"
            Me.Barcode6.Text = "Barcode1"
            Me.Barcode6.Top = 2.8125!
            Me.Barcode6.Width = 1.2495!
            '
            'lblTalla10
            '
            Me.lblTalla10.Height = 0.1875!
            Me.lblTalla10.HyperLink = Nothing
            Me.lblTalla10.Left = 2.1875!
            Me.lblTalla10.Name = "lblTalla10"
            Me.lblTalla10.Style = "text-align: center"
            Me.lblTalla10.Text = "Talla"
            Me.lblTalla10.Top = 6.1875!
            Me.lblTalla10.Width = 0.75!
            '
            'lblPrecioP10
            '
            Me.lblPrecioP10.Height = 0.1875!
            Me.lblPrecioP10.HyperLink = Nothing
            Me.lblPrecioP10.Left = 3.375!
            Me.lblPrecioP10.Name = "lblPrecioP10"
            Me.lblPrecioP10.Style = "text-align: center"
            Me.lblPrecioP10.Text = "Precio Público"
            Me.lblPrecioP10.Top = 6.1875!
            Me.lblPrecioP10.Width = 0.75!
            '
            'txtPrecioP10
            '
            Me.txtPrecioP10.DataField = "Medidas"
            Me.txtPrecioP10.Height = 0.2!
            Me.txtPrecioP10.Left = 3.375!
            Me.txtPrecioP10.Name = "txtPrecioP10"
            Me.txtPrecioP10.OutputFormat = resources.GetString("txtPrecioP10.OutputFormat")
            Me.txtPrecioP10.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP10.Text = "1501.23"
            Me.txtPrecioP10.Top = 6.3925!
            Me.txtPrecioP10.Width = 0.7495!
            '
            'lblPrecioF10
            '
            Me.lblPrecioF10.Height = 0.1875!
            Me.lblPrecioF10.HyperLink = Nothing
            Me.lblPrecioF10.Left = 2.1875!
            Me.lblPrecioF10.Name = "lblPrecioF10"
            Me.lblPrecioF10.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF10.Text = "Precio Factory"
            Me.lblPrecioF10.Top = 6.6875!
            Me.lblPrecioF10.Width = 1.9375!
            '
            'txtTalla11
            '
            Me.txtTalla11.DataField = "Medidas"
            Me.txtTalla11.Height = 0.2!
            Me.txtTalla11.Left = 4.313!
            Me.txtTalla11.Name = "txtTalla11"
            Me.txtTalla11.OutputFormat = resources.GetString("txtTalla11.OutputFormat")
            Me.txtTalla11.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla11.Text = "29.0"
            Me.txtTalla11.Top = 6.3925!
            Me.txtTalla11.Width = 0.7495!
            '
            'txtPrecioF11
            '
            Me.txtPrecioF11.DataField = "Precio"
            Me.txtPrecioF11.Height = 0.2!
            Me.txtPrecioF11.Left = 4.3125!
            Me.txtPrecioF11.Name = "txtPrecioF11"
            Me.txtPrecioF11.OutputFormat = resources.GetString("txtPrecioF11.OutputFormat")
            Me.txtPrecioF11.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF11.Text = "1102.46"
            Me.txtPrecioF11.Top = 6.925!
            Me.txtPrecioF11.Width = 1.9375!
            '
            'Barcode7
            '
            Me.Barcode7.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode7.Height = 0.3125!
            Me.Barcode7.Left = 4.4375!
            Me.Barcode7.Name = "Barcode7"
            Me.Barcode7.Text = "Barcode1"
            Me.Barcode7.Top = 2.8125!
            Me.Barcode7.Width = 1.25!
            '
            'lblTalla11
            '
            Me.lblTalla11.Height = 0.1875!
            Me.lblTalla11.HyperLink = Nothing
            Me.lblTalla11.Left = 4.3125!
            Me.lblTalla11.Name = "lblTalla11"
            Me.lblTalla11.Style = "text-align: center"
            Me.lblTalla11.Text = "Talla"
            Me.lblTalla11.Top = 6.1875!
            Me.lblTalla11.Width = 0.75!
            '
            'lblPrecioP11
            '
            Me.lblPrecioP11.Height = 0.1875!
            Me.lblPrecioP11.HyperLink = Nothing
            Me.lblPrecioP11.Left = 5.5!
            Me.lblPrecioP11.Name = "lblPrecioP11"
            Me.lblPrecioP11.Style = "text-align: center"
            Me.lblPrecioP11.Text = "Precio Público"
            Me.lblPrecioP11.Top = 6.1875!
            Me.lblPrecioP11.Width = 0.75!
            '
            'txtPrecioP11
            '
            Me.txtPrecioP11.DataField = "Medidas"
            Me.txtPrecioP11.Height = 0.2!
            Me.txtPrecioP11.Left = 5.5!
            Me.txtPrecioP11.Name = "txtPrecioP11"
            Me.txtPrecioP11.OutputFormat = resources.GetString("txtPrecioP11.OutputFormat")
            Me.txtPrecioP11.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP11.Text = "1501.23"
            Me.txtPrecioP11.Top = 6.3925!
            Me.txtPrecioP11.Width = 0.7495!
            '
            'lblPrecioF11
            '
            Me.lblPrecioF11.Height = 0.1875!
            Me.lblPrecioF11.HyperLink = Nothing
            Me.lblPrecioF11.Left = 4.3125!
            Me.lblPrecioF11.Name = "lblPrecioF11"
            Me.lblPrecioF11.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF11.Text = "Precio Factory"
            Me.lblPrecioF11.Top = 6.6875!
            Me.lblPrecioF11.Width = 1.9375!
            '
            'txtTalla12
            '
            Me.txtTalla12.DataField = "Medidas"
            Me.txtTalla12.Height = 0.2!
            Me.txtTalla12.Left = 6.3755!
            Me.txtTalla12.Name = "txtTalla12"
            Me.txtTalla12.OutputFormat = resources.GetString("txtTalla12.OutputFormat")
            Me.txtTalla12.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla12.Text = "29.0"
            Me.txtTalla12.Top = 6.3925!
            Me.txtTalla12.Width = 0.7495!
            '
            'txtPrecioF12
            '
            Me.txtPrecioF12.DataField = "Precio"
            Me.txtPrecioF12.Height = 0.2!
            Me.txtPrecioF12.Left = 6.3755!
            Me.txtPrecioF12.Name = "txtPrecioF12"
            Me.txtPrecioF12.OutputFormat = resources.GetString("txtPrecioF12.OutputFormat")
            Me.txtPrecioF12.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF12.Text = "1102.46"
            Me.txtPrecioF12.Top = 6.925!
            Me.txtPrecioF12.Width = 1.937!
            '
            'Barcode8
            '
            Me.Barcode8.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode8.Height = 0.3125!
            Me.Barcode8.Left = 6.5!
            Me.Barcode8.Name = "Barcode8"
            Me.Barcode8.Text = "Barcode1"
            Me.Barcode8.Top = 2.8125!
            Me.Barcode8.Width = 1.25!
            '
            'lblTalla12
            '
            Me.lblTalla12.Height = 0.1875!
            Me.lblTalla12.HyperLink = Nothing
            Me.lblTalla12.Left = 6.3755!
            Me.lblTalla12.Name = "lblTalla12"
            Me.lblTalla12.Style = "text-align: center"
            Me.lblTalla12.Text = "Talla"
            Me.lblTalla12.Top = 6.1875!
            Me.lblTalla12.Width = 0.75!
            '
            'lblPrecioP12
            '
            Me.lblPrecioP12.Height = 0.1875!
            Me.lblPrecioP12.HyperLink = Nothing
            Me.lblPrecioP12.Left = 7.5625!
            Me.lblPrecioP12.Name = "lblPrecioP12"
            Me.lblPrecioP12.Style = "text-align: center"
            Me.lblPrecioP12.Text = "Precio Público"
            Me.lblPrecioP12.Top = 6.1875!
            Me.lblPrecioP12.Width = 0.75!
            '
            'txtPrecioP12
            '
            Me.txtPrecioP12.DataField = "Medidas"
            Me.txtPrecioP12.Height = 0.2!
            Me.txtPrecioP12.Left = 7.5625!
            Me.txtPrecioP12.Name = "txtPrecioP12"
            Me.txtPrecioP12.OutputFormat = resources.GetString("txtPrecioP12.OutputFormat")
            Me.txtPrecioP12.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP12.Text = "1501.23"
            Me.txtPrecioP12.Top = 6.3925!
            Me.txtPrecioP12.Width = 0.7495!
            '
            'lblPrecioF12
            '
            Me.lblPrecioF12.Height = 0.1875!
            Me.lblPrecioF12.HyperLink = Nothing
            Me.lblPrecioF12.Left = 6.3755!
            Me.lblPrecioF12.Name = "lblPrecioF12"
            Me.lblPrecioF12.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF12.Text = "Precio Factory"
            Me.lblPrecioF12.Top = 6.6875!
            Me.lblPrecioF12.Width = 1.937!
            '
            'txtTalla13
            '
            Me.txtTalla13.DataField = "Medidas"
            Me.txtTalla13.Height = 0.2!
            Me.txtTalla13.Left = 0.1254999!
            Me.txtTalla13.Name = "txtTalla13"
            Me.txtTalla13.OutputFormat = resources.GetString("txtTalla13.OutputFormat")
            Me.txtTalla13.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla13.Text = "29.0"
            Me.txtTalla13.Top = 9.08!
            Me.txtTalla13.Width = 0.7495!
            '
            'txtPrecioF13
            '
            Me.txtPrecioF13.DataField = "Precio"
            Me.txtPrecioF13.Height = 0.2!
            Me.txtPrecioF13.Left = 0.125!
            Me.txtPrecioF13.Name = "txtPrecioF13"
            Me.txtPrecioF13.OutputFormat = resources.GetString("txtPrecioF13.OutputFormat")
            Me.txtPrecioF13.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF13.Text = "1102.46"
            Me.txtPrecioF13.Top = 9.6125!
            Me.txtPrecioF13.Width = 1.9375!
            '
            'Barcode9
            '
            Me.Barcode9.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode9.Height = 0.3125!
            Me.Barcode9.Left = 0.25!
            Me.Barcode9.Name = "Barcode9"
            Me.Barcode9.Text = "Barcode1"
            Me.Barcode9.Top = 5.500999!
            Me.Barcode9.Width = 1.25!
            '
            'lblTalla13
            '
            Me.lblTalla13.Height = 0.1875!
            Me.lblTalla13.HyperLink = Nothing
            Me.lblTalla13.Left = 0.125!
            Me.lblTalla13.Name = "lblTalla13"
            Me.lblTalla13.Style = "text-align: center"
            Me.lblTalla13.Text = "Talla"
            Me.lblTalla13.Top = 8.875!
            Me.lblTalla13.Width = 0.75!
            '
            'lblPrecioP13
            '
            Me.lblPrecioP13.Height = 0.1875!
            Me.lblPrecioP13.HyperLink = Nothing
            Me.lblPrecioP13.Left = 1.3125!
            Me.lblPrecioP13.Name = "lblPrecioP13"
            Me.lblPrecioP13.Style = "text-align: center"
            Me.lblPrecioP13.Text = "Precio Público"
            Me.lblPrecioP13.Top = 8.875!
            Me.lblPrecioP13.Width = 0.75!
            '
            'txtPrecioP13
            '
            Me.txtPrecioP13.DataField = "Medidas"
            Me.txtPrecioP13.Height = 0.2!
            Me.txtPrecioP13.Left = 1.313!
            Me.txtPrecioP13.Name = "txtPrecioP13"
            Me.txtPrecioP13.OutputFormat = resources.GetString("txtPrecioP13.OutputFormat")
            Me.txtPrecioP13.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP13.Text = "1501.23"
            Me.txtPrecioP13.Top = 9.08!
            Me.txtPrecioP13.Width = 0.7495!
            '
            'lblPrecioF13
            '
            Me.lblPrecioF13.Height = 0.1875!
            Me.lblPrecioF13.HyperLink = Nothing
            Me.lblPrecioF13.Left = 0.125!
            Me.lblPrecioF13.Name = "lblPrecioF13"
            Me.lblPrecioF13.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF13.Text = "Precio Factory"
            Me.lblPrecioF13.Top = 9.375!
            Me.lblPrecioF13.Width = 1.9375!
            '
            'txtTalla14
            '
            Me.txtTalla14.DataField = "Medidas"
            Me.txtTalla14.Height = 0.2!
            Me.txtTalla14.Left = 2.188!
            Me.txtTalla14.Name = "txtTalla14"
            Me.txtTalla14.OutputFormat = resources.GetString("txtTalla14.OutputFormat")
            Me.txtTalla14.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla14.Text = "29.0"
            Me.txtTalla14.Top = 9.08!
            Me.txtTalla14.Width = 0.7495!
            '
            'txtPrecioF14
            '
            Me.txtPrecioF14.DataField = "Precio"
            Me.txtPrecioF14.Height = 0.2!
            Me.txtPrecioF14.Left = 2.1875!
            Me.txtPrecioF14.Name = "txtPrecioF14"
            Me.txtPrecioF14.OutputFormat = resources.GetString("txtPrecioF14.OutputFormat")
            Me.txtPrecioF14.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF14.Text = "1102.46"
            Me.txtPrecioF14.Top = 9.6125!
            Me.txtPrecioF14.Width = 1.9375!
            '
            'Barcode10
            '
            Me.Barcode10.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode10.Height = 0.3125!
            Me.Barcode10.Left = 2.3125!
            Me.Barcode10.Name = "Barcode10"
            Me.Barcode10.Text = "Barcode1"
            Me.Barcode10.Top = 5.5!
            Me.Barcode10.Width = 1.25!
            '
            'lblTalla14
            '
            Me.lblTalla14.Height = 0.1875!
            Me.lblTalla14.HyperLink = Nothing
            Me.lblTalla14.Left = 2.1875!
            Me.lblTalla14.Name = "lblTalla14"
            Me.lblTalla14.Style = "text-align: center"
            Me.lblTalla14.Text = "Talla"
            Me.lblTalla14.Top = 8.875!
            Me.lblTalla14.Width = 0.75!
            '
            'lblPrecioP14
            '
            Me.lblPrecioP14.Height = 0.1875!
            Me.lblPrecioP14.HyperLink = Nothing
            Me.lblPrecioP14.Left = 3.375!
            Me.lblPrecioP14.Name = "lblPrecioP14"
            Me.lblPrecioP14.Style = "text-align: center"
            Me.lblPrecioP14.Text = "Precio Público"
            Me.lblPrecioP14.Top = 8.875!
            Me.lblPrecioP14.Width = 0.75!
            '
            'txtPrecioP14
            '
            Me.txtPrecioP14.DataField = "Medidas"
            Me.txtPrecioP14.Height = 0.2!
            Me.txtPrecioP14.Left = 3.375!
            Me.txtPrecioP14.Name = "txtPrecioP14"
            Me.txtPrecioP14.OutputFormat = resources.GetString("txtPrecioP14.OutputFormat")
            Me.txtPrecioP14.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP14.Text = "1501.23"
            Me.txtPrecioP14.Top = 9.08!
            Me.txtPrecioP14.Width = 0.7495!
            '
            'lblPrecioF14
            '
            Me.lblPrecioF14.Height = 0.1875!
            Me.lblPrecioF14.HyperLink = Nothing
            Me.lblPrecioF14.Left = 2.1875!
            Me.lblPrecioF14.Name = "lblPrecioF14"
            Me.lblPrecioF14.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF14.Text = "Precio Factory"
            Me.lblPrecioF14.Top = 9.375!
            Me.lblPrecioF14.Width = 1.9375!
            '
            'txtTalla15
            '
            Me.txtTalla15.DataField = "Medidas"
            Me.txtTalla15.Height = 0.2!
            Me.txtTalla15.Left = 4.313!
            Me.txtTalla15.Name = "txtTalla15"
            Me.txtTalla15.OutputFormat = resources.GetString("txtTalla15.OutputFormat")
            Me.txtTalla15.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla15.Text = "29.0"
            Me.txtTalla15.Top = 9.08!
            Me.txtTalla15.Width = 0.7495!
            '
            'txtPrecioF15
            '
            Me.txtPrecioF15.DataField = "Precio"
            Me.txtPrecioF15.Height = 0.2!
            Me.txtPrecioF15.Left = 4.3125!
            Me.txtPrecioF15.Name = "txtPrecioF15"
            Me.txtPrecioF15.OutputFormat = resources.GetString("txtPrecioF15.OutputFormat")
            Me.txtPrecioF15.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF15.Text = "1102.46"
            Me.txtPrecioF15.Top = 9.6125!
            Me.txtPrecioF15.Width = 1.9375!
            '
            'Barcode11
            '
            Me.Barcode11.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode11.Height = 0.3125!
            Me.Barcode11.Left = 4.4375!
            Me.Barcode11.Name = "Barcode11"
            Me.Barcode11.Text = "Barcode1"
            Me.Barcode11.Top = 5.5!
            Me.Barcode11.Width = 1.2495!
            '
            'lblTalla15
            '
            Me.lblTalla15.Height = 0.1875!
            Me.lblTalla15.HyperLink = Nothing
            Me.lblTalla15.Left = 4.3125!
            Me.lblTalla15.Name = "lblTalla15"
            Me.lblTalla15.Style = "text-align: center"
            Me.lblTalla15.Text = "Talla"
            Me.lblTalla15.Top = 8.875!
            Me.lblTalla15.Width = 0.75!
            '
            'lblPrecioP15
            '
            Me.lblPrecioP15.Height = 0.1875!
            Me.lblPrecioP15.HyperLink = Nothing
            Me.lblPrecioP15.Left = 5.5!
            Me.lblPrecioP15.Name = "lblPrecioP15"
            Me.lblPrecioP15.Style = "text-align: center"
            Me.lblPrecioP15.Text = "Precio Público"
            Me.lblPrecioP15.Top = 8.875!
            Me.lblPrecioP15.Width = 0.75!
            '
            'txtPrecioP15
            '
            Me.txtPrecioP15.DataField = "Medidas"
            Me.txtPrecioP15.Height = 0.2!
            Me.txtPrecioP15.Left = 5.5005!
            Me.txtPrecioP15.Name = "txtPrecioP15"
            Me.txtPrecioP15.OutputFormat = resources.GetString("txtPrecioP15.OutputFormat")
            Me.txtPrecioP15.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP15.Text = "1501.23"
            Me.txtPrecioP15.Top = 9.08!
            Me.txtPrecioP15.Width = 0.7495!
            '
            'lblPrecioF15
            '
            Me.lblPrecioF15.Height = 0.1875!
            Me.lblPrecioF15.HyperLink = Nothing
            Me.lblPrecioF15.Left = 4.3125!
            Me.lblPrecioF15.Name = "lblPrecioF15"
            Me.lblPrecioF15.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF15.Text = "Precio Factory"
            Me.lblPrecioF15.Top = 9.375!
            Me.lblPrecioF15.Width = 1.9375!
            '
            'txtTalla16
            '
            Me.txtTalla16.DataField = "Medidas"
            Me.txtTalla16.Height = 0.2!
            Me.txtTalla16.Left = 6.3755!
            Me.txtTalla16.Name = "txtTalla16"
            Me.txtTalla16.OutputFormat = resources.GetString("txtTalla16.OutputFormat")
            Me.txtTalla16.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Arial"
            Me.txtTalla16.Text = "29.0"
            Me.txtTalla16.Top = 9.08!
            Me.txtTalla16.Width = 0.7495!
            '
            'txtPrecioF16
            '
            Me.txtPrecioF16.DataField = "Precio"
            Me.txtPrecioF16.Height = 0.2!
            Me.txtPrecioF16.Left = 6.375!
            Me.txtPrecioF16.Name = "txtPrecioF16"
            Me.txtPrecioF16.OutputFormat = resources.GetString("txtPrecioF16.OutputFormat")
            Me.txtPrecioF16.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecioF16.Text = "1102.46"
            Me.txtPrecioF16.Top = 9.6125!
            Me.txtPrecioF16.Width = 1.9375!
            '
            'Barcode12
            '
            Me.Barcode12.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode12.Height = 0.3125!
            Me.Barcode12.Left = 6.5005!
            Me.Barcode12.Name = "Barcode12"
            Me.Barcode12.Text = "Barcode1"
            Me.Barcode12.Top = 5.5!
            Me.Barcode12.Width = 1.2495!
            '
            'lblTalla16
            '
            Me.lblTalla16.Height = 0.1875!
            Me.lblTalla16.HyperLink = Nothing
            Me.lblTalla16.Left = 6.375!
            Me.lblTalla16.Name = "lblTalla16"
            Me.lblTalla16.Style = "text-align: center"
            Me.lblTalla16.Text = "Talla"
            Me.lblTalla16.Top = 8.875!
            Me.lblTalla16.Width = 0.75!
            '
            'lblPrecioP16
            '
            Me.lblPrecioP16.Height = 0.1875!
            Me.lblPrecioP16.HyperLink = Nothing
            Me.lblPrecioP16.Left = 7.5625!
            Me.lblPrecioP16.Name = "lblPrecioP16"
            Me.lblPrecioP16.Style = "text-align: center"
            Me.lblPrecioP16.Text = "Precio Público"
            Me.lblPrecioP16.Top = 8.875!
            Me.lblPrecioP16.Width = 0.75!
            '
            'txtPrecioP16
            '
            Me.txtPrecioP16.DataField = "Medidas"
            Me.txtPrecioP16.Height = 0.2!
            Me.txtPrecioP16.Left = 7.563!
            Me.txtPrecioP16.Name = "txtPrecioP16"
            Me.txtPrecioP16.OutputFormat = resources.GetString("txtPrecioP16.OutputFormat")
            Me.txtPrecioP16.Style = "text-decoration: line-through; text-align: center; font-size: 9.75pt; font-family"& _ 
                ": Arial"
            Me.txtPrecioP16.Text = "1501.23"
            Me.txtPrecioP16.Top = 9.08!
            Me.txtPrecioP16.Width = 0.7495!
            '
            'lblPrecioF16
            '
            Me.lblPrecioF16.Height = 0.1875!
            Me.lblPrecioF16.HyperLink = Nothing
            Me.lblPrecioF16.Left = 6.375!
            Me.lblPrecioF16.Name = "lblPrecioF16"
            Me.lblPrecioF16.Style = "text-align: center; font-weight: bold; font-size: 12pt"
            Me.lblPrecioF16.Text = "Precio Factory"
            Me.lblPrecioF16.Top = 9.375!
            Me.lblPrecioF16.Width = 1.9375!
            '
            'Barcode13
            '
            Me.Barcode13.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode13.Height = 0.3125!
            Me.Barcode13.Left = 0.25!
            Me.Barcode13.Name = "Barcode13"
            Me.Barcode13.Text = "Barcode13"
            Me.Barcode13.Top = 8.1875!
            Me.Barcode13.Width = 1.25!
            '
            'Barcode14
            '
            Me.Barcode14.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode14.Height = 0.3125!
            Me.Barcode14.Left = 2.3125!
            Me.Barcode14.Name = "Barcode14"
            Me.Barcode14.Text = "Barcode1"
            Me.Barcode14.Top = 8.1875!
            Me.Barcode14.Width = 1.25!
            '
            'Barcode15
            '
            Me.Barcode15.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode15.Height = 0.3125!
            Me.Barcode15.Left = 4.4375!
            Me.Barcode15.Name = "Barcode15"
            Me.Barcode15.Text = "Barcode1"
            Me.Barcode15.Top = 8.1875!
            Me.Barcode15.Width = 1.25!
            '
            'Barcode16
            '
            Me.Barcode16.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode16.Height = 0.3125!
            Me.Barcode16.Left = 6.5!
            Me.Barcode16.Name = "Barcode16"
            Me.Barcode16.Text = "Barcode1"
            Me.Barcode16.Top = 8.1875!
            Me.Barcode16.Width = 1.25!
            '
            'txtModelo5
            '
            Me.txtModelo5.DataField = "CodArticulo"
            Me.txtModelo5.Height = 0.2!
            Me.txtModelo5.Left = 0.25!
            Me.txtModelo5.Name = "txtModelo5"
            Me.txtModelo5.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo5.Text = "MODELO"
            Me.txtModelo5.Top = 3.1875!
            Me.txtModelo5.Width = 1.25!
            '
            'txtModelo6
            '
            Me.txtModelo6.DataField = "CodArticulo"
            Me.txtModelo6.Height = 0.2!
            Me.txtModelo6.Left = 2.3125!
            Me.txtModelo6.Name = "txtModelo6"
            Me.txtModelo6.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo6.Text = "MODELO"
            Me.txtModelo6.Top = 3.1875!
            Me.txtModelo6.Width = 1.25!
            '
            'txtModelo7
            '
            Me.txtModelo7.DataField = "CodArticulo"
            Me.txtModelo7.Height = 0.2!
            Me.txtModelo7.Left = 4.4375!
            Me.txtModelo7.Name = "txtModelo7"
            Me.txtModelo7.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo7.Text = "MODELO"
            Me.txtModelo7.Top = 3.1875!
            Me.txtModelo7.Width = 1.25!
            '
            'txtModelo8
            '
            Me.txtModelo8.DataField = "CodArticulo"
            Me.txtModelo8.Height = 0.2!
            Me.txtModelo8.Left = 6.5!
            Me.txtModelo8.Name = "txtModelo8"
            Me.txtModelo8.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo8.Text = "MODELO"
            Me.txtModelo8.Top = 3.1875!
            Me.txtModelo8.Width = 1.25!
            '
            'txtModelo9
            '
            Me.txtModelo9.DataField = "CodArticulo"
            Me.txtModelo9.Height = 0.2!
            Me.txtModelo9.Left = 0.25!
            Me.txtModelo9.Name = "txtModelo9"
            Me.txtModelo9.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo9.Text = "MODELO"
            Me.txtModelo9.Top = 5.875!
            Me.txtModelo9.Width = 1.25!
            '
            'txtModelo10
            '
            Me.txtModelo10.DataField = "CodArticulo"
            Me.txtModelo10.Height = 0.2!
            Me.txtModelo10.Left = 2.313!
            Me.txtModelo10.Name = "txtModelo10"
            Me.txtModelo10.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo10.Text = "MODELO"
            Me.txtModelo10.Top = 5.875!
            Me.txtModelo10.Width = 1.2495!
            '
            'txtModelo11
            '
            Me.txtModelo11.DataField = "CodArticulo"
            Me.txtModelo11.Height = 0.2!
            Me.txtModelo11.Left = 4.4375!
            Me.txtModelo11.Name = "txtModelo11"
            Me.txtModelo11.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo11.Text = "MODELO"
            Me.txtModelo11.Top = 5.875!
            Me.txtModelo11.Width = 1.2495!
            '
            'txtModelo12
            '
            Me.txtModelo12.DataField = "CodArticulo"
            Me.txtModelo12.Height = 0.2!
            Me.txtModelo12.Left = 6.5005!
            Me.txtModelo12.Name = "txtModelo12"
            Me.txtModelo12.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo12.Text = "MODELO"
            Me.txtModelo12.Top = 5.875!
            Me.txtModelo12.Width = 1.2495!
            '
            'txtModelo13
            '
            Me.txtModelo13.DataField = "CodArticulo"
            Me.txtModelo13.Height = 0.2!
            Me.txtModelo13.Left = 0.25!
            Me.txtModelo13.Name = "txtModelo13"
            Me.txtModelo13.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo13.Text = "MODELO"
            Me.txtModelo13.Top = 8.5625!
            Me.txtModelo13.Width = 1.25!
            '
            'txtModelo14
            '
            Me.txtModelo14.DataField = "CodArticulo"
            Me.txtModelo14.Height = 0.2!
            Me.txtModelo14.Left = 2.3125!
            Me.txtModelo14.Name = "txtModelo14"
            Me.txtModelo14.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo14.Text = "MODELO"
            Me.txtModelo14.Top = 8.5625!
            Me.txtModelo14.Width = 1.25!
            '
            'txtModelo15
            '
            Me.txtModelo15.DataField = "CodArticulo"
            Me.txtModelo15.Height = 0.2!
            Me.txtModelo15.Left = 4.4375!
            Me.txtModelo15.Name = "txtModelo15"
            Me.txtModelo15.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo15.Text = "MODELO"
            Me.txtModelo15.Top = 8.5625!
            Me.txtModelo15.Width = 1.25!
            '
            'txtModelo16
            '
            Me.txtModelo16.DataField = "CodArticulo"
            Me.txtModelo16.Height = 0.2!
            Me.txtModelo16.Left = 6.5!
            Me.txtModelo16.Name = "txtModelo16"
            Me.txtModelo16.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; font-family: Arial"
            Me.txtModelo16.Text = "MODELO"
            Me.txtModelo16.Top = 8.5625!
            Me.txtModelo16.Width = 1.25!
            '
            'bcQR5
            '
            Me.bcQR5.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR5.Height = 0.5!
            Me.bcQR5.Left = 1.5625!
            Me.bcQR5.Name = "bcQR5"
            Me.bcQR5.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR5.Text = "000000097621674901"
            Me.bcQR5.Top = 2.75!
            Me.bcQR5.Width = 0.5!
            '
            'bcQR6
            '
            Me.bcQR6.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR6.Height = 0.5!
            Me.bcQR6.Left = 3.625!
            Me.bcQR6.Name = "bcQR6"
            Me.bcQR6.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR6.Text = "000000097621674901"
            Me.bcQR6.Top = 2.75!
            Me.bcQR6.Width = 0.5!
            '
            'bcQR7
            '
            Me.bcQR7.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR7.Height = 0.5!
            Me.bcQR7.Left = 5.75!
            Me.bcQR7.Name = "bcQR7"
            Me.bcQR7.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR7.Text = "000000097621674901"
            Me.bcQR7.Top = 2.75!
            Me.bcQR7.Width = 0.5!
            '
            'bcQR8
            '
            Me.bcQR8.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR8.Height = 0.5!
            Me.bcQR8.Left = 7.8125!
            Me.bcQR8.Name = "bcQR8"
            Me.bcQR8.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR8.Text = "000000097621674901"
            Me.bcQR8.Top = 2.75!
            Me.bcQR8.Width = 0.5!
            '
            'bcQR9
            '
            Me.bcQR9.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR9.Height = 0.5!
            Me.bcQR9.Left = 1.5625!
            Me.bcQR9.Name = "bcQR9"
            Me.bcQR9.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR9.Text = "000000097621674901"
            Me.bcQR9.Top = 5.4375!
            Me.bcQR9.Width = 0.5!
            '
            'bcQR10
            '
            Me.bcQR10.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR10.Height = 0.5!
            Me.bcQR10.Left = 3.625!
            Me.bcQR10.Name = "bcQR10"
            Me.bcQR10.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR10.Text = "000000097621674901"
            Me.bcQR10.Top = 5.4375!
            Me.bcQR10.Width = 0.5!
            '
            'bcQR11
            '
            Me.bcQR11.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR11.Height = 0.5!
            Me.bcQR11.Left = 5.75!
            Me.bcQR11.Name = "bcQR11"
            Me.bcQR11.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR11.Text = "000000097621674901"
            Me.bcQR11.Top = 5.4375!
            Me.bcQR11.Width = 0.5!
            '
            'bcQR12
            '
            Me.bcQR12.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR12.Height = 0.5!
            Me.bcQR12.Left = 7.8125!
            Me.bcQR12.Name = "bcQR12"
            Me.bcQR12.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR12.Text = "000000097621674901"
            Me.bcQR12.Top = 5.4375!
            Me.bcQR12.Width = 0.5!
            '
            'bcQR13
            '
            Me.bcQR13.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR13.Height = 0.5!
            Me.bcQR13.Left = 1.5625!
            Me.bcQR13.Name = "bcQR13"
            Me.bcQR13.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR13.Text = "000000097621674901"
            Me.bcQR13.Top = 8.125!
            Me.bcQR13.Width = 0.5!
            '
            'bcQR14
            '
            Me.bcQR14.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR14.Height = 0.5!
            Me.bcQR14.Left = 3.625!
            Me.bcQR14.Name = "bcQR14"
            Me.bcQR14.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR14.Text = "000000097621674901"
            Me.bcQR14.Top = 8.125!
            Me.bcQR14.Width = 0.5!
            '
            'bcQR15
            '
            Me.bcQR15.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR15.Height = 0.5!
            Me.bcQR15.Left = 5.75!
            Me.bcQR15.Name = "bcQR15"
            Me.bcQR15.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR15.Text = "000000097621674901"
            Me.bcQR15.Top = 8.125!
            Me.bcQR15.Width = 0.5!
            '
            'bcQR16
            '
            Me.bcQR16.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcQR16.Height = 0.5!
            Me.bcQR16.Left = 7.8125!
            Me.bcQR16.Name = "bcQR16"
            Me.bcQR16.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.bcQR16.Text = "000000097621674901"
            Me.bcQR16.Top = 8.125!
            Me.bcQR16.Width = 0.5!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.1!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0.6!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 8.385417!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtTalla1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioF16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioP16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioP16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioF16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub LimpiarCampos()

        For i As Integer = 1 To 16
            DirectCast(ReportHeader.Controls("txtPrecioP" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtPrecioF" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtTalla" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtModelo" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("Barcode" & i), Barcode).Text = ""
            DirectCast(ReportHeader.Controls("lblPrecioP" & i), Label).Text = ""
            DirectCast(ReportHeader.Controls("lblPrecioF" & i), Label).Text = ""
            DirectCast(ReportHeader.Controls("lblTalla" & i), Label).Text = ""
            DirectCast(ReportHeader.Controls("bcQR" & i), Barcode).Text = ""
        Next i

    End Sub

End Class
