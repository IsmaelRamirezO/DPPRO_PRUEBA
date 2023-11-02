Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class frmCancelarContratoDefinitivamente
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nbFolioContrato As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbCodCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarContratoDefinitivamente))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.ebResponsableName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nbFolioContrato = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.Controls.Add(Me.lblLabel4)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.cmbCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableName)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableID)
        Me.ExplorerBar1.Controls.Add(Me.nbFolioContrato)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(378, 311)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VerticalScrollBar = Janus.Windows.ExplorerBar.VerticalScrollBar.Never
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel4.Location = New System.Drawing.Point(32, 131)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(104, 23)
        Me.lblLabel4.TabIndex = 8
        Me.lblLabel4.Text = "Fecha  :"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.Color.Ivory
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(144, 129)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(88, 22)
        Me.ebFecha.TabIndex = 2
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Caja  :"
        '
        'cmbCodCaja
        '
        Me.cmbCodCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbCodCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodCaja.Location = New System.Drawing.Point(144, 59)
        Me.cmbCodCaja.Name = "cmbCodCaja"
        Me.cmbCodCaja.Size = New System.Drawing.Size(88, 22)
        Me.cmbCodCaja.TabIndex = 0
        Me.cmbCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Enabled = False
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.Location = New System.Drawing.Point(81, 264)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(216, 32)
        Me.UiButton1.TabIndex = 5
        Me.UiButton1.Text = "Cancelar Contrato"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebResponsableName
        '
        Me.ebResponsableName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableName.Location = New System.Drawing.Point(144, 199)
        Me.ebResponsableName.Name = "ebResponsableName"
        Me.ebResponsableName.ReadOnly = True
        Me.ebResponsableName.Size = New System.Drawing.Size(216, 22)
        Me.ebResponsableName.TabIndex = 4
        Me.ebResponsableName.TabStop = False
        Me.ebResponsableName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableID
        '
        Me.ebResponsableID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableID.Location = New System.Drawing.Point(144, 164)
        Me.ebResponsableID.Name = "ebResponsableID"
        Me.ebResponsableID.ReadOnly = True
        Me.ebResponsableID.Size = New System.Drawing.Size(88, 22)
        Me.ebResponsableID.TabIndex = 3
        Me.ebResponsableID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFolioContrato
        '
        Me.nbFolioContrato.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolioContrato.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolioContrato.ButtonImage = CType(resources.GetObject("nbFolioContrato.ButtonImage"), System.Drawing.Image)
        Me.nbFolioContrato.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolioContrato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbFolioContrato.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbFolioContrato.Location = New System.Drawing.Point(144, 94)
        Me.nbFolioContrato.Name = "nbFolioContrato"
        Me.nbFolioContrato.Size = New System.Drawing.Size(88, 22)
        Me.nbFolioContrato.TabIndex = 1
        Me.nbFolioContrato.Text = "0"
        Me.nbFolioContrato.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolioContrato.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolioContrato.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Responsable  :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Folio Contrato  :"
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(356, 215)
        Me.grpGroupBox1.TabIndex = 10
        Me.grpGroupBox1.TabStop = False
        '
        'frmCancelarContratoDefinitivamente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(378, 311)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCancelarContratoDefinitivamente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Contrato de Forma Definitiva"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variblaes"
    Private bolContraseña As Boolean = False


    Private oVendedor As Vendedor

    Private oApartado As Contrato
    Private oApartadosMgr As ContratoManager

    Private oDistribucionNC As DistribucionNC
    Private oDistribucionNCMgr As DistribucionNCManager

    Private oCajasMgr As CatalogoCajaManager

#End Region

    Private Sub frmCancelarContratoDefinitivamente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.ebResponsableName.Text = oVendedor.Nombre
        'Me.ebResponsableID.Text = oVendedor.ID

        oApartadosMgr = New ContratoManager(oAppContext)
        oApartado = oApartadosMgr.Create

        oCajasMgr = New CatalogoCajaManager(oAppContext)

        oDistribucionNCMgr = New DistribucionNCManager(oAppContext)

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajasMgr.GetAll(False)

        Me.cmbCodCaja.DataSource = dsCaja
        Me.cmbCodCaja.DataMember = "CatalogoCajas"
        Me.cmbCodCaja.DisplayMember = "CodCaja"
        Me.cmbCodCaja.ValueMember = "CodCaja"

        Me.cmbCodCaja.SelectedValue = oAppContext.ApplicationConfiguration.NoCaja



    End Sub

