Imports DportenisPro.DPTienda.ApplicationUnits.CancelacionAbonoAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Public Class frmCancelacionAbono


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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nebNumAbono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiBSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiBAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelacionAbono))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebNumAbono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiBSalir = New Janus.Windows.EditControls.UIButton()
        Me.UiBAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.nebNumAbono)
        Me.ExplorerBar1.Controls.Add(Me.UiBSalir)
        Me.ExplorerBar1.Controls.Add(Me.UiBAceptar)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Cancelacion de Abono"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -2)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(384, 160)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebNumAbono
        '
        Me.nebNumAbono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebNumAbono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebNumAbono.FormatString = "0"
        Me.nebNumAbono.Location = New System.Drawing.Point(160, 56)
        Me.nebNumAbono.MaxLength = 6
        Me.nebNumAbono.Name = "nebNumAbono"
        Me.nebNumAbono.Size = New System.Drawing.Size(128, 23)
        Me.nebNumAbono.TabIndex = 1
        Me.nebNumAbono.Text = "0"
        Me.nebNumAbono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebNumAbono.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebNumAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiBSalir
        '
        Me.UiBSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBSalir.Location = New System.Drawing.Point(192, 104)
        Me.UiBSalir.Name = "UiBSalir"
        Me.UiBSalir.Size = New System.Drawing.Size(96, 32)
        Me.UiBSalir.TabIndex = 3
        Me.UiBSalir.Text = "&Salir"
        Me.UiBSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiBAceptar
        '
        Me.UiBAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBAceptar.Location = New System.Drawing.Point(72, 104)
        Me.UiBAceptar.Name = "UiBAceptar"
        Me.UiBAceptar.Size = New System.Drawing.Size(96, 32)
        Me.UiBAceptar.TabIndex = 2
        Me.UiBAceptar.Text = "&Aceptar"
        Me.UiBAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "No. Abono:"
        '
        'frmCancelacionAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 149)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCancelacionAbono"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cancelacion de Abono"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oCancelacionAbonoMgr As New CancelacionAbonoManager(oAppContext)
    Private oCancelacionAbono As CancelacionAbono

    Private oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)
    Private oAbonosApartados As AbonosApartados

    Private oContratosMgr As New ContratoManager(oAppContext)
    Private oContratos As Contrato

    Private oCierreDiaMgr As New CierreDiaManager(oAppContext)
    Private oCierreDia As CierreDia

    Dim vlFolioApartado As Integer

