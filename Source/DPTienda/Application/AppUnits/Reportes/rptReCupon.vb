Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptReCupon
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Folio As String, ByVal MinMax As Decimal, ByVal Descuento As Decimal, ByVal FechaVig As Date, ByVal strFirma As String, Optional ByVal TipoDesc As String = "I", Optional ByVal TipoCupon As String = "RC", Optional ByVal LimiteDescuento As Decimal = 0, Optional ByVal EsDPCA As Boolean = False)
        MyBase.New()
        InitializeComponent()

        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (16/05/2013) - Se Adaptó para imprimir Cupones de descuento de tipo Pedido Insurtible (PI)
        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        If TipoCupon = "CD" Then
            Me.Label8.Visible = False
            Me.Label9.Visible = True
            Me.Label9.Text = "*Solo aplica en productos hasta con el " & LimiteDescuento & " % de descuento."
        Else
            Me.Label13.Location = New PointF(0.188, 5)
        End If

        If TipoDesc = "P" Then
            'QUITAMOS LABELS QUE NO NECESITAMOS
            Me.txtDesc.Visible = False
            Me.Label11.Visible = False
            Me.txtDescIVA.Visible = False

            'LE DAMOS EL FORMATO A LO QUE SI NECESITAMOS
            Me.Label4.Text = "Descuento: "
            Me.Label10.Text = Descuento & "%" 'Porcentaje Descuento
            Me.Label10.Font = New Font(Label1.Font, FontStyle.Bold)

            Me.Label7.Location = New PointF(0.188, 2)
            Me.txtFechaVigencia.Location = New PointF(1.375, 2)

            Me.lblMinMax.Location = New PointF(0.188, 2.313)
            Me.txtMinMax.Location = New PointF(1.188, 2.313)

            Me.Line1.Location = New PointF(0.188, 3.75)
            Me.txtFirma.Location = New PointF(0.188, 3.813)

            Me.Label9.Location = New PointF(0.188, 4.25)
            Me.Label13.Location = New PointF(0.188, 4.688)
            'Me.PageHeader.Height = 5.104
        End If

        Me.lblFecha.Text &= " " & Today.ToShortDateString
        Me.lblHora.Text &= " " & Now.ToShortTimeString
        Me.txtFolio.Text = Folio.Trim.ToUpper
        '----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (16.07.2015): Si el cupon se genera por primer venta con DP Card Credit se muestra el mensaje correspondiente
        '----------------------------------------------------------------------------------------------------------------------------------------
        If EsDPCA AndAlso TipoDesc = "P" Then
            Me.lblMinMax.Text = "Aplica a Maximo: "
        End If
        Me.txtMinMax.Text = IIf(TipoDesc = "P", CInt(MinMax) & " Pzas.", Format(MinMax, "$ #,###0.00"))
        Me.txtDesc.Text = Format(Descuento / (1 + oAppContext.ApplicationConfiguration.IVA), "$ #,###0.00")
        Me.txtDescIVA.Text = Format(Descuento, "$ #,###0.00")
        Me.txtFechaVigencia.Text = Format(FechaVig, "dd/MM/yyyy")
        If strFirma.Trim <> "" Then Me.txtFirma.Text = strFirma.Trim & vbCrLf & "FIRMA"

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblTitulo As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblMinMax As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtMinMax As TextBox = Nothing
	Private txtDesc As TextBox = Nothing
	Private lblFecha As Label = Nothing
	Private Label7 As Label = Nothing
	Private txtFechaVigencia As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Line1 As Line = Nothing
	Private txtFirma As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private txtDescIVA As TextBox = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private lblHora As Label = Nothing
	Private Label13 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReCupon))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.lblMinMax = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtMinMax = New DataDynamics.ActiveReports.TextBox()
            Me.txtDesc = New DataDynamics.ActiveReports.TextBox()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaVigencia = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.txtDescIVA = New DataDynamics.ActiveReports.TextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.lblHora = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMinMax,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMinMax,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDesc,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaVigencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFirma,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescIVA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.Label1, Me.Label2, Me.lblMinMax, Me.Label4, Me.txtFolio, Me.txtMinMax, Me.txtDesc, Me.lblFecha, Me.Label7, Me.txtFechaVigencia, Me.Label8, Me.Line1, Me.txtFirma, Me.Label9, Me.Label10, Me.txtDescIVA, Me.Label11, Me.Label12, Me.lblHora, Me.Label13})
            Me.PageHeader.Height = 5.839583!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.25!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 0.1875!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.lblTitulo.Text = "Dportenis"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 2.3125!
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.1875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 11.5pt; font-family: Tahoma"
            Me.Label1.Text = "Cupón de Descuento"
            Me.Label1.Top = 0.3125!
            Me.Label1.Width = 2.3125!
            '
            'Label2
            '
            Me.Label2.Height = 0.25!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.1875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: left; font-weight: normal; font-size: 11.25pt; font-family: Tahoma"
            Me.Label2.Text = "Folio:"
            Me.Label2.Top = 1.375!
            Me.Label2.Width = 0.9375!
            '
            'lblMinMax
            '
            Me.lblMinMax.Height = 0.5!
            Me.lblMinMax.HyperLink = Nothing
            Me.lblMinMax.Left = 0.1875!
            Me.lblMinMax.Name = "lblMinMax"
            Me.lblMinMax.Style = "text-align: left; font-weight: normal; font-size: 11.25pt; font-family: Tahoma"
            Me.lblMinMax.Text = "Compra mínima de:"
            Me.lblMinMax.Top = 3.0625!
            Me.lblMinMax.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.25!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label4.Text = "Bueno por:"
            Me.Label4.Top = 1.6875!
            Me.Label4.Width = 1!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.25!
            Me.txtFolio.Left = 1.125!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right; font-size: 11.25pt; font-family: Arial"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 1.375!
            Me.txtFolio.Width = 1.375!
            '
            'txtMinMax
            '
            Me.txtMinMax.Height = 0.5!
            Me.txtMinMax.Left = 1.1875!
            Me.txtMinMax.Name = "txtMinMax"
            Me.txtMinMax.Style = "text-align: right; font-size: 11.25pt; font-family: Arial; vertical-align: middle"& _ 
                ""
            Me.txtMinMax.Text = "Minimo"
            Me.txtMinMax.Top = 3.0625!
            Me.txtMinMax.Width = 1.3125!
            '
            'txtDesc
            '
            Me.txtDesc.Height = 0.25!
            Me.txtDesc.Left = 1.1875!
            Me.txtDesc.Name = "txtDesc"
            Me.txtDesc.Style = "text-align: right; font-weight: bold; font-size: 12pt"
            Me.txtDesc.Text = "Descuento"
            Me.txtDesc.Top = 1.9375!
            Me.txtDesc.Width = 1.3125!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.25!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.1875!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9.75pt; font-f"& _ 
                "amily: Tahoma"
            Me.lblFecha.Text = "Fecha:"
            Me.lblFecha.Top = 0.9375!
            Me.lblFecha.Width = 1.1875!
            '
            'Label7
            '
            Me.Label7.Height = 0.25!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.1875!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label7.Text = "Válido Hasta:"
            Me.Label7.Top = 2.75!
            Me.Label7.Width = 1.1875!
            '
            'txtFechaVigencia
            '
            Me.txtFechaVigencia.Height = 0.25!
            Me.txtFechaVigencia.Left = 1.375!
            Me.txtFechaVigencia.Name = "txtFechaVigencia"
            Me.txtFechaVigencia.Style = "text-align: right; font-weight: bold; font-size: 12pt"
            Me.txtFechaVigencia.Text = "Fecha Vigencia"
            Me.txtFechaVigencia.Top = 2.75!
            Me.txtFechaVigencia.Width = 1.125!
            '
            'Label8
            '
            Me.Label8.Height = 0.25!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.1875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 11.5pt; font-family: Tahoma"
            Me.Label8.Text = "(Re-Cupón)"
            Me.Label8.Top = 0.5625!
            Me.Label8.Width = 2.3125!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.1944444!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 4.506945!
            Me.Line1.Width = 2.430556!
            Me.Line1.X1 = 0.1944444!
            Me.Line1.X2 = 2.625!
            Me.Line1.Y1 = 4.506945!
            Me.Line1.Y2 = 4.506945!
            '
            'txtFirma
            '
            Me.txtFirma.Height = 0.375!
            Me.txtFirma.Left = 0.1875!
            Me.txtFirma.Name = "txtFirma"
            Me.txtFirma.Style = "text-align: center; font-size: 8.25pt"
            Me.txtFirma.Text = "FIRMA"
            Me.txtFirma.Top = 4.5625!
            Me.txtFirma.Width = 2.4375!
            '
            'Label9
            '
            Me.Label9.Height = 0.375!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.1875!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: normal; font-size: 9pt; font-family: Tahoma"
            Me.Label9.Text = "*Solo aplica en productos hasta con el % de descuento."
            Me.Label9.Top = 5!
            Me.Label9.Visible = false
            Me.Label9.Width = 2.4375!
            '
            'Label10
            '
            Me.Label10.Height = 0.25!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.1875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: right; font-weight: normal; font-size: 11.25pt; font-family: Arial"
            Me.Label10.Text = "Antes de IVA"
            Me.Label10.Top = 1.6875!
            Me.Label10.Width = 1.3125!
            '
            'txtDescIVA
            '
            Me.txtDescIVA.Height = 0.25!
            Me.txtDescIVA.Left = 1.1875!
            Me.txtDescIVA.Name = "txtDescIVA"
            Me.txtDescIVA.Style = "text-align: right; font-weight: bold; font-size: 12pt"
            Me.txtDescIVA.Text = "Descuento"
            Me.txtDescIVA.Top = 2.4375!
            Me.txtDescIVA.Width = 1.3125!
            '
            'Label11
            '
            Me.Label11.Height = 0.25!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 1.1875!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: right; font-weight: normal; font-size: 11.25pt; font-family: Arial"
            Me.Label11.Text = "IVA Incluido"
            Me.Label11.Top = 2.25!
            Me.Label11.Width = 1.3125!
            '
            'Label12
            '
            Me.Label12.Height = 0.25!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.1875!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9.75pt; font-f"& _ 
                "amily: Tahoma"
            Me.Label12.Text = "Fecha:"
            Me.Label12.Top = 0.9375!
            Me.Label12.Width = 1.1875!
            '
            'lblHora
            '
            Me.lblHora.Height = 0.25!
            Me.lblHora.HyperLink = Nothing
            Me.lblHora.Left = 1.375!
            Me.lblHora.Name = "lblHora"
            Me.lblHora.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9.75pt; font-"& _ 
                "family: Tahoma"
            Me.lblHora.Text = "Hora:"
            Me.lblHora.Top = 0.9375!
            Me.lblHora.Width = 1.125!
            '
            'Label13
            '
            Me.Label13.Height = 0.375!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.1875!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center; font-weight: normal; font-size: 9pt; font-family: Tahoma"
            Me.Label13.Text = "*Válido solo al presentar este cupón en caja."
            Me.Label13.Top = 5.4375!
            Me.Label13.Width = 2.4375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0.1!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.739583!
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
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMinMax,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMinMax,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDesc,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaVigencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFirma,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescIVA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
