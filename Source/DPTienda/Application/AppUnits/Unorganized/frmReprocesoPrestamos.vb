Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports Janus.Windows.GridEX

Public Class frmReprocesoPrestamos

#Region "Variables de instancia"

    Private oDPVMgr As DPValeFinancieroManager
    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    Private dtCreditos As DataTable
    Private Dispersion As DisposicionEfeClubDP
    Private dtPlazos As DataTable
    Private dtBancos As DataTable

#End Region


#Region "Contructores"
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Inicializar()
    End Sub
#End Region

#Region "Metodos y funciones"

    Private Sub Inicializar()
        Me.oDPVMgr = New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        dtPlazos = oDPVMgr.GetPlazos(oAppContext.ApplicationConfiguration.Almacen, oSAPMgr.MSS_GET_SY_DATE_TIME())
        dtBancos = oDPVMgr.GetBancos()
        Dispersion = Nothing
        FillReproceso()
    End Sub

    Private Sub FillReproceso()
        Me.dtCreditos = oDPVMgr.GetDisposicionEfeClubDPByAlmacen(oAppContext.ApplicationConfiguration.Almacen)
        Me.gridCreditos.DataSource = dtCreditos
    End Sub

    Private Sub Reproceso()
        If Not gridCreditos.GetRow() Is Nothing Then
            Try
                Dim row As DataRowView = CType(gridCreditos.GetRow().DataRow, DataRowView)
                Dim VendedorMgr As New CatalogoVendedoresManager(oAppContext)
                Dim vendedor As Vendedor = VendedorMgr.Create()
                Dim TransactionId As Integer = CInt(row("TransactionId"))
                Dim VoucherInfo As New Hashtable
                Dim rows() As DataRow
                Dim Plazo As String = ""
                Dispersion = New DisposicionEfeClubDP(oDPVMgr, TransactionId)
                VendedorMgr.LoadInto(Dispersion.CodVendedor, vendedor)
                VoucherInfo("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                VoucherInfo("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                VoucherInfo("Tarjeta") = Dispersion.NoTarjeta
                VoucherInfo("TarjetaHabiente") = Dispersion.NombreCliente
                VoucherInfo("Vendedor") = vendedor.ID & " " & vendedor.Nombre
                VoucherInfo("ConsecutivoPOS") = Dispersion.TransactionSequenceNumber
                VoucherInfo("Monto") = Dispersion.Monto
                If Dispersion.Deslizada = True Then
                    VoucherInfo("Linea") = "DESLIZADA"
                Else
                    VoucherInfo("Linea") = "DIGITADA"
                End If
                VoucherInfo("IFE") = Dispersion.IFE
                VoucherInfo("Reimpresa") = False
                rows = dtPlazos.Select("PlanCode='" & Dispersion.PaymentPlan & "'")
                If rows.Length > 0 Then
                    Plazo = rows(0)!PlazoMicroCreditoDesc
                End If
                VoucherInfo("Promocion") = Plazo
                Dim meses As Integer, strMeses As String = Plazo.Substring(0, 1)
                If IsNumeric(strMeses) = True Then
                    meses = CInt(strMeses)
                Else
                    meses = 0
                End If
                VoucherInfo("Meses") = CStr(meses)
                Dim frmDispersion As New frmServicioDispersion(Dispersion, True)
                frmDispersion.VoucherInfo = VoucherInfo
                If frmDispersion.ShowDialog() = DialogResult.OK Then
                    FillReproceso()
                Else
                    MessageBox.Show("Se cancelo la dispersión en el reproceso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                EscribeLog(ex.Message, "Hubo un error al reprocesar la dispersión")
                MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub ToolbarReprocesoPrestamo_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles ToolbarReprocesoPrestamo.CommandClick
        Select Case e.Command.Key
            Case "MnuActualizar"
                FillReproceso()
            Case "tbReproceso"
                Reproceso()
            Case "tbSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub frmReprocesoPrestamos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                Reproceso()
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub gridCreditos_RowDoubleClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles gridCreditos.RowDoubleClick
        If Not gridCreditos.GetRow() Is Nothing Then
            Reproceso()
        End If
    End Sub

#End Region

End Class