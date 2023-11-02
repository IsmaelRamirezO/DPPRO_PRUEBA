Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmMotivoCaptura

    Dim dtMotivos As New DataTable
    Dim oFacturaMgr As FacturaManager
    Public strMotivo As String = String.Empty


#Region "Initialize"


    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        InitializeObjects()

        'InitializeObjectsSAP()
    End Sub


    Public Sub InitializeObjects()
        FillComboMotivos()
    End Sub

#End Region

#Region "User Methods"


    Private Sub FillComboMotivos()
        dtMotivos = oFacturaMgr.GetMotivosCaptura()

        With cmbMotivos

            .DropDownList.ClearStructure()

            .DataSource = dtMotivos
            .DropDownList.Columns.Add("id")
            .DropDownList.Columns.Add("motivo")
            .DropDownList.Columns("id").Visible = False
            .DropDownList.Columns("id").DataMember = "id"
            .DropDownList.Columns("motivo").DataMember = "motivo"
            .DropDownList.Columns("motivo").Width = 250

            .DisplayMember = "motivo"
            .ValueMember = "id"

            .Refresh()

        End With

        Dim oRow As DataRow
        For Each oRow In dtMotivos.Rows
            If CStr(oRow!Motivo) = "Falla de banda lectora" Then
                Me.cmbMotivos.Value = oRow!id
                Exit For
            End If
        Next


    End Sub

#End Region

    Private Sub performAction(e As Keys)
        Dim avance As Boolean = True

        If e = Keys.Enter Then
            If cmbMotivos.Text.Trim.Length > 0 Then
                strMotivo = cmbMotivos.Text.Trim
                If strMotivo = "Otros" Then
                    Dim frmOtroMotivo As New frmOtroMotivo()
                    frmOtroMotivo.ShowDialog()
                    strMotivo = frmOtroMotivo.strMotivo
                    If strMotivo.Length = 0 Then
                        avance = False
                    End If
                End If
                If avance Then
                    Me.Dispose()
                End If
            Else
                MessageBox.Show("No se a ingresado correctamente los campos favor de ingresarlos para continuar ", "Tecleo manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub



    Private Sub btnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim avance As Boolean = True
        If cmbMotivos.Text.Trim.Length > 0 Then
            strMotivo = cmbMotivos.Text.Trim
            If strMotivo = "Otros" Then
                Dim frmOtroMotivo As New frmOtroMotivo()
                frmOtroMotivo.ShowDialog()
                strMotivo = frmOtroMotivo.strMotivo
                If strMotivo.Length = 0 Then
                    avance = False
                End If
            End If
            If avance Then
                Me.Dispose()
            End If

        Else
            MessageBox.Show("No se a ingresado correctamente los campos favor de ingresarlos para continuar ", "Tecleo manual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub cmbMotivos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbMotivos.KeyDown
        performAction(e.KeyCode)
        
    End Sub
End Class