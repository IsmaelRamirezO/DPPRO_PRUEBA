
Public Class frmCapturaVentaElectronicos
    Inherits System.Windows.Forms.Form

    Public dtElectronicos As DataTable 'Tabla original
    Public bContinuar As Boolean = True

    Private bCancelar As Boolean = False
    Private dtElectronicosCopy As DataTable     'Tabla con capturas
    Private strTipoCaptura As String  'NS = Solo se captura Numero de Serie, NSI = Se captura Numero de Serie e IMEI

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnContinuar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridElectronicos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaVentaElectronicos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.gridElectronicos = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnContinuar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridElectronicos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.lblMsg)
        Me.ExplorerBar1.Controls.Add(Me.gridElectronicos)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.PictureBox1)
        Me.ExplorerBar1.Controls.Add(Me.btnContinuar)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(746, 376)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(195, 16)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(475, 80)
        Me.lblMsg.TabIndex = 50
        Me.lblMsg.Text = "Mensaje"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gridElectronicos
        '
        Me.gridElectronicos.AllowColumnDrag = False
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridElectronicos.DesignTimeLayout = GridEXLayout1
        Me.gridElectronicos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridElectronicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridElectronicos.GroupByBoxVisible = False
        Me.gridElectronicos.Location = New System.Drawing.Point(8, 112)
        Me.gridElectronicos.Name = "gridElectronicos"
        Me.gridElectronicos.Size = New System.Drawing.Size(728, 192)
        Me.gridElectronicos.TabIndex = 0
        Me.gridElectronicos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Icon = CType(resources.GetObject("btnCancelar.Icon"), System.Drawing.Icon)
        Me.btnCancelar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancelar.Location = New System.Drawing.Point(392, 320)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 40)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(76, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'btnContinuar
        '
        Me.btnContinuar.AccessibleDescription = ""
        Me.btnContinuar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.Icon = CType(resources.GetObject("btnContinuar.Icon"), System.Drawing.Icon)
        Me.btnContinuar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnContinuar.Location = New System.Drawing.Point(232, 320)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(120, 40)
        Me.btnContinuar.TabIndex = 1
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmCapturaVentaElectronicos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 376)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaVentaElectronicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Venta de Electrónicos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gridElectronicos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    Private Function GetMensaje() As String

        Dim strMsg As String = ""

        If strTipoCaptura = "NS" Then
            strMsg = "Favor de capturar el Número de Serie de los siguientes Electrónicos:"
        Else
            strMsg = "Favor de capturar el Número de Serie y/o IMEI de los siguientes Electrónicos:"
        End If

        Return strMsg

    End Function

    Private Function ObtenerTipoCaptura() As String

        Dim strTipo As String = String.Empty

        Dim dvElectronicos As DataView
        dvElectronicos = New DataView(dtElectronicosCopy, "NumDenominacion = '21'", "", DataViewRowState.CurrentRows)

        'Si solo hay tablets, solo se capturan Num. de Serie
        If dvElectronicos.Count = dtElectronicos.Rows.Count Then
            strTipo = "NS"
        Else 'En cualquier otro caso (si hay tablets y celulares o solo hay celulares, se captura tambien le IMEI)
            strTipo = "NSI"
        End If

        Return strTipo

    End Function

    Private Function ValidaCaptura() As Boolean

        Dim bResp As Boolean = False
        Dim Mensaje As String = String.Empty
        Dim dvElectronicos As DataView

        'Si el tipo de captura es solo de Numeros de serie....
        If strTipoCaptura = "NS" Then
            dvElectronicos = Nothing
            'Revisamos que ningun numero de serie este vacio
            dvElectronicos = New DataView(dtElectronicosCopy, "NumSerie = ''", "", DataViewRowState.CurrentRows)
            If dvElectronicos.Count = 0 Then
                bResp = True
            Else 'Si hay algun registro vacio, muestra el mensaje
                Mensaje = "Es necesario capturar todos los Números de Serie para continuar."
            End If
        Else 'Si el tipo de captura es de Numeros de serie e IMEI...
            Dim Filtro As String = String.Empty
            Dim Tablets As Integer = 0
            Dim Celulares As Integer = 0

            'Revisamos uno a uno los registros
            For Each oRow As DataRow In dtElectronicosCopy.Rows
                'Dependiendo del tipo de electronico (tablet o Celular), es la consulta que haremos
                If oRow!NumDenominacion = "11" Or oRow!NumDenominacion = "12" Then 'Celulares/celulares telcel
                    If oRow!NumSerie = "" Or oRow!IMEI = "" Then
                        Celulares += 1 'Hacemos la sumatoria de Celulares sin Num. de Serie o IMEI capturados
                    End If
                ElseIf oRow!NumDenominacion = "21" Or oRow!NumDenominacion = "22" Then  'Tablets
                    If oRow!NumSerie = "" Then
                        Tablets += 1 'Hacemos la sumatoria de Tablets sin Num. de Serie capturados
                    End If
                End If
            Next

            'Si ningun electronico esta sin datos, continua con la carga
            If Celulares = 0 AndAlso Tablets = 0 Then
                bResp = True
            Else
                Mensaje = "Es necesario capturar todos los Números de Serie y/o IMEI para Continuar."
            End If

        End If

        '--------------------------------------------------------------------------------------------
        'JNAVA (22.12.2014): Validamos que no vengan repeditos los Numeros de Serie ingresados
        '--------------------------------------------------------------------------------------------
        dvElectronicos = Nothing
        Dim cduplicados As Integer = 0
        For Each oRow As DataRow In dtElectronicosCopy.Rows
            'Revisamos si estan repetidos los numeros de serie
            dvElectronicos = New DataView(dtElectronicosCopy, "NumSerie = '" & oRow!NumSerie & "'", "", DataViewRowState.CurrentRows)
            If dvElectronicos.Count > 1 Then
                cduplicados += 1
            End If
        Next
        If cduplicados > 0 Then
            bResp = False
            Mensaje = "Se encontrarón Números de Serie duplicados. Favor de revisar"
        End If

        'Si no se capturo todo lo necesario, muestra mensaje y no se sale de la pantalla actual
        If bResp = False Then
            MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bContinuar = False
        Else
            bContinuar = True
        End If

        Return bResp

    End Function

    Private Sub SelectedGridEditType()

        'Determinamos que se permite capturar si esta seleccionado un registro de Celular o de Tablet
        Dim gRow As Janus.Windows.GridEX.GridEXRow

        'Obtenemos el registro actual
        gRow = gridElectronicos.GetRow()
        If gRow.Cells("NumDenominacion").Value = "11" Or gRow.Cells("NumDenominacion").Value = "12" Then  'Si es Celular, permitimos que se 
            gRow.Cells("IMEI").Column.EditType = Janus.Windows.GridEX.EditType.TextBox
            gRow.Cells("IMEI").Column.Selectable = True
        ElseIf gRow.Cells("NumDenominacion").Value = "21" Or gRow.Cells("NumDenominacion").Value = "22" Then 'Tablets
            gRow.Cells("IMEI").Column.EditType = Janus.Windows.GridEX.EditType.NoEdit
            gRow.Cells("IMEI").Column.Selectable = False
        End If

        gridElectronicos.Update()

    End Sub

