Imports Janus.Windows.GridEX
Public Class AjustesESView
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim pdtAjustes As DataTable
        Dim pdaAjustes As SqlClient.SqlDataAdapter
        Dim pconBase As SqlClient.SqlConnection
        Dim pcmdAjustes As SqlClient.SqlCommand

        pconBase = New SqlClient.SqlConnection
        pcmdAjustes = New SqlClient.SqlCommand
        pdaAjustes = New SqlClient.SqlDataAdapter
        pdtAjustes = New DataTable

        pconBase.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        pconBase.Open()
        pcmdAjustes.Connection = pconBase
        pcmdAjustes.CommandText = "SELECT Folio,Fecha,Usuario,TipoMov,Almacen FROM AjustesEntrada ORDER BY Folio;"
        pdaAjustes.SelectCommand = pcmdAjustes
        pdaAjustes.Fill(pdtAjustes)
        pdtAjustes.TableName = "Ajustes"
        TargetGridEx.SetDataBinding(pdtAjustes, "")
        TargetGridEx.RetrieveStructure()
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Ajustes")
            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Width = 50

            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd/MM/yyyy"

            .Columns("Usuario").Caption = "Usuario"
            .Columns("Usuario").Width = 70

            .Columns("TipoMov").Caption = "Tipo de Movimiento"
            .Columns("TipoMov").Width = 50

            .Columns("Almacen").Caption = "Almacen"
            .Columns("Almacen").Width = 50
        End With
    End Sub
End Class
