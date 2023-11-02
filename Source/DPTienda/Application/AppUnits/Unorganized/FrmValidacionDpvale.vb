Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports System.IO
Imports System.Collections.Generic

Public Class FrmValidacionDpvale
    Inherits System.Windows.Forms.Form
    Dim oFactura As Factura
    Dim oFacturaMgr As FacturaManager
    Dim oFirmaMgr As FirmaManager
    Dim bolTecleara As Boolean = False
    Dim str As String = ""
    Friend WithEvents eNCodigoVale As Janus.Windows.GridEX.EditControls.EditBox
    Private oClienteSAP As ClientesSAP
    Private b_Codct As Boolean = False


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal oFacturaExp As Factura)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        IniciaObjetos()

        oFactura = oFacturaExp
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiBtdAltaClientes As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents eNParesPzas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents eNMontoDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents eNAsociado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiBtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFechaCaducidad As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents UiChckCredencial As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents UiChckFirma As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents PicBxFirma As System.Windows.Forms.PictureBox
    Friend WithEvents EdNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents exbGuardarCliente As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents pbAvance As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents lblLabel14 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmValidacionDpvale))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EdNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.PicBxFirma = New System.Windows.Forms.PictureBox()
        Me.UiChckCredencial = New Janus.Windows.EditControls.UICheckBox()
        Me.UiChckFirma = New Janus.Windows.EditControls.UICheckBox()
        Me.eNAsociado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.eNMontoDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.eNParesPzas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.edNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebFechaCaducidad = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiBtdAltaClientes = New Janus.Windows.EditControls.UIButton()
        Me.UiBtnOk = New Janus.Windows.EditControls.UIButton()
        Me.exbGuardarCliente = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbAvance = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblLabel14 = New System.Windows.Forms.Label()
        Me.eNCodigoVale = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.PicBxFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exbGuardarCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.eNCodigoVale)
        Me.ExplorerBar1.Controls.Add(Me.EdNombreCliente)
        Me.ExplorerBar1.Controls.Add(Me.PicBxFirma)
        Me.ExplorerBar1.Controls.Add(Me.UiChckCredencial)
        Me.ExplorerBar1.Controls.Add(Me.UiChckFirma)
        Me.ExplorerBar1.Controls.Add(Me.eNAsociado)
        Me.ExplorerBar1.Controls.Add(Me.eNMontoDPVale)
        Me.ExplorerBar1.Controls.Add(Me.eNParesPzas)
        Me.ExplorerBar1.Controls.Add(Me.edNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebClienteID)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaCaducidad)
        Me.ExplorerBar1.Controls.Add(Me.UiBtdAltaClientes)
        Me.ExplorerBar1.Controls.Add(Me.UiBtnOk)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Icon = CType(resources.GetObject("ExplorerBarGroup1.Icon"), System.Drawing.Icon)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(504, 398)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EdNombreCliente
        '
        Me.EdNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EdNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EdNombreCliente.BackColor = System.Drawing.SystemColors.Info
        Me.EdNombreCliente.Enabled = False
        Me.EdNombreCliente.Location = New System.Drawing.Point(152, 312)
        Me.EdNombreCliente.Name = "EdNombreCliente"
        Me.EdNombreCliente.Size = New System.Drawing.Size(349, 23)
        Me.EdNombreCliente.TabIndex = 10
        Me.EdNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EdNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'PicBxFirma
        '
        Me.PicBxFirma.Location = New System.Drawing.Point(264, 56)
        Me.PicBxFirma.Name = "PicBxFirma"
        Me.PicBxFirma.Size = New System.Drawing.Size(237, 110)
        Me.PicBxFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBxFirma.TabIndex = 33
        Me.PicBxFirma.TabStop = False
        '
        'UiChckCredencial
        '
        Me.UiChckCredencial.BackColor = System.Drawing.Color.Transparent
        Me.UiChckCredencial.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiChckCredencial.Location = New System.Drawing.Point(32, 360)
        Me.UiChckCredencial.Name = "UiChckCredencial"
        Me.UiChckCredencial.Size = New System.Drawing.Size(216, 16)
        Me.UiChckCredencial.TabIndex = 11
        Me.UiChckCredencial.Text = "¿Se Presentó Credencial Oficial?"
        Me.UiChckCredencial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiChckFirma
        '
        Me.UiChckFirma.BackColor = System.Drawing.Color.Transparent
        Me.UiChckFirma.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiChckFirma.Location = New System.Drawing.Point(264, 176)
        Me.UiChckFirma.Name = "UiChckFirma"
        Me.UiChckFirma.Size = New System.Drawing.Size(216, 16)
        Me.UiChckFirma.TabIndex = 4
        Me.UiChckFirma.Text = "¿La Firma del DPVale Coincide?"
        Me.UiChckFirma.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'eNAsociado
        '
        Me.eNAsociado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.eNAsociado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.eNAsociado.BackColor = System.Drawing.SystemColors.Info
        Me.eNAsociado.Enabled = False
        Me.eNAsociado.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eNAsociado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.eNAsociado.FormatString = "0000000000"
        Me.eNAsociado.Location = New System.Drawing.Point(152, 167)
        Me.eNAsociado.Name = "eNAsociado"
        Me.eNAsociado.Size = New System.Drawing.Size(101, 23)
        Me.eNAsociado.TabIndex = 3
        Me.eNAsociado.Text = "0000000000"
        Me.eNAsociado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.eNAsociado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.eNAsociado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'eNMontoDPVale
        '
        Me.eNMontoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.eNMontoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.eNMontoDPVale.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eNMontoDPVale.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.eNMontoDPVale.Location = New System.Drawing.Point(152, 93)
        Me.eNMontoDPVale.Name = "eNMontoDPVale"
        Me.eNMontoDPVale.Size = New System.Drawing.Size(101, 23)
        Me.eNMontoDPVale.TabIndex = 1
        Me.eNMontoDPVale.Text = "$0.00"
        Me.eNMontoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.eNMontoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'eNParesPzas
        '
        Me.eNParesPzas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.eNParesPzas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.eNParesPzas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eNParesPzas.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.eNParesPzas.Location = New System.Drawing.Point(152, 130)
        Me.eNParesPzas.Name = "eNParesPzas"
        Me.eNParesPzas.Size = New System.Drawing.Size(101, 23)
        Me.eNParesPzas.TabIndex = 2
        Me.eNParesPzas.Text = "0"
        Me.eNParesPzas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.eNParesPzas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.eNParesPzas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'edNombre
        '
        Me.edNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.edNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.edNombre.BackColor = System.Drawing.SystemColors.Info
        Me.edNombre.Enabled = False
        Me.edNombre.Location = New System.Drawing.Point(152, 204)
        Me.edNombre.Name = "edNombre"
        Me.edNombre.Size = New System.Drawing.Size(349, 23)
        Me.edNombre.TabIndex = 5
        Me.edNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.edNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Nombre:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Código del Vale:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Monto del DPVale:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Pares Pieza:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Asociado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Cliente del Asociado:"
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteID.Location = New System.Drawing.Point(152, 278)
        Me.ebClienteID.MaxLength = 10
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(136, 22)
        Me.ebClienteID.TabIndex = 8
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Caducidad:"
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Enabled = False
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(152, 241)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(115, 23)
        Me.ebFecha.TabIndex = 6
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Fecha Expedición:"
        '
        'ebFechaCaducidad
        '
        '
        '
        '
        Me.ebFechaCaducidad.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaCaducidad.Enabled = False
        Me.ebFechaCaducidad.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaCaducidad.Location = New System.Drawing.Point(384, 241)
        Me.ebFechaCaducidad.Name = "ebFechaCaducidad"
        Me.ebFechaCaducidad.Size = New System.Drawing.Size(115, 23)
        Me.ebFechaCaducidad.TabIndex = 7
        Me.ebFechaCaducidad.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'UiBtdAltaClientes
        '
        Me.UiBtdAltaClientes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBtdAltaClientes.Location = New System.Drawing.Point(296, 278)
        Me.UiBtdAltaClientes.Name = "UiBtdAltaClientes"
        Me.UiBtdAltaClientes.Size = New System.Drawing.Size(120, 22)
        Me.UiBtdAltaClientes.TabIndex = 9
        Me.UiBtdAltaClientes.Text = "A&lta Clientes"
        Me.UiBtdAltaClientes.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiBtnOk
        '
        Me.UiBtnOk.Enabled = False
        Me.UiBtnOk.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBtnOk.Location = New System.Drawing.Point(400, 352)
        Me.UiBtnOk.Name = "UiBtnOk"
        Me.UiBtnOk.Size = New System.Drawing.Size(96, 32)
        Me.UiBtnOk.TabIndex = 12
        Me.UiBtnOk.Text = "&Aceptar"
        Me.UiBtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'exbGuardarCliente
        '
        Me.exbGuardarCliente.Controls.Add(Me.pbAvance)
        Me.exbGuardarCliente.Controls.Add(Me.lblLabel14)
        Me.exbGuardarCliente.Location = New System.Drawing.Point(56, 416)
        Me.exbGuardarCliente.Name = "exbGuardarCliente"
        Me.exbGuardarCliente.Size = New System.Drawing.Size(328, 96)
        Me.exbGuardarCliente.TabIndex = 195
        Me.exbGuardarCliente.Text = "ExplorerBar2"
        Me.exbGuardarCliente.Visible = False
        Me.exbGuardarCliente.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'pbAvance
        '
        Me.pbAvance.Location = New System.Drawing.Point(8, 40)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ShowPercentage = True
        Me.pbAvance.Size = New System.Drawing.Size(312, 32)
        Me.pbAvance.TabIndex = 2
        '
        'lblLabel14
        '
        Me.lblLabel14.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel14.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel14.Name = "lblLabel14"
        Me.lblLabel14.Size = New System.Drawing.Size(200, 40)
        Me.lblLabel14.TabIndex = 1
        Me.lblLabel14.Text = "Guardando Cliente ..."
        '
        'eNCodigoVale
        '
        Me.eNCodigoVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.eNCodigoVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.eNCodigoVale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eNCodigoVale.Location = New System.Drawing.Point(152, 56)
        Me.eNCodigoVale.MaxLength = 50
        Me.eNCodigoVale.Name = "eNCodigoVale"
        Me.eNCodigoVale.ReadOnly = True
        Me.eNCodigoVale.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.eNCodigoVale.Size = New System.Drawing.Size(101, 22)
        Me.eNCodigoVale.TabIndex = 0
        Me.eNCodigoVale.Text = "0"
        Me.eNCodigoVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.eNCodigoVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'FrmValidacionDpvale
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.exbGuardarCliente)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(520, 456)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 0)
        Me.Name = "FrmValidacionDpvale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validación Dportenis Vale"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.PicBxFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exbGuardarCliente.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Inicializar Objetos"

    Private Sub IniciaObjetos()
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oDPValeSAP = New cDPValeSAP
        oDPVale = New cDPVale
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFirmaMgr = New FirmaManager(oAppContext, oConfigCierreFI)
        oFactura = oFacturaMgr.Create
        oClientesMgr = New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oCliente = oClientesMgr.CreateAlterno
    End Sub

#End Region

#Region "Variables"

    Private oSAPMgr As ProcesoSAPManager
    Public oDPValeSAP As cDPValeSAP
    Public oDPVale As cDPVale
    Dim oCliente As ClienteAlterno
    Dim oClientesMgr As ClientesManager

