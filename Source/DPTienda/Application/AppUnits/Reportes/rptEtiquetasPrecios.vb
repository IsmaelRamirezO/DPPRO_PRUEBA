Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiquetasPrecios

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal bNormal As Boolean, ByVal dtCodigos As DataTable, ByVal Index As Integer)

        MyBase.New()
        InitializeComponent()

        LimpiarCampos()

        For Each oRow As DataRow In dtCodigos.Rows

            DirectCast(ReportHeader.Controls("txtPrecio" & Index), TextBox).Text = Format(CDec(oRow!Precio), "$ #,###0.00")
            If bNormal Then
                DirectCast(ReportHeader.Controls("txtMedidas" & Index), TextBox).Text = CStr(oRow!Medidas).Trim
            Else
                DirectCast(ReportHeader.Controls("txtMedidas" & Index), TextBox).Text = Format(CDec(oRow!Medidas), "$ #,###0.00")
            End If
            DirectCast(ReportHeader.Controls("txtModelo" & Index), TextBox).Text = CStr(oRow!CodArticulo).Trim

            Index += 1

        Next

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtMedidas1 As TextBox = Nothing
	Private txtPrecio1 As TextBox = Nothing
	Private txtModelo1 As TextBox = Nothing
	Private txtMedidas2 As TextBox = Nothing
	Private txtPrecio2 As TextBox = Nothing
	Private txtModelo2 As TextBox = Nothing
	Private txtMedidas5 As TextBox = Nothing
	Private txtPrecio5 As TextBox = Nothing
	Private txtModelo5 As TextBox = Nothing
	Private txtMedidas3 As TextBox = Nothing
	Private txtPrecio3 As TextBox = Nothing
	Private txtModelo3 As TextBox = Nothing
	Private txtMedidas4 As TextBox = Nothing
	Private txtPrecio4 As TextBox = Nothing
	Private txtModelo4 As TextBox = Nothing
	Private txtMedidas6 As TextBox = Nothing
	Private txtPrecio6 As TextBox = Nothing
	Private txtModelo6 As TextBox = Nothing
	Private txtMedidas7 As TextBox = Nothing
	Private txtPrecio7 As TextBox = Nothing
	Private txtModelo7 As TextBox = Nothing
	Private txtMedidas8 As TextBox = Nothing
	Private txtPrecio8 As TextBox = Nothing
	Private txtModelo8 As TextBox = Nothing
	Private txtMedidas9 As TextBox = Nothing
	Private txtPrecio9 As TextBox = Nothing
	Private txtModelo9 As TextBox = Nothing
	Private txtMedidas10 As TextBox = Nothing
	Private txtPrecio10 As TextBox = Nothing
	Private txtModelo10 As TextBox = Nothing
	Private txtMedidas11 As TextBox = Nothing
	Private txtPrecio11 As TextBox = Nothing
	Private txtModelo11 As TextBox = Nothing
	Private txtMedidas12 As TextBox = Nothing
	Private txtPrecio12 As TextBox = Nothing
	Private txtModelo12 As TextBox = Nothing
	Private txtMedidas13 As TextBox = Nothing
	Private txtPrecio13 As TextBox = Nothing
	Private txtModelo13 As TextBox = Nothing
	Private txtMedidas14 As TextBox = Nothing
	Private txtPrecio14 As TextBox = Nothing
	Private txtModelo14 As TextBox = Nothing
	Private txtMedidas15 As TextBox = Nothing
	Private txtPrecio15 As TextBox = Nothing
	Private txtModelo15 As TextBox = Nothing
	Private txtMedidas16 As TextBox = Nothing
	Private txtPrecio16 As TextBox = Nothing
	Private txtModelo16 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEtiquetasPrecios))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.txtMedidas1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo13 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo14 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo15 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMedidas16 = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio16 = New DataDynamics.ActiveReports.TextBox()
            Me.txtModelo16 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtMedidas1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtModelo15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMedidas16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio16,System.ComponentModel.ISupportInitialize).BeginInit
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
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtMedidas1, Me.txtPrecio1, Me.txtModelo1, Me.txtMedidas2, Me.txtPrecio2, Me.txtModelo2, Me.txtMedidas5, Me.txtPrecio5, Me.txtModelo5, Me.txtMedidas3, Me.txtPrecio3, Me.txtModelo3, Me.txtMedidas4, Me.txtPrecio4, Me.txtModelo4, Me.txtMedidas6, Me.txtPrecio6, Me.txtModelo6, Me.txtMedidas7, Me.txtPrecio7, Me.txtModelo7, Me.txtMedidas8, Me.txtPrecio8, Me.txtModelo8, Me.txtMedidas9, Me.txtPrecio9, Me.txtModelo9, Me.txtMedidas10, Me.txtPrecio10, Me.txtModelo10, Me.txtMedidas11, Me.txtPrecio11, Me.txtModelo11, Me.txtMedidas12, Me.txtPrecio12, Me.txtModelo12, Me.txtMedidas13, Me.txtPrecio13, Me.txtModelo13, Me.txtMedidas14, Me.txtPrecio14, Me.txtModelo14, Me.txtMedidas15, Me.txtPrecio15, Me.txtModelo15, Me.txtMedidas16, Me.txtPrecio16, Me.txtModelo16})
            Me.ReportHeader.Height = 10.29167!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'txtMedidas1
            '
            Me.txtMedidas1.DataField = "Medidas"
            Me.txtMedidas1.Height = 0.2!
            Me.txtMedidas1.Left = 0.125!
            Me.txtMedidas1.Name = "txtMedidas1"
            Me.txtMedidas1.OutputFormat = resources.GetString("txtMedidas1.OutputFormat")
            Me.txtMedidas1.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas1.Text = "Medidas"
            Me.txtMedidas1.Top = 1.205!
            Me.txtMedidas1.Width = 1.375!
            '
            'txtPrecio1
            '
            Me.txtPrecio1.DataField = "Precio"
            Me.txtPrecio1.Height = 0.2!
            Me.txtPrecio1.Left = 0.125!
            Me.txtPrecio1.Name = "txtPrecio1"
            Me.txtPrecio1.OutputFormat = resources.GetString("txtPrecio1.OutputFormat")
            Me.txtPrecio1.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio1.Text = "Precio"
            Me.txtPrecio1.Top = 0.04999999!
            Me.txtPrecio1.Width = 1.375!
            '
            'txtModelo1
            '
            Me.txtModelo1.DataField = "CodArticulo"
            Me.txtModelo1.Height = 0.2!
            Me.txtModelo1.Left = 0.1255!
            Me.txtModelo1.Name = "txtModelo1"
            Me.txtModelo1.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo1.Text = "MODELO"
            Me.txtModelo1.Top = 1.9375!
            Me.txtModelo1.Width = 1.375!
            '
            'txtMedidas2
            '
            Me.txtMedidas2.DataField = "Medidas"
            Me.txtMedidas2.Height = 0.2!
            Me.txtMedidas2.Left = 2.25!
            Me.txtMedidas2.Name = "txtMedidas2"
            Me.txtMedidas2.OutputFormat = resources.GetString("txtMedidas2.OutputFormat")
            Me.txtMedidas2.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas2.Text = "Medidas"
            Me.txtMedidas2.Top = 1.205!
            Me.txtMedidas2.Width = 1.375!
            '
            'txtPrecio2
            '
            Me.txtPrecio2.DataField = "Precio"
            Me.txtPrecio2.Height = 0.2!
            Me.txtPrecio2.Left = 2.25!
            Me.txtPrecio2.Name = "txtPrecio2"
            Me.txtPrecio2.OutputFormat = resources.GetString("txtPrecio2.OutputFormat")
            Me.txtPrecio2.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio2.Text = "Precio"
            Me.txtPrecio2.Top = 0.05049999!
            Me.txtPrecio2.Width = 1.375!
            '
            'txtModelo2
            '
            Me.txtModelo2.DataField = "CodArticulo"
            Me.txtModelo2.Height = 0.2!
            Me.txtModelo2.Left = 2.25!
            Me.txtModelo2.Name = "txtModelo2"
            Me.txtModelo2.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo2.Text = "MODELO"
            Me.txtModelo2.Top = 1.9375!
            Me.txtModelo2.Width = 1.375!
            '
            'txtMedidas5
            '
            Me.txtMedidas5.DataField = "Medidas"
            Me.txtMedidas5.Height = 0.2!
            Me.txtMedidas5.Left = 0.125!
            Me.txtMedidas5.Name = "txtMedidas5"
            Me.txtMedidas5.OutputFormat = resources.GetString("txtMedidas5.OutputFormat")
            Me.txtMedidas5.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas5.Text = "Medidas"
            Me.txtMedidas5.Top = 3.875!
            Me.txtMedidas5.Width = 1.375!
            '
            'txtPrecio5
            '
            Me.txtPrecio5.DataField = "Precio"
            Me.txtPrecio5.Height = 0.2!
            Me.txtPrecio5.Left = 0.125!
            Me.txtPrecio5.Name = "txtPrecio5"
            Me.txtPrecio5.OutputFormat = resources.GetString("txtPrecio5.OutputFormat")
            Me.txtPrecio5.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio5.Text = "Precio"
            Me.txtPrecio5.Top = 2.738!
            Me.txtPrecio5.Width = 1.375!
            '
            'txtModelo5
            '
            Me.txtModelo5.DataField = "CodArticulo"
            Me.txtModelo5.Height = 0.2!
            Me.txtModelo5.Left = 0.1263!
            Me.txtModelo5.Name = "txtModelo5"
            Me.txtModelo5.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo5.Text = "MODELO"
            Me.txtModelo5.Top = 4.67!
            Me.txtModelo5.Width = 1.375!
            '
            'txtMedidas3
            '
            Me.txtMedidas3.DataField = "Medidas"
            Me.txtMedidas3.Height = 0.2!
            Me.txtMedidas3.Left = 4.3125!
            Me.txtMedidas3.Name = "txtMedidas3"
            Me.txtMedidas3.OutputFormat = resources.GetString("txtMedidas3.OutputFormat")
            Me.txtMedidas3.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas3.Text = "Medidas"
            Me.txtMedidas3.Top = 1.205!
            Me.txtMedidas3.Width = 1.375!
            '
            'txtPrecio3
            '
            Me.txtPrecio3.DataField = "Precio"
            Me.txtPrecio3.Height = 0.2!
            Me.txtPrecio3.Left = 4.3125!
            Me.txtPrecio3.Name = "txtPrecio3"
            Me.txtPrecio3.OutputFormat = resources.GetString("txtPrecio3.OutputFormat")
            Me.txtPrecio3.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio3.Text = "Precio"
            Me.txtPrecio3.Top = 0.05049999!
            Me.txtPrecio3.Width = 1.375!
            '
            'txtModelo3
            '
            Me.txtModelo3.DataField = "CodArticulo"
            Me.txtModelo3.Height = 0.2!
            Me.txtModelo3.Left = 4.3125!
            Me.txtModelo3.Name = "txtModelo3"
            Me.txtModelo3.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo3.Text = "MODELO"
            Me.txtModelo3.Top = 1.938!
            Me.txtModelo3.Width = 1.375!
            '
            'txtMedidas4
            '
            Me.txtMedidas4.DataField = "Medidas"
            Me.txtMedidas4.Height = 0.2!
            Me.txtMedidas4.Left = 6.375!
            Me.txtMedidas4.Name = "txtMedidas4"
            Me.txtMedidas4.OutputFormat = resources.GetString("txtMedidas4.OutputFormat")
            Me.txtMedidas4.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas4.Text = "Medidas"
            Me.txtMedidas4.Top = 1.205!
            Me.txtMedidas4.Width = 1.375!
            '
            'txtPrecio4
            '
            Me.txtPrecio4.DataField = "Precio"
            Me.txtPrecio4.Height = 0.2!
            Me.txtPrecio4.Left = 6.375!
            Me.txtPrecio4.Name = "txtPrecio4"
            Me.txtPrecio4.OutputFormat = resources.GetString("txtPrecio4.OutputFormat")
            Me.txtPrecio4.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio4.Text = "Precio"
            Me.txtPrecio4.Top = 0.05049999!
            Me.txtPrecio4.Width = 1.375!
            '
            'txtModelo4
            '
            Me.txtModelo4.DataField = "CodArticulo"
            Me.txtModelo4.Height = 0.2!
            Me.txtModelo4.Left = 6.3745!
            Me.txtModelo4.Name = "txtModelo4"
            Me.txtModelo4.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo4.Text = "MODELO"
            Me.txtModelo4.Top = 1.938!
            Me.txtModelo4.Width = 1.375!
            '
            'txtMedidas6
            '
            Me.txtMedidas6.DataField = "Medidas"
            Me.txtMedidas6.Height = 0.2!
            Me.txtMedidas6.Left = 2.25!
            Me.txtMedidas6.Name = "txtMedidas6"
            Me.txtMedidas6.OutputFormat = resources.GetString("txtMedidas6.OutputFormat")
            Me.txtMedidas6.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas6.Text = "Medidas"
            Me.txtMedidas6.Top = 3.875!
            Me.txtMedidas6.Width = 1.375!
            '
            'txtPrecio6
            '
            Me.txtPrecio6.DataField = "Precio"
            Me.txtPrecio6.Height = 0.2!
            Me.txtPrecio6.Left = 2.25!
            Me.txtPrecio6.Name = "txtPrecio6"
            Me.txtPrecio6.OutputFormat = resources.GetString("txtPrecio6.OutputFormat")
            Me.txtPrecio6.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio6.Text = "Precio"
            Me.txtPrecio6.Top = 2.738!
            Me.txtPrecio6.Width = 1.375!
            '
            'txtModelo6
            '
            Me.txtModelo6.DataField = "CodArticulo"
            Me.txtModelo6.Height = 0.2!
            Me.txtModelo6.Left = 2.25!
            Me.txtModelo6.Name = "txtModelo6"
            Me.txtModelo6.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo6.Text = "MODELO"
            Me.txtModelo6.Top = 4.67!
            Me.txtModelo6.Width = 1.375!
            '
            'txtMedidas7
            '
            Me.txtMedidas7.DataField = "Medidas"
            Me.txtMedidas7.Height = 0.2!
            Me.txtMedidas7.Left = 4.25!
            Me.txtMedidas7.Name = "txtMedidas7"
            Me.txtMedidas7.OutputFormat = resources.GetString("txtMedidas7.OutputFormat")
            Me.txtMedidas7.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas7.Text = "Medidas"
            Me.txtMedidas7.Top = 3.875!
            Me.txtMedidas7.Width = 1.375!
            '
            'txtPrecio7
            '
            Me.txtPrecio7.DataField = "Precio"
            Me.txtPrecio7.Height = 0.2!
            Me.txtPrecio7.Left = 4.25!
            Me.txtPrecio7.Name = "txtPrecio7"
            Me.txtPrecio7.OutputFormat = resources.GetString("txtPrecio7.OutputFormat")
            Me.txtPrecio7.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio7.Text = "Precio"
            Me.txtPrecio7.Top = 2.738!
            Me.txtPrecio7.Width = 1.375!
            '
            'txtModelo7
            '
            Me.txtModelo7.DataField = "CodArticulo"
            Me.txtModelo7.Height = 0.2!
            Me.txtModelo7.Left = 4.25!
            Me.txtModelo7.Name = "txtModelo7"
            Me.txtModelo7.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo7.Text = "MODELO"
            Me.txtModelo7.Top = 4.67!
            Me.txtModelo7.Width = 1.375!
            '
            'txtMedidas8
            '
            Me.txtMedidas8.DataField = "Medidas"
            Me.txtMedidas8.Height = 0.2!
            Me.txtMedidas8.Left = 6.375!
            Me.txtMedidas8.Name = "txtMedidas8"
            Me.txtMedidas8.OutputFormat = resources.GetString("txtMedidas8.OutputFormat")
            Me.txtMedidas8.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas8.Text = "Medidas"
            Me.txtMedidas8.Top = 3.875!
            Me.txtMedidas8.Width = 1.375!
            '
            'txtPrecio8
            '
            Me.txtPrecio8.DataField = "Precio"
            Me.txtPrecio8.Height = 0.2!
            Me.txtPrecio8.Left = 6.375!
            Me.txtPrecio8.Name = "txtPrecio8"
            Me.txtPrecio8.OutputFormat = resources.GetString("txtPrecio8.OutputFormat")
            Me.txtPrecio8.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio8.Text = "Precio"
            Me.txtPrecio8.Top = 2.738!
            Me.txtPrecio8.Width = 1.375!
            '
            'txtModelo8
            '
            Me.txtModelo8.DataField = "CodArticulo"
            Me.txtModelo8.Height = 0.2!
            Me.txtModelo8.Left = 6.375!
            Me.txtModelo8.Name = "txtModelo8"
            Me.txtModelo8.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo8.Text = "MODELO"
            Me.txtModelo8.Top = 4.67!
            Me.txtModelo8.Width = 1.375!
            '
            'txtMedidas9
            '
            Me.txtMedidas9.DataField = "Medidas"
            Me.txtMedidas9.Height = 0.2!
            Me.txtMedidas9.Left = 0.125!
            Me.txtMedidas9.Name = "txtMedidas9"
            Me.txtMedidas9.OutputFormat = resources.GetString("txtMedidas9.OutputFormat")
            Me.txtMedidas9.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas9.Text = "Medidas"
            Me.txtMedidas9.Top = 6.6075!
            Me.txtMedidas9.Width = 1.375!
            '
            'txtPrecio9
            '
            Me.txtPrecio9.DataField = "Precio"
            Me.txtPrecio9.Height = 0.2!
            Me.txtPrecio9.Left = 0.125!
            Me.txtPrecio9.Name = "txtPrecio9"
            Me.txtPrecio9.OutputFormat = resources.GetString("txtPrecio9.OutputFormat")
            Me.txtPrecio9.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio9.Text = "Precio"
            Me.txtPrecio9.Top = 5.426!
            Me.txtPrecio9.Width = 1.375!
            '
            'txtModelo9
            '
            Me.txtModelo9.DataField = "CodArticulo"
            Me.txtModelo9.Height = 0.2!
            Me.txtModelo9.Left = 0.126!
            Me.txtModelo9.Name = "txtModelo9"
            Me.txtModelo9.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo9.Text = "MODELO"
            Me.txtModelo9.Top = 7.3405!
            Me.txtModelo9.Width = 1.375!
            '
            'txtMedidas10
            '
            Me.txtMedidas10.DataField = "Medidas"
            Me.txtMedidas10.Height = 0.2!
            Me.txtMedidas10.Left = 2.1875!
            Me.txtMedidas10.Name = "txtMedidas10"
            Me.txtMedidas10.OutputFormat = resources.GetString("txtMedidas10.OutputFormat")
            Me.txtMedidas10.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas10.Text = "Medidas"
            Me.txtMedidas10.Top = 6.6075!
            Me.txtMedidas10.Width = 1.375!
            '
            'txtPrecio10
            '
            Me.txtPrecio10.DataField = "Precio"
            Me.txtPrecio10.Height = 0.2!
            Me.txtPrecio10.Left = 2.1875!
            Me.txtPrecio10.Name = "txtPrecio10"
            Me.txtPrecio10.OutputFormat = resources.GetString("txtPrecio10.OutputFormat")
            Me.txtPrecio10.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio10.Text = "Precio"
            Me.txtPrecio10.Top = 5.426!
            Me.txtPrecio10.Width = 1.375!
            '
            'txtModelo10
            '
            Me.txtModelo10.DataField = "CodArticulo"
            Me.txtModelo10.Height = 0.2!
            Me.txtModelo10.Left = 2.1875!
            Me.txtModelo10.Name = "txtModelo10"
            Me.txtModelo10.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo10.Text = "MODELO"
            Me.txtModelo10.Top = 7.3405!
            Me.txtModelo10.Width = 1.375!
            '
            'txtMedidas11
            '
            Me.txtMedidas11.DataField = "Medidas"
            Me.txtMedidas11.Height = 0.2!
            Me.txtMedidas11.Left = 4.25!
            Me.txtMedidas11.Name = "txtMedidas11"
            Me.txtMedidas11.OutputFormat = resources.GetString("txtMedidas11.OutputFormat")
            Me.txtMedidas11.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas11.Text = "Medidas"
            Me.txtMedidas11.Top = 6.6075!
            Me.txtMedidas11.Width = 1.4375!
            '
            'txtPrecio11
            '
            Me.txtPrecio11.DataField = "Precio"
            Me.txtPrecio11.Height = 0.2!
            Me.txtPrecio11.Left = 4.25!
            Me.txtPrecio11.Name = "txtPrecio11"
            Me.txtPrecio11.OutputFormat = resources.GetString("txtPrecio11.OutputFormat")
            Me.txtPrecio11.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio11.Text = "Precio"
            Me.txtPrecio11.Top = 5.426!
            Me.txtPrecio11.Width = 1.4375!
            '
            'txtModelo11
            '
            Me.txtModelo11.DataField = "CodArticulo"
            Me.txtModelo11.Height = 0.2!
            Me.txtModelo11.Left = 4.25!
            Me.txtModelo11.Name = "txtModelo11"
            Me.txtModelo11.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo11.Text = "MODELO"
            Me.txtModelo11.Top = 7.3405!
            Me.txtModelo11.Width = 1.375!
            '
            'txtMedidas12
            '
            Me.txtMedidas12.DataField = "Medidas"
            Me.txtMedidas12.Height = 0.2!
            Me.txtMedidas12.Left = 6.375!
            Me.txtMedidas12.Name = "txtMedidas12"
            Me.txtMedidas12.OutputFormat = resources.GetString("txtMedidas12.OutputFormat")
            Me.txtMedidas12.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas12.Text = "Medidas"
            Me.txtMedidas12.Top = 6.6075!
            Me.txtMedidas12.Width = 1.375!
            '
            'txtPrecio12
            '
            Me.txtPrecio12.DataField = "Precio"
            Me.txtPrecio12.Height = 0.2!
            Me.txtPrecio12.Left = 6.375!
            Me.txtPrecio12.Name = "txtPrecio12"
            Me.txtPrecio12.OutputFormat = resources.GetString("txtPrecio12.OutputFormat")
            Me.txtPrecio12.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio12.Text = "Precio"
            Me.txtPrecio12.Top = 5.426!
            Me.txtPrecio12.Width = 1.375!
            '
            'txtModelo12
            '
            Me.txtModelo12.DataField = "CodArticulo"
            Me.txtModelo12.Height = 0.2!
            Me.txtModelo12.Left = 6.375!
            Me.txtModelo12.Name = "txtModelo12"
            Me.txtModelo12.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo12.Text = "MODELO"
            Me.txtModelo12.Top = 7.3405!
            Me.txtModelo12.Width = 1.375!
            '
            'txtMedidas13
            '
            Me.txtMedidas13.DataField = "Medidas"
            Me.txtMedidas13.Height = 0.2!
            Me.txtMedidas13.Left = 0.125!
            Me.txtMedidas13.Name = "txtMedidas13"
            Me.txtMedidas13.OutputFormat = resources.GetString("txtMedidas13.OutputFormat")
            Me.txtMedidas13.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas13.Text = "Medidas"
            Me.txtMedidas13.Top = 9.2775!
            Me.txtMedidas13.Width = 1.375!
            '
            'txtPrecio13
            '
            Me.txtPrecio13.DataField = "Precio"
            Me.txtPrecio13.Height = 0.2!
            Me.txtPrecio13.Left = 0.125!
            Me.txtPrecio13.Name = "txtPrecio13"
            Me.txtPrecio13.OutputFormat = resources.GetString("txtPrecio13.OutputFormat")
            Me.txtPrecio13.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio13.Text = "Precio"
            Me.txtPrecio13.Top = 8.1215!
            Me.txtPrecio13.Width = 1.375!
            '
            'txtModelo13
            '
            Me.txtModelo13.DataField = "CodArticulo"
            Me.txtModelo13.Height = 0.2!
            Me.txtModelo13.Left = 0.126!
            Me.txtModelo13.Name = "txtModelo13"
            Me.txtModelo13.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo13.Text = "MODELO"
            Me.txtModelo13.Top = 10.0105!
            Me.txtModelo13.Width = 1.375!
            '
            'txtMedidas14
            '
            Me.txtMedidas14.DataField = "Medidas"
            Me.txtMedidas14.Height = 0.2!
            Me.txtMedidas14.Left = 2.1875!
            Me.txtMedidas14.Name = "txtMedidas14"
            Me.txtMedidas14.OutputFormat = resources.GetString("txtMedidas14.OutputFormat")
            Me.txtMedidas14.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas14.Text = "Medidas"
            Me.txtMedidas14.Top = 9.281!
            Me.txtMedidas14.Width = 1.375!
            '
            'txtPrecio14
            '
            Me.txtPrecio14.DataField = "Precio"
            Me.txtPrecio14.Height = 0.2!
            Me.txtPrecio14.Left = 2.1875!
            Me.txtPrecio14.Name = "txtPrecio14"
            Me.txtPrecio14.OutputFormat = resources.GetString("txtPrecio14.OutputFormat")
            Me.txtPrecio14.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio14.Text = "Precio"
            Me.txtPrecio14.Top = 8.125!
            Me.txtPrecio14.Width = 1.375!
            '
            'txtModelo14
            '
            Me.txtModelo14.DataField = "CodArticulo"
            Me.txtModelo14.Height = 0.2!
            Me.txtModelo14.Left = 2.1875!
            Me.txtModelo14.Name = "txtModelo14"
            Me.txtModelo14.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo14.Text = "MODELO"
            Me.txtModelo14.Top = 10.0105!
            Me.txtModelo14.Width = 1.375!
            '
            'txtMedidas15
            '
            Me.txtMedidas15.DataField = "Medidas"
            Me.txtMedidas15.Height = 0.2!
            Me.txtMedidas15.Left = 4.25!
            Me.txtMedidas15.Name = "txtMedidas15"
            Me.txtMedidas15.OutputFormat = resources.GetString("txtMedidas15.OutputFormat")
            Me.txtMedidas15.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas15.Text = "Medidas"
            Me.txtMedidas15.Top = 9.2775!
            Me.txtMedidas15.Width = 1.375!
            '
            'txtPrecio15
            '
            Me.txtPrecio15.DataField = "Precio"
            Me.txtPrecio15.Height = 0.2!
            Me.txtPrecio15.Left = 4.25!
            Me.txtPrecio15.Name = "txtPrecio15"
            Me.txtPrecio15.OutputFormat = resources.GetString("txtPrecio15.OutputFormat")
            Me.txtPrecio15.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio15.Text = "Precio"
            Me.txtPrecio15.Top = 8.1215!
            Me.txtPrecio15.Width = 1.375!
            '
            'txtModelo15
            '
            Me.txtModelo15.DataField = "CodArticulo"
            Me.txtModelo15.Height = 0.2!
            Me.txtModelo15.Left = 4.25!
            Me.txtModelo15.Name = "txtModelo15"
            Me.txtModelo15.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo15.Text = "MODELO"
            Me.txtModelo15.Top = 10.0105!
            Me.txtModelo15.Width = 1.375!
            '
            'txtMedidas16
            '
            Me.txtMedidas16.DataField = "Medidas"
            Me.txtMedidas16.Height = 0.2!
            Me.txtMedidas16.Left = 6.375!
            Me.txtMedidas16.Name = "txtMedidas16"
            Me.txtMedidas16.OutputFormat = resources.GetString("txtMedidas16.OutputFormat")
            Me.txtMedidas16.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtMedidas16.Text = "Medidas"
            Me.txtMedidas16.Top = 9.2775!
            Me.txtMedidas16.Width = 1.375!
            '
            'txtPrecio16
            '
            Me.txtPrecio16.DataField = "Precio"
            Me.txtPrecio16.Height = 0.2!
            Me.txtPrecio16.Left = 6.375!
            Me.txtPrecio16.Name = "txtPrecio16"
            Me.txtPrecio16.OutputFormat = resources.GetString("txtPrecio16.OutputFormat")
            Me.txtPrecio16.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.txtPrecio16.Text = "Precio"
            Me.txtPrecio16.Top = 8.1215!
            Me.txtPrecio16.Width = 1.375!
            '
            'txtModelo16
            '
            Me.txtModelo16.DataField = "CodArticulo"
            Me.txtModelo16.Height = 0.2!
            Me.txtModelo16.Left = 6.375!
            Me.txtModelo16.Name = "txtModelo16"
            Me.txtModelo16.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.txtModelo16.Text = "MODELO"
            Me.txtModelo16.Top = 10.0105!
            Me.txtModelo16.Width = 1.375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0.1!
            Me.PageSettings.Margins.Left = 0.3!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0.4!
            Me.PageSettings.PaperHeight = 12!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 8.270139!
            Me.PrintWidth = 7.84375!
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
            CType(Me.txtMedidas1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMedidas16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtModelo16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub LimpiarCampos()

        For i As Integer = 1 To 16
            DirectCast(ReportHeader.Controls("txtPrecio" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtMedidas" & i), TextBox).Text = ""
            DirectCast(ReportHeader.Controls("txtModelo" & i), TextBox).Text = ""
        Next i

    End Sub

End Class
