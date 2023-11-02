Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptContratosVigentes
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsDetalle As DataSet)
        MyBase.New()
        InitializeComponent()

        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen


        End If

        Me.lblFecha.Text = Now.Date.ToShortDateString

        Me.txtAnticipos.Text = CDec(dsDetalle.Tables(0).Compute("sum(ITotal)", "ITotal>0") - dsDetalle.Tables(0).Compute("sum(Saldo)", "Saldo>0"))
        Me.txtDiferencia.Text = CDec(dsDetalle.Tables(0).Compute("sum(ITotal)", "ITotal>0") - Me.txtAnticipos.Text)

        Me.txtAnticipos.Text = Me.txtAnticipos.Text
        Me.txtDiferencia.Text = Me.txtDiferencia.Text

        Dim col As New DataColumn("Anticipos")

        With col
            .DataType = GetType(System.Decimal)
            .DefaultValue = Me.txtAnticipos.Text
        End With

        Dim col2 As New DataColumn("Diferencia")

        With col2
            .DataType = GetType(System.Decimal)
            .DefaultValue = Me.txtDiferencia.Text
        End With

        dsDetalle.Tables(0).Columns.Add(col)
        dsDetalle.Tables(0).Columns.Add(col2)
        dsDetalle.AcceptChanges()

        Me.DataSource = dsDetalle
        Me.DataMember = dsDetalle.Tables(0).TableName

        

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtFecha As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private txtCodVendedor As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private txtCodCliente As TextBox = Nothing
	Private txtNombre As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Shape3 As Shape = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private txtImporteTotal As TextBox = Nothing
	Private txtAnticipos As TextBox = Nothing
	Private txtDiferencia As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptContratosVigentes))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtCodCliente = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtImporteTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtAnticipos = New DataDynamics.ActiveReports.TextBox()
            Me.txtDiferencia = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAnticipos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDiferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtFecha, Me.TextBox2, Me.txtCodVendedor, Me.txtImporte, Me.TextBox5, Me.TextBox6, Me.Label4, Me.Label5, Me.txtCodCliente, Me.txtNombre, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11})
            Me.Detail.Height = 1.15625!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.lblFecha, Me.Label3, Me.txtSucursal})
            Me.PageHeader.Height = 0.6666667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.7388889!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label12, Me.Label13, Me.Label14, Me.txtImporteTotal, Me.txtAnticipos, Me.txtDiferencia})
            Me.GroupFooter1.Height = 0.84375!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6692914!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.496063!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.406004!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "APARTADOS VIGENTES"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 1.653543!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 4.330709!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = "Label2"
            Me.lblFecha.Top = 0.07874014!
            Me.lblFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.732283!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.3543307!
            Me.Label3.Width = 0.6299212!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.362204!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "Sucu"
            Me.txtSucursal.Top = 0.3543307!
            Me.txtSucursal.Width = 2.755905!
            '
            'Shape2
            '
            Me.Shape2.Height = 1.141733!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.496063!
            '
            'txtFecha
            '
            Me.txtFecha.DataField = "Fecha"
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.0625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "text-align: center"
            Me.txtFecha.Text = "TextBox1"
            Me.txtFecha.Top = 0.9375!
            Me.txtFecha.Width = 1!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "FolioApartado"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 1.181102!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center"
            Me.TextBox2.Text = "1"
            Me.TextBox2.Top = 0.9143701!
            Me.TextBox2.Width = 1!
            '
            'txtCodVendedor
            '
            Me.txtCodVendedor.DataField = "CodVendedor"
            Me.txtCodVendedor.Height = 0.2!
            Me.txtCodVendedor.Left = 2.424705!
            Me.txtCodVendedor.Name = "txtCodVendedor"
            Me.txtCodVendedor.Style = "text-align: center"
            Me.txtCodVendedor.Top = 0.9143701!
            Me.txtCodVendedor.Width = 0.7874014!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "ITotal"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 3.307087!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right"
            Me.txtImporte.Top = 0.9143701!
            Me.txtImporte.Width = 0.944882!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Saldo"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 4.409449!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "text-align: right"
            Me.TextBox5.Top = 0.9143701!
            Me.TextBox5.Width = 0.9448826!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "Entregada"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 5.613681!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "text-align: center"
            Me.TextBox6.Top = 0.9143701!
            Me.TextBox6.Width = 0.7480313!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.03937007!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Cod. Cliente:"
            Me.Label4.Top = 0.07874014!
            Me.Label4.Width = 1!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.03937006!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Nom. Cliente:"
            Me.Label5.Top = 0.3937007!
            Me.Label5.Width = 1!
            '
            'txtCodCliente
            '
            Me.txtCodCliente.DataField = "ClienteID"
            Me.txtCodCliente.Height = 0.2!
            Me.txtCodCliente.Left = 1.181102!
            Me.txtCodCliente.Name = "txtCodCliente"
            Me.txtCodCliente.Text = "TextBox1"
            Me.txtCodCliente.Top = 0.07874014!
            Me.txtCodCliente.Width = 1!
            '
            'txtNombre
            '
            Me.txtNombre.DataField = "Nombre"
            Me.txtNombre.Height = 0.2!
            Me.txtNombre.Left = 1.181102!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Text = "TextBox2"
            Me.txtNombre.Top = 0.3937007!
            Me.txtNombre.Width = 3.188977!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "FECHA"
            Me.Label6.Top = 0.7086611!
            Me.Label6.Width = 0.9055118!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.102362!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "NUM. CONTRATO"
            Me.Label7.Top = 0.7086611!
            Me.Label7.Width = 1.259842!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.440945!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "VENDEDOR"
            Me.Label8.Top = 0.7086611!
            Me.Label8.Width = 0.8267716!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.494587!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "IMPORTE"
            Me.Label9.Top = 0.7086611!
            Me.Label9.Width = 0.8198826!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 4.78494!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center"
            Me.Label10.Text = "SALDO"
            Me.Label10.Top = 0.7086611!
            Me.Label10.Width = 0.5831699!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 5.590551!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center"
            Me.Label11.Text = "LIQUIDADO"
            Me.Label11.Top = 0.7086611!
            Me.Label11.Width = 0.8267716!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.8267716!
            Me.Shape3.Left = 0!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 6.496063!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "Importe Total de Mercancia Apartada:"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 2.378445!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.03937006!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = ""
            Me.Label13.Text = "Anticipos y Abonos Recibidos."
            Me.Label13.Top = 0.2987205!
            Me.Label13.Width = 2.362205!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.03937006!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Diferencia que podemos Cobrar:"
            Me.Label14.Top = 0.5580709!
            Me.Label14.Width = 2.362205!
            '
            'txtImporteTotal
            '
            Me.txtImporteTotal.DataField = "ITotal"
            Me.txtImporteTotal.Height = 0.2!
            Me.txtImporteTotal.Left = 2.480315!
            Me.txtImporteTotal.Name = "txtImporteTotal"
            Me.txtImporteTotal.OutputFormat = resources.GetString("txtImporteTotal.OutputFormat")
            Me.txtImporteTotal.Style = "text-align: right"
            Me.txtImporteTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtImporteTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtImporteTotal.Text = "TextBox7"
            Me.txtImporteTotal.Top = 0.07874014!
            Me.txtImporteTotal.Width = 1!
            '
            'txtAnticipos
            '
            Me.txtAnticipos.DataField = "Anticipos"
            Me.txtAnticipos.Height = 0.2!
            Me.txtAnticipos.Left = 2.480315!
            Me.txtAnticipos.Name = "txtAnticipos"
            Me.txtAnticipos.OutputFormat = resources.GetString("txtAnticipos.OutputFormat")
            Me.txtAnticipos.Style = "text-align: right"
            Me.txtAnticipos.Text = "TextBox8"
            Me.txtAnticipos.Top = 0.3149606!
            Me.txtAnticipos.Width = 1!
            '
            'txtDiferencia
            '
            Me.txtDiferencia.DataField = "Diferencia"
            Me.txtDiferencia.Height = 0.2!
            Me.txtDiferencia.Left = 2.480315!
            Me.txtDiferencia.Name = "txtDiferencia"
            Me.txtDiferencia.OutputFormat = resources.GetString("txtDiferencia.OutputFormat")
            Me.txtDiferencia.Style = "text-align: right"
            Me.txtDiferencia.Text = "TextBox9"
            Me.txtDiferencia.Top = 0.551181!
            Me.txtDiferencia.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.541667!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAnticipos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDiferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format

        '  DirectCast(Me.GroupFooter1.Controls("txtDiferencia"), TextBox).Text = DirectCast(Me.GroupFooter1.Controls("txtImporteTotal"), TextBox).Text.Trim("$") - _
                                                                              DirectCast(Me.GroupFooter1.Controls("txtAnticipos"), TextBox).Text.Trim("$")

    End Sub
End Class
