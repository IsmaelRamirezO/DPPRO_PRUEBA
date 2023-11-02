Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class rptCartaReclamacionDHLDetalle
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal dvFaltantes As DataView)

        MyBase.New()
        InitializeComponent()

        Dim dtSource As DataTable
        Dim CostoTotal As Decimal

        dtSource = ComplementarDetalle(dvFaltantes, CostoTotal)

        Me.DataSource = dtSource

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private lbl As Label = Nothing
	Private Label94 As Label = Nothing
	Private Label95 As Label = Nothing
	Private Label96 As Label = Nothing
	Private Label97 As Label = Nothing
	Private Label98 As Label = Nothing
	Private Label99 As Label = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtTalla As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtCostoUnit As TextBox = Nothing
	Private txtCostoTotalPieza As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCartaReclamacionDHLDetalle))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.lbl = New DataDynamics.ActiveReports.Label()
            Me.Label94 = New DataDynamics.ActiveReports.Label()
            Me.Label95 = New DataDynamics.ActiveReports.Label()
            Me.Label96 = New DataDynamics.ActiveReports.Label()
            Me.Label97 = New DataDynamics.ActiveReports.Label()
            Me.Label98 = New DataDynamics.ActiveReports.Label()
            Me.Label99 = New DataDynamics.ActiveReports.Label()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtCostoUnit = New DataDynamics.ActiveReports.TextBox()
            Me.txtCostoTotalPieza = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lbl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label94,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label95,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label96,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label97,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label98,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label99,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoTotalPieza,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodArticulo, Me.txtDescripcion, Me.txtTalla, Me.txtCantidad, Me.txtCostoUnit, Me.txtCostoTotalPieza})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lbl, Me.Label94, Me.Label95, Me.Label96, Me.Label97, Me.Label98, Me.Label99})
            Me.ReportHeader.Height = 0.4375!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'lbl
            '
            Me.lbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lbl.Height = 0.25!
            Me.lbl.HyperLink = Nothing
            Me.lbl.Left = 0.125!
            Me.lbl.Name = "lbl"
            Me.lbl.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.lbl.Text = "DESCRIPCION DE MERCANCÍA FALTANTE O DAÑADA"
            Me.lbl.Top = 0!
            Me.lbl.Width = 7.0625!
            '
            'Label94
            '
            Me.Label94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label94.Height = 0.1875!
            Me.Label94.HyperLink = Nothing
            Me.Label94.Left = 0.125!
            Me.Label94.Name = "Label94"
            Me.Label94.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label94.Text = "Código"
            Me.Label94.Top = 0.25!
            Me.Label94.Width = 1.25!
            '
            'Label95
            '
            Me.Label95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label95.Height = 0.1875!
            Me.Label95.HyperLink = Nothing
            Me.Label95.Left = 1.375!
            Me.Label95.Name = "Label95"
            Me.Label95.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label95.Text = "Descripción"
            Me.Label95.Top = 0.25!
            Me.Label95.Width = 3.0625!
            '
            'Label96
            '
            Me.Label96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label96.Height = 0.1875!
            Me.Label96.HyperLink = Nothing
            Me.Label96.Left = 4.4375!
            Me.Label96.Name = "Label96"
            Me.Label96.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label96.Text = "Talla"
            Me.Label96.Top = 0.25!
            Me.Label96.Width = 0.5!
            '
            'Label97
            '
            Me.Label97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label97.Height = 0.1875!
            Me.Label97.HyperLink = Nothing
            Me.Label97.Left = 4.9375!
            Me.Label97.Name = "Label97"
            Me.Label97.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label97.Text = "Cant"
            Me.Label97.Top = 0.25!
            Me.Label97.Width = 0.625!
            '
            'Label98
            '
            Me.Label98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label98.Height = 0.1875!
            Me.Label98.HyperLink = Nothing
            Me.Label98.Left = 5.5625!
            Me.Label98.Name = "Label98"
            Me.Label98.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label98.Text = "Costo U."
            Me.Label98.Top = 0.25!
            Me.Label98.Width = 0.8125!
            '
            'Label99
            '
            Me.Label99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label99.Height = 0.1875!
            Me.Label99.HyperLink = Nothing
            Me.Label99.Left = 6.375!
            Me.Label99.Name = "Label99"
            Me.Label99.Style = "color: buttontext; text-align: center; font-weight: bold; background-color: Gold;"& _ 
                " font-size: 9pt; vertical-align: middle"
            Me.Label99.Text = "Costo T."
            Me.Label99.Top = 0.25!
            Me.Label99.Width = 0.8125!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.DataField = "Codigo"
            Me.txtCodArticulo.Height = 0.1875!
            Me.txtCodArticulo.Left = 0.125!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Style = "text-align: center; background-color: window; font-size: 9pt"
            Me.txtCodArticulo.Text = "NK-385747-1011"
            Me.txtCodArticulo.Top = 0!
            Me.txtCodArticulo.Width = 1.25!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.Left = 1.375!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "background-color: window; font-size: 9pt"
            Me.txtDescripcion.Text = "NK-385747-1011"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 3.0625!
            '
            'txtTalla
            '
            Me.txtTalla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla.DataField = "Talla"
            Me.txtTalla.Height = 0.1875!
            Me.txtTalla.Left = 4.4375!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: center; background-color: window; font-size: 9pt"
            Me.txtTalla.Text = "10.0"
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.5!
            '
            'txtCantidad
            '
            Me.txtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.1875!
            Me.txtCantidad.Left = 4.9375!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; background-color: window; font-size: 9pt"
            Me.txtCantidad.Text = "5"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.625!
            '
            'txtCostoUnit
            '
            Me.txtCostoUnit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoUnit.DataField = "CostoUnit"
            Me.txtCostoUnit.Height = 0.1875!
            Me.txtCostoUnit.Left = 5.5625!
            Me.txtCostoUnit.Name = "txtCostoUnit"
            Me.txtCostoUnit.Style = "text-align: center; background-color: window; font-size: 9pt"
            Me.txtCostoUnit.Text = "$ 125.2"
            Me.txtCostoUnit.Top = 0!
            Me.txtCostoUnit.Width = 0.8125!
            '
            'txtCostoTotalPieza
            '
            Me.txtCostoTotalPieza.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCostoTotalPieza.DataField = "CostoTotal"
            Me.txtCostoTotalPieza.Height = 0.1875!
            Me.txtCostoTotalPieza.Left = 6.375!
            Me.txtCostoTotalPieza.Name = "txtCostoTotalPieza"
            Me.txtCostoTotalPieza.Style = "text-align: center; background-color: window; font-size: 9pt"
            Me.txtCostoTotalPieza.Text = "$ 125.2"
            Me.txtCostoTotalPieza.Top = 0!
            Me.txtCostoTotalPieza.Width = 0.8125!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.3!
            Me.PageSettings.Margins.Left = 0.3!
            Me.PageSettings.Margins.Right = 0.3!
            Me.PageSettings.Margins.Top = 0.3!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.3125!
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
            CType(Me.lbl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label94,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label95,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label96,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label97,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label98,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label99,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoTotalPieza,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Function ComplementarDetalle(ByVal dvFal As DataView, ByRef Costo As Decimal) As DataTable

        Dim dtTemp As DataTable = dvFal.Table.Clone

        Try
            Dim oArticulo As Articulo
            Dim oRowV As DataRowView
            Dim oRow As DataRow
1:          Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)

