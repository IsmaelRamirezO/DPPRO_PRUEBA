Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic

Public Class rptPagueTiendaEcommerceDPVale
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private lstVales As List(Of String)
    Private lstClientes As List(Of String)
    Public Sub New(ByVal Fecha As DateTime)
        MyBase.New()
        InitializeComponent()

        'Dim owsValidaDPVale As wsControlDPVales.ControlDPVales
        Dim oFacturasMgr As New FacturaManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dsVentasPTVenta As New DataSet
        Dim dsVentasCredito As New DataSet
        Dim IFactura As Decimal
        Dim IPagoDPVale As Decimal
        Dim oClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim oCliente As ClienteAlterno
        oCliente = oClienteMgr.CreateAlterno()
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros())
        lstVales = New List(Of String)
        lstClientes = New List(Of String)
        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & Space(1) & oAlmacen.Descripcion

        End If

        Me.txtFecha.Text = Format(Fecha, "dd/MM/yyyy")

        dsVentasPTVenta = oFacturasMgr.VtasCompreLineaPagueTiendaDia(Fecha.Date.ToShortDateString).Copy
        '-----------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 20.11.2014: Juntamos la info de vales usados tanto en facturas como en pedidos SH para mostrarla en el reporte
        '-----------------------------------------------------------------------------------------------------------------------------------
        'UnirInfo(dsVentasPTVenta)

        Dim FoliosVale As String

        For Each oRow As DataRow In dsVentasPTVenta.Tables("VentasDPVale").Rows
            FoliosVale &= oRow("NDPV") & ","
        Next

        If FoliosVale <> Nothing Then

            FoliosVale = FoliosVale.TrimEnd(",")

            If Not oAppSAPConfig.DPValeSAP Then



                'owsValidaDPVale = New wsControlDPVales.ControlDPVales

                If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

                    'owsValidaDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
                    '            owsValidaDPVale.strURL.TrimStart("/")
                End If

                'dsVentasCredito = owsValidaDPVale.VentasDPValeDelDia(FoliosVale).Copy

                For Each oRow As DataRow In dsVentasPTVenta.Tables("VentasDPVale").Rows

                    Dim dvDatosSocio As New DataView(dsVentasCredito.Tables(0), "DPValeID=" & oRow("NDPV"), "DPValeID", DataViewRowState.CurrentRows)

                    If dvDatosSocio.Count > 0 Then

                        oRow("Cliente") = dvDatosSocio(0)("ClienteAsociado") 'Asociado.
                        oRow("Asociado") = dvDatosSocio(0)("AsociadoID") 'Distribuidor
                        oRow("IVale") = dvDatosSocio(0)("MontoDPValeI") 'Importe Expedicion DPVale (Monto)
                        oRow("PPV") = dvDatosSocio(0)("MontoDPValeP") 'Importe Expedicion DPVale (Par/Pzas.)
                        oRow("Status") = CStr(oRow("Status")).Substring(0, 1)

                        Dim dvDatosRevale As New DataView(dsVentasCredito.Tables(0), "DPValeOrigen=" & oRow("NDPV") & " and FacturaOrigenID=" & oRow("FacturaID"), "DPValeID", DataViewRowState.CurrentRows)

                        If dvDatosRevale.Count > 0 Then 'Se generó Revale

                            oRow("FRevale") = dvDatosRevale(0)("DPValeID")
                            oRow("IRevale") = dvDatosRevale(0)("MontoDPValeI")
                            oRow("PPR") = dvDatosRevale(0)("MontoDPValeP")

                        Else 'No se generó revale


                            If CDec(oRow("IVale")) > 0 Then 'Venta con Importe

                                If CDec(orow("PDPV")) < CDec(oRow("IVale")) Then 'Diferencia
                                    oRow("FRevale") = "S/C"
                                    oRow("IRevale") = 0
                                    oRow("PPR") = 0
                                Else
                                    oRow("FRevale") = "No"
                                    oRow("IRevale") = 0
                                    oRow("PPR") = 0
                                End If

                            Else 'Venta con Pares Pzas.

                                If CDec(oRow("PPF")) < CDec(oRow("PPV")) Then 'Diferencia
                                    oRow("FRevale") = "S/C"
                                    oRow("IRevale") = 0
                                    oRow("PPR") = 0
                                Else
                                    oRow("FRevale") = "No"
                                    oRow("IRevale") = 0
                                    oRow("PPR") = 0
                                End If

                            End If

                        End If
                    End If
                Next

            Else 'DPVale SAP
                'FoliosVale
                For Each oRow As DataRow In dsVentasPTVenta.Tables("VentasDPVale").Rows
                    'Consultaremos el Vale Utilizado.
                    Dim oDPVale As New cDPVale


                    oDPVale.INUMVA = CStr(oRow("NDPV")).PadLeft(10, "0")
                    oDPVale.I_RUTA = "X"

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                    '----------------------------------------------------------------------------------------
                    Dim oS2Credit As New ProcesosS2Credit
                    'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (18.07.2016): Valida DPVale
                    '----------------------------------------------------------------------------------------
                    Dim FirmaDistribuidor As Image = Nothing
                    Dim NombreDistribuidor As String = String.Empty
                    If oConfigCierreFI.AplicarS2Credit Then
                        oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If
                    '----------------------------------------------------------------------------------------

                    If oDPVale.EEXIST = "S" Then
                        Dim oRowSAP As DataRow
                        oRowSAP = oDPVale.InfoDPVALE.Rows(0)
                        'oRow("Cliente") = oRowSAP("CODCT")  'Asociado.
                        If Not oRowSAP("CODCT") Is Nothing Then
                            If CStr(oRowSAP("CODCT")).Trim() <> "" Then
                                GetClienteDPVale(oRowSAP("CODCT"))
                                oCliente.Clear()
                                oClienteMgr.Load(CStr(oRowSAP("CODCT")), oCliente)

                                oRow("Cliente") = Left(oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno, 36)
                                oRow("Asociado") = CStr(oRowSAP("KUNNR")).TrimStart("0") 'Distribuidor

                                If oRow("PPV") > 0 Then
                                    oRow("IVale") = 0  'Importe Expedicion DPVale (Monto)
                                    oRow("PPV") = oRowSAP("PARES")  'Importe Expedicion DPVale (Par/Pzas.)
                                Else
                                    oRow("IVale") = oRowSAP("MONTO")  'Importe Expedicion DPVale (Monto)
                                    oRow("PPV") = 0  'Importe Expedicion DPVale (Par/Pzas.)
                                End If

                                oRow("Status") = CStr(oRow("Status")).Substring(0, 1)

                                ''Checar si se Generó ReVale.
                                'Dim oReVale As New cDPVale
                                'oReVale.INUMVA = CStr(oRow("NDPV")).PadLeft(10, "0")
                                'oReVale = oSAPMgr.ZBAPI_VALIDA_REVALE_Venta(oReVale)
                                If CStr(oDPVale.InfoDPVALE.Rows(0)!REVAL).Trim() = "X" Then
                                    oRow("FRevale") = oDPVale.InfoDPVALE.Rows(0)!ORIGE
                                    oRow("IRevale") = oDPVale.InfoDPVALE.Rows(0)!Monto
                                    oRow("PPR") = oDPVale.InfoDPVALE.Rows(0)!Pares
                                    If oRow("PPR") > 0 Then
                                        oRow("IVale") = 0
                                        oRow("PPV") = oRow("PPV") + oDPVale.InfoDPVALE.Rows(0)!Pares
                                    Else
                                        oRow("IVale") = oRow("IVale") + oDPVale.InfoDPVALE.Rows(0)!Monto
                                        oRow("PPV") = 0
                                    End If
                                Else
                                    ''Cuando No hay ReVale
                                    If CDec(oRow("IVale")) > 0 Then 'Venta con Importe

                                        If CDec(oRow("PDPV")) < CDec(oRow("IVale")) Then 'Diferencia
                                            oRow("FRevale") = "S/C"
                                            oRow("IRevale") = 0
                                            oRow("PPR") = 0
                                        Else
                                            oRow("FRevale") = "No"
                                            oRow("IRevale") = 0
                                            oRow("PPR") = 0
                                        End If

                                    Else 'Venta con Pares Pzas.

                                        If CDec(oRow("PPF")) < CDec(oRow("PPV")) Then 'Diferencia
                                            oRow("FRevale") = "S/C"
                                            oRow("IRevale") = 0
                                            oRow("PPR") = 0
                                        Else
                                            oRow("FRevale") = "No"
                                            oRow("IRevale") = 0
                                            oRow("PPR") = 0
                                        End If
                                    End If
                                End If
                            Else
                                lstVales.Add("Vale: " & CStr(oRow("NDPV")).PadLeft(10, "0"))
                            End If
                        Else
                            lstClientes.Add("El cliente del vale: " & CStr(oRow("NDPV")).PadLeft(10, "0") & " esta vacio")
                        End If
                    Else
                        lstVales.Add("Vale: " & CStr(oRow("NDPV")).PadLeft(10, "0"))
                    End If
                Next

            End If
            Me.DataSource = dsVentasPTVenta
            Me.DataMember = "VentasDPVale"

        End If

    End Sub

    Private Sub UnirInfo(ByRef dsOrigen As DataSet)

        Dim dtTemp1 As DataTable = dsOrigen.Tables(0)
        Dim dtTemp2 As DataTable = dsOrigen.Tables(1)
        Dim dtTemp3 As DataTable = dsOrigen.Tables(2)
        Dim oRow As DataRow

        For Each oRow In dtTemp2.Rows
            dtTemp1.ImportRow(oRow)
        Next

        '---------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 10/07/2019: Se unen los vales que se generaron por medio de ecommerce
        '---------------------------------------------------------------------------------------------------------------
        For Each oRow In dtTemp3.Rows
            dtTemp1.ImportRow(oRow)
        Next

        dtTemp1.AcceptChanges()

        dsOrigen.AcceptChanges()

    End Sub

    Public Function GetValesInexistentes() As List(Of String)
        Return lstVales
    End Function

    Public Function GetClientesErroneos() As List(Of String)
        Return lstClientes
    End Function

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private Label20 As Label = Nothing
	Private Label21 As Label = Nothing
	Private Label23 As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtIFactura As TextBox = Nothing
	Private txtPDPV As TextBox = Nothing
	Private txtNDPV As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private txtPPF As TextBox = Nothing
	Private txtIVale As TextBox = Nothing
	Private txtPPV As TextBox = Nothing
	Private txtFRevale As TextBox = Nothing
	Private txtIRevale As TextBox = Nothing
	Private txtPPR As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private Shape5 As Shape = Nothing
	Private TextBox9 As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPagueTiendaEcommerceDPVale))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.txtIFactura = New DataDynamics.ActiveReports.TextBox()
        Me.txtPDPV = New DataDynamics.ActiveReports.TextBox()
        Me.txtNDPV = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.txtPPF = New DataDynamics.ActiveReports.TextBox()
        Me.txtIVale = New DataDynamics.ActiveReports.TextBox()
        Me.txtPPV = New DataDynamics.ActiveReports.TextBox()
        Me.txtFRevale = New DataDynamics.ActiveReports.TextBox()
        Me.txtIRevale = New DataDynamics.ActiveReports.TextBox()
        Me.txtPPR = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape5 = New DataDynamics.ActiveReports.Shape()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPDPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFRevale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIRevale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtCliente, Me.txtIFactura, Me.txtPDPV, Me.txtNDPV, Me.TextBox6, Me.txtPPF, Me.txtIVale, Me.txtPPV, Me.txtFRevale, Me.txtIRevale, Me.txtPPR, Me.TextBox11})
        Me.Detail.Height = 0.1666667!
        Me.Detail.Name = "Detail"
        '
        'txtFolio
        '
        Me.txtFolio.DataField = "Folio"
        Me.txtFolio.Height = 0.1574803!
        Me.txtFolio.Left = 0.0!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "text-align: center; font-size: 8.25pt"
        Me.txtFolio.Text = Nothing
        Me.txtFolio.Top = 0.0!
        Me.txtFolio.Width = 0.5625!
        '
        'txtCliente
        '
        Me.txtCliente.DataField = "Cliente"
        Me.txtCliente.Height = 0.1574803!
        Me.txtCliente.Left = 0.625!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Style = "font-size: 8.25pt"
        Me.txtCliente.Text = Nothing
        Me.txtCliente.Top = 0.0!
        Me.txtCliente.Width = 1.375!
        '
        'txtIFactura
        '
        Me.txtIFactura.DataField = "IFactura"
        Me.txtIFactura.Height = 0.1574803!
        Me.txtIFactura.Left = 2.014026!
        Me.txtIFactura.Name = "txtIFactura"
        Me.txtIFactura.OutputFormat = resources.GetString("txtIFactura.OutputFormat")
        Me.txtIFactura.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIFactura.Text = Nothing
        Me.txtIFactura.Top = 0.0!
        Me.txtIFactura.Width = 0.6734743!
        '
        'txtPDPV
        '
        Me.txtPDPV.DataField = "PDPV"
        Me.txtPDPV.Height = 0.1574803!
        Me.txtPDPV.Left = 2.75!
        Me.txtPDPV.Name = "txtPDPV"
        Me.txtPDPV.OutputFormat = resources.GetString("txtPDPV.OutputFormat")
        Me.txtPDPV.Style = "text-align: right; font-size: 8.25pt"
        Me.txtPDPV.Text = Nothing
        Me.txtPDPV.Top = 0.0!
        Me.txtPDPV.Width = 0.6875!
        '
        'txtNDPV
        '
        Me.txtNDPV.DataField = "NDPV"
        Me.txtNDPV.Height = 0.1574803!
        Me.txtNDPV.Left = 3.4375!
        Me.txtNDPV.Name = "txtNDPV"
        Me.txtNDPV.Style = "text-align: center; font-size: 8.25pt"
        Me.txtNDPV.Text = Nothing
        Me.txtNDPV.Top = 0.0!
        Me.txtNDPV.Width = 0.5580707!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "Asociado"
        Me.TextBox6.Height = 0.1574803!
        Me.TextBox6.Left = 4.022966!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.6020341!
        '
        'txtPPF
        '
        Me.txtPPF.DataField = "PPF"
        Me.txtPPF.Height = 0.1574803!
        Me.txtPPF.Left = 4.644766!
        Me.txtPPF.Name = "txtPPF"
        Me.txtPPF.Style = "text-align: center; font-size: 8.25pt"
        Me.txtPPF.Text = Nothing
        Me.txtPPF.Top = 0.0!
        Me.txtPPF.Width = 0.1677337!
        '
        'txtIVale
        '
        Me.txtIVale.DataField = "IVale"
        Me.txtIVale.Height = 0.1574803!
        Me.txtIVale.Left = 4.8125!
        Me.txtIVale.Name = "txtIVale"
        Me.txtIVale.OutputFormat = resources.GetString("txtIVale.OutputFormat")
        Me.txtIVale.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIVale.Text = Nothing
        Me.txtIVale.Top = 0.0!
        Me.txtIVale.Width = 0.5625!
        '
        'txtPPV
        '
        Me.txtPPV.DataField = "PPV"
        Me.txtPPV.Height = 0.1574803!
        Me.txtPPV.Left = 5.375!
        Me.txtPPV.Name = "txtPPV"
        Me.txtPPV.Style = "text-align: center; font-size: 8.25pt"
        Me.txtPPV.Text = Nothing
        Me.txtPPV.Top = 0.0!
        Me.txtPPV.Width = 0.1968503!
        '
        'txtFRevale
        '
        Me.txtFRevale.DataField = "FRevale"
        Me.txtFRevale.Height = 0.1574803!
        Me.txtFRevale.Left = 5.580462!
        Me.txtFRevale.Name = "txtFRevale"
        Me.txtFRevale.Style = "text-align: center; font-size: 8.25pt"
        Me.txtFRevale.Text = Nothing
        Me.txtFRevale.Top = 0.0!
        Me.txtFRevale.Width = 0.4195375!
        '
        'txtIRevale
        '
        Me.txtIRevale.DataField = "IRevale"
        Me.txtIRevale.Height = 0.1574803!
        Me.txtIRevale.Left = 6.0!
        Me.txtIRevale.Name = "txtIRevale"
        Me.txtIRevale.OutputFormat = resources.GetString("txtIRevale.OutputFormat")
        Me.txtIRevale.Style = "text-align: right; font-size: 8.25pt"
        Me.txtIRevale.Text = Nothing
        Me.txtIRevale.Top = 0.0!
        Me.txtIRevale.Width = 0.5511818!
        '
        'txtPPR
        '
        Me.txtPPR.DataField = "PPR"
        Me.txtPPR.Height = 0.1574803!
        Me.txtPPR.Left = 6.5625!
        Me.txtPPR.Name = "txtPPR"
        Me.txtPPR.Style = "text-align: center; font-size: 8.25pt"
        Me.txtPPR.Text = Nothing
        Me.txtPPR.Top = 0.0!
        Me.txtPPR.Width = 0.1875!
        '
        'TextBox11
        '
        Me.TextBox11.DataField = "Status"
        Me.TextBox11.Height = 0.1574803!
        Me.TextBox11.Left = 6.75!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.1205702!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.TextBox9, Me.TextBox10})
        Me.ReportFooter.Height = 0.2909722!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape5
        '
        Me.Shape5.Height = 0.25!
        Me.Shape5.Left = 0.0!
        Me.Shape5.Name = "Shape5"
        Me.Shape5.RoundingRadius = 9.999999!
        Me.Shape5.Top = 0.0!
        Me.Shape5.Width = 6.9375!
        '
        'TextBox9
        '
        Me.TextBox9.DataField = "IFactura"
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 1.885417!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox9.Text = "TextBox9"
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.75!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "PDPV"
        Me.TextBox10.Height = 0.2!
        Me.TextBox10.Left = 2.690289!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox10.Text = "TextBox10"
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.7217847!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.txtSucursal, Me.txtFecha, Me.Label12, Me.Label11, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label16, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label23, Me.Shape1})
        Me.GroupHeader1.Height = 1.020833!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label1.Text = "Reporte de Pagos Ecommerce Vale"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.8125!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 2.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label2.Text = "Sucursal:"
        Me.Label2.Top = 0.375!
        Me.Label2.Width = 0.5826772!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label3.Text = "Fecha:"
        Me.Label3.Top = 0.1875!
        Me.Label3.Width = 0.4576772!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 2.625!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Style = "font-size: 8.25pt"
        Me.txtSucursal.Text = "TextBox7"
        Me.txtSucursal.Top = 0.375!
        Me.txtSucursal.Width = 2.413878!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 3.5!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt"
        Me.txtFecha.Text = "TextBox8"
        Me.txtFecha.Top = 0.1875!
        Me.txtFecha.Width = 0.75!
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 5.5625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label12.Text = "Revale"
        Me.Label12.Top = 0.625!
        Me.Label12.Width = 1.1875!
        '
        'Label11
        '
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 4.8125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label11.Text = "DPV Emitido"
        Me.Label11.Top = 0.625!
        Me.Label11.Width = 0.75!
        '
        'Label4
        '
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label4.Text = "Folio"
        Me.Label4.Top = 0.8125!
        Me.Label4.Width = 0.5905511!
        '
        'Label5
        '
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.5905511!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label5.Text = "Cliente"
        Me.Label5.Top = 0.8125!
        Me.Label5.Width = 1.409449!
        '
        'Label6
        '
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label6.Text = "Imp. Factura"
        Me.Label6.Top = 0.8125!
        Me.Label6.Width = 0.748032!
        '
        'Label7
        '
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.75!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label7.Text = "Pago DPV"
        Me.Label7.Top = 0.8125!
        Me.Label7.Width = 0.6875!
        '
        'Label8
        '
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 3.4375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label8.Text = "No. DPV"
        Me.Label8.Top = 0.8125!
        Me.Label8.Width = 0.5625!
        '
        'Label9
        '
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label9.Text = "Asociado"
        Me.Label9.Top = 0.8125!
        Me.Label9.Width = 0.625!
        '
        'Label10
        '
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.625!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label10.Text = "PP"
        Me.Label10.Top = 0.8125!
        Me.Label10.Width = 0.1875!
        '
        'Label16
        '
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.8125!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label16.Text = "Importe"
        Me.Label16.Top = 0.8125!
        Me.Label16.Width = 0.5625!
        '
        'Label18
        '
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.1875!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 5.375!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label18.Text = "PP"
        Me.Label18.Top = 0.8125!
        Me.Label18.Width = 0.1875!
        '
        'Label19
        '
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.1875!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 5.5625!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label19.Text = "Folio"
        Me.Label19.Top = 0.8125!
        Me.Label19.Width = 0.4375!
        '
        'Label20
        '
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 6.0!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label20.Text = "Importe"
        Me.Label20.Top = 0.8125!
        Me.Label20.Width = 0.5625!
        '
        'Label21
        '
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 6.5625!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label21.Text = "PP"
        Me.Label21.Top = 0.8125!
        Me.Label21.Width = 0.1875!
        '
        'Label23
        '
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.1875!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 6.75!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
        Me.Label23.Text = "S."
        Me.Label23.Top = 0.8125!
        Me.Label23.Width = 0.1875!
        '
        'Shape1
        '
        Me.Shape1.Height = 1.0!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.9375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptPagueTiendaEcommerceDPVale
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.7875!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.7875!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.989583!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPDPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNDPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFRevale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIRevale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
