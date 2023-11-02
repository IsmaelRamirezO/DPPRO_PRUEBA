
Imports DportenisPro.DpTienda.ApplicationUnits.CambiarFolioFacturaAU

Public Class FrmCambiarFolio
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebFolioNuevo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioActual As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambiarFolio))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ebFolioActual = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolioNuevo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btGuardar)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioActual)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioNuevo)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Actualizar Folio"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(272, 152)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btGuardar
        '
        Me.btGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuardar.Image = CType(resources.GetObject("btGuardar.Image"), System.Drawing.Image)
        Me.btGuardar.Location = New System.Drawing.Point(86, 106)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(107, 32)
        Me.btGuardar.TabIndex = 1
        Me.btGuardar.Text = "&Guardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFolioActual
        '
        Me.ebFolioActual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioActual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioActual.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolioActual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioActual.Location = New System.Drawing.Point(104, 40)
        Me.ebFolioActual.Name = "ebFolioActual"
        Me.ebFolioActual.ReadOnly = True
        Me.ebFolioActual.Size = New System.Drawing.Size(112, 22)
        Me.ebFolioActual.TabIndex = 48
        Me.ebFolioActual.TabStop = False
        Me.ebFolioActual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioActual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioNuevo
        '
        Me.ebFolioNuevo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioNuevo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioNuevo.BackColor = System.Drawing.Color.White
        Me.ebFolioNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioNuevo.Location = New System.Drawing.Point(104, 72)
        Me.ebFolioNuevo.Name = "ebFolioNuevo"
        Me.ebFolioNuevo.Size = New System.Drawing.Size(112, 22)
        Me.ebFolioNuevo.TabIndex = 0
        Me.ebFolioNuevo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioNuevo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folio Nuevo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio Actual:"
        '
        'FrmCambiarFolio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(272, 149)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambiarFolio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Folio de Factura"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Members Variables"

    Private oDG As New CambiarFolioFacturaDataGateway(oAppContext)

#End Region


#Region "APIs"

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As System.IntPtr
    End Function

#End Region


#Region "Members Methods"

    Private Sub Sm_Inicializar()

        ebFolioActual.Text = oDG.MostrarFolioActual

    End Sub


    Private Sub Sm_Finalizar()

        oDG = Nothing

    End Sub


    Private Function Fm_bolValidarFolio() As Boolean

        'Validar que el Módulo Facturación no se encuentre Abierto.
        Dim nHwnI As System.IntPtr

        nHwnI = FindWindow(vbNullString, "Facturación")

        If Val(nHwnI.ToString) <> 0 Then

            MsgBox("Debe Cerrar el Módulo de Facturación.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If


        If (IsNumeric(ebFolioNuevo.Text.Trim) = False) Then

            MsgBox("El Folio no es Valido.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioNuevo.Text = String.Empty
            ebFolioNuevo.Focus()

            Exit Function

        End If


        If (oDG.ValidarFolioInicial(ebFolioNuevo.Text.Trim) = True) Then

            'El Folio es Menor al Primer Folio capturado del dia.
            MsgBox("El Folio es Menor a la Primera Venta.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioNuevo.SelectionStart = 0
            ebFolioNuevo.SelectionLength = ebFolioNuevo.Text.Length
            ebFolioNuevo.Focus()

            Exit Function

        End If


        If (oDG.ValidarFolio(ebFolioNuevo.Text.Trim) = True) Then

            'El Folio se encuentra Usado.
            MsgBox("El Folio ya se encuentra usado.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioNuevo.SelectionStart = 0
            ebFolioNuevo.SelectionLength = ebFolioNuevo.Text.Length
            ebFolioNuevo.Focus()

            Exit Function

        End If


        If (ebFolioNuevo.Text > (CType(ebFolioActual.Text, Integer) + 50)) Then

            'El Folio No debe ser Mayor a 50 Facturas.
            MsgBox("El Folio no debe ser Mayor a 50 Facturas.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioNuevo.SelectionStart = 0
            ebFolioNuevo.SelectionLength = ebFolioNuevo.Text.Length
            ebFolioNuevo.Focus()

            Exit Function

        End If


        If (ebFolioNuevo.Text < (CType(ebFolioActual.Text, Integer) - 50)) Then

            'El Folio No debe ser Menor a 50 Facturas.
            MsgBox("El Folio no debe ser Menor a 50 Facturas.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolioNuevo.SelectionStart = 0
            ebFolioNuevo.SelectionLength = ebFolioNuevo.Text.Length
            ebFolioNuevo.Focus()

            Exit Function

        End If


        Return True

    End Function


    Private Sub Sm_ActualizarFolio()

        If (Fm_bolValidarFolio() = False) Then
            Exit Sub
        End If

        oDG.Update(ebFolioNuevo.Text.Trim)

        MsgBox("El Folio ha sido Actualizado.", MsgBoxStyle.Information, "DPTienda.")

        ebFolioActual.Text = oDG.MostrarFolioActual
        ebFolioNuevo.Text = String.Empty
        ebFolioNuevo.Focus()

    End Sub

#End Region


#Region "Private Methods [Events]"

    Private Sub FrmCambiarFolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub


    Private Sub FrmCambiarFolio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub


    Private Sub FrmCambiarFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.Close()

        End Select

    End Sub


    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click

        Sm_ActualizarFolio()

    End Sub

#End Region

End Class
