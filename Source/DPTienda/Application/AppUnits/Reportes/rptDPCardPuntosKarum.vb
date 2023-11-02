Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptDPCardPuntosKarum
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dpCardDatos As Hashtable)
        MyBase.New()
        InitializeComponent()
        If dpCardDatos.ContainsKey("TipoReporte") = True Then
            Dim tipoRep As String = CStr(dpCardDatos("TipoReporte")).ToUpper()
            Me.lblPuntosEnPesos.Text = "Puntos en pesos:"
            Me.lblPuntosEnPesos.Visible = False
            Select Case tipoRep
                Case "ACT"
                    Me.lblDPCardPuntos.Text = "Activacion DPCard Puntos"
                    Me.lblPuntosGanados.Visible = False
                    Me.lblPuntosEnPesos.Visible = False
                    Me.txtPuntosGanados.Visible = False
                    Me.txtPuntosPesos.Visible = False
                    Me.lblCustomer.Visible = False
                    Me.txtCustomer.Visible = False
                    Me.lblSaldo.Visible = False
                    Me.txtPuntosAcumulados.Visible = False

                Case "BON"
                    'wgomez eliminar comentados cuando se aprueve
                    Me.lblDPCardPuntos.Text = "Acumulación de puntos"
                    Me.lblPuntosGanados.Visible = False
                    Me.lblPuntosGanados.Text = "Cliente CLUB DP:"
                    Me.txtPuntosGanados.Visible = True
                    Me.txtPuntosPesos.Visible = False
                    Me.lblCustomer.Visible = True
                    Me.txtCustomer.Visible = True
                    'Me.txtCustomer.Visible = False
                    Me.lblSaldo.Visible = True
                    Me.txtSaldo.Visible = True
                    'MLVARGAS (25/11/2019) Fijar el valor del cliente    
                    If dpCardDatos.ContainsKey("CustomerName") Then
                        Me.txtCustomer.Text = CStr(dpCardDatos("CustomerName"))
                    End If
                    'wgomez eliminr asignasion de Customer
                    'Me.txtPuntosGanados.Text = "DE LEON"
                    'wgomez mostrar Puntos acumulados y terminos y condiciones
                    Me.lblpuntosAcumulados.Visible = True
                    Me.txtPuntosAcumulados.Visible = True
                    Me.lblTerminosyCondiciones.Visible = True
                    Me.txtTeminosyCondiciones.Visible = True
                    'Me.lblPuntosEnPesos.Height = 0
                    Me.txtPuntosAcumulados.Text = CStr(dpCardDatos("TransactionPoints"))
                    'wgomez reacomodar campos en eje Y
                    Me.lblCustomer.Top = Me.lblCustomer.Top - 0.6
                    Me.txtCustomer.Top = Me.txtCustomer.Top - 0.6
                    Me.lblpuntosAcumulados.Top = Me.lblpuntosAcumulados.Top - 0.5
                    Me.txtPuntosAcumulados.Top = Me.txtPuntosAcumulados.Top - 0.5
                    Me.lblSaldo.Top = Me.lblSaldo.Top - 0.5
                    Me.txtSaldo.Top = Me.txtSaldo.Top - 0.5
                    Me.lblTerminosyCondiciones.Top = Me.lblTerminosyCondiciones.Top - 0.5
                    Me.txtTeminosyCondiciones.Top = Me.txtTeminosyCondiciones.Top - 0.5
                    If dpCardDatos.ContainsKey("TotalPoints") Then
                        Me.txtSaldo.Text = CDec(dpCardDatos("TotalPoints")).ToString("##,##0.00")
                    End If
                Case "CAN"
                    Me.lblDPCardPuntos.Text = "Canje de Puntos"
                    'Me.lblPuntosGanados.Text = "Monto:"
                    Me.txtPuntosPesos.Visible = False
                    Me.lblPuntosEnPesos.Visible = False
                    Me.lblCustomer.Visible = True
                    Me.txtCustomer.Visible = True
                    Me.lblpuntosAcumulados.Visible = True
                    Me.lblpuntosAcumulados.Text = "Número de puntos canjeados:"
                    Me.lblSaldo.Visible = True
                    Me.txtPuntosAcumulados.Visible = True
                    Me.lblPuntosGanados.Visible = False
                    'Me.lblPuntosGanados.Text = "Puntos Disponibles:"
                    'If dpCardDatos.ContainsKey("Monto") Then Me.txtPuntosGanados.Text = CDec(dpCardDatos("Monto")).ToString("##,##0.00")
                    If dpCardDatos.ContainsKey("Monto") Then Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("Monto")).ToString("##,##0.00")
                    'If CStr(dpCardDatos("tipo")) = "00" Then
                    '    Me.lblPuntosEnPesos.Text = "Deslizada"
                    'ElseIf CStr(dpCardDatos("tipo")) = "01" Then
                    '    Me.lblPuntosEnPesos.Text = "Digitalizada"
                    'End If
                    Me.lnLinea.Visible = True
                    Me.txtFirma.Visible = True
                    Me.txtFirma.Text = CStr(dpCardDatos("NombreCliente"))
                    If dpCardDatos.ContainsKey("CustomerName") Then
                        Me.txtFirma.Text = CStr(dpCardDatos("CustomerName"))
                    End If
                    'MLVARGAS (25/11/2019) Asignar los valores del Cliente y del Saldo del canje                    
                    'If dpCardDatos.ContainsKey("TotalPoints") Then
                    '    Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("TotalPoints")).ToString("##,##0.00")
                    'End If
                    If dpCardDatos.ContainsKey("TotalPoints") Then
                        Me.txtSaldo.Text = CDec(dpCardDatos("TotalPoints")).ToString("##,##0.00")
                    End If
                    If dpCardDatos.ContainsKey("CustomerName") Then
                        Me.txtCustomer.Text = CStr(dpCardDatos("CustomerName"))
                    End If
                    'wgomez reacomodar campos en eje Y
                    Me.lblCustomer.Top = Me.lblCustomer.Top - 0.54
                    Me.txtCustomer.Top = Me.txtCustomer.Top - 0.54
                    Me.lblpuntosAcumulados.Top = Me.lblpuntosAcumulados.Top - 0.5
                    Me.txtPuntosAcumulados.Top = Me.txtPuntosAcumulados.Top - 0.5
                    Me.lblSaldo.Top = Me.lblSaldo.Top - 0.5
                    Me.txtSaldo.Top = Me.txtSaldo.Top - 0.5
                    'Me.lblTerminosyCondiciones.Top = Me.lblTerminosyCondiciones.Top - 0.5
                    'Me.txtTeminosyCondiciones.Top = Me.txtTeminosyCondiciones.Top - 0.5
                    'Me.lnLinea.Top = Me.lnLinea.Top - 0.5
                    'Me.txtFirma.Top = Me.txtFirma.Top - 0.5
                Case "DEV"
                    Me.lblDPCardPuntos.Text = "Cancelación Canje de puntos"
                    'Me.lblPuntosGanados.Text = "Monto:"
                    Me.lblCustomer.Visible = True
                    Me.txtCustomer.Visible = True
                    Me.lblSaldo.Visible = True
                    Me.txtPuntosAcumulados.Visible = True
                    Me.lblpuntosAcumulados.Visible = True
                    Me.lblpuntosAcumulados.Text = "Monto devolución de puntos:"
                    Me.lblPuntosEnPesos.Visible = False
                    Me.lblPuntosGanados.Visible = False

                    'If dpCardDatos.ContainsKey("Monto") Then Me.txtPuntosGanados.Text = CDec(dpCardDatos("Monto")).ToString()
                    If dpCardDatos.ContainsKey("PoinstoReturn") Then Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("PoinstoReturn")).ToString("##,##0.00")

                    'If dpCardDatos.ContainsKey("TransactionPoints") Then Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("TransactionPoints")).ToString("##,##0.00")
                    'If CStr(dpCardDatos("tipo")) = "00" Then
                    '    Me.lblPuntosEnPesos.Text = "Deslizada"
                    'ElseIf CStr(dpCardDatos("tipo")) = "01" Then
                    '    Me.lblPuntosEnPesos.Text = "Digitalizada"
                    'End If
                    Me.txtPuntosPesos.Visible = False

                    'MLVARGAS (25/11/2019) Asignar los valores del Cliente y del Saldo del canje   
                    If dpCardDatos.ContainsKey("TotalPoints") Then
                        Me.txtSaldo.Text = CDec(dpCardDatos("TotalPoints")).ToString("##,##0.00")
                    End If
                    If dpCardDatos.ContainsKey("CustomerName") Then
                        Me.txtCustomer.Text = CStr(dpCardDatos("CustomerName"))
                    End If
                    Me.lblCustomer.Top = Me.lblCustomer.Top - 0.54
                    Me.txtCustomer.Top = Me.txtCustomer.Top - 0.54
                    Me.lblpuntosAcumulados.Top = Me.lblpuntosAcumulados.Top - 0.5
                    Me.txtPuntosAcumulados.Top = Me.txtPuntosAcumulados.Top - 0.5
                    Me.lblSaldo.Top = Me.lblSaldo.Top - 0.46
                    Me.txtSaldo.Top = Me.txtSaldo.Top - 0.46
                    Me.lblTerminosyCondiciones.Top = Me.lblTerminosyCondiciones.Top - 0.55
                    Me.txtTeminosyCondiciones.Top = Me.txtTeminosyCondiciones.Top - 0.55
                Case "DEVBON"
                    Me.lblDPCardPuntos.Text = "Cancelación de Acumulación"
                    Me.lblCustomer.Visible = True
                    Me.txtCustomer.Visible = True
                    Me.lblSaldo.Visible = True
                    Me.lblpuntosAcumulados.Visible = True
                    Me.lblpuntosAcumulados.Text = "Monto de puntos cancelados:"
                    Me.txtPuntosAcumulados.Visible = True
                    Me.lblSaldo.Visible = True
                    Me.txtSaldo.Visible = True
                    'Me.lblPuntosGanados.Text = "Cliente CLUB DP:"
                    Me.lblPuntosGanados.Visible = False
                    Me.txtPuntosGanados.Visible = False
                    'MLVARGAS (25/11/2019) Fijar el valor del cliente   
                    If dpCardDatos.ContainsKey("CustomerName") Then
                        Me.txtCustomer.Text = CStr(dpCardDatos("CustomerName")).Trim
                    End If
                    If dpCardDatos.ContainsKey("PoinstoRedeem") Then Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("PoinstoRedeem")).ToString("##,##0.00")
                    'If dpCardDatos.ContainsKey("TransactionPoints") Then Me.txtPuntosAcumulados.Text = CDec(dpCardDatos("TransactionPoints")).ToString("##,##0.00")
                    If dpCardDatos.ContainsKey("TotalPoints") Then
                        Me.txtSaldo.Text = CDec(dpCardDatos("TotalPoints")).ToString("##,##0.00")
                    End If
                    Me.lblCustomer.Top = Me.lblCustomer.Top - 0.54
                    Me.txtCustomer.Top = Me.txtCustomer.Top - 0.54
                    Me.lblpuntosAcumulados.Top = Me.lblpuntosAcumulados.Top - 0.5
                    Me.txtPuntosAcumulados.Top = Me.txtPuntosAcumulados.Top - 0.5
                    Me.lblSaldo.Top = Me.lblSaldo.Top - 0.46
                    Me.txtSaldo.Top = Me.txtSaldo.Top - 0.46
                    Me.lblTerminosyCondiciones.Top = Me.lblTerminosyCondiciones.Top - 0.55
                    Me.txtTeminosyCondiciones.Top = Me.txtTeminosyCondiciones.Top - 0.55
            End Select
        End If
        Me.txtFecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
        Me.txtHora.Text = "Hora: " & DateTime.Now.ToString("HH:mm")
        Me.txtNoTienda.Text = CStr(dpCardDatos("NoTienda")).Replace("D3", "")
        Me.txtNoCaja.Text = CStr(dpCardDatos("NoCaja")).Trim
        Me.txtVendedor.Text = CStr(dpCardDatos("CodVendedor"))
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '"2" & oAppContext.ApplicationConfiguration.Almacen)
        Me.txtNombreTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        If CStr(CStr(dpCardDatos("CardId"))).Trim().Length = 16 Then
            Me.txtNoTarjeta.Text = "**** **** ****" & CStr(dpCardDatos("CardId")).Substring(12, 4)
        ElseIf CStr(CStr(dpCardDatos("CardId"))).Trim().Length = 13 Then
            Me.txtNoTarjeta.Text = "**** **** ****" & CStr(dpCardDatos("CardId")).Substring(9, 4)
            Else
                Me.txtNoTarjeta.Text = CStr(dpCardDatos("CardId"))
        End If

        Me.txtConsecutivoPOS.Text = CStr(dpCardDatos("ConsecutivoPOS"))
        'If CStr(dpCardDatos("TotalPoints")) <> "" Then Me.txtPuntosGanados.Text = CLng(dpCardDatos("TotalPoints")).ToString()
        'If CStr(dpCardDatos("TotalPointsInCash")) <> "" Then Me.txtPuntosPesos.Text = CDec(dpCardDatos("TotalPointsInCash")).ToString("##,##0.00")


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private lblDPCardPuntos As Label = Nothing
    Private lblPuntosGanados As Label = Nothing
    Private txtPuntosGanados As TextBox = Nothing
    Private lblPuntosEnPesos As Label = Nothing
    Private txtPuntosPesos As TextBox = Nothing
    Private lblNoTarjeta As Label = Nothing
    Private lblNoTienda As Label = Nothing
    Private txtNoTienda As TextBox = Nothing
    Private lblNoCaja As Label = Nothing
    Private txtNoCaja As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private txtHora As TextBox = Nothing
    Private txtVendedor As TextBox = Nothing
    Private lblVendedor As Label = Nothing
    Private txtNombreTienda As TextBox = Nothing
    Friend WithEvents lblCM As DataDynamics.ActiveReports.Label
    Friend WithEvents txtConsecutivoPOS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFirma As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lnLinea As DataDynamics.ActiveReports.Line
    Friend WithEvents lblCustomer As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSaldo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCustomer As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPuntosAcumulados As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblpuntosAcumulados As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTerminosyCondiciones As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTeminosyCondiciones As DataDynamics.ActiveReports.Label
    Private txtNoTarjeta As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDPCardPuntosKarum))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblDPCardPuntos = New DataDynamics.ActiveReports.Label()
        Me.lblPuntosGanados = New DataDynamics.ActiveReports.Label()
        Me.txtPuntosGanados = New DataDynamics.ActiveReports.TextBox()
        Me.lblPuntosEnPesos = New DataDynamics.ActiveReports.Label()
        Me.txtPuntosPesos = New DataDynamics.ActiveReports.TextBox()
        Me.lblNoTarjeta = New DataDynamics.ActiveReports.Label()
        Me.lblNoTienda = New DataDynamics.ActiveReports.Label()
        Me.txtNoTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblNoCaja = New DataDynamics.ActiveReports.Label()
        Me.txtNoCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.txtHora = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.lblVendedor = New DataDynamics.ActiveReports.Label()
        Me.txtNombreTienda = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoTarjeta = New DataDynamics.ActiveReports.TextBox()
        Me.lblCM = New DataDynamics.ActiveReports.Label()
        Me.txtConsecutivoPOS = New DataDynamics.ActiveReports.TextBox()
        Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
        Me.lnLinea = New DataDynamics.ActiveReports.Line()
        Me.lblCustomer = New DataDynamics.ActiveReports.Label()
        Me.lblSaldo = New DataDynamics.ActiveReports.Label()
        Me.txtCustomer = New DataDynamics.ActiveReports.TextBox()
        Me.txtPuntosAcumulados = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblpuntosAcumulados = New DataDynamics.ActiveReports.Label()
        Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
        Me.lblTerminosyCondiciones = New DataDynamics.ActiveReports.Label()
        Me.txtTeminosyCondiciones = New DataDynamics.ActiveReports.Label()
        CType(Me.lblDPCardPuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPuntosGanados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosGanados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPuntosEnPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuntosAcumulados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblpuntosAcumulados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTerminosyCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTeminosyCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDPCardPuntos, Me.lblPuntosGanados, Me.txtPuntosGanados, Me.lblPuntosEnPesos, Me.txtPuntosPesos, Me.lblNoTarjeta, Me.lblNoTienda, Me.txtNoTienda, Me.lblNoCaja, Me.txtNoCaja, Me.txtFecha, Me.txtHora, Me.txtVendedor, Me.lblVendedor, Me.txtNombreTienda, Me.txtNoTarjeta, Me.lblCM, Me.txtConsecutivoPOS, Me.txtFirma, Me.lnLinea, Me.lblCustomer, Me.lblSaldo, Me.txtCustomer, Me.txtPuntosAcumulados, Me.lblpuntosAcumulados, Me.txtSaldo, Me.lblTerminosyCondiciones, Me.txtTeminosyCondiciones})
        Me.PageHeader.Height = 4.39325!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblDPCardPuntos
        '
        Me.lblDPCardPuntos.Height = 0.1875!
        Me.lblDPCardPuntos.HyperLink = Nothing
        Me.lblDPCardPuntos.Left = 0.3!
        Me.lblDPCardPuntos.Name = "lblDPCardPuntos"
        Me.lblDPCardPuntos.Style = "font-weight: bold; font-size: 9.75pt; vertical-align: top; text-align: center"
        Me.lblDPCardPuntos.Text = "Activacion DPCard Puntos"
        Me.lblDPCardPuntos.Top = 0.0!
        Me.lblDPCardPuntos.Width = 2.265!
        '
        'lblPuntosGanados
        '
        Me.lblPuntosGanados.Height = 0.1875!
        Me.lblPuntosGanados.HyperLink = Nothing
        Me.lblPuntosGanados.Left = 0.19!
        Me.lblPuntosGanados.Name = "lblPuntosGanados"
        Me.lblPuntosGanados.Style = ""
        Me.lblPuntosGanados.Text = "Puntos Disponibles:"
        Me.lblPuntosGanados.Top = 2.312!
        Me.lblPuntosGanados.Width = 1.323!
        '
        'txtPuntosGanados
        '
        Me.txtPuntosGanados.Height = 0.1875!
        Me.txtPuntosGanados.Left = 1.44!
        Me.txtPuntosGanados.Name = "txtPuntosGanados"
        Me.txtPuntosGanados.Text = Nothing
        Me.txtPuntosGanados.Top = 2.3125!
        Me.txtPuntosGanados.Width = 1.25!
        '
        'lblPuntosEnPesos
        '
        Me.lblPuntosEnPesos.Height = 0.3520002!
        Me.lblPuntosEnPesos.HyperLink = Nothing
        Me.lblPuntosEnPesos.Left = 0.19!
        Me.lblPuntosEnPesos.Name = "lblPuntosEnPesos"
        Me.lblPuntosEnPesos.Style = ""
        Me.lblPuntosEnPesos.Text = "Puntos en pesos:"
        Me.lblPuntosEnPesos.Top = 2.5!
        Me.lblPuntosEnPesos.Width = 2.5!
        '
        'txtPuntosPesos
        '
        Me.txtPuntosPesos.Height = 0.1875!
        Me.txtPuntosPesos.Left = 1.44!
        Me.txtPuntosPesos.Name = "txtPuntosPesos"
        Me.txtPuntosPesos.OutputFormat = resources.GetString("txtPuntosPesos.OutputFormat")
        Me.txtPuntosPesos.Text = Nothing
        Me.txtPuntosPesos.Top = 2.5!
        Me.txtPuntosPesos.Width = 1.25!
        '
        'lblNoTarjeta
        '
        Me.lblNoTarjeta.Height = 0.1875!
        Me.lblNoTarjeta.HyperLink = Nothing
        Me.lblNoTarjeta.Left = 0.19!
        Me.lblNoTarjeta.Name = "lblNoTarjeta"
        Me.lblNoTarjeta.Style = ""
        Me.lblNoTarjeta.Text = "No. Tarjeta:"
        Me.lblNoTarjeta.Top = 2.0!
        Me.lblNoTarjeta.Width = 0.8125!
        '
        'lblNoTienda
        '
        Me.lblNoTienda.Height = 0.1875!
        Me.lblNoTienda.HyperLink = Nothing
        Me.lblNoTienda.Left = 0.19!
        Me.lblNoTienda.Name = "lblNoTienda"
        Me.lblNoTienda.Style = ""
        Me.lblNoTienda.Text = "No. Tienda:"
        Me.lblNoTienda.Top = 0.53125!
        Me.lblNoTienda.Width = 0.75!
        '
        'txtNoTienda
        '
        Me.txtNoTienda.Height = 0.1875!
        Me.txtNoTienda.Left = 0.9400001!
        Me.txtNoTienda.Name = "txtNoTienda"
        Me.txtNoTienda.Text = Nothing
        Me.txtNoTienda.Top = 0.531!
        Me.txtNoTienda.Width = 0.6875!
        '
        'lblNoCaja
        '
        Me.lblNoCaja.Height = 0.1875!
        Me.lblNoCaja.HyperLink = Nothing
        Me.lblNoCaja.Left = 0.19!
        Me.lblNoCaja.Name = "lblNoCaja"
        Me.lblNoCaja.Style = ""
        Me.lblNoCaja.Text = "No. Caja:"
        Me.lblNoCaja.Top = 1.46875!
        Me.lblNoCaja.Width = 0.75!
        '
        'txtNoCaja
        '
        Me.txtNoCaja.Height = 0.1875!
        Me.txtNoCaja.Left = 0.9400001!
        Me.txtNoCaja.Name = "txtNoCaja"
        Me.txtNoCaja.Text = Nothing
        Me.txtNoCaja.Top = 1.4685!
        Me.txtNoCaja.Width = 0.6875!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 0.19!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "Fecha:"
        Me.txtFecha.Top = 0.25!
        Me.txtFecha.Width = 1.375!
        '
        'txtHora
        '
        Me.txtHora.Height = 0.1875!
        Me.txtHora.Left = 1.565!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Text = "Hora:"
        Me.txtHora.Top = 0.25!
        Me.txtHora.Width = 1.125!
        '
        'txtVendedor
        '
        Me.txtVendedor.Height = 0.1875!
        Me.txtVendedor.Left = 0.9400001!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Text = Nothing
        Me.txtVendedor.Top = 1.656!
        Me.txtVendedor.Width = 0.6875!
        '
        'lblVendedor
        '
        Me.lblVendedor.Height = 0.1875!
        Me.lblVendedor.HyperLink = Nothing
        Me.lblVendedor.Left = 0.19!
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Style = ""
        Me.lblVendedor.Text = "Vendedor:"
        Me.lblVendedor.Top = 1.65625!
        Me.lblVendedor.Width = 0.75!
        '
        'txtNombreTienda
        '
        Me.txtNombreTienda.Height = 0.565!
        Me.txtNombreTienda.Left = 0.19!
        Me.txtNombreTienda.Name = "txtNombreTienda"
        Me.txtNombreTienda.Text = Nothing
        Me.txtNombreTienda.Top = 0.7925!
        Me.txtNombreTienda.Width = 2.5!
        '
        'txtNoTarjeta
        '
        Me.txtNoTarjeta.Height = 0.1875!
        Me.txtNoTarjeta.Left = 1.0025!
        Me.txtNoTarjeta.Name = "txtNoTarjeta"
        Me.txtNoTarjeta.Text = Nothing
        Me.txtNoTarjeta.Top = 2.0!
        Me.txtNoTarjeta.Width = 1.6875!
        '
        'lblCM
        '
        Me.lblCM.Height = 0.1875!
        Me.lblCM.HyperLink = Nothing
        Me.lblCM.Left = 1.687!
        Me.lblCM.Name = "lblCM"
        Me.lblCM.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.lblCM.Text = "CM:"
        Me.lblCM.Top = 1.469!
        Me.lblCM.Width = 0.3125!
        '
        'txtConsecutivoPOS
        '
        Me.txtConsecutivoPOS.Height = 0.1875!
        Me.txtConsecutivoPOS.Left = 1.9995!
        Me.txtConsecutivoPOS.Name = "txtConsecutivoPOS"
        Me.txtConsecutivoPOS.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
        Me.txtConsecutivoPOS.Text = "0001"
        Me.txtConsecutivoPOS.Top = 1.469!
        Me.txtConsecutivoPOS.Width = 0.75!
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.3!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtFirma.Text = "Nombre"
        Me.txtFirma.Top = 3.552!
        Me.txtFirma.Visible = False
        Me.txtFirma.Width = 2.125!
        '
        'lnLinea
        '
        Me.lnLinea.Height = 0.0!
        Me.lnLinea.Left = 0.3000001!
        Me.lnLinea.LineWeight = 1.0!
        Me.lnLinea.Name = "lnLinea"
        Me.lnLinea.Top = 3.5!
        Me.lnLinea.Visible = False
        Me.lnLinea.Width = 2.165!
        Me.lnLinea.X1 = 2.465!
        Me.lnLinea.X2 = 0.3000001!
        Me.lnLinea.Y1 = 3.5!
        Me.lnLinea.Y2 = 3.5!
        '
        'lblCustomer
        '
        Me.lblCustomer.Height = 0.1875!
        Me.lblCustomer.HyperLink = Nothing
        Me.lblCustomer.Left = 0.19!
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Style = ""
        Me.lblCustomer.Text = "Cliente Club DP:"
        Me.lblCustomer.Top = 2.852!
        Me.lblCustomer.Width = 1.25!
        '
        'lblSaldo
        '
        Me.lblSaldo.Height = 0.1875!
        Me.lblSaldo.HyperLink = Nothing
        Me.lblSaldo.Left = 0.19!
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Style = ""
        Me.lblSaldo.Text = "Saldo en puntos:"
        Me.lblSaldo.Top = 3.229!
        Me.lblSaldo.Width = 1.25!
        '
        'txtCustomer
        '
        Me.txtCustomer.Height = 0.1875!
        Me.txtCustomer.Left = 1.209!
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.OutputFormat = resources.GetString("txtCustomer.OutputFormat")
        Me.txtCustomer.Text = Nothing
        Me.txtCustomer.Top = 2.852!
        Me.txtCustomer.Width = 1.481!
        '
        'txtPuntosAcumulados
        '
        Me.txtPuntosAcumulados.Height = 0.1875!
        Me.txtPuntosAcumulados.Left = 2.222!
        Me.txtPuntosAcumulados.Name = "txtPuntosAcumulados"
        Me.txtPuntosAcumulados.OutputFormat = resources.GetString("txtPuntosAcumulados.OutputFormat")
        Me.txtPuntosAcumulados.Top = 3.04!
        Me.txtPuntosAcumulados.Visible = False
        Me.txtPuntosAcumulados.Width = 0.4679999!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblpuntosAcumulados
        '
        Me.lblpuntosAcumulados.Height = 0.1875!
        Me.lblpuntosAcumulados.HyperLink = Nothing
        Me.lblpuntosAcumulados.Left = 0.19!
        Me.lblpuntosAcumulados.Name = "lblpuntosAcumulados"
        Me.lblpuntosAcumulados.Style = ""
        Me.lblpuntosAcumulados.Text = "Número de puntos acumulados:"
        Me.lblpuntosAcumulados.Top = 3.042!
        Me.lblpuntosAcumulados.Visible = False
        Me.lblpuntosAcumulados.Width = 2.032!
        '
        'txtSaldo
        '
        Me.txtSaldo.Height = 0.1875!
        Me.txtSaldo.Left = 1.365!
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
        Me.txtSaldo.Text = Nothing
        Me.txtSaldo.Top = 3.229!
        Me.txtSaldo.Width = 1.325!
        '
        'lblTerminosyCondiciones
        '
        Me.lblTerminosyCondiciones.Height = 0.1875!
        Me.lblTerminosyCondiciones.HyperLink = Nothing
        Me.lblTerminosyCondiciones.Left = 0.19!
        Me.lblTerminosyCondiciones.Name = "lblTerminosyCondiciones"
        Me.lblTerminosyCondiciones.Style = ""
        Me.lblTerminosyCondiciones.Text = "Consulta términos y condiciones en"
        Me.lblTerminosyCondiciones.Top = 3.862!
        Me.lblTerminosyCondiciones.Width = 2.5!
        '
        'txtTeminosyCondiciones
        '
        Me.txtTeminosyCondiciones.Height = 0.1875!
        Me.txtTeminosyCondiciones.HyperLink = Nothing
        Me.txtTeminosyCondiciones.Left = 0.19!
        Me.txtTeminosyCondiciones.Name = "txtTeminosyCondiciones"
        Me.txtTeminosyCondiciones.Style = "text-decoration: underline"
        Me.txtTeminosyCondiciones.Text = "www.clubdp.mx"
        Me.txtTeminosyCondiciones.Top = 4.042!
        Me.txtTeminosyCondiciones.Width = 2.5!
        '
        'rptDPCardPuntosKarum
        '
        Me.MasterReport = False
        Me.PageSettings.Gutter = 0.04!
        Me.PageSettings.Margins.Bottom = 0.04!
        Me.PageSettings.Margins.Left = 0.04!
        Me.PageSettings.Margins.Right = 0.04!
        Me.PageSettings.Margins.Top = 0.04!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.813!
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
        CType(Me.lblDPCardPuntos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPuntosGanados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosGanados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPuntosEnPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsecutivoPOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuntosAcumulados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblpuntosAcumulados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTerminosyCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTeminosyCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