#Region "Metodos de Busqueda"

    Private Sub Sm_AbrirContrato(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (Me.nbFolioContrato.Value = 0)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New ContratoOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oApartado = Nothing
                oApartado = oApartadosMgr.LoadFolioCaja(oOpenRecordDlg.Record.Item("FolioApartado"), oOpenRecordDlg.Record.Item("CodCaja"))

            End If

        Else

            oApartado = Nothing
            oApartado = oApartadosMgr.LoadFolioCaja(Me.nbFolioContrato.Value, Me.cmbCodCaja.SelectedValue)

        End If

        If oApartado Is Nothing Then

            MessageBox.Show("El contrato no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.nbFolioContrato.Value = 0
            Me.ebFecha.Text = String.Empty
            Me.ebResponsableID.Text = String.Empty
            Me.ebResponsableName.Text = String.Empty
            Me.UiButton1.Enabled = False
            Me.nbFolioContrato.Focus()

        Else

            Me.nbFolioContrato.Value = oApartado.FolioApartado
            Me.cmbCodCaja.SelectedValue = oApartado.CodCaja
            Me.ebFecha.Text = Format(oApartado.Fecha, "short date")

            If oApartado.StatusRegistro = False Then

                MessageBox.Show("Este contrato ya fue cancelado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                oApartado = Nothing
                Me.nbFolioContrato.Value = 0
                Me.ebFecha.Text = String.Empty
                Me.ebResponsableID.Text = String.Empty
                Me.ebResponsableName.Text = String.Empty
                Me.UiButton1.Enabled = False
                Me.nbFolioContrato.Focus()

            ElseIf oApartado.Entregada.ToUpper = "S" Then

                MessageBox.Show("No puede cancelar este contrato por que ya fue entregado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                oApartado = Nothing
                Me.nbFolioContrato.Value = 0
                Me.ebFecha.Text = String.Empty
                Me.ebResponsableID.Text = String.Empty
                Me.ebResponsableName.Text = String.Empty
                Me.UiButton1.Enabled = False
                Me.nbFolioContrato.Focus()

            ElseIf oApartado.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) < Today Then

                MessageBox.Show("Este contrato ya esta vencido, es necesario la autorizacion del auditor para continuar", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = False Then
                    oApartado = Nothing
                    Me.nbFolioContrato.Value = 0
                    Me.ebFecha.Text = String.Empty
                    Me.ebResponsableID.Text = String.Empty
                    Me.ebResponsableName.Text = String.Empty
                    Me.UiButton1.Enabled = False
                    Me.nbFolioContrato.Focus()
                End If
                oAppContext.Security.CloseImpersonatedSession()

            End If

        End If

    End Sub

#End Region

    Private Sub nbFolioContrato_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbFolioContrato.ButtonClick
        Sm_AbrirContrato(True)
    End Sub

    Private Sub nbFolioContrato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolioContrato.KeyDown
        If e.KeyCode = Keys.Enter Then

            Sm_AbrirContrato()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_AbrirContrato(True)

        End If
    End Sub

    Private Function ValidarAbonosCancelados(ByVal dtAbonos As DataTable) As Boolean

        Dim bRes As Boolean = True
        Dim oRow As DataRow
        '--------------------------------------------------------------------------------------------------------------
        'Si algún abono no ha sido cancelado no permito continuar con la cancelación
        '--------------------------------------------------------------------------------------------------------------
        For Each oRow In dtAbonos.Rows
            If CBool(oRow!StatusRegistro) = True OrElse CStr(oRow!DocNumFB01).TrimEnd = "" Then
                bRes = False
                Exit For
            End If
        Next

        Return bRes

    End Function

    Public Sub Sm_ActionPrint(Optional ByVal Reimpresion As Boolean = False)

        Dim oCliente As ClienteAlterno
        Dim oCatalogoClientesMgr As ClientesManager

        oCatalogoClientesMgr = New ClientesManager(oAppContext)


        oCliente = oCatalogoClientesMgr.CreateAlterno
        oCatalogoClientesMgr.Load(oApartado.ClienteID, oCliente, "A")

        If (oApartado Is Nothing) Then
            MsgBox("Debe Abrir un Contrato.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub
        End If

        Dim oARReporte
        Dim oView As New ReportViewerForm

        oARReporte = New ReporteCancelacionContrato(oApartado, oCliente, oApartado.Detalle.Tables(0), Reimpresion)
        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
        oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

        'oARReporte.DataSource = oContrato.Detalle.Tables(0)
        oARReporte.Document.Name = "Reporte Cancelación de Apartado"
        oARReporte.Run()

        Try

            oARReporte.Document.Print(False, False)
            'oView.Report = oARReporte
            'oView.Show()

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Sub



    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Try

            If oApartado Is Nothing Then
                MessageBox.Show("¡Favor de elegir un folio de contrato!", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If oApartado.Fecha.AddDays(oAppContext.ApplicationConfiguration.DiasVencimientoApartados) > Today Then
                MessageBox.Show("El contrato aun no se encuentra vencido, debe ser cancelado desde la aplicación de cancelación para nota de crédito.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show("¿Esta seguro que desea continuar con la cancelacion del contrato de apartado?", "DPTienda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                '------------------------------------------------------------------------------------------------------------------------------
                '******  CANCELAMOS EN SAP *******
                '------------------------------------------------------------------------------------------------------------------------------
                'Obtengo la informacion de los abonos
                '------------------------------------------------------------------------------------------------------------------------------
                Dim ds As New DataSet
                ds = oApartadosMgr.AbonosApartadosSel(oApartado.ID)
                '------------------------------------------------------------------------------------------------------------------------------
                'Si el contrato es de hoy validamos que todos los abonos hayan sido cancelados de lo contrario no permitimos continuar con la
                'cancelación
                '------------------------------------------------------------------------------------------------------------------------------
                If Format(oApartado.Fecha, "dd/MM/yyyy").Trim.ToUpper = Format(Today, "dd/MM/yyyy").Trim.ToUpper AndAlso _
                ValidarAbonosCancelados(ds.Tables(0)) = False Then
                    MessageBox.Show("El contrato de apartado todavia tiene abonos pendientes por cancelar" & vbCrLf & "Es necesario cancelarlos" & _
                    " antes de continuar con el proceso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Try
                End If

                If ds.Tables(0).Rows.Count > 0 Then


                    Dim strDocNumFB01 As String

                    'Cancelamos en contrato
                    ds.Tables(0).Columns.Add("Tienda", GetType(String))
                    ds.Tables(0).Columns.Add("Referencia", GetType(String))
                    For Each row As DataRow In ds.Tables(0).Rows
                        row("Tienda") = oAppContext.ApplicationConfiguration.Almacen
                        row("Referencia") = oApartado.Referencia
                        row.AcceptChanges()
                    Next
                    ds.Tables(0).AcceptChanges()
                    strDocNumFB01 = oSap.CancelarApartadoDefinitivo(ds, oApartado.ID, oApartado.Referencia, oAppContext.ApplicationConfiguration.Almacen)

                    If strDocNumFB01 <> "" Then

                        Dim intAnticipoID As Integer

                        intAnticipoID = oApartadosMgr.DistibucionCancelarContrato(oApartado)

                        oDistribucionNC = Nothing
                        oDistribucionNC = oDistribucionNCMgr.LoadAnticipoCliente(intAnticipoID, "AP")

                        For Each oRow As DataRow In oDistribucionNC.Detalle.Tables("AnticiposClientesDetalle").Rows
                            If strDocNumFB01 <> "" Then
                                oApartadosMgr.ActualizaDOCNUMFB01xFolioAbono(oRow!REFERENCIA, strDocNumFB01)
                            Else
                                'No se guardo en SAP
                            End If
                        Next

                        '********************Cancelar En MM14********************
                        'Dim strDocFi As String

                        ''strDocFi = oSap.Write_DesbloqueApartado(oApartado.ContratoSAP, oApartado.Detalle.Tables("ContratoDetalle"))

                        ''If strDocFi = "" Then
                        ''    GoTo NoGrabaSAP
                        ''End If

                        ''tambien guarda en la tabla Apartado el DocFi de cancelacion que regresa sap
                        'oApartadosMgr.SetDocFiCancelacion(oApartado.ID, strDocFi)

                        'Actualiza el apartado Entregado= "C" y StatusRegistro = 0
                        oApartadosMgr.Delete(oApartado.ID, ebResponsableID.Text.Trim())

                        'Actualiza los Apartados en existencias de acuerdo al almacen, articulo y numero.
                        oApartadosMgr.ContratoCancelarUpdateInventario(oApartado.Detalle)

                        Sm_ActionPrint()

                        MessageBox.Show("Contrato Cancelado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.nbFolioContrato.Value = 0
                        Me.ebFecha.Text = String.Empty
                        Me.ebResponsableID.Text = String.Empty
                        Me.ebResponsableName.Text = String.Empty
                        Me.UiButton1.Enabled = False
                        Me.nbFolioContrato.Focus()

                    Else
NoGrabaSAP:

                        'no se graba en SAP 
                        MessageBox.Show("El Contrato no se cancelo en SAP", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Else

                    'Si el contrato no tuvo abonos, se cancela y actualiza la existencia

                    'tambien guarda en la tabla Apartado el DocFi de cancelacion que regresa sap
                    oApartadosMgr.SetDocFiCancelacion(oApartado.ID, "1111111111")

                    'Actualiza el apartado Entregado= "C" y StatusRegistro = 0
                    oApartadosMgr.Delete(oApartado.ID, ebResponsableID.Text.Trim())

                    'Actualiza los Apartados en existencias de acuerdo al almacen, articulo y numero.
                    oApartadosMgr.ContratoCancelarUpdateInventario(oApartado.Detalle)

                    Sm_ActionPrint()

                    MessageBox.Show("Contrato Cancelado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.nbFolioContrato.Value = 0
                    Me.ebFecha.Text = String.Empty
                    Me.ebResponsableID.Text = String.Empty
                    Me.ebResponsableName.Text = String.Empty
                    Me.UiButton1.Enabled = False
                    Me.nbFolioContrato.Focus()

                    oApartado = Nothing

                End If

            End If

        Catch ex As Exception

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        Catch oSqlException As SqlClient.SqlException

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        End Try
    End Sub

    Private Sub frmCancelarContratoDefinitivamente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub ebResponsableID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebResponsableID.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                If Me.ebFecha.Text = Format(Now, "short date") Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.CancelaContrato", "DportenisPro.DPTienda.Apartados.CancelaContrato.DefinitivoDia") = True Then
                        Me.ebResponsableID.Text = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
                        Me.ebResponsableName.Text = UCase(oAppContext.Security.CurrentUser.Name)
                        Me.UiButton1.Enabled = True
                        oAppContext.Security.CloseImpersonatedSession()
                        SendKeys.Send("{TAB}")
                    Else
                        Me.ebResponsableID.Text = String.Empty
                        Me.ebResponsableName.Text = String.Empty
                        Me.UiButton1.Enabled = False
                    End If
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.CancelaContrato", "DportenisPro.DPTienda.Apartados.CancelaContrato.DefinitivoAnterior") = True Then
                        Me.ebResponsableID.Text = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
                        Me.ebResponsableName.Text = UCase(oAppContext.Security.CurrentUser.Name)
                        Me.UiButton1.Enabled = True
                        oAppContext.Security.CloseImpersonatedSession()
                        SendKeys.Send("{TAB}")
                    Else
                        Me.ebResponsableID.Text = String.Empty
                        Me.ebResponsableName.Text = String.Empty
                        Me.UiButton1.Enabled = False
                    End If
                End If

        End Select

    End Sub

End Class
