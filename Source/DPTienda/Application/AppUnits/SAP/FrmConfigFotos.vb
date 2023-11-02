Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU

Public Class FrmConfigFotos
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
    Friend WithEvents ebUnidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EbRuta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents UiBtnTest As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSave As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmConfigFotos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ebUnidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EbRuta = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblStatus = New System.Windows.Forms.Label
        Me.UiBtnTest = New Janus.Windows.EditControls.UIButton
        Me.btnCancel = New Janus.Windows.EditControls.UIButton
        Me.btnSave = New Janus.Windows.EditControls.UIButton
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebUnidad)
        Me.ExplorerBar1.Controls.Add(Me.EbRuta)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebPassword)
        Me.ExplorerBar1.Controls.Add(Me.ebUsuario)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.LblStatus)
        Me.ExplorerBar1.Controls.Add(Me.UiBtnTest)
        Me.ExplorerBar1.Controls.Add(Me.btnCancel)
        Me.ExplorerBar1.Controls.Add(Me.btnSave)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-4, -1)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(336, 256)
        Me.ExplorerBar1.TabIndex = 7
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebUnidad
        '
        Me.ebUnidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidad.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUnidad.Location = New System.Drawing.Point(100, 126)
        Me.ebUnidad.MaxLength = 2
        Me.ebUnidad.Name = "ebUnidad"
        Me.ebUnidad.Size = New System.Drawing.Size(24, 26)
        Me.ebUnidad.TabIndex = 4
        Me.ebUnidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EbRuta
        '
        Me.EbRuta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EbRuta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EbRuta.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EbRuta.Location = New System.Drawing.Point(100, 92)
        Me.EbRuta.MaxLength = 100
        Me.EbRuta.Name = "EbRuta"
        Me.EbRuta.Size = New System.Drawing.Size(224, 26)
        Me.EbRuta.TabIndex = 3
        Me.EbRuta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EbRuta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(28, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 22)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Unidad"
        '
        'ebPassword
        '
        Me.ebPassword.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPassword.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPassword.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(100, 58)
        Me.ebPassword.MaxLength = 30
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Microsoft.VisualBasic.ChrW(174)
        Me.ebPassword.Size = New System.Drawing.Size(144, 26)
        Me.ebPassword.TabIndex = 1
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUsuario
        '
        Me.ebUsuario.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUsuario.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUsuario.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuario.Location = New System.Drawing.Point(100, 24)
        Me.ebUsuario.MaxLength = 30
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.Size = New System.Drawing.Size(144, 26)
        Me.ebUsuario.TabIndex = 0
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 22)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(44, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 22)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Ruta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 22)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Usuario"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.Color.Transparent
        Me.LblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblStatus.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblStatus.Location = New System.Drawing.Point(8, 160)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(320, 24)
        Me.LblStatus.TabIndex = 18
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UiBtnTest
        '
        Me.UiBtnTest.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBtnTest.Location = New System.Drawing.Point(20, 208)
        Me.UiBtnTest.Name = "UiBtnTest"
        Me.UiBtnTest.Size = New System.Drawing.Size(72, 32)
        Me.UiBtnTest.TabIndex = 5
        Me.UiBtnTest.Text = "&Probar"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(204, 208)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 32)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Salir"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(92, 208)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "&Guardar"
        '
        'FrmConfigFotos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 19)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(328, 254)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(336, 288)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(336, 288)
        Me.Name = "FrmConfigFotos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar Ruta Imagenes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Montar Unidad RED"


    Structure NETRESOURCE
        Public dwScope As Int32
        Public dwType As Int32
        Public dwDisplayType As Int32
        Public dwUsage As Int32
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure

    Public Const NO_ERROR As Int32 = 0
    Public Const CONNECT_UPDATE_PROFILE As Int32 = &H1
    Public Const RESOURCETYPE_DISK As Int32 = &H1
    Private Const RESOURCETYPE_PRINT = &H2
    Private Const RESOURCETYPE_ANY = &H0
    Private Const RESOURCE_CONNECTED = &H1
    Private Const RESOURCE_REMEMBERED = &H3
    Private Const RESOURCE_GLOBALNET = &H2
    Private Const RESOURCEDISPLAYTYPE_DOMAIN = &H1
    Private Const RESOURCEDISPLAYTYPE_GENERIC = &H0
    Private Const RESOURCEDISPLAYTYPE_SERVER = &H2
    Private Const RESOURCEDISPLAYTYPE_SHARE = &H3
    Private Const RESOURCEUSAGE_CONNECTABLE = &H1
    Private Const RESOURCEUSAGE_CONTAINER = &H2

    Declare Function WNetAddConnection2 Lib "mpr.dll" Alias _
      "WNetAddConnection2A" (ByRef lpNetResource As NETRESOURCE, _
       ByVal lpPassword As String, ByVal lpUserName As String, _
      ByVal dwFlags As Int32) As Int32
    '
    Declare Function WNetCancelConnection2 Lib "mpr.dll" Alias _
    "WNetCancelConnection2A" (ByVal lpName As String, _
    ByVal dwFlags As Long, ByVal fForce As Long) As Long

    Dim NetR As New NETRESOURCE
