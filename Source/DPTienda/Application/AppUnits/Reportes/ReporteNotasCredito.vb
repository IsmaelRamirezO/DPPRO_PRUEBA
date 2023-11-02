Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class ReporteNotasCredito
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oClientesMgr As ClientesManager
    Dim oCliente As Clientes
    Public Sub New(ByVal oForm As frmModCapNotCredito, ByVal ClienteID As Integer)
        MyBase.New()
        InitializeComponent()
        InicializaObjetos()

        tbFolio.Text = oForm.ebFolio.Text
        'oClientesMgr.LoadInto(ClienteID, oCliente)

        'If (oCliente.ClienteID = 1) Then
        If (ClienteID = 1) Then

            'tbCliente.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno
            tbCliente.Text = "PÚBLICO GENERAL"

        Else

            oClientesMgr.LoadInto(ClienteID, oCliente)

            'Mostrar Datos Fiscalez [Nombre, RFC, Domicilio] :

            tbCliente.Text = oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno

            tbRFC.Text = oCliente.CedulaFiscal

            tbSubTotal.Text = Format(oForm.ebSubTotal.Text, "Currency")

            tbIVA.Text = Format(oForm.ebIVA.Text, "Currency")

            tbDomicilio.Text = oCliente.Domicilio & " " & oCliente.Colonia

        End If


        tbTipoDevolucion.Text = oForm.uicmbTipoDevolucion.Text
        tbFecha.Text = oForm.ebFecha.Text
        tbSucursal.Text = oAppContext.ApplicationConfiguration.Almacen
        tbSucOrigen.Text = oForm.ebSucOrigen.Text
        tbAplicada.Text = oForm.ebAplicada.Text

        tbTotal.Text = oForm.ebTotal.Text

        Dim TotalALetras As Decimal = CDec(tbTotal.Text) 'Correccion por cambio Framework (JNAVA - 06/11/2015)
        tbTotalLetras.Text = Letras(Decimal.Round(TotalALetras, 2))

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbRFC As TextBox = Nothing
	Private tbTipoDevolucion As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbSucursal As TextBox = Nothing
	Private tbNumeroControl As TextBox = Nothing
	Private tbSucOrigen As TextBox = Nothing
	Private tbAplicada As TextBox = Nothing
	Private tbDomicilio As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox17 As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private tbSubTotal As TextBox = Nothing
	Private tbIVA As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteNotasCredito))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbRFC = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoDevolucion = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.tbNumeroControl = New DataDynamics.ActiveReports.TextBox()
            Me.tbSucOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.tbAplicada = New DataDynamics.ActiveReports.TextBox()
            Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
            Me.tbSubTotal = New DataDynamics.ActiveReports.TextBox()
            Me.tbIVA = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbRFC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoDevolucion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNumeroControl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSucOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbAplicada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDomicilio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalLetras,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSubTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbIVA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.TextBox17, Me.TextBox18})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.tbCliente, Me.tbRFC, Me.tbTipoDevolucion, Me.tbFecha, Me.tbSucursal, Me.tbNumeroControl, Me.tbSucOrigen, Me.tbAplicada, Me.tbDomicilio})
            Me.PageHeader.Height = 2.041667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.02083333!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.CanGrow = false
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTotalLetras, Me.tbSubTotal, Me.tbIVA, Me.tbTotal})
            Me.GroupFooter1.Height = 2.666667!
            Me.GroupFooter1.Name = "GroupFooter1"
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
            'tbCliente
            '
            Me.tbCliente.Height = 0.2!
            Me.tbCliente.Left = 1.25!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbCliente.Top = 0.25!
            Me.tbCliente.Width = 3.4375!
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
            'tbSucursal
            '
            Me.tbSucursal.Height = 0.2!
            Me.tbSucursal.Left = 0.25!
            Me.tbSucursal.Name = "tbSucursal"
            Me.tbSucursal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbSucursal.Top = 1.0625!
            Me.tbSucursal.Width = 1.479!
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
            'tbSucOrigen
            '
            Me.tbSucOrigen.Height = 0.2!
            Me.tbSucOrigen.Left = 3.1875!
            Me.tbSucOrigen.Name = "tbSucOrigen"
            Me.tbSucOrigen.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbSucOrigen.Top = 1.0625!
            Me.tbSucOrigen.Width = 1.479!
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
            'tbDomicilio
            '
            Me.tbDomicilio.Height = 0.1875!
            Me.tbDomicilio.Left = 0.3125!
            Me.tbDomicilio.Name = "tbDomicilio"
            Me.tbDomicilio.Style = "font-size: 8.25pt"
            Me.tbDomicilio.Top = 1.75!
            Me.tbDomicilio.Width = 4.0625!
            '
            'TextBox10
            '
            Me.TextBox10.CanGrow = false
            Me.TextBox10.DataField = "Fecha"
            Me.TextBox10.Height = 0.155!
            Me.TextBox10.Left = 0.125!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox10.Top = 0!
            Me.TextBox10.Width = 0.625!
            '
            'TextBox11
            '
            Me.TextBox11.DataField = "FolioReferencia"
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 0.75!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox11.Top = 0!
            Me.TextBox11.Width = 0.625!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "Cantidad"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 1.375!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox12.Top = 0!
            Me.TextBox12.Width = 0.4375!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "Descripcion"
            Me.TextBox13.Height = 0.2!
            Me.TextBox13.Left = 1.8125!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox13.Top = 0!
            Me.TextBox13.Width = 1.3125!
            '
            'TextBox17
            '
            Me.TextBox17.DataField = "PrecioUnit"
            Me.TextBox17.Height = 0.2!
            Me.TextBox17.Left = 3.125!
            Me.TextBox17.Name = "TextBox17"
            Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
            Me.TextBox17.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox17.Top = 0!
            Me.TextBox17.Width = 0.875!
            '
            'TextBox18
            '
            Me.TextBox18.DataField = "Importe"
            Me.TextBox18.Height = 0.2!
            Me.TextBox18.Left = 4!
            Me.TextBox18.Name = "TextBox18"
            Me.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat")
            Me.TextBox18.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.TextBox18.Top = 0!
            Me.TextBox18.Width = 0.75!
            '
            'tbTotalLetras
            '
            Me.tbTotalLetras.Height = 0.2!
            Me.tbTotalLetras.Left = 1.1875!
            Me.tbTotalLetras.Name = "tbTotalLetras"
            Me.tbTotalLetras.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbTotalLetras.Top = 1.8125!
            Me.tbTotalLetras.Width = 2.875!
            '
            'tbSubTotal
            '
            Me.tbSubTotal.Height = 0.2!
            Me.tbSubTotal.Left = 2.5!
            Me.tbSubTotal.Name = "tbSubTotal"
            Me.tbSubTotal.OutputFormat = resources.GetString("tbSubTotal.OutputFormat")
            Me.tbSubTotal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbSubTotal.Top = 2.625!
            Me.tbSubTotal.Width = 0.6000001!
            '
            'tbIVA
            '
            Me.tbIVA.Height = 0.2!
            Me.tbIVA.Left = 3.125!
            Me.tbIVA.Name = "tbIVA"
            Me.tbIVA.OutputFormat = resources.GetString("tbIVA.OutputFormat")
            Me.tbIVA.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbIVA.Top = 2.625!
            Me.tbIVA.Width = 0.6000001!
            '
            'tbTotal
            '
            Me.tbTotal.Height = 0.2!
            Me.tbTotal.Left = 3.75!
            Me.tbTotal.Name = "tbTotal"
            Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
            Me.tbTotal.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.tbTotal.Top = 2.625!
            Me.tbTotal.Width = 0.6000001!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.2!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 4.770833!
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
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbRFC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoDevolucion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNumeroControl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSucOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbAplicada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDomicilio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalLetras,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSubTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbIVA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub InicializaObjetos()

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.Create

    End Sub

    Public Function Letras(ByVal numero As String) As String
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
                Letras = palabras & "con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function


End Class
