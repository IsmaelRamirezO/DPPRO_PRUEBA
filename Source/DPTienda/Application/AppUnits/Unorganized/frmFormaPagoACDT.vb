Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoTarjetas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU

Public Class frmFormaPagoACDT
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    Public Sub New(ByVal cantidad As Double, _
                    ByVal oAbonoCreditoDirectoMgr2 As AbonoCreditoDirectoManager, _
                    ByVal oAsociado2 As Asociado, _
                    ByVal oAbonoCreditoDirecto2 As AbonoCreditoDirecto, _
                    ByVal dsValeCaja2 As DataSet, _
                    ByVal bandConsulta2 As Boolean, _
                    ByVal ValeCajaID As Integer)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        Me.txtCantidadaPagar.Value = cantidad
        oAbonoCreditoDirectoMgr = oAbonoCreditoDirectoMgr2
        oAsociado = oAsociado2
        oAbonoCreditoDirecto = oAbonoCreditoDirecto2
        'oValeCaja = oValeCaja2 'Para un sOlo vale de caja
        dsValeCaja = dsValeCaja2
        bandConsulta = bandConsulta2
        ValeCajaDevID = ValeCajaID
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents uitnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents EBNumTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EBPagoCom As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EBPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EBBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EBIDBanco As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EBAutorizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EBTipoTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EBIDTipoTarj As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents txtEfectivo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents EBAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GridFormaPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadaPagar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nbValeCajaID As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblSaldoFavor As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormaPagoACDT))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nbValeCajaID = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbFormaPago1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.uitnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.EBNumTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EBPagoCom = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EBPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EBBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EBIDBanco = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EBAutorizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EBTipoTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EBIDTipoTarj = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSaldoFavor = New System.Windows.Forms.Label()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidadaPagar = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.EBAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GridFormaPago = New Janus.Windows.GridEX.GridEX()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.GridFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.nbValeCajaID)
        Me.ExplorerBar2.Controls.Add(Me.cmbFormaPago1)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.uitnNuevo)
        Me.ExplorerBar2.Controls.Add(Me.EBNumTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label13)
        Me.ExplorerBar2.Controls.Add(Me.EBPagoCom)
        Me.ExplorerBar2.Controls.Add(Me.EBPago)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        Me.ExplorerBar2.Controls.Add(Me.EBBanco)
        Me.ExplorerBar2.Controls.Add(Me.Label11)
        Me.ExplorerBar2.Controls.Add(Me.EBIDBanco)
        Me.ExplorerBar2.Controls.Add(Me.EBAutorizacion)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.EBTipoTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label6)
        Me.ExplorerBar2.Controls.Add(Me.EBIDTipoTarj)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Controls.Add(Me.lblSaldoFavor)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Captura de Forma de Pago"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(399, 488)
        Me.ExplorerBar2.TabIndex = 0
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nbValeCajaID
        '
        Me.nbValeCajaID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbValeCajaID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbValeCajaID.BackColor = System.Drawing.Color.Ivory
        Me.nbValeCajaID.Enabled = False
        Me.nbValeCajaID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbValeCajaID.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbValeCajaID.Location = New System.Drawing.Point(152, 70)
        Me.nbValeCajaID.MaxLength = 8
        Me.nbValeCajaID.Name = "nbValeCajaID"
        Me.nbValeCajaID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.nbValeCajaID.Size = New System.Drawing.Size(120, 22)
        Me.nbValeCajaID.TabIndex = 1
        Me.nbValeCajaID.Text = "0"
        Me.nbValeCajaID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nbValeCajaID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFormaPago1
        '
        Me.cmbFormaPago1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbFormaPago1.BackColor = System.Drawing.Color.Ivory
        Me.cmbFormaPago1.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbFormaPago1.DesignTimeLayout = GridEXLayout1
        Me.cmbFormaPago1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago1.Location = New System.Drawing.Point(152, 40)
        Me.cmbFormaPago1.Name = "cmbFormaPago1"
        Me.cmbFormaPago1.Size = New System.Drawing.Size(152, 22)
        Me.cmbFormaPago1.TabIndex = 10
        Me.cmbFormaPago1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbFormaPago1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(8, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 23)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Saldo a Favor:"
        '
        'uitnNuevo
        '
        Me.uitnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnNuevo.Location = New System.Drawing.Point(48, 288)
        Me.uitnNuevo.Name = "uitnNuevo"
        Me.uitnNuevo.Size = New System.Drawing.Size(152, 32)
        Me.uitnNuevo.TabIndex = 10
        Me.uitnNuevo.Text = "Nuevo"
        Me.uitnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EBNumTarj
        '
        Me.EBNumTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBNumTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBNumTarj.BackColor = System.Drawing.Color.Ivory
        Me.EBNumTarj.Enabled = False
        Me.EBNumTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBNumTarj.ForeColor = System.Drawing.Color.Black
        Me.EBNumTarj.Location = New System.Drawing.Point(152, 187)
        Me.EBNumTarj.MaxLength = 20
        Me.EBNumTarj.Name = "EBNumTarj"
        Me.EBNumTarj.Size = New System.Drawing.Size(240, 22)
        Me.EBNumTarj.TabIndex = 6
        Me.EBNumTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBNumTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = "0"
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 14)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Número. de Tarjeta:"
        '
        'EBPagoCom
        '
        Me.EBPagoCom.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPagoCom.BackColor = System.Drawing.Color.Ivory
        Me.EBPagoCom.Enabled = False
        Me.EBPagoCom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPagoCom.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPagoCom.Location = New System.Drawing.Point(152, 245)
        Me.EBPagoCom.MaxLength = 8
        Me.EBPagoCom.Name = "EBPagoCom"
        Me.EBPagoCom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBPagoCom.Size = New System.Drawing.Size(128, 22)
        Me.EBPagoCom.TabIndex = 8
        Me.EBPagoCom.Text = "$0.00"
        Me.EBPagoCom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPagoCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBPago
        '
        Me.EBPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBPago.BackColor = System.Drawing.Color.Ivory
        Me.EBPago.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBPago.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBPago.Location = New System.Drawing.Point(152, 96)
        Me.EBPago.MaxLength = 8
        Me.EBPago.Name = "EBPago"
        Me.EBPago.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBPago.Size = New System.Drawing.Size(120, 22)
        Me.EBPago.TabIndex = 3
        Me.EBPago.Text = "$0.00"
        Me.EBPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = "0"
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 245)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 14)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Comisión por Tarjeta:"
        '
        'EBBanco
        '
        Me.EBBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBBanco.BackColor = System.Drawing.Color.Ivory
        Me.EBBanco.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.Enabled = False
        Me.EBBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBBanco.ForeColor = System.Drawing.Color.Black
        Me.EBBanco.Location = New System.Drawing.Point(239, 158)
        Me.EBBanco.Name = "EBBanco"
        Me.EBBanco.ReadOnly = True
        Me.EBBanco.Size = New System.Drawing.Size(152, 22)
        Me.EBBanco.TabIndex = 28
        Me.EBBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = "0"
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Banco:"
        '
        'EBIDBanco
        '
        Me.EBIDBanco.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDBanco.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDBanco.BackColor = System.Drawing.Color.Ivory
        Me.EBIDBanco.ButtonImage = CType(resources.GetObject("EBIDBanco.ButtonImage"), System.Drawing.Image)
        Me.EBIDBanco.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDBanco.Enabled = False
        Me.EBIDBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDBanco.ForeColor = System.Drawing.Color.Black
        Me.EBIDBanco.Location = New System.Drawing.Point(152, 158)
        Me.EBIDBanco.MaxLength = 4
        Me.EBIDBanco.Name = "EBIDBanco"
        Me.EBIDBanco.Size = New System.Drawing.Size(80, 22)
        Me.EBIDBanco.TabIndex = 5
        Me.EBIDBanco.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EBAutorizacion
        '
        Me.EBAutorizacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAutorizacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAutorizacion.BackColor = System.Drawing.Color.Ivory
        Me.EBAutorizacion.Enabled = False
        Me.EBAutorizacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAutorizacion.ForeColor = System.Drawing.Color.Black
        Me.EBAutorizacion.Location = New System.Drawing.Point(152, 216)
        Me.EBAutorizacion.MaxLength = 20
        Me.EBAutorizacion.Name = "EBAutorizacion"
        Me.EBAutorizacion.Size = New System.Drawing.Size(240, 22)
        Me.EBAutorizacion.TabIndex = 7
        Me.EBAutorizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBAutorizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = "0"
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 14)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "No. Autorización:"
        '
        'EBTipoTarj
        '
        Me.EBTipoTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBTipoTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBTipoTarj.BackColor = System.Drawing.Color.Ivory
        Me.EBTipoTarj.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTipoTarj.Enabled = False
        Me.EBTipoTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBTipoTarj.ForeColor = System.Drawing.Color.Black
        Me.EBTipoTarj.Location = New System.Drawing.Point(207, 129)
        Me.EBTipoTarj.Name = "EBTipoTarj"
        Me.EBTipoTarj.ReadOnly = True
        Me.EBTipoTarj.Size = New System.Drawing.Size(184, 22)
        Me.EBTipoTarj.TabIndex = 25
        Me.EBTipoTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBTipoTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = "0"
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 14)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Tipo de Tarjeta:"
        '
        'EBIDTipoTarj
        '
        Me.EBIDTipoTarj.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBIDTipoTarj.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBIDTipoTarj.BackColor = System.Drawing.Color.Ivory
        Me.EBIDTipoTarj.ButtonImage = CType(resources.GetObject("EBIDTipoTarj.ButtonImage"), System.Drawing.Image)
        Me.EBIDTipoTarj.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EBIDTipoTarj.Enabled = False
        Me.EBIDTipoTarj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBIDTipoTarj.ForeColor = System.Drawing.Color.Black
        Me.EBIDTipoTarj.Location = New System.Drawing.Point(152, 129)
        Me.EBIDTipoTarj.MaxLength = 2
        Me.EBIDTipoTarj.Name = "EBIDTipoTarj"
        Me.EBIDTipoTarj.Size = New System.Drawing.Size(48, 22)
        Me.EBIDTipoTarj.TabIndex = 4
        Me.EBIDTipoTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBIDTipoTarj.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = "0"
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 14)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Monto a Pagar:"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Location = New System.Drawing.Point(208, 288)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(152, 32)
        Me.uitnAgregar.TabIndex = 9
        Me.uitnAgregar.Text = "Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = "0"
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 14)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Forma de Pago:"
        '
        'lblSaldoFavor
        '
        Me.lblSaldoFavor.BackColor = System.Drawing.SystemColors.Window
        Me.lblSaldoFavor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFavor.Location = New System.Drawing.Point(152, 69)
        Me.lblSaldoFavor.Name = "lblSaldoFavor"
        Me.lblSaldoFavor.Size = New System.Drawing.Size(120, 23)
        Me.lblSaldoFavor.TabIndex = 2
        Me.lblSaldoFavor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSaldoFavor.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(88, 288)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(152, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.Label1)
        Me.ExplorerBar3.Controls.Add(Me.txtCantidadaPagar)
        Me.ExplorerBar3.Controls.Add(Me.txtEfectivo)
        Me.ExplorerBar3.Controls.Add(Me.Label15)
        Me.ExplorerBar3.Controls.Add(Me.EBAbono)
        Me.ExplorerBar3.Controls.Add(Me.Label10)
        Me.ExplorerBar3.Controls.Add(Me.GridFormaPago)
        Me.ExplorerBar3.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Detalle del Pago"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar3.Location = New System.Drawing.Point(392, 0)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(328, 488)
        Me.ExplorerBar3.TabIndex = 1
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "0"
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 14)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Cantidad a Pagar:"
        '
        'txtCantidadaPagar
        '
        Me.txtCantidadaPagar.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCantidadaPagar.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCantidadaPagar.BackColor = System.Drawing.Color.Ivory
        Me.txtCantidadaPagar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadaPagar.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtCantidadaPagar.Location = New System.Drawing.Point(192, 31)
        Me.txtCantidadaPagar.MaxLength = 8
        Me.txtCantidadaPagar.Name = "txtCantidadaPagar"
        Me.txtCantidadaPagar.ReadOnly = True
        Me.txtCantidadaPagar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCantidadaPagar.Size = New System.Drawing.Size(120, 22)
        Me.txtCantidadaPagar.TabIndex = 42
        Me.txtCantidadaPagar.Text = "$0.00"
        Me.txtCantidadaPagar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCantidadaPagar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtEfectivo
        '
        Me.txtEfectivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtEfectivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtEfectivo.BackColor = System.Drawing.Color.Ivory
        Me.txtEfectivo.Enabled = False
        Me.txtEfectivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.ForeColor = System.Drawing.Color.Red
        Me.txtEfectivo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtEfectivo.Location = New System.Drawing.Point(200, 248)
        Me.txtEfectivo.MaxLength = 8
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEfectivo.Size = New System.Drawing.Size(112, 22)
        Me.txtEfectivo.TabIndex = 41
        Me.txtEfectivo.Text = "$0.00"
        Me.txtEfectivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtEfectivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AccessibleDescription = "0"
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(44, 248)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 14)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Monto sin Comision:"
        '
        'EBAbono
        '
        Me.EBAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EBAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EBAbono.BackColor = System.Drawing.Color.Ivory
        Me.EBAbono.Enabled = False
        Me.EBAbono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EBAbono.ForeColor = System.Drawing.Color.Red
        Me.EBAbono.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.EBAbono.Location = New System.Drawing.Point(200, 216)
        Me.EBAbono.MaxLength = 8
        Me.EBAbono.Name = "EBAbono"
        Me.EBAbono.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EBAbono.Size = New System.Drawing.Size(112, 22)
        Me.EBAbono.TabIndex = 39
        Me.EBAbono.Text = "$0.00"
        Me.EBAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EBAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = "0"
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 14)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Monto total del abono:"
        '
        'GridFormaPago
        '
        Me.GridFormaPago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridFormaPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridFormaPago.BackColor = System.Drawing.Color.Ivory
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.GridFormaPago.DesignTimeLayout = GridEXLayout2
        Me.GridFormaPago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridFormaPago.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridFormaPago.GroupByBoxVisible = False
        Me.GridFormaPago.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridFormaPago.Location = New System.Drawing.Point(16, 63)
        Me.GridFormaPago.Name = "GridFormaPago"
        Me.GridFormaPago.Size = New System.Drawing.Size(296, 145)
        Me.GridFormaPago.TabIndex = 37
        Me.GridFormaPago.TabStop = False
        Me.GridFormaPago.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridFormaPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmFormaPagoACDT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 338)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(720, 376)
        Me.MinimumSize = New System.Drawing.Size(720, 376)
        Me.Name = "frmFormaPagoACDT"
        Me.Text = "Formas de Pago"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.ExplorerBar3.PerformLayout()
        CType(Me.GridFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oPorcComision As Decimal
    Private oAbonoCreditoDirectoMgr As AbonoCreditoDirectoManager
    Private oAbonoCreditoDirectoDG As AbonoCreditoDirectoDataGateway
    Private oAbonoCreditoDirecto As AbonoCreditoDirecto

    Private oAsociadosMgr As AsociadosManager
    Private oAsociado As Asociado

    Private oCatalogoBancosMgr As CatalogoBancosManager
    Private oBancos As Bancos

    Private oCatalogoTipoTarjetasMgr As CatalogoTipoTarjetasManager
    Private oTipoTarjeta As TipoTarjeta

    Public dsDataSet As DataSet

    Public oValeCaja As ValeCaja
    Public oValeCajaMgr As ValeCajaManager
    Public dsValeCaja As DataSet
    Private ValeCajaDevID As Integer = 0

    Public difValeCaja As Double
    Private ComisionBancaria As Decimal

    Private bandConsulta As Boolean = False

    Private oCatalogoFormasPagoMgr As New CatalogoFormasPagoManager(oAppContext)
    Private oCatalogoFormasPago As FormaPago

#End Region


#Region "Controles"

    Public Sub ShowDev()

        InitializeObjects()
        BuildFormasPagoDataset()
        BuildValesCajaDataSet()
        Me.cmbFormaPago1.Value = "VCJA"
        'Me.cmbFormaPago1.Text = "A"
        'Me.EBFormaPago.Text = "VALE DE CAJA"
        Me.EBPago.ReadOnly = True

        If bandConsulta Then

            Me.txtEfectivo.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Monto)", "Monto>0")
            Me.EBAbono.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Total)", "Total>0")

            For Each row As DataRow In dsDataSet.Tables("FormasPago").Rows
                If row("IDFormaPago") = "EFECT" Then
                    'Me.cmbFormaPago1.Value
                    'Me.CmbFormaPago.Items.Remove("E")
                    'DESABILITAR EFECTIVO
                End If
            Next

            Me.ExplorerBar2.Enabled = True
            Me.ExplorerBar3.Enabled = True
        Else

            Me.EBAbono.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Total)", "Total>0")
            Me.txtEfectivo.Value = EBAbono.Value - dsDataSet.Tables("FormasPago").Compute("Sum(ComisionBancaria)", "ComisionBancaria>=0")

            Me.ExplorerBar2.Enabled = False
            Me.ExplorerBar3.Enabled = False
        End If

        If ValeCajaDevID > 0 Then
            nbValeCajaID.Value = ValeCajaDevID
            Me.uitnNuevo.Enabled = False
            Me.cmbFormaPago1.Enabled = False
            Me.nbValeCajaID.Enabled = True
            Me.nbValeCajaID.ReadOnly = True
            nbValeCajaID.Focus()
        Else
            Me.nbValeCajaID.Enabled = True
            Me.nbValeCajaID.ReadOnly = False
        End If

        ComisionBancaria = EBAbono.Value - txtEfectivo.Value

        'Me.EBFormaPago.Text = "VALE DE CAJA"
        Me.Label14.Text = "Folio Vale de Caja"
        Me.nbValeCajaID.Visible = True
        Me.EBPago.ReadOnly = True
        Me.nbValeCajaID.Enabled = True

        oValeCaja = oValeCajaMgr.Load(nbValeCajaID.Value)

        If oValeCaja Is Nothing Then

            MessageBox.Show("Vale de Caja Incorrecto", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            If oValeCaja.MontoUtilizado > 0 Or oValeCaja.StastusRegistro = False Then

                MessageBox.Show("Vale de Caja Utilizado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                If (Me.txtCantidadaPagar.Value - Me.EBAbono.Value) < oValeCaja.Importe Then
                    Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.EBAbono.Value
                Else
                    Me.EBPago.Value = oValeCaja.Importe
                End If

            End If
        End If

        EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)

        uitnAgregar.PerformClick()

        Me.DialogResult = DialogResult.OK

    End Sub

#End Region

    Private Sub InitializeObjects()

        oAsociadosMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadosMgr.Create
        oAsociado.Clear()

        oCatalogoTipoTarjetasMgr = New CatalogoTipoTarjetasManager(oAppContext)
        oCatalogoBancosMgr = New CatalogoBancosManager(oAppContext)

        oValeCajaMgr = New ValeCajaManager(oAppContext)

    End Sub


#Region "ActivaTarjetas"
    Private Sub ActivaDatTC(ByVal Valor As Boolean)
        If Valor = False Then
            EBIDTipoTarj.Text = String.Empty
            EBTipoTarj.Text = String.Empty
            EBIDBanco.Text = String.Empty
            EBBanco.Text = String.Empty
            EBNumTarj.Text = String.Empty
            EBAutorizacion.Text = String.Empty
            EBPagoCom.Text = 0
        End If
        EBIDTipoTarj.Enabled = Valor
        EBIDBanco.Enabled = Valor
        EBNumTarj.Enabled = Valor
        EBAutorizacion.Enabled = Valor
    End Sub
#End Region

#Region "DataSet Formas de Pago"
    Private Sub BuildFormasPagoDataset()
        If Not (oAbonoCreditoDirecto.FormasDePago Is Nothing) Then
            dsDataSet = oAbonoCreditoDirecto.FormasDePago.Copy

            For Each row As DataRow In dsDataSet.Tables("FormasPago").Rows
                If row("FormaPago") = "EFEC" Then
                    row("FormaPago") = "EFECTIVO"
                ElseIf row("FormaPago") = "TACR" Then
                    row("FormaPago") = "TARJETA DE CRÉDITO"
                ElseIf row("FormaPago") = "TADB" Then
                    row("FormaPago") = "TARJETA DE DÉBITO"
                ElseIf row("FormaPago") = "S" Then
                    row("FormaPago") = "SALDO A FAVOR"
                ElseIf row("FormaPago") = "VCJA" Then
                    row("FormaPago") = "VALE DE CAJA"
                End If
            Next

            GridFormaPago.SetDataBinding(dsDataSet, "FormasPago")
        Else

            dsDataSet = New DataSet("FormasPago")
            Dim dtFormasPago As New DataTable("FormasPago")

            Dim dcIDFormaPago As New DataColumn
            With dcIDFormaPago
                .ColumnName = "IDFormaPago"
                .Caption = "ID Forma de Pago"
                .DataType = GetType(System.String)
                .MaxLength = 4
                .DefaultValue = String.Empty
            End With

            Dim dcFormaPago As New DataColumn
            With dcFormaPago
                .ColumnName = "FormaPago"
                .Caption = "Forma de Pago"
                .DataType = GetType(System.String)
                .DefaultValue = String.Empty
            End With

            Dim dcMonto As New DataColumn
            With dcMonto
                .ColumnName = "Monto"
                .Caption = "Monto"
                .DataType = GetType(System.Decimal)
                .DefaultValue = 0
            End With

            Dim dcIDTipoTarjeta As New DataColumn
            With dcIDTipoTarjeta
                .ColumnName = "IDTipoTarjeta"
                .Caption = "ID Tipo de Tarjeta"
                .DataType = GetType(System.String)
                .MaxLength = 2
                .DefaultValue = String.Empty
            End With

            Dim dcTipoTarjeta As New DataColumn
            With dcTipoTarjeta
                .ColumnName = "TipoTarjeta"
                .Caption = "Tipo de Tarjeta"
                .DataType = GetType(System.String)
                .DefaultValue = String.Empty
            End With

            Dim dcIDBanco As New DataColumn
            With dcIDBanco
                .ColumnName = "IDBanco"
                .Caption = "ID Banco"
                .DataType = GetType(System.String)
                .MaxLength = 4
                .DefaultValue = String.Empty
            End With

            Dim dcBanco As New DataColumn
            With dcBanco
                .ColumnName = "Banco"
                .Caption = "Banco"
                .DataType = GetType(System.String)
                .DefaultValue = String.Empty
            End With

            Dim dcNumTarjeta As New DataColumn
            With dcNumTarjeta
                .ColumnName = "NumTarjeta"
                .Caption = "Num. de Tarjeta"
                .DataType = GetType(System.String)
                .MaxLength = 20
                .DefaultValue = String.Empty
            End With

            Dim dcNumAutorizacion As New DataColumn
            With dcNumAutorizacion
                .ColumnName = "NumAutorizacion"
                .Caption = "Num. de Autorizacion"
                .DataType = GetType(System.String)
                .MaxLength = 20
                .DefaultValue = String.Empty
            End With

            Dim dcComision As New DataColumn
            With dcComision
                .ColumnName = "Comision"
                .Caption = "Comision"
                .DataType = GetType(System.Decimal)
                .DefaultValue = 0
            End With

            Dim dcTotal As New DataColumn
            With dcTotal
                .ColumnName = "Total"
                .Caption = "Total"
                .DataType = GetType(System.Decimal)
                .DefaultValue = 0
            End With

            Dim dcUsuario As New DataColumn
            With dcUsuario
                .ColumnName = "Usuario"
                .Caption = "Usuario"
                .DataType = GetType(System.String)
                .DefaultValue = String.Empty
            End With

            Dim dcFecha As New DataColumn
            With dcFecha
                .ColumnName = "Fecha"
                .Caption = "Fecha"
                .DataType = GetType(System.DateTime)
                .DefaultValue = Date.Today
            End With

            Dim dcStatusRegistro As New DataColumn
            With dcStatusRegistro
                .ColumnName = "StatusRegistro"
                .Caption = "StatusRegistro"
                .DataType = GetType(System.Boolean)
                .DefaultValue = True
            End With

            Dim dcValeCajaID As New DataColumn
            With dcValeCajaID
                .ColumnName = "ValeCajaID"
                .Caption = "ValeCaja ID"
                .DataType = GetType(System.Int32)
                .DefaultValue = True
            End With


            With dtFormasPago.Columns
                .Add(dcIDFormaPago)
                .Add(dcFormaPago)
                .Add(dcMonto)
                .Add(dcIDTipoTarjeta)
                .Add(dcTipoTarjeta)
                .Add(dcIDBanco)
                .Add(dcBanco)
                .Add(dcNumTarjeta)
                .Add(dcNumAutorizacion)
                .Add(dcComision)
                .Add(dcTotal)
                .Add(dcUsuario)
                .Add(dcFecha)
                .Add(dcStatusRegistro)
                .Add(dcValeCajaID)
            End With

            dsDataSet.Tables.Add(dtFormasPago)

            GridFormaPago.SetDataBinding(dsDataSet, "FormasPago")
        End If

    End Sub

    Private Sub BuildValesCajaDataSet()

        If dsValeCaja Is Nothing Then 'Copi la estructura del dataset
            dsValeCaja = oValeCajaMgr.GetAll(False).Clone
        End If

    End Sub

#End Region

    Private Sub frmFormaPagoACDT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeObjects()
        BuildFormasPagoDataset()
        BuildValesCajaDataSet()

        If bandConsulta Then

            Me.txtEfectivo.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Monto)", "Monto>0")
            Me.EBAbono.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Total)", "Total>0")
            Me.ExplorerBar2.Enabled = True
            Me.ExplorerBar3.Enabled = True
        Else

            Me.EBAbono.Value = dsDataSet.Tables("FormasPago").Compute("Sum(Total)", "Total>0")
            Me.txtEfectivo.Value = EBAbono.Value - dsDataSet.Tables("FormasPago").Compute("Sum(ComisionBancaria)", "ComisionBancaria>=0")
            Me.ExplorerBar2.Enabled = False
            Me.ExplorerBar3.Enabled = False
        End If

        If ValeCajaDevID > 0 Then
            Me.cmbFormaPago1.Value = "VCJA"
            nbValeCajaID.Value = ValeCajaDevID
            Me.uitnNuevo.Enabled = False
            Me.cmbFormaPago1.Enabled = False
            Me.nbValeCajaID.Enabled = True
            Me.nbValeCajaID.ReadOnly = True
            nbValeCajaID.Focus()
            valecaja()
        Else
            Me.nbValeCajaID.Enabled = True
            Me.nbValeCajaID.ReadOnly = False
        End If

        ComisionBancaria = EBAbono.Value - txtEfectivo.Value
        'LLENA LOS TIPOS DE PAGO
        FillFormaPago()

        If nbValeCajaID.Value <> 0 Then
            uitnAgregar.PerformClick()
        End If

        Me.cmbFormaPago1.Value = "EFEC"
        'Para que bloque los controles
        cmbFormaPago1_ValueChanged(sender, e)
    End Sub


    Private Sub valecaja()
        oValeCaja = oValeCajaMgr.Load(nbValeCajaID.Value)

        If oValeCaja Is Nothing Then

            MessageBox.Show("Vale de Caja Incorrecto", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            If oValeCaja.MontoUtilizado > 0 Or oValeCaja.StastusRegistro = False Then

                MessageBox.Show("Vale de Caja Utilizado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                If (Me.txtCantidadaPagar.Value - Me.EBAbono.Value) < oValeCaja.Importe Then
                    Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.EBAbono.Value
                Else
                    Me.EBPago.Value = oValeCaja.Importe
                End If

            End If
        End If
    End Sub
#Region "Metodos de Validacion"

    Private Sub FillFormaPago()
        'Para saber que es facturacion general
        cmbFormaPago1.DataSource = oCatalogoFormasPagoMgr.GetAll("I").Tables(0)
        cmbFormaPago1.DropDownList.Columns.Add("Cod.")
        cmbFormaPago1.DropDownList.Columns.Add("Descripción")
        cmbFormaPago1.DropDownList.Columns("Cod.").DataMember = "CodFormasPago"
        cmbFormaPago1.DropDownList.Columns("Cod.").Width = 50
        cmbFormaPago1.DropDownList.Columns("Descripción").DataMember = "Descripcion"
        cmbFormaPago1.DropDownList.Columns("Descripción").Width = 150
        cmbFormaPago1.DisplayMember = "Descripcion"
        cmbFormaPago1.ValueMember = "CodFormasPago"
        cmbFormaPago1.Refresh()

    End Sub


    Private Sub FrmAbonoDPVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub EBPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBPago.Validating
        Try
            If Me.lblSaldoFavor.Text = "" Then Me.lblSaldoFavor.Text = "0"
            'VALIDAR POR QUE SI NO VA A TRONAR
            If (CType(Me.lblSaldoFavor.Text, Integer) < CType(EBPago.Text, Integer)) And Me.cmbFormaPago1.Text = "S" Then
                MessageBox.Show("El monto a pagar no puede ser mayor al saldo a favor", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                EBPago.Focus()
                Exit Sub
                'VALIDAR POR QUE SI NO VA A TRONAR
            ElseIf Me.cmbFormaPago1.Text = "S" Then
                Me.lblSaldoFavor.Text = Format(CType(Me.lblSaldoFavor.Text, Double) - CType(EBPago.Text, Double), "$###,###,###.#0")
            End If

        Catch ex As Exception

        End Try
    End Sub





    Private Sub EBNumTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBNumTarj.Validating
        Try
            If EBNumTarj.Text = String.Empty Then
                MessageBox.Show("El número de tarjeta no puede ser nulo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub EBAutorizacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBAutorizacion.Validating
        Try
            If EBAutorizacion.Text = String.Empty Then
                MessageBox.Show("El número de autorización no puede ser nulo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub


#End Region


    Private Function Fm_bolTxtValidarFP() As Boolean

        If Me.cmbFormaPago1.Text = String.Empty Then
            MsgBox("No ha seleccionado la forma de pago.", MsgBoxStyle.Exclamation, "DPTienda")
            cmbFormaPago1.Focus()
            Exit Function
        End If

        If EBPago.Text <= 0 Then
            MessageBox.Show("El abono debe ser mayor a $0", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EBPago.Focus()
            Exit Function
        End If


        If cmbFormaPago1.Value = "TACR" Or cmbFormaPago1.Value = "TADB" Then
            If EBTipoTarj.Text = String.Empty Then
                MsgBox("No ha especificado el tipo de tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBIDTipoTarj.Focus()
                Exit Function
            End If
            If EBBanco.Text = String.Empty Then
                MsgBox("No ha especificado el banco de la tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBIDBanco.Focus()
                Exit Function
            End If
            If EBNumTarj.Text = String.Empty Then
                MsgBox("No ha especificado el numero de tarjeta.", MsgBoxStyle.Exclamation, "DPTienda")
                EBNumTarj.Focus()
                Exit Function
            End If
            If EBAutorizacion.Text = String.Empty Then
                MsgBox("No ha especificado el numero de autorización.", MsgBoxStyle.Exclamation, "DPTienda")
                EBAutorizacion.Focus()
                Exit Function
            End If
        End If
        Return True
    End Function

    Private Sub LimpiaDatCaptFP()
        cmbFormaPago1.Text = String.Empty
        EBPago.Text = 0
        EBIDTipoTarj.Text = String.Empty
        EBTipoTarj.Text = String.Empty
        EBIDBanco.Text = String.Empty
        EBBanco.Text = String.Empty
        EBNumTarj.Text = String.Empty
        EBAutorizacion.Text = String.Empty
        EBPagoCom.Text = 0
        oPorcComision = 0
        cmbFormaPago1.Focus()
        EBPagoCom.Value = 0
        nbValeCajaID.Text = "0"
    End Sub

    Private Sub uitnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnAgregar.Click

        '<Validación>
        If (Fm_bolTxtValidarFP() = False) Then
            Exit Sub
        End If
        '</Validación>

        If (Me.EBAbono.Value + Me.EBPago.Value) - ComisionBancaria <= Me.txtCantidadaPagar.Value Then

            ComisionBancaria += EBPagoCom.Value 'Aumento Comision

            Dim drRow As DataRow

            drRow = dsDataSet.Tables("FormasPago").NewRow

            drRow("IDFormaPago") = cmbFormaPago1.Value
            drRow("FormaPago") = cmbFormaPago1.Text
            drRow("Monto") = EBPago.Value
            drRow("IDTipoTarjeta") = EBIDTipoTarj.Text
            drRow("TipoTarjeta") = EBTipoTarj.Text
            drRow("IDBanco") = EBIDBanco.Text
            drRow("Banco") = EBBanco.Text
            drRow("NumTarjeta") = EBNumTarj.Text
            drRow("NumAutorizacion") = EBAutorizacion.Text
            drRow("Comision") = EBPagoCom.Value
            drRow("Total") = EBPago.Value + EBPagoCom.Value
            drRow("ValeCajaID") = Me.nbValeCajaID.Value ''Almacenamos IDValeCaja
            drRow("Usuario") = oAppContext.Security.CurrentUser.Name
            drRow("Fecha") = Date.Today
            drRow("StatusRegistro") = True

            dsDataSet.Tables("FormasPago").Rows.Add(drRow)
            dsDataSet.AcceptChanges()

            EBAbono.Value = EBAbono.Value + (EBPago.Value + EBPagoCom.Value)

            Me.txtEfectivo.Value = EBAbono.Value - ComisionBancaria

            If Me.cmbFormaPago1.Value = "VCJA" Then '''Sacamos diferencia para ver si se generá otro vale

                difValeCaja = oValeCaja.Importe - Me.EBAbono.Value
                oValeCaja.MontoUtilizado = Me.EBPago.Value
                'CmbFormaPago.Items.Remove("A")'Si solo se permite un vale de caja
                Me.EBPago.ReadOnly = False
                Me.nbValeCajaID.Enabled = False
                addVale()
            ElseIf Me.cmbFormaPago1.Value = "EFEC" Then

                'CmbFormaPago.Items.Remove("E")

            End If



            LimpiaDatCaptFP()

        Else
            MessageBox.Show("El monto del abono no puede ser mayor a Cantidad a Pagar", "DPTienda", MessageBoxButtons.OK)
        End If

    End Sub


#Region "Control Tipo Tarjeta"

    Private Sub EBIDTipoTarj_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDTipoTarj.ButtonClick
        Sm_BuscarTT(True)
    End Sub

    Private Sub Sm_BuscarTT(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EBIDTipoTarj.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoTipoTarjetasOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oTipoTarjeta = Nothing
                oTipoTarjeta = oCatalogoTipoTarjetasMgr.Load(oOpenRecordDlg.Record.Item("CodTipoTarjeta"))

                EBIDTipoTarj.Text = oTipoTarjeta.ID
                EBTipoTarj.Text = oTipoTarjeta.Descripcion

            End If

        Else

            On Error Resume Next

            oTipoTarjeta = Nothing
            oTipoTarjeta = oCatalogoTipoTarjetasMgr.Load(EBIDTipoTarj.Text.Trim)

            If oTipoTarjeta.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                EBIDTipoTarj.Text = oTipoTarjeta.ID
                EBTipoTarj.Text = oTipoTarjeta.Descripcion
            End If

        End If

    End Sub

    Private Sub EBIDTipoTarj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBIDTipoTarj.Validating
        Try
            Sm_BuscarTT()
        Catch ex As Exception
            MessageBox.Show("El tipo de tarjeta no es númerico", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub EBIDTipoTarj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDTipoTarj.KeyDown
        If e.KeyCode = Keys.Enter Then
            Sm_BuscarTT()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            Sm_BuscarTT(True)
        End If
    End Sub

#End Region

#Region "Control Banco"
    Private Sub EBIDBanco_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBIDBanco.ButtonClick
        Sm_BuscarBanc(True)
    End Sub

    Private Sub Sm_BuscarBanc(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EBIDBanco.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoBancosOpenRecordDialogView
            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next
                oBancos = Nothing
                oBancos = oCatalogoBancosMgr.Load(oOpenRecordDlg.Record.Item("CodBanco"))

                EBIDBanco.Text = oBancos.ID
                EBBanco.Text = oBancos.Descripcion

            End If

        Else

            On Error Resume Next

            oBancos = Nothing
            oBancos = oCatalogoBancosMgr.Load(EBIDBanco.Text.Trim)

            If oBancos.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                EBIDBanco.Text = oBancos.ID
                EBBanco.Text = oBancos.Descripcion
            End If
        End If

    End Sub

    Private Sub EBIDBanco_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EBIDBanco.Validating
        Sm_BuscarBanc()
    End Sub

    Private Sub EBIDBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EBIDBanco.KeyDown
        If e.KeyCode = Keys.Enter Then
            Sm_BuscarBanc()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            Sm_BuscarBanc(True)
        End If
    End Sub
#End Region


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub nbValeCajaID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbValeCajaID.Validating

        oValeCaja = oValeCajaMgr.Load(nbValeCajaID.Value)

        If oValeCaja Is Nothing Then

            MessageBox.Show("Vale de Caja Incorrecto", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            If oValeCaja.MontoUtilizado > 0 Or oValeCaja.StastusRegistro = False Then

                MessageBox.Show("Vale de Caja Utilizado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                If (Me.txtCantidadaPagar.Value - Me.EBAbono.Value) < oValeCaja.Importe Then
                    Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.EBAbono.Value
                Else
                    Me.EBPago.Value = oValeCaja.Importe
                End If

            End If
        End If

    End Sub

    Private Sub GridFormaPago_RecordsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFormaPago.RecordsDeleted

        'If EBFormaPago.Text = "EFECTIVO" Then
        If Me.cmbFormaPago1.Value = "EFEC" Then
            'CmbFormaPago.Items.Add("E")
        ElseIf Me.cmbFormaPago1.Value = "VCJA" Then
            'CmbFormaPago.Items.Add("A")Solo un vale
            oValeCaja = Nothing
            Me.EBPago.ReadOnly = False
            Me.nbValeCajaID.Enabled = False

            For Each row As DataRow In dsValeCaja.Tables("ValesCajas").Rows
                If row("ValeCajaID") = Me.nbValeCajaID.Value Then
                    row.Delete()
                End If
            Next
            dsValeCaja.Tables("ValesCajas").AcceptChanges()

        End If
        'TODO: RAMIRO ver que rollo por que no entra
        If Me.cmbFormaPago1.Text = "S" Then
            oAsociado.SaldoDPVale += Me.EBPago.Text
        Else
            'Me.txtBonificacion.Text -= EBPago.Value
        End If

        EBAbono.Value = EBAbono.Value - (EBPago.Value + EBPagoCom.Value)

        If Me.cmbFormaPago1.Value = "TACR" Or Me.cmbFormaPago1.Value = "TADB" Then
            ComisionBancaria -= EBPagoCom.Value
        End If

        Me.txtEfectivo.Value = EBAbono.Value - ComisionBancaria
        dsDataSet.AcceptChanges()
        LimpiaDatCaptFP()
    End Sub

    Private Sub EBPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBPago.LostFocus
        EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
    End Sub

    Private Sub GridFormaPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridFormaPago.Click
        Try

            Dim oCurrentRow As GridEXRow
            Dim odrDataRow As DataRowView

            oCurrentRow = GridFormaPago.GetRow()

            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            With odrDataRow
                cmbFormaPago1.Value = .Item(0)
                'EBFormaPago.Text = .Item(1)
                EBPago.Value = .Item(2)
                EBIDTipoTarj.Text = .Item(3)
                EBTipoTarj.Text = .Item(4)
                EBIDBanco.Text = .Item(5)
                EBBanco.Text = .Item(6)
                EBNumTarj.Text = .Item(7)
                EBAutorizacion.Text = .Item(8)
                EBPagoCom.Value = .Item(9)
                Me.nbValeCajaID.Value = .Item("ValeCajaID")
            End With

            oCurrentRow = Nothing
            odrDataRow = Nothing

        Catch ex As Exception

        End Try


    End Sub

    Private Sub addVale()
        Dim drRow As DataRow

        drRow = dsValeCaja.Tables("ValesCajas").NewRow

        drRow("ValeCajaID") = oValeCaja.ValeCajaID
        drRow("TipoDocumento") = oValeCaja.TipoDocumento
        drRow("FolioDocumento") = oValeCaja.FolioDocumento
        drRow("DocumentoID") = oValeCaja.DocumentoID
        drRow("CodCliente") = oValeCaja.CodCliente
        drRow("Nombre") = oValeCaja.Nombre
        drRow("Importe") = oValeCaja.Importe
        drRow("MontoUtilizado") = oValeCaja.MontoUtilizado
        drRow("ValeGenerado") = oValeCaja.ValeGenerado
        drRow("DevEfectivo") = oValeCaja.DevEfectivo
        drRow("Motivo") = oValeCaja.Motivo
        drRow("Fecha") = oValeCaja.Fecha
        drRow("Usuario") = oValeCaja.Usuario
        drRow("StatusRegistro") = oValeCaja.StastusRegistro
        dsValeCaja.Tables("ValesCajas").Rows.Add(drRow)
        dsValeCaja.AcceptChanges()

    End Sub

    Private Sub cmbFormaPago1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago1.ValueChanged
        Select Case cmbFormaPago1.Value
            Case "VCJA"
                'Me.EBFormaPago.Text = "VALE DE CAJA"
                Me.Label14.Text = "Folio Vale de Caja"
                nbValeCajaID.Text = "0"
                EBPago.Text = "0"
                Me.nbValeCajaID.Visible = True
                Me.EBPago.ReadOnly = True
                Me.nbValeCajaID.Enabled = True
                ActivaDatTC(False)
            Case "TACR"
                'Me.EBFormaPago.Text = "TARJETA DE CRÉDITO"
                oPorcComision = oAbonoCreditoDirectoMgr.ApplicationContext.ApplicationConfiguration.ComisionTarjetaCredito
                Me.EBIDTipoTarj.Text = "TE"
                Me.EBTipoTarj.Text = "Tarjeta Electrónica"
                EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
                ActivaDatTC(True)
                'Me.EBIDTipoTarj.Enabled = False
                nbValeCajaID.Text = "0"
                EBPago.Text = "0"
                Me.EBPago.ReadOnly = False
                Me.nbValeCajaID.Enabled = False
                Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.txtEfectivo.Value
            Case "TADB"
                'Me.EBFormaPago.Text = "TARJETA DE DÉBITO"
                'Me.EBFormaPago.Text = "TARJETA BANCARIA"
                oPorcComision = oAbonoCreditoDirectoMgr.ApplicationContext.ApplicationConfiguration.ComisionTarjetaCredito
                EBPagoCom.Value = CDbl(EBPago.Value) * (CDbl(oPorcComision) / 100)
                ActivaDatTC(True)
                Me.EBPago.ReadOnly = False
                Me.nbValeCajaID.Enabled = False
                Me.EBIDTipoTarj.Text = "TE"
                Me.EBTipoTarj.Text = "Tarjeta Electrónica"
                Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.txtEfectivo.Value
                nbValeCajaID.Text = "0"
                EBPago.Text = "0"
            Case "EFEC"
                'Me.EBFormaPago.Text = "EFECTIVO"
                nbValeCajaID.Text = "0"
                EBPago.Text = "0"
                oPorcComision = 0
                ActivaDatTC(False)
                Me.EBPago.ReadOnly = False
                Me.nbValeCajaID.Enabled = False
                Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.txtEfectivo.Value
            Case "S"
                'Me.EBFormaPago.Text = "SALDO A FAVOR"
                nbValeCajaID.Text = "0"
                EBPago.Text = "0"
                oPorcComision = 0
                ActivaDatTC(False)
                Me.EBPago.ReadOnly = False
                Me.nbValeCajaID.Enabled = False
                Me.lblSaldoFavor.Text = Format(oAsociado.SaldoDirectoTienda, "$###,###,###.#0")
                Me.EBPago.Value = Me.txtCantidadaPagar.Value - Me.txtEfectivo.Value
        End Select

    End Sub

    Private Sub uitnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uitnNuevo.Click

    End Sub
End Class
