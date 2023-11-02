Imports System.Collections.Generic

Public Class frmCodigosPostalesS2Credit

    Public Sub New(ByVal CodigoPostal As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        oCodigoPostal = CodigoPostal
        Inicializar()

    End Sub

#Region "Variables"

    Private oS2Credit As New ProcesosS2Credit
    Private oCodigoPostal As String = String.Empty
    Private dtSepomex As DataTable

    Public oDatosSepomex As Dictionary(Of String, Object)

#End Region

#Region "Metodos y Funciones"

    Private Sub Inicializar()

        If oCodigoPostal.Trim <> String.Empty Then
            Me.ebCP.Text = oCodigoPostal
            dtSepomex = oS2Credit.ConsultarCodigoPostal(oCodigoPostal)
            Me.gSepomex.DataSource = dtSepomex
        End If

    End Sub

    Private Sub VerCiudadEstado()

        If Not Me.dtSepomex Is Nothing AndAlso Me.dtSepomex.Rows.Count > 0 Then
            Dim dtConfigSuc As DataTable
            Dim gxRow As Janus.Windows.GridEX.GridEXRow
            gxRow = Me.gSepomex.GetRow
            If Not gxRow Is Nothing Then
                Me.ebCiudad.Text = CStr(gxRow.Cells("city").Value.ToString)
                Me.ebEstado.Text = CStr(gxRow.Cells("state").Value.ToString)
            Else
                Me.ebCiudad.Text = String.Empty
                Me.ebEstado.Text = String.Empty
            End If
        Else
            Me.dtSepomex = Nothing
            Me.gSepomex.DataSource = Me.dtSepomex
        End If

    End Sub

    Private Sub RegresarInformacion()

        oDatosSepomex = New Dictionary(Of String, Object)

        If Not Me.dtSepomex Is Nothing AndAlso Me.dtSepomex.Rows.Count > 0 Then
            Dim dtConfigSuc As DataTable
            Dim gxRow As Janus.Windows.GridEX.GridEXRow
            gxRow = Me.gSepomex.GetRow
            If Not gxRow Is Nothing Then
                oDatosSepomex.Add("CodigoPostal", CStr(gxRow.Cells("zipcode").Value.ToString))
                oDatosSepomex.Add("Colonia", CStr(gxRow.Cells("neighborhood").Value.ToString))
                oDatosSepomex.Add("Ciudad", CStr(gxRow.Cells("settlement").Value.ToString))
                oDatosSepomex.Add("Estado", CStr(gxRow.Cells("state").Value.ToString))
            Else
                oDatosSepomex = Nothing
            End If
        Else
            oDatosSepomex = Nothing
        End If

        Me.Close()

    End Sub

#End Region

#Region "Eventos"

    Private Sub ebCP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ebCP.Validating
        If Me.ebCP.Text.Trim <> String.Empty Then
            Me.dtSepomex = oS2Credit.ConsultarCodigoPostal(Me.ebCP.Text)
            Me.gSepomex.DataSource = Me.dtSepomex
        Else
            Me.dtSepomex = Nothing
            Me.gSepomex.DataSource = Me.dtSepomex
        End If
    End Sub

    Private Sub frmCodigosPostalesS2Credit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub gSepomex_DoubleClick(sender As Object, e As System.EventArgs) Handles gSepomex.DoubleClick
        RegresarInformacion()
    End Sub

    Private Sub gSepomex_SelectionChanged(sender As Object, e As System.EventArgs) Handles gSepomex.SelectionChanged
        VerCiudadEstado()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        RegresarInformacion()
    End Sub

    Private Sub frmCodigosPostalesS2Credit_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        RegresarInformacion()
    End Sub

#End Region

End Class