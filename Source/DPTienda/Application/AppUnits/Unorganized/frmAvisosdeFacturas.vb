
Imports DPSoft.Framework.Configuration
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports Janus.Windows.GridEX


Public Class frmAvisosdeFacturas
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
    Friend WithEvents GrdAvisosFactura As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MenuBarCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuBarCancelar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuBarGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents cbModulo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGuardarA As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEliminar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAvisosdeFacturas))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.btnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnGuardarA = New Janus.Windows.EditControls.UIButton()
        Me.cbModulo = New Janus.Windows.EditControls.UIComboBox()
        Me.GrdAvisosFactura = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuBarCancelar = New Janus.Windows.UI.CommandBars.UICommand("MenuBarCancelar")
        Me.MenuBarCancelar1 = New Janus.Windows.UI.CommandBars.UICommand("MenuBarCancelar")
        Me.MenuBarGuardar = New Janus.Windows.UI.CommandBars.UICommand("MenuBarGuardar")
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GrdAvisosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnEliminar)
        Me.ExplorerBar1.Controls.Add(Me.btnNuevo)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardarA)
        Me.ExplorerBar1.Controls.Add(Me.cbModulo)
        Me.ExplorerBar1.Controls.Add(Me.GrdAvisosFactura)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(600, 360)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Window
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(322, 313)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(104, 32)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.SystemColors.Window
        Me.btnNuevo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(26, 313)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(104, 32)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Window
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(466, 313)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Salir"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnGuardarA
        '
        Me.btnGuardarA.BackColor = System.Drawing.SystemColors.Window
        Me.btnGuardarA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarA.Location = New System.Drawing.Point(178, 313)
        Me.btnGuardarA.Name = "btnGuardarA"
        Me.btnGuardarA.Size = New System.Drawing.Size(104, 32)
        Me.btnGuardarA.TabIndex = 4
        Me.btnGuardarA.Text = "&Guardar"
        Me.btnGuardarA.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cbModulo
        '
        Me.cbModulo.BackColor = System.Drawing.Color.Ivory
        Me.cbModulo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbModulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "ABONOS"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "CONTRATOS"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "FACTURACION"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "NOTAS DE CREDITO"
        Me.cbModulo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4})
        Me.cbModulo.Location = New System.Drawing.Point(80, 24)
        Me.cbModulo.Name = "cbModulo"
        Me.cbModulo.Size = New System.Drawing.Size(168, 22)
        Me.cbModulo.TabIndex = 2
        Me.cbModulo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GrdAvisosFactura
        '
        Me.GrdAvisosFactura.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><GroupByBoxInfo>Arrast" & _
    "re una columna para agrupar</GroupByBoxInfo></LocalizableData>"
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdAvisosFactura.DesignTimeLayout = GridEXLayout1
        Me.GrdAvisosFactura.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdAvisosFactura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GrdAvisosFactura.Location = New System.Drawing.Point(8, 56)
        Me.GrdAvisosFactura.Name = "GrdAvisosFactura"
        Me.GrdAvisosFactura.Size = New System.Drawing.Size(584, 248)
        Me.GrdAvisosFactura.TabIndex = 6
        Me.GrdAvisosFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modulo"
        '
        'MenuBarCancelar
        '
        Me.MenuBarCancelar.Key = "MenuBarCancelar"
        Me.MenuBarCancelar.Name = "MenuBarCancelar"
        Me.MenuBarCancelar.Text = "Cancelar"
        '
        'MenuBarCancelar1
        '
        Me.MenuBarCancelar1.Key = "MenuBarCancelar"
        Me.MenuBarCancelar1.Name = "MenuBarCancelar1"
        '
        'MenuBarGuardar
        '
        Me.MenuBarGuardar.Key = "MenuBarGuardar"
        Me.MenuBarGuardar.Name = "MenuBarGuardar"
        Me.MenuBarGuardar.Text = "Guardar"
        '
        'frmAvisosdeFacturas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 357)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAvisosdeFacturas"
        Me.Text = "Avisos del Sistema"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.GrdAvisosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Dim oAvisosFacturaMgr As New AvisosFacturaManager(oAppContext)
    Dim oAvisosFactura As AvisosFactura
    Dim dsAvisosFactura As DataSet
    Dim NewId As Integer
    Dim vlClose As Boolean = False

#End Region


