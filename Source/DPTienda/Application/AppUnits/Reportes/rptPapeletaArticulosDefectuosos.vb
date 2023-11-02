Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class rptPapeletaArticulosDefectuosos
    Inherits DataDynamics.ActiveReports.ActiveReport

    '---------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (15.03.2016): Modificado para no mostrar la talla si no la descripcion del articulo (el cual incluye la talla)
    '---------------------------------------------------------------------------------------------------------------------------------------
    Public Sub New(ByVal oDefectuoso As Defectuoso)
        MyBase.New()
        InitializeComponent()

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oCatalogoAlmacen As Almacen

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oCatalogoAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)

        Me.txtFolioDefectuoso.Text = oDefectuoso.FolioMovimiento
        Me.txtTienda.Text = oCatalogoAlmacen.ID & " " & oCatalogoAlmacen.Descripcion

        '---------------------------------------------------------------------------------------------------------------------------------------
        ' Mostramos la fecha corta
        '---------------------------------------------------------------------------------------------------------------------------------------
        Me.txtFecha.Text = oDefectuoso.Fecha.ToShortDateString
        '---------------------------------------------------------------------------------------------------------------------------------------

        Me.txtModelo.Text = oDefectuoso.CodArticulo.TrimStart("0")
        Me.txtNFactura.Text = oDefectuoso.FolioFactura
        If oDefectuoso.Observaciones <> "" Then
            Me.RichTextBox1.Text = oDefectuoso.DefectoNota & " - " & oDefectuoso.Observaciones
        Else
            Me.RichTextBox1.Text = oDefectuoso.DefectoNota
        End If


        '---------------------------------------------------------------------------------------------------------------------------------------
        ' Obtenemos los datos del articulo
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create
        oArticulo = oArticuloMgr.Load(oDefectuoso.CodArticulo)
        Me.txtTalla.Text = oArticulo.Descripcion
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor

        oVendedor = oVendedoresMgr.Load(oDefectuoso.UsuarioMov)
        Me.txtElaboro.Text = oVendedor.ID & " " & oVendedor.Nombre

        oVendedor = oVendedoresMgr.Load(oDefectuoso.Autorizo)
        Me.txtAutorizo.Text = oVendedor.ID & " " & oVendedor.Nombre

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label2 As Label = Nothing
	Private Label1 As Label = Nothing
	Private txtFolioDefectuoso As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtTienda As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtTalla As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Label7 As Label = Nothing
	Private txtNFactura As TextBox = Nothing
	Private txtModelo As TextBox = Nothing
	Private RichTextBox1 As RichTextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private txtElaboro As TextBox = Nothing
	Private txtAutorizo As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPapeletaArticulosDefectuosos))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.txtFolioDefectuoso = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.txtNFactura = New DataDynamics.ActiveReports.TextBox()
        Me.txtModelo = New DataDynamics.ActiveReports.TextBox()
        Me.RichTextBox1 = New DataDynamics.ActiveReports.RichTextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.txtElaboro = New DataDynamics.ActiveReports.TextBox()
        Me.txtAutorizo = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioDefectuoso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtElaboro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAutorizo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.Label1, Me.txtFolioDefectuoso, Me.Label6, Me.txtTienda, Me.Label3, Me.txtFecha, Me.Label4, Me.txtTalla, Me.Label5, Me.Label7, Me.txtNFactura, Me.txtModelo, Me.RichTextBox1, Me.Label8, Me.Label9, Me.Label10, Me.txtElaboro, Me.txtAutorizo, Me.Line1, Me.Line2})
        Me.PageHeader.Height = 3.395139!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.4955709!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "ARTICULOS DEFECTUOSOS"
        Me.Label2.Top = 0.0625!
        Me.Label2.Width = 2.007874!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.727362!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = "FOLIO No."
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 1.0!
        '
        'txtFolioDefectuoso
        '
        Me.txtFolioDefectuoso.Height = 0.2!
        Me.txtFolioDefectuoso.Left = 3.8125!
        Me.txtFolioDefectuoso.Name = "txtFolioDefectuoso"
        Me.txtFolioDefectuoso.Text = "TextBox1"
        Me.txtFolioDefectuoso.Top = 0.0625!
        Me.txtFolioDefectuoso.Width = 1.0!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.125!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = ""
        Me.Label6.Text = "TIENDA:"
        Me.Label6.Top = 0.5!
        Me.Label6.Width = 1.0!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.2!
        Me.txtTienda.Left = 1.155!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Text = "TextBox2"
        Me.txtTienda.Top = 0.5!
        Me.txtTienda.Width = 2.309547!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.1181103!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "FECHA:"
        Me.Label3.Top = 0.7874014!
        Me.Label3.Width = 1.00689!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 1.155!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "TextBox3"
        Me.txtFecha.Top = 0.7870001!
        Me.txtFecha.Width = 1.04!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.598!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "DESCRIPCIÓN:"
        Me.Label4.Top = 1.102!
        Me.Label4.Width = 1.05889!
        '
        'txtTalla
        '
        Me.txtTalla.Height = 0.2!
        Me.txtTalla.Left = 3.74!
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Text = "TextBox4"
        Me.txtTalla.Top = 1.102!
        Me.txtTalla.Width = 1.732!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.125!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = ""
        Me.Label5.Text = "MODELO:"
        Me.Label5.Top = 1.102!
        Me.Label5.Width = 1.0!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.598!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = ""
        Me.Label7.Text = "No. FACTURA:"
        Me.Label7.Top = 0.7870001!
        Me.Label7.Width = 1.0!
        '
        'txtNFactura
        '
        Me.txtNFactura.Height = 0.2!
        Me.txtNFactura.Left = 3.74!
        Me.txtNFactura.Name = "txtNFactura"
        Me.txtNFactura.Text = "TextBox5"
        Me.txtNFactura.Top = 0.7870001!
        Me.txtNFactura.Width = 1.039527!
        '
        'txtModelo
        '
        Me.txtModelo.Height = 0.2!
        Me.txtModelo.Left = 1.155!
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Text = "TextBox6"
        Me.txtModelo.Top = 1.102!
        Me.txtModelo.Width = 1.348!
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoReplaceFields = True
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.RichTextBox1.Height = 0.6299211!
        Me.RichTextBox1.Left = 0.1574803!
        Me.RichTextBox1.MaxLength = 200
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.RTF = resources.GetString("RichTextBox1.RTF")
        Me.RichTextBox1.Top = 1.535433!
        Me.RichTextBox1.Width = 4.96063!
        '
        'Label8
        '
        Me.Label8.Height = 0.3543307!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.1181103!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = ""
        Me.Label8.Text = "Nota: Todos los articulos deberan ser enviados en su caja original."
        Me.Label8.Top = 2.244095!
        Me.Label8.Width = 3.346457!
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.9055118!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = ""
        Me.Label9.Text = "Elaboró"
        Me.Label9.Top = 2.913386!
        Me.Label9.Width = 1.0!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 3.267717!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = ""
        Me.Label10.Text = "Autorizó"
        Me.Label10.Top = 2.913386!
        Me.Label10.Width = 1.0!
        '
        'txtElaboro
        '
        Me.txtElaboro.Height = 0.2!
        Me.txtElaboro.Left = 0.3937007!
        Me.txtElaboro.Name = "txtElaboro"
        Me.txtElaboro.Text = "TextBox7"
        Me.txtElaboro.Top = 3.149606!
        Me.txtElaboro.Width = 2.007874!
        '
        'txtAutorizo
        '
        Me.txtAutorizo.Height = 0.2!
        Me.txtAutorizo.Left = 2.795276!
        Me.txtAutorizo.Name = "txtAutorizo"
        Me.txtAutorizo.Text = "TextBox8"
        Me.txtAutorizo.Top = 3.149606!
        Me.txtAutorizo.Width = 1.968504!
        '
        'Line1
        '
        Me.Line1.Height = 0.006944895!
        Me.Line1.Left = 2.76285!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.88096!
        Me.Line1.Width = 1.96156!
        Me.Line1.X1 = 2.76285!
        Me.Line1.X2 = 4.72441!
        Me.Line1.Y1 = 2.887905!
        Me.Line1.Y2 = 2.88096!
        '
        'Line2
        '
        Me.Line2.Height = 0.006944895!
        Me.Line2.Left = 0.4006453!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 2.88096!
        Me.Line2.Width = 1.96156!
        Me.Line2.X1 = 0.4006453!
        Me.Line2.X2 = 2.362205!
        Me.Line2.Y1 = 2.887905!
        Me.Line2.Y2 = 2.88096!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptPapeletaArticulosDefectuosos
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 5.520833!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioDefectuoso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtElaboro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAutorizo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
End Class
