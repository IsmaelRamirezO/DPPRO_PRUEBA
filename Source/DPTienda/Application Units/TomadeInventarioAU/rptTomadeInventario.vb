Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptTomadeInventario

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oTomaInventarioInfo As TomadeInventarioInfo, _
                    ByVal strSucursalDes As String, _
                    ByVal strAdministrativoDes As String, _
                    ByVal strResponsableDes As String)

        MyBase.New()

        InitializeComponent()

        With oTomaInventarioInfo

            ebSucursal.Text = "Sucursal: " & strSucursalDes
            ebFolio.Text = ":" & .Folio
            ebAdministrativo.Text = ":" & .Administrativo & " " & strAdministrativoDes
            ebResponsable.Text = ":" & .Responsable & " " & strResponsableDes
            ebAuditoria.Text = .Semana
            ebFecha.Text = Format(.FechaAuditoria, "dd/MM/yyyy")
            ebTotalCodigos.Text = .TotalCodigos
            ResName.Text = strResponsableDes
            AdmName.Text = strAdministrativoDes

            ebLeyenda.Text = _
                    "LOS CODIGOS ARRIBA MENCIONADOS FUERON CONTADOS POR EL ADMINISTRATIVO DE LA PLAZA: " & strAdministrativoDes _
                    & " EN PRESENCIA DEL RESPONSABLE DE LA SUCURSAL: " & strResponsableDes & ", OBTENIENDO LOS RESULTADOS DESCRITOS" _
                    & " EN ESTE FORMATO, LOS CUALES EL RESPONSABLE DE ESTA SUCURSAL CERTIFICA QUE ESTOS SON CORRECTOS " _
                    & "Y QUE ESTA TOTALMENTE DE ACUERDO CON LOS MISMOS."

            Me.DataSource = .Detalle
            Me.DataMember = "Detalle"

            ebCodigo.DataField = "Codigo"
            ebTalla.DataField = "Talla"
            ebSistema.DataField = "Sistema"
            ebFisico.DataField = "Fisico"
            ebDiferencia.DataField = "Diferencia"
            ebTipo.DataField = "Tipo"
            ebMovimiento.DataField = "Movimientos"
            ebFolioDetalle.DataField = "FolioDetalle"
            ebObservaciones.DataField = "Observaciones"

        End With

        With Me.PageSettings.Margins
            .Top = 0.5
            .Left = 0.2
        End With


        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private lblFolio As Label = Nothing
	Private lblAdministrativo As Label = Nothing
	Private lblResponsable As Label = Nothing
	Private lblAuditoria As Label = Nothing
	Private ebFolio As Label = Nothing
	Private ebAdministrativo As Label = Nothing
	Private ebResponsable As Label = Nothing
	Private ebAuditoria As Label = Nothing
	Private lblFecha As Label = Nothing
	Private ebFecha As Label = Nothing
	Private ebSucursal As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private ebCodigo As TextBox = Nothing
	Private ebTalla As TextBox = Nothing
	Private ebSistema As TextBox = Nothing
	Private ebFisico As TextBox = Nothing
	Private ebDiferencia As TextBox = Nothing
	Private ebTipo As TextBox = Nothing
	Private ebMovimiento As TextBox = Nothing
	Private ebFolioDetalle As TextBox = Nothing
	Private ebObservaciones As TextBox = Nothing
	Private ResName As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private Label11 As Label = Nothing
	Private ebTotalCodigos As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private ebLeyenda As TextBox = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private AdmName As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTomadeInventario))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblFolio = New DataDynamics.ActiveReports.Label()
            Me.lblAdministrativo = New DataDynamics.ActiveReports.Label()
            Me.lblResponsable = New DataDynamics.ActiveReports.Label()
            Me.lblAuditoria = New DataDynamics.ActiveReports.Label()
            Me.ebFolio = New DataDynamics.ActiveReports.Label()
            Me.ebAdministrativo = New DataDynamics.ActiveReports.Label()
            Me.ebResponsable = New DataDynamics.ActiveReports.Label()
            Me.ebAuditoria = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.ebFecha = New DataDynamics.ActiveReports.Label()
            Me.ebSucursal = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.ebCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.ebTalla = New DataDynamics.ActiveReports.TextBox()
            Me.ebSistema = New DataDynamics.ActiveReports.TextBox()
            Me.ebFisico = New DataDynamics.ActiveReports.TextBox()
            Me.ebDiferencia = New DataDynamics.ActiveReports.TextBox()
            Me.ebTipo = New DataDynamics.ActiveReports.TextBox()
            Me.ebMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.ebFolioDetalle = New DataDynamics.ActiveReports.TextBox()
            Me.ebObservaciones = New DataDynamics.ActiveReports.TextBox()
            Me.ResName = New DataDynamics.ActiveReports.Label()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.ebTotalCodigos = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.ebLeyenda = New DataDynamics.ActiveReports.TextBox()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.AdmName = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAuditoria,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebAdministrativo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebAuditoria,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebSistema,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebFisico,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebDiferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebTipo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebFolioDetalle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebObservaciones,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ResName,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebTotalCodigos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.ebLeyenda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.AdmName,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ebCodigo, Me.ebTalla, Me.ebSistema, Me.ebFisico, Me.ebDiferencia, Me.ebTipo, Me.ebMovimiento, Me.ebFolioDetalle, Me.ebObservaciones})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.lblFolio, Me.lblAdministrativo, Me.lblResponsable, Me.lblAuditoria, Me.ebFolio, Me.ebAdministrativo, Me.ebResponsable, Me.ebAuditoria, Me.lblFecha, Me.ebFecha, Me.ebSucursal, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9})
            Me.PageHeader.Height = 1.603472!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ResName, Me.Shape2, Me.Label11, Me.ebTotalCodigos, Me.Label12, Me.Label13, Me.ebLeyenda, Me.Line10, Me.Line11, Me.AdmName})
            Me.GroupFooter1.Height = 1.665972!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.25!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 1.345!
            Me.Shape1.Width = 7.5625!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "color: Black; text-align: center"
            Me.Label1.Text = "REPORTE DE TOMA DE INVENTARIO"
            Me.Label1.Top = 0!
            Me.Label1.Width = 7.4375!
            '
            'lblFolio
            '
            Me.lblFolio.Height = 0.2!
            Me.lblFolio.HyperLink = Nothing
            Me.lblFolio.Left = 0.0625!
            Me.lblFolio.Name = "lblFolio"
            Me.lblFolio.Style = "color: Black"
            Me.lblFolio.Text = "Folio"
            Me.lblFolio.Top = 0.5!
            Me.lblFolio.Width = 1.1875!
            '
            'lblAdministrativo
            '
            Me.lblAdministrativo.Height = 0.2!
            Me.lblAdministrativo.HyperLink = Nothing
            Me.lblAdministrativo.Left = 0.0625!
            Me.lblAdministrativo.Name = "lblAdministrativo"
            Me.lblAdministrativo.Style = "color: Black"
            Me.lblAdministrativo.Text = "Administrativo"
            Me.lblAdministrativo.Top = 0.6875!
            Me.lblAdministrativo.Width = 1.1875!
            '
            'lblResponsable
            '
            Me.lblResponsable.Height = 0.2!
            Me.lblResponsable.HyperLink = Nothing
            Me.lblResponsable.Left = 0.0625!
            Me.lblResponsable.Name = "lblResponsable"
            Me.lblResponsable.Style = "color: Black"
            Me.lblResponsable.Text = "Responsable Suc."
            Me.lblResponsable.Top = 0.875!
            Me.lblResponsable.Width = 1.1875!
            '
            'lblAuditoria
            '
            Me.lblAuditoria.Height = 0.2!
            Me.lblAuditoria.HyperLink = Nothing
            Me.lblAuditoria.Left = 0.0625!
            Me.lblAuditoria.Name = "lblAuditoria"
            Me.lblAuditoria.Style = "color: Black"
            Me.lblAuditoria.Text = "Auditoría de la Semana :"
            Me.lblAuditoria.Top = 1.0625!
            Me.lblAuditoria.Width = 1.5625!
            '
            'ebFolio
            '
            Me.ebFolio.Height = 0.2!
            Me.ebFolio.HyperLink = Nothing
            Me.ebFolio.Left = 1.3125!
            Me.ebFolio.Name = "ebFolio"
            Me.ebFolio.Style = "color: Black"
            Me.ebFolio.Text = ""
            Me.ebFolio.Top = 0.5!
            Me.ebFolio.Width = 0.6875!
            '
            'ebAdministrativo
            '
            Me.ebAdministrativo.Height = 0.2!
            Me.ebAdministrativo.HyperLink = Nothing
            Me.ebAdministrativo.Left = 1.3125!
            Me.ebAdministrativo.Name = "ebAdministrativo"
            Me.ebAdministrativo.Style = "color: Black"
            Me.ebAdministrativo.Text = ""
            Me.ebAdministrativo.Top = 0.6875!
            Me.ebAdministrativo.Width = 3.6875!
            '
            'ebResponsable
            '
            Me.ebResponsable.Height = 0.2!
            Me.ebResponsable.HyperLink = Nothing
            Me.ebResponsable.Left = 1.3125!
            Me.ebResponsable.Name = "ebResponsable"
            Me.ebResponsable.Style = "color: Black"
            Me.ebResponsable.Text = ""
            Me.ebResponsable.Top = 0.875!
            Me.ebResponsable.Width = 3.6875!
            '
            'ebAuditoria
            '
            Me.ebAuditoria.Height = 0.2!
            Me.ebAuditoria.HyperLink = Nothing
            Me.ebAuditoria.Left = 1.6875!
            Me.ebAuditoria.Name = "ebAuditoria"
            Me.ebAuditoria.Style = "color: Black"
            Me.ebAuditoria.Text = ""
            Me.ebAuditoria.Top = 1.0625!
            Me.ebAuditoria.Width = 5.0625!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 5.5625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "color: Black"
            Me.lblFecha.Text = "Fecha :"
            Me.lblFecha.Top = 0.5!
            Me.lblFecha.Width = 0.5!
            '
            'ebFecha
            '
            Me.ebFecha.Height = 0.2!
            Me.ebFecha.HyperLink = Nothing
            Me.ebFecha.Left = 6.125!
            Me.ebFecha.Name = "ebFecha"
            Me.ebFecha.Style = "color: Black"
            Me.ebFecha.Text = ""
            Me.ebFecha.Top = 0.5!
            Me.ebFecha.Width = 1.3125!
            '
            'ebSucursal
            '
            Me.ebSucursal.Height = 0.2!
            Me.ebSucursal.HyperLink = Nothing
            Me.ebSucursal.Left = 0.0625!
            Me.ebSucursal.Name = "ebSucursal"
            Me.ebSucursal.Style = "color: Black; text-align: center"
            Me.ebSucursal.Text = "Sucursal :"
            Me.ebSucursal.Top = 0.25!
            Me.ebSucursal.Width = 7.4375!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8pt"
            Me.Label2.Text = "CODIGO"
            Me.Label2.Top = 1.375!
            Me.Label2.Width = 1.1875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.25!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8pt"
            Me.Label3.Text = "TALLA"
            Me.Label3.Top = 1.375!
            Me.Label3.Width = 0.501!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.8!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 8pt"
            Me.Label4.Text = "SISTEMA"
            Me.Label4.Top = 1.375!
            Me.Label4.Width = 0.563!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.4375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 8pt"
            Me.Label5.Text = "FISICO"
            Me.Label5.Top = 1.375!
            Me.Label5.Width = 0.4385!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 8pt"
            Me.Label6.Text = "DIFER."
            Me.Label6.Top = 1.375!
            Me.Label6.Width = 0.501!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-size: 8pt"
            Me.Label7.Text = "TIPO"
            Me.Label7.Top = 1.375!
            Me.Label7.Width = 0.626!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.25!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8pt"
            Me.Label8.Text = "MOVIMIENTO"
            Me.Label8.Top = 1.375!
            Me.Label8.Width = 1.375!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 5.625!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 8pt"
            Me.Label9.Text = "FOLIO"
            Me.Label9.Top = 1.375!
            Me.Label9.Width = 0.5625!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 6.1875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 8pt"
            Me.Label10.Text = "OBSERVACIONES"
            Me.Label10.Top = 1.375!
            Me.Label10.Width = 1.3125!
            '
            'Line1
            '
            Me.Line1.Height = 0.25!
            Me.Line1.Left = 5.631945!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1.35!
            Me.Line1.Width = 0!
            Me.Line1.X1 = 5.631945!
            Me.Line1.X2 = 5.631945!
            Me.Line1.Y1 = 1.35!
            Me.Line1.Y2 = 1.6!
            '
            'Line2
            '
            Me.Line2.Height = 0.25!
            Me.Line2.Left = 1.256944!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.35!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 1.256944!
            Me.Line2.X2 = 1.256944!
            Me.Line2.Y1 = 1.35!
            Me.Line2.Y2 = 1.6!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 5.631945!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.35!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 5.631945!
            Me.Line3.X2 = 5.631945!
            Me.Line3.Y1 = 1.35!
            Me.Line3.Y2 = 1.6!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 4.256945!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.35!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 4.256945!
            Me.Line4.X2 = 4.256945!
            Me.Line4.Y1 = 1.35!
            Me.Line4.Y2 = 1.6!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 3.58!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 1.35!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 3.58!
            Me.Line5.X2 = 3.58!
            Me.Line5.Y1 = 1.35!
            Me.Line5.Y2 = 1.6!
            '
            'Line6
            '
            Me.Line6.Height = 0.25!
            Me.Line6.Left = 2.95!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 1.35!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 2.95!
            Me.Line6.X2 = 2.95!
            Me.Line6.Y1 = 1.35!
            Me.Line6.Y2 = 1.6!
            '
            'Line7
            '
            Me.Line7.Height = 0.25!
            Me.Line7.Left = 2.35!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 1.35!
            Me.Line7.Width = 0!
            Me.Line7.X1 = 2.35!
            Me.Line7.X2 = 2.35!
            Me.Line7.Y1 = 1.35!
            Me.Line7.Y2 = 1.6!
            '
            'Line8
            '
            Me.Line8.Height = 0.25!
            Me.Line8.Left = 1.756944!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 1.35!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 1.756944!
            Me.Line8.X2 = 1.756944!
            Me.Line8.Y1 = 1.35!
            Me.Line8.Y2 = 1.6!
            '
            'Line9
            '
            Me.Line9.Height = 0.25!
            Me.Line9.Left = 6.194445!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 1.35!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 6.194445!
            Me.Line9.X2 = 6.194445!
            Me.Line9.Y1 = 1.35!
            Me.Line9.Y2 = 1.6!
            '
            'ebCodigo
            '
            Me.ebCodigo.Height = 0.2!
            Me.ebCodigo.Left = 0!
            Me.ebCodigo.Name = "ebCodigo"
            Me.ebCodigo.Style = "color: Black; font-size: 9pt"
            Me.ebCodigo.Top = 0!
            Me.ebCodigo.Width = 1.4375!
            '
            'ebTalla
            '
            Me.ebTalla.Height = 0.2!
            Me.ebTalla.Left = 1.4375!
            Me.ebTalla.Name = "ebTalla"
            Me.ebTalla.Style = "color: Black; text-align: right; font-size: 9pt"
            Me.ebTalla.Top = 0!
            Me.ebTalla.Width = 0.375!
            '
            'ebSistema
            '
            Me.ebSistema.Height = 0.2!
            Me.ebSistema.Left = 1.8125!
            Me.ebSistema.Name = "ebSistema"
            Me.ebSistema.Style = "color: Black; text-align: right; font-size: 9pt"
            Me.ebSistema.Top = 0!
            Me.ebSistema.Width = 0.5!
            '
            'ebFisico
            '
            Me.ebFisico.Height = 0.2!
            Me.ebFisico.Left = 2.375!
            Me.ebFisico.Name = "ebFisico"
            Me.ebFisico.Style = "color: Black; text-align: right; font-size: 9pt"
            Me.ebFisico.Top = 0!
            Me.ebFisico.Width = 0.5625!
            '
            'ebDiferencia
            '
            Me.ebDiferencia.Height = 0.2!
            Me.ebDiferencia.Left = 3!
            Me.ebDiferencia.Name = "ebDiferencia"
            Me.ebDiferencia.Style = "color: Black; text-align: right; font-size: 9pt"
            Me.ebDiferencia.Top = 0!
            Me.ebDiferencia.Width = 0.5625!
            '
            'ebTipo
            '
            Me.ebTipo.Height = 0.2!
            Me.ebTipo.Left = 3.625!
            Me.ebTipo.Name = "ebTipo"
            Me.ebTipo.Style = "color: Black; text-align: left; font-size: 9pt"
            Me.ebTipo.Top = 0!
            Me.ebTipo.Width = 0.6875!
            '
            'ebMovimiento
            '
            Me.ebMovimiento.Height = 0.2!
            Me.ebMovimiento.Left = 4.3125!
            Me.ebMovimiento.Name = "ebMovimiento"
            Me.ebMovimiento.Style = "color: Black; text-align: left; font-size: 9pt"
            Me.ebMovimiento.Top = 0!
            Me.ebMovimiento.Width = 1.3125!
            '
            'ebFolioDetalle
            '
            Me.ebFolioDetalle.Height = 0.2!
            Me.ebFolioDetalle.Left = 5.625!
            Me.ebFolioDetalle.Name = "ebFolioDetalle"
            Me.ebFolioDetalle.Style = "color: Black; text-align: right; font-size: 9pt"
            Me.ebFolioDetalle.Top = 0!
            Me.ebFolioDetalle.Width = 0.5625!
            '
            'ebObservaciones
            '
            Me.ebObservaciones.Height = 0.2!
            Me.ebObservaciones.Left = 6.1875!
            Me.ebObservaciones.Name = "ebObservaciones"
            Me.ebObservaciones.Style = "color: Black; text-align: left; font-size: 9pt"
            Me.ebObservaciones.Top = 0!
            Me.ebObservaciones.Width = 1.375!
            '
            'ResName
            '
            Me.ResName.Height = 0.2!
            Me.ResName.HyperLink = Nothing
            Me.ResName.Left = 3.9375!
            Me.ResName.Name = "ResName"
            Me.ResName.Style = "color: Black; text-align: center; font-size: 9pt"
            Me.ResName.Text = ""
            Me.ResName.Top = 1.3125!
            Me.ResName.Width = 2.625!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.03250003!
            Me.Shape2.Width = 7.5625!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.0625!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black"
            Me.Label11.Text = "Total de Códigos Auditados :"
            Me.Label11.Top = 0.0625!
            Me.Label11.Width = 1.875!
            '
            'ebTotalCodigos
            '
            Me.ebTotalCodigos.Height = 0.2!
            Me.ebTotalCodigos.HyperLink = Nothing
            Me.ebTotalCodigos.Left = 2!
            Me.ebTotalCodigos.Name = "ebTotalCodigos"
            Me.ebTotalCodigos.Style = "color: Black"
            Me.ebTotalCodigos.Text = "Label12"
            Me.ebTotalCodigos.Top = 0.0625!
            Me.ebTotalCodigos.Width = 0.6875!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.6875!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: Black; text-align: center; font-size: 8.25pt"
            Me.Label12.Text = "Administrativo de Plaza"
            Me.Label12.Top = 1.5!
            Me.Label12.Width = 2.625!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 3.9375!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "color: Black; text-align: center; font-size: 8pt"
            Me.Label13.Text = "Responsable Sucursal"
            Me.Label13.Top = 1.5!
            Me.Label13.Width = 2.625!
            '
            'ebLeyenda
            '
            Me.ebLeyenda.Height = 0.5625!
            Me.ebLeyenda.Left = 0.0625!
            Me.ebLeyenda.Name = "ebLeyenda"
            Me.ebLeyenda.Style = "color: Black; text-align: justify; font-size: 8pt"
            Me.ebLeyenda.Top = 0.3125!
            Me.ebLeyenda.Width = 7.4375!
            '
            'Line10
            '
            Me.Line10.Height = 0!
            Me.Line10.Left = 4.25!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 1.3125!
            Me.Line10.Width = 2.0625!
            Me.Line10.X1 = 6.3125!
            Me.Line10.X2 = 4.25!
            Me.Line10.Y1 = 1.3125!
            Me.Line10.Y2 = 1.3125!
            '
            'Line11
            '
            Me.Line11.Height = 0!
            Me.Line11.Left = 0.9444444!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 1.319444!
            Me.Line11.Width = 2.0625!
            Me.Line11.X1 = 3.006944!
            Me.Line11.X2 = 0.9444444!
            Me.Line11.Y1 = 1.319444!
            Me.Line11.Y2 = 1.319444!
            '
            'AdmName
            '
            Me.AdmName.Height = 0.2!
            Me.AdmName.HyperLink = Nothing
            Me.AdmName.Left = 0.6875!
            Me.AdmName.Name = "AdmName"
            Me.AdmName.Style = "color: Black; text-align: center; font-size: 9pt"
            Me.AdmName.Text = ""
            Me.AdmName.Top = 1.3125!
            Me.AdmName.Width = 2.625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.583333!
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
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAuditoria,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebAdministrativo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebAuditoria,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebSistema,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebFisico,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebDiferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebTipo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebFolioDetalle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebObservaciones,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ResName,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebTotalCodigos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.ebLeyenda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.AdmName,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
