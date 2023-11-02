Imports System
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class CierreDiaCancelacionApartados
Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape2 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label11 As Label = Nothing
	Private LblFechaDE As Label = Nothing
	Private Label12 As Label = Nothing
	Private LblFechaAL As Label = Nothing
	Private Label13 As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private tbFolioApartado As TextBox = Nothing
	Private tbFolioAbono As TextBox = Nothing
	Private tbAbono As TextBox = Nothing
	Private tbUsuario As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private Shape1 As Shape = Nothing
	Private tbTotalAbono As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CierreDiaCancelacionApartados))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.tbFolioApartado = New DataDynamics.ActiveReports.TextBox()
            Me.tbFolioAbono = New DataDynamics.ActiveReports.TextBox()
            Me.tbAbono = New DataDynamics.ActiveReports.TextBox()
            Me.tbUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.tbTotalAbono = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolioApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolioAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolioApartado, Me.tbFolioAbono, Me.tbAbono, Me.tbUsuario, Me.tbFecha})
            Me.Detail.Height = 0.15625!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.tbTotalAbono})
            Me.ReportFooter.Height = 0.2909722!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label7, Me.Label8, Me.Line1, Me.Label11, Me.LblFechaDE, Me.Label12, Me.LblFechaAL, Me.Label13, Me.LblSucursal, Me.lblFecha})
            Me.GroupHeader1.Height = 0.84375!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape2
            '
            Me.Shape2.Height = 0.8125!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 5.6875!
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8pt; font-family: Arial"
            Me.Label1.Text = "Reporte de Cancelación Apartados"
            Me.Label1.Top = 0!
            Me.Label1.Width = 2.0625!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Fecha :"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.5!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label3.Text = "Folio Apartado"
            Me.Label3.Top = 0.625!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Folio Abono"
            Me.Label4.Top = 0.625!
            Me.Label4.Width = 1!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.1875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label5.Text = "Abono"
            Me.Label5.Top = 0.625!
            Me.Label5.Width = 1.1875!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.4375!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label7.Text = "Usuario"
            Me.Label7.Top = 0.625!
            Me.Label7.Width = 1.0625!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.5625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label8.Text = "Fecha"
            Me.Label8.Top = 0.625!
            Me.Label8.Width = 1.0625!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.5625!
            Me.Line1.Width = 5.6875!
            Me.Line1.X1 = 0!
            Me.Line1.X2 = 5.6875!
            Me.Line1.Y1 = 0.5625!
            Me.Line1.Y2 = 0.5625!
            '
            'Label11
            '
            Me.Label11.Height = 0.1811025!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 1.75!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label11.Text = "De:"
            Me.Label11.Top = 0.1875!
            Me.Label11.Width = 0.2810042!
            '
            'LblFechaDE
            '
            Me.LblFechaDE.Height = 0.1811025!
            Me.LblFechaDE.HyperLink = Nothing
            Me.LblFechaDE.Left = 2.0625!
            Me.LblFechaDE.Name = "LblFechaDE"
            Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaDE.Text = "LblFechaDE"
            Me.LblFechaDE.Top = 0.1875!
            Me.LblFechaDE.Width = 0.9685042!
            '
            'Label12
            '
            Me.Label12.Height = 0.1811025!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 3.0625!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label12.Text = "Al:"
            Me.Label12.Top = 0.1875!
            Me.Label12.Width = 0.2810042!
            '
            'LblFechaAL
            '
            Me.LblFechaAL.Height = 0.1811025!
            Me.LblFechaAL.HyperLink = Nothing
            Me.LblFechaAL.Left = 3.3125!
            Me.LblFechaAL.Name = "LblFechaAL"
            Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFechaAL.Text = "LblFechaAL"
            Me.LblFechaAL.Top = 0.1875!
            Me.LblFechaAL.Width = 0.9685042!
            '
            'Label13
            '
            Me.Label13.Height = 0.1811025!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.9375!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label13.Text = "Sucursal:"
            Me.Label13.Top = 0.375!
            Me.Label13.Width = 0.5625!
            '
            'LblSucursal
            '
            Me.LblSucursal.Height = 0.1811025!
            Me.LblSucursal.HyperLink = Nothing
            Me.LblSucursal.Left = 1.625001!
            Me.LblSucursal.Name = "LblSucursal"
            Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblSucursal.Text = "LblSucursal"
            Me.LblSucursal.Top = 0.375!
            Me.LblSucursal.Width = 3.448326!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.5625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 8.25pt"
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0!
            Me.lblFecha.Width = 0.875!
            '
            'tbFolioApartado
            '
            Me.tbFolioApartado.Height = 0.1875!
            Me.tbFolioApartado.Left = 0.1041667!
            Me.tbFolioApartado.Name = "tbFolioApartado"
            Me.tbFolioApartado.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFolioApartado.Top = 0!
            Me.tbFolioApartado.Width = 0.9583333!
            '
            'tbFolioAbono
            '
            Me.tbFolioAbono.Height = 0.1875!
            Me.tbFolioAbono.Left = 1.125!
            Me.tbFolioAbono.Name = "tbFolioAbono"
            Me.tbFolioAbono.OutputFormat = resources.GetString("tbFolioAbono.OutputFormat")
            Me.tbFolioAbono.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFolioAbono.Top = 0!
            Me.tbFolioAbono.Width = 1!
            '
            'tbAbono
            '
            Me.tbAbono.Height = 0.1875!
            Me.tbAbono.Left = 2.1875!
            Me.tbAbono.Name = "tbAbono"
            Me.tbAbono.OutputFormat = resources.GetString("tbAbono.OutputFormat")
            Me.tbAbono.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbAbono.Top = 0!
            Me.tbAbono.Width = 1.1875!
            '
            'tbUsuario
            '
            Me.tbUsuario.Height = 0.1875!
            Me.tbUsuario.Left = 3.4375!
            Me.tbUsuario.Name = "tbUsuario"
            Me.tbUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbUsuario.Top = 0!
            Me.tbUsuario.Width = 1.0625!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 4.5625!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.OutputFormat = resources.GetString("tbFecha.OutputFormat")
            Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFecha.Top = 0!
            Me.tbFecha.Width = 1.0625!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.25!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 5.6875!
            '
            'tbTotalAbono
            '
            Me.tbTotalAbono.Height = 0.1875!
            Me.tbTotalAbono.Left = 2.1875!
            Me.tbTotalAbono.Name = "tbTotalAbono"
            Me.tbTotalAbono.OutputFormat = resources.GetString("tbTotalAbono.OutputFormat")
            Me.tbTotalAbono.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotalAbono.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
            Me.tbTotalAbono.Top = 0!
            Me.tbTotalAbono.Width = 1.1875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.9840278!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.708333!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.ReportFooter)
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
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaDE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFechaAL,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolioApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolioAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

