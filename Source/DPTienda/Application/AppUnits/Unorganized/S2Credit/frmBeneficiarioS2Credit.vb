
Imports System.Collections.Generic

'-----------------------------------------------------------------------------------------------------------------
' JNAVA (05.08.2016): Formulario para capturar benficiario de seguro en S2Credit
'-----------------------------------------------------------------------------------------------------------------
Public Class frmBeneficiarioS2Credit

#Region "Variables Globales"

    Public DatosBeneficiario As Dictionary(Of String, Object)

#End Region

#Region "Metodos y Funciones"

    Private Sub Inicializar()

        LlenarComboParentescos()

    End Sub

    Private Function ValidarDatos() As Boolean

        Dim bResp As Boolean = True

        '-----------------------------------------------------------------------------------------------------------------
        ' Validamos Nombre
        '-----------------------------------------------------------------------------------------------------------------
        If Me.ebNombres.Text.Trim = String.Empty Then
            MessageBox.Show("Debe capturar el Nombre del Beneficiario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNombres.Focus()
            bResp = False
        End If

        '-----------------------------------------------------------------------------------------------------------------
        ' Validamos Apellido Paterno
        '-----------------------------------------------------------------------------------------------------------------
        If Me.ebApellidoPaterno.Text.Trim = String.Empty Then
            MessageBox.Show("Debe capturar el Apellido Paterno del Beneficiario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebApellidoPaterno.Focus()
            bResp = False
        End If

        '-----------------------------------------------------------------------------------------------------------------
        ' Validamos Apellido Materno
        '-----------------------------------------------------------------------------------------------------------------
        If Me.ebApellidoMaterno.Text.Trim = String.Empty Then
            MessageBox.Show("Debe capturar el Apellido Materno del Beneficiario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebApellidoMaterno.Focus()
            bResp = False
        End If

        '-----------------------------------------------------------------------------------------------------------------
        ' Validamos Parentesco
        '-----------------------------------------------------------------------------------------------------------------
        If Me.cmbParentesco.Text.Trim = String.Empty Then
            MessageBox.Show("Debe seleccionar el Parentesco del Beneficiario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbParentesco.Focus()
            bResp = False
        End If

        Return bResp

    End Function

    Private Sub LlenarComboParentescos()

        Dim oS2Credit As New ProcesosS2Credit
        Dim dtParentescos As DataTable

        dtParentescos = oS2Credit.ObtenerParentescos()

        With cmbParentesco

            .DataSource = dtParentescos
            .DropDownList.Columns.Add("id")
            .DropDownList.Columns.Add("value")
            .DropDownList.Columns("id").DataMember = "id"
            .DropDownList.Columns("value").DataMember = "value"
            .DropDownList.Columns("value").Width = 220

            .DropDownList.Columns("id").Visible = False

            .DisplayMember = "value"
            .ValueMember = "id"

            .Refresh()

        End With

    End Sub

    Private Sub RegresarInformacion()

        If ValidarDatos() Then
            DatosBeneficiario = New Dictionary(Of String, Object)
            DatosBeneficiario.Add("Nombres", Me.ebNombres.Text.TrimEnd)
            DatosBeneficiario.Add("ApellidoPaterno", Me.ebApellidoPaterno.Text.TrimEnd)
            DatosBeneficiario.Add("ApellidoMaterno", Me.ebApellidoMaterno.Text.TrimEnd)
            DatosBeneficiario.Add("ParentescoID", Me.cmbParentesco.Value)
            DatosBeneficiario.Add("Parentesco", Me.cmbParentesco.Text)
            Me.Close()
        Else
            DatosBeneficiario = Nothing
        End If

    End Sub

#End Region

#Region "Eventos"

    Private Sub frmBeneficiarioS2Credit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicializar()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        RegresarInformacion()
    End Sub

#End Region

End Class