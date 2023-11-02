Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports DportenisPro.DpTienda.ApplicationUnits.ExporterDBF

Public Class FrmExportarInformacion
    Inherits System.Windows.Forms.Form

#Region "Variables Miembros"

    Private oExportInfo As Auditoria

#End Region

#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oExportInfo = New Auditoria(oAppContext)

    End Sub

    Private Sub Sm_Finalizar()

        oExportInfo = Nothing

    End Sub
#End Region

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblFileName As System.Windows.Forms.Label
    Friend WithEvents Barra As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExportarInformacion))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblFileName = New System.Windows.Forms.Label()
        Me.Barra = New Janus.Windows.EditControls.UIProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(440, 168)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Location = New System.Drawing.Point(328, 96)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(96, 23)
        Me.btnGenerar.TabIndex = 32
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LblFileName)
        Me.GroupBox1.Controls.Add(Me.Barra)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'LblFileName
        '
        Me.LblFileName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFileName.Location = New System.Drawing.Point(64, 16)
        Me.LblFileName.Name = "LblFileName"
        Me.LblFileName.Size = New System.Drawing.Size(328, 16)
        Me.LblFileName.TabIndex = 2
        '
        'Barra
        '
        Me.Barra.Location = New System.Drawing.Point(8, 32)
        Me.Barra.Maximum = 13
        Me.Barra.Name = "Barra"
        Me.Barra.ProgressFormatStyle.BackColor = System.Drawing.Color.Navy
        Me.Barra.ProgressFormatStyle.BackColorGradient = System.Drawing.Color.White
        Me.Barra.ProgressFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.Barra.Size = New System.Drawing.Size(392, 24)
        Me.Barra.TabIndex = 1
        Me.Barra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Archivo:"
        '
        'FrmExportarInformacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 112)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(432, 150)
        Me.MinimumSize = New System.Drawing.Size(432, 150)
        Me.Name = "FrmExportarInformacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Información"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim ArchBAT As Integer

        Barra.Value = 0
        oExportInfo.ArchivoBat()

        'Archivos de Exportación de Información

        LblFileName.Text = "Ajustes de Entrada"
        LblFileName.Refresh()
        oExportInfo.AjustesEntrada()
        Barra.Value = 1

        LblFileName.Text = "Ajustes de Salida"
        LblFileName.Refresh()
        oExportInfo.AjustesSalida()
        Barra.Value = 2

        LblFileName.Text = "Archivos"
        LblFileName.Refresh()
        oExportInfo.Archivos()
        oExportInfo.ExpoInfo()
        Barra.Value = 3

        LblFileName.Text = "Articulos"
        LblFileName.Refresh()
        oExportInfo.Articulos()
        Barra.Value = 4

        LblFileName.Text = "Movimientos"
        LblFileName.Refresh()
        oExportInfo.Movimientos()
        Barra.Value = 5

        LblFileName.Text = "Existencias"
        LblFileName.Refresh()
        oExportInfo.Existencias()
        Barra.Value = 6

        LblFileName.Text = "Familias"
        LblFileName.Refresh()
        oExportInfo.Familias()
        Barra.Value = 7

        LblFileName.Text = "Lineas"
        LblFileName.Refresh()
        oExportInfo.Lineas()
        Barra.Value = 8

        LblFileName.Text = "Marcas"
        LblFileName.Refresh()
        oExportInfo.Marcas()
        Barra.Value = 9

        LblFileName.Text = "Traspasos"
        LblFileName.Refresh()
        oExportInfo.TCanOD()
        oExportInfo.TraspasosEntrada()
        oExportInfo.TraspasosSalida()
        oExportInfo.TraspasosPendientes()
        oExportInfo.TSGC()
        Barra.Value = 10

        LblFileName.Text = "Tipos de Ajustes"
        LblFileName.Refresh()
        oExportInfo.TipoAjustes()
        Barra.Value = 11

        LblFileName.Text = "UPC"
        LblFileName.Refresh()
        oExportInfo.UPC()
        Barra.Value = 12

        LblFileName.Text = "Usuarios"
        LblFileName.Refresh()
        oExportInfo.Usuarios()
        Barra.Value = 13

        ArchBAT = Shell("C:\DPT\AUD\ExportInfo.bat", AppWinStyle.Hide)
       

        LblFileName.Text = ""
        MsgBox("Archivo generado con exitó en la ruta C:\DPT\AUD\ con el nombre de AudBas.arj", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub FrmExportarInformacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sm_Inicializar()
    End Sub

    Private Sub FrmExportarInformacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Sm_Finalizar()
    End Sub

#End Region

End Class
