Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmCuentasxCobrar
    Inherits DPTienda.GridReportBaseForm
    Private mdsDatos As DataSet
    Private msAlmacen As String
    Private mnTipo As Integer '0=Cuentas x cobrar grabadas,1=Canceladas

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal Tipo As Integer)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        mnTipo = Tipo
        Select Case mnTipo
            Case 0
                Text = "Reporte de cuentas por cobrar"
            Case 1
                Text = "Reporte de cuentas por cobrar canceladas"
        End Select
        txtAlmacen.Text = oAppContext.ApplicationConfiguration.Almacen
        txtCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents ccDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasxCobrar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtCaja = New System.Windows.Forms.TextBox()
        Me.ccDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.TabIndex = 4
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.Size = New System.Drawing.Size(504, 131)
        '
        'uigbParameters
        '
        Me.uigbParameters.Controls.Add(Me.ccHasta)
        Me.uigbParameters.Controls.Add(Me.ccDesde)
        Me.uigbParameters.Controls.Add(Me.txtCaja)
        Me.uigbParameters.Controls.Add(Me.txtAlmacen)
        Me.uigbParameters.Controls.Add(Me.Label4)
        Me.uigbParameters.Controls.Add(Me.Label3)
        Me.uigbParameters.Controls.Add(Me.Label2)
        Me.uigbParameters.Controls.Add(Me.Label1)
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        Me.uigbParameters.Controls.SetChildIndex(Me.Label1, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.Label2, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.Label3, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.Label4, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.txtAlmacen, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.txtCaja, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ccDesde, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.ccHasta, 0)
        Me.uigbParameters.Controls.SetChildIndex(Me.btnGenerateReport, 0)
        '
        'uicmEnvironment
        '
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        Me.uicmEnvironment.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(216, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Caja"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(216, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Hasta"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.BackColor = System.Drawing.Color.Ivory
        Me.txtAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlmacen.Location = New System.Drawing.Point(80, 8)
        Me.txtAlmacen.MaxLength = 3
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(112, 21)
        Me.txtAlmacen.TabIndex = 0
        Me.txtAlmacen.Text = "000"
        '
        'txtCaja
        '
        Me.txtCaja.BackColor = System.Drawing.Color.Ivory
        Me.txtCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaja.Location = New System.Drawing.Point(296, 8)
        Me.txtCaja.MaxLength = 2
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(112, 21)
        Me.txtCaja.TabIndex = 1
        Me.txtCaja.Text = "00"
        '
        'ccDesde
        '
        Me.ccDesde.BackColor = System.Drawing.Color.Ivory
        Me.ccDesde.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat
        '
        '
        '
        Me.ccDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccDesde.Location = New System.Drawing.Point(80, 32)
        Me.ccDesde.Name = "ccDesde"
        Me.ccDesde.Size = New System.Drawing.Size(112, 21)
        Me.ccDesde.TabIndex = 2
        Me.ccDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccHasta
        '
        Me.ccHasta.BackColor = System.Drawing.Color.Ivory
        Me.ccHasta.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat
        '
        '
        '
        Me.ccHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccHasta.Location = New System.Drawing.Point(296, 32)
        Me.ccHasta.Name = "ccHasta"
        Me.ccHasta.Size = New System.Drawing.Size(112, 21)
        Me.ccHasta.TabIndex = 3
        Me.ccHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'dlgArchivo
        '
        Me.dlgArchivo.CheckFileExists = False
        Me.dlgArchivo.DefaultExt = "xls"
        Me.dlgArchivo.Filter = "Archivos Excel (*.xls)|*.xls|Todos los Archivos (*.*)|*.*"
        '
        'frmCuentasxCobrar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 253)
        Me.Name = "frmCuentasxCobrar"
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        Me.uigbParameters.PerformLayout()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Friend Overrides Sub ActionPrint()

        ' Dim piCXC As CuentasXCobrar.CuentasXCobrar

        Dim piRep As rptCuentasxCobrar

        Dim piPrev As ReportViewerForm

        Cursor = Cursors.WaitCursor

        'piCXC = New CuentasXCobrar.CuentasXCobrar

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'piCXC.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'piCXC.strURL.TrimStart("/")

        End If

        piPrev = New ReportViewerForm

        piRep = New rptCuentasxCobrar

        piRep.Desde = ccDesde.Value

        piRep.Hasta = ccHasta.Value

        piRep.CodigoSucursal = txtAlmacen.Text

        piRep.NombreSucursal = msAlmacen

        piRep.Caja = txtCaja.Text

        If mnTipo = 1 Then
            piRep.Titulo = "REPORTE DE CUENTAS POR COBRAR CANCELADAS"
        End If
        piRep.DataSource = mdsDatos
        piRep.DataMember = "CuentasXCobrar"
        piRep.Document.Print(False, False)
        Cursor = Cursors.Default
    End Sub

    Protected Friend Overrides Sub ActionPreview()
        'Dim piCXC As CuentasXCobrar.CuentasXCobrar
        Dim piRep As rptCuentasxCobrar
        Dim piPrev As ReportViewerForm

        'Cursor = Cursors.WaitCursor
        'piCXC = New CuentasXCobrar.CuentasXCobrar
        piPrev = New ReportViewerForm
        piRep = New rptCuentasxCobrar
        piRep.Desde = ccDesde.Value
        piRep.Hasta = ccHasta.Value
        piRep.CodigoSucursal = txtAlmacen.Text
        piRep.NombreSucursal = msAlmacen
        piRep.Caja = txtCaja.Text
        If mnTipo = 1 Then
            piRep.Titulo = "REPORTE DE CUENTAS POR COBRAR CANCELADAS"
        End If
        piRep.DataSource = mdsDatos
        piRep.DataMember = "CuentasXCobrar"
        piRep.Run()
        piPrev.Report = piRep
        piPrev.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Protected Friend Overrides Sub ActionGenerate()
        Dim pdsDatos As DataSet

        Cursor = Cursors.WaitCursor
        ObtDatos()
        geResults.DataSource = mdsDatos
        geResults.DataMember = "CuentasXCobrar"
        msAlmacen = ObtNombreAlmacen()
        Cursor = Cursors.Default
    End Sub

    Private Sub ObtDatos()

        'Dim piCXC As CuentasXCobrar.CuentasXCobrar
        Dim i As Integer

        'piCXC = New CuentasXCobrar.CuentasXCobrar
        'piCXC.Url = oAppContext.ApplicationConfiguration.WSUrl.Trim("/") & "/Credito/CuentasXCobrar.asmx"
        Select Case mnTipo
            Case 0
                'mdsDatos = piCXC.ObtCuentasXCobrar(ccDesde.Value, ccHasta.Value, txtAlmacen.Text, txtCaja.Text)
            Case 1
                'mdsDatos = piCXC.ObtCuentasXCobrarCan(ccDesde.Value, ccHasta.Value, txtAlmacen.Text, txtCaja.Text)
        End Select
        mdsDatos.Tables("CuentasXCobrar").Columns.Add("Abonos", Type.GetType("System.Double"))
        For i = 0 To mdsDatos.Tables("CuentasXCobrar").Rows.Count - 1
            mdsDatos.Tables("CuentasXCobrar").Rows(i).Item("Abonos") = mdsDatos.Tables("CuentasXCobrar").Rows(i).Item("PagoEstablecido") - mdsDatos.Tables("CuentasXCobrar").Rows(i).Item("Saldo")
        Next

    End Sub

    Private Function ObtNombreAlmacen() As String

        Dim piAlmMng As CatalogoAlmacenesManager

        Dim piAlm As Almacen

        piAlmMng = New CatalogoAlmacenesManager(oAppContext)

        piAlm = piAlmMng.Create()

        piAlm = piAlmMng.Load(txtAlmacen.Text)

        ObtNombreAlmacen = piAlm.Descripcion

    End Function

    Protected Friend Overrides Sub ActionExport()

        Dim piExp As RepAjustesESEng.cCuentasXCobrar
        Dim psArchivo As String
        Dim psTitulo As String

        If dlgArchivo.ShowDialog() = DialogResult.OK Then
            psArchivo = dlgArchivo.FileName
            Cursor = Cursors.WaitCursor
            piExp = New RepAjustesESEng.cCuentasXCobrar
            If mnTipo = 1 Then
                psTitulo = "REPORTE DE CUENTAS POR COBRAR CANCELADAS"
            Else
                psTitulo = "REPORTE DE CUENTAS POR COBRAR"
            End If
            piExp.ExportarXLS(psArchivo, psTitulo, ccDesde.Value, ccHasta.Value, txtAlmacen.Text, msAlmacen, txtCaja.Text, mdsDatos.Tables("CuentasXCobrar"))
            Cursor = Cursors.Default
        End If

    End Sub

End Class
