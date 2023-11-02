Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmMovimientosPorArticulo
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
    Friend WithEvents cmdFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnCargar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUnidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCosto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgMovimientos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTEntrada As System.Windows.Forms.Label
    Friend WithEvents lblTSalida As System.Windows.Forms.Label
    Friend WithEvents lblTFinal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ebSaldoInicial As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientosPorArticulo))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTFinal = New System.Windows.Forms.Label()
        Me.lblTSalida = New System.Windows.Forms.Label()
        Me.lblTEntrada = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ebSaldoInicial = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ebUnidad = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCosto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgMovimientos = New Janus.Windows.GridEX.GridEX()
        Me.btnCargar = New Janus.Windows.EditControls.UIButton()
        Me.cmbFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmdFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.lblTFinal)
        Me.ExplorerBar1.Controls.Add(Me.lblTSalida)
        Me.ExplorerBar1.Controls.Add(Me.lblTEntrada)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.dgMovimientos)
        Me.ExplorerBar1.Controls.Add(Me.btnCargar)
        Me.ExplorerBar1.Controls.Add(Me.cmbFechaFin)
        Me.ExplorerBar1.Controls.Add(Me.cmdFechaInicio)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(680, 482)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(600, 456)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 23)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "F2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(624, 456)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 23)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Imprimir"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTFinal
        '
        Me.lblTFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblTFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTFinal.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTFinal.Location = New System.Drawing.Point(120, 440)
        Me.lblTFinal.Name = "lblTFinal"
        Me.lblTFinal.Size = New System.Drawing.Size(64, 23)
        Me.lblTFinal.TabIndex = 12
        Me.lblTFinal.Text = "0"
        Me.lblTFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTSalida
        '
        Me.lblTSalida.BackColor = System.Drawing.Color.Transparent
        Me.lblTSalida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTSalida.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSalida.ForeColor = System.Drawing.Color.Red
        Me.lblTSalida.Location = New System.Drawing.Point(120, 416)
        Me.lblTSalida.Name = "lblTSalida"
        Me.lblTSalida.Size = New System.Drawing.Size(64, 23)
        Me.lblTSalida.TabIndex = 11
        Me.lblTSalida.Text = "0"
        Me.lblTSalida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTEntrada
        '
        Me.lblTEntrada.BackColor = System.Drawing.Color.Transparent
        Me.lblTEntrada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTEntrada.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEntrada.Location = New System.Drawing.Point(120, 392)
        Me.lblTEntrada.Name = "lblTEntrada"
        Me.lblTEntrada.Size = New System.Drawing.Size(64, 23)
        Me.lblTEntrada.TabIndex = 10
        Me.lblTEntrada.Text = "0"
        Me.lblTEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 416)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Total Salidas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 440)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Stock Final"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 392)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total Entrada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ebSaldoInicial)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.ebUnidad)
        Me.UiGroupBox1.Controls.Add(Me.ebCosto)
        Me.UiGroupBox1.Controls.Add(Me.ebDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.ebCodigo)
        Me.UiGroupBox1.Location = New System.Drawing.Point(24, 16)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(648, 80)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Informacion producto"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ebSaldoInicial
        '
        Me.ebSaldoInicial.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoInicial.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoInicial.BackColor = System.Drawing.Color.Ivory
        Me.ebSaldoInicial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoInicial.Location = New System.Drawing.Point(560, 48)
        Me.ebSaldoInicial.Name = "ebSaldoInicial"
        Me.ebSaldoInicial.ReadOnly = True
        Me.ebSaldoInicial.Size = New System.Drawing.Size(80, 22)
        Me.ebSaldoInicial.TabIndex = 8
        Me.ebSaldoInicial.TabStop = False
        Me.ebSaldoInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebSaldoInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(470, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Saldo Inicial:"
        '
        'ebUnidad
        '
        Me.ebUnidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidad.BackColor = System.Drawing.Color.Ivory
        Me.ebUnidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUnidad.Location = New System.Drawing.Point(352, 48)
        Me.ebUnidad.Name = "ebUnidad"
        Me.ebUnidad.ReadOnly = True
        Me.ebUnidad.Size = New System.Drawing.Size(72, 22)
        Me.ebUnidad.TabIndex = 6
        Me.ebUnidad.TabStop = False
        Me.ebUnidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCosto
        '
        Me.ebCosto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCosto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCosto.BackColor = System.Drawing.Color.Ivory
        Me.ebCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCosto.Location = New System.Drawing.Point(96, 48)
        Me.ebCosto.Name = "ebCosto"
        Me.ebCosto.ReadOnly = True
        Me.ebCosto.Size = New System.Drawing.Size(120, 22)
        Me.ebCosto.TabIndex = 4
        Me.ebCosto.TabStop = False
        Me.ebCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCosto.Visible = False
        Me.ebCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(288, 24)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(352, 22)
        Me.ebDescripcion.TabIndex = 2
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(288, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Unidad:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Costo:"
        Me.Label5.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cod. Articulo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigo.Location = New System.Drawing.Point(96, 24)
        Me.ebCodigo.MaxLength = 22
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(184, 22)
        Me.ebCodigo.TabIndex = 1
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(208, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Fin"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Inicio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgMovimientos
        '
        Me.dgMovimientos.AllowColumnDrag = False
        Me.dgMovimientos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.dgMovimientos.DesignTimeLayout = GridEXLayout1
        Me.dgMovimientos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgMovimientos.GroupByBoxVisible = False
        Me.dgMovimientos.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.dgMovimientos.Location = New System.Drawing.Point(16, 144)
        Me.dgMovimientos.Name = "dgMovimientos"
        Me.dgMovimientos.Size = New System.Drawing.Size(656, 240)
        Me.dgMovimientos.TabIndex = 6
        Me.dgMovimientos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(392, 104)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(88, 23)
        Me.btnCargar.TabIndex = 5
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbFechaFin
        '
        Me.cmbFechaFin.CustomFormat = "dd.MM.yyyy"
        Me.cmbFechaFin.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.cmbFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaFin.Location = New System.Drawing.Point(272, 105)
        Me.cmbFechaFin.Name = "cmbFechaFin"
        Me.cmbFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.cmbFechaFin.TabIndex = 4
        Me.cmbFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'cmdFechaInicio
        '
        Me.cmdFechaInicio.CustomFormat = "dd.MM.yyyy"
        Me.cmdFechaInicio.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.cmdFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmdFechaInicio.Location = New System.Drawing.Point(104, 105)
        Me.cmdFechaInicio.Name = "cmdFechaInicio"
        Me.cmdFechaInicio.Size = New System.Drawing.Size(96, 20)
        Me.cmdFechaInicio.TabIndex = 2
        Me.cmdFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'frmMovimientosPorArticulo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(680, 482)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(696, 520)
        Me.MinimumSize = New System.Drawing.Size(696, 520)
        Me.Name = "frmMovimientosPorArticulo"
        Me.Text = "Historico de Movimientos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oArticulo As Articulo
    Private oCatalogoArticulosMgr As CatalogoArticuloManager
    Private dtMovimientos As DataTable

    Private Sub Sm_BuscarArticulo(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog2


            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.Cancel) Then
                Exit Sub
            End If


            Try

                Dim cArticulo As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    cArticulo = oOpenRecordDlg.Record.Item("Código")

                Else
                    cArticulo = oOpenRecordDlg.pbCodigo

                End If


                oArticulo = Nothing
                'oArticulo = oCatalogoArticulosMgr.Load(oOpenRecordDlg.Record.Item("Código"))
                oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
                oArticulo = oCatalogoArticulosMgr.Load(cArticulo)

                'Sm_GenerarArticuloCorrida()

            Catch ex As Exception

                Return

            End Try

        Else

            oArticulo = Nothing
            oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)


            If ebCodigo.Text.IndexOf("*") >= 0 Then
                Dim codigo1 As String = ebCodigo.Text.Replace("*", "0")
                Dim codigo2 As String = codigo1.PadLeft(18, "0")
                
                ebCodigo.Text = codigo2
            End If


            oArticulo = oCatalogoArticulosMgr.Load(ebCodigo.Text.Trim)

            If (oArticulo Is Nothing) Then

                'MsgBox("El Artículo no ha sido encontrado.", MsgBoxStyle.Exclamation, "DPTienda")
                Sm_TxtLimpiar()

                Exit Sub

            End If

        End If

        If Not oArticulo Is Nothing Then

            With oArticulo

                ebCodigo.Text = .CodArticulo
                ebDescripcion.Text = .CodArticulo & " - " & .Descripcion
                ebCosto.Text = Format(.CostoProm, "Standard")
                ebUnidad.Text = .CodUnidadVta

            End With

        End If

     

  

        'Sm_GenerarArticuloCorrida()

    End Sub

    Private Sub Sm_TxtLimpiar()

        ebCodigo.Text = String.Empty

        ebDescripcion.Text = String.Empty

        ebCosto.Text = String.Empty

        ebUnidad.Text = String.Empty

        ebCodigo.Focus()

    End Sub



    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick
        Sm_BuscarArticulo(True)
    End Sub

    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ebCodigo.Text = String.Empty Then
                    Sm_BuscarArticulo(True)
                Else
                    Sm_BuscarArticulo()
                End If
        End Select
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim IntExports(3) As Integer
        Dim oProcesosSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        dtMovimientos = oProcesosSAPMgr.Read_HistoricoMovimientos(Me.ebCodigo.Text, Me.cmdFechaInicio.Text, Me.cmbFechaFin.Text, IntExports)
        dtMovimientos.DefaultView.RowFilter = "FechaPC <= '" & CDate(Now.ToShortDateString) & "'"

        Me.dgMovimientos.DataSource = dtMovimientos
        Me.ebSaldoInicial.Text = IntExports(0)
        Me.lblTEntrada.Text = IntExports(1)
        Me.lblTSalida.Text = IntExports(2)
        Me.lblTFinal.Text = IntExports(3)

        If dtMovimientos.Rows.Count > 0 Then
            'Me.lblTEntrada.Text = IIf(dtMovimientos.Compute("sum(menge)", "menge > 0") Is System.DBNull.Value, 0, dtMovimientos.Compute("sum(menge)", "menge > 0"))
            'Me.lblTSalida.Text = -CInt(IIf(dtMovimientos.Compute("sum(menge)", "menge < 0") Is DBNull.Value, 0, dtMovimientos.Compute("sum(menge)", "menge < 0")))
            'Me.lblTFinal.Text = dtMovimientos.Compute("sum(menge)", "menge <> 0")
            MessageBox.Show("Movimientos cargados.", "Resultado Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se encontraron movimientos.", "Resultado Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub frmMovimientosPorArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.F2

                Dim oARReporte As New rptMovimientosPorArticulo(Me.ebCodigo.Text, Me.ebDescripcion.Text, Me.lblTEntrada.Text, Me.lblTSalida.Text, Me.lblTFinal.Text)
                oARReporte.DataSource = dtMovimientos
                oARReporte.Run()

                Dim oReportView As New ReportViewerForm
                oReportView.Report = oARReporte
                oReportView.ShowDialog()

        End Select
    End Sub
End Class