#End Region

#Region "Eventos"

    Private Sub frmCapturaVentaElectronicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strTipoCaptura = String.Empty
        dtElectronicosCopy = dtElectronicos.Copy

        Try

            'Mostramos los datos en el Grid
            gridElectronicos.DataSource = dtElectronicosCopy

            'Obtenemos el tipo de Captura
            strTipoCaptura = ObtenerTipoCaptura()

            'Mostramos el mensaje correcto
            lblMsg.Text = GetMensaje()

            'Focus al grid
            gridElectronicos.Focus()

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click

        'Validamos que se haya capturado todo
        If ValidaCaptura() Then
            'Si capturo todo, se sale de la pantalla y regresa la tabla con los numeros de serie y/o IMEIs capturados
            dtElectronicos = dtElectronicosCopy
            Me.Close()
        End If

    End Sub

    Private Sub frmCapturaVentaElectronicos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Si no cancelo la captura (y no continúo con el proceso), entonces dio clic en cerrar
        If Not bCancelar And Not bContinuar Then
            'Validamos que se haya capturado todo
            If Not ValidaCaptura() Then
                'No permitimos que se salga sin completar los datos
                e.Cancel() = False
            End If
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        If strTipoCaptura = "NS" Then
            If MessageBox.Show("Los Números de serie capturados se perderán al cancelar y no podrá continuar continuar a las Forma de Pago." & vbCrLf & _
                               "¿Seguro que desea continuar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                bCancelar = True
                bContinuar = False
                Me.Close()
            End If
        Else
            If MessageBox.Show("Los Números de serie y/o IMEI capturados se perderán al cancelar y no podrá continuar a las Forma de Pago." & vbCrLf & _
                               "¿Seguro que desea continuar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                bCancelar = True
                bContinuar = False
                Me.Close()
            End If
        End If

    End Sub

    Private Sub gridElectronicos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridElectronicos.Click

        SelectedGridEditType()

    End Sub

    Private Sub gridElectronicos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridElectronicos.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
            Case Keys.Tab
                SelectedGridEditType()
        End Select

    End Sub

#End Region

End Class
