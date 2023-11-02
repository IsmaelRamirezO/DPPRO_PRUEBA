Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmMetaDiaTienda
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        IntializeMetas()
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
    Friend WithEvents MenuToolbar As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TbMenuTienda As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents GridMetaTienda As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMetaDiaTienda))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.MenuToolbar = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TbMenuTienda = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuGuardar")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuGuardar = New Janus.Windows.UI.CommandBars.UICommand("MnuGuardar")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.GridMetaTienda = New Janus.Windows.GridEX.GridEX()
        CType(Me.MenuToolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbMenuTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.GridMetaTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuToolbar
        '
        Me.MenuToolbar.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuToolbar.BottomRebar = Me.BottomRebar1
        Me.MenuToolbar.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.TbMenuTienda})
        Me.MenuToolbar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuGuardar, Me.MnuSalir})
        Me.MenuToolbar.ContainerControl = Me
        '
        '
        '
        Me.MenuToolbar.EditContextMenu.Key = ""
        Me.MenuToolbar.Id = New System.Guid("c104218c-d8bb-4e4e-888f-0e0d12523cd2")
        Me.MenuToolbar.LeftRebar = Me.LeftRebar1
        Me.MenuToolbar.LockCommandBars = True
        Me.MenuToolbar.RightRebar = Me.RightRebar1
        Me.MenuToolbar.TopRebar = Me.TopRebar1
        Me.MenuToolbar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.MenuToolbar
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 630)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(312, 0)
        '
        'TbMenuTienda
        '
        Me.TbMenuTienda.CommandManager = Me.MenuToolbar
        Me.TbMenuTienda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuGuardar1, Me.MnuSalir1})
        Me.TbMenuTienda.Key = "tbMenuTienda"
        Me.TbMenuTienda.Location = New System.Drawing.Point(0, 0)
        Me.TbMenuTienda.Name = "TbMenuTienda"
        Me.TbMenuTienda.RowIndex = 0
        Me.TbMenuTienda.Size = New System.Drawing.Size(141, 28)
        Me.TbMenuTienda.Text = "tbMenuTienda"
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
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.MenuToolbar
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 26)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 604)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.MenuToolbar
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(312, 26)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 604)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.TbMenuTienda})
        Me.TopRebar1.CommandManager = Me.MenuToolbar
        Me.TopRebar1.Controls.Add(Me.TbMenuTienda)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(312, 28)
        '
        'GridMetaTienda
        '
        Me.GridMetaTienda.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GridMetaTienda.DesignTimeLayout = GridEXLayout1
        Me.GridMetaTienda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMetaTienda.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridMetaTienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridMetaTienda.GroupByBoxVisible = False
        Me.GridMetaTienda.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always
        Me.GridMetaTienda.Location = New System.Drawing.Point(0, 28)
        Me.GridMetaTienda.Name = "GridMetaTienda"
        Me.GridMetaTienda.Size = New System.Drawing.Size(312, 322)
        Me.GridMetaTienda.TabIndex = 9
        Me.GridMetaTienda.TabStop = False
        Me.GridMetaTienda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmMetaDiaTienda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 350)
        Me.Controls.Add(Me.GridMetaTienda)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMetaDiaTienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metas Diarias de Tienda"
        CType(Me.MenuToolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbMenuTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.GridMetaTienda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables de Instancias"
    Private metas As DataTable
    Private webService As WSBroker
    Public result As DialogResult
#End Region

#Region "Metodos"
    '------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2014: Inicializar las metas
    '------------------------------------------------------------------------------------------------------------------

    Private Sub IntializeMetas()
        metas = New DataTable("MetasTiendas")
        metas.Columns.Add("MetaDiaTiendaID", GetType(Integer))
        metas.Columns.Add("Quincena", GetType(Integer))
        metas.Columns.Add("MetaQuincenalTienda", GetType(Decimal))
        metas.Columns.Add("Fecha", GetType(DateTime))
        metas.Columns.Add("MetaDia", GetType(Decimal))
        metas.AcceptChanges()
        result = DialogResult.Cancel
    End Sub

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2014: Cargar las metas diarias de ese periodo
    '-------------------------------------------------------------------------------------------------------------------

    Private Sub CargarMetasQuincenales()
        Dim index As Integer = 1, cont As Integer = 0
        Dim row As DataRow, fila As DataRow, dayQuincena As Integer = 1
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        'fecha = New DateTime(2014, 5, 1)
        Dim fechaInicio As DateTime, fechaFin As DateTime, dia As DateTime
        Dim quincena As Integer = 0
        Dim lstMeses As ArrayList = GetListaMeses()
        Me.webService = New WSBroker("METAS_MS")
        If fecha.Day < 16 Then
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 1)
            fechaFin = New DateTime(fecha.Year, fecha.Month, 15)
            cont = 15
            quincena = 1
            dayQuincena = 1
        Else
            quincena = 2
            dayQuincena = 16
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 16)
            If lstMeses.Contains(fecha.Month) Then
                fechaFin = New DateTime(fecha.Year, fecha.Month, 31)
                cont = 16

            Else
                fechaFin = New DateTime(fecha.Year, fecha.Month, 30)
                cont = 15
            End If
        End If
        Dim dtResponse As DataTable = Me.webService.GetMetasDiasPlayer("T" & oAppContext.ApplicationConfiguration.Almacen, fechaInicio, fechaFin)
        If Not dtResponse Is Nothing Then
            If dtResponse.Rows.Count > 0 Then
                row = dtResponse.Rows(0)
                For index = 1 To cont Step 1
                    fila = metas.NewRow()
                    fila("MetaDiaTiendaID") = 0
                    fila("Quincena") = quincena
                    fila("MetaQuincenalTienda") = CDec(row("MetaTienda"))
                    dia = New DateTime(fecha.Year, fecha.Month, dayQuincena, 0, 0, 0, 0)
                    fila("Fecha") = dia
                    fila("MetaDia") = 0
                    metas.Rows.Add(fila)
                    dayQuincena += 1
                Next
            Else
                MessageBox.Show("No se han cargado las metas de la tienda de este Periodo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Me.GridMetaTienda.DataSource = metas
            Dim lstMetas As ArrayList = MetasDia.GetMetaDias(fechaInicio, fechaFin)
            Dim datePeriodo As DateTime
            For Each row In Me.metas.Rows
                datePeriodo = CDate(row("Fecha"))
                For Each Meta As MetasDia In lstMetas
                    If Meta.Fecha.Date.ToString("yyyy-MM-dd") = datePeriodo.Date.ToString("yyyy-MM-dd") Then
                        row("MetaDiaTiendaID") = Meta.MetaDiaTiendaID
                        row("MetaDia") = Meta.MetaDia
                        row.AcceptChanges()
                    End If
                Next
            Next
            Me.metas.AcceptChanges()
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2014: Guarda las metas diarias
    '-------------------------------------------------------------------------------------------------------------------
    Private Sub Guardar()
        If Me.metas.Rows.Count > 0 Then
            Dim meta As MetasDia = Nothing
            Dim player As MetaDiaPlayer = Nothing
            Dim row As DataRow = Me.metas.Rows(0)
            Dim fila As DataRow = Nothing, quincena As Integer = 0, mes As String = ""
            Dim metaTienda As Decimal = CDec(row("MetaQuincenalTienda"))
            Dim fecha As DateTime = CDate(row("Fecha"))
            Dim suma As Decimal = Me.metas.Compute("SUM(MetaDia)", "")
            If suma <> metaTienda Then
                MessageBox.Show("La suma de las metas diarias no es igual a la quincenal", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            For Each fila In Me.metas.Rows
                meta = New MetasDia
                meta.MetaDiaTiendaID = CInt(fila("MetaDiaTiendaID"))
                meta.Quincena = CInt(fila("Quincena"))
                meta.Fecha = CDate(fila("Fecha"))
                meta.MetaDia = CDec(fila("MetaDia"))
                meta.Save()
                fila("MetaDiaTiendaID") = meta.MetaDiaTiendaID
                fila.AcceptChanges()
            Next
            result = DialogResult.OK
            MessageBox.Show("Las metas diarias se han guardado exitosamente", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DashBoard.ShowAndUpdateScoreBoard()
        Else
            MessageBox.Show("No hay ningun Player Cargado", "DPortenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "Eventos Form"
    Private Sub GridMetaTienda_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles GridMetaTienda.UpdatingCell
        If IsNumeric(e.Value) = True Then
            Dim value As Decimal = CDec(e.Value)
            Dim row As DataRow = CType(Me.GridMetaTienda.GetRow(Me.GridMetaTienda.Row).DataRow, DataRowView).Row
            Dim fila As DataRow = Nothing, suma As Decimal = 0, total As Decimal = 0, player As String
            Dim meta As Decimal = CDec(row("MetaQuincenalTienda"))
            If meta = 0 Then
                MessageBox.Show("No tiene Meta Quincenal la Tienda: ", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
            'suma = Me.metas.Compute("SUM(MetaDia)", "")
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

    Private Sub MenuToolbar_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles MenuToolbar.CommandClick
        Select Case e.Command.Key
            Case "MnuGuardar"
                Guardar()
            Case "MnuSalir"
                Me.Dispose()
        End Select
    End Sub
#End Region

End Class
