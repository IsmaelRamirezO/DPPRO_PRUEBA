Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU

Public Class ActRptDevolucionNC53
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oNC As NotaCredito)
        MyBase.New()
        InitializeComponent()
        Me.TxtBxCantidad.DataField = "Cantidad"
        Me.TxtBxCodigo.DataField = "CodArticulo"
        Me.TxtBxDesc.DataField = "Descripcion"
        Me.TxtBxTalla.DataField = "Numero"
        Me.TxtBxPrecio.DataField = "importe"
        Me.TxtBxTotal.Text = oNC.Importe
        Me.TxtBxNC.Text = oNC.NotaCreditoFolio
        Me.TxtBxFactura.DataField = "FolioReferencia"
        Me.TxtBxFecha.Text = Format(Date.Now, "dd-MM-yyyy")
        Me.TxtBxTotalLetra.Text = Letras(CStr(oNC.Importe))


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private LblFecha As Label = Nothing
	Private LblNC As Label = Nothing
	Private LblAplicaFact As Label = Nothing
	Private TxtBxFecha As TextBox = Nothing
	Private TxtBxNC As TextBox = Nothing
	Private TxtBxFactura As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line3 As Line = Nothing
	Private TxtBxCodigo As TextBox = Nothing
	Private TxtBxDesc As TextBox = Nothing
	Private TxtBxCantidad As TextBox = Nothing
	Private TxtBxTalla As TextBox = Nothing
	Private TxtBxPrecio As TextBox = Nothing
	Private LblTotal As Label = Nothing
	Private TxtBxTotal As TextBox = Nothing
	Private TxtBxTotalLetra As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActRptDevolucionNC53))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.LblNC = New DataDynamics.ActiveReports.Label()
            Me.LblAplicaFact = New DataDynamics.ActiveReports.Label()
            Me.TxtBxFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxNC = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxFactura = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDesc = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTalla = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxPrecio = New DataDynamics.ActiveReports.TextBox()
            Me.LblTotal = New DataDynamics.ActiveReports.Label()
            Me.TxtBxTotal = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTotalLetra = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblAplicaFact,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxNC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDesc,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxPrecio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotalLetra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxCodigo, Me.TxtBxDesc, Me.TxtBxCantidad, Me.TxtBxTalla, Me.TxtBxPrecio})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTotal, Me.TxtBxTotal, Me.TxtBxTotalLetra, Me.Label6, Me.Line2})
            Me.ReportFooter.Height = 0.6756945!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblFecha, Me.LblNC, Me.LblAplicaFact, Me.TxtBxFecha, Me.TxtBxNC, Me.TxtBxFactura, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Line1, Me.Line3})
            Me.PageHeader.Height = 1.052083!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1574803!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 0.1574803!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = ""
            Me.LblFecha.Text = "Fecha:"
            Me.LblFecha.Top = 0.07874014!
            Me.LblFecha.Width = 1.181102!
            '
            'LblNC
            '
            Me.LblNC.Height = 0.1574803!
            Me.LblNC.HyperLink = Nothing
            Me.LblNC.Left = 0.1574803!
            Me.LblNC.Name = "LblNC"
            Me.LblNC.Style = "text-align: left"
            Me.LblNC.Text = "NC:"
            Me.LblNC.Top = 0.3149606!
            Me.LblNC.Width = 1.181102!
            '
            'LblAplicaFact
            '
            Me.LblAplicaFact.Height = 0.1574803!
            Me.LblAplicaFact.HyperLink = Nothing
            Me.LblAplicaFact.Left = 0.1574803!
            Me.LblAplicaFact.Name = "LblAplicaFact"
            Me.LblAplicaFact.Style = ""
            Me.LblAplicaFact.Text = "Aplica a Factura:"
            Me.LblAplicaFact.Top = 0.551181!
            Me.LblAplicaFact.Width = 1.181102!
            '
            'TxtBxFecha
            '
            Me.TxtBxFecha.Height = 0.1574803!
            Me.TxtBxFecha.Left = 1.417323!
            Me.TxtBxFecha.Name = "TxtBxFecha"
            Me.TxtBxFecha.Text = "Fecha"
            Me.TxtBxFecha.Top = 0.07874014!
            Me.TxtBxFecha.Width = 1.181102!
            '
            'TxtBxNC
            '
            Me.TxtBxNC.Height = 0.1574803!
            Me.TxtBxNC.Left = 1.417323!
            Me.TxtBxNC.Name = "TxtBxNC"
            Me.TxtBxNC.OutputFormat = resources.GetString("TxtBxNC.OutputFormat")
            Me.TxtBxNC.Text = "NC"
            Me.TxtBxNC.Top = 0.3149606!
            Me.TxtBxNC.Width = 1.181102!
            '
            'TxtBxFactura
            '
            Me.TxtBxFactura.Height = 0.1574803!
            Me.TxtBxFactura.Left = 1.417323!
            Me.TxtBxFactura.Name = "TxtBxFactura"
            Me.TxtBxFactura.OutputFormat = resources.GetString("TxtBxFactura.OutputFormat")
            Me.TxtBxFactura.Text = "Factura"
            Me.TxtBxFactura.Top = 0.551181!
            Me.TxtBxFactura.Width = 1.181102!
            '
            'Label1
            '
            Me.Label1.Height = 0.1574803!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.1574803!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Cod Articulo"
            Me.Label1.Top = 0.8267716!
            Me.Label1.Width = 1.259842!
            '
            'Label2
            '
            Me.Label2.Height = 0.1574803!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.496063!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Descripción"
            Me.Label2.Top = 0.8267716!
            Me.Label2.Width = 0.7874014!
            '
            'Label3
            '
            Me.Label3.Height = 0.1574803!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 4.452756!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Pzas"
            Me.Label3.Top = 0.8267716!
            Me.Label3.Width = 0.3799215!
            '
            'Label4
            '
            Me.Label4.Height = 0.1574803!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 5.007874!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Talla"
            Me.Label4.Top = 0.8267716!
            Me.Label4.Width = 0.4251976!
            '
            'Label5
            '
            Me.Label5.Height = 0.1574803!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 5.433072!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: right"
            Me.Label5.Text = "Precio"
            Me.Label5.Top = 0.8267716!
            Me.Label5.Width = 0.7874014!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.1574798!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.7874014!
            Me.Line1.Width = 6.141733!
            Me.Line1.X1 = 6.299212!
            Me.Line1.X2 = 0.1574798!
            Me.Line1.Y1 = 0.7874014!
            Me.Line1.Y2 = 0.7874014!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0.1574798!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.023622!
            Me.Line3.Width = 6.141733!
            Me.Line3.X1 = 6.299212!
            Me.Line3.X2 = 0.1574798!
            Me.Line3.Y1 = 1.023622!
            Me.Line3.Y2 = 1.023622!
            '
            'TxtBxCodigo
            '
            Me.TxtBxCodigo.Height = 0.1574803!
            Me.TxtBxCodigo.Left = 0.1574802!
            Me.TxtBxCodigo.Name = "TxtBxCodigo"
            Me.TxtBxCodigo.Style = "font-size: 9pt; vertical-align: top"
            Me.TxtBxCodigo.Text = "Codigo Articulo"
            Me.TxtBxCodigo.Top = 0!
            Me.TxtBxCodigo.Width = 1.259842!
            '
            'TxtBxDesc
            '
            Me.TxtBxDesc.Height = 0.1574803!
            Me.TxtBxDesc.Left = 1.496063!
            Me.TxtBxDesc.Name = "TxtBxDesc"
            Me.TxtBxDesc.Style = "font-size: 9pt"
            Me.TxtBxDesc.Text = "Descripción"
            Me.TxtBxDesc.Top = 0!
            Me.TxtBxDesc.Width = 2.913385!
            '
            'TxtBxCantidad
            '
            Me.TxtBxCantidad.Height = 0.1574803!
            Me.TxtBxCantidad.Left = 4.453247!
            Me.TxtBxCantidad.Name = "TxtBxCantidad"
            Me.TxtBxCantidad.Style = "font-size: 9pt"
            Me.TxtBxCantidad.Text = "Cantidad"
            Me.TxtBxCantidad.Top = 0!
            Me.TxtBxCantidad.Width = 0.5211616!
            '
            'TxtBxTalla
            '
            Me.TxtBxTalla.Height = 0.1574803!
            Me.TxtBxTalla.Left = 5.006889!
            Me.TxtBxTalla.Name = "TxtBxTalla"
            Me.TxtBxTalla.Style = "font-size: 9pt"
            Me.TxtBxTalla.Text = "Talla"
            Me.TxtBxTalla.Top = 0!
            Me.TxtBxTalla.Width = 0.3149605!
            '
            'TxtBxPrecio
            '
            Me.TxtBxPrecio.Height = 0.1574803!
            Me.TxtBxPrecio.Left = 5.433072!
            Me.TxtBxPrecio.Name = "TxtBxPrecio"
            Me.TxtBxPrecio.OutputFormat = resources.GetString("TxtBxPrecio.OutputFormat")
            Me.TxtBxPrecio.Style = "text-align: right; font-size: 9pt"
            Me.TxtBxPrecio.Text = "Precio"
            Me.TxtBxPrecio.Top = 0!
            Me.TxtBxPrecio.Width = 0.7874014!
            '
            'LblTotal
            '
            Me.LblTotal.Height = 0.1574803!
            Me.LblTotal.HyperLink = Nothing
            Me.LblTotal.Left = 4.431512!
            Me.LblTotal.Name = "LblTotal"
            Me.LblTotal.Style = ""
            Me.LblTotal.Text = "Total"
            Me.LblTotal.Top = 0.1875!
            Me.LblTotal.Width = 0.629921!
            '
            'TxtBxTotal
            '
            Me.TxtBxTotal.Height = 0.1574803!
            Me.TxtBxTotal.Left = 5.19685!
            Me.TxtBxTotal.Name = "TxtBxTotal"
            Me.TxtBxTotal.OutputFormat = resources.GetString("TxtBxTotal.OutputFormat")
            Me.TxtBxTotal.Style = "text-align: right"
            Me.TxtBxTotal.Text = "Total"
            Me.TxtBxTotal.Top = 0.1875!
            Me.TxtBxTotal.Width = 1.023623!
            '
            'TxtBxTotalLetra
            '
            Me.TxtBxTotalLetra.Height = 0.1574803!
            Me.TxtBxTotalLetra.Left = 0.1737205!
            Me.TxtBxTotalLetra.Name = "TxtBxTotalLetra"
            Me.TxtBxTotalLetra.Text = "Total Letra"
            Me.TxtBxTotalLetra.Top = 0.4862205!
            Me.TxtBxTotalLetra.Width = 5.275591!
            '
            'Label6
            '
            Me.Label6.Height = 0.1574803!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.1737203!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Total con Letra:"
            Me.Label6.Top = 0.25!
            Me.Label6.Width = 1.417323!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0.1574798!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.07874014!
            Me.Line2.Width = 6.141733!
            Me.Line2.X1 = 6.299212!
            Me.Line2.X2 = 0.1574798!
            Me.Line2.Y1 = 0.07874014!
            Me.Line2.Y2 = 0.07874014!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.364583!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblAplicaFact,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxNC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDesc,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxPrecio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotalLetra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & " pesos con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

End Class
