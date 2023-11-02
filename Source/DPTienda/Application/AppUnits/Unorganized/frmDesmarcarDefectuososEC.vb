Public Class frmDesmarcarDefectuososEC
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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesmarcarDefectuososEC))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.grdDetalle = New Janus.Windows.GridEX.GridEX()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.lblLabel1)
        Me.explorerBar1.Controls.Add(Me.btnCancelar)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(442, 272)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(432, 40)
        Me.lblLabel1.TabIndex = 4
        Me.lblLabel1.Text = "Especifica las piezas de las marcadas como baja calidad que van en la operación"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Icon = CType(resources.GetObject("btnCancelar.Icon"), System.Drawing.Icon)
        Me.btnCancelar.Location = New System.Drawing.Point(296, 232)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(136, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowColumnDrag = False
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetalle.DesignTimeLayout = GridEXLayout1
        Me.grdDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.GroupByBoxVisible = False
        Me.grdDetalle.Location = New System.Drawing.Point(8, 48)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(424, 176)
        Me.grdDetalle.TabIndex = 1
        Me.grdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Icon = CType(resources.GetObject("btnAceptar.Icon"), System.Drawing.Icon)
        Me.btnAceptar.Location = New System.Drawing.Point(8, 232)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(136, 32)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmDesmarcarDefectuososEC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grdDetalle)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDesmarcarDefectuososEC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desmarcar artículos de baja calidad"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public dtSource As DataTable
    Public dtDefectuososEC As DataTable
    Public UserDesmarca As String = ""

    Private Sub ActualizaGrid()
        Me.grdDetalle.DataSource = dtDefectuososEC
        Me.grdDetalle.Refresh()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarCantidades() = False Then
            Exit Sub
        ElseIf UserDesmarca.Trim = "" Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.AplicarDescuentosDMA") = False Then
                MessageBox.Show("Es necesario identificarse para continuar", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                UserDesmarca = oAppContext.Security.CurrentUser.Name
                oAppContext.Security.CloseImpersonatedSession()
            End If
        End If

        EliminarCodigosSinCantidad()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub EliminarCodigosSinCantidad()
        Dim oRow As DataRow
        Dim dtTemp As DataTable = dtDefectuososEC.Clone

        For Each oRow In dtDefectuososEC.Rows
            If CInt(oRow!Cantidad) > 0 Then
                dtTemp.ImportRow(oRow)
            End If
        Next
        dtTemp.AcceptChanges()

        dtDefectuososEC = dtTemp.Copy
    End Sub

    Private Function ValidarCantidades() As Boolean

        Dim oRow As DataRow
        Dim CantXTalla As Integer = 0
        Dim Codigos As String = ""
        Dim CodigosMax As String = ""
        Dim CodigosMin As String = ""
        Dim strFilter As String = ""
        Dim bRes As Boolean = True

        For Each oRow In dtDefectuososEC.Rows
            strFilter = oRow!Material & oRow!Talla & ","
            If InStr(Codigos.Trim.ToUpper, strFilter.Trim.ToUpper) <= 0 Then
                Codigos &= strFilter.Trim

                CantXTalla = dtDefectuososEC.Compute("SUM(Cantidad)", "Material = '" & oRow!Material & "' and Talla = '" & oRow!Talla & "'")

                If CantXTalla > oRow!MaximoTotal Then
                    CodigosMax &= oRow!Material & "      " & oRow!Talla & vbCrLf
                End If
                If CantXTalla < oRow!Minimo Then
                    CodigosMin &= oRow!Material & "      " & oRow!Talla & vbCrLf
                End If
            End If

        Next

        Dim strMsg As String = ""

        If CodigosMax.Trim <> "" Then
            bRes = False
            strMsg = "Especificaste mas articulos de los que van en la operación de los siguientes materiales" & vbCrLf & vbCrLf & CodigosMax.Trim
        End If
        If CodigosMin.Trim <> "" Then
            bRes = False
            If strMsg.Trim <> "" Then strMsg &= vbCrLf & vbCrLf
            strMsg &= "Especificaste menos articulos de los que van en la operación de los siguientes materiales" & vbCrLf & vbCrLf & CodigosMin.Trim
        End If

        If strMsg.Trim <> "" Then MessageBox.Show(strMsg.Trim, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return bRes

    End Function

    Private Sub grdDetalle_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdDetalle.CellValueChanged
        If Me.grdDetalle.RootTable.Columns(Me.grdDetalle.Col).Key = "Cantidad" Then
            If CStr(Me.grdDetalle.GetValue("Cantidad")).Trim <> "" Then
                Dim Cant As Integer = Me.grdDetalle.GetValue("Cantidad")

                If Cant > Me.grdDetalle.GetRow.DataRow!Maximo Then
                    Me.grdDetalle.SetValue("Cantidad", Me.grdDetalle.GetRow.DataRow!Maximo)
                End If
                'If Cant < Me.grdDetalle.GetRow.DataRow!Minimo Then
                '    Me.grdDetalle.SetValue("Cantidad", Me.grdDetalle.GetRow.DataRow!Minimo)
                'End If
                If Cant < 0 Then
                    Me.grdDetalle.SetValue("Cantidad", 0)
                End If
            Else
                'Me.grdDetalle.SetValue("Cantidad", Me.grdDetalle.GetRow.DataRow!Minimo)
                Me.grdDetalle.SetValue("Cantidad", 0)
            End If
        End If
    End Sub

    Private Sub frmDesmarcarDefectuososEC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtDefectuososEC = dtSource.Copy
        ActualizaGrid()

    End Sub

End Class
