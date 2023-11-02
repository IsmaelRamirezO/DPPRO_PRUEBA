Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiquetasPrecioFactory
    Inherits ActiveReport

    Public Sub New(ByVal dtCodigos As DataTable, ByVal Index As Integer)
        MyBase.New()
        InitializeReport()

        LimpiarCampos()

        For Each oRow As DataRow In dtCodigos.Rows

            DirectCast(ReportHeader.Controls("Barcode" & Index), TextBox).Text = oRow!UPC
            DirectCast(ReportHeader.Controls("txtTalla" & Index), TextBox).Text = CStr(oRow!Talla).Trim
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
	Private txtTalla5 As TextBox = Nothing
	Private txtPrecioF5 As TextBox = Nothing
	Private Barcode1 As Barcode = Nothing
	Private lblTalla5 As Label = Nothing
	Private lblPrecioP5 As Label = Nothing
	Private txtPrecioP5 As TextBox = Nothing
	Private lblPrecioF5 As Label = Nothing
	Private txtTalla6 As TextBox = Nothing
	Private txtPrecioF6 As TextBox = Nothing
	Private Barcode2 As Barcode = Nothing
	Private lblTalla6 As Label = Nothing
	Private lblPrecioP6 As Label = Nothing
	Private txtPrecioP6 As TextBox = Nothing
	Private lblPrecioF6 As Label = Nothing
	Private txtTalla7 As TextBox = Nothing
	Private txtPrecioF7 As TextBox = Nothing
	Private Barcode3 As Barcode = Nothing
	Private lblTalla7 As Label = Nothing
	Private lblPrecioP7 As Label = Nothing
	Private txtPrecioP7 As TextBox = Nothing
	Private lblPrecioF7 As Label = Nothing
	Private txtTalla8 As TextBox = Nothing
	Private txtPrecioF8 As TextBox = Nothing
	Private Barcode4 As Barcode = Nothing
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
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "DportenisPro.DPTienda.rptEtiquetasPrecioFactory.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.txtTalla1 = CType(Me.ReportHeader.Controls(0),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF1 = CType(Me.ReportHeader.Controls(1),DataDynamics.ActiveReports.TextBox)
		Me.lblTalla1 = CType(Me.ReportHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP1 = CType(Me.ReportHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP1 = CType(Me.ReportHeader.Controls(4),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF1 = CType(Me.ReportHeader.Controls(5),DataDynamics.ActiveReports.Label)
		Me.txtModelo1 = CType(Me.ReportHeader.Controls(6),DataDynamics.ActiveReports.TextBox)
		Me.txtTalla2 = CType(Me.ReportHeader.Controls(7),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF2 = CType(Me.ReportHeader.Controls(8),DataDynamics.ActiveReports.TextBox)
		Me.lblTalla2 = CType(Me.ReportHeader.Controls(9),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP2 = CType(Me.ReportHeader.Controls(10),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP2 = CType(Me.ReportHeader.Controls(11),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF2 = CType(Me.ReportHeader.Controls(12),DataDynamics.ActiveReports.Label)
		Me.txtModelo2 = CType(Me.ReportHeader.Controls(13),DataDynamics.ActiveReports.TextBox)
		Me.txtTalla3 = CType(Me.ReportHeader.Controls(14),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF3 = CType(Me.ReportHeader.Controls(15),DataDynamics.ActiveReports.TextBox)
		Me.lblTalla3 = CType(Me.ReportHeader.Controls(16),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP3 = CType(Me.ReportHeader.Controls(17),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP3 = CType(Me.ReportHeader.Controls(18),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF3 = CType(Me.ReportHeader.Controls(19),DataDynamics.ActiveReports.Label)
		Me.txtModelo3 = CType(Me.ReportHeader.Controls(20),DataDynamics.ActiveReports.TextBox)
		Me.txtTalla4 = CType(Me.ReportHeader.Controls(21),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF4 = CType(Me.ReportHeader.Controls(22),DataDynamics.ActiveReports.TextBox)
		Me.lblTalla4 = CType(Me.ReportHeader.Controls(23),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP4 = CType(Me.ReportHeader.Controls(24),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP4 = CType(Me.ReportHeader.Controls(25),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF4 = CType(Me.ReportHeader.Controls(26),DataDynamics.ActiveReports.Label)
		Me.txtModelo4 = CType(Me.ReportHeader.Controls(27),DataDynamics.ActiveReports.TextBox)
		Me.txtTalla5 = CType(Me.ReportHeader.Controls(28),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF5 = CType(Me.ReportHeader.Controls(29),DataDynamics.ActiveReports.TextBox)
		Me.Barcode1 = CType(Me.ReportHeader.Controls(30),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla5 = CType(Me.ReportHeader.Controls(31),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP5 = CType(Me.ReportHeader.Controls(32),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP5 = CType(Me.ReportHeader.Controls(33),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF5 = CType(Me.ReportHeader.Controls(34),DataDynamics.ActiveReports.Label)
		Me.txtTalla6 = CType(Me.ReportHeader.Controls(35),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF6 = CType(Me.ReportHeader.Controls(36),DataDynamics.ActiveReports.TextBox)
		Me.Barcode2 = CType(Me.ReportHeader.Controls(37),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla6 = CType(Me.ReportHeader.Controls(38),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP6 = CType(Me.ReportHeader.Controls(39),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP6 = CType(Me.ReportHeader.Controls(40),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF6 = CType(Me.ReportHeader.Controls(41),DataDynamics.ActiveReports.Label)
		Me.txtTalla7 = CType(Me.ReportHeader.Controls(42),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF7 = CType(Me.ReportHeader.Controls(43),DataDynamics.ActiveReports.TextBox)
		Me.Barcode3 = CType(Me.ReportHeader.Controls(44),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla7 = CType(Me.ReportHeader.Controls(45),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP7 = CType(Me.ReportHeader.Controls(46),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP7 = CType(Me.ReportHeader.Controls(47),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF7 = CType(Me.ReportHeader.Controls(48),DataDynamics.ActiveReports.Label)
		Me.txtTalla8 = CType(Me.ReportHeader.Controls(49),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF8 = CType(Me.ReportHeader.Controls(50),DataDynamics.ActiveReports.TextBox)
		Me.Barcode4 = CType(Me.ReportHeader.Controls(51),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla8 = CType(Me.ReportHeader.Controls(52),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP8 = CType(Me.ReportHeader.Controls(53),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP8 = CType(Me.ReportHeader.Controls(54),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF8 = CType(Me.ReportHeader.Controls(55),DataDynamics.ActiveReports.Label)
		Me.txtTalla9 = CType(Me.ReportHeader.Controls(56),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF9 = CType(Me.ReportHeader.Controls(57),DataDynamics.ActiveReports.TextBox)
		Me.Barcode5 = CType(Me.ReportHeader.Controls(58),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla9 = CType(Me.ReportHeader.Controls(59),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP9 = CType(Me.ReportHeader.Controls(60),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP9 = CType(Me.ReportHeader.Controls(61),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF9 = CType(Me.ReportHeader.Controls(62),DataDynamics.ActiveReports.Label)
		Me.txtTalla10 = CType(Me.ReportHeader.Controls(63),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF10 = CType(Me.ReportHeader.Controls(64),DataDynamics.ActiveReports.TextBox)
		Me.Barcode6 = CType(Me.ReportHeader.Controls(65),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla10 = CType(Me.ReportHeader.Controls(66),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP10 = CType(Me.ReportHeader.Controls(67),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP10 = CType(Me.ReportHeader.Controls(68),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF10 = CType(Me.ReportHeader.Controls(69),DataDynamics.ActiveReports.Label)
		Me.txtTalla11 = CType(Me.ReportHeader.Controls(70),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF11 = CType(Me.ReportHeader.Controls(71),DataDynamics.ActiveReports.TextBox)
		Me.Barcode7 = CType(Me.ReportHeader.Controls(72),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla11 = CType(Me.ReportHeader.Controls(73),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP11 = CType(Me.ReportHeader.Controls(74),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP11 = CType(Me.ReportHeader.Controls(75),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF11 = CType(Me.ReportHeader.Controls(76),DataDynamics.ActiveReports.Label)
		Me.txtTalla12 = CType(Me.ReportHeader.Controls(77),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF12 = CType(Me.ReportHeader.Controls(78),DataDynamics.ActiveReports.TextBox)
		Me.Barcode8 = CType(Me.ReportHeader.Controls(79),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla12 = CType(Me.ReportHeader.Controls(80),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP12 = CType(Me.ReportHeader.Controls(81),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP12 = CType(Me.ReportHeader.Controls(82),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF12 = CType(Me.ReportHeader.Controls(83),DataDynamics.ActiveReports.Label)
		Me.txtTalla13 = CType(Me.ReportHeader.Controls(84),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF13 = CType(Me.ReportHeader.Controls(85),DataDynamics.ActiveReports.TextBox)
		Me.Barcode9 = CType(Me.ReportHeader.Controls(86),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla13 = CType(Me.ReportHeader.Controls(87),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP13 = CType(Me.ReportHeader.Controls(88),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP13 = CType(Me.ReportHeader.Controls(89),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF13 = CType(Me.ReportHeader.Controls(90),DataDynamics.ActiveReports.Label)
		Me.txtTalla14 = CType(Me.ReportHeader.Controls(91),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF14 = CType(Me.ReportHeader.Controls(92),DataDynamics.ActiveReports.TextBox)
		Me.Barcode10 = CType(Me.ReportHeader.Controls(93),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla14 = CType(Me.ReportHeader.Controls(94),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP14 = CType(Me.ReportHeader.Controls(95),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP14 = CType(Me.ReportHeader.Controls(96),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF14 = CType(Me.ReportHeader.Controls(97),DataDynamics.ActiveReports.Label)
		Me.txtTalla15 = CType(Me.ReportHeader.Controls(98),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF15 = CType(Me.ReportHeader.Controls(99),DataDynamics.ActiveReports.TextBox)
		Me.Barcode11 = CType(Me.ReportHeader.Controls(100),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla15 = CType(Me.ReportHeader.Controls(101),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP15 = CType(Me.ReportHeader.Controls(102),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP15 = CType(Me.ReportHeader.Controls(103),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF15 = CType(Me.ReportHeader.Controls(104),DataDynamics.ActiveReports.Label)
		Me.txtTalla16 = CType(Me.ReportHeader.Controls(105),DataDynamics.ActiveReports.TextBox)
		Me.txtPrecioF16 = CType(Me.ReportHeader.Controls(106),DataDynamics.ActiveReports.TextBox)
		Me.Barcode12 = CType(Me.ReportHeader.Controls(107),DataDynamics.ActiveReports.Barcode)
		Me.lblTalla16 = CType(Me.ReportHeader.Controls(108),DataDynamics.ActiveReports.Label)
		Me.lblPrecioP16 = CType(Me.ReportHeader.Controls(109),DataDynamics.ActiveReports.Label)
		Me.txtPrecioP16 = CType(Me.ReportHeader.Controls(110),DataDynamics.ActiveReports.TextBox)
		Me.lblPrecioF16 = CType(Me.ReportHeader.Controls(111),DataDynamics.ActiveReports.Label)
		Me.Barcode13 = CType(Me.ReportHeader.Controls(112),DataDynamics.ActiveReports.Barcode)
		Me.Barcode14 = CType(Me.ReportHeader.Controls(113),DataDynamics.ActiveReports.Barcode)
		Me.Barcode15 = CType(Me.ReportHeader.Controls(114),DataDynamics.ActiveReports.Barcode)
		Me.Barcode16 = CType(Me.ReportHeader.Controls(115),DataDynamics.ActiveReports.Barcode)
		Me.txtModelo5 = CType(Me.ReportHeader.Controls(116),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo6 = CType(Me.ReportHeader.Controls(117),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo7 = CType(Me.ReportHeader.Controls(118),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo8 = CType(Me.ReportHeader.Controls(119),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo9 = CType(Me.ReportHeader.Controls(120),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo10 = CType(Me.ReportHeader.Controls(121),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo11 = CType(Me.ReportHeader.Controls(122),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo12 = CType(Me.ReportHeader.Controls(123),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo13 = CType(Me.ReportHeader.Controls(124),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo14 = CType(Me.ReportHeader.Controls(125),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo15 = CType(Me.ReportHeader.Controls(126),DataDynamics.ActiveReports.TextBox)
		Me.txtModelo16 = CType(Me.ReportHeader.Controls(127),DataDynamics.ActiveReports.TextBox)
	End Sub

#End Region

    Private Sub LimpiarCampos()

        For i As Integer = 1 To 16
            DirectCast(ReportHeader.Controls("txtPrecioP" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtPrecioF" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtTalla" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtModelo" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("Barcode" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("lblPrecioP" & i), Label).Text = ""
            DirectCast(ReportHeader.Controls("lblPrecioF" & i), Label).Text = ""
            DirectCast(ReportHeader.Controls("lblTalla" & i), Label).Text = ""
        Next i

    End Sub

End Class
