Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Public Class frmPedidosCancelados
    Inherits System.Windows.Forms.Form

    Dim oSAPMgr As ProcesoSAPManager
    Dim oTEMgr As TraspasosEntradaManager
    Dim oTSMgr As TraspasosSalidaManager
    Dim dtPedidosCan, dtCabecera, dtDetalle As DataTable, dsPedidosCancSiHay As DataSet  'dsPedidosCancSiHayDetalle
    Dim UserSessionAplicated, UserNameAplicated As String
    Public Proceso As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oTEMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        oTSMgr = New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        dsPedidosCancSiHay = New DataSet
        ' dsPedidosCancSiHayDetalle = New DataSet
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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents mnuReIngresar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents mnuReIngresar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents grdPedidosCancelados As Janus.Windows.GridEX.GridEX
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosCancelados))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdPedidosCancelados = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.mnuReIngresar1 = New Janus.Windows.UI.CommandBars.UICommand("mnuReIngresar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.mnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("mnuSalir")
        Me.mnuReIngresar = New Janus.Windows.UI.CommandBars.UICommand("mnuReIngresar")
        Me.mnuSalir = New Janus.Windows.UI.CommandBars.UICommand("mnuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdPedidosCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.grdPedidosCancelados)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = " Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 34)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(370, 306)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdPedidosCancelados
        '
        Me.grdPedidosCancelados.AllowColumnDrag = False
        Me.grdPedidosCancelados.AlternatingColors = True
        Me.grdPedidosCancelados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdPedidosCancelados.DesignTimeLayout = GridEXLayout1
        Me.grdPedidosCancelados.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdPedidosCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPedidosCancelados.GroupByBoxVisible = False
        Me.grdPedidosCancelados.Location = New System.Drawing.Point(8, 32)
        Me.grdPedidosCancelados.Name = "grdPedidosCancelados"
        Me.grdPedidosCancelados.Size = New System.Drawing.Size(352, 264)
        Me.grdPedidosCancelados.TabIndex = 35
        Me.grdPedidosCancelados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowMerge = False
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.mnuReIngresar, Me.mnuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("04ceb37f-b7f7-4af3-ac56-0337c8b2903a")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.ShowShortcutInToolTips = True
        Me.UiCommandManager1.SmallImageSize = New System.Drawing.Size(24, 24)
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.mnuReIngresar1, Me.Separator1, Me.mnuSalir1})
        Me.UiCommandBar1.FullRow = True
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(370, 34)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Wrappable = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'mnuReIngresar1
        '
        Me.mnuReIngresar1.Key = "mnuReIngresar"
        Me.mnuReIngresar1.Name = "mnuReIngresar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'mnuSalir1
        '
        Me.mnuSalir1.Key = "mnuSalir"
        Me.mnuSalir1.Name = "mnuSalir1"
        '
        'mnuReIngresar
        '
        Me.mnuReIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuReIngresar.Icon = CType(resources.GetObject("mnuReIngresar.Icon"), System.Drawing.Icon)
        Me.mnuReIngresar.Key = "mnuReIngresar"
        Me.mnuReIngresar.Name = "mnuReIngresar"
        Me.mnuReIngresar.Text = "ReIngresar Inventario"
        Me.mnuReIngresar.ToolTipText = "ReIngresar Inventario"
        '
        'mnuSalir
        '
        Me.mnuSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuSalir.Icon = CType(resources.GetObject("mnuSalir.Icon"), System.Drawing.Icon)
        Me.mnuSalir.Key = "mnuSalir"
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.ToolTipText = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(370, 34)
        '
        'frmPedidosCancelados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 340)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(376, 368)
        Me.MinimumSize = New System.Drawing.Size(376, 368)
        Me.Name = "frmPedidosCancelados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Cancelados Ecommerce"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdPedidosCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "mnuReIngresar"
                If Proceso = "CancelacionEccommerce" Then
                    ReingresarInventario()
                Else
                    ReingresarInventarioPedidoSiHay()
                End If
            Case "mnuSalir"
                Me.Close()
        End Select
    End Sub

