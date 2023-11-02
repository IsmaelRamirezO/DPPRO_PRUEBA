Public Class frmPagosVirtual

    Private Sub btnPagosTarjetas_Click(sender As System.Object, e As System.EventArgs) Handles btnPagosTarjetas.Click
        Dim ofrmTPVVirtual As New frmTPV
        ofrmTPVVirtual.ShowDialog()
    End Sub

    Private Sub btnCancelarPagosTarjetas_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarPagosTarjetas.Click
        Dim ofrmCancPago As New frmCancPagoTarjeta()
        ofrmCancPago.ShowDialog()
    End Sub

    Private Sub btnAbonoDPCard_Click(sender As System.Object, e As System.EventArgs) Handles btnAbonoDPCard.Click
        If oConfigCierreFI.AplicaDPCard Then
            Dim menuClickB As New frmOtrosPagos(True)
            menuClickB.ShowDialog()
        End If
    End Sub

    Private Sub btnPagoDPCard_Click(sender As System.Object, e As System.EventArgs) Handles btnPagoDPCard.Click
        Dim ofrmPagoDPCard As New frmPagoDpCard()
        ofrmPagoDPCard.ShowDialog()
    End Sub
End Class