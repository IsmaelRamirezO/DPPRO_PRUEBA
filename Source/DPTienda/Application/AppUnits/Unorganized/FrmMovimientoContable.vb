Imports Microsoft.VisualBasic
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU

Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta

Public Class FrmMovimientoContable
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbTipoMovimiento As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbReferencia As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents chkCuentasSimilares As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkSuprimirMovimiento As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebPorcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCuenta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbImporteBase As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebConcepto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkLstFormaPago As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChkLstTipoVenta As System.Windows.Forms.CheckedListBox
    Friend WithEvents ebOrdenImp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ChkAgregaConc As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ChkAsignarDif As Janus.Windows.EditControls.UICheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientoContable))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem14 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ChkAsignarDif = New Janus.Windows.EditControls.UICheckBox()
        Me.ChkAgregaConc = New Janus.Windows.EditControls.UICheckBox()
        Me.ebOrdenImp = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ChkLstTipoVenta = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkLstFormaPago = New System.Windows.Forms.CheckedListBox()
        Me.ebConcepto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.chkSuprimirMovimiento = New Janus.Windows.EditControls.UICheckBox()
        Me.chkCuentasSimilares = New Janus.Windows.EditControls.UICheckBox()
        Me.cbReferencia = New Janus.Windows.EditControls.UIComboBox()
        Me.ebPorcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbImporteBase = New Janus.Windows.EditControls.UIComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTipoMovimiento = New Janus.Windows.EditControls.UIComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebCuenta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ChkAsignarDif)
        Me.ExplorerBar1.Controls.Add(Me.ChkAgregaConc)
        Me.ExplorerBar1.Controls.Add(Me.ebOrdenImp)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.ChkLstTipoVenta)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ChkLstFormaPago)
        Me.ExplorerBar1.Controls.Add(Me.ebConcepto)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.chkSuprimirMovimiento)
        Me.ExplorerBar1.Controls.Add(Me.chkCuentasSimilares)
        Me.ExplorerBar1.Controls.Add(Me.cbReferencia)
        Me.ExplorerBar1.Controls.Add(Me.ebPorcentaje)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.cbImporteBase)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.cbTipoMovimiento)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebCuenta)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.ShowGroupCaption = False
        ExplorerBarGroup1.Text = "Datos Generales del Asiento Contable"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, -1)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(576, 577)
        Me.ExplorerBar1.TabIndex = 5
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ChkAsignarDif
        '
        Me.ChkAsignarDif.BackColor = System.Drawing.Color.Transparent
        Me.ChkAsignarDif.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAsignarDif.Location = New System.Drawing.Point(18, 280)
        Me.ChkAsignarDif.Name = "ChkAsignarDif"
        Me.ChkAsignarDif.Size = New System.Drawing.Size(352, 16)
        Me.ChkAsignarDif.TabIndex = 8
        Me.ChkAsignarDif.Text = "Asignar la diferencia entre los totales de la poliza"
        Me.ChkAsignarDif.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ChkAgregaConc
        '
        Me.ChkAgregaConc.BackColor = System.Drawing.Color.Transparent
        Me.ChkAgregaConc.Checked = True
        Me.ChkAgregaConc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAgregaConc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAgregaConc.Location = New System.Drawing.Point(18, 408)
        Me.ChkAgregaConc.Name = "ChkAgregaConc"
        Me.ChkAgregaConc.Size = New System.Drawing.Size(376, 16)
        Me.ChkAgregaConc.TabIndex = 19
        Me.ChkAgregaConc.Text = "Agregar a concepto codigo y nombre del  cliente"
        Me.ChkAgregaConc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebOrdenImp
        '
        Me.ebOrdenImp.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebOrdenImp.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebOrdenImp.BackColor = System.Drawing.Color.White
        Me.ebOrdenImp.ButtonImage = CType(resources.GetObject("ebOrdenImp.ButtonImage"), System.Drawing.Image)
        Me.ebOrdenImp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebOrdenImp.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebOrdenImp.Location = New System.Drawing.Point(424, 272)
        Me.ebOrdenImp.MaxLength = 5
        Me.ebOrdenImp.Name = "ebOrdenImp"
        Me.ebOrdenImp.Size = New System.Drawing.Size(128, 22)
        Me.ebOrdenImp.TabIndex = 8
        Me.ebOrdenImp.Text = "0"
        Me.ebOrdenImp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebOrdenImp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(424, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Orden de Impresión"
        '
        'ChkLstTipoVenta
        '
        Me.ChkLstTipoVenta.Location = New System.Drawing.Point(18, 72)
        Me.ChkLstTipoVenta.Name = "ChkLstTipoVenta"
        Me.ChkLstTipoVenta.Size = New System.Drawing.Size(248, 166)
        Me.ChkLstTipoVenta.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tipo de Venta"
        '
        'ChkLstFormaPago
        '
        Me.ChkLstFormaPago.Location = New System.Drawing.Point(304, 72)
        Me.ChkLstFormaPago.Name = "ChkLstFormaPago"
        Me.ChkLstFormaPago.Size = New System.Drawing.Size(256, 166)
        Me.ChkLstFormaPago.TabIndex = 5
        '
        'ebConcepto
        '
        Me.ebConcepto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebConcepto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebConcepto.BackColor = System.Drawing.Color.White
        Me.ebConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebConcepto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebConcepto.Location = New System.Drawing.Point(18, 368)
        Me.ebConcepto.MaxLength = 60
        Me.ebConcepto.Name = "ebConcepto"
        Me.ebConcepto.Size = New System.Drawing.Size(320, 22)
        Me.ebConcepto.TabIndex = 16
        Me.ebConcepto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConcepto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(456, 400)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(104, 32)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'chkSuprimirMovimiento
        '
        Me.chkSuprimirMovimiento.BackColor = System.Drawing.Color.Transparent
        Me.chkSuprimirMovimiento.Checked = True
        Me.chkSuprimirMovimiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSuprimirMovimiento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuprimirMovimiento.Location = New System.Drawing.Point(18, 264)
        Me.chkSuprimirMovimiento.Name = "chkSuprimirMovimiento"
        Me.chkSuprimirMovimiento.Size = New System.Drawing.Size(352, 16)
        Me.chkSuprimirMovimiento.TabIndex = 7
        Me.chkSuprimirMovimiento.Text = "Suprimir movimiento cuando su valor sea igual a cero"
        Me.chkSuprimirMovimiento.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'chkCuentasSimilares
        '
        Me.chkCuentasSimilares.BackColor = System.Drawing.Color.Transparent
        Me.chkCuentasSimilares.Checked = True
        Me.chkCuentasSimilares.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCuentasSimilares.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuentasSimilares.Location = New System.Drawing.Point(18, 248)
        Me.chkCuentasSimilares.Name = "chkCuentasSimilares"
        Me.chkCuentasSimilares.Size = New System.Drawing.Size(264, 16)
        Me.chkCuentasSimilares.TabIndex = 6
        Me.chkCuentasSimilares.Text = "Concentrar en un movimiento cuentas similares"
        Me.chkCuentasSimilares.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cbReferencia
        '
        Me.cbReferencia.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbReferencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Rango de folios del movimiento"
        UiComboBoxItem1.Value = "Rango de folios del movimiento"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Folio del documento origen"
        UiComboBoxItem2.Value = "Folio del documento origen"
        Me.cbReferencia.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.cbReferencia.Location = New System.Drawing.Point(352, 368)
        Me.cbReferencia.Name = "cbReferencia"
        Me.cbReferencia.Size = New System.Drawing.Size(196, 22)
        Me.cbReferencia.TabIndex = 18
        Me.cbReferencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebPorcentaje
        '
        Me.ebPorcentaje.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPorcentaje.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPorcentaje.BackColor = System.Drawing.Color.White
        Me.ebPorcentaje.ButtonImage = CType(resources.GetObject("ebPorcentaje.ButtonImage"), System.Drawing.Image)
        Me.ebPorcentaje.DecimalDigits = 4
        Me.ebPorcentaje.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPorcentaje.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebPorcentaje.Location = New System.Drawing.Point(480, 320)
        Me.ebPorcentaje.MaxLength = 8
        Me.ebPorcentaje.Name = "ebPorcentaje"
        Me.ebPorcentaje.Size = New System.Drawing.Size(72, 22)
        Me.ebPorcentaje.TabIndex = 14
        Me.ebPorcentaje.Text = "0"
        Me.ebPorcentaje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPorcentaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(480, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Porcentaje"
        '
        'cbImporteBase
        '
        Me.cbImporteBase.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbImporteBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Subtotal"
        UiComboBoxItem3.Value = "Subtotal"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "IVA"
        UiComboBoxItem4.Value = "IVA"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Total"
        UiComboBoxItem5.Value = "Total"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Descuento"
        UiComboBoxItem6.Value = "Descuento"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "Costo del movimiento"
        UiComboBoxItem7.Value = "Costo del movimiento"
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.IsSeparator = False
        UiComboBoxItem8.Text = "Bonificación"
        UiComboBoxItem8.Value = "Bonificacion"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.IsSeparator = False
        UiComboBoxItem9.Text = "Diferencia cargo-abono"
        UiComboBoxItem9.Value = "Diferencia cargo-abono"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.IsSeparator = False
        UiComboBoxItem10.Text = "Total documento asociado"
        UiComboBoxItem10.Value = "Total documento asociado"
        Me.cbImporteBase.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7, UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10})
        Me.cbImporteBase.Location = New System.Drawing.Point(208, 320)
        Me.cbImporteBase.Name = "cbImporteBase"
        Me.cbImporteBase.Size = New System.Drawing.Size(248, 22)
        Me.cbImporteBase.TabIndex = 12
        Me.cbImporteBase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Importe Base"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo de Movimiento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipoMovimiento
        '
        Me.cbTipoMovimiento.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoMovimiento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.IsSeparator = False
        UiComboBoxItem11.Text = "Cargos"
        UiComboBoxItem11.Value = "Cargos"
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.IsSeparator = False
        UiComboBoxItem12.Text = "Cargos en Rojo"
        UiComboBoxItem12.Value = "Cargos en rojo"
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.IsSeparator = False
        UiComboBoxItem13.Text = "Abonos"
        UiComboBoxItem13.Value = "Abonos"
        UiComboBoxItem14.FormatStyle.Alpha = 0
        UiComboBoxItem14.IsSeparator = False
        UiComboBoxItem14.Text = "Abonos en rojo"
        UiComboBoxItem14.Value = "Abonos en rojo"
        Me.cbTipoMovimiento.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem11, UiComboBoxItem12, UiComboBoxItem13, UiComboBoxItem14})
        Me.cbTipoMovimiento.Location = New System.Drawing.Point(18, 320)
        Me.cbTipoMovimiento.Name = "cbTipoMovimiento"
        Me.cbTipoMovimiento.Size = New System.Drawing.Size(164, 22)
        Me.cbTipoMovimiento.TabIndex = 10
        Me.cbTipoMovimiento.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(304, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Forma de Pago"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(352, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Referencia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCuenta
        '
        Me.ebCuenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCuenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCuenta.BackColor = System.Drawing.Color.White
        Me.ebCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCuenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCuenta.Location = New System.Drawing.Point(18, 24)
        Me.ebCuenta.MaxLength = 60
        Me.ebCuenta.Name = "ebCuenta"
        Me.ebCuenta.Size = New System.Drawing.Size(542, 22)
        Me.ebCuenta.TabIndex = 1
        Me.ebCuenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCuenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Cuenta"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 23)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Concepto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmMovimientoContable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 443)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMovimientoContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento Contable"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Funciones"

    Function ValidaCuenta(ByVal Cuenta As String) As Boolean
        Dim vlPosc As Integer, vlLetra As Integer

        ValidaCuenta = False
        For vlLetra = 1 To Len(Cuenta)
            vlPosc = InStr(Cuenta.Substring(vlLetra - 1, Len(Cuenta) - vlLetra), "+", CompareMethod.Text)
            If vlPosc <> 0 Then
                ValidaCuenta = ValidaSegmento(Cuenta.Substring(vlLetra - 1, vlPosc - vlLetra))
                vlLetra = vlPosc
            Else
                ValidaCuenta = ValidaSegmento(Cuenta.Substring(vlLetra - 1, Len(Cuenta) - vlLetra + 1))
                Exit For
            End If
        Next
    End Function

    Function ValidaSegmento(ByVal Segmento As String) As Boolean
        If Asc(Segmento.Substring(0, 1)) = 34 And Asc(Segmento.Substring(Len(Segmento) - 1, 1)) = 34 Then
            If IsNumeric(Segmento.Substring(1, Len(Segmento) - 2)) Then
                ValidaSegmento = True
            Else
                ValidaSegmento = False
            End If
        Else
            Select Case Segmento
                Case "ALM01", "ALM02", "ALM03", "ALM04", "ALM05"
                    ValidaSegmento = True
                Case "BAN01", "BAN02", "BAN03", "BAN04", "BAN05"
                    ValidaSegmento = True
                Case "TD01", "TD02", "TD03", "TD04", "TD05"
                    ValidaSegmento = True
                Case "FP01", "FP02", "FP03", "FP04", "FP05"
                    ValidaSegmento = True
                Case "TV01", "TV02", "TV03", "TV04", "TV05"
                    ValidaSegmento = True
                Case "CLI01", "CLI02", "CLI03", "CLI04", "CLI05"
                    ValidaSegmento = True
                Case "GE01", "GE02", "GE03", "GE04", "GE05", "GE06", "GE07"
                    ValidaSegmento = True
                Case Else
                    ValidaSegmento = False
            End Select
        End If
    End Function

#End Region


#Region "Member Variables"

    Private oDefinicionAsientoContable As DefinicionAsientoContableDataGateway

#End Region


#Region "Properties"

    Private dr As DataRow
    Private dtFP As DataTable
    Private dtTV As DataTable

    Public WriteOnly Property Row() As DataRow

        Set(ByVal Value As DataRow)

            dr = Value

        End Set

    End Property

    Public WriteOnly Property RowFP() As DataTable

        Set(ByVal Value As DataTable)

            dtFP = Value

        End Set

    End Property

    Public WriteOnly Property RowTV() As DataTable

        Set(ByVal Value As DataTable)

            dtTV = Value

        End Set

    End Property

#End Region


#Region "Members Methods"

    Private Sub Sm_InitializeObjects()

        oDefinicionAsientoContable = New DefinicionAsientoContableDataGateway(oAppContext)

        Sm_FillCbFormaPago()
        Sm_FillCbTipoVenta()

        If Not (dr!Cuenta = String.Empty) Then

            Sm_MostrarInformacion()

        End If

    End Sub

    Private Sub Sm_FinalizeObjects()

        oDefinicionAsientoContable = Nothing

    End Sub

    Private Sub Sm_FillCbFormaPago()

        Dim dsForPag As DataSet
        Dim drForPag As DataRow

        dsForPag = oDefinicionAsientoContable.LoadAllFormasPago

        For Each drForPag In dsForPag.Tables(0).Rows
            If drForPag!CodFormasPago <> "T" Then

                ChkLstFormaPago.Items.Add(drForPag!CodFormasPago & Space(1) & drForPag!Descripcion, False)
                If drForPag!CodFormasPago = "D" Then
                    ChkLstFormaPago.Items.Add("TE" & Space(1) & "TARJETA ELECTRONICA", False)
                    ChkLstFormaPago.Items.Add("TM" & Space(1) & "TARJETA MANUAL", False)
                End If

            End If
        Next
        dsForPag = Nothing

    End Sub

    Private Sub Sm_FillCbTipoVenta()

        Dim dsTipVta As DataSet
        Dim drTipVta As DataRow

        dsTipVta = oDefinicionAsientoContable.LoadAllTiposVenta

        For Each drTipVta In dsTipVta.Tables(0).Rows
            ChkLstTipoVenta.Items.Add(drTipVta!CodTipoVenta & Space(1) & drTipVta!Descripcion, False)
        Next
        dsTipVta = Nothing

    End Sub

    Private Function Fm_bolValidar() As Boolean

        If (ebCuenta.Text.Trim = String.Empty) Then

            MsgBox("El Campo Cuenta es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            ebCuenta.Focus()

            Exit Function

        End If

        Dim i As Integer, vlSel As Boolean

        vlSel = False
        For i = 0 To ChkLstTipoVenta.Items.Count - 1
            If ChkLstTipoVenta.GetItemChecked(i) = True Then
                vlSel = True
                Exit For
            End If
        Next
        If vlSel = False Then
            MsgBox("El Campo Tipo de Venta es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            ChkLstTipoVenta.Focus()
            Exit Function
        End If

        vlSel = False
        For i = 0 To ChkLstFormaPago.Items.Count - 1
            If ChkLstFormaPago.GetItemChecked(i) = True Then
                vlSel = True
                Exit For
            End If
        Next
        If vlSel = False Then
            MsgBox("El Campo Forma de Pago es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            ChkLstFormaPago.Focus()
            Exit Function
        End If

        If (cbTipoMovimiento.SelectedIndex = -1) Then

            MsgBox("El Campo Tipo de Movimiento es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            cbTipoMovimiento.Focus()

            Exit Function

        End If

        If (cbReferencia.SelectedIndex = -1) Then

            MsgBox("El Campo Referencia es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            cbReferencia.Focus()

            Exit Function

        End If

        If (cbImporteBase.SelectedIndex = -1) Then

            MsgBox("El Campo Importe Base es Requerido", MsgBoxStyle.Exclamation, "DPTienda")
            cbImporteBase.Focus()

            Exit Function

        End If

        If (ebPorcentaje.Text < 0) Or (ebPorcentaje.Text > 100) Then

            MsgBox("El Campor porcentaje no es valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebPorcentaje.Focus()

            Exit Function

        End If

        Return True

    End Function

    Private Sub Sm_GuardarMovimientoContable()

        Dim vlPasa As Boolean

        vlPasa = ValidaCuenta(ebCuenta.Text)

        If (vlPasa = False) Then
            MsgBox("El Campo Cuenta no es valido.")
            ebCuenta.Focus()
            Return
        End If

        If (Fm_bolValidar() = False) Then

            Return

        End If

        With dr

            !Cuenta = ebCuenta.Text

            Select Case cbTipoMovimiento.SelectedItem.Value

                Case "Cargos", "Cargos en rojo"

                    !PorcentajeCargo = ebPorcentaje.Text

                    !ImporteCargo = cbImporteBase.SelectedItem.Value

                    !PorcentajeAbono = 0

                    !ImporteAbono = String.Empty


                Case "Abonos", "Abonos en rojo"

                    !PorcentajeAbono = ebPorcentaje.Text

                    !ImporteAbono = cbImporteBase.SelectedItem.Value

                    !PorcentajeCargo = 0

                    !ImporteCargo = String.Empty

            End Select

            !TipoMov = cbTipoMovimiento.SelectedItem.Value

            !Referencia = cbReferencia.SelectedItem.Value

            !ConcentrarMov = chkCuentasSimilares.Checked

            !SupMovCero = chkSuprimirMovimiento.Checked

            !Concepto = ebConcepto.Text

            !OrdenImp = ebOrdenImp.Text

            !AgregaConc = ChkAgregaConc.Checked

            !AgregarDif = ChkAsignarDif.Checked

        End With

        dtFP.Clear()
        dtTV.Clear()

        Dim i As Integer, drFP As DataRow, vlFormaPago As String

        For i = 0 To ChkLstFormaPago.Items.Count - 1
            If ChkLstFormaPago.GetItemChecked(i) = True Then

                drFP = dtFP.NewRow
                drFP!CtaID = dr!CtaID
                vlFormaPago = ChkLstFormaPago.Items(i)
                drFP!CodFormasPago = vlFormaPago.Substring(0, 2)
                dtFP.Rows.Add(drFP)
                dtFP.AcceptChanges()

            End If
        Next

        Dim drTV As DataRow, vlTipoVenta As String

        For i = 0 To ChkLstTipoVenta.Items.Count - 1
            If ChkLstTipoVenta.GetItemChecked(i) = True Then

                drTV = dtTV.NewRow
                drTV!CtaID = dr!CtaID
                vlTipoVenta = ChkLstTipoVenta.Items(i)
                drTV!CodTipoVenta = vlTipoVenta.Substring(0, 1)
                dtTV.Rows.Add(drTV)
                dtTV.AcceptChanges()

            End If
        Next

        Me.DialogResult = DialogResult.OK

    End Sub


    Private Sub Sm_MostrarInformacion()

        With dr

            ebCuenta.Text = !Cuenta

            Select Case !TipoMov

                Case "Cargos", "Cargos en rojo"

                    cbImporteBase.Text = !ImporteCargo

                    cbTipoMovimiento.Text = !TipoMov

                    ebPorcentaje.Text = !PorcentajeCargo


                Case "Abonos", "Abonos en rojo"

                    cbImporteBase.Text = !ImporteAbono

                    cbTipoMovimiento.Text = !TipoMov

                    ebPorcentaje.Text = !PorcentajeAbono

            End Select

            cbReferencia.Text = !Referencia

            chkCuentasSimilares.Checked = !ConcentrarMov

            chkSuprimirMovimiento.Checked = !SupMovCero

            ebConcepto.Text = !Concepto

            ebOrdenImp.Text = !OrdenImp

            ChkAgregaConc.Checked = !AgregaConc

            ChkAsignarDif.Checked = !AgregarDif

        End With

        Dim drFP As DataRow, i As Integer, vlCod As String

        With dtFP
            For Each drFP In .Rows
                For i = 0 To ChkLstFormaPago.Items.Count - 1
                    vlCod = ChkLstFormaPago.Items(i)
                    If vlCod.Substring(0, 2) = drFP!CodFormasPago Then
                        ChkLstFormaPago.SetItemChecked(i, True)
                    End If
                Next
            Next
        End With

        Dim drTV As DataRow

        With dtTV
            For Each drTV In .Rows
                For i = 0 To ChkLstTipoVenta.Items.Count - 1
                    vlCod = ChkLstTipoVenta.Items(i)
                    If vlCod.Substring(0, 1) = drTV!CodTipoVenta Then
                        ChkLstTipoVenta.SetItemChecked(i, True)
                    End If
                Next
            Next
        End With

    End Sub

#End Region


#Region "Members Methods [Events]"

    Private Sub FrmMovimientoContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub

    Private Sub FrmMovimientoContable_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_FinalizeObjects()

    End Sub

    Private Sub FrmMovimientoContable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        ElseIf (e.KeyCode = Keys.Escape) Then

            Me.DialogResult = DialogResult.Cancel

        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_GuardarMovimientoContable()

    End Sub

#End Region

End Class
