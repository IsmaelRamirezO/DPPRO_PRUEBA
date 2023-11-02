Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU
Imports DportenisPro.DPTienda.ApplicationUnits.ArchivosTransAU

Public Class FrmGenArchCierreDia
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
    Friend WithEvents btnGenArch As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ebFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChckBxVPN As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGenArchCierreDia))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ChckBxVPN = New System.Windows.Forms.CheckBox()
        Me.ebFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnGenArch = New Janus.Windows.EditControls.UIButton()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ChckBxVPN)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaFin)
        Me.ExplorerBar1.Controls.Add(Me.btnGenArch)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(315, 216)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ChckBxVPN
        '
        Me.ChckBxVPN.BackColor = System.Drawing.Color.Transparent
        Me.ChckBxVPN.Location = New System.Drawing.Point(24, 144)
        Me.ChckBxVPN.Name = "ChckBxVPN"
        Me.ChckBxVPN.Size = New System.Drawing.Size(112, 24)
        Me.ChckBxVPN.TabIndex = 2
        Me.ChckBxVPN.Text = "SIN VPN"
        Me.ChckBxVPN.UseVisualStyleBackColor = False
        '
        'ebFechaFin
        '
        '
        '
        '
        Me.ebFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFin.Location = New System.Drawing.Point(144, 97)
        Me.ebFechaFin.Name = "ebFechaFin"
        Me.ebFechaFin.Size = New System.Drawing.Size(142, 23)
        Me.ebFechaFin.TabIndex = 1
        Me.ebFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'btnGenArch
        '
        Me.btnGenArch.Icon = CType(resources.GetObject("btnGenArch.Icon"), System.Drawing.Icon)
        Me.btnGenArch.Location = New System.Drawing.Point(200, 144)
        Me.btnGenArch.Name = "btnGenArch"
        Me.btnGenArch.Size = New System.Drawing.Size(104, 32)
        Me.btnGenArch.TabIndex = 3
        Me.btnGenArch.Text = "&Generar"
        Me.btnGenArch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Location = New System.Drawing.Point(144, 56)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(142, 23)
        Me.ebFecha.TabIndex = 0
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Inicial:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 104)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(24, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha Final:"
        '
        'FrmGenArchCierreDia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 178)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(328, 216)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(328, 216)
        Me.Name = "FrmGenArchCierreDia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Archivos de Cierre de Dia"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oCierreDiasMgr As CierreDiaManager

    Private oGenerarPoliza As GenerarPoliza

    Private oGenerarArchTrans As GenerarArch

    Private dsDataSet As DataSet

#End Region

#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oGenerarPoliza = New GenerarPoliza(oAppContext)

        oCierreDiasMgr = New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        oGenerarArchTrans = New GenerarArch(oAppContext)

        ebFecha.Value = Now.Date

    End Sub

    Private Sub Sm_Finalizar()

        oGenerarPoliza = Nothing

        oCierreDiasMgr = Nothing

        oGenerarArchTrans = Nothing

    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        If (oCierreDiasMgr.ValidarCierreDia(ebFecha.Value) = True) Then

            MsgBox("No se ha realizado el cierre de este día.", MsgBoxStyle.Exclamation, "DPTienda.")
            ebFecha.Focus()

            Return False

        End If

        Return True

    End Function

    Private Sub GenerarArchivos(ByVal fecha As Date)

        If Me.ChckBxVPN.Checked = True Then
            'no hay VPN
            oCierreDiasMgr.VentasTienda(fecha, False, False)
        Else
            'si hay VPN
            oCierreDiasMgr.VentasTienda(fecha, False)
        End If

        'Dim udFecha As Date

        'dsDataSet = oGenerarPoliza.GeneraPoliza(ebFecha.Value, dsDataSet)

        'oGenerarArchTrans.GenArchFTOT(ebFecha.Value)
        'oGenerarArchTrans.GenArchMOVD(ebFecha.Value)

        'udFecha = ebFecha.Value.AddDays(1)

        'If Month(ebFecha.Value) <> udFecha.Month Then

        '    oGenerarArchTrans.fGenerarDBF(ebFecha.Value)

        'End If

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub btnGenArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenArch.Click
        'Si no se va usar esto ya Borrar
        'If (Fm_bolTxtValidar() = False) Then

        '    Exit Sub

        'End If


        'oCierreDiasMgr.ArchivoDiaLargo()

        Me.Cursor = Cursors.WaitCursor
        Dim fechaini As Date = ebFecha.Value

        While fechaini <= ebFechaFin.Value
            GenerarArchivos(fechaini)
            fechaini = fechaini.AddDays(1)
        End While



        Me.Cursor = Cursors.Default

        MsgBox("Archivos generados con éxito.", MsgBoxStyle.Information, "DPTienda.")

    End Sub

    Private Sub FrmGenArchCierreDia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub

    Private Sub FrmGenArchCierreDia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub

    Private Sub FrmGenArchCierreDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

#End Region

End Class
