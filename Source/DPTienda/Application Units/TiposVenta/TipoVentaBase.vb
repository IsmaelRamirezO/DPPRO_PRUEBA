Public Class TipoVentaBase

    Protected strID As String
    Protected strDescription As String

    Private dtTable As DataTable

    Public Sub New()
        strID = String.Empty
        strDescription = String.Empty
    End Sub

    Public ReadOnly Property ID() As String
        Get
            Return strID
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return strDescription
        End Get
    End Property

    Public Function GetFormasPagoList() As DataSet

        Dim dsData As New DataSet("TiposVenta")
        dtTable = New DataTable("FormasPago")

        Dim dcID As New DataColumn("ID", GetType(System.String))
        Dim dcDescription As New DataColumn("Description", GetType(System.String))

        dtTable.Columns.Add(dcID)
        dtTable.Columns.Add(dcDescription)

        dsData.Tables.Add(dtTable)

        FillFormasPagoList()

        dsData.AcceptChanges()

        dtTable = Nothing
        Return dsData

    End Function

    Protected Overridable Sub FillFormasPagoList()

    End Sub

    Protected Sub AddFormaPagoToList(ByVal FormaPago As FormaPagoBase)

        Dim drRow As DataRow

        drRow = dtTable.NewRow

        drRow("ID") = FormaPago.ID
        drRow("Description") = FormaPago.Description

        dtTable.Rows.Add(drRow)

    End Sub

End Class






