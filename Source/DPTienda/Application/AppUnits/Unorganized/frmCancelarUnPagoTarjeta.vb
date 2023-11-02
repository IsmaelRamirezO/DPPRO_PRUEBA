Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports System.IO

Public Class frmCancelarUnPagoTarjeta
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oBancoMgr = New CatalogoBancosManager(oAppContext)
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
    Friend WithEvents txtCVV2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTicket As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTicket As System.Windows.Forms.Label
    Friend WithEvents ebCodBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebNoTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoTarjeta As System.Windows.Forms.Label
    Friend WithEvents ebNoAutorizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoAutorizacion As System.Windows.Forms.Label
    Friend WithEvents ebBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarUnPagoTarjeta))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebNumTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.ebNoAutorizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoAutorizacion = New System.Windows.Forms.Label()
        Me.ebNoTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoTarjeta = New System.Windows.Forms.Label()
        Me.ebBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebTicket = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTicket = New System.Windows.Forms.Label()
        Me.txtCVV2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnLeerTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebNumTarj)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.ebNoAutorizacion)
        Me.ExplorerBar1.Controls.Add(Me.lblNoAutorizacion)
        Me.ExplorerBar1.Controls.Add(Me.ebNoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.lblNoTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.ebBanco)
        Me.ExplorerBar1.Controls.Add(Me.ebCodBanco)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebTicket)
        Me.ExplorerBar1.Controls.Add(Me.lblTicket)
        Me.ExplorerBar1.Controls.Add(Me.txtCVV2)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(394, 248)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(336, 144)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerTarjeta.TabIndex = 15
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "No. Tarjeta :"
        '
        'ebNumTarj
        '
        Me.ebNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumTarj.BackColor = System.Drawing.SystemColors.Info
        Me.ebNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumTarj.Location = New System.Drawing.Point(136, 144)
        Me.ebNumTarj.MaxLength = 200
        Me.ebNumTarj.Name = "ebNumTarj"
        Me.ebNumTarj.ReadOnly = True
        Me.ebNumTarj.Size = New System.Drawing.Size(200, 22)
        Me.ebNumTarj.TabIndex = 1
        Me.ebNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(136, 208)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(96, 32)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNoAutorizacion
        '
        Me.ebNoAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoAutorizacion.BackColor = System.Drawing.SystemColors.Info
        Me.ebNoAutorizacion.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoAutorizacion.Location = New System.Drawing.Point(136, 112)
        Me.ebNoAutorizacion.Name = "ebNoAutorizacion"
        Me.ebNoAutorizacion.ReadOnly = True
        Me.ebNoAutorizacion.Size = New System.Drawing.Size(168, 22)
        Me.ebNoAutorizacion.TabIndex = 13
        Me.ebNoAutorizacion.TabStop = False
        Me.ebNoAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoAutorizacion
        '
        Me.lblNoAutorizacion.AccessibleDescription = "0"
        Me.lblNoAutorizacion.AutoSize = True
        Me.lblNoAutorizacion.BackColor = System.Drawing.Color.Transparent
        Me.lblNoAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoAutorizacion.Location = New System.Drawing.Point(16, 112)
        Me.lblNoAutorizacion.Name = "lblNoAutorizacion"
        Me.lblNoAutorizacion.Size = New System.Drawing.Size(123, 16)
        Me.lblNoAutorizacion.TabIndex = 12
        Me.lblNoAutorizacion.Text = "No. Autorización :"
        '
        'ebNoTarjeta
        '
        Me.ebNoTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoTarjeta.BackColor = System.Drawing.SystemColors.Info
        Me.ebNoTarjeta.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoTarjeta.Location = New System.Drawing.Point(136, 80)
        Me.ebNoTarjeta.Name = "ebNoTarjeta"
        Me.ebNoTarjeta.ReadOnly = True
        Me.ebNoTarjeta.Size = New System.Drawing.Size(168, 22)
        Me.ebNoTarjeta.TabIndex = 11
        Me.ebNoTarjeta.TabStop = False
        Me.ebNoTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoTarjeta
        '
        Me.lblNoTarjeta.AccessibleDescription = "0"
        Me.lblNoTarjeta.AutoSize = True
        Me.lblNoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblNoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTarjeta.Location = New System.Drawing.Point(16, 80)
        Me.lblNoTarjeta.Name = "lblNoTarjeta"
        Me.lblNoTarjeta.Size = New System.Drawing.Size(88, 16)
        Me.lblNoTarjeta.TabIndex = 10
        Me.lblNoTarjeta.Text = "No. Tarjeta :"
        '
        'ebBanco
        '
        Me.ebBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebBanco.BackColor = System.Drawing.SystemColors.Info
        Me.ebBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebBanco.Location = New System.Drawing.Point(216, 48)
        Me.ebBanco.Name = "ebBanco"
        Me.ebBanco.ReadOnly = True
        Me.ebBanco.Size = New System.Drawing.Size(168, 22)
        Me.ebBanco.TabIndex = 9
        Me.ebBanco.TabStop = False
        Me.ebBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodBanco
        '
        Me.ebCodBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodBanco.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodBanco.Location = New System.Drawing.Point(136, 48)
        Me.ebCodBanco.Name = "ebCodBanco"
        Me.ebCodBanco.ReadOnly = True
        Me.ebCodBanco.Size = New System.Drawing.Size(75, 22)
        Me.ebCodBanco.TabIndex = 7
        Me.ebCodBanco.TabStop = False
        Me.ebCodBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = "0"
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Banco :"
        '
        'ebTicket
        '
        Me.ebTicket.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTicket.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTicket.BackColor = System.Drawing.SystemColors.Info
        Me.ebTicket.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTicket.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTicket.Location = New System.Drawing.Point(136, 16)
        Me.ebTicket.Name = "ebTicket"
        Me.ebTicket.ReadOnly = True
        Me.ebTicket.Size = New System.Drawing.Size(75, 22)
        Me.ebTicket.TabIndex = 5
        Me.ebTicket.TabStop = False
        Me.ebTicket.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTicket.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTicket
        '
        Me.lblTicket.AccessibleDescription = "0"
        Me.lblTicket.AutoSize = True
        Me.lblTicket.BackColor = System.Drawing.Color.Transparent
        Me.lblTicket.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicket.Location = New System.Drawing.Point(16, 16)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(55, 16)
        Me.lblTicket.TabIndex = 6
        Me.lblTicket.Text = "Ticket :"
        '
        'txtCVV2
        '
        Me.txtCVV2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCVV2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCVV2.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV2.Location = New System.Drawing.Point(136, 144)
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
        Me.Label16.Location = New System.Drawing.Point(16, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 16)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "CVV2 :"
        Me.Label16.Visible = False
        '
        'frmCancelarUnPagoTarjeta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 248)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelarUnPagoTarjeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "...::: Cancelar Pago Tarjeta :::..."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim oBanco As Bancos
    Dim oBancoMgr As CatalogoBancosManager
    Dim m_strTicket As String
    Dim m_strCodBanco As String
    Dim m_strNumTarjeta As String
    Dim m_strNoAutorizacion As String
    Dim m_strMonto As String
    Dim m_strCodAlmacen As String
    Dim m_strCodCaja As String
    Dim m_strCodVendedor As String
    Public Promocion As Integer = 0
    Dim oFacturaMgr As FacturaManager

