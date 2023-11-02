Imports System
Imports DataDynamics.ActiveReports
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptCancelacionNotasVentaManuales
    Inherits DataDynamics.ActiveReports.ActiveReport
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oAlmacen As Almacen
#Region "Variables Miembros"

    Private dsInfo As New DataSet

#End Region
    Public Sub New(ByVal Fecha As Date)
        MyBase.New()
        InitializeComponent()

        Me.txtFecha.Text = Format(Fecha, "dd/MM/yyyy")

        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion
        End If

        CreateDataSet(Fecha)

        ShowInfo(Fecha)

    End Sub
    Private Sub ShowInfo(ByVal Fecha As Date)
        Me.DataSource = dsInfo.Tables(0)

        Me.txtFolioManual.DataField = "FolioVentaManual"
        Me.txtFolioSAP.DataField = "FolioSAP"
        Me.txtTotal.DataField = "Total"
        Me.txtDescSistema.DataField = "DescSistema"
        Me.txtDescAplicado.DataField = "DescAplicado"
        Me.txtUsuario.DataField = "Realizo"
    End Sub
    Private Sub CreateDataSet(ByVal Fecha As Date)
        Dim cnnString As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim cmdGetInfo As SqlCommand
        Dim daGetInfo As SqlDataAdapter

        cmdGetInfo = New SqlCommand
        daGetInfo = New SqlDataAdapter

        With cmdGetInfo
            .Connection = cnnString
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RepVentasManualesSelAll"
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCierre", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3))

        End With

        daGetInfo.SelectCommand = cmdGetInfo
        Try
            With cmdGetInfo
                cnnString.Open()
                .Parameters("@FechaCierre").Value = Format(Fecha, "Short Date")
                .Parameters("@CodAlmacen").Value = oAppContext.ApplicationConfiguration.Almacen
                .Parameters("@CodCaja").Value = oAppContext.ApplicationConfiguration.NoCaja

                'Fill DataSet
                daGetInfo.Fill(dsInfo, "Reporte Ventas Manuales")

                cnnString.Close()
            End With

        Catch oSqlException As SqlException

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (cnnString.State <> ConnectionState.Closed) Then
                Try
                    cnnString.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        cnnString.Dispose()
        cnnString = Nothing
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
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private txtFolioManual As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtDescAplicado As TextBox = Nothing
	Private txtDescSistema As TextBox = Nothing
	Private txtUsuario As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTotalGen As TextBox = Nothing
	Private txtTotalDescAplicado As TextBox = Nothing
	Private txtTotalDescSistema As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCancelacionNotasVentaManuales))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.txtFolioManual = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescAplicado = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescSistema = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.Label()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtTotalGen = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalDescAplicado = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalDescSistema = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioManual,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescAplicado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescSistema,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalGen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalDescAplicado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalDescSistema,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioManual, Me.txtFolioSAP, Me.txtTotal, Me.txtDescAplicado, Me.txtDescSistema, Me.txtUsuario})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0.25!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtFecha, Me.Label3, Me.txtSucursal, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9})
            Me.GroupHeader1.Height = 1.009722!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtTotalGen, Me.txtTotalDescAplicado, Me.txtTotalDescSistema})
            Me.GroupFooter1.Height = 0.34375!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.9375!
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Reporte del dia de Notas de Venta Manuales"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 3!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2.875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.25!
            Me.Label2.Width = 0.5!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1875!
            Me.txtFecha.Left = 3.4375!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "text-align: left; font-size: 8.25pt"
            Me.txtFecha.Text = "Fecha"
            Me.txtFecha.Top = 0.25!
            Me.txtFecha.Width = 1.1875!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.4375!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Sucursal:"
            Me.Label3.Top = 0.4375!
            Me.Label3.Width = 0.625!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.1875!
            Me.txtSucursal.Left = 3.125!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: left; font-size: 8.25pt"
            Me.txtSucursal.Text = "Sucursal"
            Me.txtSucursal.Top = 0.4375!
            Me.txtSucursal.Width = 2.875!
            '
            'Label4
            '
            Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Height = 0.3125!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Folio Nota de Venta Manual"
            Me.Label4.Top = 0.6875!
            Me.Label4.Width = 1.0625!
            '
            'Label5
            '
            Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label5.Height = 0.3125!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 1.0625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "Folio Factura SAP"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 1.1875!
            '
            'Label6
            '
            Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label6.Height = 0.3125!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 2.25!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Total"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 1!
            '
            'Label7
            '
            Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Height = 0.3125!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.25!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Desc. Aplicado"
            Me.Label7.Top = 0.6875!
            Me.Label7.Width = 1.1875!
            '
            'Label8
            '
            Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label8.Height = 0.3125!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.4375!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label8.Text = "Desc. Sistema"
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 1.25!
            '
            'Label9
            '
            Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label9.Height = 0.3125!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 5.6875!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label9.Text = "Realizo"
            Me.Label9.Top = 0.6875!
            Me.Label9.Width = 1.25!
            '
            'txtFolioManual
            '
            Me.txtFolioManual.Height = 0.1875!
            Me.txtFolioManual.Left = 0!
            Me.txtFolioManual.Name = "txtFolioManual"
            Me.txtFolioManual.Style = "text-align: right"
            Me.txtFolioManual.Text = "FolioManual"
            Me.txtFolioManual.Top = 0!
            Me.txtFolioManual.Width = 1.0625!
            '
            'txtFolioSAP
            '
            Me.txtFolioSAP.Height = 0.1875!
            Me.txtFolioSAP.Left = 1.0625!
            Me.txtFolioSAP.Name = "txtFolioSAP"
            Me.txtFolioSAP.Style = "text-align: right"
            Me.txtFolioSAP.Text = "FolioSAP"
            Me.txtFolioSAP.Top = 0!
            Me.txtFolioSAP.Width = 1.1875!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.1875!
            Me.txtTotal.Left = 2.25!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: right"
            Me.txtTotal.Text = "Total"
            Me.txtTotal.Top = 0!
            Me.txtTotal.Width = 1!
            '
            'txtDescAplicado
            '
            Me.txtDescAplicado.Height = 0.1875!
            Me.txtDescAplicado.Left = 3.25!
            Me.txtDescAplicado.Name = "txtDescAplicado"
            Me.txtDescAplicado.OutputFormat = resources.GetString("txtDescAplicado.OutputFormat")
            Me.txtDescAplicado.Style = "text-align: right"
            Me.txtDescAplicado.Text = "Desc.Aplicado"
            Me.txtDescAplicado.Top = 0!
            Me.txtDescAplicado.Width = 1.1875!
            '
            'txtDescSistema
            '
            Me.txtDescSistema.Height = 0.1875!
            Me.txtDescSistema.Left = 4.4375!
            Me.txtDescSistema.Name = "txtDescSistema"
            Me.txtDescSistema.OutputFormat = resources.GetString("txtDescSistema.OutputFormat")
            Me.txtDescSistema.Style = "text-align: right"
            Me.txtDescSistema.Text = "DescSistema"
            Me.txtDescSistema.Top = 0!
            Me.txtDescSistema.Width = 1.25!
            '
            'txtUsuario
            '
            Me.txtUsuario.Height = 0.1875!
            Me.txtUsuario.HyperLink = Nothing
            Me.txtUsuario.Left = 5.6875!
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Style = "text-align: right"
            Me.txtUsuario.Text = "Usuario"
            Me.txtUsuario.Top = 0!
            Me.txtUsuario.Width = 1.25!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.0625!
            Me.Shape2.Width = 6.9375!
            '
            'txtTotalGen
            '
            Me.txtTotalGen.DataField = "Total"
            Me.txtTotalGen.Height = 0.1875!
            Me.txtTotalGen.Left = 2.25!
            Me.txtTotalGen.Name = "txtTotalGen"
            Me.txtTotalGen.OutputFormat = resources.GetString("txtTotalGen.OutputFormat")
            Me.txtTotalGen.Style = "text-align: right"
            Me.txtTotalGen.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTotalGen.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalGen.Text = "TotalGen"
            Me.txtTotalGen.Top = 0.0625!
            Me.txtTotalGen.Width = 1!
            '
            'txtTotalDescAplicado
            '
            Me.txtTotalDescAplicado.DataField = "DescAplicado"
            Me.txtTotalDescAplicado.Height = 0.1875!
            Me.txtTotalDescAplicado.Left = 3.25!
            Me.txtTotalDescAplicado.Name = "txtTotalDescAplicado"
            Me.txtTotalDescAplicado.OutputFormat = resources.GetString("txtTotalDescAplicado.OutputFormat")
            Me.txtTotalDescAplicado.Style = "text-align: right"
            Me.txtTotalDescAplicado.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTotalDescAplicado.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalDescAplicado.Text = "TotalDescApl"
            Me.txtTotalDescAplicado.Top = 0.0625!
            Me.txtTotalDescAplicado.Width = 1.1875!
            '
            'txtTotalDescSistema
            '
            Me.txtTotalDescSistema.DataField = "DescSistema"
            Me.txtTotalDescSistema.Height = 0.1875!
            Me.txtTotalDescSistema.Left = 4.4375!
            Me.txtTotalDescSistema.Name = "txtTotalDescSistema"
            Me.txtTotalDescSistema.OutputFormat = resources.GetString("txtTotalDescSistema.OutputFormat")
            Me.txtTotalDescSistema.Style = "text-align: right"
            Me.txtTotalDescSistema.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTotalDescSistema.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalDescSistema.Text = "TotalDescSistema"
            Me.txtTotalDescSistema.Top = 0.0625!
            Me.txtTotalDescSistema.Width = 1.25!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0.2125!
            Me.PageSettings.Margins.Left = 0.4097222!
            Me.PageSettings.Margins.Right = 0.4097222!
            Me.PageSettings.Margins.Top = 0.1847222!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7!
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
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioManual,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescAplicado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescSistema,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalGen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalDescAplicado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalDescSistema,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