#Region "Constructores"

    Public Sub New(ByVal datFechaCierre As Date, ByVal strSucursal As String)

        MyBase.New()
        InitializeComponent()

        lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        LblFechaDE.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblFechaAL.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblSucursal.Text = strSucursal

        Sm_CreatDataSet(datFechaCierre)

        Sm_MostrarInformacion(datFechaCierre)

    End Sub

#End Region

#Region "Variables Miembros"

    Private dsApartados As New DataSet

#End Region

#Region "Métodos Miembros"

    Private Sub Sm_CreatDataSet(ByVal datFechaCierre As Date)

        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdDataSet As SqlCommand
        Dim scdaDataSet As SqlDataAdapter


        sccmdDataSet = New SqlCommand
        scdaDataSet = New SqlDataAdapter


        With sccmdDataSet

            .Connection = sccnnConnection

            .CommandText = "[CierreDiaReporteCancelacionApartados]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))


        End With

        scdaDataSet.SelectCommand = sccmdDataSet

        Try
            With sccmdDataSet

                sccnnConnection.Open()

                .Parameters("@Fecha").Value = Format(datFechaCierre, "Short Date")

                'Fill DataSet
                scdaDataSet.Fill(dsApartados, "Apartados")

                sccnnConnection.Close()

            End With


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub



    Private Sub Sm_MostrarInformacion(ByVal datFechaCierre As Date)

        Me.DataSource = dsApartados.Tables(0)

        Me.tbFolioApartado.DataField = "FolioApartado"
        Me.tbFolioAbono.DataField = "FolioAbono"
        Me.tbAbono.DataField = "Abono"
        Me.tbUsuario.DataField = "Usuario"
        Me.tbFecha.DataField = "Fecha"

        Me.tbTotalAbono.DataField = "Abono"

    End Sub

#End Region

End Class
