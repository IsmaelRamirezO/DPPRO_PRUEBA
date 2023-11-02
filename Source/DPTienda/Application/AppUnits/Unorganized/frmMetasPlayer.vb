Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Public Class frmMetasPlayer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.InitializePlayers()
        Me.CargarMetasQuincenales()
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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents GridMetasPlayers As Janus.Windows.GridEX.GridEX
    Friend WithEvents MnuCargarXFecha As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarXFecha1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMetasPlayer))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuCargarXFecha1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarXFecha")
        Me.MnuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuGuardar")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuGuardar = New Janus.Windows.UI.CommandBars.UICommand("MnuGuardar")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuCargarXFecha = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarXFecha")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.GridMetasPlayers = New Janus.Windows.GridEX.GridEX()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.GridMetasPlayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuGuardar, Me.MnuSalir, Me.MnuCargarXFecha})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("c104218c-d8bb-4e4e-888f-0e0d12523cd2")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 266)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(512, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuCargarXFecha1, Me.MnuGuardar1, Me.MnuSalir1})
        Me.UiCommandBar1.Key = "tbMetasPlayer"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(141, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuCargarXFecha1
        '
        Me.MnuCargarXFecha1.Key = "MnuCargarXFecha"
        Me.MnuCargarXFecha1.Name = "MnuCargarXFecha1"
        Me.MnuCargarXFecha1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MnuGuardar1
        '
        Me.MnuGuardar1.Icon = CType(resources.GetObject("MnuGuardar1.Icon"), System.Drawing.Icon)
        Me.MnuGuardar1.Key = "MnuGuardar"
        Me.MnuGuardar1.Name = "MnuGuardar1"
        '
        'MnuSalir1
        '
        Me.MnuSalir1.Icon = CType(resources.GetObject("MnuSalir1.Icon"), System.Drawing.Icon)
        Me.MnuSalir1.Key = "MnuSalir"
        Me.MnuSalir1.Name = "MnuSalir1"
        '
        'MnuGuardar
        '
        Me.MnuGuardar.Key = "MnuGuardar"
        Me.MnuGuardar.Name = "MnuGuardar"
        Me.MnuGuardar.Text = "&Guardar"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "&Salir"
        '
        'MnuCargarXFecha
        '
        Me.MnuCargarXFecha.Key = "MnuCargarXFecha"
        Me.MnuCargarXFecha.Name = "MnuCargarXFecha"
        Me.MnuCargarXFecha.Text = "Cargar Meta"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 26)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 240)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(512, 26)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 240)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(312, 28)
        '
        'GridMetasPlayers
        '
        Me.GridMetasPlayers.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridMetasPlayers.DesignTimeLayout = GridEXLayout1
        Me.GridMetasPlayers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMetasPlayers.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridMetasPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridMetasPlayers.GroupByBoxVisible = False
        Me.GridMetasPlayers.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.GridMetasPlayers.Location = New System.Drawing.Point(0, 28)
        Me.GridMetasPlayers.Name = "GridMetasPlayers"
        Me.GridMetasPlayers.Size = New System.Drawing.Size(312, 602)
        Me.GridMetasPlayers.TabIndex = 8
        Me.GridMetasPlayers.TabStop = False
        Me.GridMetasPlayers.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmMetasPlayer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 630)
        Me.Controls.Add(Me.GridMetasPlayers)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMetasPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metas Player"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.GridMetasPlayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private players As DataTable
    Private webService As WSBroker
    Private dtResponse As DataTable
#End Region

