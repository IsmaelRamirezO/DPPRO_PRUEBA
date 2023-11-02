Public Class TiposVenta

    Private Shared oPublicoGeneral As TipoVentaBase
    Private Shared oDPVale As TipoVentaBase
    Private Shared oAsociado As TipoVentaAsociado
    Private Shared oAsociadoCredito As TipoVentaAsociadoCredito
    Private Shared oDPSocio As TipoVentaDPSocio
    Private Shared oFonacot As TipoVentaFonacot
    Private Shared oFacilito As TipoVentaFacilito
    Private Shared oMayoreo As TipoVentaMayoreo

    Shared Sub New()
        oPublicoGeneral = New TipoVentaPublicoGeneral
        oDPVale = New TipoVentaDPVale
        oAsociado = New TipoVentaAsociado
        oAsociadoCredito = New TipoVentaAsociadoCredito
        oDPSocio = New TipoVentaDPSocio
        oFonacot = New TipoVentaFonacot
        oFacilito = New TipoVentaFacilito
        oMayoreo = New TipoVentaMayoreo
    End Sub

    Public Shared ReadOnly Property PublicoGeneral() As TipoVentaPublicoGeneral
        Get
            Return oPublicoGeneral
        End Get
    End Property

    Public Shared ReadOnly Property DPVale() As TipoVentaDPVale
        Get
            Return oDPVale
        End Get
    End Property

    Public Shared ReadOnly Property Asociado() As TipoVentaAsociado
        Get
            Return oAsociado
        End Get
    End Property

    Public Shared ReadOnly Property AsociadoCredito() As TipoVentaAsociadoCredito
        Get
            Return oAsociadoCredito
        End Get
    End Property

    Public Shared ReadOnly Property DPSocio() As TipoVentaDPSocio
        Get
            Return oDPSocio
        End Get
    End Property

    Public Shared ReadOnly Property Fonacot() As TipoVentaFonacot
        Get
            Return oFonacot
        End Get
    End Property

    Public Shared ReadOnly Property Facilito() As TipoVentaFacilito
        Get
            Return oFacilito
        End Get
    End Property

    Public Shared ReadOnly Property Mayoreo() As TipoVentaMayoreo
        Get
            Return oMayoreo
        End Get
    End Property



    Public Shared Function GetList() As DataSet

        Dim dsData As New DataSet("TiposVenta")
        Dim dtTable As New DataTable("TiposVenta")

        Dim dcID As New DataColumn("ID", GetType(System.String))
        Dim dcDescription As New DataColumn("Description", GetType(System.String))

        dtTable.Columns.Add(dcID)
        dtTable.Columns.Add(dcDescription)

        dsData.Tables.Add(dtTable)

        AddTipoVentaToList(dtTable, oPublicoGeneral)
        AddTipoVentaToList(dtTable, oDPVale)
        AddTipoVentaToList(dtTable, oAsociado)
        AddTipoVentaToList(dtTable, oAsociadoCredito)
        AddTipoVentaToList(dtTable, oDPSocio)
        AddTipoVentaToList(dtTable, oFonacot)
        AddTipoVentaToList(dtTable, oFacilito)
        AddTipoVentaToList(dtTable, oMayoreo)

        dsData.AcceptChanges()

        Return dsData

    End Function

    Private Shared Sub AddTipoVentaToList(ByVal Table As DataTable, ByVal TipoVenta As TipoVentaBase)

        Dim drRow As DataRow

        drRow = Table.NewRow

        drRow("ID") = TipoVenta.ID
        drRow("Description") = TipoVenta.Description

        Table.Rows.Add(drRow)

    End Sub

End Class