#End Region

    Private strConfigurationFile As String = Application.StartupPath & "\configFotos.cml"

    Private Sub ShowConfigFotos()

        With oConfigFotos
            Me.ebUnidad.Text = .Unidad
            Me.EbRuta.Text = .Ruta
            Me.ebUsuario.Text = .Usuario
            Me.ebPassword.Text = .Password
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ebUsuario.Text <> String.Empty And ebPassword.Text <> String.Empty And EbRuta.Text <> String.Empty And ebUnidad.Text <> String.Empty Then
            Dim oReader As New ConfigSaveArchivosReader(strConfigurationFile)
            Dim oSettings As New ConfigSaveArchivos
            With oSettings
                .Ruta = Me.EbRuta.Text
                .Usuario = Me.ebUsuario.Text
                .Password = Me.ebPassword.Text
                .Unidad = Me.ebUnidad.Text
            End With
            oReader.SaveSettings(oSettings)
            oSettings = Nothing
            oReader = Nothing
            '''Cargamos nuevamente en el objeto global los datos
            LoadConfigFotos()
            MsgBox("Se guardó configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "DPTienda")
        Else
            If ebUsuario.Text = String.Empty Then
                MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                ebUsuario.Focus()
            Else
                If Me.ebPassword.Text = String.Empty Then
                    MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                    ebPassword.Focus()
                Else
                    If Me.EbRuta.Text = String.Empty Then
                        MsgBox("Falta IP", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                        EbRuta.Focus()
                    Else
                        If Me.ebUnidad.Text = String.Empty Then
                            MsgBox("Falta Unidad", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                            ebUnidad.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmConfigCierreSAP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(strConfigurationFile) Then
            ShowConfigFotos()
        End If
    End Sub

    Private Sub UiBtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBtnTest.Click
        Me.LblStatus.Text = ""
        Try
            If ebUsuario.Text <> String.Empty And ebPassword.Text <> String.Empty And EbRuta.Text <> String.Empty And ebUnidad.Text <> String.Empty Then
                Conecta()
                Desconecta()
                Desconecta()
            Else
                If ebUsuario.Text = String.Empty Then
                    MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                    ebUsuario.Focus()
                Else
                    If Me.ebPassword.Text = String.Empty Then
                        MsgBox("Falta Usuario", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                        ebPassword.Focus()
                    Else
                        If Me.EbRuta.Text = String.Empty Then
                            MsgBox("Falta Ruta", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "DpTienda")
                            EbRuta.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Conecta()
        Dim ErrInfo As Long
        Dim MyPass As String, MyUser As String
        MyPass = Me.ebPassword.Text
        MyUser = Me.ebUsuario.Text

        NetR.dwScope = RESOURCE_GLOBALNET
        NetR.dwType = RESOURCETYPE_DISK
        NetR.dwDisplayType = RESOURCEDISPLAYTYPE_SHARE
        NetR.dwUsage = RESOURCEUSAGE_CONNECTABLE
        NetR.lpLocalName = Me.ebUnidad.Text
        NetR.lpRemoteName = Me.EbRuta.Text

        ErrInfo = WNetAddConnection2(NetR, MyPass, MyUser, CONNECT_UPDATE_PROFILE)
        If ErrInfo = NO_ERROR Then
            Me.LblStatus.ForeColor = System.Drawing.Color.Green
            LblStatus.Text = " Conexión realizada con éxito"
        Else
            Me.LblStatus.ForeColor = System.Drawing.Color.Red
            LblStatus.Text = " ERROR al intentar realizar la conexión"
        End If

    End Sub

    Private Sub Desconecta()
        Dim ErrInfo As Long
        ErrInfo = WNetCancelConnection2(NetR.lpLocalName, CONNECT_UPDATE_PROFILE, True)
        If ErrInfo = NO_ERROR Then
            'Se desconecto
        Else
            'error al desconectar
        End If
    End Sub


End Class
