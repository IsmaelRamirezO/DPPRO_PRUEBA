Public Class FormasPago

    Private Shared oEfectivo As FormaPagoEfectivo
    Private Shared oTarjetaCredito As FormaPagoTarjetaCredito
    Private Shared oTarjetaDebito As FormaPagoTarjetaDebito

#Region "Properties"
    'Public Shared ReadOnly Property () As FormaPago

    Public Shared ReadOnly Property Efectivo() As FormaPagoEfectivo
        Get
            Return oEfectivo
        End Get
    End Property

    Public Shared ReadOnly Property TarjetaCredito() As FormaPagoTarjetaCredito
        Get
            Return oTarjetaCredito
        End Get
    End Property

    Public Shared ReadOnly Property TarjetaDebito() As FormaPagoTarjetaDebito
        Get
            Return oTarjetaDebito
        End Get
    End Property

#End Region

#Region "Constructors / Destructors"

    Shared Sub New()

        oEfectivo = New FormaPagoEfectivo
        oTarjetaCredito = New FormaPagoTarjetaCredito
        oTarjetaDebito = New FormaPagoTarjetaDebito

    End Sub

#End Region

#Region "Methods"

    Public Shared Function GetList() As DataSet

        Dim dsData As New DataSet("FormasPago")
        Dim dtTable As New DataTable("FormasPago")

        Dim dcID As New DataColumn("ID", GetType(System.String))
        Dim dcDescription As New DataColumn("Description", GetType(System.String))

        dtTable.Columns.Add(dcID)
        dtTable.Columns.Add(dcDescription)

        dsData.Tables.Add(dtTable)

        AddTipoVentaToList(dtTable, oEfectivo)
        'AddTipoVentaToList(dtTable, oTarjetaCredito)
        AddTipoVentaToList(dtTable, oTarjetaDebito)

        dsData.AcceptChanges()

        Return dsData

    End Function

    Private Shared Sub AddTipoVentaToList(ByVal Table As DataTable, ByVal FormaPago As FormaPagoBase)

        Dim drRow As DataRow

        drRow = Table.NewRow

        drRow("ID") = FormaPago.ID
        drRow("Description") = FormaPago.Description

        Table.Rows.Add(drRow)

    End Sub

#End Region

End Class
