Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.PolizaAU

Public Class rptPoliza
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal CodCaja As String, ByVal Fecha As Date)
        MyBase.New()
        InitializeComponent()

        Me.txtFechaPoliza.Text = Fecha
        Me.txtFechaPolizaGH.Text = Fecha

        Dim dsRetiros, dsVentasTotales, dsVentasTarjetas As DataSet
        Dim oPolizaMgr As New PolizaManager(oAppContext)
        dsRetiros = oPolizaMgr.GetRetiros(CodCaja, Fecha).Copy
        dsVentasTotales = oPolizaMgr.GetVentasTotales(CodCaja, Fecha).Copy
        dsVentasTarjetas = oPolizaMgr.GetVentasTarjetas(CodCaja, Fecha).Copy

        CreateTable()
        Dim movimiento As Integer = 0
        Dim fondo As Decimal

        '''''Retiros
        For Each row As DataRow In dsRetiros.Tables("Retiros").Rows
            movimiento += 1

            Dim newRow As DataRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("Cuenta") = CStr(row("Cuenta")).Insert(3, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(7, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(11, "-")
            newRow("Cuenta") = row("Cuenta")

            newRow("Nombre") = "AQUILES SERDAN REF " & row("Referencia") _
                               & vbCrLf & "Fact. " & row("FolioFacturaInicial") & " - " & row("FolioFacturaFinal") _
                               & vbCrLf & "Ficha " & row("Ficha") & " Responsable " & row("Responsable")

            newRow("Cargos") = row("CantidadRetiro")

            fondo = row("Fondo")
            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()
        Next

        VentasTarjetas(dsVentasTarjetas, movimiento)

        ''''''VentasTarjetas
        'For Each row As DataRow In dsVentasTarjetas.Tables("Ventas").Rows
        '    movimiento += 1

        '    Dim newRow As DataRow = dsPoliza.Tables("Poliza").NewRow

        '    newRow("NumMovimiento") = movimiento

        '    row("Cuenta") = CStr(row("Cuenta")).Insert(3, "-")
        '    row("Cuenta") = CStr(row("Cuenta")).Insert(7, "-")
        '    row("Cuenta") = CStr(row("Cuenta")).Insert(11, "-")
        '    newRow("Cuenta") = row("Cuenta")

        '    newRow("Nombre") = "AQUILES SERDAN REF " & row("Referencia") _
        '                       & vbCrLf & "POR EL CIERRE DE LOTE"

        '    newRow("Cargos") = row("VTarjetas")

        '    dsPoliza.Tables("Poliza").Rows.Add(newRow)
        '    dsPoliza.AcceptChanges()


        '    ''''Iva Comision Tarjeta
        '    movimiento += 1
        '    newRow = dsPoliza.Tables("Poliza").NewRow

        '    newRow("NumMovimiento") = movimiento

        '    row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(3, "-")
        '    row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(7, "-")
        '    row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(11, "-")
        '    newRow("Cuenta") = row("CuentaTIVA")

        '    newRow("Nombre") = "TARJETAS DE CREDITO" _
        '                       & vbCrLf & "COM. " & oAppContext.ApplicationConfiguration.ComisionTarjetaCredito & "% S/T. C." _
        '                       & vbCrLf & "POR EL CIERRE DE LOTE"

        '    newRow("Cargos") = row("VTarjetas") * (oAppContext.ApplicationConfiguration.ComisionTarjetaCredito / 100)

        '    Dim IvaTC As Decimal = newRow("Cargos")

        '    dsPoliza.Tables("Poliza").Rows.Add(newRow)
        '    dsPoliza.AcceptChanges()

        '    ''''Iva por gastos
        '    movimiento += 1
        '    newRow = dsPoliza.Tables("Poliza").NewRow

        '    newRow("NumMovimiento") = movimiento

        '    row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(3, "-")
        '    row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(7, "-")
        '    row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(11, "-")
        '    newRow("Cuenta") = row("CuentaIVAGASTOS")

        '    newRow("Nombre") = "IVA POR GASTOS" _
        '                       & vbCrLf & oAppContext.ApplicationConfiguration.IVA & "% IMP.S/COM." _
        '                       & vbCrLf & "POR EL CIERRE DE LOTE"

        '    newRow("Cargos") = IvaTC * oAppContext.ApplicationConfiguration.IVA

        '    Dim CargoComision As Double = IvaTC + newRow("Cargos")

        '    dsPoliza.Tables("Poliza").Rows.Add(newRow)
        '    dsPoliza.AcceptChanges()


        '    ''''CARGO POR COMISION
        '    movimiento += 1
        '    newRow = dsPoliza.Tables("Poliza").NewRow

        '    newRow("NumMovimiento") = movimiento

        '    newRow("Cuenta") = row("Cuenta")

        '    newRow("Nombre") = "AQUILES SERDAN REF " & row("Referencia") _
        '                    & vbCrLf & "CARGO POR COMISION" _
        '                    & vbCrLf & "POR EL CIERRE DE LOTE"

        '    newRow("Abonos") = CargoComision


        '    dsPoliza.Tables("Poliza").Rows.Add(newRow)
        '    dsPoliza.AcceptChanges()

        'Next


        '''''VentasTotales
        For Each row As DataRow In dsVentasTotales.Tables("Ventas").Rows
            movimiento += 1

            Dim newRow As DataRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("Cuenta") = CStr(row("Cuenta")).Insert(3, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(7, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(11, "-")
            newRow("Cuenta") = row("Cuenta")

            newRow("Nombre") = "VENTAS AQUILES SERDAN" _
                               & vbCrLf & "Fact. " & row("FolioFacturaInicial") & " - " & row("FolioFacturaFinal")

            newRow("Abonos") = row("Facturacion")

            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()




            ''''Impuestos
            movimiento += 1
            newRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("CuentaIVA") = CStr(row("CuentaIVA")).Insert(3, "-")
            row("CuentaIVA") = CStr(row("CuentaIVA")).Insert(7, "-")
            row("CuentaIVA") = CStr(row("CuentaIVA")).Insert(11, "-")
            newRow("Cuenta") = row("CuentaIVA")

            newRow("Nombre") = "IVA TRASLADADO" _
                               & vbCrLf & " 15% Imp. S/Vtas."

            'newRow("Abonos") = row("Facturacion") * 0.15
            newRow("Abonos") = row("Facturacion") * oAppContext.ApplicationConfiguration.IVA

            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()

        Next


        Me.DataSource = dsPoliza
        Me.DataMember = "Poliza"

        Me.txtNumMovimiento.DataField = "NumMovimiento"
        Me.txtCuenta.DataField = "Cuenta"
        Me.txtNombre.DataField = "Nombre"
        Me.txtCargos.DataField = "Cargos"
        Me.txtAbonos.DataField = "Abonos"


        Me.Label22.Text = "La información aquí presentada es real, generada de la operacion del dia de hoy " & _
        Fecha & ", realizada con el Marcador DXT. Por lo que de existir diferncias a cargos en los ingresos " & _
        "reportados acepto cubrir la cantidad mencionada en la cuenta contable diferencias. El fondo de la caja " & _
        "cerro con $ " & fondo

    End Sub

    Private dsPoliza As DataSet

    Public Sub VentasTarjetas(ByVal dsVentasTarjetas As DataSet, ByRef movimiento As Integer)
        '''''VentasTarjetas
        For Each row As DataRow In dsVentasTarjetas.Tables("Ventas").Rows
            movimiento += 1

            Dim newRow As DataRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("Cuenta") = CStr(row("Cuenta")).Insert(3, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(7, "-")
            row("Cuenta") = CStr(row("Cuenta")).Insert(11, "-")
            newRow("Cuenta") = row("Cuenta")

            newRow("Nombre") = "AQUILES SERDAN REF " & row("Referencia") _
                               & vbCrLf & "POR EL CIERRE DE LOTE"

            newRow("Cargos") = row("VTarjetas")

            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()


            ''''Iva Comision Tarjeta
            movimiento += 1
            newRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(3, "-")
            row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(7, "-")
            row("CuentaTIVA") = CStr(row("CuentaTIVA")).Insert(11, "-")
            newRow("Cuenta") = row("CuentaTIVA")

            newRow("Nombre") = "TARJETAS DE CREDITO" _
                               & vbCrLf & "COM. " & oAppContext.ApplicationConfiguration.ComisionTarjetaCredito & "% S/T. C." _
                               & vbCrLf & "POR EL CIERRE DE LOTE"

            newRow("Cargos") = row("VTarjetas") * (oAppContext.ApplicationConfiguration.ComisionTarjetaCredito / 100)

            Dim IvaTC As Decimal = newRow("Cargos")

            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()

            ''''Iva por gastos
            movimiento += 1
            newRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(3, "-")
            row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(7, "-")
            row("CuentaIVAGASTOS") = CStr(row("CuentaIVAGASTOS")).Insert(11, "-")
            newRow("Cuenta") = row("CuentaIVAGASTOS")

            newRow("Nombre") = "IVA POR GASTOS" _
                               & vbCrLf & oAppContext.ApplicationConfiguration.IVA & "% IMP.S/COM." _
                               & vbCrLf & "POR EL CIERRE DE LOTE"

            newRow("Cargos") = IvaTC * oAppContext.ApplicationConfiguration.IVA

            Dim CargoComision As Double = IvaTC + newRow("Cargos")

            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()


            ''''CARGO POR COMISION
            movimiento += 1
            newRow = dsPoliza.Tables("Poliza").NewRow

            newRow("NumMovimiento") = movimiento

            newRow("Cuenta") = row("Cuenta")

            newRow("Nombre") = "AQUILES SERDAN REF " & row("Referencia") _
                            & vbCrLf & "CARGO POR COMISION" _
                            & vbCrLf & "POR EL CIERRE DE LOTE"

            newRow("Abonos") = CargoComision


            dsPoliza.Tables("Poliza").Rows.Add(newRow)
            dsPoliza.AcceptChanges()

        Next
    End Sub

    Public Sub CreateTable()

        dsPoliza = New DataSet("Poliza")
        Dim dtPoliza As New DataTable("Poliza")

        Dim dcNumMovimiento As New DataColumn
        With dcNumMovimiento
            .ColumnName = "NumMovimiento"
            .Caption = "Número Movimiento"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcCuenta As New DataColumn
        With dcCuenta
            .ColumnName = "Cuenta"
            .Caption = "Cuenta"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcNombre As New DataColumn
        With dcNombre
            .ColumnName = "Nombre"
            .Caption = "Nombre"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCargos As New DataColumn
        With dcCargos
            .ColumnName = "Cargos"
            .Caption = "Cargos"
            .DataType = GetType(System.Decimal)
            '.DefaultValue = 0.0
        End With

        Dim dcAbonos As New DataColumn
        With dcAbonos
            .ColumnName = "Abonos"
            .Caption = "Abonos"
            .DataType = GetType(System.Decimal)
            '.DefaultValue = 0.0
        End With



        With dtPoliza.Columns
            .Add(dcNumMovimiento)
            .Add(dcCuenta)
            .Add(dcNombre)
            .Add(dcCargos)
            .Add(dcAbonos)
        End With

        dsPoliza.Tables.Add(dtPoliza)
        dsPoliza.AcceptChanges()
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
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Label9 As Label = Nothing
    Private txtFechaPoliza As TextBox = Nothing
    Private txtDireccion As TextBox = Nothing
    Private txtRegFed As TextBox = Nothing
    Private txtRegEstatal As TextBox = Nothing
    Private txtCodPostal As TextBox = Nothing
    Private txtRegCamara As TextBox = Nothing
    Private Label10 As Label = Nothing
    Private Label11 As Label = Nothing
    Private Label12 As Label = Nothing
    Private Label13 As Label = Nothing
    Private Label14 As Label = Nothing
    Private Label15 As Label = Nothing
    Private Label16 As Label = Nothing
    Private Label17 As Label = Nothing
    Private Label18 As Label = Nothing
    Private Label19 As Label = Nothing
    Private txtFechaPolizaGH As TextBox = Nothing
    Private Label20 As Label = Nothing
    Private txtCajaSucursal As TextBox = Nothing
    Private Line3 As Line = Nothing
    Private Line4 As Line = Nothing
    Private txtNumMovimiento As TextBox = Nothing
    Private txtCuenta As TextBox = Nothing
    Private txtNombre As TextBox = Nothing
    Private txtCargos As TextBox = Nothing
    Private txtAbonos As TextBox = Nothing
    Private txtTCargos As TextBox = Nothing
    Private txtTAbonos As TextBox = Nothing
    Private Label21 As Label = Nothing
    Private Line5 As Line = Nothing
    Private Label22 As Label = Nothing
    Private Label23 As Label = Nothing
    Private Label24 As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line2 As Line = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPoliza))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaPoliza = New DataDynamics.ActiveReports.TextBox()
            Me.txtDireccion = New DataDynamics.ActiveReports.TextBox()
            Me.txtRegFed = New DataDynamics.ActiveReports.TextBox()
            Me.txtRegEstatal = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodPostal = New DataDynamics.ActiveReports.TextBox()
            Me.txtRegCamara = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaPolizaGH = New DataDynamics.ActiveReports.TextBox()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.txtCajaSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.txtNumMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.txtCuenta = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtCargos = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtTCargos = New DataDynamics.ActiveReports.TextBox()
            Me.txtTAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaPoliza,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDireccion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtRegFed,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtRegEstatal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodPostal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtRegCamara,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaPolizaGH,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCajaSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNumMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCuenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCargos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTCargos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNumMovimiento, Me.txtCuenta, Me.txtNombre, Me.txtCargos, Me.txtAbonos})
            Me.Detail.Height = 0.2291667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.txtFechaPoliza, Me.txtDireccion, Me.txtRegFed, Me.txtRegEstatal, Me.txtCodPostal, Me.txtRegCamara})
            Me.PageHeader.Height = 1.270833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label22, Me.Label23, Me.Label24, Me.Line1, Me.Line2})
            Me.PageFooter.Height = 1.5!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.txtFechaPolizaGH, Me.Label20, Me.txtCajaSucursal, Me.Line3, Me.Line4})
            Me.GroupHeader1.Height = 1!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTCargos, Me.txtTAbonos, Me.Label21, Me.Line5})
            Me.GroupFooter1.Height = 0.2076389!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.862205!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "COMERCIAL D'PORTENIS, S.A. DE C.V."
            Me.Label1.Top = 0.03937007!
            Me.Label1.Width = 2.677165!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.03937007!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Dirección:"
            Me.Label2.Top = 0.6692914!
            Me.Label2.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.01624016!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Reg. Fed.:"
            Me.Label3.Top = 0.9055118!
            Me.Label3.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 2.283465!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Reg. Estatal:"
            Me.Label6.Top = 0.9055118!
            Me.Label6.Width = 1!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 2.283465!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Codigo postal:"
            Me.Label7.Top = 0.6692914!
            Me.Label7.Width = 0.944882!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.055118!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Reg. Camara:"
            Me.Label8.Top = 0.6692914!
            Me.Label8.Width = 1!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.68504!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "Fecha:"
            Me.Label9.Top = 0.3149606!
            Me.Label9.Width = 0.4862203!
            '
            'txtFechaPoliza
            '
            Me.txtFechaPoliza.Height = 0.2!
            Me.txtFechaPoliza.Left = 5.27559!
            Me.txtFechaPoliza.Name = "txtFechaPoliza"
            Me.txtFechaPoliza.Text = "FechaPoliza"
            Me.txtFechaPoliza.Top = 0.3149606!
            Me.txtFechaPoliza.Width = 1!
            '
            'txtDireccion
            '
            Me.txtDireccion.Height = 0.2!
            Me.txtDireccion.Left = 1.125492!
            Me.txtDireccion.Name = "txtDireccion"
            Me.txtDireccion.Text = "txtDireccion"
            Me.txtDireccion.Top = 0.6530511!
            Me.txtDireccion.Width = 1!
            '
            'txtRegFed
            '
            Me.txtRegFed.Height = 0.2!
            Me.txtRegFed.Left = 1.102362!
            Me.txtRegFed.Name = "txtRegFed"
            Me.txtRegFed.Text = "txtRegFed"
            Me.txtRegFed.Top = 0.9055118!
            Me.txtRegFed.Width = 1!
            '
            'txtRegEstatal
            '
            Me.txtRegEstatal.Height = 0.2!
            Me.txtRegEstatal.Left = 3.346457!
            Me.txtRegEstatal.Name = "txtRegEstatal"
            Me.txtRegEstatal.Text = "txtRegEstatal"
            Me.txtRegEstatal.Top = 0.9055118!
            Me.txtRegEstatal.Width = 1!
            '
            'txtCodPostal
            '
            Me.txtCodPostal.Height = 0.2!
            Me.txtCodPostal.Left = 3.307087!
            Me.txtCodPostal.Name = "txtCodPostal"
            Me.txtCodPostal.Text = "txtCodPostal"
            Me.txtCodPostal.Top = 0.6692914!
            Me.txtCodPostal.Width = 0.6692917!
            '
            'txtRegCamara
            '
            Me.txtRegCamara.Height = 0.2!
            Me.txtRegCamara.Left = 5.078741!
            Me.txtRegCamara.Name = "txtRegCamara"
            Me.txtRegCamara.Text = "txtRegCamara"
            Me.txtRegCamara.Top = 0.6692914!
            Me.txtRegCamara.Width = 1!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.0625!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "Fecha"
            Me.Label10.Top = 0.0625!
            Me.Label10.Width = 0.488681!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.03937006!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "No. Refer."
            Me.Label11.Top = 0.3149606!
            Me.Label11.Width = 0.6692914!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.875!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "Tipo"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 0.3597441!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 1.248031!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = ""
            Me.Label13.Text = "Cuenta"
            Me.Label13.Top = 0.3149606!
            Me.Label13.Width = 0.511811!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 1.8125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Número Concepto"
            Me.Label14.Top = 0.0625!
            Me.Label14.Width = 1.23376!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 6!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = ""
            Me.Label15.Text = "Clase Diario"
            Me.Label15.Top = 0.0625!
            Me.Label15.Width = 0.8061021!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 4.133858!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = ""
            Me.Label16.Text = "Diario"
            Me.Label16.Top = 0.3149606!
            Me.Label16.Width = 0.3937011!
            '
            'Label17
            '
            Me.Label17.Height = 0.2!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 6.241142!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = ""
            Me.Label17.Text = "Abonos"
            Me.Label17.Top = 0.3149606!
            Me.Label17.Width = 0.5595472!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 5.02559!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = ""
            Me.Label18.Text = "Cargos"
            Me.Label18.Top = 0.3149606!
            Me.Label18.Width = 0.5044293!
            '
            'Label19
            '
            Me.Label19.Height = 0.2!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 3.161417!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = ""
            Me.Label19.Text = "Nombre"
            Me.Label19.Top = 0.3149606!
            Me.Label19.Width = 0.5511813!
            '
            'txtFechaPolizaGH
            '
            Me.txtFechaPolizaGH.Height = 0.2!
            Me.txtFechaPolizaGH.Left = 0!
            Me.txtFechaPolizaGH.Name = "txtFechaPolizaGH"
            Me.txtFechaPolizaGH.Text = "FechaPolizaGH"
            Me.txtFechaPolizaGH.Top = 0.7874014!
            Me.txtFechaPolizaGH.Width = 1!
            '
            'Label20
            '
            Me.Label20.Height = 0.2!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 1.174212!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = ""
            Me.Label20.Text = "Ingresos"
            Me.Label20.Top = 0.7874014!
            Me.Label20.Width = 0.5905513!
            '
            'txtCajaSucursal
            '
            Me.txtCajaSucursal.Height = 0.2!
            Me.txtCajaSucursal.Left = 1.992126!
            Me.txtCajaSucursal.Name = "txtCajaSucursal"
            Me.txtCajaSucursal.Text = "CajaSucursal"
            Me.txtCajaSucursal.Top = 0.7874014!
            Me.txtCajaSucursal.Width = 1!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0.03937053!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.6299213!
            Me.Line3.Width = 6.811024!
            Me.Line3.X1 = 6.850394!
            Me.Line3.X2 = 0.03937053!
            Me.Line3.Y1 = 0.6299213!
            Me.Line3.Y2 = 0.6299213!
            '
            'Line4
            '
            Me.Line4.Height = 0!
            Me.Line4.Left = 0.006944444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.006944418!
            Me.Line4.Width = 6.811023!
            Me.Line4.X1 = 6.817968!
            Me.Line4.X2 = 0.006944444!
            Me.Line4.Y1 = 0.006944418!
            Me.Line4.Y2 = 0.006944418!
            '
            'txtNumMovimiento
            '
            Me.txtNumMovimiento.Height = 0.2!
            Me.txtNumMovimiento.Left = 0.03937007!
            Me.txtNumMovimiento.Name = "txtNumMovimiento"
            Me.txtNumMovimiento.Text = "txtNumMovimiento"
            Me.txtNumMovimiento.Top = 0!
            Me.txtNumMovimiento.Width = 0.7086611!
            '
            'txtCuenta
            '
            Me.txtCuenta.Height = 0.2!
            Me.txtCuenta.Left = 1.10187!
            Me.txtCuenta.Name = "txtCuenta"
            Me.txtCuenta.Text = "txtCuenta"
            Me.txtCuenta.Top = 0!
            Me.txtCuenta.Width = 1!
            '
            'txtNombre
            '
            Me.txtNombre.Height = 0.2!
            Me.txtNombre.Left = 2.22687!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Text = "txtNombre"
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 2.891239!
            '
            'txtCargos
            '
            Me.txtCargos.Height = 0.2!
            Me.txtCargos.Left = 4.77313!
            Me.txtCargos.Name = "txtCargos"
            Me.txtCargos.OutputFormat = resources.GetString("txtCargos.OutputFormat")
            Me.txtCargos.Style = "text-align: right"
            Me.txtCargos.Text = "txtCargos"
            Me.txtCargos.Top = 0!
            Me.txtCargos.Width = 0.9306104!
            '
            'txtAbonos
            '
            Me.txtAbonos.Height = 0.2!
            Me.txtAbonos.Left = 5.944882!
            Me.txtAbonos.Name = "txtAbonos"
            Me.txtAbonos.OutputFormat = resources.GetString("txtAbonos.OutputFormat")
            Me.txtAbonos.Style = "text-align: right"
            Me.txtAbonos.Text = "txtAbonos"
            Me.txtAbonos.Top = 0!
            Me.txtAbonos.Width = 0.8861548!
            '
            'txtTCargos
            '
            Me.txtTCargos.DataField = "Cargos"
            Me.txtTCargos.Height = 0.2!
            Me.txtTCargos.Left = 4.733759!
            Me.txtTCargos.Name = "txtTCargos"
            Me.txtTCargos.OutputFormat = resources.GetString("txtTCargos.OutputFormat")
            Me.txtTCargos.Style = "text-align: right"
            Me.txtTCargos.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTCargos.Text = "txtTCargos"
            Me.txtTCargos.Top = 0!
            Me.txtTCargos.Width = 1!
            '
            'txtTAbonos
            '
            Me.txtTAbonos.DataField = "Abonos"
            Me.txtTAbonos.Height = 0.2!
            Me.txtTAbonos.Left = 5.831201!
            Me.txtTAbonos.Name = "txtTAbonos"
            Me.txtTAbonos.OutputFormat = resources.GetString("txtTAbonos.OutputFormat")
            Me.txtTAbonos.Style = "text-align: right"
            Me.txtTAbonos.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTAbonos.Text = "txtTAbonos"
            Me.txtTAbonos.Top = 0!
            Me.txtTAbonos.Width = 1!
            '
            'Label21
            '
            Me.Label21.Height = 0.2!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 3.740158!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = ""
            Me.Label21.Text = "Total poliza"
            Me.Label21.Top = 0!
            Me.Label21.Width = 0.8267716!
            '
            'Line5
            '
            Me.Line5.Height = 0!
            Me.Line5.Left = 5.046315!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.006944444!
            Me.Line5.Width = 1.771653!
            Me.Line5.X1 = 5.046315!
            Me.Line5.X2 = 6.817968!
            Me.Line5.Y1 = 0.006944444!
            Me.Line5.Y2 = 0.006944444!
            '
            'Label22
            '
            Me.Label22.Height = 0.511811!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 0.07874014!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = ""
            Me.Label22.Text = resources.GetString("Label22.Text")
            Me.Label22.Top = 0.07874014!
            Me.Label22.Width = 6.692914!
            '
            'Label23
            '
            Me.Label23.Height = 0.2!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 0.1968503!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = ""
            Me.Label23.Text = "Reviso        :"
            Me.Label23.Top = 1.181102!
            Me.Label23.Width = 0.8267716!
            '
            'Label24
            '
            Me.Label24.Height = 0.2!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 0.1574803!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = ""
            Me.Label24.Text = "Responsable:"
            Me.Label24.Top = 0.9055118!
            Me.Label24.Width = 0.9055118!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 1.069937!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1.069937!
            Me.Line1.Width = 1.771653!
            Me.Line1.X1 = 2.84159!
            Me.Line1.X2 = 1.069937!
            Me.Line1.Y1 = 1.069937!
            Me.Line1.Y2 = 1.069937!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 1.069937!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.345527!
            Me.Line2.Width = 1.771653!
            Me.Line2.X1 = 2.841589!
            Me.Line2.X2 = 1.069937!
            Me.Line2.Y1 = 1.345527!
            Me.Line2.Y2 = 1.345527!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.09375!
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
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaPoliza,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDireccion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtRegFed,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtRegEstatal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodPostal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtRegCamara,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaPolizaGH,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCajaSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNumMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCuenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCargos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTCargos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region
End Class
