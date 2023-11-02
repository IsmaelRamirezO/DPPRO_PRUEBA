Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class FrmInvTraspasoDEntradaPorBultos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
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
    Friend WithEvents ebNoBulto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblNoBulto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdBultos As Janus.Windows.GridEX.GridEX
    Friend WithEvents nebPiezasBulto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAplicarTraspaso As Janus.Windows.EditControls.UIButton
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvTraspasoDEntradaPorBultos))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAplicarTraspaso = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.grdBultos = New Janus.Windows.GridEX.GridEX()
        Me.nebPiezasBulto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebNoBulto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblNoBulto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdBultos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.btnSalir)
        Me.explorerBar1.Controls.Add(Me.btnAplicarTraspaso)
        Me.explorerBar1.Controls.Add(Me.btnAgregar)
        Me.explorerBar1.Controls.Add(Me.grdBultos)
        Me.explorerBar1.Controls.Add(Me.nebPiezasBulto)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.ebNoBulto)
        Me.explorerBar1.Controls.Add(Me.ebFolio)
        Me.explorerBar1.Controls.Add(Me.lblNoBulto)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(370, 344)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(216, 296)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(136, 32)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Cancelar"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAplicarTraspaso
        '
        Me.btnAplicarTraspaso.Image = CType(resources.GetObject("btnAplicarTraspaso.Image"), System.Drawing.Image)
        Me.btnAplicarTraspaso.Location = New System.Drawing.Point(16, 296)
        Me.btnAplicarTraspaso.Name = "btnAplicarTraspaso"
        Me.btnAplicarTraspaso.Size = New System.Drawing.Size(136, 32)
        Me.btnAplicarTraspaso.TabIndex = 4
        Me.btnAplicarTraspaso.Text = "Aplicar Bultos"
        Me.btnAplicarTraspaso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(216, 48)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(136, 32)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Ag&regar"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdBultos
        '
        Me.grdBultos.AllowCardSizing = False
        Me.grdBultos.AllowColumnDrag = False
        Me.grdBultos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdBultos.DesignTimeLayout = GridEXLayout1
        Me.grdBultos.GroupByBoxVisible = False
        Me.grdBultos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdBultos.Location = New System.Drawing.Point(16, 96)
        Me.grdBultos.Name = "grdBultos"
        Me.grdBultos.Size = New System.Drawing.Size(336, 192)
        Me.grdBultos.TabIndex = 118
        Me.grdBultos.TabStop = False
        Me.grdBultos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nebPiezasBulto
        '
        Me.nebPiezasBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebPiezasBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebPiezasBulto.Location = New System.Drawing.Point(64, 48)
        Me.nebPiezasBulto.Name = "nebPiezasBulto"
        Me.nebPiezasBulto.Size = New System.Drawing.Size(112, 20)
        Me.nebPiezasBulto.TabIndex = 2
        Me.nebPiezasBulto.Text = "0"
        Me.nebPiezasBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebPiezasBulto.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebPiezasBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Piezas:"
        '
        'ebNoBulto
        '
        Me.ebNoBulto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoBulto.Location = New System.Drawing.Point(240, 16)
        Me.ebNoBulto.Name = "ebNoBulto"
        Me.ebNoBulto.Size = New System.Drawing.Size(112, 20)
        Me.ebNoBulto.TabIndex = 1
        Me.ebNoBulto.Text = "0"
        Me.ebNoBulto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebNoBulto.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebNoBulto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.FormatString = "0000000000"
        Me.ebFolio.Location = New System.Drawing.Point(64, 16)
        Me.ebFolio.MaxLength = 10
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.ReadOnly = True
        Me.ebFolio.Size = New System.Drawing.Size(112, 20)
        Me.ebFolio.TabIndex = 0
        Me.ebFolio.Text = "0000000000"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoBulto
        '
        Me.lblNoBulto.BackColor = System.Drawing.Color.Transparent
        Me.lblNoBulto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoBulto.Location = New System.Drawing.Point(192, 16)
        Me.lblNoBulto.Name = "lblNoBulto"
        Me.lblNoBulto.Size = New System.Drawing.Size(66, 17)
        Me.lblNoBulto.TabIndex = 113
        Me.lblNoBulto.Text = "Bulto:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 23)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Folio:"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'FrmInvTraspasoDEntradaPorBultos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 344)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmInvTraspasoDEntradaPorBultos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso de Entrada por Bultos"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdBultos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtDetalleBultos As DataTable
    Dim oSAPMgr As ProcesoSAPManager
    Dim dtTraspaso As DataTable
    Dim oTraspasoEntradaMgr As TraspasosEntradaManager
    Dim oArticulosMgr As CatalogoArticuloManager
    Dim UserSessionAplicated As String = ""
    Dim UserNameAplicated As String = ""
    Dim strFolioTraspaso As String = ""
    Dim oFrmMessage As frmMessages

    Private Sub Inicializar()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)

        oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oFrmMessage = New frmMessages

        CrearEstructuraDetalle()

    End Sub

    Private Sub CrearEstructuraDetalle()

        dtDetalleBultos = New DataTable("Bultos")

        Dim oNewCol As DataColumn

        oNewCol = New DataColumn("FolioTraspaso")
        With oNewCol
            .Caption = "FolioTraslado"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtDetalleBultos.Columns.Add(oNewCol)

        oNewCol = New DataColumn("Bulto")
        With oNewCol
            .Caption = "Bulto"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With
        dtDetalleBultos.Columns.Add(oNewCol)

        oNewCol = New DataColumn("CentroOrigen")
        With oNewCol
            .Caption = "Centro Origen"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtDetalleBultos.Columns.Add(oNewCol)

        oNewCol = New DataColumn("CentroDestino")
        With oNewCol
            .Caption = "Centro Destino"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtDetalleBultos.Columns.Add(oNewCol)

        oNewCol = New DataColumn("Piezas")
        With oNewCol
            .Caption = "Piezas"
            .DataType = GetType(Integer)
            .DefaultValue = 0
        End With
        dtDetalleBultos.Columns.Add(oNewCol)

        dtDetalleBultos.AcceptChanges()

    End Sub

    Private Function ValidarBultoAgregado(ByVal dtTemp As DataTable, ByVal Folio As String, ByVal Bulto As Integer) As Boolean

        Dim oRow As DataRow
        Dim bRes As Boolean = False

        For Each oRow In dtTemp.Rows
            If CStr(oRow!FolioTraspaso).Trim.ToUpper = Folio.Trim.ToUpper AndAlso Bulto = CInt(oRow!Bulto) Then
                bRes = True
                Exit For
            End If
        Next

        Return bRes

    End Function

    Private Sub AgregarBulto()

        Dim strCentroOrigen As String = ""
        Dim strCentroDestino As String = ""

        If Me.ebFolio.Text.Trim = "" OrElse Me.ebFolio.Value <= 0 Then
            MessageBox.Show("Es necesario indicar el folio del traslado a ingresar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebFolio.Focus()
            Exit Sub
        ElseIf Me.nebPiezasBulto.Value <= 0 Then
            MessageBox.Show("Es necesario indicar el número de piezas del bulto a ingresar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebPiezasBulto.Focus()
            Exit Sub
        ElseIf ValidarBultoAgregado(dtDetalleBultos, Me.ebFolio.Text, Me.ebNoBulto.Value) Then
            MessageBox.Show("El bulto y traspaso indicados ya estan agregados a la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNoBulto.Focus()
            Exit Sub
        End If

        oFrmMessage = New frmMessages
        With oFrmMessage
            .lblMessage.Text = "Validando Traspaso" & vbCrLf & "Favor de Esperar..."
            .Text = "Validando Traspaso ..."
            .Show()
        End With
        Application.DoEvents()

        Dim dtDetalleBulto As DataTable

        If ValidaTraspaso(Me.ebFolio.Text, True, strCentroOrigen, strCentroDestino, dtDetalleBulto) Then
            SumarAlDetalle(dtDetalleBulto)
            AgregrarBultoAlGrid(strCentroOrigen, strCentroDestino)
        End If

        oFrmMessage.Close()
        Application.DoEvents()

    End Sub

    Private Sub BorrarDelDetalle(ByVal strFolioTraspaso As String, ByVal Bulto As Integer)

        If Not dtTraspaso Is Nothing AndAlso dtTraspaso.Rows.Count > 0 Then

            Dim dvBorrar As New DataView(dtTraspaso, "Referencia = '" & strFolioTraspaso.Trim & "' And Bulto = " & Bulto, "", DataViewRowState.CurrentRows)
            Dim oRowV As DataRowView

            For Each oRowV In dvBorrar
                dtTraspaso.Rows.Remove(oRowV.Row)
            Next
            dtTraspaso.AcceptChanges()
        End If

    End Sub

    Private Sub AgregrarBultoAlGrid(ByVal CentroOrigen As String, ByVal CentroDestino As String)

        Dim oNewRow As DataRow = dtDetalleBultos.NewRow

        With oNewRow
            !FolioTraspaso = Me.ebFolio.Text.Trim.PadLeft(10, "0")
            !Bulto = Me.ebNoBulto.Value
            !CentroOrigen = CentroOrigen.Trim
            !CentroDestino = CentroDestino.Trim
            !Piezas = Me.nebPiezasBulto.Value
        End With
        dtDetalleBultos.Rows.Add(oNewRow)

        dtDetalleBultos.AcceptChanges()

        ActualizaGrid()

        Sm_Nuevo()

    End Sub

    Private Sub EliminarBultoDelGrid()

        If dtDetalleBultos.Rows.Count > 0 Then
            Dim oRowV As DataRowView = CType(Me.grdBultos.GetRow().DataRow, DataRowView)
            BorrarDelDetalle(oRowV!FolioTraspaso, oRowV!Bulto)
            Me.dtDetalleBultos.Rows.Remove(oRowV.Row)
            Me.dtDetalleBultos.AcceptChanges()
            ActualizaGrid()
        End If

    End Sub

    Private Sub ActualizaGrid()

        Me.grdBultos.DataSource = dtDetalleBultos
        Me.grdBultos.Refresh()

    End Sub

    Private Sub Sm_Nuevo()

        Me.ebFolio.Value = 0
        Me.ebNoBulto.Value = 0
        Me.nebPiezasBulto.Value = 0

        Me.ebFolio.Focus()

    End Sub

    Private Sub CreaEstructuraTablaDescarga(ByRef dtTemp As DataTable)

        dtTemp = New DataTable("Materiales")
        dtTemp.Columns.Add("Material", Type.GetType("System.String"))
        dtTemp.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtTemp.AcceptChanges()

    End Sub

    Private Sub AgregarCodigo(ByVal strCodigo As String, ByRef dtTemp As DataTable)

        Dim oRow As DataRow = dtTemp.NewRow
        oRow!Material = strCodigo.Trim.ToUpper
        oRow!Descripcion = ""
        dtTemp.Rows.Add(oRow)
        dtTemp.AcceptChanges()

    End Sub

    Private Function ValidaCodigosEnCatalogo(ByVal dtTemp As DataTable) As Boolean
        Dim strMateriales As String = ""
        Dim odrArticulo As DataRow
        Dim oArticulo As Articulo
        Dim bRes As Boolean = True
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim dtCod As DataTable

        frmDescargas.Timer1.Enabled = False

        CreaEstructuraTablaDescarga(dtCod)

        For Each odrArticulo In dtTemp.Rows
            oArticulo = Nothing
            oArticulo = oArticulosMgr.Load(CStr(odrArticulo("Codigo")))
            If oArticulo Is Nothing Then

                frmDescargas.bPorCodigo = True
                frmDescargas.bMostrarMensaje = False

                dtCod.Clear()
                AgregarCodigo(CStr(odrArticulo("Codigo")).Trim, dtCod)
                frmDescargas.dtMateriales = dtCod

                frmDescargas.ShowDev("Articulos")

                oArticulo = Nothing
                oArticulo = oArticulosMgr.Load(CStr(odrArticulo("Codigo")))
                If Not oArticulo Is Nothing Then
                    frmDescargas.ShowDev("Descuentos")
                    frmDescargas.ShowDev("Inventarios")
                Else
                    strMateriales = CStr(odrArticulo("Codigo")) & vbCrLf
                End If
            End If
        Next

        If strMateriales.Trim <> "" Then
            strMateriales = "Los siguientes artículos no se encuentran en su catalogo favor de hacer la descarga:" & _
                             vbCrLf & strMateriales
            MessageBox.Show(strMateriales, "Valida Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Function ValidaCamposTraspaso(ByVal dtTemp As DataTable, ByVal oTraspasoE As TraspasoEntrada) As Boolean

        Dim bRes As Boolean = True

        If (oTraspasoE Is Nothing) Then
            MsgBox("No ha sido seleccionado un Traspaso", MsgBoxStyle.Exclamation, "DPTienda")
            bRes = False
        ElseIf (oTraspasoE.Status <> "TRA") Then
            MsgBox("El Traspaso No puede ser Aplicado debido a su Status.", MsgBoxStyle.Exclamation, "DPTienda")
            bRes = False
        End If

        Return bRes

    End Function

    Private Function ValidarBultosParaAplicar(ByVal dtTemp As DataTable) As Boolean

        Dim bRes As Boolean = True

        If ValidaCodigosEnCatalogo(dtTemp) = False Then
            bRes = False
        ElseIf oConfigCierreFI.RecibirParcialmente Then
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                bRes = False
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If

        Return bRes

    End Function

    Private Sub Sm_AplicarTraspaso(ByVal strFolioTraspaso As String)

        Dim strFolioMB01 As String = ""

        Dim dvDetalleTemp As New DataView(dtTraspaso, "Referencia = '" & strFolioTraspaso.Trim & "'", "", DataViewRowState.CurrentRows)
        Dim dtDetTemp As DataTable = dvDetalleTemp.Table.Clone
        Dim oTraspasoEntradaTemp As TraspasoEntrada

        For Each oRow As DataRowView In dvDetalleTemp
            dtDetTemp.ImportRow(oRow.Row)
        Next
        dtDetTemp.AcceptChanges()

        oTraspasoEntradaTemp = CrearTraspasoEntrada(strFolioTraspaso, dtDetTemp)

        If ValidaCamposTraspaso(dtDetTemp, oTraspasoEntradaTemp) = False Then
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos traspaso en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Cursor.Current = Cursors.WaitCursor

        If oConfigCierreFI.RecibirParcialmente Then
            strFolioMB01 = oSAPMgr.Write_TrasladoEntradaParcialSAPMM02(oTraspasoEntradaTemp.Folio, oTraspasoEntradaTemp.Detalle.Tables(0))
        Else
            strFolioMB01 = oSAPMgr.Write_TrasladoEntradaSAPMM02(oTraspasoEntradaTemp.Folio)
        End If
        If strFolioMB01.Trim = "" Then
            'MsgBox("El Traspaso de Entrada No se Aplico en SAP", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If
        oTraspasoEntradaTemp.Referencia = strFolioMB01.Trim
        Cursor.Current = Cursors.Default
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Aplico el Traspaso de entrada en las bases locales
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oTraspasoEntradaTemp.TraspasoRecibidoEl = Now.ToShortDateString
        If (oTraspasoEntradaMgr.AplicarEntrada(oTraspasoEntradaTemp, UserSessionAplicated, UserNameAplicated) = True) Then

            With oTraspasoEntradaTemp
                .Status = "GRA"
            End With
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Guardamos el traspaso en el Servidor si esta activada la config
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                Try
                    oTraspasoEntradaMgr.AplicarTraspasoEntradaInServer(oTraspasoEntradaTemp, UserSessionAplicated, UserNameAplicated)
                Catch ex As Exception
                    EscribeLog(ex.ToString, "Error al guardar traspaso de entrada en el servidor.")
                End Try
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------------------------------

            'MsgBox("El Traspaso ha sido Aplicado satisfactoriamente.", MsgBoxStyle.Information, "DPTienda.")

        Else

            Cursor.Current = Cursors.Default
            MsgBox("El Traspaso no pudo ser Aplicado.", MsgBoxStyle.Exclamation, "DPTienda.")

        End If

    End Sub

    Private Function ValidaTraspaso(ByVal strFolioTraspaso As String, ByVal SoloValidar As Boolean, ByRef CentroOrigen As String, ByRef CentroDestino As String, ByRef dtTemp As DataTable) As Boolean

        Dim bRes As Boolean = True

        Try

            dtTemp = oSAPMgr.Read_TraspasosEspera(Today.ToShortDateString, Today.ToShortDateString, strFolioTraspaso.Trim.PadLeft(10, "0"), "N", oConfigCierreFI.RecibirParcialmente)

            If dtTemp.Rows.Count <= 0 Then
                MessageBox.Show("El traspaso no existe o no está pendiente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sm_Nuevo()
                bRes = False
                Exit Try
            ElseIf oConfigCierreFI.RecibirParcialmente Then
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Validamos si el centro origen es el CDist que tenga que indicar el bulto que estan recibiendo
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim strCentroOrigen As String = dtTemp.Rows(0).Item("Origen")

                Select Case strCentroOrigen.Trim.ToUpper
                    Case "Z000", "Z001"
                        If Me.ebNoBulto.Value <= 0 Then
                            Me.ebNoBulto.Value = 0
                            MessageBox.Show("Es necesario indicar el número de bulto del traslado a ingresar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            bRes = False
                            Me.ebNoBulto.Focus()
                            Exit Try
                        End If
                End Select

                CentroOrigen = strCentroOrigen.Trim
                CentroDestino = CStr(dtTemp.Rows(0).Item("Destino")).Trim
            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que no se haya aplicado ese bulto anteriormente si esta activada la configuracion para recibir por bulto
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim Bulto As Integer = 0

            If oConfigCierreFI.RecibirParcialmente Then
                'If Me.ebNoBulto.Text.Trim <> "" Then Bulto = CInt(Me.ebNoBulto.Text.Trim)
                Bulto = Me.ebNoBulto.Value

                If Bulto > 0 Then
                    If oTraspasoEntradaMgr.ValidarBultoAplicado(strFolioTraspaso.Trim.PadLeft(10, "0"), Bulto) OrElse _
                    oTraspasoEntradaMgr.ValidarBultoAplicadoServer(strFolioTraspaso.Trim.PadLeft(10, "0"), Bulto) Then
                        MessageBox.Show("El bulto " & Bulto & " del traspaso indicado ya fue aplicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Sm_Nuevo()
                        bRes = False
                        Exit Try
                    End If
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Agregamos la columna Bulto al detalle para separar por bultos
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim dcBulto As New DataColumn
            With dcBulto
                .ColumnName = "Bulto"
                .Caption = "Bulto"
                .DataType = GetType(Integer)
                .DefaultValue = 1
            End With
            dtTemp.Columns.Add(dcBulto)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Separamos por bulto el detalle si esta activada la config
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.RecibirParcialmente Then
                Dim dtTraspasoBultos As DataTable
                Dim Tratado As Boolean = True

                If Bulto > 0 Then
                    dtTraspasoBultos = oTraspasoEntradaMgr.GetDetalleByBultos(strFolioTraspaso.Trim.PadLeft(10, "0"), Bulto, Tratado)

                    If dtTraspasoBultos.Rows.Count > 0 Then
                        dtTemp = FiltrarTraspasoPorBulto(dtTemp, dtTraspasoBultos)
                    ElseIf Tratado AndAlso InStr("Z001,Z000", CentroOrigen.Trim.ToUpper) > 0 Then
                        MessageBox.Show("El bulto indicado no pertenece al traspaso especificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                        Me.ebNoBulto.Focus()
                        Exit Try
                    End If
                End If
            End If

            If dtTemp.Rows.Count > 0 AndAlso dtTemp.Compute("SUM(Cantidad)", "") <> Me.nebPiezasBulto.Value Then
                MessageBox.Show("La cantidad de piezas no coincide. Favor de verificar de nuevo." & vbCrLf & vbCrLf & "Si hay diferencias es necesario utilizar la opcion de Recibir Traspaso a Detalle.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bRes = False
                Me.nebPiezasBulto.Focus()
                Exit Try
            End If

            If SoloValidar = False Then
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Agremos las columnas Lecturado y Agregado para saber si hay diferencias
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim dcLecturado As New DataColumn
                With dcLecturado
                    .ColumnName = "Lecturado"
                    .Caption = "Cant. Lecturada"
                    .DataType = GetType(Integer)
                    .DefaultValue = 0
                End With
                dtTemp.Columns.Add(dcLecturado)

                Dim dcAgregado As New DataColumn
                With dcAgregado
                    .ColumnName = "Agregado"
                    .Caption = "Agregado"
                    .DataType = GetType(Integer)
                    .DefaultValue = 0
                End With
                dtTemp.Columns.Add(dcAgregado)

                dtTemp.AcceptChanges()
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------
                'Igualamos las cantidades para que modifiquen solo en caso de que fisicamente reciban con diferecias
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.RecibirParcialmente Then
                    IgualarCantidadesTraspaso(dtTemp)
                End If

            Else

                Me.nebPiezasBulto.Focus()

            End If

        Catch ex As Exception
            Throw New ApplicationException("[ValidaTraspaso]", ex)
        End Try

        Me.ebFolio.ReadOnly = True

        Return bRes

    End Function

    Private Sub SumarAlDetalle(ByVal dtTempDet As DataTable)

        Dim oRow As DataRow

        If dtTraspaso Is Nothing Then
            dtTraspaso = dtTempDet.Copy
        Else
            For Each oRow In dtTempDet.Rows
                dtTraspaso.ImportRow(oRow)
            Next
        End If
        dtTraspaso.AcceptChanges()

    End Sub

    Private Function CrearTraspasoEntrada(ByVal strFolioTraspaso As String, ByVal dtDetalleBultoTraspaso As DataTable) As TraspasoEntrada

        Dim oTraspasoEntrada As New TraspasoEntrada(oTraspasoEntradaMgr)

        Try

            With oTraspasoEntrada

                Dim oRow As DataRow

                oRow = dtDetalleBultoTraspaso.Rows(0)

                .Status = "TRA"

                .Folio = oRow("Referencia")
                .FolioSAP = oRow("Referencia")

                .TraspasoCreadoEl = oRow("fecha")
                .TraspasoRecibidoEl = Format(oRow("fecha"), "Short Date")

                Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim strCentroOrig(2) As String
                Dim strCentroDest(2) As String

                strCentroOrig = oSap.Read_CentrosSAP(oRow("Origen"))

                .AlmacenOrigenID = strCentroOrig(0)

                strCentroDest = oSap.Read_CentrosSAP(oRow("Destino"))

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
                oSap.ReadInfoPaqueteria(strFolioTraspaso.Trim, strGuia, strTransportista, iBultos)
                .Guia = strGuia 'oSap.ReadInfoPaqueteria(strFolioTraspaso.Trim, "F01")

                'Dim NumBultos As String = oSap.ReadInfoPaqueteria(strFolioTraspaso.Trim, "F02")
                'If NumBultos.Trim = "" Then
                .TotalBultos = iBultos
                'Else
                '    .TotalBultos = CInt(NumBultos.Trim)
                'End If

                .TransportistaID = strTransportista 'oSap.ReadInfoPaqueteria(strFolioTraspaso.Trim, "F03")
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim ds As New DataSet
                ds.Tables.Add(dtDetalleBultoTraspaso)
                .Detalle = New DataSet
                .Detalle = ds.Copy

            End With

        Catch ex As Exception

            Throw New ApplicationException("[Sm_MostrarTraspasoInformacionPorBultos]", ex)

        End Try

        Return oTraspasoEntrada

    End Function

    Private Sub EliminarBultosAplicados(ByVal indices As String)

        Dim idx As String = ""
        Dim idxs() As String = indices.Split("|")

        If idxs.Length > 0 Then
            For Each idx In indices.Split("|")
                If idx.Trim <> "" Then
                    dtDetalleBultos.Rows.RemoveAt(CInt(idx))
                End If
            Next
            dtDetalleBultos.AcceptChanges()
            ActualizaGrid()
        End If

    End Sub

    Private Sub AplicarBultos()

        Dim oRow As DataRow
        Dim strMensaje As String = ""
        Dim idxs As String = ""
        Dim i As Integer = 0

        If dtDetalleBultos.Rows.Count > 0 Then
            If ValidarBultosParaAplicar(dtTraspaso) = True Then
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Mostramos mensaje para que no se desesperen los players
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                oFrmMessage = New frmMessages
                With oFrmMessage
                    .lblMessage.Text = "Aplicando Bultos en SAP" & vbCrLf & "Favor de Esperar..."
                    .Text = "Aplicando Bultos ..."
                    .Show()
                End With
                Application.DoEvents()
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Filtramos por traspaso ingresando todos los bultos por traspaso
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim strFoliosTraspasos As String = ""
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                For Each oRow In dtDetalleBultos.Rows
                    Try
                        If InStr(strFoliosTraspasos, CStr(oRow!FolioTraspaso)) <= 0 Then
                            Sm_AplicarTraspaso(CStr(oRow!FolioTraspaso))
                            idxs &= i & "|"
                            strFoliosTraspasos &= CStr(oRow!FolioTraspaso) & "|"
                        End If
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Ocurrio un error al aplicar el bulto " & oRow!Bulto & " del traspaso " & oRow!FolioTraspaso)
                        strMensaje &= "Folio Traspaso: " & oRow!FolioTraspaso & "".PadLeft(15, " ") & "Bulto: " & oRow!Bulto & vbCrLf
                    End Try
                    i += 1
                Next
                oFrmMessage.Close()
                Application.DoEvents()
                If strMensaje.Trim <> "" Then
                    EliminarBultosAplicados(idxs)
                    MessageBox.Show("Ocurrió un error al aplicar los siguientes bultos: " & vbCrLf & vbCrLf & strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Todos los bultos se aplicaron correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtDetalleBultos.Clear()
                    dtTraspaso.Clear()
                    ActualizaGrid()
                    Sm_Nuevo()
                End If
            End If
        Else
            MessageBox.Show("No hay bultos agregados para aplicar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebFolio.Focus()
        End If

    End Sub

    Private Sub IgualarCantidadesTraspaso(ByRef dtTemp As DataTable)

        Dim oRow As DataRow

        For Each oRow In dtTemp.Rows
            oRow!Lecturado = oRow!Cantidad
        Next
        dtTemp.AcceptChanges()

    End Sub

    Private Function FiltrarTraspasoPorBulto(ByVal dtOriginal As DataTable, ByVal dtFiltrada As DataTable) As DataTable

        Dim dtFiltradaByBulto As DataTable
        Dim oRow As DataRow
        Dim oRowF As DataRow
        Dim oNewRow As DataRow
        Dim Talla As String = ""

        dtFiltradaByBulto = dtOriginal.Clone

        For Each oRow In dtOriginal.Rows
            For Each oRowF In dtFiltrada.Rows
                If InStr(CStr(oRowF!Talla), ".5", CompareMethod.Text) <= 0 And InStr(CStr(oRowF!Talla), ".0", CompareMethod.Text) <> 0 And IsNumeric(CStr(oRowF!Talla)) Then
                    Talla = CStr(CInt(oRowF!Talla))
                Else
                    Talla = CStr(oRowF!Talla)
                End If
                If CStr(oRow!Codigo).Trim.ToUpper = CStr(oRowF!MATNR).Trim.ToUpper AndAlso CStr(oRow!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                    oRow!Cantidad = oRowF!Cantidad
                    oRow!Bulto = oRowF!NBulto
                    dtFiltradaByBulto.ImportRow(oRow)
                End If
            Next
        Next
        dtFiltradaByBulto.AcceptChanges()

        Return dtFiltradaByBulto

    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarBulto()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdBultos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdBultos.KeyDown
        If e.KeyCode = Keys.Delete Then
            EliminarBultoDelGrid()
        End If
    End Sub

    Private Sub btnAplicarTraspaso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAplicarTraspaso.Click
        AplicarBultos()
    End Sub

    Private Sub ebFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.ebFolio.ReadOnly = True Then
                If strFolioTraspaso.Trim.Length > 10 Then
                    Me.ebNoBulto.Value = IIf(IsNumeric(strFolioTraspaso.Trim.Substring(Me.strFolioTraspaso.Length - 1, 1)), strFolioTraspaso.Trim.Substring(Me.strFolioTraspaso.Length - 1, 1), 0)
                    strFolioTraspaso = strFolioTraspaso.Trim.Substring(0, 10)
                End If
                Me.ebFolio.Text = strFolioTraspaso.Trim
                strFolioTraspaso = ""
            End If
            Me.ebNoBulto.Focus()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.T Then
            Me.ebFolio.ReadOnly = False
        Else
            strFolioTraspaso &= Chr(e.KeyCode)
        End If
    End Sub

    'Private Sub FrmInvTraspasoDEntradaPorBultos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Enter
    '            SendKeys.Send("{TAB}")
    '    End Select
    'End Sub

    Private Sub ebNoBulto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebNoBulto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.nebPiezasBulto.Focus()
        End If
    End Sub

    Private Sub nebPiezasBulto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebPiezasBulto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAgregar.Focus()
        End If
    End Sub

End Class
