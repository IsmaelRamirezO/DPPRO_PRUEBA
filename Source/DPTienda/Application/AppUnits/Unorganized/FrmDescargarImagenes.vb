Imports System.IO


Public Class FrmDescargarImagenes
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        Application.EnableVisualStyles()

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
    Friend WithEvents gbProgreso As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents pbProceso As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents gbOperacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescargarImagenes))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gbOperacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.gbProgreso = New Janus.Windows.EditControls.UIGroupBox()
        Me.pbProceso = New Janus.Windows.EditControls.UIProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gbOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOperacion.SuspendLayout()
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.gbOperacion)
        Me.ExplorerBar1.Controls.Add(Me.gbProgreso)
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(384, 160)
        Me.ExplorerBar1.TabIndex = 9
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'gbOperacion
        '
        Me.gbOperacion.BackColor = System.Drawing.Color.Transparent
        Me.gbOperacion.Controls.Add(Me.lblProceso)
        Me.gbOperacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOperacion.Location = New System.Drawing.Point(40, 16)
        Me.gbOperacion.Name = "gbOperacion"
        Me.gbOperacion.Size = New System.Drawing.Size(312, 48)
        Me.gbOperacion.TabIndex = 1
        Me.gbOperacion.Text = "Imagen"
        Me.gbOperacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'lblProceso
        '
        Me.lblProceso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.Location = New System.Drawing.Point(11, 19)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(291, 17)
        Me.lblProceso.TabIndex = 0
        '
        'gbProgreso
        '
        Me.gbProgreso.BackColor = System.Drawing.Color.Transparent
        Me.gbProgreso.Controls.Add(Me.pbProceso)
        Me.gbProgreso.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProgreso.Location = New System.Drawing.Point(40, 78)
        Me.gbProgreso.Name = "gbProgreso"
        Me.gbProgreso.Size = New System.Drawing.Size(312, 52)
        Me.gbProgreso.TabIndex = 2
        Me.gbProgreso.Text = " Progreso "
        Me.gbProgreso.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'pbProceso
        '
        Me.pbProceso.BackgroundFormatStyle.BackColor = System.Drawing.Color.White
        Me.pbProceso.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Lavender
        Me.pbProceso.BackgroundFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbProceso.Location = New System.Drawing.Point(9, 18)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.ProgressFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackColorAlphaMode = Janus.Windows.UI.AlphaMode.Opaque
        Me.pbProceso.ProgressFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbProceso.ProgressFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.pbProceso.ProgressFormatStyle.BackgroundImageDrawMode = Janus.Windows.UI.BackgroundImageDrawMode.Center
        Me.pbProceso.ProgressFormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        Me.pbProceso.ShowPercentage = True
        Me.pbProceso.Size = New System.Drawing.Size(294, 24)
        Me.pbProceso.TabIndex = 0
        Me.pbProceso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'FrmDescargarImagenes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 22)
        Me.ClientSize = New System.Drawing.Size(376, 154)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(392, 192)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(392, 192)
        Me.Name = "FrmDescargarImagenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descargar Imagenes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gbOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOperacion.ResumeLayout(False)
        CType(Me.gbProgreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProgreso.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function ComparaArreglos(ByVal strRed As String(), ByVal strC As String()) As String()
        Dim fRed As String
        Dim fC As String
        Dim strFdif As String()
        Dim band As Boolean = False
        Dim i As Integer = 0

        For Each fRed In strRed
            For Each fC In strC
                'para sacar la parte del Nombre del Archivo
                If UCase(Mid(fRed, fRed.Length - 17, 18)) = UCase(Mid(fC, fC.Length - 17, 18)) Then
                    band = True
                    Exit For
                End If
            Next
            If band Then
                band = False
            Else
                'se graba en la lista de los que no existe
                If UCase(Mid(fRed, fRed.Length - 3, 4)) = ".JPG" Then
                    ReDim Preserve strFdif(i)  'Agrego otro string al arreglo
                    strFdif(i) = fRed
                    i += 1
                End If
            End If
        Next
        Return strFdif
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        'Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigFotos.Password, oConfigFotos.Usuario, oConfigFotos.Unidad, oConfigFotos.Ruta)
        Dim oMontarURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.PasswordIMG, oConfigCierreFI.UsuarioIMG, oConfigCierreFI.UnidadIMG, oConfigCierreFI.RutaIMG)
        If oMontarURed.Conecta() Then
            'Creo un arreglo con la lista de imagenes del servidor
            Dim ArchivosRed As String() = Directory.GetFileSystemEntries(oConfigCierreFI.RutaIMG)
            Dim ruta As String = Application.StartupPath & "\Fotos\"
            'Validó que exista la carpeta de fotos
            If Not Directory.Exists(ruta) Then
                'si no existe lo creo
                Directory.CreateDirectory(ruta)
            End If

            'Generó un arreglo con la lista de imagenes locales
            Dim ArchivosC As String() = Directory.GetFileSystemEntries(ruta)
            'Mando llamar a funcion para saber cuales son las fotos que no estan localmente
            Dim ArchToCopy As String() = ComparaArreglos(ArchivosRed, ArchivosC)

            Dim Archivo As String
            Dim cont As Integer = 1
            Dim dt As DateTime
            If Not ArchToCopy Is Nothing Then
                pbProceso.Maximum = ArchToCopy.Length
                For Each Archivo In ArchToCopy
                    'validó nuevamente que no exista el archivo
                    If Not File.Exists(UCase(ruta & Mid(Archivo, Archivo.Length - 17, 18))) Then
                        'si no existe se copia
                        File.Copy(Archivo.ToUpper, UCase((ruta & Mid(Archivo, Archivo.Length - 17, 18))))
                    End If
                    lblProceso.Text = Archivo
                    pbProceso.Value += 1
                    Application.DoEvents()
                Next
                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
                MessageBox.Show("Se Realizó la Descarga de Imagenes", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                oMontarURed.Desconecta()
                oMontarURed.Desconecta()
                MessageBox.Show("No hay Imagenes para descargar", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Else
            MessageBox.Show("ERROR al intentar realizar la conexión", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

End Class
