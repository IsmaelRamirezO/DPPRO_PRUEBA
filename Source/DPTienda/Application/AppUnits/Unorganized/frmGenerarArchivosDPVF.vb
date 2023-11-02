Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports System.IO

Public Class frmGenerarArchivosDPVF
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
    Friend WithEvents txtNoDPVale As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoDPVale As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRuta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipoArchivo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.txtRuta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNoDPVale = New System.Windows.Forms.Label()
        Me.txtNoDPVale = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbTipoArchivo = New Janus.Windows.EditControls.UIComboBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.lblTipo)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.txtRuta)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.lblNoDPVale)
        Me.ExplorerBar1.Controls.Add(Me.txtNoDPVale)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(344, 348)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.Transparent
        Me.lblTipo.Location = New System.Drawing.Point(24, 80)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(56, 23)
        Me.lblTipo.TabIndex = 8
        Me.lblTipo.Text = "Tipo:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(24, 112)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(312, 23)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "Generar Archivos"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtRuta
        '
        Me.txtRuta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtRuta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtRuta.BackColor = System.Drawing.SystemColors.Info
        Me.txtRuta.Location = New System.Drawing.Point(88, 56)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(248, 20)
        Me.txtRuta.TabIndex = 3
        Me.txtRuta.TabStop = False
        Me.txtRuta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtRuta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ruta:"
        '
        'lblNoDPVale
        '
        Me.lblNoDPVale.BackColor = System.Drawing.Color.Transparent
        Me.lblNoDPVale.Location = New System.Drawing.Point(24, 32)
        Me.lblNoDPVale.Name = "lblNoDPVale"
        Me.lblNoDPVale.Size = New System.Drawing.Size(56, 23)
        Me.lblNoDPVale.TabIndex = 2
        Me.lblNoDPVale.Text = "# DPVale:"
        '
        'txtNoDPVale
        '
        Me.txtNoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoDPVale.Location = New System.Drawing.Point(88, 32)
        Me.txtNoDPVale.MaxLength = 10
        Me.txtNoDPVale.Name = "txtNoDPVale"
        Me.txtNoDPVale.Size = New System.Drawing.Size(75, 20)
        Me.txtNoDPVale.TabIndex = 0
        Me.txtNoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbTipoArchivo
        '
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Abono A Tarjeta (Layout D)"
        UiComboBoxItem3.Value = 1
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.IsSeparator = False
        UiComboBoxItem4.Text = "Registro de Tarjeta"
        UiComboBoxItem4.Value = 2
        Me.cmbTipoArchivo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem3, UiComboBoxItem4})
        Me.cmbTipoArchivo.Location = New System.Drawing.Point(80, 72)
        Me.cmbTipoArchivo.Name = "cmbTipoArchivo"
        Me.cmbTipoArchivo.Size = New System.Drawing.Size(248, 20)
        Me.cmbTipoArchivo.TabIndex = 1
        Me.cmbTipoArchivo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmGenerarArchivosDPVF
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 142)
        Me.Controls.Add(Me.cmbTipoArchivo)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.MaximizeBox = False
        Me.Name = "frmGenerarArchivosDPVF"
        Me.Text = "Generar Archivos DPVF"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oDPVale As cDPVale
    Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    Dim oDPVF As DPVFinanciero
    Dim oDPVFMgr As New DPValeFinancieroManager(oAppContext, oConfigCierreFI)

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim oRow As DataRow
        Dim oFrmDPVF As New DPValeFinanciero
        oFrmDPVF.ClearFields()

        Dim strSec As String
        Dim Tam As Integer
        Dim Tipo As Integer
        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, _
                                                               oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)

        'If oMontarURed.Conecta() Then

        'Else
        '    MsgBox("Es necesario configurar correctamente las rutas de archivos", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
        '    oMontarURed = Nothing
        '    Exit Sub
        'End If

        Try

            If ValidaCampos() = True Then

                'If Directory.Exists(Trim(Me.txtRuta.Text)) = False Then

                '    MkDir(Trim(Me.txtRuta.Text))

                'End If

                'If Directory.Exists(Trim(Me.txtRuta.Text)) Then

                Tam = Len(Me.txtRuta.Text)
                If Mid(Me.txtRuta.Text, Tam, 1) = "\" Then
                    Me.txtRuta.Text = Mid(Me.txtRuta.Text, 1, Len(Me.txtRuta.Text) - 1)
                End If

                oDPVale = New cDPVale
                oDPVale.INUMVA = Trim(Me.txtNoDPVale.Text).PadLeft(10, "0")
                oDPVale.I_RUTA = "X"
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                If oDPVale.EEXIST = "S" Then

                    oRow = oDPVale.InfoDPVALE.Rows(0)

                    If oDPVale.ESTATU = "U" Then

                        Tipo = Me.cmbTipoArchivo.SelectedValue
                        oDPVF = oDPVFMgr.Create
                        oDPVF = oDPVFMgr.Load(Trim(Me.txtNoDPVale.Text), Tipo)

                        If oDPVF Is Nothing Then

                            If Tipo = 1 Then

                                MsgBox("El vale capturado no está asociado con un prestamo financiero", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                Me.txtNoDPVale.Focus()

                            Else

                                MsgBox("No existe el archivo de registro de tarjeta DPago para el vale capturado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                Me.cmbTipoArchivo.Focus()

                            End If

                        Else

                            If Format(oDPVF.Fecha, "dd/MM/yyyy").ToUpper <> Format(Date.Today, "dd/MM/yyy").ToUpper Then

                                MsgBox("Solo se pueden generar los archivos de prestamos de hoy", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                                oDPVF = Nothing
                                Me.txtNoDPVale.Focus()
                                Exit Sub

                            Else

                                oFrmDPVF.txtNoCliente.Text = oDPVF.IDCliente
                                oFrmDPVF.txtIntereses.Text = oDPVF.Intereses
                                oFrmDPVF.cmbMonto.Text = oDPVF.Importe
                                oFrmDPVF.txtFecha.Text = oDPVF.Fecha
                                oFrmDPVF.txtNoTarjeta.Text = oDPVF.NoCuentaAbono.Trim
                                oFrmDPVF.txtNoDPVale.Text = oDPVF.NoDPVale
                                strSec = CStr(oDPVF.SecuencialFile).PadLeft(4, "0")

                                oFrmDPVF.GenerarArchivos(Trim(Me.txtRuta.Text), False, Me.cmbTipoArchivo.SelectedValue, strSec)

                                MsgBox("Archivo Generado Satisfactoriamente", MsgBoxStyle.Information, "Dportenis Vale Financiero")
                                Me.txtNoDPVale.Focus()

                            End If

                        End If

                    Else

                        If oRow.Item("STATU") = "C" Then
                            MsgBox("El vale capturado está cancelado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        Else
                            MsgBox("El vale capturado no ha sido utilizado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        End If
                        oDPVale = Nothing
                        Me.txtNoDPVale.Focus()

                    End If

                Else

                    MsgBox("El vale capturado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    oDPVale = Nothing
                    Me.txtNoDPVale.Focus()

                End If

                'Else

                '    MsgBox("El directorio especificado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                '    Me.txtRuta.Focus()

                'End If

            End If

        Catch ex As Exception
            oMontarURed.Desconecta()
            oMontarURed.Desconecta()
        Finally
            oMontarURed.Desconecta()
            oMontarURed.Desconecta()
        End Try


    End Sub

    Private Function ValidaCampos() As Boolean

        ValidaCampos = True

        If Me.txtNoDPVale.Text = String.Empty Then
            MsgBox("Es necesario especificar el numero DPVale", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            Me.txtNoDPVale.Focus()
        End If

        If Me.txtRuta.Text = String.Empty Then
            MsgBox("Es necesario especificar la ruta", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            Me.txtRuta.Focus()
        End If

        If Me.cmbTipoArchivo.Text = String.Empty Then
            MsgBox("Es necesario especificar el tipo de archivo", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
            ValidaCampos = False
            Me.cmbTipoArchivo.Focus()
        End If

        Return ValidaCampos

    End Function

    Private Sub txtNoDPVale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoDPVale.LostFocus

        Me.txtNoDPVale.Text = Me.txtNoDPVale.Text.PadLeft(10, "0")

    End Sub

    Private Sub txtNoDPVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoDPVale.KeyDown

        If e.KeyCode = Keys.Enter Then

            Me.cmbTipoArchivo.Focus()

        End If

    End Sub

    Private Sub frmGenerarArchivosDPVF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtRuta.Text = Trim(oConfigCierreFI.Ruta & "\RegeneracionArchivosDPVF")
    End Sub
End Class

