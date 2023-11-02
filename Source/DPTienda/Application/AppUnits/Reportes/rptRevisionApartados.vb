Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.RevisionApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores



Public Class rptRevisionApartados
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oRevisionApartados As RevisionApartados, ByVal Administrativo As String, ByVal Responsable As String)
        MyBase.New()
        InitializeComponent()

        Me.txtFecha.Text = Now.Date.ToShortDateString
        Me.txtFolio.Text = oRevisionApartados.Folio

        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oAlmacenMgr.Load(oRevisionApartados.Sucursal)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oRevisionApartados.Sucursal

        End If

        Me.txtAdministrativo.Text = UCase(Administrativo)
        Me.txtAdministrativoPie.Text = UCase(Administrativo)

        Me.txtResponsablePie.Text = UCase(Responsable)
        Me.txtResponsable.Text = UCase(Responsable)

        'End If

        Me.lblNotaPie.Text = _
        "LOS CODIGOS ARRIBA MENCIONADOS FUERON CONTADOS POR EL ADMINISTRATIVO DE LA PLAZA: " & Me.txtAdministrativoPie.Text & _
        " EN PRESENCIA DEL RESPONSABLE DE LA SUCURSAL: " & Me.txtResponsablePie.Text & _
        ", OBTENIENDO LOS RESULTADOS DESCRITOS EN ESTE FORMATO, LOS CUALES EL RESPONSABLE DE ESTA SUCURSAL CERTIFICA QUE ESTOS SON CORRECTOS Y QUE ESTA TOTALMENTE DE ACUERDO CON LOS MISMOS."

        Me.DataSource = oRevisionApartados.Detalle
        Me.DataMember = oRevisionApartados.Detalle.Tables(0).TableName

        If oRevisionApartados.Detalle.Tables(0).Rows.Count > 20 Then

            Me.txtTotalCodigosPie.Text = oRevisionApartados.Detalle.Tables(0).Rows.Count

            Me.Label2.Visible = False
            Me.Shape3.Visible = False
            Me.txtTotalCodigos.Visible = False

            Me.Shape4.Visible = True
            Me.Label13.Visible = True
            Me.txtTotalCodigosPie.Visible = True

        Else

            Me.txtTotalCodigos.Text = oRevisionApartados.Detalle.Tables(0).Rows.Count


        End If



    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtResponsable As TextBox = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtAdministrativo As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private txtFaltantes As TextBox = Nothing
	Private txtVencidos As TextBox = Nothing
	Private txtNoRegistrados As TextBox = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Label12 As Label = Nothing
	Private txtTotalCodigos As TextBox = Nothing
	Private Shape4 As Shape = Nothing
	Private txtTotalCodigosPie As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private lblNotaPie As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private txtAdministrativoPie As TextBox = Nothing
	Private txtResponsablePie As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRevisionApartados))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtAdministrativo = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFaltantes = New DataDynamics.ActiveReports.TextBox()
            Me.txtVencidos = New DataDynamics.ActiveReports.TextBox()
            Me.txtNoRegistrados = New DataDynamics.ActiveReports.TextBox()
            Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtTotalCodigos = New DataDynamics.ActiveReports.TextBox()
            Me.Shape4 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotalCodigosPie = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.lblNotaPie = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.txtAdministrativoPie = New DataDynamics.ActiveReports.TextBox()
            Me.txtResponsablePie = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFaltantes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVencidos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoRegistrados,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalCodigos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalCodigosPie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNotaPie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAdministrativoPie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsablePie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodArticulo, Me.txtFaltantes, Me.txtVencidos, Me.txtNoRegistrados, Me.txtObservaciones})
            Me.Detail.Height = 0.1666667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.txtFolio, Me.txtFecha, Me.txtResponsable, Me.txtSucursal, Me.txtAdministrativo})
            Me.PageHeader.Height = 1.03125!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape4, Me.txtTotalCodigosPie, Me.Label13, Me.lblNotaPie, Me.Label14, Me.Label15, Me.txtAdministrativoPie, Me.txtResponsablePie})
            Me.PageFooter.Height = 1.583333!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11})
            Me.GroupHeader1.Height = 0.3222222!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label12, Me.txtTotalCodigos})
            Me.GroupFooter1.Height = 0.3131945!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.023622!
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
            Me.Label1.Left = 1.885335!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "REPORTE DE REVISION DE APARTADOS"
            Me.Label1.Top = 0.03937007!
            Me.Label1.Width = 2.795276!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.1968503!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Folio.:"
            Me.Label2.Top = 0.3937007!
            Me.Label2.Width = 0.433071!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.259842!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Sucursal.:"
            Me.Label3.Top = 0.3937007!
            Me.Label3.Width = 0.6692915!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.72441!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Fecha.:"
            Me.Label4.Top = 0.3937007!
            Me.Label4.Width = 0.5118113!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.1968504!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Administrativo :"
            Me.Label5.Top = 0.5905511!
            Me.Label5.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.1968504!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Responsable Suc.:"
            Me.Label6.Top = 0.7874014!
            Me.Label6.Width = 1.299212!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.6692915!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center"
            Me.txtFolio.Top = 0.3937007!
            Me.txtFolio.Width = 0.4724408!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 5.27559!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0.3937007!
            Me.txtFecha.Width = 1!
            '
            'txtResponsable
            '
            Me.txtResponsable.Height = 0.2!
            Me.txtResponsable.Left = 1.574803!
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Style = "text-align: left"
            Me.txtResponsable.Top = 0.7874014!
            Me.txtResponsable.Width = 2.952756!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 1.968504!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Top = 0.3937007!
            Me.txtSucursal.Width = 2.559056!
            '
            'txtAdministrativo
            '
            Me.txtAdministrativo.Height = 0.2!
            Me.txtAdministrativo.Left = 1.574803!
            Me.txtAdministrativo.Name = "txtAdministrativo"
            Me.txtAdministrativo.Top = 0.5905511!
            Me.txtAdministrativo.Width = 2.952756!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3149606!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 6.496063!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.03937006!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "CODIGOS CON PROBLEMAS"
            Me.Label7.Top = 0.03937007!
            Me.Label7.Width = 1.968504!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.047244!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "FALTANTES"
            Me.Label8.Top = 0.03937007!
            Me.Label8.Width = 0.8661417!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.952756!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "VENCIDOS"
            Me.Label9.Top = 0.03937007!
            Me.Label9.Width = 0.7874014!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.779528!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "NO REGISTRADOS"
            Me.Label10.Top = 0.03937009!
            Me.Label10.Width = 1.299212!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 5.157481!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "OBSERVACIONES"
            Me.Label11.Top = 0.03937009!
            Me.Label11.Width = 1.299212!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.DataField = "CodArticulo"
            Me.txtCodArticulo.Height = 0.2!
            Me.txtCodArticulo.Left = 0!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Style = "text-align: left"
            Me.txtCodArticulo.Top = 0!
            Me.txtCodArticulo.Width = 1.968504!
            '
            'txtFaltantes
            '
            Me.txtFaltantes.DataField = "Faltantes"
            Me.txtFaltantes.Height = 0.2!
            Me.txtFaltantes.Left = 1.968504!
            Me.txtFaltantes.Name = "txtFaltantes"
            Me.txtFaltantes.Style = "text-align: right"
            Me.txtFaltantes.Text = "0"
            Me.txtFaltantes.Top = 0!
            Me.txtFaltantes.Width = 0.8661417!
            '
            'txtVencidos
            '
            Me.txtVencidos.DataField = "Vencidos"
            Me.txtVencidos.Height = 0.2!
            Me.txtVencidos.Left = 2.913386!
            Me.txtVencidos.Name = "txtVencidos"
            Me.txtVencidos.Style = "text-align: right"
            Me.txtVencidos.Text = "0"
            Me.txtVencidos.Top = 0!
            Me.txtVencidos.Width = 0.7874014!
            '
            'txtNoRegistrados
            '
            Me.txtNoRegistrados.DataField = "NoRegistrados"
            Me.txtNoRegistrados.Height = 0.2!
            Me.txtNoRegistrados.Left = 3.897638!
            Me.txtNoRegistrados.Name = "txtNoRegistrados"
            Me.txtNoRegistrados.Style = "text-align: right"
            Me.txtNoRegistrados.Text = "0"
            Me.txtNoRegistrados.Top = 0!
            Me.txtNoRegistrados.Width = 1!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.DataField = "Observaciones"
            Me.txtObservaciones.Height = 0.2!
            Me.txtObservaciones.Left = 5.118111!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Style = "text-align: right"
            Me.txtObservaciones.Text = "0"
            Me.txtObservaciones.Top = 0!
            Me.txtObservaciones.Width = 1.338583!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.3149606!
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
            Me.Label12.Left = 0.07874014!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "TOTAL DE CODIGOS AUDITADOS"
            Me.Label12.Top = 0.07874014!
            Me.Label12.Width = 2.283465!
            '
            'txtTotalCodigos
            '
            Me.txtTotalCodigos.Height = 0.2!
            Me.txtTotalCodigos.Left = 2.716535!
            Me.txtTotalCodigos.Name = "txtTotalCodigos"
            Me.txtTotalCodigos.Text = "TextBox1"
            Me.txtTotalCodigos.Top = 0.07874014!
            Me.txtTotalCodigos.Width = 1!
            '
            'Shape4
            '
            Me.Shape4.Height = 0.3149606!
            Me.Shape4.Left = 0!
            Me.Shape4.Name = "Shape4"
            Me.Shape4.RoundingRadius = 9.999999!
            Me.Shape4.Top = 0!
            Me.Shape4.Visible = false
            Me.Shape4.Width = 6.496063!
            '
            'txtTotalCodigosPie
            '
            Me.txtTotalCodigosPie.Height = 0.2!
            Me.txtTotalCodigosPie.Left = 2.716535!
            Me.txtTotalCodigosPie.Name = "txtTotalCodigosPie"
            Me.txtTotalCodigosPie.Text = "TextBox1"
            Me.txtTotalCodigosPie.Top = 0.07874014!
            Me.txtTotalCodigosPie.Visible = false
            Me.txtTotalCodigosPie.Width = 1!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.07874014!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = ""
            Me.Label13.Text = "TOTAL DE CODIGOS AUDITADOS"
            Me.Label13.Top = 0.07874014!
            Me.Label13.Visible = false
            Me.Label13.Width = 2.283465!
            '
            'lblNotaPie
            '
            Me.lblNotaPie.Height = 0.6299213!
            Me.lblNotaPie.HyperLink = Nothing
            Me.lblNotaPie.Left = 0.1181102!
            Me.lblNotaPie.Name = "lblNotaPie"
            Me.lblNotaPie.Style = "text-align: justify; font-size: 8.25pt"
            Me.lblNotaPie.Text = resources.GetString("lblNotaPie.Text")
            Me.lblNotaPie.Top = 0.4330709!
            Me.lblNotaPie.Width = 6.259843!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 0.1875!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-size: 9pt"
            Me.Label14.Text = "ADMINISTRATIVO DE PLAZA"
            Me.Label14.Top = 1.1875!
            Me.Label14.Width = 2.929!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 3.420768!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "text-align: center; font-size: 9pt"
            Me.Label15.Text = "RESPONSABLE SUCURSAL"
            Me.Label15.Top = 1.181102!
            Me.Label15.Width = 2.929!
            '
            'txtAdministrativoPie
            '
            Me.txtAdministrativoPie.Height = 0.2!
            Me.txtAdministrativoPie.Left = 0.1875!
            Me.txtAdministrativoPie.Name = "txtAdministrativoPie"
            Me.txtAdministrativoPie.Style = "text-align: center; font-size: 9pt"
            Me.txtAdministrativoPie.Text = "TextBox2"
            Me.txtAdministrativoPie.Top = 1.375!
            Me.txtAdministrativoPie.Width = 2.929134!
            '
            'txtResponsablePie
            '
            Me.txtResponsablePie.Height = 0.2!
            Me.txtResponsablePie.Left = 3.420768!
            Me.txtResponsablePie.Name = "txtResponsablePie"
            Me.txtResponsablePie.Style = "text-align: center; font-size: 9pt"
            Me.txtResponsablePie.Text = "TextBox3"
            Me.txtResponsablePie.Top = 1.377953!
            Me.txtResponsablePie.Width = 2.929!
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
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFaltantes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVencidos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoRegistrados,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalCodigos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalCodigosPie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNotaPie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAdministrativoPie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsablePie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