#End Region

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (11.04.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit
    'Public oDPValeS2C As Dictionary(Of String, Object) 'InfoValeS2Credit
    'Dim oPromocionesS2C As Dictionary(Of String, Object) 'PromocionesS2Credit
    'Dim oSegurosS2C As Dictionary(Of String, Object) 'SegurosS2Credit
    'Public oClienteResS2C As List(Of Dictionary(Of String, Object)) 'ResultadoClienteS2Credit

#End Region

#Region "Propiedades"

    Public Property DPValeSAP() As cDPValeSAP
        Get
            Return oDPValeSAP
        End Get
        Set(ByVal Value As cDPValeSAP)
            oDPValeSAP = Value
        End Set
    End Property

#End Region

#Region "Eventos de Controles"

    Private Sub FrmValidacionDpvale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        End If
        If Me.ActiveControl Is Me.eNCodigoVale And Not e.KeyCode = Keys.Enter And Me.eNCodigoVale.ReadOnly = True Then
            str = str & Chr(e.KeyCode)
            'MsgBox(e.KeyCode)
        ElseIf Me.ActiveControl Is Me.eNCodigoVale And Me.eNCodigoVale.ReadOnly = True Then
            str = str.PadLeft(10, "0")
            If str <> "" And str.Length > 9 Then
                str = Mid(str, str.Length - 9)
                eNCodigoVale.Text = str
                str = ""
            Else
                str = ""
            End If

        End If

    End Sub

    Private Function BuscarVentaSAPCAR(ByRef oFact As Factura, ByVal Referencia As String) As Boolean
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable
        Dim result As Boolean = True

        htParams.Add("sap-client", oSAPMgr.SAPApplicationConfig.ClienteCAR)

        htParams.Add("REFERENCIA", Referencia)

        '--------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '--------------------------------------------------------------------
        Dim oRetail As ProcesosRetail
        oRetail = New ProcesosRetail("/sap/bc/z_rest_service", "GET")

        oFact = oRetail.BuscarVenta(htParams)

    End Function


    Private Function BuscarVenta(ByVal Referencia As String, ByRef pedido As String) As Boolean
        Dim Result As Boolean = False
        Dim oFact As Factura
        Dim oFacturasMgr = New FacturaManager(oAppContext)

        oFact = Nothing
        oFact = oFacturasMgr.Create

        '--------------------------------------------------------------------------------------
        ' MLVARGAS (06/10/2021) Buscar la factura en BD Local o con el servicio de SAP CAR
        '--------------------------------------------------------------------------------------

        BuscarVentaSAPCAR(oFact, Referencia)

        If Not oFact Is Nothing Then
            pedido = oFact.PedidoID
            Result = True
        End If

        Return Result

    End Function


    Private Sub eNCodigoVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eNCodigoVale.KeyDown
        Dim byteFirma As Byte()
        Try

            'If eNCodigoVale.Text.Trim() <> String.Empty Then
            If e.KeyCode = Keys.Enter Then
                If eNCodigoVale.Text.Trim() = "" Then Exit Sub
                '***Aki pide la confirmacion del codigo del vale, para evitar que ponga el codigo equivoco.
                Dim strCodDPVale As String = ""
                If IsNumeric(Me.eNCodigoVale.Text.Trim()) Then
                    strCodDPVale = Me.eNCodigoVale.Text.PadLeft(10, "0")
                Else
                    strCodDPVale = Me.eNCodigoVale.Text.Trim()
                End If
                If bolTecleara = True Then
                    If IsNumeric(Me.eNCodigoVale.Text.Trim()) Then
                        If Not InputBox("Confirme Código DpVale: ", Me.Text, "", 400, 300).PadLeft(10, "0").Equals(strCodDPVale) Then
                            MsgBox("El codigo es diferente al seleccionado!", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    Else
                        If Not InputBox("Confirme Código DpVale: ", Me.Text, "", 400, 300).Trim().Equals(strCodDPVale) Then
                            MsgBox("El codigo es diferente al seleccionado!", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    End If
                End If


                '------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 20/06/2022: Validar si el DPVale no fué ya utilizado en otra venta, se busca la referencia con SAPCAR
                '------------------------------------------------------------------------------------------------------------------

                If oAppSAPConfig.Inventario Or oAppSAPConfig.SiHay Then
                    Dim pedido As String = String.Empty
                    If BuscarVenta("DPVL-" & strCodDPVale, pedido) Then
                        MessageBox.Show("Para la referencia DPVL-" & strCodDPVale & " ya existe un pedido de venta, con folio: " & pedido & ", favor de comunicarlo a soporte", "DPVale", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta usado
                        Exit Sub
                        'Me.DialogResult = DialogResult.Cancel
                    End If
                End If


                ''Cambiar por una ruta de configuración
                'Dim oConURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
                'oConURed.Conecta()

                'If Not Directory.Exists(oConfigCierreFI.Ruta & "\Firmas") Then
                '    Directory.CreateDirectory(oConfigCierreFI.Ruta & "\Firmas")
                'Else
                '    'Obtener la lista de todos los archivos
                '    Dim strFiles() As String = Directory.GetFileSystemEntries(oConfigCierreFI.Ruta & "\Firmas\", "*.BMP")

                '    For Each strFile As String In strFiles
                '        If Now.AddDays(-1).ToShortDateString = File.GetCreationTime(strFile).ToShortDateString Then
                '            If File.Exists(strFile) Then File.Delete(strFile)
                '        End If
                '    Next

                'End If
                If IsNumeric(Me.eNCodigoVale.Text.Trim()) Then
                    Me.oDPVale.INUMVA = Me.eNCodigoVale.Text.PadLeft(10, "0")
                Else
                    Me.oDPVale.INUMVA = Me.eNCodigoVale.Text.Trim()
                End If

                'Me.oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & Me.eNCodigoVale.Text.PadLeft(10, "0") & ".bmp"

                'If File.Exists(Me.oDPVale.I_RUTA) Then
                Me.oDPVale.I_RUTA = "X"
                'End If

                '-------------------------------------------------------------------------------------------------
                ' JNAVA (07.07.2016): Valida DPVale en S2Credit si esta activo como validador o esta en paralelo
                '-------------------------------------------------------------------------------------------------
                Dim FirmaDistrS2C As Image
                Dim NombreDistrS2C As String = String.Empty
                If oConfigCierreFI.AplicarS2Credit Then
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistrS2C, NombreDistrS2C)
                Else
                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                End If
                '-------------------------------------------------------------------------------------------------
                If oDPVale.EsElectronico Then
                    oDPValeSAP.EsCalzado = oDPVale.EsCalzado
                    oDPValeSAP.PromocionValeElectronico = oDPVale.PromocionValeElectronico
                    If oDPVale.EsCalzado = False Then
                        MessageBox.Show("El vale no es de calzado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    Dim oCSAP As ClientesSAP
                    'oCSAP = GetCliente(ebClienteID.Text, oFactura.CodTipoVenta)
                    oCSAP = GetClienteDPVale(CStr(oDPVale.InfoDPVALE.Rows(0)!CODCT).PadLeft(10, "0"))
                    If oCSAP.Status <> 1 Then
                        MessageBox.Show("El cliente esta bloqueado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                'Me.oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & Me.eNCodigoVale.Text.PadLeft(10, "0") & ".bmp"

                Me.oDPValeSAP.InfoDPVALE = oDPVale.InfoDPVALE
                Me.oDPValeSAP.IDDPVale = oDPVale.INUMVA
                Me.oDPValeSAP.Plaza = oDPVale.EPLAZA
                Me.oDPValeSAP.ValeElectronico = oDPVale.EsElectronico
                'rgermain 15.10.2016: Si es S2Credit el saldo disponible esta en la propiedad LimiteCreditoPrestamo
                If oConfigCierreFI.AplicarS2Credit Then
                    Me.oDPValeSAP.LimiteCredito = oDPVale.LimiteCreditoPrestamo
                Else
                    Me.oDPValeSAP.LimiteCredito = oDPVale.LimiteCredito
                End If

                Me.oDPValeSAP.Congelado = oDPVale.Congelado

                If oDPVale.EEXIST = "S" Then

                    '-------------------------------------------------------------------------------------------------'-----------------------------------------------------
                    'rgermain 14.10.2016: En este caso el limite de credito de prestamo es el saldo disponible, se guardo el valor ahi para no generar una nueva propiedad
                    '                     al objeto
                    '-------------------------------------------------------------------------------------------------'-----------------------------------------------------
                    If Me.oDPValeSAP.LimiteCredito <= 0 Then
                        DPValeSAP = Nothing
                        MsgBox("El Acreditado no tiene saldo disponible. Verificar con la plaza DPVale.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.DialogResult = DialogResult.Cancel
                        Exit Sub
                    End If
                    If Me.oDPValeSAP.Congelado = "X" Then
                        DPValeSAP = Nothing
                        MessageBox.Show("El Asociado esta congelado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.Cancel
                        Exit Sub
                    End If
                    If Me.oDPValeSAP.Plaza = String.Empty Then
                        DPValeSAP = Nothing
                        MessageBox.Show("No hay Plaza", "sin Plaza", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.Cancel
                        Exit Sub
                    End If

                    If oDPVale.ESTATU = "A" Then

                        If Me.oDPValeSAP.Plaza.Trim.ToUpper <> oAppSAPConfig.Plaza.Trim.ToUpper Then
                            If MessageBox.Show("El Dpvale indicado pertenece a otra plaza, ¿Estas seguro de aplicarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                Me.DialogResult = DialogResult.Cancel
                                Exit Sub
                            End If
                            '-----------------------------------------------------------------------------------------------
                            'I FLIZARRAGA 25/02/2014: Vuelve a validar el número de Vale en caso de pertenecer a otra Plaza
                            '-----------------------------------------------------------------------------------------------
                            'Dim vale As String = InputBox("Introduzca el numero de DPVale", "DPVale", "")
                            'If vale = "" Then
                            '    Me.DialogResult = DialogResult.Cancel
                            '    Exit Sub
                            'Else
                            '    If vale.Trim() <> CStr(eNCodigoVale.Value).Trim() Then
                            '        Me.DialogResult = DialogResult.Cancel
                            '        Exit Sub
                            '    End If
                            'End If
                            '----------------------------------------------------------------------------------------------
                            'F FLIZARRAGA 25/02/2014
                            '----------------------------------------------------------------------------------------------
                        End If


                        '----------------------------------------------------------------------------------------------
                        ' JNAVA (08.07.2016): Si paso por S2Credit, obtenemos la firma del distribuidor
                        '----------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            Me.PicBxFirma.Image = FirmaDistrS2C
                        Else
                            '----------------------------------------------------------------------------------------------
                            ' JNAVA (08.07.2016): Si paso por SAP, obtenemos la firma del distribuidor
                            '----------------------------------------------------------------------------------------------
                            byteFirma = Me.oFirmaMgr.GetImagenFirmaAsociado(CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " "))
                            If Not byteFirma Is Nothing And Not IsDBNull(byteFirma) Then

                                Dim oFirmaAsociado() As Byte = CType(byteFirma, Byte())
                                Dim msFotoAsociado As New MemoryStream(oFirmaAsociado)
                                If Not PicBxFirma.Image Is Nothing Then
                                    PicBxFirma.Image.Dispose()
                                End If
                                Me.PicBxFirma.Image = Image.FromStream(msFotoAsociado)

                            Else
                                PicBxFirma.Image = Nothing
                            End If
                        End If

                        'If File.Exists(Me.oDPVale.I_RUTA) Then

                        'PicBxFirma.Image = Image.FromFile(Me.oDPVale.I_RUTA)

                        'Else
                        '    PicBxFirma.Image = Nothing
                        'End If

                        If MsgBox("¿Coinciden las Firmas?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                            Me.eNCodigoVale.Focus()
                            Me.UiChckFirma.Checked = False
                        Else
                            Me.UiChckFirma.Checked = True
                            Me.eNMontoDPVale.Focus()
                        End If

                        Dim oRow As DataRow
                        oRow = Me.oDPValeSAP.InfoDPVALE.Rows(0)
                        Me.oDPValeSAP.IDAsociado = CStr(oRow("KUNNR"))
                        If Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 1, 4) = "0000" Then
                            oDPValeSAP.FechaExpedicion = Now.Date
                            oDPValeSAP.FechaCreacion = Now.Date
                        Else
                            oDPValeSAP.FechaExpedicion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
                            oDPValeSAP.FechaCreacion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
                        End If

                        If Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 1, 4) = "0000" Then
                            oDPValeSAP.FechaInicial = Now.Date
                        Else
                            oDPValeSAP.FechaInicial = Mid(oRow("FECIN"), 7, 2) & "/" & Mid(oRow("FECIN"), 5, 2) & "/" & Mid(oRow("FECIN"), 1, 4)
                        End If

                        Me.oDPValeSAP.IDCliente = CStr(oRow("CODCT")).PadLeft(10, "0")
                        Me.oDPValeSAP.RMONTODPVALE = CDec(oRow("Monto"))
                        Me.oDPValeSAP.RPARES_PZAS = CInt(oRow("Pares"))

                        eNAsociado.Text = Me.oDPValeSAP.IDAsociado

                        '----------------------------------------------------------------------------------------------
                        ' JNAVA (08.07.2016): Si paso por S2Credit, obtenemos el nombre del distribuidor
                        '----------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            Me.oDPValeSAP.NombreAsociado = NombreDistrS2C.TrimEnd
                            Me.edNombre.Text = NombreDistrS2C.TrimEnd
                        Else
                            Me.oDPValeSAP.NombreAsociado = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(Me.oDPValeSAP.IDAsociado))
                            Me.edNombre.Text = Me.oDPValeSAP.NombreAsociado
                        End If

                        ''---------------------------------------------------------------------------------------------------------------------------------------------
                        ''Validamos los datos del Cliente
                        ''---------------------------------------------------------------------------------------------------------------------------------------------
                        'oCliente.Clear()
                        'Me.oClientesMgr.Load(Me.oDPValeSAP.IDAsociado, oCliente, oFactura.CodTipoVenta)
                        HabilitaBotones()
                        If CStr(oRow("CODCT")).Trim() <> "" Then
                            Me.ebClienteID.Text = CStr(oRow("CODCT")).PadLeft(10, "0")
                            Dim oCSAP As ClientesSAP
                            oCSAP = GetClienteDPVale(ebClienteID.Text)
                            If oCSAP.Status <> 1 Then
                                MessageBox.Show("Cliente Bloqueado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            Else
                                ebClienteID.Text = ebClienteID.Text.PadLeft(10, "0")
                                '-------------------------------------------------

                                oDPValeSAP.IDCliente = ebClienteID.Text
                                oDPValeSAP.NombreCliente = oCSAP.Nombre & " " & oCSAP.Apellidos 'FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPValeSAP.IDCliente))

                                ''-----------------------------------------------------
                                '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
                                ''-----------------------------------------------------
                                'BuscaClienteS2Credit(oDPValeSAP.NombreCliente)
                                ''-----------------------------------------------------

                                Me.EdNombreCliente.Text = oDPValeSAP.NombreCliente.TrimEnd
                            End If
                            b_Codct = True
                        End If
                        '*****'
                        bolTecleara = False
                        Me.eNCodigoVale.ReadOnly = True
                        '*****'

                        'SendKeys.Send("{TAB}")


                        If CStr(oRow("REVAL")) = "X" Then
                            EsRevale(oDPValeSAP)
                            oDPValeSAP.IsRevale = True 'JNAVA 30.09.2014: Para saber SI es Revale
                        Else
                            Me.oDPValeSAP.REVALE = False
                            oDPValeSAP.IsRevale = False 'JNAVA 30.09.2014: Para saber si NO es Revale
                        End If


                        '----------------------------------------------------------------------------------
                        ' JNAVA 29.09.2014: Identificamos si es un REREVALE
                        '----------------------------------------------------------------------------------
                        If CStr(oRow("ZREVAL2")) = "X" Then
                            EsRevale(oDPValeSAP) 'Hacemos lo mismo que con el REVALE
                            oDPValeSAP.IsReRevale = True 'JNAVA 30.09.2014: Para saber SI es ReRevale
                        Else
                            oDPValeSAP.IsReRevale = False 'JNAVA 30.09.2014: Para saber si NO es ReRevale
                        End If

                        '-------------------------------------------------------------------------------------
                        'FLIZARRAGA 27/07/2018: Se valida si el cliente final no esta topado o bloqueado
                        '-------------------------------------------------------------------------------------
                        If oDPValeSAP.IsRevale Or oDPValeSAP.IsReRevale Then
                            Dim strFecin As String = CStr(oDPValeSAP.InfoDPVALE.Rows(0)!FECIN)
                            Dim fecin As DateTime = Mid(strFecin, 7, 2) & "/" & Mid(strFecin, 5, 2) & "/" & Mid(strFecin, 1, 4)
                            If fecin.Date < DateTime.Now.Date Then
                                MessageBox.Show("El DPVale esta expirado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ClearForm()
                                HabilitaBotones()
                                Exit Sub
                            End If
                            If oS2Credit.SearchCustomersWithAmount(ebClienteID.Text.Trim(), oDPValeSAP.RMONTODPVALE) = True Then
                                If oClienteSAP.Status <> 1 Then
                                    MessageBox.Show("Cliente Bloqueado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    ClearForm()
                                    HabilitaBotones()
                                    Exit Sub
                                End If
                            Else
                                ClearForm()
                                HabilitaBotones()
                                Exit Sub
                            End If
                        End If
                        '-----------------------------------------------------------------------------------
                        'FLIZARRAGA 21/07/2017: Identifica si es un vale electronico
                        '-----------------------------------------------------------------------------------

                        If oDPValeSAP.ValeElectronico Then
                            oDPValeSAP.MontoElectronico = oDPVale.MontoElectronico
                            EsValeElectronico(oDPValeSAP)
                        End If

                        

                    Else

                        If oDPVale.ESTATU = "E" Then
                            DPValeSAP = Nothing
                            MessageBox.Show("El Dpvale está Expirado", "esta expirado", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta usado
                            Me.DialogResult = DialogResult.Cancel
                        Else
                            If oDPVale.ESTATU = "U" Then
                                DPValeSAP = Nothing
                                MessageBox.Show("El Dpvale ya esta Usado", "esta usado", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta usado
                                Me.DialogResult = DialogResult.Cancel
                            Else
                                If oDPVale.ESTATU = "C" Then
                                    MessageBox.Show("El Dpvale esta Cancelado", "esta Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta Cancelado
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    MessageBox.Show("El Dpvale no se encuentra disponible. Favor de verificar.", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information) 'esta Cancelado
                                    Me.DialogResult = DialogResult.Cancel
                                End If
                            End If
                            'oConURed.Desconecta()
                            'oConURed.Desconecta()
                        End If
                    End If
                Else
                    DPValeSAP = Nothing
                    MessageBox.Show("El Dpvale no Existe ", "No existe", MessageBoxButtons.OK, MessageBoxIcon.Information) 'NO existe
                    Me.DialogResult = DialogResult.Cancel
                    'oConURed.Desconecta()
                    'oConURed.Desconecta()

                End If
            Else
                If e.KeyCode = Keys.Escape Then
                    Me.DialogResult = DialogResult.Cancel
                End If
                If e.KeyCode = Keys.T Then
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.TeclearDpVale") = True Then
                        Me.eNCodigoVale.ReadOnly = False
                        bolTecleara = True
                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            End If
            'Else
            '    MessageBox.Show("Se Necesita Numero de DPVale", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    eNCodigoVale.Focus()
            'End If
        Catch ex As Exception
            Throw New ApplicationException("[eNCodigoVale_KeyDown]", ex)
        End Try

    End Sub

    Private Sub ExplorerBar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ExplorerBar1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub eNMontoDPVale_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles eNMontoDPVale.GotFocus
        Me.eNParesPzas.Text = 0
    End Sub

    Private Sub eNMontoDPVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eNMontoDPVale.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        Else
            If e.KeyCode = Keys.Enter Then
                If Me.eNMontoDPVale.Value < oDPValeSAP.EBPago And Me.eNMontoDPVale.Value > 0 Then
                    MessageBox.Show("Es mayor el monto a pagar con DPVale que el monto del vale será necesaria otra forma de pago.", "Monto Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    UiChckFirma.Focus() 'SendKeys.Send("{TAB}{TAB}")
                Else
                    If Me.eNMontoDPVale.Value > 0 Then
                        UiChckFirma.Focus()
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub eNParesPzas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles eNParesPzas.GotFocus
        Me.eNMontoDPVale.Text = 0
    End Sub

    Private Sub eNParesPzas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eNParesPzas.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        Else
            If e.KeyCode = Keys.Enter Then
                If Me.eNParesPzas.Value < oDPValeSAP.ParesPzas And Me.eNParesPzas.Value > 0 Then
                    'MessageBox.Show("La cantidad de Pares Piezas Facturado es mayor que los Pares Piezas del DPVale, favor de corregir el número  de Pares Piezas a Facturar.", "Pares Piezas Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.eNParesPzas.Focus()
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub UiBtdAltaClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBtdAltaClientes.Click
        AltadeCliente()
    End Sub

    Private Sub UiBtdAltaClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBtdAltaClientes.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub UiBtnOk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiBtnOk.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub UiBtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBtnOk.Click
        Try
            '-------------------------------------------------------------------------------------------------------------------------
            'JNAVA (19.04.2016): Validamos que se haya ingresado el cliente correctamente
            '-------------------------------------------------------------------------------------------------------------------------
            If (Me.ebClienteID.Text.Trim = "" OrElse Me.ebClienteID.Text.Trim("0") = "") AndAlso Me.EdNombreCliente.Text.Trim = "" Then
                MessageBox.Show("El Cliente no puede ir Vacio. Favor de Verificar.", "Validación de DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            '-------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/02/2014: Se agrego validacion de DPVale
            '-------------------------------------------------------------------------------------------------------------------------
            Dim input As String = InputBox("Confirme el Código DPVale", "DPVale", "")
            If input = "" Then
                MessageBox.Show("El campo no puede ir Vacio", "DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim NumVale As String = input.Trim()
            If NumVale.Trim() <> Me.eNCodigoVale.Text.Trim() Then
                MessageBox.Show("El DPVale ingresado no coincide con el capturado", "DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            '-------------------------------------------------------------------------------------------------------------------------
            'JNAVA (30.06.2015): Se agrego validacion de Edad cuando esta activa la generacion de Seguros de Vida de DPVale
            '-------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.GenerarSeguro Then
                Me.oClientesMgr.Load(Me.ebClienteID.Text, oCliente, "V")
                Dim Edad As Integer = 0
                Edad = DateDiff(DateInterval.Year, oCliente.FechaNacimiento, Date.Now)
                If Edad >= 100 Then
                    MessageBox.Show("La Fecha de Nacimiento del Cliente es incorrecta. Favor de Verificar.", "DPVale", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If b_Codct = True Then
                Dim oCSAP As ClientesSAP
                oCSAP = GetClienteDPVale(ebClienteID.Text)
                If oS2Credit.SearchCustomersWithAmount(ebClienteID.Text.Trim(), DPValeSAP.EBPago) = True Then
                    If oCSAP.Status <> 1 Then
                        MessageBox.Show("Cliente Bloqueado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        ebClienteID.Text = ebClienteID.Text.PadLeft(10, "0")
                        '-------------------------------------------------

                        oDPValeSAP.IDCliente = ebClienteID.Text
                        oDPValeSAP.NombreCliente = oCSAP.Nombre & " " & oCSAP.Apellidos 'FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPValeSAP.IDCliente))

                        ''-----------------------------------------------------
                        '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
                        ''-----------------------------------------------------
                        'BuscaClienteS2Credit(oDPValeSAP.NombreCliente)
                        ''-----------------------------------------------------

                        Me.EdNombreCliente.Text = oDPValeSAP.NombreCliente.TrimEnd
                    End If

                Else
                    Exit Sub
                End If
            End If
            If Me.UiChckCredencial.Checked And Me.UiChckFirma.Checked And Me.EdNombreCliente.Text <> String.Empty _
                And (Me.eNMontoDPVale.Value <> 0 Or Me.eNParesPzas.Value <> 0) And Me.eNCodigoVale.Text <> String.Empty Then

                '-------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 27/06/2013: Se agrego la variable del datatable para cargar promociones del Compre Hoy y Pague despues
                '-------------------------------------------------------------------------------------------------------------------------
                Dim dtDetalleVale As DataTable
                If MessageBox.Show("¿Está seguro que estos datos son correctos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    'Todo salio bien
                    'Me.eNParesPzas.Value <--- pzas de revale
                    'oDPValeSAP.ParesPzas <--- Pzas de Factura

                    'TODO: Aragon .- Rehacer proceso de validacion.
                    If eNMontoDPVale.Value > 0 Then 'Vale por Monto
                        'Primer Validacion (Limite de Credito)
                        If oDPValeSAP.EBPago > oDPValeSAP.LimiteCredito Then 'En caso de que el credito disponible no cubra la factura.
                            MessageBox.Show("El crédito del Asociado no es suficiente para cubrir el monto que desea pagar con dpvale, Credito Disponible: " & Format(oDPValeSAP.LimiteCredito, "c"), "Credito Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If DialogResult.Yes = MessageBox.Show("¿Desea Continuar con el Proceso de Facturación y Utilizar otra forma de pago?, Nota: No se generara Revale.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                                oDPValeSAP.REVALE = False
                                oDPValeSAP.RMONTODPVALE = 0

                                'Ponemos como monto de forma de pago el limite de credito.
                                oDPValeSAP.MONTODPVALE = eNMontoDPVale.Value 'Monto Capturado en la ventana de Validacion.
                                oDPValeSAP.MontoUtilizado = oDPValeSAP.LimiteCredito

                                'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador
                                '--------------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                Else
                                    oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                oDPValeSAP.ParesPzas = 0

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                '--------------------------------------------------------------------------------------------
                                'Me.DialogResult = DialogResult.OK
                                If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                    MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    Me.DialogResult = DialogResult.OK
                                End If

                                'Exit Sub

                            Else
                                Me.DialogResult = DialogResult.Cancel
                                'Exit Sub
                            End If
                        Else 'El Limite de Credito Cubre la Factura. Se verifica que cubra el revale.
                            'Ponemos el monto a pagar con DPortenis Vale.
                            If oDPValeSAP.ValeElectronico Then
                                If eNMontoDPVale.Value > oDPValeSAP.MontoElectronico Then
                                    MessageBox.Show("El monto a pagar no debe ser mayor al monto al que tiene permitido el vale electronico", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    eNMontoDPVale.Focus()
                                    Exit Sub
                                End If
                            End If
                            If eNMontoDPVale.Value < oDPValeSAP.EBPago Then
                                If oDPValeSAP.ValeElectronico Then
                                    oDPValeSAP.MONTODPVALE = oDPValeSAP.MontoElectronico 'Se captura el monto del vale electronico
                                Else
                                    oDPValeSAP.MONTODPVALE = eNMontoDPVale.Value 'Monto Capturado en la ventana de Validacion.
                                End If
                                oDPValeSAP.MontoUtilizado = eNMontoDPVale.Value 'Monto capturado en la distribucion de Formas de Pago. (frmPago).
                            Else
                                If oDPValeSAP.ValeElectronico Then
                                    oDPValeSAP.MONTODPVALE = oDPValeSAP.MontoElectronico
                                Else
                                    oDPValeSAP.MONTODPVALE = eNMontoDPVale.Value
                                End If
                                'Monto Capturado en la ventana de Validacion.
                                oDPValeSAP.MontoUtilizado = oDPValeSAP.EBPago 'Monto capturado en la distribucion de Formas de Pago. (frmPago).
                            End If


                            If oDPValeSAP.MONTODPVALE > oDPValeSAP.MontoUtilizado Then
                                Dim decMontoRevale As Decimal
                                Dim decSobranteDespuesFacturacion As Decimal
                                decMontoRevale = oDPValeSAP.MONTODPVALE - oDPValeSAP.MontoUtilizado
                                decSobranteDespuesFacturacion = oDPValeSAP.LimiteCredito - oDPValeSAP.MontoUtilizado

                                If decSobranteDespuesFacturacion > 0 Then

                                    If decMontoRevale > decSobranteDespuesFacturacion Then
                                        Dim decDiferencia As Decimal
                                        decDiferencia = decSobranteDespuesFacturacion
                                        MessageBox.Show("El saldo del distribuidor solo permite realizar un ReVale por .- " & Format(decDiferencia, "c"), "ReVale", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        If DialogResult.Yes = MessageBox.Show("¿Desea continuar con el proceso de Facturación? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                            oDPValeSAP.REVALE = True
                                            oDPValeSAP.RMONTODPVALE = decDiferencia
                                            'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                            '--------------------------------------------------------------------------------------------
                                            ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                            '--------------------------------------------------------------------------------------------
                                            If oConfigCierreFI.AplicarS2Credit Then
                                                '----------------------------------------------------------------------------------------
                                                ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                                '----------------------------------------------------------------------------------------
                                                oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                            Else
                                                oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                            End If
                                            '--------------------------------------------------------------------------------------------

                                            oDPValeSAP.ParesPzas = 0

                                            '--------------------------------------------------------------------------------------------
                                            ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                            '--------------------------------------------------------------------------------------------
                                            'Me.DialogResult = DialogResult.OK
                                            If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                                MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                Me.DialogResult = DialogResult.Cancel
                                            Else
                                                Me.DialogResult = DialogResult.OK
                                            End If

                                            'Exit Sub
                                        Else
                                            Me.DialogResult = DialogResult.Cancel
                                            'Exit Sub
                                        End If

                                    Else
                                        oDPValeSAP.REVALE = True
                                        oDPValeSAP.RMONTODPVALE = decMontoRevale
                                        'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                        '--------------------------------------------------------------------------------------------
                                        ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                        '--------------------------------------------------------------------------------------------
                                        If oConfigCierreFI.AplicarS2Credit Then
                                            '----------------------------------------------------------------------------------------
                                            ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                            '----------------------------------------------------------------------------------------
                                            oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                        Else
                                            oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                        End If
                                        '--------------------------------------------------------------------------------------------

                                        oDPValeSAP.ParesPzas = 0

                                        '--------------------------------------------------------------------------------------------
                                        ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                        '--------------------------------------------------------------------------------------------
                                        'Me.DialogResult = DialogResult.OK
                                        If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                            MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            Me.DialogResult = DialogResult.Cancel
                                        Else
                                            Me.DialogResult = DialogResult.OK
                                        End If

                                        'Exit Sub
                                    End If

                                Else
                                    If DialogResult.Yes = MessageBox.Show("El saldo del cliente no permite realizar un Revale. Saldo = $0.00." & Microsoft.VisualBasic.vbCrLf & " ¿Desea continuar con el proceso de Facturación? Nota.- No se generará ReVale.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                        oDPValeSAP.REVALE = False
                                        oDPValeSAP.RMONTODPVALE = 0
                                        'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                        '--------------------------------------------------------------------------------------------
                                        ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                        '--------------------------------------------------------------------------------------------
                                        If oConfigCierreFI.AplicarS2Credit Then
                                            '----------------------------------------------------------------------------------------
                                            ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                            '----------------------------------------------------------------------------------------
                                            oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                        Else
                                            oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                        End If
                                        '--------------------------------------------------------------------------------------------

                                        oDPValeSAP.ParesPzas = 0

                                        '--------------------------------------------------------------------------------------------
                                        ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                        '--------------------------------------------------------------------------------------------
                                        'Me.DialogResult = DialogResult.OK
                                        If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                            MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            Me.DialogResult = DialogResult.Cancel
                                        Else
                                            Me.DialogResult = DialogResult.OK
                                        End If

                                        'Exit Sub
                                    Else
                                        Me.DialogResult = DialogResult.Cancel
                                        'Exit Sub
                                    End If

                                End If

                            Else 'No hay ReVale.
                                oDPValeSAP.REVALE = False
                                oDPValeSAP.RMONTODPVALE = 0
                                'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                '--------------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                    '----------------------------------------------------------------------------------------
                                    oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                Else
                                    oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                oDPValeSAP.ParesPzas = 0

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                '--------------------------------------------------------------------------------------------
                                'Me.DialogResult = DialogResult.OK
                                If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                    MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    Me.DialogResult = DialogResult.OK
                                End If

                                'Exit Sub
                            End If

                        End If
                    ElseIf Me.eNParesPzas.Value > 0 Then 'Vale por pares pzas.

                        'Primero validamos que el vale cubra todas las piezas de la factura.
                        ' si no las cubre calculamos el monto en base a las pzas mas caras.

                        ' el revale por piezas es menor a las que se facturaran
                        If Me.eNParesPzas.Value < oDPValeSAP.ParesPzas Then

                            'Ordeno de forma descendente los articulos mas caros
                            Dim foundRows As DataRow() = Me.oFactura.Detalle.Tables(0).Select("", "Importe desc")
                            'Variables para llevar el control
                            Dim ContPzas As Integer = 0
                            Dim ContImporte As Decimal = 0

                            'barro los resultados
                            For Each rrow As DataRow In foundRows

                                'si hay un descuento se le resta el importe y lo multiplico por el IVA
                                If rrow("descuento") > 0 Then
                                    ContPzas += CInt(rrow("Cantidad"))
                                    ContImporte += ((CDec(rrow("Total")) - CDec(rrow("descuento"))) _
                                                    * (1 + oAppContext.ApplicationConfiguration.IVA))
                                Else
                                    'en caso de no tener descuento solo le saco el IVA
                                    ContPzas += CInt(rrow("Cantidad"))
                                    ContImporte += (rrow("Total") * (1 + oAppContext.ApplicationConfiguration.IVA))
                                End If

                                If ContPzas = Me.eNParesPzas.Value Then
                                    'YA ESTA COMPLETO no se necesita hacer el resistro cubrio con los articulos
                                    oDPValeSAP.MONTODPVALE = ContImporte 'Posible Monto Utilizado
                                    oDPValeSAP.MontoUtilizado = ContImporte 'Posible Monto Utilizado
                                    Exit For
                                End If

                                'si ya me pase de piezas le tengo que quitar las que no necesito
                                If ContPzas > Me.eNParesPzas.Value Then
                                    'Sacar diferencia y obtener el # piezas que no necesito
                                    Dim dif As Integer = Math.Abs(ContPzas - Me.eNParesPzas.Value)
                                    'Al contador le resto las que Me pase
                                    ContPzas = Math.Abs(ContPzas - dif)
                                    'Ahora el importe le quito el costo con iva y menos descuento 
                                    'de las que no necesitare
                                    If rrow("descuento") > 0 Then
                                        Dim decDesc As Decimal = (rrow("descuento") / rrow("Cantidad"))
                                        ContImporte = ContImporte - ((dif * CDec(rrow("Importe"))) - (dif * decDesc)) * (1 + oAppContext.ApplicationConfiguration.IVA)
                                    Else
                                        ContImporte = ContImporte - ((dif * rrow("Importe")) * (1 + oAppContext.ApplicationConfiguration.IVA))
                                    End If

                                    oDPValeSAP.MONTODPVALE = ContImporte 'Posible Monto Utilizado
                                    oDPValeSAP.MontoUtilizado = ContImporte 'Posible Monto Utilizado
                                    Exit For

                                End If

                            Next

                        Else
                            oDPValeSAP.MONTODPVALE = oDPValeSAP.EBPago 'Posible Monto Utilizado 
                            oDPValeSAP.MontoUtilizado = oDPValeSAP.EBPago 'Posible Monto Utilizado
                        End If

                        'Segundo Ya tenemos el posible monto utilizado del credito.
                        'Ahora validamos que el Limite de Cretido sea mayor al Monto Utilizado.
                        If oDPValeSAP.MontoUtilizado > oDPValeSAP.LimiteCredito Then 'El limiete de credito no alcanza a cubrir el monto utilizado.

                            MessageBox.Show("El crédito del Asociado no es suficiente para cubrir el monto que desea pagar con dpvale, Credito Disponible: " & Format(oDPValeSAP.LimiteCredito, "c"), "Credito Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If DialogResult.Yes = MessageBox.Show("¿Desea Continuar con el Proceso de Facturación y Utilizar otra forma de pago?, Nota: No se generara Revale.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                                oDPValeSAP.REVALE = False
                                oDPValeSAP.RMONTODPVALE = 0

                                'Ponemos como monto de forma de pago el limite de credito.
                                oDPValeSAP.MONTODPVALE = eNMontoDPVale.Value 'Monto Capturado en la ventana de Validacion.
                                oDPValeSAP.MontoUtilizado = oDPValeSAP.LimiteCredito

                                'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                '--------------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                    '----------------------------------------------------------------------------------------
                                    oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                Else
                                    oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                '--------------------------------------------------------------------------------------------
                                'Me.DialogResult = DialogResult.OK
                                If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                    MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    Me.DialogResult = DialogResult.OK
                                End If
                                'Exit Sub

                            Else
                                Me.DialogResult = DialogResult.Cancel
                                'Exit Sub
                            End If

                        Else 'Validamos Para ver si se genera ReVale Pares/Pzas.
                            'En los ReVales de Pares/Pzas. no se valida el Limite de Credito.
                            'por que no sabemos por cuanto vaya a ser la compra con ese ReVale.


                            If Me.eNParesPzas.Text > oDPValeSAP.ParesPzas Then
                                oDPValeSAP.REVALE = True
                                oDPValeSAP.RPARES_PZAS = Math.Abs(CInt(Me.eNParesPzas.Text) - oDPValeSAP.ParesPzas)

                                'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                '--------------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                    '----------------------------------------------------------------------------------------
                                    oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                Else
                                    oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                '--------------------------------------------------------------------------------------------
                                'Me.DialogResult = DialogResult.OK
                                If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                    MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    Me.DialogResult = DialogResult.OK
                                End If
                                'Exit Sub

                            ElseIf Me.eNParesPzas.Text < oDPValeSAP.ParesPzas Then
                                MessageBox.Show("El vale no cubre el total de Pzas. de la Factura.", "Vale Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                If DialogResult.Yes = MessageBox.Show("¿Desea Continuar con el Proceso de Facturación y Utilizar otra forma de pago por .- " & Format(oDPValeSAP.EBPago - oDPValeSAP.MontoUtilizado, "c") & "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                    'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                    '--------------------------------------------------------------------------------------------
                                    ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                    '--------------------------------------------------------------------------------------------
                                    If oConfigCierreFI.AplicarS2Credit Then
                                        '----------------------------------------------------------------------------------------
                                        ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                        '----------------------------------------------------------------------------------------
                                        oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                    Else
                                        oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                    End If
                                    '--------------------------------------------------------------------------------------------

                                    '--------------------------------------------------------------------------------------------
                                    ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                    '--------------------------------------------------------------------------------------------
                                    'Me.DialogResult = DialogResult.OK
                                    If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                        MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Me.DialogResult = DialogResult.Cancel
                                    Else
                                        Me.DialogResult = DialogResult.OK
                                    End If
                                    'Exit Sub
                                Else
                                    Me.DialogResult = DialogResult.Cancel
                                    'Exit Sub
                                End If
                            Else
                                oDPValeSAP.REVALE = False
                                oDPValeSAP.RPARES_PZAS = 0
                                'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                                '--------------------------------------------------------------------------------------------
                                If oConfigCierreFI.AplicarS2Credit Then
                                    '----------------------------------------------------------------------------------------
                                    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                                    '----------------------------------------------------------------------------------------
                                    oDPValeSAP.NUMDE = oS2Credit.ObtenerPromociones(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                Else
                                    oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MontoUtilizado, oDPValeSAP.IDDPVale, oDPValeSAP.FechaCobro, dtDetalleVale)
                                End If
                                '--------------------------------------------------------------------------------------------

                                '--------------------------------------------------------------------------------------------
                                ' JNAVA (13.09.2016): Validamos si se cargaron promociones, si no, no continua con la venta
                                '--------------------------------------------------------------------------------------------
                                'Me.DialogResult = DialogResult.OK
                                If oDPValeSAP.NUMDE = 0 AndAlso dtDetalleVale Is Nothing Then
                                    MessageBox.Show("No hay promociones cargadas para la Plaza " & oAppSAPConfig.Plaza & " y el monto $" & oDPValeSAP.MontoUtilizado & ". Favor de contactar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.DialogResult = DialogResult.Cancel
                                Else
                                    Me.DialogResult = DialogResult.OK
                                End If

                                'Exit Sub
                            End If
                        End If
                    End If
                    'TODO: Aragon .- Fin Rehacer proceso de validacion.


                    '' el revale por piezas es menor a las que se facturaran
                    'If Me.eNParesPzas.Value < oDPValeSAP.ParesPzas And Me.eNParesPzas.Value > 0 Then

                    '    'Ordeno de forma descendente los articulos mas caros
                    '    Dim foundRows As DataRow() = Me.oFactura.Detalle.Tables(0).Select("", "Importe desc")
                    '    'Variables para llevar el control
                    '    Dim ContPzas As Integer = 0
                    '    Dim ContImporte As Decimal = 0

                    '    'barro los resultados
                    '    For Each rrow As DataRow In foundRows

                    '        'si hay un descuento se le resta el importe y lo multiplico por el IVA
                    '        If rrow("descuento") > 0 Then
                    '            ContPzas += CInt(rrow("Cantidad"))
                    '            ContImporte += ((CDec(rrow("Total")) - CDec(rrow("descuento"))) _
                    '                            * (1 + oAppContext.ApplicationConfiguration.IVA))
                    '        Else
                    '            'en caso de no tener descuento solo le saco el IVA
                    '            ContPzas += CInt(rrow("Cantidad"))
                    '            ContImporte += (rrow("Total") * (1 + oAppContext.ApplicationConfiguration.IVA))
                    '        End If

                    '        If ContPzas = Me.eNParesPzas.Value Then
                    '            'YA ESTA COMPLETO no se necesita hacer el resistro cubrio con los articulos
                    '            oDPValeSAP.MONTODPVALE = ContImporte
                    '            oDPValeSAP.MontoUtilizado = ContImporte
                    '            Exit For
                    '        End If

                    '        'si ya me pase de piezas le tengo que quitar las que no necesito
                    '        If ContPzas > Me.eNParesPzas.Value Then
                    '            'Sacar diferencia y obtener el # piezas que no necesito
                    '            Dim dif As Integer = Math.Abs(ContPzas - Me.eNParesPzas.Value)
                    '            'Al contador le resto las que Me pase
                    '            ContPzas = Math.Abs(ContPzas - dif)
                    '            'Ahora el importe le quito el costo con iva y menos descuento 
                    '            'de las que no necesitare
                    '            If rrow("descuento") > 0 Then
                    '                Dim decDesc As Decimal = (rrow("descuento") / rrow("Cantidad"))
                    '                ContImporte = ContImporte - ((dif * CDec(rrow("Importe"))) - (dif * decDesc)) * (1 + oAppContext.ApplicationConfiguration.IVA)
                    '            Else
                    '                ContImporte = ContImporte - ((dif * rrow("Importe")) * (1 + oAppContext.ApplicationConfiguration.IVA))
                    '            End If

                    '            oDPValeSAP.MONTODPVALE = ContImporte
                    '            oDPValeSAP.MontoUtilizado = ContImporte
                    '            Exit For

                    '        End If

                    '    Next

                    'Else
                    '    If CDec(Me.eNMontoDPVale.Text) = 0 Or CDec(Me.eNMontoDPVale.Text) > oDPValeSAP.EBPago Then
                    '        oDPValeSAP.MONTODPVALE = oDPValeSAP.EBPago
                    '        oDPValeSAP.MontoUtilizado = oDPValeSAP.EBPago
                    '    Else
                    '        oDPValeSAP.MONTODPVALE = CDec(Me.eNMontoDPVale.Text)
                    '        oDPValeSAP.MontoUtilizado = CDec(Me.eNMontoDPVale.Text)
                    '    End If
                    'End If

                    ''Obtener las quincenas en las que se pagara dpvale
                    'oDPValeSAP.NUMDE = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(Me.oDPValeSAP.Plaza, Date.Now.Date, oDPValeSAP.MONTODPVALE)

                    'If Me.eNMontoDPVale.Text > oDPValeSAP.EBPago Then
                    '    oDPValeSAP.REVALE = True
                    '    oDPValeSAP.RMONTODPVALE = Math.Abs(CDec(Me.eNMontoDPVale.Text) - oDPValeSAP.EBPago)
                    'End If

                    'If Me.eNParesPzas.Text > oDPValeSAP.ParesPzas Then
                    '    oDPValeSAP.REVALE = True
                    '    oDPValeSAP.RPARES_PZAS = Math.Abs(CInt(Me.eNParesPzas.Text) - oDPValeSAP.ParesPzas)
                    'End If

                    'oDPValeSAP.ParesPzas = Me.eNParesPzas.Value

                    'If Me.eNParesPzas.Text = 0 Then
                    '    'TODO Aragon .- Saldo DPVales
                    '    If oDPValeSAP.MONTODPVALE > oDPValeSAP.LimiteCredito And eNMontoDPVale.Value <> 0 Then
                    '        MessageBox.Show("El crédito del Asociado no es suficiente para cubrir el monto que desea pagar con dpvale, Credito Disponible: " & Format(oDPValeSAP.LimiteCredito, "c"), "Credito Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        If DialogResult.Yes = MessageBox.Show("¿Desea Continuar con el Proceso de Facturación y Utilizar otra forma de pago?, Nota: No se generara Revale.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    '            oDPValeSAP.REVALE = False
                    '            oDPValeSAP.RMONTODPVALE = 0

                    '            'Ponemos como monto de forma de pago el limite de credito.
                    '            oDPValeSAP.MONTODPVALE = oDPValeSAP.LimiteCredito
                    '            oDPValeSAP.MontoUtilizado = oDPValeSAP.LimiteCredito

                    '            Me.DialogResult = DialogResult.OK
                    '            Exit Sub
                    '        Else
                    '            Me.DialogResult = DialogResult.Cancel
                    '            Exit Sub
                    '        End If
                    '    Else
                    '        If eNMontoDPVale.Value > oDPValeSAP.LimiteCredito And eNMontoDPVale.Value <> 0 Then
                    '            MessageBox.Show("El crédito del Asociado no es suficiente para cubrir el monto de revale, crédito disponible: " & Format(oDPValeSAP.LimiteCredito, "c"), "Credito Insuficiente para revale", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '            If DialogResult.Yes = MessageBox.Show("¿Desea Continuar con el proceso de facturación? Nota: Se generara revale por el Crédito disponible del Asociado: " & Format(Math.Abs(oDPValeSAP.MONTODPVALE - oDPValeSAP.LimiteCredito), "c"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    '                oDPValeSAP.REVALE = True
                    '                oDPValeSAP.RMONTODPVALE = Math.Abs(oDPValeSAP.MONTODPVALE - oDPValeSAP.LimiteCredito)
                    '                Me.DialogResult = DialogResult.OK
                    '                Exit Sub
                    '            Else
                    '                Me.DialogResult = DialogResult.Cancel
                    '                Exit Sub
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    'Me.DialogResult = DialogResult.OK

                Else
                    'No hace nada
                End If
                '--------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 28/05/2013: Validamos si esta activa la promocion Compre ahora y pague despues y le preguntamos si desea aprovechar 
                'la promoción, siempre y cuando este como opcional en la configuracion
                '--------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 27/06/2013: Se obtiene la fecha de SAP y se valida que la promocion sea del dia para hoy y le preguntamos si
                'desea aprovechar la promocion y en caso contrario toma la configuracion la que tiene mas quincena pero comienza a partir de
                'la compra.
                '--------------------------------------------------------------------------------------------------------------------------------
                'Dim Hoy As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim Hoy As DateTime = DateTime.Now
                Dim vale As DataRow = GetRowFechaCobro(dtDetalleVale, Hoy)
                If Not vale Is Nothing Then
                    If oConfigCierreFI.CompreAhoraPDOpcional Then
                        If oDPValeSAP.ValeElectronico = False OrElse (oDPValeSAP.PromocionValeElectronico = 1 OrElse oDPValeSAP.PromocionValeElectronico = 3) Then
                            If MessageBox.Show("La promoción Compre Ahora y Pague Después está activa" & vbCrLf & vbCrLf & "¿Desea aprovecharla y que se aplique en esta venta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                                oDPValeSAP.NUMDE = CInt(vale!NUMDE)
                                oDPValeSAP.FechaCobro = CDate(vale!FECCO)
                                '-----------------------------------------------------------------------------------
                                ' JNAVA (04.04.2017): Obtenemos el ID de la promocion de s2credit aplicada
                                '-----------------------------------------------------------------------------------
                                If Not dtDetalleVale Is Nothing AndAlso dtDetalleVale.Columns.Contains("PromocionID") Then
                                    oDPValeSAP.PromocionID = CStr(vale!PromocionID)
                                End If
                                '-----------------------------------------------------------------------------------
                            Else
                                oDPValeSAP.FechaCobro = Hoy
                                Dim emptyDateRow As DataRow = GetRowEmptyFecha(dtDetalleVale)
                                If Not emptyDateRow Is Nothing Then
                                    oDPValeSAP.NUMDE = CInt(emptyDateRow!NUMDE)
                                    '-----------------------------------------------------------------------------------
                                    ' JNAVA (04.04.2017): Obtenemos el ID de la promocion de s2credit aplicada
                                    '-----------------------------------------------------------------------------------
                                    If Not dtDetalleVale Is Nothing AndAlso dtDetalleVale.Columns.Contains("PromocionID") Then
                                        oDPValeSAP.PromocionID = CStr(emptyDateRow!PromocionID)
                                    End If
                                    '-----------------------------------------------------------------------------------
                                End If
                            End If
                        End If
                    Else
                        oDPValeSAP.NUMDE = CInt(vale!NUMDE)
                        oDPValeSAP.FechaCobro = CDate(vale!FECCO)
                        '-----------------------------------------------------------------------------------
                        ' JNAVA (04.04.2017): Obtenemos el ID de la promocion de s2credit aplicada
                        '-----------------------------------------------------------------------------------
                        If Not dtDetalleVale Is Nothing AndAlso dtDetalleVale.Columns.Contains("PromocionID") Then
                            oDPValeSAP.PromocionID = CStr(vale!PromocionID)
                        End If
                        '-----------------------------------------------------------------------------------
                    End If
                    'If IsDate(oDPValeSAP.FechaCobro) AndAlso oDPValeSAP.FechaCobro > Hoy Then
                    '    If MessageBox.Show("La promoción Compre Ahora y Pague Después está activa" & vbCrLf & vbCrLf & "¿Desea aprovecharla y que se aplique en esta venta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    '        oDPValeSAP.FechaCobro = Hoy
                    '    End If
                    'End If
                Else
                    '-----------------------------------------------------------------------------------
                    ' JNAVA (04.04.2017): Obtenemos el ID de la promocion de s2credit aplicada
                    '-----------------------------------------------------------------------------------
                    If Not dtDetalleVale Is Nothing AndAlso dtDetalleVale.Columns.Contains("PromocionID") Then
                        oDPValeSAP.PromocionID = dtDetalleVale.Rows(0).Item("PromocionID")
                    End If
                    '-----------------------------------------------------------------------------------
                End If
            Else
                If Me.eNCodigoVale.Text.Trim() = String.Empty Then
                    MessageBox.Show("Ingrese Código de DPVale", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.eNCodigoVale.Focus()
                Else
                    If Me.eNMontoDPVale.Value = 0 And Me.eNParesPzas.Value = 0 Then
                        MessageBox.Show("Capture el Monto del DPVale o Cantidad Pares/Piezas.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.eNMontoDPVale.Focus()
                    Else
                        If EdNombreCliente.Text = String.Empty Then
                            MessageBox.Show("Ingrese Nombre y Apellidos del Cliente del Asociado.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.ebClienteID.Focus()
                        Else
                            If Not Me.UiChckFirma.Checked Then
                                MessageBox.Show("Favor de confirmar si coinciden las firmas.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.UiChckFirma.Focus()
                            Else
                                If Not Me.UiChckCredencial.Checked Then
                                    MessageBox.Show("Favor de confirmar si el cliente mostró identificación oficial.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.UiChckCredencial.Focus()
                                Else
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException("[UiBtnOk_Click]", ex)
        End Try
    End Sub

    Private Sub UiChckCredencial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiChckCredencial.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub UiChckFirma_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiChckFirma.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub ebFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFecha.Validating
        Me.ebFechaCaducidad.Value = Me.ebFecha.Value.AddDays(30)

        If Me.ebFecha.Value > Date.Now.Date Then
            MessageBox.Show("La Fecha del DPVale es posterior a fecha de la facturación.", "Fecha no valida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ebFecha.Focus()
        Else
            If Me.ebFechaCaducidad.Value < Date.Now.Date Then
                MessageBox.Show("Esta DPVALE ha Vencido", "vencido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ebFecha.Focus()
            Else
                Me.UiBtnOk.Enabled = True
            End If
        End If
    End Sub

    Private Sub ebFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFecha.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        Else
            If e.KeyCode = Keys.Enter Then
                Me.ebFechaCaducidad.Value = Me.ebFecha.Value.AddDays(30)

                If Me.ebFecha.Value > Date.Now.Date Then
                    MessageBox.Show("La Fecha del DPVale es posterior a fecha de la facturación.", "Fecha no valida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ebFecha.Focus()
                Else
                    If Me.ebFechaCaducidad.Value < Date.Now.Date Then
                        MessageBox.Show("Esta DPVALE ha Vencido", "vencido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ebFecha.Focus()
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ebClienteID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteID.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.DialogResult = DialogResult.Cancel
            Else
                If e.KeyCode = Keys.Enter Then
                    'Limpiar el Nombre 

                    Me.EdNombreCliente.Text = String.Empty

                    If ebClienteID.Text.Trim <> String.Empty Then
                        '-------------------------------------------------
                        ' JNAVA (08.02.2016): Adaptacion para retail
                        '-------------------------------------------------
                        Dim oCSAP As ClientesSAP
                        'oCSAP = GetCliente(ebClienteID.Text, oFactura.CodTipoVenta)
                        oCSAP = GetClienteDPVale(ebClienteID.Text)
                        If Not oCSAP Is Nothing Then
                            If oS2Credit.SearchCustomersWithAmount(ebClienteID.Text.Trim(), DPValeSAP.EBPago) = True Then
                                If oCSAP.Status = 1 Then
                                    ebClienteID.Text = ebClienteID.Text.PadLeft(10, "0")
                                    '-------------------------------------------------

                                    oDPValeSAP.IDCliente = ebClienteID.Text
                                    oDPValeSAP.NombreCliente = oCSAP.Nombre & " " & oCSAP.Apellidos 'FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPValeSAP.IDCliente))

                                    ''-----------------------------------------------------
                                    '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
                                    ''-----------------------------------------------------
                                    'BuscaClienteS2Credit(oDPValeSAP.NombreCliente)
                                    ''-----------------------------------------------------

                                    Me.EdNombreCliente.Text = oDPValeSAP.NombreCliente.TrimEnd

                                    If Me.EdNombreCliente.Text = String.Empty Then
                                        MessageBox.Show("Código de Cliente Incorrecto.", "Información Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        ebClienteID.Text = String.Empty
                                        oDPValeSAP.IDCliente = String.Empty
                                        ebClienteID.Focus()
                                    Else
                                        SendKeys.Send("{TAB}{TAB}")
                                    End If
                                Else
                                    MessageBox.Show("Cliente Bloqueado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            End If

                        Else
                            MessageBox.Show("No existe cliente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                ElseIf e.Alt And e.KeyCode = Keys.S Then
                    If oConfigCierreFI.HuellaOpcional = True Then
                        'LoadSearchForm()
                        LoadSearchFormDPVale()
                    Else
                        ProcesoBusquedaClienteCRM()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException("[ebClienteID_KeyDown]", ex)
        End Try
    End Sub

    Private Sub ebClienteID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.ButtonClick
        If oConfigCierreFI.HuellaOpcional = True Then
            'LoadSearchForm()
            LoadSearchFormDPVale()
        Else
            ProcesoBusquedaClienteCRM()
        End If
    End Sub

    Private Sub ProcesoBusquedaClienteCRM()

        'Mostrar el cuadro de busqueda manual del cliente
        'LoadSearchForm()
        LoadSearchFormDPVale()

        If Me.EdNombreCliente.Text.Trim = "" Then ebClienteID_Validating(Nothing, Nothing)

        If Me.EdNombreCliente.Text.Trim = "" Then
            If MessageBox.Show("¿Deseas dar de alta al cliente en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                AltadeCliente()
            Else
                Me.ebClienteID.Focus()
            End If
        End If

    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating
        If Me.ebClienteID.Text = String.Empty OrElse CLng(Me.ebClienteID.Text.Trim) <= 0 Then
            Me.EdNombreCliente.Text = String.Empty
            oDPValeSAP.NombreCliente = String.Empty
            ebClienteID.Focus()
        Else
            '---------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que el cliente no esté congelado.
            '---------------------------------------------------------------------------------------------------------------------------------------------
            If oAppSAPConfig.Prestamos Then
                Dim oProcesosSAP As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim strMensaje As String
                '------------------------------------------------------------------------------------
                ' JNAVA (01.08.2016):  Valida si el clietne esta congelado o adeuda un vale
                '------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    If oS2Credit.SearchCustomersWithAmount(ebClienteID.Text.Trim(), DPValeSAP.EBPago) = True Then
                        strMensaje = oS2Credit.ValidaCliente(Me.ebClienteID.Text)
                    End If
                Else
                    strMensaje = oProcesosSAP.Valida_Clientes(Me.ebClienteID.Text)
                End If
                '------------------------------------------------------------------------------------
                If Mid(Trim(strMensaje), 1, 4) = "DPVF" Then strMensaje = String.Empty
                If Mid(Trim(strMensaje), 1, 4) = "TARJ" Then strMensaje = String.Empty
                If strMensaje <> String.Empty Then
                    Me.ebClienteID.Text = String.Empty
                    Me.EdNombreCliente.Text = String.Empty
                    oDPValeSAP.NombreCliente = String.Empty
                    oDPValeSAP.IDCliente = String.Empty

                    ebClienteID.Focus()
                    MessageBox.Show(strMensaje & vbCrLf & "Comunicate ahora con las oficinas DPVale", "Cliente Congelado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
            '---------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos los datos del Cliente
            '---------------------------------------------------------------------------------------------------------------------------------------------
            oCliente.Clear()
            If oConfigCierreFI.UsarDescargaClientes = False Then oClienteSAP = GetClienteDPVale(Me.ebClienteID.Text) ', oFactura.CodTipoVenta)
            Me.oClientesMgr.Load(Me.ebClienteID.Text, oCliente, "V")
            oCliente.TipoVenta = oFactura.CodTipoVenta
            If oCliente.CodigoAlterno.Trim.PadLeft(10, "0") = "0000000000" Then
                MessageBox.Show("El folio del cliente especificado no existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If ValidaDatosObligatoriosCliente(oCliente, True) = False Then
                    'If MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "¿Deseas complementarlos en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    '    AltadeCliente(oCliente.CodigoAlterno, oCliente.TipoVenta, True)
                    'End If
                    MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "Es necesario complementarlos para continuar con la venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    AltadeCliente(oCliente.CodigoAlterno, oCliente.TipoVenta)
                End If
            End If
        End If

        ''-----------------------------------------------------
        '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
        ''-----------------------------------------------------
        'BuscaClienteS2Credit(oCliente.NombreCompleto)

    End Sub


#End Region

#Region "Metodos"

    Private Function FormatName(ByVal strname As String) As String
        Try
            Dim strApepApemNom() As String
            Dim strNombre As String = String.Empty
            Dim strApelidos As String = String.Empty

            strApepApemNom = Split(Trim(strname), "_")
            Select Case strApepApemNom.Length
                Case 6
                    strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2) & " " & strApepApemNom(3)
                Case 5
                    strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2)
                Case 4
                    strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 3
                    strNombre = Trim(strApepApemNom(2))
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 2
                    strNombre = strApepApemNom(1)
                    strApelidos = Trim(strApepApemNom(0))
                Case 1
                    strNombre = String.Empty
                    strApelidos = Trim(strApepApemNom(0))
                Case Else
                    strNombre = String.Empty
                    strApelidos = String.Empty
            End Select

            strNombre = strNombre & " " & strApelidos

            Return Trim(strNombre)

        Catch ex As Exception
            Throw New ApplicationException("[FormatName]", ex)
        End Try

    End Function

    'Private Sub LoadSearchForm()

    '    Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes

    '    oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes
    '    oOpenRecordDlg.TipoVenta = "C"
    '    oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView

    '    If (oOpenRecordDlg.CurrentView Is Nothing) Then
    '        Exit Sub
    '    End If

    '    oOpenRecordDlg.ShowDialog()

    '    If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

    '        Try
    '            Dim intClienteID As String

    '            If oOpenRecordDlg.pbCodigo = String.Empty Then

    '                Me.ebClienteID.Text = oOpenRecordDlg.Record.Item("KUNNR")
    '                Me.EdNombreCliente.Text = oOpenRecordDlg.Record.Item("NAME1") & " " & oOpenRecordDlg.Record.Item("NAME2") & " " & oOpenRecordDlg.Record.Item("NAME3") 'FormatName(oOpenRecordDlg.Record.Item("NAME1"))

    '            Else

    '                Me.ebClienteID.Text = CType(oOpenRecordDlg.pbCodigo, String)
    '                Me.EdNombreCliente.Text = oOpenRecordDlg.pbNombre 'FormatName(CType(oOpenRecordDlg.pbNombre, String))

    '            End If

    '            oDPValeSAP.IDCliente = Me.ebClienteID.Text
    '            oDPValeSAP.NombreCliente = Me.EdNombreCliente.Text
    '            'SendKeys.Send("{TAB}{TAB}")
    '            Me.UiChckCredencial.Focus()

    '        Catch ex As Exception
    '            Throw New ApplicationException("[LoadSearchForm]", ex)
    '        End Try

    '    End If

    'End Sub

    Private Sub EsRevale(ByVal oDPValeSAP As cDPValeSAP, Optional ByVal IsReReVale As Boolean = False)

        eNMontoDPVale.Enabled = False
        ebClienteID.Enabled = False
        ebFecha.Enabled = False
        eNParesPzas.Enabled = False
        UiBtdAltaClientes.Enabled = False

        ebClienteID.Text = oDPValeSAP.IDCliente
        'oDPValeSAP.NombreCliente = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPValeSAP.IDCliente))
        'Dim oClienteSAP As ClientesSAP
        '-----------------------------------------------------
        ' JNAVA (15.04.2016): Busca Cliente DPVALE
        '-----------------------------------------------------
        'oClienteSAP = GetCliente(oDPValeSAP.IDCliente, "VL")
        oClienteSAP = GetClienteDPVale(oDPValeSAP.IDCliente
                                       )
        Me.oClientesMgr.Load(Me.ebClienteID.Text, oCliente, "V")
        oDPValeSAP.NombreCliente = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos

        ''-----------------------------------------------------
        '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
        ''-----------------------------------------------------
        'BuscaClienteS2Credit(oDPValeSAP.NombreCliente)

        EdNombreCliente.Text = oDPValeSAP.NombreCliente
        ebFecha.Value = oDPValeSAP.FechaExpedicion
        ebFechaCaducidad.Value = ebFecha.Value.AddDays(30)
        eNMontoDPVale.Value = oDPValeSAP.RMONTODPVALE
        eNParesPzas.Value = oDPValeSAP.RPARES_PZAS




        UiBtnOk.Enabled = True

        'Quitar que sea revale ya se asignaron a los Text
        oDPValeSAP.RMONTODPVALE = 0
        oDPValeSAP.RPARES_PZAS = 0
        'Quitar que sea revale ya se asignaron a los Text

    End Sub

    Private Sub HabilitaBotones()

        eNMontoDPVale.Enabled = True
        ebClienteID.Enabled = True
        ebFecha.Enabled = True
        eNParesPzas.Enabled = True
        UiBtdAltaClientes.Enabled = True

        ebClienteID.Text = String.Empty
        EdNombreCliente.Text = String.Empty
        ebFecha.Value = Date.Now.Date
        ebFechaCaducidad.Value = Date.Now.Date
        eNMontoDPVale.Value = 0
        eNParesPzas.Value = 0

        '---------------------------------------------------------------------------------------------------------
        ' JNAVA (20.07.2016): Si esta activa la configuracion de S2Credit, los pares piezas los deshabilitamos
        '---------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicarS2Credit Then
            Me.eNParesPzas.Enabled = False
        End If

    End Sub

#End Region

    Private Sub FrmValidacionDpvale_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try
            If Not PicBxFirma.Image Is Nothing Then
                PicBxFirma.Image.Dispose()
                PicBxFirma.Image = Nothing
            End If
            '----------------------------------------------------------------------------------
            ' JNAVA 06/04/2014 - Validamos si se necesita caputar o no, los motivos de rechazo
            '----------------------------------------------------------------------------------
            If Me.DialogResult <> DialogResult.OK Then CapturarMotivoRechazo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardadoAutomatico(ByVal strClienteID As String, ByVal CodTipoVenta As String)
        Me.pbAvance.Value = 0
        Me.pbAvance.Minimum = 0
        Me.pbAvance.Maximum = 2
        Me.exbGuardarCliente.Left = 92
        Me.exbGuardarCliente.Top = 163
        Me.exbGuardarCliente.Visible = True
        Application.DoEvents()
        Me.pbAvance.Value = 1
        AltadeCliente(strClienteID, CodTipoVenta)
        Me.pbAvance.Value = 2
        Me.exbGuardarCliente.Visible = False
    End Sub

    Private Sub AltadeCliente(Optional ByVal ClienteID As String = "", Optional ByVal TipoCliente As String = "", Optional ByVal Complemento As Boolean = False)

        Try
            Dim frmClientes As New frmClientesSAP
            frmClientes.TipoVenta = "C" 'oDPValeSAP.TipoVenta
            frmClientes.ClienteID = ClienteID
            frmClientes.TipoCliente = TipoCliente
            frmClientes.EsDPVale = True
            frmClientes.Player = oFactura.CodVendedor

            frmClientes.ShowMeforFactura()

            If frmClientes.DialogResult = DialogResult.OK Then

                oDPValeSAP.IDCliente = frmClientes.ClienteID
                oDPValeSAP.NombreCliente = frmClientes.NombreApellidos

                ebClienteID.Text = oDPValeSAP.IDCliente
                Me.EdNombreCliente.Text = oDPValeSAP.NombreCliente

                'frmClientes.Dispose()
                'frmClientes = Nothing

            ElseIf Complemento = False Then

                Me.ebClienteID.Text = "0"
                Me.EdNombreCliente.Text = ""
                oDPValeSAP.IDCliente = "0"
                oDPValeSAP.NombreCliente = ""
                'frmClientes.Dispose()
                'frmClientes = Nothing

            End If

            frmClientes.Dispose()
            frmClientes = Nothing
        Catch ex As Exception
            Throw New ApplicationException("[UiBtdAltaClientes_Click]", ex)
        End Try

    End Sub

#Region "Compre Ahora Pague Despues"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/06/2013: Obtiene la fecha que es mayor al día de hoy, para obtener el registro
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetRowFechaCobro(ByVal dtDetalle As DataTable, ByVal Hoy As DateTime) As DataRow
        Dim fila As DataRow = Nothing
        If Not dtDetalle Is Nothing AndAlso dtDetalle.Rows.Count > 0 Then
            Dim view As New DataView(dtDetalle.Copy())
            view.Sort = "NUMDE DESC"
            For Each row As DataRow In view.Table.Rows
                Dim strFecha As String = CStr(row!FECCO)
                Dim FechaCobro As DateTime
                If strFecha.Trim() <> "" AndAlso CLng(strFecha.Trim) > 0 Then
                    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                    FechaCobro = CDate(strFecha)
                    If FechaCobro > Hoy Then
                        row("FECCO") = FechaCobro
                        fila = row
                        Return fila
                    End If
                End If
            Next
        End If
        Return fila
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/06/2013: Obtiene el elemento de los DPVales que no contiene fecha
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function GetRowEmptyFecha(ByVal dtDetalle As DataTable) As DataRow
        Dim fila As DataRow = Nothing
        Dim view As New DataView(dtDetalle.Copy())
        view.Sort = "NUMDE DESC"
        For Each row As DataRow In view.Table.Rows
            Dim strFecha As String = CStr(row!FECCO)
            If strFecha.Trim() = "" OrElse CLng(strFecha.Trim) = 0 Then
                fila = row
                Return fila
            End If
        Next
        Return fila
    End Function
#End Region

#Region "Motivos de Rechazo DPVale"
    '----------------------------------------------------------------------------------------------------------------------
    ' JNAVA 06/05/2014 - Funcion para validar si se debe mostrar o no la captura de motivos de rechazo
    '----------------------------------------------------------------------------------------------------------------------
    Private Sub CapturarMotivoRechazo()
        If oConfigCierreFI.MotivosRechazoDPVL Then 'Validamos que este la configuracion activa
            If oDPValeSAP Is Nothing OrElse oDPValeSAP.IDDPVale = String.Empty Then 'Validamos que se haya cargado o no algun vale
                Exit Sub
            Else 'Mostramos pantalla de captura de motivo de rechazos
                Dim ofrmMotivos As New frmCapturarMotivos(oDPValeSAP.IDDPVale, "3")
                ofrmMotivos.ShowDialog()
                ofrmMotivos.Dispose()
            End If
        End If
    End Sub
#End Region

    Private Function oFingerP() As Object
        Throw New NotImplementedException
    End Function

#Region "S2Credit"

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016): Valida/Busca Vale en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscarValeS2Credit(ByVal NumVale As String)
    '    If oConfigCierreFI.AplicarS2Credit Then
    '        Try
    '            oDPValeS2C = Nothing
    '            oDPValeS2C = oS2Credit.CouponSearch(NumVale)
    '            If Not oDPValeS2C Is Nothing Then
    '                oDPValeS2C.Add("idCoupon", NumVale)
    '            End If
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    'End Sub

    ''-----------------------------------------------------
    '' JNAVA (11.04.2016):  Valida/Busca cliente en S2Credit
    ''-----------------------------------------------------
    'Private Sub BuscaClienteS2Credit(ByVal NombreCliente As String)
    '    If oConfigCierreFI.AplicarS2Credit Then
    '        Try
    '            Me.oClienteResS2C = Nothing
    '            Me.oClienteResS2C = oS2Credit.SearchCustomers(NombreCliente)
    '        Catch ex As Exception
    '            'Throw ex
    '        End Try
    '    End If
    'End Sub


    ''-------------------------------------------------------------------------------
    '' JNAVA (07.07.2016): Valida el DPVale en S2 Credit
    ''-------------------------------------------------------------------------------
    'Private Function ValidaDPValeS2Credit(ByVal cdpvale As cDPVale, ByRef FirmaDistribuidor As String, ByRef NombreDistribuidor As String) As cDPVale

    '    Try

    '        '-------------------------------------------------------------------------------
    '        ' Consumimos el servicio de S2Credit
    '        '-------------------------------------------------------------------------------
    '        Me.oDPValeS2C = oS2Credit.CouponSearch(cdpvale.INUMVA)

    '        '-------------------------------------------------------------------------------
    '        ' Obtenemos Respuesta y seteamos
    '        '-------------------------------------------------------------------------------
    '        If Not oDPValeS2C Is Nothing Then

    '            oDPValeS2C.Add("idCoupon", cdpvale.INUMVA)

    '            Dim dtInfoDPVALE As New DataTable
    '            dtInfoDPVALE.Columns.Add("KUNNR")
    '            dtInfoDPVALE.Columns.Add("FECCR")
    '            dtInfoDPVALE.Columns.Add("FECIN")
    '            dtInfoDPVALE.Columns.Add("CODCT")
    '            dtInfoDPVALE.Columns.Add("Monto")
    '            dtInfoDPVALE.Columns.Add("Pares")
    '            dtInfoDPVALE.Columns.Add("REVAL")
    '            dtInfoDPVALE.Columns.Add("ZREVAL2")
    '            dtInfoDPVALE.AcceptChanges()

    '            Dim oRow As DataRow
    '            oRow = dtInfoDPVALE.NewRow
    '            oRow("KUNNR") = oDPValeS2C("idDistributor").ToString
    '            oRow("FECCR") = ""
    '            oRow("FECIN") = ""
    '            oRow("CODCT") = ""
    '            oRow("Monto") = ""
    '            oRow("Pares") = ""
    '            oRow("REVAL") = ""
    '            oRow("ZREVAL2") = ""
    '            dtInfoDPVALE.Rows.Add(oRow)
    '            dtInfoDPVALE.AcceptChanges()

    '            cdpvale.InfoDPVALE = dtInfoDPVALE 'oS2Credit.ListToDataTable(oDPValeS2C("T_DP_VALE")("T_DP_VALE"))

    '            If oDPValeS2C("status").ToString = "1" Then cdpvale.EEXIST = "S" : cdpvale.ESTATU = "A"

    '            'cdpvale.EEXIST = "S" 'oDPValeS2C("EEXIST").ToString
    '            'cdpvale.ESTATU = oDPValeS2C("ESTATU").ToString

    '            'cdpvale.EPLAZA = oDPValeS2C("EPLAZA").ToString
    '            'cdpvale.LimiteCredito = CDec(oDPValeS2C("ELCREDITO").ToString)
    '            'cdpvale.Congelado = oDPValeS2C("Congelado").ToString
    '            'cdpvale.LimiteCreditoPrestamo = CDec(oDPValeS2C("ECREDITOP").ToString)
    '            'cdpvale.FlagPrestamo = oDPValeS2C("EPRESTAMO").ToString

    '            '-------------------------------------------------------------------------------------------
    '            ' DATOS DE DISTRIBUIDOR
    '            '-------------------------------------------------------------------------------------------
    '            If oDPValeS2C("signature") Is Nothing Then
    '                FirmaDistribuidor = ""
    '            Else
    '                FirmaDistribuidor = oDPValeS2C("signature").ToString
    '            End If
    '            NombreDistribuidor = oDPValeS2C("name").ToString

    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return cdpvale

    'End Function

#End Region

#Region "DPVale AFS"

    Private Sub LoadSearchFormDPVale()

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientesDPVale 'OK

        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientesDPVale 'OK
        oOpenRecordDlg.TipoVenta = "V"
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogViewDPVale

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try
                Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    Me.ebClienteID.Text = oOpenRecordDlg.Record.Item("KUNNR")
                    Me.EdNombreCliente.Text = FormatName(oOpenRecordDlg.Record.Item("NAME1"))

                Else

                    Me.ebClienteID.Text = CType(oOpenRecordDlg.pbCodigo, String)
                    Me.EdNombreCliente.Text = FormatName(CType(oOpenRecordDlg.pbNombre, String))

                End If

                oDPValeSAP.IDCliente = Me.ebClienteID.Text
                oDPValeSAP.NombreCliente = Me.EdNombreCliente.Text

                'SendKeys.Send("{TAB}{TAB}")
                Me.UiChckCredencial.Focus()

            Catch ex As Exception
                Throw New ApplicationException("[LoadSearchFormDPVale]", ex)
            End Try

        End If

    End Sub

#End Region

#Region "Vale Electronico"

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/07/2017: Carga los datos cuando es un vale electronico
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Sub EsValeElectronico(ByVal oDPValeSAP As cDPValeSAP)

        'eNMontoDPVale.Enabled = False
        ebClienteID.Enabled = False
        ebFecha.Enabled = False
        eNParesPzas.Enabled = False
        UiBtdAltaClientes.Enabled = False
        eNMontoDPVale.Enabled = False

        ebClienteID.Text = oDPValeSAP.IDCliente
        'oDPValeSAP.NombreCliente = FormatName(oSAPMgr.ZBAPI_NOMBRE_CLIENTE(oDPValeSAP.IDCliente))
        'Dim oClienteSAP As ClientesSAP
        '-----------------------------------------------------
        ' JNAVA (15.04.2016): Busca Cliente DPVALE
        '-----------------------------------------------------
        'oClienteSAP = GetCliente(oDPValeSAP.IDCliente, "VL")
        oClienteSAP = GetClienteDPVale(oDPValeSAP.IDCliente)
        Me.oClientesMgr.Load(Me.ebClienteID.Text, oCliente, "V")
        oDPValeSAP.NombreCliente = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos

        ''-----------------------------------------------------
        '' JNAVA (11.04.2016): Valida/Busca cliente en S2Credit
        ''-----------------------------------------------------
        'BuscaClienteS2Credit(oDPValeSAP.NombreCliente)


        '------------------------------------------------------------------------------------
        ' MLVARGAS (03.10.2019): Verificar que el cliente tenga todos los datos capturados
        '------------------------------------------------------------------------------------
        If ValidaDatosObligatoriosCliente(oCliente, True) = False Then            
            MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "Es necesario complementarlos para continuar con la venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            AltadeCliente(oClienteSAP.Clienteid, oClienteSAP.TipoVenta) 'oDPValeSAP.IDCliente, oCliente.TipoVenta)
        End If


        EdNombreCliente.Text = oDPValeSAP.NombreCliente
        ebFecha.Value = oDPValeSAP.FechaExpedicion
        ebFechaCaducidad.Value = ebFecha.Value.AddDays(30)
        eNMontoDPVale.Value = oDPValeSAP.MontoElectronico
        'eNMontoDPVale.Value = oDPValeSAP.RMONTODPVALE
        eNParesPzas.Value = oDPValeSAP.RPARES_PZAS
        UiBtnOk.Enabled = True


    End Sub

#End Region

#Region "Mejoras Validacion Revale"

    Private Sub ClearForm()
        eNCodigoVale.Text = ""
        eNMontoDPVale.Value = 0
        eNParesPzas.Value = 0
        eNAsociado.Text = ""
        edNombre.Text = ""
        ebFecha.Value = DateTime.Now
        ebFechaCaducidad.Value = DateTime.Now
        ebClienteID.Text = ""
        EdNombreCliente.Text = ""
        eNCodigoVale.Focus()
    End Sub

#End Region

End Class
