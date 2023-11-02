Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Public Class frmCancelarNotaVenta
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtUserName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents txtfolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarNotaVenta))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnCancel = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtfolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtUserID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.btnCancel)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(340, 261)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(240, 216)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(144, 216)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.txtfolio)
        Me.UiGroupBox1.Controls.Add(Me.cmbCaja)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtUserName)
        Me.UiGroupBox1.Controls.Add(Me.txtUserID)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Image = CType(resources.GetObject("UiGroupBox1.Image"), System.Drawing.Image)
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(304, 184)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Cancelacion de Nota Venta Manual"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtfolio
        '
        Me.txtfolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtfolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtfolio.ButtonImage = CType(resources.GetObject("txtfolio.ButtonImage"), System.Drawing.Image)
        Me.txtfolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfolio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtfolio.Location = New System.Drawing.Point(180, 128)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(112, 29)
        Me.txtfolio.TabIndex = 6
        Me.txtfolio.Text = "0"
        Me.txtfolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'cmbCaja
        '
        Me.cmbCaja.Location = New System.Drawing.Point(128, 100)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(48, 24)
        Me.cmbCaja.TabIndex = 5
        Me.cmbCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "No. Caja:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Folio Nota Venta:"
        '
        'txtUserName
        '
        Me.txtUserName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUserName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUserName.BackColor = System.Drawing.Color.Ivory
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(80, 60)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(216, 24)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'txtUserID
        '
        Me.txtUserID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtUserID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtUserID.BackColor = System.Drawing.Color.Ivory
        Me.txtUserID.Enabled = False
        Me.txtUserID.Location = New System.Drawing.Point(116, 28)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(180, 24)
        Me.txtUserID.TabIndex = 1
        Me.txtUserID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Autoriza       :"
        '
        'frmCancelarNotaVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(340, 261)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCancelarNotaVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancenar Nota de Venta Manual"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "V_Globales"

    Dim vUserID As String
    Dim vUserName As String
#End Region
#Region "Inicializa"

#Region "Variables Globales"
    Dim oAjusteMgr As AjusteGeneralManager
#End Region
    Private Sub InicializarObjetos()
        oAjusteMgr = New AjusteGeneralManager(oAppContext)
    End Sub

#End Region
    Private Sub FillCaja()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        oCajaMgr = New CatalogoCajaManager(oAppContext)

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(True)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1
                cmbCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))
            Next i

            dsCaja = Nothing

            cmbCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        End If

        oCajaMgr.Dispose()
        oCajaMgr = Nothing

    End Sub
    Private Sub UpdStatusRegFolioNotaVenta(ByVal Folio As Integer)

        InicializarObjetos()
        oAjusteMgr.UpdStatusRegNotaVenta(Folio)

    End Sub
    Private Sub Sm_BuscarFolioNotaVenta(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        Dim CodCaja As String
        Dim Existe As Boolean = False
        Dim Folio2Del As Integer = 0
        Dim FolioFound As Integer = 0
        '<Validación>
        CodCaja = Me.cmbCaja.Text
        If (CodCaja = String.Empty) Then
            MsgBox("No ha sido seleccionada un Código de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If
        '<Validación>
        InicializarObjetos()
        Folio2Del = Me.txtfolio.Value
        FolioFound = ValidateFolio(Folio2Del)

        If FolioFound = 1 Then
            Existe = True
        Else
            Existe = False
        End If
        If Existe = False Then
            MessageBox.Show("El Folio " & Folio2Del & " no se puede cancelar por alguna de las siguientes razónes: " & vbCrLf & " + El Folio aún no se ha dado de alta. " & vbCrLf & " + El Folio de venta manual no se ha usado para una factura.", "Folio no existe.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'Si si se encontro el folio factura y cumple con los requisitos se cambia el Status a CAN
            Me.UpdStatusRegFolioNotaVenta(Folio2Del)
            MessageBox.Show("El Folio " & Folio2Del & " se ha Cancelado de forma satisfactoria.", "Informacion Nota Venta Manual.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub frmCancelarNotaVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vUserID = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
        vUserName = UCase(oAppContext.Security.CurrentUser.Name)
        Me.txtUserID.Text = vUserID
        Me.txtUserName.Text = vUserName

        oAppContext.Security.CloseImpersonatedSession()
        FillCaja()

    End Sub
    Public Function ValidateFolio(ByVal Folio As Integer) As Integer
        Dim FolioFound As New Integer
        InicializarObjetos()
        FolioFound = oAjusteMgr.BuscarFolio(Folio)

        Return FolioFound
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Sm_BuscarFolioNotaVenta()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
