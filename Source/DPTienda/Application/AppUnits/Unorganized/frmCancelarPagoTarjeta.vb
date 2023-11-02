Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.IO
Imports System.Collections.Generic
Imports Pinpad

Public Class frmCancelarPagoTarjeta
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebNumTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgFormasPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarPagoTarjeta))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.dgFormasPago = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.dgFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.txtCVV2)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarj)
        Me.ExplorerBar1.Controls.Add(Me.dgFormasPago)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(520, 294)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(432, 176)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 11
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(200, 232)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(96, 32)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(200, 152)
        Me.txtCVV2.Name = "txtCVV2"
        Me.txtCVV2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCVV2.Size = New System.Drawing.Size(75, 22)
        Me.txtCVV2.TabIndex = 0
        Me.txtCVV2.Text = "123"
        Me.txtCVV2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCVV2.Visible = False
        Me.txtCVV2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = "0"
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(179, 16)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "CVV2                                 :"
        Me.Label16.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pase Tarjeta por la Lectora :"
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(200, 176)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(232, 22)
        Me.ebNumTarj.TabIndex = 1
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'dgFormasPago
        '
        Me.dgFormasPago.AllowCardSizing = False
        Me.dgFormasPago.AllowColumnDrag = False
        Me.dgFormasPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.dgFormasPago.DesignTimeLayout = GridEXLayout1
        Me.dgFormasPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgFormasPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgFormasPago.GroupByBoxVisible = False
        Me.dgFormasPago.Location = New System.Drawing.Point(8, 16)
        Me.dgFormasPago.Name = "dgFormasPago"
        Me.dgFormasPago.Size = New System.Drawing.Size(504, 120)
        Me.dgFormasPago.TabIndex = 2
        Me.dgFormasPago.TabStop = False
        Me.dgFormasPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCancelarPagoTarjeta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelarPagoTarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "...::: Cancelar Pago Tarjeta :::..."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.dgFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private o_Factura As Factura
    Private o_Pedido As Pedidos
    Private m_EsSiHay As Boolean = False
    Dim oFacturaMgr As FacturaManager
    Dim bolCargoeHub As Boolean
    Private deslizada As Boolean = False
    Public dsFormasPago As DataSet
    Public EsFactura As Boolean = True

    Public Property oFactura() As Factura
        Get
            Return o_Factura
        End Get
        Set(ByVal Value As Factura)
            o_Factura = Value
        End Set
    End Property

    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 07/07/2017: Se carga en caso de que cancele tarjetas de pedidos del si hay
    '--------------------------------------------------------------------------------------

    Public Property oPedido As Pedidos
        Get
            Return o_Pedido
        End Get
        Set(value As Pedidos)
            o_Pedido = value
        End Set
    End Property

    Public Property EsSiHay As Boolean
        Get
            Return m_EsSiHay
        End Get
        Set(value As Boolean)
            m_EsSiHay = value
        End Set
    End Property

    '    Private Sub ebNumTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarj.KeyDown
    '        If e.KeyCode = Keys.Enter Then

    '            If Trim(Me.txtCVV2.Text) = "" Then
    '                MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
    '                Me.txtCVV2.Focus()
    '                Exit Sub
    '            End If

    '            Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub

    '            Dim i As Long
    '            Dim mSalida As String
    '            Dim mAmount As Double           '4    
    '            Dim mPOSEntry As String         '22        
    '            Dim mTrack2 As String           '35        
    '            Dim mRespose As String          '61

    '            Dim mE2 As String
    '            Dim mHRecordType As String
    '            Dim mHTerm As String
    '            Dim mHCajero As String
    '            Dim mHTienda As String
    '            Dim mHTicket As String
    '            Dim mHTrack2 As String
    '            Dim mHImporte As String
    '            Dim mHMeses As String
    '            Dim mHSkip As String
    '            Dim mHCVV2 As String
    '            Dim mHCargo As String
    '            Dim mHCredito As String
    '            Dim mHFijo As String
    '            Dim mCard As String
    '            Dim mAutorizacion As String
    '            Dim Mensaje As String
    '            Dim Mensaje46 As String
    '            Dim mRespcode As String
    '            Dim mFile As Integer

    '            Dim mDummy As String
    '            Dim mCarPun As String
    '            Dim mCrePun As String
    '            Dim mCarDin As String
    '            Dim mCreDin As String
    '            Dim mNumCia As String
    '            Dim mNumPlan As String
    '            Dim mOperacion As String
    '            Dim mAfiliacion As String
    '            Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
    '            Dim mRespuesta As String
    '            Dim mComentario As String

    '            'Ocultamos informacion de la tarjeta , para dejar unicamente el numero
    '            Dim strTrack() As String = ebNumTarj.Text.Split(";")
    '            Dim strNombre As String

    '            strNombre = GetName(strTrack(0))
    '            'If InStr(strTrack(0), "¨") > 0 Then
    '            '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("¨", 19) - 18)
    '            '    strNombre = strNombre.Replace("¨", "").Trim
    '            'Else
    '            '    strNombre = strTrack(0).Substring(18, strTrack(0).IndexOf("^", 19) - 18)
    '            '    strNombre = strNombre.Replace("^", "").Trim
    '            'End If
    '            ebNumTarj.Text = strTrack(1)

    '            Dim intPosition As Integer = 0
    '            Dim strVencimiento As String = String.Empty
    '            Dim strPromocion As String = String.Empty
    '            Dim strNum As String = (ebNumTarj.Text).Replace(";", "")
    '            intPosition = InStr(strNum, "=")
    '            strVencimiento = Mid(strNum, intPosition + 3, 2) & "/" & Mid(strNum, intPosition + 1, 2)
    '            strNum = Mid(strNum, 1, intPosition - 1)


    '            mTrack2 = (ebNumTarj.Text).Replace(";", "")
    '            mTrack2 = (mTrack2).Replace("?", "")

    '            Dim dvTarjeta As New DataView(dsFormasPago.Tables(0), "NumeroTarjeta ='" & strNum & "'", "DPValeID", DataViewRowState.CurrentRows)

    '            If dvTarjeta.Count > 0 Then

    '                mCVV2 = dvTarjeta(0)("NumeroAutorizacion")
    '                mHTicket = oAppSAPConfig.Ticket & "|" & dvTarjeta(0)("DPValeID")

    '                'mSalida = x.PagoTarjeta(o_Factura.CodAlmacen, _
    '                '                        o_Factura.CodCaja, _
    '                '                        oFactura.CodVendedor, _
    '                '                        "010000", 902, mTrack2, _
    '                '                        CDbl(dvTarjeta(0)("MontoPago")), _
    '                '                        dvTarjeta(0)("DPValeID"), _
    '                '                        mComentario, _
    '                '                        mRespuesta, _
    '                '                        0, _
    '                '                        0, _
    '                '                        mCVV2)

    '                mSalida = x.PagoTarjeta( _
    '                                        o_Factura.CodAlmacen, _
    '                                        o_Factura.CodCaja, _
    '                                        oFactura.CodVendedor, _
    '                                        "010000", 902, mTrack2, _
    '                                        CDbl(dvTarjeta(0)("MontoPago")), _
    '                                        mHTicket, _
    '                                        mComentario, _
    '                                        mRespuesta, _
    '                                        0, _
    '                                        0, _
    '                                        mCVV2)

    '                mDummy = mSalida
    '                Do While Len(mDummy) > 0
    '                    mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                    mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                    If InStr(mRespose, "38==") > 0 Then
    '                        mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
    '                    End If
    '                    If InStr(mRespose, "39==") > 0 Then
    '                        mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                    End If
    '                    If InStr(mRespose, "43==") > 0 Then
    '                        Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                        If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                    End If
    '                    If InStr(mRespose, "46==") > 0 Then
    '                        Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                        Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
    '                    End If
    '                    If InStr(mRespose, "48==") > 0 Then
    '                        mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
    '                    End If
    '                Loop
    '                If mOperacion = "000001" Then
    '                    If mAutorizacion > 1 Then
    '                        Mid$(mHFijo, 4, 1) = "1"
    '                    End If
    '                    While InStr(Mensaje46, vbCrLf) > 0
    '                        mDummy = Mensaje46.Substring(0, InStr(Mensaje46, vbCrLf) - 1)
    '                        Mensaje46 = Mensaje46.Substring(InStr(Mensaje46, vbCrLf) + 1, Len(Mensaje46) - InStr(Mensaje46, vbCrLf) - 1)
    '                    End While
    '                Else
    '                    mDummy = mHFijo
    '                    If mOperacion = "000002" Then
    '                        mDummy = mDummy & mRespcode & mAutorizacion
    '                        mDummy = mDummy & Mensaje.Substring(0, 40)
    '                        If Len(Mensaje) < 40 Then
    '                            mDummy = mDummy & Space(40 - Len(Mensaje))
    '                        End If
    '                    End If
    '                    If mOperacion = "000002" Then
    '                        mDummy = mDummy & Mensaje46.Substring(0, 20)
    '                        If Len(Mensaje46) < 20 Then
    '                            mDummy = mDummy & Space(20 - Len(Mensaje46))
    '                        End If
    '                        mDummy = mDummy & mAfiliacion
    '                    Else
    '                        mDummy = mDummy & Mensaje46
    '                    End If

    '                End If

    '                If mRespcode = "00" AndAlso Trim(mAfiliacion) <> "" Then 'AndAlso Trim(mAutorizacion) <> "" Then
    '                    'Transaccion Exitosa

    '                    Dim strBanco As String
    '                    Mensaje = UCase(Mensaje)
    '                    If InStr(Mensaje, "BANAMEX") > 0 Then
    '                        strBanco = "BANAMEX"
    '                    ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
    '                        strBanco = "BANCOMER"
    '                    ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
    '                        strBanco = "SANTANDER"
    '                    End If

    '                    If InStr(mSalida, "6 MESES") > 0 Then
    '                        strPromocion = "6 Meses Sin Intereses"
    '                    ElseIf InStr(mSalida, "3 MESES") > 0 Then
    '                        strPromocion = "3 Meses Sin Intereses"
    '                    ElseIf InStr(mSalida, "9 MESES") > 0 Then
    '                        strPromocion = "9 Meses Sin Intereses"
    '                    End If

    '                    MsgBox("Transacción Exitosa." & vbCrLf & "Preparar Miniprinter.", MsgBoxStyle.Information, "DPTienda")

    '                    ''''I. Actualizamos Ticket.
    '                    Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    '                    Dim oSApReader As New SapConfigReader(strConfigurationFile)
    '                    oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
    '                    oSApReader.SaveSettings(oAppSAPConfig)

    '                    Dim bolReimprimir As Boolean = False

    'Reimprimir:

    '                    Select Case strBanco

    '                        Case "BANAMEX"
    'Imprime_Banamex:
    '                            'Original Banco
    '                            Dim oARReporte As New rptTicketBANAMEX(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
    '                                                    dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", strNombre, oFactura.CodVendedor, _
    '                                                                                            mAfiliacion, strBanco, "ORIGINAL BANCO")

    '                            oARReporte.Document.Name = "Cancelación Tarjeta de Crédito"
    '                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                            oARReporte.Run()
    '                            oARReporte.Document.Print(False, False)

    '                            'COPIA CLIENTE
    '                            Dim oARReporteC As New rptTicketBANAMEX(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
    '                                                    dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", strNombre, oFactura.CodVendedor, _
    '                                                                    mAfiliacion, strBanco, "COPIA CLIENTE")
    '                            oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
    '                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                            oARReporteC.Run()
    '                            oARReporteC.Document.Print(False, False)


    '                        Case "BANCOMER"

    '                            'Original Banco
    '                            Dim oARReporte As New rptTicketBancomer(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
    '                                                                    dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", _
    '                                                                    strNombre, oFactura.CodVendedor, mAfiliacion, strBanco, "ORIGINAL BANCO", _
    '                                                                    mPOSEntry, True, True)
    '                            oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                            oARReporte.Run()
    '                            oARReporte.Document.Print(False, False)

    '                            'Copia Cliente
    '                            Dim oARReporteC As New rptTicketBancomer(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
    '                                                                     dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", _
    '                                                                     strNombre, oFactura.CodVendedor, mAfiliacion, strBanco, "COPIA CLIENTE", _
    '                                                                     mPOSEntry, True, True)
    '                            oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
    '                            oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                            oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                            oARReporteC.Run()
    '                            oARReporteC.Document.Print(False, False)

    '                        Case Else

    '                            GoTo Imprime_Banamex

    '                    End Select

    '                    If bolReimprimir = False Then
    '                        If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '                            bolReimprimir = True
    '                            GoTo Reimprimir
    '                        End If
    '                    End If

    '                    Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)
    '                    oFacturaFormasPago.FacturaFormaPagoID = dvTarjeta(0)("FormaPagoID")
    '                    oFacturaFormasPago.RecordStatus = False
    '                    oFacturaFormasPago.Update()

    '                    dvTarjeta(0).Delete()
    '                    dsFormasPago.AcceptChanges()

    '                    Me.ebNumTarj.Text = ""
    '                    Me.txtCVV2.Text = ""
    '                    Me.txtCVV2.Focus()

    '                    If dsFormasPago.Tables(0).Rows.Count <= 0 Then
    '                        bolCargoeHub = False
    '                        Me.DialogResult = DialogResult.OK
    '                    Else
    '                        bolCargoeHub = True
    '                    End If

    '                Else
    '                    'Transaccion Rechazada

    '                    'MsgBox("Transacción Rechazada", MsgBoxStyle.Information, "DPTienda")

    '                    If Trim(mRespcode) <> "00" Then

    '                        MsgBox("Transacción Rechazada." & Microsoft.VisualBasic.vbCrLf & _
    '                        mSalida, MsgBoxStyle.Exclamation, "DPTienda")

    '                    ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

    '                        MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
    '                               " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                               MsgBoxStyle.Exclamation, "DPTienda")

    '                    ElseIf Trim(mAutorizacion) = "" Then

    '                        MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
    '                               Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                               MsgBoxStyle.Exclamation, "DPTienda")

    '                    ElseIf Trim(mAfiliacion) = "" Then

    '                        MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
    '                               Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                               MsgBoxStyle.Exclamation, "DPTienda")

    '                    End If

    '                    Me.ebNumTarj.Text = ""
    '                    Me.txtCVV2.Text = ""
    '                    Me.txtCVV2.Focus()

    '                End If

    '            Else
    '                MessageBox.Show("La tarjeta no fue utilizada en esta Venta. Verifique", "Validar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If

    '        End If
    '    End Sub

    Private Sub GenerarArchivoMonto(ByVal Ruta As String, ByVal monto As String)

        Dim oStreamW As StreamWriter

        oStreamW = New StreamWriter(Ruta)

        oStreamW.Write(monto)

        oStreamW.Close()

    End Sub

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.ASCII)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Function LeerCampo55(ByVal Ruta As String) As String

        Dim oStreamR As StreamReader
        Dim strContenido As String = ""

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.UTF8)

        strContenido = oStreamR.ReadToEnd

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub AutorizarCargoTarjeta()

        'If Trim(Me.txtCVV2.Text) = "" Then
        '    MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
        '    Me.txtCVV2.Focus()
        '    Exit Sub
        'End If
        Dim tarjeta As String, cliente As String, venc As String
        '--------------------------------------------------------------------
        'JNAVA (04.03.2015): Revisamos si hay pagos de DP CARD
        '--------------------------------------------------------------------
        Dim dpCard As New DataView(dsFormasPago.Tables(0), "CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
        If dpCard.Count > 0 Then

            '----------------------------------------------------------------------------------
            'JNAVA (20.04.2015): Si la tarjeta ya fue digitada...
            '-----------------------------------------------------------------------------------
            If Me.ebNumTarj.Text.Trim <> "" Then
                '----------------------------------------------------------------------------------
                'JNAVA (20.04.2015): Si no fue digitada, seteamo
                '-----------------------------------------------------------------------------------
                tarjeta = Me.ebNumTarj.Text.Trim
                cliente = ""
                venc = ""
            Else
                '----------------------------------------------------------------------------------
                'JNAVA (04.03.2015): Obtenemos los datos de la tarjeta DP Card
                '-----------------------------------------------------------------------------------
                LeerDPCard(tarjeta, cliente, venc)
                dpCard = Nothing
            End If

            '----------------------------------------------------------------------------------
            'JNAVA (04.03.2015): Revisamos si hay pagos de DP CARD para la tarjeta lecturada
            '-----------------------------------------------------------------------------------
            dpCard = New DataView(dsFormasPago.Tables(0), "NumeroTarjeta ='" & tarjeta & "' AND CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
            If dpCard.Count > 0 Then
                For Each oRowV As DataRowView In dpCard
                    CancelarPagoKarum(oRowV.Row, cliente, venc)
                    Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)
                    oFacturaFormasPago.FacturaFormaPagoID = CInt(oRowV("FormaPagoID"))
                    oFacturaFormasPago.RecordStatus = False
                    oFacturaFormasPago.Update()
                Next

                'For Each row As DataRow In dpCard.Table.Rows
                '    CancelarPagoKarum(row, cliente, venc)
                '    Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)
                '    oFacturaFormasPago.FacturaFormaPagoID = CInt(row("FormaPagoID"))
                '    oFacturaFormasPago.RecordStatus = False
                '    oFacturaFormasPago.Update()
                'Next

                Dim i As Integer
ReCount:
                i = 0
                For i = 0 To dpCard.Count - 1
                    dpCard(i).Delete()
                    '----------------------------------------------------------------------------------
                    'JNAVA (04.03.2015): Eliminamos los registros de los pagos de DPCard
                    '-----------------------------------------------------------------------------------
                    If dpCard.Count > 0 Then
                        GoTo ReCount
                    End If
                Next
                dsFormasPago.AcceptChanges()

                Me.ebNumTarj.Text = ""
                Me.txtCVV2.Text = ""
                Me.txtCVV2.Focus()
                Dim pagosDPCA As New DataView(dsFormasPago.Tables(0), "CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
                If pagosDPCA.Count = 0 Then
                    Me.ebNumTarj.ReadOnly = True
                End If
                If dsFormasPago.Tables(0).Rows.Count <= 0 Then
                    bolCargoeHub = False
                    Me.DialogResult = DialogResult.OK
                Else
                    bolCargoeHub = True
                End If
                If dsFormasPago.Tables(0).Rows.Count > 0 Then
                    dgFormasPago.Col = 0
                    dgFormasPago.Row = 0
                End If
            Else

                '----------------------------------------------------------------------------------
                'JNAVA (20.04.2015): Si no hay cargos con la tarjeta deslizada, no continua
                '-----------------------------------------------------------------------------------
                Me.ebNumTarj.Text = ""
                Exit Sub

            End If
        Else
            '------------------------------------------------------------------------------------------
            'FLIZARRAGA 16/01/2017: Configuración para pagos Banamex
            '------------------------------------------------------------------------------------------
            If oConfigCierreFI.PagosBanamex Then
                If CancelarPagoBanamex() Then
                    Dim row As DataRowView = CType(dgFormasPago.GetRow().DataRow, DataRowView)
                    Dim numSeg As Integer = CInt(row("DPValeID"))
                    Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)

                    If EsFactura Then
                        oFacturaFormasPago.FacturaFormaPagoID = row("FormaPagoID")
                        oFacturaFormasPago.RecordStatus = False
                        oFacturaFormasPago.Update()
                    End If
                  
                    Dim dvTarjeta As New DataView(dsFormasPago.Tables(0), "FormaPagoID ='" & CStr(oFacturaFormasPago.FacturaFormaPagoID) & "'", "DPValeID", DataViewRowState.CurrentRows)
                    dvTarjeta(0).Delete()
                    dsFormasPago.AcceptChanges()

                    Me.ebNumTarj.Text = ""
                    Me.txtCVV2.Text = ""
                    Me.txtCVV2.Focus()

                    If dsFormasPago.Tables(0).Rows.Count <= 0 Then
                        bolCargoeHub = False
                        Me.DialogResult = DialogResult.OK
                    Else
                        bolCargoeHub = True
                    End If
                End If
            Else
1:              Dim Ruta As String = "C:\LecturaTarjeta.txt"
2:              Dim strDatosEMV As String = ""

3:              Dim Datos() As String

4:              If File.Exists(Ruta) Then File.Delete(Ruta)

5:              Dim oApp As Process
6:              Dim oProcesos() As Process
7:              oProcesos = Process.GetProcessesByName("eHubEMV")
8:              For Each oApp In oProcesos
9:                  oApp.CloseMainWindow()
10:                 oApp.WaitForExit()
                Next

11:             Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

12:             If File.Exists(Ruta) Then
13:                 Datos = LeerArchivoTarjeta(Ruta)
14:                 File.Delete(Ruta)
                Else
15:                 Me.ebNumTarj.Text = ""
16:                 Exit Sub
                End If

17:             Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub

18:             Dim i As Long
19:             Dim mSalida As String
20:             Dim mAmount As Double           '4    
21:             Dim mPOSEntry As String         '22        
22:             Dim mTrack2 As String           '35        
23:             Dim mRespose As String          '61

24:             Dim mE2 As String
25:             Dim mHRecordType As String
26:             Dim mHTerm As String
27:             Dim mHCajero As String
28:             Dim mHTienda As String
29:             Dim mHTicket As String
30:             Dim mHTrack2 As String
31:             Dim mHImporte As String
32:             Dim mHMeses As String
33:             Dim mHSkip As String
34:             Dim mHCVV2 As String
35:             Dim mHCargo As String
36:             Dim mHCredito As String
37:             Dim mHFijo As String
38:             Dim mCard As String
39:             Dim mAutorizacion As String
40:             Dim Mensaje As String
41:             Dim Mensaje46 As String
42:             Dim mRespcode As String
43:             Dim mFile As Integer

44:             Dim mDummy As String
45:             Dim mCarPun As String
46:             Dim mCrePun As String
47:             Dim mCarDin As String
48:             Dim mCreDin As String
49:             Dim mNumCia As String
50:             Dim mNumPlan As String = "00"
51:             Dim mOperacion As String
52:             Dim mAfiliacion As String
53:             Dim mCVV2 As String = Trim(Me.txtCVV2.Text)
54:             Dim mRespuesta As String
55:             Dim mComentario As String
56:             Dim strNombre As String
57:             Dim strCriptograma As String = ""
58:             Dim strCardSN As String = ""
59:             Dim mFirma As String = ""
60:             Dim mEmisor As String = ""
61:             Dim mLote As String = ""
62:             Dim mSubtechTermID As String = ""
63:             Dim mTrace As String = ""
64:             Dim mTrnID As String = ""

65:             Me.ebNumTarj.Text = Datos(0)
66:             strNombre = Datos(1)
67:             strCardSN = Datos(4)
68:             strCriptograma = Datos(5)
69:             mFirma = Datos(6)

70:             Dim intPosition As Integer = 0
71:             Dim strVencimiento As String = ""
72:             Dim strPromocion As String = ""
73:             Dim strNum As String = (ebNumTarj.Text).Replace(";", "")
74:             intPosition = InStr(strNum, "=")
75:             strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
76:             strNum = Mid(strNum, 1, intPosition - 1)
77:             mPOSEntry = Datos(3) & "1"

78:             mTrack2 = (ebNumTarj.Text).Replace(";", "")
79:             mTrack2 = (mTrack2).Replace("?", "")
80:             If mTrack2.Length > 37 Then mTrack2 = mTrack2.Substring(0, 37)

81:             Dim dvTarjeta As New DataView(dsFormasPago.Tables(0), "NumeroTarjeta ='" & strNum & "'", "DPValeID", DataViewRowState.CurrentRows)

82:             If dvTarjeta.Count > 0 Then

83:                 mCVV2 = dvTarjeta(0)("NumeroAutorizacion")
84:                 mHTicket = oAppSAPConfig.Ticket & "|" & dvTarjeta(0)("DPValeID")
                    mNumPlan = dvTarjeta(0)("id_num_promo")
                    mNumPlan = mNumPlan.PadLeft(2, "0")
                    Dim codVendedor As String = ""
                    Dim codAlmacen As String = ""
                    Dim codCaja As String = ""
                    If EsSiHay Then
                        codVendedor = oPedido.CodVendedor.Substring(o_Factura.CodVendedor.Length - 6, 6)
                        codAlmacen = oPedido.CodAlmacen
                        codCaja = oPedido.CodCaja
                    Else
                        codVendedor = o_Factura.CodVendedor.Substring(o_Factura.CodVendedor.Length - 6, 6)
                        codAlmacen = o_Factura.CodAlmacen
                        codCaja = o_Factura.CodCaja
                    End If
85:                 mSalida = x.PagoTarjeta( _
                                codAlmacen, _
                                codCaja, _
                                codVendedor, _
                                "010000", mPOSEntry, mTrack2, _
                                CDbl(dvTarjeta(0)("MontoPago")), _
                                mHTicket, _
                                mComentario, _
                                mRespuesta, _
                                strCardSN, _
                                strDatosEMV, _
                                mNumPlan, _
                                "00", _
                                mCVV2)

86:                 mHTicket = ""
87:                 mDummy = mSalida
88:                 Do While Len(mDummy) > 0
89:                     mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
90:                     mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
91:                     If InStr(mRespose, "11==") > 0 Then
92:                         mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
93:                     If InStr(mRespose, "38==") > 0 Then
94:                         mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
95:                     End If
                        If InStr(mRespose, "39==") > 0 Then
                            mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                        End If
                        If InStr(mRespose, "43==") > 0 Then
                            Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
                        End If
                        If InStr(mRespose, "46==") > 0 Then
                            Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
                            Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
                        End If
                        If InStr(mRespose, "48==") > 0 Then
                            mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
                        End If
                        If InStr(mRespose, "61==") > 0 Then
                            mSubtechTermID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "62==") > 0 Then
                            mLote = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "63==") > 0 Then
                            mTrace = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                        If InStr(mRespose, "64==") > 0 Then
                            mTrnID = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
                        End If
                    Loop

                    ''''I. Actualizamos Ticket.
                    Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
                    Dim oSApReader As New SapConfigReader(strConfigurationFile)
                    oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
                    oSApReader.SaveSettings(oAppSAPConfig)
                    ''''F. Actualizamos Ticket.

                    If mRespcode = "00" AndAlso mAfiliacion.Trim <> "" Then 'AndAlso Trim(mAutorizacion) <> "" Then

                        Dim intPromo As Integer = 1

                        If InStr(mSalida, "6 MESES") > 0 Then
                            strPromocion = "6 Meses Sin Intereses"
                            intPromo = 6
                        ElseIf InStr(mSalida, "3 MESES") > 0 Then
                            strPromocion = "3 Meses Sin Intereses"
                            intPromo = 3
                        ElseIf InStr(mSalida, "9 MESES") > 0 Then
                            strPromocion = "9 Meses Sin Intereses"
                            intPromo = 9
                        ElseIf InStr(mSalida, "12 MESES") > 0 Then
                            strPromocion = "12 Meses Sin Intereses"
                            intPromo = 12
                        ElseIf InStr(mSalida, "18 MESES") > 0 Then
                            strPromocion = "18 Meses Sin Intereses"
                            intPromo = 18
                        Else
                            strPromocion = "Normal"
                            intPromo = 1
                        End If

                        Dim strBanco As String = ""

                        Mensaje = ""
                        Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper
                        'Mensaje = UCase(Mensaje)
                        If InStr(Mensaje, "BANAMEX") > 0 Then
                            strBanco = "BANAMEX"
                        ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                            strBanco = "BANCOMER"
                        ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                            strBanco = "SANTANDER"
                        End If

                        'Transaccion Exitosa

                        MsgBox("Transacción Exitosa." & vbCrLf & "Preparar Miniprinter.", MsgBoxStyle.Information, "DPTienda")

                        Dim bolReimprimir As Boolean = False
                        Dim oReportView As ReportViewerForm

Reimprimir:

                        Select Case strBanco

                            Case "BANAMEX"
Imprime_Banamex:
                                If InStr(mFirma, "TEL:") > 0 Then mFirma = mFirma.Substring(0, InStr(mFirma, "TEL:") - 1)
                                mFirma = mFirma & "".PadLeft(44, " ")
                                mFirma = mFirma & "".PadLeft(44, " ")
                                mFirma = mFirma & mSubtechTermID.Trim & "  "
                                mFirma = mFirma & mLote.PadLeft(6, "0") & "  "
                                mFirma = mFirma & CLng(mTrnID)
                                'Original Banco
                                Dim oARReporte As New rptTicketBANAMEX(CDbl(dvTarjeta(0)("MontoPago")), strNum, _
                                                                       strVencimiento, mAutorizacion, _
                                                                       strPromocion, "CANCELACION", strNombre, _
                                                                       codVendedor, mAfiliacion, strBanco, _
                                                                       "ORIGINAL BANCO", mFirma, strCriptograma, True, _
                                                                        mHTicket, mLote, mTrace, mSubtechTermID)
                                oARReporte.Document.Name = "Cancelación Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'COPIA CLIENTE
                                Dim oARReporteC As New rptTicketBANAMEX(CDbl(dvTarjeta(0)("MontoPago")), strNum, _
                                                                        strVencimiento, mAutorizacion, _
                                                                        strPromocion, "CANCELACION", strNombre, _
                                                                        codVendedor, mAfiliacion, strBanco, _
                                                                        "COPIA CLIENTE", mFirma, strCriptograma, True, _
                                                                        mHTicket, mLote, mTrace, mSubtechTermID)
                                oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporte
                                oReportView.Show()

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporteC
                                oReportView.Show()

                            Case "BANCOMER"

                                'Original Banco
                                Dim oARReporte As New rptTicketBancomer(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
                                                                        dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", _
                                                                        strNombre, codVendedor, mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                                        mPOSEntry, True, True, strCriptograma, mFirma)
                                oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporte.Run()
                                oARReporte.Document.Print(False, False)

                                'Copia Cliente
                                Dim oARReporteC As New rptTicketBancomer(CDbl(dvTarjeta(0)("MontoPago")), strNum, strVencimiento, _
                                                                         dvTarjeta(0)("NumeroAutorizacion"), strPromocion, "CANCELACION", _
                                                                         strNombre, codVendedor, mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                                         mPOSEntry, True, True, strCriptograma, mFirma)
                                oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                                oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                                oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                                oARReporteC.Run()
                                oARReporteC.Document.Print(False, False)

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporte
                                oReportView.Show()

                                oReportView = New ReportViewerForm
                                oReportView.Report = oARReporteC
                                oReportView.Show()

                            Case Else

                                GoTo Imprime_Banamex

                        End Select

                        If bolReimprimir = False Then
                            If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                bolReimprimir = True
                                GoTo Reimprimir
                            End If
                        End If

                        Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)
                        oFacturaFormasPago.FacturaFormaPagoID = dvTarjeta(0)("FormaPagoID")
                        oFacturaFormasPago.RecordStatus = False
                        oFacturaFormasPago.Update()

                        dvTarjeta(0).Delete()
                        dsFormasPago.AcceptChanges()

                        Me.ebNumTarj.Text = ""
                        Me.txtCVV2.Text = ""
                        Me.txtCVV2.Focus()

                        If dsFormasPago.Tables(0).Rows.Count <= 0 Then
                            bolCargoeHub = False
                            Me.DialogResult = DialogResult.OK
                        Else
                            bolCargoeHub = True
                        End If

                    Else
                        'Transaccion Rechazada

                        'MsgBox("Transacción Rechazada", MsgBoxStyle.Information, "DPTienda")

                        If Trim(mRespcode) <> "00" Then

                            MsgBox("Transacción Rechazada." & Microsoft.VisualBasic.vbCrLf & _
                            mSalida, MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
                                   " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAutorizacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        ElseIf Trim(mAfiliacion) = "" Then

                            MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
                                   Microsoft.VisualBasic.vbCrLf & mSalida, _
                                   MsgBoxStyle.Exclamation, "DPTienda")

                        End If

                        Me.ebNumTarj.Text = ""
                        Me.txtCVV2.Text = ""
                        Me.txtCVV2.Focus()

                    End If

                Else
                    MessageBox.Show("La tarjeta no fue utilizada en esta Venta. Verifique", "Validar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebNumTarj.Text = ""
                    Me.txtCVV2.Text = ""
                    Me.txtCVV2.Focus()
                End If

                If mPOSEntry.Trim = "051" Then
                    Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
                End If
            End If
        End If
    End Sub

    Private Sub frmCancelarPagoTarjeta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgFormasPago.DataSource = Me.dsFormasPago
        Me.dgFormasPago.DataMember = Me.dsFormasPago.Tables(0).TableName
        bolCargoeHub = False
        Dim dpCard As New DataView(dsFormasPago.Tables(0), "CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
        If dpCard.Count > 0 Then
            Me.ebNumTarj.ReadOnly = False
        End If
    End Sub

    Private Sub frmCancelarPagoTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If dsFormasPago.Tables(0).Rows.Count = 0 Then
            Me.Close()
        Else
            MessageBox.Show("Necesita cancelar todas las formas de pagos", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub frmCancelarPagoTarjeta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bolCargoeHub = True Then
            MsgBox("Es necesario cancelar todos los cargos con tarjeta de la factura.", MsgBoxStyle.Exclamation, "Dportenis Pro")
            e.Cancel = True
            Me.txtCVV2.Focus()
        End If
    End Sub

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        Me.btnLeerTarjeta.Enabled = False
        '----------------------------------------------------------------------------------
        'JNAVA (20.04.2015): Limpiamos el numero de tarjeta para que sea lecturada
        '-----------------------------------------------------------------------------------
        Me.ebNumTarj.Text = ""

        Me.AutorizarCargoTarjeta()

        Me.btnLeerTarjeta.Enabled = True
    End Sub

#Region "DPCard"

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/02/2015: Lecturar Tarjeta DPCard
    '--------------------------------------------------------------------------------------------------------------------------
    Private Sub LeerDPCard(ByRef numTar As String, ByRef cliente As String, ByRef vencimiento As String)
        Try
            'Leemos el numero de la tarjeta DP Card
            If oConfigCierreFI.PagosBanamex Then
                Dim pinpad As New Pinpad.Pinpad()
                Dim bin As String = ""
                'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
                Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
                If code.Trim() <> "10" AndAlso code.Trim() <> "40" Then
                    Dim Name As String = pinpad.getAppLabel()
                    bin = pinpad.getCardNumber(code)
                    cliente = Name
                    numTar = bin
                    deslizada = True
                Else
                    MessageBox.Show("Hubo un error al lecturar la tarjeta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 20/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            Else
                Dim oOtrosPagos As New OtrosPagos
                oOtrosPagos.LeerDatosDPCard(numTar, cliente, vencimiento)
                deslizada = True
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/02/2015: Metodo para cancelar la compra hecha con forma de pago Karum
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub CancelarPagoKarum(ByVal row As DataRow, Optional ByVal cliente As String = "", Optional ByVal vencimiento As String = "")
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim ws As New WSBroker("WS_KARUM", True)
        Dim param As New Hashtable
        Dim resultado As Hashtable
        Try
            param("NoTarjeta") = CStr(row("NumeroTarjeta"))
            param("Monto") = CDec(row("MontoPago"))
            Dim promo As Integer = CInt(row("Id_Num_Promo"))
            If promo < 10 Then
                param("Promocion") = CStr(row("Id_Num_Promo")).PadLeft(2, "0")
            Else
                param("Promocion") = CStr(row("Id_Num_Promo"))
            End If
            param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
            param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
            param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
            param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            If deslizada = True Then
                param("Tipo") = "00"
            Else
                param("Tipo") = "01"
            End If
            '----------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/07/2017: Se envia el detalle en caso de que sea pedido.
            '----------------------------------------------------------------------------------------------------------
            If EsSiHay Then
                Dim dtPedidoDetalle As DataTable = PedidoDetalles.GetPedidoDetallesDataTableByPedidoID(oPedido.PedidoID)
                resultado = ws.PurchaseVoid(param, dtPedidoDetalle)
            Else
                resultado = ws.PurchaseVoid(param, Me.oFactura.Detalle.Tables(0))
            End If
            '-----------------------------------------------------------------------
            ' JNAVA (25.02.2015): Validamos si se realizo la cancelacio o no
            '-----------------------------------------------------------------------
            Dim mensaje As String = ""
            If resultado.Count > 0 Then
                If resultado.ContainsKey("Success") = True Then
                    If CBool(resultado("Success")) = True Then
                        '-----------------------------------------------------------------------------
                        ' JNAVA (25.02.2015): Obtenemos datos de KARUM (para ticket y registros)
                        '-----------------------------------------------------------------------------
                        Dim htDatosDPC As Hashtable
                        htDatosDPC = resultado

                        '''PRUEBAS
                        'htDatosDPC("Transaccion") = "1234"
                        'htDatosDPC("Autorizacion") = Date.Now.ToString("ddMMyyyyHHmmss")
                        '''PRUEBAS

                        '-----------------------------------------------------------------------------
                        ' JNAVA (08.04.2015): El número de la tienda debe ser el de KARUM
                        '-----------------------------------------------------------------------------
                        htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                        htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                        htDatosDPC("Tarjeta") = CStr(row("NumeroTarjeta"))
                        htDatosDPC("Monto") = CDec(row("MontoPago"))
                        htDatosDPC("Vendedor") = oAppContext.Security.CurrentUser.Name 'Vendedor
                        'htDatosDPC("Linea") = "EN LINEA"

                        '-----------------------------------------------------------------------------
                        ' JNAVA (08.04.2015): Incluimos la promocion (Payment Plan)
                        '-----------------------------------------------------------------------------
                        htDatosDPC("PM") = CStr(row("Id_Num_Promo")).PadRight(2, "0")

                        '---------------------------------------------------------------------------------------
                        'JNAVA (13.03.2015): Especificamos si fue deslizada o Digitada para determinar nombre
                        '---------------------------------------------------------------------------------------
                        If deslizada = True Then
                            htDatosDPC("TarjetaHabiente") = cliente
                            htDatosDPC("Linea") = "DESLIZADA"
                        Else
                            htDatosDPC("TarjetaHabiente") = String.Empty
                            htDatosDPC("Linea") = "DIGITADA"
                        End If

                        '-----------------------------------------------------------
                        'FLIZARRAGA 30/10/2017: Consecutivo POS
                        '-----------------------------------------------------------
                        htDatosDPC("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")

                        '-----------------------------------------------------------------------------
                        ' JNAVA (25.02.2015): Imprimimos Vouchers de cancelacion de ventas
                        '-----------------------------------------------------------------------------
                        Dim oOtrosPagos As New OtrosPagos
                        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", False, True) 'COPIA P/TIENDA
                        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", True, True) 'COPIA P/CLIENTE
                    Else
                        EscribeLog(CStr(resultado("Mensaje")), "Cancelacion Pago Karum")
                        MessageBox.Show(CStr(resultado("Mensaje")), "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Throw New ApplicationException(CStr(resultado("Mensaje")))
                        Exit Sub
                    End If
                End If
            Else
                EscribeLog("El Webservice no envio respuesta", "Cancelación Pago Karum")
                MessageBox.Show("El WebService no envio respuesta", "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Throw New ApplicationException("El Webservice no envio respuesta")
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al cancelar el pago de tarjeta")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub ebNumTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumTarj.KeyDown
        If e.KeyCode = Keys.Enter Then
            deslizada = False
            Dim dpCard As New DataView(dsFormasPago.Tables(0), "CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
            If dpCard.Count > 0 Then
                CancelarTarjetas(dpCard)
            End If
        End If
    End Sub

    Private Sub CancelarTarjetas(ByVal dpCard As DataView)
        For Each oRowV As DataRowView In dpCard
            CancelarPagoKarum(oRowV.Row)
            Dim oFacturaFormasPago As New FacturaFormaPago(oAppContext)
            oFacturaFormasPago.FacturaFormaPagoID = CInt(oRowV("FormaPagoID"))
            oFacturaFormasPago.RecordStatus = False
            oFacturaFormasPago.Update()
        Next
        Dim i As Integer
ReCount:
        i = 0
        For i = 0 To dpCard.Count - 1
            dpCard(i).Delete()
            '----------------------------------------------------------------------------------
            'JNAVA (04.03.2015): Eliminamos los registros de los pagos de DPCard
            '-----------------------------------------------------------------------------------
            If dpCard.Count > 0 Then
                GoTo ReCount
            End If
        Next
        dsFormasPago.AcceptChanges()

        Me.ebNumTarj.Text = ""
        Me.txtCVV2.Text = ""
        Me.txtCVV2.Focus()
        If dsFormasPago.Tables(0).Rows.Count <= 0 Then
            bolCargoeHub = False
            Me.DialogResult = DialogResult.OK
        Else
            bolCargoeHub = True
        End If
        Dim pagosDPCA As New DataView(dsFormasPago.Tables(0), "CodFormasPago='DPCA'", "DPValeID", DataViewRowState.CurrentRows)
        If pagosDPCA.Count = 0 Then
            Me.ebNumTarj.ReadOnly = True
        End If
    End Sub

    Private Sub ebNumTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumTarj.Validating
        '--------------------------------------------------------------------------------------------
        'JNAVA (13.03.2015): Determinamos que la tarjeta no fue deslizada y continuamos
        '--------------------------------------------------------------------------------------------
        deslizada = False
        '--------------------------------------------------------------------------------------------
        'JNAVA (20.04.2015): Validamos si fue capturado el numero de tarjeta y autorizamos cancelacion
        '--------------------------------------------------------------------------------------------
        If Me.ebNumTarj.Text.Trim <> "" Then
            Me.AutorizarCargoTarjeta()
        End If

    End Sub

    Private Sub ebNumTarj_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebNumTarj.KeyPress
        ValidarNumeros(e)
    End Sub
#End Region

#Region "Pagos de Banamex"

    Private Function CancelarPagoBanamex() As Boolean
        Dim valido As Boolean = False
        If Not dgFormasPago.GetRow() Is Nothing Then
            Dim row As DataRowView = CType(dgFormasPago.GetRow().DataRow, DataRowView)
            Dim numSeg As Integer = CInt(row("DPValeID"))
            Dim pay As New uPaydll.upaydll()
            Dim response As String = pay.cancelacion(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, numSeg)
            If response.Trim() <> "" Then
                Dim lstResponse As Dictionary(Of String, Object) = GetResponse(response)
                '--------------------------------------------------------------------------------
                'FLIZARRAGA 18/01/2017: Se valida si paso la tarjeta
                '--------------------------------------------------------------------------------
                If CInt(lstResponse("trn_internal_respcode")) = -1 Then
                    'PrintVoucherBanamex(lstResponse, False)
                    'PrintVoucherBanamex(lstResponse, True)
                    valido = True
                    MessageBox.Show("El cargo fue cancelado exitosamente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(CStr(lstResponse("trn_msg_host")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("No has seleccionado ningun pago de Banamex", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Function GetResponse(ByVal response As String) As Dictionary(Of String, Object)
        Dim resultado As New Dictionary(Of String, Object)
        If response.Trim() <> "" Then
            Dim responses() As String = response.Split("|")
            Dim values() As String
            For Each answer As String In responses
                values = answer.Split("=")
                If values(0).Trim() <> "" Then
                    resultado(CStr(values(0)).Trim()) = values(1)
                End If
            Next
        End If
        Return resultado
    End Function

    Private Sub PrintVoucherBanamex(ByVal Datos As Dictionary(Of String, Object), ByVal EsCopia As Boolean)
        Dim oARReporte As New rptVoucherBanamex(Datos, EsCopia, False)
        oARReporte.Document.Name = "Voucher Banamex"

        If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

            oARReporte.PageSettings.PaperHeight = 7
            oARReporte.PageSettings.PaperWidth = 14
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
            oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
            oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        End If

        oARReporte.Run()

        'Dim oReportViewer As New ReportViewerForm
        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        '-----------------------------------------------------------------------------------
        ' Imprimimos voucher 
        '-----------------------------------------------------------------------------------
        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

End Class
