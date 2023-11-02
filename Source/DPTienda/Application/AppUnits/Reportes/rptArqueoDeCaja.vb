Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class rptArqueoDeCaja

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oArqueoCaja As ArqueoDeCaja, ByVal Administrativo As String, ByVal Responsable As String)

        MyBase.New()

        InitializeComponent()

        Me.txtFolio.Text = oArqueoCaja.Folio
        Me.txtFecha.Text = oArqueoCaja.Fecha

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig), strCentro As String = ""
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        strCentro = oSAPMgr.Read_Centros
        oAlmacen = oCatalogoAlmacenesMgr.Load(strCentro) 'oArqueoCaja.Sucursal)
        If Not oAlmacen Is Nothing Then Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion
        oSAPMgr = Nothing

        Me.txtAdministrativo.Text = Administrativo

        Me.txtResponsable.Text = Responsable

        Me.txtObservaciones.Text = oArqueoCaja.Observaciones

        Dim totalconteo As Decimal = 0

        '''Inicioamos Detalle ingresos
        If IsDBNull(oArqueoCaja.Ingresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")) Then
            totalconteo = 0
        Else
            totalconteo = oArqueoCaja.Ingresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")
        End If
        Dim oReporteDenominaciones As New rptDenominaciones(oArqueoCaja.IngresosDia, totalconteo, 1)
        oReporteDenominaciones.DataSource = oArqueoCaja.Ingresos
        oReporteDenominaciones.DataMember = "Denominaciones"
        Me.srIngresosDia.Report = oReporteDenominaciones
        Me.srIngresosDia.Report.DataSource = oReporteDenominaciones.DataSource
        Me.srIngresosDia.Report.DataMember = oReporteDenominaciones.DataMember
        '''Inicioamos Detalle ingresos

        '''Inicioamos Detalle Fondo caja
        If IsDBNull(oArqueoCaja.Ingresos.Tables("Denominaciones2").Compute("sum(Total)", "Total>0")) Then
            totalconteo = 0
        Else
            totalconteo = oArqueoCaja.Ingresos.Tables("Denominaciones2").Compute("sum(Total)", "Total>0")
        End If
        Dim oReporteDenominaciones2 As New rptDenominaciones(oArqueoCaja.FondoCaja, totalconteo, 2)
        oReporteDenominaciones2.DataSource = oArqueoCaja.Ingresos
        oReporteDenominaciones2.DataMember = oArqueoCaja.Ingresos.Tables("Denominaciones2").TableName
        Me.srFondoCaja.Report = oReporteDenominaciones2
        Me.srFondoCaja.Report.DataSource = oReporteDenominaciones2.DataSource
        Me.srFondoCaja.Report.DataMember = oReporteDenominaciones2.DataMember
        '''Inicioamos Detalle Fondo caja

        '''Inicioamos Detalle Ingresos Dia Anterior 
        If IsDBNull(oArqueoCaja.Ingresos.Tables("IngresoAnterior").Compute("sum(Importe)", "Importe>0")) Then
            totalconteo = 0
        Else
            totalconteo = oArqueoCaja.Ingresos.Tables("IngresoAnterior").Compute("sum(Importe)", "Importe>0")
        End If
        Dim oIngresosAnterior As New rptIngresosDiaAnterior(oArqueoCaja.IngresosDiaAnterioro, totalconteo)
        oIngresosAnterior.DataSource = oArqueoCaja.Ingresos
        oIngresosAnterior.DataMember = oArqueoCaja.Ingresos.Tables("IngresoAnterior").TableName

        Me.srIngresosDiaAnterior.Report = oIngresosAnterior
        Me.srIngresosDiaAnterior.Report.DataSource = oIngresosAnterior.DataSource
        Me.srIngresosDiaAnterior.Report.DataMember = oIngresosAnterior.DataMember
        '''Inicioamos Detalle Ingresos Dia Anterior 

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
    Private txtAdministrativo As TextBox = Nothing
    Private txtResponsable As TextBox = Nothing
    Private txtSucursal As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private txtFolio As TextBox = Nothing
    Private Label9 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Label7 As Label = Nothing
    Private srIngresosDia As SubReport = Nothing
    Private srIngresosDiaAnterior As SubReport = Nothing
    Private srFondoCaja As SubReport = Nothing
    Private Label10 As Label = Nothing
    Private txtObservaciones As RichTextBox = Nothing
    Private Label11 As Label = Nothing
    Private Label12 As Label = Nothing
    Private lblNota As Label = Nothing
    Private txtFAdministrativo As TextBox = Nothing
    Private txtFResponsable As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptArqueoDeCaja))
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
            Me.txtAdministrativo = New DataDynamics.ActiveReports.TextBox()
            Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.srIngresosDia = New DataDynamics.ActiveReports.SubReport()
            Me.srIngresosDiaAnterior = New DataDynamics.ActiveReports.SubReport()
            Me.srFondoCaja = New DataDynamics.ActiveReports.SubReport()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.txtObservaciones = New DataDynamics.ActiveReports.RichTextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.lblNota = New DataDynamics.ActiveReports.Label()
            Me.txtFAdministrativo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFResponsable = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNota,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.srIngresosDia, Me.srIngresosDiaAnterior, Me.srFondoCaja})
            Me.Detail.Height = 0.2708333!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.txtAdministrativo, Me.txtResponsable, Me.txtSucursal, Me.txtFecha, Me.txtFolio})
            Me.PageHeader.Height = 1.020833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label8, Me.Label7})
            Me.GroupHeader1.Height = 0.3020833!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.txtObservaciones, Me.Label11, Me.Label12, Me.lblNota, Me.txtFAdministrativo, Me.txtFResponsable})
            Me.GroupFooter1.Height = 2.426389!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.283465!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "Ingresos y Fondo de Caja"
            Me.Label1.Top = 0!
            Me.Label1.Width = 2.598425!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.2755906!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Folio:"
            Me.Label2.Top = 0.2362205!
            Me.Label2.Width = 0.4251968!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.40059!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.2362205!
            Me.Label3.Width = 0.6466535!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.77559!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Fecha:"
            Me.Label4.Top = 0.2362205!
            Me.Label4.Width = 0.6466535!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.1574803!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Administrativo:"
            Me.Label5.Top = 0.511811!
            Me.Label5.Width = 1.220472!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.1181103!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Responsable Suc.:"
            Me.Label6.Top = 0.7874014!
            Me.Label6.Width = 1.259842!
            '
            'txtAdministrativo
            '
            Me.txtAdministrativo.Height = 0.2!
            Me.txtAdministrativo.Left = 1.5625!
            Me.txtAdministrativo.Name = "txtAdministrativo"
            Me.txtAdministrativo.Text = "TextBox1"
            Me.txtAdministrativo.Top = 0.5!
            Me.txtAdministrativo.Width = 3.293307!
            '
            'txtResponsable
            '
            Me.txtResponsable.Height = 0.2!
            Me.txtResponsable.Left = 1.574803!
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Text = "TextBox2"
            Me.txtResponsable.Top = 0.7874014!
            Me.txtResponsable.Width = 3.293307!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.165354!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "TextBox3"
            Me.txtSucursal.Top = 0.2362205!
            Me.txtSucursal.Width = 1.980807!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 5.540354!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "TextBox4"
            Me.txtFecha.Top = 0.2362205!
            Me.txtFecha.Width = 1.152559!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.7903541!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Text = "TextBox5"
            Me.txtFolio.Top = 0.2362205!
            Me.txtFolio.Width = 0.5088583!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0.3056103!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "Ingresos en Efvo. del Día"
            Me.Label9.Top = 0.03740144!
            Me.Label9.Width = 1.653543!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.556595!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Ingresos en Efvo. del Día Anterior"
            Me.Label8.Top = 0.03740144!
            Me.Label8.Width = 2.204725!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.493111!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Fondo Caja"
            Me.Label7.Top = 0.03740144!
            Me.Label7.Width = 0.8705708!
            '
            'srIngresosDia
            '
            Me.srIngresosDia.CloseBorder = false
            Me.srIngresosDia.Height = 0.2362205!
            Me.srIngresosDia.Left = 0!
            Me.srIngresosDia.Name = "srIngresosDia"
            Me.srIngresosDia.Report = Nothing
            Me.srIngresosDia.Top = 0!
            Me.srIngresosDia.Width = 2.362205!
            '
            'srIngresosDiaAnterior
            '
            Me.srIngresosDiaAnterior.CloseBorder = false
            Me.srIngresosDiaAnterior.Height = 0.2362205!
            Me.srIngresosDiaAnterior.Left = 2.533465!
            Me.srIngresosDiaAnterior.Name = "srIngresosDiaAnterior"
            Me.srIngresosDiaAnterior.Report = Nothing
            Me.srIngresosDiaAnterior.Top = 0!
            Me.srIngresosDiaAnterior.Width = 2.362205!
            '
            'srFondoCaja
            '
            Me.srFondoCaja.CloseBorder = false
            Me.srFondoCaja.Height = 0.2362205!
            Me.srFondoCaja.Left = 4.979823!
            Me.srFondoCaja.Name = "srFondoCaja"
            Me.srFondoCaja.Report = Nothing
            Me.srFondoCaja.Top = 0!
            Me.srFondoCaja.Width = 2.362205!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.1181103!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "Observaciones:"
            Me.Label10.Top = 0.03740144!
            Me.Label10.Width = 1.259842!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Font = New System.Drawing.Font("Arial", 10!)
            Me.txtObservaciones.Height = 0.4862204!
            Me.txtObservaciones.Left = 1.285433!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.RTF = resources.GetString("txtObservaciones.RTF")
            Me.txtObservaciones.Top = 0.2755906!
            Me.txtObservaciones.Width = 6.037402!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.7431104!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "ADMINISTRATIVO DE PLAZA"
            Me.Label11.Top = 1.912401!
            Me.Label11.Width = 1.934056!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.80561!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "RESPONSABLE SUCURSAL"
            Me.Label12.Top = 1.912401!
            Me.Label12.Width = 1.981791!
            '
            'lblNota
            '
            Me.lblNota.Height = 0.9055118!
            Me.lblNota.HyperLink = Nothing
            Me.lblNota.Left = 0.1043307!
            Me.lblNota.Name = "lblNota"
            Me.lblNota.Style = "font-size: 9pt"
            Me.lblNota.Text = resources.GetString("lblNota.Text")
            Me.lblNota.Top = 0.8267716!
            Me.lblNota.Width = 7.218507!
            '
            'txtFAdministrativo
            '
            Me.txtFAdministrativo.Height = 0.2!
            Me.txtFAdministrativo.Left = 0.7480313!
            Me.txtFAdministrativo.Name = "txtFAdministrativo"
            Me.txtFAdministrativo.Text = "TextBox1"
            Me.txtFAdministrativo.Top = 2.125984!
            Me.txtFAdministrativo.Width = 1.929134!
            '
            'txtFResponsable
            '
            Me.txtFResponsable.Height = 0.2!
            Me.txtFResponsable.Left = 3.818898!
            Me.txtFResponsable.Name = "txtFResponsable"
            Me.txtFResponsable.Text = "TextBox2"
            Me.txtFResponsable.Top = 2.125984!
            Me.txtFResponsable.Width = 1.968504!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.395833!
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
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNota,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