#Region "Metodos Players"
    Private Sub InitializePlayers()
        players = New DataTable("Players")
        players.Columns.Add("MetaDiaPlayerID", GetType(Integer))
        players.Columns.Add("CodAlmacen", GetType(String))
        players.Columns.Add("Almacen", GetType(String))
        players.Columns.Add("MetaQuincenal", GetType(Decimal))
        players.Columns.Add("CodPlayer", GetType(String))
        players.Columns.Add("Puesto", GetType(String))
        players.Columns.Add("MetaTienda", GetType(Decimal))
        players.Columns.Add("FechaPeriodo", GetType(DateTime))
        players.Columns.Add("MetaDia", GetType(Decimal))
        players.AcceptChanges()
    End Sub

    Private Sub CargarMetasQuincenales()
        Dim index As Integer = 1, cont As Integer = 0
        Dim row As DataRow, fila As DataRow
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME(), quincena As Integer = 1, quincenaOfDay As Integer = 1
        'fecha = New DateTime(2014, 5, 1)
        Dim fechaInicio As DateTime, fechaFin As DateTime, dia As DateTime
        Dim lstMeses As ArrayList = GetListaMeses()
        Me.webService = New WSBroker("METAS_MS")
        If fecha.Day < 16 Then
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 1)
            fechaFin = New DateTime(fecha.Year, fecha.Month, 15)
            cont = 15
            quincena = 1
        Else
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 16)
            quincena = 16
            If lstMeses.Contains(fecha.Month) Then
                fechaFin = New DateTime(fecha.Year, fecha.Month, 31)
                cont = 16
            Else
                fechaFin = New DateTime(fecha.Year, fecha.Month, 30)
                cont = 15
            End If
        End If
        dtResponse = Me.webService.GetMetasDiasPlayer("T" & oAppContext.ApplicationConfiguration.Almacen, fechaInicio, fechaFin)
        If Not dtResponse Is Nothing Then
            If dtResponse.Rows.Count > 0 Then
                For Each row In dtResponse.Rows
                    quincenaOfDay = quincena
                    For index = 1 To cont Step 1
                        fila = players.NewRow()
                        fila("MetaDiaPlayerID") = 0
                        fila("CodAlmacen") = row("CodAlmacen")
                        fila("Almacen") = row("Almacen")
                        If CStr(row("MetaEmpleado")).Trim() <> "" Then
                            fila("MetaQuincenal") = Convert.ToDecimal(row("MetaEmpleado"))
                        Else
                            fila("MetaQuincenal") = 0
                        End If
                        fila("CodPlayer") = row("CodEmpleado")
                        fila("Puesto") = row("Puesto")
                        fila("MetaTienda") = Convert.ToDecimal(row("MetaTienda"))
                        dia = New DateTime(fecha.Year, fecha.Month, quincenaOfDay, 0, 0, 0, 0)
                        fila("FechaPeriodo") = dia
                        fila("MetaDia") = 0
                        players.Rows.Add(fila)
                        quincenaOfDay += 1
                    Next
                Next
            Else
                MessageBox.Show("No ha cargado las metas quincenales de los empleados", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Me.GridMetasPlayers.DataSource = players
            Dim lstMetasDias As ArrayList = MetaDiaPlayer.GetMetasDiasPlayers(fechaInicio, fechaFin)
            Dim datePeriodo As DateTime
            Dim strPlayer As String = ""
            If lstMetasDias.Count > 0 Then
                For Each row In Me.players.Rows
                    datePeriodo = CDate(row("FechaPeriodo"))
                    strPlayer = CStr(row("CodPlayer"))
                    For Each Meta As MetaDiaPlayer In lstMetasDias
                        If Meta.Fecha.Date.ToString("yyyy-MM-dd") = datePeriodo.Date.ToString("yyyy-MM-dd") And strPlayer.Trim() = Meta.CodPlayer Then
                            row("MetaDiaPlayerID") = Meta.MetaDiaPlayerID
                            row("MetaDia") = Meta.MetaDia
                            row.AcceptChanges()
                        End If
                    Next
                Next
                Me.players.AcceptChanges()
            End If
        End If
    End Sub

    Private Function ValidarMetasPlayers() As Boolean
        Dim valido As Boolean = True, row As DataRow = Nothing, codPlayer As String = "", sumaMeta As Decimal, metaQuincenal As Decimal = 0
        Dim mensaje As String = ""
        For Each row In dtResponse.Rows
            codPlayer = CStr(row("CodEmpleado"))
            metaQuincenal = CStr(row("MetaEmpleado"))
            If Me.players.Select("CodPlayer='" & codPlayer & "'").Length > 0 Then
                sumaMeta = Me.players.Compute("Sum(MetaDia)", "CodPlayer='" & codPlayer & "'")
                If sumaMeta > metaQuincenal Then
                    valido = False
                    mensaje &= "La metas diarias de el Player: " & codPlayer & " son superiores a la meta quincenal" & vbCrLf
                ElseIf sumaMeta < metaQuincenal Then
                    valido = False
                    mensaje &= "La metas diarias de el Player: " & codPlayer & " son menores a la meta quincenal" & vbCrLf
                End If
            End If
        Next
        If valido = False Then
            MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    

    Private Sub Guardar()
        If Me.players.Rows.Count > 0 Then
            If ValidarMetasPlayers() = True Then
                Dim meta As MetaDiaPlayer = Nothing
                Dim player As MetaDiaPlayer = Nothing
                Dim row As DataRow = Me.players.Rows(0)
                Dim fila As DataRow = Nothing, quincena As Integer = 0, mes As String = ""
                Dim metaTienda As Decimal = CDec(row("MetaTienda"))
                Dim fecha As DateTime = CDate(row("FechaPeriodo"))
                'Dim suma As Decimal = Me.players.Compute("SUM(MetaDia)", "")
                'If suma > metaTienda Then
                '    MessageBox.Show("La suma de las metas diarias de todos los players es mayor a la Meta de la Tienda", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'End If
                mes = fecha.ToString("MMMM")
                If fecha.Day < 16 Then
                    quincena = 1
                Else
                    quincena = 2
                End If
                For Each fila In Me.players.Rows
                    meta = New MetaDiaPlayer
                    meta.MetaDiaPlayerID = CInt(fila("MetaDiaPlayerID"))
                    meta.Quincena = quincena
                    meta.CodPlayer = CStr(fila("CodPlayer"))
                    meta.Fecha = CDate(fila("FechaPeriodo"))
                    meta.MetaDia = CDec(fila("MetaDia"))
                    meta.Save()
                    fila("MetaDiaPlayerID") = meta.MetaDiaPlayerID
                    fila.AcceptChanges()
                Next
                MessageBox.Show("Las metas diarias se han guardado exitosamente", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DashBoard.ShowAndUpdateScoreBoard()
            End If

        Else
            MessageBox.Show("No hay ningun Player Cargado", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region

#Region "Eventos Controles"
    Private Sub GridMetasPlayers_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles GridMetasPlayers.UpdatingCell
        If IsNumeric(e.Value) = True Then
            Dim value As Decimal = CDec(e.Value)
            Dim row As DataRow = CType(Me.GridMetasPlayers.GetRow(GridMetasPlayers.Row).DataRow, DataRowView).Row
            Dim fila As DataRow = Nothing, suma As Decimal = 0, total As Decimal = 0, player As String, codPlayer As String = ""
            Dim meta As Decimal = CDec(row("MetaQuincenal"))
            player = CStr(row("CodPlayer"))
            If meta = 0 Then
                MessageBox.Show("No tiene Meta Quincenal el player: " & player, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
            'suma = Me.players.Compute("Sum(MetaDia)", "CodPlayer='" & player & "'")
            'total = suma
            'total += value
            'If total > meta Then
            '    e.Value = meta - suma
            '    MessageBox.Show("La meta quincenal es de " & Format("{0:c}", meta), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        Else
            MessageBox.Show("Solo se aceptan números", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "MnuCargarXFecha"
            Case "MnuGuardar"
                Me.Guardar()
            Case "MnuSalir"
                Me.Dispose()
        End Select
    End Sub
#End Region
    
    
End Class