#End Region

    Private Sub UiBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBSalir.Click

        Me.Close()

    End Sub

    Private Sub UiBAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBAceptar.Click

        Sm_Aceptar()

    End Sub

    Public Sub ActionPreview(Optional ByVal Reimpresion As Boolean = False)
        Dim oARReporte
        Dim TotalAbonos As Decimal = 0


        Dim oCliente As ClienteAlterno
        Dim oCatalogoClientesMgr As ClientesManager

        oCatalogoClientesMgr = New ClientesManager(oAppContext)


        oCliente = oCatalogoClientesMgr.CreateAlterno
        oCatalogoClientesMgr.Load(oContratos.ClienteID, oCliente, "A")

        Dim dtTotal As DataTable = oContratosMgr.GetImporteAbonosByApartadoId(oContratos.ID)

        If Not dtTotal Is Nothing Then
            Dim oRow As DataRow = dtTotal.Rows(0)
            TotalAbonos = oRow!Total
        End If



        oARReporte = New rptCancelacionAbonoApartadoMiniPrinter(oAbonosApartados, oContratos.FolioApartado, oCliente.NombreCompleto, oContratos.ImporteTotal, TotalAbonos, Reimpresion)
        oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
        oARReporte.Document.Name = "Cancelacion Abono Apartado"
        oARReporte.Run()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub CreaEstructuraTarjetas(ByRef dtTarjetas As DataTable)

        dtTarjetas = New DataTable("Tarjetas")

        With dtTarjetas
            .Columns.Add(New DataColumn("DPValeID", GetType(String)))
            .Columns.Add(New DataColumn("CodFormasPago", GetType(String)))
            .Columns.Add(New DataColumn("CodBanco", GetType(String)))
            .Columns.Add(New DataColumn("NumeroTarjeta", GetType(String)))
            .Columns.Add(New DataColumn("NumeroAutorizacion", GetType(String)))
            .Columns.Add(New DataColumn("FormaPagoID", GetType(Integer)))
            .AcceptChanges()
        End With

    End Sub

    Private Sub Sm_Aceptar()

        Dim x As Boolean

        'If (oCancelacionAbono Is Nothing) Then
        'MessageBox.Show("No ha sido seleccionado un Registro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'nebNumAbono.Focus()
        'Exit Sub
        'End If

        Cursor = Cursors.WaitCursor

        If oAbonosApartados Is Nothing Then
            MsgBox("Abono no registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
            nebNumAbono.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        x = oAbonosApartados.Status
        If oAbonosApartados.Status = False Then
            MsgBox("Este Abono ya fue Cancelado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
            nebNumAbono.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        'Falta validacion de cierre de dia
        oCierreDia = oCierreDiaMgr.LoadFecha((oAbonosApartados.Fecha.Date))
        If Not (oCierreDia Is Nothing) Then
            If oCierreDia.Fecha.Date = oAbonosApartados.Fecha.Date Then
                MsgBox("Imposible cancelar Abono porque ya esta incluido en el Cierre.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
                nebNumAbono.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If


        oContratos = oContratosMgr.LoadFolioApartado(oAbonosApartados.FolioApartado)
        If oContratos.Entregada = "S" Then
            MsgBox("Imposible cancelar Abono porque el Apartado al que correponde ya fue Entregado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
            nebNumAbono.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        If oContratos.Entregada = "C" Then
            MsgBox("El contrato asociado a dicho abono ya se encuentra cancelado.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
            nebNumAbono.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If


        '--------------------------------------------------------------------------
        ' JNAVA (12.02.2016): Se obtiene la referencia del contrato
        '--------------------------------------------------------------------------
        Dim strReferenciaContrato As String
        strReferenciaContrato = oContratos.Referencia
        '--------------------------------------------------------------------------


        Dim dsAbonos As DataSet
        dsAbonos = oContratosMgr.AbonosApartadosSel(oAbonosApartados.ApartadoID)
        Dim TotalAbonos As Decimal = 0

        If Not dsAbonos Is Nothing Then
            Dim dtAbonos As DataTable = dsAbonos.Tables(0)

            If Not dtAbonos Is Nothing AndAlso dtAbonos.Rows.Count > 0 Then

                For Each oRow As DataRow In dtAbonos.Rows
                    If oRow!StatusRegistro Then
                        TotalAbonos += oRow!Abono
                    End If
                Next
            End If
        End If

        Dim porcentaje = oContratos.ImporteTotal * (oAppContext.ApplicationConfiguration.MinPrimerAbono / 100)

        If (TotalAbonos - oAbonosApartados.Abono) < porcentaje Then
            MsgBox("No se puede cancelar el abono ya que debe de existir un pago que cubra el porcentaje de penalización.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelación de Abonos")
            Exit Sub
        End If


        If (MessageBox.Show("Se encuentra seguro de Cancelar el Abono", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        'Cancelacion Tarjeta de Credito EHub.
        If oAppSAPConfig.eHub = True Then
            If (oAbonosApartados.CodFormaPago = "TACR" OrElse oAbonosApartados.CodFormaPago = "TADB") Then ' AndAlso oAbonosApartados.TipoTarjeta = "TE" Then
NoCierra:
                'Dim oFrmCancelarPagoTarjeta As New frmCancelarUnPagoTarjeta
                'With oFrmCancelarPagoTarjeta
                '    .Ticket = oAbonosApartados.Ticket
                '    .CodBanco = oAbonosApartados.CodBanco
                '    .NoTarjeta = oAbonosApartados.NumeroTarjeta
                '    .NoAutorizacion = oAbonosApartados.NumeroAutorizacion
                '    .Monto = oAbonosApartados.Abono
                '    .CodCaja = oAbonosApartados.CodCaja
                '    .CodAlmacen = oAbonosApartados.CodAlmacen
                '    .CodVendedor = oAbonosApartados.CodVendedor
                '    .Promocion = oAbonosApartados.Promocion
                '    If .ShowDialog() <> DialogResult.OK Then
                '        'GoTo NoCierra
                '        Exit Sub
                '    End If
                'End With


                Dim dtFormasPago As DataTable
                CreaEstructuraTarjetas(dtFormasPago)
                Dim dsFormaPago As New DataSet()

                Dim fila As DataRow = dtFormasPago.NewRow
                fila("DPValeID") = oAbonosApartados.DPValeID
                fila("CodFormasPago") = oAbonosApartados.CodFormaPago
                fila("CodBanco") = oAbonosApartados.CodBanco
                fila("NumeroTarjeta") = oAbonosApartados.NumeroTarjeta
                fila("NumeroAutorizacion") = oAbonosApartados.NumeroAutorizacion
                fila("FormaPagoID") = 0
                dtFormasPago.Rows.Add(fila)


                dsFormaPago.Tables.Add(dtFormasPago)

                Dim oFrmCancelarPagoTarjeta As New frmCancelarPagoTarjeta
                ' oFrmCancelarPagoTarjeta.oPedido = Me
                oFrmCancelarPagoTarjeta.EsFactura = False
                oFrmCancelarPagoTarjeta.EsSiHay = False
                oFrmCancelarPagoTarjeta.dsFormasPago = dsFormaPago
                oFrmCancelarPagoTarjeta.ShowDialog()

            End If
        End If

        vlFolioApartado = oAbonosApartados.ApartadoID
        oCancelacionAbonoMgr.Delete(oAbonosApartados.ID, vlFolioApartado)
        nebNumAbono.Text = String.Empty

        oCancelacionAbono = Nothing

        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim DOCNUMFB01 As String
        Dim strTienda, strError, strFecha As String
        strTienda = oAbonosApartadosMgr.SelectNombreTienda(oAbonosApartados.ClaCobr, oSap.Read_Centros)
        'Para cancelacion de abono no se cobra penalidad
        'DOCNUMFB01 = oSap.Write_CancelaApartado(oAbonosApartados.ClienteID, oAbonosApartados.Abono, 0, strTienda, "", oAbonosApartados.Abono, oAbonosApartados.Docfi, "", "")
        Dim CuentaMayor, GSBER, Werks As String
        oAbonosApartadosMgr.SelectCtaMayor(strTienda, oAbonosApartados.ClaCobr, CuentaMayor, GSBER, Werks)
        strFecha = Format(oAbonosApartados.Fecha, "dd.MM.yyyy") 'oAbonosApartados.Fecha.Date.Day & "." & oAbonosApartados.Fecha.Date.Month & "." & oAbonosApartados.Fecha.Date.Year

        '--------------------------------------------------------------------------
        ' JNAVA (12.02.2016): Se envia la referencia del contrato por retail
        '--------------------------------------------------------------------------
        DOCNUMFB01 = oSap.Write_CancelaAbonoApartado(oAbonosApartados.ClienteID, strFecha, oAbonosApartados.Abono, CuentaMayor, oAbonosApartados.Docfi, GSBER, "T" & oAppContext.ApplicationConfiguration.Almacen, strError, strReferenciaContrato)

        If DOCNUMFB01 <> "" Then
            oCancelacionAbonoMgr.ActualizaDOCNUMFB01(oAbonosApartados.ID, DOCNUMFB01)
        Else
            'No se guardo en SAP           
            MsgBox(strError, MsgBoxStyle.Information, Me.Text)
        End If


        '--------------------------------------------------------------------------
        ' MLVARGAS (14.02.2022): Imprimir el ticket de cancelación
        '--------------------------------------------------------------------------

        ActionPreview()

        MessageBox.Show("El Abono ha sido Cancelado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.nebNumAbono.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub nebNumAbono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nebNumAbono.Validating


        If nebNumAbono.Text = String.Empty Then

            Exit Sub

        End If

        If nebNumAbono.Text <= 0 Then

            Exit Sub

        End If

        oAbonosApartados = oAbonosApartadosMgr.Load(nebNumAbono.Text)

    End Sub

    Private Sub frmCancelacionAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class
