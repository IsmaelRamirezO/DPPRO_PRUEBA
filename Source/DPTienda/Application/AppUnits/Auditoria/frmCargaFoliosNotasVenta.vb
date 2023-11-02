Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Public Class frmCargaFoliosNotasVenta
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nboxLimInf As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nBoxLimSup As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents StatusBar As Janus.Windows.UI.StatusBar.UIStatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiStatusBarPanel4 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaFoliosNotasVenta))
        Dim UiStatusBarPanel5 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel6 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.StatusBar = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nBoxLimSup = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nboxLimInf = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.StatusBar)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.btnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(500, 205)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 165)
        Me.StatusBar.Name = "StatusBar"
        UiStatusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel4.FormatStyle.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel4.Image = CType(resources.GetObject("UiStatusBarPanel4.Image"), System.Drawing.Image)
        UiStatusBarPanel4.Key = ""
        UiStatusBarPanel4.ProgressBarValue = 0
        UiStatusBarPanel4.Text = "Usuario:"
        UiStatusBarPanel4.Width = 86
        UiStatusBarPanel5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel5.FormatStyle.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel5.Key = ""
        UiStatusBarPanel5.ProgressBarValue = 0
        UiStatusBarPanel6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        UiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel6.FormatStyle.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel6.Image = CType(resources.GetObject("UiStatusBarPanel6.Image"), System.Drawing.Image)
        UiStatusBarPanel6.Key = ""
        UiStatusBarPanel6.ProgressBarValue = 0
        UiStatusBarPanel6.Width = 304
        Me.StatusBar.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel4, UiStatusBarPanel5, UiStatusBarPanel6})
        Me.StatusBar.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.StatusBar.Size = New System.Drawing.Size(500, 40)
        Me.StatusBar.TabIndex = 5
        Me.StatusBar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(400, 128)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(288, 128)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.nBoxLimSup)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.nboxLimInf)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Image = CType(resources.GetObject("UiGroupBox1.Image"), System.Drawing.Image)
        Me.UiGroupBox1.ImageSize = New System.Drawing.Size(30, 30)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(488, 104)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.Text = "Rango de Folios"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nBoxLimSup
        '
        Me.nBoxLimSup.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nBoxLimSup.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nBoxLimSup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nBoxLimSup.FormatString = "#,##0"
        Me.nBoxLimSup.Location = New System.Drawing.Point(372, 40)
        Me.nBoxLimSup.Name = "nBoxLimSup"
        Me.nBoxLimSup.Size = New System.Drawing.Size(96, 29)
        Me.nBoxLimSup.TabIndex = 5
        Me.nBoxLimSup.Text = "0"
        Me.nBoxLimSup.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nBoxLimSup.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 40)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "No. Folios a Agregar:"
        '
        'nboxLimInf
        '
        Me.nboxLimInf.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nboxLimInf.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nboxLimInf.BackColor = System.Drawing.Color.Gainsboro
        Me.nboxLimInf.Enabled = False
        Me.nboxLimInf.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nboxLimInf.FormatString = "#,##0"
        Me.nboxLimInf.Location = New System.Drawing.Point(136, 40)
        Me.nboxLimInf.Name = "nboxLimInf"
        Me.nboxLimInf.Size = New System.Drawing.Size(96, 29)
        Me.nboxLimInf.TabIndex = 3
        Me.nboxLimInf.Text = "0"
        Me.nboxLimInf.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nboxLimInf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 28)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folio Final:"
        '
        'frmCargaFoliosNotasVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(500, 205)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCargaFoliosNotasVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Folios Notas Venta"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Variables"
    Public AdmnistrativoID As String
    Public AdmnistrativoName As String
#End Region

#Region "Variables Globales"
    Dim oAjusteMgr As AjusteGeneralManager
    Dim oAjuste As AjusteGeneralInfo
    Dim oCatalogoCajasMgr As CatalogoCajaManager

#End Region
    Private Sub InicializarObjetos()
        oAjusteMgr = New AjusteGeneralManager(oAppContext)
        oCatalogoCajasMgr = New CatalogoCajaManager(oAppContext)
    End Sub
    Private Sub frmCargaFoliosNotasVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StatusBar.Panels(1).Text = AdmnistrativoName
        Me.StatusBar.Panels(2).Text = Format(Now, "Long Date")
        CargarLimiteInferior()
    End Sub
    Private Function CargarLimiteInferior() As Integer
        Dim FolioInferior As New Integer
        InicializarObjetos()
        FolioInferior = oAjusteMgr.LoadLimiteInferior()
        Me.nboxLimInf.Text = FolioInferior
        Return FolioInferior
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.nBoxLimSup.Value > 0 Then
            GuardarFolios()
            CleanAndLoad()

            MessageBox.Show("El rango de folios se agrego de forma correcta.", "Auditoria Dportenis PRO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El Limite superior de folios tiene que ser mayor que cero.", "Folios Notas de venta.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Public Sub GuardarFolios()
        Dim LimInf, LimSup As Integer
        Dim TotalFolios As Integer = 100
        Dim CodCaja As String = ""
        LimInf = Me.nboxLimInf.Value
        LimSup = Me.nBoxLimSup.Value
        TotalFolios = LimInf + LimSup
        CodCaja = oAppContext.ApplicationConfiguration.NoCaja
        If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If
        InicializarObjetos()
        oAjusteMgr.SaveFolios(LimInf, LimSup, TotalFolios, CodCaja)

    End Sub
    Public Sub CleanAndLoad()
        Me.nboxLimInf.Text = String.Empty
        Me.nBoxLimSup.Text = String.Empty
        CargarLimiteInferior()
        Me.btnAgregar.Focus()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class
