Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptArqueoCajaChica
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oArqueoCaja As ArqueoDeCaja, ByVal Administrativo As String, ByVal Responsable As String)

        MyBase.New()

        InitializeComponent()

        Me.txtFolio.Text = oArqueoCaja.Folio
        Me.txtFecha.Text = oArqueoCaja.Fecha

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""
        strCentro = oSAPMgr.Read_Centros
        Dim oAlmacen As Almacen = oCatalogoAlmacenesMgr.Load(strCentro) 'oArqueoCaja.Sucursal)
        Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion


        Me.txtAdministrativo.Text = Administrativo

        Me.txtResponsable.Text = Responsable

        Me.txtObservaciones.Text = oArqueoCaja.Observaciones

        Dim Totalconteo As Decimal = 0, TotalDoc As Decimal = 0

        If IsDBNull(oArqueoCaja.Ingresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")) Then
            Totalconteo = 0
        Else
            Totalconteo = oArqueoCaja.Ingresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")
        End If

        If IsDBNull(oArqueoCaja.Ingresos.Tables("Documentos").Compute("sum(Importe)", "Importe>0")) Then
            TotalDoc = 0
        Else
            TotalDoc = oArqueoCaja.Ingresos.Tables("Documentos").Compute("sum(Importe)", "Importe>0")
        End If

        '''Inicioamos Detalle ingresos
        Dim oReporteDenominaciones As New rptDenominaciones(oArqueoCaja.FondoCaja, Totalconteo + TotalDoc, 3)
        oReporteDenominaciones.DataSource = oArqueoCaja.Ingresos
        oReporteDenominaciones.DataMember = "Denominaciones"
        Me.sbEfectivo.Report = oReporteDenominaciones
        Me.sbEfectivo.Report.DataSource = oReporteDenominaciones.DataSource
        Me.sbEfectivo.Report.DataMember = oReporteDenominaciones.DataMember
        '''Inicioamos Detalle ingresos

        '''Inicioamos Documentos
        Dim oDocumentos As New rptArqueoDocumentos
        oDocumentos.DataSource = oArqueoCaja.Ingresos
        oDocumentos.DataMember = "Documentos"
        Me.sbDocumentos.Report = oDocumentos
        Me.sbDocumentos.Report.DataSource = oDocumentos.DataSource
        Me.sbDocumentos.Report.DataMember = oDocumentos.DataMember
        '''Inicioamos Detalle ingresos



        'Me.lblNota.Text = "LOS VALORES ARRIBA MENCIONADOS FUERON CONTADOS POR EL ADMINISTRATIVO DE LA PLAZA: " & oVendedor.Nombre & _
        '" Y RESPONSABLE DE LA SUCURSAL: " & oVendedor2.Nombre & " , OBTENIENDO LOS RESULTADOS DESCRITOS EN ESTE FORMATO, LOS CUALES " & _
        '"EL RESPONSABLE DE ESTA SUCURSAL CERTIFICA QUE ESTOS SON CORRECTOS Y QUE ESTA TOTALMENTE DE ACUERDO CON LOS MISMOS."

        'Me.txtFAdministrativo.Text = oVendedor.Nombre
        'Me.txtFResponsable.Text = oVendedor2.Nombre


        Me.lblNota.Text = "LOS VALORES ARRIBA MENCIONADOS FUERON CONTADOS POR EL ADMINISTRATIVO DE LA PLAZA: " & Administrativo & _
                            " Y RESPONSABLE DE LA SUCURSAL: " & Responsable & " , OBTENIENDO LOS RESULTADOS DESCRITOS EN ESTE FORMATO, LOS CUALES " & _
                            "EL RESPONSABLE DE ESTA SUCURSAL CERTIFICA QUE ESTOS SON CORRECTOS Y QUE ESTA TOTALMENTE DE ACUERDO CON LOS MISMOS."

        Me.txtFAdministrativo.Text = Administrativo
        Me.txtFResponsable.Text = Responsable


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtAdministrativo As TextBox = Nothing
	Private txtResponsable As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private sbDocumentos As SubReport = Nothing
	Private sbEfectivo As SubReport = Nothing
	Private Label9 As Label = Nothing
	Private txtObservaciones As RichTextBox = Nothing
	Private lblNota As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtFAdministrativo As TextBox = Nothing
	Private txtFResponsable As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptArqueoCajaChica))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtAdministrativo = New DataDynamics.ActiveReports.TextBox()
            Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.sbDocumentos = New DataDynamics.ActiveReports.SubReport()
            Me.sbEfectivo = New DataDynamics.ActiveReports.SubReport()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.txtObservaciones = New DataDynamics.ActiveReports.RichTextBox()
            Me.lblNota = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtFAdministrativo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFResponsable = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNota,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.sbDocumentos, Me.sbEfectivo})
            Me.Detail.Height = 0.3333333!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.txtFolio, Me.txtSucursal, Me.txtFecha, Me.txtAdministrativo, Me.txtResponsable})
            Me.PageHeader.Height = 1.364583!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label11, Me.txtFAdministrativo, Me.txtFResponsable, Me.Label12})
            Me.PageFooter.Height = 0.5!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7, Me.Label8})
            Me.GroupHeader1.Height = 0.1979167!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.txtObservaciones, Me.lblNota})
            Me.GroupFooter1.Height = 2.104167!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.047244!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "Arqueo de Fondo de Caja Chica"
            Me.Label1.Top = 0.03937007!
            Me.Label1.Width = 2.716535!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.3937007!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Folio:"
            Me.Label2.Top = 0.3937007!
            Me.Label2.Width = 0.4330708!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.672244!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.3937007!
            Me.Label3.Width = 0.6692915!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.566929!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Fecha:"
            Me.Label4.Top = 0.3937007!
            Me.Label4.Width = 0.5511808!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.3937008!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Administrativo"
            Me.Label5.Top = 0.7086611!
            Me.Label5.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.3937007!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Responsable:"
            Me.Label6.Top = 0.9842521!
            Me.Label6.Width = 1!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.8661417!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Text = "TextBox1"
            Me.txtFolio.Top = 0.3937007!
            Me.txtFolio.Width = 0.7086611!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.459646!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "TextBox2"
            Me.txtSucursal.Top = 0.3937007!
            Me.txtSucursal.Width = 2.028543!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 5.118111!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "TextBox3"
            Me.txtFecha.Top = 0.3937007!
            Me.txtFecha.Width = 1!
            '
            'txtAdministrativo
            '
            Me.txtAdministrativo.Height = 0.2!
            Me.txtAdministrativo.Left = 1.456693!
            Me.txtAdministrativo.Name = "txtAdministrativo"
            Me.txtAdministrativo.Text = "TextBox4"
            Me.txtAdministrativo.Top = 0.7086611!
            Me.txtAdministrativo.Width = 2.992126!
            '
            'txtResponsable
            '
            Me.txtResponsable.Height = 0.2!
            Me.txtResponsable.Left = 1.433563!
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Text = "TextBox5"
            Me.txtResponsable.Top = 0.9842521!
            Me.txtResponsable.Width = 3.015256!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.875!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "DOCUMENTOS"
            Me.Label7.Top = 0!
            Me.Label7.Width = 1.139764!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "EFECTIVO"
            Me.Label8.Top = 0!
            Me.Label8.Width = 1!
            '
            'sbDocumentos
            '
            Me.sbDocumentos.CloseBorder = false
            Me.sbDocumentos.Height = 0.2918307!
            Me.sbDocumentos.Left = 0.01624016!
            Me.sbDocumentos.Name = "sbDocumentos"
            Me.sbDocumentos.Report = Nothing
            Me.sbDocumentos.Top = 0!
            Me.sbDocumentos.Width = 3.290846!
            '
            'sbEfectivo
            '
            Me.sbEfectivo.CloseBorder = false
            Me.sbEfectivo.Height = 0.3149606!
            Me.sbEfectivo.Left = 3.375!
            Me.sbEfectivo.Name = "sbEfectivo"
            Me.sbEfectivo.Report = Nothing
            Me.sbEfectivo.Top = 0!
            Me.sbEfectivo.Width = 3!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.0625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "OBSERVACIONES"
            Me.Label9.Top = 0.0625!
            Me.Label9.Width = 1.276083!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Font = New System.Drawing.Font("Arial", 10!)
            Me.txtObservaciones.Height = 0.7844486!
            Me.txtObservaciones.Left = 1.5!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.RTF = resources.GetString("txtObservaciones.RTF")
            Me.txtObservaciones.Top = 0.2780512!
            Me.txtObservaciones.Width = 4.562992!
            '
            'lblNota
            '
            Me.lblNota.Height = 0.8267716!
            Me.lblNota.HyperLink = Nothing
            Me.lblNota.Left = 0.1181103!
            Me.lblNota.Name = "lblNota"
            Me.lblNota.Style = "text-align: justify; font-size: 9pt"
            Me.lblNota.Text = "Label10"
            Me.lblNota.Top = 1.181102!
            Me.lblNota.Width = 6.220472!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.8267716!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "ADMINISTRATIVO DE PLAZA"
            Me.Label11.Top = 0.03937006!
            Me.Label11.Width = 1.934056!
            '
            'txtFAdministrativo
            '
            Me.txtFAdministrativo.Height = 0.2!
            Me.txtFAdministrativo.Left = 0.8316923!
            Me.txtFAdministrativo.Name = "txtFAdministrativo"
            Me.txtFAdministrativo.Text = "TextBox1"
            Me.txtFAdministrativo.Top = 0.2529526!
            Me.txtFAdministrativo.Width = 1.929134!
            '
            'txtFResponsable
            '
            Me.txtFResponsable.Height = 0.2!
            Me.txtFResponsable.Left = 3.902559!
            Me.txtFResponsable.Name = "txtFResponsable"
            Me.txtFResponsable.Text = "TextBox2"
            Me.txtFResponsable.Top = 0.2529526!
            Me.txtFResponsable.Width = 1.968504!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.889271!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "RESPONSABLE SUCURSAL"
            Me.Label12.Top = 0.03937006!
            Me.Label12.Width = 1.981791!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
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
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNota,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
