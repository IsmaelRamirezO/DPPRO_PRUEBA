Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU
Imports Janus.Windows.GridEX

Public Class FrmAsientoContableDefinicion
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebNumero As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFrecuencia As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbFecha As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTipo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebPolizaNum As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grAsientoContable As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebConcepto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btNuevo As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsientoContableDefinicion))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btNuevo = New Janus.Windows.EditControls.UIButton()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.grAsientoContable = New Janus.Windows.GridEX.GridEX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebConcepto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPolizaNum = New Janus.Windows.EditControls.UIComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTipo = New Janus.Windows.EditControls.UIComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbFecha = New Janus.Windows.EditControls.UIComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFrecuencia = New Janus.Windows.EditControls.UIComboBox()
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebNumero = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grAsientoContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btNuevo)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.grAsientoContable)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebConcepto)
        Me.ExplorerBar1.Controls.Add(Me.ebPolizaNum)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.cbTipo)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.cbFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.cbFrecuencia)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.ebNumero)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales del Asiento Contable"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(696, 507)
        Me.ExplorerBar1.TabIndex = 4
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btNuevo
        '
        Me.btNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNuevo.Image = CType(resources.GetObject("btNuevo.Image"), System.Drawing.Image)
        Me.btNuevo.Location = New System.Drawing.Point(464, 464)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(104, 32)
        Me.btNuevo.TabIndex = 8
        Me.btNuevo.Text = "&Nuevo"
        Me.btNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(584, 464)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(104, 32)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grAsientoContable
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grAsientoContable.DesignTimeLayout = GridEXLayout1
        Me.grAsientoContable.GroupByBoxVisible = False
        Me.grAsientoContable.Location = New System.Drawing.Point(25, 176)
        Me.grAsientoContable.Name = "grAsientoContable"
        Me.grAsientoContable.Size = New System.Drawing.Size(663, 280)
        Me.grAsientoContable.TabIndex = 37
        Me.grAsientoContable.TabStop = False
        Me.grAsientoContable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(384, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Concepto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebConcepto
        '
        Me.ebConcepto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebConcepto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebConcepto.BackColor = System.Drawing.Color.White
        Me.ebConcepto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebConcepto.Location = New System.Drawing.Point(456, 120)
        Me.ebConcepto.MaxLength = 60
        Me.ebConcepto.Name = "ebConcepto"
        Me.ebConcepto.Size = New System.Drawing.Size(208, 22)
        Me.ebConcepto.TabIndex = 7
        Me.ebConcepto.TabStop = False
        Me.ebConcepto.Text = "Poliza de ingresos Fecha del día"
        Me.ebConcepto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConcepto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPolizaNum
        '
        Me.ebPolizaNum.BackColor = System.Drawing.Color.White
        Me.ebPolizaNum.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebPolizaNum.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Numero tienda, Dia del mes"
        UiComboBoxItem1.Value = "Numero Tienda"
        Me.ebPolizaNum.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1})
        Me.ebPolizaNum.Location = New System.Drawing.Point(456, 96)
        Me.ebPolizaNum.Name = "ebPolizaNum"
        Me.ebPolizaNum.Size = New System.Drawing.Size(208, 22)
        Me.ebPolizaNum.TabIndex = 4
        Me.ebPolizaNum.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(384, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Poliza Num"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 23)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Tipo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipo
        '
        Me.cbTipo.BackColor = System.Drawing.Color.White
        Me.cbTipo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Diario"
        UiComboBoxItem2.Value = "Diario"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Egresos"
        UiComboBoxItem3.Value = "Egresos"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Ingresos"
        UiComboBoxItem4.Value = "Ingresos"
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "Orden"
        UiComboBoxItem5.Value = "Orden"
        Me.cbTipo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4, UiComboBoxItem5})
        Me.cbTipo.Location = New System.Drawing.Point(96, 120)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(128, 22)
        Me.cbTipo.TabIndex = 5
        Me.cbTipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Fecha"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFecha
        '
        Me.cbFecha.BackColor = System.Drawing.Color.White
        Me.cbFecha.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "Documento"
        UiComboBoxItem6.Value = "Documento"
        Me.cbFecha.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem6})
        Me.cbFecha.Location = New System.Drawing.Point(96, 96)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(128, 22)
        Me.cbFecha.TabIndex = 3
        Me.cbFecha.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(384, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Frecuencia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFrecuencia
        '
        Me.cbFrecuencia.BackColor = System.Drawing.Color.White
        Me.cbFrecuencia.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFrecuencia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.IsSeparator = False
        UiComboBoxItem7.Text = "Una Poliza Diaria"
        UiComboBoxItem7.Value = "Una Poliza Diaria"
        Me.cbFrecuencia.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem7})
        Me.cbFrecuencia.Location = New System.Drawing.Point(456, 72)
        Me.cbFrecuencia.Name = "cbFrecuencia"
        Me.cbFrecuencia.Size = New System.Drawing.Size(144, 22)
        Me.cbFrecuencia.TabIndex = 2
        Me.cbFrecuencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.BackColor = System.Drawing.Color.White
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(96, 72)
        Me.ebNombre.MaxLength = 60
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(272, 22)
        Me.ebNombre.TabIndex = 1
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(40, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Nombre"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNumero
        '
        Me.ebNumero.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNumero.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNumero.BackColor = System.Drawing.Color.White
        Me.ebNumero.ButtonImage = CType(resources.GetObject("ebNumero.ButtonImage"), System.Drawing.Image)
        Me.ebNumero.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebNumero.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNumero.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebNumero.Location = New System.Drawing.Point(96, 48)
        Me.ebNumero.MaxLength = 4
        Me.ebNumero.Name = "ebNumero"
        Me.ebNumero.Size = New System.Drawing.Size(104, 22)
        Me.ebNumero.TabIndex = 0
        Me.ebNumero.Text = "0"
        Me.ebNumero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebNumero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Num"
        '
        'FrmAsientoContableDefinicion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(696, 507)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsientoContableDefinicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Definición de Asientos Contables"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grAsientoContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Members Variables"

    Private oDefinicionAsientoContable As DefinicionAsientoContable

    Private oDefinicionAsientoContableDG As DefinicionAsientoContableDataGateway

    Private dsAsientoContable As New DataSet
    Private dsAsientoContableFP As New DataSet
    Private dsAsientoContableTV As New DataSet

    Private vlIDCta As Integer

#End Region


#Region "Member Methods"

    Private Sub Sm_InitializeObjects()

        oDefinicionAsientoContableDG = New DefinicionAsientoContableDataGateway(oAppContext)
        
        Dim dt As New DataTable("AsientoContableDetalle")
        Dim dtFP As New DataTable("AsientoContableFormasPago")
        Dim dtTV As New DataTable("AsientoContableTiposVenta")

        With dt

            .Columns.Add("CtaID", GetType(Decimal))

            .Columns.Add("Cuenta", GetType(String))

            .Columns.Add("OrdenImp", GetType(Decimal))

            .Columns.Add("PorcentajeCargo", GetType(Decimal))

            .Columns.Add("ImporteCargo", GetType(String))

            .Columns.Add("PorcentajeAbono", GetType(Decimal))

            .Columns.Add("ImporteAbono", GetType(String))

            .Columns.Add("Referencia", GetType(String))

            .Columns.Add("ConcentrarMov", GetType(Boolean))

            .Columns.Add("SupMovCero", GetType(Boolean))

            .Columns.Add("Concepto", GetType(String))

            .Columns.Add("AgregaConc", GetType(Boolean))

            .Columns.Add("TipoMov", GetType(String))

            .Columns.Add("AgregarDif", GetType(Boolean))

        End With

        dsAsientoContable.Tables.Add(dt)

        With dtFP

            .Columns.Add("CtaID", GetType(Decimal))
            .Columns.Add("CodFormasPago", GetType(String))

        End With

        dsAsientoContableFP.Tables.Add(dtFP)

        With dtTV

            .Columns.Add("CtaID", GetType(Decimal))
            .Columns.Add("CodTipoVenta", GetType(String))

        End With

        dsAsientoContableTV.Tables.Add(dtTV)

        grAsientoContable.SetDataBinding(dsAsientoContable, "AsientoContableDetalle")

    End Sub


    Private Sub Sm_FinalizeObjetcs()

        dsAsientoContable.Dispose()

        dsAsientoContable = Nothing

        dsAsientoContableFP.Dispose()

        dsAsientoContableFP = Nothing

        dsAsientoContableTV.Dispose()

        dsAsientoContableTV = Nothing

    End Sub


    Private Function Fm_bolValidar() As Boolean

        If (ebNombre.Text.Trim = String.Empty) Then

            MsgBox("El Campo Nombre es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebNombre.Focus()

            Exit Function

        End If


        If (cbFrecuencia.Text = String.Empty) Then

            MsgBox("El Campo Frecuencia es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            cbFrecuencia.Focus()

            Exit Function

        End If


        If (cbFecha.Text = String.Empty) Then

            MsgBox("El Campo Fecha es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            cbFecha.Focus()

            Exit Function

        End If


        If (cbTipo.Text = String.Empty) Then

            MsgBox("El Campo Tipo es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            cbTipo.Focus()

            Exit Function

        End If


        If (ebPolizaNum.Text = String.Empty) Then

            MsgBox("El Campo Número de Poliza es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebPolizaNum.Focus()

            Exit Function

        End If


        If (ebConcepto.Text.Trim = String.Empty) Then

            MsgBox("El Campo Concepto es Requerido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebConcepto.Focus()

            Exit Function

        End If


        If (dsAsientoContable.Tables("AsientoContableDetalle").Rows.Count = 0) Then

            MsgBox("El Detalle no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If

        Return True

    End Function

    Private Sub Sm_GuardarDefinicionAsientoContable()

        If (oDefinicionAsientoContable Is Nothing) Then

            If (Fm_bolValidar() = False) Then
                Return
            End If

            'Guardar.

            oDefinicionAsientoContable = oDefinicionAsientoContableDG.Create

            With oDefinicionAsientoContable

                .Descripcion = ebNombre.Text
                .Frecuencia = cbFrecuencia.SelectedItem.Value
                .Fecha = cbFecha.SelectedItem.Value
                .NumPoliza = ebPolizaNum.SelectedItem.Value
                .Tipo = cbTipo.SelectedItem.Value
                .Concepto = ebConcepto.Text

                .Detalle = dsAsientoContable

                .DetalleFP = dsAsientoContableFP

                .DetalleTV = dsAsientoContableTV

            End With

            oDefinicionAsientoContableDG.GuardarAsientoContable(oDefinicionAsientoContable)

            MsgBox("El Registro ha sido Guardado.", MsgBoxStyle.Information, "DPTienda")

        Else

            'Actualizar.

            With oDefinicionAsientoContable

                .Descripcion = ebNombre.Text
                .Frecuencia = cbFrecuencia.SelectedItem.Value
                .Fecha = cbFecha.SelectedItem.Value
                .NumPoliza = ebPolizaNum.SelectedItem.Value
                .Tipo = cbTipo.SelectedItem.Value
                .Concepto = ebConcepto.Text

                .Detalle = dsAsientoContable

                .DetalleFP = dsAsientoContableFP

                .DetalleTV = dsAsientoContableTV

            End With

            'Actualizar

            oDefinicionAsientoContableDG.ActualizarAsientoContable(oDefinicionAsientoContable)


            Dim intCodAsiento As Integer = oDefinicionAsientoContable.CodAsiento

            oDefinicionAsientoContable = Nothing
            oDefinicionAsientoContable = oDefinicionAsientoContableDG.Select(intCodAsiento)

            Sm_MostrarInformacion()


            MsgBox("El Registro ha sido Actualizado.", MsgBoxStyle.Information, "DPTienda")

        End If

    End Sub


    Private Sub Sm_CapturarGridDetalle()

        Dim dr As DataRow
        Dim dtFormPago As DataTable, drFormPago As DataRow, drFP As DataRow
        Dim dtTipVta As DataTable, drTipVta As DataRow, drTV As DataRow

        vlIDCta = 1
        For Each dr In dsAsientoContable.Tables("AsientoContableDetalle").Rows
            If dr!CtaID > vlIDCta Then
                vlIDCta = dr!CtaID + 1
            End If
        Next

        dr = dsAsientoContable.Tables("AsientoContableDetalle").NewRow

        dtFormPago = dsAsientoContableFP.Tables("AsientoContableFormasPago").Clone

        dtTipVta = dsAsientoContableTV.Tables("AsientoContableTiposVenta").Clone

        Dim oFrmMovimientoContable As New FrmMovimientoContable

        dr!CtaID = vlIDCta

        dr!Cuenta = String.Empty

        oFrmMovimientoContable.Row = dr

        oFrmMovimientoContable.RowFP = dtFormPago

        oFrmMovimientoContable.RowTV = dtTipVta

        oFrmMovimientoContable.ShowDialog()


        If oFrmMovimientoContable.DialogResult = DialogResult.OK Then

            dsAsientoContable.Tables("AsientoContableDetalle").Rows.Add(dr)

            For Each drFormPago In dtFormPago.Rows
                drFP = dsAsientoContableFP.Tables("AsientoContableFormasPago").NewRow
                drFP!CtaID = drFormPago!CtaID
                drFP!CodFormasPago = drFormPago!CodFormasPago
                dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows.Add(drFP)
            Next

            For Each drTipVta In dtTipVta.Rows
                drTV = dsAsientoContableTV.Tables("AsientoContableTiposVenta").NewRow
                drTV!CtaID = drTipVta!CtaID
                drTV!CodTipoVenta = drTipVta!CodTipoVenta
                dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows.Add(drTV)
            Next
        End If

        oFrmMovimientoContable.Dispose()

        oFrmMovimientoContable = Nothing

    End Sub


    Private Sub Sm_EliminarGridDetalle()

        If (dsAsientoContable.Tables("AsientoContableDetalle").Rows.Count = 0) Then

            MsgBox("No se cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Return

        End If

        Dim drGridEX As GridEXRow
        Dim drDataRowView As DataRowView

        'Extraer el Registro Seleccionado.

        drGridEX = grAsientoContable.GetRow

        drDataRowView = CType(drGridEX.DataRow, DataRowView)

        With drDataRowView

            Dim drFP As DataRow, drTV As DataRow
            Dim i As Integer = 0
            Dim Tope As Integer = dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows.Count

            Do While i < Tope
                If dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows(i).Item("CtaID") = !CtaID Then
                    dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows(i).Delete()
                    dsAsientoContableFP.Tables("AsientoContableFormasPago").AcceptChanges()
                    Tope = dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows.Count
                    i = -1
                End If
                i += 1
            Loop
            dsAsientoContableFP.Tables("AsientoContableFormasPago").AcceptChanges()

            i = 0
            Tope = dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows.Count
            Do While i < Tope
                If dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows(i).Item("CtaID") = !CtaID Then
                    dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows(i).Delete()
                    dsAsientoContableTV.Tables("AsientoContableTiposVenta").AcceptChanges()
                    Tope = dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows.Count
                    i = -1
                End If
                i += 1
            Loop

        End With

        With dsAsientoContable.Tables("AsientoContableDetalle").Rows

            .RemoveAt(grAsientoContable.GetRow.RowIndex)

        End With

    End Sub


    Private Sub Sm_ActualizarGridDetalle()

        If (dsAsientoContable.Tables("AsientoContableDetalle").Rows.Count = 0) Then

            Return

        End If


        Dim drGridEX As GridEXRow
        Dim drDataRowView As DataRowView

        'Extraer el Registro Seleccionado.

        drGridEX = grAsientoContable.GetRow

        drDataRowView = CType(drGridEX.DataRow, DataRowView)


        Dim dr As DataRow
        Dim dtFormPago As DataTable, drFormPago As DataRow, drFP As DataRow
        Dim dtTipVta As DataTable, drTipVta As DataRow, drTV As DataRow

        dr = dsAsientoContable.Tables("AsientoContableDetalle").NewRow

        dtFormPago = dsAsientoContableFP.Tables("AsientoContableFormasPago").Clone

        dtTipVta = dsAsientoContableTV.Tables("AsientoContableTiposVenta").Clone

        Dim oFrmMovimientoContable As New FrmMovimientoContable

        'Asignar Valores del Registro seleccionado.

        With drDataRowView

            dr!CtaID = !CtaID

            dr!Cuenta = !Cuenta

            dr!OrdenImp = !OrdenImp

            dr!PorcentajeCargo = !PorcentajeCargo

            dr!ImporteCargo = !ImporteCargo

            dr!PorcentajeAbono = !PorcentajeAbono

            dr!ImporteAbono = !ImporteAbono

            dr!TipoMov = !TipoMov

            dr!Referencia = !Referencia

            dr!ConcentrarMov = !ConcentrarMov

            dr!SupMovCero = !SupMovCero

            dr!Concepto = !Concepto

            dr!AgregaConc = !AgregaConc

            dr!AgregarDif = !AgregarDif

            For Each drFormPago In dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows
                If drFormPago!CtaID = !CtaID Then
                    drFP = dtFormPago.NewRow
                    drFP!CtaID = drFormPago!CtaID
                    drFP!CodFormasPago = drFormPago!CodFormasPago
                    dtFormPago.Rows.Add(drFP)
                    dtFormPago.AcceptChanges()
                End If
            Next

            For Each drTipVta In dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows
                If drTipVta!CtaID = !CtaID Then
                    drTV = dtTipVta.NewRow
                    drTV!CtaID = drTipVta!CtaID
                    drTV!CodTipoVenta = drTipVta!CodTipoVenta
                    dtTipVta.Rows.Add(drTV)
                    dtTipVta.AcceptChanges()
                End If
            Next

        End With


        oFrmMovimientoContable.Row = dr

        oFrmMovimientoContable.RowFP = dtFormPago

        oFrmMovimientoContable.RowTV = dtTipVta

        oFrmMovimientoContable.ShowDialog()


        If (oFrmMovimientoContable.DialogResult = DialogResult.OK) Then

            Sm_EliminarGridDetalle()

            dsAsientoContable.Tables("AsientoContableDetalle").Rows.Add(dr)

            For Each drFormPago In dtFormPago.Rows
                drFP = dsAsientoContableFP.Tables("AsientoContableFormasPago").NewRow
                drFP!CtaID = drFormPago!CtaID
                drFP!CodFormasPago = drFormPago!CodFormasPago
                dsAsientoContableFP.Tables("AsientoContableFormasPago").Rows.Add(drFP)
                dsAsientoContableFP.Tables("AsientoContableFormasPago").AcceptChanges()
            Next

            For Each drTipVta In dtTipVta.Rows
                drTV = dsAsientoContableTV.Tables("AsientoContableTiposVenta").NewRow
                drTV!CtaID = drTipVta!CtaID
                drTV!CodTipoVenta = drTipVta!CodTipoVenta
                dsAsientoContableTV.Tables("AsientoContableTiposVenta").Rows.Add(drTV)
                dsAsientoContableTV.Tables("AsientoContableTiposVenta").AcceptChanges()
            Next

        End If


        oFrmMovimientoContable.Dispose()

        oFrmMovimientoContable = Nothing

    End Sub



    Private Sub Sm_BuscarAsientoContable(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New AsientoContableOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oDefinicionAsientoContable = Nothing
                oDefinicionAsientoContable = oDefinicionAsientoContableDG.Select(oOpenRecordDlg.Record.Item("CodAsiento"))

                'Mostrar Informacion

                Sm_MostrarInformacion()

                ebNumero.Focus()

            End If

        Else

            If (ebNumero.Text.Trim = String.Empty) Then

                Exit Sub

            End If

            oDefinicionAsientoContable = Nothing
            oDefinicionAsientoContable = oDefinicionAsientoContableDG.Select(ebNumero.Text)

            '<Validación>

            If (oDefinicionAsientoContable Is Nothing) Then

                MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sm_Limpiar()

                ebNumero.Focus()

                Exit Sub

            End If

            '</Validación>

            Sm_MostrarInformacion()

            'ebNumero.Focus()

        End If

    End Sub



    Private Sub Sm_MostrarInformacion()

        With oDefinicionAsientoContable

            ebNumero.Text = .CodAsiento

            ebNombre.Text = .Descripcion

            cbFrecuencia.SelectedValue = .Frecuencia

            cbFecha.SelectedValue = .Fecha

            cbTipo.SelectedValue = .Tipo

            ebPolizaNum.SelectedValue = .NumPoliza

            ebConcepto.Text = .Concepto

            dsAsientoContable = .Detalle

            dsAsientoContableFP = .DetalleFP

            dsAsientoContableTV = .DetalleTV

            grAsientoContable.SetDataBinding(dsAsientoContable, "AsientoContableDetalle")

        End With

    End Sub



    Private Sub Sm_Limpiar()

        oDefinicionAsientoContable = Nothing

        ebNumero.Text = 0

        ebNombre.Text = String.Empty

        cbFrecuencia.Text = String.Empty

        cbFecha.Text = String.Empty

        cbTipo.Text = String.Empty

        ebPolizaNum.Text = String.Empty

        ebConcepto.Text = "Poliza de ingresos Fecha del día"

        dsAsientoContable.Tables("AsientoContableDetalle").Clear()

    End Sub

    Private Sub Sm_Nuevo()

        Sm_Limpiar()

    End Sub

#End Region


#Region "Member Methods [Events]"

    Private Sub FrmAsientoContableDefinicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub



    Private Sub FrmAsientoContableDefinicion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_FinalizeObjetcs()

    End Sub



    Private Sub FrmAsientoContableDefinicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        End If


        If (e.KeyCode = Keys.Insert) Then

            Sm_CapturarGridDetalle()

        End If


        If (e.KeyCode = Keys.Delete) Then

            Sm_EliminarGridDetalle()

        End If

    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_GuardarDefinicionAsientoContable()

    End Sub



    Private Sub grAsientoContable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grAsientoContable.DoubleClick

        Sm_ActualizarGridDetalle()

    End Sub



    Private Sub ebNumero_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebNumero.ButtonClick

        Sm_BuscarAsientoContable(True)

    End Sub



    Private Sub ebNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNumero.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarAsientoContable(True)

        End If

    End Sub



    Private Sub ebNumero_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNumero.Validating

        If (ebNumero.Text.Trim <> String.Empty) Then

            If (ebNumero.Text > 0) Then

                Sm_BuscarAsientoContable(False)

            End If

        End If

    End Sub



    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click

        Sm_Nuevo()

    End Sub

#End Region

End Class