#Region "Metodos"

    'Private Sub RevisarPedidosCancelados()

    '    Dim oRow As DataRow
    '    Dim dvDetalle As DataView
    '    Dim oRowV As DataRowView

    '    dtPedidosCan = oSAPMgr.ZPOL_PEDIDOSCANCELADOS(dtDetalle)

    '    If dtPedidosCan.Rows.Count > 0 Then
    '        Dim oNewCol As New DataColumn("TotalPiezas")
    '        oNewCol.DataType = GetType(Integer)
    '        oNewCol.DefaultValue = 0
    '        dtPedidosCan.Columns.Add(oNewCol)
    '        dtPedidosCan.AcceptChanges()

    '        dvDetalle = New DataView(dtDetalle, "", "", DataViewRowState.CurrentRows)
    '        For Each oRow In dtPedidosCan.Rows
    '            dvDetalle.RowFilter = "Folio_Pedido = '" & CStr(oRow!Folio_Pedido).Trim & "'"
    '            If dvDetalle.Count > 0 Then
    '                For Each oRowV In dvDetalle
    '                    oRow!TotalPiezas += oRowV!Cant_Entregado
    '                Next
    '            End If
    '        Next
    '    End If

    '    ActualizaGrid()

    'End Sub

    Private Sub RevisarPedidoCanceladosSiHay()
        '------------------------------------------------------------------------------------------------------------------------
        'MPERAZA 06/06/2013 esta funcion es para reingresar el inventaro de pedidos cancelados de si hay
        '------------------------------------------------------------------------------------------------------------------------
        Dim TotalPiezas As Integer, htStatus As New Hashtable(0), strCentroSAP As String = oSAPMgr.Read_Centros

        dsPedidosCancSiHay.Clear()
        'Va y checa en sap si existen pedidos de si hay cancelados
        htStatus(1) = "PC"
        dtPedidosCan = oSAPMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabecera, dtDetalle, htStatus)

        If dtPedidosCan.Rows.Count > 0 Then
            dsPedidosCancSiHay = CreaEstructura()
            'Primero agrego los datos del encabezado y lo agrego a un dataset
            For Each fila As DataRow In dtCabecera.Rows
                TotalPiezas = 0
                Try
                    TotalPiezas = CInt(dtDetalle.Compute("Sum(Surtido)", "VBELN = '" & fila!VBELN & "'"))
                    AgregarPedidoCancelado(CStr(fila!VBELN), CStr(fila!Traslado), TotalPiezas)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al consultar pedidos cancelados SH en SAP")
                    MessageBox.Show("Ocurrio un error al consultar los pedidos cancelados en SAP" & vbNewLine & ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Next
            grdPedidosCancelados.DataSource = dsPedidosCancSiHay.Tables(0)
        End If
    End Sub

    Private Sub ActualizaGrid()
        grdPedidosCancelados.DataSource = Nothing
        grdPedidosCancelados.DataSource = dtPedidosCan
        grdPedidosCancelados.Refresh()
    End Sub

    Private Function ValidaCampos() As String

        Dim strRes As String = ""
        Dim oRow As Janus.Windows.GridEX.GridEXRow

        '------------------------------------------------------------------------------------------------------------------------
        'Validamos que haya seleccionado al menos un traslado para reingresar
        '------------------------------------------------------------------------------------------------------------------------
        For Each oRow In Me.grdPedidosCancelados.GetRows
            If CBool(oRow.Cells("Reingresar").Value) Then
                If strRes.Trim <> "" Then strRes &= ", "
                strRes &= CStr(oRow.DataRow!Folio_Traslado).Trim
            End If
        Next

        If strRes.Trim = "" Then
            MessageBox.Show("Es necesario seleccionar al menos un traslado para reingresar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf MessageBox.Show("Se reingresará el inventario de los traslados" & vbCrLf & vbCrLf & strRes.Trim & vbCrLf & vbCrLf & _
        "¿Es correcta esta información?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            strRes = ""
        Else
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                strRes = ""
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If

        Return strRes.Trim

    End Function

    Private Sub ReingresarInventario()

        Try
1:          Dim strTraslados() As String
            Dim strResult As String = ""

2:          strResult = ValidaCampos()
3:          If strResult.Trim <> "" Then
4:              strTraslados = strResult.Trim.Split(",")
                Dim strFolio As String = ""
                Dim strFolio352 As String = ""
5:              Dim dvPed As New DataView(dtPedidosCan, "", "", DataViewRowState.CurrentRows)
                Dim oRow As DataRowView
                Dim dtDetalleTE As DataTable
                Dim strFoliosError As String = ""
                '------------------------------------------------------------------------------------------------------------------------
                'Realizamos el movimiento 352 en SAP para darle reversa a los traslados seleccionados y reingresar el inventario
                '------------------------------------------------------------------------------------------------------------------------
6:              For Each strFolio In strTraslados
7:                  If Not strFolio Is Nothing AndAlso strFolio.Trim <> "" Then
                        strFolio352 = ""
8:                      dvPed.RowFilter = "Folio_Traslado = '" & strFolio.Trim & "'"
9:                      oRow = dvPed(0)
                        '--------------------------------------------------------------------------------------------------------
                        'Obtenemos el detalle del traspaso en SAP
                        '--------------------------------------------------------------------------------------------------------
10:                     dtDetalleTE = oSAPMgr.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, strFolio.Trim.PadLeft(10, "0"), _
                                                                    "N", False, True, CStr(oRow!CeDes).Trim)
                        '--------------------------------------------------------------------------------------------------------
                        'Le damos reversa al traspaso en SAP
                        '--------------------------------------------------------------------------------------------------------
11:                     strFolio352 = oSAPMgr.ZMM_BORRAR_TRASLADO_Y_352(strFolio.Trim, True)
12:                     If strFolio352.Trim <> "" Then
                            '--------------------------------------------------------------------------------------------------------
                            'Actualizamos el inventario en la base de datos local
                            '--------------------------------------------------------------------------------------------------------
13:                         ActualizarInventario(CStr(oRow!Folio_Pedido).Trim, strFolio.Trim, strFolio352, dtDetalleTE, "PedidosEccomerce")
                            '--------------------------------------------------------------------------------------------------------
                            'Actualizamos los datos de cancelacion en la tabla de pedidos cancelados en la USI
                            '--------------------------------------------------------------------------------------------------------
14:                         oSAPMgr.ZPOL_USI_CANCELA_PEDIDO_352(CStr(oRow!Folio_Pedido).Trim, CStr(oRow!CeSum).Trim, strFolio352, UserNameAplicated)
                        Else
15:                         If strFoliosError.Trim <> "" Then strFoliosError &= ", "
16:                         strFoliosError &= strFolio
                        End If
                    End If
                Next

17:             If strFoliosError.Trim = "" Then
18:                 MessageBox.Show("Los traslados se han cancelado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
19:                 MessageBox.Show("Ocurrió un error al cancelar los traslados" & vbCrLf & vbCrLf & strFoliosError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
20:             'RevisarPedidosCancelados()
                '----------------------------------------------------------------------------------------------------------------------------
                'Actualizamos el panel que muestra los pedidos pendientes del Ecommerce
                '----------------------------------------------------------------------------------------------------------------------------
21:             RefreshPedidosEC()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al reingresar el inventario de un pedido cancelado. Linea " & Err.Erl)
        End Try

    End Sub

    Private Function FiltrarCabSHByPedido(ByVal FolioPedido As String, ByVal dtCabSH As DataTable) As DataTable
        Dim dtTemp As DataTable
        Dim oRow As DataRowView
        Dim dvCabSH As DataView

        dtTemp = dtCabSH.Clone
        dvCabSH = New DataView(dtCabSH, "VBELN = '" & FolioPedido.Trim & "'", "", DataViewRowState.CurrentRows)
        For Each oRow In dvCabSH
            dtTemp.ImportRow(oRow.Row)
        Next

        Return dtTemp

    End Function

    Private Sub ActualizarInventario(ByVal FolioPedido As String, ByVal FolioTraslado As String, ByVal FolioSAP352 As String, ByRef dtDetalleTE As DataTable, ByVal Proceso As String)
        Try
1:          Dim dvDetalle As New DataView(dtDetalle, "", "", DataViewRowState.CurrentRows)
            Dim oTraspasoE As TraspasoEntrada
2:          If Proceso = "PedidosEccomerce" Then
                dvDetalle.RowFilter = "Folio_Pedido = '" & FolioPedido.Trim & "'"
            ElseIf Proceso = "PedidosSiHay" Then
                dvDetalle.RowFilter = "VBELN = '" & FolioPedido.Trim & "'"
            End If

3:          If dvDetalle.Count > 0 Then
4:              oTraspasoE = New TraspasoEntrada(oTEMgr)
                With oTraspasoE
5:                  Dim dcBulto As New DataColumn
                    With dcBulto
                        .ColumnName = "Bulto"
                        .Caption = "Bulto"
                        .DataType = GetType(Integer)
                        .DefaultValue = 1
                    End With
6:                  dtDetalleTE.Columns.Add(dcBulto)
7:                  .Detalle = New DataSet
8:                  .Detalle.Tables.Add(dtDetalleTE)
9:                  .Folio = FolioTraslado.Trim
10:                 .FolioSAP = FolioTraslado.Trim
11:                 Dim oRow As DataRow = dtDetalleTE.Rows(0)
12:                 .TraspasoCreadoEl = oRow("fecha")
13:                 Dim strCentroOrig(2) As String
14:                 Dim strCentroDest(2) As String
15:                 strCentroOrig = oSAPMgr.Read_CentrosSAP(oRow("Origen"))
16:                 .AlmacenDestinoID = strCentroOrig(0)
17:                 strCentroDest = oSAPMgr.Read_CentrosSAP(oRow("Destino"))
18:                 .AlmacenOrigenID = strCentroDest(0)
20:                 .AutorizadoPorID = oAppContext.Security.CurrentUser.SessionLoginName
21:                 .Referencia = FolioSAP352.Trim
22:                 .TraspasoRecibidoEl = Now.ToShortDateString
                    '---------------------------------------------------------------------------------------------------------------------
                    'Regresamos el inventario en la base de datos local
                    '---------------------------------------------------------------------------------------------------------------------
23:                 oTEMgr.AfectaInventario(oTraspasoE, True)
                    '---------------------------------------------------------------------------------------------------------------------
                    'Cancelamos el traspaso de salida en la base de datos local
                    '---------------------------------------------------------------------------------------------------------------------
24:                 oTSMgr.CancelaTraspasoEC(FolioTraslado, FolioSAP352, UserSessionAplicated)
                End With
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al actualizar el inventario en tablas del PRO. Linea " & Err.Erl)
        End Try
    End Sub

    Private Sub GenerarTraspasoEntrada(ByVal FolioSAP As String, ByVal FolioSAPMM As String)
        Dim dvDetalle As New DataView(dtDetalle, "", "", DataViewRowState.CurrentRows)
        Dim dtDetalleTE As DataTable
        Dim oTraspasoE As TraspasoEntrada

        dvDetalle.RowFilter = "Folio_Traslado = '" & FolioSAP.Trim & "'"

        If dvDetalle.Count > 0 Then

            dtDetalleTE = oSAPMgr.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, FolioSAP.Trim.PadLeft(10, "0"), "N", oConfigCierreFI.RecibirParcialmente)

            oTraspasoE = New TraspasoEntrada(oTEMgr)

            With oTraspasoE

                Dim dcBulto As New DataColumn
                With dcBulto
                    .ColumnName = "Bulto"
                    .Caption = "Bulto"
                    .DataType = GetType(Integer)
                    .DefaultValue = 1
                End With
                dtDetalleTE.Columns.Add(dcBulto)

                .Detalle = New DataSet
                .Detalle.Tables.Add(dtDetalleTE)

                .Status = "TRA"

                .Folio = FolioSAP.Trim
                .FolioSAP = FolioSAP.Trim

                Dim oRow As DataRow = dtDetalle.Rows(0)

                .TraspasoCreadoEl = oRow("fecha")

                Dim strCentroOrig(2) As String
                Dim strCentroDest(2) As String

                strCentroOrig = oSAPMgr.Read_CentrosSAP(oRow("Origen"))

                .AlmacenOrigenID = strCentroOrig(0)

                strCentroDest = oSAPMgr.Read_CentrosSAP(oRow("Destino"))

                .AlmacenDestinoID = strCentroDest(0)

                .AutorizadoPorID = oAppContext.Security.CurrentUser.SessionLoginName

                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Guia - Total Bultos - Paqueteria - Transportista
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (16.02.2016): Adecuaciones por retail
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim strGuia, strTransportista As String
                Dim iBultos As Integer = 0
                oSAPMgr.ReadInfoPaqueteria(FolioSAP, strGuia, strTransportista, iBultos)
                .Guia = strGuia 'oSAPMgr.ReadInfoPaqueteria(FolioSAP, "F01")
                .TotalBultos = iBultos ' oSAPMgr.ReadInfoPaqueteria(FolioSAP, "F02")
                .TransportistaID = strTransportista 'oSAPMgr.ReadInfoPaqueteria(FolioSAP, "F03")
                '------------------------------------------------------------------------------------------------------------------------------------------------------------

                .Referencia = FolioSAPMM.Trim

                .TraspasoRecibidoEl = Now.ToShortDateString

                oTEMgr.AplicarEntrada(oTraspasoE, UserSessionAplicated, UserNameAplicated, True)

                .Status = "GRA"

            End With

        End If

    End Sub

    Private Sub CreaDetalleTE(ByRef dtTemp As DataTable, ByVal dvDetalle As DataView)

        dtTemp = New DataTable("DetalleTraspaso")

        With dtTemp
            .Columns.Add("Codigo", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Talla", GetType(String))
            .Columns.Add("Cantidad", GetType(Integer))
            .Columns.Add("Bulto", GetType(Integer))
        End With

        dtTemp.AcceptChanges()

        Dim oRowV As DataRowView
        Dim oRow As DataRow

        For Each oRowV In dvDetalle
            oRow = dtTemp.NewRow
            With oRow
                !Codigo = oRowV!Material
                !Descripcion = ""
                !Talla = oRowV!Talla
                !Cantidad = oRowV!Cant_Entregado
                !Bulto = 1
            End With
            dtTemp.Rows.Add(oRow)
        Next

        dtTemp.AcceptChanges()

    End Sub

    Private Function CreaEstructura() As DataSet
        Dim dsDataSet As DataSet

        dsDataSet = New DataSet("Procesos")
        Dim dtProcesos As New DataTable("Procesos")
        Dim dcPedido As New DataColumn
        With dcPedido
            .ColumnName = "Folio_Pedido"
            .Caption = "Folio_Pedido"
            .DataType = GetType(System.String)
            .DefaultValue = ""
        End With
        Dim dcTraslado As New DataColumn
        With dcTraslado
            .ColumnName = "Folio_Traslado"
            .Caption = "Folio_Traslado"
            .DataType = GetType(System.String)
            .MaxLength = 22
            .DefaultValue = String.Empty
        End With
        Dim dcPiezas As New DataColumn
        With dcPiezas
            .ColumnName = "TotalPiezas"
            .Caption = "TotalPiezas"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With
        With dtProcesos.Columns
            .Add(dcPedido)
            .Add(dcTraslado)
            .Add(dcPiezas)
        End With
        dsDataSet.Tables.Add(dtProcesos)
        Return dsDataSet
    End Function

    Private Sub AgregarPedidoCancelado(ByVal Folio_Pedido As String, ByVal Folio_Traslado As String, ByVal TotalPiezas As Integer)
        Dim drDato As DataRow
        drDato = dsPedidosCancSiHay.Tables(0).NewRow
        drDato!Folio_Pedido = Folio_Pedido
        drDato!Folio_Traslado = Folio_Traslado
        drDato!TotalPiezas = TotalPiezas
        dsPedidosCancSiHay.Tables(0).Rows.Add(drDato)
    End Sub

    Private Sub ReingresarInventarioPedidoSiHay()
        '------------------------------------------------------------------------------------------------------------------------
        'MPERAZA 06/06/2013 esta funcion es para reingresar el inventaro de pedidos cancelados de si hay
        '------------------------------------------------------------------------------------------------------------------------
        Try
1:          Dim strTraslados() As String
            Dim strResult As String = ""

2:          strResult = ValidaCampos()
3:          If strResult.Trim <> "" Then
4:              strTraslados = strResult.Trim.Split(",")
                Dim strFolio As String = ""
                Dim strFolio352 As String = ""
5:              Dim dvPed As New DataView(dtCabecera, "", "", DataViewRowState.CurrentRows)
                Dim oRow As DataRowView
                Dim dtDetalleTE As DataTable
                Dim strFoliosError As String = ""
                '------------------------------------------------------------------------------------------------------------------------
                'Realizamos el movimiento 352 en SAP para darle reversa a los traslados seleccionados y reingresar el inventario
                '------------------------------------------------------------------------------------------------------------------------
6:              For Each strFolio In strTraslados
7:                  If Not strFolio Is Nothing AndAlso strFolio.Trim <> "" Then
                        strFolio352 = ""
8:                      dvPed.RowFilter = "Traslado = '" & strFolio.Trim & "'"
9:                      oRow = dvPed(0)
                        '--------------------------------------------------------------------------------------------------------
                        'Obtenemos el detalle del traspaso en SAP
                        '--------------------------------------------------------------------------------------------------------
10:                     dtDetalleTE = oSAPMgr.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, strFolio.Trim.PadLeft(10, "0"), _
                                                                    "N", False, True, CStr(oRow!CeDes).Trim)
                        '--------------------------------------------------------------------------------------------------------
                        'Le damos reversa al traspaso en SAP
                        '--------------------------------------------------------------------------------------------------------
11:                     strFolio352 = oSAPMgr.ZMM_BORRAR_TRASLADO_Y_352(strFolio.Trim, True)
12:                     If strFolio352.Trim <> "" Then
                            '--------------------------------------------------------------------------------------------------------
                            'Actualizamos el inventario en la base de datos local
                            '--------------------------------------------------------------------------------------------------------
13:                         ActualizarInventario(CStr(oRow!VBELN).Trim, strFolio.Trim, strFolio352, dtDetalleTE, "PedidosSiHay")
                            '--------------------------------------------------------------------------------------------------------
                            'Actualizamos los datos de cancelacion en la tabla de pedidos cancelados en la USI
                            '--------------------------------------------------------------------------------------------------------
                            Dim htCabecera As New Hashtable(2)
                            Dim dtCabeceraSH As DataTable
                            Dim MarcoError As String
                            htCabecera("Guia") = CStr(oRow!Guia).Trim
                            htCabecera("Responsable") = UserNameAplicated
                            htCabecera("Pedido") = CStr(oRow!VBELN).Trim
                            '------------------------------------------------------------------------------------------------------------------
                            'RGERMAIN 06/06/2013: Filtramos la cabecera de las solicitudes solo por el pedido que queremos asignar guia
                            '------------------------------------------------------------------------------------------------------------------
                            dtCabeceraSH = FiltrarCabSHByPedido(CStr(oRow!VBELN).Trim, dtCabecera)

14:                         oSAPMgr.ZSH_ACTUALIZAR_SOLICITUD("CANCELACION", htCabecera, dtCabeceraSH, Nothing, Nothing, "", MarcoError)
                        Else
15:                         If strFoliosError.Trim <> "" Then strFoliosError &= ", "
16:                         strFoliosError &= strFolio
                        End If
                    End If
                Next

17:             If strFoliosError.Trim = "" Then
18:                 MessageBox.Show("Los traslados se han cancelado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
19:                 MessageBox.Show("Ocurrió un error al cancelar los traslados" & vbCrLf & vbCrLf & strFoliosError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
20:             RevisarPedidoCanceladosSiHay()
                '----------------------------------------------------------------------------------------------------------------------------
                'Actualizamos el panel que muestra los pedidos pendientes del Ecommerce
                '----------------------------------------------------------------------------------------------------------------------------
21:             RefreshPedidosEC()
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 19/06/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay
                '-----------------------------------------------------------------------------------------------------------------------------------------
                RefreshPedidosSiHay()
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al reingresar el inventario de un pedido cancelado. Linea " & Err.Erl)
            MsgBox("Ocurrio un error al reingresar el inventario de un pedido cancelado.", MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

#End Region

#Region "Eventos"

    Private Sub frmPedidosCancelados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Proceso = "CancelacionEccommerce" Then
            'RevisarPedidosCancelados()
        Else
            RevisarPedidoCanceladosSiHay()
        End If
    End Sub

#End Region

End Class
