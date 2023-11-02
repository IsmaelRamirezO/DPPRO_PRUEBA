Public Class frmOtroMotivo

    Public strMotivo As String = String.Empty


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.txtMotivo.Text.Length > 0 Then
            strMotivo = Me.txtMotivo.Text
            Me.Dispose()
        Else
            MessageBox.Show("Debe ingresar el motivo, favor de ingresarlo para continuar ", "Tecleo manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub txtMotivo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If Me.txtMotivo.Text.Length > 0 Then
                strMotivo = Me.txtMotivo.Text
                Me.Dispose()
            Else
                MessageBox.Show("Debe ingresar el motivo, favor de ingresarlo para continuar ", "Tecleo manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

   
End Class