Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class frmReporteCatalogoMotivosFac
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
    Friend WithEvents ebStatus As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnReporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbTipoMovto As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCatalogoMotivosFac))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cbTipoMovto = New Janus.Windows.EditControls.UIComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnReporte = New Janus.Windows.EditControls.UIButton()
        Me.ebStatus = New Janus.Windows.EditControls.UIComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.cbTipoMovto)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.cbFin)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.cbInicio)
        Me.ExplorerBar1.Controls.Add(Me.btnReporte)
        Me.ExplorerBar1.Controls.Add(Me.ebStatus)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Seleccion de Filtro"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(432, 157)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cbTipoMovto
        '
        Me.cbTipoMovto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbTipoMovto.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoMovto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "VENTA"
        UiComboBoxItem1.Value = "VTA"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "TRASPASO DE ENTRADA"
        UiComboBoxItem2.Value = "TE"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "TRASPASO DE SALIDA"
        UiComboBoxItem3.Value = "TS"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "TODOS"
        UiComboBoxItem4.Value = "TODOS"
        Me.cbTipoMovto.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4})
        Me.cbTipoMovto.Location = New System.Drawing.Point(80, 88)
        Me.cbTipoMovto.Name = "cbTipoMovto"
        Me.cbTipoMovto.Size = New System.Drawing.Size(120, 22)
        Me.cbTipoMovto.TabIndex = 6
        Me.cbTipoMovto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo Movto.:"
        '
        'cbFin
        '
        '
        '
        '
        Me.cbFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cbFin.Location = New System.Drawing.Point(280, 48)
        Me.cbFin.Name = "cbFin"
        Me.cbFin.Size = New System.Drawing.Size(120, 20)
        Me.cbFin.TabIndex = 3
        Me.cbFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(224, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta:"
        '
        'cbInicio
        '
        '
        '
        '
        Me.cbInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cbInicio.Location = New System.Drawing.Point(80, 48)
        Me.cbInicio.Name = "cbInicio"
        Me.cbInicio.Size = New System.Drawing.Size(120, 20)
        Me.cbInicio.TabIndex = 1
        Me.cbInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.SystemColors.Window
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Location = New System.Drawing.Point(272, 112)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(128, 32)
        Me.btnReporte.TabIndex = 4
        Me.btnReporte.Text = "&Reporte"
        Me.btnReporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebStatus
        '
        Me.ebStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebStatus.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.IsSeparator = False
        UiComboBoxItem5.Text = "ACTIVO"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.IsSeparator = False
        UiComboBoxItem6.Text = "INACTIVO"
        Me.ebStatus.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem5, UiComboBoxItem6})
        Me.ebStatus.Location = New System.Drawing.Point(168, 192)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.Size = New System.Drawing.Size(128, 22)
        Me.ebStatus.TabIndex = 4
        Me.ebStatus.Visible = False
        Me.ebStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Status:"
        Me.Label6.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'frmReporteCatalogoMotivosFac
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 157)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmReporteCatalogoMotivosFac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Motivos Captura Manual"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oFacturaMGR As FacturaManager
    Dim dsMotivos As DataSet
    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        If valida() Then
            oFacturaMGR = New FacturaManager(oAppContext)
            dsMotivos = New DataSet
            dsMotivos = oFacturaMGR.SelectMotivosFac(Me.cbInicio.Value, Me.cbFin.Value, Me.cbTipoMovto.SelectedValue)
            If dsMotivos.Tables(0).Rows.Count > 0 Then

                Dim orptCat As New rptCatalogoMotivosFac(GetAlmacen(), Me.cbTipoMovto.Text)
                orptCat.DataSource = dsMotivos
                orptCat.DataMember = dsMotivos.Tables(0).TableName

                Dim oReportViewer As New ReportViewerForm
                orptCat.Document.Name = "Reporte De Motivos"
                orptCat.Run()

                oReportViewer.Report = orptCat
                oReportViewer.WindowState = FormWindowState.Maximized
                oReportViewer.Show()
            Else
                MsgBox("!No se encontraron registros¡", MsgBoxStyle.Information, Me.Text)

            End If

        End If
    End Sub

    Private Function valida() As Boolean
        valida = False
        If Me.cbInicio.Value = Nothing Then
            MsgBox("!La fecha inicio se requiere¡", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If
        If Me.cbFin.Value = Nothing Then
            MsgBox("!La fecha fin se requiere¡", MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If

        valida = True
    End Function

    Private Sub frmReporteCatalogoMotivosFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReporteCatalogoMotivosFac_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cbTipoMovto.SelectedValue = "TODOS"
    End Sub
End Class
