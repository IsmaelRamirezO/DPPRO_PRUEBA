Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida
Public Class OpenTraspasoSalidaVirtual
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dtTraspaso As DataTable
        Dim oTraspaso As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        dtTraspaso = oTraspaso.GetTraspasoSalidaDetalleVirtual(oAppContext.ApplicationConfiguration.Almacen)
        dtTraspaso = GetTraspasoCodigoBarra(dtTraspaso)
        With TargetGridEx
            .DataSource = dtTraspaso
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables(0)

            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Width = 130

            .Columns("Origen").Caption = "S. Origen"
            .Columns("Origen").Width = 50

            .Columns("Destino").Caption = "S. Destino"
            .Columns("Destino").Width = 150

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

        End With
    End Sub

    Private Function GetTraspasoCodigoBarra(ByVal dtTraspaso As DataTable) As DataTable
        Dim dtResult As New DataTable("Traspaso"), fila As DataRow = Nothing
        Dim cajaID As Integer = 0, CajaAnt As Integer = 0
        dtResult.Columns.Add("Folio", GetType(String))
        dtResult.Columns.Add("CajaID", GetType(Integer))
        dtResult.Columns.Add("Origen", GetType(String))
        dtResult.Columns.Add("Destino", GetType(String))
        dtResult.Columns.Add("Fecha", GetType(DateTime))
        dtResult.Columns.Add("FolioTraspaso", GetType(String))
        dtResult.AcceptChanges()
        For Each row As DataRow In dtTraspaso.Rows
            cajaID = CInt(row("CajaID"))
            If cajaID <> CajaAnt Then
                fila = dtResult.NewRow()
                fila("FolioTraspaso") = CStr(row("FolioTraspaso"))
                fila("CajaID") = CInt(row("CajaID"))
                fila("Folio") = CStr(row("FolioTraspaso")).PadLeft(10, "0") & CStr(row("CajaID")).PadLeft(4, "0")
                fila("Origen") = CStr(row("Origen"))
                fila("Destino") = CStr(row("Destino"))
                fila("Fecha") = CDate(row("Fecha"))
                dtResult.Rows.Add(fila)
                CajaAnt = cajaID
            End If
        Next
        dtResult.AcceptChanges()
        Return dtResult
    End Function
End Class