2:          For Each oRowV In dvFal
3:              dtTemp.ImportRow(oRowV.Row)
            Next
4:          dtTemp.AcceptChanges()

5:          dtTemp.Columns.Add("CostoUnit", GetType(Decimal))
6:          dtTemp.Columns.Add("CostoTotal", GetType(Decimal))
7:          dtTemp.AcceptChanges()

8:          For Each oRow In dtTemp.Rows
9:              oArticulo = Nothing
10:             oArticulo = oArticuloMgr.Load(CStr(oRow!Codigo).Trim)
                If Not oArticulo Is Nothing Then
11:                 oRow!CostoUnit = oArticulo.CostoProm
12:                 oRow!Cantidad = CInt(oRow!Cantidad - oRow!Lecturado)
13:                 oRow!CostoTotal = oRow!CostoUnit * oRow!Cantidad
14:                 Costo += oRow!CostoTotal
                End If
            Next
15:         dtTemp.AcceptChanges()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al complementar el detalle en la impresion de los faltantes. Linea: " & Err.Erl)
        End Try

        Return dtTemp

    End Function

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.txtCostoUnit.Text = Format(CDec(Me.txtCostoUnit.Text), "$#,##0.00")
        Me.txtCostoTotalPieza.Text = Format(CDec(Me.txtCostoTotalPieza.Text), "$#,##0.00")
    End Sub

End Class