#Region "Metodos Miembros"

    Private Sub Sm_Nuevo()

        If GrdAvisosFactura.AllowAddNew = InheritableBoolean.True Then Exit Sub
        If cbModulo.Text = "" Then
            MsgBox("Seleccione el modulo al que desea agregar la Nota.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        GrdAvisosFactura.AllowAddNew = InheritableBoolean.True
        GrdAvisosFactura.Tables("AvisosFactura").Columns("Disponible").DefaultValue = True
        oAvisosFactura = oAvisosFacturaMgr.Load(cbModulo.Text)

        NewId = oAvisosFactura.ID


    End Sub

    Private Sub Sm_Guardar()


        Dim i As Integer

        If cbModulo.Text = "" Then
            MsgBox("Seleccione el modulo al que desea agregar la Nota.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If

        If (Fm_bolTxtValidar() = False) Then Exit Sub

        oAvisosFacturaMgr.Delete(cbModulo.Text)

        oAvisosFactura = oAvisosFacturaMgr.Create

        GrdAvisosFactura.MoveFirst()
        For i = 1 To GrdAvisosFactura.RowCount
            oAvisosFactura.ID = GrdAvisosFactura.GetValue(1)
            oAvisosFactura.Modulo = cbModulo.Text
            oAvisosFactura.Nota = GrdAvisosFactura.GetValue(3)

            'If (GrdAvisosFactura.GetValue(4) Then
            oAvisosFactura.Disponible = GrdAvisosFactura.GetValue(4)
            'Else
            '    oAvisosFactura.Disponible = False
            'End If

            oAvisosFactura.Usuario = GrdAvisosFactura.GetValue(5)
            oAvisosFactura.Fecha = GrdAvisosFactura.GetValue(6)
            oAvisosFactura.Status = GrdAvisosFactura.GetValue(7)

            oAvisosFactura.Save()

            GrdAvisosFactura.MoveNext()
        Next

        MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        GrdAvisosFactura.AllowAddNew = InheritableBoolean.False

        On Error Resume Next
        oAvisosFactura = Nothing

    End Sub

#End Region

#Region "Propiedades [ReadOnly]"

    Dim drResult As DataRowView

    Public ReadOnly Property Record() As DataRowView
        Get
            Return drResult
        End Get
    End Property

#End Region


#Region "Métodos Privados"

    Private Sub Sm_FinalizeObjects()

        On Error Resume Next

        vlClose = True
        oAvisosFacturaMgr = Nothing

    End Sub


    Public Sub SetupViewAvisosFactura()

        With GrdAvisosFactura.Tables("AvisosFactura")

            .Columns("ID").Visible = False

            .Columns("NumNota").Width = 50
            .Columns("NumNota").TextAlignment = TextAlignment.Center
            .Columns("NumNota").Caption = "Folio"
            .Columns("NumNota").Visible = True
            .Columns("NumNota").EditType = EditType.NoEdit


            .Columns("Modulo").Visible = False

            .Columns("Nota").Width = 450
            .Columns("Nota").Caption = "Nota"
            .Columns("Nota").Visible = True
            .Columns("NumNota").MaxLength = 150

            .Columns("Disponible").Width = 90
            .Columns("Disponible").Caption = "Disponible"
            .Columns("Disponible").Visible = True

            .Columns("Usuario").Visible = False
            .Columns("Fecha").Visible = False
            .Columns("StatusRegistro").Visible = False

        End With

    End Sub


    Private Sub Sm_BuscarAvisosFactura()

        dsAvisosFactura = oAvisosFacturaMgr.GetAll(cbModulo.Text)

        With GrdAvisosFactura
            .SetDataBinding(dsAvisosFactura, "AvisosFactura")
            .RetrieveStructure()

        End With

        SetupViewAvisosFactura()
        GrdAvisosFactura.AllowAddNew = InheritableBoolean.False

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"


    Private Sub frmAvisosdeFactura_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Sm_FinalizeObjects()

    End Sub

    Private Sub cbModulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbModulo.SelectedIndexChanged
        If vlClose = False Then
            Sm_BuscarAvisosFactura()
        End If
    End Sub
    Private Sub btnNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Sm_Nuevo()
    End Sub

    Private Sub btnGuardarA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarA.Click
        Sm_Guardar()
    End Sub

    Private Sub btnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        Dim i As Integer
        Dim x As String

        GrdAvisosFactura.MoveFirst()
        For i = 1 To GrdAvisosFactura.RowCount
            'x = ((GrdAvisosFactura.GetValue(3)))
            If IsDBNull(((GrdAvisosFactura.GetValue("Nota")))) Then
                MsgBox("Falta ingresar datos en la Columna Notas.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Function
            Else
                If (GrdAvisosFactura.GetValue(3).Length > 150) Then
                    MsgBox("Ha excedido el tamaño de caracteres de la columna Nota.", MsgBoxStyle.Exclamation, "DPTienda")
                    Exit Function
                End If
            End If

            GrdAvisosFactura.MoveNext()
        Next


        If (GrdAvisosFactura Is Nothing) Then
            MsgBox("El Detalle del Traspaso no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If


        If (GrdAvisosFactura.RowCount = 0) Then
            MsgBox("El Detalle del Traspaso no cuenta con Registros.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If

        Return True

    End Function

    Private Sub GrdAvisosFactura_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GrdAvisosFactura.AddingRecord

        'If Len(GrdAvisosFactura.Tables("AvisosFactura").Columns("Nota")) > 150 Then
        'MsgBox("Excede")
        'Exit Sub
        'End If

        NewId = (NewId + 1)
        GrdAvisosFactura.Tables("AvisosFactura").Columns("NumNota").EditType = EditType.TextBox

        GrdAvisosFactura.SetValue("NumNota", NewId)
        GrdAvisosFactura.SetValue("Usuario", oAppContext.Security.CurrentUser.Name)
        GrdAvisosFactura.SetValue("Fecha", Date.Now)
        GrdAvisosFactura.SetValue("StatusRegistro", True)

        GrdAvisosFactura.Tables("AvisosFactura").Columns("NumNota").EditType = EditType.NoEdit

    End Sub

#End Region

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        GrdAvisosFactura.AllowDelete = InheritableBoolean.True
        GrdAvisosFactura.Delete()
        GrdAvisosFactura.Refresh()

    End Sub

    Private Sub GrdAvisosFactura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdAvisosFactura.GotFocus
        btnEliminar.Enabled = True
        GrdAvisosFactura.Tables("AvisosFactura").Columns("Nota").MaxLength = 150

    End Sub

    Private Sub GrdAvisosFactura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdAvisosFactura.LostFocus
        btnEliminar.Enabled = False
    End Sub

    Private Sub frmAvisosdeFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