#Region "Propiedades"

    Public Property Ticket() As String
        Get
            Return m_strTicket
        End Get
        Set(ByVal Value As String)
            m_strTicket = Value
        End Set
    End Property

    Public Property CodBanco() As String
        Get
            Return m_strCodBanco
        End Get
        Set(ByVal Value As String)
            m_strCodBanco = Value
        End Set
    End Property

    Public Property NoTarjeta() As String
        Get
            Return m_strNumTarjeta
        End Get
        Set(ByVal Value As String)
            m_strNumTarjeta = Value
        End Set
    End Property

    Public Property NoAutorizacion() As String
        Get
            Return m_strNoAutorizacion
        End Get
        Set(ByVal Value As String)
            m_strNoAutorizacion = Value
        End Set
    End Property

    Public Property Monto() As String
        Get
            Return m_strMonto
        End Get
        Set(ByVal Value As String)
            m_strMonto = Value
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set
    End Property

    Public Property CodVendedor() As String
        Get
            Return m_strCodVendedor
        End Get
        Set(ByVal Value As String)
            m_strCodVendedor = Value
        End Set
    End Property

#End Region

#Region "Form Events"

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
    '            Dim mCVV2 As String = Trim(Me.ebNoAutorizacion.Text)
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

    '            If strNum.Trim <> Me.ebNoTarjeta.Text.Trim Then
    '                MessageBox.Show("La tarjeta no fue utilizada en este abono. Verifique", "Validar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            End If

    '            mSalida = x.PagoTarjeta( _
    '                        CodAlmacen, _
    '                        CodCaja, _
    '                        CodVendedor, _
    '                        "010000", 902, mTrack2, _
    '                        CDbl(Monto), _
    '                        Ticket, _
    '                        mComentario, _
    '                        mRespuesta, _
    '                        0, _
    '                        0, _
    '                        mCVV2)

    '            mDummy = mSalida
    '            Do While Len(mDummy) > 0
    '                mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
    '                mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
    '                If InStr(mRespose, "38==") > 0 Then
    '                    mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
    '                End If
    '                If InStr(mRespose, "39==") > 0 Then
    '                    mRespcode = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                End If
    '                If InStr(mRespose, "43==") > 0 Then
    '                    Mensaje = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                    If Len(Mensaje) > 40 Then Mensaje = Mensaje.Substring(0, 40) Else Mensaje = Mensaje & Space(40 - Len(Mensaje))
    '                End If
    '                If InStr(mRespose, "46==") > 0 Then
    '                    Mensaje46 = Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1))
    '                    Mensaje46 = Replace(Mensaje46, "|", vbCrLf)
    '                End If
    '                If InStr(mRespose, "48==") > 0 Then
    '                    mAfiliacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim 'Trim$(mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)).Substring(0, 10)
    '                End If
    '            Loop
    '            If mOperacion = "000001" Then
    '                If mAutorizacion > 1 Then
    '                    Mid$(mHFijo, 4, 1) = "1"
    '                End If
    '                While InStr(Mensaje46, vbCrLf) > 0
    '                    mDummy = Mensaje46.Substring(0, InStr(Mensaje46, vbCrLf) - 1)
    '                    Mensaje46 = Mensaje46.Substring(InStr(Mensaje46, vbCrLf) + 1, Len(Mensaje46) - InStr(Mensaje46, vbCrLf) - 1)
    '                End While
    '            Else
    '                mDummy = mHFijo
    '                If mOperacion = "000002" Then
    '                    mDummy = mDummy & mRespcode & mAutorizacion
    '                    mDummy = mDummy & Mensaje.Substring(0, 40)
    '                    If Len(Mensaje) < 40 Then
    '                        mDummy = mDummy & Space(40 - Len(Mensaje))
    '                    End If
    '                End If
    '                If mOperacion = "000002" Then
    '                    mDummy = mDummy & Mensaje46.Substring(0, 20)
    '                    If Len(Mensaje46) < 20 Then
    '                        mDummy = mDummy & Space(20 - Len(Mensaje46))
    '                    End If
    '                    mDummy = mDummy & mAfiliacion
    '                Else
    '                    mDummy = mDummy & Mensaje46
    '                End If

    '            End If

    '            If mRespcode = "00" AndAlso Trim(mAfiliacion) <> "" Then 'AndAlso Trim(mAutorizacion) <> "" Then
    '                'Transaccion Exitosa

    '                Dim strBanco As String
    '                Mensaje = UCase(Mensaje)
    '                If InStr(Mensaje, "BANAMEX") > 0 Then
    '                    strBanco = "BANAMEX"
    '                ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
    '                    strBanco = "BANCOMER"
    '                ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
    '                    strBanco = "SANTANDER"
    '                End If

    '                If InStr(mSalida, "6 MESES") > 0 Then
    '                    strPromocion = "6 Meses Sin Intereses"
    '                ElseIf InStr(mSalida, "3 MESES") > 0 Then
    '                    strPromocion = "3 Meses Sin Intereses"
    '                ElseIf InStr(mSalida, "9 MESES") > 0 Then
    '                    strPromocion = "9 Meses Sin Intereses"
    '                End If

    '                MsgBox("Transacción Exitosa" & vbCrLf & "Preparar Miniprinter.", MsgBoxStyle.Information, "DPTienda")

    '                ''''I. Actualizamos Ticket.
    '                Dim strConfigurationFile As String = Application.StartupPath & "\configSAP.cml"
    '                Dim oSApReader As New SapConfigReader(strConfigurationFile)
    '                oAppSAPConfig.Ticket = oAppSAPConfig.Ticket + 1
    '                oSApReader.SaveSettings(oAppSAPConfig)

    '                Dim bolReimprimir As Boolean = False

    'Reimprimir:
    '                Select Case strBanco

    '                    Case "BANAMEX"
    'Imprime_Banamex:
    '                        'Original Banco
    '                        Dim oARReporte As New rptTicketBANAMEX(CDbl(Monto), strNum, strVencimiento, _
    '                                                NoAutorizacion, strPromocion, "CANCELACION", strNombre, CodVendedor, _
    '                                                mAfiliacion, strBanco, "ORIGINAL BANCO")

    '                        oARReporte.Document.Name = "Cancelación Tarjeta de Crédito"
    '                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporte.Run()
    '                        oARReporte.Document.Print(False, False)

    '                        'COPIA CLIENTE
    '                        Dim oARReporteC As New rptTicketBANAMEX(CDbl(Monto), strNum, strVencimiento, _
    '                                                NoAutorizacion, strPromocion, "CANCELACION", strNombre, CodVendedor, _
    '                                                                mAfiliacion, strBanco, "COPIA CLIENTE")
    '                        oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
    '                        oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporteC.Run()
    '                        oARReporteC.Document.Print(False, False)

    '                    Case "BANCOMER"

    '                        'Original Banco
    '                        Dim oARReporte As New rptTicketBancomer(CDbl(Monto), strNum, strVencimiento, _
    '                                                                NoAutorizacion, strPromocion, "CANCELACION", _
    '                                                                strNombre, CodVendedor, mAfiliacion, strBanco, "ORIGINAL BANCO")
    '                        oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
    '                        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporte.Run()
    '                        oARReporte.Document.Print(False, False)

    '                        'Copia Cliente
    '                        Dim oARReporteC As New rptTicketBancomer(CDbl(Monto), strNum, strVencimiento, _
    '                                                                 NoAutorizacion, strPromocion, "CANCELACION", _
    '                                                                 strNombre, CodVendedor, mAfiliacion, strBanco, "COPIA CLIENTE")
    '                        oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
    '                        oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
    '                        oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
    '                        oARReporteC.Run()
    '                        oARReporteC.Document.Print(False, False)


    '                    Case Else

    '                        GoTo Imprime_Banamex

    '                End Select

    '                If bolReimprimir = False Then
    '                    If MessageBox.Show("¿Desea reimprimir los vouchers?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '                        bolReimprimir = True
    '                        GoTo Reimprimir
    '                    End If
    '                End If

    '                Me.ebNumTarj.Text = ""
    '                Me.txtCVV2.Text = ""
    '                Me.txtCVV2.Focus()

    '                Me.DialogResult = DialogResult.OK

    '            Else

    '                'Transaccion Rechazada

    '                If Trim(mRespcode) <> "00" Then

    '                    MsgBox("Transacción Rechazada." & Microsoft.VisualBasic.vbCrLf & _
    '                    mSalida, MsgBoxStyle.Exclamation, "DPTienda")

    '                ElseIf Trim(mAutorizacion) = "" AndAlso Trim(mAfiliacion) = "" Then

    '                    MsgBox("Transacción Rechazada. No se regresaron el número de afiliación ni el número" & _
    '                           " de autorización." & Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                           MsgBoxStyle.Exclamation, "DPTienda")

    '                ElseIf Trim(mAutorizacion) = "" Then

    '                    MsgBox("Transacción Rechazada. No se regresó el número de autorización." & _
    '                           Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                           MsgBoxStyle.Exclamation, "DPTienda")

    '                ElseIf Trim(mAfiliacion) = "" Then

    '                    MsgBox("Transacción Rechazada. No se regresó el número de afiliación." & _
    '                           Microsoft.VisualBasic.vbCrLf & mSalida, _
    '                           MsgBoxStyle.Exclamation, "DPTienda")

    '                End If

    '                Me.ebNumTarj.Text = ""
    '                Me.txtCVV2.Text = ""
    '                Me.txtCVV2.Focus()

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

        oStreamR = New StreamReader(Ruta)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        File.Delete(Ruta)

        Return strContenido

    End Function

    Private Sub AutorizaCargoTarjeta()

        'If Trim(Me.txtCVV2.Text) = "" Then
        '    MsgBox("Es necesario capturar el CVV2", MsgBoxStyle.Exclamation, "Dportenis Pro")
        '    Me.txtCVV2.Focus()
        '    Exit Sub
        'End If

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        Dim Datos() As String

        If File.Exists(Ruta) Then File.Delete(Ruta)

        Dim oApp As Process
        Dim oProcesos() As Process
        oProcesos = Process.GetProcessesByName("eHubEMV")
        For Each oApp In oProcesos
            oApp.CloseMainWindow()
            oApp.WaitForExit()
        Next

        'GenerarArchivoMonto(Ruta, CStr(Monto))

        Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

        If File.Exists(Ruta) Then
            Datos = LeerArchivoTarjeta(Ruta)
            File.Delete(Ruta)
        Else
            Me.ebNumTarj.Text = ""
            Exit Sub
        End If

        Dim x As New DportenisPro.DPTienda.ApplicationUnits.POSeHubDepilite.POSeHub

        Dim i As Long
        Dim mSalida As String
        Dim mAmount As Double           '4    
        Dim mPOSEntry As String         '22        
        Dim mTrack2 As String           '35        
        Dim mRespose As String          '61

        Dim mE2 As String
        Dim mHRecordType As String
        Dim mHTerm As String
        Dim mHCajero As String
        Dim mHTienda As String
        Dim mHTicket As String
        Dim mHTrack2 As String
        Dim mHImporte As String
        Dim mHMeses As String
        Dim mHSkip As String
        Dim mHCVV2 As String
        Dim mHCargo As String
        Dim mHCredito As String
        Dim mHFijo As String
        Dim mCard As String
        Dim mAutorizacion As String
        Dim Mensaje As String
        Dim Mensaje46 As String
        Dim mRespcode As String
        Dim mFile As Integer

        Dim mDummy As String
        Dim mCarPun As String
        Dim mCrePun As String
        Dim mCarDin As String
        Dim mCreDin As String
        Dim mNumCia As String
        Dim mNumPlan As String
        Dim mOperacion As String
        Dim mAfiliacion As String
        Dim mCVV2 As String = Trim(Me.ebNoAutorizacion.Text)
        Dim mRespuesta As String
        Dim mComentario As String
        Dim strNombre As String
        Dim strCriptograma As String = ""
        Dim mFirma As String = ""
        Dim mLote As String = ""
        Dim mSubtechTermID As String = ""
        Dim mTrace As String = ""
        Dim mTrnID As String = ""

        ebNumTarj.Text = Datos(0)
        strNombre = Datos(1)
        strCriptograma = Datos(5)
        mFirma = Datos(6)

        Dim intPosition As Integer = 0
        Dim strVencimiento As String = ""
        Dim strPromocion As String = ""
        Dim strNum As String = (ebNumTarj.Text).Replace(";", "")
        intPosition = InStr(strNum, "=")
        strVencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)
        strNum = Mid(strNum, 1, intPosition - 1)
        mPOSEntry = Datos(3) & "1"

        mTrack2 = (ebNumTarj.Text).Replace(";", "")
        mTrack2 = (mTrack2).Replace("?", "")
        If mTrack2.Length > 37 Then mTrack2 = mTrack2.Substring(0, 37)

        If strNum.Trim <> Me.ebNoTarjeta.Text.Trim Then
            MessageBox.Show("La tarjeta no fue utilizada en este abono. Verifique", "Validar Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            GoTo Final
        End If

        Ticket = oAppSAPConfig.Ticket & "|" & Ticket

        mSalida = x.PagoTarjeta(CodAlmacen, CodCaja, CodVendedor, "010000", mPOSEntry, mTrack2, CDbl(Monto), _
                                Ticket, mComentario, mRespuesta, "", "", CStr(Promocion).PadLeft(2, "0"), "00", mCVV2)

        mHTicket = ""
        mDummy = mSalida
        Do While Len(mDummy) > 0
            mRespose = mDummy.Substring(0, InStr(mDummy, vbCrLf) - 1)
            mDummy = mDummy.Substring(InStr(mDummy, vbCrLf) + 1, (Len(mDummy) - InStr(mDummy, vbCrLf) - 1))
            If InStr(mRespose, "11==") > 0 Then
                mHTicket = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1).Trim
            End If
            If InStr(mRespose, "38==") > 0 Then
                mAutorizacion = mRespose.Substring(InStr(mRespose, ">") + 1, Len(mRespose) - InStr(mRespose, ">") - 1)
            End If
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
            Dim strBanco As String = ""

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

            Mensaje = ""
            Mensaje = oFacturaMgr.BancoAutorizador(Me.ebNumTarj.Text, intPromo).ToUpper

            If InStr(Mensaje, "BANAMEX") > 0 Then
                strBanco = "BANAMEX"
            ElseIf InStr(Mensaje, "BANCOMER") > 0 Then
                strBanco = "BANCOMER"
            ElseIf InStr(Mensaje, "SANTANDER") > 0 Then
                strBanco = "SANTANDER"
            End If

            'Transaccion Exitosa
            MsgBox("Transacción Exitosa" & vbCrLf & "Preparar Miniprinter.", MsgBoxStyle.Information, "DPTienda")

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
                    Dim oARReporte As New rptTicketBANAMEX(CDbl(Monto), strNum, strVencimiento, _
                                                           mAutorizacion, strPromocion, "CANCELACION", _
                                                           strNombre, CodVendedor, mAfiliacion, strBanco, _
                                                           "ORIGINAL BANCO", mFirma, strCriptograma, True, _
                                                           mHTicket, mLote, mTrace, mSubtechTermID)
                    oARReporte.Document.Name = "Cancelación Tarjeta de Crédito"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporte.Run()
                    oARReporte.Document.Print(False, False)

                    'COPIA CLIENTE
                    Dim oARReporteC As New rptTicketBANAMEX(CDbl(Monto), strNum, strVencimiento, _
                                                            mAutorizacion, strPromocion, "CANCELACION", _
                                                            strNombre, CodVendedor, mAfiliacion, strBanco, _
                                                            "COPIA CLIENTE", mFirma, strCriptograma, True, _
                                                            mHTicket, mLote, mTrace, mSubtechTermID)
                    oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporteC.Run()
                    oARReporteC.Document.Print(False, False)

                    oReportView = New ReportViewerForm
                    oReportView.Report = oarreporte
                    oReportView.Show()

                    oReportView = New ReportViewerForm
                    oReportView.Report = oarreportec
                    oReportView.Show()

                Case "BANCOMER"

                    'Original Banco
                    Dim oARReporte As New rptTicketBancomer(CDbl(Monto), strNum, strVencimiento, _
                                                            NoAutorizacion, strPromocion, "CANCELACION", _
                                                            strNombre, CodVendedor, mAfiliacion, strBanco, "ORIGINAL BANCO", _
                                                            mPOSEntry, True, True, strCriptograma, mFirma)
                    oARReporte.Document.Name = "Pagaré Tarjeta de Crédito"
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporte.Run()
                    oARReporte.Document.Print(False, False)

                    'Copia Cliente
                    Dim oARReporteC As New rptTicketBancomer(CDbl(Monto), strNum, strVencimiento, _
                                                             NoAutorizacion, strPromocion, "CANCELACION", _
                                                             strNombre, CodVendedor, mAfiliacion, strBanco, "COPIA CLIENTE", _
                                                             mPOSEntry, True, True, strCriptograma, mFirma)
                    oARReporteC.Document.Name = "Cancelación Tarjeta de Crédito"
                    oARReporteC.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                    oARReporteC.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                    oARReporteC.Run()
                    oARReporteC.Document.Print(False, False)

                    oReportView = New ReportViewerForm
                    oReportView.Report = oarreporte
                    oReportView.Show()

                    oReportView = New ReportViewerForm
                    oReportView.Report = oarreportec
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

            Me.ebNumTarj.Text = ""
            Me.txtCVV2.Text = ""
            Me.txtCVV2.Focus()

            Me.DialogResult = DialogResult.OK

        Else

            'Transaccion Rechazada

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
Final:
        If mPOSEntry.Trim = "051" Then
            Shell(Application.StartupPath & "\PinPadNurit293.exe /C", AppWinStyle.NormalFocus, False)
        End If

    End Sub

    Private Sub frmCancelarPagoTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCancelarUnPagoTarjeta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ebTicket.Text = Ticket
        Me.ebCodBanco.Text = CodBanco
        oBanco = oBancoMgr.Load(CodBanco)
        If oBanco Is Nothing Then
            oBanco = oBancoMgr.Create
            oBanco.Descripcion = "BANAMEX"
        End If
        Me.ebBanco.Text = oBanco.Descripcion
        Me.ebNoTarjeta.Text = Me.NoTarjeta
        Me.ebNoAutorizacion.Text = Me.NoAutorizacion
        oBanco = Nothing
        oBancoMgr = Nothing

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

#End Region

    Private Sub btnLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerTarjeta.Click
        Me.btnLeerTarjeta.Enabled = False
        AutorizaCargoTarjeta()
        Me.btnLeerTarjeta.Enabled = True
    End Sub
End Class
