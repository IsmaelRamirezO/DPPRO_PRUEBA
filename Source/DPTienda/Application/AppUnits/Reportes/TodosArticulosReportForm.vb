
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ReportTodosArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class TodosArticulosReportForm
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uibtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebTotalArticulos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents uitnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblLabel5 As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    Friend WithEvents ebFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TodosArticulosReportForm))
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblLabel2 = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.uibtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.ebTotalArticulos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.uitnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ebFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.lblLabel5)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel2)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar2.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.uibtnEliminar)
        Me.ExplorerBar2.Controls.Add(Me.ebTotalArticulos)
        Me.ExplorerBar2.Controls.Add(Me.Label9)
        Me.ExplorerBar2.Controls.Add(Me.uitnAgregar)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Todos los Artículos"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(392, 104)
        Me.ExplorerBar2.TabIndex = 65
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Black
        Me.lblLabel5.Location = New System.Drawing.Point(144, 77)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(48, 16)
        Me.lblLabel5.TabIndex = 91
        Me.lblLabel5.Text = "Salir"
        '
        'lblLabel2
        '
        Me.lblLabel2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel2.ForeColor = System.Drawing.Color.Black
        Me.lblLabel2.Location = New System.Drawing.Point(32, 77)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(84, 16)
        Me.lblLabel2.TabIndex = 90
        Me.lblLabel2.Text = "Imprimir"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Red
        Me.lblLabel1.Location = New System.Drawing.Point(112, 77)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel1.TabIndex = 89
        Me.lblLabel1.Text = "Esc"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Red
        Me.lblLabel4.Location = New System.Drawing.Point(8, 77)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(32, 24)
        Me.lblLabel4.TabIndex = 88
        Me.lblLabel4.Text = "F9"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(181, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "A"
        '
        'uibtnEliminar
        '
        Me.uibtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uibtnEliminar.Image = CType(resources.GetObject("uibtnEliminar.Image"), System.Drawing.Image)
        Me.uibtnEliminar.Location = New System.Drawing.Point(191, 483)
        Me.uibtnEliminar.Name = "uibtnEliminar"
        Me.uibtnEliminar.Size = New System.Drawing.Size(176, 32)
        Me.uibtnEliminar.TabIndex = 4
        Me.uibtnEliminar.Text = "&Eliminar"
        Me.uibtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebTotalArticulos
        '
        Me.ebTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.ebTotalArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTotalArticulos.Location = New System.Drawing.Point(518, 490)
        Me.ebTotalArticulos.Name = "ebTotalArticulos"
        Me.ebTotalArticulos.ReadOnly = True
        Me.ebTotalArticulos.Size = New System.Drawing.Size(88, 22)
        Me.ebTotalArticulos.TabIndex = 13
        Me.ebTotalArticulos.TabStop = False
        Me.ebTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(398, 498)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Total de Articulos:"
        '
        'uitnAgregar
        '
        Me.uitnAgregar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uitnAgregar.Image = CType(resources.GetObject("uitnAgregar.Image"), System.Drawing.Image)
        Me.uitnAgregar.Location = New System.Drawing.Point(9, 483)
        Me.uitnAgregar.Name = "uitnAgregar"
        Me.uitnAgregar.Size = New System.Drawing.Size(176, 32)
        Me.uitnAgregar.TabIndex = 3
        Me.uitnAgregar.Text = "&Agregar"
        Me.uitnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 23)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "De"
        '
        'ebFechaInicio
        '
        '
        '
        '
        Me.ebFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaInicio.Location = New System.Drawing.Point(37, 43)
        Me.ebFechaInicio.Name = "ebFechaInicio"
        Me.ebFechaInicio.Size = New System.Drawing.Size(128, 20)
        Me.ebFechaInicio.TabIndex = 0
        Me.ebFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ebFechaFin
        '
        '
        '
        '
        Me.ebFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFin.Location = New System.Drawing.Point(204, 43)
        Me.ebFechaFin.Name = "ebFechaFin"
        Me.ebFechaFin.Size = New System.Drawing.Size(128, 20)
        Me.ebFechaFin.TabIndex = 1
        Me.ebFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'TodosArticulosReportForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 101)
        Me.Controls.Add(Me.ebFechaFin)
        Me.Controls.Add(Me.ebFechaInicio)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "TodosArticulosReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta General de Movimientos de Todos los Artículos"
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Pasar DataTable como parametro.

#Region "Members Variables"

    'Private oDG As TodosArticulosDataGateway

    Private oAlmacen As Almacen

    Private oCatalogoAlmacenes As CatalogoAlmacenesManager
    
#End Region



#Region "Private Methods"

    Private Sub Sm_Inicializar()

        'oDG = New TodosArticulosDataGateway(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oCatalogoAlmacenes = New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oCatalogoAlmacenes.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        ebFechaInicio.Value = Date.Today
        ebFechaFin.Value = Date.Today

    End Sub


    Private Sub Sm_Finalizar()

        'oDG = Nothing

        oAlmacen = Nothing
        oCatalogoAlmacenes = Nothing

    End Sub


    Private Function Fm_bolTxtValidar() As Boolean

        If (ebFechaInicio.Value > ebFechaFin.Value) Then
            MsgBox("La Fecha de Inicio es Menor.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFechaInicio.Focus()

            Exit Function
        End If

        Return True

    End Function


    Private Sub Sm_ActionPrint()

        If (Fm_bolTxtValidar() = False) Then
            Exit Sub
        End If

        Dim oARReporte As New TodosArticulosReport(oAlmacen.ID & "  " & oAlmacen.Descripcion, _
                                                   ebFechaInicio.Value, ebFechaFin.Value)

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Artículos Con Movimientos"
        oARReporte.Run()

        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()


        'Try
        '    'Imprimir Directo :
        '    oARReporte.Document.Print(False, False)

        'Catch ex As Exception

        '    Throw New ApplicationException("Se produjó un error. El Reporte Cierre de Dia Notas de Crédito no pudo ser impreso.", ex)

        'End Try

        'oARReporte = Nothing

    End Sub

#End Region



#Region "Members Methods [Events]"

    Private Sub TodosArticulosReportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub


    Private Sub TodosArticulosReportForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub


    Private Sub TodosArticulosReportForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If


        If (e.KeyCode = Keys.F9) Then

            Cursor.Current = Cursors.WaitCursor
            Sm_ActionPrint()
            Cursor.Current = Cursors.Default

        End If


        If (e.KeyCode = Keys.Escape) Then

            Me.Close()

        End If

    End Sub

#End Region

End Class
